# 病患管理系統 - 功能說明

## 專案概述

這是一個全端病患管理系統，包含病患列表展示和醫囑（Order）管理功能。

## 技術架構

### 前端

- **框架**: React 18
- **狀態管理**: React Hooks (useState, useEffect)
- **UI 框架**: Material-UI v5
- **HTTP 客戶端**: Axios
- **建構工具**: React Scripts

### 後端

- **框架**: .NET 6+
- **架構模式**: CQRS (MediatR)
- **資料庫**: PostgreSQL
- **API 模式**: RESTful API

## 主要功能

### 1. 病患列表 (Patient List)

**位置**: 主頁面
**元件**: `PatientList.js`

**功能特點**:

- 顯示所有病患資訊
- 每個病患卡片顯示：
  - 病患姓名
  - 病患 ID
  - 醫囑數量（以 Chip 顯示）
- 點擊病患卡片開啟醫囑對話框
- 使用 Material-UI 的 Paper 和 List 元件
- 響應式設計，支援不同裝置

### 2. 醫囑對話框 (Orders Dialog)

**位置**: 點擊病患後彈出
**元件**: `OrdersDialog.js`

**功能特點**:

- 顯示選中病患的所有醫囑
- 對話框標題顯示病患姓名
- 右上角新增按鈕（+ 圖示）
- 每筆醫囑顯示：
  - 醫囑內容
  - 醫囑 ID
  - 編輯按鈕
- 無醫囑時顯示提示訊息

### 3. 新增醫囑 (Add Order)

**觸發**: 點擊對話框右上角的 + 按鈕

**流程**:

1. 顯示新增醫囑表單
2. 輸入醫囑內容（支援多行）
3. 點擊「儲存」按鈕提交
4. 可以點擊「取消」取消新增
5. 成功後顯示成功通知
6. 自動重新載入病患資料

**驗證**:

- 不允許空白內容
- 表單會自動聚焦

### 4. 編輯醫囑 (Edit Order)

**觸發**: 點擊醫囑項目的編輯按鈕

**流程**:

1. 醫囑項目轉換為編輯模式
2. 顯示文字輸入框，預填原內容
3. 可修改內容（支援多行）
4. 點擊「儲存」提交更新
5. 可點擊「取消」取消編輯
6. 成功後顯示成功通知
7. 自動重新載入病患資料

**特點**:

- 編輯時背景色變化以示區別
- 每次只能編輯一筆醫囑
- 即時更新 UI

### 5. 通知系統 (Snackbar)

**位置**: 螢幕底部中央

**類型**:

- 成功通知（綠色）：操作成功
- 錯誤通知（紅色）：操作失敗

**訊息**:

- "載入病患資料失敗"
- "醫囑新增成功"
- "新增醫囑失敗"
- "醫囑更新成功"
- "更新醫囑失敗"

### 6. 載入狀態 (Loading State)

- 初始載入時顯示轉圈動畫
- 使用 Material-UI 的 CircularProgress
- 在漸層背景上使用白色轉圈圖示

## API 端點

### GET /api/v1/patient

取得所有病患及其醫囑

**回應格式**:

```json
{
  "data": {
    "patients": [
      {
        "patientId": 1,
        "name": "Peter",
        "orders": [
          {
            "orderId": 1,
            "message": "X光檢查"
          }
        ]
      }
    ]
  },
  "code": 200
}
```

### POST /api/v1/patient/{patientId}/order/add

新增醫囑到指定病患

**請求格式**:

```json
{
  "message": "新的醫囑內容"
}
```

### PATCH /api/v1/patient/{patientId}/order/{orderId}/modify

修改指定醫囑

**請求格式**:

```json
{
  "message": "更新後的醫囑內容"
}
```

## 狀態管理

### App.js 主要狀態

```javascript
const [patients, setPatients] = useState([]);           // 病患列表
const [selectedPatient, setSelectedPatient] = useState(null);  // 選中的病患
const [dialogOpen, setDialogOpen] = useState(false);    // 對話框開關
const [loading, setLoading] = useState(true);           // 載入狀態
const [snackbar, setSnackbar] = useState({...});        // 通知狀態
```

### OrdersDialog.js 主要狀態

```javascript
const [editingOrderId, setEditingOrderId] = useState(null); // 正在編輯的醫囑 ID
const [editMessage, setEditMessage] = useState(''); // 編輯中的訊息
const [newOrderMessage, setNewOrderMessage] = useState(''); // 新增醫囑的訊息
const [isAddingOrder, setIsAddingOrder] = useState(false); // 是否正在新增
```

## UI/UX 設計重點

### 視覺設計

- 漸層背景（紫色漸層）
- 白色文字標題
- Material Design 風格
- 卡片式布局
- 圖示輔助識別

### 互動設計

- Hover 效果提示可點擊
- 即時回饋（通知）
- 載入狀態提示
- 表單驗證
- 錯誤處理

### 響應式設計

- 使用 Container maxWidth="md"
- Flexbox 布局
- 適配不同螢幕尺寸

## 資料流程

1. **初始載入**
   - useEffect 觸發
   - 呼叫 loadPatients()
   - 設定 loading 狀態
   - 更新 patients 狀態

2. **查看醫囑**
   - 點擊病患
   - 設定 selectedPatient
   - 開啟 dialog

3. **新增醫囑**
   - 開啟新增表單
   - 輸入內容
   - 提交到 API
   - 重新載入資料
   - 更新 selectedPatient

4. **編輯醫囑**
   - 進入編輯模式
   - 修改內容
   - 提交到 API
   - 重新載入資料
   - 更新 selectedPatient

## 錯誤處理

- 所有 API 呼叫都包含 try-catch
- 錯誤會 console.error 記錄
- 顯示使用者友善的錯誤訊息
- 不會因錯誤而中斷應用程式

## 程式碼結構

```
src/frontend/src/
├── App.js                 # 主應用程式，包含狀態管理和業務邏輯
├── App.css                # 全域樣式
├── components/
│   ├── PatientList.js     # 病患列表元件（展示型元件）
│   └── OrdersDialog.js    # 醫囑對話框元件（展示型元件）
└── services/
    └── api.js             # API 呼叫封裝
```

## 設計模式

- **容器/展示元件模式**: App.js 是容器元件，PatientList 和 OrdersDialog 是展示元件
- **服務層模式**: API 呼叫封裝在獨立的 services 資料夾
- **單一職責原則**: 每個元件專注於一個功能
- **狀態提升**: 狀態管理集中在 App.js

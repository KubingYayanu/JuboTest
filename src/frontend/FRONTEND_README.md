# 前端專案說明

## 專案結構

```
src/frontend/
  ├── public/               # 靜態資源
  └── src/
      ├── components/       # React 元件
      │   ├── PatientList.js      # 病患列表元件
      │   └── OrdersDialog.js     # 醫囑對話框元件
      ├── services/         # API 服務層
      │   └── api.js              # API 呼叫函式
      ├── App.js            # 主應用程式元件
      ├── App.css           # 主樣式檔
      └── index.js          # 入口檔案
```

## 技術棧

- **React 18+** - 使用 Hooks (useState, useEffect)
- **Material-UI v5** - UI 元件函式庫
- **Axios** - HTTP 客戶端
- **React Scripts** - 建構工具

## 功能實作

### 1. 病患列表 (PatientList.js)

- 顯示所有病患
- 顯示每個病患的醫囑數量
- 點擊病患開啟醫囑對話框

### 2. 醫囑對話框 (OrdersDialog.js)

- 顯示選中病患的所有醫囑
- 新增醫囑功能（右上角 + 按鈕）
- 編輯醫囑功能（每筆醫囑的編輯按鈕）
- 即時儲存更新

### 3. API 服務層 (api.js)

- `getAllPatients()` - 取得所有病患
- `addOrderToPatient(patientId, message)` - 新增醫囑
- `modifyPatientOrder(patientId, orderId, message)` - 修改醫囑

## 安裝與執行

### 安裝相依套件

```bash
cd src/frontend
npm install
```

### 啟動開發伺服器

```bash
npm start
```

應用程式將在 http://localhost:3000 開啟

## API 端點

後端 API 需要在 http://localhost:18886 執行

- `GET /api/v1/patient` - 取得病患列表
- `POST /api/v1/patient/{patientId}/order/add` - 新增醫囑
- `PATCH /api/v1/patient/{patientId}/order/{orderId}/modify` - 修改醫囑

## 狀態管理

使用 React Hooks 進行狀態管理：

- `useState` - 管理本地狀態（病患列表、對話框開關、表單資料等）
- `useEffect` - 處理副作用（載入資料）

## UI 設計

- 使用 Material-UI 元件確保一致性和美觀
- 漸層背景提供現代感
- 響應式設計，適配不同螢幕尺寸
- 使用 Snackbar 提供操作回饋

## 注意事項

1. 確保後端 API 已啟動並加上 CORS 設定
2. API 基礎 URL 設定在 `services/api.js` 中
3. 所有 API 呼叫都包含錯誤處理

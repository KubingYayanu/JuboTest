@echo off
echo ========================================
echo   啟動前端應用程式
echo ========================================
echo.
cd /d "./src/frontend"
if not exist node_modules (
    echo 正在安裝相依套件...
    call npm install
)
echo.
echo 前端將在 http://localhost:3000 開啟
echo.
npm start



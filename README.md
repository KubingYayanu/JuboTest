# README

- `https://docs.google.com/document/d/1sAmgxU690KNfm8VdILZwRYfseE1D2IO7ACw0tBLQHGE/edit?tab=t.0`

# Docker 環境建置

```shell
$ docker compose -p jubo-test up -d

$ docker compose -p jubo-test stop

# 移除並刪除 volume
$ docker compose -p jubo-test down -v
```

# 啟動應用程式

前端將在 http://localhost:3000 開啟
後端 API 運行在 http://localhost:18886

## 1. 啟動後端 API

```shell
$ ./watch-api.bat
```

## 2. 啟動前端

```shell
$ ./start-frontend.bat
```

# API 端點

```shell
# Get patient list
$ curl http://localhost:18886/api/v1/patient

# Add patient order
$ curl -X POST http://localhost:18886/api/v1/patient/1/order/add \
  -H "Content-Type: application/json" \
  -d '{
        "message": "test a"
      }'

# Modify patient order
$ curl -X Patch http://localhost:18886/api/v1/patient/1/order/1/modify \
  -H "Content-Type: application/json" \
  -d '{
        "message": "update test a"
      }'
```

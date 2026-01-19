# README

# Docker 環境建置

```shell
$ docker compose -p jubo-test up -d

$ docker compose -p jubo-test stop

# 移除並刪除 volume
$ docker compose -p jubo-test down -v
```

# API

```shell
# 啟動 API
$ ./watch-api.bat

# 停止 API
$ ./kill-watch-api.bat

# Get patient list
$ curl http://localhost:18886/api/v1/patient

# Add patient order
$ curl -X POST http://localhost:18886/api/v1/patient/1/order/add \
  -H "Content-Type: application/json" \
  -d '{
        "message": "test a"
      }'
```
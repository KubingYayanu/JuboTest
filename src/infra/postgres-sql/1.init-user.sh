#!/bin/bash
# 建立 jubo User
set -e

cd /docker-entrypoint-initdb.d
psql -v ON_ERROR_STOP=1 -U postgres <<-EOSQL
CREATE USER $POSTGRES_INITDB_USERNAME with encrypted password '$POSTGRES_INITDB_PASSWORD';
EOSQL

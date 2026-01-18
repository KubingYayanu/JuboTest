#!/bin/bash
# 建立 DB 和 Tables
set -e

cd /docker-entrypoint-initdb.d

# medical
psql -v ON_ERROR_STOP=1 -U postgres -f sql/medical/2.1.db.sql
psql -v ON_ERROR_STOP=1 -U jubo medical -f sql/medical/2.2.patient.sql
psql -v ON_ERROR_STOP=1 -U jubo medical -f sql/medical/2.3.patient_order.sql
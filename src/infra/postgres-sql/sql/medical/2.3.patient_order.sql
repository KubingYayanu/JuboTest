/*
建立 patient_order Tables
*/
DO $$
BEGIN
    RAISE NOTICE 'SET patient_order Tables BEGIN';

    CREATE TABLE patient_order (
        patient_order_id   serial          NOT NULL PRIMARY KEY,
        patient_id         integer         NOT NULL REFERENCES patient (patient_id),
        message            varchar(500)    NOT NULL,
        created_time       timestamptz     NOT NULL DEFAULT CURRENT_TIMESTAMP,
        updated_time       timestamptz     NOT NULL
    );

    CREATE INDEX IF NOT EXISTS patient_order_idx1
        ON patient_order (patient_id ASC);

    RAISE NOTICE 'SET patient_order Tables END';
END;
$$ LANGUAGE plpgsql;

/*
建立 patient_order Tables 資料
*/
DO $$
DECLARE
    _patientA varchar(64) = 'Perter';
    _patientB varchar(64) = 'Mary';
BEGIN
    RAISE NOTICE 'SET patient_order Tables Data BEGIN';

    INSERT INTO patient_order
        (patient_id, message, updated_time)
    VALUES
        ((SELECT patient_id FROM patient WHERE name = _patientA), '血液檢查', CURRENT_TIMESTAMP),
        ((SELECT patient_id FROM patient WHERE name = _patientA), 'X光檢查', CURRENT_TIMESTAMP),
        ((SELECT patient_id FROM patient WHERE name = _patientB), '心電圖檢查', CURRENT_TIMESTAMP);

    RAISE NOTICE 'SET patient_order Tables Data END';
END;
$$ LANGUAGE plpgsql;
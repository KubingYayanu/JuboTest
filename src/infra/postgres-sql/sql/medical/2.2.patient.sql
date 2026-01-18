/*
建立 patient Tables
*/
DO $$
BEGIN
    RAISE NOTICE 'SET patient Tables BEGIN';

    CREATE TABLE patient (
        patient_id         serial          NOT NULL PRIMARY KEY,
        name               varchar(64)     NOT NULL,
        created_time       timestamptz     NOT NULL DEFAULT CURRENT_TIMESTAMP
    );

    RAISE NOTICE 'SET patient Tables END';
END;
$$ LANGUAGE plpgsql;

/*
建立 patient Tables 資料
*/
DO $$
BEGIN
    RAISE NOTICE 'SET patient Tables Data BEGIN';

    INSERT INTO patient
        (name)
	VALUES
        ('Perter'),
        ('Mary'),
        ('John'),
        ('Susan'),
        ('Tom');

    RAISE NOTICE 'SET patient Tables Data END';
END;
$$ LANGUAGE plpgsql;
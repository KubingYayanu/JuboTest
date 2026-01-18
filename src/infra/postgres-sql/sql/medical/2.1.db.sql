/*
建立 medical DB，並將 OWNER 設為 jubo
*/
DO $$
DECLARE
	_db_user varchar(50) = 'jubo';
BEGIN
	-- CREATE EXTENSION dblink
	IF NOT EXISTS (SELECT 1 FROM pg_extension WHERE extname = 'dblink') THEN
		CREATE EXTENSION dblink;
		RAISE NOTICE 'CREATE EXTENSION dblink DONE';
	END IF;

    -- CREATE DATABASE medical
	RAISE NOTICE 'SET medical DATABASE BEGIN';
	IF NOT EXISTS (SELECT 1 FROM pg_catalog.pg_database WHERE datname='medical') THEN
		PERFORM dblink_exec('dbname=' || current_database()
						, 'CREATE DATABASE medical WITH OWNER = ' || _db_user || ' ENCODING ''utf8''');
		RAISE NOTICE 'CREATE DATABASE DONE';
	END IF;
	ALTER DATABASE medical SET timezone TO 'Asia/Taipei';
	RAISE NOTICE 'SET medical DATABASE END';

END;
$$ LANGUAGE plpgsql;
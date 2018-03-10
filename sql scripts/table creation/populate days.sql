BEGIN TRAN

--clear the table

DELETE FROM dbo.t_days
--reseed
DBCC CHECKIDENT (t_days, reseed, 0)


DECLARE @tmp TABLE (
        day_text VARCHAR(15)
)

INSERT @tmp
          SELECT 'Monday'
UNION ALL SELECT 'Tuesday'
UNION ALL SELECT 'Wednesday'
UNION ALL SELECT 'Thursday'
UNION ALL SELECT 'Friday'
UNION ALL SELECT 'Saturday'
UNION ALL SELECT 'Sunday'


SELECT * FROM dbo.t_days

INSERT dbo.t_days(day_text, insert_user, insert_process, insert_datetime)

SELECT day_text, 'stanislavp', 'creation', GETDATE()
  FROM @tmp

SELECT * FROM dbo.t_days



--ROLLBACK

--COMMIT
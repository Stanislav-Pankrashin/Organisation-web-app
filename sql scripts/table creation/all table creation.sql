--this table holds simple information of a day
CREATE TABLE t_days (
             day_id          INT IDENTITY(1,1) PRIMARY KEY,
			 day_text        VARCHAR(15),
		     insert_user     VARCHAR(40),
		     insert_process  VARCHAR(40),
		     insert_datetime DATETIME,
		     update_user     VARCHAR(40),
		     update_process  VARCHAR(40),
		     update_datetime DATETIME,	
)
GO

--this table holds simple information on the half hours (This might not be strictly necesary)
CREATE TABLE t_half_hours(
             half_hour_id    INT IDENTITY(1,1) PRIMARY KEY,
			 half_hour_time  VARCHAR(10),                  
		     insert_user     VARCHAR(40),
		     insert_process  VARCHAR(40),
		     insert_datetime DATETIME,
		     update_user     VARCHAR(40),
		     update_process  VARCHAR(40),
		     update_datetime DATETIME,	
)
GO


--this table holds all of the group information
CREATE TABLE c_group (
		     group_id        INT IDENTITY(1,1) PRIMARY KEY,
		     group_name      VARCHAR(40) UNIQUE NOT NULL,
		     group_password  VARCHAR(50),
		     group_desc      VARCHAR(200),
		     insert_user     VARCHAR(40),
		     insert_process  VARCHAR(40),
		     insert_datetime DATETIME,
		     update_user     VARCHAR(40),
		     update_process  VARCHAR(40),
		     update_datetime DATETIME,		

)
GO

--this table holds information about the user
CREATE TABLE s_user(
			 user_id         INT IDENTITY(1,1) PRIMARY KEY,
			 --user_code       VARCHAR(20)        NOT NULL, --This seems unneeded
			 username        VARCHAR(40) UNIQUE NOT NULL,
			 password        VARCHAR(50)        NOT NULL,
		     insert_user     VARCHAR(40),
		     insert_process  VARCHAR(40),
		     insert_datetime DATETIME,
		     update_user     VARCHAR(40),
		     update_process  VARCHAR(40),
		     update_datetime DATETIME,		
)
GO

--this table holds the relationship between users and groups
CREATE TABLE c_group_relationship (
             relationship_id INT IDENTITY(1,1) PRIMARY KEY,
			 user_id         INT NOT NULL FOREIGN KEY REFERENCES dbo.s_user (user_id),
			 group_id        INT NOT NULL FOREIGN KEY REFERENCES dbo.c_group (group_id),
		     insert_user     VARCHAR(40),
		     insert_process  VARCHAR(40),
		     insert_datetime DATETIME,
		     update_user     VARCHAR(40),
		     update_process  VARCHAR(40),
		     update_datetime DATETIME,		
)
GO
CREATE INDEX I_c_group_relationship_user_id ON dbo.c_group_relationship (user_id)
CREATE INDEX I_c_group_relationship_group_id ON dbo.c_group_relationship (group_id)
GO

--this table holds user times
CREATE TABLE t_user_time(
             time_id            INT IDENTITY(1,1) PRIMARY KEY,
			 user_id            INT FOREIGN KEY REFERENCES dbo.s_user       (user_id),
			 day_id             INT FOREIGN KEY REFERENCES dbo.t_days       (day_id),
			 half_hour_id_start INT FOREIGN KEY REFERENCES dbo.t_half_hours (half_hour_id),
			 half_hour_id_end   INT FOREIGN KEY REFERENCES dbo.t_half_hours (half_hour_id),
		     insert_user        VARCHAR(40),
		     insert_process     VARCHAR(40),
		     insert_datetime    DATETIME,
		     update_user        VARCHAR(40),
		     update_process     VARCHAR(40),
		     update_datetime    DATETIME,	

)
GO
CREATE INDEX I_t_user_times_day_id       ON dbo.t_user_time (day_id)
CREATE INDEX I_t_user_times_half_hour_id_start ON dbo.t_user_time (half_hour_id_start)
GO


-- this table holds group times
CREATE TABLE t_group_time(
             time_id             INT IDENTITY(1,1) PRIMARY KEY,
			 group_id            INT FOREIGN KEY REFERENCES dbo.c_group      (group_id),
			 day_id              INT FOREIGN KEY REFERENCES dbo.t_days       (day_id),
			 half_hour_id_start  INT FOREIGN KEY REFERENCES dbo.t_half_hours (half_hour_id),
			 half_hour_id_end    INT FOREIGN KEY REFERENCES dbo.t_half_hours (half_hour_id),
		     insert_user         VARCHAR(40),
		     insert_process      VARCHAR(40),
		     insert_datetime     DATETIME,
		     update_user         VARCHAR(40),
		     update_process      VARCHAR(40),
		     update_datetime     DATETIME,	

)
GO
CREATE INDEX I_t_group_times_day_id             ON dbo.t_group_time (group_id)
CREATE INDEX I_t_group_times_half_hour_id_start ON dbo.t_group_time (half_hour_id_start)










SET XACT_ABORT ON

/*
This populates dummy data so that the api doesn't freak out
this is for testing
*/

BEGIN TRAN


INSERT c_group
(
group_name     
,group_password 
,group_desc     
,insert_user    
,insert_process 
,insert_datetime
)
SELECT 'test group',
       'test123',
	   'group for testing',
	   'stanislav',
	   'creation',
	   GETDATE()

INSERT s_user
(
username       
,password       
,insert_user    
,insert_process 
,insert_datetime
)
SELECT 'test_user',
       'test123',
	   'stanislav',
	   'creation',
	   GETDATE()


INSERT c_group_relationship
(
user_id         
,group_id        
,insert_user     
,insert_process  
,insert_datetime 
)
SELECT 1,
       1,
	   'stanislav',
	   'creation',
	   GETDATE()


INSERT t_times
(
day_id            
,half_hour_id_start
,half_hour_id_end  
,insert_user       
,insert_process    
,insert_datetime   
)
SELECT 1,
       1,
	   20,
	   'stanislav',
	   'creation',
	   GETDATE()

INSERT t_times
(
day_id            
,half_hour_id_start
,half_hour_id_end  
,insert_user       
,insert_process    
,insert_datetime   
)
SELECT 2,
       1,
	   20,
	   'stanislav',
	   'creation',
	   GETDATE()


INSERT c_user_calendar_entry
(
user_id         
,time_id         
,insert_user     
,insert_process  
,insert_datetime 
)
SELECT 1,
       1,
	   'stanislav',
	   'creation',
	   GETDATE()


INSERT c_group_calendar_entry
(
group_id         
,time_id         
,insert_user     
,insert_process  
,insert_datetime 
)
SELECT 1,
       2,
	   'stanislav',
	   'creation',
	   GETDATE()


ROLLBACK
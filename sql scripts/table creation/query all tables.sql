SELECT 's_user', * FROM s_user
SELECT 'c_group', * FROM c_group
SELECT 't_half_hours', * FROM t_half_hours
SELECT 't_days', * FROM t_days
SELECT 'c_group_relationship', * FROM c_group_relationship
SELECT 'c_user_calendar_entry', * FROM c_user_calendar_entry
SELECT 'c_group_calendar_entry', * FROM c_group_calendar_entry
SELECT 't_user_time', * FROM t_user_time
SELECT 't_group_time', * FROM t_group_time


SELECT u.username, 
       d.day_text,
	   t.half_hour_id_start,
	   t.half_hour_id_end
  FROM dbo.s_user               u
  JOIN dbo.c_group_relationship gr  ON u.user_id = gr.user_id
  JOIN dbo.c_group              g   ON gr.group_id = g.group_id
  JOIN c_user_calendar_entry    uce ON u.user_id = uce.user_id
  JOIN c_group_calendar_entry   gce ON g.group_id = gce.group_id
  JOIN t_times                  t   ON uce.time_id = t.time_id
                                    OR gce.time_id = t.time_id
  JOIN t_days                   d   ON t.day_id = d.day_id
  JOIN t_half_hours             hh  ON t.half_hour_id_start = hh.half_hour_id
                                    OR t.half_hour_id_end = hh.half_hour_id
  
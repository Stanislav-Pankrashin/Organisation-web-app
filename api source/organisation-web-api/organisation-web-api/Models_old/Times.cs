using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace organisation_web_api.Models_old
{
    [Table("dbo.t_times")]
    public class Times
    {
        [Key]
        public int time_id;
        public int day_id;
        public int half_hour_id_start;
        public int half_hour_id_end;
        public string insert_user;
        public string insert_process;
        public DateTime insert_datetime;
        public string update_user;
        public string update_process;
        public DateTime update_datetime;
    }
}
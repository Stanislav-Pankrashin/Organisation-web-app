using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace organisation_web_api.Models_old
{
    [Table("dbo.t_days")]
    public class Days
    {
        [Key]
        public int day_id;
        public string day_text;
        public string insert_user;
        public string insert_process;
        public DateTime insert_datetime;
        public string update_user;
        public string update_process;
        public string update_datetime;
    }
}
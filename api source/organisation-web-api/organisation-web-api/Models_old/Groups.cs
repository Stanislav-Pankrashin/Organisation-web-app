using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace organisation_web_api.Models_old
{   
    [Table("dbo.c_group")]
    public class Groups
    {   
        [Key]
        public int group_id;
        public string group_name;
        public string group_password;
        public string group_desc;
        public string insert_user;
        public string insert_process;
        public DateTime insert_datetime;
        public string update_user;
        public string update_process;
        public DateTime update_datetime;
    }
}
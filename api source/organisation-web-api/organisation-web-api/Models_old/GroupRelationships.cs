using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace organisation_web_api.Models_old
{
    [Table("dbo.c_group_relationship")]
    public class GroupRelationships
    {
        [Key]
        public int relationship_id;
        [ForeignKey("Users")]
        public int user_id;
        [ForeignKey("Groups")]
        public int group_id;
        public string insert_user;
        public string insert_process;
        public DateTime insert_datetime;
        public string update_user;
        public string update_process;
        public DateTime update_datetime;

        public Users User;
        public Groups Group;
    }
}
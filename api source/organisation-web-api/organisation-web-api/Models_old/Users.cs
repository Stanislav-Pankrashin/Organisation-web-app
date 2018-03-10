using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace organisation_web_api.Models_old
{
    [Table("dbo.s_user")]
    public class Users
    {
        
        public Users()
        {
            this.Groups = new HashSet<GroupRelationships>();
        }
        [Key]
        public int user_id;
        public string username;
        public string password;
        public string insert_user;
        public string insert_process;
        public DateTime insert_datetime;
        public string update_user;
        public string update_process;
        public DateTime update_datetime;

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GroupRelationships> Groups { get; set; }
    }
}
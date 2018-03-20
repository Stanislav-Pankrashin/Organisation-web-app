namespace organisation_web_api.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class c_group_calendar_entry
    {
        [Key]
        public int calendar_id { get; set; }

        public int group_id { get; set; }

        public int time_id { get; set; }

        [StringLength(40)]
        public string insert_user { get; set; }

        [StringLength(40)]
        public string insert_process { get; set; }

        public DateTime? insert_datetime { get; set; }

        [StringLength(40)]
        public string update_user { get; set; }

        [StringLength(40)]
        public string update_process { get; set; }

        public DateTime? update_datetime { get; set; }

        public virtual c_group c_group { get; set; }

        public virtual t_times t_times { get; set; }
    }
}
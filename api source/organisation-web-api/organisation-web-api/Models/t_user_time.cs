namespace organisation_web_api.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("dbo.t_user_time")]
    public class t_user_time
    {
        [Key] public int time_id { get; set; }

        public int? user_id { get; set; }

        public int? day_id { get; set; }

        public int? half_hour_id_start { get; set; }

        public int? half_hour_id_end { get; set; }

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

    }
}
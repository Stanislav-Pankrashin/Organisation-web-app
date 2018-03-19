namespace organisation_web_api.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class t_times
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public t_times()
        {
            c_group_calendar_entry = new HashSet<c_group_calendar_entry>();
            c_user_calendar_entry = new HashSet<c_user_calendar_entry>();
        }

        [Key]
        public int time_id { get; set; }

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

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<c_group_calendar_entry> c_group_calendar_entry { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<c_user_calendar_entry> c_user_calendar_entry { get; set; }

        public virtual t_days t_days { get; set; }

        public virtual t_half_hours t_half_hours { get; set; }

        public virtual t_half_hours t_half_hours1 { get; set; }
    }
}

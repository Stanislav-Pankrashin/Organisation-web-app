namespace organisation_web_api.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class t_half_hours
    {
        // [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        // public t_half_hours()
        // {
        //     c_group_calendar_entry = new HashSet<c_group_calendar_entry>();
        //     c_group_calendar_entry1 = new HashSet<c_group_calendar_entry>();
        //     c_user_calendar_entry = new HashSet<c_user_calendar_entry>();
        //     c_user_calendar_entry1 = new HashSet<c_user_calendar_entry>();
        //     t_times = new HashSet<t_times>();
        //     t_times1 = new HashSet<t_times>();
        // }

        [Key]
        public int half_hour_id { get; set; }

        [StringLength(10)]
        public string half_hour_time { get; set; }

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

        // [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        // public virtual ICollection<c_group_calendar_entry> c_group_calendar_entry { get; set; }
        // 
        // [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        // public virtual ICollection<c_group_calendar_entry> c_group_calendar_entry1 { get; set; }
        // 
        // [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        // public virtual ICollection<c_user_calendar_entry> c_user_calendar_entry { get; set; }
        // 
        // [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        // public virtual ICollection<c_user_calendar_entry> c_user_calendar_entry1 { get; set; }
        // 
        // [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        // public virtual ICollection<t_times> t_times { get; set; }
        // 
        // [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        // public virtual ICollection<t_times> t_times1 { get; set; }
    }
}

namespace organisation_web_api.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class c_group
    {
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        //public c_group()
        //{
        //    c_group_calendar_entry = new HashSet<c_group_calendar_entry>();
        //    c_group_relationship = new HashSet<c_group_relationship>();
        //}

        [Key]
        public int group_id { get; set; }

        [Required]
        [StringLength(40)]
        public string group_name { get; set; }

        [StringLength(50)]
        public string group_password { get; set; }

        [StringLength(200)]
        public string group_desc { get; set; }

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

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<c_group_calendar_entry> c_group_calendar_entry { get; set; }
        //
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<c_group_relationship> c_group_relationship { get; set; }
    }
}

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace organisation_web_api.Models_old
{
    [Table("dbo.t_half_hours")]
    public class HalfHours
    {   
        [Key]
        public int  half_hour_id { get; set; }
        public string   half_hour_time { get; set; }

    }
}
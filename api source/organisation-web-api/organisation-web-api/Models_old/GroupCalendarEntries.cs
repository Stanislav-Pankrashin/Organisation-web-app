using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace organisation_web_api.Models_old
{
    [Table("dbo.c_group_calendar_entry")]
    public class GroupCalendarEntries
    {   [Key]
        public int calendar_id;
        [ForeignKey("Groups")]
        public int group_id;
        [ForeignKey("HalfHours")]
        public int half_hour_id_start;
        [ForeignKey("HalfHours")]
        public int half_hour_id_end;
        public string insert_user;
        public string insert_process;
        public DateTime insert_datetime;
        public string update_user;
        public string update_process;
        public DateTime update_datetime;

        public Groups Group;
        public HalfHours HalfHourStart;
        public HalfHours HalfHourEnd;
    }
}
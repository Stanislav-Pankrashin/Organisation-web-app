namespace organisation_web_api.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Organisation_model : DbContext
    {
        public Organisation_model()
            : base("name=Organisation_Data_Connection")
        {
        }

        public virtual DbSet<c_group> c_group { get; set; }
        public virtual DbSet<c_group_calendar_entry> c_group_calendar_entry { get; set; }
        public virtual DbSet<c_group_relationship> c_group_relationship { get; set; }
        public virtual DbSet<c_user_calendar_entry> c_user_calendar_entry { get; set; }
        public virtual DbSet<s_user> s_user { get; set; }
        public virtual DbSet<t_days> t_days { get; set; }
        public virtual DbSet<t_half_hours> t_half_hours { get; set; }
        public virtual DbSet<t_times> t_times { get; set; }
        public virtual DbSet<t_user_time> t_user_time { get; set; }
        public virtual DbSet<t_group_time> t_group_time { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<c_group>()
            //    .Property(e => e.group_name)
            //    .IsUnicode(false);
            //
            //modelBuilder.Entity<c_group>()
            //    .Property(e => e.group_password)
            //    .IsUnicode(false);
            //
            //modelBuilder.Entity<c_group>()
            //    .Property(e => e.group_desc)
            //    .IsUnicode(false);
            //
            //modelBuilder.Entity<c_group>()
            //    .Property(e => e.insert_user)
            //    .IsUnicode(false);
            //
            //modelBuilder.Entity<c_group>()
            //    .Property(e => e.insert_process)
            //    .IsUnicode(false);
            //
            //modelBuilder.Entity<c_group>()
            //    .Property(e => e.update_user)
            //    .IsUnicode(false);
            //
            //modelBuilder.Entity<c_group>()
            //    .Property(e => e.update_process)
            //    .IsUnicode(false);
            //
            //modelBuilder.Entity<c_group>()
            //    .HasMany(e => e.c_group_calendar_entry)
            //    .WithRequired(e => e.c_group)
            //    .WillCascadeOnDelete(false);
            //
            //modelBuilder.Entity<c_group>()
            //    .HasMany(e => e.c_group_relationship)
            //    .WithRequired(e => e.c_group)
            //    .WillCascadeOnDelete(false);
            //
            //modelBuilder.Entity<c_group_calendar_entry>()
            //    .Property(e => e.insert_user)
            //    .IsUnicode(false);
            //
            //modelBuilder.Entity<c_group_calendar_entry>()
            //    .Property(e => e.insert_process)
            //    .IsUnicode(false);
            //
            //modelBuilder.Entity<c_group_calendar_entry>()
            //    .Property(e => e.update_user)
            //    .IsUnicode(false);
            //
            //modelBuilder.Entity<c_group_calendar_entry>()
            //    .Property(e => e.update_process)
            //    .IsUnicode(false);
            //
            //modelBuilder.Entity<c_group_relationship>()
            //    .Property(e => e.insert_user)
            //    .IsUnicode(false);
            //
            //modelBuilder.Entity<c_group_relationship>()
            //    .Property(e => e.insert_process)
            //    .IsUnicode(false);
            //
            //modelBuilder.Entity<c_group_relationship>()
            //    .Property(e => e.update_user)
            //    .IsUnicode(false);
            //
            //modelBuilder.Entity<c_group_relationship>()
            //    .Property(e => e.update_process)
            //    .IsUnicode(false);
            //
            //modelBuilder.Entity<c_user_calendar_entry>()
            //    .Property(e => e.insert_user)
            //    .IsUnicode(false);
            //
            //modelBuilder.Entity<c_user_calendar_entry>()
            //    .Property(e => e.insert_process)
            //    .IsUnicode(false);
            //
            //modelBuilder.Entity<c_user_calendar_entry>()
            //    .Property(e => e.update_user)
            //    .IsUnicode(false);
            //
            //modelBuilder.Entity<c_user_calendar_entry>()
            //    .Property(e => e.update_process)
            //    .IsUnicode(false);
            //
            //modelBuilder.Entity<s_user>()
            //    .Property(e => e.username)
            //    .IsUnicode(false);
            //
            //modelBuilder.Entity<s_user>()
            //    .Property(e => e.password)
            //    .IsUnicode(false);
            //
            //modelBuilder.Entity<s_user>()
            //    .Property(e => e.insert_user)
            //    .IsUnicode(false);
            //
            //modelBuilder.Entity<s_user>()
            //    .Property(e => e.insert_process)
            //    .IsUnicode(false);
            //
            //modelBuilder.Entity<s_user>()
            //    .Property(e => e.update_user)
            //    .IsUnicode(false);
            //
            //modelBuilder.Entity<s_user>()
            //    .Property(e => e.update_process)
            //    .IsUnicode(false);
            //
            //modelBuilder.Entity<s_user>()
            //    .HasMany(e => e.c_group_relationship)
            //    .WithRequired(e => e.s_user)
            //    .WillCascadeOnDelete(false);
            //
            //modelBuilder.Entity<s_user>()
            //    .HasMany(e => e.c_user_calendar_entry)
            //    .WithRequired(e => e.s_user)
            //    .WillCascadeOnDelete(false);
            //
            //modelBuilder.Entity<t_days>()
            //    .Property(e => e.day_text)
            //    .IsUnicode(false);
            //
            //modelBuilder.Entity<t_days>()
            //    .Property(e => e.insert_user)
            //    .IsUnicode(false);
            //
            //modelBuilder.Entity<t_days>()
            //    .Property(e => e.insert_process)
            //    .IsUnicode(false);
            //
            //modelBuilder.Entity<t_days>()
            //    .Property(e => e.update_user)
            //    .IsUnicode(false);
            //
            //modelBuilder.Entity<t_days>()
            //    .Property(e => e.update_process)
            //    .IsUnicode(false);
            //
            //modelBuilder.Entity<t_half_hours>()
            //    .Property(e => e.half_hour_time)
            //    .IsUnicode(false);
            //
            //modelBuilder.Entity<t_half_hours>()
            //    .Property(e => e.insert_user)
            //    .IsUnicode(false);
            //
            //modelBuilder.Entity<t_half_hours>()
            //    .Property(e => e.insert_process)
            //    .IsUnicode(false);
            //
            //modelBuilder.Entity<t_half_hours>()
            //    .Property(e => e.update_user)
            //    .IsUnicode(false);
            //
            //modelBuilder.Entity<t_half_hours>()
            //    .Property(e => e.update_process)
            //    .IsUnicode(false);
            //
            //modelBuilder.Entity<t_half_hours>()
            //    .HasMany(e => e.t_times)
            //    .WithOptional(e => e.t_half_hours)
            //    .HasForeignKey(e => e.half_hour_id_start);
            //
            //modelBuilder.Entity<t_half_hours>()
            //    .HasMany(e => e.t_times1)
            //    .WithOptional(e => e.t_half_hours1)
            //    .HasForeignKey(e => e.half_hour_id_end);
            //
            modelBuilder.Entity<t_times>()
                .Property(e => e.insert_user)
                .IsUnicode(false);
            
            modelBuilder.Entity<t_times>()
                .Property(e => e.insert_process)
                .IsUnicode(false);
            
            modelBuilder.Entity<t_times>()
                .Property(e => e.update_user)
                .IsUnicode(false);
            
            modelBuilder.Entity<t_times>()
                .Property(e => e.update_process)
                .IsUnicode(false);
            
            //modelBuilder.Entity<t_times>()
            //    .HasMany(e => e.c_group_calendar_entry)
            //    .WithRequired(e => e.t_times)
            //    .WillCascadeOnDelete(false);
            //
            //modelBuilder.Entity<t_times>()
            //    .HasMany(e => e.c_user_calendar_entry)
            //    .WithRequired(e => e.t_times)
            //    .WillCascadeOnDelete(false);
        }
    }
}

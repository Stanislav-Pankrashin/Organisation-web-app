using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using organisation_web_api.Models;
using organisation_web_api.Models_old;

namespace organisation_web_api.DAL
{
    public class DatabaseContext : DbContext
    {
        public DbSet<HalfHours> HalfHours { get; set; }

        public DatabaseContext() : base("MyDbConn") 
        {
        }

       

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingEntitySetNameConvention>();
        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using SeleniumPhanthomjs.Configuration;

namespace SeleniumPhanthomjs.Database
{
    public class BDContext : DbContext
    {

        public BDContext() : base("name=con")
        {

            this.Configuration.AutoDetectChangesEnabled = false;

        }


        public DbSet<StagingArea> StageTable { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Configurations.Add(new StagingAreaConfiguration());

            base.OnModelCreating(modelBuilder);
        }

    }
}

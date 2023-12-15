using FIADatabase.Areas.FIANCFiles.Modules;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace FIADatabase.Contexts
{
    public class FIANCFilesContext : DbContext
    {
        public FIANCFilesContext() : base("FIANCFilesConnection"){ }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); 
        }

        public DbSet<HVI> HVIs { get; set; }
        public DbSet<Shard> Shards { get; set; } 
        public DbSet<Prologue> Prologues { get; set; }
    }
}
using FIADatabase.Areas.FIAUsers.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace FIADatabase.Contexts
{
    public class FIAUsersContext : DbContext
    {
        public FIAUsersContext() : base("UsersConnection") { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); 
        }
        public DbSet<User> Users { get; set; }  
    }
}
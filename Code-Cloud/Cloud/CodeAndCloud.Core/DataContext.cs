using System;
using System.Collections.Generic;
using System.Text;
using CodeAndCloud.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace CodeAndCloud.Core
{
    public class DataContext : DbContext
    {
        public virtual DbSet<ContactModel> ContactModel { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=tcp:codeandcloudwarstaty4.database.windows.net,1433;Initial Catalog=testbase;Persist Security Info=False;User ID=wilkadmin;Password=qwertyuiop!2;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}

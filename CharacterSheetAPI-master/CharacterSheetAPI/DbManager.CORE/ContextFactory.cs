using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DbManager.CORE
{
    public class ContextFactory : IDesignTimeDbContextFactory<DbCharacterContext>
    {
       
        public DbCharacterContext CreateDbContext(string[] args)
        {
            string connectionString = "";
            using (StreamReader r = new StreamReader("appsettings.json"))
            {
                var json= r.ReadToEnd();
                var jobj = JObject.Parse(json);
                var item =jobj.Property("ConnectionStrings");
                var item2 = item.First();
                var item3 = item2["AzureConnection"];
                connectionString = item3.ToString();
            }

             
            var optionsBuilder = new DbContextOptionsBuilder<DbCharacterContext>();
            
            optionsBuilder.UseSqlServer(connectionString);

            return new DbCharacterContext(optionsBuilder.Options);
        }
    }
}

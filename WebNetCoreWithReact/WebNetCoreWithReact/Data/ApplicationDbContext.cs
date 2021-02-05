using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebNetCoreWithReact.Models;
using Microsoft.EntityFrameworkCore;

namespace WebNetCoreWithReact.Data
{
    public class ApplicationDbContext: DbContext
    {

        public DbSet<Daprt> Daprts { get; set; }

        public ApplicationDbContext(): base()
        {

        }
        public ApplicationDbContext(DbContextOptions options): base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //use the connection string provided in the appsettings.{Environment}.json file
            if (!optionsBuilder.IsConfigured)
            {

            optionsBuilder.UseSqlServer(@"Server=.\\SQLEXPRESS;Database=RaectAPI;Trusted_Connection=True;");
            }

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.Entity<Daprt>().HasData(new Daprt { DepartNumber = 1, Departname = "Sofia",Locations ="Airport Terminal 1" });
            builder.Entity<Daprt>().HasData(new Daprt { DepartNumber = 2, Departname = "Sofia", Locations ="Airport Terminal 2" });
            builder.Entity<Daprt>().HasData(new Daprt { DepartNumber = 3, Departname = "Plovdiv", Locations ="Novotel" });
            builder.Entity<Daprt>().HasData(new Daprt { DepartNumber = 4, Departname = "Stara Zagora", Locations ="Stadium Beroe" });
            builder.Entity<Daprt>().HasData(new Daprt { DepartNumber = 5, Departname = "Shumen",Locations ="Post Office" });
            builder.Entity<Daprt>().HasData(new Daprt { DepartNumber = 6, Departname = "Burgas",Locations ="Post Office" });
            builder.Entity<Daprt>().HasData(new Daprt { DepartNumber = 7, Departname = "Varna",Locations ="Dolphinarium" });
            builder.Entity<Daprt>().HasData(new Daprt { DepartNumber = 8, Departname = "Pleven",Locations = "Hotel Bulgaria" });
            builder.Entity<Daprt>().HasData(new Daprt { DepartNumber = 9, Departname = "Sozopol",Locations = "Old City Post Office" });
            builder.Entity<Daprt>().HasData(new Daprt { DepartNumber = 10, Departname = "Lovech", Locations ="Varosha Gallery" });
        }

        }
}

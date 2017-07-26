namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using WebApplication1.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<WebApplication1.Migrations.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(WebApplication1.Migrations.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            context.Employees.AddOrUpdate(
              p => p.EmployeeId,
              new Employee
                {
                  EmployeeId = 1,
                  City ="Kato",
                  Gender = (Sex)1,
                  Name = "Dori"                  
                },
              new Employee
              {
                  EmployeeId = 2,
                  City = "Sosnowiec",
                  Gender = (Sex)0,
                  Name = "Andrzej"
              }, 
              new Employee
              {
                  EmployeeId = 3,
                  City = "Warszawa",
                  Gender = (Sex)0,
                  Name = "Tomasz"
              });

        }
    }
}

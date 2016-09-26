namespace Dnp.Kanban.SqlRepository.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Dnp.Kanban.SqlRepository.KanbanDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Migrations";
        }

        protected override void Seed(Dnp.Kanban.SqlRepository.KanbanDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            context.DbPriority.AddOrUpdate(p => p.Name,
              new DbPriority { Name = "Critical" },
              new DbPriority { Name = "High" },
              new DbPriority { Name = "Medium" },
              new DbPriority { Name = "Low" });
        }
    }
}

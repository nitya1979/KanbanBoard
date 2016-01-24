using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dnp.Kanban.SqlRepository
{
    public class KanbanDbContext : DbContext
    {
        static KanbanDbContext()
        {
            Database.SetInitializer<KanbanDbContext>(null);
        }

        public KanbanDbContext() : base("DefaultConnection")
        { }

        public KanbanDbContext(string connectionName_)
            :base(connectionName_)
        { }

        public DbSet<DbProject> DbProjects { get; set; }

        public DbSet<DbProjectStage> DbProjectStage { get; set; }
    }
}

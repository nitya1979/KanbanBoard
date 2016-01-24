using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dnp.Kanban.Domain;

namespace Dnp.Kanban.SqlRepository
{
    public class SqlProjectRepository : IProjectRepository
    {
        public SqlProjectRepository(string defaultConnection)
        {

        }

        public List<Project> GetProjectList()
        {
            throw new NotImplementedException();
        }
    }
}

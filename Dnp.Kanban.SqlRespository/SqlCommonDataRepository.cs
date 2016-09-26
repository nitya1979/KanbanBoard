using AutoMapper;
using Dnp.Kanban.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dnp.Kanban.SqlRepository
{
    public class SqlCommonDataRepository : ICommonDataRepository
    {
        KanbanDbContext _kanbanContext = null;

        public SqlCommonDataRepository(string defaultConnection)
        {
            _kanbanContext = new KanbanDbContext(defaultConnection);
        }

        public async Task<List<DnpPriority>> GetPriorities()
        {
            return await Task.Factory.StartNew<List<DnpPriority>>(() =>
            {
                var pList = _kanbanContext.DbPriority.ToListAsync();

                List<DnpPriority> list = new List<DnpPriority>();
                foreach(DbPriority p in pList.Result)
                {
                    list.Add(Mapper.Map<DnpPriority>(p));
                }

                return list;
            });

        }
    }
}

using AutoMapper;
using Dnp.Kanban.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dnp.Kanban.SqlRepository
{
    public static class MapperSetup
    {
        public static void InitializeMapper()
        {
            
            Mapper.Initialize(cnfg =>
            {
                cnfg.CreateMap<DbProject, Project>();
                cnfg.CreateMap<DbProjectStage, ProjectStage>();

                cnfg.CreateMap<Project, DbProject>();
                cnfg.CreateMap<ProjectStage, DbProjectStage>();

                cnfg.CreateMap<DnpTask, DbTask>();
                cnfg.CreateMap<DbTask, DnpTask>();

            });
        }
    }
}

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
            Mapper.CreateMap<DbProject, Project>();
            Mapper.CreateMap<DbProjectStage, ProjectStage>();

            Mapper.CreateMap<Project, DbProject>();
            Mapper.CreateMap<ProjectStage, DbProjectStage>();
        }
    }
}

using AutoMapper;
using Dnp.Kanban.Domain;
using Dnp.Kanban.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dnp.Kanban.Web
{
    public static class AutoMapperConfig
    {
        public static void Setup()
        {
            Mapper.Configuration.CreateMap<ProjectViewModel, Project>();
            Mapper.Configuration.CreateMap<ProjectStageViewModel, ProjectStage>();
            Mapper.Configuration.CreateMap<Project, ProjectViewModel>();
            Mapper.Configuration.CreateMap<ProjectStageViewModel, ProjectStage>();
        }
    }
}
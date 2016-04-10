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
            Mapper.Initialize(conf => {
                conf.CreateMap<ProjectViewModel, Project>();
                conf.CreateMap<ProjectStageViewModel, ProjectStage>();
                conf.CreateMap<Project, ProjectViewModel>();
                conf.CreateMap<ProjectStageViewModel, ProjectStage>();
            });
        }
    }
}
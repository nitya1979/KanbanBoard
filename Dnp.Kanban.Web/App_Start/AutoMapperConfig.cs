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
           
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<ProjectViewModel, Project>();
                cfg.CreateMap<ProjectStageViewModel, ProjectStage>();
                cfg.CreateMap<Project, ProjectViewModel>();
                cfg.CreateMap<ProjectStageViewModel, ProjectStage>();
                cfg.CreateMap<DnpTaskViewModel, DnpTask>();
                cfg.CreateMap<DnpTask, DnpTaskViewModel>();
                
            });
        }
    }
}
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dnp.Kanban.Web.Helper
{
    public static class WebHelper
    {
        public static IMapper GetMapper<TSource, TTarget>()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<TSource, TTarget>());

            return config.CreateMapper();
        }
    }
}
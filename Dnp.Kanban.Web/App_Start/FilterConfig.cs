﻿using Dnp.Kanban.Web.Filters;
using System.Web;
using System.Web.Mvc;

namespace Dnp.Kanban.Web
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}

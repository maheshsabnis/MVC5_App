﻿using System.Web;
using System.Web.Mvc;
using MVC5_App.CustomFilters;

namespace MVC5_App
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new LogFilterAttribute());
        }
    }
}

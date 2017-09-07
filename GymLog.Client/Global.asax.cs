﻿using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace GymLog.Client {
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            GlobalFilters.Filters.Add(new RequireHttpsAttribute());
        }
    }
}

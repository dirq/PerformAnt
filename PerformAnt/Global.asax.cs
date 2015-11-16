using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace PerformAnt
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            ConfigureViewEngines();

            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //turn off minification if we are debugging
            //see web.config > system.web > compliation[debug]
            if (HttpContext.Current.IsDebuggingEnabled)
            {
                BundleTable.EnableOptimizations = false;
                BundleTable.Bundles.UseCdn = false;

                //pretty up the json so I can read it (but only in debug mode)
                var json = GlobalConfiguration.Configuration.Formatters.JsonFormatter;
                json.SerializerSettings.Formatting = Newtonsoft.Json.Formatting.Indented;

                //more debug details
                GlobalConfiguration.Configuration.IncludeErrorDetailPolicy = IncludeErrorDetailPolicy.Always;
            }
            else
            {
                BundleTable.EnableOptimizations = true;
                BundleTable.Bundles.UseCdn = true;
            }
        }

        private static void ConfigureViewEngines()
        {
            // Only use the RazorViewEngine.  Disables web forms view engine.
            ViewEngines.Engines.Clear();
            ViewEngines.Engines.Add(new RazorViewEngine());
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Newtonsoft.Json.Serialization;

namespace PerformAnt
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            var json = config.Formatters.JsonFormatter;

            //cameCase intead of PascalCase, better for javascript
            json.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

            //fix reference loop problems when serializing hierarchical objects.
            //If you need it to go deeper down an object chain, this might be the problem.
            json.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;

#if DEBUG
			//pretty up the json so I can read it
			json.SerializerSettings.Formatting = Newtonsoft.Json.Formatting.Indented;
#endif

            // Remove the XML formatter from the Web API - only use JSON
            GlobalConfiguration.Configuration.Formatters.Remove(GlobalConfiguration.Configuration.Formatters.XmlFormatter);

            config.IncludeErrorDetailPolicy = IncludeErrorDetailPolicy.Always;

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
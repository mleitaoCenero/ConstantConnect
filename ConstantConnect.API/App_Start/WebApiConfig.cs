using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace ConstantConnect.API
{
    public static class WebApiConfig
    {
        public static HttpConfiguration Register()
        {
            var config = new HttpConfiguration();

            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultRouting",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            var cors = new EnableCorsAttribute("*", "*", "*");

            config.EnableCors(cors);

            config.Formatters.XmlFormatter.SupportedMediaTypes.Clear();

            config.Formatters.JsonFormatter.SerializerSettings.Formatting = Newtonsoft.Json.Formatting.Indented;

            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

            config.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            //TODO Config CacheCow for SQL Server, currently it is just using in memory store which is not persistent.
            //TODO Config Output Caching Strathweb.CacheOutput.WebApi2
            config.MessageHandlers.Add(new CacheCow.Server.CachingHandler(config));

            return config;
        }
    }
}

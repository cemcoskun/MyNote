using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json.Serialization;

namespace MyNote.API
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // https://stackoverflow.com/questions/7397207/json-net-error-self-referencing-loop-detected-for-type

            // Web API configuration and services
            config.Formatters.Remove(config.Formatters.XmlFormatter);

            config.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling
                = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            // Web API yapılandırması ve hizmetler
            // Web API yapılandırmasını yalnızca taşıyıcı belirtecini kullanacak şekilde düzenleyin.
            config.SuppressDefaultHostAuthentication();
            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

            // Web API yolları
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}

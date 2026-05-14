using System.Configuration;
using System.Net.Http.Headers;
using System.Web.Http;
using System.Web.Http.Cors;

namespace WebAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(
                new MediaTypeHeaderValue("text/html"));

            var allowedOrigin = ConfigurationManager.AppSettings["AllowedOrigin"];
            config.EnableCors(new EnableCorsAttribute(allowedOrigin, "Content-Type,Authorization", "GET,POST,PUT,DELETE"));
        }
    }
}

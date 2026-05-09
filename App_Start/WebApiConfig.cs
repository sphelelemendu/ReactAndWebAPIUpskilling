using System.Configuration;
using System.Net.Http.Headers;
using System.Web.Http;
using System.Web.Http.Cors;
using Unity;
using Unity.Lifetime;
using Unity.WebApi;
using WebAPI.Data_Layer_Service;
namespace WebAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            var container = new UnityContainer();
            container.RegisterType<IEmployeeService, EmployeeService>(new HierarchicalLifetimeManager());
            container.RegisterType<IDepartmentService, DepartmentService>(new HierarchicalLifetimeManager());
            config.DependencyResolver = new UnityDependencyResolver(container);

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(
                
                new MediaTypeHeaderValue( "text/html" ) );
            var allowedOrigin = ConfigurationManager.AppSettings["AllowedOrigin"];
            config.EnableCors(new EnableCorsAttribute(allowedOrigin, "Content-Type,Authorization", "GET,POST,PUT,DELETE"));
        }
    }
}

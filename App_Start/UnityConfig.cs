using System.Web.Http;
using Unity;
using Unity.Lifetime;
using Unity.WebApi;
using WebAPI.Data_Layer_Service;

namespace WebAPI
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();
            container.RegisterType<IEmployeeService, EmployeeService>(new HierarchicalLifetimeManager());
            container.RegisterType<IDepartmentService, DepartmentService>(new HierarchicalLifetimeManager());
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}
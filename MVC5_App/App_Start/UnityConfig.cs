using System.Web.Mvc;
using Unity;
using Unity.Mvc5;
using MVC5_App.Models;
using MVC5_App.Services;

namespace MVC5_App
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            // register the DbCOntext class in container
            container.RegisterType<EmployeeEDMX>();
            container.RegisterType<IService<Department,int>,DepartmentService>();
            container.RegisterType<IService<Employee, int>, EmployeeService>();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}
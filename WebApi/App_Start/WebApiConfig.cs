using Data;
using Data.Interfaces;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Web.Http;
using WebApi.App_Start;

namespace WebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));

            var container = CreateUnityContainer();
            config.DependencyResolver = new MockInjection(container);
        }

        private static UnityContainer CreateUnityContainer()
        {
            var container = new UnityContainer();
            container.RegisterType<ITestRepository, TestRepository>(new ContainerControlledLifetimeManager());

            return container;
        }
    }
}

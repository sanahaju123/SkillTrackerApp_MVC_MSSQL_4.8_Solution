﻿using SkillTrackerApp.DAL.Interface;
using SkillTrackerApp.DAL.Repository;
using System.Web.Mvc; // Use System.Web.Mvc instead of System.Web.Http
using System.Web.Routing;
using Unity;
using Unity.AspNet.Mvc; // Use Unity.AspNet.Mvc for MVC

namespace SkillTrackerApp
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            var container = new UnityContainer();

            // Register your dependencies, including ISkillTrackerInterface
            container.RegisterType<ISkillTrackerInterface, SkillTrackerSkill>();
            container.RegisterType<ISkillTrackerRepository, SkillTrackerRepository>();

            // Set the dependency resolver for MVC
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}

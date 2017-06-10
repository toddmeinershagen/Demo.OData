﻿using System.ServiceModel.Activation;
using System.Web.Mvc;
using System.Web.Routing;

namespace Demo.OData.Web
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

            routes.Add(new ServiceRoute(nameof(ContactsService), new ServiceHostFactory(), typeof(ContactsService)));
        }
    }
}

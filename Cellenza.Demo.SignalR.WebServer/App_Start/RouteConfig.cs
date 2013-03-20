using Cellenza.Demo.SignalR.WebServer.Connections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Cellenza.Demo.SignalR.WebServer
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.MapConnection<MessageConnection>("chat", "/chat");

            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Messages", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
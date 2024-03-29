﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Property.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                //defaults: new { controller = "RentalOffer", action = "Create", id = UrlParameter.Optional }
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "PortfolioCreate",
                url: "Portfolio/{portfolioId}/Property/Create/",
                //defaults: new { controller = "RentalOffer", action = "Create", id = UrlParameter.Optional }
                defaults: new { portfolioId = 0, controller = "PropertyDescription", action = "Create", id = UrlParameter.Optional }
            );
        }
    }
}
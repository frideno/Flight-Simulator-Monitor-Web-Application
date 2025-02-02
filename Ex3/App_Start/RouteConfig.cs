﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Ex3
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

			// if we want to add simple home page.

			//routes.MapRoute(
			//	name: "Default",
			//	url: "",
			//	defaults: new
			//	{
			//		controller = "Home",
			//		action = "Index",
			//		id = UrlParameter.Optional
			//	}
			//);

			routes.MapRoute("displayPoint", "display/{prm1}/{prm2}",
				defaults: new { controller = "Display", action = "Display", ip = UrlParameter.Optional, port = UrlParameter.Optional });

			routes.MapRoute("displayPath", "display/{ip}/{port}/{updateFrequency}",
				defaults: new { controller = "Display", action = "DisplayPath"});

			routes.MapRoute("savePath", "save/{ip}/{port}/{updateFrequency}/{duration}/{flightName}",
				defaults: new { controller = "Display", action = "Save"});

			routes.MapRoute("displayInfo", "getLocation",
				defaults: new { controller = "Display", action = "GetLocation" });

			
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Routing;
using System.Web.Routing;

namespace RoutingSample
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //DefaultInlineConstraintResolver resolver = new DefaultInlineConstraintResolver();

            routes.MapMvcAttributeRoutes();

            //routes.MapRoute(
            //    "DateRoute",                                           // Route name
            //    "customers/{birthDate}",                            // URL with parameters
            //    new { controller = "Customer", action = "GetCustomerByBirthDate" }  // Parameter defaults
            //);

            routes.MapRoute(
                "NameRoute",                                           // Route name
                "customers/{firstName}/{lastName}",                            // URL with parameters
                new { controller = "Customer", action = "GetCustomerByName" }  // Parameter defaults
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            
        }
    }
}

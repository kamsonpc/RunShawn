using System.Web.Mvc;
using System.Web.Routing;

namespace RunShawn.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapMvcAttributeRoutes();
            AreaRegistration.RegisterAllAreas();
            routes.MapRoute(
                name: "Client",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "RunShawn.Web.Controllers", "RunShawn.Web.Areas.Default.Controllers" }
            );
        }
    }
}

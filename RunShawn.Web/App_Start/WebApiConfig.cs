using RunShawn.Web.Handlers;
using System.Web.Http;
using System.Web.Http.Cors;

namespace RunShawn.Web.App_Start
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            var cors = new EnableCorsAttribute("*", "*", "*");
            config.EnableCors(cors);
            config.MessageHandlers.Add(new PreflightRequestsHandler());
        }
    }
}
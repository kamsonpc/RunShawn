using System.Web.Mvc;

namespace RunShawn.Web.Areas.Admin
{
    public class DefaultAreaRegistration : AreaRegistration
    {
        public override string AreaName => "Default";

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Default_default",
                "{controller}/{action}/{id}",
                new { controller = "News", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "RunShawn.Web.Areas.Default.Controllers" }
            );
        }
    }
}
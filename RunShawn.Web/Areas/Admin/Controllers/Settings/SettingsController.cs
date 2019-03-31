using RunShawn.Web.Attributes;
using RunShawn.Web.Extentions.Contoller;
using RunShawn.Web.Extentions.Icons;
using System.Web.Mvc;

namespace RunShawn.Web.Areas.Admin.Controllers
{
    [Authorize]
    [MenuItem(CssIcon = AwesomeHelper.cogs, Title = "Ustawienia", Action = "Index")]
    public partial class SettingsController : BaseController
    {
        #region Index()

        public virtual ActionResult Index()
        {
            return RedirectToAction(MVC.Admin.Menu.Edit());
        }

        #endregion Index()
    }
}
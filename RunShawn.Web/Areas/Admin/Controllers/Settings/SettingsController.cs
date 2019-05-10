using RunShawn.Web.Extentions.Controllers;
using System.Web.Mvc;

namespace RunShawn.Web.Areas.Admin.Controllers
{
    [Authorize]
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
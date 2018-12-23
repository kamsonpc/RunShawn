using RunShawn.Web.Attributes;
using RunShawn.Web.Extentions.Contoller;
using RunShawn.Web.Extentions.Icons;
using System.Web.Mvc;

namespace RunShawn.Web.Areas.Admin.Controllers
{
    [Authorize]
    [MenuItem(CssIcon = AwesomeHelper.database, Title = "Dashboard", Action = "Dashboard")]
    public partial class DashboardController : BaseController
    {
        #region Index()
        public virtual ActionResult Index()
        {
            return RedirectToAction(MVC.Admin.Dashboard.Dashboard());
        }
        #endregion

        #region Dashboard()
        public virtual ActionResult Dashboard()
        {
            return View(MVC.Admin.Dashboard.Views.Dashboard);
        }
        #endregion

    }
}
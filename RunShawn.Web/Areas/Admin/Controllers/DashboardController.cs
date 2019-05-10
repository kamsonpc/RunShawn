using RunShawn.Web.Extentions.Controllers;
using System.Web.Mvc;

namespace RunShawn.Web.Areas.Admin.Controllers
{
    [Authorize]
    public partial class DashboardController : BaseController
    {
        #region Index()

        public virtual ActionResult Index()
        {
            return RedirectToAction(MVC.Admin.Dashboard.Dashboard());
        }

        #endregion Index()

        #region Dashboard()

        public virtual ActionResult Dashboard()
        {
            return View(MVC.Admin.Dashboard.Views.Dashboard);
        }

        #endregion Dashboard()
    }
}
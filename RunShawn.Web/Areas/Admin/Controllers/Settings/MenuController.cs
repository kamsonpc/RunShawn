using RunShawn.Web.Attributes;
using RunShawn.Web.Extentions.Contoller;
using System.Web.Mvc;

namespace RunShawn.Web.Areas.Admin.Controllers
{
    [Authorize]
    [RoutePrefix(@"Settings/Menu")]
    public partial class MenuController : BaseController
    {
        #region Index()
        public virtual ActionResult Index()
        {
            return RedirectToAction(MVC.Admin.Pages.Edit());
        }
        #endregion

        #region Edit()
        public virtual ActionResult Edit()
        {
            return View(MVC.Admin.Settings.Views.Menu.Edit);
        }
        #endregion

        #region Save()
        [HttpPost]
        [AjaxOnly]
        public virtual ActionResult Save()
        {
            return View(MVC.Admin.Settings.Views.Menu.Edit);
        }
        #endregion
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RunShawn.Web.Attributes;
using RunShawn.Web.Extentions.Icons;

namespace RunShawn.Web.Areas.Admin.Controllers
{
    [Authorize]
    public partial class UsersController : Controller
    {
        #region Index()
        [MenuItem(Action = "Index", CssIcon = AwesomeHelper.adjust, Title = "Użytkownicy")]
        public virtual ActionResult Index()
        {
            return RedirectToAction(MVC.Admin.Users.List());
        }
        #endregion

        #region List()
        [MenuItem(Title = "Lista")]
        public virtual ActionResult List()
        {

            return View();
        }
        #endregion
    }
}
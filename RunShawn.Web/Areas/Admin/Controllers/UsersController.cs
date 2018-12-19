using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RunShawn.Web.Attributes;
using RunShawn.Web.Extentions.Icons;

namespace RunShawn.Web.Areas.Admin.Controllers
{
    [MenuItem(Action = "", CssIcon = AwesomeHelper.users, Title = "Użytkownicy")]
    public partial class UsersController : Controller
    {

        [MenuItem(Action = "Index", CssIcon = "fa fa-users fa-lg fa-fw", Title = "Dodaj")]
        public virtual ActionResult Index()
        {
            return RedirectToAction(MVC.Admin.Users.List());
        }

        [MenuItem(Action = "List", CssIcon = "fa fa-users fa-lg fa-fw", Title = "Lista")]
        public virtual ActionResult List()
        {
            return View();
        }
    }
}
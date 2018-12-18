using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RunShawn.Web.Areas.Admin.Controllers
{
    public partial class UsersController : Controller
    {
        public virtual ActionResult Index()
        {
            return RedirectToAction(MVC.Admin.Users.List());
        }

        public virtual ActionResult List()
        {
            return View();
        }
    }
}
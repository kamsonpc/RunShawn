using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RunShawn.Web.Extentions;
using RunShawn.Web.Models;

namespace RunShawn.Web.Controllers
{
    public partial class MenusController : Controller
    {
        [ChildActionOnly]
        public virtual ActionResult Index()
        {
            List<Menu> menus = MenuGenerator.CreateMenu();

            return PartialView(MVC.Menus.Views._SidebarMenu, menus);
        }

    }
}
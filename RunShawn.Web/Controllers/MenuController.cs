using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RunShawn.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Web;
    using System.Web.Mvc;
    using global::RunShawn.Web.Attributes;
    using global::RunShawn.Web.Extentions;
    using global::RunShawn.Web.Models;

    namespace RunShawn.Web.Controllers
    {
        public partial class MenuController : Controller
        {
            #region Index()
            public virtual ActionResult Index()
            {
                List<Menu> menus = MenuGenerator.CreateMenu();
                return PartialView(MVC.Menu.Views._SidebarMenu, menus);
            }
            #endregion

        }
    }
}
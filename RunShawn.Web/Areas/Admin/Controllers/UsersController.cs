using RunShawn.Core.Features.Users;
using RunShawn.Web.Areas.Admin.Models.Users;
using RunShawn.Web.Attributes;
using RunShawn.Web.Extentions;
using RunShawn.Web.Extentions.Icons;
using System.Collections.Generic;
using System.Web.Mvc;

namespace RunShawn.Web.Areas.Admin.Controllers
{
    [Authorize]
    [MenuItem(CssIcon = AwesomeHelper.adjust, Title = "Użytkownicy", Action = "#", IsClickable = false)]
    public partial class UsersController : Controller
    {
        #region Index()
        public virtual ActionResult Index()
        {
            return RedirectToAction(MVC.Admin.Users.List());
        }
        #endregion

        #region List()
        [MenuItem(Title = "Lista", Action = "List")]
        public virtual ActionResult List()
        {
            var model = UsersService.GetAll()
                                    .MapTo<List<UserListViewModel>>();

            return View(MVC.Admin.Users.Views.List, model);
        }
        #endregion
    }
}
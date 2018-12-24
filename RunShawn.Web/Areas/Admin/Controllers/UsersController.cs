using FluentBootstrap;
using Microsoft.AspNet.Identity.Owin;
using RunShawn.Core.Features.Roles.Model;
using RunShawn.Core.Features.Users;
using RunShawn.Web.Areas.Admin.Models.Users;
using RunShawn.Web.Attributes;
using RunShawn.Web.Extentions;
using RunShawn.Web.Extentions.Contoller;
using RunShawn.Web.Extentions.Icons;
using RunShawn.Web.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace RunShawn.Web.Areas.Admin.Controllers
{
    [Authorize]
    [MenuItem(CssIcon = AwesomeHelper.users, Title = "Użytkownicy", Action = "#", IsClickable = false)]
    public partial class UsersController : BaseController
    {
        private ApplicationUserManager _userManager;

        public ApplicationUserManager UserManager
        {
            get => _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            private set => _userManager = value;
        }

        #region Ctor
        public UsersController()
        {

        }

        public UsersController(ApplicationUserManager userManager)
        {
            _userManager = userManager;
        }
        #endregion

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

        #region Create()
        [MenuItem(Title = "Dodaj Użytkownika", Action = "Create")]
        public virtual ActionResult Create()
        {
            var roles = RolesService.GetAll()
                                    .Select(x => new SelectListItem
                                    {
                                        Value = x.Id,
                                        Text = x.Name
                                    })
                                    .ToList();


            var model = new UserViewModel
            {
                Roles = roles
            };
            return View(MVC.Admin.Users.Views.Create, model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual async Task<ActionResult> Create(UserViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = model.MapTo<ApplicationUser>();
                await UserManager.CreateAsync(user, model.Password);

                if (!string.IsNullOrEmpty(model.RoleId) && !string.IsNullOrEmpty(user.Id))
                {
                    RolesService.SetRole(user.Id, model.RoleId);
                }

                TempData[_alert] = new Alert($"Dodano Użytkownika {user.UserName}", AlertState.Success);
                return RedirectToAction(MVC.Admin.Users.List());
            }

            var roles = RolesService.GetAll()
                                   .Select(x => new SelectListItem
                                   {
                                       Value = x.Id,
                                       Text = x.Name
                                   })
                                   .ToList();

            model.Roles = roles;
            TempData[_alert] = new Alert($"Niepoprawny formularz", AlertState.Danger);
            return View(MVC.Admin.Users.Views.Create, model);
        }
        #endregion

        #region Edit()
        public virtual ActionResult Edit(string id)
        {
            var roles = RolesService.GetAll()
                                    .Select(x => new SelectListItem
                                    {
                                        Value = x.Id,
                                        Text = x.Name
                                    })
                                    .ToList();

            var model = UsersService.GetById(id)
                                     .MapTo<UserViewModel>();

            model.RoleId = RolesService.GetByUser(id);
            model.Roles = roles;

            return View(MVC.Admin.Users.Views.Edit, model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult Edit(UserViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = model.MapTo<ApplicationUser>();
                if (!string.IsNullOrEmpty(model.RoleId) && !string.IsNullOrEmpty(user.Id))
                {
                    RolesService.SetRole(user.Id, model.RoleId);
                }

                TempData[_alert] = new Alert($"Dodano Użytkownika {user.UserName}", AlertState.Success);
                return RedirectToAction(MVC.Admin.Users.List());
            }

            var roles = RolesService.GetAll()
                                   .Select(x => new SelectListItem
                                   {
                                       Value = x.Id,
                                       Text = x.Name
                                   })
                                   .ToList();

            model.Roles = roles;
            TempData[_alert] = new Alert($"Niepoprawny formularz", AlertState.Danger);
            return View(MVC.Admin.Users.Views.Create, model);
        }
        #endregion
    }
}
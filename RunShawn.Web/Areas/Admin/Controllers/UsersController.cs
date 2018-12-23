using FluentBootstrap;
using Microsoft.AspNet.Identity.Owin;
using RunShawn.Core.Features.Roles.Model;
using RunShawn.Core.Features.Users;
using RunShawn.Web.Areas.Admin.Models.Users;
using RunShawn.Web.Attributes;
using RunShawn.Web.Extentions;
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
    public partial class UsersController : Controller
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
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public virtual async Task<ActionResult> Create(UserViewModel model)
        {
            if (ModelState.IsValid)
            {
                #region MapUser
                var user = new ApplicationUser
                {
                    UserName = model.Email,
                    Email = model.Email,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    EmailConfirmed = true,
                    PhoneNumber = model.PhoneNumber,
                    LockoutEnabled = model.LockoutEnabled,
                    LockoutEndDateUtc = model.LockoutEndDateUtc
                };
                #endregion

                await UserManager.CreateAsync(user, model.Password);

                if (model.RoleId != null)
                {
                    RolesService.SetRole(user.Id, model.RoleId);
                }
                TempData["Alert"] = new Alert($"Dodano Użytkownika {user.UserName}", AlertState.Success);
            }

            var roles = RolesService.GetAll()
                                   .Select(x => new SelectListItem
                                   {
                                       Value = x.Id,
                                       Text = x.Name
                                   })
                                   .ToList();

            model.Roles = roles;
            return View(MVC.Admin.Users.Views.Create, model);
        }
        #endregion
    }
}
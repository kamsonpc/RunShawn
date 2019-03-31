using FluentBootstrap;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using RunShawn.Core.Features.Roles.Model;
using RunShawn.Core.Features.Users;
using RunShawn.Core.Features.Users.Model;
using RunShawn.Web.Areas.Admin.Models.Users;
using RunShawn.Web.Extentions;
using RunShawn.Web.Extentions.Contoller;
using RunShawn.Web.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace RunShawn.Web.Areas.Admin.Controllers
{
    [Authorize()]
    public partial class UsersController : BaseController
    {
        public IUsersService _usersService { get; internal set; }

        #region InjectUserManager

        private ApplicationUserManager _userManager;

        public ApplicationUserManager UserManager
        {
            get => _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            private set => _userManager = value;
        }

        #endregion InjectUserManager

        #region Ctor

        public UsersController(IUsersService usersService)
        {
            _usersService = usersService;
        }

        public UsersController(ApplicationUserManager userManager)
        {
            _userManager = userManager;
        }

        #endregion Ctor

        #region Index()

        public virtual ActionResult Index()
        {
            return RedirectToAction(MVC.Admin.Users.List());
        }

        #endregion Index()

        #region List()

        public virtual ActionResult List()
        {
            var model = _usersService.GetAll()
                                    .MapTo<List<UserListViewModel>>();

            return View(MVC.Admin.Users.Views.List, model);
        }

        #endregion List()

        #region Create()

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

        #endregion Create()

        #region CreatePost()

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual async Task<ActionResult> Create(UserViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = model.MapTo<ApplicationUser>();
                try
                {
                    await UserManager.CreateAsync(user, model.Password);
                    if (!string.IsNullOrEmpty(model.RoleId) && !string.IsNullOrEmpty(user.Id))
                    {
                        RolesService.SetRole(user.Id, model.RoleId);
                    }

                    TempData[_alert] = new Alert($"Dodano Użytkownika {user.UserName}", AlertState.Success);
                    return RedirectToAction(MVC.Admin.Users.List());
                }
                catch (Exception ex)
                {
                    logger.Error(ex);
                }
            }

            var roles = RolesService.GetAll()
                                   .Select(x => new SelectListItem
                                   {
                                       Value = x.Id,
                                       Text = x.Name
                                   })
                                   .ToList();
            model.Roles = roles;

            TempData[_alert] = new Alert("Niepoprawny formularz", AlertState.Danger);
            return View(MVC.Admin.Users.Views.Create, model);
        }

        #endregion CreatePost()

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

            var model = _usersService.GetById(id)
                                     .MapTo<UserEditViewModel>();

            model.RoleId = RolesService.GetByUser(id);
            model.Roles = roles;

            return View(MVC.Admin.Users.Views.Edit, model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult Edit(UserEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var user = model.MapTo<User>();
                    _usersService.Update(user);

                    if (!string.IsNullOrEmpty(user.Id))
                    {
                        RolesService.ChangeRole(user.Id, model.RoleId);
                    }

                    TempData[_alert] = new Alert($"Zaktualizowano Użytkownika {user.UserName}", AlertState.Success);
                    return RedirectToAction(MVC.Admin.Users.List());
                }
                catch (Exception ex)
                {
                    logger.Error(ex);
                }
            }

            model.Roles = RolesService.GetAll()
                                   .Select(x => new SelectListItem
                                   {
                                       Value = x.Id,
                                       Text = x.Name
                                   })
                                   .ToList();
            TempData[_alert] = new Alert("Niepoprawny formularz", AlertState.Danger);
            return View(MVC.Admin.Users.Views.Edit, model);
        }

        #endregion Edit()

        #region Delete()

        public virtual ActionResult Delete(string id)
        {
            try
            {
                _usersService.Delete(id);

                TempData[_alert] = new Alert("Pomyślnie Usunięto", AlertState.Success);
                return RedirectToAction(MVC.Admin.Users.List());
            }
            catch (Exception)
            {
                TempData[_alert] = new Alert("Wystąpił Błąd podczas usuwania", AlertState.Danger);
                return RedirectToAction(MVC.Admin.Users.List());
            }
        }

        #endregion Delete()

        #region GetAvatar()

        public virtual FileContentResult GetAvatar()
        {
            string userId = User.Identity.GetUserId();

            var user = _usersService.GetById(userId);

            var avatar = user.Avatar;
            if (avatar?.Length <= 0)
            {
                try
                {
                    string fileName = HttpContext.Server.MapPath("~/Content/images/user.png");

                    byte[] imageData = null;
                    FileInfo fileInfo = new FileInfo(fileName);

                    long imageFileLength = fileInfo.Length;

                    FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                    BinaryReader br = new BinaryReader(fs);
                    imageData = br.ReadBytes((int)imageFileLength);

                    return new FileContentResult(imageData, "image/jpeg");
                }
                catch (FileNotFoundException)
                {
                    return new FileContentResult(new byte[1], "image/jpeg");
                }
            }
            else
            {
                return new FileContentResult(user.Avatar, "image/jpeg");
            }
        }

        #endregion GetAvatar()
    }
}
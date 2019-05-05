using AutoMapper;
using FluentBootstrap;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using RunShawn.Core.Features.Roles.Model;
using RunShawn.Core.Features.Roles.Repositories;
using RunShawn.Core.Features.Users.Model;
using RunShawn.Core.Features.Users.Repositories;
using RunShawn.Web.Areas.Admin.Models.Users;
using RunShawn.Web.Areas.General.Models;
using RunShawn.Web.Extentions.Alerts;
using RunShawn.Web.Extentions.Controllers;
using RunShawn.Web.Extentions.Linq;
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
        #region Depenecies

        public IRolesRepository _rolesRepository { get; internal set; }

        public IMapper _mapper { get; internal set; }

        #endregion Depenecies

        #region InjectUserManager

        private ApplicationUserManager _userManager;
        private readonly IUsersRepository _usersRepository;

        public ApplicationUserManager UserManager
        {
            get => _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            private set => _userManager = value;
        }

        #endregion InjectUserManager

        #region Ctor

        public UsersController(IUsersRepository usersRepository, IRolesRepository rolesRepository, IMapper mapper)
        {
            _rolesRepository = rolesRepository;
            _mapper = mapper;
            _usersRepository = usersRepository;
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
            var data = _usersRepository.GetAll();
            var model = _mapper.Map<List<UserListViewModel>>(data);

            return View(MVC.Admin.Users.Views.List, model);
        }

        #endregion List()

        #region Create()

        public virtual ActionResult Create()
        {
            var roles = _rolesRepository.GetAll()
                                    .ToSelectList(x => x.Name, y => y.Id);

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
                var user = _mapper.Map<ApplicationUser>(model);

                try
                {
                    await UserManager.CreateAsync(user, model.Password).ConfigureAwait(false);
                    if (!string.IsNullOrEmpty(model.RoleId) && !string.IsNullOrEmpty(user.Id))
                    {
                        _rolesRepository.SetRole(new UserRole { UserId = user.Id, RoleId = model.RoleId });
                    }

                    TempData[_alert] = new Alert($"Dodano Użytkownika {user.UserName}", AlertState.Success);
                    return RedirectToAction(MVC.Admin.Users.List());
                }
                catch (Exception ex)
                {
                    logger.Error(ex);
                }
            }

            model.Roles = _rolesRepository.GetAll()
                                   .Select(x => new SelectListItem
                                   {
                                       Value = x.Id,
                                       Text = x.Name
                                   })
                                   .ToList();

            TempData[_alert] = new Alert("Niepoprawny formularz", AlertState.Danger);
            return View(MVC.Admin.Users.Views.Create, model);
        }

        #endregion CreatePost()

        #region Edit()

        public virtual ActionResult Edit(string id)
        {
            var roles = _rolesRepository.GetAll()
                                    .Select(x => new SelectListItem
                                    {
                                        Value = x.Id,
                                        Text = x.Name
                                    })
                                    .ToList();

            var user = _usersRepository.GetById(id);
            var model = _mapper.Map<UserEditViewModel>(user);

            model.RoleId = _rolesRepository.GetByUser(id);
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
                    var user = _mapper.Map<User>(model);
                    _usersRepository.Update(user);

                    if (!string.IsNullOrEmpty(user.Id))
                    {
                        _rolesRepository.ChangeRole(new UserRole
                        { UserId = user.Id, RoleId = model.RoleId });
                    }

                    TempData[_alert] = new Alert($"Zaktualizowano Użytkownika {user.UserName}", AlertState.Success);
                    return RedirectToAction(MVC.Admin.Users.List());
                }
                catch (Exception ex)
                {
                    logger.Error(ex);
                }
            }

            model.Roles = _rolesRepository.GetAll()
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
                _usersRepository.Delete(id);

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

            var user = _usersRepository.GetById(userId);

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
using RunShawn.Core.Features.Roles.Repository;
using RunShawn.Core.Features.Users;
using RunShawn.Web.Areas.Admin.Models.Roles;
using RunShawn.Web.Extentions;
using RunShawn.Web.Extentions.Contoller;
using System.Collections.Generic;
using System.Web.Mvc;

namespace RunShawn.Web.Areas.Admin.Controllers
{
    [Authorize()]
    public partial class RolesController : BaseController
    {
        public IRolesRepository _rolesRepository { get; internal set; }

        #region Ctor

        public RolesController(IUsersService usersService, IRolesRepository rolesRepository)
        {
            _rolesRepository = rolesRepository;
        }

        #endregion Ctor

        #region Index()

        public virtual ActionResult Index()
        {
            return RedirectToAction(MVC.Admin.Roles.List());
        }

        #endregion Index()

        #region List()

        public virtual ActionResult List()
        {
            var model = _rolesRepository.GetAll()
                                     .MapTo<List<RoleListViewModel>>();

            return View(MVC.Admin.Users.Views.List, model);
        }

        #endregion List()
    }
}
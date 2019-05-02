using AutoMapper;
using RunShawn.Core.Features.Roles.Repository;
using RunShawn.Core.Features.Users;
using RunShawn.Web.Areas.Admin.Models.Roles;
using RunShawn.Web.Extentions.Controllers;
using System.Collections.Generic;
using System.Web.Mvc;

namespace RunShawn.Web.Areas.Admin.Controllers
{
    [Authorize()]
    public partial class RolesController : BaseController
    {

        #region Dependecies
        private readonly IUsersService _usersService;
        private readonly IRolesRepository _rolesRepository;
        private readonly IMapper _mapper;

        public RolesController(
            IUsersService usersService,
            IRolesRepository rolesRepository,
            IMapper mapper)
        {
            _usersService = usersService;
            _rolesRepository = rolesRepository;
            _mapper = mapper;
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
            var roles = _rolesRepository.GetAll();
            var model = _mapper.Map<List<RoleListViewModel>>(roles);

            return View(MVC.Admin.Users.Views.List, model);
        }

        #endregion List()
    }
}
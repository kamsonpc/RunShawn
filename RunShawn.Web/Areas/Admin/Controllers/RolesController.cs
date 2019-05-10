using AutoMapper;
using RunShawn.Core.Features.Roles.Repositories;
using RunShawn.Core.Features.Users.Repositories;
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
        private readonly IRolesRepository _rolesRepository;
        private readonly IMapper _mapper;
        private readonly IUsersRepository _usersRepository;

        public RolesController(
            IUsersRepository usersRepository,
            IRolesRepository rolesRepository,
            IMapper mapper)
        {
            _rolesRepository = rolesRepository;
            _mapper = mapper;
            _usersRepository = usersRepository;
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
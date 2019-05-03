using AutoMapper;
using RunShawn.Core.Features.Pages.Repositories;
using RunShawn.Web.Areas.Default.Models.Pages;
using RunShawn.Web.Extentions.Roles;
using System.Web.Mvc;

namespace RunShawn.Web.Controllers
{
    [RoutePrefix("Pages")]
    public partial class PagesController : Controller
    {
        #region Dependencies
        private readonly IMapper _mapper;
        private readonly IPagesRepository _pagesRepository;

        public PagesController(IMapper mapper, IPagesRepository pagesRepository)
        {
            _mapper = mapper;
            _pagesRepository = pagesRepository;
        }
        #endregion

        #region Page
        [Route("{slug}")]
        public virtual ActionResult Page(string slug)
        {
            slug = slug.ToLower();

            var page = _pagesRepository.GetBySlug(slug);
            if (page == null)
            {
                return HttpNotFound();
            }

            if (!page.Active && User.IsInRole(nameof(RoleTypes.Administrator)))
            {
                return HttpNotFound();
            }

            var model = _mapper.Map<PageViewModel>(page);
            return View(MVC.Default.Pages.Views.Page, model);
        }
        #endregion
    }
}
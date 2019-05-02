using AutoMapper;
using RunShawn.Core.Features.Pages;
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

        public PagesController(IMapper mapper)
        {
            _mapper = mapper;
        }
        #endregion

        #region Page
        [Route("{slug}")]
        public virtual ActionResult Page(string slug)
        {
            slug = slug.ToLower();

            var page = PagesService.GetBySlug(slug);
            if (page == null)
            {
                return HttpNotFound();
            }

            if (!page.Active && User.IsInRole(RoleTypes.Administrator.ToString()))
            {
                return HttpNotFound();
            }

            var model = _mapper.Map<PageViewModel>(page);
            return View(MVC.Default.Pages.Views.Page, model);
        }
        #endregion
    }
}
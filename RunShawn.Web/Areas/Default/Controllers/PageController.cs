using RunShawn.Core.Features.Pages;
using RunShawn.Web.Areas.Default.Models.Pages;
using RunShawn.Web.Extentions;
using System.Web.Mvc;

namespace RunShawn.Web.Controllers
{
    [RoutePrefix("Pages")]
    public partial class PagesController : Controller
    {
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

            var model = page.MapTo<PageViewModel>();
            return View(MVC.Default.Pages.Views.Page, model);
        }
    }
}
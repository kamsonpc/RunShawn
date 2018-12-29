using RunShawn.Core.Features.News.Categories;
using RunShawn.Web.Areas.Admin.Models.News;
using RunShawn.Web.Extentions;
using RunShawn.Web.Extentions.Contoller;
using System.Collections.Generic;
using System.Web.Mvc;

namespace RunShawn.Web.Areas.Admin.Controllers
{
    [Authorize]
    public partial class CategoriesController : BaseController
    {
        #region Index()
        public virtual ActionResult Index()
        {
            return RedirectToAction(MVC.Admin.Categories.List());
        }
        #endregion

        #region List()
        public virtual ActionResult List()
        {
            var categories = CategoriesService.GetCategoriesAndSubcategories()
                                              .MapTo<List<CategoryViewModel>>();

            return View();
        }
        #endregion
    }
}
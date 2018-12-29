using RunShawn.Core.Features.News.Categories;
using RunShawn.Web.Areas.Admin.Models.News;
using RunShawn.Web.Extentions;
using RunShawn.Web.Extentions.Contoller;
using System.Collections.Generic;
using System.Linq;
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
                                              .MapTo<List<CategoryListViewModel>>();

            return View(MVC.Admin.Categories.Views.List, categories);
        }
        #endregion

        #region Create()
        [HttpGet]
        [ChildActionOnly]
        public virtual ActionResult Create()
        {
            var categories = CategoriesService.GetCategoriesAndSubcategories()
                                              .MapTo<List<CategoryListViewModel>>()
                                              .Select(x => new SelectListItem
                                              {
                                                  Value = x.Id.ToString(),
                                                  Text = x.Title
                                              })
                                              .ToList();

            var model = new CategoryViewModel
            {
                Categories = categories
            };

            return PartialView(MVC.Admin.Categories.Views._Create, model);
        }
        #endregion

        #region Create()
        [ChildActionOnly]
        [HttpPost]
        public virtual ActionResult Create(CategoryViewModel model)
        {

            return RedirectToAction(MVC.Admin.Categories.List());
        }
        #endregion
    }
}
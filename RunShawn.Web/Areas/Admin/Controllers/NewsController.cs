using RunShawn.Core.Features.News.Categories;
using RunShawn.Web.Areas.Admin.Models.News;
using RunShawn.Web.Attributes;
using RunShawn.Web.Extentions.Contoller;
using RunShawn.Web.Extentions.Icons;
using System.Linq;
using System.Web.Mvc;

namespace RunShawn.Web.Areas.Admin.Controllers
{
    [Authorize]
    [MenuItem(CssIcon = AwesomeHelper.globe, Title = "Aktualności", Action = "List")]
    public partial class NewsController : BaseController
    {
        #region Index()
        public virtual ActionResult Index()
        {
            return RedirectToAction(MVC.Admin.News.List());
        }
        #endregion

        #region List()
        public virtual ActionResult List()
        {
            return View(MVC.Admin.News.Views.List);
        }
        #endregion

        #region Create()
        [MenuItem(Title = "Dodaj Wpis", Action = "Create")]
        public virtual ActionResult Create()
        {
            var categories = CategoriesService.GetCategoriesAndSubcategories()
                                              .Select(x => new SelectListItem
                                              {
                                                  Value = x.Id.ToString(),
                                                  Text = x.Title
                                              })
                                              .ToList();
            var model = new NewsViewModel
            {
                Categories = categories
            };

            return View(MVC.Admin.News.Views.Create, model);
        }
        #endregion

    }
}
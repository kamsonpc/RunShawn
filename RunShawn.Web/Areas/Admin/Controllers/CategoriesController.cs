using FluentBootstrap;
using Microsoft.AspNet.Identity;
using RunShawn.Core.Features.News.Categories;
using RunShawn.Core.Features.News.Categories.Model;
using RunShawn.Core.Features.News.News;
using RunShawn.Web.Areas.Admin.Models.News;
using RunShawn.Web.Attributes;
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
            return View(MVC.Admin.Categories.Views.List);
        }

        public virtual ActionResult GenerateList()
        {
            var categories = CategoriesService.GetCategoriesAndSubcategories()
                                              .MapTo<List<CategoryListViewModel>>();

            return PartialView(MVC.Admin.Categories.Views._List, categories);
        }
        #endregion

        #region Create()
        [HttpGet]
        public virtual ActionResult Create()
        {
            var categories = CategoriesService.GetCategoriesAndSubcategories()
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
        [HttpPost]
        [AjaxOnly]
        [ValidateAntiForgeryToken]
        public virtual ActionResult Create(CategoryViewModel model)
        {
            if (ModelState.IsValid)
            {
                var category = model.MapTo<Category>();

                CategoriesService.Create(category, User.Identity.GetUserId());

                return RedirectToAction(MVC.Admin.Categories.GenerateList());
            }

            TempData[_alert] = new Alert("Niepoprawny formularz", AlertState.Danger);
            var categories = CategoriesService.GetCategoriesAndSubcategories()
                                              .Select(x => new SelectListItem
                                              {
                                                  Value = x.Id.ToString(),
                                                  Text = x.Title
                                              })
                                              .ToList();
            model.Categories = categories;

            return PartialView(MVC.Admin.Categories.Views._Create, model);
        }
        #endregion

        #region Delete()
        [AjaxOnly]
        public virtual JsonResult Delete(long id)
        {
            var articles = ArticlesService.GetByCategory(id);
            if (articles != null)
            {
                return Json(new
                {
                    status = CategoryDeleteErrors.HasArticles
                }, JsonRequestBehavior.AllowGet);
            }

            CategoriesService.Delete(id);

            return Json(new
            {
                status = CategoryDeleteErrors.NoError
            }, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region ChangeArticlesCategory()
        [HttpGet]
        [AjaxOnly]
        public virtual ActionResult ChangeArticlesCategory(long categoryId)
        {
            var categories = CategoriesService.GetCategoriesAndSubcategories(categoryId)
                                              .Select(x => new SelectListItem
                                              {
                                                  Value = x.Id.ToString(),
                                                  Text = x.Title
                                              })
                                              .ToList();

            var model = new ArticlesMoveViewModel
            {
                CurrentCategoryId = categoryId,
                Categories = categories
            };

            return PartialView(MVC.Admin.Categories.Views._MoveArticles, model);
        }
        #endregion

        #region ChangeArticlesCategory()
        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult ChangeArticlesCategory(ArticlesMoveViewModel model)
        {
            if (ModelState.IsValid)
            {
                ArticlesService.Move(model.CurrentCategoryId, model.NewCategoryId);
                CategoriesService.Delete(model.CurrentCategoryId);
            }

            return RedirectToAction(MVC.Admin.Categories.GenerateList());
        }
        #endregion
    }
}
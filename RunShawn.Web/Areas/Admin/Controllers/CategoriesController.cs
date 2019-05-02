using AutoMapper;
using FluentBootstrap;
using Microsoft.AspNet.Identity;
using RunShawn.Core.Features.News.Categories;
using RunShawn.Core.Features.News.Categories.Model;
using RunShawn.Core.Features.News.News;
using RunShawn.Web.Areas.Admin.Models.News;
using RunShawn.Web.Extentions.Alerts;
using RunShawn.Web.Extentions.Attributes;
using RunShawn.Web.Extentions.Controllers;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace RunShawn.Web.Areas.Admin.Controllers
{
    [Authorize]
    public partial class CategoriesController : BaseController
    {
        #region Dependencies

        private readonly IArticlesService _articlesService;
        private readonly IMapper _mapper;

        public CategoriesController(IArticlesService articlesService, IMapper mapper)
        {
            _articlesService = articlesService;
            _mapper = mapper;
        }

        #endregion Dependencies

        #region Index()

        public virtual ActionResult Index()
        {
            return RedirectToAction(MVC.Admin.Categories.List());
        }

        #endregion Index()

        #region List()

        public virtual ActionResult List()
        {
            return View(MVC.Admin.Categories.Views.List);
        }

        public virtual ActionResult GenerateList()
        {
            var categories = CategoriesService.GetCategoriesAndSubcategories();
            var model = _mapper.Map<List<CategoryListViewModel>>(categories);

            return PartialView(MVC.Admin.Categories.Views._List, model);
        }

        #endregion List()

        #region Create()

        [HttpGet]
        [AjaxOnly]
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

        #endregion Create()

        #region Create()

        [HttpPost]
        [AjaxOnly]
        [ValidateAntiForgeryToken]
        public virtual ActionResult Create(CategoryViewModel model)
        {
            if (ModelState.IsValid)
            {
                var category = _mapper.Map<Category>(model);

                CategoriesService.Create(category, User.Identity.GetUserId());

                return RedirectToAction(MVC.Admin.Categories.GenerateList());
            }

            TempData[_alert] = new Alert("Niepoprawny formularz", AlertState.Danger);
            model.Categories = CategoriesService.GetCategoriesAndSubcategories()
                                                .Select(x => new SelectListItem
                                                {
                                                    Value = x.Id.ToString(),
                                                    Text = x.Title
                                                })
                                                .ToList();

            return PartialView(MVC.Admin.Categories.Views._Create, model);
        }

        #endregion Create()

        #region Edit()

        [HttpGet]
        public virtual ActionResult Edit(long id)
        {
            var categories = CategoriesService.GetCategoriesAndSubcategories(id)
                                              .Select(x => new SelectListItem
                                              {
                                                  Value = x.Id.ToString(),
                                                  Text = x.Title
                                              })
                                              .ToList();

            var category = CategoriesService.GetById(id);
            var model = _mapper.Map<CategoryViewModel>(category);

            model.Categories = categories;

            return PartialView(MVC.Admin.Categories.Views._Edit, model);
        }

        #endregion Edit()

        #region Edit()

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult Edit(CategoryViewModel model)
        {
            if (ModelState.IsValid)
            {
                var category = _mapper.Map<Category>(model);

                CategoriesService.Update(category, User.Identity.GetUserId());

                return RedirectToAction(MVC.Admin.Categories.GenerateList());
            }

            TempData[_alert] = new Alert("Niepoprawny formularz", AlertState.Danger);
            model.Categories = CategoriesService.GetCategoriesAndSubcategories()
                                              .Select(x => new SelectListItem
                                              {
                                                  Value = x.Id.ToString(),
                                                  Text = x.Title
                                              })
                                              .ToList();

            return PartialView(MVC.Admin.Categories.Views._Edit, model);
        }

        #endregion Edit()

        #region Delete()

        [AjaxOnly]
        public virtual JsonResult Delete(long id)
        {
            var articles = _articlesService.GetByCategory(id);
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

        #endregion Delete()

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

        #endregion ChangeArticlesCategory()

        #region ChangeArticlesCategory()

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult ChangeArticlesCategory(ArticlesMoveViewModel model)
        {
            if (ModelState.IsValid)
            {
                _articlesService.Move(model.CurrentCategoryId, model.NewCategoryId);
                CategoriesService.Delete(model.CurrentCategoryId);
            }

            return RedirectToAction(MVC.Admin.Categories.GenerateList());
        }

        #endregion ChangeArticlesCategory()
    }
}
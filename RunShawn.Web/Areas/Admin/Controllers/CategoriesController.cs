using AutoMapper;
using FluentBootstrap;
using Microsoft.AspNet.Identity;
using RunShawn.Core.Features.News.Categories.Model;
using RunShawn.Core.Features.News.Categories.Repositories;
using RunShawn.Core.Features.News.News.Repositories;
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

        private readonly IMapper _mapper;
        private readonly IArticlesRepository _articlesRepository;
        private readonly ICategoriesRepository _categoriesRepository;

        public CategoriesController(IArticlesRepository articlesRepository, IMapper mapper, ICategoriesRepository categoriesRepository)
        {
            _mapper = mapper;
            _articlesRepository = articlesRepository;
            _categoriesRepository = categoriesRepository;
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
            var categories = _categoriesRepository.GetCategoriesAndSubcategories();
            var model = _mapper.Map<List<CategoryListViewModel>>(categories);

            return PartialView(MVC.Admin.Categories.Views._List, model);
        }

        #endregion List()

        #region Create()

        [HttpGet]
        [AjaxOnly]
        public virtual ActionResult Create()
        {
            var categories = _categoriesRepository.GetCategoriesAndSubcategories()
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

                _categoriesRepository.Create(category, User.Identity.GetUserId());

                return RedirectToAction(MVC.Admin.Categories.GenerateList());
            }

            TempData[_alert] = new Alert("Niepoprawny formularz", AlertState.Danger);
            model.Categories = _categoriesRepository.GetCategoriesAndSubcategories()
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
            var categories = _categoriesRepository.GetCategoriesAndSubcategories(id)
                                              .Select(x => new SelectListItem
                                              {
                                                  Value = x.Id.ToString(),
                                                  Text = x.Title
                                              })
                                              .ToList();

            var category = _categoriesRepository.GetById(id);
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

                _categoriesRepository.Update(category, User.Identity.GetUserId());

                return RedirectToAction(MVC.Admin.Categories.GenerateList());
            }

            TempData[_alert] = new Alert("Niepoprawny formularz", AlertState.Danger);
            model.Categories = _categoriesRepository.GetCategoriesAndSubcategories()
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
            var articles = _articlesRepository.GetByCategory(id);
            if (articles != null)
            {
                return Json(new
                {
                    status = CategoryDeleteErrors.HasArticles
                }, JsonRequestBehavior.AllowGet);
            }

            _categoriesRepository.Delete(id);

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
            var categories = _categoriesRepository.GetCategoriesAndSubcategories(categoryId)
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
                _articlesRepository.Move(model.CurrentCategoryId, model.NewCategoryId);
                _categoriesRepository.Delete(model.CurrentCategoryId);
            }

            return RedirectToAction(MVC.Admin.Categories.GenerateList());
        }

        #endregion ChangeArticlesCategory()
    }
}
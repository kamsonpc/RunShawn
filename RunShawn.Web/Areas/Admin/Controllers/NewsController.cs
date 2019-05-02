using AutoMapper;
using FluentBootstrap;
using Microsoft.AspNet.Identity;
using RunShawn.Core.Features.News.Categories;
using RunShawn.Core.Features.News.News;
using RunShawn.Core.Features.News.News.Model;
using RunShawn.Web.Areas.Admin.Models.News;
using RunShawn.Web.Extentions.Alerts;
using RunShawn.Web.Extentions.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace RunShawn.Web.Areas.Admin.Controllers
{
    [Authorize]
    public partial class NewsController : BaseController
    {
        #region Dependecies

        private readonly IArticlesService _articlesService;
        private readonly IMapper _mapper;

        public NewsController(IArticlesService articlesService, IMapper mapper)
        {
            _mapper = mapper;
            _articlesService = articlesService;
        }

        #endregion Dependecies

        #region Index()

        public virtual ActionResult Index()
        {
            return RedirectToAction(MVC.Admin.News.List());
        }

        #endregion Index()

        #region List()

        public virtual ActionResult List()
        {
            var articlesFromDb = _articlesService.GetAll();
            var model = _mapper.Map<List<ArticleListViewModel>>(articlesFromDb);

            return View(MVC.Admin.News.Views.List, model);
        }

        #endregion List()

        #region Create()

        public virtual ActionResult Create()
        {
            var categories = CategoriesService.GetCategoriesAndSubcategories()
                                              .Select(x => new SelectListItem
                                              {
                                                  Value = x.Id.ToString(),
                                                  Text = x.Title
                                              })
                                              .ToList();
            var model = new ArticleViewModel
            {
                Categories = categories,
                PublishDate = DateTime.Now
            };

            return View(MVC.Admin.News.Views.Create, model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult Create(ArticleViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var article = _mapper.Map<Article>(model);

                    _articlesService.Create(article, User.Identity.GetUserId());

                    TempData[_alert] = new Alert($"Dodano Artykuł {article.Title}", AlertState.Success);
                    return RedirectToAction(MVC.Admin.News.List());
                }
                catch (Exception ex)
                {
                    TempData[_alert] = new Alert("Wystąpił Błąd podczas dodawania artykułu", AlertState.Danger);
                    logger.Error(ex);
                    return RedirectToAction(MVC.Admin.News.List());
                }
            }

            TempData[_alert] = new Alert("Niepoprawny formularz", AlertState.Danger);
            model.Categories = CategoriesService.GetCategoriesAndSubcategories()
                                                .Select(x => new SelectListItem
                                                {
                                                    Value = x.Id.ToString(),
                                                    Text = x.Title
                                                })
                                                .ToList();

            return View(MVC.Admin.News.Views.Create, model);
        }

        #endregion Create()

        #region Edit()

        public virtual ActionResult Edit(long id)
        {
            var categories = CategoriesService.GetCategoriesAndSubcategories()
                                              .Select(x => new SelectListItem
                                              {
                                                  Value = x.Id.ToString(),
                                                  Text = x.Title
                                              })
                                              .ToList();

            var article = _articlesService.GetById(id);
            var model = _mapper.Map<ArticleViewModel>(article);
            model.Categories = categories;

            return View(MVC.Admin.News.Views.Edit, model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult Edit(ArticleViewModel model)
        {
            if (ModelState.IsValid)
            {
                var article =_mapper.Map<Article>(model);

                _articlesService.Update(article, User.Identity.GetUserId());

                TempData[_alert] = new Alert($"Zaktualizowano Artykuł {article.Title}", AlertState.Success);
                return RedirectToAction(MVC.Admin.News.List());
            }

            TempData[_alert] = new Alert("Niepoprawny formularz", AlertState.Danger);
            model.Categories = CategoriesService.GetCategoriesAndSubcategories()
                                             .Select(x => new SelectListItem
                                             {
                                                 Value = x.Id.ToString(),
                                                 Text = x.Title
                                             })
                                             .ToList();

            return View(MVC.Admin.News.Views.Edit, model);
        }

        #endregion Edit()

        #region Delete()

        public virtual ActionResult Delete(long id)
        {
            try
            {
                _articlesService.Delete(id, User.Identity.GetUserId());

                TempData[_alert] = new Alert("Pomyślnie Usunięto", AlertState.Success, Url.Action(MVC.Admin.News.Restore(id)));
                return RedirectToAction(MVC.Admin.News.List());
            }
            catch (Exception)
            {
                TempData[_alert] = new Alert("Wystąpił Błąd podczas usuwania", AlertState.Danger);
                return RedirectToAction(MVC.Admin.News.List());
            }
        }

        #endregion Delete()

        #region Feature()

        public virtual ActionResult Feature(long id)
        {
            _articlesService.Feature(id);
            return RedirectToAction(MVC.Admin.News.List());
        }

        #endregion Feature()

        #region Restore()

        public virtual ActionResult Restore(long id)
        {
            try
            {
                _articlesService.Restore(id);

                TempData[_alert] = new Alert("Pomyślnie Przywrócono", AlertState.Success);
                return RedirectToAction(MVC.Admin.News.List());
            }
            catch (Exception ex)
            {
                TempData[_alert] = new Alert("Wystąpił Błąd podczas przywracania", AlertState.Danger);
                logger.Error(ex);
                return RedirectToAction(MVC.Admin.News.List());
            }
        }

        #endregion Restore()

        #region Categories

        public virtual ActionResult Categories()
        {
            return RedirectToAction(MVC.Admin.Categories.List());
        }

        #endregion Categories
    }
}
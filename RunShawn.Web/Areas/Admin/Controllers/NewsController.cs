using FluentBootstrap;
using Microsoft.AspNet.Identity;
using RunShawn.Core.Features.News.Categories;
using RunShawn.Core.Features.News.News;
using RunShawn.Core.Features.News.News.Model;
using RunShawn.Web.Areas.Admin.Models.News;
using RunShawn.Web.Extentions;
using RunShawn.Web.Extentions.Contoller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace RunShawn.Web.Areas.Admin.Controllers
{
    [Authorize]
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
            var model = ArticlesService.GetAll()
                              .MapTo<List<ArticleListViewModel>>();

            return View(MVC.Admin.News.Views.List, model);
        }
        #endregion

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
                    var article = model.MapTo<Article>();

                    ArticlesService.Create(article, User.Identity.GetUserId());

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
            var categories = CategoriesService.GetCategoriesAndSubcategories()
                                             .Select(x => new SelectListItem
                                             {
                                                 Value = x.Id.ToString(),
                                                 Text = x.Title
                                             })
                                             .ToList();
            model.Categories = categories;

            return View(MVC.Admin.News.Views.Create, model);
        }
        #endregion

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

            var model = ArticlesService.GetById(id).MapTo<ArticleViewModel>();
            model.Categories = categories;

            return View(MVC.Admin.News.Views.Edit, model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult Edit(ArticleViewModel model)
        {
            if (ModelState.IsValid)
            {
                var article = model.MapTo<Article>();

                ArticlesService.Update(article, User.Identity.GetUserId());

                TempData[_alert] = new Alert($"Zaktualizowano Artykuł {article.Title}", AlertState.Success);
                return RedirectToAction(MVC.Admin.News.List());
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

            return View(MVC.Admin.News.Views.Edit, model);
        }
        #endregion

        #region Delete()
        public virtual ActionResult Delete(long id)
        {
            try
            {
                ArticlesService.Delete(id, User.Identity.GetUserId());

                TempData[_alert] = new Alert("Pomyślnie Usunięto", AlertState.Success, Url.Action(MVC.Admin.News.Restore(id)));
                return RedirectToAction(MVC.Admin.News.List());
            }
            catch (Exception)
            {
                TempData[_alert] = new Alert("Wystąpił Błąd podczas usuwania", AlertState.Danger);
                return RedirectToAction(MVC.Admin.News.List());
            }
        }
        #endregion

        #region Feature()
        public virtual ActionResult Feature(long id)
        {
            ArticlesService.Feature(id);
            return RedirectToAction(MVC.Admin.News.List());
        }
        #endregion

        #region Restore()
        public virtual ActionResult Restore(long id)
        {
            try
            {
                ArticlesService.Restore(id);

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
        #endregion

        #region Categories
        public virtual ActionResult Categories()
        {
            return RedirectToAction(MVC.Admin.Categories.List());
        }
        #endregion
    }
}
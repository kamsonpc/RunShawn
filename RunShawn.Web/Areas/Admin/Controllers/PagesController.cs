﻿using AutoMapper;
using FluentBootstrap;
using Microsoft.AspNet.Identity;
using RunShawn.Core.Features.Pages;
using RunShawn.Core.Features.Pages.Model;
using RunShawn.Web.Areas.Admin.Models.Pages;
using RunShawn.Web.Extentions.Alerts;
using RunShawn.Web.Extentions.Controllers;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace RunShawn.Web.Areas.Admin.Controllers
{
    [Authorize]
    public partial class PagesController : BaseController
    {
        #region Depenecies
        private readonly IMapper _mapper;
        public PagesController(IMapper mapper)
        {
            _mapper = mapper;
        }
        #endregion

        #region Index()

        public virtual ActionResult Index()
        {
            return RedirectToAction(MVC.Admin.Pages.List());
        }

        #endregion Index()

        #region List()

        public virtual ActionResult List()
        {
            var pages = PagesService.GetAll();
            var model = _mapper.Map<List<PageListViewModel>>(pages);

            return View(MVC.Admin.Pages.Views.List, model);
        }

        #endregion List()

        #region Create()

        public virtual ActionResult Create()
        {
            return View(MVC.Admin.Pages.Views.Create);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult Create(PageViewModel model)
        {
            if (ModelState.IsValid)
            {
                var page = _mapper.Map<Page>(model);

                PagesService.Create(page, User.Identity.GetUserId());

                TempData[_alert] = new Alert($"Dodano Stronę {page.Title}", AlertState.Success);
                return RedirectToAction(MVC.Admin.Pages.List());
            }

            TempData[_alert] = new Alert("Niepoprawny formularz", AlertState.Danger);

            return View(MVC.Admin.Pages.Views.Create, model);
        }

        #endregion Create()

        #region Edit()

        public virtual ActionResult Edit(long id)
        {
            var page = PagesService.GetById(id);
            var model = _mapper.Map<PageViewModel>(page);
            return View(MVC.Admin.Pages.Views.Edit, model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult Edit(PageViewModel model)
        {
            if (ModelState.IsValid)
            {
                var page = _mapper.Map<Page>(model);

                PagesService.Update(page, User.Identity.GetUserId());

                TempData[_alert] = new Alert($"Zaktualizowano Stronę {page.Title}", AlertState.Success);
                return RedirectToAction(MVC.Admin.Pages.List());
            }

            TempData[_alert] = new Alert("Niepoprawny formularz", AlertState.Danger);
            return View(MVC.Admin.Pages.Views.Edit, model);
        }

        #endregion Edit()

        #region Delete()

        public virtual ActionResult Delete(long id)
        {
            try
            {
                PagesService.Delete(id, User.Identity.GetUserId());

                TempData[_alert] = new Alert("Pomyślnie Usunięto", AlertState.Success);
                return RedirectToAction(MVC.Admin.Pages.List());
            }
            catch (Exception)
            {
                TempData[_alert] = new Alert("Wystąpił Błąd podczas usuwania", AlertState.Danger);
                return RedirectToAction(MVC.Admin.Pages.List());
            }
        }

        #endregion Delete()
    }
}
﻿using FluentBootstrap;
using Microsoft.AspNet.Identity;
using RunShawn.Core.Features.News.Categories;
using RunShawn.Core.Features.Pages;
using RunShawn.Core.Features.Pages.Model;
using RunShawn.Web.Areas.Admin.Models.Pages;
using RunShawn.Web.Attributes;
using RunShawn.Web.Extentions;
using RunShawn.Web.Extentions.Contoller;
using RunShawn.Web.Extentions.Icons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace RunShawn.Web.Areas.Admin.Controllers
{
    [Authorize]
    [RoutePrefix(@"Settings/Menu")]
    public partial class MenuController : BaseController
    {
        #region Index()
        public virtual ActionResult Index()
        {
            return RedirectToAction(MVC.Admin.Pages.Edit());
        }
        #endregion

        #region Edit()
        public virtual ActionResult Edit()
        {
            return View(MVC.Admin.Settings.Views.Menu.Edit);
        }
        #endregion
    }
}
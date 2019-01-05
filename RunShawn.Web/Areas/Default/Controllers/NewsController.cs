using RunShawn.Core.Features.News.News;
using RunShawn.Web.Areas.Admin.Models.News;
using RunShawn.Web.Extentions;
using RunShawn.Web.Extentions.Contoller;
using System.Collections.Generic;
using System.Web.Mvc;

namespace RunShawn.Web.Areas.Default.Controllers
{
    public partial class NewsController : BaseController
    {
        #region Index()
        public virtual ActionResult Index()
        {
            return RedirectToAction(MVC.Default.News.List());
        }
        #endregion

        #region List()
        public virtual ActionResult List()
        {
            var model = ArticlesService.GetAll()
                                       .MapTo<List<ArticleListViewModel>>();

            return View(MVC.Default.News.Views.List);
        }
        #endregion

    }
}
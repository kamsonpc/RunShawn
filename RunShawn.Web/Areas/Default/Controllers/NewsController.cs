using MvcPaging;
using RunShawn.Core.Features.News.News;
using RunShawn.Web.Areas.Default.Models.News;
using RunShawn.Web.Extentions;
using RunShawn.Web.Extentions.Contoller;
using System.Collections.Generic;
using System.Web.Mvc;

namespace RunShawn.Web.Areas.Default.Controllers
{
    public partial class NewsController : BaseController
    {
        private const int _defaultPageSize = 10;


        #region Index()
        public virtual ActionResult Index()
        {
            return RedirectToAction(MVC.Default.News.List(null));
        }
        #endregion

        #region List()
        public virtual ActionResult List(int? pageIndex)
        {
            pageIndex = pageIndex.HasValue ? pageIndex.Value - 1 : 0;
            var model = ArticlesService.GetAll()
                                       .MapTo<List<ArticleListViewModel>>()
                                       .ToPagedList(pageIndex.Value, _defaultPageSize);

            return View(MVC.Default.News.Views.List, model);
        }
        #endregion

    }
}
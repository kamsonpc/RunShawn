using MvcPaging;
using RunShawn.Core.Features.News.News;
using RunShawn.Core.Features.News.News.Model;
using RunShawn.Web.Areas.Default.Models.News;
using RunShawn.Web.Extentions;
using RunShawn.Web.Extentions.Contoller;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RunShawn.Web.Areas.Default.Controllers
{
    public partial class NewsController : BaseController
    {
        private const int _defaultPageSize = 10;

        #region Dependecies

        private IArticlesService _articlesService { get; }

        public NewsController(IArticlesService articlesService)
        {
            _articlesService = articlesService;
        }
        #endregion

        #region Index()

        public virtual ActionResult Index()
        {
            return RedirectToAction(MVC.Default.News.List(null));
        }

        #endregion Index()

        #region List()

        public virtual ActionResult List(int? pageIndex)
        {
            pageIndex = pageIndex.HasValue ? pageIndex.Value - 1 : 0;
            var allArticles = _articlesService.GetAll(true)
                                       .MapTo<List<ArticleListItemViewModel>>();

            var featuredArticles = allArticles.Where(x => x.Featured == true).ToList();
            var articles = allArticles.Where(x => x.Featured == false)
                                      .ToPagedList(pageIndex.Value, _defaultPageSize);

            var model = new ArticleList
            {
                Articles = articles,
                FeaturedArticles = featuredArticles
            };

            return View(MVC.Default.News.Views.List, model);
        }

        #endregion List()

        #region Details()

        public virtual ActionResult Details(long id)
        {
            Article entity = null;
            var link = Url.Action(MVC.Default.News.Details(id));
            if (User.IsInRole(RoleTypes.Administrator.ToString()) || User.IsInRole(nameof(RoleTypes.SuperUser)))
            {
                entity = _articlesService.GetByIdForDetails(id);
            }
            else
            {
                entity = _articlesService.GetByIdForDetails(id, true);
            }

            if (entity == null)
            {
                return HttpNotFound();
            }
            var model = entity.MapTo<ArticleViewModel>();
            model.Content = HttpUtility.HtmlDecode(model.Content);

            return View(MVC.Default.News.Views.Details, model);
        }

        #endregion Details()
    }
}
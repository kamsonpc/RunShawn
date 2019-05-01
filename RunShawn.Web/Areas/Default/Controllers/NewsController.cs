using AutoMapper;
using MvcPaging;
using RunShawn.Core.Features.News.News;
using RunShawn.Core.Features.News.News.Model;
using RunShawn.Web.Areas.Default.Models.News;
using RunShawn.Web.Extentions;
using RunShawn.Web.Extentions.Contoller;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace RunShawn.Web.Areas.Default.Controllers
{
    public partial class NewsController : BaseController
    {
        #region Dependecies

        private IArticlesService _articlesService { get; }

        private IMapper _mapper { get; }

        public NewsController(IArticlesService articlesService, IMapper mapper)
        {
            _articlesService = articlesService;
            _mapper = mapper;
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

            var articlesFromDb = _articlesService.GetAll(true);
            var allArticles = _mapper.Map<List<ArticleListItemViewModel>>(articlesFromDb);

            var featuredArticles = allArticles.Where(x => x.Featured).ToList();
            var articles = allArticles.Where(x => !x.Featured)
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
            Article article;
            if (User.IsInRole(RoleTypes.Administrator.ToString()) || User.IsInRole(nameof(RoleTypes.SuperUser)))
            {
                article = _articlesService.GetByIdForDetails(id);
            }
            else
            {
                article = _articlesService.GetByIdForDetails(id, true);
            }

            if (article == null)
            {
                return HttpNotFound();
            }
            var model = _mapper.Map<ArticleViewModel>(article);

            return View(MVC.Default.News.Views.Details, model);
        }

        #endregion Details()
    }
}
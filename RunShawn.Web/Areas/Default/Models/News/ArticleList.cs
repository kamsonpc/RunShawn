using MvcPaging;
using System.Collections.Generic;

namespace RunShawn.Web.Areas.Default.Models.News
{
    public class ArticleList
    {
        public IPagedList<ArticleListItemViewModel> Articles { get; set; }
        public List<ArticleListItemViewModel> FeaturedArticles { get; set; }
    }
}
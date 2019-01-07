using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcPaging;

namespace RunShawn.Web.Areas.Default.Models.News
{
    public class ArticleList
    {
        public IPagedList<ArticleListItemViewModel> Articles { get; set; }
        public List<ArticleListItemViewModel> FeaturedArticles { get; set; }
    }
}
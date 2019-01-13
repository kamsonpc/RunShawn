using AutoMapper;
using RunShawn.Core.Features.News.News.Model;
using RunShawn.Core.Features.Pages.Model;
using RunShawn.Web.Areas.Default.Models.News;
using RunShawn.Web.Areas.Default.Models.Pages;

namespace RunShawn.Web.Areas.Default.Models
{
    public class DefaultMapProfile : Profile
    {
        public DefaultMapProfile()
        {
            CreateMap<Article, ArticleViewModel>();
            CreateMap<ArticleViewModel, Article>();
            CreateMap<ArticleListItemViewModel, Article>();
            CreateMap<Page, PageViewModel>();
        }
    }
}
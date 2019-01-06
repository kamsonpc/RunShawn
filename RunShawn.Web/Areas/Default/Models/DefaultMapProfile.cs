using AutoMapper;
using RunShawn.Core.Features.News.News.Model;
using RunShawn.Web.Areas.Default.Models.News;

namespace RunShawn.Web.Areas.Default.Models
{
    public class DefaultMapProfile : Profile
    {
        public DefaultMapProfile()
        {
            CreateMap<Article, ArticleViewModel>();
            CreateMap<ArticleViewModel, Article>();
            CreateMap<ArticleListViewModel, Article>();
        }
    }
}
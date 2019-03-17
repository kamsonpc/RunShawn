using AutoMapper;
using RunShawn.Core.Features.News.Categories.Model;
using RunShawn.Core.Features.News.News.Model;
using RunShawn.Core.Features.Pages.Model;
using RunShawn.Core.Features.Users.Model;
using RunShawn.Web.Areas.Admin.Models.News;
using RunShawn.Web.Areas.Admin.Models.Pages;
using RunShawn.Web.Areas.Admin.Models.Settings.Menu;
using RunShawn.Web.Areas.Admin.Models.Users;
using RunShawn.Web.Extentions;
using RunShawn.Web.Models;
using System.Web.UI.WebControls;

namespace RunShawn.Web.Areas.Admin.Models
{
    public class AdminMapProfile : Profile
    {
        public AdminMapProfile()
        {
            CreateMap<User, UserListViewModel>();
            CreateMap<User, UserViewModel>()
                                            .Ignore(x => x.Roles)
                                            .Ignore(x => x.RoleId);

            CreateMap<UserViewModel, ApplicationUser>()
                                            .Ignore(x => x.Id)
                                            .Ignore(x => x.PasswordHash)
                                            .Ignore(x => x.Roles)
                                            .Ignore(x => x.SecurityStamp)
                                            .Ignore(x => x.TwoFactorEnabled)
                                            .Ignore(x => x.AccessFailedCount)
                                            .Ignore(x => x.Claims)
                                            .Ignore(x => x.Logins);

            CreateMap<UserEditViewModel, User>();
            CreateMap<User, UserEditViewModel>()
                                            .Ignore(x => x.Roles)
                                            .Ignore(x => x.RoleId);


            CreateMap<Category, CategoryListViewModel>();
            CreateMap<CategoryViewModel, Category>();
            CreateMap<Category, CategoryViewModel>();


            CreateMap<ArticleViewModel, Article>();
            CreateMap<Article, ArticleViewModel>();

            CreateMap<ArticleListView, ArticleListViewModel>();

            CreateMap<PageListView, PageListViewModel>();
            CreateMap<Page, PageViewModel>();
            CreateMap<PageViewModel, Page>();

            CreateMap<MenuItem, MenuItemViewModel>();
            CreateMap<MenuItemCreateModel, MenuItem>();


            CreateMap<MenuItemViewModel, MenuItem>();

        }
    }
}
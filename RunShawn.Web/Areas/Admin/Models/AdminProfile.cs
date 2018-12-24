using AutoMapper;
using RunShawn.Core.Features.Users.Model;
using RunShawn.Web.Areas.Admin.Models.Users;
using RunShawn.Web.Extentions;
using RunShawn.Web.Models;

namespace RunShawn.Web.Areas.Admin.Models
{
    public class AdminProfile : Profile
    {
        public AdminProfile()
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
        }
    }
}
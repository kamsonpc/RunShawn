using AutoMapper;
using RunShawn.Core.Features.Users.Model;
using RunShawn.Web.Areas.Admin.Models.Users;

namespace RunShawn.Web.Areas.Admin.Models
{
    public class AdminProfile : Profile
    {
        public AdminProfile()
        {
            CreateMap<User, UserListViewModel>();
        }
    }
}
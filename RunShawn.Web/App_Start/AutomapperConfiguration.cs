using AutoMapper;
using RunShawn.Web.Areas.Admin.Models;
using RunShawn.Web.Areas.Default.Models;

namespace RunShawn.Web.App_Start
{
    public static class AutoMapperConfiguration
    {
        #region GetConfig()

        public static IMapper GetConfig()
        {
            var config = new MapperConfiguration(x =>
             {
                 x.AddProfile<AdminMapProfile>();
                 x.AddProfile<DefaultMapProfile>();
             });

            return config.CreateMapper();
        }

        #endregion GetConfig()
    }
}
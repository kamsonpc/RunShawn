using AutoMapper;
using RunShawn.Web.Areas.Admin.Models;
using RunShawn.Web.Areas.Default.Models;

namespace RunShawn.Web.App_Start
{
    public class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(x =>
            {
                x.AddProfile<AdminMapProfile>();
                x.AddProfile<DefaultMapProfile>();

            });

        }

        public static void Reset()
        {
            Mapper.Reset();
        }
    }
}
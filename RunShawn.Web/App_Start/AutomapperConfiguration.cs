using AutoMapper;
using RunShawn.Web.Areas.Admin.Models;
using RunShawn.Web.Areas.Default.Models;

namespace RunShawn.Web.App_Start
{
    public static class AutoMapperConfiguration
    {
        public static object thislock = new object();
        private static bool _initialized = false;

        #region Configure()
        public static void Configure()
        {
            lock (thislock)
            {
                if (!_initialized)
                {
                    Mapper.Initialize(x =>
                    {
                        x.AddProfile<AdminMapProfile>();
                        x.AddProfile<DefaultMapProfile>();
                    });
                    _initialized = true;
                }
            }
        }
        #endregion

        #region Reset()
        public static void Reset()
        {
            lock (thislock)
            {
                Mapper.Reset();
                _initialized = false;
            }
        }
        #endregion
    }
}
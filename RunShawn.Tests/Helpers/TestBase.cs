using RunShawn.Web.App_Start;
using System;

namespace RunShawn.Tests.Helpers
{
    public abstract class TestsBase : IDisposable
    {
        protected TestsBase()
        {
            AutoMapperConfiguration.Reset();
            AutoMapperConfiguration.Configure();
        }

        public void Dispose()
        {
        }
    }
}

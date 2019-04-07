using RunShawn.Web.App_Start;
using System;

namespace RunShawn.Tests
{
    public abstract class ControllerTestBase : IDisposable
    {
        protected ControllerTestBase()
        {
            AutoMapperConfiguration.Configure();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);

            AutoMapperConfiguration.Reset();
        }
    }
}

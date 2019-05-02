using NLog;

namespace RunShawn.Core.Base
{
    public class BaseRepository
    {
        protected BaseRepository()
        {
            Log = LogManager.GetLogger(GetType().ToString());
        }

        protected Logger Log { get; private set; }
    }
}
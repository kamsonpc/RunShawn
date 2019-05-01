using NLog;
using System.Web.Mvc;

namespace RunShawn.Web.Extentions.Contoller
{
    public class BaseController : Controller
    {
        internal const string _alert = "Alert";
        internal const int _defaultPageSize = 10;

        internal static Logger logger = LogManager.GetCurrentClassLogger();
    }
}
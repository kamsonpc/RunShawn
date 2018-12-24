using NLog;
using System.Web.Mvc;

namespace RunShawn.Web.Extentions.Contoller
{
    public class BaseController : Controller
    {
        internal const string _alert = "Alert";
        internal static Logger logger = LogManager.GetCurrentClassLogger();
    }
}
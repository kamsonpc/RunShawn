using NLog;
using System.Web.Mvc;

namespace RunShawn.Web.Extentions.Controllers
{
    public class BaseController : Controller
    {
        protected const string _alert = "Alert";
        protected const int _defaultPageSize = 10;

        protected static Logger logger = LogManager.GetCurrentClassLogger();
    }
}
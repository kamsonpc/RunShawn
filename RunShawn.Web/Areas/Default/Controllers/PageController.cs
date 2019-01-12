using System.Web.Mvc;

namespace RunShawn.Web.Controllers
{
    [RoutePrefix("Pages")]
    public partial class PagesController : Controller
    {
        [Route("{name}")]
        public virtual ActionResult Page(string name)
        {

            return View();
        }


    }
}
using Microsoft.AspNetCore.Mvc;
using RunShaw.Application.Controllers;

namespace RunShaw.Controllers
{
    public partial class UsersController : BaseController
    {
        #region Index()
        public virtual IActionResult Index()
        {
            return RedirectToAction();
        }
        #endregion

        #region List()
        public virtual IActionResult List()
        {
            return View();
        }
        #endregion
    }
}

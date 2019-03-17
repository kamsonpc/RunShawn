using RunShawn.Core.Features.Settings.Menu;
using RunShawn.Core.Features.Settings.Menu.Model;
using RunShawn.Web.Actions.Results;
using RunShawn.Web.Areas.Admin.Models.Settings.Menu;
using RunShawn.Web.Attributes;
using RunShawn.Web.Extentions;
using RunShawn.Web.Extentions.Contoller;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace RunShawn.Web.Areas.Admin.Controllers
{
    [Authorize]
    [RoutePrefix(@"Settings/Menu")]
    public partial class MenuController : BaseController
    {
        #region Index()
        public virtual ActionResult Index()
        {
            return RedirectToAction(MVC.Admin.Pages.Edit());
        }
        #endregion

        #region Edit()
        public virtual ActionResult Edit()
        {
            return View(MVC.Admin.Settings.Views.Menu.Edit);
        }
        #endregion

        #region SaveMenuSettings()
        [HttpPost]
        [AjaxOnly]
        public virtual JsonResult SaveMenuSettings(List<MenuNestedItem> model)
        {
            return Json(true);
        }
        #endregion

        #region GetMenuTree()
        [AjaxOnly]
        public virtual JsonNetActionResult GetMenuTree()
        {
            var menuItems = MenuConfigurationService.GetAll().MapTo<List<MenuItemViewModel>>();

            var nestedList = new List<MenuNestedItem>();
            var parentMenuItems = menuItems.Where(x => x.ParentId == null);

            foreach (var item in parentMenuItems)
            {
                nestedList.Add(new MenuNestedItem
                {
                    Text = item.Text,
                    Id = item.Id,
                    Icon = item.Icon,
                    Children = GetNestedMenu(menuItems, item.Id)
                });
            }

            return new JsonNetActionResult(nestedList);
        }
        #endregion

        #region GetNestedMenu()
        private static List<MenuNestedItem> GetNestedMenu(List<MenuItemViewModel> flatObjects, long? parentId)
        {
            List<MenuNestedItem> nestedMenuList = new List<MenuNestedItem>();

            foreach (var item in flatObjects.Where(x => x.ParentId == parentId.Value))
            {
                nestedMenuList.Add(new MenuNestedItem
                {
                    Text = item.Text,
                    Id = item.Id,
                    Icon = item.Icon,
                    Children = GetNestedMenu(flatObjects, item.Id)
                });
            }

            return nestedMenuList.ToList();
        }
        #endregion

        #region Create()
        [HttpPost]
        public virtual JsonResult Create(MenuItemCreateModel model)
        {
            MenuConfigurationService.Create(model.MapTo<MenuItem>());
            return Json(true);
        }
        #endregion
    }
}
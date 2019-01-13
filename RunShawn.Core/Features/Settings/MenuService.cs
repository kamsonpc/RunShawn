using RunShawn.Core.Features.Settings.Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunShawn.Core.Features.Settings
{
    public static class MenuService
    {
        #region GetAll()
        public static List<PageListView> GetAll(bool onlyActive = false)
        {
            var db = Database.Open();
            List<PageListView> pages = db.Pages.PagesListView.FindAll(db.Pages.PagesListView.DeletedDate == null);

            if (onlyActive)
            {
                pages.Where(x => x.Active);
            }

            return pages.ToList();
        }
        #endregion

        #region GetById()
        public static Page GetById(long id)
        {
            var db = Database.Open();
            Page entity = db.Pages.Pages.All()
                                        .Where(db.Pages.Pages.DeletedDate == null)
                                        .Where(db.Pages.Pages.Id == id)
                                        .SingleOrDefault();
            return entity;

        }
        #endregion

        #region Delete()
        public static void Delete(long id)
        {

        }
        #endregion
    }
}

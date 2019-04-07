using RunShawn.Core.Features.Settings.Menu.Model;
using Simple.Data;
using System.Collections.Generic;
using System.Linq;

namespace RunShawn.Core.Features.Settings.Menu
{
    public static class MenuConfigurationService
    {
        #region GetAll()

        public static List<MenuItem> GetAll()
        {
            var db = Database.Open();
            List<MenuItem> menuItems = db.Settings.Menu.All();

            return menuItems.ToList();
        }

        #endregion GetAll()

        #region GetById()

        //public static Page GetById(long id)
        //{
        //    var db = Database.Open();
        //    Page entity = db.Pages.Pages.All()
        //                                .Where(db.Pages.Pages.DeletedDate == null)
        //                                .Where(db.Pages.Pages.Id == id)
        //                                .SingleOrDefault();
        //    return entity;

        //}

        #endregion GetById()

        #region Create()

        public static MenuItem Create(MenuItem entity)
        {
            var db = Database.Open();
            db.Settings.Menu.Insert(entity);
            return entity;
        }

        #endregion Create()
    }
}
using RunShawn.Core.Features.Pages.Model;
using Simple.Data;
using Simple.Data.RawSql;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RunShawn.Core.Features.Pages
{
    public static class PagesService
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

        #region Create()
        public static Page Create(Page page, string userId)
        {
            page.CreatedBy = userId;
            page.CreatedDate = DateTime.Now;

            Database.Open().Pages.Pages.Insert(page);
            return page;
        }
        #endregion

        #region Update()
        public static Page Update(Page page, string userId)
        {
            var db = Database.Open();
            Page pageInDb = db.Pages.Pages.FindById(page.Id);

            page.CreatedBy = pageInDb.CreatedBy;
            page.CreatedDate = pageInDb.CreatedDate;
            page.ModifiedDate = DateTime.Now;
            page.ModifiedBy = userId;

            db.Pages.Pages.UpdateById(page);

            return page;
        }
        #endregion

        #region Delete()
        public static void Delete(long id, string userId)
        {
            var db = Database.Open();
            Page pageToDelete = db.Pages.Pages.FindById(id);
            pageToDelete.DeletedDate = DateTime.Now;
            pageToDelete.DeletedBy = userId;

            db.Pages.Pages.UpdateById(pageToDelete);
        }
        #endregion
    }
}

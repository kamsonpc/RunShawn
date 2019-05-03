using RunShawn.Core.Base;
using RunShawn.Core.Features.Pages.Model;
using Simple.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RunShawn.Core.Features.Pages.Repositories
{
    public class PagesRepository : BaseRepository, IPagesRepository
    {
        #region GetAll()

        public List<PageListView> GetAllInfo(bool onlyActive = false)
        {
            var db = Database.Open();
            List<PageListView> pages = db.Pages.PagesListView.FindAll(db.Pages.PagesListView.DeletedDate == null);

            if (onlyActive)
            {
                pages.Where(x => x.Active);
            }

            return pages.ToList();
        }


        public List<Page> GetAll(bool deleted = false)
        {
            var db = Database.Open();
            List<Page> pages = db.Pages.Pages.All();
            if (deleted)
            {
                pages.Where(x => x.DeletedDate == null);
            }
            return pages.ToList();
        }

        #endregion GetAll()

        #region GetById()

        public Page GetById(long id)
        {
            var db = Database.Open();
            return (Page)db.Pages.Pages.All()
                                        .Where(db.Pages.Pages.DeletedDate == null)
                                        .Where(db.Pages.Pages.Id == id)
                                        .SingleOrDefault();
        }

        #endregion GetById()

        #region GetByUrlSlug()

        public Page GetBySlug(string urlSlug)
        {
            var db = Database.Open();
            return (Page)db
                .Pages
                .Pages
                .All()
                .Where(db.Pages.Pages.DeletedDate == null)
                .Where(db.Pages.Pages.UrlSlug == urlSlug)
                .SingleOrDefault();
        }

        #endregion GetByUrlSlug()

        #region GetCountByUrlSlug()
        public int GetCountByUrlSlug(string urlSlug, long? exceptId = null)
        {
            dynamic db = Database
                .Open();

            dynamic query = db
                .Pages
                .Pages
                .All()
                .Where(db.Pages.Pages.UrlSlug == urlSlug);

            if (exceptId.HasValue)
                query = query.Where(db.Pages.Pages.Id != exceptId.Value);

            return query.Count();
        }
        #endregion

        #region Create()
        public Page Create(Page page, string userId)
        {
            page.CreatedBy = userId;
            page.CreatedDate = DateTime.Now;

            Database.Open().Pages.Pages.Insert(page);
            return page;
        }
        #endregion Create()

        #region Update()

        public Page Update(Page page, string userId)
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

        #endregion Update()

        #region Delete()

        public void Delete(long id, string userId)
        {
            var db = Database.Open();
            Page pageToDelete = db.Pages.Pages.FindById(id);
            pageToDelete.DeletedDate = DateTime.Now;
            pageToDelete.DeletedBy = userId;

            db.Pages.Pages.UpdateById(pageToDelete);
        }

        #endregion Delete()

    }
}

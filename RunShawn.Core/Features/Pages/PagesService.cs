using RunShawn.Core.Features.Pages.Model;
using Simple.Data;
using Simple.Data.RawSql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

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

        #region GetByUrlSlug()
        public static Page GetBySlug(string urlSlug)
        {
            var db = Database.Open();
            Page entity = db.Pages.Pages.All()
                                        .Where(db.Pages.Pages.DeletedDate == null)
                                        .Where(db.Pages.Pages.UrlSlug == urlSlug)
                                        .SingleOrDefault();
            return entity;

        }
        #endregion

        #region Create()
        public static Page Create(Page page, string userId)
        {
            var db = Database.Open();

            var urlSlug = page.Title.ToUrlSlug();
            int count = db.Pages.Pages.All().Where(db.Pages.Pages.UrlSlug == urlSlug).Count();
            urlSlug = UpdateSlug(count, urlSlug);


            page.CreatedBy = userId;
            page.CreatedDate = DateTime.Now;
            page.UrlSlug = urlSlug;

            db.Pages.Pages.Insert(page);
            return page;
        }
        #endregion

        #region Update()
        public static Page Update(Page page, string userId)
        {
            var db = Database.Open();
            Page pageInDb = db.Pages.Pages.FindById(page.Id);

            var urlSlug = page.Title.ToUrlSlug();
            var count = db.Pages.Pages.All()
                .Where(db.Pages.Pages.UrlSlug == urlSlug)
                .Where(db.Pages.Pages.Id != page.Id)
                .Count();

            urlSlug = UpdateSlug(count, urlSlug);

            page.CreatedBy = pageInDb.CreatedBy;
            page.CreatedDate = pageInDb.CreatedDate;
            page.ModifiedDate = DateTime.Now;
            page.ModifiedBy = userId;
            page.UrlSlug = urlSlug;


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

        #region toUrlSlug()
        private static string ToUrlSlug(this string value)
        {
            value = value.ToLowerInvariant();
            var bytes = Encoding.GetEncoding("Cyrillic").GetBytes(value);
            value = Encoding.ASCII.GetString(bytes);
            value = Regex.Replace(value, @"\s", "-", RegexOptions.Compiled);
            value = value.Trim('-', '_');
            value = Regex.Replace(value, @"([-_]){2,}", "$1", RegexOptions.Compiled);

            return value;
        }
        #endregion

        #region UpdateSlug()
        private static string UpdateSlug(int count, string urlSlug)
        {
            if (count > 0)
            {
                return $"{urlSlug}-{(count + 1)}";
            }
            return urlSlug;
        }
        #endregion
    }
}

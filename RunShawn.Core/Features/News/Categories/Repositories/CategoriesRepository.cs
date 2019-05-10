using RunShawn.Core.Features.News.Categories.Model;
using Simple.Data;
using Simple.Data.RawSql;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RunShawn.Core.Features.News.Categories.Repositories
{
    public class CategoriesRepository : ICategoriesRepository
    {
        #region GetById()

        public Category GetById(long id)
        {
            return (Category)Database.Open().News.Categories.FindById(id);
        }

        #endregion GetById()

        #region GetAll()
        public List<Category> GetAll()
        {
            return (List<Category>)Database.Open().News.Categories.All();
        }
        #endregion GetAll()

        #region GetCategoriesAndSubcategories()

        public List<Category> GetCategoriesAndSubcategories(long? exceptId = null)
        {
            var db = Database.Open();

            List<Category> categoriesAndSubcategories = new List<Category>();
            List<Category> allCategories = db.News.Categories.All();
            List<Category> parentCategories = allCategories.Where(c => c.ParentId == null)
                                                           .OrderBy(c => c.Title)
                                                           .ToList();

            foreach (var cat in parentCategories)
            {
                string depthstring = string.Empty;
                categoriesAndSubcategories.Add(new Category
                {
                    Id = cat.Id,
                    Title = cat.Title
                });
                GetSubTree(allCategories, cat, categoriesAndSubcategories, depthstring);
            }

            if (exceptId.HasValue)
            {
                categoriesAndSubcategories = categoriesAndSubcategories.Where(x => x.Id != exceptId).ToList();
            }

            return categoriesAndSubcategories;
        }

        #endregion GetCategoriesAndSubcategories()

        #region Create()

        public Category Create(Category category, string userId)
        {
            var random = new Random();
            category.Color = string.Format("#{0:x6}", random.Next(0x1000000));

            category.CreatedBy = userId;
            category.CreatedDate = DateTime.Now;

            Database.Open().News.Categories.Insert(category);
            return category;
        }

        #endregion Create()

        #region Update()

        public Category Update(Category category, string userId)
        {
            var entity = GetById(category.Id);

            category.CreatedDate = entity.CreatedDate;
            category.CreatedBy = entity.CreatedBy;
            category.ModifiedBy = userId;
            category.ModifiedDate = DateTime.Now;

            Database.Open().News.Categories.UpdateById(category);
            return category;
        }

        #endregion Update()

        #region Delete()

        public void Delete(long id)
        {
            Database db = Database.Open();
            const string sql = @"
                       UPDATE
                           News.Categories
                       SET
                           ParentId = NULL
                       WHERE
                            ParentId = @Id";

            db.Execute(sql, new { Id = id });

            Database.Open().News.Categories.DeleteById(id);
        }

        #endregion Delete()

        #region GetSubTree()

        private void GetSubTree(IList<Category> allCats, Category parent, IList<Category> items, string depthstring)
        {
            depthstring = $"-{depthstring}";
            foreach (var cat in allCats.Where(c => c.ParentId == parent.Id).ToList())
            {
                items.Add(new Category
                {
                    Title = $"{depthstring} {cat.Title}",
                    Id = cat.Id
                });

                GetSubTree(allCats, cat, items, depthstring);
            }
        }

        #endregion GetSubTree()
    }
}
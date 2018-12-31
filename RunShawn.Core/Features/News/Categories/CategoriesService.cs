using RunShawn.Core.Features.News.Categories.Model;
using Simple.Data;
using Simple.Data.RawSql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RunShawn.Core.Features.News.Categories
{
    public class CategoriesService
    {
        #region GetCategoriesAndSubcategories()
        public static List<Category> GetCategoriesAndSubcategories(long? exceptId = null)
        {
            var db = Database.Open();

            List<Category> categoriesAndSubcategories = new List<Category>();
            List<Category> allCategories = db.News.Categories.All();
            List<Category> parentCategories = allCategories.Where(c => c.ParentId == null)
                                                           .OrderBy(c => c.Title)
                                                           .ToList();

            foreach (var cat in parentCategories)
            {
                categoriesAndSubcategories.Add(new Category
                {
                    Id = cat.Id,
                    Title = cat.Title
                });
                GetSubTree(allCategories, cat, categoriesAndSubcategories);
            }

            if (exceptId.HasValue)
            {
                categoriesAndSubcategories = categoriesAndSubcategories.Where(x => x.Id != exceptId).ToList();
            }

            return categoriesAndSubcategories;
        }
        #endregion

        #region Create()
        public static Category Create(Category category, string userId)
        {
            category.CreatedBy = userId;
            category.CreatedDate = DateTime.Now;

            Database.Open().News.Categories.Insert(category);
            return category;
        }
        #endregion

        #region Delete()
        public static void Delete(long id)
        {
            Database db = Database.Open();
            var sql = @"
                       UPDATE
                           News.Categories
                       SET 
                           ParentId = NULL 
                       WHERE 
                            ParentId = @Id";

            db.Execute(sql, new { Id = id });

            Database.Open().News.Categories.DeleteById(id);
        }
        #endregion

        #region CountDepth()
        private static int CountDepth(Category category, Category parent, char specialChar = '-')
        {

            int depth = 0;
            for (int i = 0; i < parent.Title.Length; i++)
            {
                if (parent.Title[i] == specialChar)
                    depth++;
                else
                    break;
            }

            if (depth == 0 && category.ParentId != null)
                return 1;
            return depth;
        }
        #endregion

        #region GenerateDepthString()
        private static string GenerateDepthString(int count, char specialChar = '-')
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < count; i++)
            {
                sb.Append(specialChar);
            }
            return sb.ToString();
        }
        #endregion

        #region GetSubTree()
        private static void GetSubTree(IList<Category> allCats, Category parent, IList<Category> items)
        {
            var subCats = allCats.Where(c => c.ParentId == parent.Id).ToList();
            foreach (var cat in subCats)
            {
                var deeplevel = CountDepth(cat, parent);
                var depthstring = GenerateDepthString(deeplevel);

                items.Add(new Category
                {
                    Title = depthstring + cat.Title,
                    Id = cat.Id
                });

                GetSubTree(allCats, cat, items);
            }
        }
        #endregion
    }
}

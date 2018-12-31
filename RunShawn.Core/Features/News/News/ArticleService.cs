using RunShawn.Core.Features.News.News.Model;
using Simple.Data;
using Simple.Data.RawSql;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RunShawn.Core.Features.News.News
{
    public class ArticlesService
    {
        #region GetById()
        public static Article GetById(long id)
        {
            return (Article)Database.Open().News.News.FindById(id);

        }
        #endregion

        #region GetByCategory()
        public static List<Article> GetByCategory(long id)
        {
            List<Article> articles = Database.Open().News.News.FindByCategoryId(id);
            return articles;
        }
        #endregion

        #region Create()
        public static Article Create(Article article, string userId)
        {
            article.CreatedBy = userId;
            article.CreatedDate = DateTime.Now;

            Database.Open().News.News.Insert(article);
            return article;
        }
        #endregion

        #region GetAll()
        public static List<ArticleListView> GetAll()
        {
            List<ArticleListView> articles = Database.Open().News.NewsListView.All();

            return articles
                           .Where(x => x.DeletedDate == null)
                           .ToList();
        }
        #endregion

        #region Update()
        public static Article Update(Article article, string userId)
        {
            var db = Database.Open();
            var articleInDb = GetById(article.Id);

            article.CreatedBy = articleInDb.CreatedBy;
            article.CreatedDate = articleInDb.CreatedDate;
            article.ModifiedDate = DateTime.Now;
            article.ModifiedBy = userId;

            db.News.News.UpdateById(article);

            return article;
        }
        #endregion

        #region MoveArticles()
        public static void Move(long currentCategoryId, long newCategoryId)
        {
            Database db = Database.Open();
            var sql = @"
                       UPDATE
                           News.News
                       SET 
                           CategoryId = @NewCategoryId 
                       WHERE 
                            CategoryId = @CurrentCategoryId";

            db.Execute(sql, new
            {
                CurrentCategoryId = currentCategoryId,
                NewCategoryId = newCategoryId
            });
        }
        #endregion

        #region Delete()
        public static void Delete(long id, string userId)
        {
            var db = Database.Open();
            Article articleToDelete = db.News.News.FindById(id);
            articleToDelete.DeletedDate = DateTime.Now;
            articleToDelete.DeletedBy = userId;

            db.News.News.UpdateById(articleToDelete);
        }
        #endregion
    }
}

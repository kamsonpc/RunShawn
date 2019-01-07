using System;
using System.Collections.Generic;
using System.Linq;
using RunShawn.Core.Features.News.News.Model;
using Simple.Data;
using Simple.Data.RawSql;

namespace RunShawn.Core.Features.News.News
{
    public class ArticlesService
    {
        #region GetById()
        public static Article GetById(long id)
        {
            var db = Database.Open();
            Article entity = db.News.News.Where(db.News.News.DeletedDate == null)
                                         .Where(db.News.News.Id == id);
            return entity;

        }
        #endregion

        #region GetByIdForDetails()
        public static Article GetByIdForDetails(long id, bool onlyPublished = false)
        {
            var db = Database.Open();
            var query = db.News.News.All()
                                .Where(db.News.News.DeletedDate == null)
                                .Where(db.News.News.Id == id);


            if (onlyPublished)
            {
                query = query.Where(db.News.News.PublishDate <= DateTime.Now);
            }

            Article article = query.SingleOrDefault();

            return article;
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
            article.Featured = false;

            Database.Open().News.News.Insert(article);
            return article;
        }
        #endregion

        #region GetAll()
        public static List<ArticleListView> GetAll(bool onlyPublished = false)
        {
            var db = Database.Open();
            List<ArticleListView> articles = db.News.NewsListView.FindAll(db.News.NewsListView.DeletedDate == null);

            if (onlyPublished)
            {
                articles.Where(x => x.PublishDate <= DateTime.Now);
            }

            return articles
                           .ToList();
        }
        #endregion

        #region Update()
        public static Article Update(Article article, string userId)
        {
            var db = Database.Open();
            Article articleInDb = db.News.News.FindById(article.Id);

            article.Featured = articleInDb.Featured;
            article.CreatedBy = articleInDb.CreatedBy;
            article.CreatedDate = articleInDb.CreatedDate;
            article.ModifiedDate = DateTime.Now;
            article.ModifiedBy = userId;

            db.News.News.UpdateById(article);

            return article;
        }
        #endregion

        #region Feature()
        public static void Feature(long id)
        {
            var db = Database.Open();
            Article articleToFeature = db.News.News.FindById(id);
            if (articleToFeature.Featured)
            {
                articleToFeature.Featured = false;
            }
            else
            {
                articleToFeature.Featured = true;
            }
            db.News.News.UpdateById(articleToFeature);
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

using RunShawn.Core.Features.News.News.Model;
using Simple.Data;
using Simple.Data.RawSql;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RunShawn.Core.Features.News.News
{
    public class ArticlesService : IArticlesService
    {
        #region GetById()

        public Article GetById(long id)
        {
            var db = Database.Open();
            return (Article)db.News.News.All()
                              .Where(db.News.News.DeletedDate == null)
                              .Where(db.News.News.Id == id)
                              .SingleOrDefault();
        }

        #endregion GetById()

        #region GetByIdForDetails()

        public Article GetByIdForDetails(long id, bool onlyPublished = false)
        {
            var db = Database.Open();
            var query = db.News.News.All()
                               .Where(db.News.News.DeletedDate == null)
                               .Where(db.News.News.Id == id);

            if (onlyPublished)
            {
                query = query.Where(db.News.News.PublishDate <= DateTime.Now);
            }

            return (Article)query.SingleOrDefault();
        }

        #endregion GetByIdForDetails()

        #region GetByCategory()

        public List<Article> GetByCategory(long id)
        {
            return (List<Article>)Database.Open().News.News.FindByCategoryId(id);
        }

        #endregion GetByCategory()

        #region Create()

        public Article Create(Article article, string userId)
        {
            article.CreatedBy = userId;
            article.CreatedDate = DateTime.Now;
            article.Featured = false;

            Database.Open().News.News.Insert(article);
            return article;
        }

        #endregion Create()

        #region GetAll()

        public List<ArticleListView> GetAll(bool onlyPublished = false)
        {
            var db = Database.Open();
            List<ArticleListView> articles = db.News.NewsListView
                                               .FindAll(db.News.NewsListView.DeletedDate == null);

            if (onlyPublished)
            {
                articles.Where(x => x.PublishDate <= DateTime.Now);
            }

            return articles.ToList();
        }

        #endregion GetAll()

        #region Update()

        public Article Update(Article article, string userId)
        {
            Database.Open().News.News.UpdateById(
                Id: article.Id,
                Title: article.Title,
                Content: article.Content,
                PublishDate: article.PublishDate,
                CategoryId: article.CategoryId,
                ModifiedDate: DateTime.Now,
                ModifiedBy: userId
                );

            return article;
        }

        #endregion Update()

        #region Feature()

        public void Feature(long id)
        {
            var db = Database.Open();
            Article articleToFeature = db.News.News.FindById(id);
            articleToFeature.Featured = !articleToFeature.Featured;

            db.News.News.UpdateById(articleToFeature);
        }

        #endregion Feature()

        #region MoveArticles()

        public void Move(long currentCategoryId, long newCategoryId)
        {
            Database db = Database.Open();
            const string sql = @"
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

        #endregion MoveArticles()

        #region Restore()

        public void Restore(long id)
        {
            Database.Open().News.News.UpdateById
            (
                Id: id,
                DeletedBy: null,
                DeletedDate: null
            );
        }

        #endregion Restore()

        #region Delete()

        public void Delete(long id, string userId)
        {
            Database.Open().News.News.UpdateById
            (
                Id: id,
                DeletedBy: userId,
                DeletedDate: DateTime.Now
            );
        }

        #endregion Delete()
    }
}
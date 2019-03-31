using RunShawn.Core.Features.News.News.Model;
using System.Collections.Generic;

namespace RunShawn.Core.Features.News.News
{
    public interface IArticlesService
    {
        #region GetById()

        Article GetById(long id);

        #endregion GetById()

        #region GetByIdForDetails()

        Article GetByIdForDetails(long id, bool onlyPublished = false);

        #endregion GetByIdForDetails()

        #region GetByCategory()

        List<Article> GetByCategory(long id);

        #endregion GetByCategory()

        #region Create()

        Article Create(Article article, string userId);

        #endregion Create()

        #region GetAll()

        List<ArticleListView> GetAll(bool onlyPublished = false);

        #endregion GetAll()

        #region Update()

        Article Update(Article article, string userId);

        #endregion Update()

        #region Feature()

        void Feature(long id);

        #endregion Feature()

        #region MoveArticles()

        void Move(long currentCategoryId, long newCategoryId);

        #endregion MoveArticles()

        #region Restore()

        void Restore(long id);

        #endregion Restore()

        #region Delete()

        void Delete(long id, string userId);

        #endregion Delete()
    }
}
using System.Collections.Generic;
using RunShawn.Core.Features.News.Categories.Model;

namespace RunShawn.Core.Features.News.Categories.Repositories
{
    public interface ICategoriesRepository
    {
        Category Create(Category category, string userId);
        void Delete(long id);
        List<Category> GetAll();
        Category GetById(long id);
        List<Category> GetCategoriesAndSubcategories(long? exceptId = null);
        Category Update(Category category, string userId);
    }
}
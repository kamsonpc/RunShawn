using System.Collections.Generic;

namespace RunShawn.Core.Features.News.Categories.Model
{
    public class CategoryAndSubcategory
    {
        public long Id { get; set; }
        public string Title { get; set; }

        public List<Category> Subcategories { get; set; }
    }
}

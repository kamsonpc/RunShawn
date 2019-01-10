using System;

namespace RunShawn.Core.Features.News.Categories.Model
{
    public class Category
    {
        public long Id { get; set; }
        public long? ParentId { get; set; }
        public string Title { get; set; }
        public string Color { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string DeletedBy { get; set; }
        public DateTime? DeletedDate { get; set; }
    }

    public enum CategoryDeleteErrors
    {
        HasArticles = 20,
        NoError = 10
    }
}

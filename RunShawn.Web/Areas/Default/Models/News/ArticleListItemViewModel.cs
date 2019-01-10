using System;

namespace RunShawn.Web.Areas.Default.Models.News
{
    public class ArticleListItemViewModel
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public long CategoryId { get; set; }
        public string CategoryTitle { get; set; }
        public string CategoryColor { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public DateTime PublishDate { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedByName { get; set; }
        public string FeaturedImage { get; set; }
        public bool Featured { get; set; }

    }
}
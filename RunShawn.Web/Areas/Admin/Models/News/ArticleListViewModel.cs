using System;

namespace RunShawn.Web.Areas.Admin.Models.News
{
    public class ArticleListViewModel
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string CategoryTitle { get; set; }
        public DateTime PublishDate { get; set; }
        public string CreatedByName { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
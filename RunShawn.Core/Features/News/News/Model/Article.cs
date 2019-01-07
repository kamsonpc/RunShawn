using System;

namespace RunShawn.Core.Features.News.News.Model
{
    public class Article
    {
        public long Id { get; set; }
        public bool Featured { get; set; }
        public string Title { get; set; }
        public long CategoryId { get; set; }
        public string Content { get; set; }
        public DateTime PublishDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string DeletedBy { get; set; }
        public DateTime? DeletedDate { get; set; }
    }
}

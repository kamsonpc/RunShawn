using System;

namespace RunShawn.Core.Features.Pages.Model
{
    public class PageListView
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public bool Active { get; set; }
        public string Content { get; set; }
        public string UrlSlug { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedByName { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string DeletedBy { get; set; }
        public DateTime? DeletedDate { get; set; }
    }
}
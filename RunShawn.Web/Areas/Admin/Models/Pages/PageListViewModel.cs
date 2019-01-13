using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RunShawn.Web.Areas.Admin.Models.Pages
{
    public class PageListViewModel
    {
        public long Id { get; set; }
        public string UrlSlug { get; set; }
        public string Title { get; set; }
        public bool Active { get; set; }
        public string Content { get; set; }
        public string CreatedByName { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ActiveText => Active ? "Tak" : "Nie";
    }
}
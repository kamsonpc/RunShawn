using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace RunShawn.Web.Areas.Admin.Models.News
{
    public class CategoryViewModel
    {
        public long Id { get; set; }
        public string Title { get; set; }

        [Display(Name = "Kategoria Nadrzędna")]
        public long? ParentId { get; set; }

        public List<SelectListItem> Categories { get; set; }
    }
}
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace RunShawn.Web.Areas.Admin.Models.News
{
    public class ArticlesMoveViewModel
    {
        [Required]
        public long CurrentCategoryId { get; set; }

        [Display(Name = "Nowa Kategoria")]
        [Required]
        public long NewCategoryId { get; set; }

        public List<SelectListItem> Categories { get; set; }
    }
}
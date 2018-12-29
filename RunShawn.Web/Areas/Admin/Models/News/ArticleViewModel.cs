using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace RunShawn.Web.Areas.Admin.Models.News
{
    public class ArticleViewModel
    {
        public long Id { get; set; }
        [Required]
        public string Title { get; set; }

        [Required]
        [AllowHtml]

        public string Content { get; set; }

        [Required]
        [Display(Name = "Kategoria")]
        public int CategoryId { get; set; }

        [Required]
        public DateTime PublishDate { get; set; }

        public List<SelectListItem> Categories { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RunShawn.Web.Areas.Admin.Models.Pages
{
    public class PageViewModel
    {
        public long Id { get; set; }

        [Required]
        [Display(Name = "Nazwa")]
        public string Title { get; set; }

        [Display(Name = "Aktywna")]
        public bool Active { get; set; }

        [Display(Name = "Treść")]
        [AllowHtml]
        [Required]
        public string Content { get; set; }

    }
}
using System;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace RunShawn.Web.Areas.Admin.Models.Settings.Menu
{
    public class MenuItemCreateModel
    {
        public long Id { get; set; }
        public long? ParentId { get; set; }
        public long PageId
        {
            get
            {
                Uri parsedUrl = new Uri(Url);
                long id = long.Parse(HttpUtility.ParseQueryString(parsedUrl.Query).Get("id"));
                return id;
            }
        }
        public string Icon { get; set; }

        [Display(Name = "Tekst")]
        public string Text { get; set; }

        [Display(Name = "Adres Url")]
        public string Url { get; set; }

    }
}
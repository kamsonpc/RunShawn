﻿using System;
using RunShawn.Web.Extentions.Icons;

namespace RunShawn.Web.Areas.Admin.Models.News
{
    public class ArticleListViewModel
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public bool Feature { get; set; }
        public string CategoryTitle { get; set; }
        public DateTime PublishDate { get; set; }
        public string CreatedByName { get; set; }
        public DateTime CreatedDate { get; set; }

        public string FeatureIcon
        {
            get
            {
                if (Feature)
                {
                    return AwesomeHelper.star;
                }
                else
                {
                    return AwesomeHelper.star_o;
                }

            }
        }
    }
}
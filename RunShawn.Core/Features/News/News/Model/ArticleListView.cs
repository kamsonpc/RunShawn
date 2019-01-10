using System;
using System.Text.RegularExpressions;

namespace RunShawn.Core.Features.News.News.Model
{
    public class ArticleListView
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public long CategoryId { get; set; }
        public string CategoryTitle { get; set; }
        public string CategoryColor { get; set; }
        public string Content { get; set; }
        public DateTime PublishDate { get; set; }
        public string CreatedByName { get; set; }
        public bool Featured { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string DeletedBy { get; set; }
        public DateTime? DeletedDate { get; set; }

        #region FeaturedImage
        public string FeaturedImage
        {
            get
            {
                if(string.IsNullOrEmpty(this.Content))
                {
                    return string.Empty;
                }
                return Regex.Match(this.Content, "<img.+?src=[\"'](.+?)[\"'].*?>", RegexOptions.IgnoreCase).Groups[1]?.Value;
            }
        }
        #endregion

        #region Description
        public string Description
        {
            get
            {
                if (string.IsNullOrEmpty(this.Content))
                {
                    return string.Empty;
                }
                return Regex.Match(this.Content, @"<p>\s*(.+?)\s*</p>", RegexOptions.IgnoreCase).Groups[1]?.Value;
            }
        }
        #endregion
    }
}

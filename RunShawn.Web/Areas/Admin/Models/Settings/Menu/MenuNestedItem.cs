using System.Collections.Generic;
using System.Runtime.Serialization;

namespace RunShawn.Web.Areas.Admin.Models.Settings.Menu
{
    [DataContract]
    public class MenuNestedItem
    {
        public MenuNestedItem()
        {
            Children = new List<MenuNestedItem>();
        }

        [DataMember(Name = "text")]
        public string Text { get; set; }

        [DataMember(Name = "href")]
        public string Href { get; set; }

        [DataMember(Name = "icon")]
        public string Icon { get; set; }

        [DataMember(Name = "target")]
        public string Target { get; set; }

        [DataMember(Name = "title")]
        public string Title { get; set; }

        [DataMember(Name = "id")]
        public long Id { get; set; }

        [DataMember(Name = "parentId")]
        public long? ParentId { get; set; }

        [DataMember(Name = "children")]
        public List<MenuNestedItem> Children { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunShawn.Core.Features.Settings.Menu
{
    public class MenuItemView
    {
        public long Id { get; set; }
        public long? ParentId { get; set; }
        public long UrlSlug { get; set; }
        public string Icon { get; set; }
        public string Name { get; set; }
        public int Order { get; set; }

    }
}

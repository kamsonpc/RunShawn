using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunShawn.Core.Features.Settings.Menu
{
    public class MenuTree
    {
        public long Id { get; set; }
        public long PageId { get; set; }
        public string Icon { get; set; }
        public List<MenuItem> Children { get; set; }
    }
}

using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RunShawn.Web.Models
{
    public class Menu
    {
        public Menu()
        {
            SubMenus = new List<SubMenu>();
        }
        public string Name { get; set; }
        public string CssIcon { get; set; }
        public string Url { get; set; }
        public List<SubMenu> SubMenus { get; set; }
        public string ParentControllerFullName { get; set; }
        public string ControllerFullName { get; set; }
        public int Order { get; set; }
    }

    public class SubMenu
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public string CssIcon { get; set; }
        public int Order { get; set; }
    }
}
using System;

namespace RunShawn.Web.Extentions.Attributes
{
    #region MenuItemAttribute

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class MenuItemAttribute : Attribute
    {
        public MenuItemAttribute()
        {
            IsClickable = true;
        }

        public bool IsClickable { get; set; }
        public string Title { get; set; }
        public string Action { get; set; }
        public string CssIcon { get; set; }
        public int Order { get; set; }
        public Type ParentController { get; set; }
    }

    #endregion MenuItemAttribute
}
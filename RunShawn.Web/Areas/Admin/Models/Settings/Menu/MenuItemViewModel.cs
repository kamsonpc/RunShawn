namespace RunShawn.Web.Areas.Admin.Models.Settings.Menu
{
    public class MenuItemViewModel
    {
        public long Id { get; set; }
        public long? ParentId { get; set; }
        public string Icon { get; set; }
        public string Text { get; set; }
    }
}
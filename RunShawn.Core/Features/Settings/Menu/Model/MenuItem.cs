namespace RunShawn.Core.Features.Settings.Menu.Model
{
    public class MenuItem
    {
        public long Id { get; set; }
        public long? ParentId { get; set; }
        public long PageId { get; set; }
        public string Icon { get; set; }
        public string Text { get; set; }
    }
}
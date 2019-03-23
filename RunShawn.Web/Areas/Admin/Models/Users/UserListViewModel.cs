namespace RunShawn.Web.Areas.Admin.Models.Users
{
    public class UserListViewModel
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => $"{FirstName} {LastName}";
        public long? Scores { get; set; }
    }
}
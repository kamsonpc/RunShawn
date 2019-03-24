using System.ComponentModel;

namespace RunShawn.Web.Extentions
{
    public enum RoleTypes
    {
        [Description("Administrator")]
        Administrator = 10,

        [Description("SuperUser")]
        SuperUser = 30,

        [Description("Manager")]
        Manager = 20,


        [Description("Customer")]
        Customer = 40
    }
}
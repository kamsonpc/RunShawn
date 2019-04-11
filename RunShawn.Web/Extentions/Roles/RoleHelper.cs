using System;

namespace RunShawn.Web.Extentions.Roles
{
    public static class RoleHelper
    {
        public static string GetRoleString(RoleTypes[] roleTypes)
        {
            if (roleTypes == null)
            {
                throw new ArgumentNullException(nameof(roleTypes));
            }

            return string.Empty;
        }
    }
}
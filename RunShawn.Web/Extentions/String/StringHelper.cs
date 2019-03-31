using System.Text;
using System.Text.RegularExpressions;

namespace RunShawn.Web.Extentions
{
    public static class StringHelper
    {
        #region toUrlSlug()

        public static string ToUrlSlug(this string value)
        {
            value = value.ToLowerInvariant();
            var bytes = Encoding.GetEncoding("Cyrillic").GetBytes(value);
            value = Encoding.ASCII.GetString(bytes);
            value = Regex.Replace(value, @"\s", "-", RegexOptions.Compiled);
            value = value.Trim('-', '_');
            value = Regex.Replace(value, @"([-_]){2,}", "$1", RegexOptions.Compiled);

            return value;
        }

        #endregion toUrlSlug()
    }
}
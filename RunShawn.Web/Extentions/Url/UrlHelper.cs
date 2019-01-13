using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace RunShawn.Web.Extentions
{
    public static class UrlUtil
    {
        #region GetBaseUrl()
        public static string GetBaseUrl()
        {
            var request = HttpContext.Current.Request;
            var appUrl = HttpRuntime.AppDomainAppVirtualPath;

            var baseUrl = string.Format("{0}://{1}{2}",
                                        request.Url.Scheme,
                                        request.Url.Authority,
                                        appUrl);

            return baseUrl;
        }
        #endregion

        #region GetPageUrl()
        public static string GetPageUrl(string slug)
        {
            var baseUrl = GetBaseUrl();
            return $"{baseUrl}/Pages/{slug}";
        }
        #endregion
    }
}
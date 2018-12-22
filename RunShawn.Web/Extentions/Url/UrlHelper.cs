using System.Web;

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
    }
}
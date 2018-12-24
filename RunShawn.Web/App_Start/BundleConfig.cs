using System.Web.Optimization;

namespace RunShawn.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/sidebar.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/tooltip/jquery.darktooltip.js",
                      "~/Scripts/tooltip/tooltipCustom.js"
                      ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.min.css",
                      "~/Content/tooltip/darktooltip.css",
                      "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/dashboard").Include(
                      "~/Content/dashboard/dashboard.css"));

            bundles.Add(new StyleBundle("~/Content/css/login").Include(
                      "~/Content/bootstrap.min.css",
                      "~/Content/login/login_form.css"));


        }
    }
}

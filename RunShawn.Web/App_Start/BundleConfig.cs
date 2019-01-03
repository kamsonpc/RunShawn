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

            bundles.Add(new ScriptBundle("~/bundles/validate").Include(
                        "~/Scripts/validate/jquery.validate*",
                        "~/Scripts/validate/bootstrap-validate.js"));

            bundles.Add(new ScriptBundle("~/bundles/js").Include(
                        "~/Scripts/nprogress/nprogress.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/tooltip/jquery.darktooltip.js",
                      "~/Scripts/summernote/summernote-lite.js",
                      "~/Scripts/summernote/summernote-init.js"));
            
            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/nprogress/nprogress.css",
                      "~/Content/bootstrap.min.css",
                      "~/Content/tooltip/darktooltip.css",
                      "~/Content/summernote/summernote-lite.css",
                      "~/Content/site/site.css"));

            bundles.Add(new StyleBundle("~/Content/article").Include(
                      "~/Content/article/style.css"));

            bundles.Add(new StyleBundle("~/Content/dashboard").Include(
                      "~/Content/dashboard/dashboard.css",
                      "~/Contant/modal-style/modal.css"));

            bundles.Add(new StyleBundle("~/Content/css/login").Include(
                      "~/Content/login/login.css"));
        }
    }
}

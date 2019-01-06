using System.Web.Optimization;

[assembly: WebActivatorEx.PostApplicationStartMethod(typeof(RunShawn.Web.App_Start.DatePickerHelperBundleConfig), "RegisterBundles")]

namespace RunShawn.Web.App_Start
{
    public class DatePickerHelperBundleConfig
    {
        public static void RegisterBundles()
        {
            BundleTable.Bundles.Add(new ScriptBundle("~/bundles/datepicker").Include(
            "~/Scripts/datepicker/bootstrap-datepicker.js",
            "~/Scripts/datepicker/locales/bootstrap-datepicker.pl.js",
            "~/Scripts/datepicker/bootstrap-datepicker-init.js"
            ));

            BundleTable.Bundles.Add(new StyleBundle("~/Content/datepicker").Include(
            "~/Content/datepicker/bootstrap-datepicker.min.css"));
        }
    }
}
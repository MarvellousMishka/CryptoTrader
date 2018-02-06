using System.Web;
using System.Web.Optimization;

namespace LAP_PowerMining
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Verwenden Sie die Entwicklungsversion von Modernizr zum Entwickeln und Erweitern Ihrer Kenntnisse. Wenn Sie dann
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            //ADDED Manually

            bundles.Add(new StyleBundle("~/content/toastr", "http://cdnjs.cloudflare.com/ajax/libs/toastr.js/latest/css/toastr.min.css")
                .Include("~/Content/toastr.css"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            bundles.Add(new ScriptBundle("~/bundles/toastr", "http://cdnjs.cloudflare.com/ajax/libs/toastr.js/latest/js/toastr.min.js")
                            .Include("~/Scripts/toastr.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                        "~/Scripts/jquery-ui-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/chartjs").Include(
                        "~/Scripts/Chart.js"));


            bundles.Add(new StyleBundle("~/Content/themes/base/css").Include(
                          "~/Content/themes/base/jquery.ui.core.css",
                          "~/Content/themes/base/jquery.ui.resizable.css",
                          "~/Content/themes/base/jquery.ui.selectable.css",
                          "~/Content/themes/base/jquery.ui.accordion.css",
                          "~/Content/themes/base/jquery.ui.autocomplete.css",
                          "~/Content/themes/base/jquery.ui.button.css",
                          "~/Content/themes/base/jquery.ui.dialog.css",
                          "~/Content/themes/base/jquery.ui.slider.css",
                          "~/Content/themes/base/jquery.ui.tabs.css",
                          "~/Content/themes/base/jquery.ui.datepicker.css",
                          "~/Content/themes/base/jquery.ui.progressbar.css",
                          "~/Content/themes/base/jquery.ui.theme.css"));
            
        }
    }
}

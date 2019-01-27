using System.Web;
using System.Web.Optimization;

namespace cobom
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/headerJS").Include(
               
                     "~/Scripts/ckeditor/ckeditor.js",
                     "~/Scripts/ckeditor/samples/js/sample.js"
                     ));

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.min.js",
                                               "~/Scripts/easing.js",
                                               "~/Scripts/jquery.magnific-popup.js",
                                               "~/Scripts/lightbox-plus-jquery.min.js",
                                               "~/Scripts/main.js",
                                               "~/Scripts/move-top.js",
                                               "~/Scripts/responsiveslides.min.js",
                                              
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.min.css",
                      "~/Content/font-awesome.css",
                      "~/Content/lightbox.css",
                      "~/Content/style.css"));
        }
    }
}

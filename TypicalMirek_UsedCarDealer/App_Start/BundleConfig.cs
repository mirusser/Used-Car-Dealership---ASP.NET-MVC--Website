using System.Web.Optimization;

namespace TypicalMirek_UsedCarDealer
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/bootstrap.min.css",
                      "~/Content/site.css",
                      "~/Content/fileinput.css",
                      "~/Content/fileinput.min.css"));

            bundles.Add(new ScriptBundle("~/bundles/AdminMenu").Include(
                      "~/Scripts/sidenav.min.js"));

            bundles.Add(new StyleBundle("~/Content/AdminMenu").Include(
                      "~/Content/sidenav.css"));

            bundles.Add(new ScriptBundle("~/bundles/HomeSlider").Include(
                      "~/Scripts/responsiveslides.min.js"));

            bundles.Add(new StyleBundle("~/Content/HomeSlider").Include(
                      "~/Content/responsiveslides.css"));

            bundles.Add(new ScriptBundle("~/bundles/OneScrollHeader").Include(
                      "~/Scripts/jquery.oneScrollHeader.js"));

            bundles.Add(new StyleBundle("~/Content/OneScrollHeader").Include(
                      "~/Content/jquery.oneScrollHeader.css"));

            bundles.Add(new StyleBundle("~/Content/HoverGallery").Include(
                      "~/Content/hovergallery.css"));

            bundles.Add(new ScriptBundle("~/bundles/HideNavbar").Include(
                      "~/Scripts/jquery.bootstrap-autohidingnavbar.js"));
        }
    }
}

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
                      "~/Scripts/slippry.min.js"));

            bundles.Add(new StyleBundle("~/Content/HomeSlider").Include(
                      "~/Content/slippry.css"));

            bundles.Add(new ScriptBundle("~/bundles/OneScrollHeader").Include(
                      "~/Scripts/onescrollheader.js"));

            bundles.Add(new StyleBundle("~/Content/OneScrollHeader").Include(
                      "~/Content/onescrollheader.css"));

            bundles.Add(new StyleBundle("~/Content/ProductShopSlider").Include(
                      "~/Content/elastislide.css"));

            bundles.Add(new ScriptBundle("~/bundles/ProductShopSlider").Include(
                      "~/Scripts/elastislide.js"));

            bundles.Add(new ScriptBundle("~/bundles/HideNavbar").Include(
                      "~/Scripts/bootstrap-autohidingnavbar.js"));

            bundles.Add(new ScriptBundle("~/bundles/Tabs").Include(
                      "~/Scripts/pwstabs.js"));

            bundles.Add(new StyleBundle("~/Content/Tabs").Include(
                      "~/Content/pwstabs.css"));

            bundles.Add(new ScriptBundle("~/bundles/CssAnimate").Include(
                "~/Scripts/mb.browser.min.js",
                "~/Scripts/mb.CSSAnimate.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/CarGallery").Include(
                      "~/Scripts/mb.thumbGallery.js"));

            bundles.Add(new StyleBundle("~/Content/CarGallery").Include(
                      "~/Content/thumbGrid.css"));

            bundles.Add(new ScriptBundle("~/bundles/ProductList").Include(
                      "~/Scripts/mb.thumbGallery.js"));

            bundles.Add(new StyleBundle("~/Content/ProductList").Include(
                      "~/Content/thumbGrid.css"));
        }
    }
}

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
                      "~/Scripts/sidenav.js"));

            bundles.Add(new StyleBundle("~/Content/AdminMenu").Include(
                      "~/Content/sidenav.css"));

            bundles.Add(new ScriptBundle("~/bundles/HomeSlider").Include(
                      "~/Scripts/slippry.min.js"));

            bundles.Add(new StyleBundle("~/Content/HomeSlider").Include(
                      "~/Content/slippry.css"));

            bundles.Add(new StyleBundle("~/Content/ProductShopSlider").Include(
                      "~/Content/elastislide.css"));

            bundles.Add(new ScriptBundle("~/bundles/ProductShopSlider").Include(
                      "~/Scripts/elastislide.js"));

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

            bundles.Add(new StyleBundle("~/Content/car-list").Include(
                      "~/Content/car-list.css"));

            bundles.Add(new ScriptBundle("~/bundles/DependendDropdown").Include(
                      "~/Scripts/dependent-dropdown.js"));

            bundles.Add(new StyleBundle("~/Content/DependendDropdown").Include(
                      "~/Content/dependent-dropdown.css"));

            bundles.Add(new ScriptBundle("~/bundles/WYSIWYG").Include(
                      "~/Scripts/summernote.js"));

            bundles.Add(new StyleBundle("~/Content/WYSIWYG").Include(
                      "~/Content/summernote.css"));

            bundles.Add(new ScriptBundle("~/bundles/sendWysiwygPost").Include(
                      "~/Scripts/sendWysiwygPost.js"));

            bundles.Add(new ScriptBundle("~/bundles/sendDeleteSlidePost").Include(
                      "~/Scripts/sendDeleteSlidePost.js"));

            bundles.Add(new ScriptBundle("~/bundles/SendSelectPhotosForCarsPost").Include(
                      "~/Scripts/sendSelectPhotosForCarsPost.js"));

            bundles.Add(new ScriptBundle("~/bundles/AdminMenuScroll").Include(
                      "~/Scripts/jquery.mCustomScrollbar.js"));

            bundles.Add(new StyleBundle("~/Content/AdminMenuScroll").Include(
                      "~/Content/jquery.mCustomScrollbar.css"));

            bundles.Add(new ScriptBundle("~/bundles/Chosen").Include(
                      "~/Scripts/chosen.jquery.js"));

            bundles.Add(new StyleBundle("~/Content/Chosen").Include(
                      "~/Content/chosen.css"));

            bundles.Add(new ScriptBundle("~/bundles/ImageSelect").Include(
                      "~/Scripts/ImageSelect.jquery.js"));

            bundles.Add(new StyleBundle("~/Content/ImageSelect").Include(
                      "~/Content/ImageSelect.css"));

            bundles.Add(new ScriptBundle("~/bundles/ImageSelect2").Include(
                      "~/Scripts/image-picker.js"));

            bundles.Add(new StyleBundle("~/Content/ImageSelect2").Include(
                      "~/Content/image-picker.css"));
        }
    }
}

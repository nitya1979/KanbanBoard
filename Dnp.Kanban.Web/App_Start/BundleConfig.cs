using System.Web;
using System.Web.Optimization;

namespace Dnp.Kanban.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/jquery-ui-1.11.4.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"/*,
                       "~/Scripts/moment.min.js",
                      "~/Scripts/bootstrap-datetimepicker.min.js"*/));    

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            bundles.Add(new ScriptBundle("~/bundles/angular").Include(
                      "~/Scripts/angular.js",
                      "~/Scripts/angular-route.js",
                      "~/Scripts/angular-local-storage.js",
                      "~/Scripts/angular-cookies.min.js",
                      "~/Scripts/angular-ui/ui-bootstrap.min.js",
                      "~/Scripts/angular-ui/ui-bootstrap-tpls.min.js",
                      "~/app/app.js",
                      "~/app/models.js",
                      "~/app/sessionInjector.js",
                      "~/app/Services/AccountService.js",
                      "~/app/Services/sharedService.js",
                      "~/app/Services/projectService.js",
                      "~/app/Controller/menuController.js",
                      "~/app/Controller/RegistrationController.js",
                      "~/app/Controller/LoginController.js",
                      "~/app/Controller/LogoutController.js",
                      "~/app/Controller/projectController.js",
                      "~/app/Controller/dashboardController.js"
                ));
        }
    }
}

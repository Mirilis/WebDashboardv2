using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace WebDashboardv2.Controllers
{
    public class QualityAlertsController : Controller
    {
        private readonly Model.IProductsModel products;
        private readonly Model.IQualityAlertsModel qualityAlerts;
        private readonly Model.IUserAccessModel userAccess;
        private readonly IHostingEnvironment appEnvironment;

        public QualityAlertsController(Model.IProductsModel products, Model.IUserAccessModel userAccess, IHostingEnvironment appEnvironment, Model.IQualityAlertsModel qualityAlerts)
        {
            this.products = products;
            this.userAccess = userAccess;
            this.appEnvironment = appEnvironment;
            this.qualityAlerts = qualityAlerts;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ViewForProduct(string Product)
        {
            return PartialView("_QualityAlertsForProduct");
        }

        public IActionResult CreateNew()
        {
            return View();
        }

        public IActionResult ViewCurrent()
        {
            return View();
        }

        public IActionResult ViewAll()
        {
            ViewData["Products"] = products;
            ViewData["Alerts"] = qualityAlerts;
            return View();
        }
    }
}
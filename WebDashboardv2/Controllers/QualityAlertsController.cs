using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebDashboardv2.Model;
using System.IO;
using Microsoft.Net.Http.Headers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using System.Net.Http;
using System.Net;


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

        public IActionResult Partial90d(string Product)
        {
            ViewData["User"] = userAccess;
            ViewData["90dAlerts"] = qualityAlerts.ProductAlerts.Where(x => x.Product == Product && x.AlertDate >= DateTime.Now.AddDays(-90)).ToList();
            ViewData["Header"] = string.Format("Alerts for {0}, Last 90 Days", Product);
                return PartialView("_QualityAlertsByProduct");
        }

        public IActionResult PartialAllTime(string Product)
        {
            ViewData["User"] = userAccess;
            ViewData["Header"] = string.Format("Alerts for {0}, All Alerts", Product);
            ViewData["90dAlerts"] = qualityAlerts.ProductAlerts.Where(x => x.Product == Product).ToList();
            return PartialView("_QualityAlertsByProduct");
        }

        public IActionResult CreateNew()
        {
            return Create(0);
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

        public IActionResult CreateRepeatAlert(int Id)
        {
            
            return Create(Id);
        }

        private IActionResult Create(int Id)
        {
            return View("Create");
        }
        
    }
}
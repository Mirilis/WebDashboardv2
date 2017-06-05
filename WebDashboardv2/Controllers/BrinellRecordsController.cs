using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebDashboardv2.Controllers
{
    public class BrinellRecordsController : Controller
    {
        private readonly Model.BrinellRecordsContext bContext;
        private readonly List<Model.ProductionHardness> productionHardnesses;
        public BrinellRecordsController(Model.BrinellRecordsContext bContext)
        {
            this.bContext = bContext;
            this.productionHardnesses = bContext.ProductionHardnesses.Where(x=>x.Date >= DateTime.Now.AddDays(-90)).OrderByDescending(y=>y.Date).ToList();
        }
        public IActionResult Index()
        {
            
            return View();
        }

        public IActionResult ViewAll()
        {
            ViewData["Records"] = productionHardnesses;
            return View();
        }
    }
}
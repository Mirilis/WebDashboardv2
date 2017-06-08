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
                
        }
        public IActionResult Index()
        {
            
            return View();
        }

        public async Task<IActionResult> ViewAll()
        {

            ViewData["Records"] = await GetHardnessesAsync();
            return View();
        }

        public async Task<List<Model.ProductionHardness>> GetHardnessesAsync()
        {
            return await Task.Run(() => GetHardnesses());
            
        }

        private List<Model.ProductionHardness> GetHardnesses()
        {
            return bContext.ProductionHardnesses.Where(x => x.Date >= DateTime.Now.AddDays(-90) && x.HTCode != "HT").OrderByDescending(y => y.Date).ToList();
        }
    }
}
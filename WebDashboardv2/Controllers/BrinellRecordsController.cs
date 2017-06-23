using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebDashboardv2.Model;

namespace WebDashboardv2.Controllers
{
    public class BrinellRecordsController : Controller
    {
        private readonly Model.BrinellRecordsContext bContext;
        private readonly List<Model.ProductionHardnessSummary> productionHardnesses;
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

            ViewData["Records"] = await getHardnessesAsync();
            return View();
        }

        public async Task<IActionResult> FixRecordErrors()
        {
            ViewData["Records"] = await getAllRecordsAsync();
            ViewData["Ranges"] = await getAllRangesAsync();
            return View();
        }

        public async Task<List<Model.RangeData>> getAllRangesAsync()
        {
            return await Task.Run(() => getAllRanges());
        }

        private List<RangeData> getAllRanges()
        {
            return bContext.RangeData.ToList();
        }

        public async Task<List<Model.ProductionHardnessSummary>> getHardnessesAsync()
        {
            return await Task.Run(() => GetHardnesses());
            
        }

        public async Task<List<Model.Record>> getAllRecordsAsync()
        {
            return await Task.Run(() => getAllRecords());
        }

        private List<Record> getAllRecords()
        {
            return bContext.Records.Where(x => x.CastDate >= DateTime.Now.AddDays(-90)).OrderByDescending(y => y.CastDate).ToList();
        }

        private List<Model.ProductionHardnessSummary> GetHardnesses()
        {
            return bContext.ProductionHardnessSummaries.Where(x => x.Date >= DateTime.Now.AddDays(-90)).OrderByDescending(y => y.Date).ToList();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebDashboardv2.Controllers
{

    //enum for loading LPA documents by department
    public enum Departments
    {
        Core,
        Mold,
        Melt,
        Cleaning,
        Finishing,
        Maintenance,
        IndustrialEngineering,
        Technical,
        Quality,
        FoundryEngineering,
        PlantEngineering,
        Environmental,
        ProductionControl,
        HumanResources,
        Safety,
        Training
    }


    public class LayeredProcessAuditingController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddQuestion()
        {
            throw new NotImplementedException();
        }

        public IActionResult GenerateNewAudit(int id)
        {
            throw new NotImplementedException();
        }

        public IActionResult ViewRecords(int id)
        {
            throw new NotImplementedException();
        }
    }
}
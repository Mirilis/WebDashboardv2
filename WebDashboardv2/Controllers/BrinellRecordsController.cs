using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebDashboardv2.Controllers
{
    public class BrinellRecordsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
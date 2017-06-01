using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebDashboardv2.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;

namespace WebDashboardv2.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserAccessModel userAccessModel;
        
        public HomeController(Model.IUserAccessModel userAccessModel)
        {
            this.userAccessModel = userAccessModel;
           
        }
        public IActionResult Index()
        {
            ViewData["User"] = userAccessModel;
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}

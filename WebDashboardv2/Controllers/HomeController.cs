using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebDashboardv2.Model;
using Microsoft.AspNetCore.Authorization;

namespace WebDashboardv2.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserAccessModel userAccessModel;
        public HomeController(Model.IUserAccessModel userAccessModel)
        {
            this.userAccessModel = userAccessModel;
            try
            {
                userAccessModel.UpdateUser(User.Identity.Name);
            }
            catch
            {
                userAccessModel.UpdateUser(null);
            }
        }
        public IActionResult Index()
        {
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

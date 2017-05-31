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
        private readonly Model.IProcessCardsModel ProcessCards;
        private readonly Model.IUserAccessModel UserAccess;
        private readonly IHostingEnvironment appEnvironment;

        public QualityAlertsController(Model.IProcessCardsModel processCards, Model.IUserAccessModel userAccess, IHostingEnvironment appEnvironment)
        {
            this.ProcessCards = processCards;
            this.UserAccess = userAccess;
            this.appEnvironment = appEnvironment;
        }

        public IActionResult Index()
        {
            var pcc = ProcessCardClass.MoldingOsborn;
            ViewData["ProcessCards"] = ProcessCards.DepartmentalCards(pcc);
            ViewData["CardClass"] = pcc.ToString().ToSentenceCase();
            ViewData["UserAccess"] = UserAccess.IsAuthorizedToEdit(pcc);
            return View();
        }
        public IActionResult Product(string Product)
        {
            var pcc = ProcessCardClass.MoldingOsborn;
            ViewData["ProcessCards"] = ProcessCards.DepartmentalCards(pcc);
            ViewData["CardClass"] = pcc.ToString().ToSentenceCase();
            ViewData["UserAccess"] = UserAccess.IsAuthorizedToEdit(pcc);
            return View();
        }
    }
}
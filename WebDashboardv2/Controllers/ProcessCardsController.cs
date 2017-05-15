using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebDashboardv2.Model;

namespace WebDashboardv2.Controllers
{
    public class ProcessCardsController : Controller
    {
        private readonly Model.IProcessCardsModel ProcessCards;

        public ProcessCardsController(Model.IProcessCardsModel processCards)
        {
            this.ProcessCards = processCards;
        }

        public IActionResult All()
        {
            ViewData["ProcessCards"] = ProcessCards.ProcessCards;
            return View();
        }

        public IActionResult Index(int id)
        {
            var pcc = (Model.ProcessCardClass) id;
            ViewData["ProcessCards"] = ProcessCards.DepartmentalCards(pcc);
            ViewData["CardClass"] = pcc.ToString().ToSentenceCase();
            return View();
        }
    }
}
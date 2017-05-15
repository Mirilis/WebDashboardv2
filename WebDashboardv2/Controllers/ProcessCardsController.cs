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
        private readonly Model.IUserAccessModel UserAccess;
        public ProcessCardsController(Model.IProcessCardsModel processCards, Model.IUserAccessModel userAccess)
        {
            this.ProcessCards = processCards;
            this.UserAccess = userAccess;
        }

        [HttpPost]
        public IActionResult Update(string value)
        {
            var p = value.Split(' ');
            var a = ProcessCards.Update(p[0], p[1], p[2]);
            if (a)
            {
                return Json(new { success = true });
            }
            return Json(new { success = false });
        }

        public IActionResult All()
        {
            ViewData["ProcessCards"] = ProcessCards.ProcessCards;
            ViewData["UserAccess"] = false;
                return View();
        }

        public IActionResult Index(int id)
        {
            var pcc = (Model.ProcessCardClass) id;
            ViewData["ProcessCards"] = ProcessCards.DepartmentalCards(pcc);
            ViewData["CardClass"] = pcc.ToString().ToSentenceCase();
            ViewData["UserAccess"] = UserAccess.IsAuthorizedToEdit(pcc);
            return View();
        }
    }
}
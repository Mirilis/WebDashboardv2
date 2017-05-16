using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebDashboardv2.Model;
using System.IO;


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

        [HttpPost]
        public IActionResult UploadImage(string value)
        {
            var uid = Guid.NewGuid();
            using (var ms = new MemoryStream((byte[])Newtonsoft.Json.JsonConvert.DeserializeObject(value)))
            {
                using (FileStream file = new FileStream("/images/" + uid + ".jpg", FileMode.Create, System.IO.FileAccess.Write))
                {
                    byte[] bytes = new byte[ms.Length];
                    ms.Read(bytes, 0, (int)ms.Length);
                    file.Write(bytes, 0, bytes.Length);
                }
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
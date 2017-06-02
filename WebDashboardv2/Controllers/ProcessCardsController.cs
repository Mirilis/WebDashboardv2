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
    public class ProcessCardsController : Controller
    {
        private readonly Model.IProcessCardsModel ProcessCards;
        private readonly Model.IUserAccessModel UserAccess;
        private readonly IHostingEnvironment appEnvironment;

        public ProcessCardsController(Model.IProcessCardsModel processCards, Model.IUserAccessModel userAccess, IHostingEnvironment appEnvironment)
        {
            this.ProcessCards = processCards;
            this.UserAccess = userAccess;
            this.appEnvironment = appEnvironment;
        }

        [HttpPost]
        public string Update(string value)
        {
            try
            {

                        var p = value.Split('-');
            if (p.Count() == 4)
            {
                p[2] = Path.GetFileName(p[2]);
                p[2] = p[2].Replace('*', '-');
                var q = new string[3] { p[0], p[1], p[2], };
                p = q;
            }
            if (p.Count() == 3)
            {

                var a = ProcessCards.Update(p[0], p[1], p[2]);
                if (a)
                {
                    return string.Format("{0}-{1}-true", p[0], p[1]);
                }
                return string.Format("{0}-{1}-false", p[0], p[1]);
            }
            return "Bad Data Submitted.";
        }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }

        [HttpPost]
        public string UploadImage()
        {
        
            long size = 0;
            var files = Request.Form.Files;
            foreach (var file in files)
            {
                
                var fileName = ContentDispositionHeaderValue
                                .Parse(file.ContentDisposition)
                                .FileName
                                .Trim('"');
                if (fileName.ToLower().Contains(".jpg") || fileName.ToLower().Contains(".png"))
                {
                    fileName = Path.GetFileName(fileName);
                    var filename = appEnvironment.WebRootPath + @"/pdfcreator/content/pdfImages/" + $@"/{fileName}";
                size += file.Length;
                using (FileStream fs = System.IO.File.Create(filename))
                {
                    file.CopyTo(fs);
                    fs.Flush();
                }
                    return "File Upload Complete";
                }
            }
            return "File Upload Failed.";
        }
            public IActionResult All()
        {
                return View();
        }

        public IActionResult Edit(int id)
        {
            var currentProcesscard = ProcessCards.GetProcessCard(id);
            ViewData["CurrentCard"] = currentProcesscard;
            return PartialView("_EditDetails");

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
using Arenda.Models;
using Arenda.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NLog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Xceed.Wpf.Toolkit;

namespace Arenda.Controllers
{
    public class ContractController : Controller
    {
        private IWebHostEnvironment _env;
        //private FileManager _fileManager;
        private string _dir;
        private static Logger logger = LogManager.GetCurrentClassLogger();
        public ShelkContext db;
        //db dbop = new db();
        public ContractController(ShelkContext context, IWebHostEnvironment env)
        {
            _env = env;
            _dir = _env.ContentRootPath;
            db = context;
        }
        public ActionResult KdaWord(int? id)
        {
            if (id != null)
            {
                Arendator arendator =  db.Arendators.FirstOrDefault(p => p.ArendatorId == id);
                logger.Trace("Зашел посмотреть информацию об арендаторе " + arendator.ArendatorName);
                return View(arendator);
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<ActionResult> UploadKdaWord(int? id, IFormFile ContactWord)
        {
            Arendator arendator = db.Arendators.FirstOrDefault(p => p.ArendatorId == id);
            string path = "/Contract/Word";
            path += ContactWord.FileName;
            arendator.Contact = await UploadImage(path, ContactWord);
            db.Arendators.Update(arendator);
            db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
        public ActionResult KdaPDF(int? id)
        {
            //PdfFile pdfFile =  db.PdfFiles.Include(u => u.PdffkNavigation).FirstOrDefault(u => u.Pdffk == id);
            //return View (pdfFile);
            TempData["ID"] = id;
            //ViewData.Model = arendator.ArendatorId;
            return View(db.PdfFiles.Where(p => p.Pdffk == id).ToList());
        }
        [HttpPost]
        public async Task<ActionResult> UploadKdaPDF(IFormFile KDAPDF, int? id)
        { 
            var pdfFile = new PdfFile();
            //pdfFile.Pdffk = (int?)TempData["ID"];
            pdfFile.Pdffk = id;
            string path = "contract/pdf/kda/";
                pdfFile.Pdfkda = await UploadImage(path, KDAPDF);
                db.PdfFiles.Add(pdfFile);
                db.SaveChanges();
            //if (arendator.Contact1 != null)
            //{
             //   string folder = "/Contract/PDF/";
             //   arendator.Contact1 = await UploadImage(folder, Contact1);
             //   db.Arendators.Update(arendator);
             //   db.SaveChanges();
            //}
            return RedirectToAction("Index", "Home");
            
        }
        [HttpPost]
        public ActionResult ViewKda(int? id)
        {
            Arendator arendator = db.Arendators.FirstOrDefault(p => p.ArendatorId == id);
            return View(arendator);

        }
        private async Task<string> UploadImage(string folderPath, IFormFile file)
        {

            folderPath = file.FileName;

            string serverFolder = Path.Combine(_env.WebRootPath, folderPath);

            await file.CopyToAsync(new FileStream(serverFolder, FileMode.Create));

            return "/" + folderPath;
        }
    }
}

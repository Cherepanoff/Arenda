using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Arenda.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Arenda.Controllers
{
    public class InformationController : Controller
    {
        private IWebHostEnvironment _env;
        //private FileManager _fileManager;
        private string _dir;
        public ShelkContext db;
        public InformationController(ShelkContext context, IWebHostEnvironment env)
        {
            ///_fileManager = fileManager;
            _env = env;
            _dir = _env.ContentRootPath;
            db = context;
        }
        [HttpPost]
        public async Task<IActionResult> UploadCondition(IFormFile file)
        {
            if (file != null)
            {
                // путь к папке Files
                string path = "/Contract/" + file.FileName;
                using (var fileStream = new FileStream(_env.WebRootPath + path, FileMode.Create, FileAccess.Write))
                {
                    await file.CopyToAsync(fileStream);
                }

            }
            return RedirectToAction("Info");
        }
        //public IActionResult UploadFiles(IEnumerable<IFormFile> files)
        //{
        //    int i = 0;
        //   foreach (var file in files)
        // {
        //      using (var fileStream = new FileStream(Path.Combine(_dir, $"file{i++}.docx"), FileMode.Create, FileAccess.Write))
        //       {
        //          file.CopyTo(fileStream);
        //     }
        //  }

        //   return RedirectToAction("Info");
        // }
        public async Task<IActionResult> Info()
        { 
            return View(await db.Arendators.FromSqlRaw("SELECT * FROM Arendator WHERE ArendatorID=1").ToListAsync());
        }
        [HttpPost]
        public async Task<IActionResult> NewInfo(Arendator Arendator)
        {
            //db.Arendators.Update(Arendator);
            db.Arendators.FromSqlRaw("UPDATE Arendator SET LegalPerson=", Arendator.LegalPerson).ToListAsync();
            await db.SaveChangesAsync();
            return RedirectToAction("Info");
        }
        //public IActionResult NewInfo() => View(_fileManager.GetFiles());
       public IActionResult NewInfo()
        {

            return View();
        }
        public async Task<IActionResult> Dogovor()
        {
            return View(await db.Arendators.ToListAsync());
        }
        [HttpPost]
        public async Task<IActionResult> NewDogovor(Arendator Arendator)
        {
            db.Arendators.Add(Arendator);
            await db.SaveChangesAsync();
            return RedirectToAction("Dogovor");
        }
        public IActionResult NewDogovor()
        {
            return View();
        }
        public async Task<IActionResult> SpecConditions()
        {
            return View(await db.Arendators.ToListAsync());
        }
        public async Task<IActionResult> UploadImage(IFormFile file)
        {
            if (file != null)
            {
                // путь к папке Files
                string path = "/Image/" + file.FileName;
                using (var fileStream = new FileStream(_env.WebRootPath + path, FileMode.Create, FileAccess.Write))
                {
                    await file.CopyToAsync(fileStream);
                }

            }
            return RedirectToAction("Info");
        }
    }
}

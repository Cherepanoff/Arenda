﻿using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Arenda.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;

namespace Arenda.Controllers
{
    public class InformationController : Controller
    {
        private IWebHostEnvironment _env;
        //private FileManager _fileManager;
        private string _dir;
        public ShelkContext db;
        //db dbop = new db();
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
        [Authorize(Roles = "Админ,Юрист")]
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
        [Authorize(Roles = "Админ")]
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
        [HttpPost]
        public async Task<IActionResult> NewCondition(Arendator Arendator)
        {
            db.Arendators.Add(Arendator);
            await db.SaveChangesAsync();
            return RedirectToAction("SpecCondtions");
        }
        public IActionResult NewCondition()
        {
            return View();
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
       // public async IActionResult ExportExcel()
       // {
            //DataSet dbop = 
        //    var stream = new MemoryStream();
        //    using (var package = new ExcelPackage(stream))
        //    {
         //       var worksheet = package.Workbook.Worksheets.Add("Sheet1");
         //       worksheet.Cells.LoadFromDataTable(ds)
        //    }
        //}
    }
}

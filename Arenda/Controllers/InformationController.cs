using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Arenda.Models;
using Arenda.ViewModels;
using ClosedXML.Excel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NLog;
using OfficeOpenXml;

namespace Arenda.Controllers
{
    public class InformationController : Controller
    {
        private IWebHostEnvironment _env;
        //private FileManager _fileManager;
        private string _dir;
        private static Logger logger = LogManager.GetCurrentClassLogger();
        public ShelkContext db;
        //db dbop = new db();
        public InformationController(ShelkContext context, IWebHostEnvironment env)
        {
            _env = env;
            _dir = _env.ContentRootPath;
            db = context;
        }
      //  [HttpPost]
      //  public async Task<IActionResult> UploadCondition(CondtitionViewModel pvm, int? id)
       // {
           // Arendator arendator = new Arendator { ArendatorName = pvm.Name };
           // if (pvm.Condition != null)
            //{
           //     byte[] imageData = null;
                // считываем переданный файл в массив байтов
            //    using (var binaryReader = new BinaryReader(pvm.Condition.OpenReadStream()))
            //    {
            //        imageData = binaryReader.ReadBytes((int)pvm.Condition.Length);
            //    }
                // установка массива байтов
            //    arendator.Files = imageData;
           // }
           // db.Arendators.Update(arendator);
           // await db.SaveChangesAsync();

          //  return RedirectToAction("Index", "Home");
       // }

    
        [Authorize(Roles = "Админ,Аренда")]
        public async Task<IActionResult> Info(int? id)
        {
            if (id != null)
            {
                ArendatorModel arendatorModel = new ArendatorModel();
                arendatorModel.ArendatorId = (int)id;
                Arendator arendator = await db.Arendators.FirstOrDefaultAsync(p => p.ArendatorId == id);
                logger.Trace("Зашел посмотреть информацию об арендаторе " + arendator.ArendatorName);
                return View(arendator);
            }
           return NotFound();
        }
        [Authorize(Roles = "Админ,Аренда")]
        public async Task<IActionResult> NewInfo(int? id)
        {
             if (id != null)
             {
            Arendator arendator = await db.Arendators.FirstOrDefaultAsync(p => p.ArendatorId == id);
                logger.Trace("Зашел изменить информацию об арендаторе " + arendator.ArendatorName);
                if (arendator != null)
            return View(arendator);
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> NewInfo(Arendator arendator)
        {
            db.Arendators.Update(arendator);
            await db.SaveChangesAsync();
            return RedirectToAction("Index", "Home");
        }
        [Authorize(Roles = "Админ,Аренда")]
        public async Task<IActionResult> Dogovor(int? id)
        {

                Arendator arendator = await db.Arendators.FirstOrDefaultAsync(p => p.ArendatorId == id);
                logger.Trace("Зашел посмотреть договор " + arendator.ArendatorName);
                return View(arendator);
        }
        [Authorize(Roles = "Админ,Аренда")]
        public async Task<IActionResult> SaveChanges(int? id)
        {
            //if (id != null)
            //{
            Contact contact = await db.Contacts.Include(u => u.ContactFkNavigation).FirstOrDefaultAsync(p => p.ContactId == id);
            //Arendator arendator = await db.Arendators.FirstOrDefaultAsync(p => p.ArendatorId == id);
            return View("Index", "Home");
            //}
            //return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> NewDogovor(Arendator Arendator)
        {
            db.Arendators.Add(Arendator);
            await db.SaveChangesAsync();
            return RedirectToAction("Dogovor");
        }
        [Authorize(Roles = "Админ,Аренда")]

        public IActionResult NewDogovor()
        {
            return View();
        }
        [Authorize(Roles = "Админ,Аренда")]
        public async Task<IActionResult> SpecConditions(int? id)
        {
            //if (id != null)
            //{
            Arendator arendator = await db.Arendators.FirstOrDefaultAsync(p => p.ArendatorId == id);
            return View(arendator);
            //}
           //return NotFound();
        }
        [Authorize(Roles = "Админ,Аренда")]
        public async Task<IActionResult> NewCondition(int? id)
        {
            // if (id != null)
            // {
            Arendator arendator = await db.Arendators.FirstOrDefaultAsync(p => p.ArendatorId == id);
            //if (arendator != null)
            return View(arendator);
            //}
            //return NotFound();
        }
        [HttpPost]
        [Authorize(Roles = "Админ,Аренда")]

        public async Task<IActionResult> NewCondition(Arendator arendator)
        {
            db.Arendators.Update(arendator);
            await db.SaveChangesAsync();
            return RedirectToAction("Info");
        }
        [Authorize(Roles = "Админ,Аренда")]
        public async Task<IActionResult> Card(int? id)
        {

            Arendator arendator = await db.Arendators.FirstOrDefaultAsync(p => p.ArendatorId == id);
            return View(arendator);
        }
        [Authorize(Roles = "Админ,Аренда")]
        public async Task<IActionResult> NewCard(int? id)
        {
            //if (id != null)
           // {
                Arendator arendator = await db.Arendators.FirstOrDefaultAsync(p => p.ArendatorId == id);
             //   if (arendator != null)
                    return View(arendator);
           // }
            //return NotFound();
        }
        [HttpPost]
        [Authorize(Roles = "Админ,Аренда")]
        public async Task<IActionResult> NewCard(Arendator arendator)
        {
            db.Arendators.Update(arendator);
            await db.SaveChangesAsync();
            return RedirectToAction("Index", "Home");
        }
        [Authorize(Roles = "Админ,Аренда")]
        public async Task<IActionResult> ContractPDF(int? id)
        {
            if (id != null)
            {
                Arendator arendator = await db.Arendators.FirstOrDefaultAsync(p => p.ArendatorId == id);
                logger.Trace("Зашел посмотреть информацию об арендаторе " + arendator.ArendatorName);
                return View(arendator);
            }
            return NotFound();

        }
        public async Task<IActionResult> ContractWord(int? id)
        {

            if (id != null)
            {
                Arendator arendator = await db.Arendators.FirstOrDefaultAsync(p => p.ArendatorId == id);
                logger.Trace("Зашел посмотреть информацию об арендаторе " + arendator.ArendatorName);
                return View(arendator);
            }
            return NotFound();
        }
        [HttpPost]
        public ActionResult UploadImage(int? id, IFormFile Logo)
        {
            Arendator arendator =  db.Arendators.FirstOrDefault(p => p.ArendatorId == id);
            if (ModelState.IsValid && Logo != null)
            {
                byte[] imageData = null;
                // считываем переданный файл в массив байтов
                using (var binaryReader = new BinaryReader(Logo.OpenReadStream()))
                {
                    imageData = binaryReader.ReadBytes((int)Logo.Length);
                }
                // установка массива байтов
                arendator.Logo = imageData;

                db.Arendators.Update(arendator);
                db.SaveChanges();

                return RedirectToAction("Info");
            }
            return RedirectToAction("Info");
        }
        [Authorize(Roles = "Админ,Аренда")]
        public IActionResult Excel()
        {
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Arendator");
                var currentRow = 1;
                worksheet.Cell(currentRow, 1).Value = "Юридическое лицо";
                worksheet.Cell(currentRow, 2).Value = "Ген. директор";
                worksheet.Cell(currentRow, 3).Value = "Номер договора";
                worksheet.Cell(currentRow, 4).Value = "Дата договора";
                worksheet.Cell(currentRow, 5).Value = "Юр. Адрес";
                worksheet.Cell(currentRow, 6).Value = "Факт. Адрес";
                worksheet.Cell(currentRow, 7).Value = "Акт о начале коммерческой деятельности";
                foreach (var a in db.Arendators)
                {
                    currentRow++;
                    worksheet.Cell(currentRow, 1).Value = a.GeneralDirector;
                    worksheet.Cell(currentRow, 2).Value = a.LegalPerson;
                    worksheet.Cell(currentRow, 3).Value = a.NumberContract;
                    worksheet.Cell(currentRow, 4).Value = a.DateContract;
                    worksheet.Cell(currentRow, 5).Value = a.AdressLegal;
                    worksheet.Cell(currentRow, 6).Value = a.AllowAct;
                    worksheet.Cell(currentRow, 7).Value = a.StartAct;
                }

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();

                    return File(
                        content,
                        "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                        "Arendator.xlsx");
                }
            }
        }
    }
}

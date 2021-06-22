using Arenda.Models;
using Arenda.ViewModels;
using GroupDocs.Viewer;
using GroupDocs.Viewer.Options;
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
using word = Microsoft.Office.Interop.Word;
using System.Threading.Tasks;
using Xceed.Wpf.Toolkit;
using Aspose.Words.Saving;
using Aspose.Words;

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
        public ActionResult KdaPDF(int? id)
        {

            TempData["ID"] = id;
            return View(db.PdfFiles.Where(p => p.Pdffk == id).ToList());
        }
        [HttpPost]
        public async Task<ActionResult> UploadKdaPDF(IFormFile KDAPDF, int? id)
        { 
            var pdfFile = new PdfFile();
            pdfFile.Pdffk = id;
            string path = "contract/pdf/kda/";
                pdfFile.Pdfkda = await UploadImage(path, KDAPDF);
                db.PdfFiles.Add(pdfFile);
                db.SaveChanges();

            return RedirectToAction("Info", "Information");
            
        }
        public ActionResult PdaPDF(int? id)
        {

            TempData["ID"] = id;
            return View(db.PdfFiles.Where(p => p.Pdffk == id).ToList());
        }
        [HttpPost]
        public async Task<ActionResult> UploadPdaPDF(IFormFile PDAPDF, int? id)
        {
            var pdfFile = new PdfFile();
            pdfFile.Pdffk = id;
            string path = "contract/pdf/pda/";
            pdfFile.Pdfpda = await UploadImage(path, PDAPDF);
            db.PdfFiles.Add(pdfFile);
            db.SaveChanges();

            return RedirectToAction("Index", "Home");

        }
        public ActionResult DaPDF(int? id)
        {

            TempData["ID"] = id;
            return View(db.PdfFiles.Where(p => p.Pdffk == id).ToList());
        }
        [HttpPost]
        public async Task<ActionResult> UploadDaPDF(IFormFile DAPDF, int? id)
        {
            var pdfFile = new PdfFile();
            pdfFile.Pdffk = id;
            string path = "contract/pdf/da/";
            pdfFile.Pdfdda = await UploadImage(path, DAPDF);
            db.PdfFiles.Add(pdfFile);
            db.SaveChanges();

            return RedirectToAction("Index", "Home");

        }
        public ActionResult DdaPDF(int? id)
        {

            TempData["ID"] = id;
            return View(db.PdfFiles.Where(p => p.Pdffk == id).ToList());
        }
        [HttpPost]
        public async Task<ActionResult> UploadDdaPDF(IFormFile DDAPDF, int? id)
        {
            var pdfFile = new PdfFile();
            pdfFile.Pdffk = id;
            string path = "contract/pdf/dda/";
            pdfFile.Pdfdda = await UploadImage(path, DDAPDF);
            db.PdfFiles.Add(pdfFile);
            db.SaveChanges();

            return RedirectToAction("Index", "Home");

        }
        public ActionResult StorePDF(int? id)
        {
            TempData["ID"] = id;
            return View(db.PdfFiles.Where(p => p.Pdffk == id).ToList());
        }
        [HttpPost]
        public async Task<ActionResult> UploadStorePDF(IFormFile STOREPDF, int? id)
        {
            var pdfFile = new PdfFile();
            pdfFile.Pdffk = id;
            string path = "contract/pdf/store/";
            pdfFile.Pdfstore = await UploadImage(path, STOREPDF);
            db.PdfFiles.Add(pdfFile);
            db.SaveChanges();
            return RedirectToAction("Index", "Home");

        }
        public ActionResult AttorneyPDF(int? id)
        {
            TempData["ID"] = id;
            return View(db.PdfFiles.Where(p => p.Pdffk == id).ToList());
        }
        [HttpPost]
        public async Task<ActionResult> UploadAttorneyPDF(IFormFile AttorneyPDF, int? id)
        {
            var pdfFile = new PdfFile();
            pdfFile.Pdffk = id;
            string path = "contract/pdf/attorney/";
            pdfFile.Pdfattorney= await UploadImage(path, AttorneyPDF);
            db.PdfFiles.Add(pdfFile);
            db.SaveChanges();
            return RedirectToAction("Index", "Home");

        }
        public ActionResult DocPDF(int? id)
        {
            TempData["ID"] = id;
            return View(db.PdfFiles.Where(p => p.Pdffk == id).ToList());
        }
        [HttpPost]
        public async Task<ActionResult> UploadDocPDF(IFormFile DOCPDF, int? id)
        {
            var pdfFile = new PdfFile();
            pdfFile.Pdffk = id;
            string path = "contract/pdf/doc/";
            pdfFile.Pdfdoc = await UploadImage(path, DOCPDF);
            db.PdfFiles.Add(pdfFile);
            db.SaveChanges();
            return RedirectToAction("Index", "Home");

        }
        public ActionResult PolicyPDF(int? id)
        {

            TempData["ID"] = id;
            return View(db.PdfFiles.Where(p => p.Pdffk == id).ToList());
        }
        [HttpPost]
        public async Task<ActionResult> UploadPolicyPDF(IFormFile POLICYPDF, int? id)
        {
            var pdfFile = new PdfFile();
            pdfFile.Pdffk = id;
            string path = "contract/pdf/policy/";
            pdfFile.Pdfpolicy = await UploadImage(path, POLICYPDF);
            db.PdfFiles.Add(pdfFile);
            db.SaveChanges();
            return RedirectToAction("Index", "Home");

        }
        public ActionResult KdaWord(int? id)
        {

            TempData["ID"] = id;
            return View(db.WordFiles.Where(p => p.WordFk == id).ToList());
        }
        [HttpPost]
        public async Task<ActionResult> UploadKdaWord(IFormFile KDAWord, int? id)
        {
            var wordFile = new WordFile();
            wordFile.WordFk = id;
            string path = "contract/word/kda/";
            wordFile.WordKda = await UploadImage(path, KDAWord);
            db.WordFiles.Add(wordFile);
            db.SaveChanges();

            return RedirectToAction("Index", "Home");

        }
        public ActionResult PdaWord(int? id)
        {

            TempData["ID"] = id;
            return View(db.WordFiles.Where(p => p.WordFk == id).ToList());
        }
        [HttpPost]
        public async Task<ActionResult> UploadPdaWord(IFormFile PDAWord, int? id)
        {
            var wordFile = new WordFile();
            wordFile.WordFk = id;
            string path = "contract/word/pda/";
            wordFile.WordPda = await UploadImage(path, PDAWord);
            db.WordFiles.Add(wordFile);
            db.SaveChanges();

            return RedirectToAction("Index", "Home");

        }
        public ActionResult DaWord(int? id)
        {

            TempData["ID"] = id;
            return View(db.WordFiles.Where(p => p.WordFk == id).ToList());
        }
        [HttpPost]
        public async Task<ActionResult> UploadDaWord(IFormFile DAWord, int? id)
        {
            var wordFile = new WordFile();
            wordFile.WordFk = id;
            string path = "contract/word/da/";
            wordFile.WordDa = await UploadImage(path, DAWord);
            db.WordFiles.Add(wordFile);
            db.SaveChanges();

            return RedirectToAction("Index", "Home");

        }
        public ActionResult DdaWord(int? id)
        {

            TempData["ID"] = id;
            return View(db.WordFiles.Where(p => p.WordFk == id).ToList());
        }
        [HttpPost]
        public async Task<ActionResult> UploadDdaWord(IFormFile DDAWord, int? id)
        {
            var wordFile = new WordFile();
            wordFile.WordFk = id;
            string path = "contract/word/dda/";
            wordFile.WordDda = await UploadImage(path, DDAWord);
            db.WordFiles.Add(wordFile);
            db.SaveChanges();

            return RedirectToAction("Index", "Home");

        }
        public ActionResult StoreWord(int? id)
        {
            TempData["ID"] = id;
            return View(db.WordFiles.Where(p => p.WordFk == id).ToList());
        }
        [HttpPost]
        public async Task<ActionResult> UploadStoreWord(IFormFile STOREWord, int? id)
        {
            var wordFile = new WordFile();
            wordFile.WordFk = id;
            string path = "contract/word/store/";
            wordFile.WordStore = await UploadImage(path, STOREWord);
            db.WordFiles.Add(wordFile);
            db.SaveChanges();
            return RedirectToAction("Index", "Home");

        }
        public ActionResult AttorneyWord(int? id)
        {
            TempData["ID"] = id;
            return View(db.WordFiles.Where(p => p.WordFk == id).ToList());
        }
        [HttpPost]
        public async Task<ActionResult> UploadAttorneyWord(IFormFile AttorneyWord, int? id)
        {
            var wordFile = new WordFile();
            wordFile.WordFk = id;
            string path = "contract/word/attorney/";
            wordFile.WordAttorney = await UploadImage(path, AttorneyWord);
            db.WordFiles.Add(wordFile);
            db.SaveChanges();
            return RedirectToAction("Index", "Home");

        }
        public ActionResult DocWord(int? id)
        {
            TempData["ID"] = id;
            return View(db.WordFiles.Where(p => p.WordFk == id).ToList());
        }
        [HttpPost]
        public async Task<ActionResult> UploadDocWord(IFormFile DOCWord, int? id)
        {
            var wordFile = new WordFile();
            wordFile.WordFk = id;
            string path = "contract/word/doc/";
            wordFile.WordDoc = await UploadImage(path, DOCWord);
            db.WordFiles.Add(wordFile);
            db.SaveChanges();
            return RedirectToAction("Index", "Home");

        }
        private async Task<string> UploadImage(string folderPath, IFormFile file)
        {

            folderPath += file.FileName;

            string serverFolder = Path.Combine(_env.WebRootPath, folderPath);

            await file.CopyToAsync(new FileStream(serverFolder, FileMode.Create));

            return "/" + folderPath;
        }
    }
}

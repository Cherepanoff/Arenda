using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Arenda.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace Arenda.Controllers
{
    public class HomeController : Controller
    {
        private ShelkContext db;
        public HomeController(ShelkContext context)
        {
            db = context;
        }
        [HttpGet]
        [Authorize]
        public IActionResult Index()
        {
            return View(db.Arendators.ToList());
        }
        public IActionResult ArendatorList()
        {
            return View(db.Arendators.ToList());
        }
        [HttpPost]
        public async Task<IActionResult> AddArendator(Arendator arendator)
        {
            db.Arendators.Add(arendator);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        public IActionResult AddArendator()
        {
            return View();
        }
        // [HttpPost]
        // public async Task<IActionResult> DeleteArendator(Arendator arendator)
        // {
        //     db.Arendators.Remove(arendator);
        //        await db.SaveChangesAsync();
        //         return RedirectToAction("Index");
        // }
        // public IActionResult DeleteArendator()
        //{
        //    return View();
        // }
        [HttpGet]
        [ActionName("DeleteArendator")]
        public async Task<IActionResult> ConfirmDelete(int? ArendatorId)
        {
            if (ArendatorId != null)
            {
                Arendator arendator = await db.Arendators.FirstOrDefaultAsync(p => p.ArendatorId == ArendatorId);
                if (arendator != null)
                return View(arendator);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> DeleteArendator(int? ArendatorId)
        {
            if (ArendatorId != null)
            {
                Arendator arendator = new Arendator { ArendatorId = ArendatorId.Value };
                db.Entry(arendator).State = EntityState.Deleted;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return NotFound();
        }
        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        //public IActionResult Index()
        //{
        //    return View();
        //}

        //public IActionResult Privacy()
        //{
        //    return View();
        //}

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
    }

}

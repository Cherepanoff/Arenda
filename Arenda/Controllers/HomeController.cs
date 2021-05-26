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
        public IActionResult Index(string id)
        {
           return View(db.Arendators.Where(p => p.ArendatorFloor.ToString() == id).ToList());
        }
        public IActionResult ArendatorList()
        {
            return View(db.Arendators.ToList());
        }
        public IActionResult IslandArendatorList()
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
        [HttpPost]
        public async Task<IActionResult> DeleteArendator(int? id)
        {
            Arendator arendator = await db.Arendators.FirstOrDefaultAsync(p => p.ArendatorId == id);
            db.Arendators.Remove(arendator);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        public IActionResult DeleteArendator()
        {
            return View();
        }
        public IActionResult fl_0(string id)
        {
            return View(db.Arendators.Where(p => p.ArendatorFloor.ToString() == id).ToList());
        }
        public IActionResult fl_2(string id)
        {
            return View(db.Arendators.Where(p => p.ArendatorFloor.ToString() == id).ToList());
        }
        public IActionResult fl_3(string id)
        {
            return View(db.Arendators.Where(p => p.ArendatorFloor.ToString() == id).ToList());
        }
        public IActionResult fl_4(string id)
        {
            return View(db.Arendators.Where(p => p.ArendatorFloor.ToString() == id).ToList());
        }
        public IActionResult fl_5(string id)
        {
            return View(db.Arendators.Where(p => p.ArendatorFloor.ToString() == id).ToList());
        }
        public IActionResult fl_6(string id)
        {
            return View(db.Arendators.Where(p => p.ArendatorFloor.ToString() == id).ToList());
        }
    }

}

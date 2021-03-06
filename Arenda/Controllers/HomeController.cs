﻿using System;
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
        [HttpPost]
        public ActionResult DeleteArendator(int id)
        {
            Arendator b = db.Arendators.Find(id);
            if (b != null)
            {
                db.Arendators.Remove(b);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        //public async Task<IActionResult> DeleteArendator(Arendator arendator)
        //{
        //  db.Arendators.Remove(arendator);
        // await db.SaveChangesAsync();
        // return RedirectToAction("Index");
        //}
        //public IActionResult DeleteArendator()
        //{
        //    return View();
        //}
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

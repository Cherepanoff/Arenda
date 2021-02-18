using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Arenda.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Arenda.Controllers
{
    public class DogovorsController : Controller
    {
        public ShelkContext db;
        ////public DogovorsController(ShelkDBContext context)
        ////{
        ////    db = context;
        ////}
        ////public async Task<IActionResult> Dogovor()
        ////{
        ////    return View(await db.Dogovors.ToListAsync());
        ////}
        ////[HttpPost]
        ////public async Task<IActionResult> NewDogovor(Dogovor dogovor)
        ////{
        ////    db.Dogovors.Add(dogovor);
        ////    await db.SaveChangesAsync();
        ////    return RedirectToAction("Dogovor");
        ////}
        ////public IActionResult NewDogovor()
        ////{
        ////    return View();
        ////}
    }
}

using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CardGenerator.Models;

namespace CardGenerator.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult CardEntry()
        {
            return View(new CardEntry());
        }

        [HttpPost]
        public IActionResult CardEntry(Models.CardEntry cardEntry)
        {
            if (ModelState.IsValid)
            {
                return View("CardSent", cardEntry);
            }
            else
            {
                return View(cardEntry);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVCMiniproject.Models;
using MVCMiniproject.Models.ViewModels;

namespace MVCMiniproject.Controllers
{
    public class BeersController : Controller
    {
        BeersService beersService;
        public BeersController(BeersService beersService)
        {
            this.beersService = beersService;
        }
        public IActionResult Index()
        {
            return View(beersService.GetAllBeers());
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(BeersCreateVM beersCreateVM)
        {
            if (!ModelState.IsValid)
                return View();
            beersService.AddBeer(beersCreateVM);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Remove(BeersRemoveVM beersRemoveVM)
        {
            beersService.RemoveBeer(beersRemoveVM);
            return RedirectToAction(nameof(Index));
        }
    }
}
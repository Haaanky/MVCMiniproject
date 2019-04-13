using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using MVCMiniproject.Models;
using MVCMiniproject.Models.ViewModels;

namespace MVCMiniproject.Controllers
{
    public class BeersController : Controller
    {
        BeersService beersService;
        private readonly IHostingEnvironment hostingEnvironment;

        public BeersController(BeersService beersService, IHostingEnvironment hostingEnvironment)
        {
            this.beersService = beersService;
            this.hostingEnvironment = hostingEnvironment;
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
            if (beersCreateVM.Image?.Length > 0)
            {
                var filePath = Path.Combine(hostingEnvironment.WebRootPath, "uploads", beersCreateVM.Image.FileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    beersCreateVM.Image.CopyTo(fileStream);
                }
            }
            var success = beersService.AddBeer(beersCreateVM);
            if (!success)
            {
                ModelState.AddModelError(/*null*/string.Empty, "This combination is already entered!!!");
                return View();
            }
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Remove(BeersRemoveVM beersRemoveVM)
        {
            beersService.RemoveBeer(beersRemoveVM);
            // hur ta bort en statisk fil från disk
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int id)
        {
            return View(beersService.GetBeerByID(id));
        }
    }
}
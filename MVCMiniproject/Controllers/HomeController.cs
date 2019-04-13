using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVCMiniproject.Models;

namespace MVCMiniproject.Controllers
{
    public class HomeController : Controller
    {
        private readonly BeersService beersService;

        public HomeController(BeersService beersService)
        {
            this.beersService = beersService;
        }
        public IActionResult Index()
        {
            return View(beersService.GetAllBeers());
        }
    }
}
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using InglesWeb.Models;
using Microsoft.AspNetCore.Authorization;
using InglesWeb.Services;

namespace InglesWeb.Controllers
{

    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICapituloService capituloService;

        public HomeController(ILogger<HomeController> logger, ICapituloService capituloService)
        {
            _logger = logger;
            this.capituloService = capituloService;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            _logger.LogInformation("Start Application !!");
            var teste = await capituloService.GetCapitulo(1);

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

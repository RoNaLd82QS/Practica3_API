using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace API_PRACTICA3_MVC.Controllers
{
    [Route("[controller]")]
    public class NoticiasController : Controller
    {
        private readonly ILogger<NoticiasController> _logger;

        public NoticiasController(ILogger<NoticiasController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}
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
    public class FeedbackApiController : Controller
    {
        private readonly ILogger<FeedbackApiController> _logger;

        public FeedbackApiController(ILogger<FeedbackApiController> logger)
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
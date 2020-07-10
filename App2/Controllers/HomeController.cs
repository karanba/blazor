using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using App2.Models;
using System.Threading;

namespace App2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
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

        [HttpGet("/slow")]
        public async Task<string> Get(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Starting to do slow work");
            for (var i = 0; i < 10; i++)
            {
                cancellationToken.ThrowIfCancellationRequested();
                // slow non-cancellable work
                Thread.Sleep(1000);
            }
            var message = "Finished slow delay of 10 seconds";
            _logger.LogInformation(message);
            return message;
        }
    }
}

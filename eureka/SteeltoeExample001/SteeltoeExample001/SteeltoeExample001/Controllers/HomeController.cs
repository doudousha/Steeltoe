using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Steeltoe.Common.Discovery;
using SteeltoeExample001.Models;
using SteeltoeExample001.Service;

namespace SteeltoeExample001.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEurekaClientService _eurekaClientService;
        private readonly IDiscoveryClient _client;
        private DiscoveryHttpClientHandler _handler;


        public HomeController(IEurekaClientService eurekaClientService , IDiscoveryClient client, ILoggerFactory logFactory = null)
        {
            _eurekaClientService = eurekaClientService;
            _client = client;
            _handler = new DiscoveryHttpClientHandler(client);
        }

     

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

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

        [HttpGet]
        public async Task<string> GetMember()
        {

            return _eurekaClientService.GetServices().Result;
        }


        [HttpGet]
        public async Task<string> MyService()
        {
            var client = new HttpClient(_handler, false);
            var result = client.GetStringAsync("http://NETCORE-SERVICE/api/MyService/test").Result;
            return result;
        }
    }
}

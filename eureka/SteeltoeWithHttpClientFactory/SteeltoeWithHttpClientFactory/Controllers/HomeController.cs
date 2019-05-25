using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SteeltoeWithHttpClientFactory.Controllers
{
   
    [Route("api/Home")]
    public class HomeController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public HomeController(IHttpClientFactory  httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public string Test()
        {
            var client = _httpClientFactory.CreateClient("eurekakClient01");
            var result = client.GetStringAsync("/getMember").Result;
            return result;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SteeltoeWithHttpClientFactory.Service;

namespace SteeltoeWithHttpClientFactory.Controllers
{

    // 参考: .NET Core & Spring Cloud 互相调用微服务

    [Route("api/InjectHttpClient")]
    public class InjectHttpClientController : Controller
    {
        private readonly ITeamService _teamService;

        public InjectHttpClientController(ITeamService teamService )
        {
            _teamService = teamService;
        }

        [HttpGet]
        public  async Task<string> Test()
        {
            return await _teamService.GetInfo();
        }
    }
}
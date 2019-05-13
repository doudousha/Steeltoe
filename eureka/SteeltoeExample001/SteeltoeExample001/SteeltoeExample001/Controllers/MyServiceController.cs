using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SteeltoeExample001.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MyServiceController : ControllerBase
    {

        [HttpGet]
        [Route("test")]
        public ActionResult<string> Get()
        {
            return "hello world netCore微服务";
        }

    }
}
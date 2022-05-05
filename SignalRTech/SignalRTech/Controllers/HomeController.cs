using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalRTech.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRTech.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        readonly MyBusiness _myBusiness;

        public HomeController(MyBusiness myBusiness)
        {
            _myBusiness = myBusiness;
        }

        [HttpGet("{message}")]
        public async Task<IActionResult> SendMessage(string message)
        {
            await _myBusiness.SendMessageAsync(message);
            return Ok();
        }
    }
}

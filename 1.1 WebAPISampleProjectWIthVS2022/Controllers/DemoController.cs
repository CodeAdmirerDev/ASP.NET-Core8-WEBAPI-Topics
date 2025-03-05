using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPISampleProjectWIthVS2022.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DemoController : ControllerBase
    {

        [HttpGet]
        public string Get()
        {
            return "Hello from the DemoController!";
        }

        [HttpGet]
        public string GetUserCount(int usercount)
        {
            return "Hello from the DemoController!" + "User count is "+ usercount;
        }

    }
}

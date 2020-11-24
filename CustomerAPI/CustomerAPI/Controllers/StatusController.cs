using Microsoft.AspNetCore.Mvc;

namespace CustomerAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class StatusController : ControllerBase
    {
        public string GetStatus()
        {
            return "OK";
        }
    }
}
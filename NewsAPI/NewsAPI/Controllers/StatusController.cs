using Microsoft.AspNetCore.Mvc;

namespace NewsAPI.Controllers
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
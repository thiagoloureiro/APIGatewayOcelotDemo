using Microsoft.AspNetCore.Mvc;

namespace StockAPI.Controllers
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
using Microsoft.AspNetCore.Mvc;
using MontyHall.Infrastructure.Services;

namespace MontyHall.Web.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValueController : ControllerBase
    {
        private IRoundService RoundService { get; set; }

        public ValueController(IRoundService roundService)
        {
            RoundService = roundService;
        }

        [HttpGet("/attempts")]
        public IActionResult Get(int attempts, bool reselect = false)
        {
            var res = RoundService.Execute(reselect, attempts);

            return Ok(res.ToString());
        }
    }
}

using Microsoft.AspNetCore.Mvc;

namespace Blog.Api.Controllers
{
    [Route("api/values")]
    public class ValueController : Controller
    {
        public IActionResult Get()
        {
            return Ok("ok");
        }
    }
}

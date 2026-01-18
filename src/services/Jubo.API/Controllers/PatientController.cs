using Microsoft.AspNetCore.Mvc;

namespace Jubo.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new { Message = "Patient API is working!" });
        }
    }
}
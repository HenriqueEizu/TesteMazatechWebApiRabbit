using Microsoft.AspNetCore.Mvc;
using Rabbit.Model.Entities;
using Rabbit.Services;

namespace Rabbit.Publisher.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {
        [HttpPost]
        public IActionResult Auth(string userName, string password)
        {
            if (userName == "henriqueEizu" && password == "123456")
            {
                var token = TokenService.GenerateToken(new RabbitMessage());
                return Ok(token);
            }
                return BadRequest("Nome do usuário ou senha incorretos");
        }
    }
}

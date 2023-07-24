using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rabbit.Model.Entities;
using Rabbit.Services.Interfaces;

namespace Rabbit.Publisher.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RabbitMessageController : ControllerBase
    {
        private readonly IRabbitMessageService _service;
        public RabbitMessageController(IRabbitMessageService service)
        {
            _service = service;
        }

        [HttpPost]
        [Authorize]
        public void AddMessage(RabbitMessage message)
        {
            _service.sendMessage(message);
        }
    }
}

using Rabbit.Model.Entities;
using Rabbit.Services;
using Rabbit.Services.Interfaces;

namespace RabbitMq.Test
{
    public class RaabbitMQTest
    {
        private readonly RabbitMessageService _service;
        [Fact]
        public void SendMessage()
        {
            RabbitMessage msg = new RabbitMessage();
            msg.numeroProtocolo = 1;
            msg.numeroVia = 1;
            msg.rg = "19491674";
            msg.cpf = "13557833801";
            _service.sendMessage(msg);
        }
    }
}
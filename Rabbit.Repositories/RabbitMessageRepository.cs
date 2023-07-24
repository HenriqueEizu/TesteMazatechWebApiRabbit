using Rabbit.Model.Entities;
using Rabbit.Repositories.Interfaces;
using RabbitMQ.Client;
using System.Text;
using System.Text.Json;

namespace Rabbit.Repositories
{
    public class RabbitMessageRepository : IRabbitMessageRepository
    {
        public void sendMessage(RabbitMessage message)
        {
            var factory = new ConnectionFactory { 
                HostName = "localhost" 
                ,UserName = "admin"
                ,Password = "123456"
            };
            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();

            channel.QueueDeclare(queue: "rabbitMessaseQueue",
                                 durable: false,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);

            string json = JsonSerializer.Serialize(message);
            var body = Encoding.UTF8.GetBytes(json);

            channel.BasicPublish(exchange: string.Empty,
                                 routingKey: "rabbitMessaseQueue",
                                 basicProperties: null,
                                 body: body);
        }
    }
}
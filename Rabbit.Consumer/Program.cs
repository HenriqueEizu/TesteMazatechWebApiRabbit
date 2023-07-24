
using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text.Json;
using Rabbit.Model.Entities;
using System.Data.Entity;
using System;
using RabbitMqMessage.DAO;
using RabbitMq.Business;

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

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

Console.WriteLine(" [*] Waiting for messages.");

var consumer = new EventingBasicConsumer(channel);
consumer.Received += (model, ea) =>
{
    var body = ea.Body.ToArray();
    var json = Encoding.UTF8.GetString(body);

    RabbitMessage message1 = JsonSerializer.Deserialize<RabbitMessage>(json);

    System.Threading.Thread.Sleep(1000);

    Console.WriteLine($"Titulo: {message1.rg}; Texto: {message1.numeroProtocolo}; id: {message1.cpf}");

    // Instância do Data Context
    RabbitMqMessageBusiness rbBus = new RabbitMqMessageBusiness();

    rbBus.AddRabbitMqMessage(message1);

    // Persiste as mudanças
};
channel.BasicConsume(queue: "rabbitMessaseQueue",
                     autoAck: true,
                     consumer: consumer);

Console.WriteLine(" Press [enter] to exit.");
Console.ReadLine();

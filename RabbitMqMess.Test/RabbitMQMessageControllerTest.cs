using Rabbit.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using AutoFixture;
using Rabbit.Publisher.Api.Controllers;
using Rabbit.Model.Entities;
using Rabbit.Services.Interfaces;
using Rabbit.Repositories;
using Rabbit.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RabbitMqMess.Test
{
    [TestClass]
    public class RabbitMQMessageControllerTest
    {
       
        [TestMethod]
        public  Task TesteSendMessage()
        {
            var mockConnectionFactory = new RabbitMessageRepository();
            var rabbitMQService = new RabbitMessageService (mockConnectionFactory);
            RabbitMessage msg = new RabbitMessage();

            byte[] imagem = new byte[10] {1,2,3,4,5,6,7,8,9,10};

            msg.numeroProtocolo = 1;
            msg.numeroVia = 1;
            msg.cpf = "00000000001";
            msg.rg = "000000001X";
            msg.nome = "Jose Manoel";
            msg.pai = "Renato dos Santos";
            msg.mae = "Maria dos Santos";
            msg.foto = imagem;
            msg.dataHoraEnviada = DateTime.Now;
            rabbitMQService.sendMessage(msg);


            // Protocolo Repetido

            msg = new RabbitMessage();
            msg.numeroProtocolo = 1;
            msg.numeroVia = 1;
            msg.cpf = "00000000002";
            msg.rg = "000000002X";
            msg.nome = "Jose Manoel 2";
            msg.pai = "Renato dos Santos 2";
            msg.mae = "Maria dos Santos 2";
            msg.dataHoraEnviada = DateTime.Now;
            msg.foto = imagem;
            rabbitMQService.sendMessage(msg);

            // Protocolo CPF via ja existente

            msg = new RabbitMessage();
            msg.numeroProtocolo = 2;
            msg.numeroVia = 1;
            msg.cpf = "00000000001";
            msg.rg = "000000002X";
            msg.nome = "Jose Manoel 2";
            msg.pai = "Renato dos Santos 2";
            msg.mae = "Maria dos Santos 2";
            msg.dataHoraEnviada = DateTime.Now;
            msg.foto = imagem;
            rabbitMQService.sendMessage(msg);

            // Protocolo RG via ja existente
            rabbitMQService.sendMessage(msg);
            msg = new RabbitMessage();
            msg.numeroProtocolo = 2;
            msg.numeroVia = 1;
            msg.cpf = "00000000001";
            msg.rg = "000000001X";
            msg.nome = "Jose Manoel 2";
            msg.pai = "Renato dos Santos 2";
            msg.mae = "Maria dos Santos 2";
            msg.dataHoraEnviada = DateTime.Now;
            msg.foto = imagem;
            rabbitMQService.sendMessage(msg);

            // ok
            msg = new RabbitMessage();
            msg.numeroProtocolo = 2;
            msg.numeroVia = 1;
            msg.cpf = "00000000002";
            msg.rg = "000000002X";
            msg.nome = "Pedro Silva";
            msg.pai = "Osvaldo Silva";
            msg.mae = "Renata Silva";
            msg.foto = imagem;
            msg.dataHoraEnviada = DateTime.Now;

            // Protocolo CPF invalido
            msg = new RabbitMessage();
            msg.numeroProtocolo = 3;
            msg.numeroVia = 1;
            msg.cpf = "";
            msg.rg = "000000002X";
            msg.nome = "Paulo Silva";
            msg.pai = "Osvaldo Silva";
            msg.mae = "Renata Silva";
            msg.foto = imagem;
            msg.dataHoraEnviada = DateTime.Now;
            rabbitMQService.sendMessage(msg);

            // Protocolo rg invalido
            msg = new RabbitMessage();
            msg.numeroProtocolo = 4;
            msg.numeroVia = 1;
            msg.cpf = "000000003X";
            msg.rg = "";
            msg.nome = "Daniella Silva";
            msg.pai = "Osvaldo Silva";
            msg.mae = "Renata Silva";
            msg.dataHoraEnviada = DateTime.Now;
            msg.foto = imagem;
            rabbitMQService.sendMessage(msg);

            // Protocolo foto obrigatorio
            msg = new RabbitMessage();
            msg.numeroProtocolo = 4;
            msg.numeroVia = 1;
            msg.cpf = "000000003X";
            msg.rg = "000000003X";
            msg.nome = "Daniella Silva";
            msg.pai = "Osvaldo Silva";
            msg.mae = "Renata Silva";
            msg.dataHoraEnviada = DateTime.Now;
            msg.foto = null;
            rabbitMQService.sendMessage(msg);

            // Protocolo foto obrigatorio
            msg = new RabbitMessage();
            msg.numeroProtocolo = 5;
            msg.numeroVia = 1;
            msg.cpf = "000000005X";
            msg.rg = "000000005X";
            msg.nome = "Henrique Silva";
            msg.pai = "Osvaldo Silva";
            msg.mae = "Renata Silva";
            msg.dataHoraEnviada = DateTime.Now;
            msg.foto = imagem;
            rabbitMQService.sendMessage(msg);

            rabbitMQService.sendMessage(msg);
            msg = new RabbitMessage();


            rabbitMQService.sendMessage(msg);
            return null;
        }

    }
}

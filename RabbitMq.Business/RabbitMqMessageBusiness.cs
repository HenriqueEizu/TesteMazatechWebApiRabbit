using Microsoft.IdentityModel.Tokens;
using Rabbit.Model.Entities;
using RabbitMq.Business.Interfaces;
using RabbitMqMessage.DAO;
using System.Reflection.Metadata.Ecma335;

namespace RabbitMq.Business
{
    public class RabbitMqMessageBusiness : IRabbitMqMessage
    {

        public bool AddRabbitMqMessage(RabbitMessage message)
        {
            using var context = new RabbitMqContext();
            using var contextLog = new RabbitMqContext();


            RabbitMessageLog rabLog = new RabbitMessageLog();
            rabLog.NumeroProtocolo = message.numeroProtocolo;
            rabLog.DataLog = DateTime.Now;

            try
            {
                if (message.cpf == null)
                {
                    rabLog.ErrorDescription = $"CPF  {message.cpf} inválido ou  não enviado.";
                    contextLog.RabbitMessageLog.AddAsync(rabLog);
                    contextLog.SaveChanges();
                }
                else if (message.cpf.Trim().Length > 11 || message.cpf.Trim().Length == 0)
                {
                    rabLog.ErrorDescription = $"CPF  {message.cpf} inválido ou  não enviado.";
                    contextLog.RabbitMessageLog.AddAsync(rabLog);
                    contextLog.SaveChanges();
                }
                else if (message.rg == null)
                {
                    rabLog.ErrorDescription = $"RG  {message.cpf} inválido ou  não enviado.";
                    contextLog.RabbitMessageLog.AddAsync(rabLog);
                    contextLog.SaveChanges();
                }
                else if (message.rg.Trim().Length == 0)
                {
                    rabLog.ErrorDescription = $"RG  {message.cpf} não foi enviado.";
                    contextLog.RabbitMessageLog.AddAsync(rabLog);
                    contextLog.SaveChanges();
                }
                else if (message.nome.Trim().Length == 0)
                {
                    rabLog.ErrorDescription = $"Nome  {message.nome} não foi enviado.";
                    contextLog.RabbitMessageLog.AddAsync(rabLog);
                    contextLog.SaveChanges();
                }
                else if (message.foto == null)
                {
                    rabLog.ErrorDescription = "Foto  não foi enviado.";
                    contextLog.RabbitMessageLog.AddAsync(rabLog);
                    contextLog.SaveChanges();
                }
                else
                {
                    context.RabbitMessage.AddAsync(message);
                    context.SaveChanges();
                }
                
            }
            catch (Exception ex)
            {
                rabLog = new RabbitMessageLog();
                rabLog.NumeroProtocolo = message.numeroProtocolo;
                rabLog.DataLog = DateTime.Now;

                if (ex.InnerException.ToString().IndexOf("UC_RabbitMessage_Protocolo") > -1)
                {
                    rabLog.ErrorDescription = "Número de protocolo ja existente na base de dados";
                }
                else if (ex.InnerException.ToString().IndexOf("UC_RabbitMessage_CpfVia") > -1)
                {
                    rabLog.ErrorDescription = "CPF com a mesma via ja cadastrado";
                }
                else if (ex.InnerException.ToString().IndexOf("UC_RabbitMessage_RgVia") > -1)
                {
                    rabLog.ErrorDescription = "CPF com a mesma via ja cadastrado";
                }
                else
                {
                    rabLog.ErrorDescription = ex.Message.ToString();
                }

                contextLog.RabbitMessageLog.AddAsync(rabLog);
                contextLog.SaveChanges();
            }

            return false;
        }
    }
}
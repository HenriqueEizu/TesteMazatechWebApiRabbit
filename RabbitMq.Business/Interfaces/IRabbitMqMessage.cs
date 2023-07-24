using Rabbit.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMq.Business.Interfaces
{
    public interface IRabbitMqMessage
    {
        bool AddRabbitMqMessage (RabbitMessage message);  
    }
}

using Rabbit.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rabbit.Services.Interfaces
{
    public interface IRabbitMessageService
    {
        void sendMessage(RabbitMessage message);
    }
}

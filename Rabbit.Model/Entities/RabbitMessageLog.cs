using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rabbit.Model.Entities
{
    public class RabbitMessageLog
    {
        public int RabbitMessageLogId { get; set; }
        public int NumeroProtocolo { get; set; }
        public string ErrorDescription { get; set; }
        public DateTime DataLog { get; set; }
    }
}

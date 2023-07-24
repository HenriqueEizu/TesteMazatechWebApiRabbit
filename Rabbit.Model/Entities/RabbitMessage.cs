using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace Rabbit.Model.Entities
{
    public class RabbitMessage
    {

        [Key]
        public int numeroProtocolo { get; set; }

        public int numeroVia { get; set; }

        public string cpf { get; set; }

        public string rg { get; set; }

        public string nome { get; set; }

        public string pai { get; set; }

        public string mae { get; set; }

        public byte[]? foto { get; set; }

        public DateTime dataHoraEnviada { get; set; }



        //Número do Protocolo(obrigatório)
        //• Número da Via do documento(obrigatório) - EX: via 1 = Primeira via de um RG, Via 2,3,4... =
        //Segunda via emitida para um cidadão(perda ou roubo)
        //• Cpf(obrigatório) Sem formatação
        //• RG(obrigatório)
        //• Nome(obrigatório)
        //• Nome da Mãe
        //• Nome do Pai
        //• Foto(obrigatório) - Uma imagem no formato jpg ou png

    }
}

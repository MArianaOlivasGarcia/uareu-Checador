using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checador.Models
{
    public class Message
    {
        public int Id { get; set; }
        public int IdEmployee { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFinal { get; set; }
        public Boolean IsGeneral { get; set; }
        public string Asunto { get; set; }
        public string Mensaje { get; set; }
    }
}

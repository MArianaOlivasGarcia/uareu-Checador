using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checador.Models
{
    public class Checking
    {
        public Int32 Id { get; set; }
        public Int32 Employee { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Time { get; set; }

    }
}

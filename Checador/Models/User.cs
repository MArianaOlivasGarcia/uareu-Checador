using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checador.Models
{
    public class User
    {
        public Int32 Id { get; set; }
        public String Name { get; set; }
        public Int32 Role { get; set; }
        public String Password { get; set; }
        public Boolean IsActive { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checador.Models
{
    public class Employee
    {
        public Int32 Id { get; set; }
        public String Titulo { get; set; }
        public String Nombre { get; set; }
        public String Paterno { get; set; }
        public String Materno { get; set; }
        public String Sexo { get; set; }
        public String RFC { get; set; }
        public String CURP { get; set; }
        public String Contrato { get; set; }
        public String Tipo { get; set; }
        public Int32 TotalHoras { get; set; }
        public String Status { get; set; }
        public String Email { get; set; }
        public String CodigoTarjeta { get; set; }

        public DPFP.Sample Huella { get; set; }
        public string Huella1 { get; set; }
        public DPUruNet.Fmd Huella2 { get; set; }
        public string Huella3 { get; set; }
        public DateTime FechaIngreso { get; set; }
        public System.Drawing.Image Foto { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCovisian.Dto_
{
    public class DatalleAlquilerClienteDTO
    {
        public string Cedula { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaAlquiler { get; set; }
        public int TiempoAlquilado { get; set; }
        public decimal Saldo { get; set; }
        public string Placa { get; set; }
        public string Marca { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCovisian.Modelo
{
    public class Alquiler
    {
        public int AlquilerId { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public decimal ValorTotal { get; set; }
        public decimal AbonoInicial { get; set; }
        public decimal Saldo { get; set; }
        public bool Devuelto { get; set; }
        public int CarroId { get; set; }
        public int ClienteId { get; set; }


    }
}

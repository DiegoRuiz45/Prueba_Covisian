using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCovisian.Modelo
{
    public class Carro
    {
        public int CarroId { get; set; }
        public string Placa { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public decimal Costo { get; set; }
        public bool Disponible { get; set; }
    }
}

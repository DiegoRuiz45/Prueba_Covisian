using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCovisian.Dto_;
using TestCovisian.Modelo;

namespace TestCovisian.Repositorio
{
    public interface IAlquilerServicio
    {
        List<DatalleAlquilerClienteDTO> ObtenerAlquileres();
        List<DatalleAlquilerClienteDTO> ObtenerAlquileresPorFechas(DateTime fechaInicio, DateTime fechaFin);
        int ObtenerAlquileresPorDia(DateTime fecha);
        int ObtenerAlquileresPorMes(int anio, int mes);

    }
}

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

using TestCovisian.Dto_;
using TestCovisian.Modelo;
using TestCovisian.Repositorio;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
namespace TestCovisian.Impl
{
    public class AlquilerServicioImpl : IAlquilerServicio
    {
      
        private readonly string _connectionString;
        public AlquilerServicioImpl()
        {
            _connectionString =  ConfigurationManager.ConnectionStrings["DB_Covisian"].ConnectionString;
            
        }


        public List<DatalleAlquilerClienteDTO> ObtenerAlquileres()
        {
            List<DatalleAlquilerClienteDTO> alquileres = new List<DatalleAlquilerClienteDTO>();

            string query = @"
            SELECT 
                C.Cedula,
                C.Nombre,
                A.FechaInicio AS FechaAlquiler,
                DATEDIFF(DAY, A.FechaInicio, A.FechaFin) AS TiempoAlquilado,
                A.Saldo,
                CR.Placa,
                CR.Marca
            FROM 
                TblAlquiler A
            JOIN 
                TblCliente C ON A.ClienteId = C.ClienteId
            JOIN 
                TblCarro CR ON A.CarroId = CR.CarroId";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    DatalleAlquilerClienteDTO dto = new DatalleAlquilerClienteDTO
                    {
                        Cedula = reader["Cedula"].ToString(),
                        Nombre = reader["Nombre"].ToString(),
                        FechaAlquiler = Convert.ToDateTime(reader["FechaAlquiler"]),
                        TiempoAlquilado = Convert.ToInt32(reader["TiempoAlquilado"]),
                        Saldo = Convert.ToDecimal(reader["Saldo"]),
                        Placa = reader["Placa"].ToString(),
                        Marca = reader["Marca"].ToString()
                    };
                    alquileres.Add(dto);
                }
            }

            Console.WriteLine($"Alquileres obtenidos: {alquileres.Count}");
            return alquileres;
        }

        public List<DatalleAlquilerClienteDTO> ObtenerAlquileresPorFechas(DateTime fechaInicio, DateTime fechaFin)
        {
            var alquileres = new List<DatalleAlquilerClienteDTO>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string query = @"
                    SELECT 
                        c.Cedula,
                        c.Nombre,
                        a.FechaInicio AS FechaAlquiler,
                        DATEDIFF(DAY, a.FechaInicio, a.FechaFin) AS TiempoAlquilado,
                        a.Saldo,
                        car.Placa,
                        car.Marca
                    FROM TblAlquiler a
                    JOIN TblCliente c ON a.ClienteId = c.ClienteId
                    JOIN TblCarro car ON a.CarroId = car.CarroId
                    WHERE convert(date, a.FechaInicio) >= @FechaInicio AND convert(date, a.FechaFin) <= @FechaFin";

                

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add("@FechaInicio", SqlDbType.Date).Value = fechaInicio.Date;
                    command.Parameters.Add("@FechaFin", SqlDbType.Date).Value = fechaFin.Date;

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var alquiler = new DatalleAlquilerClienteDTO
                            {
                                Cedula = reader["Cedula"].ToString(),
                                Nombre = reader["Nombre"].ToString(),
                                FechaAlquiler = Convert.ToDateTime(reader["FechaAlquiler"]),
                                TiempoAlquilado = Convert.ToInt32(reader["TiempoAlquilado"]),
                                Saldo = Convert.ToDecimal(reader["Saldo"]),
                                Placa = reader["Placa"].ToString(),
                                Marca = reader["Marca"].ToString()
                            };
                            alquileres.Add(alquiler);
                        }
                    }
                }
            }

            return alquileres;
        }


        //ALQUILER POR DIA Y POR MES
        public int ObtenerAlquileresPorDia(DateTime fecha)
        {
            int alquileresPorDia = 0;

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string query = @"
            SELECT COUNT(*) 
            FROM TblAlquiler
            WHERE CONVERT(date, FechaInicio) = @Fecha";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add("@Fecha", SqlDbType.Date).Value = fecha.Date;

                    alquileresPorDia = (int)command.ExecuteScalar();
                }
            }

            return alquileresPorDia;
        }

        public int ObtenerAlquileresPorMes(int anio, int mes)
        {
            int alquileresPorMes = 0;

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string query = @"
            SELECT COUNT(*) 
            FROM TblAlquiler
            WHERE YEAR(FechaInicio) = @Anio AND MONTH(FechaInicio) = @Mes";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add("@Anio", SqlDbType.Int).Value = anio;
                    command.Parameters.Add("@Mes", SqlDbType.Int).Value = mes;

                    alquileresPorMes = (int)command.ExecuteScalar();
                }
            }

            return alquileresPorMes;
        }








    }
}

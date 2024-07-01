using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestCovisian.Dto_;
using TestCovisian.Impl;
using TestCovisian.Modelo;
using TestCovisian.Repositorio;

namespace TestCovisian.Forms
{
    public partial class DetalleClienteAlquiler : Form
    {
        private readonly IAlquilerServicio _alquilerService;
        public DetalleClienteAlquiler()
        {
            InitializeComponent();
            _alquilerService = new AlquilerServicioImpl();
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            DateTime fechaInicio = DateTime.Parse(txtFechaInicio.Text);
            //DateTime fechaInicio = fechaIni.Date;
            DateTime fechaFin = DateTime.Parse(txtFechaFin.Text);
            //DateTime fechaFinal = fechaFin.Date;
            CargarDatos(fechaInicio, fechaFin);
            //MessageBox.Show("fechaInicio" + fechaInicio+ " fechaFin" + fechaFin);
            
        }

        private void CargarDatos(DateTime fechaInicio, DateTime fechaFin)
        {
            List<DatalleAlquilerClienteDTO> alquileres = _alquilerService.ObtenerAlquileresPorFechas(fechaInicio, fechaFin);
            if (alquileres.Count == 0)
            {
                MessageBox.Show("No se encontraron alquileres en el rango de fechas especificado.");
            }
            else
            {
                //tblClienteAlquiler.DataSource = alquileres;
                this.tblClienteAlquiler.Rows.Clear();
                foreach (var item in alquileres)
                {
                    this.tblClienteAlquiler.Rows.Add(
                        item.Cedula,
                        item.Nombre,
                        item.FechaAlquiler,
                        item.TiempoAlquilado,
                        item.Saldo,
                        item.Placa,
                        item.Marca
                       );
                }
            }
        }

        public void CargarDatos()
        {
            tblClienteAlquiler.AutoGenerateColumns = false;
            List<DatalleAlquilerClienteDTO> alquileres = _alquilerService.ObtenerAlquileres();
            if (alquileres.Count == 0)
            {
                MessageBox.Show("No existen registros");
            }
            else
            {
                //MessageBox.Show("clientes: " + alquileres.Count);
                //tblClienteAlquiler.DataSource = alquileres;
                this.tblClienteAlquiler.Rows.Clear();
                foreach (var item in alquileres)
                {
                    this.tblClienteAlquiler.Rows.Add(
                        item.Cedula,
                        item.Nombre,
                        item.FechaAlquiler,
                        item.TiempoAlquilado,
                        item.Saldo,
                        item.Placa,
                        item.Marca
                       );
                }


            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CargarDatos();
        }
    } 


        
}


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestCovisian.Impl;
using TestCovisian.Repositorio;

namespace TestCovisian.Forms
{
    public partial class TotalAlquiler : Form
    {
        private readonly IAlquilerServicio _alquilerService;
        public TotalAlquiler()
        {
            InitializeComponent();
            _alquilerService = new AlquilerServicioImpl();
        }


        private void ClienteForm_Load(object sender, EventArgs e)
        {
          
            timer.Start();
            ActualizarAlquileres();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            ActualizarAlquileres();
        }

        private void ActualizarAlquileres()
        {
            DateTime fechaActual = DateTime.Now;
            int alquileresDiarios = _alquilerService.ObtenerAlquileresPorDia(fechaActual);
            int alquileresMensuales = _alquilerService.ObtenerAlquileresPorMes(fechaActual.Year, fechaActual.Month);

            
            lbMensual.Text = $" {alquileresMensuales}";
            lbDiario.Text = $" {alquileresDiarios}";
        }

        
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestCovisian.Forms;

namespace TestCovisian
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DetalleClienteAlquiler af = new DetalleClienteAlquiler();
            af.Visible = true;
            af.CargarDatos();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            TotalAlquiler total = new TotalAlquiler();
            total.Visible = true;   
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AppPractica.Conect;

namespace AppPractica.Views
{
    public partial class PnlAdClientes : Form
    {
        public Conexion con;
        public PnlAdClientes()
        {
            InitializeComponent();
        }
        public PnlAdClientes(Conexion con)
        {
            this.con = con;
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            con.agregar_Cliente(txtPN.Text, txtSN.Text, txtPA.Text, txtSA.Text, txtDirc.Text, txtTel.Text, int.Parse(txtdep.Text));
            this.Hide();
        }

        private void PnlAdClientes_Load(object sender, EventArgs e)
        {

        }
    }
}

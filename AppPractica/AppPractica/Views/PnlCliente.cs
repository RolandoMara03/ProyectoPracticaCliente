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
    public partial class PnlCliente : Form
    {
        public Conexion con;
        public PnlCliente()
        {
            InitializeComponent();
        }
        public PnlCliente(Conexion con)
        {
            this.con = con;
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void PnlCliente_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = con.llenar_clientes();
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            PnlAdClientes adC = new PnlAdClientes(con);
            adC.Show();

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = con.llenar_clientes();
        }
    }
}

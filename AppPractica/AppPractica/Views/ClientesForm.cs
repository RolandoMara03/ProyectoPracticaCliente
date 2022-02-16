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
    public partial class ClientesForm : Form
    {
        public Conexion con;
        String Usuario;
        PnlCliente pc;
        
        public ClientesForm()
        {
            InitializeComponent();
        }
        public ClientesForm(Conexion con,String Usuario)
        {
            this.con = con;
            this.Usuario = Usuario;
            InitializeComponent();
            

        }
        private void ClientesForm_Load(object sender, EventArgs e)
        {
            txtUsuario.Text = Usuario;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Gracias por utilizar la app", "Terminar");
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pc = new PnlCliente(con);
            pc.TopLevel = false;
            PnlContent.Controls.Add(pc);
            pc.Show();
           
        }
    }
}

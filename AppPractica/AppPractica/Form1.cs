using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using AppPractica.Conect;
using AppPractica.Views;

namespace AppPractica
{
    public partial class Form1 : Form
    {
        int cont = 3;
        Conexion con;
        ClientesForm cf;


        public Form1()
        {
            InitializeComponent();
      
        }

        private void label1_Click(object sender, EventArgs e)
        {


        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            if (txtUsuario.Text.Equals("") || txtContraseña.Text.Equals(""))
            {
                MessageBox.Show("No pueden haber campos vacios", "Alerta");
                Cursor.Current = Cursors.Default;
                return;
            }

            con = new Conexion(txtUsuario.Text, txtContraseña.Text);
            if (this.con.connect.State == ConnectionState.Open)
            {
                /*
                bg.WorkerReportsProgress = true;
                bg.ProgressChanged += bg_ProgressChanged;
                bg.DoWork += bg_DoWork;
                bg.RunWorkerCompleted += bg_RunWorkerCompleted;
                bg.RunWorkerAsync();
                label5.Visible = true;
                progressBar1.Visible = true;
                */
                MessageBox.Show("Su conexion fue realizada con exito!!", "Conexion");
                cf = new ClientesForm(con,txtUsuario.Text);

                cf.Show();
                this.Hide();
            }
            else
            {
                Cursor.Current = Cursors.Default;
                --cont;
                MessageBox.Show("Error:usuario o contrasenia incorrecta ", cont + " Intentos restantes");
                if (cont == 0)
                {
                    cont = 3;
                    BtnLogin.Enabled = false;
                    BtnSalir.Enabled = false;
                    Thread.Sleep(3000);
                    BtnLogin.Enabled = true;
                    BtnSalir.Enabled = true;

                }


            }
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Gracias por utilizar la app","Terminar");
            Application.Exit();
        }
    }
}

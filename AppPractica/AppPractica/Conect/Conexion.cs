using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppPractica.Conect
{
    public class Conexion
    {
        public SqlConnection connect = new SqlConnection();

        public Conexion(String user, String pass)
        {
            try
            {

                connect = new SqlConnection("Server=tcp:CCBB31,45679;Database=CV;UID=" + user + ";PWD=" + pass);
                connect.Open();
            }
            catch (Exception)
            {


            }
        }
        public DataTable llenar_clientes() {
            SqlCommand cmd = new SqlCommand();
            SqlDataReader leer;

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ViewClientes";
            cmd.Connection = connect;


            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();
            da.Fill(dt);

            // GridView1.DataSource = dt;
            return dt;

        }
        public void agregar_Cliente(String PNombre, String SNombre, String PApellido, String SApellido, String direccion, String telefono,int iddep)
        {

            SqlCommand cmd = new SqlCommand();

            SqlParameter[] param = new SqlParameter[7];
            param[0] =  new SqlParameter("@PN", SqlDbType.NVarChar);
            param[0].Value = PNombre;
            param[1] = new SqlParameter("@SN", SqlDbType.NVarChar);
            param[1].Value = SNombre;
            param[2] = new SqlParameter("@PA", SqlDbType.NVarChar);
            param[2].Value = PApellido;
            param[3] = new SqlParameter("@SA", SqlDbType.NVarChar);
            param[3].Value = SApellido;
            param[4] = new SqlParameter("@DIR", SqlDbType.NVarChar);
            param[4].Value = direccion;
            param[5] = new SqlParameter("@TEL", SqlDbType.Char);
            param[5].Value = telefono;
            param[6] = new SqlParameter("@IDD", SqlDbType.Int);
            param[6].Value = iddep;

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "AgregarCliente";
            cmd.Connection = connect;
            cmd.Parameters.AddRange(param);
            cmd.ExecuteNonQuery();

            SqlDataAdapter da = new SqlDataAdapter(cmd);

            

        }


    }
}

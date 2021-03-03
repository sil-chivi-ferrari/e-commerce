using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Negocio
{
    public class AccesoDatos
    {
        public SqlDataReader lector { get; set; }
        public SqlConnection conexion { get; set; }
        public SqlCommand comando { get; set; }

        public AccesoDatos() //constructor
        {
            conexion = new SqlConnection("data source = .\\SQLEXPRESS; initial catalog = Remeras_DB ; integrated security = sspi");
            comando = new SqlCommand();
            comando.Connection = conexion;
        }
        public void setearQuery (string consulta )
        {
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = consulta;

        }
        public void setearQuery_ConPa(string consulta)
        {
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.CommandText = consulta;

        }

        public void agregarParametro (string nombre, object valor)
        {
            comando.Parameters.AddWithValue(nombre, valor);
        }
        public void ejecutarLector()
        {
        try {
                conexion.Open();
                
            }
        catch (Exception ex)
            { throw ex; }
        finally
            {
                //conexion.Close();
            }

        }
        public void cerrarConexion() 
        {
            conexion.Close();
        }
        internal void ejecutarAccion()
        {
            try {
                conexion.Open();
                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {   throw ex; }
            finally { conexion.Close(); }
        }





    }
}

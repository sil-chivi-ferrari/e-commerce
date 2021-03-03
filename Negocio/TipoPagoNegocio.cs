using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class TipoPagoNegocio
    {
        public List<TipoPago> Listar()
        {
            AccesoDatos datos = new AccesoDatos();
            List<TipoPago> Lista = new List<TipoPago>();
            datos.setearQuery("select Id, Nombre from TipoPagos");
            try
            {
                datos.ejecutarLector();
                datos.lector = datos.comando.ExecuteReader();
                while (datos.lector.Read())
                {
                    TipoPago aux = new TipoPago();
                    aux.Id = (Byte)datos.lector["Id"];
                    aux.Nombre = (string)datos.lector["Nombre"];
                   
                    Lista.Add(aux);

                }
                datos.lector.Close();
                datos.conexion.Close();
                return Lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}

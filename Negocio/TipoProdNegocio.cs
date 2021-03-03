using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Negocio;
using Dominio;
using System.Data.SqlClient;

namespace Negocio
{
    public class TipoProdNegocio
    {
        public List<TipoProducto> Listar()
        {
            AccesoDatos datos = new AccesoDatos();
            List<TipoProducto> Lista = new List<TipoProducto>();
            datos.setearQuery("select Id, Nombre, Estado from TipoProducto");
            try
            {
                datos.ejecutarLector();
                datos.lector = datos.comando.ExecuteReader();
                while (datos.lector.Read())
                {
                    TipoProducto aux = new TipoProducto();
                    aux.Id = (Byte)datos.lector["Id"];
                    aux.Nombre = (string)datos.lector["Nombre"];
                    aux.Estado = (bool)datos.lector["Estado"];
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

        public void Agregar(TipoProducto nuevo) // es hacer un insert into en la DB 
        {
            AccesoDatos datos = new AccesoDatos();
            //List<Producto> lista = new List<Producto>();


            datos.setearQuery("insert into TipoProducto (Nombre) values(@Nombre)");


            datos.agregarParametro("@Nombre", nuevo.Nombre);


            datos.conexion.Open();
            datos.comando.ExecuteNonQuery();

        }

        public void Modificar(TipoProducto tipo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearQuery("Update TipoProducto set Nombre = @Nombre  where Id = @Id");


                datos.agregarParametro("@Id", tipo.Id);

                datos.agregarParametro("@Nombre", tipo.Nombre);



                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void DarBajaLogicaTIpoProducto(TipoProducto tipo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearQuery("Update TipoProducto set Estado = 0  where Id = @Id");


                datos.agregarParametro("@Id", tipo.Id);


                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}

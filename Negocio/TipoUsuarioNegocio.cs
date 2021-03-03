using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class TipoUsuarioNegocio
    {
        public List<TipoUsuario> Listar()
        {
            AccesoDatos datos = new AccesoDatos();
            List<TipoUsuario> Lista = new List<TipoUsuario>();
            datos.setearQuery("select Id, Nombre, Estado from TipoUsuario");
            try
            {
                datos.ejecutarLector();
                datos.lector = datos.comando.ExecuteReader();
                while (datos.lector.Read())
                {
                    TipoUsuario aux = new TipoUsuario();
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

        public void Agregar(TipoUsuario tipoUsuario) // es hacer un insert into en la DB 
        {
            AccesoDatos datos = new AccesoDatos();
            //List<Producto> lista = new List<Producto>();


            datos.setearQuery("insert into TipoUsuario (Nombre) values(@Nombre)");


            datos.agregarParametro("@Nombre", tipoUsuario.Nombre);


            datos.conexion.Open();
            datos.comando.ExecuteNonQuery();

        }

        public void Modificar(TipoUsuario tipoUsuario)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearQuery("Update TipoUsuario set Nombre = @Nombre  where Id = @Id");


                datos.agregarParametro("@Id", tipoUsuario.Id);

                datos.agregarParametro("@Nombre", tipoUsuario.Nombre);



                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void DarBajaLogicaTipoUsuario(TipoUsuario tipo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearQuery("Update TipoUsuario set Estado = 0  where Id = @Id");


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


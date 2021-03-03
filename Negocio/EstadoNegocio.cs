using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class EstadoNegocio
    {
        public List<Estado> Listar()
        {
            AccesoDatos datos = new AccesoDatos();
            List<Estado> Lista = new List<Estado>();
            datos.setearQuery(" select Id, NombreEstado, Estado from Estados");
            try
            {
                datos.ejecutarLector();
                datos.lector = datos.comando.ExecuteReader();
                while (datos.lector.Read())
                {
                    Estado aux = new Estado();
                    aux.Id = (Byte)datos.lector["Id"];
                    aux.NombreEstado = (string)datos.lector["NombreEstado"];
                    aux.Estados = (bool)datos.lector["Estado"];
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
        public void Agregar(Estado estado) // es hacer un insert into en la DB 
        {
            AccesoDatos datos = new AccesoDatos();
            //List<Producto> lista = new List<Producto>();


            datos.setearQuery("insert into Estados (NombreEstado) values(@NombreEstado)");


            datos.agregarParametro("@NombreEstado", estado.NombreEstado);


            datos.conexion.Open();
            datos.comando.ExecuteNonQuery();

        }

        public void Modificar(Estado estado)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearQuery("Update Estados set Nombre = @Nombre  where Id = @Id");


                datos.agregarParametro("@Id", estado.Id);

                datos.agregarParametro("@Nombre", estado.NombreEstado);



                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void DarBajaLogicaEstado(Estado estado)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearQuery("Update Estados set Estado = 0  where Id = @Id");


                datos.agregarParametro("@Id", estado.Id);


                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        
        

        
    }
}

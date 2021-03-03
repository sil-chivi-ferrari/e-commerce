using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class TalleNegocio
    {
        public List<Talle> Listar()
        {
            AccesoDatos datos = new AccesoDatos();
            List<Talle> Lista = new List<Talle>();
            datos.setearQuery(" select Id, Nombre, Estado from Talles");
            try
            {
                datos.ejecutarLector();
                datos.lector = datos.comando.ExecuteReader();
                while (datos.lector.Read())
                {
                    Talle aux = new Talle();
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

        public void Agregar(Talle nuevo) // es hacer un insert into en la DB 
        {
            AccesoDatos datos = new AccesoDatos();
            //List<Producto> lista = new List<Producto>();


            datos.setearQuery("insert into Talles (Nombre) values(@Nombre)");


            datos.agregarParametro("@Nombre", nuevo.Nombre);


            datos.conexion.Open();
            datos.comando.ExecuteNonQuery();

        }

        public void Modificar(Talle talle)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearQuery("Update Talles set Nombre = @Nombre  where Id = @Id");


                datos.agregarParametro("@Id", talle.Id);

                datos.agregarParametro("@Nombre", talle.Nombre);



                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void DarBajaLogicaTalle(Talle talles)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearQuery("Update Talles set Estado = 0  where Id = @Id");


                datos.agregarParametro("@Id", talles.Id);


                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}

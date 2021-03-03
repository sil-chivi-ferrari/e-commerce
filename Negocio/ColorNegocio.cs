using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;


namespace Negocio
{
    public class ColorNegocio
    {
        public List<Color> Listar()
        {
            AccesoDatos datos = new AccesoDatos();
            List<Color> Lista = new List<Color>();
            datos.setearQuery(" select Id, Nombre, Estado from Color");
            try
            {
                datos.ejecutarLector();
                datos.lector = datos.comando.ExecuteReader();
                while (datos.lector.Read())
                {
                    Color aux = new Color();
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
        public void Agregar(Color nuevo) // es hacer un insert into en la DB 
        {
            AccesoDatos datos = new AccesoDatos();
            //List<Producto> lista = new List<Producto>();

            
            datos.setearQuery("insert into Color (Nombre) values(@Nombre)");
        
           
            datos.agregarParametro("@Nombre", nuevo.Nombre);
           

            datos.conexion.Open();
            datos.comando.ExecuteNonQuery();

        }

        public void Modificar(Color color)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearQuery("Update Color set Nombre = @Nombre  where Id = @Id");


                    datos.agregarParametro("@Id", color.Id);
              
                datos.agregarParametro("@Nombre", color.Nombre);
              


                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void DarBajaLogicaColor(Color color)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearQuery("Update Color set Estado = 0  where Id = @Id");

              
                datos.agregarParametro("@Id", color.Id);


                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}

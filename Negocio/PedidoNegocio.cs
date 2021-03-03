using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class PedidoNegocio
    {

        public List<Pedido> Listar()
        {
            AccesoDatos datos = new AccesoDatos();// aca adentro hay magia, estan lector, conexion y comando
            List<Pedido> lista = new List<Pedido>();
            datos.setearQuery("select p.*,u.id as idUser,u.NombreUsuario, e.Id as Idest, e.NombreEstado from Pedidos p join Usuarios u on p.IdUsuario = u.Id join Estados e on e.Id = p.IdEstado");
                //select p.*,u.id as idUser,u.NombreUsuario from Pedidos p join Usuarios u on p.IdUsuario = u.Id
            try
            {
                datos.ejecutarLector();
                datos.lector = datos.comando.ExecuteReader();

                while (datos.lector.Read())
                {

                   
                    Pedido aux;
                    aux = new Pedido();// es como darle un espacio de memoria al nacer.
                                         // aux.id es la parte del setter xq le etoy asignando un valor si el codigo estuviera al reves seria un getter 
                    aux.Id = (long)datos.lector["Id"];
                    aux.IdUsuario = (long)datos.lector["IdUsuario"];
                    aux.IdEstado = (byte)datos.lector["IdEstado"];
                    aux.Fecha = (DateTime)datos.lector["Fecha"];
                    aux.Importe = (decimal)datos.lector["Importe"];

                    aux.usuario = new Usuario();
                    aux.usuario.Id= (long)datos.lector["idUser"];
                    aux.usuario.NombreUsuario = (string)datos.lector["NombreUsuario"];

                    aux.estado = new Estado();
                    aux.estado.Id = (byte)datos.lector["Idest"];
                    aux.estado.NombreEstado = (string)datos.lector["NombreEstado"];

                    lista.Add(aux);


                }

                datos.lector.Close();
                datos.conexion.Close();
                return lista;
            }
            catch (Exception ex)
            {

                throw ex;

            }

        }
        public void Agregar (Pedido pedido)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {

                datos.setearQuery(" insert into Pedidos (IdUsuario, IdEstado, Fecha, Importe, IdTipoPago, Agregado) values (@IdUsuario, @IdEstado , getdate(), @Importe, @IdTipoPago, @Agregado)");

                if (!string.IsNullOrEmpty(pedido.tipoPago.Nombre)) // para decir si es nulo
                    datos.agregarParametro("@Agregado", pedido.tipoPago.Nombre);
                else
                    datos.agregarParametro("@Agregado", DBNull.Value); // pasa un null q el sql lo puede interpretar

                datos.agregarParametro("@IdUsuario",pedido.IdUsuario);
                datos.agregarParametro("@IdEstado",pedido.IdEstado);
                //datos.agregarParametro("@Fecha",pedido.Fecha);
                datos.agregarParametro("@Importe",pedido.Importe);
                datos.agregarParametro("@IdTipoPago", pedido.IdTipoPago);
               // datos.agregarParametro("@Agregado", pedido.tipoPago.Nombre);




                //datos.conexion.Open();
                //datos.comando.ExecuteNonQuery();
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

      

        public long InsertarDetalle()
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                long Id;
               //datos.setearQuery("SELECT IDENT_CURRENT ('pedidos') AS Ultimo");
                //datos.setearQuery_ConPa("sp_UltimoIdPedido");





                datos.setearQuery("select max(id) from Pedidos "); // selecciono el ultimo id DE LA TABLA PEDIDO   
                datos.ejecutarLector();
                datos.lector = datos.comando.ExecuteReader();
                datos.lector.Read(); //No hace falta while porque es un solo registro :)
                Id = datos.lector.GetInt64(0); //se lo asigno
                datos.cerrarConexion();
                return Id; // retorno ese id

                //datos.ejecutarLector();
                //datos.lector = datos.comando.ExecuteReader();
                ////Pedido aux;
                ////aux = new Pedido();
                //long Id=0;
                //while (datos.lector.Read())
                //{
                //    //aca esta mal porque no se como guardarme el numero del id que me devuelve
                //    //aux.IdPedido = (long)datos.lector["Ultimo"];
                //    Id =  datos.lector.GetInt64(0);
                //}

                //datos.lector.Close();
                //datos.conexion.Close();
                //return Id;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void CambiarEstado(Pedido pedido)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearQuery("Update Pedidos set IdEstado = @IdEstado where Id = @Id");


                datos.agregarParametro("@IdEstado", pedido.IdEstado);
                datos.agregarParametro("@Id", pedido.Id);


                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public Pedido BuscarPorId(long IdPedido)
        {
            AccesoDatos datos = new AccesoDatos();
            // List<Producto> lista = new List<Producto>();
            try
            {
                //YA LE AGREGUE IDCOLOR Y IDTALLE
                datos.setearQuery("select * from pedidos where id = @idPedido");
                datos.agregarParametro("@IdPedido", IdPedido);


                datos.ejecutarLector();
                datos.lector = datos.comando.ExecuteReader();

                Pedido aux = new Pedido();
                while (datos.lector.Read())
                {
                    //Producto aux;
                   
                    aux.Id = (long)datos.lector["Id"];
                    aux.IdUsuario = (long)datos.lector["IdUsuario"];
                    aux.IdEstado = (byte)datos.lector["IdEstado"];
                    aux.Fecha = (DateTime)datos.lector["Fecha"];
                    aux.Importe = (decimal)datos.lector["Importe"];


                }

                datos.lector.Close();
                datos.conexion.Close();
                return aux;


            }
            catch (Exception ex)
            {

                throw ex;

            }
        }

        public List<Pedido> ListarPorUser(long Id)
        {
            AccesoDatos Acceso = new AccesoDatos();
            List<Pedido> Lista = new List<Pedido>();
            Acceso.setearQuery("select p.*,u.id as idUser,u.NombreUsuario, e.Id as Idest, e.NombreEstado from Pedidos p join Usuarios u on p.IdUsuario = u.Id join Estados e on e.Id = p.IdEstado where @IdUser = IdUsuario");
            try
            {
                Acceso.agregarParametro("@IdUser", Id);
                Acceso.ejecutarLector();
                Acceso.lector = Acceso.comando.ExecuteReader();
                while (Acceso.lector.Read())
                {
                    Pedido Aux = new Pedido();
                    Aux.Id = Acceso.lector.GetInt64(0);
                    Aux.IdUsuario = Acceso.lector.GetInt64(1);
                    Aux.IdEstado = Acceso.lector.GetByte(2);
                    Aux.Fecha = Acceso.lector.GetDateTime(3);
                    Aux.Importe = Acceso.lector.GetDecimal(4);

                    Aux.usuario = new Usuario();
                    Aux.usuario.Id= (long)Acceso.lector["idUser"];
                    Aux.usuario.NombreUsuario = (string)Acceso.lector["NombreUsuario"];
                    
                    Aux.estado = new Estado();
                    Aux.estado.Id = (byte)Acceso.lector["Idest"];
                    Aux.estado.NombreEstado = (string)Acceso.lector["NombreEstado"];

                    Lista.Add(Aux);
                }
                return Lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}

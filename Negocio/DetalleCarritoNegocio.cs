using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using Negocio;

namespace Negocio
{
    public class DetalleCarritoNegocio
    {
        public List<DetalleCarrito> Listar()
        {
            AccesoDatos datos = new AccesoDatos();// aca adentro hay magia, estan lector, conexion y comando
            List<DetalleCarrito> lista = new List<DetalleCarrito>();
            datos.setearQuery("Select IdProducto, IdPedido, PrecioActual, CantidadPedida, Detalle.UrlImagen, Detalle.Nombre from Detalle join Producto on Producto.Id = Detalle.IdProducto");
            try
            {
                datos.ejecutarLector();
                datos.lector = datos.comando.ExecuteReader();

                while (datos.lector.Read())
                {
                    DetalleCarrito aux;
                    aux = new DetalleCarrito();// es como darle un espacio de memorio al nacer.
                                               // aux.id es la parte del setter xq le etoy asignando un valor si el codigo estuviera al reves seria un getter 
                    aux.IdProducto = (long)datos.lector["IdProducto"];
                    aux.IdPedido = (long)datos.lector["IdPedido"];
                    aux.PrecioActual = datos.lector.GetDecimal(2);
                    aux.CantidadPedida = (byte)datos.lector["CantidadPedida"];
                    aux.UrlImagen = datos.lector.GetString(4);
                    aux.NombreActual = (string)datos.lector["Nombre"];




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

        public ItemCarrito Map(Producto producto)
        {
            ItemCarrito carrito = new ItemCarrito() // inicializacion mientras instancio
            {
                UrlImagen = producto.UrlImagen,
                Precio = producto.Precio,
                IdProducto = producto.Id,
                IdTipo = producto.IdTipo,
                Nombre = producto.Nombre,
                Talle = producto.talle.Nombre,
                Descripcion = producto.Descripcion,
                Color = producto.color.Nombre,


            };

            return carrito;
        }

        public List<DetalleCarrito> Asignar(List<ItemCarrito> lista)
        {
            List<DetalleCarrito> ListaDetalle = new List<DetalleCarrito>();
            DetalleCarrito detalle = new DetalleCarrito();
            ItemCarrito itemcarrito = new ItemCarrito();



            foreach (var item in lista)
            {
                detalle = new DetalleCarrito(); // esto es para no pisar lo que esta en la direccion de memoria, si solo tengo un detalle siempre se va a pisar ahi, en cambio instanciandolo le doy un nuevo lugar en memoria
                detalle.NombreActual = item.Nombre;
                detalle.PrecioActual = item.Precio;
                detalle.UrlImagen = item.UrlImagen;
                detalle.IdProducto = item.IdProducto;
                detalle.CantidadPedida = item.CantidadItem;
                ListaDetalle.Add(detalle);
            }

            return ListaDetalle;
        }

        public void PasarDeLista_a_detalle(List<DetalleCarrito> detalleCarrito, long valorDevuelto)
        {
          
            DetalleCarrito detalle;
            foreach (var item in detalleCarrito)
            {
                detalle = new DetalleCarrito();
                detalle.IdProducto = item.IdProducto;
                detalle.NombreActual = item.NombreActual;
                detalle.PrecioActual = item.PrecioActual;
                detalle.UrlImagen = item.UrlImagen;
                detalle.CantidadPedida = item.CantidadPedida;
                detalle.IdPedido = valorDevuelto;
               
                GuardarDetalle_DB(detalle);
            }


        }

        public void GuardarDetalle_DB (DetalleCarrito detalle)
        {
            AccesoDatos datos = new AccesoDatos();

            datos.setearQuery_ConPa("SP_AgregarDetalle");

            datos.agregarParametro("@IdProducto", detalle.IdProducto);
            datos.agregarParametro("@IdPedido", detalle.IdPedido);
            datos.agregarParametro("@PrecioActual", detalle.PrecioActual);
            datos.agregarParametro("@CantidadPedida", detalle.CantidadPedida);
            datos.agregarParametro("@UrlImagen", detalle.UrlImagen);
            datos.agregarParametro("@Nombre", detalle.NombreActual);

            datos.ejecutarAccion();
        }

        public List<DetalleCarrito> BuscadorDeLong(long Busqueda)
        {
            AccesoDatos datos = new AccesoDatos();
            List<DetalleCarrito> listaBuscado = new List<DetalleCarrito>();

            try
            {
                //Producto aux = new Producto();
                datos.setearQuery("select * from Detalle where IdPedido = @Busqueda");
                //select p.*, c.Id as IdColores, c.Nombre as NombreColores from Producto p join Color as c on c.id = p.IdColor where IdColor = @Busqueda

                datos.agregarParametro("@Busqueda", Busqueda);



                datos.ejecutarLector();
                datos.lector = datos.comando.ExecuteReader();

                while (datos.lector.Read())
                {
                    DetalleCarrito aux;
                    aux = new DetalleCarrito();

                    aux.IdProducto = (long)datos.lector["IdProducto"];
                    aux.IdPedido = (long)datos.lector["IdPedido"];
                    aux.PrecioActual = datos.lector.GetDecimal(2);
                    aux.CantidadPedida = (byte)datos.lector["CantidadPedida"];
                    aux.UrlImagen = datos.lector.GetString(4);
                    aux.NombreActual = (string)datos.lector["Nombre"];

                    



                    listaBuscado.Add(aux);
                }

                datos.lector.Close();
                datos.conexion.Close();
                return listaBuscado;
            }
            catch (Exception ex)
            {

                throw ex;

            }
        }

    }




}

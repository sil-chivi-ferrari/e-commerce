using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using System.Data.SqlClient;

namespace Negocio
{
    //ACA VA A ESTAR TODA LA LOGICA DE NEGOCIO
    public class ProductoNegocio
    {
        public List<Producto> Listar()
        {
            AccesoDatos datos = new AccesoDatos();// aca adentro hay magia, estan lector, conexion y comando
            List<Producto> lista = new List<Producto>();
            datos.setearQuery(" Select p.Id, p.IdTipo, p.Precio, p.Nombre, p.IdTalle, p.Descripcion, p.IdColor, p.UrlImagen, p.Estado, p.StockMinimo, p.StockActual, tp.Id as IdTipo, tp.Nombre as TipoNombre,c.Id as IdClr , c.Nombre as NombreColor,t.Id as IdTa , t.Nombre as NombreTalle " +
                "from Producto as p " +
                "join TipoProducto as tp on p.IdTipo = tp.Id " +
                "join Talles as t on t.Id = p.IdTalle " +
                "join Color as c on c.Id = p.IdColor ");
            try
            {
                datos.ejecutarLector();
                datos.lector = datos.comando.ExecuteReader();

                while (datos.lector.Read())
                {


                    Producto aux;
                    aux = new Producto();// es como darle un espacio de memoria al nacer.
                                         // aux.id es la parte del setter xq le etoy asignando un valor si el codigo estuviera al reves seria un getter 
                    aux.Id = (long)datos.lector["Id"];
                    aux.IdTipo = (Byte)datos.lector["IdTipo"];
                    aux.Nombre = (string)datos.lector["Nombre"];
                    aux.Precio = datos.lector.GetDecimal(2);
                    aux.IdTalle = (Byte)datos.lector["IdTalle"];
                    aux.Descripcion = datos.lector.GetString(5);
                    aux.IdColor = (Byte)datos.lector["IdColor"];
                    aux.UrlImagen = (string)datos.lector["UrlImagen"];
                    aux.Estado = datos.lector.GetBoolean(8);
                    aux.StockActual = (int)datos.lector["StockActual"];
                    aux.StockMinimo = (int)datos.lector["StockMinimo"];

                    aux.tipoProducto = new TipoProducto(); // no olvidar esto
                    aux.tipoProducto.Id = (byte)datos.lector["IdTipo"];
                    aux.tipoProducto.Nombre = (string)datos.lector["TipoNombre"];

                    aux.color = new Color();
                    aux.color.Id = (byte)datos.lector["IdClr"];
                    aux.color.Nombre = (string)datos.lector["NombreColor"];

                    aux.talle = new Talle();
                    aux.talle.Id = (byte)datos.lector["IdTa"];
                    aux.talle.Nombre = (string)datos.lector["NombreTalle"];


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

        public void Agregar(Producto nuevo) // es hacer un insert into en la DB 
        {
            AccesoDatos datos = new AccesoDatos();
            //List<Producto> lista = new List<Producto>();

            datos.setearQuery_ConPa("sp_InsertarRegistro"); //LO CAMBIE 19/01 
            //datos.setearQuery("insert into Producto (/*Id,*/ IdTipo, Precio,  Nombre, Talle, Descripcion, Color, UrlImagen, Estado, StockMinimo, StockActual) values(/*@Id,*/ @IdTipo, @Precio, @Nombre, @Talle, @Descripcion, @Color, @UrlImagen, @Estado, @StockMinimo, @StockActual)");
            // datos.agregarParametro("@Id",nuevo.Id);
            datos.agregarParametro("@IdTipo", nuevo.IdTipo);
            datos.agregarParametro("@Precio", nuevo.Precio);
            datos.agregarParametro("@Nombre", nuevo.Nombre);
            datos.agregarParametro("@IdTalle", nuevo.IdTalle);
            datos.agregarParametro("@Descripcion", nuevo.Descripcion);
            datos.agregarParametro("@IdColor", nuevo.IdColor);
            datos.agregarParametro("@UrlImagen", nuevo.UrlImagen);
            //datos.agregarParametro("@Estado", nuevo.Estado);
            datos.agregarParametro("@StockMinimo", nuevo.StockMinimo);
            datos.agregarParametro("@StockActual", nuevo.StockActual);
            //datos.agregarParametro("@TipoNombre", nuevo.tipoProducto.Nombre);

            //datos.conexion.Open();
            //datos.comando.ExecuteNonQuery();

            datos.ejecutarAccion();

        }
        public void Modificar(Producto produ)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearQuery("Update Producto set Precio = @Precio, IdTipo = @IdTipo, Nombre = @Nombre, IdTalle = @Talle, Descripcion = @Descripcion, IdColor = @Color, UrlImagen = @UrlImagen, StockMinimo = @StockMinimo, StockActual = @StockActual where Id = @Id");


                datos.agregarParametro("@Id", produ.Id);
                datos.agregarParametro("@IdTipo", produ.IdTipo);
                datos.agregarParametro("@Precio", produ.Precio);
                datos.agregarParametro("@Nombre", produ.Nombre);
                datos.agregarParametro("@Talle", produ.IdTalle);
                datos.agregarParametro("@Descripcion", produ.Descripcion);
                datos.agregarParametro("@Color", produ.IdColor);
                datos.agregarParametro("@UrlImagen", produ.UrlImagen);
                //datos.agregarParametro("@Estado", produ.Estado);
                datos.agregarParametro("@StockMinimo", produ.StockMinimo);
                datos.agregarParametro("@StockActual", produ.StockActual);


                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void DarBajaLogicaProducto(Producto producto)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearQuery("Update Producto set Estado = 0  where Id = @Id");

                // esto no entendiendo porque va???
                datos.agregarParametro("@Id", producto.Id);


                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Producto BuscarPorId(int Id)
        {
            AccesoDatos datos = new AccesoDatos();
            // List<Producto> lista = new List<Producto>();
            try
            {
                //YA LE AGREGUE IDCOLOR Y IDTALLE
                datos.setearQuery("  Select p.Id, p.IdTipo, p.Precio, p.Nombre, p.IdTalle, p.Descripcion, p.IdColor, p.UrlImagen, p.Estado, p.StockMinimo, p.StockActual, tp.Id as IdTipo, tp.Nombre as TipoNombre,c.Id as IdClr,  c.Nombre as NombreColor,t.Id as IdTa, t.Nombre as NombreTalle from Producto as p join TipoProducto as tp on p.IdTipo = tp.Id join Talles as t on t.Id = p.IdTalle join Color as c on c.Id = p.IdColor where p.id =@Id");
                datos.agregarParametro("@Id", Id);


                datos.ejecutarLector();
                datos.lector = datos.comando.ExecuteReader();

                Producto aux = new Producto();
                while (datos.lector.Read())
                {
                    //Producto aux;
                    aux = new Producto();
                    aux.Id = (long)datos.lector["Id"];
                    aux.IdTipo = (Byte)datos.lector["IdTipo"];
                    aux.Nombre = (string)datos.lector["Nombre"];
                    aux.Precio = datos.lector.GetDecimal(2);
                    aux.IdTalle = (byte)datos.lector["IdTalle"];
                    aux.Descripcion = datos.lector.GetString(5);
                    aux.IdColor = (byte)datos.lector["IdColor"];
                    aux.UrlImagen = datos.lector.GetString(7);
                    aux.Estado = datos.lector.GetBoolean(8);
                    aux.StockActual = (int)datos.lector["StockActual"];
                    aux.StockMinimo = (int)datos.lector["StockMinimo"];

                    aux.tipoProducto = new TipoProducto();
                    aux.tipoProducto.Id = (byte)datos.lector["IdTipo"];
                    aux.tipoProducto.Nombre = (string)datos.lector["TipoNombre"];

                    aux.color = new Color();
                    aux.color.Id = (byte)datos.lector["IdClr"];
                    aux.color.Nombre = (string)datos.lector["NombreColor"];

                    aux.talle = new Talle();
                    aux.talle.Id = (byte)datos.lector["IdTa"];
                    aux.talle.Nombre = (string)datos.lector["NombreTalle"];

                    //lista.Add(aux);
                    // return aux;
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
        public List<Producto> BuscarPorPalabra(string Busqueda)
        {
            AccesoDatos datos = new AccesoDatos();
            List<Producto> listaBuscado = new List<Producto>();

            try
            {
                //Producto aux = new Producto();
                datos.setearQuery("SELECT p.Id,p.Nombre,p.Precio, p.IdTalle, p.Descripcion, p.IdColor,p.Estado, p.StockActual, p.StockMinimo  FROM Producto as p  " +
                    "WHERE p.Nombre LIKE '%' + @Busqueda + '%'" +
                    "or p.Precio LIKE '%' + @Busqueda + '%'" +
                    "or p.IdTalle LIKE '%' + @Busqueda + '%'" +
                    "or p.Descripcion LIKE '%' + @Busqueda + '%'" +
                    "or p.IdColor LIKE '%' + @Busqueda + '%'" +
                    "or p.StockActual LIKE '%' + @Busqueda + '%'" +
                    "or p.StockMinimo LIKE '%' + @Busqueda + '%'  ");

                //if (Busqueda != null)
                //    datos.agregarParametro("@Busqueda", Busqueda);
                //else
                //    datos.agregarParametro("@Busqueda", DBNull.Value);

                datos.ejecutarLector();
                datos.lector = datos.comando.ExecuteReader();

                while (datos.lector.Read())
                {
                    Producto aux;
                    aux = new Producto();
                    aux.Id = (long)datos.lector["Id"];
                    //aux.IdTipo = (Byte)datos.lector["IdTipo"];
                    aux.Nombre = (string)datos.lector["Nombre"];
                    //aux.Precio = datos.lector.GetDecimal(2);
                    aux.Precio = (decimal)datos.lector["Precio"];
                    aux.IdTalle = (byte)datos.lector["IdTalle"];
                    aux.Descripcion = (string)datos.lector["Descripcion"];
                    //aux.Descripcion = datos.lector.GetString(5);
                    aux.IdColor = (byte)datos.lector["IdColor"];
                    //aux.UrlImagen = datos.lector.GetString(7);
                    //aux.UrlImagen = (string)datos.lector["UrlImagen"];
                    //aux.Estado = datos.lector.GetBoolean(8);
                    aux.Estado = (bool)datos.lector["Estado"];
                    aux.StockActual = (int)datos.lector["StockActual"];
                    aux.StockMinimo = (int)datos.lector["StockMinimo"];

                    //aux.tipoProducto = new TipoProducto();
                    //aux.tipoProducto.Id = (byte)datos.lector["IdTipo"];
                    //aux.tipoProducto.Nombre = (string)datos.lector["TipoNombre"];

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

        public List<Producto> Buscador(string Busqueda, int? Color, int? Talle, int? Tipo) // pueden ser nuleables
        {
            AccesoDatos datos = new AccesoDatos();
            List<Producto> listaBuscado = new List<Producto>();

            try
            {
                //Producto aux = new Producto();
                datos.setearQuery_ConPa("SP_Busqueda");

                //datos.agregarParametro("@Busqueda", Busqueda);
                //datos.agregarParametro("@Color", Color);
                //datos.agregarParametro("@Talle", Talle);
                //datos.agregarParametro("@Tipo", Tipo);

                if (!string.IsNullOrEmpty (Busqueda) ) // para decir si es nulo
                    datos.agregarParametro("@Busqueda", Busqueda);
                else
                    datos.agregarParametro("@Busqueda", DBNull.Value); // pasa un null q el sql lo puede interpretar

                if (Color != null)
                    datos.agregarParametro("@Color", Color);
                else
                    datos.agregarParametro("@Color", DBNull.Value);

                if (Talle != null)
                    datos.agregarParametro("@Talle", Talle);
                else
                    datos.agregarParametro("@Talle", DBNull.Value);

                if (Tipo != null)
                    datos.agregarParametro("@Tipo", Tipo);
                else
                    datos.agregarParametro("@Tipo", DBNull.Value);

                datos.ejecutarLector();
                datos.lector = datos.comando.ExecuteReader();

                while (datos.lector.Read())
                {
                    Producto aux;
                    aux = new Producto();
                    aux.Id = (long)datos.lector["Id"];
                    //aux.IdTipo = (Byte)datos.lector["IdTipo"];
                    aux.Nombre = (string)datos.lector["Nombre"];
                    //aux.Precio = datos.lector.GetDecimal(2);
                    aux.Precio = (decimal)datos.lector["Precio"];
                    aux.IdTalle = (byte)datos.lector["IdTalle"];
                    aux.Descripcion = (string)datos.lector["Descripcion"];
                    //aux.Descripcion = datos.lector.GetString(5);
                    aux.IdColor = (byte)datos.lector["IdColor"];
                    //aux.UrlImagen = datos.lector.GetString(7);
                    aux.UrlImagen = (string)datos.lector["UrlImagen"];
                    //aux.Estado = datos.lector.GetBoolean(8);
                    aux.Estado = (bool)datos.lector["Estado"];
                    aux.StockActual = (int)datos.lector["StockActual"];
                    aux.StockMinimo = (int)datos.lector["StockMinimo"];

                    //aux.tipoProducto = new TipoProducto();
                    //aux.tipoProducto.Id = (byte)datos.lector["IdTipo"];
                    //aux.tipoProducto.Nombre = (string)datos.lector["TipoNombre"];

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


        public List<Producto> BuscadorDeInt(int Busqueda)
        {
            AccesoDatos datos = new AccesoDatos();
            List<Producto> listaBuscado = new List<Producto>();

            try
            {
                //Producto aux = new Producto();
                datos.setearQuery("select p.*, c.Id as IdColores, c.Nombre as NombreColores, t.Id as TalleId, t.Nombre as NombreTalle from Producto p join Color as c on c.id = p.IdColor join Talles as t on t.Id = p.IdTalle where IdColor = @Busqueda");
                //select p.*, c.Id as IdColores, c.Nombre as NombreColores from Producto p join Color as c on c.id = p.IdColor where IdColor = @Busqueda

                datos.agregarParametro("@Busqueda", Busqueda);



                datos.ejecutarLector();
                datos.lector = datos.comando.ExecuteReader();

                while (datos.lector.Read())
                {
                    Producto aux;
                    aux = new Producto();


                    aux = new Producto();
                    aux.Id = (long)datos.lector["Id"];
                    //aux.IdTipo = (Byte)datos.lector["IdTipo"];
                    aux.Nombre = (string)datos.lector["Nombre"];
                    //aux.Precio = datos.lector.GetDecimal(2);
                    aux.Precio = (decimal)datos.lector["Precio"];
                    aux.IdTalle = (byte)datos.lector["IdTalle"];
                    aux.Descripcion = (string)datos.lector["Descripcion"];
                    //aux.Descripcion = datos.lector.GetString(5);
                    aux.IdColor = (byte)datos.lector["IdColor"];
                    //aux.UrlImagen = datos.lector.GetString(7);
                    //aux.UrlImagen = (string)datos.lector["UrlImagen"];
                    //aux.Estado = datos.lector.GetBoolean(8);
                    aux.Estado = (bool)datos.lector["Estado"];
                    aux.StockActual = (int)datos.lector["StockActual"];
                    aux.StockMinimo = (int)datos.lector["StockMinimo"];


                    aux.color = new Color();
                    aux.color.Id = (byte)datos.lector["IdColores"];
                    aux.color.Nombre = (string)datos.lector["NombreColores"];

                    aux.talle = new Talle();
                    aux.talle.Id = (byte)datos.lector["TalleId"];
                    aux.talle.Nombre = (string)datos.lector["NombreTalle"];



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



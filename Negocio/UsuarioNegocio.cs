using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using System.Data.SqlClient;

namespace Negocio
{
    public class UsuarioNegocio
    {
        public List<Usuario> Listar()
        {
            AccesoDatos datos = new AccesoDatos();// aca adentro hay magia, estan lector, conexion y comando
            List<Usuario> lista = new List<Usuario>();
            datos.setearQuery("select u.Id, u.NombreUsuario, u.Contraseña, u.IdTipoUsuario, u.Estado, dp.Nombre, dp.Apellido, dp.DNI, dp.FechaNac, dp.Genero, dp.Telefono, dp.CP, dp.Direccion, dp.Ciudad, dp.Email, tp.Nombre as TipoNombre, tp.Id as IdTipo from Usuarios as u  join DatosPersonales as dp on u.Id = dp.IdUsuario  join TipoUsuario as tp on u.IdTipoUsuario = tp.Id");
               // "select u.Id, u.NombreUsuario, u.Contraseña, u.IdTipoUsuario, u.Estado, dp.Nombre, dp.Apellido, dp.DNI, dp.FechaNac, dp.Genero, dp.Telefono, dp.CP, dp.Direccion, dp.Ciudad, dp.Email from Usuarios as u join DatosPersonales as dp on u.Id = dp.IdUsuario ");
            
            
            try
            {
                datos.ejecutarLector();
                datos.lector = datos.comando.ExecuteReader();

                while (datos.lector.Read())
                {
                    Usuario aux;
                    aux = new Usuario();

                    aux.Id = (long)datos.lector["Id"];
                    aux.NombreUsuario = (string)datos.lector["NombreUsuario"];
                    aux.Contrasenia = (string)datos.lector["Contraseña"];
                    aux.IdTipoUsiario = (Byte)datos.lector["IdTipoUsuario"];
                    aux.Estado = datos.lector.GetSqlBoolean(4);
                    aux.Nombre = (string)datos.lector["Nombre"];
                    aux.Apellido = (string)datos.lector["Apellido"];
                    aux.DNI = (string)datos.lector["DNI"];
                    aux.FechaNac = (DateTime)datos.lector["FechaNac"];
                    aux.Genero = (string)datos.lector["Genero"];
                    aux.Telefono = (string)datos.lector["Telefono"];
                    aux.CP = (int)datos.lector["CP"];
                    aux.Direccion = (string)datos.lector["Direccion"];
                    aux.Ciudad = (string)datos.lector["Ciudad"];
                    aux.Email = (string)datos.lector["Email"];


                    aux.tipoUsuario = new TipoUsuario(); // no olvidar esto
                    aux.tipoUsuario.Id = (byte)datos.lector["IdTipo"];
                    aux.tipoUsuario.Nombre = (string)datos.lector["TipoNombre"];

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

        public void AgregarUsuario(Usuario nuevo) // es hacer un insert into en la DB 
        {
            AccesoDatos datos = new AccesoDatos();
            //List<Producto> lista = new List<Producto>();

            datos.setearQuery_ConPa("spAgregarCliente");

            // datos.agregarParametro("@Id",nuevo.Id);
            datos.agregarParametro("@NombreUsuario", nuevo.NombreUsuario);
            datos.agregarParametro("@Contraseña", nuevo.Contrasenia);
            datos.agregarParametro("@IdTipoUsuario", nuevo.IdTipoUsiario);
            datos.agregarParametro("@Nombre", nuevo.Nombre);
            datos.agregarParametro("@Apellido", nuevo.Apellido);
            datos.agregarParametro("@DNI", nuevo.DNI);
            datos.agregarParametro("@FechaNac", nuevo.FechaNac);
            datos.agregarParametro("@Genero", nuevo.Genero);
            datos.agregarParametro("@Telefono", nuevo.Telefono);
            datos.agregarParametro("@CP", nuevo.CP);
            datos.agregarParametro("@Direccion", nuevo.Direccion);
            datos.agregarParametro("@Ciudad", nuevo.Ciudad);
            datos.agregarParametro("@Email", nuevo.Email);

  



            datos.conexion.Open();
            datos.comando.ExecuteNonQuery();

        }
        public void AgregarCliente(Usuario nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            //List<Producto> lista = new List<Producto>();

            datos.setearQuery_ConPa("spAgregarCliente");

            // datos.agregarParametro("@Id",nuevo.Id);
            datos.agregarParametro("@NombreUsuario", nuevo.NombreUsuario);
            datos.agregarParametro("@Contraseña", nuevo.Contrasenia);
            datos.agregarParametro("@IdTipoUsuario", 2);
            datos.agregarParametro("@Nombre", nuevo.Nombre);
            datos.agregarParametro("@Apellido", nuevo.Apellido);
            datos.agregarParametro("@DNI", nuevo.DNI);
            datos.agregarParametro("@FechaNac", nuevo.FechaNac);
            datos.agregarParametro("@Genero", nuevo.Genero);
            datos.agregarParametro("@Telefono", nuevo.Telefono);
            datos.agregarParametro("@CP", nuevo.CP);
            datos.agregarParametro("@Direccion", nuevo.Direccion);
            datos.agregarParametro("@Ciudad", nuevo.Ciudad);
            datos.agregarParametro("@Email", nuevo.Email);





            datos.conexion.Open();
            datos.comando.ExecuteNonQuery();

        }


        public void ModificarUsuario(Usuario nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearQuery_ConPa("SP_ModificarUsuario");

                datos.agregarParametro("@Id", nuevo.Id);
                datos.agregarParametro("@NombreUsuario", nuevo.NombreUsuario);
                datos.agregarParametro("@Contraseña", nuevo.Contrasenia);
                datos.agregarParametro("@IdTipoUsuario", nuevo.IdTipoUsiario);
                datos.agregarParametro("@Nombre", nuevo.Nombre);
                datos.agregarParametro("@Apellido", nuevo.Apellido);
                datos.agregarParametro("@DNI", nuevo.DNI);
                datos.agregarParametro("@FechaNac", nuevo.FechaNac);
                datos.agregarParametro("@Genero", nuevo.Genero);
                datos.agregarParametro("@Telefono", nuevo.Telefono);
                datos.agregarParametro("@CP", nuevo.CP);
                datos.agregarParametro("@Direccion", nuevo.Direccion);
                datos.agregarParametro("@Ciudad", nuevo.Ciudad);
                datos.agregarParametro("@Email", nuevo.Email);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void ModificarCliente(Usuario nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearQuery_ConPa("SP_ModificarUsuario");

                datos.agregarParametro("@Id", nuevo.Id);
                datos.agregarParametro("@NombreUsuario", nuevo.NombreUsuario);
                datos.agregarParametro("@Contraseña", nuevo.Contrasenia);
                datos.agregarParametro("@IdTipoUsuario", 2);
                datos.agregarParametro("@Nombre", nuevo.Nombre);
                datos.agregarParametro("@Apellido", nuevo.Apellido);
                datos.agregarParametro("@DNI", nuevo.DNI);
                datos.agregarParametro("@FechaNac", nuevo.FechaNac);
                datos.agregarParametro("@Genero", nuevo.Genero);
                datos.agregarParametro("@Telefono", nuevo.Telefono);
                datos.agregarParametro("@CP", nuevo.CP);
                datos.agregarParametro("@Direccion", nuevo.Direccion);
                datos.agregarParametro("@Ciudad", nuevo.Ciudad);
                datos.agregarParametro("@Email", nuevo.Email);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void DarBajaLogicaUsuario(Usuario usuario)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                //aca quizá esta faltando incluir en el update a Datos personales?
                datos.setearQuery("Update Usuarios set Estado = 0  where Id = @Id");


                datos.agregarParametro("@Id", usuario.Id);


                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        public Usuario BuscarPorIdUsuario(int Id)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearQuery("select u.Id, u.NombreUsuario, u.Contraseña, u.IdTipoUsuario, u.Estado, dp.Nombre, dp.Apellido, dp.DNI, dp.FechaNac, dp.Genero, dp.Telefono, dp.CP, dp.Direccion, dp.Ciudad, dp.Email from Usuarios as u join DatosPersonales as dp on u.Id = dp.IdUsuario where Id =@Id");
                datos.agregarParametro("@Id", Id);


                datos.ejecutarLector();
                datos.lector = datos.comando.ExecuteReader();

                Usuario aux = new Usuario();
                while (datos.lector.Read())
                {
                    //Producto aux;
                    aux.Id = (long)datos.lector["Id"];
                    aux.NombreUsuario = (string)datos.lector["NombreUsuario"];
                    aux.Contrasenia = (string)datos.lector["Contraseña"];
                    aux.IdTipoUsiario = (Byte)datos.lector["IdTipoUsuario"];
                    aux.Estado = datos.lector.GetSqlBoolean(4);
                    aux.Nombre = (string)datos.lector["Nombre"];
                    aux.Apellido = (string)datos.lector["Apellido"];
                    aux.DNI = (string)datos.lector["DNI"];
                    aux.FechaNac = (DateTime)datos.lector["FechaNac"];
                    aux.Genero = (string)datos.lector["Genero"];
                    aux.Telefono = (string)datos.lector["Telefono"];
                    aux.CP = (int)datos.lector["CP"];
                    aux.Direccion = (string)datos.lector["Direccion"];
                    aux.Ciudad = (string)datos.lector["Ciudad"];
                    aux.Email = (string)datos.lector["Email"];
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
        public Usuario InicioSesion(Usuario usuario)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearQuery("select * from Usuarios u join DatosPersonales dp on u.Id = dp.IdUsuario where NombreUsuario = @NombreUsuario and  Contraseña = @Contrasenia");
                datos.agregarParametro("@NombreUsuario", usuario.NombreUsuario);
                datos.agregarParametro("@Contrasenia", usuario.Contrasenia);


                datos.ejecutarLector();

                datos.lector = datos.comando.ExecuteReader();

                Usuario aux = new Usuario();
                while (datos.lector.Read())
                {
                    //Producto aux;
                    aux.Id = (long)datos.lector["Id"];
                    aux.NombreUsuario = (string)datos.lector["NombreUsuario"];
                    aux.Contrasenia = (string)datos.lector["Contraseña"];
                    aux.IdTipoUsiario = (Byte)datos.lector["IdTipoUsuario"];
                    aux.Estado = datos.lector.GetSqlBoolean(4);
                    aux.Nombre = (string)datos.lector["Nombre"];
                    aux.Apellido = (string)datos.lector["Apellido"];
                    aux.DNI = (string)datos.lector["DNI"];
                    aux.FechaNac = (DateTime)datos.lector["FechaNac"];
                    aux.Genero = (string)datos.lector["Genero"];
                    aux.Telefono = (string)datos.lector["Telefono"];
                    aux.CP = (int)datos.lector["CP"];
                    aux.Direccion = (string)datos.lector["Direccion"];
                    aux.Ciudad = (string)datos.lector["Ciudad"];
                    aux.Email = (string)datos.lector["Email"];
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
    }

}



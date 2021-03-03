using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dominio;
using Negocio;

namespace MVC_Ecommerce.Controllers
{
    
    public class HomeController : Controller
    {
        ProductoNegocio negocio;

        public HomeController()
        {
            negocio = new ProductoNegocio();
        }

        public ActionResult Index()
        {
            return RedirectToAction("Catalogo");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            TipoProdNegocio negocio = new TipoProdNegocio();
            List<TipoProducto> TipoRemera;
            TipoRemera = negocio.Listar();
            ViewBag.tipoRemera = TipoRemera;

            return View();
        }
        [HttpPost]
        public ActionResult Contact(FormCollection form)
        {

            // List<TipoProducto> TipoRemera;
            string tipo;
           tipo  = form["tiporemera"];

           
            
            return RedirectToAction("Contact");
        }

        public ActionResult Catalogo(string busqueda, int? Colores, int? Talles, int? Tipo) // ? es para que pueda tener valor nulo (recibir o no el valor, es lo mismo que ponet aux=0)
        {
            //COLORES, BUSQUEDA, TALLES y TIPO son el name del dropdown, y es lo que paso por parametro
            //primero se carga la pagina y  son nulos, luego por el form y por el metodo get yo paso el name ya con los valores cargados
            // y al action ya no llegan nulos. 
            // no se puede pasar el view.bag de action a action. por eso directamente hago esto con el method get

            ColorNegocio colorNegocio = new ColorNegocio();
            List<Color> ColorRemera;
            ColorRemera = colorNegocio.Listar();
            ViewBag.ColorRemera = ColorRemera;

            TalleNegocio talleNegocio = new TalleNegocio();
            List<Talle> TalleRemera;
            TalleRemera = talleNegocio.Listar();
            ViewBag.TalleRemera = TalleRemera;

            TipoProdNegocio tipoProdNegocio = new TipoProdNegocio();
            List<TipoProducto> TipoRemera;
            TipoRemera = tipoProdNegocio.Listar();
            ViewBag.TipoRemera = TipoRemera;

            List<Producto> listaBuscado;
           
            // este ?int es un int nuleable y este int es el comun son tipos de datos diferentes.
            
                listaBuscado = negocio.Buscador(busqueda, Colores, Talles, Tipo); // en la declaracion que esta en el Negocio, tambien tiene ?

                ViewBag.ListaDeProductos = listaBuscado;
            
           

                //List<Producto> listita;

                //listita = negocio.Listar();
                //ViewBag.ListaDeProductos = listita;
            

            //if (!string.IsNullOrEmpty(busqueda))// si el string no esta vacio entra
            //{
            //    listaBuscado = negocio.BuscarPorPalabra(busqueda);
            //    ViewBag.ListaDeProductos = listaBuscado;
            //}
            //else
            //{

            //    List<Producto> listita;

            //    listita = negocio.Listar();
            //ViewBag.ListaDeProductos = listita;
            //}

            //if (Colores.HasValue) // si tiene valor, osea no es nulo
            //{
            //    listaBuscado = negocio.BuscadorDeInt(Colores.Value); // porque int? es nuleable y entonces los toma como valores diferentes a los int. 
            //    ViewBag.ListaDeProductos = listaBuscado;
            //}
            //if (Talles.HasValue) // si tiene valor, osea no es nulo
            //{
            //    listaBuscado = negocio.BuscadorDeInt(Talles.Value); // porque int? es nuleable y entonces los toma como valores diferentes a los int. 
            //    ViewBag.ListaDeProductos = listaBuscado;
            //}
            //if (Tipos.HasValue) // si tiene valor, osea no es nulo
            //{
            //    listaBuscado = negocio.BuscadorDeInt(Tipos.Value); // porque int? es nuleable y entonces los toma como valores diferentes a los int. 
            //    ViewBag.ListaDeProductos = listaBuscado;
            //}
            return View();

        }

       [HttpGet]
        public ActionResult Login()
        {
            //ViewBag.lisita = listita;
            return View();
        }
        [HttpPost]
        public ActionResult Login(FormCollection form)
        {
            Usuario usuario = new Usuario();
            UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
           usuario.NombreUsuario = form["nombreUsuario"];
            usuario.Contrasenia = form["contrasenia"];
            
            usuario = usuarioNegocio.InicioSesion(usuario);

            if (usuario.Id != 0 && Session["listaCarrito"] != null)
            {
                Session["user"] = usuario;
                Session["TipoUsuario"] = usuario.IdTipoUsiario;
                return RedirectToAction("Carrito");
            }
            else if (usuario.Id != 0 && Session["listaCarrito"] == null)
            {
                Session["user"] = usuario;
                Session["TipoUsuario"] = usuario.IdTipoUsiario;
                return RedirectToAction("Catalogo");
            }
            else
                return RedirectToAction("Login");

        }

        public ActionResult Logout()
        {
            Session["user"] = null;
           // List<DetalleCarrito> detalleCarrito = (List<DetalleCarrito>)Session["detalleCarrito"];
            Session["detalleCarrito"] = null;
            //List<ItemCarrito> listaCarrito = (List<ItemCarrito>)Session["listaCarrito"];
            Session["listaCarrito"] = null;

            Session["TipoUsuario"] = null;

            return RedirectToAction("Catalogo", "Home");
        }
       


        public ActionResult Detalle(int idAux)
        {
           // Producto detalle;
            List<Producto> listita;
            listita = negocio.Listar();
            ViewBag.Detalle = listita.Find(x => x.Id == idAux);
            //ViewBag.Detalle = detalle;
            return View();
        }
        public ActionResult Compra()
        {
            if (Session["TipoUsuario"] == null)
                return RedirectToAction("Login");


            List<ItemCarrito> listaCarrito;
            listaCarrito = (List<ItemCarrito>)Session["listaCarrito"];
            
            DetalleCarritoNegocio detalle = new DetalleCarritoNegocio();
            

           List<DetalleCarrito> detalleCarrito = detalle.Asignar(listaCarrito);
            
            Session["detalleCarrito"] = detalleCarrito;//me guardo lo que tengo en detalle que es TODO MENOS EL ID PEDIDO
            
            ViewBag.DetalleCarrito = detalleCarrito;
            decimal acu = 0;
            decimal importe = 0;
            foreach (var item in detalleCarrito)
            {
                acu += item.PrecioActual;
                
                
            }
           
            acu = (decimal) Session["importe"];
            ViewBag.Acu = acu;
            return View();

            //PONER LOS DATOS DE LA PERSONA PARA CONFIRMAR LA COMPRA
        }

        public  ActionResult DatosPago()
        {

           

            TipoPago tipoPago = new TipoPago();
            TipoPagoNegocio tipoPagoNegocio = new TipoPagoNegocio();
            List<TipoPago> ListaPagos;
            ListaPagos = tipoPagoNegocio.Listar();

            ViewBag.listaPagos = ListaPagos;
         
            return View();
        }
        [HttpPost]
        public ActionResult DatosPago(byte formaDePago)
        {
            //tarjeta 1, transferencia 2, mercado pago
            // yo me tengo que guardar la tarjeta que termina eligiendo

         


            Session["formaDePago"] = formaDePago;
            
            if(formaDePago == 1)
            {
                
                
                return RedirectToAction("DatosTarjeta");
            }
            else if (formaDePago == 2)
            {
               
                return RedirectToAction("DatosBanco");
            }
            else
            {
               
                return RedirectToAction("ConfirmacionCompra");

            }

        }
        public ActionResult DatosBanco()
        {

          

            List<Combo> tipoTarjeta = new List<Combo>();
            tipoTarjeta.Add(new Combo { Id = 1, Nombre = "Santender" });
            tipoTarjeta.Add(new Combo { Id = 2, Nombre = "Galicia" });
            tipoTarjeta.Add(new Combo { Id = 3, Nombre = "Banco Nación" });
            tipoTarjeta.Add(new Combo { Id = 4, Nombre = "American Express" });
            //tipoTarjeta.Add(new Combo { Id = 2, Nombre = "" });
            ViewBag.tiposDeTarjetas = tipoTarjeta;

            return View();
        }
        [HttpPost]
        public ActionResult DatosBanco(string nombreTarjeta)
        {

         

            Pedido pedido = new Pedido();

            Session["nombreTarjeta"] = nombreTarjeta;
           
            
           return RedirectToAction("ConfirmacionCompra");
        }
        public ActionResult DatosTarjeta()
        {
          

            List<Combo> creditoDebito = new List<Combo>();
            creditoDebito.Add(new Combo { Id = 1, Nombre = "Credito" });
            creditoDebito.Add(new Combo { Id = 2, Nombre = "Debito" });

            ViewBag.tipoTarjeta = creditoDebito;
            return View();
        }
        [HttpPost]
        public ActionResult DatosTarjeta(string dato)
        {

         

            Session["debitoOcredito"] = dato;
                //return RedirectToAction("DatosBanco");
                           
            return RedirectToAction("ConfirmacionCompra");
        }

        public ActionResult ConfirmacionDatos()
        {

          
            Usuario user = new Usuario();

            user = (Usuario)Session["user"];

           

            return View(user);
        }
        [HttpPost]
        public ActionResult ConfirmacionDatos(Usuario user)
        {

            

            UsuarioNegocio usuarioNegocio = new UsuarioNegocio();

            //if (user.Id > 0)
                usuarioNegocio.ModificarCliente(user);
            //else
            //    usuarioNegocio.AgregarCliente(user);

            return RedirectToAction("DatosPago");

        }

        public ActionResult ConfirmacionCompra ()
        {

           
            string nombreTarjeta = Convert.ToString(Session["nombreTarjeta"]);


       
            byte formadePago = (byte) Session["formaDePago"];
            ViewBag.formadePago = formadePago;
            string debitoOcredito = Convert.ToString( Session["debitoOcredito"]);
          
            Usuario user = new Usuario();
            
            user = (Usuario)Session["user"];
            decimal importe = (decimal)Session["importe"];
           
            List < DetalleCarrito > detalleCarrito = (List<DetalleCarrito>)Session["detalleCarrito"];

           
            PedidoNegocio pedidoNegocio = new PedidoNegocio();
            Pedido pedido = new Pedido();
            pedido.tipoPago = new TipoPago();
       
            pedido.IdUsuario = user.Id;
            pedido.Importe = importe;
            pedido.IdEstado = 1;
            pedido.IdTipoPago = formadePago;

            if (Session["debitoOcredito"] != null)
                pedido.tipoPago.Nombre = debitoOcredito;
            else if (Session["nombreTarjeta"] != null)
                pedido.tipoPago.Nombre = nombreTarjeta;
           






           pedidoNegocio.Agregar(pedido);

            DetalleCarrito detalledelCarrito = new DetalleCarrito();

            
          
             DetalleCarritoNegocio detalleNegocio = new DetalleCarritoNegocio();
           
           long valorDevuelto = pedidoNegocio.InsertarDetalle();

            detalledelCarrito.IdPedido = valorDevuelto;

            detalleNegocio.PasarDeLista_a_detalle(detalleCarrito,valorDevuelto);

            
            return View();
        }
        public ActionResult DetallePedido(long idPedido = 0)
        {

          

            EstadoNegocio estadoNegocio = new EstadoNegocio();
            List<Estado> estado;
            estado = estadoNegocio.Listar();
            ViewBag.Estado = estado;

            DetalleCarritoNegocio detalleCarritoNegocio = new DetalleCarritoNegocio();

            DetalleCarrito detalleCarrito;
            List<DetalleCarrito> listaDetalle;
            Pedido pedido;
            PedidoNegocio pedidoNegocio = new PedidoNegocio();
            pedido = pedidoNegocio.BuscarPorId(idPedido);

            listaDetalle =  detalleCarritoNegocio.BuscadorDeLong(idPedido);


            pedido.listaDetalle = listaDetalle;



            Usuario usuario;
            usuario = (Usuario)Session["user"];

            
            ViewBag.usuario = usuario;

            return View(pedido); // estoy mandando el model (el objeto a la vista)
        }
        [HttpPost]
        public ActionResult DetallePedido(Pedido pedido)
        {
            

            PedidoNegocio pedidoNegocio = new PedidoNegocio ();
            
            pedidoNegocio.CambiarEstado(pedido);
            //Session["pedido"] = pedido;
            
            
            return RedirectToAction("PedidosListar");
        }


        public ActionResult PedidosListar ()
        {

            List<Pedido> listaPedidos;
            PedidoNegocio pedidoNegocio = new PedidoNegocio();
            if(Session["user"]== null)
            {
                return RedirectToAction("Login");
            }
            
            else if (Session["TipoUsuario"] as byte? != 1)
            {
               Usuario user;
                user = (Usuario)Session["user"];
                ViewBag.user = user;
                listaPedidos =  pedidoNegocio.ListarPorUser(user.Id);
            }
               else
            {
                Usuario user;
                user = (Usuario)Session["user"];
                ViewBag.user = user;
                listaPedidos = pedidoNegocio.Listar();
            }
            ViewBag.ListaDePedidos = listaPedidos;
          
                //return RedirectToAction("Login");

            return View(); 
        }

        public ActionResult Carrito()
        {
          
            List<ItemCarrito> listaCarrito;


             if (Session["listaCarrito"] == null) //para que no se pinche cuando no tiene nada
                listaCarrito = new List<ItemCarrito>();
            else
            listaCarrito = (List<ItemCarrito>)Session["listaCarrito"]; // para que traiga lo que hay
            

            ViewBag.ListaCarrito = listaCarrito;
            
            decimal acumlador = 0;
          
            foreach (var itemFor in listaCarrito)
            {
                acumlador += itemFor.PrecioFinal;
              
                           
            }
            ViewBag.Acumulador = acumlador;
            Session["importe"] = acumlador;


            return View();
        }

      
      public ActionResult Agregar (int IdAux) // aca viene por medio del href, con el id para agregar al carrito
        {
           
            ItemCarrito item;

            Producto producto;

            List<ItemCarrito> listaCarrito;
           producto= negocio.BuscarPorId(IdAux);

           

            DetalleCarritoNegocio negocioCarrito = new DetalleCarritoNegocio();
            item = negocioCarrito.Map(producto);


           

            if (Session["listaCarrito"] == null)
            {
                listaCarrito = new List<ItemCarrito>();
                
            }
            else
            {
                listaCarrito = (List<ItemCarrito>)Session["listaCarrito"];
               
            }
            ItemCarrito repe = new ItemCarrito();
            foreach (var itemCarrito in listaCarrito)
            {
                
                
                if (IdAux == itemCarrito.IdProducto )
                {
                     repe = itemCarrito;
                }

            }

            if (item.IdProducto != repe.IdProducto)
            {
                listaCarrito.Add(item);
                Session["listaCarrito"] = listaCarrito;
            }

           

            foreach (var itemProd in listaCarrito )
            {
                if(IdAux == itemProd.IdProducto)
                {
                   
                    itemProd.CantidadItem++;
                }

            }

            return RedirectToAction("Carrito");
        }
        //[HttpPost] 
        //public ActionResult Carrito(int idAux = 0)
        //{

        //    Producto producto;
            
        //    List<Producto> listaCarrito;

        //    //listaOriginal = negocio.Listar();

        //    //producto = listaOriginal.Find(x => x.Id == idAux);

        //    producto = negocio.BuscarPorId(idAux);

        //    if (Session["listaCarrito"] == null)
        //    {
        //        listaCarrito = new List<Producto>();
        //        listaCarrito.Add(producto);
        //        Session.Add("listaCarrito", listaCarrito);
        //    }
        //    else
        //    {
        //        listaCarrito = (List<Producto>)Session["listaCarrito"];
        //        listaCarrito.Add(producto);
        //        Session.Add("listaCarrito", listaCarrito);
        //        // ViewBag.ListaCarrito = listaCarrito;
        //    }

        //    ViewBag.ListaCarrito = listaCarrito;


        //    return RedirectToAction("Carrito");
        //}
        public ActionResult Eliminar(int idAux)
        {
            
           
            List<ItemCarrito> listaCarrito;
            //me traigo de carrito la session
            listaCarrito = (List<ItemCarrito>)Session["listaCarrito"];
            //listaOriginal = negocio.Listar();
            //producto = listaOriginal.Find(x => x.Id == idAux);

            //TODA ESTA BUSQUEDA PARA QUE ME SIRVE?

            //producto = negocio.BuscarPorId(idAux);
            
            listaCarrito.RemoveAll(x=>x.IdProducto == idAux);
            //Session.Add("listaCarrito", listaCarrito);
            Session["listaCarrito"] = listaCarrito;
            


            
            return RedirectToAction("Carrito");
        }

        public ActionResult QuitarUnItem(int idAux)
        {
            ItemCarrito item;
            Producto producto;

            //List<ItemCarrito> listaCarrito;

            List<ItemCarrito> listaCarrito;
            listaCarrito = (List<ItemCarrito>)Session["listaCarrito"];


            //item =  listaCarrito.Find(x=>x.Id == idAux);

            //lo que pasa es que como tengo dos id iguales, 
            //la lista me la trae como si tuviera un solo producto de esos que quiero quitar uno



            foreach (var itemAquitar in listaCarrito)
            {
                if (idAux == itemAquitar.IdProducto)
                {
                    itemAquitar.CantidadItem--;
                    //listaCarrito.Remove(itemAquitar);
                    Session["listaCarrito"] = listaCarrito;
                }
            }

            return RedirectToAction("Carrito");
        }

        [HttpGet]
        public ActionResult FormAltaProducto(int idAux = 0) // si le llega toma ese, y sino toma el valor por defecto de 0
        {
            //si no es admin return al catalogo o donde sea.

            if(Session["TipoUsuario"] as byte? != 1)
            {
                return RedirectToAction("Catalogo");
            }

            TipoProdNegocio negocioTipo = new TipoProdNegocio();
            List<TipoProducto> TipoRemera;
            TipoRemera = negocioTipo.Listar();
            ViewBag.tipoRemera = TipoRemera;

            ColorNegocio colorNegocio = new ColorNegocio();
            List<Color> ColorRemera;
            ColorRemera = colorNegocio.Listar();
            ViewBag.colorRemera = ColorRemera;

            TalleNegocio talleNegocio = new TalleNegocio();
            List<Talle> TalleRemera;
            TalleRemera = talleNegocio.Listar();
            ViewBag.talleRemera = TalleRemera;


            Producto producto;
         
                
          producto= negocio.BuscarPorId( idAux);


            return View(producto);
        }
        [HttpPost]
        public ActionResult FormAltaProducto(Producto remera)
        {

            bool valid = ModelState.IsValid;
            if (!valid)
            {
                TalleNegocio talleNegocio = new TalleNegocio();
                List<Talle> TalleRemera;
                TalleRemera = talleNegocio.Listar();
                ViewBag.talleRemera = TalleRemera;
                return View(remera);
            }

                if (remera.Id > 0)
             negocio.Modificar(remera); 
            else 
            negocio.Agregar(remera);
           

         
            return RedirectToAction("ABMProducto"); // redirijo al action, no a la vista.
        }
        [HttpGet]
        public ActionResult FormAltaColores(int IdAux = 0)
        {

            if (Session["TipoUsuario"] as byte? != 1)
            {
                return RedirectToAction("Catalogo");
            }
            Color color;
            ColorNegocio colorNegocio = new ColorNegocio();
            List<Color> ListaColores;
            ListaColores = colorNegocio.Listar();
            color = ListaColores.Find(x=>x.Id == IdAux);

             

            return View(color);
        }
        [HttpPost]
        public ActionResult FormAltaColores(Color color)
        {
            ColorNegocio colorNegocio = new ColorNegocio();
            //bool valid = ModelState.IsValid;
            //if(!valid)
            //{
            //    List<Color> ListaColores;
            //    ListaColores = colorNegocio.Listar();              
            //    return View(color);
            //}

            if (color.Id > 0)
               colorNegocio.Modificar(color);
            else
                colorNegocio.Agregar(color);


            return RedirectToAction("ABMColores");
        }




        public ActionResult FormAltaEstados(int IdAux = 0)
        {
            Estado estado;
            if (Session["TipoUsuario"] as byte? != 1)
            {
                return RedirectToAction("Catalogo");
            }
            EstadoNegocio estadoNegocio = new EstadoNegocio();
            List<Estado> ListaEstados;
            ListaEstados = estadoNegocio.Listar();
            estado = ListaEstados.Find(x => x.Id == IdAux);



            return View(estado);
        }
        [HttpPost]
        public ActionResult FormAltaEstados(Estado estado)
        {
            EstadoNegocio estadoNegocio = new EstadoNegocio();

            if (estado.Id > 0)
                estadoNegocio.Modificar(estado);
            else
                estadoNegocio.Agregar(estado);


            return RedirectToAction("ABMEstados");
        }

        [HttpGet]
        public ActionResult FormAltaTalles(int IdAux = 0)
        {
            Talle talle;
            TalleNegocio talleNegocio = new TalleNegocio();
            List<Talle> ListaTalles;
            ListaTalles = talleNegocio.Listar();
            talle = ListaTalles.Find(x => x.Id == IdAux);



            return View(talle);
        }
        [HttpPost]
        public ActionResult FormAltaTalles(Talle talle)
        {

            if (Session["TipoUsuario"] as byte? != 1)
            {
                return RedirectToAction("Catalogo");
            }
            TalleNegocio talleNegocio = new TalleNegocio();

            //bool valid = ModelState.IsValid;
            //if (!valid)
            //{
               
            //    List<Talle> ListaTalles;
            //    ListaTalles = talleNegocio.Listar();
            //    return View(talle);
            //}

                if (talle.Id > 0)
                talleNegocio.Modificar(talle);
            else
                talleNegocio.Agregar(talle);


            return RedirectToAction("ABMTalle");
        }



        [HttpGet]
        public ActionResult FormAltaTipoUsuario(int IdAux = 0)
        {

            if (Session["TipoUsuario"] as byte? != 1)
            {
                return RedirectToAction("Catalogo");
            }
            TipoUsuario tipoUsuario;
            TipoUsuarioNegocio tipoUsuarioNegocio = new TipoUsuarioNegocio();
            List<TipoUsuario> ListaTipo;
            ListaTipo = tipoUsuarioNegocio.Listar();
            tipoUsuario = ListaTipo.Find(x => x.Id == IdAux);



            return View(tipoUsuario);
        }
        [HttpPost]

        public ActionResult FormAltaTipoUsuario(TipoUsuario tipoUsuario)
        {
            TipoUsuarioNegocio tipoUsuarioNegocio = new TipoUsuarioNegocio();

            bool valid = ModelState.IsValid;
            if (!valid)
            {                           
                List<TipoUsuario> ListaTipo;
                ListaTipo = tipoUsuarioNegocio.Listar();
                return View(tipoUsuario);
            }

            if (tipoUsuario.Id > 0)
                tipoUsuarioNegocio.Modificar(tipoUsuario);
            else
                tipoUsuarioNegocio.Agregar(tipoUsuario);


            return RedirectToAction("ABMTipoUsuario");
        }





        [HttpGet]
        public ActionResult FormAltaTipoRemera(int IdAux = 0)
        {
            if (Session["TipoUsuario"] as byte? != 1)
            {
                return RedirectToAction("Catalogo");
            }
            TipoProducto tipo;
            TipoProdNegocio tipoProdNegocio = new TipoProdNegocio();
            List<TipoProducto> ListaTiporemeras;
            ListaTiporemeras = tipoProdNegocio.Listar();
            tipo = ListaTiporemeras.Find(x => x.Id == IdAux);



            return View(tipo);
        }
        [HttpPost]
        public ActionResult FormAltaTipoRemera(TipoProducto tipo)
        {
            TipoProdNegocio tipoProdNegocio = new TipoProdNegocio();


            //bool valid = ModelState.IsValid;
            //if (!valid)
            //{
                
               
            //    List<TipoProducto> ListaTiporemeras;
            //    ListaTiporemeras = tipoProdNegocio.Listar();
            //    return View(tipo);
            //}

                if (tipo.Id > 0)
                tipoProdNegocio.Modificar(tipo);
            else
                tipoProdNegocio.Agregar(tipo);


            return RedirectToAction("ABMTipoRemera");
        }

        public ActionResult ABMProducto()
        {
            if (Session["TipoUsuario"] as byte? != 1)
            {
                return RedirectToAction("Catalogo");
            }

            List<Producto> listita;

            listita = negocio.Listar();

            ViewBag.ListaDeProductos = listita;
            

            return View();
        }

        public ActionResult ABMColores()
        {

            if (Session["TipoUsuario"] as byte? != 1)
            {
                return RedirectToAction("Catalogo");
            }
            List<Color> listita;
            ColorNegocio colorNegocio = new ColorNegocio();
            listita = colorNegocio.Listar();

            ViewBag.ListaDeColores = listita;
            return View();
        }

        public ActionResult ABMEstados()
        {

            if (Session["TipoUsuario"] as byte? != 1)
            {
                return RedirectToAction("Catalogo");
            }

            List<Estado> listaEstados;
            EstadoNegocio estadonegocio = new EstadoNegocio();
            listaEstados = estadonegocio.Listar();

            ViewBag.ListaDeEstados = listaEstados;
            Session["listaEstados"] = listaEstados;
            return View();
        }

        public ActionResult ABMTalle()
        {

            if (Session["TipoUsuario"] as byte? != 1)
            {
                return RedirectToAction("Catalogo");
            }

            List<Talle> listita;
            TalleNegocio talleNegocio = new TalleNegocio();
            listita = talleNegocio.Listar();

            ViewBag.ListaDeTalles = listita;
            return View();
        }

        public ActionResult ABMTipoRemera()
        {
            if (Session["TipoUsuario"] as byte? != 1)
            {
                return RedirectToAction("Catalogo");
            }

            List<TipoProducto> listita;
            TipoProdNegocio tipoProdNegocio = new TipoProdNegocio();
            listita = tipoProdNegocio.Listar();

            ViewBag.ListaTipoRemera = listita;
            return View();
        }

        public ActionResult ABMTipoUsuario()
        {
            if (Session["TipoUsuario"] as byte? != 1)
            {
                return RedirectToAction("Catalogo");
            }

            List<TipoUsuario> listita;
            TipoUsuarioNegocio tipoUsuarioNegocio = new TipoUsuarioNegocio();
            listita = tipoUsuarioNegocio.Listar();

            ViewBag.ListaDeTipoUsuario = listita;
            return View();
        }
        //public ActionResult FormAltaUsuario()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public ActionResult FormAltaUsuario (FormCollection form)
        //{
        //    Usuario usuario;
        //    UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
        //    usuario = new Usuario();


        //    usuario.NombreUsuario   = form["NombreUsuario"];
        //    usuario.Contrasenia   = form["Contrasenia"];
        //    usuario.IdTipoUsiario = Convert.ToByte(form["IdTipoUsuario"]);
        //    usuario.Nombre   = form["Nombre"];
        //    usuario.Apellido   = form["Apellido"];
        //    usuario.DNI  = form["DNI"];
        //    usuario.FechaNac   = Convert.ToDateTime (form["FechaNac"]);
        //    usuario.Genero   = form["Genero"];
        //    usuario.Telefono   = form["Telefono"];
        //    usuario.Ciudad   = form["Ciudad"];
        //    usuario.Direccion   = form["Direccion"];
        //    usuario.Email = form["Email"];
        //    usuario.CP = Convert.ToInt32( form["CP"]);

        //    usuarioNegocio.AgregarUsuario(usuario);

        //    return RedirectToAction("FormAltaUsuario");
        //}

        public ActionResult AbmUsuario()
        {

            if (Session["TipoUsuario"] as byte? != 1)
            {
                return RedirectToAction("Catalogo");
            }

            List<Usuario> listaUsuario;
            UsuarioNegocio negocio = new UsuarioNegocio();

            listaUsuario = negocio.Listar();

            
           
            ViewBag.ListaUsuarios = listaUsuario;

           // Session["listaUsuario"] = listaUsuario;
            return View("AbmUsuario");
        }

        public ActionResult FormAltaUsuario(int idAux=0)
        {

            //if (Session["TipoUsuario"] as byte? != 1)
            //{
            //    return RedirectToAction("Catalogo");
            //}

            TipoUsuarioNegocio negocioTipo = new TipoUsuarioNegocio();
            List<TipoUsuario> tipoUsuarios;
            tipoUsuarios = negocioTipo.Listar();
            ViewBag.TipoDeUsuario = tipoUsuarios;


            Usuario usuario;
            
            UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
            usuario = usuarioNegocio.BuscarPorIdUsuario(idAux);

            //List<Usuario> listaOriginal = usuarioNegocio.Listar();

            //usuario = listaOriginal.Find(x => x.Id == idAux);

            return View(usuario);
        }

        [HttpPost]
        public ActionResult FormAltaUsuario(Usuario usuario)
        {

            bool valid = ModelState.IsValid;
            if (!valid)
            {
                TipoUsuarioNegocio negocioTipo = new TipoUsuarioNegocio();
               
                return View(usuario);
            }

                UsuarioNegocio usuarioNegocio = new UsuarioNegocio();

            if (usuario.Id > 0)
                usuarioNegocio.ModificarUsuario(usuario);
            else
                usuarioNegocio.AgregarUsuario(usuario);

           
            return RedirectToAction("AbmUsuario");
           
        }


        public ActionResult FormAltaCliente(int idAux = 0)
        {

            //if (Session["TipoUsuario"] as byte? != 1)
            //{
            //    return RedirectToAction("Catalogo");
            //}

            Usuario usuario;

            UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
            usuario = usuarioNegocio.BuscarPorIdUsuario(idAux);

   

            return View(usuario);
        }

        [HttpPost]
        public ActionResult FormAltaCliente(Usuario usuario)
        {

            UsuarioNegocio usuarioNegocio = new UsuarioNegocio();


            bool valid = ModelState.IsValid;
            if (!valid)
            {
                //TipoUsuarioNegocio negocioTipo = new TipoUsuarioNegocio();
                //List<TipoUsuario> tipoUsuarios;
                //tipoUsuarios = negocioTipo.Listar();
                //ViewBag.TipoDeUsuario = tipoUsuarios;
                return View(usuario);
            }




            if (usuario.Id > 0)
                usuarioNegocio.ModificarCliente(usuario);
            else
                usuarioNegocio.AgregarCliente(usuario);


             if (usuario.IdTipoUsiario == 1)
                return RedirectToAction("AbmUsuario");
            else if (Session["listaCarrito"]== null)
                return RedirectToAction("Catalogo");
            else
                return RedirectToAction("Carrito");
        }





        public ActionResult BajaLogicaProducto (int idAux)
        {
             
            List<Producto> listaOriginal = negocio.Listar();
            //HASTA ACA LO QUE DEBERIA HACER ES ENCONTRAR EL PRODUCTO QUE QUIERO DAR DE BAJA
            Producto producto = listaOriginal.Find(x => x.Id == idAux);
            
          

            negocio.DarBajaLogicaProducto(producto);
            return RedirectToAction("ABMproducto");
        }

        public ActionResult BajaLogicaColores(int idAux)
        {
            ColorNegocio colorNegocio = new ColorNegocio();
            List<Color> listaOriginal = colorNegocio.Listar();
            //HASTA ACA LO QUE DEBERIA HACER ES ENCONTRAR EL PRODUCTO QUE QUIERO DAR DE BAJA
            Color color = listaOriginal.Find(x => x.Id == idAux);



            colorNegocio.DarBajaLogicaColor(color);
            return RedirectToAction("ABMColores");
        }

        public ActionResult BajaLogicaEstado(int idAux)
        {
            EstadoNegocio estado = new EstadoNegocio();
            List<Estado> listaOriginal = estado.Listar();
            //HASTA ACA LO QUE DEBERIA HACER ES ENCONTRAR EL PRODUCTO QUE QUIERO DAR DE BAJA
            Estado estado1 = listaOriginal.Find(x => x.Id == idAux);



            estado.DarBajaLogicaEstado(estado1);
            return RedirectToAction("ABMEstados");
        }

        public ActionResult BajaLogicaTalles(int idAux)
        {
            TalleNegocio talleNegocio = new TalleNegocio();
            List<Talle> listaOriginal = talleNegocio.Listar();
            //HASTA ACA LO QUE DEBERIA HACER ES ENCONTRAR EL PRODUCTO QUE QUIERO DAR DE BAJA
            Talle talle = listaOriginal.Find(x => x.Id == idAux);



            talleNegocio.DarBajaLogicaTalle(talle);
            return RedirectToAction("ABMTalle");
        }

        public ActionResult BajaLogicaTipoRemera(int idAux)
        {
            TipoProdNegocio tipoProdNegocio = new TipoProdNegocio();
            List<TipoProducto> listaOriginal = tipoProdNegocio.Listar();
            //HASTA ACA LO QUE DEBERIA HACER ES ENCONTRAR EL PRODUCTO QUE QUIERO DAR DE BAJA
           TipoProducto tipo = listaOriginal.Find(x => x.Id == idAux);



            tipoProdNegocio.DarBajaLogicaTIpoProducto(tipo);
            return RedirectToAction("ABMTipoRemera");
        }

        
          public ActionResult BajaLogicaTipoUsuario(int idAux)
        {
            TipoUsuarioNegocio tipoUsuarioNegocio = new TipoUsuarioNegocio();
            List<TipoUsuario> listaOriginal = tipoUsuarioNegocio.Listar();
            //HASTA ACA LO QUE DEBERIA HACER ES ENCONTRAR EL PRODUCTO QUE QUIERO DAR DE BAJA
            TipoUsuario tipo = listaOriginal.Find(x => x.Id == idAux);



            tipoUsuarioNegocio.DarBajaLogicaTipoUsuario(tipo);
            return RedirectToAction("ABMTipoUsuario");
        }
        public ActionResult BajaLogicaUsuario1(int idAux)
        {
            UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
            List<Usuario> listaOriginal = usuarioNegocio.Listar();
            //HASTA ACA LO QUE DEBERIA HACER ES ENCONTRAR EL PRODUCTO QUE QUIERO DAR DE BAJA
            Usuario usuario = listaOriginal.Find(x => x.Id == idAux);



            usuarioNegocio.DarBajaLogicaUsuario(usuario);
            
                return RedirectToAction("ABMUsuario");
        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace cosasLindas
{
    public partial class Carrito : System.Web.UI.Page
    {
        public List<DetalleCarrito> ListaProducto;
        public List<DetalleCarrito> listaCarrito;
        public DetalleCarrito detalle;

        //public List<Producto> ListaProducto;
        //public List<Producto> listaCarrito;
       // public Producto producto;
        int idAux;
        int idExtra;
        protected void Page_Load(object sender, EventArgs e)
        {
            //ListaProducto = new List<Producto>();
            ////ProductoNegocio negocio = new ProductoNegocio();
            ////ListaProducto = negocio.Listar();

            ////listaCarrito = new List<Producto>();

            ////idAux = Convert.ToInt32(Request.QueryString["IdArticulo"]);
            ////idExtra = Convert.ToInt32(Request.QueryString["idExtra"]);
            ////producto = ListaProducto.Find(x=>x.Id== idAux);

            ////ListaProducto = new List<DetalleCarrito>();
            //DetalleCarritoNegocio negocio = new DetalleCarritoNegocio();
            //ListaProducto = negocio.Listar();

            //listaCarrito = new List<DetalleCarrito>();

            //idAux = Convert.ToInt32(Request.QueryString["IdArticulo"]);
            //idExtra = Convert.ToInt32(Request.QueryString["idExtra"]);
            //producto = ListaProducto.Find(x => x.IdProducto == idAux);

            //if (idExtra == 1 && idAux > 0)
            //{
            //    listaCarrito = (List<Producto>)Session["listaCarrito"];
            //    foreach (var item in listaCarrito)
            //    {

            //        if (item.Id == idAux)
            //        {

            //            listaCarrito.Remove(item);
            //            Session.Add("listaCarrito", listaCarrito);
            //            Response.Redirect("Carrito.aspx");
            //        }
            //    }
            //}
            //else if (idExtra != 1 && idAux > 0)

            //{
            //    if (Session["listaCarrito"] == null)// si no existe creamela y agregalo
            //    {
            //        listaCarrito = new List<Producto>();
            //        listaCarrito.Add(producto);
            //        Session.Add("listaCarrito", listaCarrito);
        }
        //        else
        //        {

        //            listaCarrito = (List<Producto>) Session["listaCarrito"];//aca esta la lista cn los productos ya agregados
        //listaCarrito.Add(producto);
        //            Session.Add("listaCarrito", listaCarrito);

        //        }



    //}

    //else
    //{
    //    if (Session["listaCarrito"] != null)
    //    {

    //        listaCarrito = (List<Producto>)Session["listaCarrito"];
    //    }
    //    // listaCarrito = new List<Producto>();
    //}



}

       
    }
}
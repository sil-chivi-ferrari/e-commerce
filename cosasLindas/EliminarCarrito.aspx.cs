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
    public partial class EliminarCarrito : System.Web.UI.Page
    {
        int idAux;
        public List<Producto> ListaOriginal;
        public Producto producto;
        public List<Producto> listaCarrin;
        protected void Page_Load(object sender, EventArgs e)
        {
            producto = new Producto();
            ProductoNegocio negocio = new ProductoNegocio();
            ListaOriginal = negocio.Listar();
            idAux = Convert.ToInt32(Request.QueryString["idArticulo"]);
            producto = ListaOriginal.Find(x => x.Id == idAux);

            listaCarrin = (List<Producto>)Session["listaCarrito"];
            foreach (var item in listaCarrin)
            {

                if (item.Id == idAux)
                {

                    listaCarrin.Remove(item);
                    Session.Add("listaCarrito", listaCarrin);
                    Response.Redirect("Carrito.aspx");
                }
            }


        }
    }
}
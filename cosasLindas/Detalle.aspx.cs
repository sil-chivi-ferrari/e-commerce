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
    public partial class Detalle : System.Web.UI.Page
    {
        public List<Producto> ListaProducto;
        public Producto producto;
        long idAux;

       
        protected void Page_Load(object sender, EventArgs e)
        {
           
           
           //ListaProducto = new List<Producto>();
            ProductoNegocio negocio = new ProductoNegocio();
            ListaProducto = negocio.Listar();

            idAux = Convert.ToInt32(Request.QueryString["idArticulo"]);
            producto = ListaProducto.Find(x => x.Id == idAux);
           

        }
    }
}
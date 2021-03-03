using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Dominio;

namespace cosasLindas
{
    public partial class _Default : Page
    {
        public List<Producto> ListaProductos;
        public List<Producto> ListaBuscada;
        public Producto producto;

        protected void Page_Load(object sender, EventArgs e)
        {
            ProductoNegocio negocio = new ProductoNegocio();
            ListaProductos = new List<Producto>();
            //if (!IsPostBack)
            //{
            //    ListaProductos = negocio.Listar();
            //    Session.Add("ListaProductos", ListaProductos);
            //}

            if (Session["ListaBuscada"] == null)
            {
                ListaProductos = negocio.Listar();
                
            }
            
            if (Session["ListaBuscada"] != null)
            {
                
                ListaBuscada = (List<Producto>)Session["ListaBuscada"];
                
            }
                


        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            
            ProductoNegocio negocio = new ProductoNegocio();
            ListaProductos = negocio.Listar();
            Session.Add("ListaProductos", ListaProductos);
            List<Producto> ListaBuscada = ListaProductos.FindAll(X => X.Nombre.ToUpper().Contains(txtBuscar.Text.ToUpper()) || X.Descripcion.ToUpper().Contains(txtBuscar.Text.ToUpper()));

            //Session.Add("listaBuscada", ListaBuscada);
            Session.Add("listaBuscada", ListaBuscada);
            //Session.Add("ListaProductos", ListaBuscada);
            Response.Redirect("Default.aspx");

        }
    }
}
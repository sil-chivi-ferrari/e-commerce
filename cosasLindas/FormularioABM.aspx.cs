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
    public partial class FormularioABM : System.Web.UI.Page
    {
        public List<Producto> ListaOriginal;
        public Producto producto;
       

        protected void Page_Load(object sender, EventArgs e)
        {
            ProductoNegocio negocio = new ProductoNegocio();

            ListaOriginal = negocio.Listar();
           // Session.Add("ListaOriginal", ListaOriginal);
           
            
            
           
        }
    }
}
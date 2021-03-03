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
    public partial class FormularioRealABM : System.Web.UI.Page
    {
        public List<Producto> lista;
        public Producto produ = null;
        int idAux;
       
        protected void Page_Load(object sender, EventArgs e)
        {
            ProductoNegocio negocio = new ProductoNegocio();
            lista = negocio.Listar();

         

            idAux = Convert.ToInt32(Request.QueryString["IdArticulo"]);
    
            produ = lista.Find(x => x.Id == idAux);

            if (!IsPostBack)
            {
                if (produ != null)
                {
                    txtImagen.Text = produ.UrlImagen;
                    txtPrecio.Text = Convert.ToString(produ.Precio);
                    txtTalle.Text = produ.Talle;
                    txtColor.Text = produ.Color;
                    txtNombre.Text = produ.Nombre;
                    txtDescripcion.Text = produ.Descripcion;
                    txtEstado.Text = Convert.ToString(produ.Estado);
                    txtStockActual.Text = Convert.ToString(produ.StockActual);
                    txtStockMini.Text = Convert.ToString(produ.StockMinimo);
                    txtidtipo.Text = Convert.ToString(produ.IdTipo);

                }
                //ddlTipo.DataSource = lista;
                //ddlTipo.DataBind();
            }
        }
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            ProductoNegocio negocio = new ProductoNegocio();
            //hace falta instanciar al producto?

            if (produ == null)
            {
                produ = new Producto();
            }

            produ.Color = txtColor.Text;
            produ.Nombre = txtNombre.Text;
            produ.Descripcion = txtDescripcion.Text;
            //produ.Id = Convert.ToInt64(txtId.Text);
            produ.IdTipo = Convert.ToByte(txtidtipo.Text);
            produ.UrlImagen = txtImagen.Text;
            produ.Precio = Convert.ToDecimal(txtPrecio.Text);
            produ.Talle = txtTalle.Text;
            produ.Estado = Convert.ToBoolean(txtEstado.Text);
            produ.StockActual = Convert.ToInt32 (txtStockActual.Text);
            produ.StockMinimo = Convert.ToInt32(txtStockMini.Text);

            if (produ.Id == 0)
            {
                negocio.Agregar(produ);
            }
            else
            {
                negocio.Modificar(produ);
            }





        }
    }
}
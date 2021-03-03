using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class ItemCarrito
    {
        public long IdProducto { get; set; } // es el id del producto

        public Byte IdTipo { get; set; }

        public decimal Precio { get; set; }
        public string Nombre { get; set; }
        public string Talle { get; set; }
        public string Descripcion { get; set; }
        public string Color { get; set; }
        public string UrlImagen { get; set; }

        public byte CantidadItem { get; set; }

        public decimal PrecioFinal 
        {
            get // le saco el set y no se le puede asignar ningun valor
            {
                decimal precioFin;
                precioFin = Precio * CantidadItem;
                return precioFin;
            }
        }

        // public TipoProducto tipoProducto { get; set; }
    }
}

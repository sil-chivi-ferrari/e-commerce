using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlTypes;
using System.ComponentModel.DataAnnotations;

namespace Dominio
{
    public class Producto
    {
        public long Id { get; set; }

        public Byte IdTipo { get; set; }
       
        [Required]       
        public decimal Precio { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Nombre { get; set; }
        public byte IdTalle { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Descripcion { get; set; }
        public byte IdColor { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string UrlImagen  { get; set; }

        public bool Estado { get; set; }
        [Required]
        public int StockMinimo { get; set; }
        [Required]
        public int StockActual { get; set; }

        public TipoProducto tipoProducto { get; set; }

        public Color color { get; set; }

        public Talle talle { get; set; }

    }
}

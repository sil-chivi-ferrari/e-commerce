using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Pedido
    {
        public long Id { get; set; }
        public long IdUsuario { get; set; }

        public byte IdEstado { get; set; }

        public DateTime Fecha { get; set; }

        public decimal Importe { get; set; }

        public byte IdTipoPago { get; set; }

        public string datosFormaDePago { get; set; }

        public Estado estado { get; set; }

        public Usuario usuario { get; set; }

        public TipoPago tipoPago { get; set; }

        public List<DetalleCarrito> listaDetalle { get; set; }
    }
}

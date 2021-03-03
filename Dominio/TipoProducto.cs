using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace Dominio
{
    public class TipoProducto
    {
        public byte Id { get; set; }

        [Required(ErrorMessage = "Debe ingresa el tipo de la remera por favor.")]
        public string Nombre { get; set; }

        public bool Estado { get; set; }

    }
}

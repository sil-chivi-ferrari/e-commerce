using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Dominio
{
    public class Talle
    {
        public byte Id { get; set; }

        [Required(ErrorMessage ="Debe ingresa el TALLE por favor.")]
        //[Required(AllowEmptyStrings = false)]
        public string Nombre { get; set; }
        public bool Estado { get; set; }
    }
}

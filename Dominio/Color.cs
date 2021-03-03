using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

using System.ComponentModel.DataAnnotations;

namespace Dominio
{
    public class Color
    {
        public byte Id { get; set; }

        [Required(AllowEmptyStrings =false)]
        public string Nombre { get; set; }

        public bool Estado { get; set; }
    }
}

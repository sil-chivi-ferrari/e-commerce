using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Dominio
{
    public class TipoUsuario
    {
        public byte Id { get; set; }

        [Required(ErrorMessage = "Debe ingresa el tipo del Usuario por favor.")]
        public string Nombre { get; set; }

        public bool Estado { get; set; }
    }
}

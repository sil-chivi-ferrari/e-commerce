using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlTypes;
using System.ComponentModel.DataAnnotations;

namespace Dominio
{
    public class Usuario
    {
        public long Id { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string NombreUsuario { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Contrasenia { get; set; }

        public byte IdTipoUsiario { get; set; }

        public SqlBoolean Estado { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Nombre { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Apellido { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string DNI { get; set; }
        public DateTime FechaNac { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Genero { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Telefono { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Direccion { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Ciudad { get; set; }

        [Required(AllowEmptyStrings = false)]
        [EmailAddress]
        public string Email { get; set; }

        [Required(AllowEmptyStrings = false)]
        public int CP { get; set; }

        public TipoUsuario tipoUsuario { get; set; }

        public override string ToString()
        {
            return Nombre;
        }

    }
}

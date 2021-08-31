using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PeliculasAPI.Entidades
{
    public class Actor
    {
        public int id { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(maximumLength: 200)]
        public string nombre { get; set; }
        public string briografia { get; set; }
        public DateTime fechaNacimiento { get; set; }
        public string foto { get; set; }

        public List<PeliculasActores> peliculasActores { get; set; }
    }
}

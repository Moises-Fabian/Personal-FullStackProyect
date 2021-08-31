using PeliculasAPI.Validaciones;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PeliculasAPI.Entidades
{
    public class Genero
    {
        public int id { get; set; }
        [Required(ErrorMessage ="El campo {0} es requerido")]
        [StringLength(maximumLength: 30)]
        [PrimeraLetraMayuscula]
        public string nombre { get; set; }

        public List<PeliculasGeneros> peliculasGeneros { get; set; }
    }
}

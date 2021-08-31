using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PeliculasAPI.Entidades
{
    public class Pelicula
    {
        public int id { get; set; }
        [Required]
        [StringLength(maximumLength: 300)]
        public string titulo { get; set; }
        public string resumen { get; set; }
        public string trailer { get; set; }
        public bool enCines { get; set; }
        public DateTime fechaLanzamiento { get; set; }
        public string poster { get; set; }
        public List<PeliculasActores> peliculasActores { get; set; }
        public List<PeliculasGeneros> peliculasGeneros { get; set; }
        public List<PeliculasCines> peliculasCines { get; set; }
    }
}
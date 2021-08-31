using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PeliculasAPI.Entidades
{
    public class PeliculasActores
    {
        public int peliculaId { get; set; }
        public int actorId { get; set; }
        public Pelicula pelicula { get; set; }
        public Actor actor { get; set; }
        [StringLength(maximumLength:100)]
        public string personaje { get; set; }
        public int orden { get; set; }
    }
}

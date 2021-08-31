using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PeliculasAPI.Entidades
{
    public class PeliculasGeneros
    {
        public int peliculaId { get; set; }
        public int generoId { get; set; }
        public Pelicula pelicula { get; set; }
        public Genero genero { get; set; }
    }
}

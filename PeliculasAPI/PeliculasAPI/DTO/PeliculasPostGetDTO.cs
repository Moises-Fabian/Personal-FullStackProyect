using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PeliculasAPI.DTO
{
    public class PeliculasPostGetDTO
    {
        public List<GeneroDTO> generos { get; set; }
        public List<CineDTO> cines { get; set; }
    }
}

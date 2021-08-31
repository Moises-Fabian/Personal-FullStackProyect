using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PeliculasAPI.DTO
{
    public class ActorDTO
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string briografia { get; set; }
        public DateTime fechaNacimiento { get; set; }
        public string foto { get; set; }
    }
}

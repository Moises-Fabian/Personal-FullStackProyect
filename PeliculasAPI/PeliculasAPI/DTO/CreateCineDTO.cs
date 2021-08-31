using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PeliculasAPI.DTO
{
    public class CreateCineDTO
    {
        [Required]
        [StringLength(maximumLength: 75)]
        public string nombre { get; set; }
        [Range(-90, 90)]
        public double latitud { get; set; }
        [Range(-180, 180)]
        public double longitud { get; set; }
    }
}

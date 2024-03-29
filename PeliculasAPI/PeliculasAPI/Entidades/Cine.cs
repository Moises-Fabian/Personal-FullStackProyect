﻿using NetTopologySuite.Geometries;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PeliculasAPI.Entidades
{
    public class Cine
    {
        public int id { get; set; }

        [Required]
        [StringLength(maximumLength:75)]
        public string nombre { get; set; }

        public Point ubicacion { get; set; }

        public List<PeliculasCines> peliculasCines { get; set; }
    }
}

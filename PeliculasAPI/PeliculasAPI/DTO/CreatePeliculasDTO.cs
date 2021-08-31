using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PeliculasAPI.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PeliculasAPI.DTO
{
    public class CreatePeliculasDTO
    {
        [Required]
        [StringLength(maximumLength: 300)]
        public string titulo { get; set; }
        public string resumen { get; set; }
        public string trailer { get; set; }
        public bool enCines { get; set; }
        public DateTime fechaLanzamiento { get; set; }
        public IFormFile poster { get; set; }
        [ModelBinder(BinderType = typeof(TypeBinder<List<int>>))]
        public List<int> generosIds { get; set; }
        [ModelBinder(BinderType = typeof(TypeBinder<List<int>>))]
        public List<int> cinesIds { get; set; }

        [ModelBinder(BinderType = typeof(TypeBinder<List<CreateActorPeliculasDTO>>))]
        public List<CreateActorPeliculasDTO> actores { get; set; }
    }
}

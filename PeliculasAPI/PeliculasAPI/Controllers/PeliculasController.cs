using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PeliculasAPI.DTO;
using PeliculasAPI.Entidades;
using PeliculasAPI.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PeliculasAPI.Controllers
{
    [ApiController]
    [Route("api/peliculas")]
    public class PeliculasController: ControllerBase
    {
        private readonly ApplicationDbContext applicationDbContext;
        private readonly IMapper mapper;
        private readonly IAlmacenadorArchivo almacenadorArchivo;
        private readonly string contenedor = "peliculas";

        public PeliculasController(ApplicationDbContext applicationDbContext,
            IMapper mapper, IAlmacenadorArchivo almacenadorArchivo)
        {
            this.applicationDbContext = applicationDbContext;
            this.mapper = mapper;
            this.almacenadorArchivo = almacenadorArchivo;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromForm] CreatePeliculasDTO createPeliculasDTO)
        {
            var pelicula = mapper.Map<Pelicula>(createPeliculasDTO);

            if (createPeliculasDTO.poster != null)
            {
                pelicula.poster = await almacenadorArchivo.GuardarArchivo(contenedor, createPeliculasDTO.poster);
            }

            EscribirOrdenActores(pelicula);

            applicationDbContext.Add(pelicula);
            await applicationDbContext.SaveChangesAsync();
            return NoContent();
        }

        [HttpGet("PostGet")]
        public async Task<ActionResult<PeliculasPostGetDTO>> PostGet()
        {
            var cines = await applicationDbContext.Cines.ToListAsync();
            var generos = await applicationDbContext.Generos.ToListAsync();

            var cinesDTO = mapper.Map<List<CineDTO>>(cines);
            var generosDTO = mapper.Map<List<GeneroDTO>>(generos);

            return new PeliculasPostGetDTO() { cines = cinesDTO, generos = generosDTO };
        }

        private void EscribirOrdenActores(Pelicula pelicula)
        {
            if (pelicula.peliculasActores != null)
            {
                for (int i = 0; i < pelicula.peliculasActores.Count; i++)
                {
                    pelicula.peliculasActores[i].orden = i;
                }
            }
        }
    }
}

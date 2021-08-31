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
    [Route("api/actores")]
    [ApiController]
    public class ActoresController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;
        private readonly IAlmacenadorArchivo almacenadorArchivo;
        private readonly string contenedor = "actores";

        public ActoresController(ApplicationDbContext context, IMapper mapper, IAlmacenadorArchivo almacenadorArchivo)
        {
            this.context = context;
            this.mapper = mapper;
            this.almacenadorArchivo = almacenadorArchivo;
        }

        [HttpGet]
        public async Task<ActionResult<List<ActorDTO>>> get([FromQuery] PaginacionDTO paginacionDTO)
        {
            var queryable = context.Actores.AsQueryable();
            await HttpContext.InsertarParametrosPaginacionEnCabecera(queryable);
            var actores = await queryable.OrderBy(x => x.nombre).Paginar(paginacionDTO).ToListAsync();
            return mapper.Map<List<ActorDTO>>(actores);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ActorDTO>> Get(int id){
            var actor =await context.Actores.FirstOrDefaultAsync(x => x.id == id);

            if (actor == null)
            {
                return NotFound();
            }

            return mapper.Map<ActorDTO>(actor);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromForm] CreateActorDTO createActorDTO)
        {
            var actor = await context.Actores.FirstOrDefaultAsync(x => x.id == id);

            if (actor == null)
            {
                return NotFound();
            }

            actor = mapper.Map(createActorDTO, actor);
            
            if (createActorDTO.foto != null)
            {
                actor.foto = await almacenadorArchivo.EditarArchivo(contenedor, createActorDTO.foto, actor.foto);
            }

            await context.SaveChangesAsync();
            return NoContent();

        }

        [HttpPost]
        public async Task<ActionResult> Post([FromForm] CreateActorDTO CreateActorDTO)
        {
            var actor = mapper.Map<Actor>(CreateActorDTO);

            if (CreateActorDTO.foto != null)
            {
               actor.foto =  await almacenadorArchivo.GuardarArchivo(contenedor, CreateActorDTO.foto);
            }



            context.Add(actor);
            await context.SaveChangesAsync();
            return NoContent();
            
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var actor = await context.Actores.FirstOrDefaultAsync(x => x.id == id);

            if (actor == null)
            {
                return NotFound();
            }

            context.Remove(actor);
            await context.SaveChangesAsync();

            await almacenadorArchivo.BorrarArchivo(actor.foto, contenedor);

            return NoContent();
        }
    }
}

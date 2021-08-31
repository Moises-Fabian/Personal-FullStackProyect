using AutoMapper;
using NetTopologySuite.Geometries;
using PeliculasAPI.DTO;
using PeliculasAPI.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PeliculasAPI.Utility
{
    public class AutoMapperProfiles: Profile
    {
        public AutoMapperProfiles(GeometryFactory geometryFactory)
        {
            CreateMap<Genero, GeneroDTO>().ReverseMap();
            CreateMap<CreateGeneroDTO, Genero>();
            CreateMap<Actor, ActorDTO>().ReverseMap();
            CreateMap<CreateActorDTO, Actor>().
                ForMember(x => x.foto, options => options.Ignore());
            CreateMap<CreateCineDTO, Cine>()
                .ForMember(x => x.ubicacion, x => x.MapFrom(dto =>
                geometryFactory.CreatePoint(new Coordinate(dto.latitud, dto.latitud))));
            CreateMap<Cine, CineDTO>()
                .ForMember(x => x.latitud, dto => dto.MapFrom(campo => campo.ubicacion.Y))
                .ForMember(x => x.longitud, dto => dto.MapFrom(campo => campo.ubicacion.X));
            CreateMap<CreatePeliculasDTO, Pelicula>()
                .ForMember(x => x.poster, opciones => opciones.Ignore())
                .ForMember(x => x.peliculasGeneros, opciones => opciones.MapFrom(MapearPeliculasGeneros))
                .ForMember(x => x.peliculasCines, opciones => opciones.MapFrom(MapearPeliculasCines))
                .ForMember(x => x.peliculasActores, opciones => opciones.MapFrom(MapearPeliculasActores));
        }

        private List<PeliculasActores> MapearPeliculasActores(CreatePeliculasDTO createPeliculasDTO,
             Pelicula pelicula)
        {
            var resultado = new List<PeliculasActores>();

            if (createPeliculasDTO.actores == null) { return resultado; }

            foreach (var actor in createPeliculasDTO.actores)
            {
                resultado.Add(new PeliculasActores() { actorId = actor.id, personaje = actor.personaje });
            }

            return resultado;
        }

        private List<PeliculasGeneros> MapearPeliculasGeneros(CreatePeliculasDTO createPeliculasDTO,
            Pelicula pelicula)
        {
            var resultado = new List<PeliculasGeneros>();

            if(createPeliculasDTO.generosIds == null) { return resultado;}

            foreach (var id in createPeliculasDTO.generosIds)
            {
                resultado.Add(new PeliculasGeneros() { generoId = id });
            }

            return resultado;
        }

        private List<PeliculasCines> MapearPeliculasCines(CreatePeliculasDTO createPeliculasDTO,
            Pelicula pelicula)
        {
            var resultado = new List<PeliculasCines>();

            if (createPeliculasDTO.cinesIds == null) { return resultado; }

            foreach (var id in createPeliculasDTO.cinesIds)
            {
                resultado.Add(new PeliculasCines() { cineId = id });
            }

            return resultado;
        }
    }
}

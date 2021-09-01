import { actorPeliculaDTO } from "../actores/actor";
import { cineDTO } from "../cines/cine";
import { generoDTO } from "../generos/genero";

export interface peliculaCreacionDTO{
  titulo: string;
  resumen: string;
  enCines: boolean;
  fechaLanzamiento: Date;
  trailer: string;
  poster: File;
  generosIds: number[];
  actores: actorPeliculaDTO[];
  cinesIds: number[];
}

export interface peliculaDTO{
  titulo: string;
  resumen: string;
  enCines: boolean;
  fechaLanzamiento: Date;
  trailer: string;
  poster: string;
}

export interface peliculaPostGet{
  generos: generoDTO[];
  cines: cineDTO[];
}

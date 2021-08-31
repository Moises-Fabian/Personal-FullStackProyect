export interface actorDTO{
  id: number;
  nombre: string;
  fechaNacimiento: Date;
  foto: string;
  briografia: string;
}

export interface actorCreacionDTO{
  nombre: string;
  fechaNacimiento: Date;
  foto: File;
  briografia: string;
}

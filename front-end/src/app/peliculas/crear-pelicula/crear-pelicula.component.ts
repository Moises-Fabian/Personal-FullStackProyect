import { Component, OnInit } from '@angular/core';
import { error } from 'protractor';
import { multipleSelectorModel } from 'src/app/utilidades/selector-multiple/multipleSelectorModule';
import { parsearErroresAPI } from 'src/app/utilidades/utilidades';
import { peliculaCreacionDTO } from '../pelicula';
import { PeliculasService } from '../peliculas.service';

@Component({
  selector: 'app-crear-pelicula',
  templateUrl: './crear-pelicula.component.html',
  styleUrls: ['./crear-pelicula.component.css']
})
export class CrearPeliculaComponent implements OnInit {

  constructor(private peliculasService: PeliculasService) { }

  errores: string[] = [];

  generosNoSeleccionados!: multipleSelectorModel[];
  cinesNoSeleccionados!: multipleSelectorModel[];

  ngOnInit(): void {
    this.peliculasService.postGet()
    .subscribe(resultado => {
      this.generosNoSeleccionados = resultado.generos.map(generos => {
        return <multipleSelectorModel>{llave: generos.id, valor: generos.nombre}
      });

      this.cinesNoSeleccionados = resultado.cines.map(cines => {
        return <multipleSelectorModel>{llave: cines.id, valor: cines.nombre}
      });

    }, error => console.error(error));
  }

  guardarCambios(pelicula: peliculaCreacionDTO){
    this.peliculasService.crear(pelicula)
    .subscribe(() => console.log('exitoso'),
    error => this.errores = parsearErroresAPI(error));
  }

}

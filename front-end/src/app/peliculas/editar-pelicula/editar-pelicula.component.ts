import { Component, OnInit } from '@angular/core';
import { peliculaCreacionDTO, peliculaDTO } from '../pelicula';

@Component({
  selector: 'app-editar-pelicula',
  templateUrl: './editar-pelicula.component.html',
  styleUrls: ['./editar-pelicula.component.css']
})
export class EditarPeliculaComponent implements OnInit {

  constructor() { }

  modelo: peliculaDTO = {titulo: 'Spider-Man', trailer: 'abc', enCines: true, resumen: 'cosa',
fechaLanzamiento: new Date(), poster: 'https://es.web.img2.acsta.net/pictures/18/10/03/19/36/5818625.jpg'};

  ngOnInit(): void {
  }

  guardarCambios(pelicula: peliculaCreacionDTO){
    console.log(pelicula);
  }

}

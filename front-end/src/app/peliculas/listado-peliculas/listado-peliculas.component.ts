import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-listado-peliculas',
  templateUrl: './listado-peliculas.component.html',
  styleUrls: ['./listado-peliculas.component.css']
})
export class ListadoPeliculasComponent implements OnInit {

  constructor() { }
  @Input()
  Peliculas: any;

  ngOnInit(): void {
  }

  remover(indicePelicula: number): void{
    this.Peliculas.splice(indicePelicula, 1);
  }

}

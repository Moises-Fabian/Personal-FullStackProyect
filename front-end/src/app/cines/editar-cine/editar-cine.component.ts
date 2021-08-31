import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { parsearErroresAPI } from 'src/app/utilidades/utilidades';
import { cineCreacionDTO, cineDTO } from '../cine';
import { CinesService } from '../cines.service';

@Component({
  selector: 'app-editar-cine',
  templateUrl: './editar-cine.component.html',
  styleUrls: ['./editar-cine.component.css']
})
export class EditarCineComponent implements OnInit {

  constructor(private router: Router,
    private cinesService: CinesService,
    private activedRoute: ActivatedRoute) { }

  modelo!: cineDTO;
  errores: string[] = [];

  ngOnInit(): void {
    this.activedRoute.params.subscribe((params) => {
      this.cinesService.obtenerPorId(params.id)
      .subscribe(cine => {
        this.modelo = cine;
      }, () => this.router.navigate(['/cines']))
    });
  }



  guardarCambios(cine: cineCreacionDTO){
    this.cinesService.editar(this.modelo.id, cine)
    .subscribe(() => {
      this.router.navigate(['/cines']);
    }, error => this.errores = parsearErroresAPI(error))
  }

}

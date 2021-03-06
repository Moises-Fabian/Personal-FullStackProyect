import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { actorPeliculaDTO } from 'src/app/actores/actor';
import { multipleSelectorModel } from 'src/app/utilidades/selector-multiple/multipleSelectorModule';
import { peliculaCreacionDTO, peliculaDTO } from '../pelicula';

@Component({
  selector: 'app-formulario-pelicula',
  templateUrl: './formulario-pelicula.component.html',
  styleUrls: ['./formulario-pelicula.component.css']
})
export class FormularioPeliculaComponent implements OnInit {

  constructor(private fromBuilder: FormBuilder) { }

  form!: FormGroup;

  @Input()
  errores: string[] = [];

  @Input()
  modelo!: peliculaDTO;

  @Output()
  OnSubmit: EventEmitter<peliculaCreacionDTO> = new EventEmitter<peliculaCreacionDTO>();

  @Input()
  generosNoSeleccionados: multipleSelectorModel[] = [];

  generosSeleccionados: multipleSelectorModel[] = [];

  @Input()
  cinesNoSeleccionados: multipleSelectorModel[] = []

  cinesSeleccionados: multipleSelectorModel[] = [];

  @Input()
  actoresSeleccionados: actorPeliculaDTO[] = [];

  ngOnInit(): void {
    this.form = this.fromBuilder.group({
      titulo: [
        '',
        {
          validators: [Validators.required]
        }
      ],
      resumen: '',
      enCines: false,
      trailer: '',
      fechaLanzamiento: '',
      poster: '',
      generosIds: '',
      cinesIds:'',
      actores: ''
    });

    if (this.modelo !== undefined) {
      this.form.patchValue(this.modelo);
    }
  }

  guardarCambios(){
    console.log(this.generosSeleccionados);
    const generosIds = this.generosSeleccionados.map(val => val.llave);
    this.form.get('generosIds')?.setValue(generosIds);

    const cinesIds = this.cinesSeleccionados.map(val => val.llave);
    this.form.get('cinesIds')?.setValue(cinesIds);

    const actores = this.actoresSeleccionados.map(val => {
      return {id: val.id, personaje: val.personaje}
    });

    this.form.get('actores')?.setValue(actores);

    this.OnSubmit.emit(this.form.value);
  }

  archivoSeleccionado(archivo: File){
    this.form.get('poster')?.setValue(archivo);
  }

  changeMarkdown(texto: any){
    this.form.get('resumen')?.setValue(texto);
  }
}

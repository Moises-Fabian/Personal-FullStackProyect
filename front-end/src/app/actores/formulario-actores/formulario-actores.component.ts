import { Component, OnInit, Output, EventEmitter, Input} from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { actorCreacionDTO, actorDTO } from '../actor';

@Component({
  selector: 'app-formulario-actores',
  templateUrl: './formulario-actores.component.html',
  styleUrls: ['./formulario-actores.component.css']
})
export class FormularioActoresComponent implements OnInit {

  constructor(private formBuilder: FormBuilder) { }

  form!: FormGroup;

  @Input()
  modelo!: actorDTO;

  @Input()
  errores: string[] = [];

  @Output()
  OnSubmit: EventEmitter<actorCreacionDTO> = new EventEmitter<actorCreacionDTO>();

  imagenCambiada = false;

  ngOnInit(): void {
    this.form = this.formBuilder.group({
      nombre: [
        '',
        {
          validators: [Validators.required],
        },
      ],
      fechaNacimiento: '',
      foto: '',
      briografia: ''

    });

    if (this.modelo !== undefined) {
      this.form.patchValue(this.modelo);
    }
  }

  onSubmit(){
    if (!this.imagenCambiada) {
      this.form.patchValue({'foto': null});
    }
    this.OnSubmit.emit(this.form.value);
  }

  archivoSeleccionado(file: any){
    this.imagenCambiada = true;
    this.form.get('foto')?.setValue(file);
  }

  cambioMarkdown(texto: string){
    this.form.get('briografia')?.setValue(texto);
  }
}
import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { tobase64 } from '../utilidades';

@Component({
  selector: 'app-input-img',
  templateUrl: './input-img.component.html',
  styleUrls: ['./input-img.component.css']
})
export class InputImgComponent implements OnInit {

  constructor() { }

  imagenBase64!: string;

  @Input()
  urlImagenActual: string | undefined;

  @Output()
  archivosSeleccionado: EventEmitter<File> = new EventEmitter<File>();

  ngOnInit(): void {
  }

  change(event: any){
    if (event.target.files.length > 0) {
      const file: File = event.target.files[0];
      tobase64(file).then((value: any) => this.imagenBase64 = value)
      .catch(error => console.log(error));
      this.archivosSeleccionado.emit(file);
      this.urlImagenActual = undefined;
    }
  }

}

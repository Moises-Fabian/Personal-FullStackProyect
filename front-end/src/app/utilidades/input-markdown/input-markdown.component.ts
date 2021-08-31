import { Component, OnInit, Output, EventEmitter, Input } from '@angular/core';

@Component({
  selector: 'app-input-markdown',
  templateUrl: './input-markdown.component.html',
  styleUrls: ['./input-markdown.component.css']
})
export class InputMarkdownComponent implements OnInit {

  constructor() { }

  @Input()
  contenidoMarkdown: any;

  @Input()
  placeHolderTextarea: string = 'texto';

  @Output()
  changeMarkdown: EventEmitter<string> = new EventEmitter<string>();

  ngOnInit(): void {
  }

  OnChangeMarkdown(evento: any):void{
  const texto = evento.target.value;
  this.contenidoMarkdown = texto;
  this.changeMarkdown.emit(texto);
  console.log(texto);
  }

}

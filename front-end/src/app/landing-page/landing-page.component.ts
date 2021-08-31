import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-landing-page',
  templateUrl: './landing-page.component.html',
  styleUrls: ['./landing-page.component.css']
})
export class LandingPageComponent implements OnInit {

  ngOnInit(): void {
      this.PeliculasEnCines = [{
        titulo: 'Spiderman: far from home',
        fechaLanzamiento: new Date(),
        precio: 1990,
        poster: 'https://play-lh.googleusercontent.com/Zei0qLmw_UIfyv48C_vMbFNOaR8iduiK9qCl8xoZSi2utmtczoli0RJXyoUAYhXD_Vfz0qcdnZyxgVawRA'
      },
      {
        titulo: 'Moana',
        fechaLanzamiento: new Date('2022-02-16'),
        precio: 30990,
        poster: 'https://i.pinimg.com/originals/e0/ae/48/e0ae489f31577f6c185ee9b13f39582c.jpg'
      }];
  }

  title = 'front-end';

  PeliculasEnCines: any;
  PeliculasProximosEstrenos = [];


}

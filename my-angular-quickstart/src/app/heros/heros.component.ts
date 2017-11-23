import { Component, OnInit } from '@angular/core';
import { Hero } from '../heros';
import { HerosArr } from '../../app/mock-heros-db';

@Component({
  selector: 'app-heros',
  templateUrl: './heros.component.html',
  styleUrls: ['./heros.component.css']
})
export class HerosComponent implements OnInit {

  selectedHero: Hero;

  heroes = HerosArr;

  
  constructor() { }
  
  ngOnInit() {
  }
  
  onSelect(hero:Hero): void {
    this.selectedHero = hero;
  }
}


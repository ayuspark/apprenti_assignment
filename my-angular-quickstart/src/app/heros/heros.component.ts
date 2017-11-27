import { Component, OnInit } from '@angular/core';
import { Hero } from '../heros';
import { HerosArr } from '../../app/mock-heros-db';

// service injection
import {MyServiceService} from '../my-service.service';

@Component({
  selector: 'app-heros',
  templateUrl: './heros.component.html',
  styleUrls: ['./heros.component.css']
})
export class HerosComponent implements OnInit {
  constructor(private _myService: MyServiceService) { }

  selectedHero: Hero;
  heroes = HerosArr;

  numbers : number[] = [];
  addNumber() : void {
    this._myService.addNumber(1);
  }
  
  data: any[] = [];

  ngOnInit() {
    this.numbers = this._myService.retriveNumbers();
    this._myService.data.subscribe(
      (data) => {this.data = data}
    )
  }

  onSelect(hero:Hero): void {
    this.selectedHero = hero;
  }
}


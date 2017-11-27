import { Injectable } from '@angular/core';

@Injectable()
export class MyServiceService {
  numbers: number[] = [1, 2, 3,];

  constructor() { }

  retriveNumbers(): number[] {
    return this.numbers;
  }

  addNumber(num: number): void {
    this.numbers.push(num);
  }

}

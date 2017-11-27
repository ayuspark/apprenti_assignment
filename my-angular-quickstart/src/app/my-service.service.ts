import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
// import { HttpClient } from 'selenium-webdriver/http';
import { HttpClient } from '@angular/common/http';

@Injectable()
export class MyServiceService {
  
  // BehaviorSubject
  data : BehaviorSubject<any[]> = new BehaviorSubject([]);

  constructor(private _http:HttpClient) {
    this.retrieveData();
  }

  // updateData(newData:any): void {
  //   const tempData = this.data.getValue();
  //   tempData.push(newData);
  //   this.data.next(newData);
  // }
  
  retrieveData() : void {
    this._http.get('https://5a1ba7e606220a0012d35159.mockapi.io/data').subscribe(
      (d: any[]) => { this.data.next(d)}
    )
  }
  
  addData(newData: any) {
    this._http.post('https://5a1ba7e606220a0012d35159.mockapi.io/data', newData).subscribe(
      (resp) => { this.retrieveData }
    )
  }

  // numbers service
  numbers: number[] = [1, 2, 3,];

  retriveNumbers(): number[] {
    return this.numbers;
  }

  addNumber(num: number): void {
    this.numbers.push(num);
  }

}

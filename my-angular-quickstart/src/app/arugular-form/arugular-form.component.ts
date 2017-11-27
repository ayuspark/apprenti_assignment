import { Component, OnInit } from '@angular/core';
import { ArugularUser } from '../arugular-user';
import { NgModel } from '@angular/forms/src/directives/ng_model';

// service injection
import { MyServiceService } from '../my-service.service';

@Component({
  selector: 'app-arugular-form',
  templateUrl: './arugular-form.component.html',
  styleUrls: ['./arugular-form.component.css']
})
export class arugularFormComponent implements OnInit {
  constructor(private _myService : MyServiceService) {  }

  data : any[] = [];

  ngOnInit() {
    this._myService.data.subscribe(
      (data) => { this.data = data }
    )
  }

  submitted: boolean = false;
  user: ArugularUser = new ArugularUser("", "", "", "",);
  onSubmit(): void {
    this.submitted = true;
    console.log("New User: " +  this.user);

    // pass data to mockAPI and then update the data subscribed in HeroComponent
    this._myService.addData({
      "id": "100",
      "createdAt": 1511762273,
      "name": this.user.username,
      "imageUrl": "imageUrl 6",
      "username": "ass",
      "_password": "",
      "email": "sa",
      "address": "",
      "password": "0000"
    },);
  }

  numbers : number[] = this._myService.retriveNumbers();

}

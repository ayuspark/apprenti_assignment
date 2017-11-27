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
export class arugularFormComponent {
  constructor(private _myService : MyServiceService) {  }

  submitted: boolean = false;
  user: ArugularUser = new ArugularUser("", "", "", "",);
  onSubmit(): void {
    this.submitted = true;
    console.log("New User: " +  this.user);
  }

  numbers : number[] = this._myService.retriveNumbers();

}

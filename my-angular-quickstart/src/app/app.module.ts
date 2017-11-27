import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';


import { AppComponent } from './app.component';
import { HerosComponent } from './heros/heros.component';
import { FormsModule } from '@angular/forms';
import { HeroDetailComponent } from './hero-detail/hero-detail.component';
import { arugularFormComponent } from './arugular-form/arugular-form.component';

import { MyServiceService } from './my-service.service'



@NgModule({
  declarations: [
    AppComponent,
    HerosComponent,
    HeroDetailComponent,
    arugularFormComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
  ],
  providers: [MyServiceService],
  bootstrap: [AppComponent]
})
export class AppModule { }

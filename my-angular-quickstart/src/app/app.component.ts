import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser/src/browser';
import { ngModuleJitUrl } from '@angular/compiler';
import { NgModel } from '@angular/forms/src/directives/ng_model';
import { NgModule } from '@angular/core/src/metadata/ng_module';

import { RGBcolor } from '../app/rgbColor';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})

export class AppComponent {
  title = 'Ma First Arugular App!';
  numberOfDivs = stringifyRGB();
}

function generateColor(): RGBcolor[]{
  let colorArr: RGBcolor[] = [];
  for (let i: number = 0; i < 20; i++) {
    let rgb: RGBcolor;

    // TODO: WHY it no work!
    // rgb.r = Math.floor(Math.random() * (255 - 0 + 1));
    // rgb.g = Math.floor(Math.random() * (255 - 0 + 1));
    // rgb.b = Math.floor(Math.random() * (255 - 0 + 1));

    rgb = {
      r: Math.floor(Math.random() * (255 - 0 + 1)),
      g: Math.floor(Math.random() * (255 - 0 + 1)),
      b: Math.floor(Math.random() * (255 - 0 + 1)),
    }

    colorArr.push(rgb);
  }
  return colorArr;
}

const colorArr = generateColor();

function stringifyRGB(): any[]{
  let rgbStringArr: string[] = [];
  for(let i = 0; i < colorArr.length; i++)
  {
    let rgbString : string = "";
    rgbString = "rgb(" + colorArr[i].r + "," + colorArr[i].g + "," + colorArr[i].b + ")"; 
    rgbStringArr.push(rgbString);
  }
  return rgbStringArr;
}

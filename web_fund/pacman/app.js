'use strict';
var world = [];
function createWorldArray(){
  var rowNumber = Math.floor((window.innerHeight - 200)/20);
  console.log(rowNumber, window.innerHeight);
  var colNumber = Math.floor((window.innerWidth - 200)/20);
  console.log(colNumber, window.innerWidth);

  for(let j = 0; j < rowNumber; j++){
    var rowInWorld = new Array(colNumber);
    for(let i = 0; i < colNumber; i++){
      rowInWorld[i] = Math.floor(Math.random() * 2);
      if(j > 1 && i > 0 && j < rowNumber - 1 && i < colNumber - 1){
        if(rowInWorld[i] === 1 && world[j - 1][i] === 0 && rowInWorld[i - 1] === 0){
          world[j - 1][i - 1] = 1;
          world[j - 1][i] = 1;
          world[j - 1][i + 1] = 1;
          rowInWorld[i - 1] = 1;
          rowInWorld[i + 1] = 1;
          continue;
        }
      }
    }
    world.push(rowInWorld);
  }
  //create borders
  world.forEach(function(val){
    val[0] = 0;
    val[val.length - 1] = 0;
  })
  world[0].fill(0);
  world[world.length - 1].fill(0);
  world[1][1] = 1; //leave space for pacman
  // console.table(world);
}

function displayWorld(){
  document.getElementById('world_container').style.width = (window.innerWidth - 200) + 'px';

  for(let j = 0; j < world.length; j++){
    for(let i = 0; i < world[j].length; i++){
      var div = document.createElement('div');
      var br = document.createElement('br');
      if(world[j][i] === 0){
        div.setAttribute('class', 'brick');
      } else {
        div.setAttribute('class', 'coin');
      }
      document.getElementById('world_container').appendChild(div);
      if(i === world[j].length - 1){
        document.getElementById('world_container').appendChild(br);
      }
    }
  }
}

function Pacman(x, y){
  this.x = x;
  this.y = y;
}

function displayPacman(x, y){
  var pacmanDiv = document.createElement('div');
  pacmanDiv.setAttribute('id', 'pacman');
  document.getElementById('world_container').appendChild(pacmanDiv);
  pacmanDiv.style.top = y * 1.25 + 'rem';
  pacmanDiv.style.left = x * 1.25 + 'rem';
}

createWorldArray();
displayWorld();
var pacman1 = new Pacman(1, 1);
displayPacman(pacman1.x, pacman1.y);

'use strict';
var world = [];
function createWorldArray(){
  var rowNumber = Math.floor((window.innerHeight - 200)/20);
  console.log(rowNumber, window.innerHeight);
  var colNumber = Math.floor((window.innerWidth - 200)/20);
  console.log(colNumber, window.innerWidth);
  rowInWorld = new Array(colNumber).fill(0);
  world.push(rowInWorld); //top border of game field

  for(let j = 1; j < rowNumber - 1; j++){
    var rowInWorld = new Array(colNumber);
    rowInWorld[0] = 0;
    rowInWorld[colNumber - 1] = 0;
    for(let i = 1; i < colNumber - 1; i++){
      var surrounding = [];
      rowInWorld[i] = Math.floor(Math.random() * 2);
      if(j > 2 && i > 2){
        // surrounding.push(rowInWorld[i - 1]);
        // surrounding.push(rowInWorld[i - 2]);
        surrounding.push(world[j - 1][i]);
        // surrounding.push(world[j - 1][i - 1]);
        surrounding.push(world[j - 1][i + 1]);
        console.log(surrounding);
      }
      if(j > 1){
        var count = 0;
        surrounding.forEach(function(val){
          if(val === 0){
            count++;
          }
        });
        if(count > 1){
          rowInWorld[i] = 1;
          // rowInWorld[i - 1] = 1;
          world[j - 1][i - 1] = 1;

        }
      }
    }
    world.push(rowInWorld);
  }
  rowInWorld = new Array(colNumber).fill(0);
  world.push(rowInWorld);//bottom border of game field
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
      // if(i === world[j].length - 1){
      //   document.getElementById('world_container').appendChild(br);
      // }
    }
  }
}

createWorldArray();
displayWorld();

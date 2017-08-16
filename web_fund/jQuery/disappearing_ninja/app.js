'use strict';
$(function() {
  console.log( "ready!" );
  var imgString = '';
  for(var i = 0; i < 8; i++){
    imgString += '<img src=\"https://pbs.twimg.com/profile_images/2370446440/6e2jwf7ztbr5t1yjq4c5.jpeg\" alt=\"nyan cat\">';
  };
  $('div').append(imgString);
  
  var $allImg = $('img');
  $('img').click(function () {
    $(this).css('border', '2px solid gold');
    $allImg.not(this).css('filter', 'grayscale(0.7)');
    $(this).fadeOut(3000);
    setTimeout(function(){
      $allImg.css('filter', '');
    }, 3000);
  });

  $('button').click(function () {
    $('img').show();
  });
});

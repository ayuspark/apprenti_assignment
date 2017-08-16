'use strict';

$( document ).ready(function() {
  $('img').attr('alt', $('img').attr('src'));

  $('img').click(function(){
    var $newSrc = $(this).attr('data-alt-src');
    console.log($newSrc);
    $(this).fadeOut(1000, function(){
      $(this).attr('src', $newSrc);
      $(this).attr('alt', $(this).attr('src'));
    })
    .fadeIn(1000);
  });
});

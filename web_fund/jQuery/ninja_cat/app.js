'use strict';

$( document ).ready(function() {
  $('img').attr('alt', $('img').attr('src'));

  $('img').click(function(){
    var $newSrc = $(this).attr('data-alt-src');
    console.log($newSrc);
    $(this).attr('src', $newSrc);
    $(this).attr('alt', $(this).attr('src'));
    $(this).fadeIn(3000);
  });
});

'use strict';

$(document).ready(function(){
  $('#add_class').click(function(){
    $('#add_class ~ p').addClass('redClass');
  });

  $('#slide_toggle').click(function(){
    $('#slide_toggle ~ p').before('<img src=\'https://media4.s-nbcnews.com/j/newscms/2016_36/1685951/ss-160826-twip-05_8cf6d4cb83758449fd400c7c3d71aa1f.nbcnews-ux-2880-1000.jpg\' alt=\'panda\' />');
  })
  .click(function(){
    $('#slide_toggle ~ p').remove();
  });

  $('#append').click(function(){
    $('#append ~ p').append('<p>This is the new paragraph!</p>');
  });

  $('#slide_down ~ img').hide();
  $('#slide_down').click(function(){
    if($('#slide_down ~ img').is(':hidden')){
      $('#slide_down ~ img').slideDown('slow');
    } else {
      $('#slide_down ~ img').slideUp('3000');
    }
  });

  $('#fade ~ img').hide();
  $('#fade').click(function(){
    if($('#fade ~ img').is(':hidden')){
      $('#fade ~ img').fadeIn('4000');
    } else {
      $('#fade ~ img').fadeOut('5000');
    }
  });



});

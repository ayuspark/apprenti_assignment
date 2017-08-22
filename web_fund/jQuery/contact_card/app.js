'use strict';
console.log($);

$(document).ready(function(){
  $('#add').on('click', function(e){
    e.preventDefault();
    var name = '';
    var desc = '';
    $('#user input').each(function(){
      name += ($(this).val() + ' ');
    })
    desc = $('#user textarea').val();
    var card_front = document.createElement('div');
    var card_back = document.createElement('div');
    $(card_front).attr('id', $('#user input:first-child').val());
    $(card_front).append('<h2>' + name + '</h2>').append('<p>Click for description</p>');
    $('.contact_cards').append(card_front);

    $(card_back).attr('id', $(card_front).attr('id') + '_back');
    $(card_back).append('<p>' + desc + '</p>');
    $('.contact_cards').append(card_back);
    $(card_back).hide();
  })

  $('.contact_cards').on('click', 'div', function(e){
    console.log(e.target);
    if($("div[id~='back']")){
      $(this).hide();
      $(this).prev().show();
    }
    // else {
    //   $(this).hide();
    //   $(this).next().show();
    // }
    var cardID = $(this).attr('id')
    console.log(cardID);
    $(this).hide();
    cardID += '_back';
    console.log(cardID);
    $('#'+cardID).show();
  })

})

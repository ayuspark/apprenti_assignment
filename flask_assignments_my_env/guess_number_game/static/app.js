$(function(){
    console.log('ready!')
    $('form').on('submit', function(){
        var guess = $('input:first-child').val()
        $.ajax({
            type: 'POST',
            contentType: 'application/JSON',
            url: '/',
            dataType: 'json',
            data: JSON.stringify(guess),
            success: function(result){
                $('#hint').append('<h2>' + result + '</h2>')
            }
        })
    })


})
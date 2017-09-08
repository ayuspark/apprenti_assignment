$(function(){
    console.log('ready!')
    $('form').on('submit', function(e){
        e.preventDefault();
        var guess = $('input:first-of-type').val()
        console.log(guess)
        $.post('/process', $('form').serialize(), function(result){
            $('#hint').empty().append('<h2>' + result + '</h2>')
        })
    })
})
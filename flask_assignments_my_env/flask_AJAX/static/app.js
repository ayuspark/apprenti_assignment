function pick_src(data){
    var src = {
        'red': 'https://goo.gl/ZErms6',
        'black': 'https://goo.gl/5CYrCU',
        'brown': 'https://goo.gl/ahg5Fc'
    }
    return src[data].toString()
}

$(function () {
    console.log("ready!");
    var color = '';
    // var data = []
    $('button').on('click', function(e){
        color = e.target.id;
        var data = {'color': color}
        console.log(JSON.stringify(data));
        $.ajax({
            type: 'POST',
            contentType: 'application/json',
            url: '/',
            dataType: 'json',
            data: JSON.stringify(data),
            success: function (result) {
                console.log('result is', result);
                $('.imgs').empty().append('<img src=\'' + pick_src(result) + '\'/ >')
            }
        });
    })
});

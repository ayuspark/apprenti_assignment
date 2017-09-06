$(function () {
    console.log("ready!");
    var color = '';
    var data = []
    $('button').on('click', function(e){
        color = e.target.id;
        data = [{'color': color}]
        console.log(data);
        $.post('/', JSON.stringify(data));
    })
});

// var counter = 0;
// $(function(){
//     console.log('ready')
//     counter++;
//     console.log('from the load', counter)
//     $.ajax({
//         type: 'POST',
//         contentType: 'application/json',
//         url: '/',
//         dataType: 'json',
//         data: JSON.stringify({'counter': counter}),
//         success: function(result){
//             console.log('counter:', result)
//             $('h2').text(result + ' times!')
//         }
//     })
// })
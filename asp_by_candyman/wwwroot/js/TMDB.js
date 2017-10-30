'use strict';
$(function(){
    console.log("ready from movie page!");

    $("#search_form").on('submit', function(e){
        e.preventDefault();
        $.ajax({
            url: "/movies/search",
            method: "post",
            data: $(this).serialize(),
            success: function (resp) {
                $("#search_result").append(resp);
            }
        })
    })
})
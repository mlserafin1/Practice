$(document).ready(function() {


    $('#green').css('background-color', 'green');
    $('#blue').css('background-color', '#0abab5');
    $(document).on('click', '#hideButton', function() {
        $('#firstHide').toggle('slow');
    })


});
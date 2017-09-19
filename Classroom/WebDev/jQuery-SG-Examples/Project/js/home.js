$('#emptyDiv').append('p').text('A new paragraph of text...');
//$('div').css({ 'width': '400', 'background-color': 'CornflowerBlue' });
$('#add-button').addClass('btn btn-default');
$("#toggleH1s").on("click", function () {
    $("h1").toggle("slow");
})
$("div").hover(
    // in callback
    function () {
        $(this).css("background-color", "CornflowerBlue");
    },
    // out callback
    function () {
        $(this).css("background-color", "");
    }
);
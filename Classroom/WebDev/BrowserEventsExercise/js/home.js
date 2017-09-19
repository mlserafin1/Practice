$(document).ready(function () {
    
$("#akronInfoDiv").hide();
$("#akronWeather").hide();
$("#minneapolisInfoDiv").hide();
$("#minneapolisWeather").hide();
$("#louisvilleInfoDiv").hide();
$("#louisvilleWeather").hide();
$("#mainButton").on("click", function () {
    $("#mainInfoDiv").toggle('slow');
})
$(document).on("click","#akronButton", function () {
    $("#akronInfoDiv").toggle('slow');
})
$(document).on("click","#minneapolisButton", function () {
    $("#minneapolisInfoDiv").toggle('slow');
})
$(document).on("click","#louisvilleButton", function () {
    $("#louisvilleInfoDiv").toggle('slow');
})
$(document).on("click","#akronWeatherButton", function () {
    $("#akronWeather").toggle('slow');
})
$(document).on("click","#minneapolisWeatherButton", function () {
    $("#minneapolisWeather").toggle('slow');
})
$(document).on("click","#louisvilleWeatherButton", function () {
    $("#louisvilleWeather").toggle('slow');
})
$("tr").hover(
    // in callback
    function () {
        $(this).css("background-color", "WhiteSmoke");
    },
    // out callback
    function () {
        $(this).css("background-color", "");
    }
);


});
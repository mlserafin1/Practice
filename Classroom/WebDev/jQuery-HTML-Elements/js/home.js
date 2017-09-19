$(document).ready(function () {
$( "#yellowHeading" ).replaceWith( "<h2 id=yellowHeading>Yellow Team</h2>" );
$('h1').css('text-align', 'center');
$('h2').css('text-align', 'center');
$('h1').removeClass('myBannerHeading');
$('h1').addClass('page-header');
$('.orange').css('background-color' , 'orange');
$('.blue').css('background-color' , 'blue');
$('.yellow').css('background-color' , 'yellow');
$('.red').css('background-color' , 'red');
$('#yellowTeamList').append('<li>Joseph Banks</li>');
$('#yellowTeamList').append('<li>Simon Jones</li>');
$('#oops').hide();
$('#footerPlaceholder').remove();
//$('.col-md-6').hide().fadeIn(1500);
$('#footer').append('<p text-align: center; font-family: Courier; font-size: 15px;>Test Name anyname@gmail.com</p>');



    
});//end ready
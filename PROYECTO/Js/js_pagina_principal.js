

	//Estilo al nav
	$(".direccion").hover(
		function(){
			$(this).css("color", "red");
		},
		function(){
			$(this).css("color", "black");
		}
);


	//Efecto a las portadas con un sombreado
	$(".portada").hover(
		function(){
			$(this).css("box-shadow", "1px 1px 5px 1px gray");
			$(this).find("figcaption").css("opacity", "1");	
		},
		function(){
			$(this).css("box-shadow", "none");
			$(this).find("figcaption").css("opacity", "0");
		}

	);


	
	
$(document).ready(function () {
	
	$('#carrusel').slick({
		autoplay: true, 
		autoplaySpeed: 2000, 
		dots: false,
		arrows: false 
	});
	
	$("#retroceder").click(function () {
		$('#carrusel').slick('slickPrev');
	});


	$("#avanzar").click(function () {
		$('#carrusel').slick('slickNext');
	});

});

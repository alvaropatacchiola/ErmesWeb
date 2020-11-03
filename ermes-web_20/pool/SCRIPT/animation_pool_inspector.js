// JavaScript Document



		//$(document).ready(function() {
//            var $body = $('body');
//
//            var setBodyScale = function() {
//                var scaleSource = $body.width(),
//                    scaleFactor = 0.35,                     
//                    maxScale = 300,
//                    minScale = 150;
//				
//				var fontSize = 1000 - scaleSource;
//
//                if (fontSize > maxScale) fontSize = maxScale;
//                if (fontSize < minScale) fontSize = minScale;
//
//                $('.outer').css('font-size', fontSize + '%');
//            }
//
//            $(window).resize(function(){
//                setBodyScale();
//            });
//
//            setBodyScale();
//		});
		
	
		$(document).ready(function() {
			
			var secondi=1;
//			var num=0
			function CambiaSfumatura() {
				var sfumatura=new Array();
				sfumatura[0]='sfondo_all_good';
				sfumatura[1]='sfondo_not_good';
				sfumatura[2]='sfondo_bad';
	
				
				setTimeout(function(){
					$("#page_body").removeClass().addClass(sfumatura[0]);
					
					$("svg #changecolor_arrowleft").removeClass().addClass("st1arrow_g");
					$("svg #changecolor_arrowright").removeClass().addClass("st1arrow_g");
					
					$("#good_smile").css("display","block");
					$("#notgood_smile").css("display","none");
					$("#bad_smile").css("display","none");
					}, 0); 
			
				setTimeout(function(){
					$("#page_body").removeClass().addClass(sfumatura[1]);
					
					$("svg #changecolor_arrowleft").removeClass().addClass("st1arrow_o");
					$("svg #changecolor_arrowright").removeClass().addClass("st1arrow_o");
					
					$("#good_smile").css("display","none");
					$("#notgood_smile").css("display","block");
					$("#bad_smile").css("display","none");
					}, 12000);
				
				setTimeout(function(){
					$("#page_body").removeClass().addClass(sfumatura[2]);
					
					$("svg #changecolor_arrowleft").removeClass().addClass("st1arrow_r");
					$("svg #changecolor_arrowright").removeClass().addClass("st1arrow_r");
					
					$("#good_smile").css("display","none");
					$("#notgood_smile").css("display","none");
					$("#bad_smile").css("display","block");
					}, 24000); 
				}
			
			
			CambiaSfumatura();
			setInterval(CambiaSfumatura,secondi*36000);
			});
	

		
		$(document).ready(function() {

			$(window).scroll(function() {

			var smile = $(".smile_content");
			var smileSize = $(".smile_content").height();
			var scrollUp = $(window).scrollTop();
			var pagePosition = $(".changepool_content").outerHeight();
			var ex_pP_px = 40 + "px";
			var ex_pP_vh = 10 + "vh";

			  if (scrollUp >= pagePosition) {
				  $(".outer").css({
					  "margin-top" : pagePosition + smileSize});
				  $(".smileface").css({
					  "margin-top" : 0});
				
				smile.css({
					  "position" : "fixed",
					  "top" : 0
				});
				  
			  } else {
				  $(".outer").css({
					  "margin-top" : ""});
				  $(".smileface").css({
					  "margin-top" : "calc(25% + 10vh + 40px)"});
				  
				  smile.css({
					  "position" : "",
					  "top" : ""
				  });
			  }	
			}).scroll();
			
			var pagePosition = $(".changepool_content").outerHeight();
			alert("la mia grandezza è:" + pagePosition);

		});







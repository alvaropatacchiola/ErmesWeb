// JavaScript Document
//alvaro patacchiola
var swpIndMax = 0;
var swpLindex = 1;
//end alvaro patacchiola


// ***HIDE JQUERY UI LOADER***
	
			$(function(){
				$("div.ui-loader").css("display","none");
				
				setInterval(function(){
					$("div.ui-page").css({"margin-top":-40});
					$("body.ui-pagecontainer").css({"margin-top":-40});
				}, 1);
				
				var topBody = $("body.ui-pagecontainer").offset().top;
				var topPage = $("div.ui-page").offset().top;
				
				/*setInterval(function(){
					alert("topBody: " + topBody + "   " + "topPage: " + topPage);
				}, 15000);*/
				
			});

			
			/*function Myalert() {
				var poolInfo_contentTOP = $("#poolInfo_content").offset().top;
				var navbarHeight = $(".navbar").outerHeight();
				var scrollUp = $(window).scrollTop();
				var real_pagePosition = $(window).innerHeight();
				
				var poolInfo_contentHide = poolInfo_contentTOP - scrollUp - navbarHeight;
				
				   alert("poolInfo_contentTOP: " + poolInfo_contentTOP + "\n" + "navbarHeight: " + navbarHeight + "\n" + "scrollUp: " + scrollUp + "\n" + "real_pagePosition: " + real_pagePosition + "\n" + "\n" + "0 > " + poolInfo_contentHide);
			}
			
			setInterval(Myalert, 5000);*/
//			_______
			
			/*$(document).ready(function(){
				
			var pIW_1 = $("#pIW_2").outerHeight();
	
				setTimeout(function(){
					alert(pIW_1);
				}, 5000);
				
			});*/
			

// ***MY SCRIPT***
			function resolutionAdjust()
			{
			    /* RESOLUTION ADJUST (inserire nel codice) */

			    /*START RULE --> <meta name="viewport" content="width=device-width, height=device-height, initial-scale=1.0, user-scalable=0, minimum-scale=1.0, maximum-scale=1.0">*/

			    var viewport = $('meta[name="viewport"]');

			    if ($(window).innerWidth() < 1280) {

			        viewport.attr("content", "width=device-width, height=device-height, initial-scale=1.0, user-scalable=0, minimum-scale=1.0, maximum-scale=1.0");

			    } else if ($(window).outerWidth() >= 1280 && $(window).outerWidth() < 1920 && $(window).outerHeight() <= 720) {

			        viewport.attr("content", "width=1920, initial-scale=0.66, user-scalable=0, minimum-scale=0.66, maximum-scale=0.66");

			    } else if ($(window).outerWidth() >= 1920 && $(window).outerWidth() < 3840 && $(window).outerHeight() <= 2160) {

			        viewport.attr("content", "width=1920, initial-scale=1, user-scalable=0, minimum-scale=1, maximum-scale=1");

			    } else if ($(window).outerWidth() >= 3840 && $(window).outerWidth() < 7680 && $(window).outerHeight() <= 4320) {

			        viewport.attr("content", "width=1920, initial-scale=2, user-scalable=0, minimum-scale=2, maximum-scale=2");

			    } else if ($(window).outerWidth() >= 7680) {

			        viewport.attr("content", "width=1920, initial-scale=4, user-scalable=0, minimum-scale=4, maximum-scale=4");

			    }

			    //__________________ Fine RESOLUTION ADJUST
			}

// alvaro patacchiola
//$(document).ready(function() {
			function activateAll() {
			    //end alvaro patacchiola
			    resolutionAdjust();
			    sizeFirst(true);

			    //startScrolling();

			    $("#pN_1").css("display", "none");
			    $("#pS_1").css("display", "none");
			    $("#pS_2").removeClass("pool_status_margin");
			    
			    // alvaro patacchiola
			    //var swpIndMax = $("div.poolname_list").length;
			    swpIndMax = $("div.poolname_list").length;
			    //la variabile va definita globale altrimenti non la posso inizializzare
			    // end alvaro patacchiola
			    if (swpLindex < 1) swpLindex = swpIndMax;
			    if (swpLindex > swpIndMax) swpLindex = 1;

			    console.log("inizializzao:" + swpIndMax)

			    //			setInterval(function(){
			    //					alert("swpLindex: " + swpLindex + "\n" + "swpIndMax: " + swpIndMax);
			    //				}, 5000);
			    //			alert("swpLindex: " + swpLindex + "\n" +  "swpIndMax: " + swpIndMax);


			    //***MENU SIZE***


			    var pN = 1;
			    var pS = 1;
			    var pIW = 1;

			    $("div.poolname_list").each(function () {
			        $(this).attr('id', 'pN_' + pN);
			        $(this).attr('poolstatus', 'ind' + pN);
			        pN++;
			    });

			    $("div.pool_status").each(function () {
			        $(this).attr('id', 'pS_' + pS);
			        $(this).attr('poolstatus', 'ind' + pS);
			        pS++;
			    });

			    $("div.poolInfo_wrapper").each(function () {
			        $(this).attr('id', 'pIW_' + pIW);
			        $(this).attr('infoname', 'pIW_' + pIW);
			        pIW++;
			    });


			    var menuName = setInterval(function () {
			        $("#poolname").attr('poolname', $("#poolname").text());
			    }, 1);

			    var liName = $("div.poolname_list").each(function () {
			        $(this).attr('poolname', $(this).text());
			        //numLi++;
			    });

			    var attrMenuName = $("#poolname").attr('poolname');
			    var attrLiName = $("div.poolname_list").attr('poolname');
			    var attrMenuNameTxt = $("#poolname").text();
			    var attrLiNameTxt = $("div.poolname_list").text();
			    var findObj = attrLiName.indexOf(attrMenuName) + 1;



			    var elemPoolList = ($("div.poolname_list").length) - 1;
			    var elemPoolListMargin = elemPoolList;


			    if (elemPoolList == 0) {
			        $("#more_1_nav").css("display", "none");
			    }

			    setInterval(function () {
			        $(".pool_menu_overlay").css("padding-top", "calc(50vh - (((var(--laberl_li_size-plusborder) *" + elemPoolList + ") + (var(--poolname_li_margin) *" + elemPoolListMargin + ")) / 2))");
			    }, 1);

			    //setInterval(function(){
			    //						alert("attrMenuName: " + attrMenuName + "\n" + "attrLiName: " + attrLiName + "\n" + "attrMenuNameTxt: " + attrMenuNameTxt + "\n" + "attrLiNameTxt: " + attrLiNameTxt + "\n" + "findObj: " + findObj);
			    //					}, 5000);


			    // ***CHECK ROUTINE***

			    //var secondi=1;
			    //	
			    //			function CambiaSfumatura() {
			    //				var sfumatura = new Array();
			    //				sfumatura[0] = 'sfondo_all_good';
			    //				sfumatura[1] = 'sfondo_not_good';
			    //				sfumatura[2] = 'sfondo_bad';
			    //				
			    //				Piscina[0] = "Piscina 1";
			    //				Piscina[1] = "Piscina 2";
			    //				Piscina[2] = "Piscina 3";
			    //				
			    //				setTimeout(function(){
			    //					$("body").removeClass().addClass(sfumatura[0]);
			    //					$("svg#smile_good").css("display","block");
			    //					$("svg#smile_notGood").css("display","none");
			    //					$("svg#smile_bad").css("display","none");
			    //					$(".color_path1").css("fill","rgba(39,172,58,1.00)");
			    //					/*$(".poolname").text(Piscina[0]);*/
			    //					}, 0); 
			    //			
			    //				setTimeout(function(){
			    //					$("body").removeClass().addClass(sfumatura[1]);
			    //					$("svg#smile_good").css("display","none");
			    //					$("svg#smile_notGood").css("display","block");
			    //					$("svg#smile_bad").css("display","none");
			    //					$(".color_path1").css("fill","rgba(255,119,0,1.00)");
			    //					/*$(".poolname").text(Piscina[1]);*/
			    //					}, 12000);
			    //				
			    //				setTimeout(function(){
			    //					$("body").removeClass().addClass(sfumatura[2]);
			    //					$("svg#smile_good").css("display","none");
			    //					$("svg#smile_notGood").css("display","none");
			    //					$("svg#smile_bad").css("display","block");
			    //					$(".color_path1").css("fill","rgba(234,0,41,1.00)");
			    //					/*$(".poolname").text(Piscina[2]);*/
			    //					}, 24000); 
			    //			}
			    //			
			    //			CambiaSfumatura();
			    //			setInterval(CambiaSfumatura , secondi * 36000);



			    // ***MORE / CLOSE AUTO HOVER***



			    //			autoHover()
			    //			setInterval(autoHover , 10000);


			    // ***SMILE AUTO BOUNCE***

			    function smileBounce() {

			        var smileHeigh = $(".smile_cont" ).height() ;
			        var smileB_index = (smileHeigh * 0.002) + 'vh';
			        var smileB_index2 = ((smileHeigh * 0.002) * 2) + 'vh' ;


					
			        $(".smile_cont")
                        .animate({
                            top: "-=" + smileB_index,
                        }, {
                            duration: 500,
                            easing: "linear"
                        })
                        .animate({
                            top: "+=" + smileB_index2 ,
                        }, {
                            duration: 1000,
                            easing: "linear"
                        })
                        .animate({
                            top: "-=" + smileB_index,
                        }, {
                            duration: 500,
                            easing: "linear"
                        });
			    }
				//if (appStatus == "1")
				//		$('.smile_cont').css('margin', '20px 0');	
				//else
					$('.smile_cont').css('margin', '-40px 0');	
			    smileBounce()
			    setInterval(smileBounce, 2000);


			    // ***SCROLL FUNCTIONS (SMARTPHONE)***
			    if (($(window).innerHeight() > $(window).innerWidth()) && ($(window).innerWidth() < 600)) {
			    $(window).scroll(function () {

			        var smile = $(".smile_cont");
			        var swipeUp = $(".swipeUp");
			        var blackBG = $("#BG_blackOverlay");
					var blackDOT = $(".dot_inside");
			        var scrollUp = $(window).scrollTop();
			        var pagePosition = ($(window).innerHeight() / 20);
			        var opacityEffect = 1 - ($(window).scrollTop() * 0.01);
			        var noOpacityEffect = ($(window).scrollTop() * 0.01);
			        var minOpacity = 0;
			        var opacityBlackBG = $(window).scrollTop() * 0.01;
			        var maxOpacity = 1;

			        var poolInfo_contentTOP = $(".poolInfo_wrapper").offset().top;
			        var navbarHeight = $(".navbar").outerHeight();
			        var poolInfo_wrapper = $(".poolInfo_wrapper");
			        var poolInfo_content = $("#poolInfo_content");
			        var poolInfo_contentHide = poolInfo_contentTOP - scrollUp - navbarHeight + 20;

			        var pIW = new Array();
			        pIW[0] = $("#pIW_1");
			        pIW[1] = $("#pIW_2");
			        pIW[2] = $("#pIW_3");
			        pIW[3] = $("#pIW_4");
			        pIW[4] = $("#pIW_5");
			        pIW[5] = $("#pIW_6");
			        pIW[6] = $("#pIW_7");
			        pIW[7] = $("#pIW_8");
			        var pIWSize = new Array();
			        var indiceSize =0;
			       /* var pIW_1 = $("#pIW_1").outerHeight() + 40;
			        var pIW_2 = $("#pIW_2").outerHeight() + 40;
			        var pIW_3 = $("#pIW_3").outerHeight() + 40;
			        var pIW_4 = $("#pIW_4").outerHeight() + 40;
			        var pIW_5 = $("#pIW_5").outerHeight() + 40;
			        var pIW_5 = $("#pIW_6").outerHeight() + 40;
			        var pIW_5 = $("#pIW_7").outerHeight() + 40;
			        var pIW_5 = $("#pIW_8").outerHeight() + 40;*/

			        $('div[id*="pIW_"]').each(function () {
			            pIWSize[indiceSize] = $(this).outerHeight() + 40;
			            indiceSize++;
			        });



			        if (opacityEffect < minOpacity) opacityEffect = minOpacity;
			        if (noOpacityEffect > maxOpacity) noOpacityEffect = maxOpacity;
			        if (opacityBlackBG > maxOpacity) opacityBlackBG = maxOpacity;
			        if (opacityBlackBG < minOpacity) opacityBlackBG = minOpacity;


			        if (opacityEffect <= 0) {
			            smile.css("display", "none");
						blackDOT.css("display", "none");
			            swipeUp.css("display", "none");
			        } else {
						blackDOT.css("display", "block");
			            smile.css("display", "block");
			            swipeUp.css("display", "block");
			        }

			        if (opacityBlackBG === 0) {
						//blackDOT.css("display", "none");
			            blackBG.css("display", "none");
			        } else {
						//blackDOT.css("display", "block");
			            blackBG.css("display", "block");
			        }

			        // ___________

			        if (scrollUp >= pagePosition) {
						blackDOT.css({
			                "opacity": opacityEffect
			            });
			            smile.css({
			                "opacity": opacityEffect
			            });

			            swipeUp.css({
			                "opacity": opacityEffect
			            });

			        } else {
						blackDOT.css({
			                "opacity": 1
			            });
			            smile.css({
			                "opacity": 1
			            });

			            swipeUp.css({
			                "opacity": 1
			            });
			        }

			        // ___________

			        if (scrollUp >= pagePosition) {
						//console.log("Nascondo o vedo")
						/*blackDOT.css({
			                "opacity": opacityBlackBG
			            });*/
			            blackBG.css({
			                "opacity": opacityBlackBG
			            });

			            poolInfo_content.css({
			                "opacity": noOpacityEffect
			            });

			        } else {
						/*blackDOT.css({
			                "opacity": 0
			            });*/

			            blackBG.css({
			                "opacity": 0
			            });

			            poolInfo_content.css({
			                "opacity": 0
			            });
			        }

			        // ___________

			        if (poolInfo_contentHide <= 0) {
			            pIW[0].css({
			                "opacity": 0
			            });

			        } else {
			            pIW[0].css({
			                "opacity": 1
			            });
			        }

			        if (poolInfo_contentHide <= -pIWSize[0]) {
			            pIW[1].css({
			                "opacity": 0
			            });

			        } else {
			            pIW[1].css({
			                "opacity": 1
			            });
			        }

			        if (poolInfo_contentHide <= (-pIWSize[0] - pIWSize[1])) {
			            pIW[2].css({
			                "opacity": 0
			            });

			        } else {
			            pIW[2].css({
			                "opacity": 1
			            });
			        }

			        if (poolInfo_contentHide <= (-pIWSize[0] - pIWSize[1] - pIWSize[2])) {
			            pIW[3].css({
			                "opacity": 0
			            });

			        } else {
			            pIW[3].css({
			                "opacity": 1
			            });
			        }

			        if (poolInfo_contentHide <= (-pIWSize[0] - pIWSize[1] - pIWSize[2] - pIWSize[3])) {
			            pIW[4].css({
			                "opacity": 0
			            });

			        } else {
			            pIW[4].css({
			                "opacity": 1
			            });
			        }

			        if (poolInfo_contentHide <= (-pIWSize[0] - pIWSize[1] - pIWSize[2] - pIWSize[3] - pIWSize[4])) {
			            pIW[5].css({
			                "opacity": 0
			            });

			        } else {
			            pIW[5].css({
			                "opacity": 1
			            });
			        }

			        if (poolInfo_contentHide <= (-pIWSize[0] - pIWSize[1] - pIWSize[2] - pIWSize[3] - pIWSize[4] - pIWSize[5])) {
			            pIW[6].css({
			                "opacity": 0
			            });

			        } else {
			            pIW[6].css({
			                "opacity": 1
			            });
			        }
			        
			        if (poolInfo_contentHide <= (-pIWSize[0] - pIWSize[1] - pIWSize[2] - pIWSize[3] - pIWSize[4] - pIWSize[5] - pIWSize[6])) {
			            pIW[7].css({
			                "opacity": 0
			            });

			        } else {
			            pIW[7].css({
			                "opacity": 1
			            });
			        }


			    }).scroll();
		}

			    // ***MOUSE RULES***

			    $("#more_1_nav").click(function () {

			        clickMoreNav();
			        //FINE - NUOVA REGOLA DA AGGIUNGERE!!!
			    });





			    $("#close_1_nav").click(function () {
			        closeMoreNav();
			    });



			    $(".poolname_list").click(function () {

			        $(".poolname_list").removeClass("list_border").addClass("list_Hborder").css({
			            "background-color": "rgba(245, 247, 249, 1)"
			        });
			        $(this).removeClass("list_border").addClass("list_shadow").css({
			            "background-color": "rgba(255, 255, 255, 1)"
			        });
			        $("body").css("overflow-y", "auto");

			        setTimeout(function () {
			            appExitListPlant = 1;//chiuso il menu senza passare per il pulsante rosso
			            closemenu();
			            $(window).scrollTop(0);

			            $(".poolname_list").removeClass("list_shadow list_Hborder").addClass("list_border").css({
			                "background-color": "rgba(245, 247, 249, 1)"
			            });

			        }, 325);


			    });


			    $('div[id*="pN_"]').click(function () {
			        var oggettoCliccato = $(this);
			        var indiceTemp = parseInt(oggettoCliccato.attr("id").replace("pN_", ""));
                    console.log("indiceCliccato:" + indiceTemp)
			        $("#pN_"+indiceTemp.toString()).css("display", "none");
			        $("#pS_" + indiceTemp.toString()).css("display", "none");
			        //$("#pS_" + indiceTemp.toString()).addClass("pool_status_margin");//c'e sempre non ho capito da vedere
			        switch (indiceTemp) {
			            case 1:
			                $("#pS_2").removeClass("pool_status_margin");
			                break;
			            case 2:
			                $("#pS_3").addClass("pool_status_margin");
			                break;
			            default:
			                $("#pS_2").addClass("pool_status_margin");
			                break;

			        }

			        setTimeout(function () {
			            $('div[id*="pN_"]').each(function () {
			                if ($(this).attr("id") != oggettoCliccato.attr("id")) {
			                    var indiceTempBlock = parseInt($(this).attr("id").replace("pN_", ""));
			                    $(this).css("display", "block");
			                    $("#pS_" + indiceTempBlock.toString()).css("display", "block");
			                }
			            });

			        }, 500);
			        swpLindex = indiceTemp;
			    });
/*
			    $("#pN_1").click(function () {
			        setTimeout(function () {
			            $("#pN_1").css("display", "none");
			            $("#pS_1").css("display", "none");
			            $("#pS_2").removeClass("pool_status_margin");

			            $("#pN_2").css("display", "block");
			            $("#pS_2").css("display", "block");
			            $("#pN_3").css("display", "block");
			            $("#pS_3").css("display", "block");
			            $("#pN_4").css("display", "block");
			            $("#pS_4").css("display", "block");
			            $("#pN_5").css("display", "block");
			            $("#pS_5").css("display", "block");
			        }, 500);

			        swpLindex = 1
			        //				swpRindex = 5
			        //swpRindex = 5
			        //alert("swpLindex: " + swpLindex + "\n" + "swpRindex: " + swpRindex);
			    });

			    $("#pN_2").click(function () {
			        setTimeout(function () {
			            $("#pN_2").css("display", "none");
			            $("#pS_2").css("display", "none");
			            $("#pS_3").addClass("pool_status_margin");

			            $("#pN_1").css("display", "block");
			            $("#pS_1").css("display", "block");
			            $("#pN_3").css("display", "block");
			            $("#pS_3").css("display", "block");
			            $("#pN_4").css("display", "block");
			            $("#pS_4").css("display", "block");
			            $("#pN_5").css("display", "block");
			            $("#pS_5").css("display", "block");
			        }, 500);

			        swpLindex = 2
			        //				swpRindex = 4
			        //swpRindex = 4
			        //alert("swpLindex: " + swpLindex + "\n" + "swpRindex: " + swpRindex);
			    });

			    $("#pN_3").click(function () {
			        setTimeout(function () {
			            $("#pN_3").css("display", "none");
			            $("#pS_3").css("display", "none");
			            $("#pS_2").addClass("pool_status_margin");

			            $("#pN_1").css("display", "block");
			            $("#pS_1").css("display", "block");
			            $("#pN_2").css("display", "block");
			            $("#pS_2").css("display", "block");
			            $("#pN_4").css("display", "block");
			            $("#pS_4").css("display", "block");
			            $("#pN_5").css("display", "block");
			            $("#pS_5").css("display", "block");
			        }, 500);

			        swpLindex = 3
			        //				swpRindex = 3
			        //swpRindex = 3
			        //alert("swpLindex: " + swpLindex + "\n" + "swpRindex: " + swpRindex);
			    });

			    $("#pN_4").click(function () {
			        setTimeout(function () {
			            $("#pN_4").css("display", "none");
			            $("#pS_4").css("display", "none");
			            $("#pS_2").addClass("pool_status_margin");

			            $("#pN_1").css("display", "block");
			            $("#pS_1").css("display", "block");
			            $("#pN_2").css("display", "block");
			            $("#pS_2").css("display", "block");
			            $("#pN_3").css("display", "block");
			            $("#pS_3").css("display", "block");
			            $("#pN_5").css("display", "block");
			            $("#pS_5").css("display", "block");
			        }, 500);

			        swpLindex = 4
			        //				swpRindex = 2
			        //swpRindex = 2
			        //alert("swpLindex: " + swpLindex + "\n" + "swpRindex: " + swpRindex);
			    });

			    $("#pN_5").click(function () {
			        setTimeout(function () {
			            $("#pN_5").css("display", "none");
			            $("#pS_5").css("display", "none");
			            $("#pS_2").addClass("pool_status_margin");

			            $("#pN_1").css("display", "block");
			            $("#pS_1").css("display", "block");
			            $("#pN_2").css("display", "block");
			            $("#pS_2").css("display", "block");
			            $("#pN_3").css("display", "block");
			            $("#pS_3").css("display", "block");
			            $("#pN_4").css("display", "block");
			            $("#pS_4").css("display", "block");
			        }, 500);

			        swpLindex = 5
			        //				swpRindex = 1
			        //swpRindex = 1
			        //alert("swpLindex: " + swpLindex + "\n" + "swpRindex: " + swpRindex);
			    });

*/

			    // ***CHECK ROUTINE 2***

			    $(function () {
			        var sfumatura = new Array();
			        sfumatura[0] = 'sfondo_all_good';
			        sfumatura[1] = 'sfondo_not_good';
			        sfumatura[2] = 'sfondo_bad';

			        var Piscina = new Array();
			        Piscina[0] = "Piscina 1";
			        Piscina[1] = "Piscina 2";
			        Piscina[2] = "Piscina 3";
			        Piscina[3] = "Piscina 4";
			        Piscina[4] = "Piscina 5";

			        var status = $(".pool_status");
                    
			        /*$('div[id*="pS_"]').each(function () {
			            var indiceTemp = parseInt($(this).attr("id").replace("pS_", ""));
			            $(this).css("background-color", graficaStatusColor(indiceTemp))
			        });*/
			        aggiornaListaStrumentiStatus();
			       /* $("#pS_1").css("background-color", "rgba(39,172,58,0.75)");
			        $("#pS_2").css("background-color", "rgba(255,119,0,0.75)");
			        $("#pS_3").css("background-color", "rgba(234,0,41,0.75)");
			        $("#pS_4").css("background-color", "rgba(39,172,58,0.75)");
			        $("#pS_5").css("background-color", "rgba(255,119,0,0.75)");*/
			        $('.poolname_list').click(function () {
			            var indiceTemp = parseInt($(this).attr("id").replace("pN_", ""));
			            console.log("cliccato quello che mi serve1:" + indiceTemp)
			            setTimeout(function () {
			                $(".poolname").text(graficaText(indiceTemp));
			            }, 500);

			            $(this).css("color", graficaStatusColor(indiceTemp));
			            graficaStatusSecond(indiceTemp);
			            aggiornaGraficaVal(indiceTemp);
			            console.log("CLICK")
			            pIcPaddTop(false);
			            pIcPaddBott(false);
			        });
			        
			        /*$("#pN_1.poolname_list").click(function () {
			            console.log("cliccato quello che mi serve")
			            setTimeout(function () {
			                $(".poolname").text(Piscina[0]);
			            }, 500);

			            status.animate({
			                opacity: 0,
			            }, { queue: false, duration: 150 }).animate({
			                left: "50vw",
			            }, 500);

			            $(this).css("color", "rgba(39,172,58,1.00)");

			            $("#BG").removeClass().addClass(sfumatura[0]);
			            $("svg#smile_good").css("display", "block");
			            $("svg#smile_notGood").css("display", "none");
			            $("svg#smile_bad").css("display", "none");
			            $(".color_path1").css("fill", "rgba(39,172,58,1.00)");
			        });

			        $("#pN_2.poolname_list").click(function () {
			            setTimeout(function () {
			                $(".poolname").text(Piscina[1]);
			            }, 500);

			            status.animate({
			                opacity: 0,
			            }, { queue: false, duration: 150 }).animate({
			                left: "50vw",
			            }, 500);

			            $(this).css("color", "rgba(255,119,0,1.00)");

			            $("#BG").removeClass().addClass(sfumatura[1]);
			            $("svg#smile_good").css("display", "none");
			            $("svg#smile_notGood").css("display", "block");
			            $("svg#smile_bad").css("display", "none");
			            $(".color_path1").css("fill", "rgba(255,119,0,1.00)");
			        });

			        $("#pN_3.poolname_list").click(function () {
			            setTimeout(function () {
			                $(".poolname").text(Piscina[2]);
			            }, 500);

			            status.animate({
			                opacity: 0,
			            }, { queue: false, duration: 150 }).animate({
			                left: "50vw",
			            }, 500);

			            $(this).css("color", "rgba(234,0,41,1.00)");

			            $("#BG").removeClass().addClass(sfumatura[2]);
			            $("svg#smile_good").css("display", "none");
			            $("svg#smile_notGood").css("display", "none");
			            $("svg#smile_bad").css("display", "block");
			            $(".color_path1").css("fill", "rgba(234,0,41,1.00)");
			        });

			        $("#pN_4.poolname_list").click(function () {
			            setTimeout(function () {
			                $(".poolname").text(Piscina[3]);
			            }, 500);

			            status.animate({
			                opacity: 0,
			            }, { queue: false, duration: 150 }).animate({
			                left: "50vw",
			            }, 500);

			            $(this).css("color", "rgba(39,172,58,1.00)");

			            $("#BG").removeClass().addClass(sfumatura[0]);
			            $("svg#smile_good").css("display", "block");
			            $("svg#smile_notGood").css("display", "none");
			            $("svg#smile_bad").css("display", "none");
			            $(".color_path1").css("fill", "rgba(39,172,58,1.00)");
			        });

			        $("#pN_5.poolname_list").click(function () {
			            setTimeout(function () {
			                $(".poolname").text(Piscina[4]);
			            }, 500);

			            status.animate({
			                opacity: 0,
			            }, { queue: false, duration: 150 }).animate({
			                left: "50vw",
			            }, 500);

			            $(this).css("color", "rgba(255,119,0,1.00)");

			            $("#BG").removeClass().addClass(sfumatura[1]);
			            $("svg#smile_good").css("display", "none");
			            $("svg#smile_notGood").css("display", "block");
			            $("svg#smile_bad").css("display", "none");
			            $(".color_path1").css("fill", "rgba(255,119,0,1.00)");
			        });*/
			    });


			    $(".poolname_list").hover(function () {
			        $(this).removeClass("list_border").addClass("list_shadow");
			    }, function () {
			        $(this).removeClass("list_shadow").addClass("list_border");
			    });


			    $(".poolname_list").mousedown(function () {
			        $(this).css("background-color", "rgba(255, 255, 255, 1)");
			    });


			    $(".poolname_list").mouseup(function () {
			        $(this).css("background-color", "rgba(245, 247, 249, 1)");
			    });



			    // ***DATE AND TIME***

			    function dateAndTime() {
			        var data = new Date();
			       /* var set, gg, mm, aaaa;

			        var mesi = new Array();
			        mesi[0] = "Jan"; // January
			        mesi[1] = "Feb"; // February
			        mesi[2] = "Mar"; // March
			        mesi[3] = "Apr"; // April
			        mesi[4] = "May"; // May
			        mesi[5] = "Jun"; // June
			        mesi[6] = "Jul"; // July
			        mesi[7] = "Aug"; // August
			        mesi[8] = "Sep"; // September
			        mesi[9] = "Oct"; // October
			        mesi[10] = "Nov"; // November
			        mesi[11] = "Dec"; // December

			        var giorni = new Array();
			        giorni[0] = "Sun"; // Sunday
			        giorni[1] = "Mon"; // Monday
			        giorni[2] = "Tue"; // Tuesday
			        giorni[3] = "Wed"; // Wednesday
			        giorni[4] = "Thu"; // Thursday
			        giorni[5] = "Fri"; // Friday
			        giorni[6] = "Sat"; // Saturday

			        set = giorni[data.getDay()] + ", ";
			        gg = data.getDate() + " ";

			        mm = mesi[data.getMonth()] + " ";
			        aaaa = data.getFullYear();

			        var ora = new Date();
			        var oraEng;

			        var HH = ora.getHours();
			        var MM = ora.getMinutes();
			        var SS = ora.getSeconds();

			        parseInt(MM) < 10 ? MM = "0" + MM : null;
			        parseInt(SS) < 10 ? SS = "0" + SS : null;
                    */
			        //if (HH <= 12) oraEng = /*" - " +*/ HH + ":" + MM + " am";
			        //if (HH > 12) oraEng = /*" - " +*/ (HH - 12) + ":" + MM + " pm";
			        //if (HH === 0) oraEng = /*" - " +*/ 12 + ":" + MM + " pm";
                    
			        // $("#dateAndTime").text(set + oraEng);
			        //const options = { weekday: 'long', year: 'numeric', month: 'long', day: 'numeric' };
			        const options = { weekday: 'short', year: 'numeric', month: 'short', day: 'numeric' };
			        $("#dateAndTime").text(data.toLocaleString(undefined, options) + " " + data.toLocaleTimeString([], { timeStyle: 'short' }));


			        if ((data.getHours() == 0) && (data.getMinutes() == 0) && ((data.getSeconds() > 0) && (data.getSeconds() < 5))) {
			        //if ( ((data.getMinutes() % 2) == 0) && ((data.getSeconds() > 0) && (data.getSeconds() < 2))) {
                        console.log("autorefresh")
			            autoRefreshPage();
			        }
			    }

			    dateAndTime()
			    setInterval(dateAndTime, 1000);

			    //function Minuti() {
			    //			var data = new Date();
			    //			var minuti = data.getMinutes();
			    //			var mancanti = data.setMinutes(60 – minuti);
			    //			minuti = data.getMinutes();
			    //			return(minuti);
			    //			}
			    //			document.write("“"<div>Mancano "”" + Minuti() + "”" minuti alla fine dell’ora!!!</div>");




			    // ***HAND RULES***

			    if (($(window).innerHeight() > $(window).innerWidth()) && ($(window).innerWidth() < 600)) {	
			            if (swpIndMax > 1) { $(document).on("swiperight", swipeHandlerRight) }
			            if (swpIndMax > 1) { $(document).on("swiperight", swipeFuntion) }
			            if (swpIndMax > 1) { $(document).on("swipeleft", swipeHandlerLeft) }
			            if (swpIndMax > 1) { $(document).on("swipeleft", swipeFuntion) }
			    }
			    function swipeHandlerRight() {

			        console.log("swpIndMaxR:" + swpIndMax)
			        swpLindex--
			        if (swpLindex < 1) swpLindex = swpIndMax;

			        $("#BG_whiteOverlay").css({
			            "display": "block",
			            "width": 0,
			            "opacity": 0

			        }).animate({
			            width: "100vw",
			            opacity: 0.3

			        }, 150).animate({
			            with: 0,
			            opacity: 0.1

			        }, 150)
			        setTimeout(function () {
			            $("#BG_whiteOverlay").css({
			                "display": "none",
			                "left": 0
			            })
			        }, 300);

			        $(window).scrollTop(0);
			        stopScrolling();
			        setTimeout(startScrolling, 1000);

			    }

			    function swipeHandlerLeft() {

			        console.log("swpIndMaxR:" + swpIndMax)
			        swpLindex++
			        if (swpLindex > swpIndMax) swpLindex = 1;

			        $("#BG_whiteOverlay").css({
			            "display": "block",
			            "width": 0,
			            "left": "100vw",
			            "opacity": 0

			        }).animate({
			            width: "100vw",
			            left: 0,
			            opacity: 0.3

			        }, 150).animate({
			            with: 0,
			            opacity: 0.1

			        }, 150)
			        setTimeout(function () {
			            $("#BG_whiteOverlay").css({
			                "display": "none",
			                "left": 0
			            })
			        }, 300);

			        $(window).scrollTop(0);
			        stopScrolling();
			        setTimeout(startScrolling, 1000);
			    }



			    //______________________________________________________

                /*
			    var sfumatura = new Array();
			    sfumatura[0] = 'sfondo_all_good';
			    sfumatura[1] = 'sfondo_not_good';
			    sfumatura[2] = 'sfondo_bad';

			    var Piscina = new Array();
			    Piscina[0] = "Piscina 1";
			    Piscina[1] = "Piscina 2";
			    Piscina[2] = "Piscina 3";
			    Piscina[3] = "Piscina 4";
			    Piscina[4] = "Piscina 5";
                */

			    //______________________________________________________


                
			}
//});
			function stopScrolling() {
			    $("body").css("overflow", "hidden")
			}
			function startScrolling() {
			    $("body").css("overflow", "auto")
			}

			function devRotation() {
			    if ($(window).innerHeight() < 480) {
			        $("#tYD").css("display", "block");
			        stopScrolling();
			    } else {
			        $("#tYD").css("display", "none");
			        startScrolling();
			    }
			}
function sizeFirst(startPage)

			{
    /* TURN YOUR DEVICE (inserire nel codice) */



    devRotation();

    $(window).on("orientationchange", function () {

        devRotation();
        console.log("reload2")
        //window.location.reload();
    });

    $(window).resize(function () {

        devRotation();
        console.log("reload1")
        //window.location.reload();
    });

    //__________________ Fine TURN YOUR DEVICE
    /* poolInfo_wrapper FLOAT LEFT (inserire nel codice) */

    if ($(window).outerWidth() >= 1920 && $("div.poolInfo_wrapper").length > 5) {

        $("div.poolInfo_wrapper").css("margin-left", "80px");

        var pIwMarginCalc = ($(window).innerWidth() / 2) - $("div.poolInfo_wrapper").outerWidth();
        var pIwWidthMAX = ($("div.poolInfo_wrapper").outerWidth() - (pIwMarginCalc) * 2) / 2;

        var pIcHeight = $("div.poolInfo_wrapper").outerHeight() * $("div.poolInfo_wrapper").length;

        $("div.poolInfo_wrapper").css({
            "float": "left",
            "width": pIwWidthMAX
        });

        $("#poolInfo_content").css({
            "height": pIcHeight,
        });

    }

    //__________________ Fine poolInfo_wrapper FLOAT LEFT

    $(window).on("orientationchange", function () {

        pIcPaddTop(startPage);
    });

    $(window).resize(function () {

        pIcPaddTop(startPage);
    });

    pIcPaddTop(startPage);


    $(window).on("orientationchange", function () {

        pIcPaddBott(startPage);
    });

    $(window).resize(function () {

        pIcPaddBott(startPage);
    });

    pIcPaddBott(startPage);
}

/* poolInfo_content PADDING TOP (inserire nel codice) */

function pIcPaddTop(startPage) {

    var winHeight = $(window).outerHeight();
    //var winHeight = $(window).height();
    //var pIcHeight = $("#poolInfo_content").innerHeight();
    var pIcHeight = startPage ? $("#poolInfo_content").innerHeight() : $("#poolInfo_content").height();
    var topCalc = $(".navbar").outerHeight();
    //var topCalc = $(".navbar").height();
    var paddTop = (winHeight - pIcHeight) / 2;
    var paddTop2 = topCalc + 45;

    if (paddTop <= paddTop2) paddTop = paddTop2;
    console.log("padTop:" + paddTop + " " + winHeight + " " + pIcHeight)
    if ($(window).innerWidth() >= 480) {
        $("#poolInfo_content").css({
            "padding-top": paddTop,
        });

    } else {$("#poolInfo_content").css("padding-top", "auto"); }
}


//__________________ Fine poolInfo_content PADDING TOP


/* poolInfo_content PADDING BOTTOM (inserire nel codice) */

function pIcPaddBott(startPage) {

    var winHeight = $(window).outerHeight();
    //var bottCalc = $("#poolInfo_content").innerHeight();
    var bottCalc = startPage ? $("#poolInfo_content").innerHeight() : $("#poolInfo_content").height();
    var paddBott = (winHeight - bottCalc)/2;
    var paddBott2 = 100;

    if (paddBott < paddBott2) paddBott = paddBott2;

    if ($(window).innerWidth() >= 480) {
        $("#poolInfo_content").css("padding-bottom", paddBott);

    } else {
        $("#poolInfo_content").css("padding-bottom", "auto");
    }
}



//__________________ Fine poolInfo_content PADDING BOTTOM
function closeMoreNav()
{
    $("body").css("overflow-y", "auto");
    closemenu();
}

function closemenu() {

    $("div.pool_menu_overlay").css("opacity", 1).animate({
        opacity: 0,
    }, 250);
    setTimeout(function () {
        $("div.pool_menu_overlay").addClass("hidecont");
    }, 250);
    setTimeout(function () {
        $("#more_1_nav").removeClass("hidecont");
    }, 10);
    $(".poolname_list").css({
        "color": "rgba(50,62,72,1.00)",
        "background-color": "rgba(245, 247, 249, 1)"
    });
    setTimeout(function () {
        $(".pool_status").css({
            "opacity": 0,
            "left": "50vw"
        });
    }, 325);

    autoHover();
    //NUOVA REGOLA DA AGGIUNGERE!!!
    if ($(window).innerWidth() > 480) {
        $(".poolname").css({
            "left": "calc(-50vw + 40px)",
        });
    }
    //FINE - NUOVA REGOLA DA AGGIUNGERE!!!
}

function clickMoreNav()
{
    

    $("body").css("overflow-y", "hidden");

    $("div.pool_menu_overlay").removeClass("hidecont").css("opacity", 0).animate({
        opacity: 1,
    }, 500);
    $("#close_1_nav").addClass("hidecont");
    setTimeout(function () {
        $("#more_1_nav").addClass("hidecont");
    }, 500);
    setTimeout(function () {
        $("#close_1_nav").removeClass("hidecont");
    }, 150);

    $(".pool_status").css({
        "opacity": 0,
        "left": "50vw"
    }).animate({
        opacity: 1,
    }, { queue: false, duration: 150 }).animate({
        left: "0",
    }, 500);

    autoHover()
    //NUOVA REGOLA DA AGGIUNGERE!!!
    if ($(window).innerWidth() > 480) {
        $(".poolname").css({
            "left": "40px",
        });
    }
}
function autoHover() {
    $("#close_1_nav_anim").animate({
        left: "-=40px",
        opacity: 0,
    }, 100);

    $("#more_1_nav_anim").animate({
        left: "-=40px",
        opacity: 0,
    }, 100);

    setTimeout(function () {
        $("#close_1_nav_anim").css({
            "left": "+=80px",
            "opacity": 0,
        });

        $("#more_1_nav_anim").css({
            "left": "+=80px",
            "opacity": 0,
        });
    }, 150);

    setTimeout(function () {
        $("#close_1_nav_anim").animate({
            left: "-=40px",
            opacity: 1,
        }, 100);

        $("#more_1_nav_anim").animate({
            left: "-=40px",
            opacity: 1,
        }, 100);
    }, 200);
}

function autoSwipe(){
	swipeHandlerLeft();
	swipeFuntion();
}

			    function swipeHandlerLeft() {

			        console.log("swpIndMaxR:" + swpIndMax)
			        swpLindex++
			        if (swpLindex > swpIndMax) swpLindex = 1;

			        $("#BG_whiteOverlay").css({
			            "display": "block",
			            "width": 0,
			            "left": "100vw",
			            "opacity": 0

			        }).animate({
			            width: "100vw",
			            left: 0,
			            opacity: 0.3

			        }, 150).animate({
			            with: 0,
			            opacity: 0.1

			        }, 150)
			        setTimeout(function () {
			            $("#BG_whiteOverlay").css({
			                "display": "none",
			                "left": 0
			            })
			        }, 300);

			        $(window).scrollTop(0);
			        stopScrolling();
			        setTimeout(startScrolling, 1000);
			    }


			    function swipeFuntion() {
			        console.log("SWIPE")
			        $(".poolname").text(graficaText(swpLindex));
			        graficaStatusSecond(swpLindex);
			        aggiornaGraficaVal(swpLindex);
			        $('div[id*="pN_"]').each(function () {
			                var indiceTempBlock = parseInt($(this).attr("id").replace("pN_", ""));
			                if (indiceTempBlock == swpLindex) {
			                    $("#pS_" + indiceTempBlock.toString()).css("display", "none");
			                    $("#pN_" + indiceTempBlock.toString()).css("display", "none");
			                }
			                else {
			                    $("#pS_" + indiceTempBlock.toString()).css("display", "block");
			                    $("#pN_" + indiceTempBlock.toString()).css("display", "block");
			                }

			            switch(swpLindex)
			            {
			                case 1:
			                    $("#pS_2").removeClass("pool_status_margin");
			                    break;
			                case 2:
			                    $("#pS_3").addClass("pool_status_margin");
			                    break;
			                default:
			                    $("#pS_2").addClass("pool_status_margin");
			                    break;

			            }

			        });
			        pIcPaddTop(false);
			        pIcPaddBott(false);
/*
			        if (swpLindex == 1 || swpLindex == swpIndMax) {

			            $(".poolname").text(Piscina[0]);

			            $("#BG").removeClass().addClass(sfumatura[0]);
			            $("svg#smile_good").css("display", "block");
			            $("svg#smile_notGood").css("display", "none");
			            $("svg#smile_bad").css("display", "none");
			            $(".color_path1").css("fill", "rgba(39,172,58,1.00)");
			            //ok

			            $("#pN_1").css("display", "none");
			            $("#pS_1").css("display", "none");
			            $("#pS_2").removeClass("pool_status_margin");

			            $("#pN_2").css("display", "block");
			            $("#pS_2").css("display", "block");
			            $("#pN_3").css("display", "block");
			            $("#pS_3").css("display", "block");
			            $("#pN_4").css("display", "block");
			            $("#pS_4").css("display", "block");
			            $("#pN_5").css("display", "block");
			            $("#pS_5").css("display", "block");
			        }

			        if (swpLindex == 2) {

			            $(".poolname").text(Piscina[1]);

			            $("#BG").removeClass().addClass(sfumatura[1]);
			            $("svg#smile_good").css("display", "none");
			            $("svg#smile_notGood").css("display", "block");
			            $("svg#smile_bad").css("display", "none");
			            $(".color_path1").css("fill", "rgba(255,119,0,1.00)");

			            $("#pN_2").css("display", "none");
			            $("#pS_2").css("display", "none");
			            $("#pS_3").addClass("pool_status_margin");

			            $("#pN_1").css("display", "block");
			            $("#pS_1").css("display", "block");
			            $("#pN_3").css("display", "block");
			            $("#pS_3").css("display", "block");
			            $("#pN_4").css("display", "block");
			            $("#pS_4").css("display", "block");
			            $("#pN_5").css("display", "block");
			            $("#pS_5").css("display", "block");
			        }

			        if (swpLindex == 3) {

			            $(".poolname").text(Piscina[2]);

			            $("#BG").removeClass().addClass(sfumatura[2]);
			            $("svg#smile_good").css("display", "none");
			            $("svg#smile_notGood").css("display", "none");
			            $("svg#smile_bad").css("display", "block");
			            $(".color_path1").css("fill", "rgba(234,0,41,1.00)");

			            $("#pN_3").css("display", "none");
			            $("#pS_3").css("display", "none");
			            $("#pS_2").addClass("pool_status_margin");

			            $("#pN_1").css("display", "block");
			            $("#pS_1").css("display", "block");
			            $("#pN_2").css("display", "block");
			            $("#pS_2").css("display", "block");
			            $("#pN_4").css("display", "block");
			            $("#pS_4").css("display", "block");
			            $("#pN_5").css("display", "block");
			            $("#pS_5").css("display", "block");
			        }

			        if (swpLindex == 4) {

			            $(".poolname").text(Piscina[3]);

			            $("#BG").removeClass().addClass(sfumatura[0]);
			            $("svg#smile_good").css("display", "block");
			            $("svg#smile_notGood").css("display", "none");
			            $("svg#smile_bad").css("display", "none");
			            $(".color_path1").css("fill", "rgba(39,172,58,1.00)");

			            $("#pN_4").css("display", "none");
			            $("#pS_4").css("display", "none");
			            $("#pS_2").addClass("pool_status_margin");

			            $("#pN_1").css("display", "block");
			            $("#pS_1").css("display", "block");
			            $("#pN_2").css("display", "block");
			            $("#pS_2").css("display", "block");
			            $("#pN_3").css("display", "block");
			            $("#pS_3").css("display", "block");
			            $("#pN_5").css("display", "block");
			            $("#pS_5").css("display", "block");
			        }

			        if (swpLindex == 5) {

			            $(".poolname").text(Piscina[4]);

			            $("#BG").removeClass().addClass(sfumatura[1]);
			            $("svg#smile_good").css("display", "none");
			            $("svg#smile_notGood").css("display", "block");
			            $("svg#smile_bad").css("display", "none");
			            $(".color_path1").css("fill", "rgba(255,119,0,1.00)");

			            $("#pN_5").css("display", "none");
			            $("#pS_5").css("display", "none");
			            $("#pS_2").addClass("pool_status_margin");

			            $("#pN_1").css("display", "block");
			            $("#pS_1").css("display", "block");
			            $("#pN_2").css("display", "block");
			            $("#pS_2").css("display", "block");
			            $("#pN_3").css("display", "block");
			            $("#pS_3").css("display", "block");
			            $("#pN_4").css("display", "block");
			            $("#pS_4").css("display", "block");
			        }*/
			    }












<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="registrati.aspx.vb" Inherits="ermes_web_20.signup" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>
<html lang="en">
<head>
  <head>
  <meta charset="utf-8" />
  <meta http-equiv="X-UA-Compatible" content="IE=edge" />
  <meta name="viewport" content="width=device-width, initial-scale=1" />

  <title>ERMES - Emec , Simple as Water</title>

  <!-- GOOGLE FONTS -->
  <link href="https://fonts.googleapis.com/css?family=Karla:400,700|Roboto" rel="stylesheet">
  <link href="assets/plugins/material/css/materialdesignicons.min.css" rel="stylesheet" />
  <link href="assets/plugins/simplebar/simplebar.css" rel="stylesheet" />

  <!-- PLUGINS CSS STYLE -->
  <link href="assets/plugins/nprogress/nprogress.css" rel="stylesheet" />
  
  <!-- MONO CSS -->
  <link id="main-css-href" rel="stylesheet" href="assets/css/mono.css" />

  


  <!-- FAVICON -->
  <link href="assets/img/favicon.png" rel="shortcut icon" />

  <!--
    HTML5 shim and Respond.js for IE8 support of HTML5 elements and media queries
  -->
  <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
  <!--[if lt IE 9]>
    <script src="https://oss.maxcdn.com/html5shiv/3.7.2/html5shiv.min.js"></script>
    <script src="https://oss.maxcdn.com/respond/1.4.2/respond.min.js"></script>
  <![endif]-->
  <script src="assets/plugins/nprogress/nprogress.js"></script>
</head>

</head>
	<body class="login">
	<div class="image-preload">
		<img src="assets/img/drop-color.png" alt="">
		<img src="assets/img/drop-alpha.png" alt="">
		<img src="assets/img/weather/texture-rain-fg.png" />
		<img src="assets/img/weather/texture-rain-bg.png" />
		<img src="assets/img/weather/texture-sun-fg.png" />
		<img src="assets/img/weather/texture-sun-bg.png" />
		<img src="assets/img/weather/texture-fallout-fg.png" />
		<img src="assets/img/weather/texture-fallout-bg.png" />
		<img src="assets/img/weather/texture-drizzle-fg.png" />
		<img src="assets/img/weather/texture-drizzle-bg.png" />
	</div>
	<div class="container_login">
		<header class="codrops-header">
			
		<div class="logo_intro"><svg style="width:70px;">	<path class="st0" d="M1.59,84.83h10.77v1.53H3.27v5.09h8.13v1.53H3.27v5.21h9.19v1.53H1.59V84.83z"/>
<path class="st0" d="M14.99,84.83h6.41c1.83,0,3.3,0.55,4.23,1.49c0.72,0.72,1.15,1.77,1.15,2.94v0.04c0,2.47-1.7,3.92-4.04,4.34
	l4.57,6.09h-2.06l-4.32-5.79h-4.26v5.79h-1.68V84.83z M21.25,92.43c2.23,0,3.83-1.15,3.83-3.06v-0.04c0-1.83-1.4-2.94-3.81-2.94
	h-4.6v6.04H21.25z"/>
<path class="st0" d="M29.42,84.83h1.7l5.43,8.13l5.43-8.13h1.7v14.9h-1.68V87.66l-5.43,7.98h-0.09l-5.43-7.96v12.04h-1.64V84.83z"/>
<path class="st0" d="M46.31,84.83h10.77v1.53h-9.09v5.09h8.13v1.53h-8.13v5.21h9.19v1.53H46.31V84.83z"/>
<path class="st0" d="M58.63,97.56l1.04-1.23c1.55,1.4,3.04,2.11,5.11,2.11c2,0,3.32-1.06,3.32-2.53v-0.04
	c0-1.38-0.74-2.17-3.87-2.83c-3.43-0.74-5-1.85-5-4.3v-0.04c0-2.34,2.06-4.06,4.9-4.06c2.17,0,3.72,0.62,5.23,1.83l-0.98,1.3
	c-1.38-1.13-2.77-1.62-4.3-1.62c-1.94,0-3.17,1.06-3.17,2.4v0.04c0,1.4,0.77,2.19,4.04,2.89c3.32,0.72,4.85,1.94,4.85,4.21v0.04
	c0,2.55-2.13,4.21-5.09,4.21C62.35,99.94,60.41,99.15,58.63,97.56z"/>
<g>
	<path class="st0" d="M34.94,36.97c-10.64,8-21.64,16.27-32.28,16.31l-1.01,0l0,1.01l0.02,5.15l1.01,0
		c11.31-0.04,22.59-8.51,33.49-16.71c10.64-8,21.64-16.27,32.28-16.31l1.01,0l-0.02-6.16l-1.01,0
		C57.11,20.3,45.84,28.78,34.94,36.97"/>
	<path class="st0" d="M34.88,19.03c-10.64,8-21.64,16.27-32.28,16.31l-1.01,0l0,1.01l0.02,5.15l1.01,0
		c11.31-0.04,22.59-8.51,33.49-16.71c10.64-8,21.64-16.27,32.28-16.3l1.01,0l-0.02-6.16l-1.01,0C57.05,2.36,45.78,10.83,34.88,19.03
		"/>
	<path class="st0" d="M35,54.92c-10.64,8-21.64,16.27-32.28,16.31l-1.01,0l0,1.01l0.02,5.15l1.01,0
		c11.31-0.04,22.59-8.51,33.49-16.71c10.64-8,21.64-16.27,32.28-16.31l1.01,0l-0.02-6.16l-1.01,0C57.17,38.24,45.9,46.72,35,54.92"
		/>
</g>
<path class="st0" d="M1.49,107.91h1.71c1.61,0,2.72,1.11,2.72,2.55v0.01c0,1.44-1.11,2.56-2.72,2.56H1.49V107.91z M3.19,112.69
	c1.43,0,2.33-0.97,2.33-2.2v-0.01c0-1.22-0.9-2.21-2.33-2.21H1.87v4.42H3.19z"/>
<path class="st0" d="M7.26,107.91h0.38v5.13H7.26V107.91z"/>
<path class="st0" d="M8.99,110.49v-0.01c0-1.38,1-2.65,2.53-2.65c0.83,0,1.36,0.25,1.88,0.67l-0.25,0.29
	c-0.4-0.35-0.87-0.62-1.65-0.62c-1.25,0-2.12,1.05-2.12,2.29v0.01c0,1.33,0.83,2.31,2.2,2.31c0.65,0,1.26-0.27,1.63-0.59v-1.47H11.5
	v-0.35h2.08v1.98c-0.46,0.41-1.18,0.77-2.01,0.77C9.95,113.13,8.99,111.93,8.99,110.49z"/>
<path class="st0" d="M15,107.91h0.38v5.13H15V107.91z"/>
<path class="st0" d="M18.38,108.26h-1.79v-0.35h3.96v0.35h-1.79v4.78h-0.38V108.26z"/>
<path class="st0" d="M22.99,107.88h0.37l2.39,5.16h-0.42l-0.65-1.44h-3.02L21,113.04h-0.4L22.99,107.88z M24.51,111.26l-1.35-2.97
	l-1.35,2.97H24.51z"/>
<path class="st0" d="M26.82,107.91h0.38v4.78h3.01v0.35h-3.39V107.91z"/>
<path class="st0" d="M33.22,112.29l0.25-0.29c0.56,0.52,1.08,0.76,1.84,0.76c0.77,0,1.3-0.43,1.3-1.02v-0.01
	c0-0.54-0.29-0.86-1.45-1.09c-1.23-0.25-1.73-0.67-1.73-1.44v-0.01c0-0.76,0.7-1.35,1.65-1.35c0.75,0,1.24,0.21,1.76,0.62l-0.24,0.3
	c-0.48-0.42-0.97-0.58-1.53-0.58c-0.75,0-1.25,0.43-1.25,0.97v0.02c0,0.54,0.28,0.87,1.49,1.12c1.19,0.24,1.68,0.67,1.68,1.41v0.02
	c0,0.83-0.71,1.4-1.7,1.4C34.46,113.11,33.83,112.84,33.22,112.29z"/>
<path class="st0" d="M38.23,107.91h3.65v0.35h-3.27v2.01h2.94v0.35h-2.94v2.06h3.3v0.35h-3.68V107.91z"/>
<path class="st0" d="M43.14,107.91h2.15c0.63,0,1.13,0.2,1.44,0.5c0.24,0.24,0.39,0.59,0.39,0.95v0.01c0,0.86-0.64,1.35-1.5,1.46
	l1.69,2.19h-0.48l-1.63-2.12h-1.68v2.12h-0.38V107.91z M45.25,110.57c0.86,0,1.49-0.43,1.49-1.17v-0.02c0-0.69-0.54-1.12-1.47-1.12
	h-1.75v2.31H45.25z"/>
<path class="st0" d="M47.84,107.91h0.42l2.01,4.72l2.01-4.72h0.4l-2.26,5.16H50.1L47.84,107.91z"/>
<path class="st0" d="M53.82,107.91h0.38v5.13h-0.38V107.91z"/>
<path class="st0" d="M55.55,110.49v-0.01c0-1.45,1.08-2.65,2.56-2.65c0.92,0,1.46,0.34,1.99,0.82l-0.27,0.28
	c-0.45-0.43-0.96-0.75-1.73-0.75c-1.23,0-2.16,1-2.16,2.29v0.01c0,1.3,0.95,2.31,2.17,2.31c0.74,0,1.25-0.29,1.77-0.8l0.26,0.25
	c-0.54,0.54-1.13,0.89-2.04,0.89C56.63,113.13,55.55,111.96,55.55,110.49z"/>
<path class="st0" d="M61.17,107.91h3.65v0.35h-3.27v2.01h2.94v0.35h-2.94v2.06h3.3v0.35h-3.68V107.91z"/>
<path class="st0" d="M65.75,112.29l0.25-0.29c0.56,0.52,1.08,0.76,1.84,0.76c0.77,0,1.3-0.43,1.3-1.02v-0.01
	c0-0.54-0.29-0.86-1.45-1.09c-1.23-0.25-1.73-0.67-1.73-1.44v-0.01c0-0.76,0.7-1.35,1.65-1.35c0.75,0,1.24,0.21,1.76,0.62l-0.24,0.3
	c-0.48-0.42-0.97-0.58-1.53-0.58c-0.75,0-1.25,0.43-1.25,0.97v0.02c0,0.54,0.28,0.87,1.49,1.12c1.19,0.24,1.69,0.67,1.69,1.41v0.02
	c0,0.83-0.71,1.4-1.7,1.4C66.99,113.11,66.36,112.84,65.75,112.29z"/>
<line class="st1" x1="1.59" y1="104.64" x2="69.8" y2="104.64"/>
</svg></div>

			<a class="nav-item" id="slide1Click" href="#slide-1" style="display: none;"><i class="icon icon--rainy"></i><span>PIOGGIA FORTE</span></a>
				<a class="nav-item" id="slide2Click" href="#slide-2" style="display: none;"><i class="icon icon--drizzle"></i><span>PIOGGIA DEBOLE</span></a>
				<a class="nav-item" id="slide3Click" href="#slide-3" style="display: none;"><i class="icon icon--sun"></i><span>SERENO</span></a>
                <a class="nav-item" id="slide4Click" href="#slide-4" style="display: none;"><i class="icon icon--storm"></i><span>NEVE</span></a><br>
				<a class="nav-item" id="slide5Click" href="#slide-5" style="display: none;"><i class="icon icon--storm"></i><span>TEMPORALE</span></a><br>
		</header>
		
		<div class="slideshow">
			<canvas width="1" height="1" id="container_login" style="position:absolute"></canvas>
			<!-- Heavy Rain -->
			<div class="slide" id="slide-1" data-weather="rain">
				<div class="titolo_intro"><div class="slide__element slide__element--date"><i class="icon_time" data-icon="R"></i> <h3 class="white"></h3></div></div>
			</div>
			<!-- Drizzle -->
			<div class="slide" id="slide-2" data-weather="drizzle">
				<div class="titolo_intro"><div class="slide__element slide__element--date"><i class="icon_time" data-icon="Q"></i> <h3 class="white"></h3></div></div>
			</div>
			<!-- Sunny -->
			<div class="slide" id="slide-3" data-weather="sunny">
				<div class="titolo_intro"><div class="slide__element slide__element--date"><i class="icon_time" data-icon="B"></i> <h3 class="white"></h3></div></div>
			</div>
            <div class="slide" id="slide-4" data-weather="sunny">
			        <div class="titolo_intro"><div class="slide__element slide__element--date">	<i class="icon_time" data-icon="X"></i> <h3 class="white"></h3><div id="particles"></div></div></div>
			</div>			<!-- Heavy rain -->
			<div class="slide" id="slide-5" data-weather="storm">
				<div class="titolo_intro"><div class="slide__element slide__element--date"><i class="icon_time" data-icon="O"></i> <h3 class="white"></h3></div></div>
			</div>
		</div>
		
			
			<nav class="slideshow__nav">
				<div class="row justify-content-center m-2">
              <div class="col-lg-6 col-md-10">
                <div class="card card-default mb-0" style="box-shadow: 1px 2px 10px 0px #333333;">
                  <div class="card-header pb-0">
                    <div class="app-brand w-100 d-flex justify-content-center border-bottom-0">
                      <a class="w-auto pl-0" href="login.aspx">
                        <img src="assets/img/logo.png" alt="Mono">
                        <span class="brand-name text-dark">ERMES / SIGN UP</span>
                      </a>
                    </div>
                  </div>
                  <div class="card-body px-5 pb-5 pt-0">
                      <!--
                    <form id="validateSubmitForm" method="post" autocomplete="off"  action="signed.aspx">
                          -->
                      <form runat="server">
                      <div class="row">
						   <div class="form-group col-md-12 mb-4">
                          <!-- <input type="text" name="company" class="form-control input-lg" id="company" placeholder="company"> -->
                           <asp:TextBox  ID="company" placeholder="company"   runat="server" CssClass="form-control input-lg" ToolTip="company" ></asp:TextBox>

                        </div>
						   <div class="form-group col-md-12 mb-4">
                          <!--<input type="text" name="username" class="form-control input-lg" id="username" placeholder="username">-->
                               <asp:TextBox  ID="username" placeholder="username"   runat="server" CssClass="form-control input-lg" ToolTip="username" ></asp:TextBox>
                        </div>
                        <div class="form-group col-md-12 ">
                          <!--<input type="password" name="password" class="form-control input-lg" id="password" placeholder="Password">-->
                            <asp:TextBox  ID="password" placeholder="Password" runat="server" TextMode="Password"  CssClass="form-control input-lg"></asp:TextBox>
                        </div>
						<div class="form-group col-md-12 ">
                         <!-- <input type="password" class="form-control input-lg" id="confirm_password" placeholder="Confirm Password">-->
                            <asp:TextBox  ID="confirm_password" placeholder="Confirm Password" runat="server" TextMode="Password"  CssClass="form-control input-lg"></asp:TextBox>
                        </div>
                        <div class="form-group col-md-12 mb-4">
                          <!--<input type="email" name="email" class="form-control input-lg" name="confirm_password" id="email" aria-describedby="emailHelp"
                            placeholder="email">-->
                            <asp:TextBox  ID="email" placeholder="email"   runat="server" CssClass="form-control input-lg" ToolTip="email" ></asp:TextBox>
                        </div>
                        <div class="custom-control custom-checkbox mr-3 mb-3" style="margin:0 0 0 14px;">
                              <input type="checkbox" class="custom-control-input" id="agree">
                              <label class="custom-control-label" for="agree">Agree</label>
                        <asp:Literal ID="Literal10" Text="<a href='#' id='opener'>Please agree to our polcy</a>" runat="server" meta:resourcekey="Literal10Resource1"></asp:Literal>
                            </div>
                          <div class="col-md-12" >
<fieldset>
      <legend>Ermes-server.com CAPTCHA Validation</legend>
      <p class="prompt">
        <label for="CaptchaCodeTextBox">Retype the characters from the picture:</label></p>
      <BotDetect:WebFormsCaptcha runat="server" ID="ExampleCaptcha" 
      UserInputID="CaptchaCodeTextBox" />
      <div class="validationDiv">
        <asp:TextBox ID="CaptchaCodeTextBox" runat="server"></asp:TextBox>
        <asp:Button ID="ValidateCaptchaButton" runat="server" />
        <asp:Label ID="CaptchaCorrectLabel" runat="server" CssClass="correct"></asp:Label>
        <asp:Label ID="CaptchaIncorrectLabel" runat="server" 
        CssClass="incorrect"></asp:Label>
      </div>
    </fieldset>                        
                              </div>
                        <div class="col-md-12">
                         <asp:Button ID="Button1" runat="server" CssClass="btn btn-primary btn-pill mb-4" style="width:100% !important" Text="Create account and" meta:resourcekey="Literal11Resource1" />
                          <!--<button id="submitForm" type="submit" class="btn btn-primary btn-pill mb-4" style="width:100% !important"><asp:Literal ID="Literal11" Text="Create account and" runat="server" meta:resourcekey="Literal11Resource1"></asp:Literal></button>-->
                            <a class="text-blue" href="login.aspx">Login Page </a>
                        </div>
                      </div>
                    </form>
                  </div>
                </div>
              </div>
            </div>
				
      		<asp:Literal ID="java_script_local" runat="server" meta:resourcekey="java_script_localResource1"></asp:Literal>
	
			
			</nav>
		</div>
		<p class="nosupport">Sorry, but your browser does not support WebGL!</p>
	</div>
	<!-- /container -->
	<script src="assets/js/index.min.js"></script>
    <script src="assets/plugins/jquery/jquery.min.js"></script>
    <script type="text/javascript" src="assets/js/snowstorm.js"></script>

    <script type="text/javascript">
        var alarmUsername = true;
        var alarmPassword = true;
        var alarmPassword1 = true;
        var alarmMail = true;

        function validateMail(valoreForm)
        {
            var email_re = /^[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,4}$/i;
            return valoreForm.search(email_re)
        }
        $('#email').on('keypress keydown keyup', function () {
            var validateMailResult = validateMail($('#email').val());
            $("#email").next("div").remove();
            $("#Button1").next("div").remove();
            if (validateMailResult == -1) {
                alarmMail = true
                $("#email").after("<div class=\"text-danger small mt-1\">" + email + "</div>");
            }
            else
                alarmMail = false;
                
        });
        $('#username').on('keypress keydown keyup', function () {
            var value_form_lunghezza = $(this).val().length;
            $(this).next("div").remove();
            $("#Button1").next("div").remove();
            if (value_form_lunghezza < 6) {
                alarmUsername = true;
                $(this).after("<div class=\"text-danger small mt-1\">" + username_6 + "</div>");
            }
            else
                alarmUsername = false;
                
        });
        $('#password').on('keypress keydown keyup', function () {
            var value_form_lunghezza = $(this).val().length;
            $(this).next("div").remove();
            $("#Button1").next("div").remove();
            if (value_form_lunghezza < 6) {
                alarmPassword = true;
                $(this).after("<div class=\"text-danger small mt-1\">" + password_6 + "</div>");
            }
            else
                alarmPassword = false;
        });
        $('#confirm_password').on('keypress keydown keyup', function () {
            var value_form_lunghezza = $(this).val().length;
            $(this).next("div").remove();
            $("#Button1").next("div").remove();
            if (value_form_lunghezza < 6) {
                alarmPassword1 = true
                $(this).after("<div class=\"text-danger small mt-1\">" + password_6 + "</div>");
            }
            else
                alarmPassword1 = false
        });
        $("#Button1").click(function () {
            $("#agree").next("div").remove();
            if (!($("#agree").is(':checked'))) {
                $("#agree").after("<div class=\"text-danger small mt-1\">" + policy + "</div>");
                return false;
            }
            else {
                $("#Button1").next("div").remove();
                if ((alarmUsername) || (alarmPassword) || (alarmPassword1) || (alarmMail)) {
                    $("#Button1").after("<div class=\"text-danger small mt-1\">Error*</div>");
                    return false;
                }
                else {
                    $("#password").next("div").remove();
                    $("#confirm_password").next("div").remove();
                    if ($('#password').val() != $('#confirm_password').val()) {
                        $("#password").after("<div class=\"text-danger small mt-1\">" + password_uguale + "</div>");
                        $("#confirm_password").after("<div class=\"text-danger small mt-1\">" + password_uguale + "</div>");
                        $("#Button1").after("<div class=\"text-danger small mt-1\">Error*" + password_uguale + "</div>");
                        return false;
                    }
                }
            }
            return true;
        });

        var showWeather = function (data) {
            console.log(data)
            var codiceMeteo = data.weather[0].icon;
            codiceMeteo = codiceMeteo.replace("d", "")
            codiceMeteo = codiceMeteo.replace("n", "")
            var codiceMeteoNum = parseInt(codiceMeteo)
            console.log(data.name, codiceMeteoNum)
            if ((codiceMeteoNum >= 1) && (codiceMeteoNum <= 4)) {
                $("#particles").hide();
                $('a')[2].click();//sole
            }
            if ((codiceMeteoNum == 9)) {
                $("#particles").hide();
                $('a')[0].click();//pioggia forte
            }

            if ((codiceMeteoNum == 10)) {
                $("#particles").hide();
                $('a')[1].click();//pioggia debole
            }
            if ((codiceMeteoNum == 11)) {
                $("#particles").hide();
                $('a')[4].click();//temporale
            }
            if ((codiceMeteoNum == 13)) {
                $("#particles").show();
                $('a')[3].click();//neve
            }
            $(".white").html(data.name)
        }
        var getWeather = function (data) {
            $.ajax({
                dataType: "jsonp",
                url: 'https://api.openweathermap.org/data/2.5/weather',
                data: {
                    lat: data.latitude,
                    lon: data.longitude,
                    units: "metric",
                    appid: "57d5b21566d36d6d57fd5892ef35cc37"
                }
            ,
                success: showWeather,
                error: function (jqXHR, textStatus, errorThrown) {
                    console.log("fail")
                }
            });
        }

        //$.getJSON("https://api.ip2loc.com/jtNZrAX52QtjennyQWIkB3oOeK4Zuzvi/detect", getWeather);
        $.getJSON("https://api.ipstack.com/check?access_key=1c17d2cfbcd7c6cb1fe4204f0830abb5", getWeather);
        </script>
<script type="text/javascript">

// blue-ish snow!?
snowStorm.snowColor = '#ffffff';

// append the snow to this element (by ID or direct DOM node reference)
snowStorm.targetElement = 'particles';

</script>
</body>
 
          

</html>
		

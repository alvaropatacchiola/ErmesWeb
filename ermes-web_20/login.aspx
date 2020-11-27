<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="login.aspx.vb" Inherits="ermes_web_20.login" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>ERMES Communication software</title>
    	<!-- Meta -->
	<meta charset="UTF-8" />
	<meta name="viewport" content="width=device-width, initial-scale=1.0, user-scalable=0, minimum-scale=1.0, maximum-scale=1.0">
	<meta name="apple-mobile-web-app-capable" content="yes">
	<meta name="apple-mobile-web-app-status-bar-style" content="black">
	<meta http-equiv="X-UA-Compatible" content="IE=9; IE=8; IE=7; IE=EDGE" />
	
	<!-- Bootstrap -->
	<link href="bootstrap/css/bootstrap.css?v=1.0" rel="stylesheet" />
	<link href="bootstrap/css/responsive.css?v=1.0" rel="stylesheet" />
	
	<!-- Glyphicons Font Icons -->
	<link href="theme/css/glyphicons.css" rel="stylesheet" />
	
	<!-- Uniform Pretty Checkboxes -->
	<link href="theme/scripts/plugins/forms/pixelmatrix-uniform/css/uniform.default.css" rel="stylesheet" />
	
	<!-- Main Theme Stylesheet :: CSS -->
	<link href="theme/css/style-dark.min.css?1366720687" rel="stylesheet" />
<!-- COLOR Stylesheet :: CSS -->
	<link href="theme/skins/css/default.css" rel="stylesheet" type="text/css" />	
	    <!-- Main Theme Stylesheet :: CSS 
	<link href="theme/css/personalizzazione_stefano.css" rel="stylesheet" />-->
    <asp:Literal ID="literal_stefano" Text="" runat="server"></asp:Literal>

	<!-- LESS.js Library -->
	<script src="theme/scripts/plugins/system/less.min.js"></script>

    <asp:Literal ID="literal_theme" Text="<link id='themer-stylesheet' href='theme/personalizzazione/emecfrance.css' rel='stylesheet' type='text/css' />" runat="server"></asp:Literal>
        <script>
            (function (i, s, o, g, r, a, m) {
                i['GoogleAnalyticsObject'] = r; i[r] = i[r] || function () {
                    (i[r].q = i[r].q || []).push(arguments)
                }, i[r].l = 1 * new Date(); a = s.createElement(o),
                m = s.getElementsByTagName(o)[0]; a.async = 1; a.src = g; m.parentNode.insertBefore(a, m)
            })(window, document, 'script', '//www.google-analytics.com/analytics.js', 'ga');

            ga('create', 'UA-55370521-1', 'auto');
            ga('send', 'pageview');

</script>

</head>
<asp:literal ID="bodyContent" runat="server">
    <body class="login" >
    </asp:literal>
 <form  runat="server">
<div id="login">

	<!-- Box -->
	<div class="form-signin">
        
		<div class="navbar main hidden-print">
         <asp:Literal ID="literal_logo" text="<img src='image/logo_ermes.png' alt='logo'>" runat="server"></asp:Literal>   
		
	
			<!-- Top Menu Right -->
			<ul class="topnav pull-right">
			
				<!-- Language menu -->
				<li class="hidden-phone" id="lang_nav">
                    <asp:Literal ID="Literal3" Text="<a href='#' data-toggle='dropdown'><img src='theme/images/lang/en.png' alt='en' /></a>" runat="server" meta:resourcekey="Literal3Resource1"></asp:Literal>
					
			    	<ul class="dropdown-menu pull-left">
                        <asp:Literal ID="Literal2" Text="<li class='active'><a href='' title='English'><img src='theme/images/lang/en.png' alt='English'> English</a></li>" runat="server" meta:resourcekey="Literal2Resource1"></asp:Literal>
			      		
			      		
			    	</ul>
				</li>
				<!-- // Language menu END -->
			
				<!-- Dropdown -->
				
				<!-- // Dropdown END -->
				
				<!-- Profile / Logout menu -->
				
					</ul>
									</li>
				<!-- // Profile / Logout menu END -->
				
			</ul>
			<!-- // Top Menu Right END -->
			
		</div>
		<!-- Row -->
		<div class="row-fluid row-merge">
		
			<!-- Column -->
			<div class="span12">
				<div class="inner">
				
					<!-- Form -->
					 <form id="validateSubmitForm" method="get" autocomplete="off" novalidate>
                     
  						 <div class="control-group span6">
							<asp:Label class="control-label" ID="Label1" runat="server" Text="Username" meta:resourcekey="Label1Resource1"></asp:Label>
                            <div class="controls">
                               <asp:TextBox class="span12" ID="TextBox1" runat="server" meta:resourcekey="TextBox1Resource1"></asp:TextBox>
							</div>
						</div>   
                                           
                         <div class="control-group span6">
                             
                            <asp:label class='control-label' ID="literal4"  runat="server" Text="Password" meta:resourcekey="literal4Resource1" ></asp:label>
							<div class="controls">
                               <asp:TextBox class="span12" ID="TextBox2" runat="server" TextMode="Password" meta:resourcekey="TextBox2Resource1"></asp:TextBox>
							</div>
						</div>  
                             <div class="row-fluid">
                             <asp:literal  ID="Label2" runat="server" Text="<b style='color:red'>Username e/o Password errato<b>" Visible="False" meta:resourcekey="Label2Resource2" ></asp:literal>
                                 </div>

                        <!-- Andrea Manetta
                       <div class="uniformjs"><label class="checkbox"><input type="checkbox" value="remember-me">Remember me</label></div>
                        Andrea Manetta  -->
                             <!-- riga -->
                <div class="row-fluid">
               	<div class="uniformjs">
             
                       <label class="checkbox">
                           <asp:CheckBox ID="CheckBox1" runat="server" /><asp:literal ID="remember_me" runat="server" text ="Ricordami" meta:resourcekey="remember_meResource"></asp:literal></label>

                 
                    
                </div>
                    <div>
                    <asp:literal ID="Literal1" runat="server" text ="<a class='password' href='remember.aspx'>forgot your password?</a>" meta:resourcekey="Literal1Resource2" ></asp:literal>
                        </div>
                </div>
                 <!-- fine riga -->
                <div>
                    &nbsp
                </div>
						<div class="row-fluid">
							<div class="span5 center">
                                    <asp:Button class="btn btn-block btn-primary" ID="Button1" runat="server" Text="Sign in" meta:resourcekey="Button1Resource1" />
								<!--<button class="btn btn-block btn-primary" type="submit">Sign in</button>-->
							</div>
							<div class="span2 center">&nbsp</div>
							<div class="span5 center">
                                <asp:Button class="btn btn-block btn-info" ID="Button2" runat="server" Text="Sign up" meta:resourcekey="Button2Resource1" />
								<!--<a href="signup.html?lang=en&amp;layout_type=fluid&amp;menu_position=menu-left&amp;style=style-dark" class="btn btn-block btn-info">Sign up</a>-->
							</div>
						</div>
					</form>
					<!-- // Form END -->
					
				</div>
			</div>
			<!-- // Column END -->
			
			<!-- Column 
			<div class="span5">
				<div class="inner center">
				  <p>&nbsp;</p><p>&nbsp;</p>
                    <p> <asp:literal ID = "Literal5"  text="Download Ermes Software Windows version" runat="server" meta:resourcekey="Literal5Resource1"></asp:literal></p>
                    <p>&nbsp;</p>
                    <div class="inner center">
                        <a href="http://www.emec.it/download/ermes.zip"><span class="btn btn-primary btn-warning">Download</span></a>
                         </div>
                   </div>
                           
			</div>
                -->
			<!-- // Column END -->
			
		</div>
		<!-- // Row END -->
		
	
	</div>
	<!-- // Box END -->
	
</div>
<!-- // Wrapper END -->	

	<!-- JQuery -->
	<script src="theme/scripts/plugins/system/jquery.min.js"></script>
	
	<!-- JQueryUI -->
	<script src="theme/scripts/plugins/system/jquery-ui/js/jquery-ui-1.9.2.custom.min.js"></script>
	
	<!-- JQueryUI Touch Punch -->
	<!-- small hack that enables the use of touch events on sites using the jQuery UI user interface library -->
	<script src="theme/scripts/plugins/system/jquery-ui-touch-punch/jquery.ui.touch-punch.min.js"></script>

	<!-- Modernizr -->
	<script src="theme/scripts/plugins/system/modernizr.js"></script>
	
	<!-- Bootstrap -->
	<script src="bootstrap/js/bootstrap.min.js"></script>
	
	<!-- SlimScroll Plugin -->
	<script src="theme/scripts/plugins/other/jquery-slimScroll/jquery.slimscroll.min.js"></script>
	
	<!-- Common Demo Script -->
	<script src="theme/scripts/demo/common.js?1366720887"></script>
	
	<!-- Holder Plugin -->
	<script src="theme/scripts/plugins/other/holder/holder.js"></script>
	
	<!-- Uniform Forms Plugin -->
	<script src="theme/scripts/plugins/forms/pixelmatrix-uniform/jquery.uniform.min.js"></script>
	
    
    <!-- jQuery Validate Plugin -->
	<script src="theme/scripts/plugins/forms/jquery-validation/dist/jquery.validate.min.js"></script>
	
	<!-- Form Validator Page Demo Script -->
	<script src="theme/scripts/demo/login_validator.js"></script>
    
        
        
    


	<!-- Global -->
	<script>
	    var basePath = '';
	</script>
 <div id="footer" class="hidden-print" style="position:fixed;bottom:0;width:100%;">
        <div class="copy" style="text-align:right;padding-right:50px;">powered by ERMES | Software by <a href="http://www.emec.it" target="_blank">EMEC S.r.l.</a> - Current version: v1.4 </div></div>

    </form>
</body>
</html>

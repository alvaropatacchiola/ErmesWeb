<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="remember.aspx.vb" Inherits="ermes_web_20.remember" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
	<!-- Meta -->
	<meta charset="UTF-8" />
	<meta name="viewport" content="width=device-width, initial-scale=1.0, user-scalable=0, minimum-scale=1.0, maximum-scale=1.0">
	<meta name="apple-mobile-web-app-capable" content="yes">
	<meta name="apple-mobile-web-app-status-bar-style" content="black">
	<meta http-equiv="X-UA-Compatible" content="IE=9; IE=8; IE=7; IE=EDGE" />
	
	<!-- Bootstrap -->
	<link href="bootstrap/css/bootstrap.css" rel="stylesheet" />
	<link href="bootstrap/css/responsive.css" rel="stylesheet" />
	
	<!-- Glyphicons Font Icons -->
	<link href="theme/css/glyphicons.css" rel="stylesheet" />
	
	<!-- Uniform Pretty Checkboxes -->
	<link href="theme/scripts/plugins/forms/pixelmatrix-uniform/css/uniform.default.css" rel="stylesheet" />
	
		<!-- Main Theme Stylesheet :: CSS -->
	<link href="theme/css/style-dark.min.css?1366720687" rel="stylesheet" />
<!-- COLOR Stylesheet :: CSS -->
	<link href="theme/skins/css/default.css" rel="stylesheet" type="text/css" />

    <asp:Literal ID="literal_stefano" Text="" runat="server"></asp:Literal>
   

	<!-- LESS.js Library -->
	<script src="theme/scripts/plugins/system/less.min.js"></script>
    <asp:Literal ID="literal_theme" Text="<link id='themer-stylesheet' href='theme/personalizzazione/emecfrance.css' rel='stylesheet' type='text/css' />" runat="server"></asp:Literal>
</head>
<body class="login">
    <form id="form1" runat="server">
<div id="login">

	<!-- Box -->
	<div class="form-signin">
		
		<div class="navbar main hidden-print">
            <asp:Literal ID="Literal3" runat="server" Text="<h3 style='background-color:transparent;padding-top:10px;'>Hai problemi di accesso?</h3>" meta:resourcekey="Literal3Resource1" ></asp:Literal>
            
	  
	
			<!-- Top Menu Right -->
			
									
			<!-- // Top Menu Right END -->
			
		</div>
		<!-- Row -->
		<div class="row-fluid row-merge">
		
			<!-- Column -->
			<div class="span12">
				<div class="inner">
                    <asp:Literal ID="Literal1" runat="server" Text="<p>Non Ricordo la mia Username e/o Password	</p><p>&nbsp;</p>" meta:resourcekey="Literal1Resource1" ></asp:Literal>
					<asp:Literal ID="Literal2" runat="server" Text="<p>Inserisci l'indirizzo e-mail e ti invieremo le credenziali di Accesso</p>	<p>&nbsp;</p>" meta:resourcekey="Literal2Resource1" ></asp:Literal>
<div class="control-group">
							
                        <asp:Literal ID="Literal4" Text="Inirizzo email" runat="server" meta:resourcekey="Literal4Resource1" ></asp:Literal> 
							<div class="controls"><asp:textbox class="span12" runat="server"  id="email_val" name="mail" type="text" meta:resourcekey="email_valResource1" /></div>
						</div>
                    <asp:Literal ID="Literal5" runat="server" Text="<p><b style ='color:red;'>Abbiamo Inviato una mail con le credenziali di accesso ad ermes-server.com</b></p>	<p>&nbsp;</p>" Visible="False" meta:resourcekey="Literal5Resource1" ></asp:Literal>
                    <asp:Literal ID="Literal6" runat="server" Text="<p><b style ='color:red;'>Indirizzo mail non presente nel nostro Database</b></p>	<p>&nbsp;</p>" Visible="False" meta:resourcekey="Literal6Resource1" ></asp:Literal>
                    <div class="row-fluid">
							<div class="span5 center">
                                    <asp:Button class="btn btn-block btn-primary" ID="Button1" runat="server" Text="Invia"  OnClientClick="return (check_button1());" meta:resourcekey="Button1Resource1" />
								<!--<button class="btn btn-block btn-primary" type="submit">Sign in</button>-->
							</div>
							<div class="span2 center">or</div>
							<div class="span5 center">
                                <asp:Button class="btn btn-block btn-info" ID="Button2" runat="server" Text="Esci" meta:resourcekey="Button2Resource1"  />
								<!--<a href="signup.html?lang=en&amp;layout_type=fluid&amp;menu_position=menu-left&amp;style=style-dark" class="btn btn-block btn-info">Sign up</a>-->
							</div>
						</div>
                    <div>
                        &nbsp;
                    </div>
				</div>
			</div>
			<!-- // Column END -->
			
			<!-- Column --><!-- // Column END -->
			
		</div>
		<!-- // Row END -->
		
	
	</div>
	<!-- // Box END -->
	
</div>
        <asp:Literal ID="java_script_local" runat="server" meta:resourcekey="java_script_localResource1" ></asp:Literal>
        

    </form>

    <script src="common/validator_general_remember.js"></script>
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
</body>
</html>
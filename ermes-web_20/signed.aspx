<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="signed.aspx.vb" Inherits="ermes_web_20.signed" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
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
	<link href="theme/css/style-dark.min.css?1366720685" rel="stylesheet" />
<!-- COLOR Stylesheet :: CSS -->
	<link href="theme/skins/css/default.css" rel="stylesheet" type="text/css" />

   

	<!-- LESS.js Library -->
	<script src="theme/scripts/plugins/system/less.min.js"></script>
</head>
<body class="login">
    <form id="form1" runat="server">
<div id="login">

	<!-- Box -->
	<div class="form-signin">
		
		<div class="navbar main hidden-print">
            <asp:Literal ID="Literal3" runat="server" Text="<h3 style='background-color:transparent;padding-top:10px;'>Your account is ready</h3>" meta:resourcekey="Literal3Resource1"></asp:Literal>
            <asp:Literal ID="Literal4" runat="server" Text="<h3 style='background-color:transparent;padding-top:10px;'>Your account is NOT ready</h3>" meta:resourcekey="Literal4Resource1"></asp:Literal>
	  
	
			<!-- Top Menu Right -->
			
									
			<!-- // Top Menu Right END -->
			
		</div>
		<!-- Row -->
		<div class="row-fluid row-merge">
		
			<!-- Column -->
			<div class="span12">
				<div class="inner">
                    <asp:Literal ID="Literal1" runat="server" Text="<p>Grazie per esserti registrato su ERMES.</p><p>Il tuo account è stato creato e attivato.Registra un impianto entro 2gg altrimenti Il tuo Account sarà disattivato</p>	<p>&nbsp;</p>" meta:resourcekey="Literal1Resource1"></asp:Literal>
					<asp:Literal ID="Literal2" runat="server" Text="<p>Registrazione Fallita.</p><p>Username e Password Duplicati</p>	<p>&nbsp;</p>" meta:resourcekey="Literal2Resource1"></asp:Literal>
				</div>
			</div>
			<!-- // Column END -->
			
			<!-- Column --><!-- // Column END -->
			
		</div>
		<!-- // Row END -->
		
	
	</div>
	<!-- // Box END -->
	
</div>
<div id="footer" class="hidden-print" style="position:fixed;bottom:0;width:100%;">
        <div class="copy" style="text-align:right;padding-right:50px;">powered by ERMES | Software by <a href="http://www.emec.it" target="_blank">EMEC S.r.l.</a> - Current version: v1.4 </div></div>

    </form>
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

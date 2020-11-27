<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="signup.aspx.vb" Inherits="ermes_web_20.signup" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
	<title>Create Account</title>
	
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
	
	<!-- Wrapper -->
<div id="login">

	<!-- Box -->
	<div class="form-signin">
    <div class="navbar main hidden-print">
	  <h3 style="background-color:transparent;padding-top:10px;">
    <asp:Literal ID="Literal2" Text="Create Account" runat="server" meta:resourcekey="Literal2Resource1"></asp:Literal> <span style="color:#000"><asp:Literal ID="Literal3" Text="Already a member?" runat="server" meta:resourcekey="Literal3Resource1"></asp:Literal> <asp:Literal ID="Literal1" Text="<a href='login.html?lang=en&amp;layout_type=fluid&amp;menu_position=menu-left&amp;style=style-dark'>Sign in</a>" runat="server" meta:resourcekey="Literal1Resource1"></asp:Literal></span></h3>
	  </div>
	  <!-- Form -->
		
		 <form id="validateSubmitForm" method="post" autocomplete="off"  action="signed.aspx">
		<!-- Row -->
		<div class="row-fluid row-merge">
		
			<!-- Column -->
			<div class="span6">
				<div class="inner">
                
               			
                    <div class="control-group">
							
                        <asp:Literal ID="Literal4" Text="Company" runat="server" meta:resourcekey="Literal4Resource1"></asp:Literal> 
							<div class="controls"><input class="span12" id="company" name="company" type="text" /></div>
						</div>
                        
                     <div class="control-group">
							<asp:Literal ID="Literal5" Text="Username" runat="server" meta:resourcekey="Literal5Resource1"></asp:Literal>
							<div class="controls"><input class="span12" id="username" name="username" type="text" /></div>
						</div>
                     
                     <div class="control-group">
							<asp:Literal ID="Literal6" Text="Password" runat="server" meta:resourcekey="Literal6Resource1"></asp:Literal>
							<div class="controls"><input class="span12" id="password" name="password" type="password" /></div>
						</div>
                        
                    <div class="control-group">
							<asp:Literal ID="Literal7" Text="Confirm Password" runat="server" meta:resourcekey="Literal7Resource1"></asp:Literal>
							<div class="controls"><input class="span12" id="confirm_password" name="confirm_password" type="password" /></div>
						</div>
                    <!--
                  <p>Having troubles? <a href="faq.html?lang=en&amp;layout_type=fluid&amp;menu_position=menu-left&amp;style=style-dark">Get Help</a></p>
		   -->
                   
				</div>
			</div>
			<!-- // Column END -->
			
			<!-- Column -->
			<div class="span6">
				<div class="inner">
					    <div class="control-group">
							<asp:Literal ID="Literal8" Text="Email" runat="server" meta:resourcekey="Literal8Resource1"></asp:Literal>
							<div class="controls"><input class="span12" id="email" name="email" type="text" /></div>
						</div>
                        
                    <div class="control-group">
							<asp:Literal ID="Literal9" Text="Confirm Email" runat="server" meta:resourcekey="Literal9Resource1"></asp:Literal>
							<div class="controls"><input class="span12" id="confirm_email" name="confirm_email" type="text" /></div>
						</div>
                        
                       
        
                <div class="control-group">
							<div class="controls"><input type="checkbox" class="checkbox" id="agree" name="agree" /></div>
							
                    
                    <asp:Literal ID="Literal10" Text="<a href='#' id='opener'>Please agree to our policy</a>" runat="server" meta:resourcekey="Literal10Resource1"></asp:Literal>
						</div>    
                    


                    
                    <div class="form-actions">
                    <button type="submit" class="btn btn-icon-stacked btn-block btn-success glyphicons user_add"><i></i><span><asp:Literal ID="Literal11" Text="Create account and" runat="server" meta:resourcekey="Literal11Resource1"></asp:Literal></span><span class="strong"><asp:Literal ID="Literal12" Text="Join Ermes now" runat="server" meta:resourcekey="Literal12Resource1"></asp:Literal></span></button>
                    </div>
                    
                   </div>
			</div>
			<!-- // Column END -->
			
		</div>
		<!-- // Row END -->
		
		</form>

    

   <!-- // Form END -->
   <div class="ribbon-wrapper"><div class="ribbon success"><asp:Literal ID="Literal13" Text="Register" runat="server" meta:resourcekey="Literal13Resource1"></asp:Literal></div></div>

	</div>
	<!-- // Box END -->
	
</div>
<!-- // Wrapper END -->	
    <asp:Literal ID="java_script_local" runat="server" meta:resourcekey="java_script_localResource1"></asp:Literal>
    
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
	<script src="theme/scripts/demo/common.js?1366720892"></script>
	
	<!-- Holder Plugin -->
	<script src="theme/scripts/plugins/other/holder/holder.js"></script>
	
	<!-- Uniform Forms Plugin -->
	<script src="theme/scripts/plugins/forms/pixelmatrix-uniform/jquery.uniform.min.js"></script>
	
    <!-- jQuery Validate Plugin -->
	<script src="theme/scripts/plugins/forms/jquery-validation/dist/jquery.validate.min.js"></script>
	
       <!-- Form Validator Page Demo Script -->
	<script src="theme/scripts/demo/form_validator.js"></script>
    
    
      

    
	<!-- Global -->
	<script>
	    var basePath = '';
	  
	</script>
    

<div id="footer" class="hidden-print" style="position:fixed;bottom:0;width:100%;">
        <div class="copy" style="text-align:right;padding-right:50px;">powered by ERMES | Software by <a href="http://www.emec.it" target="_blank">EMEC S.r.l.</a> - Current version: v1.4 </div></div>
	
	
</body>
</html>

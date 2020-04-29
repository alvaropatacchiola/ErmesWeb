<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="error.aspx.vb" Inherits="ermes_web_20._error" %>

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

    <asp:Literal ID="literal_theme" Text="<link id='themer-stylesheet' href='theme/personalizzazione/emecfrance.css' rel='stylesheet' type='text/css' />" runat="server"></asp:Literal>
</head>

<body>
    <form id="form1" runat="server">
<div class="container"> 

<!-- Box --> 
<div class="hero-unit well"> 
<h1>Sorry! <span></span></h1> 
<hr class="separator" /> 
<!-- Row --> 
<div class="row-fluid row-merge"> 

<!-- Column --> 
<div class="span6"> 
<div class="innerAll center"> 
<p> we were unable to fulfill your request. Please try again!
If problem still continues please contact assistance...
</p> 
</div> 
</div> 
<!-- // Column END --> 

<!-- Column --> 
<div class="span6"> 
<div class="innerAll center"> 
<p>Is this a serious error? <a href="mailto:alvaro.patacchiola@emec.it?Subject=Ermes-Server Error">Let us know</a></p> 
<div class="row-fluid"> 
<div class="span6"> 
<a href="login.aspx" class="btn btn-icon-stacked btn-block btn-success glyphicons user_add"><i></i><span>Go Login Page</span><span class="strong">Try Again</span></a> 
</div> 
<div class="span6"> 
<a href="mailto:alvaro.patacchiola@emec.it?Subject=Ermes-Server Error" class="btn btn-icon-stacked btn-block btn-danger glyphicons circle_question_mark"><i></i><span>Support Center</span><span class="strong">Send E-Mail</span></a> 
</div> 
</div> 
</div> 
</div> 
<!-- // Column END --> 

</div> 
<!-- // Row END --> 

</div> 
<!-- // Box END --> 

</div> 
    <div>
    
    </div>
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
    </form>
</body>
</html>

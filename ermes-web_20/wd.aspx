<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/main.Master" CodeBehind="wd.aspx.vb" Inherits="ermes_web_20.wd" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>
<%@ MasterType VirtualPath="~/main.Master"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="https://maps.googleapis.com/maps/api/js?v=3.exp&sensor=false"></script>
            <link href="chart/js/css/jquery.dataTables.css" rel="stylesheet" />
    <link href="chart/js/css/dataTables.tableTools.css" rel="stylesheet" />
    
<script type="text/javascript" src="chart/localCent/jquery.dataTables.js"></script>
<script type="text/javascript" src="chart/localCent/jquery.dataTables.min.js"></script>
<script type="text/javascript" src="chart/localCent/dataTables.buttons.min.js"></script>
<script type="text/javascript" src="chart/localCent/buttons.flash.min.js"></script>
<script type="text/javascript" src="chart/localCent/jszip.min.js"></script>
<script type="text/javascript" src="chart/localCent/pdfmake.min.js"></script>
<script type="text/javascript" src="chart/localCent/vfs_fonts.js"></script>
<script type="text/javascript" src="chart/localCent/buttons.html5.min.js"></script>
<script type="text/javascript" src="chart/localCent/buttons.print.min.js"></script>
<link href="chart/localCent/buttons.dataTables.min.css" rel="stylesheet" />
   <!-- <script src="chart/js/jquery.dataTables.js"></script>
    <script src="chart/js/dataTables.tableTools.js"></script> -->
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- Content -->
<div id="content">
			

<asp:Label ID="Label28" runat="server" Text="<h3 class='heading-mosaic'>Overview</h3>" meta:resourcekey="Label28Resource1"></asp:Label>

    <div class="innerLR">

	<!-- Quick Tabs Widget -->
	<div class="widget widget-tabs widget-quick hidden-print">
	
		<!-- Tabs Widget Heading -->
		<div class="widget-head">
			<ul>
				<li class="active"><a href="#quickIndexTab" data-toggle="tab" class="glyphicons cogwheels"><i></i>
                        <asp:Label ID="Label8" runat="server" Text="Dati impianto" meta:resourcekey="Label8Resource1"></asp:Label></a></li>
				<li><a href="#quickPhotosTab" data-toggle="tab" class="glyphicons google_maps"><i></i>
                            <asp:Label ID="Label9" runat="server" Text="Mappa" meta:resourcekey="Label9Resource1"></asp:Label></a></li>
			</ul>
		</div>
		<!-- // Tabs Widget Heading END -->
		
		<div class="widget-body">
			<div class="tab-content">
			
				<!-- Quick Index Tab -->
				<div class="tab-pane active" id="quickIndexTab">
					<div class="row-fluid">
					<div class="span8">
						<!-- descrizione impianto -->
							
                            <asp:Label ID="Label6" runat="server" Text="<h4>Impianto di prova</h4>" meta:resourcekey="Label6Resource1"></asp:Label>
							 <asp:Label ID="Label2" runat="server" Text="<h5><span>CODE:</span><strong>999666</strong></h5>" meta:resourcekey="Label2Resource1"></asp:Label> 
							<p><asp:Label ID="Label1" runat="server" Text="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Maecenas convallis porta purus, pulvinar mattis nulla tempus ut. Curabitur quis dui orci. Ut nisi dolor, dignissim a aliquet quis, vulputate id dui. Proin ultrices ultrices ligula, dictum varius turpis faucibus non. Curabitur faucibus ultrices nunc, nec aliquet leo tempor cursus." meta:resourcekey="Label1Resource1"></asp:Label></p>
        
							<!-- // descrizione impianto END -->
							
							<!-- referente Section -->
							
                            <asp:Label ID="Label7" runat="server" Text="<h5>Referente</h5>" meta:resourcekey="Label7Resource1"></asp:Label>
						
							<ul class="unstyled icons">
								<li class="glyphicons user"><i></i> <asp:Label ID="Label3" runat="server" Text="Daniele Leonetti" meta:resourcekey="Label3Resource1"></asp:Label></li>
								<li class="glyphicons phone"><i></i> <asp:Label ID="Label4" runat="server" Text="338 98 74 414" meta:resourcekey="Label4Resource1"></asp:Label></li>
								<li class="glyphicons e-mail"><i></i><asp:Label ID="Label5" runat="server" Text="daniele.leonetti@emec.it" meta:resourcekey="Label5Resource1"></asp:Label></li>
										</ul>
						
							<!-- referente Section END -->
							
						</div>
						<div class="span4">
						
							<!-- Bio -->
							<asp:Label ID="Label11" runat="server" Text="<h5>Statistiche</h5>" meta:resourcekey="Label11Resource1"></asp:Label>
							<div class="separator bottom"></div>
							<ul class="unstyled icons">
                                <li class='glyphicons calendar'>
                                <asp:Label ID="Label12" runat="server" Text="<i></i> <span class='label'>10</span> <span class='label'>July</span> <span class='label'>1986</span> <span class='label'>18:56</span>" meta:resourcekey="Label12Resource1"></asp:Label>
                                    <!--
                                    <asp:HyperLink ID="refresh_link" runat="server" ClientIDMode="Static" ImageUrl="~/image/refresh.png" NavigateUrl="~/impianto.aspx"></asp:HyperLink>
                                        -->
                                    </li>
								<!-- 
								<li class="glyphicons tie"><i></i> Working at <a href="http://www.mosaicpro.biz">MosaicPro</a></li>
								<li class="glyphicons certificate"><i></i> Adobe Photoshop Certification</li>
								<li class="glyphicons microphone"><i></i> English :: French :: Italian :: Romanian :: Polish</li> -->
                                
                               
							</ul>
                            <asp:Label ID="Label13" runat="server" meta:resourcekey="Label13Resource1"></asp:Label>
                           
							
						</div>
					</div>
				</div>
				<!-- // Quick Index Tab END -->
				
				<!-- Quick Photos Tab -->
				<div class="tab-pane" id="quickPhotosTab">
				
					<!-- Tabs -->
					<asp:Literal ID="literal_map" runat="server"></asp:Literal>
	<!-- // Quick Tabs Widget END -->
	
</div>

</div>
</div>
        
<div id="indietro" class="btn-primary">
                            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/dashboardNew.aspx" ><b class="btn-primary btn-icon glyphicons circle_arrow_left" ><i></i>Dashboard</b></asp:HyperLink></div>
        
</div>
</div>

	<div class="separator bottom">
        
           </div>
	<!-- // Stats Widgets END -->
 
    
    
    <asp:Label ID="Label17" runat="server" Text="<h3 class='heading-mosaic'>01 | WD Test</h3>" meta:resourcekey="Label17Resource1"></asp:Label>
    
    <div class="row-fluid">
    <div class="innerLR">
       <div id="menu_strumento">
               
    <ul class="nav nav-pills">
           </ul>
        <asp:literal ID="Label33" runat="server" Text="<li class='active'><a id ='channels_id' href='#'>Channels</a></li>" ></asp:literal>
            <li class="dropdown" id="setpoint_li"><a class="dropdown-toggle" data-toggle="dropdown" href='#'><asp:Label ID="Label19" runat="server" Text="Set Point" meta:resourcekey="Label19Resource1"></asp:Label><span class="caret"></span></a>
                <ul class="dropdown-menu">
                   
                    <asp:literal ID="Label29" runat="server" Text="<li><a id ='setpoint_wd' href='#'>Log Ch1 </a></li>" meta:resourcekey="Label29Resource1"></asp:literal>
                    <asp:literal ID="Label24" runat="server" Text="<li><a id ='max_stroke_wd' href='#'>Max Strokes Settings</a></li>" meta:resourcekey="Label24Resource1"></asp:literal>
                    <asp:literal ID="Label26" runat="server" Text="<li><a id ='auto_setpoint' href='#'>Auto Setpoint Settings</a></li>" meta:resourcekey="Label26Resource1"></asp:literal>
                </ul>
            </li>


            <li class="dropdown" id="alarm_li"></li>
           <a class="dropdown-toggle" data-toggle="dropdown" href='#'><asp:Label ID="Label21" runat="server" Text="Alarm" meta:resourcekey="Label21Resource1"></asp:Label><span class="caret"></span></a>
                <ul class="dropdown-menu">

                        <asp:literal ID="Label10" runat="server" Text="<li><a id ='flow_wd' href='#'>Flow</a></li>" meta:resourcekey="Label10Resource1"></asp:literal>
                        <asp:literal ID="Label14" runat="server" Text="<li><a id ='probe_failure_wd' href='#'>Probe Failure</a></li>" meta:resourcekey="Label14Resource1"></asp:literal>
                        <asp:literal ID="Label16" runat="server" Text="<li><a id ='dosing_alarm_wd' href='#'>Dosing Alarm</a></li>" meta:resourcekey="Label16Resource1"></asp:literal>
                        <asp:literal ID="Label25" runat="server" Text="<li><a id ='digital_input_wd' href='#'>Digital Input</a></li>" meta:resourcekey="Label25Resource1"></asp:literal>
                    <asp:literal ID="Label30" runat="server" Text="<li><a id ='alert_wd' href='#'>Alert</a></li>" meta:resourcekey="Label30Resource1"></asp:literal>
                    <asp:literal ID="Label31" runat="server" Text="<li><a id ='pagamento_wd' href='#'>TimerP</a></li>" meta:resourcekey="Label31Resource1"></asp:literal>
                    <asp:literal ID="Label77" runat="server" Text="<li><a id ='reset_all_wd' href='#'>Reset</a></li>" meta:resourcekey="Label77Resource1"></asp:literal>

                </ul>
             </li>		
                <asp:literal ID="Label27" runat="server" Text="<li><a id ='parametersld_id' href='#'>Parameters</a></li>" meta:resourcekey="Label27Resource1"></asp:literal>
            <asp:literal ID="Label20" runat="server" Text="<li><a id ='internationalwd_id' href='#'>International</a></li>" meta:resourcekey="Label20Resource1"></asp:literal>
               
        <asp:literal ID="Literal1" runat="server" Text="<li><a id ='manual_wd_id' href='#'>Manual</a></li>" meta:resourcekey="Literal1Resource1"></asp:literal>
       <asp:literal ID="Literal2" runat="server" Text="<li><a id ='messagge_wd_id' href='#'>Message</a></li>" meta:resourcekey="Literal2Resource1"></asp:literal>
        <asp:literal ID="Literal3" runat="server" Text="<li><a id ='calibration_wld_id' href='#'>Calibration</a></li>" meta:resourcekey="Literal3Resource1"></asp:literal>

        
         <asp:literal ID="Label22" runat="server" Text="<li><a id ='logsetupld_id' href='#'>Log Setup</a></li>" meta:resourcekey="Label22Resource1"></asp:literal>
        <asp:literal ID="Literal4" runat="server" Text="<li><a id ='Log_1' href='#'>Log</a></li>"  meta:resourcekey="Label15Resource1"></asp:literal>
        <asp:literal ID="Literal5" runat="server" Text="<li><a id ='Log_2' href='#'>Log</a></li>"  ></asp:literal>


        
    </div>

    <div class="separator bottom"></div>
    </div>
    </div>
    
    
    <div id="principale_alert" style="z-index:10000; position:absolute" >
    </div>

<div id="principale" class="innerLR" >

         
</div>
<script type="text/javascript">
    //$(document).ready(function () {
    var opts = {
        lines: 13, // The number of lines to draw
        length: 9, // The length of each line
        width: 4, // The line thickness
        radius: 8, // The radius of the inner circle
        corners: 1, // Corner roundness (0..1)
        rotate: 0, // The rotation offset
        direction: 1, // 1: clockwise, -1: counterclockwise
        color: color_general, // #rgb or #rrggbb or array of colors
        speed: 1, // Rounds per second
        trail: 60, // Afterglow percentage
        shadow: false, // Whether to render a shadow
        hwaccel: false, // Whether to use hardware acceleration
        className: 'spinner', // The CSS class to assign to the spinner
        zIndex: 2e9, // The z-index (defaults to 2000000000)
        top: 'auto', // Top position relative to parent in px
        left: 'auto' // Left position relative to parent in px
    };
    var sPageURL = window.location.search.substring(1);
    var target = document.getElementById('principale');
    var spinner = new Spinner(opts).spin(target);
    var i = 0;
    var val;
    var indice = 0;
    var RefreshID;
    sPageURL = sPageURL.replace(' ', '$'); // replace dello spazio con il $, da fastidio alla url nei parametri
    var pagina_split = sPageURL.split('&');
    for (i = 0; i < pagina_split.length; i++) {
        val = pagina_split[i].split("=");
        if (val[0] == 'pagina') {
            indice = parseInt(val[1]);
        }
    }
    
    carica_pagina(indice);
    function carica_spinner() {
        if (spinner) spinner.stop();
        spinner = new Spinner(opts).spin(target);

    }
    function StopRefresh() {
        clearInterval(RefreshID);
    }

    function RestartRefresh() {
        RefreshID = setInterval("window.location.reload()", 600000);
    }

    function carica_pagina(indice) {
        if (spinner) spinner.stop();
        spinner = new Spinner(opts).spin(target);
        sPageURL = sPageURL.replace(' ', '$'); // replace dello spazio con il $, da fastidio alla url nei parametri
        switch (indice) {
            case 0:
                evidenzia("", "#channels_id");
                RestartRefresh();
                $("#principale").load("wd/main_wd.aspx?" + sPageURL);
                break;
            case 1:
                evidenzia("alarm_li", "#Probe_Failure_wd");
                StopRefresh();
                $("#principale").load("wd/Probe_Failure_wd.aspx?page=3&" + sPageURL);
                break;
            case 2:
                evidenzia("alarm_li", "#Dosing_Alarm_wd");
                StopRefresh();
                $("#principale").load("wd/Dosing_Alarm_wd.aspx?page=4&" + sPageURL);
                break;
            case 3:
                evidenzia("alarm_li", "#Flow_Alarm_wd");
                StopRefresh();
                $("#principale").load("wd/Flow_Alarm_wd.aspx?page=5&" + sPageURL);
                break;
            case 4:
                evidenzia("alarm_li", "#Digital_inputs_wd");
                StopRefresh();
                $("#principale").load("wd/Digital_inputs_wd.aspx?page=5&" + sPageURL);
                break;
            case 5:
                evidenzia("", "#parameters_wd");
                StopRefresh();
                $("#principale").load("wd/parameters_wd.aspx?page=5&" + sPageURL);
                break;
            case 6:
                evidenzia("", "#international_wd");
                StopRefresh();
                $("#principale").load("wd/international_wd.aspx?page=5&" + sPageURL);
                break;
            case 7:
                evidenzia("", "#log_setup_wd");
                StopRefresh();
                $("#principale").load("wd/log_setup_wd.aspx?" + sPageURL);
                break;
            case 8:
                evidenzia("", "#Log_1");
                StopRefresh();
                $("#principale").load("chart/log_wd.aspx?" + sPageURL);
                break;
            case 9:
                evidenzia("", "#Log_2");
                StopRefresh();
                $("#principale").load("chart/log_wh.aspx?" + sPageURL);
                break;
            case 10:
                evidenzia("setpoint_li", "#setpoint_wd_2_magneti");
                StopRefresh();
                $("#principale").load("wd/setpoint_wd_2_magneti.aspx?" + sPageURL);
                break;
            case 11:
                evidenzia("setpoint_li", "#max_strokes_2_magneti");
                StopRefresh();
                $("#principale").load("wd/max_strokes_2_magneti.aspx?" + sPageURL);
                break;
            case 12:
                evidenzia("setpoint_li", "#setpoint_wd_S");
                StopRefresh();
                $("#principale").load("wd/setpoint_wd_S.aspx?" + sPageURL);
                break;
            case 13:
                evidenzia("setpoint_li", "#max_strokes_S");
                StopRefresh();
                $("#principale").load("wd/max_strokes_S.aspx?" + sPageURL);
                break;
            case 14:
                evidenzia("setpoint_li", "#setpoint_wd_EV");
                StopRefresh();
                $("#principale").load("wd/setpoint_wd_EV.aspx?" + sPageURL);
                break;

            case 15:
                evidenzia("setpoint_li", "#setpoint_wd_PER");
                StopRefresh();
                $("#principale").load("wd/setpoint_wd_PER.aspx?" + sPageURL);
                break;

            case 16:
                evidenzia("", "#manual_wd");
                StopRefresh();
                $("#principale").load("wd/manual_wd.aspx?" + sPageURL);
                break;
            case 17:
                evidenzia("", "#message_wd");
                StopRefresh();
                $("#principale").load("wd/message_wd.aspx?" + sPageURL);
                break;
            case 18:
                evidenzia("", "#calibration_wd");
                StopRefresh();
                $("#principale").load("wd/calibration_wd.aspx?" + sPageURL);
                break;
            case 19:
                evidenzia("setpoint_li", "#auto_setpoint");
                StopRefresh();
                $("#principale").load("wd/auto_sepoint.aspx?" + sPageURL);
                break;
            case 20:
                evidenzia("alarm_li", "#assistenza");
                StopRefresh();
                $("#principale").load("wd/assistenza.aspx?page=5&" + sPageURL);
                break;
            case 21:
                evidenzia("alarm_li", "#alert");
                StopRefresh();
                $("#principale").load("wd/alert.aspx?page=5&" + sPageURL);
                break;

            case 22:
                evidenzia("", "#parameters_wd_140");
                StopRefresh();
                $("#principale").load("wd/parameters_wd_140.aspx?" + sPageURL);
                break;

            case 23:
                evidenzia("alarm_li", "#Probe_Failure_wd_140");
                StopRefresh();
                $("#principale").load("wd/Probe_Failure_wd_140.aspx?page=23&" + sPageURL);
                break;
            case 24:
                evidenzia("alarm_li", "#Dosing_Alarm_wd_140");
                StopRefresh();
                $("#principale").load("wd/Dosing_Alarm_wd_140.aspx?page=24&" + sPageURL);
                break;

            case 25:
                evidenzia("alarm_li", "#reset_all_PER");
                StopRefresh();
                $("#principale").load("wd/reset_all_PER.aspx?page=25&" + sPageURL);
                break;

        }
    }
    $("#channels_id").click(function () {
        carica_pagina(0);

    });
    $("#Probe_Failure_wd").click(function () {
        carica_pagina(1);
        
    });
    $("#Dosing_Alarm_wd").click(function () {
        carica_pagina(2);
        
    });
    $("#Flow_Alarm_wd").click(function () {
        carica_pagina(3);
        
    });
    $("#Digital_inputs_wd").click(function () {
        carica_pagina(4);
        
    });
    $("#parameters_wd").click(function () {
        carica_pagina(5);
        
    });

    $("#international_wd").click(function () {
        carica_pagina(6);
        
    });


    $("#log_setup_wd").click(function () {
        carica_pagina(7);
    });
    $("#Log_1").click(function () {
        carica_pagina(8);
    });
    $("#Log_2").click(function () {
        carica_pagina(9);
    });

    $("#setpoint_wd_2_magneti").click(function () {
       carica_pagina(10);
    });
    $("#max_strokes_2_magneti").click(function () {

        carica_pagina(11);

    });

    $("#setpoint_wd_S").click(function () {

        carica_pagina(12);

    });

    $("#max_strokes_S").click(function () {

        carica_pagina(13);

    });

    $("#setpoint_wd_EV").click(function () {

        carica_pagina(14);

    });

    $("#setpoint_wd_PER").click(function () {

        carica_pagina(15);

    });

    $("#manual_wd").click(function () {
        carica_pagina(16);

    });
    $("#message_wd").click(function () {
        carica_pagina(17);

    });
    $("#calibration_wd").click(function () {
        carica_pagina(18);

    });
   
    $("#auto_setpoint").click(function () {
       carica_pagina(19);

    });
    $("#assistenza").click(function () {
        carica_pagina(20);

    });
    $("#alert").click(function () {
        carica_pagina(21);

    });

    $("#parameters_wd_140").click(function () {
        carica_pagina(22);

    });
    $("#Probe_Failure_wd_140").click(function () {
        carica_pagina(23);
        
    });
    $("#Dosing_Alarm_wd_140").click(function () {
        carica_pagina(24);
        
    });
    $("#reset_all_PER").click(function () {
        carica_pagina(25);
        
    });

    
   



    /*
          
          gestione refresh pagina
          */
    $("#refresh_link").click(function () {

        if (spinner) spinner.stop();
        spinner = new Spinner(opts).spin(target);
        return true;
    });


    function evidenzia(item_group, oggetto) {
        $("li").removeClass("active");

        var item = $(oggetto).parent();
        item.addClass("active");

        if (item_group != "") {

            $("#" + item_group).removeClass("active");
            $("#" + item_group).addClass("active");
        }
    }
</script> 
<div style="padding-bottom:100px;"></div>
</div>

   

		<!-- // Content END -->
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="script_at_end" runat="server">
    <script src="theme/scripts/demo/notifications.js"></script>
     <script>
         function crea_mappa() {
             var geocoder;
             var map;
             geocoder = new google.maps.Geocoder();
             var latlng = new google.maps.LatLng(-34.397, 150.644);
             var mapOptions = {
                 zoom: 10,
                 center: latlng,
                 mapTypeId: google.maps.MapTypeId.ROADMAP
             }
             map = new google.maps.Map(document.getElementById('pippo'), mapOptions);
             geocoder.geocode({ 'address': indirizzo }, function (results, status) {
                 if (status == google.maps.GeocoderStatus.OK) {
                     map.setCenter(results[0].geometry.location);
                     var marker = new google.maps.Marker({
                         map: map,
                         position: results[0].geometry.location
                     });
                 } else {
                     alert('Geocode was not successful for the following reason: ' + status);
                 }
             });
             google.maps.event.addDomListener(window, 'load', initialize);
             google.maps.event.trigger(map, 'resize')
         }
         $('a[href="#quickPhotosTab"]').on('shown', function (e) {
             //google.maps.event.trigger(map, 'resize');
             
             if (indirizzo != '') {
                 crea_mappa();
             }

         });
         </script>
    <script >
        var sPageURL = window.location.search.substring(1);
        var i = 0;
        var val;
        var indice = 0;
        var pagina_split = sPageURL.split('&');
        for (i = 0; i < pagina_split.length; i++) {
            val = pagina_split[i].split("=");
            if (val[0] == 'result') {
                var risultato = parseInt(val[1]);
                if (risultato == 1) { //risposta corretta
                    result_setpoint_change(modify_plant_ok, risultato);
                }
                if (risultato == 2) { //strumento occupato
                    result_setpoint_change(modify_plant_error, risultato);
                }
                if (risultato == 3) { //server occupato
                    result_setpoint_change(server_error, risultato);
                }

            }
        }

</script>
    <asp:Literal ID="literal_script" runat="server"></asp:Literal>
    <asp:Literal ID="indirizzo_script" runat="server"></asp:Literal>
</asp:Content>
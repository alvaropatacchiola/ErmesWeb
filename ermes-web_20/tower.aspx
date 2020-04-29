<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/main.Master" CodeBehind="tower.aspx.vb" Inherits="ermes_web_20.tower" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>
<%@ MasterType VirtualPath="~/main.Master"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="https://maps.googleapis.com/maps/api/js?v=3.exp&sensor=false"></script>
            <link href="chart/js/css/jquery.dataTables.css" rel="stylesheet" />
    <link href="chart/js/css/dataTables.tableTools.css" rel="stylesheet" />
    <script type="text/javascript" src="localCent/jquery.min.js"></script>

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
			

<asp:Label ID="Label10" runat="server" Text="<h3 class='heading-mosaic'>Overview</h3>" meta:resourcekey="Label10Resource1"></asp:Label>
        
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
                                    <asp:HyperLink ID="refresh_link" runat="server" ClientIDMode="Static" ImageUrl="~/image/refresh.png" NavigateUrl="~/impianto.aspx"></asp:HyperLink>
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
                            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/dashboardNew.aspx" ><b class="btn-primary btn-icon glyphicons circle_arrow_left" ><i></i><asp:literal ID="Literal7" runat="server" Text="Dashboard" meta:resourcekey="Literal7Resource1"></asp:literal></b></asp:HyperLink></div>
</div>
</div>

	<div class="separator bottom">
        
           </div>
	<!-- // Stats Widgets END -->
 
    
    
    <asp:Label ID="Label17" runat="server" Text="<h3 class='heading-mosaic'>01 | TOWER Test</h3>" meta:resourcekey="Label17Resource1"></asp:Label>
    
    <div class="row-fluid">
    <div class="innerLR">
       <div id="menu_strumento">
               
    <ul class="nav nav-pills">
        <asp:literal ID="Label14" runat="server" Text="<li class='active'><a id ='channels_id' href='#'>Channels</a></li>" meta:resourcekey="channels_idResource1"></asp:literal>
        <asp:literal ID="Label29" runat="server" Text="<li><a id ='inhibitor_id' href='#'>Inhibitor</a></li>" meta:resourcekey="Label29Resource1"></asp:literal>
            <li class="dropdown" id ="biocide_li"><a class="dropdown-toggle" data-toggle="dropdown" href='#'><asp:Label ID="Label19" runat="server" Text="Biocide" meta:resourcekey="Label19Resource1"></asp:Label><span class="caret"></span></a>
                <ul class="dropdown-menu">
                    
                    <asp:literal ID="Label30" runat="server" Text="<li><a id ='biocide1_id' href='#'>Biocide1</a></li>" meta:resourcekey="Label30Resource1"></asp:literal>
                    <asp:literal ID="Label31" runat="server" Text="<li><a id ='biocide2_id' href='#'>Biocide2</a></li>" meta:resourcekey="Label31Resource1"></asp:literal>
                </ul>
            </li>
        <asp:literal ID="Label32" runat="server" Text="<li><a id ='bleed_id' href='#'>Bleed</a></li>" meta:resourcekey="Label32Resource1"></asp:literal>

            <li class="dropdown" id ="setpoint_li"><a class="dropdown-toggle" data-toggle="dropdown" href='#'><asp:Label ID="Label16" runat="server" Text="SetPoint" meta:resourcekey="Label16Resource1"></asp:Label><span class="caret"></span></a>
                <ul class="dropdown-menu">
                    <asp:literal ID="Label33" runat="server" Text="<li><a id ='setpoint2_id' href='#'>SetPoint CH2</a></li>" meta:resourcekey="Label33Resource1"></asp:literal>
                    
                        <asp:literal ID="Label34" runat="server" Text="<li><a id ='setpoint3_id' href='#'>SetPoint CH3</a></li>" meta:resourcekey="Label34Resource1"></asp:literal>
                        
                </ul>
            </li>


            <asp:literal ID="Label18" runat="server" Text="<li><a id ='service_id' href='#'>Service</a></li>" meta:resourcekey="Label18Resource1"></asp:literal>
            <asp:literal ID="Label20" runat="server" Text="<li><a id ='calibration_id' href='#'>Calibration</a></li>" meta:resourcekey="Label20Resource1"></asp:literal>

            <li class="dropdown" id ="setting_li"><a class="dropdown-toggle" data-toggle="dropdown" href='#'><asp:Label ID="Label22" runat="server" Text="Settings" meta:resourcekey="Label22Resource1"></asp:Label><span class="caret"></span></a>
                <ul class="dropdown-menu">
                    <asp:literal ID="Label21" runat="server" Text="<li><a id ='flowmeter_id' href='#'>Flow Meter</a></li>" meta:resourcekey="Label21Resource1"></asp:literal>
                    <asp:literal ID="Label24" runat="server" Text="<li><a id ='alarm_id' href='#'>Alarm</a></li>" meta:resourcekey="Label24Resource1"></asp:literal>
                    <asp:literal ID="Label25" runat="server" Text="<li><a id ='option_id' href='#'>Option</a></li>" meta:resourcekey="Label25Resource1"></asp:literal>
                    <asp:literal ID="Label26" runat="server" Text="<li><a id ='logsetup_id' href='#'>Log Setup</a></li>" meta:resourcekey="Label26Resource1"></asp:literal>
                    <asp:literal ID="Label27" runat="server" Text="<li><a id ='passcode_id' href='#'>Passcode</a></li>" meta:resourcekey="Label27Resource1"></asp:literal>
                    <asp:literal ID="Label28" runat="server" Text="<li><a id ='unit_id' href='#'>Unit</a></li>" meta:resourcekey="Label28Resource1"></asp:literal>
                    <asp:literal ID="Label35" runat="server" Text="<li><a id ='clock_id' href='#'>Clock</a></li>" meta:resourcekey="Label35Resource1"></asp:literal>
                </ul>
            </li>	
    
            <asp:literal ID="Literal1" runat="server" Text="<li><a id ='Log_1' href='#'>Log</a></li>" meta:resourcekey="Label15Resource1"></asp:literal>

</ul>
    </div>

    <div class="separator bottom"></div>
    </div>
    </div>
    
    <div id="principale_alert" style="z-index:10000; position:absolute" >
    </div>
<div id="principale" class="innerLR" >
    
</div>

<script type="text/javascript">
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
                $("#principale").load("tower/main_tower.aspx?" + sPageURL);
            break;
            case 1:
                evidenzia("", "#inhibitor_id");
                StopRefresh();
                $("#principale").load("tower/inhibitor.aspx?" + sPageURL);
                break;
            case 2:
                evidenzia("biocide_li", "#biocide1_id");
                StopRefresh();
                $("#principale").load("tower/biocide1.aspx?" + sPageURL);
                break;
            case 3:
                evidenzia("biocide_li", "#biocide2_id");
                StopRefresh();
                $("#principale").load("tower/biocide2.aspx?" + sPageURL);
                break;
            case 4:
                evidenzia("", "#bleed_id");
                StopRefresh();
                $("#principale").load("tower/bleed.aspx?" + sPageURL);
                break;
            case 5:
                evidenzia("setpoint_li", "#setpoint2_id");
                StopRefresh();
                $("#principale").load("tower/setpoint_ch2.aspx?" + sPageURL);
                break;
            case 6:
                evidenzia("setpoint_li", "#setpoint3_id");
                StopRefresh();
                $("#principale").load("tower/setpoint_ch3.aspx?" + sPageURL);
                break;
            case 7:
                evidenzia("setting_li", "#option_id");
                StopRefresh();
                $("#principale").load("tower/option.aspx?" + sPageURL);
                break;
            case 8:
                evidenzia("setting_li", "#flowmeter_id");
                StopRefresh();
                $("#principale").load("tower/flow_meter.aspx?" + sPageURL);
                break;
            case 9:
                evidenzia("setting_li", "#alarm_id");
                StopRefresh();
                $("#principale").load("tower/alarm.aspx?" + sPageURL);
                break;
            case 10:
                evidenzia("setting_li", "#logsetup_id");
                StopRefresh();
                $("#principale").load("tower/log_setup.aspx?" + sPageURL);
                break;
            case 11:
                evidenzia("setting_li", "#passcode_id");
                StopRefresh();
                $("#principale").load("tower/passcode.aspx?" + sPageURL);
                break;
            case 12:
                evidenzia("setting_li", "#unit_id");
                StopRefresh();
                $("#principale").load("tower/unit.aspx?" + sPageURL);
                break;
            case 13:
                evidenzia("setting_li", "#clock_id");
                StopRefresh();
                $("#principale").load("tower/clock.aspx?" + sPageURL);
                break;

                
            case 14:
                evidenzia("log_li", "#Log_1");
                StopRefresh();
                $("#principale").load("chart/log_tower.aspx?" + sPageURL);
                break;
            case 15:
                evidenzia("log_li", "#Log_2");
                StopRefresh();
                $("#principale").load("chart/report_tower.aspx?" + sPageURL);
                break;
            case 16:
                evidenzia("", "#bleed_boiler_id");
                StopRefresh();
                $("#principale").load("tower/bleed_boiler.aspx?" + sPageURL);
                break;


        }
    }

    
    function evidenzia(item_group, oggetto) {
        $("li").removeClass("active");

        var item = $(oggetto).parent();
        item.addClass("active");

        if (item_group != "") {

            $("#" + item_group).removeClass("active");
            $("#" + item_group).addClass("active");
        }
    }
    $("#channels_id").click(function () {
        carica_pagina(0);

        // $("#principale").load("test.aspx");
    });

    $("#inhibitor_id").click(function () {
        carica_pagina(1);
        
        // $("#principale").load("test.aspx");
    });
    $("#biocide1_id").click(function () {
        carica_pagina(2);
        
    });
    $("#biocide2_id").click(function () {
        carica_pagina(3);
        
    });
    $("#bleed_id").click(function () {
        carica_pagina(4);
        
    });
    $("#setpoint2_id").click(function () {
        carica_pagina(5);
        
    });
    $("#setpoint3_id").click(function () {
        carica_pagina(6);
        
    });

    $("#option_id").click(function () {
        carica_pagina(7);
        
    });
    $("#flowmeter_id").click(function () {
        carica_pagina(8);
        
    });
    $("#alarm_id").click(function () {
        carica_pagina(9);
        
    });
    $("#logsetup_id").click(function () {
        carica_pagina(10);

    });
    $("#passcode_id").click(function () {
        carica_pagina(11);

    });
    $("#unit_id").click(function () {
        carica_pagina(12);

    });
    $("#clock_id").click(function () {
        carica_pagina(13);

    });

    $("#Log_1").click(function () {
        carica_pagina(14);

    });
    $("#Log_2").click(function () {
        carica_pagina(15);

    });
    $("#bleed_boiler_id").click(function () {
        carica_pagina(16);

    });

    /*
            
            gestione refresh pagina
            */
    $("#refresh_link").click(function () {

        if (spinner) spinner.stop();
        spinner = new Spinner(opts).spin(target);
        return true;
    });

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
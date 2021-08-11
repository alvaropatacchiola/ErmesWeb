<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/main.Master" CodeBehind="max5.aspx.vb" Inherits="ermes_web_20.max5" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>

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
                                <li class="glyphicons calendar"">
                                <asp:Label ID="Label12" runat="server" Text="<i></i> <span class='label'>10</span> <span class='label'>July</span> <span class='label'>1986</span> <span class='label'>18:56</span>" meta:resourcekey="Label12Resource1"></asp:Label>
                                    
                                    <asp:HyperLink ID="refresh_link" runat="server" ClientIDMode="Static" ImageUrl="~/image/refresh.png" NavigateUrl="~/impianto.aspx"></asp:HyperLink>
                                        
                                </li>
                                
								<!-- <asp:Button runat="server" Text="Button"></asp:Button>
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
                    <!--
					<div class="tabsbar tabsbar-2">
                        
	</div>
                    -->
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
 
    
    
    <asp:Label ID="Label17" runat="server" Text="<h3 class='heading-mosaic'>01 | MAX5 Test</h3>" meta:resourcekey="Label17Resource1"></asp:Label>
    
    <div class="row-fluid">
    <div class="innerLR">



 <div id="menu_strumento">
               
    <ul class="nav nav-pills">

        <asp:literal ID="literal33" runat="server" Text="<li class='active'><a id ='channels_id' href='#'>Channels</a></li>" meta:resourcekey="channels_idResource1"></asp:literal>
        
        <asp:Literal ID="Literal1" runat="server" Text="<li class='dropdown' id ='service_li'><a class='dropdown-toggle' data-toggle='dropdown' href='#'> Service<span class='caret'></span></a>" meta:resourcekey="Label19Resource1"></asp:Literal>
        <asp:Literal ID="Literal2" runat="server" Text=" <ul class='dropdown-menu' role='menu'>"></asp:Literal>
        <asp:literal ID="literal30" runat="server" Text="<li><a id ='manual_id' href='#'>Manual</a></li>" meta:resourcekey="Label30Resource1"></asp:literal>
        <asp:literal ID="literal31" runat="server" Text="<li><a id ='reset_totalizer_id' href='#'>Reset Totalizer</a></li>" meta:resourcekey="Label31Resource1"></asp:literal>
     <asp:Literal ID="Literal3" runat="server" Text="</ul></li>"></asp:Literal>
                       <!--
                    <li><asp:LinkButton ID="reset_alarm_id" runat="server" Text="Reset Alarm"></asp:LinkButton></li>
                    -->

             <asp:literal ID="literal16" runat="server" Text="<li><a id ='calibration_id' href='#'>Calibration</a></li>" meta:resourcekey="Label16Resource1"></asp:literal>


            <li class="dropdown" id ="setpoint_li"><a class="dropdown-toggle" data-toggle="dropdown" href='#'><asp:literal ID="literal21" runat="server" Text="Set Point" meta:resourcekey="Label21Resource1"></asp:literal><span class="caret"></span></a>
                <ul class="dropdown-menu">

                        <!--
                        <asp:LinkButton ID="setpoint_1" runat="server"  Text ="<li>SetPoint</li>"> </asp:LinkButton>
                        <asp:LinkButton ID="setpoint_2" runat="server" Text="<li>SetPoint</li>"></asp:LinkButton>
                        <asp:LinkButton ID="setpoint_3" runat="server" Text="<li>SetPoint</li>"></asp:LinkButton>
                        <asp:LinkButton ID="setpoint_4" runat="server" Text="<li>SetPoint</li>"></asp:LinkButton>
                        <asp:LinkButton ID="setpoint_5" runat="server" Text="<li>SetPoint</li>"></asp:LinkButton>
                        <asp:LinkButton ID="setpoint_t" runat="server" Text="<li>SetPoint</li>"></asp:LinkButton>
                            -->
                        
                        <asp:literal ID="literal14" runat="server" Text="<li><a id ='SetPoint_1' href='#'>SetPoint Ch1 pH</a></li>" meta:resourcekey="Label14Resource1"></asp:literal>
                        


                </ul>
             </li>		
            <li class="dropdown" id="option_li"><a class="dropdown-toggle" data-toggle="dropdown" href='#'><asp:literal ID="literal20" runat="server" Text="Option" meta:resourcekey="Label20Resource1"></asp:literal><span class="caret"></span></a>
                <ul class="dropdown-menu">
                    <asp:literal ID="literla18" runat="server" Text="<li><a id ='settings_id' href='#'>Settings</a></li>" meta:resourcekey="Label18Resource1"></asp:literal>
                    <asp:literal ID="literal28" runat="server" Text="<li><a id ='password_id' href='#'>Password</a></li>" meta:resourcekey="Label28Resource1"></asp:literal>
                    <asp:literal ID="literal25" runat="server" Text="<li><a id ='clock_id' href='#'>Clock</a></li>" meta:resourcekey="Label25Resource1"></asp:literal>

                        <asp:literal ID="literal26" runat="server" Text="<li><a id ='message_id' href='#'>Message</a></li>" meta:resourcekey="Label26Resource1"></asp:literal>
                        <asp:literal ID="literal27" runat="server" Text="<li><a id ='rs485_id' href='#'>RS485</a></li>" meta:resourcekey="Label27Resource1"></asp:literal>

                </ul>
            </li>
            <li class="dropdown" id ="timer_li"><a class="dropdown-toggle" data-toggle="dropdown" href='#'><asp:literal ID="Label22" runat="server" Text="Timer" meta:resourcekey="Label22Resource1"></asp:literal><span class="caret"></span></a>
                <ul class="dropdown-menu">
                    <asp:literal ID="lieral24" runat="server" Text="<li><a id ='timer_id' href='#'>Timer</a></li>" meta:resourcekey="Label24Resource1"></asp:literal>
                </ul>
            </li>	
        <asp:literal ID="literal4" runat="server" Text="<li><a id ='Log_1' href='#'>Log Graph</a></li>" meta:resourcekey="Label15Resource1"></asp:literal>

        <!--
            <li class="dropdown" id ="log_li"><a class="dropdown-toggle" data-toggle="dropdown" href='#'><asp:literal ID="Label23" runat="server" Text="Log" meta:resourcekey="Label23Resource1"></asp:literal><span class="caret"></span></a>
                <ul class="dropdown-menu">
                    
                        <asp:literal ID="literal15" runat="server" Text="<li><a id ='Log_1' href='#'>Log Graph</a></li>" meta:resourcekey="Label15Resource1"></asp:literal>
                        <asp:literal ID="literal29" runat="server" Text="<li><a id ='Log_2' href='#'>Log Report</a></li>" meta:resourcekey="Label29Resource1"></asp:literal>
                    
                </ul>
            </li>
            -->
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
    var i = 0;
    var val;
    var indice = 0;
    var RefreshID;
    sPageURL = sPageURL.replace(' ', '$'); // replace dello spazio con il $, da fastidio alla url nei parametri
    var pagina_split = sPageURL.split('&');
    for (i=0;i<pagina_split.length;i++) {
        val = pagina_split[i].split("=");
        if (val[0] == 'pagina') {
            indice = parseInt(val[1]);
        }
    }
    
    //var codice = parseInt(pagina_split(0));
    //$("#principale").load("max5/main_max5.aspx?" + sPageURL);
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
                //$('head').append("<meta http-equiv='refresh' content='30'>");
                RestartRefresh();
                $("#principale").load("max5/main_max5.aspx?" + sPageURL);
                break;
            case 1:
                evidenzia("setpoint_li", "#SetPoint_1");
                StopRefresh();
                //$('meta[http-equiv=Refresh]').remove();
                $("#principale").load("max5/setpoint_ch.aspx?canale=1&" + sPageURL);
                break;
            case 2:
                evidenzia("setpoint_li", "#SetPoint_2");
                StopRefresh();
                //$('meta[http-equiv=Refresh]').remove().
                $("#principale").load("max5/setpoint_ch.aspx?canale=2&" + sPageURL);
                break;
            case 3:
                evidenzia("setpoint_li", "#SetPoint_3");
                StopRefresh();
                //$('meta[http-equiv=Refresh]').remove();
                $("#principale").load("max5/setpoint_ch.aspx?canale=3&" + sPageURL);
                break;
            case 4:
                evidenzia("setpoint_li", "#SetPoint_4");
                StopRefresh();
                //$('meta[http-equiv=Refresh]').remove();
                $("#principale").load("max5/setpoint_ch.aspx?canale=4&" + sPageURL);
                break;
            case 5:
                evidenzia("setpoint_li", "#SetPoint_5");
                StopRefresh();
                //$('meta[http-equiv=Refresh]').remove();
                $("#principale").load("max5/setpoint_ch.aspx?canale=5&" + sPageURL);
                break;
            case 6:
                evidenzia("setpoint_li", "#SetPoint_temp");
                StopRefresh();
                //$('meta[http-equiv=Refresh]').remove();
                $("#principale").load("max5/setpoint_temperature.aspx?canale=1&" + sPageURL);
                break;
            case 18:
                evidenzia("setpoint_li", "#SetPoint_temp1");
                StopRefresh();
                //$('meta[http-equiv=Refresh]').remove();
                $("#principale").load("max5/setpoint_temperature.aspx?canale=2&" + sPageURL);
                break;
            case 7:
                evidenzia("", "#calibration_id");
                StopRefresh();
                //$('meta[http-equiv=Refresh]').remove();
                $("#principale").load("max5/calibration.aspx?" + sPageURL);
                break;
            case 8:
                evidenzia("option_li", "#settings_id");
                StopRefresh();
                //$('meta[http-equiv=Refresh]').remove();
                $("#principale").load("max5/option.aspx?" + sPageURL);
                break;
            case 9:
                evidenzia("timer_li", "#timer_id");
                StopRefresh();
                //$('meta[http-equiv=Refresh]').remove();
                $("#principale").load("max5/timer.aspx?" + sPageURL);
                break;
            case 10:
                evidenzia("option_li", "#clock_id");
                StopRefresh();
                //$('meta[http-equiv=Refresh]').remove();
                $("#principale").load("max5/clock.aspx?" + sPageURL);
                break;
            case 11:
                evidenzia("option_li", "#message_id");
                StopRefresh();
                //$('meta[http-equiv=Refresh]').remove();
                $("#principale").load("max5/message.aspx?" + sPageURL);
                break;
            case 12:
                evidenzia("option_li", "#password_id");
                StopRefresh();
                //$('meta[http-equiv=Refresh]').remove();
                $("#principale").load("max5/password.aspx?" + sPageURL);
                break;
            case 13:
                evidenzia("service_li", "#manual_id");
                StopRefresh();
                //$('meta[http-equiv=Refresh]').remove();
                $("#principale").load("max5/manual.aspx?" + sPageURL);
                break;
            case 14:
                evidenzia("service_li", "#reset_totalizer_id");
                StopRefresh();
                //$('meta[http-equiv=Refresh]').remove();
                $("#principale").load("max5/reset_totalizer.aspx?" + sPageURL);
                break;
            case 15:
                evidenzia("option_li", "#rs485_id");
                StopRefresh();
                //$('meta[http-equiv=Refresh]').remove();
                $("#principale").load("max5/rs485.aspx?" + sPageURL);
                break;
            case 16:
                evidenzia("", "#Log_1");
                StopRefresh();
                //$('meta[http-equiv=Refresh]').remove();
                $("#principale").load("chart/log_max5.aspx?" + sPageURL);
                break;
            case 17:
                evidenzia("log_li", "#Log_2");
                StopRefresh();
                //$('meta[http-equiv=Refresh]').remove();
                $("#principale").load("chart/report_max5.aspx?" + sPageURL);
    
                break;

                
        }
    }

    function evidenzia(item_group,oggetto) {
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
    });
    $("#SetPoint_1").click(function () {
        
          carica_pagina(1);
        
       // $("#principale").load("test.aspx");
    });
    $("#SetPoint_2").click(function () {
        
        carica_pagina(2);
    });
    $("#SetPoint_3").click(function () {
        

        carica_pagina(3);
        
    });
    $("#SetPoint_4").click(function () {
        
        carica_pagina(4);
        
    });
    $("#SetPoint_5").click(function () {
        
        carica_pagina(5);
        
    });
    $("#SetPoint_temp").click(function () {
        
        carica_pagina(6);
        
    });
 
    $("#calibration_id").click(function () {
        

        carica_pagina(7);
        
    });
    $("#settings_id").click(function () {
        
        carica_pagina(8);
        
    });
    $("#timer_id").click(function () {
        
        carica_pagina(9);
        
    });
    $("#clock_id").click(function () {
        
        carica_pagina(10);
        
    });
    $("#message_id").click(function () {
        
        carica_pagina(11);
        
    });
    $("#password_id").click(function () {
        
        carica_pagina(12);
        
    });
    $("#manual_id").click(function () {
        
        carica_pagina(13);
        
    });
    $("#reset_totalizer_id").click(function () {
        
        carica_pagina(14);
        
    });
    $("#rs485_id").click(function () {
        
        carica_pagina(15);
        
    });
    $("#Log_1").click(function () {
        
        carica_pagina(16);
        
    });
    $("#Log_2").click(function () {
        
        carica_pagina(17);
        
    });
    $("#SetPoint_temp1").click(function () {

        carica_pagina(18);

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


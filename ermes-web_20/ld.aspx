<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/main.Master" CodeBehind="ld.aspx.vb" Inherits="ermes_web_20.ld" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>
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
                            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/dashboardNew.aspx" ><b class="btn-primary btn-icon glyphicons circle_arrow_left" ><i></i><asp:literal ID="Literal7" runat="server" Text="Dashboard" meta:resourcekey="Literal7Resource1"></asp:literal></b></asp:HyperLink></div>
</div>
</div>

	<div class="separator bottom">
        
           </div>
	<!-- // Stats Widgets END -->
 
    
    
    <asp:Label ID="Label17" runat="server" Text="<h3 class='heading-mosaic'>01 | LD Test</h3>" meta:resourcekey="Label17Resource1"></asp:Label>
    
    <div class="row-fluid">
    <div class="innerLR">
<div id="menu_strumento">
               
    <ul class="nav nav-pills">
        <asp:literal ID="Label33" runat="server" Text="<li class='active'><a id ='channels_id' href='#'>Channels</a></li>"  meta:resourcekey="channels_idResource1"></asp:literal>

            <li class="dropdown" id ="setpoint_li"><a  class="dropdown-toggle" data-toggle="dropdown" href='#'><asp:Label ID="Label19" runat="server" Text="SetPoint" meta:resourcekey="Label19Resource1"></asp:Label><span class="caret"></span></a>
                <ul  class="dropdown-menu">
                    <asp:literal ID="Label18" runat="server" Text="<li><a id ='setpointld_id' href='#'>SetPoint</a></li>" meta:resourcekey="Label18Resource1"></asp:literal>
                    <asp:literal ID="Label16" runat="server" Text="<li><a id ='ma_outputld_id' href='#'>mA Output</a></li>" meta:resourcekey="Label16Resource1"></asp:literal>
                    <asp:literal ID="Label22" runat="server" Text="<li><a id ='self_clean_id' href='#'>Self Clean</a></li>" meta:resourcekey="Label22Resource1"></asp:literal>
                    <asp:literal ID="Label26" runat="server" Text="<li><a id ='circulation_id' href='#'>Circulation</a></li>" meta:resourcekey="Label26Resource1"></asp:literal>

                </ul>
            </li>
        <asp:PlaceHolder ID="PlaceHolder1" runat="server">
            <li class="dropdown" id ="alarm_li"><a class="dropdown-toggle" data-toggle="dropdown" href='#'><asp:Label ID="Label25" runat="server" Text="Alarm" meta:resourcekey="Label25Resource1"></asp:Label><span class="caret"></span></a>
                <ul class="dropdown-menu">
                    <asp:literal ID="Label27" runat="server" Text="<li><a id ='rangealarmld_id' href='#'>Range Alarm</a></li>" meta:resourcekey="Label27Resource1"></asp:literal>
                    <asp:literal ID="Label28" runat="server" Text="<li><a id ='flowld_id' href='#'>Flow</a></li>" meta:resourcekey="Label28Resource1"></asp:literal>
                    <asp:literal ID="Label29" runat="server" Text="<li><a id ='probefailureld_id' href='#'>Probe Failure</a></li>" meta:resourcekey="Label29Resource1"></asp:literal>
                    <asp:literal ID="Label30" runat="server" Text="<li><a id ='dosingalarmld_id' href='#'>Dosing Alarm</a></li>" meta:resourcekey="Label30Resource1"></asp:literal>
                    <asp:literal ID="Literal6" runat="server" Text="<li><a id ='flowall_id' href='#'>Flow Alarm</a></li>" meta:resourcekey="Literal6Resource1"></asp:literal>
                </ul>
            </li>
            </asp:PlaceHolder>
        

            <asp:literal ID="Label24" runat="server" Text="<li><a id ='parametersld_id' href='#'>Parameters</a></li>" meta:resourcekey="Label24Resource1"></asp:literal>

            <asp:literal ID="Label14" runat="server" Text="<li><a id ='internationalld_id' href='#'>International</a></li>" meta:resourcekey="Label14Resource1"></asp:literal>

        <asp:literal ID="Literal1" runat="server" Text="<li><a id ='manual_ld_id' href='#'>Manual</a></li>" meta:resourcekey="Literal1Resource1"></asp:literal>
        <asp:literal ID="Literal2" runat="server" Text="<li><a id ='messagge_ld_id' href='#'>Message</a></li>" meta:resourcekey="Literal2Resource1"></asp:literal>
        <asp:literal ID="Literal3" runat="server" Text="<li><a id ='calibration_ld_id' href='#'>Calibration</a></li>" meta:resourcekey="Literal3Resource1"></asp:literal>

            <asp:literal ID="Label20" runat="server" Text="<li><a id ='logsetupld_id' href='#'>Log Setup</a></li>" meta:resourcekey="Label20Resource1"></asp:literal>

        <!--
            <li class="dropdown" id ="log_li"><a class="dropdown-toggle" data-toggle="dropdown" href='#'><asp:Label ID="Label23" runat="server" Text="Log" meta:resourcekey="Label23Resource1"></asp:Label><span class="caret"></span></a>
                <ul class="dropdown-menu">
            -->
<asp:PlaceHolder ID="enable_ld_log" runat="server">
    
                <asp:literal ID="Label35" runat="server" Text="<li><a id ='Log_1' href='#'>Log Graph</a></li>" meta:resourcekey="Label15Resource1"></asp:literal>
    <!--                   
     <asp:literal ID="Label21" runat="server" Text="<li><a id ='Log_2' href='#'>Log Report</a></li>" meta:resourcekey="Label21Resource1"></asp:literal>
    -->
</asp:PlaceHolder>
<asp:PlaceHolder ID="enable_ld4_log" runat="server">
        
     
    <asp:literal ID="Literal4" runat="server" Text="<li><a id ='Log4_1' href='#'>Log Graph</a></li>" ></asp:literal>


</asp:PlaceHolder>
<asp:PlaceHolder ID="enable_ldma_log" runat="server">
        
     
    <asp:literal ID="Literal100" runat="server" Text="<li><a id ='Logma' href='#'>Log Graph</a></li>" meta:resourcekey="Literal100Resource1"></asp:literal>


</asp:PlaceHolder>
<asp:PlaceHolder ID="enable_ldlg_log" runat="server">
        
     
    <asp:literal ID="Literal5" runat="server" Text="<li><a id ='Loglg' href='#'>Log Graph</a></li>" meta:resourcekey="Literal100Resource1"></asp:literal>


</asp:PlaceHolder>

        <!--
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
    //$(document).ready(function () {
    var sPageURL = window.location.search.substring(1);
    var target = document.getElementById('principale');
    var spinner = new Spinner(opts).spin(target);
    var i = 0;
    var val;
    var RefreshID;
    var indice = 0;
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
                $("#principale").load("ld/main_ld.aspx?" + sPageURL);
                break;
            case 1:
                evidenzia("setpoint_li", "#setpoint_ld");
                StopRefresh();
                $("#principale").load("ld/setpoint_ld.aspx?" + sPageURL);
                break;
            case 2:
                evidenzia("setpoint_li", "#maoutput_ld");
                StopRefresh();
                $("#principale").load("ld/ma_output.aspx?" + sPageURL);
                break;
            case 3:
                evidenzia("alarm_li", "#rangealarm_ld");
                StopRefresh();
                $("#principale").load("ld/range_alarm.aspx?" + sPageURL);
                break;
            case 4:
                evidenzia("alarm_li", "#flow_ld");
                StopRefresh();
                $("#principale").load("ld/flow_ld.aspx?" + sPageURL);
                break;
            case 5:
                evidenzia("alarm_li", "#probefailure_ld");
                StopRefresh();
                $("#principale").load("ld/probe_failure.aspx?" + sPageURL);
                break;
            case 6:
                evidenzia("alarm_li", "#dosingalarm_ld");
                StopRefresh();
                $("#principale").load("ld/dosing_alarm.aspx?" + sPageURL);
                break;
            case 7:
                evidenzia("", "#parameters_ld");
                StopRefresh();
                $("#principale").load("ld/parameters.aspx?" + sPageURL);
                break;
            case 8:
                evidenzia("", "#international_ld");
                StopRefresh();
                $("#principale").load("ld/international.aspx?" + sPageURL);
                break;
            case 9:
                evidenzia("", "#logsetup_ld");
                StopRefresh();
                $("#principale").load("ld/log_setup.aspx?" + sPageURL);
                break;
            case 10:
                evidenzia("setpoint_li", "#setpoint_lds");
                StopRefresh();
                $("#principale").load("lds/setpoint_lds.aspx?" + sPageURL);
                break;
            case 11:
                evidenzia("setpoint_li", "#maoutput_lds");
                StopRefresh();
                $("#principale").load("lds/ma_outputs.aspx?" + sPageURL);
                break;
            case 12:
                evidenzia("alarm_li", "#rangealarm_lds");
                StopRefresh();
                $("#principale").load("lds/range_alarms.aspx?" + sPageURL);
                break;
            case 13:
                evidenzia("alarm_li", "#flow_lds");
                StopRefresh();
                $("#principale").load("lds/flow_lds.aspx?" + sPageURL);
                break;
            case 14:
                evidenzia("alarm_li", "#probefailure_lds");
                StopRefresh();
                $("#principale").load("lds/probe_failures.aspx?" + sPageURL);
                break;
            case 15:
                evidenzia("alarm_li", "#dosingalarm_lds");
                StopRefresh();
                $("#principale").load("lds/dosing_alarms.aspx?" + sPageURL);
                break;
            case 16:
                evidenzia("", "#parameters_lds");
                StopRefresh();
                $("#principale").load("lds/parameterss.aspx?" + sPageURL);
                break;
            case 17:
                evidenzia("", "#international_lds");
                StopRefresh();
                $("#principale").load("lds/internationals.aspx?" + sPageURL);
                break;
            case 18:
                evidenzia("", "#logsetup_lds");
                StopRefresh();
                $("#principale").load("lds/log_setups.aspx?" + sPageURL);
                break;
            case 19:
                evidenzia("log_li", "#Log_1");
                StopRefresh();
                $("#principale").load("chart/log_ld.aspx?" + sPageURL);
                break;
            case 20:
                evidenzia("log_li", "#Log_2");
                StopRefresh();
                $("#principale").load("chart/report_ld.aspx?" + sPageURL);
                break;

            case 21:
                evidenzia("", "#manual_ld");
                StopRefresh();
                $("#principale").load("ld/manual_ld.aspx?" + sPageURL);
                break;
            case 22:
                evidenzia("", "#message_ld");
                StopRefresh();
                $("#principale").load("ld/message_ld.aspx?" + sPageURL);
                break;
            case 23:
                evidenzia("", "#calibration_ldd");
                StopRefresh();
                $("#principale").load("ld/calibration_ldd.aspx?" + sPageURL);
                break;
            case 24:
                evidenzia("", "#manual_lds");
                StopRefresh();
                $("#principale").load("lds/manual_lds.aspx?" + sPageURL);
                break;
            case 25:
                evidenzia("", "#message_lds");
                StopRefresh();
                $("#principale").load("lds/message_lds.aspx?" + sPageURL);
                break;
            case 26:
                evidenzia("", "#calibration_lds");
                StopRefresh();
                $("#principale").load("lds/calibration_lds.aspx?" + sPageURL);
                break;
            case 27:
                evidenzia("setpoint_li", "#setpoint_ldsB");
                StopRefresh();
                $("#principale").load("lds/setpoint_ldsB.aspx?" + sPageURL);
                break;
            case 28:
                evidenzia("setpoint_li", "#Self_clean");
                StopRefresh();
                $("#principale").load("lds/Self_clean.aspx?" + sPageURL);
                break;

            case 29:
                evidenzia("setpoint_li", "#setpoint_ld4");
                StopRefresh();
                $("#principale").load("ld4/setpoint_ld4.aspx?" + sPageURL);
                break;
            case 30:
                evidenzia("setpoint_li", "#wmeter_ld4");
                StopRefresh();
                $("#principale").load("ld4/wmeter_ld4.aspx?" + sPageURL);
                break;
            case 31:
                evidenzia("alarm_li", "#rangealarm_ld4");
                StopRefresh();
                $("#principale").load("ld4/range_alarm_ld4.aspx?" + sPageURL);
                break;
            case 32:
                evidenzia("alarm_li", "#flow_ld4");
                StopRefresh();
                $("#principale").load("ld4/flow_ld4.aspx?" + sPageURL);
                break;
            case 33:
                evidenzia("alarm_li", "#probefailure_ld4");
                StopRefresh();
                $("#principale").load("ld4/probe_failure_ld4.aspx?" + sPageURL);
                break;
            case 34:
                evidenzia("alarm_li", "#dosingalarm_ld4");
                StopRefresh();
                $("#principale").load("ld4/dosing_alarm_ld4.aspx?" + sPageURL);
                break;
            case 35:
                evidenzia("", "#parameters_ld4");
                StopRefresh();
                $("#principale").load("ld4/parameters_ld4.aspx?" + sPageURL);
                break;
            case 36:
                evidenzia("", "#international_ld4");
                StopRefresh();
                $("#principale").load("ld4/international_ld4.aspx?" + sPageURL);
                break;
            case 37:
                evidenzia("", "#logsetup_ld4");
                StopRefresh();
                $("#principale").load("ld4/log_setup_ld4.aspx?" + sPageURL);
                break;

            case 38:
                evidenzia("setpoint_li", "#Circulation");
                StopRefresh();
                $("#principale").load("lds/Circulation.aspx?" + sPageURL);
                break;

            case 40:
                evidenzia("", "#manual_ld4");
                StopRefresh();
                $("#principale").load("ld4/manual_ld4.aspx?" + sPageURL);
                break;
        
           
            
            case 41:
                evidenzia("", "#message_ld4");
                StopRefresh();
                $("#principale").load("ld4/message_ld4.aspx?" + sPageURL);
                break;
            case 42:
                evidenzia("", "#calibration_ld4");
                StopRefresh();
                $("#principale").load("ld4/calibration_ld4.aspx?" + sPageURL);
                break;

            case 43:
                evidenzia("log_li", "#Log4_1");
                StopRefresh();
                $("#principale").load("chart/log_ld4.aspx?" + sPageURL);
                break;
            case 44:
                evidenzia("log_li", "#Log4_2");
                StopRefresh();
                $("#principale").load("chart/report_ld4.aspx?" + sPageURL);
                break;
            case 45:
                evidenzia("", "#channels_id_ldma");
                RestartRefresh();
                $("#principale").load("ldma/main_ldma.aspx?" + sPageURL);
                break;
            case 46:
                evidenzia("setpoint_li", "#setpoint_ldma1");
                StopRefresh();
                $("#principale").load("ldma/setpoint_ldma.aspx?spma=1&" + sPageURL);
                break;
            case 47:
                evidenzia("setpoint_li", "#setpoint_ldma2");
                StopRefresh();
                $("#principale").load("ldma/setpoint_ldma.aspx?spma=2&" + sPageURL);
                break;
            case 48:
                evidenzia("setpoint_li", "#setpoint_ldma3");
                StopRefresh();
                $("#principale").load("ldma/setpoint_ldma.aspx?spma=3&" + sPageURL);
                break;
            case 49:
                evidenzia("setpoint_li", "#setpoint_ldma4");
                StopRefresh();
                $("#principale").load("ldma/setpoint_ldma.aspx?spma=4&" + sPageURL);
                break;
            case 50:
                evidenzia("setpoint_li", "#setpoint_ldma5");
                StopRefresh();
                $("#principale").load("ldma/setpoint_ldma.aspx?spma=5&" + sPageURL);
                break;
            case 51:
                evidenzia("", "#parameters_ldma");
                StopRefresh();
                $("#principale").load("ldma/parameters_ldma.aspx?" + sPageURL);
                break;
            case 52:
                evidenzia("", "#clock_ldma");
                StopRefresh();
                $("#principale").load("ldma/date_time.aspx?" + sPageURL);
                break;
            case 53:
                evidenzia("", "#message_ldma");
                StopRefresh();
                $("#principale").load("ldma/message.aspx?" + sPageURL);
                break;
            case 54:
                evidenzia("", "#logsetup_ldma");
                StopRefresh();
                $("#principale").load("ldma/log_setup.aspx?" + sPageURL);
                break;

            case 55:
                evidenzia("setpoint_li", "#setpoint_ldsC");
                StopRefresh();
                $("#principale").load("lds/setpoint_ldsC.aspx?" + sPageURL);
                break;
            case 56:
                evidenzia("setpoint_li", "#maoutput_ldsC");
                StopRefresh();
                $("#principale").load("lds/ma_outputsC.aspx?" + sPageURL);
                break;
            case 57:
                evidenzia("log_li", "#Logma");
                StopRefresh();
                $("#principale").load("chart/log_ldma.aspx?" + sPageURL);
                break;
            case 58:
                evidenzia("", "#channels_id_ldlg");
                RestartRefresh();
                $("#principale").load("ldlg/main_ldlg.aspx?" + sPageURL);
                break;


            case 59:
                evidenzia("setpoint_li", "#setpoint_ldlg1");
                StopRefresh();
                $("#principale").load("ldlg/setpoint_ldlg.aspx?spma=1&" + sPageURL);
                break;
            case 60:
                evidenzia("setpoint_li", "#setpoint_ldlg2");
                StopRefresh();
                $("#principale").load("ldlg/setpoint_ldlg.aspx?spma=2&" + sPageURL);
                break;
            case 61:
                evidenzia("setpoint_li", "#setpoint_ldlg3");
                StopRefresh();
                $("#principale").load("ldlg/setpoint_ldlg.aspx?spma=3&" + sPageURL);
                break;
            case 62:
                evidenzia("setpoint_li", "#setpoint_ldlg4");
                StopRefresh();
                $("#principale").load("ldlg/setpoint_ldlg.aspx?spma=4&" + sPageURL);
                break;
            case 63:
                evidenzia("setpoint_li", "#setpoint_ldlg5");
                StopRefresh();
                $("#principale").load("ldlg/setpoint_ldlg.aspx?spma=5&" + sPageURL);
                break;
            case 64:
                evidenzia("setpoint_li", "#setpoint_ldlg6");
                StopRefresh();
                $("#principale").load("ldlg/setpoint_ldlg.aspx?spma=6&" + sPageURL);
                break;
            case 65:
                evidenzia("setpoint_li", "#setpoint_ldlg7");
                StopRefresh();
                $("#principale").load("ldlg/setpoint_ldlg.aspx?spma=7&" + sPageURL);
                break;
            case 66:
                evidenzia("setpoint_li", "#setpoint_ldlg8");
                StopRefresh();
                $("#principale").load("ldlg/setpoint_ldlg.aspx?spma=8&" + sPageURL);
                break;
            case 67:
                evidenzia("setpoint_li", "#setpoint_ldlg9");
                StopRefresh();
                $("#principale").load("ldlg/setpoint_ldlg.aspx?spma=9&" + sPageURL);
                break;
            case 68:
                evidenzia("setpoint_li", "#setpoint_ldlg10");
                StopRefresh();
                $("#principale").load("ldlg/setpoint_ldlg.aspx?spma=10&" + sPageURL);
                break;
            case 69:
                evidenzia("setpoint_li", "#setpoint_diff");
                StopRefresh();
                $("#principale").load("ldlg/setpoint_diff.aspx?spma=11&" + sPageURL);
                break;
            case 70:
                evidenzia("", "#clock_ldlg");
                StopRefresh();
                $("#principale").load("ldlg/date_time.aspx?" + sPageURL);
                break;
            case 71:
                evidenzia("", "#logsetup_ldlg");
                StopRefresh();
                $("#principale").load("ldlg/log_setup.aspx?" + sPageURL);
                break;
            case 72:
                evidenzia("", "#parameters_ldlg");
                StopRefresh();
                $("#principale").load("ldlg/parameters_ldlg.aspx?" + sPageURL);
                break;
            case 73:
                evidenzia("log_li", "#Loglg");
                StopRefresh();
                $("#principale").load("chart/log_ldlg.aspx?" + sPageURL);
                break;

            case 74:
                evidenzia("setpoint_li", "#setpoint_lddt");
                StopRefresh();
                $("#principale").load("ld/setpoint_lddt.aspx?" + sPageURL);
                break;

            case 75:
                evidenzia("setpoint_li", "#setpoint_lddp");
                StopRefresh();
                $("#principale").load("ld/setpoint_lddp.aspx?" + sPageURL);
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
    
    //      });

    $("#channels_id_ldlg").click(function () {
        carica_pagina(58);
    });
    $("#setpoint_ldlg1").click(function () {
        carica_pagina(59);
    });
    $("#setpoint_ldlg2").click(function () {
        carica_pagina(60);
    });
    $("#setpoint_ldlg3").click(function () {
        carica_pagina(61);
    });
    $("#setpoint_ldlg4").click(function () {
        carica_pagina(62);
    });
    $("#setpoint_ldlg5").click(function () {
        carica_pagina(63);
    });
    $("#setpoint_ldlg6").click(function () {
        carica_pagina(64);
    });
    $("#setpoint_ldlg7").click(function () {
        carica_pagina(65);
    });
    $("#setpoint_ldlg8").click(function () {
        carica_pagina(66);
    });
    $("#setpoint_ldlg9").click(function () {
        carica_pagina(67);
    });
    $("#setpoint_ldlg10").click(function () {
        carica_pagina(68);
    });
    $("#setpoint_diff").click(function () {
        carica_pagina(69);
    });
    $("#clock_ldlg").click(function () {
        carica_pagina(70);
    });
    $("#logsetup_ldlg").click(function () {
        carica_pagina(71);
    });
    $("#parameters_ldlg").click(function () {
        carica_pagina(72);
    });
    $("#Loglg").click(function () {
        carica_pagina(73);
    });


    $("#parameters_ldma").click(function () {
        carica_pagina(51);
    });
    $("#clock_ldma").click(function () {
        carica_pagina(52);
    });
    $("#message_ldma").click(function () {
        carica_pagina(53);
    });
    $("#logsetup_ldma").click(function () {
        carica_pagina(54);
    });
    
    $("#channels_id_ldma").click(function () {
        carica_pagina(45);
    });
    $("#setpoint_ldma1").click(function () {
        carica_pagina(46);
    });
    $("#setpoint_ldma2").click(function () {
        carica_pagina(47);
    });
    $("#setpoint_ldma3").click(function () {
        carica_pagina(48);
    });
    $("#setpoint_ldma4").click(function () {
        carica_pagina(49);
    });
    $("#setpoint_ldma5").click(function () {
        carica_pagina(50);
    });
    $("#parameters_ldma").click(function () {
        carica_pagina(51);
    });
    $("#clock_ldma").click(function () {
        carica_pagina(52);
    });
    $("#message_ldma").click(function () {
        carica_pagina(53);
    });
    $("#logsetup_ldma").click(function () {
        carica_pagina(54);
    });



    
    $("#channels_id").click(function () {
        carica_pagina(0);
    });

    $("#setpoint_ld").click(function () {
        carica_pagina(1);        
    });
    $("#maoutput_ld").click(function () {
        carica_pagina(2);
        
    });
    $("#rangealarm_ld").click(function () {
        carica_pagina(3);
        
    });
    $("#flow_ld").click(function () {
        carica_pagina(4);
        
    });
    $("#probefailure_ld").click(function () {
        carica_pagina(5);
        
    });
    $("#dosingalarm_ld").click(function () {
        carica_pagina(6);
        
    });
    $("#parameters_ld").click(function () {
        carica_pagina(7);
        
    });
    $("#international_ld").click(function () {
        carica_pagina(8);
        
    });
    $("#logsetup_ld").click(function () {
        carica_pagina(9);
        
    });

    $("#setpoint_lds").click(function () {
        carica_pagina(10);
        //alert("clicco");
        
    });
    $("#maoutput_lds").click(function () {
        carica_pagina(11);
        
    });
    $("#rangealarm_lds").click(function () {
        carica_pagina(12);
        
    });
    $("#flow_lds").click(function () {
        carica_pagina(13);
        
    });
    $("#probefailure_lds").click(function () {
        carica_pagina(14);
        
    });
    $("#dosingalarm_lds").click(function () {
        carica_pagina(15);
    });
    $("#parameters_lds").click(function () {
        carica_pagina(16);
        
    });
    $("#international_lds").click(function () {
        carica_pagina(17);
        
    });
    $("#logsetup_lds").click(function () {
        carica_pagina(18);
        
    });
    $("#Log_1").click(function () {
        carica_pagina(19);
        
    });
    $("#Log_2").click(function () {
        carica_pagina(20);

    });


    $("#manual_ld").click(function () {
        carica_pagina(21);

    });
    $("#message_ld").click(function () {
        carica_pagina(22);

    });
    $("#calibration_ldd").click(function () {
        carica_pagina(23);

    });
    $("#manual_lds").click(function () {
        carica_pagina(24);

    });
    $("#message_lds").click(function () {
        carica_pagina(25);

    });
    $("#calibration_lds").click(function () {
        carica_pagina(26);

    });
    $("#setpoint_ldsB").click(function () {
       
        carica_pagina(27);

    });

    $("#Self_clean").click(function () {
        carica_pagina(28);

    }); 


    $("#setpoint_ld4").click(function () {
        carica_pagina(29);        
    });
    $("#wmeter_ld4").click(function () {
       carica_pagina(30);
        
    });
    $("#rangealarm_ld4").click(function () {
        carica_pagina(31);
        
    });
    $("#flow_ld4").click(function () {
        carica_pagina(32);
        
    });
    $("#probefailure_ld4").click(function () {
        carica_pagina(33);
        
    });
    $("#dosingalarm_ld4").click(function () {
        carica_pagina(34);
        
    });
    $("#parameters_ld4").click(function () {
        carica_pagina(35);
        
    });
    $("#international_ld4").click(function () {
        carica_pagina(36);
        
    });
    $("#logsetup_ld4").click(function () {
        carica_pagina(37);
        
    });

    $("#Circulation").click(function () {
        carica_pagina(38);

    });

    $("#manual_ld4").click(function () {
        carica_pagina(40);

    });
    $("#message_ld4").click(function () {
        carica_pagina(41);

    });
    $("#calibration_ld4").click(function () {
        carica_pagina(42);

    });


    $("#Log4_1").click(function () {
        carica_pagina(43);

    });
    $("#Log4_2").click(function () {
        carica_pagina(44);

    });
    $("#Logma").click(function () {
        carica_pagina(57);

    });

    $("#setpoint_ldsC").click(function () {

        carica_pagina(55);

    });

    $("#maoutput_ldsC").click(function () {
        carica_pagina(56);

    });

    $("#setpoint_lddt").click(function () {

        carica_pagina(74);

    });

    $("#setpoint_lddp").click(function () {

        carica_pagina(75);

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
<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/main.Master" CodeBehind="mainCenturio.aspx.vb" Inherits="ermes_web_20.mainCenturio" %>
<%@ MasterType VirtualPath="~/main.Master"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
                <link href="chart/js/css/jquery.dataTables.css" rel="stylesheet" />
    <link href="chart/js/css/dataTables.tableTools.css" rel="stylesheet" />
    <link href="cssmenu/biocide.css" rel="stylesheet" />
    
<script type="text/javascript" src="chart/localCent/jquery.dataTables.js"></script>
<script type="text/javascript" src="chart/localCent/jquery.dataTables.min.js"></script>
<script type="text/javascript" src="chart/localCent/dataTables.buttons.min.js"></script>
<script type="text/javascript" src="chart/localCent/buttons.flash.min.js"></script>
<script type="text/javascript" src="chart/localCent/jszip.min.js"></script>
<script type="text/javascript" src="chart/localCent/pdfmake.min.js"></script>
<script type="text/javascript" src="chart/localCent/vfs_fonts.js"></script>
<script type="text/javascript" src="chart/localCent/buttons.html5.min.js"></script>
<script type="text/javascript" src="chart/localCent/buttons.print.min.js"></script>
 <script src="Centurio/jquery.countdown360.js" type="text/javascript" charset="utf-8"></script>
<script type="text/javascript">
    var varsCountDown = {};
</script>
    
<link href="chart/localCent/buttons.dataTables.min.css" rel="stylesheet" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <ul id="content-notification" class="notyfy_container"></ul>
    
    

    <script src="cssmenu/script.js?v=1.1"></script>
       <div id="content" style="background-color:#dfdfdf;">
           
           <!--
        <div class="innerLR">
            <asp:Literal ID="LiteralHtml" runat="server"></asp:Literal>
         </div>
	 -->
<div id="notConnectedMain" class="row-fluid" style="display: none;">
    <div class="span12">
        <div class="well" style="background-color: #e20022;">
            <h2 style="color: white;text-align: center;">NOT CONNECTED</h2>
    	</div>          
	</div>        
</div>
			<div class="row-fluid">
				<div class="span12">
					<div class="widget" style="padding: 20px 20px 50px 20px;margin:0px">
						<strong><asp:Literal ID="nomeImpianto" runat="server" Text=" "></asp:Literal></strong>
							<span class="pull-right" style="border-left: 1px solid #dfdfdf;padding-left: 20px;">
							<asp:Literal ID="referenteImpianto" runat="server"></asp:Literal>
								<ul class="unstyled icons">
									<li class="glyphicons phone primary"><i></i><asp:Literal ID="numeroTelefono" runat="server"></asp:Literal> </li>
									<li class="glyphicons envelope primary"><i></i><asp:Literal ID="indirizzoMail" runat="server"></asp:Literal></li>
								</ul>
							</span>
							<br><asp:Literal ID="codiceSeriale" runat="server"></asp:Literal></br>
					</div>
					
					<div class="widget widget-tabs">
	
						<!-- Tabs Heading -->
						
							<div id='cssmenu2' class="cssmenu">
								<ul>
								   <li class="dashboard"><a href='DashboardNew.aspx'><asp:Literal ID="dashboard" runat="server" Text="Dashboard"></asp:Literal></a></li>
                                    <asp:Literal ID="setNameStrumento" runat="server" Text="<li id='labelCenturioR_li'  class='active' style='padding:17px'>Centurio</li>"></asp:Literal>

								</ul>
							</div>
						
						<!-- // Tabs Heading END -->
		
						
						</div>
		
					</div>
				</div>

			
				<div class="innerLR">
					<div class="row-fluid">
						<div class="span12" style="margin-bottom:10px;">
							<div class="widget" style="margin-bottom:0px;">
								<div class="widget-head" style="background-color:white;"><span style="background: #64625f;float: left;width: 20px;text-align: center;"></span><asp:Literal ID="NameStrumento1" runat="server" Text="<h3 id = 'labelCenturioR_h3' class='heading'>Centurio</h3>"></asp:Literal>
                                    <div class="buttons pull-right"><asp:Literal ID="DateTimeHeader" runat="server" Text="<h3 id = 'clockRealR'class='heading'></h3>"></asp:Literal></div>
								</div>
								<div class="widget-body" >
                                    <div class="row-fluid">
                                        <asp:Literal ID="headText" runat="server" Text=""></asp:Literal>
								    </div>	

								</div>

							</div>
					 </div>
	              </div>
					<div class="row-fluid">
						<div class="span12" style="margin-bottom:10px;">
						<!-- Tabs Heading -->
						<div id='cssmenu1' class="cssmenu">
								<ul >
								   <li  class="dropdown active"><a href="#mainChannel" data-toggle="tab"><asp:Literal ID="channels" runat="server" Text="Channels"></asp:Literal></a></li>

                                    <asp:Literal ID="listMenu" runat="server" Text="Channels"></asp:Literal>
                                    <li  class="dropdown"><a href="#mainLogGraph" data-toggle="tab"><asp:Literal ID="Literal1" runat="server" Text="Log Graph"></asp:Literal></a></li>
                                    <!--
								   <li class="dropdown"><a  class="dropdown-toggle" data-toggle="dropdown" href='#'>Service</a>
								   	 <ul class="dropdown-menu"> 
										   <li><a href='#tab2' data-toggle="tab">Manual</a></li>
										   <li><a href='#tab3' data-toggle="tab">Reset Totalizer</a></li>
										   <li><a href='#tab2' data-toggle="tab">Manual</a></li>
										   <li><a href='#tab3' data-toggle="tab">Reset Totalizer</a></li>
										   <li><a href='#tab2' data-toggle="tab">Manual</a></li>
										   <li><a href='#tab3' data-toggle="tab">Reset Totalizer</a></li>
										   <li><a href='#tab2' data-toggle="tab">Manual</a></li>
										   <li><a href='#tab3' data-toggle="tab">Reset Totalizer</a></li>
										   <li><a href='#tab2' data-toggle="tab">Manual</a></li>
										   <li><a href='#tab3' data-toggle="tab">Reset Totalizer</a></li>
										   <li><a href='#tab2' data-toggle="tab">Manual</a></li>
										   <li><a href='#tab3' data-toggle="tab">Reset Totalizer</a></li>
										</ul>
									</li>

								   <li><a href='#tab2' data-toggle="tab">Calibration</a></li>
								   <li class="dropdown"><a class="dropdown-toggle" data-toggle="dropdown" href='#'>SetPoints</a>
								   		<ul class="dropdown-menu">
													<li><a href='#tab2' data-toggle="tab">SetPoint Ch1 pH</a></li>
													<li><a href='#tab2' data-toggle="tab">SetPoint Ch2 mV</a></li>
													<li><a href='#tab2' data-toggle="tab">SetPoint Ch3 Cl<sub>2</sub></a></li>
													<li><a href='#tab2' data-toggle="tab">SetPoint Ch4 Cl<sub>2</sub></a></li>
													<li><a href='#tab2' data-toggle="tab">SetPoint Ch5 Clco</a></li>
													<li><a href='#tab2' data-toggle="tab">SetPoint Temp</a></li>
								   		</ul>

								   </li>
								   <li><a href='#'>Options</a>
								   	<ul>
								   	<li><a href='#'>Settings</a></li>
								   	<li><a href='#'>Password</a></li>
								   	<li><a href='#'>Clock</a></li>
								   	<li><a href='#'>Messagge</a></li>
								   	<li><a href='#'>RS485</a></li>
								   	</ul>

								   </li>
								   <li><a href='#'>Timers</a>
								   		<ul>
								   			<li><a href='#'>Timer</a></li>
								   		</ul>
								   </li>
								   <li><a href='#'>Log</a></li>
                                        -->
								</ul>
							</div>
						<!-- // Tabs Heading END -->
		
						
						

						</div>

					</div>
					<!-- // INIZIO RIGA -->

		<div id="principale" class="tab-content">
					<div id="mainChannel" class="tab-pane widget-body-regular active">
                        <asp:Literal ID="listBody" runat="server" Text=""></asp:Literal>
<!-- footer-->
<asp:placeholder runat="server" ID="timerEnableModule">
					<div class="row-fluid">
						<div class="span12" style="margin-bottom:10px;">
							<div class="widget" style="margin-bottom:0px;">
								<div class="widget-head" style="background-color:white;"><span style="background: #64625f;float: left;width: 20px;text-align: center;"></span><h3 class="heading"><asp:Literal ID="setNameTimer" runat="server" Text="Timer"></asp:Literal></h3>
								</div>
								<div class="widget-body">
                                    <div class="row-fluid">
                                        <asp:Literal ID="footerText" runat="server" Text=""></asp:Literal>
								    </div>	
								</div>

							</div>
						</div>

					</div>
</asp:placeholder> 
<!-- end footer-->

                    <!--    
					        <div class="row-fluid">
                                

				                <div class="span4">
					                <div class="widget">
						                            <div class="widget-head" style="background-color:white;"><h3 class="heading">pH</h3> <span style="float:right;color:black;"><img src="img/temperature.png" width="10" class="temp">25°C</span></div>
								                    <div class="widget-body">asdasdasdasda</div>
								                    <div style="border-top: 1px solid #e5e5e5;padding-top: 10px;">
                                                        <div class="row-fluid">
									                        <div class="span6" style="text-align:center">
									                        Allarmi
										                        <ul class="unstyled alarm" style="padding-left:20px;padding-top: 10px;padding-bottom: 10px;">
    										                        <li class="glyphicons circle_exclamation_mark"><i></i>Allarme 1</li>
    										                        <li class="glyphicons circle_exclamation_mark"><i></i>Allarme 2</li>
   											                        <li class="glyphicons circle_exclamation_mark"><i></i>Allarme 3</li>
										                        </ul>
									                        </div>
								                            <div class="span6" style="text-align:center">Uscite
    									                        <ul class="unstyled output" style="padding-left:20px;padding-top: 10px;padding-bottom: 10px;">
    										                        <li class="glyphicons circle_arrow_right"><i></i>Allarme 1</li>
    										                        <li class="glyphicons circle_arrow_right"><i></i>Allarme 2</li>
   											                        <li class="glyphicons circle_arrow_right"><i></i>Allarme 3</li>
										                        </ul>
                                                            </div>
							                            </div>

								                    </div>
					                </div>
				                </div>
				                <div class="span4">
					                <div class="widget">
						                <div class="widget-head" style="background-color:white;"><h3 class="heading">Pagination</h3><span style="float:right;color:black;"><img src="img/temperature.png" width="10" class="temp">25°C</span></div>
								                <div class="widget-body">asdasdasdasda</div>
					                </div>
				                </div>
				                <div class="span4">
					                <div class="widget">
						                <div class="widget-head" style="background-color:white;"><h3 class="heading">Pagination</h3><span style="float:right;color:black;"><img src="img/temperature.png" width="10" class="temp">25°C</span></div>
								                <div class="widget-body">asdasdasdasda</div>
					                </div>
				                </div>
			            </div>
			 // FINE RIGA -->
			        </div>

            <asp:Literal ID="tabMenu" runat="server" Text="Channels"></asp:Literal>
			
            <div id="mainLogGraph" class="tab-pane widget-body-regular">
                <asp:Literal ID="tabMenuLog" runat="server" Text=""></asp:Literal>
                    <div id="chart_div" style="height: 700px; min-width: 500px">
        
                   </div>
                    <div id="chart_div_ldLog" style="height: 700px; min-width: 500px;display:none">
        
                   </div>

                    <div id="chart_table" >

                    </div>
                    <div id="chart_table_ldLog" style="display:none" >

                    </div>

            </div>
		</div>	




			</div>


			</div>

		
    
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="script_footer" runat="server">
        <script src="Centurio/jcanvas.js"></script>


</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="script_at_end" runat="server">
         <script src="theme/scripts/demo/calendar_new.js"></script>
        <link href="bootstrap/css/jquery-ui-timepicker-addon.css" rel="stylesheet" />
        <script type="text/javascript" src="Centurio/centurioMain.js?v=1.23"></script>
        <asp:Literal ID="javaScriptLiteral" runat="server"></asp:Literal>    

    	<script src="theme/scripts/plugins/notifications/Gritter/js/jquery.gritter.min.js"></script>
	
	<!-- Notyfy Notifications Plugin -->
	<script src="theme/scripts/plugins/notifications/notyfy/jquery.notyfy.js"></script>

</asp:Content>

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
							<br><asp:Literal ID="codiceSeriale" runat="server"></asp:Literal>
                        <br>
                        </br>
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

                                    <li id="manualCenturioEnable" class="dropdown" style="display: none;"><a  class="dropdown-toggle" data-toggle="dropdown" href='#'>Manual</a>
                                        <ul class="dropdown-menu"> 
                                            <li ><a href="#manualPulse" data-toggle="tab">Manual Pulse</a></li>
                                            <li ><a href="#manualRelay" data-toggle="tab">Manual Relay</a></li>
                                        </ul>
                                    </li>



                                    <asp:Literal ID="listMenu" runat="server" Text="Channels"></asp:Literal>
                                    <li class="dropdown"><a  class="dropdown-toggle" data-toggle="dropdown" href='#'>Log</a>
                                        <ul class="dropdown-menu"> 
                                            <li ><a href="#mainLogGraph" data-toggle="tab"><asp:Literal ID="Literal2" runat="server" Text="Log Graph"></asp:Literal><!--<asp:Literal ID="Literal1" runat="server" Text="Log Graph"></asp:Literal>--></a></li>
                                            <li ><a href="#mainLogReport" data-toggle="tab">Text Report</a></li>
                                        </ul>
                                    </li>

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
                    <div id="manualPulse" class="tab-pane widget-body-regular">
                        <div class="row-fluid"> <h5>Manual Pulse</h5>
                            <div class="span3">
                                </div>
                        </div>
                        <div class="row-fluid"> 
                                <div class="span3">
                                    <h5>Pulse 1</h5>
                                        <div class="row-fluid">
                                            <input id="checkmanualPulse1" manualRemote = "ok" calib="no" type="checkbox"  class="checkbox" value="0" />
                                        </div>
                                </div>
                                <div class="span3">
                                    <h5>Time(h,m)</h5><div class="row-fluid"><select manualRemote = "ok" calib="no" oreminuti="ore" action="setpoint" data-original-title="Delay" id="oremanualPulse1" count="2" class="span2"><option value="0">0</option><option value="1">1</option><option value="2">2</option><option value="3">3</option><option value="4">4</option><option value="5">5</option><option value="6">6</option><option value="7">7</option><option value="8">8</option><option value="9">9</option></select><select manualRemote = "ok" calib="no" oreminuti="minuti" action="setpoint" id="minutimanualPulse1" data-original-title="Delay" count="2" class="span2"><option value="0">0</option><option value="1">1</option><option value="2">2</option><option value="3">3</option><option value="4">4</option><option value="5">5</option><option value="6">6</option><option value="7">7</option><option value="8">8</option><option value="9">9</option><option value="10">10</option><option value="11">11</option><option value="12">12</option><option value="13">13</option><option value="14">14</option><option value="15">15</option><option value="16">16</option><option value="17">17</option><option value="18">18</option><option value="19">19</option><option value="20">20</option><option value="21">21</option><option value="22">22</option><option value="23">23</option><option value="24">24</option><option value="25">25</option><option value="26">26</option><option value="27">27</option><option value="28">28</option><option value="29">29</option><option value="30">30</option><option value="31">31</option><option value="32">32</option><option value="33">33</option><option value="34">34</option><option value="35">35</option><option value="36">36</option><option value="37">37</option><option value="38">38</option><option value="39">39</option><option value="40">40</option><option value="41">41</option><option value="42">42</option><option value="43">43</option><option value="44">44</option><option value="45">45</option><option value="46">46</option><option value="47">47</option><option value="48">48</option><option value="49">49</option><option value="50">50</option><option value="51">51</option><option value="52">52</option><option value="53">53</option><option value="54">54</option><option value="55">55</option><option value="56">56</option><option value="57">57</option><option value="58">58</option><option value="59">59</option></select></div>
                                </div>
                                <div class="span3">
                                    <h5>Pulse/ Minute</h5>
                                    <input id="pulsemanualPulse1" manualRemote = "ok" calib="no" multi="no" action="setpoint" data-original-title="Pulse Minutes" type="text"  count="3" min="0" minb="0" max="180" maxb="180" decimali="0" decimalib="0" error="Invalid Value" value="0" class="span3">
                                 </div>
                        </div>
                        <div class="row-fluid"> 
                                <div class="span3">
                                    <h5>Pulse 2</h5>
                                        <div class="row-fluid">
                                            <input id="checkmanualPulse2" manualRemote = "ok" calib="no" type="checkbox"  class="checkbox" value="0" />
                                        </div>
                                </div>
                                <div class="span3">
                                    <h5>Time(h,m)</h5><div class="row-fluid"><select manualRemote = "ok" calib="no" oreminuti="ore" action="setpoint" data-original-title="Delay" id="oremanualPulse2" count="2" class="span2"><option value="0">0</option><option value="1">1</option><option value="2">2</option><option value="3">3</option><option value="4">4</option><option value="5">5</option><option value="6">6</option><option value="7">7</option><option value="8">8</option><option value="9">9</option></select><select manualRemote = "ok" calib="no" oreminuti="minuti" action="setpoint" id="minutimanualPulse2" data-original-title="Delay" count="2" class="span2"><option value="0">0</option><option value="1">1</option><option value="2">2</option><option value="3">3</option><option value="4">4</option><option value="5">5</option><option value="6">6</option><option value="7">7</option><option value="8">8</option><option value="9">9</option><option value="10">10</option><option value="11">11</option><option value="12">12</option><option value="13">13</option><option value="14">14</option><option value="15">15</option><option value="16">16</option><option value="17">17</option><option value="18">18</option><option value="19">19</option><option value="20">20</option><option value="21">21</option><option value="22">22</option><option value="23">23</option><option value="24">24</option><option value="25">25</option><option value="26">26</option><option value="27">27</option><option value="28">28</option><option value="29">29</option><option value="30">30</option><option value="31">31</option><option value="32">32</option><option value="33">33</option><option value="34">34</option><option value="35">35</option><option value="36">36</option><option value="37">37</option><option value="38">38</option><option value="39">39</option><option value="40">40</option><option value="41">41</option><option value="42">42</option><option value="43">43</option><option value="44">44</option><option value="45">45</option><option value="46">46</option><option value="47">47</option><option value="48">48</option><option value="49">49</option><option value="50">50</option><option value="51">51</option><option value="52">52</option><option value="53">53</option><option value="54">54</option><option value="55">55</option><option value="56">56</option><option value="57">57</option><option value="58">58</option><option value="59">59</option></select></div>
                                </div>
                                <div class="span3">
                                    <h5>Pulse/ Minute</h5>
                                    <input id="pulsemanualPulse2" manualRemote = "ok" calib="no" multi="no" action="setpoint" data-original-title="Pulse Minutes" type="text"  count="3" min="0" minb="0" max="180" maxb="180" decimali="0" decimalib="0" error="Invalid Value" value="0" class="span3">
                                 </div>
                        </div>
                        <div class="row-fluid"> 
                                <div class="span3">
                                    <h5>Pulse 3</h5>
                                        <div class="row-fluid">
                                            <input id="checkmanualPulse3" manualRemote = "ok" calib="no" type="checkbox"  class="checkbox" value="0" />
                                        </div>
                                </div>
                                <div class="span3">
                                    <h5>Time(h,m)</h5><div class="row-fluid"><select manualRemote = "ok" calib="no" oreminuti="ore" action="setpoint" data-original-title="Delay" id="oremanualPulse3" count="2" class="span2"><option value="0">0</option><option value="1">1</option><option value="2">2</option><option value="3">3</option><option value="4">4</option><option value="5">5</option><option value="6">6</option><option value="7">7</option><option value="8">8</option><option value="9">9</option></select><select manualRemote = "ok" calib="no" oreminuti="minuti" action="setpoint" id="minutimanualPulse3" data-original-title="Delay" count="2" class="span2"><option value="0">0</option><option value="1">1</option><option value="2">2</option><option value="3">3</option><option value="4">4</option><option value="5">5</option><option value="6">6</option><option value="7">7</option><option value="8">8</option><option value="9">9</option><option value="10">10</option><option value="11">11</option><option value="12">12</option><option value="13">13</option><option value="14">14</option><option value="15">15</option><option value="16">16</option><option value="17">17</option><option value="18">18</option><option value="19">19</option><option value="20">20</option><option value="21">21</option><option value="22">22</option><option value="23">23</option><option value="24">24</option><option value="25">25</option><option value="26">26</option><option value="27">27</option><option value="28">28</option><option value="29">29</option><option value="30">30</option><option value="31">31</option><option value="32">32</option><option value="33">33</option><option value="34">34</option><option value="35">35</option><option value="36">36</option><option value="37">37</option><option value="38">38</option><option value="39">39</option><option value="40">40</option><option value="41">41</option><option value="42">42</option><option value="43">43</option><option value="44">44</option><option value="45">45</option><option value="46">46</option><option value="47">47</option><option value="48">48</option><option value="49">49</option><option value="50">50</option><option value="51">51</option><option value="52">52</option><option value="53">53</option><option value="54">54</option><option value="55">55</option><option value="56">56</option><option value="57">57</option><option value="58">58</option><option value="59">59</option></select></div>
                                </div>
                                <div class="span3">
                                    <h5>Pulse/ Minute</h5>
                                    <input id="pulsemanualPulse3" manualRemote = "ok" calib="no" multi="no" action="setpoint" data-original-title="Pulse Minutes" type="text"  count="3" min="0" minb="0" max="180" maxb="180" decimali="0" decimalib="0" error="Invalid Value" value="0" class="span3">
                                 </div>
                        </div>
                        <div class="row-fluid"> 
                                <div class="span3">
                                    <h5>Pulse 4</h5>
                                        <div class="row-fluid">
                                            <input id="checkmanualPulse4" manualRemote = "ok" calib="no" type="checkbox"  class="checkbox" value="0" />
                                        </div>
                                </div>
                                <div class="span3">
                                    <h5>Time(h,m)</h5><div class="row-fluid"><select manualRemote = "ok" calib="no" oreminuti="ore" action="setpoint" data-original-title="Delay" id="oremanualPulse4" count="2" class="span2"><option value="0">0</option><option value="1">1</option><option value="2">2</option><option value="3">3</option><option value="4">4</option><option value="5">5</option><option value="6">6</option><option value="7">7</option><option value="8">8</option><option value="9">9</option></select><select manualRemote = "ok" calib="no" oreminuti="minuti" action="setpoint" id="minutimanualPulse4" data-original-title="Delay" count="2" class="span2"><option value="0">0</option><option value="1">1</option><option value="2">2</option><option value="3">3</option><option value="4">4</option><option value="5">5</option><option value="6">6</option><option value="7">7</option><option value="8">8</option><option value="9">9</option><option value="10">10</option><option value="11">11</option><option value="12">12</option><option value="13">13</option><option value="14">14</option><option value="15">15</option><option value="16">16</option><option value="17">17</option><option value="18">18</option><option value="19">19</option><option value="20">20</option><option value="21">21</option><option value="22">22</option><option value="23">23</option><option value="24">24</option><option value="25">25</option><option value="26">26</option><option value="27">27</option><option value="28">28</option><option value="29">29</option><option value="30">30</option><option value="31">31</option><option value="32">32</option><option value="33">33</option><option value="34">34</option><option value="35">35</option><option value="36">36</option><option value="37">37</option><option value="38">38</option><option value="39">39</option><option value="40">40</option><option value="41">41</option><option value="42">42</option><option value="43">43</option><option value="44">44</option><option value="45">45</option><option value="46">46</option><option value="47">47</option><option value="48">48</option><option value="49">49</option><option value="50">50</option><option value="51">51</option><option value="52">52</option><option value="53">53</option><option value="54">54</option><option value="55">55</option><option value="56">56</option><option value="57">57</option><option value="58">58</option><option value="59">59</option></select></div>
                                </div>
                                <div class="span3">
                                    <h5>Pulse/ Minute</h5>
                                    <input id="pulsemanualPulse4" manualRemote = "ok" calib="no" multi="no" action="setpoint" data-original-title="Pulse Minutes" type="text"  count="3" min="0" minb="0" max="180" maxb="180" decimali="0" decimalib="0" error="Invalid Value" value="0" class="span3">
                                 </div>
                        </div>
                        <div class="row-fluid"> 
                                <div class="span3">
                                    <h5>Pulse 5</h5>
                                        <div class="row-fluid">
                                            <input id="checkmanualPulse5" manualRemote = "ok" calib="no" type="checkbox"  class="checkbox" value="0" />
                                        </div>
                                </div>
                                <div class="span3">
                                    <h5>Time(h,m)</h5><div class="row-fluid"><select manualRemote = "ok" calib="no" oreminuti="ore" action="setpoint" data-original-title="Delay" id="oremanualPulse5" count="2" class="span2"><option value="0">0</option><option value="1">1</option><option value="2">2</option><option value="3">3</option><option value="4">4</option><option value="5">5</option><option value="6">6</option><option value="7">7</option><option value="8">8</option><option value="9">9</option></select><select manualRemote = "ok" calib="no" oreminuti="minuti" action="setpoint" id="minutimanualPulse5" data-original-title="Delay" count="2" class="span2"><option value="0">0</option><option value="1">1</option><option value="2">2</option><option value="3">3</option><option value="4">4</option><option value="5">5</option><option value="6">6</option><option value="7">7</option><option value="8">8</option><option value="9">9</option><option value="10">10</option><option value="11">11</option><option value="12">12</option><option value="13">13</option><option value="14">14</option><option value="15">15</option><option value="16">16</option><option value="17">17</option><option value="18">18</option><option value="19">19</option><option value="20">20</option><option value="21">21</option><option value="22">22</option><option value="23">23</option><option value="24">24</option><option value="25">25</option><option value="26">26</option><option value="27">27</option><option value="28">28</option><option value="29">29</option><option value="30">30</option><option value="31">31</option><option value="32">32</option><option value="33">33</option><option value="34">34</option><option value="35">35</option><option value="36">36</option><option value="37">37</option><option value="38">38</option><option value="39">39</option><option value="40">40</option><option value="41">41</option><option value="42">42</option><option value="43">43</option><option value="44">44</option><option value="45">45</option><option value="46">46</option><option value="47">47</option><option value="48">48</option><option value="49">49</option><option value="50">50</option><option value="51">51</option><option value="52">52</option><option value="53">53</option><option value="54">54</option><option value="55">55</option><option value="56">56</option><option value="57">57</option><option value="58">58</option><option value="59">59</option></select></div>
                                </div>
                                <div class="span3">
                                    <h5>Pulse/ Minute</h5>
                                    <input id="pulsemanualPulse5" manualRemote = "ok" calib="no" multi="no" action="setpoint" data-original-title="Pulse Minutes" type="text"  count="3" min="0" minb="0" max="180" maxb="180" decimali="0" decimalib="0" error="Invalid Value" value="0" class="span3">
                                 </div>
                        </div>
                        <div class="row-fluid"> 
                                <div class="span3">
                                    <h5>Pulse 6</h5>
                                        <div class="row-fluid">
                                            <input id="checkmanualPulse6" manualRemote = "ok" calib="no" type="checkbox"  class="checkbox" value="0" />
                                        </div>
                                </div>
                                <div class="span3">
                                    <h5>Time(h,m)</h5><div class="row-fluid"><select manualRemote = "ok" calib="no" oreminuti="ore" action="setpoint" data-original-title="Delay" id="oremanualPulse6" count="2" class="span2"><option value="0">0</option><option value="1">1</option><option value="2">2</option><option value="3">3</option><option value="4">4</option><option value="5">5</option><option value="6">6</option><option value="7">7</option><option value="8">8</option><option value="9">9</option></select><select manualRemote = "ok" calib="no" oreminuti="minuti" action="setpoint" id="minutimanualPulse6" data-original-title="Delay" count="2" class="span2"><option value="0">0</option><option value="1">1</option><option value="2">2</option><option value="3">3</option><option value="4">4</option><option value="5">5</option><option value="6">6</option><option value="7">7</option><option value="8">8</option><option value="9">9</option><option value="10">10</option><option value="11">11</option><option value="12">12</option><option value="13">13</option><option value="14">14</option><option value="15">15</option><option value="16">16</option><option value="17">17</option><option value="18">18</option><option value="19">19</option><option value="20">20</option><option value="21">21</option><option value="22">22</option><option value="23">23</option><option value="24">24</option><option value="25">25</option><option value="26">26</option><option value="27">27</option><option value="28">28</option><option value="29">29</option><option value="30">30</option><option value="31">31</option><option value="32">32</option><option value="33">33</option><option value="34">34</option><option value="35">35</option><option value="36">36</option><option value="37">37</option><option value="38">38</option><option value="39">39</option><option value="40">40</option><option value="41">41</option><option value="42">42</option><option value="43">43</option><option value="44">44</option><option value="45">45</option><option value="46">46</option><option value="47">47</option><option value="48">48</option><option value="49">49</option><option value="50">50</option><option value="51">51</option><option value="52">52</option><option value="53">53</option><option value="54">54</option><option value="55">55</option><option value="56">56</option><option value="57">57</option><option value="58">58</option><option value="59">59</option></select></div>
                                </div>
                                <div class="span3">
                                    <h5>Pulse/ Minute</h5>
                                    <input id="pulsemanualPulse6" manualRemote = "ok" calib="no" multi="no" action="setpoint" data-original-title="Pulse Minutes" type="text"  count="3" min="0" minb="0" max="180" maxb="180" decimali="0" decimalib="0" error="Invalid Value" value="0" class="span3">
                                 </div>
                        </div>
                        <div class="row-fluid"> 
                                <div class="span3">
                                    <h5>Pulse 7</h5>
                                        <div class="row-fluid">
                                            <input id="checkmanualPulse7" manualRemote = "ok" calib="no" type="checkbox"  class="checkbox" value="0" />
                                        </div>
                                </div>
                                <div class="span3">
                                    <h5>Time(h,m)</h5><div class="row-fluid"><select manualRemote = "ok" calib="no" oreminuti="ore" action="setpoint" data-original-title="Delay" id="oremanualPulse7" count="2" class="span2"><option value="0">0</option><option value="1">1</option><option value="2">2</option><option value="3">3</option><option value="4">4</option><option value="5">5</option><option value="6">6</option><option value="7">7</option><option value="8">8</option><option value="9">9</option></select><select manualRemote = "ok" calib="no" oreminuti="minuti" action="setpoint" id="minutimanualPulse7" data-original-title="Delay" count="2" class="span2"><option value="0">0</option><option value="1">1</option><option value="2">2</option><option value="3">3</option><option value="4">4</option><option value="5">5</option><option value="6">6</option><option value="7">7</option><option value="8">8</option><option value="9">9</option><option value="10">10</option><option value="11">11</option><option value="12">12</option><option value="13">13</option><option value="14">14</option><option value="15">15</option><option value="16">16</option><option value="17">17</option><option value="18">18</option><option value="19">19</option><option value="20">20</option><option value="21">21</option><option value="22">22</option><option value="23">23</option><option value="24">24</option><option value="25">25</option><option value="26">26</option><option value="27">27</option><option value="28">28</option><option value="29">29</option><option value="30">30</option><option value="31">31</option><option value="32">32</option><option value="33">33</option><option value="34">34</option><option value="35">35</option><option value="36">36</option><option value="37">37</option><option value="38">38</option><option value="39">39</option><option value="40">40</option><option value="41">41</option><option value="42">42</option><option value="43">43</option><option value="44">44</option><option value="45">45</option><option value="46">46</option><option value="47">47</option><option value="48">48</option><option value="49">49</option><option value="50">50</option><option value="51">51</option><option value="52">52</option><option value="53">53</option><option value="54">54</option><option value="55">55</option><option value="56">56</option><option value="57">57</option><option value="58">58</option><option value="59">59</option></select></div>
                                </div>
                                <div class="span3">
                                    <h5>Pulse/ Minute</h5>
                                    <input id="pulsemanualPulse7" manualRemote = "ok" calib="no" multi="no" action="setpoint" data-original-title="Pulse Minutes" type="text"  count="3" min="0" minb="0" max="180" maxb="180" decimali="0" decimalib="0" error="Invalid Value" value="0" class="span3">
                                 </div>
                        </div>
                        <div class="row-fluid"> 
                                <div class="span3">
                                    <h5>Pulse 8</h5>
                                        <div class="row-fluid">
                                            <input id="checkmanualPulse8" manualRemote = "ok" calib="no" type="checkbox"  class="checkbox" value="0" />
                                        </div>
                                </div>
                                <div class="span3">
                                    <h5>Time(h,m)</h5><div class="row-fluid"><select manualRemote = "ok" calib="no" oreminuti="ore" action="setpoint" data-original-title="Delay" id="oremanualPulse8" count="2" class="span2"><option value="0">0</option><option value="1">1</option><option value="2">2</option><option value="3">3</option><option value="4">4</option><option value="5">5</option><option value="6">6</option><option value="7">7</option><option value="8">8</option><option value="9">9</option></select><select manualRemote = "ok" calib="no" oreminuti="minuti" action="setpoint" id="minutimanualPulse8" data-original-title="Delay" count="2" class="span2"><option value="0">0</option><option value="1">1</option><option value="2">2</option><option value="3">3</option><option value="4">4</option><option value="5">5</option><option value="6">6</option><option value="7">7</option><option value="8">8</option><option value="9">9</option><option value="10">10</option><option value="11">11</option><option value="12">12</option><option value="13">13</option><option value="14">14</option><option value="15">15</option><option value="16">16</option><option value="17">17</option><option value="18">18</option><option value="19">19</option><option value="20">20</option><option value="21">21</option><option value="22">22</option><option value="23">23</option><option value="24">24</option><option value="25">25</option><option value="26">26</option><option value="27">27</option><option value="28">28</option><option value="29">29</option><option value="30">30</option><option value="31">31</option><option value="32">32</option><option value="33">33</option><option value="34">34</option><option value="35">35</option><option value="36">36</option><option value="37">37</option><option value="38">38</option><option value="39">39</option><option value="40">40</option><option value="41">41</option><option value="42">42</option><option value="43">43</option><option value="44">44</option><option value="45">45</option><option value="46">46</option><option value="47">47</option><option value="48">48</option><option value="49">49</option><option value="50">50</option><option value="51">51</option><option value="52">52</option><option value="53">53</option><option value="54">54</option><option value="55">55</option><option value="56">56</option><option value="57">57</option><option value="58">58</option><option value="59">59</option></select></div>
                                </div>
                                <div class="span3">
                                    <h5>Pulse/ Minute</h5>
                                    <input id="pulsemanualPulse8" manualRemote = "ok" calib="no" multi="no" action="setpoint" data-original-title="Pulse Minutes" type="text"  count="3" min="0" minb="0" max="180" maxb="180" decimali="0" decimalib="0" error="Invalid Value" value="0" class="span3">
                                 </div>
                        </div>
                        <p></p>
                        <asp:PlaceHolder ID="enableManualPulse" runat="server">
                        <div class="row-fluid"> 
                                <div class="row-fluid"><input manualremote="ok" calib="no" typeaction="remoteCalib" type="button" id="pulseStartRemote" actionvalue="outManualPulse"  class="btn btn-primary" value="Start Manual Pulse"></div>
                        </div>
                            </asp:PlaceHolder>
                        <p></p>
                        <p></p>
            </div>
                    <div id="manualRelay" class="tab-pane widget-body-regular">
                        <div class="row-fluid"> <h5>Manual Relay</h5>
                            <div class="span3">
                                </div>
                        </div>
                        <div class="row-fluid"> 
                                <div class="span3">
                                    <h5>Relay 1</h5>
                                        <div class="row-fluid">
                                            <input id="checkmanualRelay1" manualRemote = "ok" calib="no" type="checkbox"  class="checkbox" value="0" />
                                        </div>
                                </div>
                                <div class="span3">
                                    <h5>Time(h,m)</h5><div class="row-fluid"><select manualRemote = "ok" calib="no" oreminuti="ore" action="setpoint" data-original-title="Delay" id="oremanualRelay1" count="2" class="span2"><option value="0">0</option><option value="1">1</option><option value="2">2</option><option value="3">3</option><option value="4">4</option><option value="5">5</option><option value="6">6</option><option value="7">7</option><option value="8">8</option><option value="9">9</option></select><select manualRemote = "ok" calib="no" oreminuti="minuti" action="setpoint" id="minutimanualRelay1" data-original-title="Delay" count="2" class="span2"><option value="0">0</option><option value="1">1</option><option value="2">2</option><option value="3">3</option><option value="4">4</option><option value="5">5</option><option value="6">6</option><option value="7">7</option><option value="8">8</option><option value="9">9</option><option value="10">10</option><option value="11">11</option><option value="12">12</option><option value="13">13</option><option value="14">14</option><option value="15">15</option><option value="16">16</option><option value="17">17</option><option value="18">18</option><option value="19">19</option><option value="20">20</option><option value="21">21</option><option value="22">22</option><option value="23">23</option><option value="24">24</option><option value="25">25</option><option value="26">26</option><option value="27">27</option><option value="28">28</option><option value="29">29</option><option value="30">30</option><option value="31">31</option><option value="32">32</option><option value="33">33</option><option value="34">34</option><option value="35">35</option><option value="36">36</option><option value="37">37</option><option value="38">38</option><option value="39">39</option><option value="40">40</option><option value="41">41</option><option value="42">42</option><option value="43">43</option><option value="44">44</option><option value="45">45</option><option value="46">46</option><option value="47">47</option><option value="48">48</option><option value="49">49</option><option value="50">50</option><option value="51">51</option><option value="52">52</option><option value="53">53</option><option value="54">54</option><option value="55">55</option><option value="56">56</option><option value="57">57</option><option value="58">58</option><option value="59">59</option></select></div>
                                </div>
                        </div>
                        <div class="row-fluid"> 
                                <div class="span3">
                                    <h5>Relay 2</h5>
                                        <div class="row-fluid">
                                            <input id="checkmanualRelay2" manualRemote = "ok" calib="no" type="checkbox"  class="checkbox" value="0" />
                                        </div>
                                </div>
                                <div class="span3">
                                    <h5>Time(h,m)</h5><div class="row-fluid"><select manualRemote = "ok" calib="no" oreminuti="ore" action="setpoint" data-original-title="Delay" id="oremanualRelay2" count="2" class="span2"><option value="0">0</option><option value="1">1</option><option value="2">2</option><option value="3">3</option><option value="4">4</option><option value="5">5</option><option value="6">6</option><option value="7">7</option><option value="8">8</option><option value="9">9</option></select><select manualRemote = "ok" calib="no" oreminuti="minuti" action="setpoint" id="minutimanualRelay2" data-original-title="Delay" count="2" class="span2"><option value="0">0</option><option value="1">1</option><option value="2">2</option><option value="3">3</option><option value="4">4</option><option value="5">5</option><option value="6">6</option><option value="7">7</option><option value="8">8</option><option value="9">9</option><option value="10">10</option><option value="11">11</option><option value="12">12</option><option value="13">13</option><option value="14">14</option><option value="15">15</option><option value="16">16</option><option value="17">17</option><option value="18">18</option><option value="19">19</option><option value="20">20</option><option value="21">21</option><option value="22">22</option><option value="23">23</option><option value="24">24</option><option value="25">25</option><option value="26">26</option><option value="27">27</option><option value="28">28</option><option value="29">29</option><option value="30">30</option><option value="31">31</option><option value="32">32</option><option value="33">33</option><option value="34">34</option><option value="35">35</option><option value="36">36</option><option value="37">37</option><option value="38">38</option><option value="39">39</option><option value="40">40</option><option value="41">41</option><option value="42">42</option><option value="43">43</option><option value="44">44</option><option value="45">45</option><option value="46">46</option><option value="47">47</option><option value="48">48</option><option value="49">49</option><option value="50">50</option><option value="51">51</option><option value="52">52</option><option value="53">53</option><option value="54">54</option><option value="55">55</option><option value="56">56</option><option value="57">57</option><option value="58">58</option><option value="59">59</option></select></div>
                                </div>
                        </div>
                        <div class="row-fluid"> 
                                <div class="span3">
                                    <h5>Relay 3</h5>
                                        <div class="row-fluid">
                                            <input id="checkmanualRelay3" manualRemote = "ok" calib="no" type="checkbox"  class="checkbox" value="0" />
                                        </div>
                                </div>
                                <div class="span3">
                                    <h5>Time(h,m)</h5><div class="row-fluid"><select manualRemote = "ok" calib="no" oreminuti="ore" action="setpoint" data-original-title="Delay" id="oremanualRelay3" count="2" class="span2"><option value="0">0</option><option value="1">1</option><option value="2">2</option><option value="3">3</option><option value="4">4</option><option value="5">5</option><option value="6">6</option><option value="7">7</option><option value="8">8</option><option value="9">9</option></select><select manualRemote = "ok" calib="no" oreminuti="minuti" action="setpoint" id="minutimanualRelay3" data-original-title="Delay" count="2" class="span2"><option value="0">0</option><option value="1">1</option><option value="2">2</option><option value="3">3</option><option value="4">4</option><option value="5">5</option><option value="6">6</option><option value="7">7</option><option value="8">8</option><option value="9">9</option><option value="10">10</option><option value="11">11</option><option value="12">12</option><option value="13">13</option><option value="14">14</option><option value="15">15</option><option value="16">16</option><option value="17">17</option><option value="18">18</option><option value="19">19</option><option value="20">20</option><option value="21">21</option><option value="22">22</option><option value="23">23</option><option value="24">24</option><option value="25">25</option><option value="26">26</option><option value="27">27</option><option value="28">28</option><option value="29">29</option><option value="30">30</option><option value="31">31</option><option value="32">32</option><option value="33">33</option><option value="34">34</option><option value="35">35</option><option value="36">36</option><option value="37">37</option><option value="38">38</option><option value="39">39</option><option value="40">40</option><option value="41">41</option><option value="42">42</option><option value="43">43</option><option value="44">44</option><option value="45">45</option><option value="46">46</option><option value="47">47</option><option value="48">48</option><option value="49">49</option><option value="50">50</option><option value="51">51</option><option value="52">52</option><option value="53">53</option><option value="54">54</option><option value="55">55</option><option value="56">56</option><option value="57">57</option><option value="58">58</option><option value="59">59</option></select></div>
                                </div>
                        </div>
                        <div class="row-fluid"> 
                                <div class="span3">
                                    <h5>Relay 4</h5>
                                        <div class="row-fluid">
                                            <input id="checkmanualRelay4" manualRemote = "ok" calib="no" type="checkbox"  class="checkbox" value="0" />
                                        </div>
                                </div>
                                <div class="span3">
                                    <h5>Time(h,m)</h5><div class="row-fluid"><select manualRemote = "ok" calib="no" oreminuti="ore" action="setpoint" data-original-title="Delay" id="oremanualRelay4" count="2" class="span2"><option value="0">0</option><option value="1">1</option><option value="2">2</option><option value="3">3</option><option value="4">4</option><option value="5">5</option><option value="6">6</option><option value="7">7</option><option value="8">8</option><option value="9">9</option></select><select manualRemote = "ok" calib="no" oreminuti="minuti" action="setpoint" id="minutimanualRelay4" data-original-title="Delay" count="2" class="span2"><option value="0">0</option><option value="1">1</option><option value="2">2</option><option value="3">3</option><option value="4">4</option><option value="5">5</option><option value="6">6</option><option value="7">7</option><option value="8">8</option><option value="9">9</option><option value="10">10</option><option value="11">11</option><option value="12">12</option><option value="13">13</option><option value="14">14</option><option value="15">15</option><option value="16">16</option><option value="17">17</option><option value="18">18</option><option value="19">19</option><option value="20">20</option><option value="21">21</option><option value="22">22</option><option value="23">23</option><option value="24">24</option><option value="25">25</option><option value="26">26</option><option value="27">27</option><option value="28">28</option><option value="29">29</option><option value="30">30</option><option value="31">31</option><option value="32">32</option><option value="33">33</option><option value="34">34</option><option value="35">35</option><option value="36">36</option><option value="37">37</option><option value="38">38</option><option value="39">39</option><option value="40">40</option><option value="41">41</option><option value="42">42</option><option value="43">43</option><option value="44">44</option><option value="45">45</option><option value="46">46</option><option value="47">47</option><option value="48">48</option><option value="49">49</option><option value="50">50</option><option value="51">51</option><option value="52">52</option><option value="53">53</option><option value="54">54</option><option value="55">55</option><option value="56">56</option><option value="57">57</option><option value="58">58</option><option value="59">59</option></select></div>
                                </div>
                        </div>
                        <div class="row-fluid"> 
                                <div class="span3">
                                    <h5>Relay 5</h5>
                                        <div class="row-fluid">
                                            <input id="checkmanualRelay5" manualRemote = "ok" calib="no" type="checkbox"  class="checkbox" value="0" />
                                        </div>
                                </div>
                                <div class="span3">
                                    <h5>Time(h,m)</h5><div class="row-fluid"><select manualRemote = "ok" calib="no" oreminuti="ore" action="setpoint" data-original-title="Delay" id="oremanualRelay5" count="2" class="span2"><option value="0">0</option><option value="1">1</option><option value="2">2</option><option value="3">3</option><option value="4">4</option><option value="5">5</option><option value="6">6</option><option value="7">7</option><option value="8">8</option><option value="9">9</option></select><select manualRemote = "ok" calib="no" oreminuti="minuti" action="setpoint" id="minutimanualRelay5" data-original-title="Delay" count="2" class="span2"><option value="0">0</option><option value="1">1</option><option value="2">2</option><option value="3">3</option><option value="4">4</option><option value="5">5</option><option value="6">6</option><option value="7">7</option><option value="8">8</option><option value="9">9</option><option value="10">10</option><option value="11">11</option><option value="12">12</option><option value="13">13</option><option value="14">14</option><option value="15">15</option><option value="16">16</option><option value="17">17</option><option value="18">18</option><option value="19">19</option><option value="20">20</option><option value="21">21</option><option value="22">22</option><option value="23">23</option><option value="24">24</option><option value="25">25</option><option value="26">26</option><option value="27">27</option><option value="28">28</option><option value="29">29</option><option value="30">30</option><option value="31">31</option><option value="32">32</option><option value="33">33</option><option value="34">34</option><option value="35">35</option><option value="36">36</option><option value="37">37</option><option value="38">38</option><option value="39">39</option><option value="40">40</option><option value="41">41</option><option value="42">42</option><option value="43">43</option><option value="44">44</option><option value="45">45</option><option value="46">46</option><option value="47">47</option><option value="48">48</option><option value="49">49</option><option value="50">50</option><option value="51">51</option><option value="52">52</option><option value="53">53</option><option value="54">54</option><option value="55">55</option><option value="56">56</option><option value="57">57</option><option value="58">58</option><option value="59">59</option></select></div>
                                </div>
                        </div>
                        <div class="row-fluid"> 
                                <div class="span3">
                                    <h5>Relay 6</h5>
                                        <div class="row-fluid">
                                            <input id="checkmanualRelay6" manualRemote = "ok" calib="no" type="checkbox"  class="checkbox" value="0" />
                                        </div>
                                </div>
                                <div class="span3">
                                    <h5>Time(h,m)</h5><div class="row-fluid"><select manualRemote = "ok" calib="no" oreminuti="ore" action="setpoint" data-original-title="Delay" id="oremanualRelay6" count="2" class="span2"><option value="0">0</option><option value="1">1</option><option value="2">2</option><option value="3">3</option><option value="4">4</option><option value="5">5</option><option value="6">6</option><option value="7">7</option><option value="8">8</option><option value="9">9</option></select><select manualRemote = "ok" calib="no" oreminuti="minuti" action="setpoint" id="minutimanualRelay6" data-original-title="Delay" count="2" class="span2"><option value="0">0</option><option value="1">1</option><option value="2">2</option><option value="3">3</option><option value="4">4</option><option value="5">5</option><option value="6">6</option><option value="7">7</option><option value="8">8</option><option value="9">9</option><option value="10">10</option><option value="11">11</option><option value="12">12</option><option value="13">13</option><option value="14">14</option><option value="15">15</option><option value="16">16</option><option value="17">17</option><option value="18">18</option><option value="19">19</option><option value="20">20</option><option value="21">21</option><option value="22">22</option><option value="23">23</option><option value="24">24</option><option value="25">25</option><option value="26">26</option><option value="27">27</option><option value="28">28</option><option value="29">29</option><option value="30">30</option><option value="31">31</option><option value="32">32</option><option value="33">33</option><option value="34">34</option><option value="35">35</option><option value="36">36</option><option value="37">37</option><option value="38">38</option><option value="39">39</option><option value="40">40</option><option value="41">41</option><option value="42">42</option><option value="43">43</option><option value="44">44</option><option value="45">45</option><option value="46">46</option><option value="47">47</option><option value="48">48</option><option value="49">49</option><option value="50">50</option><option value="51">51</option><option value="52">52</option><option value="53">53</option><option value="54">54</option><option value="55">55</option><option value="56">56</option><option value="57">57</option><option value="58">58</option><option value="59">59</option></select></div>
                                </div>
                        </div>
                        <div class="row-fluid"> 
                                <div class="span3">
                                    <h5>Relay 7</h5>
                                        <div class="row-fluid">
                                            <input id="checkmanualRelay7" manualRemote = "ok" calib="no" type="checkbox"  class="checkbox" value="0" />
                                        </div>
                                </div>
                                <div class="span3">
                                    <h5>Time(h,m)</h5><div class="row-fluid"><select manualRemote = "ok" calib="no" oreminuti="ore" action="setpoint" data-original-title="Delay" id="oremanualRelay7" count="2" class="span2"><option value="0">0</option><option value="1">1</option><option value="2">2</option><option value="3">3</option><option value="4">4</option><option value="5">5</option><option value="6">6</option><option value="7">7</option><option value="8">8</option><option value="9">9</option></select><select manualRemote = "ok" calib="no" oreminuti="minuti" action="setpoint" id="minutimanualRelay7" data-original-title="Delay" count="2" class="span2"><option value="0">0</option><option value="1">1</option><option value="2">2</option><option value="3">3</option><option value="4">4</option><option value="5">5</option><option value="6">6</option><option value="7">7</option><option value="8">8</option><option value="9">9</option><option value="10">10</option><option value="11">11</option><option value="12">12</option><option value="13">13</option><option value="14">14</option><option value="15">15</option><option value="16">16</option><option value="17">17</option><option value="18">18</option><option value="19">19</option><option value="20">20</option><option value="21">21</option><option value="22">22</option><option value="23">23</option><option value="24">24</option><option value="25">25</option><option value="26">26</option><option value="27">27</option><option value="28">28</option><option value="29">29</option><option value="30">30</option><option value="31">31</option><option value="32">32</option><option value="33">33</option><option value="34">34</option><option value="35">35</option><option value="36">36</option><option value="37">37</option><option value="38">38</option><option value="39">39</option><option value="40">40</option><option value="41">41</option><option value="42">42</option><option value="43">43</option><option value="44">44</option><option value="45">45</option><option value="46">46</option><option value="47">47</option><option value="48">48</option><option value="49">49</option><option value="50">50</option><option value="51">51</option><option value="52">52</option><option value="53">53</option><option value="54">54</option><option value="55">55</option><option value="56">56</option><option value="57">57</option><option value="58">58</option><option value="59">59</option></select></div>
                                </div>
                        </div>
                        <div class="row-fluid"> 
                                <div class="span3">
                                    <h5>Relay 8</h5>
                                        <div class="row-fluid">
                                            <input id="checkmanualRelay8" manualRemote = "ok" calib="no" type="checkbox"  class="checkbox" value="0" />
                                        </div>
                                </div>
                                <div class="span3">
                                    <h5>Time(h,m)</h5><div class="row-fluid"><select manualRemote = "ok" calib="no" oreminuti="ore" action="setpoint" data-original-title="Delay" id="oremanualRelay8" count="2" class="span2"><option value="0">0</option><option value="1">1</option><option value="2">2</option><option value="3">3</option><option value="4">4</option><option value="5">5</option><option value="6">6</option><option value="7">7</option><option value="8">8</option><option value="9">9</option></select><select manualRemote = "ok" calib="no" oreminuti="minuti" action="setpoint" id="minutimanualRelay8" data-original-title="Delay" count="2" class="span2"><option value="0">0</option><option value="1">1</option><option value="2">2</option><option value="3">3</option><option value="4">4</option><option value="5">5</option><option value="6">6</option><option value="7">7</option><option value="8">8</option><option value="9">9</option><option value="10">10</option><option value="11">11</option><option value="12">12</option><option value="13">13</option><option value="14">14</option><option value="15">15</option><option value="16">16</option><option value="17">17</option><option value="18">18</option><option value="19">19</option><option value="20">20</option><option value="21">21</option><option value="22">22</option><option value="23">23</option><option value="24">24</option><option value="25">25</option><option value="26">26</option><option value="27">27</option><option value="28">28</option><option value="29">29</option><option value="30">30</option><option value="31">31</option><option value="32">32</option><option value="33">33</option><option value="34">34</option><option value="35">35</option><option value="36">36</option><option value="37">37</option><option value="38">38</option><option value="39">39</option><option value="40">40</option><option value="41">41</option><option value="42">42</option><option value="43">43</option><option value="44">44</option><option value="45">45</option><option value="46">46</option><option value="47">47</option><option value="48">48</option><option value="49">49</option><option value="50">50</option><option value="51">51</option><option value="52">52</option><option value="53">53</option><option value="54">54</option><option value="55">55</option><option value="56">56</option><option value="57">57</option><option value="58">58</option><option value="59">59</option></select></div>
                                </div>
                        </div>
                        <p></p>
                        <asp:PlaceHolder ID="enableManualRelay" runat="server">
                        <div class="row-fluid"> 
                                <div class="row-fluid"><input manualremote="ok" calib="no" typeaction="remoteCalib" type="button" id="relayStartRemote" actionvalue="outManualRelay"  class="btn btn-primary" value="Start Manual Relay"></div>
                        </div>
                       </asp:PlaceHolder>
                        <p></p>
                        <p></p>
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
            <div id="mainLogReport" class="tab-pane widget-body-regular">
                <div class="row-fluid"> <h5>Report</h5>
                    <div class="span3">
                        </div>
                </div>
                <div class="row-fluid"> <h5></h5>
                    <div class="span3">
                        </div>
                </div>
                <div class="row-fluid"> <h5></h5>
                    <div class="span3">
                        </div>
                </div>

                <div class="row-fluid"> <h5>Date Time Range</h5>
                    <div class="span3">
                        <h5>From:</h5>
                         <input calib = "no" data-placement="right" type = "text" value=""  id = "reportFrom" min ="minlog"></input>
                    </div>
                       <div class="span3">
                        <h5>To:</h5>
                           <input calib = "no" data-placement="right" type = "text" value=""  id = "reportTo" min ="minlog"></input>
                    </div>

                </div>
                <div class="row-fluid"> <h5>File Format</h5>
                <div class="span3">
                    <h5>PDF:</h5>
                    <input calib = "no" type="radio"  min ="minlog" id="pdfReport" checked="checked" name="radio" value="1" >
                </div>
                <div class="span3">
                    <h5>EXCEL:</h5>
                    <input calib = "no" type="radio"  min ="minlog" id="xlsReport" name="radio" value="1" >
                </div>
                <div class="span3">
                    <h5>CSV:</h5>
                    <input calib = "no" type="radio"  min ="minlog" id="csvReport" name="radio" value="1" >
                </div>
                <div class="row-fluid"> <h5></h5>
                    <div class="span3">
                        </div>
                </div>

            </div>
                
            <div class="row-fluid"><div class='btn-primary'><b class='btn-primary btn-icon glyphicons ok'><button  id="refreshReport" class="btn btn-primary" style="margin-top:-0px;">Create Report</button><i></i></b></div></div>
                <div class="row-fluid"> <h5></h5>
                    <div class="span3">
                        </div>
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
        <script type="text/javascript" src="Centurio/centurioMain.js?v=1.60"></script>
        <asp:Literal ID="javaScriptLiteral" runat="server"></asp:Literal>    

    	<script src="theme/scripts/plugins/notifications/Gritter/js/jquery.gritter.min.js"></script>
	
	<!-- Notyfy Notifications Plugin -->
	<script src="theme/scripts/plugins/notifications/notyfy/jquery.notyfy.js"></script>

</asp:Content>

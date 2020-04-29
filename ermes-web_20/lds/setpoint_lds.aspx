<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="setpoint_lds.aspx.vb" Inherits="ermes_web_20.setpoint_lds" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>

<form id="form" runat="server"  method="post" action="lds/setpoint_lds.aspx">
    <h3><asp:literal runat="server" text ="SetPoint LDS" ID="message_channel" meta:resourcekey="message_channelResource1"></asp:literal></h3>
    <div class="innerLR">
        <div class="box-generic">
                        	<!-- Tabs Heading -->
<div class="tabsbar tabsbar-2">
			<ul class="row-fluid row-merge">
            
                <li class="span2 active" ><a id="tab_ld_sp1" href="#tab_ld_sp1_1"  data-toggle="tab"><asp:literal text="Cl pulse"  runat="server" ID="tabld1_1" meta:resourcekey="tabld1_1Resource1" ></asp:literal></a></li>
                <li class="span2"><a id="tab_ld_sp2" href="#tab_ld_sp2_2" data-toggle="tab"><asp:literal text="Cl Relay" runat="server" ID="tabld1_2" meta:resourcekey="tabld1_2Resource1"></asp:literal></a></li>
			</ul>
		</div>
		<!-- // Tabs Heading END -->
<div class="tab-content">
 
  
  
<!-- tab 1 start-->
			<div class="tab-pane active" id="tab_ld_sp1_1">
                <div  class="box-generic">
                                 <!-- riga -->
                <div class="row-fluid">
               	<div class="span12">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal10"  text="Cl Pulse 1" runat="server" meta:resourcekey="Literal10Resource1"></asp:literal></h5>
<div class="controlli_box">
                    <asp:radiobutton ID="on_off_cl_pulse1"  runat="server"  GroupName="GROUP1" meta:resourcekey="on_off_cl_pulse1Resource1"></asp:radiobutton>
</div>
<div class="controlli_testo_box">
                    <asp:literal runat="server" text ="On / Off" meta:resourcekey="LiteralResource1"></asp:literal>
</div>
<div class="controlli_box">
                    <asp:radiobutton ID="proportional_cl_pulse1"  runat="server"  GroupName="GROUP1" meta:resourcekey="proportional_cl_pulse1Resource1"></asp:radiobutton>
</div>
<div class="controlli_testo_box">
                       <asp:literal runat="server" text ="Proportional" meta:resourcekey="LiteralResource2"></asp:literal>
</div>
<div class="controlli_box">
                    <asp:radiobutton ID="off_cl_pulse1"  runat="server"  GroupName="GROUP1" meta:resourcekey="off_cl_pulse1Resource2"></asp:radiobutton>
</div>
<div class="controlli_testo_box">
                       <asp:literal runat="server" text ="Off" meta:resourcekey="LiteralResource3"></asp:literal>
</div>
                </div>
                </div>
                 <!-- fine riga -->
                                <!-- riga -->
<div id ="disable_cl_pulse1">
                <div class="row-fluid">
               	<div class="span2">
                       <div id="riga1_cl_pulse1_1" class="control-group">
                           <div id="label1_cl_pulse1_proportional">
                                <h5 style="padding-top:10px"><asp:literal ID = "Literal29"  text="Cl" runat="server" meta:resourcekey="Literal29Resource1"></asp:literal></h5>
                           </div>
                           <div id="label1_cl_pulse1_on_off">
                                <h5 style="padding-top:10px"><asp:literal ID = "Literal30"  text="Cl ON" runat="server" meta:resourcekey="Literal30Resource1"></asp:literal></h5>
                           </div>
                       <asp:textbox ID="value1_cl_pulse1_1"  onblur="javascript: Changed_channel( 'value1_cl_pulse1_1','riga1_cl_pulse1_1',max_ch2_value, min_ch2_value,max_fix_value2 );" class="span12"  runat="server" meta:resourcekey="value1_cl_pulse1_1Resource1" ></asp:textbox>
                </div>
                       </div>

                    <div class="span2">
                       <div id="riga2_cl_pulse1_1" class="control-group">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal31"  text="Pulse / Minute" runat="server" meta:resourcekey="Literal31Resource1"></asp:literal></h5>
                       <asp:textbox ID="value2_cl_pulse1_1" onblur="javascript: Changed_channel( 'value2_cl_pulse1_1','riga2_cl_pulse1_1',180, 0,0 );"  class="span12"  runat="server" MaxLength="3" meta:resourcekey="value2_cl_pulse1_1Resource1" ></asp:textbox>
                </div>
                       </div>
                </div>
                 <!-- fine riga -->
<!-- riga -->
                <div class="row-fluid">
               	<div class="span2">
                       <div id="riga1_cl_pulse1_2" class="control-group">
                           <div id="label2_cl_pulse1_proportional">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal32"  text="Cl" runat="server" meta:resourcekey="Literal32Resource1"></asp:literal></h5>
                               </div>
                           <div id="label2_cl_pulse1_on_off">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal33"  text="Cl OFF" runat="server" meta:resourcekey="Literal33Resource1"></asp:literal></h5>
                               </div>

                       <asp:textbox ID="value1_cl_pulse1_2" onblur="javascript: Changed_channel( 'value1_cl_pulse1_2','riga1_cl_pulse1_2',max_ch2_value, min_ch2_value,max_fix_value2 );"  class="span12"  runat="server" meta:resourcekey="value1_cl_pulse1_2Resource1" ></asp:textbox>
                </div>
                       </div>

                    <div class="span2">
                       <div id="riga2_cl_pulse1_2" class="control-group">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal34"  text="Pulse / Minute" runat="server" meta:resourcekey="Literal34Resource1"></asp:literal></h5>
                       <asp:textbox ID="value2_cl_pulse1_2" onblur="javascript: Changed_channel( 'value2_cl_pulse1_2','riga2_cl_pulse1_2',180, 0,0 );" class="span12"  runat="server" MaxLength="3" meta:resourcekey="value2_cl_pulse1_2Resource1" ></asp:textbox>
                </div>
                       </div>
                </div>
                 <!-- fine riga -->                                
<!-- riga -->
                <div class="row-fluid">
               	<div class="span2">
                       <div id="riga1_cl_pulse1_3" class="control-group">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal35"  text="Pulse Speed (min)" runat="server" meta:resourcekey="Literal35Resource1"></asp:literal></h5>
                       <asp:textbox ID="value2_cl_pulse1_3" onblur="javascript: Changed_channel( 'value2_cl_pulse1_3','riga1_cl_pulse1_3',99, 0,0 );"  class="span12"  runat="server" MaxLength="2" meta:resourcekey="value2_cl_pulse1_3Resource1" ></asp:textbox>
                </div>
                       </div>
                </div>
                 <!-- fine riga -->  
    </div>
                    </div>
                </div>
<!-- tab 1 stop-->
           <!-- tab 2 start-->
			<div class="tab-pane" id="tab_ld_sp2_2">
                <div  class="box-generic">
                                 <!-- riga -->
                <div class="row-fluid">
               	<div class="span12">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal11"  text="cL Relay" runat="server" meta:resourcekey="Literal11Resource1"></asp:literal></h5>
<div class="controlli_box">
                    <asp:radiobutton ID="on_off_cl_relay"  runat="server"  GroupName="GROUP2" meta:resourcekey="on_off_cl_relayResource1"></asp:radiobutton>
</div>
<div class="controlli_testo_box">
                    <asp:literal runat="server" text ="On / Off" meta:resourcekey="LiteralResource4"></asp:literal>
</div>
<div class="controlli_box">
                    <asp:radiobutton ID="proportional_cl_relay"  runat="server"  GroupName="GROUP2" meta:resourcekey="proportional_cl_relayResource1"></asp:radiobutton>
</div>
<div class="controlli_testo_box">
                       <asp:literal runat="server" text ="Proportional PWM" meta:resourcekey="LiteralResource5"></asp:literal>
</div>
<div class="controlli_box">
                    <asp:radiobutton ID="fixed_cl_relay"  runat="server"  GroupName="GROUP2" meta:resourcekey="fixed_cl_relayResource1"></asp:radiobutton>
</div>
<div class="controlli_testo_box">
                       <asp:literal runat="server" text ="Fixed PWM" meta:resourcekey="LiteralResource6"></asp:literal>
</div>
<div class="controlli_box">
					   <asp:radiobutton ID="off_cl_relay"  runat="server"  GroupName="GROUP2" meta:resourcekey="off_cl_relayResource2"></asp:radiobutton>
</div>
<div class="controlli_testo_box">
					<asp:literal runat="server" text ="Off" meta:resourcekey="LiteralResource7"></asp:literal>
</div>
                </div>
                </div>
                 <!-- fine riga -->
                                <!-- riga -->
<div id ="disable_cl_relay">
                <div class="row-fluid">
               	<div class="span2">
                       <div id="riga1_cl_relay_1" class="control-group">
                           <div id="label1_cl_relay_else">
                                <h5 style="padding-top:10px"><asp:literal ID = "Literal38"  text="cL" runat="server" meta:resourcekey="Literal38Resource1"></asp:literal></h5>
                           </div>
                           <div id="label1_cl_relay_on_off">
                                <h5 style="padding-top:10px"><asp:literal ID = "Literal39"  text="cL ON" runat="server" meta:resourcekey="Literal39Resource1"></asp:literal></h5>
                           </div>
                       <asp:textbox ID="value1_cl_relay_1" onblur="javascript: Changed_channel( 'value1_cl_relay_1','riga1_cl_relay_1',max_ch2_value, min_ch2_value,max_fix_value2 );"  class="span12"  runat="server" meta:resourcekey="value1_cl_relay_1Resource1" ></asp:textbox>
                </div>
                       </div>

                    <div class="span2">
                       <div id="riga2_cl_relay_1" class="control-group">
					   <div id="label1_cl_relay_proportionalpwm">
							<h5 style="padding-top:10px"><asp:literal ID = "Literal40"  text="%" runat="server" meta:resourcekey="Literal40Resource1"></asp:literal></h5>
						</div>
					   <div id="label1_cl_relay_fixedpwm">
							<h5 style="padding-top:10px"><asp:literal ID = "Literal41"  text="sec" runat="server" meta:resourcekey="Literal41Resource1"></asp:literal></h5>
						</div>

						<asp:textbox ID="value2_cl_relay_1" onblur="javascript: Changed_channel( 'value2_cl_relay_1','riga2_cl_relay_1',100, 0,0 );"  class="span12"  runat="server" MaxLength="3" meta:resourcekey="value2_cl_relay_1Resource1" ></asp:textbox>
                </div>
                       </div>
                </div>
                 <!-- fine riga -->
<!-- riga -->
                <div class="row-fluid">
               	<div class="span2">
                       <div id="riga1_cl_relay_2" class="control-group">
                           <div id="label2_cl_relay_else">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal42"  text="cL" runat="server" meta:resourcekey="Literal42Resource1"></asp:literal></h5>
                               </div>
                           <div id="label2_cl_relay_on_off">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal43"  text="cL OFF" runat="server" meta:resourcekey="Literal43Resource1"></asp:literal></h5>
                               </div>

                       <asp:textbox ID="value1_cl_relay_2" onblur="javascript: Changed_channel( 'value1_cl_relay_2','riga1_cl_relay_2',max_ch2_value, min_ch2_value,max_fix_value2 );" class="span12"  runat="server" meta:resourcekey="value1_cl_relay_2Resource1" ></asp:textbox>
                </div>
                       </div>

                    <div class="span2">
                       <div id="riga2_cl_relay_2" class="control-group">
					   <div id="label2_cl_relay_proportionalpwm">
								<h5 style="padding-top:10px"><asp:literal ID = "Literal44"  text="%" runat="server" meta:resourcekey="Literal44Resource1"></asp:literal></h5>
						</div>		
					   <div id="label2_cl_relay_fixedpwm">
								<h5 style="padding-top:10px"><asp:literal ID = "Literal45"  text="sec" runat="server" meta:resourcekey="Literal45Resource1"></asp:literal></h5>
						</div>		

						<asp:textbox ID="value2_cl_relay_2" onblur="javascript: Changed_channel( 'value2_cl_relay_2','riga2_cl_relay_2',100, 0,0 );" class="span12"  runat="server" MaxLength="3" meta:resourcekey="value2_cl_relay_2Resource1" ></asp:textbox>
                </div>
                       </div>
                </div>
                 <!-- fine riga -->                                
    </div>
                    </div>
                </div>
<!-- tab 2 stop-->
    </div>
                                   <div id="salva" class="btn-primary">
                   <b class="btn-primary btn-icon glyphicons ok"><asp:button runat="server" ID="save_setpointlds_new" class="btn-primary" data-layout="center" data-type="confirm" data-toggle="notyfy" text="Salva e carica i dati" Font-Bold="True" meta:resourcekey="save_setpointlds_newResource1" /><i></i></b>

            </div>
        </div>
        </div>
<script type="text/javascript" src="lds/validator_lds_setpoint.js"></script>
    <script type="text/javascript" src="common/validator_general_notify.js"></script>
<script src="theme/scripts/demo/notifications.js"></script>
</form>  

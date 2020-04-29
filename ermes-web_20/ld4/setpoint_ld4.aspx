<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="setpoint_ld4.aspx.vb" Inherits="ermes_web_20.setpoint_ld4" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>

<form id="form" runat="server"  method="post" action="ld4/setpoint_ld4.aspx">
    <h3><asp:literal runat="server" text ="SetPoint LD" ID="message_channel" meta:resourcekey="message_channelResource1"></asp:literal></h3>
    <div class="innerLR">
        <div class="box-generic">
                        	<!-- Tabs Heading -->
<div class="tabsbar tabsbar-2">
			<ul class="row-fluid row-merge">
            
               <!-- <li class="span2 active" ><a id="tab_ld_sp1" href="#tab_ld_sp1_1"  data-toggle="tab"><asp:literal text="pH Pulse1"  runat="server" ID="tabld1_1" meta:resourcekey="tabld1_1Resource1" ></asp:literal></a></li>
                <li class="span2"><a id="tab_ld_sp2" href="#tab_ld_sp2_2" data-toggle="tab"><asp:literal text="pH Pulse2" runat="server" ID="tabld1_2" meta:resourcekey="tabld1_2Resource1"></asp:literal></a></li>-->
                <li class="span2"><a id="tab_ld_sp3" href="#tab_ld_sp3_3" data-toggle="tab"><asp:literal text="pH Relay" runat="server" ID="tabld1_3" meta:resourcekey="tabld1_3Resource1"></asp:literal></a></li>
                <!-- <li class="span2"><a id="tab_ld_sp4" href="#tab_ld_sp4_4" data-toggle="tab"><asp:literal text="Cl pulse" runat="server" ID="tabld1_4" meta:resourcekey="tabld1_4Resource1"></asp:literal></a></li>-->
                <li class="span2"><a id="tab_ld_sp5" href="#tab_ld_sp5_5" data-toggle="tab"><asp:literal text="Cl Relay" runat="server" ID="tabld1_5" meta:resourcekey="tabld1_5Resource1"></asp:literal></a></li>
			</ul>
		</div>
		<!-- // Tabs Heading END -->
<div class="tab-content">
    
    
        <!-- tab 3 start-->
			<div class="tab-pane" id="tab_ld_sp3_3">
                <div  class="box-generic">
                                 <!-- riga -->
                <div class="row-fluid">
               	<div class="span12">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal9"  text="pH Relay" runat="server" meta:resourcekey="Literal9Resource1"></asp:literal></h5>
                       <div class="controlli_box"> 
                    <asp:radiobutton ID="on_off_ph_relay"  runat="server"  GroupName="GROUP5" meta:resourcekey="on_off_ph_relayResource1"></asp:radiobutton>
                       </div>
                       <div class="controlli_testo_box"> 
                    <asp:literal runat="server" text ="On / Off" meta:resourcekey="LiteralResource7"></asp:literal>
                           </div>
                           <div class="controlli_box"> 
                    <asp:radiobutton ID="proportional_ph_relay"  runat="server"  GroupName="GROUP5" meta:resourcekey="proportional_ph_relayResource1"></asp:radiobutton>
                               </div>
                           <div class="controlli_testo_box"> 
                       <asp:literal runat="server" text ="Proportional PWM" meta:resourcekey="LiteralResource8"></asp:literal>
                               </div>
                               <div class="controlli_box"> 
                    <asp:radiobutton ID="fixed_ph_relay"  runat="server"  GroupName="GROUP5" meta:resourcekey="fixed_ph_relayResource1"></asp:radiobutton>
                                   </div>
                               <div class="controlli_testo_box"> 
                       <asp:literal runat="server" text ="Fixed PWM" meta:resourcekey="LiteralResource9"></asp:literal>
                                   </div>
                                   <div class="controlli_box"> 
					   <asp:radiobutton ID="off_ph_relay"  runat="server"  GroupName="GROUP5" meta:resourcekey="off_ph_relayResource2"></asp:radiobutton>
                                       </div>
                                   <div class="controlli_testo_box"> 
					<asp:literal runat="server" text ="Off" meta:resourcekey="LiteralResource10"></asp:literal>
                                       </div>
                </div>
                </div>
                 <!-- fine riga -->
                                <!-- riga -->
<div id ="disable_ph_relay">
                <div class="row-fluid">
               	<div class="span2">
                       <div id="riga1_ph_relay_1" class="control-group">
                           <div id="label1_ph_relay_else">
                                <h5 style="padding-top:10px"><asp:literal ID = "Literal21"  text="pH" runat="server" meta:resourcekey="Literal21Resource1"></asp:literal></h5>
                           </div>
                           <div id="label1_ph_relay_on_off">
                                <h5 style="padding-top:10px"><asp:literal ID = "Literal22"  text="pH ON" runat="server" meta:resourcekey="Literal22Resource1"></asp:literal></h5>
                           </div>
                       <asp:textbox ID="value1_ph_relay_1" onblur="javascript: Changed_channel( 'value1_ph_relay_1','riga1_ph_relay_1',max_ch1_value, min_ch1_value,max_fix_value1 );"   class="span12"  runat="server" meta:resourcekey="value1_ph_relay_1Resource1" ></asp:textbox>
                </div>
                       </div>

                    <div class="span2">
                       <div id="riga2_ph_relay_1" class="control-group">
					   <div id="label1_ph_relay_proportionalpwm">
							<h5 style="padding-top:10px"><asp:literal ID = "Literal23"  text="%" runat="server" meta:resourcekey="Literal23Resource1"></asp:literal></h5>
						</div>
					   <div id="label1_ph_relay_fixedpwm">
							<h5 style="padding-top:10px"><asp:literal ID = "Literal24"  text="sec" runat="server" meta:resourcekey="Literal24Resource1"></asp:literal></h5>
						</div>

						<asp:textbox ID="value2_ph_relay_1" onblur="javascript: Changed_channel( 'value2_ph_relay_1','riga2_ph_relay_1',100, 0,0 );"  class="span12"  runat="server" MaxLength="3" meta:resourcekey="value2_ph_relay_1Resource1" ></asp:textbox>
                </div>
                       </div>
                </div>
                 <!-- fine riga -->
<!-- riga -->
                <div class="row-fluid">
               	<div class="span2">
                       <div id="riga1_ph_relay_2" class="control-group">
                           <div id="label2_ph_relay_else">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal25"  text="pH" runat="server" meta:resourcekey="Literal25Resource1"></asp:literal></h5>
                               </div>
                           <div id="label2_ph_relay_on_off">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal26"  text="pH OFF" runat="server" meta:resourcekey="Literal26Resource1"></asp:literal></h5>
                               </div>

                       <asp:textbox ID="value1_ph_relay_2" onblur="javascript: Changed_channel( 'value1_ph_relay_2','riga1_ph_relay_2',max_ch1_value, min_ch1_value,max_fix_value1 );" class="span12"  runat="server" meta:resourcekey="value1_ph_relay_2Resource1" ></asp:textbox>
                </div>
                       </div>

                    <div class="span2">
                       <div id="riga2_ph_relay_2" class="control-group">
					   <div id="label2_ph_relay_proportionalpwm">
								<h5 style="padding-top:10px"><asp:literal ID = "Literal27"  text="%" runat="server" meta:resourcekey="Literal27Resource1"></asp:literal></h5>
						</div>		
					   <div id="label2_ph_relay_fixedpwm">
								<h5 style="padding-top:10px"><asp:literal ID = "Literal28"  text="sec" runat="server" meta:resourcekey="Literal28Resource1"></asp:literal></h5>
						</div>		

						<asp:textbox ID="value2_ph_relay_2"  onblur="javascript: Changed_channel( 'value2_ph_relay_2','riga2_ph_relay_2',100, 0,0 );" class="span12"  runat="server" MaxLength="3" meta:resourcekey="value2_ph_relay_2Resource1" ></asp:textbox>
                </div>
                       </div>
                </div>
                 <!-- fine riga -->                                
    </div>
                    </div>
                </div>
<!-- tab 3 stop-->

           <!-- tab 5 start-->
			<div class="tab-pane" id="tab_ld_sp5_5">
                <div  class="box-generic">
                                 <!-- riga -->
                <div class="row-fluid">
               	<div class="span12">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal11"  text="cL Relay" runat="server" meta:resourcekey="Literal11Resource1"></asp:literal></h5>
                       <div class="controlli_box"> 
                    <asp:radiobutton ID="on_off_cl_relay"  runat="server"  GroupName="GROUP7" meta:resourcekey="on_off_cl_relayResource1"></asp:radiobutton>
                           </div>
                       <div class="controlli_testo_box"> 
                    <asp:literal runat="server" text ="On / Off" meta:resourcekey="LiteralResource14"></asp:literal>
                           </div>
                           <div class="controlli_box"> 
                    <asp:radiobutton ID="proportional_cl_relay"  runat="server"  GroupName="GROUP7" meta:resourcekey="proportional_cl_relayResource1"></asp:radiobutton>
                               </div>
                           <div class="controlli_testo_box"> 
                       <asp:literal runat="server" text ="Proportional PWM" meta:resourcekey="LiteralResource15"></asp:literal>
                               </div>
                               <div class="controlli_box"> 
                    <asp:radiobutton ID="fixed_cl_relay"  runat="server"  GroupName="GROUP7" meta:resourcekey="fixed_cl_relayResource1"></asp:radiobutton>
                                   </div>
                               <div class="controlli_testo_box"> 
                       <asp:literal runat="server" text ="Fixed PWM" meta:resourcekey="LiteralResource16"></asp:literal>
                                   </div>
                                   <div class="controlli_box"> 
					   <asp:radiobutton ID="off_cl_relay"  runat="server"  GroupName="GROUP7" meta:resourcekey="off_cl_relayResource2"></asp:radiobutton>
                                       </div>
                                   <div class="controlli_testo_box"> 
					<asp:literal runat="server" text ="Off" meta:resourcekey="LiteralResource17"></asp:literal>
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
<!-- tab 5 stop-->
    </div>
                                   <div id="salva" class="btn-primary">
                   <b class="btn-primary btn-icon glyphicons ok"><asp:button runat="server" ID="save_setpointld4_new" class="btn-primary" data-layout="center" data-type="confirm" data-toggle="notyfy"  text="Salva e carica i dati" Font-Bold="True" meta:resourcekey="save_setpointld4_newResource1" /><i></i></b>

            </div>
        </div>
        </div>
<script type="text/javascript" src="ld4/validator_ld4_setpoint.js"></script>
<script type="text/javascript" src="common/validator_general_notify.js"></script>
<script src="theme/scripts/demo/notifications.js"></script>

</form>

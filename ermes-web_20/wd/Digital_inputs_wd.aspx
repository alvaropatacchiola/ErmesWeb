<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Digital_inputs_wd.aspx.vb" Inherits="ermes_web_20.WebForm6" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>

<form id="form" runat="server" method="post" action="wd/Digital_inputs_wd.aspx">
    <h3><asp:literal runat="server" text ="Digital Inputs" ID="message_channel" meta:resourcekey="message_channelResource1"></asp:literal></h3>
    <div class="innerLR">
        <div class="box-generic">
                        	<!-- Tabs Heading -->
<div class="tabsbar tabsbar-2">
			<ul class="row-fluid row-merge">
            
                <li class="span2 active" ><a id="tab_ld_sp1" href="#tab_ld_sp1_1"  data-toggle="tab"><asp:literal text="Level pH"  runat="server" ID="tabld1_1" meta:resourcekey="tabld1_1Resource1" ></asp:literal></a></li>
                <li class="span2"><a id="tab_ld_sp2" href="#tab_ld_sp2_2" data-toggle="tab"><asp:literal text="Level mV" runat="server" ID="tabld1_2" meta:resourcekey="tabld1_2Resource1"></asp:literal></a></li>
                <li class="span2"><a id="tab_ld_sp3" href="#tab_ld_sp3_3" data-toggle="tab"><asp:literal text="Stand-By" runat="server" ID="tabld1_3" meta:resourcekey="tabld1_3Resource1"></asp:literal></a></li>
               
			</ul>
		</div>
		<!-- // Tabs Heading END -->
<div class="tab-content">
    <!-- tab 1 start-->
			<div class="tab-pane active" id="tab_ld_sp1_1">
                <div  class="box-generic">
                                 <!-- riga -->
                <div class="row-fluid">
               	<div class="span3">
              <h5 style="padding-top:10px"><asp:literal ID = "Label7"  text="Level pH" runat="server" meta:resourcekey="Label7Resource1"></asp:literal></h5>
                    <asp:radiobutton ID="NO_ph" style="margin: 5px 10px 10px 0px;" runat="server"  GroupName="GROUP1" meta:resourcekey="NO_phResource1"></asp:radiobutton>
                    <asp:literal runat="server" text ="N.O." ID="literal1" meta:resourcekey="literal1Resource1"></asp:literal>
                    <asp:radiobutton ID="NC_ph" style="margin: 5px 10px 10px 0px;" runat="server"  GroupName="GROUP1" meta:resourcekey="NC_phResource1"></asp:radiobutton>
                       <asp:literal runat="server" text ="N.C." ID="literal2" meta:resourcekey="literal2Resource1"></asp:literal>

                </div>
                </div>
                 <!-- fine riga -->
                                <!-- riga -->
<div id ="disable_ph_pulse1">
                <div class="row-fluid">
               	<div class="span2">
                       <div id="riga1_ph_pulse1_1" class="control-group">
                           <div id="label1_ph_pulse1_proportional">
                                <h5 style="padding-top:10px"><asp:literal ID = "Literal4"  text=" " runat="server" meta:resourcekey="Literal4Resource1"></asp:literal></h5>
                           </div>
                           <div id="label1_ph_pulse1_on_off">
                                <h5 style="padding-top:10px"><asp:literal ID = "Literal6"  text=" " runat="server" meta:resourcekey="Literal6Resource1"></asp:literal></h5>
                           </div>
                </div>
                       </div>

                    <div class="span2">
                       <div id="riga2_ph_pulse1_1" class="control-group">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal5"  text=" " runat="server" meta:resourcekey="Literal5Resource1"></asp:literal></h5>
                </div>
                       </div>
                </div>
                 <!-- fine riga -->
<!-- riga -->
                <div class="row-fluid">
               	<div class="span2">
                       <div id="riga1_ph_pulse1_2" class="control-group">
                           <div id="label2_ph_pulse1_proportional">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal7"  text=" " runat="server" meta:resourcekey="Literal7Resource1"></asp:literal></h5>
                               </div>
                           <div id="label2_ph_pulse1_on_off">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal8"  text=" " runat="server" meta:resourcekey="Literal8Resource1"></asp:literal></h5>
                               </div>

                </div>
                       </div>

                    <div class="span2">
                       <div id="riga2_ph_pulse1_2" class="control-group">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal9"  text=" " runat="server" meta:resourcekey="Literal9Resource1"></asp:literal></h5>
                </div>
                       </div>
                </div>
                 <!-- fine riga -->                                
<!-- riga -->
                <div class="row-fluid">
               	<div class="span2">
                       <div id="riga1_ph_pulse1_3" class="control-group">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal10"  text=" " runat="server" meta:resourcekey="Literal10Resource1"></asp:literal></h5>
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
               	<div class="span3">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal11"  text="Level mV" runat="server" meta:resourcekey="Literal11Resource1"></asp:literal></h5>
                    <asp:radiobutton ID="NO_cl" style="margin: 5px 10px 10px 0px;" runat="server"  GroupName="GROUP2" meta:resourcekey="NO_clResource1"></asp:radiobutton>
                    <asp:literal runat="server" text ="N.O." ID="literal12" meta:resourcekey="literal12Resource1"></asp:literal>
                    <asp:radiobutton ID="NC_cl" style="margin: 5px 10px 10px 0px;" runat="server"  GroupName="GROUP2" meta:resourcekey="NC_clResource1"></asp:radiobutton>
                       <asp:literal runat="server" text ="N.C." ID="literal13" meta:resourcekey="literal13Resource1"></asp:literal>

                </div>
                </div>
                 <!-- fine riga -->
                                <!-- riga -->
<div id ="disable_ph_pulse2">
                <div class="row-fluid">
               	<div class="span2">
                       <div id="riga1_ph_pulse2_1" class="control-group">
                           <div id="label1_ph_pulse2_proportional">
                                <h5 style="padding-top:10px"><asp:literal ID = "Literal15"  text=" " runat="server" meta:resourcekey="Literal15Resource1"></asp:literal></h5>
                           </div>
                           <div id="label1_ph_pulse2_on_off">
                                <h5 style="padding-top:10px"><asp:literal ID = "Literal16"  text=" " runat="server" meta:resourcekey="Literal16Resource1"></asp:literal></h5>
                           </div>
                </div>
                       </div>

                    <div class="span2">
                       <div id="riga2_ph_pulse2_1" class="control-group">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal17"  text=" " runat="server" meta:resourcekey="Literal17Resource1"></asp:literal></h5>
                </div>
                       </div>
                </div>
                 <!-- fine riga -->
<!-- riga -->
                <div class="row-fluid">
               	<div class="span2">
                       <div id="riga1_ph_pulse2_2" class="control-group">
                           <div id="label2_ph_pulse2_proportional">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal18"  text=" " runat="server" meta:resourcekey="Literal18Resource1"></asp:literal></h5>
                               </div>
                           <div id="label2_ph_pulse2_on_off">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal19"  text=" " runat="server" meta:resourcekey="Literal19Resource1"></asp:literal></h5>
                               </div>

                </div>
                       </div>

                    <div class="span2">
                       <div id="riga2_ph_pulse2_2" class="control-group">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal20"  text=" " runat="server" meta:resourcekey="Literal20Resource1"></asp:literal></h5>
                </div>
                       </div>
                </div>
                 <!-- fine riga -->                                
<!-- riga -->
                <div class="row-fluid">
               	<div class="span2">
                       <div id="riga1_ph_pulse2_3" class="control-group">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal21"  text=" " runat="server" meta:resourcekey="Literal21Resource1"></asp:literal></h5>
                </div>
                       </div>
                </div>
                 <!-- fine riga -->  
    </div>
                    </div>
                </div>
<!-- tab 2 stop-->
        <!-- tab 3 start-->
			<div class="tab-pane" id="tab_ld_sp3_3">
                <div  class="box-generic">
                                 <!-- riga -->
                <div class="row-fluid">
               	<div class="span5">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal22"  text="Stand-By" runat="server" meta:resourcekey="Literal22Resource1"></asp:literal></h5>
                    <asp:radiobutton ID="NO_STBY" style="margin: 5px 10px 10px 0px;" runat="server"  GroupName="GROUP5" meta:resourcekey="NO_STBYResource1"></asp:radiobutton>
                    <asp:literal runat="server" text ="N.O." ID="literal23" meta:resourcekey="literal23Resource1"></asp:literal>
                    <asp:radiobutton ID="NC_STBY" style="margin: 5px 10px 10px 0px;" runat="server"  GroupName="GROUP5" meta:resourcekey="NC_STBYResource1"></asp:radiobutton>
                       <asp:literal runat="server" text ="N.C." ID="literal24" meta:resourcekey="literal24Resource1"></asp:literal>

                </div>
                </div>
                 <!-- fine riga -->
                                <!-- riga -->
<div id ="disable_ph_relay">
                <div class="row-fluid">
               	<div class="span2">
                       <div id="riga1_ph_relay_1" class="control-group">
                           <div id="label1_ph_relay_else">
                                <h5 style="padding-top:10px"><asp:literal ID = "Literal27"  text=" " runat="server" meta:resourcekey="Literal27Resource1"></asp:literal></h5>
                           </div>
                           <div id="label1_ph_relay_on_off">
                                <h5 style="padding-top:10px"><asp:literal ID = "Literal28"  text=" " runat="server" meta:resourcekey="Literal28Resource1"></asp:literal></h5>
                           </div>
                </div>
                       </div>

                    <div class="span2">
                       <div id="riga2_ph_relay_1" class="control-group">
					   <div id="label1_ph_relay_proportionalpwm">
							<h5 style="padding-top:10px"><asp:literal ID = "Literal29"  text=" " runat="server" meta:resourcekey="Literal29Resource1"></asp:literal></h5>
						</div>
					   <div id="label1_ph_relay_fixedpwm">
							<h5 style="padding-top:10px"><asp:literal ID = "Literal30"  text=" " runat="server" meta:resourcekey="Literal30Resource1"></asp:literal></h5>
						</div>

                </div>
                       </div>
                </div>
                 <!-- fine riga -->
<!-- riga -->
                <div class="row-fluid">
               	<div class="span2">
                       <div id="riga1_ph_relay_2" class="control-group">
                           <div id="label2_ph_relay_else">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal31"  text=" " runat="server" meta:resourcekey="Literal31Resource1"></asp:literal></h5>
                               </div>
                           <div id="label2_ph_relay_on_off">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal32"  text=" " runat="server" meta:resourcekey="Literal32Resource1"></asp:literal></h5>
                               </div>

                </div>
                       </div>

                    <div class="span2">
                       <div id="riga2_ph_relay_2" class="control-group">
					   <div id="label2_ph_relay_proportionalpwm">
								<h5 style="padding-top:10px"><asp:literal ID = "Literal33"  text=" " runat="server" meta:resourcekey="Literal33Resource1"></asp:literal></h5>
						</div>		
					   <div id="label2_ph_relay_fixedpwm">
								<h5 style="padding-top:10px"><asp:literal ID = "Literal34"  text=" " runat="server" meta:resourcekey="Literal34Resource1"></asp:literal></h5>
						</div>		

                </div>
                       </div>
                </div>
                 <!-- fine riga -->                                
    </div>
                    </div>
                </div>
<!-- tab 3 stop-->
<!-- tab 4 start-->
			<div class="tab-pane" id="tab_ld_sp4_4">
                <div  class="box-generic">
                                 <!-- riga -->
                <div class="row-fluid">
               	<div class="span3">
              <h5 style="padding-top:10px">&nbsp;</h5>

                </div>
                </div>
                 <!-- fine riga -->
                                <!-- riga -->
<div id ="disable_cl_pulse1">
                <div class="row-fluid">
               	<div class="span2">
                       <div id="riga1_cl_pulse1_1" class="control-group">
                           <div id="label1_cl_pulse1_proportional">
                                <h5 style="padding-top:10px">&nbsp;</h5>
                           </div>
                           <div id="label1_cl_pulse1_on_off">
                                <h5 style="padding-top:10px">&nbsp;</h5>
                           </div>
                </div>
                       </div>

                    <div class="span2">
                       <div id="riga2_cl_pulse1_1" class="control-group">
              <h5 style="padding-top:10px">&nbsp;</h5>
                </div>
                       </div>
                </div>
                 <!-- fine riga -->
<!-- riga -->
                <div class="row-fluid">
               	<div class="span2">
                       <div id="riga1_cl_pulse1_2" class="control-group">
                           <div id="label2_cl_pulse1_proportional">
              <h5 style="padding-top:10px">&nbsp;</h5>
                               </div>
                           <div id="label2_cl_pulse1_on_off">
              <h5 style="padding-top:10px">&nbsp;</h5>
                               </div>

                </div>
                       </div>

                    <div class="span2">
                       <div id="riga2_cl_pulse1_2" class="control-group">
              <h5 style="padding-top:10px">&nbsp;</h5>
                </div>
                       </div>
                </div>
                 <!-- fine riga -->                                
<!-- riga -->
                <div class="row-fluid">
               	<div class="span2">
                       <div id="riga1_cl_pulse1_3" class="control-group">
              <h5 style="padding-top:10px">&nbsp;</h5>
                </div>
                       </div>
                </div>
                 <!-- fine riga -->  
    </div>
                    </div>
                </div>
<!-- tab 4 stop-->
           <!-- tab 5 start-->
			<div class="tab-pane" id="tab_ld_sp5_5">
                <div  class="box-generic">
                                 <!-- riga -->
                <div class="row-fluid">
               	<div class="span5">
              <h5 style="padding-top:10px">&nbsp;</h5>

                </div>
                </div>
                 <!-- fine riga -->
                                <!-- riga -->
<div id ="disable_cl_relay">
                <div class="row-fluid">
               	<div class="span2">
                       <div id="riga1_cl_relay_1" class="control-group">
                           <div id="label1_cl_relay_else">
                                <h5 style="padding-top:10px">&nbsp;</h5>
                           </div>
                           <div id="label1_cl_relay_on_off">
                                <h5 style="padding-top:10px">&nbsp;</h5>
                           </div>
                </div>
                       </div>

                    <div class="span2">
                       <div id="riga2_cl_relay_1" class="control-group">
					   <div id="label1_cl_relay_proportionalpwm">
							<h5 style="padding-top:10px">&nbsp;</h5>
						</div>
					   <div id="label1_cl_relay_fixedpwm">
							<h5 style="padding-top:10px">&nbsp;</h5>
						</div>

                </div>
                       </div>
                </div>
                 <!-- fine riga -->
<!-- riga -->
                <div class="row-fluid">
               	<div class="span2">
                       <div id="riga1_cl_relay_2" class="control-group">
                           <div id="label2_cl_relay_else">
              <h5 style="padding-top:10px">&nbsp;</h5>
                               </div>
                           <div id="label2_cl_relay_on_off">
              <h5 style="padding-top:10px">&nbsp;</h5>
                               </div>

                </div>
                       </div>

                    <div class="span2">
                       <div id="riga2_cl_relay_2" class="control-group">
					   <div id="label2_cl_relay_proportionalpwm">
								<h5 style="padding-top:10px">&nbsp;</h5>
						</div>		
					   <div id="label2_cl_relay_fixedpwm">
								<h5 style="padding-top:10px">&nbsp;</h5>
						</div>		

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
                   <b class="btn-primary btn-icon glyphicons ok"><asp:button runat="server" ID="save_Digital_Input_wd_new" class="btn-primary" data-layout="center" data-type="confirm" data-toggle="notyfy" text="Salva e carica i dati" Font-Bold="True" meta:resourcekey="save_Digital_Input_wd_newResource1" /><i></i></b>

            </div>
        </div>
        </div>
<script type="text/javascript" src="wd/validator_wd_digital_inputs.js"></script>
            <script type="text/javascript" src="common/validator_general_notify.js"></script>
<script src="theme/scripts/demo/notifications.js"></script>

</form>

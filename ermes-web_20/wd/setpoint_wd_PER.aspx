<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="setpoint_wd_PER.aspx.vb" Inherits="ermes_web_20.setpoint_wd_PER" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>

<form id="form" runat="server"  method="post" action="wd/setpoint_wd_PER.aspx">
    <h3><asp:literal runat="server" text ="SetPoint WD" ID="message_channel" meta:resourcekey="message_channelResource1"></asp:literal></h3>
    <div class="innerLR">
        <div class="box-generic">
                        	<!-- Tabs Heading -->
<div class="tabsbar tabsbar-2">
			<ul class="row-fluid row-merge">
            
                <li class="span2 active" ><a id="tab_ld_sp1" href="#tab_ld_sp1_1"  data-toggle="tab"><asp:literal text="pH Pulse"  runat="server" ID="tabld1_1" meta:resourcekey="tabld1_1Resource1" ></asp:literal></a></li>
               <li class="span2"><a id="tab_ld_sp4" href="#tab_ld_sp4_4" data-toggle="tab"><asp:literal text="mV pulse" runat="server" ID="tabld1_4" meta:resourcekey="tabld1_4Resource1"></asp:literal></a></li>
                
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
              <h5 style="padding-top:10px"><asp:literal ID = "Label7"  text="pH Pulse" runat="server" meta:resourcekey="Label7Resource1"></asp:literal></h5>
                    <asp:radiobutton ID="on_off_ph_pulse1" style="margin: 5px 10px 10px 0px;" runat="server"  GroupName="GROUP1" meta:resourcekey="on_off_ph_pulse1Resource1"></asp:radiobutton>
                    <asp:literal runat="server" text ="On / Off" meta:resourcekey="LiteralResource1"></asp:literal>
                    <asp:radiobutton ID="proportional_ph_pulse1" style="margin: 5px 10px 10px 0px;" runat="server"  GroupName="GROUP1" meta:resourcekey="proportional_ph_pulse1Resource1"></asp:radiobutton>
                       <asp:literal runat="server" text ="Proportional" meta:resourcekey="LiteralResource2"></asp:literal>
                    

                </div>
                </div>
                 <!-- fine riga -->
                                <!-- riga -->
<div id ="disable_ph_pulse1">
                <div class="row-fluid">
               	<div class="span2">
                       <div id="riga1_ph_pulse1_1" class="control-group">
                           <div id="label1_ph_pulse1_proportional">
                                <h5 style="padding-top:10px"><asp:literal ID = "Literal4"  text="pH" runat="server" meta:resourcekey="Literal4Resource1"></asp:literal></h5>
                           </div>
                           <div id="label1_ph_pulse1_on_off">
                                <h5 style="padding-top:10px"><asp:literal ID = "Literal6"  text="pH ON" runat="server" meta:resourcekey="Literal6Resource1"></asp:literal></h5>
                           </div>
                       <asp:textbox ID="value1_ph_pulse1_1" onblur="javascript: Changed_channel( 'value1_ph_pulse1_1','riga1_ph_pulse1_1',max_ch1_value, min_ch1_value,max_fix_value1 );" class="span12"  runat="server" meta:resourcekey="value1_ph_pulse1_1Resource1" ></asp:textbox>
                </div>
                       </div>

                    <div class="span2">
                       <div id="riga2_ph_pulse1_1" class="control-group">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal5"  text=" %" runat="server" meta:resourcekey="Literal5Resource1"></asp:literal></h5>
                       <asp:textbox ID="value2_ph_pulse1_1" onblur="javascript: Changed_channel( 'value2_ph_pulse1_1','riga2_ph_pulse1_1',100, 0,0 );" class="span12"  runat="server" MaxLength="3" meta:resourcekey="value2_ph_pulse1_1Resource1" ></asp:textbox>
                </div>
                       </div>
                </div>
                 <!-- fine riga -->
<!-- riga -->
                <div class="row-fluid">
               	<div class="span2">
                       <div id="riga1_ph_pulse1_2" class="control-group">
                           <div id="label2_ph_pulse1_proportional">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal7"  text="pH" runat="server" meta:resourcekey="Literal7Resource1"></asp:literal></h5>
                               </div>
                           <div id="label2_ph_pulse1_on_off">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal8"  text="pH OFF" runat="server" meta:resourcekey="Literal8Resource1"></asp:literal></h5>
                               </div>

                       <asp:textbox ID="value1_ph_pulse1_2" onblur="javascript: Changed_channel( 'value1_ph_pulse1_2','riga1_ph_pulse1_2',max_ch1_value, min_ch1_value,max_fix_value1 );" class="span12"  runat="server" meta:resourcekey="value1_ph_pulse1_2Resource1" ></asp:textbox>
                </div>
                       </div>

                    <div class="span2">
                       <div id="riga2_ph_pulse1_2" class="control-group">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal9"  text=" %" runat="server" meta:resourcekey="Literal9Resource1"></asp:literal></h5>
                       <asp:textbox ID="value2_ph_pulse1_2"  onblur="javascript: Changed_channel( 'value2_ph_pulse1_2','riga2_ph_pulse1_2',100, 0,0 );" class="span12"  runat="server" MaxLength="3" meta:resourcekey="value2_ph_pulse1_2Resource1" ></asp:textbox>
                </div>
                       </div>
                </div>
                 <!-- fine riga -->                                
<!-- riga -->
                <div class="row-fluid">
               	<div class="span2">
                      
                       </div>
                </div>
                 <!-- fine riga -->  
    </div>
                    </div>
                </div>
<!-- tab 1 stop-->
   
        
<!-- tab 4 start-->
			<div class="tab-pane" id="tab_ld_sp4_4">
                <div  class="box-generic">
                                 <!-- riga -->
                <div class="row-fluid">
               	<div class="span3">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal35"  text="mV Pulse " runat="server" meta:resourcekey="Literal35Resource1"></asp:literal></h5>
                    <asp:radiobutton ID="on_off_cl_pulse1" style="margin: 5px 10px 10px 0px;" runat="server"  GroupName="GROUP6" meta:resourcekey="on_off_cl_pulse1Resource1"></asp:radiobutton>
                    <asp:literal runat="server" text ="On / Off" meta:resourcekey="LiteralResource3"></asp:literal>
                    <asp:radiobutton ID="proportional_cl_pulse1" style="margin: 5px 10px 10px 0px;" runat="server"  GroupName="GROUP6" meta:resourcekey="proportional_cl_pulse1Resource1"></asp:radiobutton>
                       <asp:literal runat="server" text ="Proportional" meta:resourcekey="LiteralResource4"></asp:literal>
                   

                </div>
                </div>
                 <!-- fine riga -->
                                <!-- riga -->
<div id ="disable_cl_pulse1">
                <div class="row-fluid">
               	<div class="span2">
                       <div id="riga1_cl_pulse1_1" class="control-group">
                           <div id="label1_cl_pulse1_proportional">
                                <h5 style="padding-top:10px"><asp:literal ID = "Literal39"  text="mV" runat="server" meta:resourcekey="Literal39Resource1"></asp:literal></h5>
                           </div>
                           <div id="label1_cl_pulse1_on_off">
                                <h5 style="padding-top:10px"><asp:literal ID = "Literal40"  text="mV ON" runat="server" meta:resourcekey="Literal40Resource1"></asp:literal></h5>
                           </div>
                       <asp:textbox ID="value1_cl_pulse1_1"  onblur="javascript: Changed_channel( 'value1_cl_pulse1_1','riga1_cl_pulse1_1',max_ch2_value, min_ch2_value,max_fix_value2 );" class="span12"  runat="server" meta:resourcekey="value1_cl_pulse1_1Resource1" ></asp:textbox>
                </div>
                       </div>

                    <div class="span2">
                       <div id="riga2_cl_pulse1_1" class="control-group">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal41"  text=" %" runat="server" meta:resourcekey="Literal41Resource1"></asp:literal></h5>
                       <asp:textbox ID="value2_cl_pulse1_1" onblur="javascript: Changed_channel( 'value2_cl_pulse1_1','riga2_cl_pulse1_1',100, 0,0 );"  class="span12"  runat="server" MaxLength="3" meta:resourcekey="value2_cl_pulse1_1Resource1" ></asp:textbox>
                </div>
                       </div>
                </div>
                 <!-- fine riga -->
<!-- riga -->
                <div class="row-fluid">
               	<div class="span2">
                       <div id="riga1_cl_pulse1_2" class="control-group">
                           <div id="label2_cl_pulse1_proportional">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal42"  text="mV" runat="server" meta:resourcekey="Literal42Resource1"></asp:literal></h5>
                               </div>
                           <div id="label2_cl_pulse1_on_off">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal43"  text="mV OFF" runat="server" meta:resourcekey="Literal43Resource1"></asp:literal></h5>
                               </div>

                       <asp:textbox ID="value1_cl_pulse1_2" onblur="javascript: Changed_channel( 'value1_cl_pulse1_2','riga1_cl_pulse1_2',max_ch2_value, min_ch2_value,max_fix_value2 );"  class="span12"  runat="server" meta:resourcekey="value1_cl_pulse1_2Resource1" ></asp:textbox>
                </div>
                       </div>

                    <div class="span2">
                       <div id="riga2_cl_pulse1_2" class="control-group">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal44"  text=" %" runat="server" meta:resourcekey="Literal44Resource1"></asp:literal></h5>
                       <asp:textbox ID="value2_cl_pulse1_2" onblur="javascript: Changed_channel( 'value2_cl_pulse1_2','riga2_cl_pulse1_2',100, 0,0 );" class="span12"  runat="server" MaxLength="3" meta:resourcekey="value2_cl_pulse1_2Resource1" ></asp:textbox>
                </div>
                       </div>
                </div>
                 <!-- fine riga -->                                
<!-- riga -->
                
                 <!-- fine riga -->  
    </div>
                    </div>
                </div>
<!-- tab 4 stop-->
           
    </div>
                                   <div id="salva" class="btn-primary">
                   <b class="btn-primary btn-icon glyphicons ok"><asp:button runat="server" ID="save_setpointwdPER_new" class="btn-primary" data-layout="center" data-type="confirm" data-toggle="notyfy" text="Salva e carica i dati" Font-Bold="True" meta:resourcekey="save_setpointwdPER_newResource1" /><i></i></b>

            </div>
        </div>
        </div>
<script type="text/javascript" src="wd/validator_wd_PER.js"></script>
      <script type="text/javascript" src="common/validator_general_notify.js"></script>
<script src="theme/scripts/demo/notifications.js"></script>
</form>


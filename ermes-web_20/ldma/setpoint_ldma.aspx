<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="setpoint_ldma.aspx.vb" Inherits="ermes_web_20.setpoint_ldma" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>

<form id="form" runat="server"  method="post" action="ldma/setpoint_ldma.aspx">
    <h3><asp:literal runat="server" text ="Level 1" ID="message_channel" meta:resourcekey="message_channelResource1"></asp:literal></h3>
    <div class="innerLR">
        <div class="box-generic">
                        	<!-- Tabs Heading -->
		<!-- // Tabs Heading END -->
<div class="tab-content">
    <!-- tab 1 start-->
			<div class="tab-pane active" id="tab_ld_sp1_1">
                <div  class="box-generic">

                                <!-- riga -->
<div id ="disable_ph_pulse1">
                <div class="row-fluid">
               	<div class="span2">
                       <div id="riga1_level_name" class="control-group">
                           <div id="label1_level_name">
                                <h5 style="padding-top:10px"><asp:literal ID = "Literal4"  text="Name" runat="server" meta:resourcekey="Literal1Resource1"></asp:literal></h5>
                           </div>
                       <asp:textbox ID="value_level_name" onblur="javascript: Changed_channel_str( 'value_level_name','riga1_level_name' );" class="span12"  runat="server"  MaxLength="15" meta:resourcekey="value_level_nameResource1" ></asp:textbox>
                </div>
                       </div>

                </div>
                 <!-- fine riga -->
<!-- riga -->
                <div class="row-fluid">
               	<div class="span2">
                       <div id="riga1_level_4ma" class="control-group">
                           <div id="label_level_4ma">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal8"  text="4 mA (Litre)" runat="server" meta:resourcekey="Literal8Resource1" ></asp:literal></h5>
                               </div>

                       <asp:textbox ID="value_level_4ma" onblur="javascript: Changed_channel( 'value_level_4ma','riga1_level_4ma',999, 0,1 );" class="span12"  runat="server" meta:resourcekey="value_level_4maResource1" ></asp:textbox>
                </div>
                       </div>

                    <div class="span2">
                       <div id="riga1_level_20ma" class="control-group">
                           <div id="label_level_20ma">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal9"  text="20 mA (Litre)" runat="server" meta:resourcekey="Literal4Resource1"></asp:literal></h5>
                               </div>
                       <asp:textbox ID="value_level_20ma"  onblur="javascript: Changed_channel( 'value_level_20ma','riga1_level_20ma',999, 0,1 );" class="span12"  runat="server" meta:resourcekey="value_level_20maResource1"  ></asp:textbox>
                </div>
                       </div>
                </div>
                 <!-- fine riga -->                                
<!-- riga -->
                <div class="row-fluid">
               	<div class="span2">
                       <div id="riga1_level_alarm" class="control-group">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal10"  text="Alarm (Litre)" runat="server" meta:resourcekey="Literal10Resource1" ></asp:literal></h5>
                       <asp:textbox ID="value_level_alarm" onblur="javascript: Changed_channel( 'value_level_alarm','riga1_level_alarm',999, 0,1 );"  class="span12"  runat="server" meta:resourcekey="value_level_alarmResource1"  ></asp:textbox>
                </div>
                       </div>
       <div class="span2">
                       <div id="riga1_level_alarm_msg" class="control-group">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal1"  text="Msg(Sms/Mail)" runat="server" meta:resourcekey="Literal1Resource2" ></asp:literal></h5>
                 <asp:dropdownlist ID="value_level_msg" class="span12" runat="server" meta:resourcekey="value_level_msgResource1">
                     <asp:ListItem Value="0" meta:resourcekey="ListItemResource1" >No</asp:ListItem>
                     <asp:ListItem Value="1" meta:resourcekey="ListItemResource2" >Yes</asp:ListItem>
                    </asp:dropdownlist>

                </div>
                       </div>
                </div>
                 <!-- fine riga -->  
    </div>
                    </div>
                </div>
<!-- tab 1 stop-->
 
    </div>
                                   <div id="salva" class="btn-primary">
                   <b class="btn-primary btn-icon glyphicons ok"><asp:button runat="server" ID="save_setpointldma_new" class="btn-primary" data-layout="center" data-type="confirm" data-toggle="notyfy"  text="Salva e carica i dati" Font-Bold="True" meta:resourcekey="save_setpointld_newResource1" /><i></i></b>

            </div>
        </div>
        </div>
<script type="text/javascript" src="ldma/validator_ldma_setpoint.js"></script>
<script type="text/javascript" src="common/validator_general_notify.js"></script>
<script src="theme/scripts/demo/notifications.js"></script>

</form>
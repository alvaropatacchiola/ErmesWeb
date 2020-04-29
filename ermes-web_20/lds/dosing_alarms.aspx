<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="dosing_alarms.aspx.vb" Inherits="ermes_web_20.dosing_alarms" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>

<form id="form" runat="server" method="post" action="lds/dosing_alarms.aspx">
    <h3><asp:literal runat="server" text ="Dosing Alarm LDS" ID="message_channel" meta:resourcekey="message_channelResource1"></asp:literal></h3>
    <div class="innerLR">
        <div class="box-generic">
            
            <div class="tab-content">
               
<!-- tab 1 start-->
			<div class="tab-pane active" id="tab_ld_sp1_1">
                <div  class="box-generic">
                                 <!-- riga -->
                <div class="row-fluid">
               	<div class="span12">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal7"  text="Dosing Alarm Cl" runat="server" meta:resourcekey="Literal7Resource1"></asp:literal></h5>
<div class="controlli_box"> 
                    <asp:radiobutton ID="cl_alarm_dosing_disable"  runat="server"  GroupName="GROUP1" meta:resourcekey="cl_alarm_dosing_disableResource1"></asp:radiobutton>
</div>
<div class="controlli_testo_box"> 
                    <asp:literal runat="server" text ="Disable" meta:resourcekey="LiteralResource1"></asp:literal>
</div>
<div class="controlli_box"> 
                    <asp:radiobutton ID="cl_alarm_dosing_enable" runat="server"  GroupName="GROUP1" meta:resourcekey="cl_alarm_dosing_enableResource1"></asp:radiobutton>
</div>
<div class="controlli_testo_box"> 
                       <asp:literal runat="server" text ="Enable" meta:resourcekey="LiteralResource2"></asp:literal>
</div>
                </div>
                </div>
                 <!-- fine riga -->
                                <!-- riga -->
<div id ="enable_value_cl_alarm_dosing">
                <div class="row-fluid">
               	<div class="span3">
                       <div id="riga1_cl_alarm_dosing" class="control-group">
                           <h5 style="padding-top:10px"><asp:literal ID = "Literal10"  text="Time Alarm(min)" runat="server" meta:resourcekey="Literal10Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_cl_alarm_dosing" onblur="javascript: Changed_channel( 'value_cl_alarm_dosing','riga1_cl_alarm_dosing',99, 0,0 );" class="span12"  runat="server" MaxLength="2" meta:resourcekey="value_cl_alarm_dosingResource1" ></asp:textbox>
                </div>
                       </div>

                   
                </div>
    <div class="row-fluid">
               	<div class="span12">
                       <h5 style="padding-top:10px"><asp:literal ID = "Literal11"  text="Mode" runat="server" meta:resourcekey="Literal11Resource1"></asp:literal></h5>
<div class="controlli_box"> 
                    <asp:radiobutton ID="cl_alarm_dosing_dose"  runat="server"  GroupName="GROUP2" meta:resourcekey="cl_alarm_dosing_doseResource1"></asp:radiobutton>
</div>
<div class="controlli_testo_box"> 
                    <asp:literal runat="server" text ="Dose" meta:resourcekey="LiteralResource3"></asp:literal>
</div>
<div class="controlli_box"> 
                    <asp:radiobutton ID="cl_alarm_dosing_stop"  runat="server"  GroupName="GROUP2" meta:resourcekey="cl_alarm_dosing_stopResource1"></asp:radiobutton>
</div>
<div class="controlli_testo_box"> 
                       <asp:literal runat="server" text ="Stop" meta:resourcekey="LiteralResource4"></asp:literal>
</div>
                       </div>

                    
                </div>
</div>
                 <!-- fine riga -->
</div>

<!-- tab 1 stop-->  
                </div>
             <div id="salva" class="btn-primary">
                   <b class="btn-primary btn-icon glyphicons ok"><asp:button runat="server" ID="save_alarmdosinglds_new" class="btn-primary" data-layout="center" data-type="confirm" data-toggle="notyfy" text="Salva e carica i dati" Font-Bold="True" meta:resourcekey="save_alarmdosinglds_newResource1" /><i></i></b>
                </div>
            </div>
        </div>
                <script type="text/javascript" src="lds/validator_lds_dosingalarm.js"></script>
           <script type="text/javascript" src="common/validator_general_notify.js"></script>
<script src="theme/scripts/demo/notifications.js"></script>
</form>
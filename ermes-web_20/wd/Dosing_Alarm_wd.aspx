<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Dosing_Alarm_wd.aspx.vb" Inherits="ermes_web_20.WebForm4" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>
<form id="form" runat="server" method="post" action="wd/Dosing_Alarm_wd.aspx">
    <h3><asp:literal runat="server" text ="Dosing Alarm WD" ID="message_channel" meta:resourcekey="message_channelResource1"></asp:literal></h3>
    <div class="innerLR">
        <div class="box-generic">
            <div class="tabsbar tabsbar-2">
			<ul class="row-fluid row-merge">
            
                <li class="span2 active" ><a id="tab_ld_sp1" href="#tab_ld_sp1_1"  data-toggle="tab"><asp:literal text="pH"  runat="server" ID="tabld1_1" meta:resourcekey="tabld1_1Resource1" ></asp:literal></a></li>
                <li class="span2"><a id="tab_ld_sp2" href="#tab_ld_sp2_2" data-toggle="tab"><asp:literal text="mV" runat="server" ID="tabld1_2" meta:resourcekey="tabld1_2Resource1"></asp:literal></a></li>
			</ul>
		</div>
            <div class="tab-content">
                <!-- tab 1 start-->
			<div class="tab-pane active" id="tab_ld_sp1_1">
                <div  class="box-generic">
                                 <!-- riga -->
                <div class="row-fluid">
               	<div class="span3">
              <h5 style="padding-top:10px"><asp:literal ID = "Label7"  text="Dosing Alarm pH" runat="server" meta:resourcekey="Label7Resource1"></asp:literal></h5>

                    <asp:radiobutton ID="ph_alarm_dosing_disable" style="margin: 5px 10px 10px 0px;" runat="server"  GroupName="GROUP1" meta:resourcekey="ph_alarm_dosing_disableResource1"></asp:radiobutton>
                    <asp:literal runat="server" text ="Disable" meta:resourcekey="LiteralResource1"></asp:literal>
                    <asp:radiobutton ID="ph_alarm_dosing_enable" style="margin: 5px 10px 10px 0px;" runat="server"  GroupName="GROUP1" meta:resourcekey="ph_alarm_dosing_enableResource1"></asp:radiobutton>
                       <asp:literal runat="server" text ="Enable" meta:resourcekey="LiteralResource2"></asp:literal>
                </div>
                </div>
                 <!-- fine riga -->
                                <!-- riga -->
<div id ="enable_value_ph_alarm_dosing">
                <div class="row-fluid">
               	<div class="span3">
                       <div id="riga1_ph_alarm_dosing" class="control-group">
                           <h5 style="padding-top:10px"><asp:literal ID = "Literal4"  text="Time Alarm(min)" runat="server" meta:resourcekey="Literal4Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_ph_alarm_dosing" onblur="javascript: Changed_channel( 'value_ph_alarm_dosing','riga1_ph_alarm_dosing',99, 0,0 );" class="span12"  runat="server" MaxLength="2" meta:resourcekey="value_ph_alarm_dosingResource1" ></asp:textbox>
                </div>
                       </div>

                   
                </div>
    <div class="row-fluid">
               	<div class="span3">
                       <h5 style="padding-top:10px"><asp:literal ID = "Literal3"  text="Mode" runat="server" meta:resourcekey="Literal3Resource1"></asp:literal></h5>
                    <asp:radiobutton ID="ph_alarm_dosing_dose" style="margin: 5px 10px 10px 0px;" runat="server"  GroupName="GROUP2" meta:resourcekey="ph_alarm_dosing_doseResource1"></asp:radiobutton>
                    <asp:literal runat="server" text ="Dose" meta:resourcekey="LiteralResource3"></asp:literal>
                    <asp:radiobutton ID="ph_alarm_dosing_stop" style="margin: 5px 10px 10px 0px;" runat="server"  GroupName="GROUP2" meta:resourcekey="ph_alarm_dosing_stopResource1"></asp:radiobutton>
                       <asp:literal runat="server" text ="Stop" meta:resourcekey="LiteralResource4"></asp:literal>

                       </div>

                    
                </div>
</div>
                 <!-- fine riga -->
</div>
</div>
<!-- tab 1 stop-->
<!-- tab 2 start-->
			<div class="tab-pane" id="tab_ld_sp2_2">
                <div  class="box-generic">
                                 <!-- riga -->
                <div class="row-fluid">
               	<div class="span3">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal7"  text="Dosing Alarm mV" runat="server" meta:resourcekey="Literal7Resource1"></asp:literal></h5>

                    <asp:radiobutton ID="cl_alarm_dosing_disable" style="margin: 5px 10px 10px 0px;" runat="server"  GroupName="GROUP3" meta:resourcekey="cl_alarm_dosing_disableResource1"></asp:radiobutton>
                    <asp:literal runat="server" text ="Disable" meta:resourcekey="LiteralResource5"></asp:literal>
                    <asp:radiobutton ID="cl_alarm_dosing_enable" style="margin: 5px 10px 10px 0px;" runat="server"  GroupName="GROUP3" meta:resourcekey="cl_alarm_dosing_enableResource1"></asp:radiobutton>
                       <asp:literal runat="server" text ="Enable" meta:resourcekey="LiteralResource6"></asp:literal>
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
               	<div class="span3">
                       <h5 style="padding-top:10px"><asp:literal ID = "Literal11"  text="Mode" runat="server" meta:resourcekey="Literal11Resource1"></asp:literal></h5>
                    <asp:radiobutton ID="cl_alarm_dosing_dose" style="margin: 5px 10px 10px 0px;" runat="server"  GroupName="GROUP4" meta:resourcekey="cl_alarm_dosing_doseResource1"></asp:radiobutton>
                    <asp:literal runat="server" text ="Dose" meta:resourcekey="LiteralResource7"></asp:literal>
                    <asp:radiobutton ID="cl_alarm_dosing_stop" style="margin: 5px 10px 10px 0px;" runat="server"  GroupName="GROUP4" meta:resourcekey="cl_alarm_dosing_stopResource1"></asp:radiobutton>
                       <asp:literal runat="server" text ="Stop" meta:resourcekey="LiteralResource8"></asp:literal>

                       </div>

                    
                </div>
</div>
                 <!-- fine riga -->
</div>

<!-- tab 2 stop-->  
                </div>
             <div id="salva" class="btn-primary">
                   <b class="btn-primary btn-icon glyphicons ok"><asp:button runat="server" data-layout="center" data-type="confirm" data-toggle="notyfy" ID="save_alarmdosingwd_new" class="btn-primary"  text="Salva e carica i dati" Font-Bold="True" meta:resourcekey="save_alarmdosingwd_newResource1" /><i></i></b>
                </div>
            </div>
        </div>
                <script type="text/javascript" src="wd/validator_wd_dosing_alarm.js"></script>
           <script type="text/javascript" src="common/validator_general_notify.js"></script>
<script src="theme/scripts/demo/notifications.js"></script>
    </form>
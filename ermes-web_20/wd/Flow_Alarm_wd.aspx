﻿<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Flow_Alarm_wd.aspx.vb" Inherits="ermes_web_20.WebForm5" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>
<form id="form" runat="server" method="post" action="wd/Flow_Alarm_wd.aspx">
    <h3><asp:literal runat="server" text ="Flow WD" ID="message_channel" meta:resourcekey="message_channelResource1"></asp:literal></h3>
    <div class="innerLR">
        <div class="box-generic">
            <div class="box-generic">
                <div class="tab-content">
                 <!-- tab 1 start-->
			<div class="tab-pane active" id="tab_ld_sp1_1">
                <div  class="box-generic">
                                 <!-- riga -->
                <div class="row-fluid">
               	<div class="span3">
              <h5 style="padding-top:10px"><asp:literal ID = "Label7"  text="Mode Flow" runat="server" meta:resourcekey="Label7Resource1"></asp:literal></h5>

                    <asp:radiobutton ID="alarm_flow_direct" style="margin: 5px 10px 10px 0px;" runat="server"  GroupName="GROUP1" meta:resourcekey="alarm_flow_directResource1"></asp:radiobutton>
                    <asp:literal runat="server" text ="Direct" meta:resourcekey="LiteralResource1"></asp:literal>
                    <asp:radiobutton ID="alarm_flow_reverse" style="margin: 5px 10px 10px 0px;" runat="server"  GroupName="GROUP1" meta:resourcekey="alarm_flow_reverseResource1"></asp:radiobutton>
                       <asp:literal runat="server" text ="Reverse" meta:resourcekey="LiteralResource2"></asp:literal>
                    <asp:radiobutton ID="alarm_flow_disable" style="margin: 5px 10px 10px 0px;" runat="server"  GroupName="GROUP1" meta:resourcekey="alarm_flow_disableResource1"></asp:radiobutton>
                       <asp:literal runat="server" text ="Disable" meta:resourcekey="LiteralResource3"></asp:literal>

                </div>
                </div>
                 <!-- fine riga -->
                                <!-- riga -->
<div id ="enable_value_alarm_flow_time">
                <div class="row-fluid">
               	<div class="span3">
                       <div id="riga1_alarm_flow_time" class="control-group">
                           <h5 style="padding-top:10px"><asp:literal ID = "Literal4"  text="Delay Time (min)" runat="server" meta:resourcekey="Literal4Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_alarm_flow_time" onblur="javascript: Changed_channel( 'value_alarm_flow_time','riga1_alarm_flow_time',99, 0,0 );" class="span12"  runat="server" MaxLength="2" meta:resourcekey="value_alarm_flow_timeResource1" ></asp:textbox>
                </div>
                       </div>

                   
                </div>
</div>
                 <!-- fine riga -->

<!-- tab 1 stop-->
                </div>
             </div>
             <div id="salva" class="btn-primary">
                   <b class="btn-primary btn-icon glyphicons ok"><asp:button runat="server" ID="save_flowwd_new" class="btn-primary" data-layout="center" data-type="confirm" data-toggle="notyfy" text="Salva e carica i dati" Font-Bold="True" meta:resourcekey="save_flowwd_newResource1" /><i></i></b>
                </div>
            </div>
        </div>
    <script type="text/javascript" src="wd/validator_wd_flow_alarm.js"></script>
                        <script type="text/javascript" src="common/validator_general_notify.js"></script>
<script src="theme/scripts/demo/notifications.js"></script>

    </form>


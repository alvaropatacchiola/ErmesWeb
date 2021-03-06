﻿<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="log_setup.aspx.vb" Inherits="ermes_web_20.log_setup1" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>
<form id="form" runat="server"  method="post" action="tower/log_setup.aspx">
    <h3><asp:literal runat="server" text ="Log Setup" ID="message_channel" meta:resourcekey="message_channelResource1"></asp:literal></h3>
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
              <h5 style="padding-top:10px"><asp:literal ID = "Label7"  text="Log TOWER" runat="server" meta:resourcekey="Label7Resource1"></asp:literal></h5>

                    <asp:radiobutton ID="log_disable" style="margin: 5px 10px 10px 0px;" runat="server"  GroupName="GROUP1" meta:resourcekey="log_disableResource1"></asp:radiobutton>
                    <asp:literal runat="server" text ="Disable" meta:resourcekey="LiteralResource1"></asp:literal>
                    <asp:radiobutton ID="log_enable" style="margin: 5px 10px 10px 0px;" runat="server"  GroupName="GROUP1" meta:resourcekey="log_enableResource1"></asp:radiobutton>
                       <asp:literal runat="server" text ="Enable" meta:resourcekey="LiteralResource2"></asp:literal>

                </div>
                </div>
                 <!-- fine riga -->
                                <!-- riga -->
<div id ="enable_value_log">
                <div class="row-fluid">
               	<div class="span3">
                       <asp:placeholder runat="server" ID="log_24">
                       <div id="riga1_log_time_24" class="control-group">
                           <h5 style="padding-top:10px"><asp:literal ID = "Literal4"  text="Log Time" runat="server" meta:resourcekey="Literal4Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_log_time_24"  onblur="javascript: Changed_channel_timer( 'value_log_time_24','riga1_log_time_24', 5);" onchange = "javascript: Changed_channel_timer( 'value_log_time_24','riga1_log_time_24', 5);" class="span12"  runat="server" meta:resourcekey="value_log_time_24Resource1"  ></asp:textbox>
                </div>
                       </asp:placeholder>
 <asp:placeholder runat="server" ID="log_12">
                       <div id="riga1_log_time_12" class="control-group">
                           <h5 style="padding-top:10px"><asp:literal ID = "Literal3"  text="Log Time" runat="server" meta:resourcekey="Literal3Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_log_time_12" onblur="javascript: Changed_channel_timer( 'value_log_time_12','riga1_log_time_12', 8);" onchange = "javascript: Changed_channel_timer( 'value_log_time_12','riga1_log_time_12', 8);" class="span12"  runat="server" meta:resourcekey="value_log_time_12Resource1"  ></asp:textbox>
                </div>
                       </asp:placeholder>

                       </div>

                   
                </div>
                   <div class="row-fluid">
               	<div class="span3">
                       <div id="riga1_log_every_h" class="control-group">
                           <h5 style="padding-top:10px"><asp:literal ID = "Literal5"  text="Log Every Hour" runat="server" meta:resourcekey="Literal5Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_log_every_h" onblur="javascript: Changed_channel( 'value_log_every_h','riga1_log_every_h',23, 0,0 );" class="span12"  runat="server" MaxLength="2" meta:resourcekey="value_log_every_hResource1" ></asp:textbox>
                </div>
                       </div>

                   
                </div>
             <div class="row-fluid">
               	<div class="span3">
                       <div id="riga1_log_every_m" class="control-group">
                           <h5 style="padding-top:10px"><asp:literal ID = "Literal6"  text="Log Every Min" runat="server" meta:resourcekey="Literal6Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_log_every_m" onblur="javascript: Changed_channel( 'value_log_every_m','riga1_log_every_m',59, 0,0 );" class="span12"  runat="server" MaxLength="2" meta:resourcekey="value_log_every_mResource1" ></asp:textbox>
                </div>
                       </div>

                   
                </div>
</div>
                 <!-- fine riga -->

<!-- tab 1 stop-->
                </div>
             </div>
             <div id="salva" class="btn-primary">
                   <b class="btn-primary btn-icon glyphicons ok"><asp:button runat="server" ID="save_logsetuptower_new" class="btn-primary" data-layout="center" data-type="confirm" data-toggle="notyfy" text="Save and Load Data" Font-Bold="True" meta:resourcekey="save_logsetuptower_newResource1" /><i></i></b>
                </div>
            </div>
        </div>
    <script type="text/javascript" src="tower/validator_tower_logsetup.js"></script>
 <script type="text/javascript" src="common/validator_general_notify.js"></script>
<script src="theme/scripts/demo/notifications.js"></script>

   <script src="theme/scripts/demo/calendar_new.js"></script>
    <link href="bootstrap/css/jquery-ui-timepicker-addon.css" rel="stylesheet" />


    </form>
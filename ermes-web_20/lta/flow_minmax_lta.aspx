<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="flow_minmax_lta.aspx.vb" Inherits="ermes_web_20.flow_minmax_lta" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>
<form id="form" runat="server" method="post" action="lta/flow_minmax_lta.aspx">
    <h3><asp:literal runat="server" text =" " ID="message_channel" meta:resourcekey="message_channelResource1"></asp:literal></h3>
    <div class="innerLR">
        <div class="box-generic">
            <div class="box-generic">
                <div class="tab-content">
                 <!-- tab 1 start-->
			<div class="tab-pane active" id="tab_ld_sp1_1">
                <div  class="box-generic">
                                 <!-- riga -->
                <div class="row-fluid">
               	<div class="span12">
              <h5 style="padding-top:10px"><asp:literal ID = "Label7"  text="Mode Flow" runat="server" meta:resourcekey="Label7Resource1"></asp:literal></h5>
<div class="controlli_box">
                    <asp:radiobutton ID="alarm_flow_direct"  runat="server"  GroupName="GROUP1" meta:resourcekey="alarm_flow_directResource1"></asp:radiobutton>
</div>
<div class="controlli_testo_box">
                    <asp:literal runat="server" text ="Direct" meta:resourcekey="LiteralResource1"></asp:literal>
</div>
<div class="controlli_box">
                    <asp:radiobutton ID="alarm_flow_reverse"  runat="server"  GroupName="GROUP1" meta:resourcekey="alarm_flow_reverseResource1"></asp:radiobutton>
</div>
<div class="controlli_testo_box">
                       <asp:literal runat="server" text ="Reverse" meta:resourcekey="LiteralResource2"></asp:literal>
</div>
<div class="controlli_box">
                    <asp:radiobutton ID="alarm_flow_disable"  runat="server"  GroupName="GROUP1" meta:resourcekey="alarm_flow_disableResource1"></asp:radiobutton>
</div>
<div class="controlli_testo_box">
                       <asp:literal runat="server" text ="Disable" meta:resourcekey="LiteralResource3"></asp:literal>
</div>
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


                    <!-- riga -->
                <div class="row-fluid">
               	<div class="span12">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal1"  text="Mode Probe" runat="server" meta:resourcekey="Label7Resource1"></asp:literal></h5>
<div class="controlli_box">
                    <asp:radiobutton ID="alarm_minmax_en"  runat="server"  GroupName="GROUP2" meta:resourcekey="alarm_minmax_enResource1"></asp:radiobutton>
</div>
<div class="controlli_testo_box">
                    <asp:literal runat="server" text ="Enable" meta:resourcekey="LiteralResource1"></asp:literal>
</div>

<div class="controlli_box">
                    <asp:radiobutton ID="alarm_minmax_disable"  runat="server"  GroupName="GROUP2" meta:resourcekey="alarm_minmax_disableResource1"></asp:radiobutton>
</div>
<div class="controlli_testo_box">
                       <asp:literal runat="server" text ="Disable" meta:resourcekey="LiteralResource3"></asp:literal>
</div>
                </div>
                </div>
                 <!-- fine riga -->
                                <!-- riga -->
<div id ="enable_value_alarm_minmax_time">
                <div class="row-fluid">
               	<div class="span3">
                       <div id="riga1_alarm_minmax_time" class="control-group">
                           <h5 style="padding-top:10px"><asp:literal ID = "Literal2"  text="Delay Time (min)" runat="server" meta:resourcekey="Literal4Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_alarm_minmax_time" onblur="javascript: Changed_channel( 'value_alarm_minmax_time','riga1_alarm_min_time',99, 0,0 );" class="span12"  runat="server" MaxLength="2" meta:resourcekey="value_alarm_minmax_timeResource1" ></asp:textbox>
                </div>
                       </div>

                   
                </div>
</div>

                        <!-- riga -->
<div id ="enable_value_alarm_minmax_max">
                <div class="row-fluid">
               	<div class="span3">
                       <div id="riga1_alarm_minmax_max" class="control-group">
                           <h5 style="padding-top:10px"><asp:literal ID = "Literal3"  text="Max:" runat="server" meta:resourcekey="Literal4Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_alarm_minmax_max" onblur="javascript: Changed_channel( 'value_alarm_minmax_max','riga1_alarm_min_max',max_ch2_value, min_ch2_value,max_fix_value2 );" class="span12"  runat="server" MaxLength="4" meta:resourcekey="value_alarm_minmax_timeResource1" ></asp:textbox>
                </div>
                       </div>

                   
                </div>
</div>

                        <!-- riga -->
<div id ="enable_value_alarm_minmax_min">
                <div class="row-fluid">
               	<div class="span3">
                       <div id="riga1_alarm_minmax_min" class="control-group">
                           <h5 style="padding-top:10px"><asp:literal ID = "Literal5"  text="Min:" runat="server" meta:resourcekey="Literal4Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_alarm_minmax_min" onblur="javascript: Changed_channel( 'value_alarm_minmax_min','riga1_alarm_minmax_min',max_ch2_value, min_ch2_value,max_fix_value2 );" class="span12"  runat="server" MaxLength="4" meta:resourcekey="value_alarm_minmax_timeResource1" ></asp:textbox>
                </div>
                       </div>

                   
                </div>
</div>

                 <!-- fine riga -->

<!-- tab 1 stop-->


                  
             <div id="salva" class="btn-primary">
                   <b class="btn-primary btn-icon glyphicons ok"><asp:button runat="server" ID="save_flow_minmax_new" class="btn-primary" data-layout="center" data-type="confirm" data-toggle="notyfy" text="Salva e carica i dati" Font-Bold="True" meta:resourcekey="save_flow_minmax_newResource1" /><i></i></b>
                </div>
            </div>
        </div>
    <script type="text/javascript" src="lta/validator_lta_flowminmax.js"></script>
            <script type="text/javascript" src="common/validator_general_notify.js"></script>
<script src="theme/scripts/demo/notifications.js"></script>

    </form>

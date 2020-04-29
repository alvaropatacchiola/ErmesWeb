<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="flow_ltb.aspx.vb" Inherits="ermes_web_20.flow_ltb" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>
<form id="form" runat="server" method="post" action="ltb/flow_ltb.aspx">
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

<!-- tab 1 stop-->


                    <!-- tab 2 start-->
			<div class="tab-pane active" id="tab_ld_sp2_2">
                <div  class="box-generic">
                                 <!-- riga -->
                <div class="row-fluid">
               	<div class="span12">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal10"  text="Mode Alarm" runat="server" meta:resourcekey="Literal10Resource1"></asp:literal></h5>
<div class="controlli_box">
                    <asp:radiobutton ID="Dose_soglie"  runat="server"  GroupName="GROUP2" meta:resourcekey="alarm_soglie_doseResource1"></asp:radiobutton>
</div>
<div class="controlli_testo_box">
                    <asp:literal runat="server" text ="Dose" meta:resourcekey="LiteralResource9"></asp:literal>
</div>
<div class="controlli_box">
                    <asp:radiobutton ID="Stop_soglie"  runat="server"  GroupName="GROUP2" meta:resourcekey="alarm_soglie_stopResource1"></asp:radiobutton>
</div>
<div class="controlli_testo_box">
                       <asp:literal runat="server" text ="Stop" meta:resourcekey="LiteralResource10"></asp:literal>
</div>
<div class="controlli_box">
                    <asp:radiobutton ID="Dis_soglie"  runat="server"  GroupName="GROUP2" meta:resourcekey="alarm_soglie_disableResource1"></asp:radiobutton>
</div>
<div class="controlli_testo_box">
                       <asp:literal runat="server" text ="Disable" meta:resourcekey="LiteralResource3"></asp:literal>
</div>
                </div>
                </div>
                 <!-- fine riga -->
                                <!-- riga -->
<div id ="enable_value_alarm_soglie_time">
                <div class="row-fluid">
               	<div class="span3">
                       <div id="riga1_alarm_soglie_time" class="control-group">
                           <h5 style="padding-top:10px"><asp:literal ID = "Literal11"  text="Time (min)" runat="server" meta:resourcekey="Literal11Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_alarm_soglie_time" onblur="javascript: Changed_channel( 'value_alarm_soglie_time','riga1_alarm_soglie_time',99, 0,0 );" class="span12"  runat="server" MaxLength="2" meta:resourcekey="value_alarm_flow_timeResource1" ></asp:textbox>
                </div>
                       </div>

                   
                </div>
</div>
                 <!-- fine riga -->

                       <!-- riga -->
<div id ="enable_value_alarm_soglie_max">
                <div class="row-fluid">
               	<div class="span3">
                       <div id="riga2_alarm_soglie_max" class="control-group">
                           <h5 style="padding-top:10px"><asp:literal ID = "Literal12"  text="Max:" runat="server" meta:resourcekey="Literal12Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_alarm_soglie_max" onblur="javascript: Changed_channel( 'value_alarm_soglie_max','riga2_alarm_soglie_max',max_ch2_value, min_ch2_value,max_fix_value2  );" class="span12"  runat="server" MaxLength="4" meta:resourcekey="value_alarm_flow_timeResource1" ></asp:textbox>
                </div>
                       </div>

                   
                </div>
</div>
                 <!-- fine riga -->

                    <div id ="enable_value_alarm_soglie_min">
                <div class="row-fluid">
               	<div class="span3">
                       <div id="riga3_alarm_soglie_min" class="control-group">
                           <h5 style="padding-top:10px"><asp:literal ID = "Literal13"  text="Min:" runat="server" meta:resourcekey="Literal13Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_alarm_soglie_min" onblur="javascript: Changed_channel( 'value_alarm_soglie_min','riga3_alarm_soglie_min',max_ch2_value, min_ch2_value,max_fix_value2  );" class="span12"  runat="server" MaxLength="4" meta:resourcekey="value_alarm_flow_timeResource1" ></asp:textbox>
                </div>
                       </div>

                   
                </div>
</div>
                 <!-- fine riga -->


      <!-- riga -->
<asp:placeholder runat="server" ID="enable_dioxide">                
                <div class="row-fluid">
               	<div class="span12">
              <h5 style="padding-top:10px"><asp:literal ID = "Literalclo2"  text="ClO2 Air Alarm" runat="server" meta:resourcekey="Literalclo2Resource1"></asp:literal></h5>
<div class="controlli_box">
                    <asp:radiobutton ID="en_dioxide"  runat="server"  GroupName="GROUP3" meta:resourcekey="alarm_en_dioxideResource1"></asp:radiobutton>
</div>
<div class="controlli_testo_box">
                    <asp:literal runat="server" text ="Enable" meta:resourcekey="Literal_en_clo2_Resource9"></asp:literal>
</div>
<div class="controlli_box">
                    <asp:radiobutton ID="dis_dioxide"  runat="server"  GroupName="GROUP3" meta:resourcekey="alarm_dis_dioxideResource1"></asp:radiobutton>
</div>
<div class="controlli_testo_box">
                       <asp:literal runat="server" text ="Disable" meta:resourcekey="Literal_dis_clo2_Resource10"></asp:literal>
</div>

                </div>
                </div>

    <div class="row-fluid">
               	<div class="span3">
                       <div id="riga1_alarm_dioxide" class="control-group">
                           <h5 style="padding-top:10px"><asp:literal ID = "Literal_value"  text="Value" runat="server" meta:resourcekey="Literal_valueResource1"></asp:literal></h5>
                       <asp:textbox ID="value_alarm_dioxide" onblur="javascript: Changed_channel( 'value_alarm_dioxide','riga1_alarm_dioxide',1, 0,2 );" class="span12"  runat="server" MaxLength="4" meta:resourcekey="value_alarm_flow_timeResource1" ></asp:textbox>
                </div>
                       </div>

                   
                </div>


                         </asp:placeholder>
                    
                 <!-- fine riga -->              

<!-- tab 2 stop-->
                </div>
             </div>
             <div id="salva" class="btn-primary">
                   <b class="btn-primary btn-icon glyphicons ok"><asp:button runat="server" ID="save_flowltb_new" class="btn-primary" data-layout="center" data-type="confirm" data-toggle="notyfy" text="Salva e carica i dati" Font-Bold="True" meta:resourcekey="save_flowltb_newResource1" /><i></i></b>
                </div>
            </div>
        </div>
    <script type="text/javascript" src="ltb/validator_ltb_flow.js"></script>
            <script type="text/javascript" src="common/validator_general_notify.js"></script>
<script src="theme/scripts/demo/notifications.js"></script>

    </form>


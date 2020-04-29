<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="alarm.aspx.vb" Inherits="ermes_web_20.alarm" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>
<form id="form" runat="server"  method="post" action="tower/alarm.aspx">
    <h3><asp:literal runat="server" text ="Alarm Tower" ID="message_channel" meta:resourcekey="message_channelResource1"></asp:literal></h3>
<div class="innerLR">
    <div class="box-generic">
        <div class="tabsbar tabsbar-2">
			<ul class="row-fluid row-merge">
            
                <li class="span2 active" ><a id="tab_tower_sp1" href="#tab_tower_sp1_1"  data-toggle="tab"><asp:literal text="Alarm"  runat="server" ID="tabtower1_1" meta:resourcekey="tabtower1_1Resource1" ></asp:literal></a></li>
                <li class="span2"><a id="tab_tower_sp2" href="#tab_tower_sp2_2" data-toggle="tab"><asp:literal text="Alarm Input" runat="server" ID="tabtower1_2" meta:resourcekey="tabtower1_2Resource1"></asp:literal></a></li>
			</ul>
		</div>
        <div class="tab-content">
<!-- tab 1 start-->
			<div class="tab-pane active" id="tab_tower_sp1_1">
                <div  class="box-generic">
<!-- riga -->

                <div class="row-fluid">
               	<div class="span3">
                       <div class="control-group">
                           <h5 style="padding-top:10px"><asp:literal ID = "Label7"  text="Low Conductivity" runat="server" meta:resourcekey="Label7Resource1"></asp:literal></h5>
                    <asp:radiobutton ID="ch1_low_off" Checked="True" style="margin: 5px 10px 10px 0px;" runat="server"  GroupName="GROUP1" meta:resourcekey="ch1_low_offResource1"></asp:radiobutton>
                    <asp:literal runat="server" text ="Off" meta:resourcekey="LiteralResource1"></asp:literal>
                    <asp:radiobutton ID="ch1_low_track" style="margin: 5px 10px 10px 0px;" runat="server"  GroupName="GROUP1" meta:resourcekey="ch1_low_trackResource1"></asp:radiobutton>
                       <asp:literal runat="server" text ="Track" meta:resourcekey="LiteralResource2"></asp:literal>
                    <asp:radiobutton ID="ch1_low_absolute" style="margin: 5px 10px 10px 0px;" runat="server"  GroupName="GROUP1" meta:resourcekey="ch1_low_absoluteResource1"></asp:radiobutton>
                       <asp:literal runat="server" text ="Absolute" meta:resourcekey="LiteralResource3"></asp:literal>

                </div>
                       </div>
 	            <div class="span3">
                       <div id="riga_ch1_low" class="control-group">
                        <h5 style="padding-top:10px"><asp:literal ID = "Literal1"  text="0 uS" runat="server" meta:resourcekey="Literal1Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_ch1_low" onblur="javascript: Changed_channel( 'value_ch1_low','riga_ch1_low',max_ch1, 0,0);" class="span12"  runat="server" MaxLength="5" meta:resourcekey="value_ch1_lowResource1" ></asp:textbox>
                </div>
                       </div>
                   
                </div>
<!-- fine riga -->
<!-- riga -->

                <div class="row-fluid">
               	<div class="span3">
                       <div class="control-group">
                           <h5 style="padding-top:10px"><asp:literal ID = "Literal2"  text="High Conductivity" runat="server" meta:resourcekey="Literal2Resource1"></asp:literal></h5>
                    <asp:radiobutton ID="ch1_high_off" Checked="True" style="margin: 5px 10px 10px 0px;" runat="server"  GroupName="GROUP2" meta:resourcekey="ch1_high_offResource1"></asp:radiobutton>
                    <asp:literal runat="server" text ="Off" meta:resourcekey="LiteralResource4"></asp:literal>
                    <asp:radiobutton ID="ch1_high_track" style="margin: 5px 10px 10px 0px;" runat="server"  GroupName="GROUP2" meta:resourcekey="ch1_high_trackResource1"></asp:radiobutton>
                       <asp:literal runat="server" text ="Track" meta:resourcekey="LiteralResource5"></asp:literal>
                    <asp:radiobutton ID="ch1_high_absolute" style="margin: 5px 10px 10px 0px;" runat="server"  GroupName="GROUP2" meta:resourcekey="ch1_high_absoluteResource1"></asp:radiobutton>
                       <asp:literal runat="server" text ="Absolute" meta:resourcekey="LiteralResource6"></asp:literal>

                </div>
                       </div>
 	            <div class="span3">
                       <div id="riga_ch1_high" class="control-group">
                        <h5 style="padding-top:10px"><asp:literal ID = "Literal6"  text="0 uS" runat="server" meta:resourcekey="Literal6Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_ch1_high" onblur="javascript: Changed_channel( 'value_ch1_high','riga_ch1_high',max_ch1, 0,0 );" class="span12"  runat="server" MaxLength="5" meta:resourcekey="value_ch1_highResource1" ></asp:textbox>
                </div>
                       </div>
                   
                </div>
<!-- fine riga -->
<!-- riga -->
<asp:placeholder runat="server" ID="ch2_enable">
                <div class="row-fluid">
               	<div class="span3">
                       <div class="control-group">
                           <h5 style="padding-top:10px"><asp:literal ID = "Literal3"  text="Low" runat="server" meta:resourcekey="Literal3Resource1"></asp:literal></h5>
                    <asp:radiobutton ID="ch2_low_off" Checked="True" style="margin: 5px 10px 10px 0px;" runat="server"  GroupName="GROUP3" meta:resourcekey="ch2_low_offResource1"></asp:radiobutton>
                    <asp:literal runat="server" text ="Off" meta:resourcekey="LiteralResource7"></asp:literal>
                    <asp:radiobutton ID="ch2_low_track" style="margin: 5px 10px 10px 0px;" runat="server"  GroupName="GROUP3" meta:resourcekey="ch2_low_trackResource1"></asp:radiobutton>
                       <asp:literal runat="server" text ="Track" meta:resourcekey="LiteralResource8"></asp:literal>
                    <asp:radiobutton ID="ch2_low_absolute" style="margin: 5px 10px 10px 0px;" runat="server"  GroupName="GROUP3" meta:resourcekey="ch2_low_absoluteResource1"></asp:radiobutton>
                       <asp:literal runat="server" text ="Absolute" meta:resourcekey="LiteralResource9"></asp:literal>

                </div>
                       </div>
 	            <div class="span3">
                       <div id="riga_ch2_low" class="control-group">
                        <h5 style="padding-top:10px"><asp:literal ID = "Literal8"  text="0 uS" runat="server" meta:resourcekey="Literal8Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_ch2_low" onblur="javascript: Changed_channel( 'value_ch2_low','riga_ch2_low',max_ch2, min_ch2,ch2_fix );" class="span12"  runat="server" MaxLength="5" meta:resourcekey="value_ch2_lowResource1" ></asp:textbox>
                </div>
                       </div>
                   
                </div>
<!-- fine riga -->
<!-- riga -->

                <div class="row-fluid">
               	<div class="span3">
                       <div class="control-group">
                           <h5 style="padding-top:10px"><asp:literal ID = "Literal9"  text="High" runat="server" meta:resourcekey="Literal9Resource1"></asp:literal></h5>
                    <asp:radiobutton ID="ch2_high_off" Checked="True" style="margin: 5px 10px 10px 0px;" runat="server"  GroupName="GROUP4" meta:resourcekey="ch2_high_offResource1"></asp:radiobutton>
                    <asp:literal runat="server" text ="Off" meta:resourcekey="LiteralResource10"></asp:literal>
                    <asp:radiobutton ID="ch2_high_track" style="margin: 5px 10px 10px 0px;" runat="server"  GroupName="GROUP4" meta:resourcekey="ch2_high_trackResource1"></asp:radiobutton>
                       <asp:literal runat="server" text ="Track" meta:resourcekey="LiteralResource11"></asp:literal>
                    <asp:radiobutton ID="ch2_high_absolute" style="margin: 5px 10px 10px 0px;" runat="server"  GroupName="GROUP4" meta:resourcekey="ch2_high_absoluteResource1"></asp:radiobutton>
                       <asp:literal runat="server" text ="Absolute" meta:resourcekey="LiteralResource12"></asp:literal>

                </div>
                       </div>
 	            <div class="span3">
                       <div id="riga_ch2_high" class="control-group">
                        <h5 style="padding-top:10px"><asp:literal ID = "Literal13"  text="0 uS" runat="server" meta:resourcekey="Literal13Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_ch2_high" onblur="javascript: Changed_channel( 'value_ch2_high','riga_ch2_high',max_ch2, min_ch2,ch2_fix );" class="span12"  runat="server" MaxLength="5" meta:resourcekey="value_ch2_highResource1" ></asp:textbox>
                </div>
                       </div>
                   
                </div>
    </asp:placeholder>
<!-- fine riga -->
<!-- riga -->
<asp:placeholder runat="server" ID="ch3_enable">
                <div class="row-fluid">
               	<div class="span3">
                       <div class="control-group">
                           <h5 style="padding-top:10px"><asp:literal ID = "Literal4"  text="Low" runat="server" meta:resourcekey="Literal4Resource1"></asp:literal></h5>
                    <asp:radiobutton ID="ch3_low_off" Checked="True" style="margin: 5px 10px 10px 0px;" runat="server"  GroupName="GROUP5" meta:resourcekey="ch3_low_offResource1"></asp:radiobutton>
                    <asp:literal runat="server" text ="Off" meta:resourcekey="LiteralResource13"></asp:literal>
                    <asp:radiobutton ID="ch3_low_track" style="margin: 5px 10px 10px 0px;" runat="server"  GroupName="GROUP5" meta:resourcekey="ch3_low_trackResource1"></asp:radiobutton>
                       <asp:literal runat="server" text ="Track" meta:resourcekey="LiteralResource14"></asp:literal>
                    <asp:radiobutton ID="ch3_low_absolute" style="margin: 5px 10px 10px 0px;" runat="server"  GroupName="GROUP5" meta:resourcekey="ch3_low_absoluteResource1"></asp:radiobutton>
                       <asp:literal runat="server" text ="Absolute" meta:resourcekey="LiteralResource15"></asp:literal>

                </div>
                       </div>
 	            <div class="span3">
                       <div id="riga_ch3_low" class="control-group">
                        <h5 style="padding-top:10px"><asp:literal ID = "Literal11"  text="0 uS" runat="server" meta:resourcekey="Literal11Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_ch3_low" onblur="javascript: Changed_channel( 'value_ch3_low','riga_ch3_low',max_ch3, min_ch3,ch3_fix  );" class="span12"  runat="server" MaxLength="5" meta:resourcekey="value_ch3_lowResource1" ></asp:textbox>
                </div>
                       </div>
                   
                </div>
<!-- fine riga -->
<!-- riga -->

                <div class="row-fluid">
               	<div class="span3">
                       <div class="control-group">
                           <h5 style="padding-top:10px"><asp:literal ID = "Literal12"  text="High " runat="server" meta:resourcekey="Literal12Resource1"></asp:literal></h5>
                    <asp:radiobutton ID="ch3_high_off" Checked="True" style="margin: 5px 10px 10px 0px;" runat="server"  GroupName="GROUP6" meta:resourcekey="ch3_high_offResource1"></asp:radiobutton>
                    <asp:literal runat="server" text ="Off" meta:resourcekey="LiteralResource16"></asp:literal>
                    <asp:radiobutton ID="ch3_high_track" style="margin: 5px 10px 10px 0px;" runat="server"  GroupName="GROUP6" meta:resourcekey="ch3_high_trackResource1"></asp:radiobutton>
                       <asp:literal runat="server" text ="Track" meta:resourcekey="LiteralResource17"></asp:literal>
                    <asp:radiobutton ID="ch3_high_absolute" style="margin: 5px 10px 10px 0px;" runat="server"  GroupName="GROUP6" meta:resourcekey="ch3_high_absoluteResource1"></asp:radiobutton>
                       <asp:literal runat="server" text ="Absolute" meta:resourcekey="LiteralResource18"></asp:literal>

                </div>
                       </div>
 	            <div class="span3">
                       <div id="riga_ch3_high" class="control-group">
                        <h5 style="padding-top:10px"><asp:literal ID = "Literal17"  text="0 uS" runat="server" meta:resourcekey="Literal17Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_ch3_high" onblur="javascript: Changed_channel( 'value_ch3_high','riga_ch3_high',max_ch3, min_ch3,ch3_fix );" class="span12"  runat="server" MaxLength="5" meta:resourcekey="value_ch3_highResource1" ></asp:textbox>
                </div>
                       </div>
                   
                </div>
    </asp:placeholder>
<!-- fine riga -->
<!-- riga -->

                <div class="row-fluid">
               	<div class="span3">
                       <div class="control-group">
                           <h5 style="padding-top:10px"><asp:literal ID = "Literal5"  text="Chemical Levels" runat="server" meta:resourcekey="Literal5Resource1"></asp:literal></h5>
                    <asp:radiobutton ID="chemical_levels_stop" style="margin: 5px 10px 10px 0px;" runat="server"  GroupName="GROUP7" meta:resourcekey="chemical_levels_stopResource1"></asp:radiobutton>
                    <asp:literal runat="server" text ="Stop" meta:resourcekey="LiteralResource19"></asp:literal>
                    <asp:radiobutton ID="chemical_levels_no" style="margin: 5px 10px 10px 0px;" runat="server"  GroupName="GROUP7" meta:resourcekey="chemical_levels_noResource1"></asp:radiobutton>
                       <asp:literal runat="server" text ="No" meta:resourcekey="LiteralResource20"></asp:literal>

                </div>
                       </div>
<asp:placeholder runat="server" ID="enable_no_nc_chemical_levels">
 	            <div class="span3">
                       <div id="Div1" class="control-group">
                           <h5 style="padding-top:10px"><asp:literal ID = "Literal7"  text="Out" runat="server" meta:resourcekey="Literal7Resource1"></asp:literal></h5>
                    <asp:radiobutton ID="chemical_levels_out_no" style="margin: 5px 10px 10px 0px;" runat="server"  GroupName="GROUP8" meta:resourcekey="chemical_levels_out_noResource1"></asp:radiobutton>
                    <asp:literal runat="server" text ="N.O." meta:resourcekey="LiteralResource21"></asp:literal>
                    <asp:radiobutton ID="chemical_levels_out_nc" style="margin: 5px 10px 10px 0px;" runat="server"  GroupName="GROUP8" meta:resourcekey="chemical_levels_out_ncResource1"></asp:radiobutton>
                       <asp:literal runat="server" text ="N.C." meta:resourcekey="LiteralResource22"></asp:literal>
                </div>
                       </div>
</asp:placeholder>                   
                </div>
<!-- fine riga -->
    </div>
</div>
<!-- tab 1 stop-->
<!-- tab 2 start-->
			<div class="tab-pane" id="tab_tower_sp2_2">
                <div  class="box-generic">
<!-- riga -->

                <div class="row-fluid">
               	<div class="span3">
                       <div class="control-group">
                           <h5 style="padding-top:10px"><asp:literal ID = "Literal10"  text="No Flow" runat="server" meta:resourcekey="Literal10Resource1"></asp:literal></h5>
                    <asp:radiobutton ID="no_flow_stop" style="margin: 5px 10px 10px 0px;" runat="server"  GroupName="GROUP9" meta:resourcekey="no_flow_stopResource1"></asp:radiobutton>
                    <asp:literal runat="server" text ="Stop" meta:resourcekey="LiteralResource23"></asp:literal>
                    <asp:radiobutton ID="no_flow_no" style="margin: 5px 10px 10px 0px;" runat="server"  GroupName="GROUP9" meta:resourcekey="no_flow_noResource1"></asp:radiobutton>
                       <asp:literal runat="server" text ="No" meta:resourcekey="LiteralResource24"></asp:literal>
                </div>
                       </div>
 	            <div class="span3">
                       <div id="Div2" class="control-group">
                           <h5 style="padding-top:10px"><asp:literal ID = "Literal14"  text="Out Alarm" runat="server" meta:resourcekey="Literal14Resource1"></asp:literal></h5>
                    <asp:radiobutton ID="out_alarm_enable" style="margin: 5px 10px 10px 0px;" runat="server"  GroupName="GROUP10" meta:resourcekey="out_alarm_enableResource1"></asp:radiobutton>
                    <asp:literal runat="server" text ="Enable" meta:resourcekey="LiteralResource25"></asp:literal>
                    <asp:radiobutton ID="out_alarm_disable" style="margin: 5px 10px 10px 0px;" runat="server"  GroupName="GROUP10" meta:resourcekey="out_alarm_disableResource1"></asp:radiobutton>
                       <asp:literal runat="server" text ="Disable" meta:resourcekey="LiteralResource26"></asp:literal>
                </div>
                       </div>
                   
                </div>
<!-- fine riga -->
<!-- riga -->
                    <asp:placeholder runat="server" ID="enable_water_meter_input">
                <div class="row-fluid">
               	<div class="span2">
                       <div class="control-group">
                           <h5 style="padding-top:10px"><asp:literal ID = "Literal15"  text="Water Meter Input" runat="server" meta:resourcekey="Literal15Resource1"></asp:literal></h5>
                    <asp:radiobutton ID="water_meter_input_stop" style="margin: 5px 10px 10px 0px;" runat="server"  GroupName="GROUP11" meta:resourcekey="water_meter_input_stopResource1"></asp:radiobutton>
                    <asp:literal runat="server" text ="Stop" meta:resourcekey="LiteralResource27"></asp:literal>
                    <asp:radiobutton ID="water_meter_input_no" style="margin: 5px 10px 10px 0px;" runat="server"  GroupName="GROUP11" meta:resourcekey="water_meter_input_noResource1"></asp:radiobutton>
                       <asp:literal runat="server" text ="No" meta:resourcekey="LiteralResource28"></asp:literal>
                </div>
                       </div>
 	            <div class="span2">
                       <div id="riga_water_meter_input_hr" class="control-group">
                        <h5 style="padding-top:10px"><asp:literal ID = "Literal19"  text="Hour" runat="server" meta:resourcekey="Literal19Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_water_meter_input_hr" onblur="javascript: Changed_channel( 'value_water_meter_input_hr','riga_water_meter_input_hr',9, 0,0 );" class="span12"  runat="server" MaxLength="2" meta:resourcekey="value_water_meter_input_hrResource1" ></asp:textbox>
                </div>
                       </div>
 <div class="span2">
                       <div id="riga_water_meter_input_min" class="control-group">
                        <h5 style="padding-top:10px"><asp:literal ID = "Literal20"  text="Min" runat="server" meta:resourcekey="Literal20Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_water_meter_input_min" onblur="javascript: Changed_channel( 'value_water_meter_input_min','riga_water_meter_input_min',59, 0,0 );" class="span12"  runat="server" MaxLength="2" meta:resourcekey="value_water_meter_input_minResource1" ></asp:textbox>
                       </div>                   
                </div>
</div>
                        </asp:placeholder>
<!-- fine riga -->
<!-- riga -->
<asp:placeholder runat="server" ID="enable_water_meter_bleed">
                <div class="row-fluid">
               	<div class="span2">
                       <div class="control-group">
                           <h5 style="padding-top:10px"><asp:literal ID = "Literal16"  text="Water Meter Bleed" runat="server" meta:resourcekey="Literal16Resource1"></asp:literal></h5>
                    <asp:radiobutton ID="water_meter_bleed_stop" style="margin: 5px 10px 10px 0px;" runat="server"  GroupName="GROUP12" meta:resourcekey="water_meter_bleed_stopResource1"></asp:radiobutton>
                    <asp:literal runat="server" text ="Stop" meta:resourcekey="LiteralResource29"></asp:literal>
                    <asp:radiobutton ID="water_meter_bleed_no" style="margin: 5px 10px 10px 0px;" runat="server"  GroupName="GROUP12" meta:resourcekey="water_meter_bleed_noResource1"></asp:radiobutton>
                       <asp:literal runat="server" text ="No" meta:resourcekey="LiteralResource30"></asp:literal>
                </div>
                       </div>
 	            <div class="span2">
                       <div id="riga_water_meter_bleed_hr" class="control-group">
                        <h5 style="padding-top:10px"><asp:literal ID = "Literal22"  text="Hour" runat="server" meta:resourcekey="Literal22Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_water_meter_bleed_hr" onblur="javascript: Changed_channel( 'value_water_meter_bleed_hr','riga_water_meter_bleed_hr',9, 0,0 );" class="span12"  runat="server" MaxLength="1" meta:resourcekey="value_water_meter_bleed_hrResource1" ></asp:textbox>
                </div>
                       </div>
 <div class="span2">
                       <div id="riga_water_meter_bleed_min" class="control-group">
                        <h5 style="padding-top:10px"><asp:literal ID = "Literal23"  text="Min" runat="server" meta:resourcekey="Literal23Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_water_meter_bleed_min" onblur="javascript: Changed_channel( 'value_water_meter_bleed_min','riga_water_meter_bleed_min',59, 0,0 );" class="span12"  runat="server" MaxLength="2" meta:resourcekey="value_water_meter_bleed_minResource1" ></asp:textbox>
                       </div>                   
                </div>
                    </div>
    </asp:placeholder>
<!-- fine riga -->
<!-- riga -->
<asp:placeholder runat="server" ID="enable_concentration_factor">
                <div class="row-fluid">
               	<div class="span2">
                       <div class="control-group">
                           <h5 style="padding-top:10px"><asp:literal ID = "Literal18"  text="Concentration Factor" runat="server" meta:resourcekey="Literal18Resource1"></asp:literal></h5>
                    <asp:radiobutton ID="concentration_factor_off" style="margin: 5px 10px 10px 0px;" runat="server"  GroupName="GROUP12" meta:resourcekey="concentration_factor_offResource1"></asp:radiobutton>
                    <asp:literal runat="server" text ="Off" meta:resourcekey="LiteralResource31"></asp:literal>
                    <asp:radiobutton ID="concentration_factor_on" style="margin: 5px 10px 10px 0px;" runat="server"  GroupName="GROUP12" meta:resourcekey="concentration_factor_onResource1"></asp:radiobutton>
                       <asp:literal runat="server" text ="ON" meta:resourcekey="LiteralResource32"></asp:literal>
                </div>
                       </div>
 	            <div class="span2">
                       <div id="riga_concentration_factor_ratio" class="control-group">
                        <h5 style="padding-top:10px"><asp:literal ID = "Literal25"  text="Ratio WMI/WMB" runat="server" meta:resourcekey="Literal25Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_concentration_factor_ratio" onblur="javascript: Changed_channel( 'value_concentration_factor_ratio','riga_concentration_factor_ratio',10, 0,1 );" class="span12"  runat="server" MaxLength="3" meta:resourcekey="value_concentration_factor_ratioResource1" ></asp:textbox>
                </div>
                       </div>
 <div class="span2">
                       <div id="riga_concentration_factor_tolerance" class="control-group">
                        <h5 style="padding-top:10px"><asp:literal ID = "Literal26"  text="Tolerance" runat="server" meta:resourcekey="Literal26Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_concentration_factor_tolerance" onblur="javascript: Changed_channel( 'value_concentration_factor_tolerance','riga_concentration_factor_tolerance',10, 0,0 );" class="span12"  runat="server" MaxLength="2" meta:resourcekey="value_concentration_factor_toleranceResource1" ></asp:textbox>
                       </div>                   
                </div>
<div class="span2">
                       <div id="riga_concentration_factor_delay" class="control-group">
                        <h5 style="padding-top:10px"><asp:literal ID = "Literal27"  text="Delay" runat="server" meta:resourcekey="Literal27Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_concentration_factor_Delay" onblur="javascript: Changed_channel( 'value_concentration_factor_Delay','riga_concentration_factor_delay',60, 0,0 );" class="span12"  runat="server" MaxLength="2" meta:resourcekey="value_concentration_factor_DelayResource1" ></asp:textbox>
                       </div>                   
                </div>				
</div>	
    </asp:placeholder>
<!-- fine riga -->
    </div>
                    </div>
</div>
<!-- tab 2 stop-->
            </div>
                    <div id="salva" class="btn-primary">
                   <b class="btn-primary btn-icon glyphicons ok"><asp:button runat="server" ID="save_alarmtower_new" class="btn-primary" data-layout="center" data-type="confirm" data-toggle="notyfy" text="Salva e carica i dati" Font-Bold="True" meta:resourcekey="save_alarmtower_newResource1" /><i></i></b>

        </div>

        </div>
    </div>
    <script type="text/javascript" src="tower/validator_tower_alarm.js"></script>
                                <script type="text/javascript" src="common/validator_general_notify.js"></script>
<script src="theme/scripts/demo/notifications.js"></script>

</form>
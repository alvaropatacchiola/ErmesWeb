<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="inhibitor.aspx.vb" Inherits="ermes_web_20.inhibitor" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>

<form id="form" runat="server"  method="post" action="tower/inhibitor.aspx">
    <h3><asp:literal runat="server" text ="Inhibitor Tower" ID="message_channel" meta:resourcekey="message_channelResource1"></asp:literal></h3>
    <div class="innerLR">
        <div class="box-generic">
            <div class="tab-content">
            <!-- tab 1 start-->
			<div class="tab-pane active" id="tab_ld_sp1_1">
                <div  class="box-generic">
                                 <!-- riga -->
                <div class="row-fluid">
               	<div class="span3">
              <h5 style="padding-top:10px"><asp:literal ID = "Label7"  text="Feed & Bleed" runat="server" meta:resourcekey="Label7Resource1"></asp:literal></h5>

                    <asp:radiobutton ID="enable_feed_bleed" style="margin: 5px 10px 10px 0px;" runat="server"  GroupName="GROUP1" meta:resourcekey="enable_feed_bleedResource1"></asp:radiobutton>
                    <asp:literal runat="server" text ="Enable" meta:resourcekey="LiteralResource1"></asp:literal>

                </div>
                </div>
                 <!-- fine riga -->
                 <!-- riga -->
                <div class="row-fluid">
               	<div class="span3">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal1"  text="Feed % Bleed" runat="server" meta:resourcekey="Literal1Resource1"></asp:literal></h5>

                    <asp:radiobutton ID="enable_feed_bleed_percent" style="margin: 5px 10px 10px 0px;" runat="server"  GroupName="GROUP1" meta:resourcekey="enable_feed_bleed_percentResource1"></asp:radiobutton>
                    <asp:literal runat="server" text ="Enable" meta:resourcekey="LiteralResource2"></asp:literal>

                </div>
                </div>
                 <!-- fine riga -->

                                <!-- riga -->
<div id ="enable_value_feed_bleed_percent">
                <div class="row-fluid">
               	<div class="span3">
                       <div id="riga_feed_bleed_percent" class="control-group">
                           <h5 style="padding-top:10px"><asp:literal ID = "Literal4"  text="Percentage (min)" runat="server" meta:resourcekey="Literal4Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_feed_bleed_percent" onblur="javascript: Changed_channel( 'value_feed_bleed_percent','riga_feed_bleed_percent',100, 0,0 );" class="span12"  runat="server" MaxLength="3" meta:resourcekey="value_feed_bleed_percentResource1" ></asp:textbox>
                </div>
                       </div>

                   
                </div>
</div>
                 <!-- fine riga -->
<!-- riga -->
                <div class="row-fluid">
               	<div class="span3">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal2"  text="Feed % Time" runat="server" meta:resourcekey="Literal2Resource1"></asp:literal></h5>

                    <asp:radiobutton ID="enable_feed_time_percent" style="margin: 5px 10px 10px 0px;" runat="server"  GroupName="GROUP1" meta:resourcekey="enable_feed_time_percentResource1"></asp:radiobutton>
                    <asp:literal runat="server" text ="Enable" meta:resourcekey="LiteralResource3"></asp:literal>

                </div>
                </div>
<!-- fine riga -->
<div id ="enable_value_feed_time_percent">
<!-- riga -->

                <div class="row-fluid">
               	<div class="span3">
                       <div id="riga_feed_time_percent_hr" class="control-group">
                           <h5 style="padding-top:10px"><asp:literal ID = "Literal3"  text="Cycle Time (Hr)" runat="server" meta:resourcekey="Literal3Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_feed_time_percent_hr" onblur="javascript: Changed_channel( 'value_feed_time_percent_hr','riga_feed_time_percent_hr',99, 0,0 );" class="span12"  runat="server" MaxLength="2" meta:resourcekey="value_feed_time_percent_hrResource1" ></asp:textbox>
                </div>
                       </div>

                   
                </div>
                 <!-- fine riga -->
<!-- riga -->

                <div class="row-fluid">
               	<div class="span3">
                       <div id="riga_feed_time_percent_min" class="control-group">
                           <h5 style="padding-top:10px"><asp:literal ID = "Literal5"  text="Cycle Time (min)" runat="server" meta:resourcekey="Literal5Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_feed_time_percent_min" onblur="javascript: Changed_channel( 'value_feed_time_percent_min','riga_feed_time_percent_min',59, 0,0 );" class="span12"  runat="server" MaxLength="2" meta:resourcekey="value_feed_time_percent_minResource1" ></asp:textbox>
                </div>
                       </div>

                   
                </div>
                 <!-- fine riga -->
<!-- riga -->

                <div class="row-fluid">
               	<div class="span3">
                       <div id="riga_feed_time_percent_percent" class="control-group">
                           <h5 style="padding-top:10px"><asp:literal ID = "Literal6"  text="Percentage (%)" runat="server" meta:resourcekey="Literal6Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_feed_time_percent_percent" onblur="javascript: Changed_channel( 'value_feed_time_percent_percent','riga_feed_time_percent_percent',100, 0,0 );" class="span12"  runat="server" MaxLength="3" meta:resourcekey="value_feed_time_percent_percentResource1" ></asp:textbox>
                </div>
                       </div>

                   
                </div>
                 <!-- fine riga -->
</div>
<!-- riga -->
                <div class="row-fluid">
               	<div class="span3">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal7"  text="Water Meter" runat="server" meta:resourcekey="Literal7Resource1"></asp:literal></h5>

                    <asp:radiobutton ID="enable_water_meter" style="margin: 5px 10px 10px 0px;" runat="server"  GroupName="GROUP1" meta:resourcekey="enable_water_meterResource1"></asp:radiobutton>
                    <asp:literal runat="server" text ="Enable" meta:resourcekey="LiteralResource4"></asp:literal>

                </div>
                </div>
<!-- fine riga -->
<div id ="enable_value_water_meter">
<!-- riga -->

                <div class="row-fluid">
               	<div class="span3">
                       <div id="riga_water_meter_hr" class="control-group">
                           <h5 style="padding-top:10px"><asp:literal ID = "Literal8"  text="Cycle Time (Min)" runat="server" meta:resourcekey="Literal8Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_water_meter_hr" onblur="javascript: Changed_channel( 'value_water_meter_hr','riga_water_meter_hr',99, 0,0 );" class="span12"  runat="server" MaxLength="2" meta:resourcekey="value_water_meter_hrResource1" ></asp:textbox>
                </div>
                       </div>

                   
                </div>
                 <!-- fine riga -->
<!-- riga -->

                <div class="row-fluid">
               	<div class="span3">
                       <div id="riga_water_meter_min" class="control-group">
                           <h5 style="padding-top:10px"><asp:literal ID = "Literal9"  text="Cycle Time (Sec)" runat="server" meta:resourcekey="Literal9Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_water_meter_min" onblur="javascript: Changed_channel( 'value_water_meter_min','riga_water_meter_min',59, 0,0 );" class="span12"  runat="server" MaxLength="2" meta:resourcekey="value_water_meter_minResource1" ></asp:textbox>
                </div>
                       </div>

                   
                </div>
                 <!-- fine riga -->
<!-- riga -->

                <div class="row-fluid">
               	<div class="span3">
                       <div id="riga_water_meter_counter" class="control-group">
                           <h5 style="padding-top:10px"><asp:literal ID = "Literal10"  text="Counter" runat="server" meta:resourcekey="Literal10Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_water_meter_counter" onblur="javascript: Changed_channel( 'value_water_meter_counter','riga_water_meter_counter',9999, 0,0 );" class="span12"  runat="server" MaxLength="4" meta:resourcekey="value_water_meter_counterResource1" ></asp:textbox>
                </div>
                       </div>

                   
                </div>
                 <!-- fine riga -->
    </div>
<!-- riga -->
                <div class="row-fluid">
               	<div class="span3">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal11"  text="Water Meter PPM" runat="server" meta:resourcekey="Literal11Resource1"></asp:literal></h5>

                    <asp:radiobutton ID="enable_water_meter_ppm" style="margin: 5px 10px 10px 0px;" runat="server"  GroupName="GROUP1" meta:resourcekey="enable_water_meter_ppmResource1"></asp:radiobutton>
                    <asp:literal runat="server" text ="Enable" meta:resourcekey="LiteralResource5"></asp:literal>

                </div>
                </div>
<!-- fine riga -->
<div id ="enable_value_water_meter_ppm">
<!-- riga -->

                <div class="row-fluid">
               	<div class="span3">
                       <div id="riga_water_meter_ppm_ppm" class="control-group">
                           <h5 style="padding-top:10px"><asp:literal ID = "Literal12"  text="PPM" runat="server"></asp:literal></h5>
                       <asp:textbox ID="value_water_meter_ppm_ppm" onblur="javascript: Changed_channel( 'value_water_meter_ppm_ppm','riga_water_meter_ppm_ppm',max_us, 0,0 );" class="span12"  runat="server" MaxLength="4" meta:resourcekey="value_water_meter_ppm_ppmResource1" ></asp:textbox>
                </div>
                       </div>

                   
                </div>
                 <!-- fine riga -->
<!-- riga -->

                <div class="row-fluid">
               	<div class="span3">
                       <div id="riga_water_meter_ppm_percent" class="control-group">
                           <h5 style="padding-top:10px"><asp:literal ID = "Literal13"  text="Concentration (%)" runat="server" meta:resourcekey="Literal13Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_water_meter_ppm_percent" onblur="javascript: Changed_channel( 'value_water_meter_ppm_percent','riga_water_meter_ppm_percent',100, 0,0 );" class="span12"  runat="server" MaxLength="3" meta:resourcekey="value_water_meter_ppm_percentResource1" ></asp:textbox>
                </div>
                       </div>

                   
                </div>
                 <!-- fine riga -->
<!-- riga -->
                <div class="row-fluid">
               	<div class="span3">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal14"  text="Mode" runat="server" meta:resourcekey="Literal14Resource1"></asp:literal></h5>
                    <asp:radiobutton ID="enable_water_meter_ppm_cc_st" style="margin: 5px 10px 10px 0px;" runat="server"  GroupName="GROUP2" Checked="True" meta:resourcekey="enable_water_meter_ppm_cc_stResource1"></asp:radiobutton>
                    <asp:literal runat="server" text ="cc/st" meta:resourcekey="LiteralResource6"></asp:literal>
                    <asp:radiobutton ID="enable_water_meter_ppm_l_h" style="margin: 5px 10px 10px 0px;" runat="server"  GroupName="GROUP2" meta:resourcekey="enable_water_meter_ppm_l_hResource1"></asp:radiobutton>
                    <asp:literal runat="server" text ="l/h" meta:resourcekey="LiteralResource7"></asp:literal>

                </div>
                </div>
<!-- fine riga -->

    <!-- riga -->
<div id="div_enable_water_meter_ppm_cc_st">
    <div class="row-fluid">
               	<div class="span3">
                       <div id="riga_water_meter_ppm_cc_st" class="control-group">
                           <h5 style="padding-top:10px"><asp:literal ID = "Literal15"  text="cc/st" runat="server" meta:resourcekey="Literal15Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_water_meter_ppm_cc_st" onblur="javascript: Changed_channel( 'value_water_meter_ppm_cc_st','riga_water_meter_ppm_cc_st',30, 0,2 );" class="span12"  runat="server" MaxLength="5" meta:resourcekey="value_water_meter_ppm_cc_stResource1" ></asp:textbox>
                </div>
                       </div>

                   
                </div>
 </div>
       <!-- fine riga -->
     <!-- riga -->
<div id="div_enable_water_meter_ppm_l_h">
    <div class="row-fluid">
               	<div class="span3">
                       <div id="riga_water_meter_ppm_l_h" class="control-group">
                           <h5 style="padding-top:10px"><asp:literal ID = "Literal16"  text="l/h" runat="server" meta:resourcekey="Literal16Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_water_meter_ppm_l_h" onblur="javascript: Changed_channel( 'value_water_meter_ppm_l_h','riga_water_meter_ppm_l_h',999, 0,0 );" class="span12"  runat="server" MaxLength="3" meta:resourcekey="value_water_meter_ppm_l_hResource1" ></asp:textbox>
                </div>
                       </div>

                   
                </div>
 </div>
       <!-- fine riga -->

    </div>
<!-- tab 1 stop-->
<div id="salva" class="btn-primary">
                   <b class="btn-primary btn-icon glyphicons ok"><asp:button runat="server" ID="save_inhibitortower_new" class="btn-primary" data-layout="center" data-type="confirm" data-toggle="notyfy" text="Salva e carica i dati" Font-Bold="True" meta:resourcekey="save_inhibitortower_newResource1" /><i></i></b>
                </div>
                </div>
            </div>
        <script type="text/javascript" src="tower/validator_tower_inhibitor.js"></script>
                <script type="text/javascript" src="common/validator_general_notify.js"></script>
<script src="theme/scripts/demo/notifications.js"></script>

        </div>
        </div>
</form>
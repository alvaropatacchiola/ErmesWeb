<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="setpoint_ch2.aspx.vb" Inherits="ermes_web_20.setpoint_ch2" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>

<form id="form" runat="server"  method="post" action="tower/setpoint_ch2.aspx">
    <h3><asp:literal runat="server" text ="Setpoint CH2" ID="message_channel" meta:resourcekey="message_channelResource1"></asp:literal></h3>
    <div class="innerLR">
        <div class="box-generic">
            <div class="tab-content">
                            <!-- tab 1 start-->
			<div class="tab-pane active" id="tab_ld_sp1_1">
                <div  class="box-generic">
<!-- riga -->

                <div class="row-fluid">
               	<div class="span3">
              <h5 style="padding-top:10px"><asp:literal ID = "Label7"  text="Digital D1" runat="server" meta:resourcekey="Label7Resource1"></asp:literal></h5>

                    <asp:radiobutton ID="disable_setpoint_ch2" style="margin: 5px 10px 10px 0px;" runat="server"  GroupName="GROUP1" meta:resourcekey="disable_setpoint_ch2Resource1"></asp:radiobutton>
                    <asp:literal runat="server" text ="Disable" meta:resourcekey="LiteralResource1"></asp:literal>
                    <asp:radiobutton ID="on_off_setpoint_ch2" style="margin: 5px 10px 10px 0px;" runat="server"  GroupName="GROUP1" meta:resourcekey="on_off_setpoint_ch2Resource1"></asp:radiobutton>
                    <asp:literal runat="server" text ="On/Off" meta:resourcekey="LiteralResource2"></asp:literal>
                    <asp:radiobutton ID="pwm_setpoint_ch2" style="margin: 5px 10px 10px 0px;" runat="server"  GroupName="GROUP1" meta:resourcekey="pwm_setpoint_ch2Resource1"></asp:radiobutton>
                    <asp:literal runat="server" text ="PWM" meta:resourcekey="LiteralResource3"></asp:literal>

                </div>
 	
                   
                </div>

<!-- fine riga -->
<!-- riga -->
<div id="enable_digital">
                <div class="row-fluid">
               	<div class="span2">
                       <div id="riga_setpoint_on" class="control-group">
                           <div id="label_on">
                           <h5 style="padding-top:10px"><asp:literal ID = "Literal2"  text="ON " runat="server" meta:resourcekey="Literal2Resource1"></asp:literal></h5>
                               </div>
                           <div id="label_on_pwm">
                           <h5 style="padding-top:10px"><asp:literal ID = "Literal5"  text="mg/l" runat="server" meta:resourcekey="Literal5Resource1"></asp:literal></h5>
                               </div>
                       <asp:textbox ID="value_setpoint_on" onblur="javascript: Changed_channel( 'value_setpoint_on','riga_setpoint_on',max_ch_value, min_ch_value,max_fix_value );" class="span12"  runat="server" MaxLength="5" meta:resourcekey="value_setpoint_onResource1" ></asp:textbox>
                </div>
                       </div>
 	<div class="span2">
                       <div id="riga_setpoint_on_percent" class="control-group">
                           <h5 style="padding-top:10px"><asp:literal ID = "Literal3"  text="%" runat="server" meta:resourcekey="Literal3Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_setpoint_on_percent" onblur="javascript: Changed_channel( 'value_setpoint_on_percent','riga_setpoint_on_percent',100, 0,0 );" class="span12"  runat="server" MaxLength="3" meta:resourcekey="value_setpoint_on_percentResource1" ></asp:textbox>
                </div>
                       </div>
                   
                </div>

<!-- fine riga -->
<!-- riga -->

                <div class="row-fluid">
               	<div class="span2">
                       <div id="riga_setpoint_off" class="control-group">
                           <div id="label_off">
                           <h5 style="padding-top:10px"><asp:literal ID = "Literal1"  text="OFF " runat="server" meta:resourcekey="Literal1Resource1"></asp:literal></h5>
                            </div>
                           <div id="label_off_pwm">
                           <h5 style="padding-top:10px"><asp:literal ID = "Literal6"  text="mg/l" runat="server" meta:resourcekey="Literal6Resource1"></asp:literal></h5>
                            </div>
                       <asp:textbox ID="value_setpoint_off" onblur="javascript: Changed_channel( 'value_setpoint_off','riga_setpoint_off',max_ch_value, min_ch_value,max_fix_value );" class="span12"  runat="server" MaxLength="5" meta:resourcekey="value_setpoint_offResource1" ></asp:textbox>
                </div>
                       </div>
 	<div class="span2">
                       <div id="riga_setpoint_off_percent" class="control-group">
                           <h5 style="padding-top:10px"><asp:literal ID = "Literal4"  text="%" runat="server" meta:resourcekey="Literal4Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_setpoint_off_percent" onblur="javascript: Changed_channel( 'value_setpoint_off_percent','riga_setpoint_off_percent',100, 0,0 );" class="span12"  runat="server" MaxLength="3" meta:resourcekey="value_setpoint_off_percentResource1" ></asp:textbox>
                </div>
                       </div>
                   
                </div>
</div>
<!-- fine riga -->
<!-- riga -->

                <div class="row-fluid">
               	<div class="span3">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal7"  text="Proportional P1" runat="server" meta:resourcekey="Literal7Resource1"></asp:literal></h5>

                    <asp:radiobutton ID="disable_setpoint_p1_ch2" style="margin: 5px 10px 10px 0px;" runat="server"  GroupName="GROUP2" meta:resourcekey="disable_setpoint_p1_ch2Resource1"></asp:radiobutton>
                    <asp:literal runat="server" text ="Disable" meta:resourcekey="LiteralResource4"></asp:literal>
                    <asp:radiobutton ID="enable_setpoint_p1_ch2" style="margin: 5px 10px 10px 0px;" runat="server"  GroupName="GROUP2" meta:resourcekey="enable_setpoint_p1_ch2Resource1"></asp:radiobutton>
                    <asp:literal runat="server" text ="Enable" meta:resourcekey="LiteralResource5"></asp:literal>

                </div>
 	
                   
                </div>

<!-- fine riga -->
<!-- riga -->
<div id="enable_proportional">
                <div class="row-fluid">
               	<div class="span2">
                       <div id="riga_setpoint_p1_1" class="control-group">
                           <h5 style="padding-top:10px"><asp:literal ID = "Literal10"  text="mg/l" runat="server" meta:resourcekey="Literal10Resource1"></asp:literal></h5>

						   <asp:textbox ID="value_setpoint_p1_1" onblur="javascript: Changed_channel( 'value_setpoint_p1_1','riga_setpoint_p1_1',max_ch_value, min_ch_value,max_fix_value );" class="span12"  runat="server" MaxLength="5" meta:resourcekey="value_setpoint_p1_1Resource1" ></asp:textbox>
                </div>
                       </div>
 	<div class="span2">
                       <div id="riga_setpoint_p1_1_pm" class="control-group">
                           <h5 style="padding-top:10px"><asp:literal ID = "Literal11"  text="pulse/minute" runat="server" meta:resourcekey="Literal11Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_setpoint_p1_1_pm" onblur="javascript: Changed_channel( 'value_setpoint_p1_1_pm','riga_setpoint_p1_1_pm',180, 0,0 );" class="span12"  runat="server" MaxLength="3" meta:resourcekey="value_setpoint_p1_1_pmResource1" ></asp:textbox>
                </div>
                       </div>
                   
                </div>

<!-- fine riga -->
<!-- riga -->
                <div class="row-fluid">
               	<div class="span2">
                       <div id="riga_setpoint_p1_2" class="control-group">
                           <h5 style="padding-top:10px"><asp:literal ID = "Literal12"  text="mg/l" runat="server" meta:resourcekey="Literal12Resource1"></asp:literal></h5>

						   <asp:textbox ID="value_setpoint_p1_2" onblur="javascript: Changed_channel( 'value_setpoint_p1_2','riga_setpoint_p1_2',max_ch_value, min_ch_value,max_fix_value );" class="span12"  runat="server" MaxLength="5" meta:resourcekey="value_setpoint_p1_2Resource1" ></asp:textbox>
                </div>
                       </div>
 	<div class="span2">
                       <div id="riga_setpoint_p1_2_pm" class="control-group">
                           <h5 style="padding-top:10px"><asp:literal ID = "Literal13"  text="Pulse/minute" runat="server" meta:resourcekey="Literal13Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_setpoint_p1_2_pm" onblur="javascript: Changed_channel( 'value_setpoint_p1_2_pm','riga_setpoint_p1_2_pm',180, 0,0 );" class="span12"  runat="server" MaxLength="3" meta:resourcekey="value_setpoint_p1_2_pmResource1" ></asp:textbox>
                </div>
                       </div>
                   
                </div>

</div>
<!-- fine riga -->
                    <!-- riga -->
<asp:placeholder runat="server" ID="enable_working" >
                <div class="row-fluid">
               	<div class="span3">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal8"  text="Working Mode" runat="server" meta:resourcekey="Literal8Resource1"></asp:literal></h5>

                    <asp:radiobutton ID="work_constant" style="margin: 5px 10px 10px 0px;" runat="server"  GroupName="GROUP3" meta:resourcekey="work_constantResource1"></asp:radiobutton>
                    <asp:literal runat="server" text ="Constant" meta:resourcekey="LiteralResource6"></asp:literal>
                    <asp:radiobutton ID="work_timer_biocide" style="margin: 5px 10px 10px 0px;" runat="server"  GroupName="GROUP3" meta:resourcekey="work_timer_biocideResource1"></asp:radiobutton>
                    <asp:literal runat="server" text ="Timer Biocide1" meta:resourcekey="LiteralResource7"></asp:literal>

                </div>
 	
                   
                </div>
</asp:placeholder>
<!-- fine riga -->
    </div>
<!-- tab 1 stop-->
                <div id="salva" class="btn-primary">
                   <b class="btn-primary btn-icon glyphicons ok"><asp:button runat="server" ID="save_setpointtower_new" class="btn-primary" data-layout="center" data-type="confirm" data-toggle="notyfy" text="Salva e carica i dati" Font-Bold="True" meta:resourcekey="save_setpointtower_newResource1" /><i></i></b>
                </div>
                </div>
            <script type="text/javascript" src="tower/validator_tower_setpoint.js"></script>
                                <script type="text/javascript" src="common/validator_general_notify.js"></script>
<script src="theme/scripts/demo/notifications.js"></script>

            </div>
        </div>
</form>
<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="bleed_boiler.aspx.vb" Inherits="ermes_web_20.bleed_boiler" %>
<form id="form" runat="server"  method="post" action="tower/bleed_boiler.aspx">
    <h3><asp:literal runat="server" text ="Bleed Tower" ID="message_channel"></asp:literal></h3>
    <div class="innerLR" >
        <div class="box-generic">
            <div class="tab-content">
                            <!-- tab 1 start-->
			<div class="tab-pane active" id="tab_ld_sp1_1">
<div  class="box-generic" id="Div1"><!--blocco4-->
<!-- riga -->

                <div class="row-fluid">
                    <h5><asp:literal runat="server" text ="Working Mode" ID="Literal16"></asp:literal></h5>
               	<div class="span4">
                           <div class="controlli_box"> 
                            <asp:radiobutton ID="continuous" runat="server"  GroupName="GROUP1" ></asp:radiobutton>
                       </div>
                        <div class="controlli_testo_box" > 
                                <asp:literal runat="server" text ="Continuous" ></asp:literal>
                        </div>
                           <div class="controlli_box"> 
                            <asp:radiobutton ID="timed" runat="server"  GroupName="GROUP1" ></asp:radiobutton>
                       </div>
                        <div class="controlli_testo_box" > 
                                <asp:literal runat="server" text ="Timed" ></asp:literal>
                        </div>
                           <div class="controlli_box"> 
                            <asp:radiobutton ID="sample_hold" runat="server"  GroupName="GROUP1" ></asp:radiobutton>
                       </div>
                        <div class="controlli_testo_box" > 
                                <asp:literal runat="server" text ="SampleHold" ></asp:literal>
                        </div>
                       
                </div>
                       </div>
 	
                   
                </div>

<!-- fine riga -->



    </div><!--end blocco4-->
<div  class="box-generic" id="id_timed"><!--blocco2-->
<!-- riga -->

                <div class="row-fluid">
                    <h5><asp:literal runat="server" text ="Timed" ID="Literal13"></asp:literal></h5>
               	<div class="span4">
                       <div id="riga_valve_open_time_timed" class="control-group">
                           <h5 style="padding-top:10px"><asp:literal ID = "Literal7"  text="Valve Open Time (Second)" runat="server" ></asp:literal></h5>
                       <asp:textbox ID="value_valve_open_time_timed" onblur="javascript: Changed_channel( 'value_valve_open_time_timed','riga_valve_open_time_timed',999, 0,0 );" class="span12"  runat="server" MaxLength="3"  ></asp:textbox>
                </div>
                       </div>
 	<div class="span4">
                       <div id="riga_sample_timed" class="control-group">
                           <h5 style="padding-top:10px"><asp:literal ID = "Literal8"  text="Sample(Min)" runat="server" ></asp:literal></h5>
                       <asp:textbox ID="value_sample_timed" onblur="javascript: Changed_channel( 'value_sample_timed','riga_sample_timed',99, 0,0 );" class="span12"  runat="server" MaxLength="2"  ></asp:textbox>
                </div>
                       </div>
                   
                </div>

<!-- fine riga -->



    </div><!--end blocco2-->
<div  class="box-generic" id="id_sample_hold"><!--blocco3-->
<!-- riga -->

                <div class="row-fluid">
                    <h5><asp:literal runat="server" text ="Sample Hold" ID="Literal9"></asp:literal></h5>
               	<div class="span4">
                       <div id="riga_valve_open_time_sample" class="control-group">
                           <h5 style="padding-top:10px"><asp:literal ID = "Literal10"  text="Valve Open Time (Second)" runat="server" ></asp:literal></h5>
                       <asp:textbox ID="value_valve_open_time_sample" onblur="javascript: Changed_channel( 'value_valve_open_time_sample','riga_valve_open_time_sample',999, 0,0 );" class="span12"  runat="server" MaxLength="3"  ></asp:textbox>
                </div>
                       </div>
 	<div class="span4">
                       <div id="riga_sample_sample" class="control-group">
                           <h5 style="padding-top:10px"><asp:literal ID = "Literal11"  text="Sample(Min)" runat="server" ></asp:literal></h5>
                       <asp:textbox ID="value_sample_sample" onblur="javascript: Changed_channel( 'value_sample_sample','riga_sample_sample',99, 0,0 );" class="span12"  runat="server" MaxLength="2"  ></asp:textbox>
                </div>
                       </div>
                   
                </div>

<!-- fine riga -->
<!-- riga -->

                <div class="row-fluid">
               	<div class="span4">
                       <div id="riga_hold_sample" class="control-group">
                           <h5 style="padding-top:10px"><asp:literal ID = "Literal14"  text="Hold (Second)" runat="server" ></asp:literal></h5>
                       <asp:textbox ID="value_hold_sample" onblur="javascript: Changed_channel( 'value_hold_sample','riga_hold_sample',999, 0,0 );" class="span12"  runat="server" MaxLength="3"  ></asp:textbox>
                </div>
                       </div>
 	<div class="span4">
                       <div id="riga_blowdown_sample" class="control-group">
                           <h5 style="padding-top:10px"><asp:literal ID = "Literal15"  text="Blowdown(Min)" runat="server" ></asp:literal></h5>
                       <asp:textbox ID="value_blowdown_sample" onblur="javascript: Changed_channel( 'value_blowdown_sample','riga_blowdown_sample',999, 0,0 );" class="span12"  runat="server" MaxLength="3"  ></asp:textbox>
                </div>
                       </div>
                   
                </div>

<!-- fine riga -->



    </div><!--end blocco3-->
<div  class="box-generic" id="id_continuous"><!--blocco1-->
    <h5><asp:literal runat="server" text ="Bleed" ID="Literal12"></asp:literal></h5>
<!-- riga -->

                <div class="row-fluid">
               	<div class="span2">
                       <div id="riga_bleed_setpoint" class="control-group">
                           <h5 style="padding-top:10px"><asp:literal ID = "Literal4"  text="Setpoint" runat="server" ></asp:literal></h5>
                       <asp:textbox ID="value_bleed_setpoint" onblur="javascript: Changed_channel( 'value_bleed_setpoint','riga_bleed_setpoint',max_us, 0,0 );" class="span12"  runat="server" MaxLength="4"  ></asp:textbox>
                </div>
                       </div>
 	<div class="span2">
                       <div id="riga_bleed_deadband" class="control-group">
                           <h5 style="padding-top:10px"><asp:literal ID = "Literal5"  text="DeadBand" runat="server" ></asp:literal></h5>
                       <asp:textbox ID="value_bleed_deadband" onblur="javascript: Changed_channel( 'value_bleed_deadband','riga_bleed_deadband',999, -999,0 );" class="span12"  runat="server" MaxLength="4"  ></asp:textbox>
                </div>
                       </div>
                   
                </div>

<!-- fine riga -->
<!-- riga -->

                <div class="row-fluid">
               	<div class="span2">
                       <div id="riga_bleed_time_limit_hr" class="control-group">
                           <h5 style="padding-top:10px"><asp:literal ID = "Literal6"  text="Time Limit (Hour)" runat="server" ></asp:literal></h5>
                       <asp:textbox ID="value_bleed_time_limit_hr" onblur="javascript: Changed_channel( 'value_bleed_time_limit_hr','riga_bleed_time_limit_hr',99, 0,0 );" class="span12"  runat="server" MaxLength="2" ></asp:textbox>
                </div>
                       </div>
 	<div class="span2">
                       <div id="riga_bleed_time_limit_min" class="control-group">
                           <h5 style="padding-top:10px"><asp:literal ID = "Literal17"  text="Time Limit (min)" runat="server" ></asp:literal></h5>
                       <asp:textbox ID="value_bleed_time_limit_min" onblur="javascript: Changed_channel( 'value_bleed_time_limit_min','riga_bleed_time_limit_min',59, 0,0 );" class="span12"  runat="server" MaxLength="2"  ></asp:textbox>
                </div>
                       </div>
                   
                </div>

<!-- fine riga -->
<!-- riga -->
<asp:PlaceHolder runat="server" ID="aquacare" Visible="False">
                <div class="row-fluid">
               	<div class="span2">
                       <div id="riga_bleed_delay_hr" class="control-group">
                           <h5 style="padding-top:10px"><asp:literal ID = "Literal18"  text="Delay (Hour)" runat="server"></asp:literal></h5>
                       <asp:textbox ID="value_bleed_delay_hr" onblur="javascript: Changed_channel( 'value_bleed_delay_hr','riga_bleed_delay_hr',99, 0,0 );" class="span12"  runat="server" MaxLength="2" ></asp:textbox>
                </div>
                       </div>
 	<div class="span2">
                       <div id="riga_bleed_delay_min" class="control-group">
                           <h5 style="padding-top:10px"><asp:literal ID = "Literal19"  text="Delay (min)" runat="server"></asp:literal></h5>
                       <asp:textbox ID="value_bleed_delay_min" onblur="javascript: Changed_channel( 'value_bleed_delay_min','riga_bleed_delay_min',59, 0,0 );" class="span12"  runat="server" MaxLength="2"></asp:textbox>
                </div>
                       </div>
                   
                </div>
    </asp:PlaceHolder>
<!-- fine riga -->

    </div><!--end blocco1-->



<!-- tab 1 stop-->
                <div id="salva" class="btn-primary">
                   <b class="btn-primary btn-icon glyphicons ok"><asp:button runat="server" ID="save_bleedtower_new" class="btn-primary" data-layout="center" data-type="confirm" data-toggle="notyfy" text="Salva e carica i dati" Font-Bold="True"/><i></i></b>
                </div>
                </div>
            <script type="text/javascript" src="tower/validator_tower_bleed_boiler.js"></script>
                                <script type="text/javascript" src="common/validator_general_notify.js"></script>
<script src="theme/scripts/demo/notifications.js"></script>

            </div>
        </div>
</form>
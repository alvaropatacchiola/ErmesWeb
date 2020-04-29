<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="bleed_ldt.aspx.vb" Inherits="ermes_web_20.bleed_ldt" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>

<form id="form" runat="server"  method="post" action="LDTower/bleed_ldt.aspx">             <!-- CAMBIARE L'INDIRIZZO DEL FILE!!!! -->   

    <h3><asp:literal runat="server" text ="Bleed CoolTrol" ID="message_channel" meta:resourcekey="message_channelResource1"></asp:literal></h3>
    <div class="innerLR">
        <div class="box-generic">
            <div class="tab-content">
                            <!-- tab 1 start-->
			<div class="tab-pane active" id="tab_ld_sp1_1">
                <div  class="box-generic">
<!-- riga -->

                <div class="row-fluid">
               	<div class="span2">
                       <div id="riga_bleed_setpoint" class="control-group">
                           <h5 style="padding-top:10px"><asp:literal ID = "Literal4"  text="Setpoint" runat="server" meta:resourcekey="Literal4Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_bleed_setpoint" onblur="javascript: Changed_channel( 'value_bleed_setpoint','riga_bleed_setpoint',max_us, 0,0 );" class="span12"  runat="server" MaxLength="4" meta:resourcekey="value_bleed_setpointResource1" ></asp:textbox>
                </div>
                       </div>
 	<div class="span2">
                       <div id="riga_bleed_deadband" class="control-group">
                           <h5 style="padding-top:10px"><asp:literal ID = "Literal1"  text="DeadBand" runat="server" meta:resourcekey="Literal1Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_bleed_deadband" onblur="javascript: Changed_channel( 'value_bleed_deadband','riga_bleed_deadband',999, -999,0 );" class="span12"  runat="server" MaxLength="4" meta:resourcekey="value_bleed_deadbandResource1" ></asp:textbox>
                </div>
                       </div>
                   
                </div>

<!-- fine riga -->
<!-- riga -->

                <div class="row-fluid">
               	<div class="span2">
                       <div id="riga_bleed_time_limit_hr" class="control-group">
                           <h5 style="padding-top:10px"><asp:literal ID = "Literal2"  text="Time Limit (Hour)" runat="server" meta:resourcekey="Literal2Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_bleed_time_limit_hr" onblur="javascript: Changed_channel( 'value_bleed_time_limit_hr','riga_bleed_time_limit_hr',99, 0,0 );" class="span12"  runat="server" MaxLength="2" meta:resourcekey="value_bleed_time_limit_hrResource1" ></asp:textbox>
                    </div>
                </div>
 	                <div class="span2">
                       <div id="riga_bleed_time_limit_min" class="control-group">
                           <h5 style="padding-top:10px"><asp:literal ID = "Literal3"  text="Time Limit (min)" runat="server" meta:resourcekey="Literal3Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_bleed_time_limit_min" onblur="javascript: Changed_channel( 'value_bleed_time_limit_min','riga_bleed_time_limit_min',59, 0,0 );" class="span12"  runat="server" MaxLength="2" meta:resourcekey="value_bleed_time_limit_minResource1" ></asp:textbox>
                </div>
                       </div>
                   
                </div>

<!-- fine riga -->
<!-- riga -->

                <div class="row-fluid">

 	            <div class="span2">
                       <div id="riga_bleed_delay_min" class="control-group">
                           <h5 style="padding-top:10px"><asp:literal ID = "Literal6"  text="Delay (min)" runat="server" meta:resourcekey="Literal6Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_bleed_delay_min" onblur="javascript: Changed_channel( 'value_bleed_delay_min','riga_bleed_delay_min',59, 0,0 );" class="span12"  runat="server" MaxLength="2" meta:resourcekey="value_bleed_delay_minResource1" ></asp:textbox>
                </div>
                       </div>
                   
                </div>
<!-- fine riga -->

    </div>
<!-- tab 1 stop-->
                <div id="salva" class="btn-primary">
                   <b class="btn-primary btn-icon glyphicons ok"><asp:button runat="server" ID="save_bleed_ldtower_new" class="btn-primary" data-layout="center" data-type="confirm" data-toggle="notyfy" text="Salva e carica i dati" Font-Bold="True" meta:resourcekey="save_bleed_ldtower_newResource1" /><i></i></b>
                </div>
                </div>


            <script type="text/javascript" src="LDTower/validator_bleed_ldt.js"></script>
             <script type="text/javascript" src="common/validator_general_notify.js"></script>
<script src="theme/scripts/demo/notifications.js"></script>

            </div>
        </div>
</form>
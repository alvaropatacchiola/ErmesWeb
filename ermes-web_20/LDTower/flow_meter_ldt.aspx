<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="flow_meter_ldt.aspx.vb" Inherits="ermes_web_20.flow_meter_ldt" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>

<form id="form" runat="server"  method="post" action="LDTower/flow_meter_ldt.aspx">               <!-- CAMBIARE L'INDIRIZZO DEL FILE!!!! -->   

    <h3><asp:literal runat="server" text ="Water Meter CoolTrol" ID="message_channel" meta:resourcekey="message_channelResource1"></asp:literal></h3>
    <div class="innerLR">
        <div class="box-generic">
            <div class="tab-content">
<!-- tab 1 start-->
			<div class="tab-pane active" id="tab_ld_sp1_1">
                <div  class="box-generic">
<!-- riga -->

        <!---------------------- PRIMO WATERMETER ------------------------------------>

                <div class="row-fluid">
               	<div class="span3">
                       <div id="riga_watermeter1" class="control-group">
                           <h5 style="padding-top:10px"><asp:literal ID = "Literal4"  text="Water Meter 1" runat="server" meta:resourcekey="Literal4Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_watermeter1" onblur="javascript: Changed_channel( 'value_watermeter1','riga_watermeter1',400, 0,1 );" class="span12"  runat="server" MaxLength="5" meta:resourcekey="value_watermeter1Resource1" ></asp:textbox>
                </div>
                       </div>
 	<div class="span3">
                       <div id="riga_watermeter1_pulse" class="control-group">
                           <h5 style="padding-top:10px"><asp:literal ID = "Label7"  text="Water Meter 1 Unit" runat="server" meta:resourcekey="Label7Resource1"></asp:literal></h5>
<asp:placeholder runat="server" ID="enable_litri_wm1">
                    <asp:radiobutton ID="watermeter1_litri_pulse" style="margin: 5px 10px 10px 0px;" runat="server"  GroupName="GROUP1" meta:resourcekey="watermeter1_litri_pulseResource1"></asp:radiobutton>
                    <asp:literal runat="server" text ="Litre / Pulse" meta:resourcekey="LiteralResource1"></asp:literal>
                    <asp:radiobutton ID="watermeter1_pulse_litre" style="margin: 5px 10px 10px 0px;" runat="server"  GroupName="GROUP1" meta:resourcekey="watermeter1_pulse_litreResource1"></asp:radiobutton>
                       <asp:literal runat="server" text ="Pulse / Litre" meta:resourcekey="LiteralResource2"></asp:literal>
</asp:placeholder>
<asp:placeholder runat="server" ID="enable_galloni_wm1">
                    <asp:radiobutton ID="watermeter1_galloni_pulse" style="margin: 5px 10px 10px 0px;" runat="server"  GroupName="GROUP2" meta:resourcekey="watermeter1_galloni_pulseResource1"></asp:radiobutton>
                    <asp:literal runat="server" text ="Gallons / Pulse" meta:resourcekey="LiteralResource3"></asp:literal>
                    <asp:radiobutton ID="watermeter1_pulse_galloni" style="margin: 5px 10px 10px 0px;" runat="server"  GroupName="GROUP2" meta:resourcekey="watermeter1_pulse_galloniResource1"></asp:radiobutton>
                       <asp:literal runat="server" text ="Pulse / Gallons" meta:resourcekey="LiteralResource4"></asp:literal>
</asp:placeholder>

                </div>
                       </div>
                   
                </div>

<!-- fine riga -->


        <!---------------------- SECONDO WATERMETER ------------------------------------>
<!-- riga -->

                <div class="row-fluid">
               	<div class="span3">
                       <div id="riga_watermeter2" class="control-group">
                           <h5 style="padding-top:10px"><asp:literal ID = "Literal6"  text="Water Meter 2" runat="server" meta:resourcekey="Literal6Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_watermeter2" onblur="javascript: Changed_channel( 'value_watermeter2','riga_watermeter2',400, 0,1 );" class="span12"  runat="server" MaxLength="5" meta:resourcekey="value_watermeter2Resource1" ></asp:textbox>
                </div>
                       </div>
 	<div class="span3">
                       <div id="riga_watermeter2_pulse" class="control-group">
                           <h5 style="padding-top:10px"><asp:literal ID = "Literal7"  text="Water Meter 2 Unit" runat="server" meta:resourcekey="Literal7Resource1"></asp:literal></h5>
                <asp:placeholder runat="server" ID="enable_litri_wm2">
                    <asp:radiobutton ID="watermeter2_litri_pulse" style="margin: 5px 10px 10px 0px;" runat="server"  GroupName="GROUP3" meta:resourcekey="watermeter2_litri_pulseResource1"></asp:radiobutton>
                    <asp:literal runat="server" text ="Litre / Pulse" meta:resourcekey="LiteralResource5"></asp:literal>
                    <asp:radiobutton ID="watermeter2_pulse_litre" style="margin: 5px 10px 10px 0px;" runat="server"  GroupName="GROUP3" meta:resourcekey="watermeter2_pulse_litreResource1"></asp:radiobutton>
                       <asp:literal runat="server" text ="Pulse / Litre" meta:resourcekey="LiteralResource6"></asp:literal>
                </asp:placeholder>
                <asp:placeholder runat="server" ID="enable_galloni_wm2">
                    <asp:radiobutton ID="watermeter2_galloni_pulse" style="margin: 5px 10px 10px 0px;" runat="server"  GroupName="GROUP4" meta:resourcekey="watermeter2_galloni_pulseResource1"></asp:radiobutton>
                    <asp:literal runat="server" text ="Gallons / Pulse" meta:resourcekey="LiteralResource7"></asp:literal>
                    <asp:radiobutton ID="watermeter2_pulse_galloni" style="margin: 5px 10px 10px 0px;" runat="server"  GroupName="GROUP4" meta:resourcekey="watermeter2_pulse_galloniResource1"></asp:radiobutton>
                       <asp:literal runat="server" text ="Pulse / Gallons" meta:resourcekey="LiteralResource8"></asp:literal>
                </asp:placeholder>

                </div>
                       </div>
                   
                </div>

<!-- fine riga -->

    </div>
<!-- tab 1 stop-->
                <div id="salva" class="btn-primary">
                   <b class="btn-primary btn-icon glyphicons ok"><asp:button runat="server" ID="save_flow_ldtower_new" class="btn-primary" data-layout="center" data-type="confirm" data-toggle="notyfy" text="Salva e carica i dati" Font-Bold="True" meta:resourcekey="save_flow_ldtower_newResource1" /><i></i></b>
                </div>
                </div>

                 
            <script type="text/javascript" src="LDTower/validator_flow_meter_ldt.js"></script>
                                <script type="text/javascript" src="common/validator_general_notify.js"></script>
<script src="theme/scripts/demo/notifications.js"></script>

            </div>
        </div>
</form>
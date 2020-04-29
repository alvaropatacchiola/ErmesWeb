<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="flow_meter.aspx.vb" Inherits="ermes_web_20.flow_meter" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>

<form id="form" runat="server"  method="post" action="tower/flow_meter.aspx">
    <h3><asp:literal runat="server" text ="Flow Meter Tower" ID="message_channel" meta:resourcekey="message_channelResource1"></asp:literal></h3>
    <div class="innerLR">
        <div class="box-generic">
            <div class="tab-content">
<!-- tab 1 start-->
			<div class="tab-pane active" id="tab_ld_sp1_1">
                <div  class="box-generic">
<!-- riga -->

                <div class="row-fluid">
               	<div class="span3">
                       <div id="riga_flowmeter_input" class="control-group">
                           <h5 style="padding-top:10px"><asp:literal ID = "Literal4"  text="Flow Meter Input" runat="server" meta:resourcekey="Literal4Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_flowmeter_input" onblur="javascript: Changed_channel( 'value_flowmeter_input','riga_flowmeter_input',400, 0,1 );" class="span12"  runat="server" MaxLength="5" meta:resourcekey="value_flowmeter_inputResource1" ></asp:textbox>
                </div>
                       </div>
 	<div class="span3">
                       <div id="riga_flowmeter_pulse" class="control-group">
                           <h5 style="padding-top:10px"><asp:literal ID = "Label7"  text="Flow Meter Input Unit" runat="server" meta:resourcekey="Label7Resource1"></asp:literal></h5>
<asp:placeholder runat="server" ID="enable_litri">
                    <asp:radiobutton ID="flowmeter_litri_pulse" style="margin: 5px 10px 10px 0px;" runat="server"  GroupName="GROUP1" meta:resourcekey="flowmeter_litri_pulseResource1"></asp:radiobutton>
                    <asp:literal runat="server" text ="Litre / Pulse" meta:resourcekey="LiteralResource1"></asp:literal>
                    <asp:radiobutton ID="flowmeter_pulse_litre" style="margin: 5px 10px 10px 0px;" runat="server"  GroupName="GROUP1" meta:resourcekey="flowmeter_pulse_litreResource1"></asp:radiobutton>
                       <asp:literal runat="server" text ="Pulse / Litre" meta:resourcekey="LiteralResource2"></asp:literal>
</asp:placeholder>
<asp:placeholder runat="server" ID="enable_galloni">
                    <asp:radiobutton ID="flowmeter_galloni_pulse" style="margin: 5px 10px 10px 0px;" runat="server"  GroupName="GROUP2" meta:resourcekey="flowmeter_galloni_pulseResource1"></asp:radiobutton>
                    <asp:literal runat="server" text ="Gallons / Pulse" meta:resourcekey="LiteralResource3"></asp:literal>
                    <asp:radiobutton ID="flowmeter_pulse_galloni" style="margin: 5px 10px 10px 0px;" runat="server"  GroupName="GROUP2" meta:resourcekey="flowmeter_pulse_galloniResource1"></asp:radiobutton>
                       <asp:literal runat="server" text ="Pulse / Gallons" meta:resourcekey="LiteralResource4"></asp:literal>
</asp:placeholder>

                </div>
                       </div>
                   
                </div>

<!-- fine riga -->
<!-- riga -->
<asp:placeholder runat="server" ID="bleed_enable">
                <div class="row-fluid">
               	<div class="span3">
                       <div id="riga_flowmeter_bleed" class="control-group">
                           <h5 style="padding-top:10px"><asp:literal ID = "Literal1"  text="Flow Meter Bleed" runat="server" meta:resourcekey="Literal1Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_flowmeter_bleed" onblur="javascript: Changed_channel( 'value_flowmeter_bleed','riga_flowmeter_bleed',400, 0,1 );" class="span12"  runat="server" MaxLength="5" meta:resourcekey="value_flowmeter_bleedResource1" ></asp:textbox>
                </div>
                       </div>
 	<div class="span3">
                       <div id="riga_flowmeter_pulse_bleed" class="control-group">
                           <h5 style="padding-top:10px"><asp:literal ID = "Literal2"  text="Flow Meter Bleed Unit" runat="server" meta:resourcekey="Literal2Resource1"></asp:literal></h5>
<asp:placeholder runat="server" ID="enable_litri_bleed">
                    <asp:radiobutton ID="flowmeter_litri_pulse_bleed" style="margin: 5px 10px 10px 0px;" runat="server"  GroupName="GROUP3" meta:resourcekey="flowmeter_litri_pulse_bleedResource1"></asp:radiobutton>
                    <asp:literal runat="server" text ="Litre / Pulse" meta:resourcekey="LiteralResource5"></asp:literal>
                    <asp:radiobutton ID="flowmeter_pulse_litre_bleed" style="margin: 5px 10px 10px 0px;" runat="server"  GroupName="GROUP3" meta:resourcekey="flowmeter_pulse_litre_bleedResource1"></asp:radiobutton>
                       <asp:literal runat="server" text ="Pulse / Litre" meta:resourcekey="LiteralResource6"></asp:literal>
</asp:placeholder>
<asp:placeholder runat="server" ID="enable_galloni_bleed">
                    <asp:radiobutton ID="flowmeter_galloni_pulse_bleed" style="margin: 5px 10px 10px 0px;" runat="server"  GroupName="GROUP4" meta:resourcekey="flowmeter_galloni_pulse_bleedResource1"></asp:radiobutton>
                    <asp:literal runat="server" text ="Gallons / Pulse" meta:resourcekey="LiteralResource7"></asp:literal>
                    <asp:radiobutton ID="flowmeter_pulse_galloni_bleed" style="margin: 5px 10px 10px 0px;" runat="server"  GroupName="GROUP4" meta:resourcekey="flowmeter_pulse_galloni_bleedResource1"></asp:radiobutton>
                       <asp:literal runat="server" text ="Pulse / Gallons" meta:resourcekey="LiteralResource8"></asp:literal>
</asp:placeholder>

                </div>
                       </div>
                   
                </div>
</asp:placeholder>
<!-- fine riga -->

    </div>
<!-- tab 1 stop-->
                <div id="salva" class="btn-primary">
                   <b class="btn-primary btn-icon glyphicons ok"><asp:button runat="server" ID="save_flowtower_new" class="btn-primary" data-layout="center" data-type="confirm" data-toggle="notyfy" text="Salva e carica i dati" Font-Bold="True" meta:resourcekey="save_flowtower_newResource1" /><i></i></b>
                </div>
                </div>
            <script type="text/javascript" src="tower/validator_tower_flowmeter.js"></script>
                                <script type="text/javascript" src="common/validator_general_notify.js"></script>
<script src="theme/scripts/demo/notifications.js"></script>

            </div>
        </div>
</form>
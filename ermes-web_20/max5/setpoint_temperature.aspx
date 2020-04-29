<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="setpoint_temperature.aspx.vb" Inherits="ermes_web_20.setpoint_temperature" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>



<form id="form" runat="server" method="post" action="max5/setpoint_temperature.aspx">


    <h3><asp:literal runat="server" text ="SetPoint Temperature" ID="calibration_channel" meta:resourcekey="calibration_channelResource1"></asp:literal></h3>
    <div class="innerLR">
        <div class="box-generic">
            <div class="tab-content">
                <div  class="box-generic">
<!-- riga -->
                <div id ="riga_temperature_on_id" class="row-fluid">
               	<div class="span2">
                    <h5 style="padding-top:10px" class="control-label"><asp:literal ID = "Label12"  text="Temperature °C" runat="server" meta:resourcekey="Label12Resource1"></asp:literal></h5>
                    <asp:textbox ID="value_temperature_on_id" class="span12"  runat="server"  onblur="javascript: Changed_channel( 'value_temperature_on_id','riga_temperature_on_id',max_ch_value, min_ch_value,max_fix_value );" MaxLength="4" meta:resourcekey="value_temperature_on_idResource1"></asp:textbox>
               	</div>
<asp:placeholder runat="server">
               	<div class="span2">
                       
                    <h5 style="padding-top:10px" class="control-label"><asp:literal ID = "Literal1"  text="Temperature °C" runat="server" ></asp:literal></h5>
                    <asp:textbox ID="value_temperature_off_id" class="span12"  runat="server"  onblur="javascript: Changed_channel( 'value_temperature_on_id','riga_temperature_on_id',max_ch_value, min_ch_value,max_fix_value );" MaxLength="4" meta:resourcekey="value_temperature_on_idResource1"></asp:textbox>
               	</div>
</asp:placeholder>
                </div>
 <!-- fine riga -->

<!-- riga -->
                <div id ="div1" class="row-fluid">
               	<div class="span2">
                <h5 style="padding-top:10px"><asp:literal ID = "label46"  text="Out Relay" runat="server" meta:resourcekey="label46Resource1"></asp:literal></h5>
                 <asp:dropdownlist ID="index_relay_temperature" class="span12" runat="server" meta:resourcekey="index_relay_temperatureResource1">
                     <asp:ListItem Value="0" meta:resourcekey="ListItemResource1">X</asp:ListItem>
                     <asp:ListItem Value="1" meta:resourcekey="ListItemResource2">Relay 1</asp:ListItem>
                     <asp:ListItem Value="2" meta:resourcekey="ListItemResource3">Relay 2</asp:ListItem>
                     <asp:ListItem Value="3" meta:resourcekey="ListItemResource4">Relay 3</asp:ListItem>
                     <asp:ListItem Value="4" meta:resourcekey="ListItemResource5">Relay 4</asp:ListItem>
                     <asp:ListItem Value="5" meta:resourcekey="ListItemResource6">Relay 5</asp:ListItem>
                     <asp:ListItem Value="6" meta:resourcekey="ListItemResource7">Relay 6</asp:ListItem>
                    </asp:dropdownlist>

               	</div>
                </div>
 <!-- fine riga -->
                                  
                </div>
                </div>
                </div>

                       <div id="salva" class="btn-primary">
                   <b class="btn-primary btn-icon glyphicons ok"><asp:button runat="server" ID="save_temperature_new" class="btn-primary" data-layout="center" data-type="confirm" data-toggle="notyfy"  text="Salva e carica i dati" Font-Bold="True" meta:resourcekey="save_temperature_newResource1" /><i></i></b>
                </div>

            </div>

    <script type="text/javascript" src="max5/validator_max5_temperature.js"></script>
        <script type="text/javascript" src="common/validator_general_notify.js"></script>
    <script src="theme/scripts/demo/notifications.js"></script>

    </form>

<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="units_ldt.aspx.vb" Inherits="ermes_web_20.units_ldt" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>

<form id="form" runat="server"  method="post" action="LDTower/units_ldt.aspx">         

    <h3><asp:literal runat="server" text ="Unit CoolTrol" ID="message_channel" meta:resourcekey="message_channelResource1"></asp:literal></h3>
    <div class="innerLR">
        <div class="box-generic">
            <div class="tab-content">
<!-- tab 1 start-->
			<div class="tab-pane active" id="tab_ld_sp1_1">
                <div  class="box-generic">
<!-- riga -->

                <div class="row-fluid">
              
 	<div class="span3">
                       <div id="riga_unit" class="control-group">
                           <h5 style="padding-top:10px"><asp:literal ID = "Label7"  text="Unit" runat="server" meta:resourcekey="Label7Resource1" ></asp:literal></h5>

                    <asp:radiobutton ID="unit_is" style="margin: 5px 10px 10px 0px;" runat="server"  GroupName="GROUP1" meta:resourcekey="unit_isResource1" ></asp:radiobutton>
                    <asp:literal runat="server" text ="IS" meta:resourcekey="LiteralResource1" ></asp:literal>
                    <asp:radiobutton ID="unit_us" style="margin: 5px 10px 10px 0px;" runat="server"  GroupName="GROUP1" meta:resourcekey="unit_usResource1" ></asp:radiobutton>
                       <asp:literal runat="server" text ="US" meta:resourcekey="LiteralResource2" ></asp:literal>


                </div>
                       </div>
                   
                </div>

<!-- fine riga -->
<!-- riga -->
                <div class="row-fluid">
               	
 	            <div class="span3">
                       <div id="riga_measure_unit" class="control-group">
                           <h5 style="padding-top:10px"><asp:literal ID = "Literal7"  text="Measure Unit" runat="server" meta:resourcekey="Literal7Resource1" ></asp:literal></h5>

                    <asp:radiobutton ID="measure_unit_us" style="margin: 5px 10px 10px 0px;" runat="server"  GroupName="GROUP3" meta:resourcekey="measure_unit_usResource1" ></asp:radiobutton>
                    <asp:literal runat="server" text ="uS" meta:resourcekey="LiteralResource5"></asp:literal>
                    <asp:radiobutton ID="measure_unit_ppm" style="margin: 5px 10px 10px 0px;" runat="server"  GroupName="GROUP3" meta:resourcekey="measure_unit_ppmResource1"></asp:radiobutton>
                       <asp:literal runat="server" text ="PPM" meta:resourcekey="LiteralResource3" ></asp:literal>


                    </div>
                </div>
                   
                </div>

<!-- fine riga -->

    </div>
<!-- tab 1 stop-->
                <div id="salva" class="btn-primary">
                   <b class="btn-primary btn-icon glyphicons ok"><asp:button runat="server" ID="save_unit_ldtower_new" class="btn-primary" data-layout="center" data-type="confirm" data-toggle="notyfy" text="Salva e carica i dati" Font-Bold="True" meta:resourcekey="save_unit_ldtower_newResource1" /><i></i></b>
                </div>
                </div>
            <script type="text/javascript" src="LDTower/validator_units_ldt.js"></script>
                                <script type="text/javascript" src="common/validator_general_notify.js"></script>
<script src="theme/scripts/demo/notifications.js"></script>

            </div>
        </div>
</form>
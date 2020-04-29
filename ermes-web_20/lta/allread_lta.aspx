<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="allread_lta.aspx.vb" Inherits="ermes_web_20.allread_lta" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>
<form id="form" runat="server" method="post" action="lta/allread_lta.aspx">
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
              <h5 style="padding-top:10px"><asp:literal ID = "Label7"  text="Mode Alarm" runat="server" meta:resourcekey="Label7Resource1"></asp:literal></h5>
<div class="controlli_box">
                    <asp:radiobutton ID="alarm_temp_show"  runat="server"  GroupName="GROUP1" meta:resourcekey="alarm_temp_showResource1"></asp:radiobutton>
</div>
<div class="controlli_testo_box">
                    <asp:literal runat="server" text ="Show Temp." meta:resourcekey="LiteralResource1"></asp:literal>
</div>
<div class="controlli_box">
                    <asp:radiobutton ID="alarm_temp_hide"  runat="server"  GroupName="GROUP1" meta:resourcekey="alarm_temp_reverseResource1"></asp:radiobutton>
</div>
<div class="controlli_testo_box">
                       <asp:literal runat="server" text ="Hide Temp." meta:resourcekey="LiteralResource2"></asp:literal>
</div>
<div class="controlli_box">
                    <asp:radiobutton ID="alarm_dioxide_show"  runat="server"  GroupName="GROUP2" meta:resourcekey="alarm_dioxide_showResource1"></asp:radiobutton>
</div>
<div class="controlli_testo_box">
                       <asp:literal runat="server" text ="Show ClO2 Air" meta:resourcekey="LiteralResource3"></asp:literal>
</div>
                       <div class="controlli_box">
                    <asp:radiobutton ID="alarm_dioxide_hide"  runat="server"  GroupName="GROUP2" meta:resourcekey="alarm_dioxide_hideResource1"></asp:radiobutton>
</div>
<div class="controlli_testo_box">
                       <asp:literal runat="server" text ="Hide ClO2 Air" meta:resourcekey="LiteralResource4"></asp:literal>
</div>

                </div>
                </div>
                 <!-- fine riga -->
                                <!-- riga -->
<div id ="enable_value_alarm_flow_time">
                <div class="row-fluid">
               	<div class="span3">
                       <div id="riga1_alarm_temp" class="control-group">
                           <h5 style="padding-top:10px"><asp:literal ID = "Literal4"  text="Temp. Value:" runat="server" meta:resourcekey="Literal4Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_alarm_temp" onblur="javascript: Changed_channel( 'value_alarm_temp','riga1_alarm_temp',200, 0,0 );" class="span12"  runat="server" MaxLength="4" meta:resourcekey="value_alarm_tempResource1" ></asp:textbox>
                </div>
                       </div>

                   
                </div>
</div>

                    <div id ="Div1">
                <div class="row-fluid">
               	<div class="span3">
                       <div id="riga1_alarm_dioxide" class="control-group">
                           <h5 style="padding-top:10px"><asp:literal ID = "Literal1"  text="Value [ppm]:" runat="server" meta:resourcekey="Literal4Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_alarm_dioxide" onblur="javascript: Changed_channel( 'value_alarm_dioxide','riga1_alarm_dioxide',2, 0,2 );" class="span12"  runat="server" MaxLength="4" meta:resourcekey="value_alarm_dioxideResource1" ></asp:textbox>
                </div>
                       </div>

                   
                </div>
</div>

                 <!-- fine riga -->

<!-- tab 1 stop-->


                  
             <div id="salva" class="btn-primary">
                   <b class="btn-primary btn-icon glyphicons ok"><asp:button runat="server" ID="save_allreadlta_new" class="btn-primary" data-layout="center" data-type="confirm" data-toggle="notyfy" text="Salva e carica i dati" Font-Bold="True" meta:resourcekey="save_allreadlta_newResource1" /><i></i></b>
                </div>
            </div>
        </div>
    <script type="text/javascript" src="lta/validator_lta_allread.js"></script>
            <script type="text/javascript" src="common/validator_general_notify.js"></script>
<script src="theme/scripts/demo/notifications.js"></script>

    </form>

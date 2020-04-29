
<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="flowall2_ld4.aspx.vb" Inherits="ermes_web_20.flowall2_ld4" %>

<form id="form" runat="server" method="post" action="ld4/flowall2_ld4.aspx">
    <h3><asp:literal runat="server" text ="Flow Alarm" ID="message_channel" meta:resourcekey="message_channelResource1"></asp:literal></h3>
    <div class="innerLR">
        <div class="box-generic">
            <div class="box-generic">
                <div class="tab-content">
                 <!-- tab 1 start-->
			<div class="tab-pane active" id="tab_ld_sp1_1">
                <div  class="box-generic">
                                 <!-- riga -->
                
                 <!-- fine riga -->
                                <!-- riga -->
<div id ="enable_value_alarm_flow_time">
                <div class="row-fluid">
               	<div class="span3">
                       <div id="riga1_alarm_flow_metri" class="control-group">
                           <h5 style="padding-top:10px"><asp:literal ID = "Literal4"  text="m3h value:" runat="server" meta:resourcekey="Literal4Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_alarm_flow_metri" onblur="javascript: Changed_channel( 'value_alarm_flow_metri','riga1_alarm_flow_metri',5999, 0,0 );" class="span12"  runat="server" MaxLength="6" meta:resourcekey="value_alarm_flow_metriResource1" ></asp:textbox>
                </div>
                       </div>

                   
                </div>
</div>
                 <!-- fine riga -->

<!-- tab 1 stop-->
                </div>
             </div>
             <div id="salva" class="btn-primary">
                   <b class="btn-primary btn-icon glyphicons ok"><asp:button runat="server" ID="save_flowall_ld4_new" class="btn-primary" data-layout="center" data-type="confirm" data-toggle="notyfy" text="Salva e carica i dati" Font-Bold="True" meta:resourcekey="save_flowall_ld4_newResource1" /><i></i></b>
                </div>
            </div>
        </div>
    <script type="text/javascript" src="ld4/validator_ld4_flowall.js"></script>
            <script type="text/javascript" src="common/validator_general_notify.js"></script>
<script src="theme/scripts/demo/notifications.js"></script>

    </form>

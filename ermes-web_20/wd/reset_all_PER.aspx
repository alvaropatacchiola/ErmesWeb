<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="reset_all_PER.aspx.vb" Inherits="ermes_web_20.reset_all_PER" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>
<form id="form" runat="server" method="post" action="wd/reset_all_PER.aspx">
    <h3><asp:literal runat="server" text ="Reset Alarm" ID="message_channel" meta:resourcekey="message_channelResource1"></asp:literal></h3>
    <div class="innerLR">
        <div class="box-generic">
            <div class="box-generic">
                <div class="tab-content">
                 <!-- tab 1 start-->
			<div class="tab-pane active" id="tab_ld_sp1_1">
                <div  class="box-generic">
                                 <!-- riga -->
                <div class="row-fluid">
               	<div class="span3">
              <h5 style="padding-top:10px"><asp:literal ID = "Label7"  text="Mode Flow" runat="server" meta:resourcekey="Label7Resource1"></asp:literal></h5>

                    <asp:radiobutton ID="alarm_reset" style="margin: 5px 10px 10px 0px;" runat="server"  GroupName="GROUP1" meta:resourcekey="alarm_resetResource1"></asp:radiobutton>
                    <asp:literal runat="server" text ="Yes" meta:resourcekey="LiteralResource1"></asp:literal>
                    <asp:radiobutton ID="alarm_reset_no" style="margin: 5px 10px 10px 0px;" runat="server"  GroupName="GROUP1" meta:resourcekey="alarm_reset_noResource1"></asp:radiobutton>
                       <asp:literal runat="server" text ="No" meta:resourcekey="LiteralResource2"></asp:literal>
                    

                </div>
                </div>
                 <!-- fine riga -->
                               

<!-- tab 1 stop-->
                </div>
             </div>
             <div id="salva" class="btn-primary">
                   <b class="btn-primary btn-icon glyphicons ok"><asp:button runat="server" ID="save_reset_new" class="btn-primary" data-layout="center" data-type="confirm" data-toggle="notyfy" text="Salva e carica i dati" Font-Bold="True" meta:resourcekey="save_reset_newResource1" /><i></i></b>
                </div>
            </div>
        </div>
    <script type="text/javascript" src="wd/validator_reset_alarm.js"></script>
                        <script type="text/javascript" src="common/validator_general_notify.js"></script>
<script src="theme/scripts/demo/notifications.js"></script>

    </form>
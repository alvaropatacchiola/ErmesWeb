<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="resetTot.aspx.vb" Inherits="ermes_web_20.resetTot"  culture="auto" uiculture="auto" meta:resourcekey="PageResource1"%>
<form id="form" runat="server" method="post" action="lta/resetTot.aspx">
    <h3><asp:literal runat="server" text ="Reset Totaliser" ID="message_channel" meta:resourcekey="message_channelResource1" ></asp:literal></h3>
       <div class="innerLR">
        <div class="box-generic">
        </div>
       </div>
    <div id="salva" class="btn-primary">
                   <b class="btn-primary btn-icon glyphicons ok"><asp:button runat="server" ID="save_resetTot_newlta" class="btn-primary" data-layout="center" data-type="confirm" data-toggle="notyfy" text="Salva e carica i dati" Font-Bold="True" meta:resourcekey="save_message_newltaResource1"  /><i></i></b>
    </div>
    <script type="text/javascript" src="lta/validator_resetTot.js"></script>
     <script type="text/javascript" src="common/validator_general_notify.js"></script>
    <script src="theme/scripts/demo/notifications.js"></script>
    </form>

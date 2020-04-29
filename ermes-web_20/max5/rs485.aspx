<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="rs485.aspx.vb" Inherits="ermes_web_20.rs485" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>

<form id="form" runat="server" method="post" action="max5/rs485.aspx">
<h3><asp:literal runat="server" text ="RS485 Setup Max5" ID="rs485_channel" meta:resourcekey="rs485_channelResource1"></asp:literal></h3>
    <div class="innerLR">
        <div class="box-generic">
            <div class="tab-content">
                <div  class="box-generic">

                    <!-- riga -->
                    <div id ="div_ch1" class="row-fluid">
                        	<div class="span3">
                                <h5 style="padding-top:10px"><asp:literal ID = "Label7"  text="ID 485" runat="server" meta:resourcekey="Label7Resource1"></asp:literal></h5>
                                <asp:literal ID = "Literal1"  text="01" runat="server" meta:resourcekey="Literal1Resource1"></asp:literal>
                            </div>

                        </div>
                    <!-- fine riga -->
                    <!-- riga -->
                    <div id ="div1" class="row-fluid">
                        	<div class="span3">
                                <h5 style="padding-top:10px"><asp:literal ID = "Literal2"  text="Label" runat="server" meta:resourcekey="Literal2Resource1"></asp:literal></h5>
                                <asp:textbox ID="label_485" class="span12"  runat="server" style=" position: relative; z-index: 100000; top: 0px; left: 0px;" MaxLength="16" meta:resourcekey="label_485Resource1"></asp:textbox>
                            </div>

                        </div>
                    <!-- fine riga -->


                    </div>
                </div>

                                   <div id="salva" class="btn-primary">
                   <b class="btn-primary btn-icon glyphicons ok"><asp:button runat="server" ID="save_rs485_new" class="btn-primary" data-layout="center" data-type="confirm" data-toggle="notyfy"  text="Salva e carica i dati" Font-Bold="True" meta:resourcekey="save_rs485_newResource1" /><i></i></b>


            </div>
        </div>
        <script type="text/javascript" src="max5/validator_max5_rs485.js"></script>
         <script type="text/javascript" src="common/validator_general_notify.js"></script>
    <script src="theme/scripts/demo/notifications.js"></script>
    </form>

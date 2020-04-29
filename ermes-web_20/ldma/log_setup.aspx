<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="log_setup.aspx.vb" Inherits="ermes_web_20.log_setup2" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>
<form id="form" runat="server" method="post" action="ldma/log_setup.aspx">
<h3><asp:literal runat="server" text ="Data Logger LD mA" ID="data_logger_channel" meta:resourcekey="data_logger_channelResource1" ></asp:literal></h3>
    <div class="innerLR">
        <div class="box-generic">
            <div class="tab-content">
                <div  class="box-generic">

                    <!-- riga -->
                    <div id ="div1" class="row-fluid">
                        	<div class="span3">
                                <h5 style="padding-top:10px"><asp:literal ID = "Literal2"  text="Interval" runat="server" meta:resourcekey="Literal2Resource1" ></asp:literal></h5>
                                 <asp:dropdownlist ID="value_level_msg" class="span12" runat="server" meta:resourcekey="value_level_msgResource1">
                                     <asp:ListItem Value="0" meta:resourcekey="ListItemResource1" >15 Minutes</asp:ListItem>
                                     <asp:ListItem Value="1" meta:resourcekey="ListItemResource2" >1 Hour</asp:ListItem>
                                     <asp:ListItem Value="2" meta:resourcekey="ListItemResource3" >6 Hour</asp:ListItem>
                                     <asp:ListItem Value="3" meta:resourcekey="ListItemResource4" >12 Hour</asp:ListItem>
                                     <asp:ListItem Value="4" meta:resourcekey="ListItemResource5" >1 Day</asp:ListItem>
                                    </asp:dropdownlist>

                            </div>

                        </div>
                    <!-- fine riga -->


                    </div>
                </div>

                                   <div id="salva" class="btn-primary">
                   <b class="btn-primary btn-icon glyphicons ok"><asp:button runat="server" ID="save_log_setup_new" class="btn-primary" data-layout="center" data-type="confirm" data-toggle="notyfy"  text="Salva e carica i dati" Font-Bold="True" meta:resourcekey="save_rs485_newResource1" /><i></i></b>


            </div>
        </div>
        <script type="text/javascript" src="ldma/validator_ldma_log.js"></script>

         <script type="text/javascript" src="common/validator_general_notify.js"></script>
    <script src="theme/scripts/demo/notifications.js"></script>
    </form>


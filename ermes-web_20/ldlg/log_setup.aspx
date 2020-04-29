<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="log_setup.aspx.vb" Inherits="ermes_web_20.log_setup3" %>

<form id="form" runat="server" method="post" action="ldlg/log_setup.aspx">
<h3><asp:literal runat="server" text ="Data Logger LD Log" ID="data_logger_channel" ></asp:literal></h3>
    <div class="innerLR">
        <div class="box-generic">
            <div class="tab-content">
                <div  class="box-generic">

                    <!-- riga -->
                    <div id ="div1" class="row-fluid">
                        	<div class="span3">
                                <h5 style="padding-top:10px"><asp:literal ID = "Literal2"  text="Interval" runat="server" ></asp:literal></h5>
                                 <asp:dropdownlist ID="value_level_msg" class="span12" runat="server" >
                                     <asp:ListItem Value="0">15 Minutes</asp:ListItem>
                                     <asp:ListItem Value="1">1 Hour</asp:ListItem>
                                     <asp:ListItem Value="2">6 Hour</asp:ListItem>
                                     <asp:ListItem Value="3">12 Hour</asp:ListItem>
                                     <asp:ListItem Value="4">1 Day</asp:ListItem>
                                    </asp:dropdownlist>

                            </div>

                        </div>
                    <!-- fine riga -->


                    </div>
                </div>

                                   <div id="salva" class="btn-primary">
                   <b class="btn-primary btn-icon glyphicons ok"><asp:button runat="server" ID="save_log_setup_new" class="btn-primary" data-layout="center" data-type="confirm" data-toggle="notyfy"  text="Salva e carica i dati" Font-Bold="True"  /><i></i></b>


            </div>
        </div>
        <script type="text/javascript" src="ldlg/validator_ldma_log.js"></script>

         <script type="text/javascript" src="common/validator_general_notify.js"></script>
    <script src="theme/scripts/demo/notifications.js"></script>
    </form>

<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="passcode.aspx.vb" Inherits="ermes_web_20.passcode" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>

<form id="form" runat="server" method="post" action="tower/passcode.aspx">
    <h3><asp:literal runat="server" text ="Password Tower" ID="password_channel" meta:resourcekey="password_channelResource1" ></asp:literal></h3>
    <div class="innerLR">
        <div class="box-generic">
            <div class="tab-content">
                <div  class="box-generic">
                    <!-- riga -->
                    <div id ="div_old_password" class="row-fluid">
                        	<div class="span3">
                                <h5 style="padding-top:10px"><asp:literal ID = "Label7"  text="OLD Password" runat="server" meta:resourcekey="Label7Resource1" ></asp:literal></h5>
                                <asp:textbox ID="old_password" class="span12"  runat="server" style=" position: relative; z-index: 100000; top: 0px; left: 0px;" MaxLength="4" meta:resourcekey="old_passwordResource1" ></asp:textbox>
                            </div>

                     </div>
                    <!-- fine riga -->
                    <!-- riga -->
                    <div id ="div_new_password" class="row-fluid">
                        	<div class="span3">
                                <h5 style="padding-top:10px"><asp:literal ID = "Literal1"  text="New Password" runat="server" meta:resourcekey="Literal1Resource1" ></asp:literal></h5>
                                <asp:textbox ID="new_password" class="span12"  runat="server" style=" position: relative; z-index: 100000; top: 0px; left: 0px;" MaxLength="4" meta:resourcekey="new_passwordResource1" ></asp:textbox>
                            </div>

                     </div>
                    <!-- fine riga -->
                    <!-- riga -->
                    <div id ="div_confirm_password" class="row-fluid">
                        	<div class="span3">
                                <h5 style="padding-top:10px"><asp:literal ID = "Literal2"  text="Confirm Password" runat="server" meta:resourcekey="Literal2Resource1" ></asp:literal></h5>
                                <asp:textbox ID="confirm_password" class="span12"  runat="server" style=" position: relative; z-index: 100000; top: 0px; left: 0px;" MaxLength="4" meta:resourcekey="confirm_passwordResource1" ></asp:textbox>
                            </div>

                     </div>
                    <!-- fine riga -->

                    </div>
                </div>
<div id="salva" class="btn-primary">
                   <b class="btn-primary btn-icon glyphicons ok"><asp:button runat="server" ID="save_password_new" class="btn-primary" data-layout="center" data-type="confirm" data-toggle="notyfy"  text="Save and Load Data" Font-Bold="True" meta:resourcekey="save_password_newResource1"  /><i></i></b>

            </div>
        </div>
    <script type="text/javascript" src="tower/validator_tower_password.js"></script>
                <script type="text/javascript" src="common/validator_general_notify.js"></script>
    <script src="theme/scripts/demo/notifications.js"></script>

    </form>
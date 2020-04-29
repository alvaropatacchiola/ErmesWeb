<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="parameters_ldma.aspx.vb" Inherits="ermes_web_20.parameters_ldma" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>

<form id="form" runat="server" method="post" action="ldma/parameters_ldma.aspx">
    <h3><asp:literal runat="server" text ="Password LD mA" ID="password_channel" meta:resourcekey="password_channelResource1" ></asp:literal></h3>
    <div class="innerLR">
        <div class="box-generic">
            <div class="tab-content">
                <div  class="box-generic">
<!-- Tabs Heading -->
		<div class="tabsbar tabsbar-2" >
			<ul class="row-fluid row-merge">
            
<li class="span3 active"  ><a id="tab_1" href="#tab1-2"  data-toggle="tab"><asp:literal text="Service Menu"  runat="server" ID="tab1" meta:resourcekey="tab1Resource1" ></asp:literal></a></li>
<li class="span3" "><a id="tab_2" href="#tab2-2" data-toggle="tab"><asp:literal text="Data logger" runat="server" ID="tab2" meta:resourcekey="tab2Resource1"></asp:literal></a></li>

			</ul>
		</div>
		<!-- // Tabs Heading END -->
<div class="tab-content">
    <!-- tab 1 start-->
			<div class="tab-pane active" id="tab1-2">

                    <!-- riga -->
                    <div id ="div_old_password_service" class="row-fluid">
                        	<div class="span3">
                                <h5 style="padding-top:10px"><asp:literal ID = "Label7"  text="OLD Password" runat="server" meta:resourcekey="Label7Resource1"></asp:literal></h5>
                                <asp:textbox ID="old_password_service" class="span12"  runat="server" style=" position: relative; z-index: 100000; top: -2px; left: 0px;" MaxLength="4" TextMode="Password" meta:resourcekey="old_password_serviceResource1"></asp:textbox>
                            </div>

                     </div>
                    <!-- fine riga -->
                    <!-- riga -->
                    <div id ="div_new_password_service" class="row-fluid">
                        	<div class="span3">
                                <h5 style="padding-top:10px"><asp:literal ID = "Literal1"  text="New Password" runat="server" meta:resourcekey="Literal1Resource1" ></asp:literal></h5>
                                <asp:textbox ID="new_password_service" class="span12"  runat="server" style=" position: relative; z-index: 100000; top: 0px; left: 0px;" MaxLength="4" TextMode="Password" meta:resourcekey="new_password_serviceResource1" ></asp:textbox>
                            </div>

                     </div>
                    <!-- fine riga -->
                    <!-- riga -->
                    <div id ="div_confirm_password_service" class="row-fluid">
                        	<div class="span3">
                                <h5 style="padding-top:10px"><asp:literal ID = "Literal2"  text="Confirm Password" runat="server" meta:resourcekey="Literal2Resource1" ></asp:literal></h5>
                                <asp:textbox ID="confirm_password_service" class="span12"  runat="server" style=" position: relative; z-index: 100000; top: 0px; left: 0px;" MaxLength="4" TextMode="Password" meta:resourcekey="confirm_password_serviceResource1" ></asp:textbox>
                            </div>

                     </div>
                    <!-- fine riga -->

                    </div>
<!-- tab 1 stop-->
    <!-- tab 2 start-->
			<div class="tab-pane" id="tab2-2">

                    <!-- riga -->
                    <div id ="div_old_password_log" class="row-fluid">
                        	<div class="span3">
                                <h5 style="padding-top:10px"><asp:literal ID = "Literal3"  text="OLD Password" runat="server" meta:resourcekey="Literal3Resource1"></asp:literal></h5>
                                <asp:textbox ID="old_password_log" class="span12"  runat="server" style=" position: relative; z-index: 100000; top: 0px; left: 0px;" MaxLength="4" TextMode="Password" meta:resourcekey="old_password_logResource1"></asp:textbox>
                            </div>

                     </div>
                    <!-- fine riga -->
                    <!-- riga -->
                    <div id ="div_new_password_log" class="row-fluid">
                        	<div class="span3">
                                <h5 style="padding-top:10px"><asp:literal ID = "Literal4"  text="New Password" runat="server" meta:resourcekey="Literal4Resource1" ></asp:literal></h5>
                                <asp:textbox ID="new_password_log" class="span12"  runat="server" style=" position: relative; z-index: 100000; top: 0px; left: 0px;" MaxLength="4" TextMode="Password" meta:resourcekey="new_password_logResource1" ></asp:textbox>
                            </div>

                     </div>
                    <!-- fine riga -->
                    <!-- riga -->
                    <div id ="div_confirm_password_log" class="row-fluid">
                        	<div class="span3">
                                <h5 style="padding-top:10px"><asp:literal ID = "Literal5"  text="Confirm Password" runat="server" meta:resourcekey="Literal5Resource1" ></asp:literal></h5>
                                <asp:textbox ID="confirm_password_log" class="span12"  runat="server" style=" position: relative; z-index: 100000; top: 0px; left: 0px;" MaxLength="4" TextMode="Password" meta:resourcekey="confirm_password_logResource1" ></asp:textbox>
                            </div>

                     </div>
                    <!-- fine riga -->

                    </div>
<!-- tab 2 stop-->
</div>
<div id="salva" class="btn-primary">
                   <b class="btn-primary btn-icon glyphicons ok"><asp:button runat="server" ID="save_password_ldma_new" class="btn-primary" data-layout="center" data-type="confirm" data-toggle="notyfy"  text="Salva e carica i dati" Font-Bold="True" meta:resourcekey="save_password_ldma_newResource1"  /><i></i></b>

            </div>
        </div>
    <script type="text/javascript" src="ldma/validator_ldma_password.js"></script>
                <script type="text/javascript" src="common/validator_general_notify.js"></script>
    <script src="theme/scripts/demo/notifications.js"></script>

    </form>
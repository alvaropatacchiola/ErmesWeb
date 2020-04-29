<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="parameters_ldlg.aspx.vb" Inherits="ermes_web_20.parameters_ldlg" %>

<form id="form" runat="server" method="post" action="ldlg/parameters_ldma.aspx">
    <h3><asp:literal runat="server" text ="Password LD Log" ID="password_channel" ></asp:literal></h3>
    <div class="innerLR">
        <div class="box-generic">
            <div class="tab-content">
                <div  class="box-generic">
<!-- Tabs Heading -->
		<div class="tabsbar tabsbar-2" >
			<ul class="row-fluid row-merge">
            
<li class="span3 active"  ><a id="tab_1" href="#tab1-2"  data-toggle="tab"><asp:literal text="Service Menu"  runat="server" ID="tab1"  ></asp:literal></a></li>
<li class="span3" "><a id="tab_2" href="#tab2-2" data-toggle="tab"><asp:literal text="Data logger" runat="server" ID="tab2" ></asp:literal></a></li>

			</ul>
		</div>
		<!-- // Tabs Heading END -->
<div class="tab-content">
    <!-- tab 1 start-->
			<div class="tab-pane active" id="tab1-2">

                    <!-- riga -->
                    <div id ="div_old_password_service" class="row-fluid">
                        	<div class="span3">
                                <h5 style="padding-top:10px"><asp:literal ID = "Label7"  text="OLD Password" runat="server" ></asp:literal></h5>
                                <asp:textbox ID="old_password_service" class="span12"  runat="server" style=" position: relative; z-index: 100000; top: -2px; left: 0px;" MaxLength="4" TextMode="Password" ></asp:textbox>
                            </div>

                     </div>
                    <!-- fine riga -->
                    <!-- riga -->
                    <div id ="div_new_password_service" class="row-fluid">
                        	<div class="span3">
                                <h5 style="padding-top:10px"><asp:literal ID = "Literal1"  text="New Password" runat="server"  ></asp:literal></h5>
                                <asp:textbox ID="new_password_service" class="span12"  runat="server" style=" position: relative; z-index: 100000; top: 0px; left: 0px;" MaxLength="4" TextMode="Password"  ></asp:textbox>
                            </div>

                     </div>
                    <!-- fine riga -->
                    <!-- riga -->
                    <div id ="div_confirm_password_service" class="row-fluid">
                        	<div class="span3">
                                <h5 style="padding-top:10px"><asp:literal ID = "Literal2"  text="Confirm Password" runat="server"  ></asp:literal></h5>
                                <asp:textbox ID="confirm_password_service" class="span12"  runat="server" style=" position: relative; z-index: 100000; top: 0px; left: 0px;" MaxLength="4" TextMode="Password"  ></asp:textbox>
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
                                <h5 style="padding-top:10px"><asp:literal ID = "Literal3"  text="OLD Password" runat="server"></asp:literal></h5>
                                <asp:textbox ID="old_password_log" class="span12"  runat="server" style=" position: relative; z-index: 100000; top: 0px; left: 0px;" MaxLength="4" TextMode="Password"></asp:textbox>
                            </div>

                     </div>
                    <!-- fine riga -->
                    <!-- riga -->
                    <div id ="div_new_password_log" class="row-fluid">
                        	<div class="span3">
                                <h5 style="padding-top:10px"><asp:literal ID = "Literal4"  text="New Password" runat="server"  ></asp:literal></h5>
                                <asp:textbox ID="new_password_log" class="span12"  runat="server" style=" position: relative; z-index: 100000; top: 0px; left: 0px;" MaxLength="4" TextMode="Password"  ></asp:textbox>
                            </div>

                     </div>
                    <!-- fine riga -->
                    <!-- riga -->
                    <div id ="div_confirm_password_log" class="row-fluid">
                        	<div class="span3">
                                <h5 style="padding-top:10px"><asp:literal ID = "Literal5"  text="Confirm Password" runat="server"  ></asp:literal></h5>
                                <asp:textbox ID="confirm_password_log" class="span12"  runat="server" style=" position: relative; z-index: 100000; top: 0px; left: 0px;" MaxLength="4" TextMode="Password"  ></asp:textbox>
                            </div>

                     </div>
                    <!-- fine riga -->

                    </div>
<!-- tab 2 stop-->
</div>
<div id="salva" class="btn-primary">
                   <b class="btn-primary btn-icon glyphicons ok"><asp:button runat="server" ID="save_password_ldlg_new" class="btn-primary" data-layout="center" data-type="confirm" data-toggle="notyfy"  text="Salva e carica i dati" Font-Bold="True"   /><i></i></b>

            </div>
        </div>
    <script type="text/javascript" src="ldlg/validator_ldlg_password.js"></script>
                <script type="text/javascript" src="common/validator_general_notify.js"></script>
    <script src="theme/scripts/demo/notifications.js"></script>

    </form>

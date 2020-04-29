<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="parameters.aspx.vb" Inherits="ermes_web_20.parameters" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>

<form id="form" runat="server" method="post" action="ld/parameters.aspx">
    <h3><asp:literal runat="server" text ="Parameters LD" ID="message_channel" meta:resourcekey="message_channelResource1"></asp:literal></h3>
    <div class="innerLR">
        <div class="box-generic">
            <div class="tabsbar tabsbar-2">
			<ul class="row-fluid row-merge">
            
                <li class="span2 active" ><a id="tab_ld_sp1" href="#tab_ld_sp1_1"  data-toggle="tab"><asp:literal text="General"  runat="server" ID="tabld1_1" meta:resourcekey="tabld1_1Resource1" ></asp:literal></a></li>
                <li class="span2"><a id="tab_ld_sp2" href="#tab_ld_sp2_2" data-toggle="tab"><asp:literal text="Password" runat="server" ID="tabld1_2" meta:resourcekey="tabld1_2Resource1"></asp:literal></a></li>
			</ul>
		</div>
            <div class="tab-content">
<!-- tab 1 start-->
			<div class="tab-pane active" id="tab_ld_sp1_1">
                <div  class="box-generic">
<!-- riga -->
                <div class="row-fluid">
               	<div class="span3">
                      <div id="riga1_ph_feeding_delay" class="control-group">
                           <h5 style="padding-top:10px"><asp:literal ID = "Literal1"  text="Feeding Delay (min)" runat="server" meta:resourcekey="Literal1Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_ph_feeding_delay" onblur="javascript: Changed_channel( 'value_ph_feeding_delay','riga1_ph_feeding_delay',60, 0,0 );" class="span12"  runat="server" MaxLength="2" meta:resourcekey="value_ph_feeding_delayResource1" ></asp:textbox>
                </div>
                   
                </div>
                </div>
                 <!-- fine riga -->
<!-- riga -->
                <div class="row-fluid">
               	<div class="span3">
                      <div id="riga1_ph_tau" class="control-group">
                           <h5 style="padding-top:10px"><asp:literal ID = "Literal2"  text="Tau " runat="server" meta:resourcekey="Literal2Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_ph_tau" onblur="javascript: Changed_channel( 'value_ph_tau','riga1_ph_tau',30, 0,0 );" class="span12"  runat="server" MaxLength="2" meta:resourcekey="value_ph_tauResource1" ></asp:textbox>
                </div>
                   
                </div>
                </div>
                 <!-- fine riga -->
<!-- riga -->
                    <asp:placeholder runat="server" ID="enable_priority">
                <div class="row-fluid">
               	<div class="span12">
              <h5 style="padding-top:10px"><asp:literal ID = "Label7"  text="Mode" runat="server" meta:resourcekey="Label7Resource1"></asp:literal></h5>
<div class="controlli_box">
                    <asp:radiobutton ID="no_priority"  runat="server"  GroupName="GROUP1" meta:resourcekey="no_priorityResource1"></asp:radiobutton>
</div>
<div class="controlli_testo_box">
                    <asp:literal runat="server" text ="No Priority" meta:resourcekey="LiteralResource1"></asp:literal>
</div>
<div class="controlli_box">
                    <asp:radiobutton ID="ph_priority"  runat="server"  GroupName="GROUP1" meta:resourcekey="ph_priorityResource1"></asp:radiobutton>
</div>
<div class="controlli_testo_box">
                       <asp:literal runat="server" text ="pH Priority" meta:resourcekey="LiteralResource2"></asp:literal>
</div>
                </div>
                </div>
                        </asp:placeholder>
                 <!-- fine riga -->
                                                    

                    </div>
                </div>
<!-- tab 1 stop-->
<!-- tab 2 start-->
			<div class="tab-pane" id="tab_ld_sp2_2">
                <div  class="box-generic">
                    <!-- riga -->
                    <div id ="div_old_password" class="row-fluid">
                        	<div class="span3">
                                <h5 style="padding-top:10px"><asp:literal ID = "Literal3"  text="OLD Password" runat="server" meta:resourcekey="Literal3Resource1"></asp:literal></h5>
                                <asp:textbox ID="old_password" class="span12"  runat="server" style=" position: relative; z-index: 100000; top: 0px; left: 0px;" MaxLength="4" meta:resourcekey="old_passwordResource1"></asp:textbox>
                            </div>

                     </div>
                    <!-- fine riga -->
                    <!-- riga -->
                    <div id ="div_new_password" class="row-fluid">
                        	<div class="span3">
                                <h5 style="padding-top:10px"><asp:literal ID = "Literal4"  text="New Password" runat="server" meta:resourcekey="Literal4Resource1"></asp:literal></h5>
                                <asp:textbox ID="new_password" class="span12"  runat="server" style=" position: relative; z-index: 100000; top: 0px; left: 0px;" MaxLength="4" meta:resourcekey="new_passwordResource1"></asp:textbox>
                            </div>

                     </div>
                    <!-- fine riga -->
                    <!-- riga -->
                    <div id ="div_confirm_password" class="row-fluid">
                        	<div class="span3">
                                <h5 style="padding-top:10px"><asp:literal ID = "Literal5"  text="Confirm Password" runat="server" meta:resourcekey="Literal5Resource1"></asp:literal></h5>
                                <asp:textbox ID="confirm_password" class="span12"  runat="server" style=" position: relative; z-index: 100000; top: 0px; left: 0px;" MaxLength="4" meta:resourcekey="confirm_passwordResource1"></asp:textbox>
                            </div>

                     </div>
                    <!-- fine riga -->

                    </div>
            </div>
                <!-- tab 2 stop-->  
                </div>
<div id="salva" class="btn-primary">
                   <b class="btn-primary btn-icon glyphicons ok"><asp:button runat="server" ID="save_parameters_new" class="btn-primary" data-layout="center" data-type="confirm" data-toggle="notyfy" text="Salva e carica i dati" Font-Bold="True" meta:resourcekey="save_parameters_newResource1" /><i></i></b>
                </div>
            </div>
        <script type="text/javascript" src="ld/validator_ld_parameters.js"></script>
        <script type="text/javascript" src="common/validator_general_notify.js"></script>
        <script src="theme/scripts/demo/notifications.js"></script>

        </div>
    </form>

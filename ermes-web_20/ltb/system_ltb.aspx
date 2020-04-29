<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="system_ltb.aspx.vb" Inherits="ermes_web_20.system_ltb" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>

<form id="form" runat="server" method="post" action="ltb/system_ltb.aspx">
    <h3><asp:literal runat="server" text ="System" ID="message_channel" meta:resourcekey="message_channelResource1"></asp:literal></h3>
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
               
                 <!-- fine riga -->

                    <!-- riga -->

                    <!--<asp:placeholder runat="server" ID="format_date">-->
                <div class="row-fluid">
               	<div class="span12">
              <h5 style="padding-top:10px"><asp:literal ID = "Label7"  text="Format" runat="server" meta:resourcekey="Label7Resource1"></asp:literal></h5>
<div class="controlli_box">
                    <asp:radiobutton ID="english"  runat="server"  GroupName="GROUP6" meta:resourcekey="englishResource1"></asp:radiobutton>
</div>
<div class="controlli_testo_box">
                    <asp:literal runat="server" text ="English" meta:resourcekey="LiteralResource1"></asp:literal>
</div>
<div class="controlli_box">
                    <asp:radiobutton ID="english_usa"  runat="server"  GroupName="GROUP6" meta:resourcekey="english_usaResource1"></asp:radiobutton>
</div>
<div class="controlli_testo_box">
                       <asp:literal runat="server" text ="English USA" meta:resourcekey="LiteralResource2"></asp:literal>
</div>

                       <div class="controlli_box">
                    <asp:radiobutton ID="italiano"  runat="server"  GroupName="GROUP6" meta:resourcekey="italianoResource1"></asp:radiobutton>
</div>
<div class="controlli_testo_box">
                       <asp:literal runat="server" text ="Italian" meta:resourcekey="LiteralResource22"></asp:literal>
</div>
                </div>
                </div>
                        <!--</asp:placeholder>-->
 <!-- fine riga -->
<!-- riga -->
               <div id ="div_ch3" class="row-fluid">
                        	<div class="span2">
                                <h5 style="padding-top:10px"><asp:literal ID = "Literal4"  text="Date Time" runat="server" meta:resourcekey="Literal2Resource1"></asp:literal></h5>
                                <div id="clock_formato_12_ggmmaa">
                                <asp:textbox ID="clock_12_ggmmaa" onblur="javascript: Changed_channel_clock( 'clock_12_ggmmaa','div_ch3', 19);" onchange="javascript: Changed_channel_clock( 'clock_12_ggmmaa','div_ch3', 19);" class="span12"  runat="server" style=" position: relative; z-index: 100000; top: 0px; left: 0px;" meta:resourcekey="clock_12_ggmmaaResource1"></asp:textbox>
                                 </div>
                                
                                <div id="clock_formato_24_ggmmaa">
                                <asp:textbox ID="clock_24_ggmmaa" onblur="javascript: Changed_channel_clock( 'clock_24_ggmmaa','div_ch3', 16);" onchange="javascript: Changed_channel_clock( 'clock_24_ggmmaa','div_ch3', 16);" class="span12"  runat="server" style=" position: relative; z-index: 100000; top: 0px; left: 0px;" meta:resourcekey="clock_24_ggmmaaResource1"></asp:textbox>
                                 </div>

                                
                            </div>

                        </div>
                 <!-- fine riga -->
<!-- riga -->
                    
                 <!-- fine riga -->
                                                    
<!-- riga -->
                    <asp:placeholder runat="server" ID="visualizza_mv">
                <div class="row-fluid">
               	<div class="span12">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal5"  text="View mV" runat="server" meta:resourcekey="LiteralResource11"></asp:literal></h5>
<div class="controlli_box">
                    <asp:radiobutton ID="view_mv"  runat="server"  GroupName="GROUP1" meta:resourcekey="yes_mVResource1"></asp:radiobutton>
</div>
<div class="controlli_testo_box">
                    <asp:literal runat="server" text ="Yes" meta:resourcekey="LiteralResource3"></asp:literal>
</div>
<div class="controlli_box">
                    <asp:radiobutton ID="view_mv_no"  runat="server"  GroupName="GROUP1" meta:resourcekey="no_mVResource1"></asp:radiobutton>
</div>
<div class="controlli_testo_box">
                       <asp:literal runat="server" text ="No" meta:resourcekey="LiteralResource4"></asp:literal>
</div>
                </div>
                </div>
                        </asp:placeholder>
                 <!-- fine riga -->


                    <!-- riga -->
                    <asp:placeholder runat="server" ID="visualizza_cl">
                <div class="row-fluid">
               	<div class="span12">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal8"  text="View Cl" runat="server" meta:resourcekey="LiteralResource10"></asp:literal></h5>
<div class="controlli_box">
                    <asp:radiobutton ID="view_cl"  runat="server"  GroupName="GROUP2" meta:resourcekey="yes_clResource1"></asp:radiobutton>
</div>
<div class="controlli_testo_box">
                    <asp:literal runat="server" text ="Yes" meta:resourcekey="LiteralResource5"></asp:literal>
</div>
<div class="controlli_box">
                    <asp:radiobutton ID="view_cl_no"  runat="server"  GroupName="GROUP2" meta:resourcekey="no_clResource1"></asp:radiobutton>
</div>
<div class="controlli_testo_box">
                       <asp:literal runat="server" text ="No" meta:resourcekey="LiteralResource6"></asp:literal>
</div>
                </div>
                </div>
                        </asp:placeholder>
                 <!-- fine riga -->

                    <!-- riga -->
                    <asp:placeholder runat="server" ID="visualizza_temp">
                <div class="row-fluid">
               	<div class="span12">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal11"  text="View Temp" runat="server" meta:resourcekey="LiteralResource7"></asp:literal></h5>
<div class="controlli_box">
                    <asp:radiobutton ID="view_temp"  runat="server"  GroupName="GROUP3" meta:resourcekey="yes_tempResource1"></asp:radiobutton>
</div>
<div class="controlli_testo_box">
                    <asp:literal runat="server" text ="Yes" meta:resourcekey="LiteralResource8"></asp:literal>
</div>
<div class="controlli_box">
                    <asp:radiobutton ID="view_temp_no"  runat="server"  GroupName="GROUP3" meta:resourcekey="no_tempResource1"></asp:radiobutton>
</div>
<div class="controlli_testo_box">
                       <asp:literal runat="server" text ="No" meta:resourcekey="LiteralResource9"></asp:literal>
</div>
                </div>
                </div>
                        </asp:placeholder>
                 <!-- fine riga -->


                     <!-- riga -->
                    <asp:placeholder runat="server" ID="standby_mode">
                <div class="row-fluid">
               	<div class="span12">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal14"  text="Stand by Mode" runat="server" meta:resourcekey="LiteralResource12"></asp:literal></h5>
<div class="controlli_box">
                    <asp:radiobutton ID="dis_stand"  runat="server"  GroupName="GROUP4" meta:resourcekey="stby_disResource1"></asp:radiobutton>
</div>
<div class="controlli_testo_box">
                    <asp:literal runat="server" text ="Disable" meta:resourcekey="LiteralResource13"></asp:literal>
</div>
<div class="controlli_box">
                    <asp:radiobutton ID="no_stand"  runat="server"  GroupName="GROUP4" meta:resourcekey="stby_noResource1"></asp:radiobutton>
</div>
<div class="controlli_testo_box">
                       <asp:literal runat="server" text ="N.O." meta:resourcekey="LiteralResource14"></asp:literal>
</div>
                       <div class="controlli_box">
                    <asp:radiobutton ID="nc_stand"  runat="server"  GroupName="GROUP4" meta:resourcekey="stby_ncResource1"></asp:radiobutton>
</div>
<div class="controlli_testo_box">
                       <asp:literal runat="server" text ="N.C." meta:resourcekey="LiteralResource15"></asp:literal>
</div>
                </div>
                </div>
                        </asp:placeholder>
                 <!-- fine riga -->

<!-- riga -->
                    <asp:placeholder runat="server" ID="Lock">
                <div class="row-fluid">
               	<div class="span12">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal18"  text="Stand by Lock" runat="server" meta:resourcekey="LiteralResource16"></asp:literal></h5>
<div class="controlli_box">
                    <asp:radiobutton ID="Lock_all"  runat="server"  GroupName="GROUP5" meta:resourcekey="all_lockResource1"></asp:radiobutton>
</div>
<div class="controlli_testo_box">
                    <asp:literal runat="server" text ="Lock All" meta:resourcekey="LiteralResource17"></asp:literal>
</div>
<div class="controlli_box">
                    <asp:radiobutton ID="Dos_only"  runat="server"  GroupName="GROUP5" meta:resourcekey="dos_lockResource1"></asp:radiobutton>
</div>
<div class="controlli_testo_box">
                       <asp:literal runat="server" text ="Dos Only" meta:resourcekey="LiteralResource18"></asp:literal>
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
                                <h5 style="padding-top:10px"><asp:literal ID = "Literal21"  text="OLD Password" runat="server" meta:resourcekey="LiteralResource19"></asp:literal></h5>
                                <asp:textbox ID="old_password" class="span12"  runat="server" style=" position: relative; z-index: 100000; top: 0px; left: 0px;" MaxLength="4" meta:resourcekey="old_passwordResource1"></asp:textbox>
                            </div>

                     </div>
                    <!-- fine riga -->
                    <!-- riga -->
                    <div id ="div_new_password" class="row-fluid">
                        	<div class="span3">
                                <h5 style="padding-top:10px"><asp:literal ID = "Literal22"  text="New Password" runat="server" meta:resourcekey="LiteralResource20"></asp:literal></h5>
                                <asp:textbox ID="new_password" class="span12"  runat="server" style=" position: relative; z-index: 100000; top: 0px; left: 0px;" MaxLength="4" meta:resourcekey="new_passwordResource1"></asp:textbox>
                            </div>

                     </div>
                    <!-- fine riga -->
                    <!-- riga -->
                    <div id ="div_confirm_password" class="row-fluid">
                        	<div class="span3">
                                <h5 style="padding-top:10px"><asp:literal ID = "Literal23"  text="Confirm Password" runat="server" meta:resourcekey="LiteralResource21"></asp:literal></h5>
                                <asp:textbox ID="confirm_password" class="span12"  runat="server" style=" position: relative; z-index: 100000; top: 0px; left: 0px;" MaxLength="4" meta:resourcekey="confirm_passwordResource1"></asp:textbox>
                            </div>

                     </div>
                    <!-- fine riga -->

                    </div>
            </div>
                <!-- tab 2 stop-->  
                </div>
<div id="salva" class="btn-primary">
                   <b class="btn-primary btn-icon glyphicons ok"><asp:button runat="server" ID="save_systemltb_new" class="btn-primary" data-layout="center" data-type="confirm" data-toggle="notyfy" text="Salva e carica i dati" Font-Bold="True" meta:resourcekey="save_systemltb_newResource1" /><i></i></b>
                </div>
            </div>
        <script type="text/javascript" src="ltb/validator_ltb_system.js"></script>
        <script src="theme/scripts/demo/calendar_new.js"></script>
        <link href="bootstrap/css/jquery-ui-timepicker-addon.css" rel="stylesheet" />
        <script type="text/javascript" src="common/validator_general_notify.js"></script>
        <script src="theme/scripts/demo/notifications.js"></script>

        </div>
    </form>

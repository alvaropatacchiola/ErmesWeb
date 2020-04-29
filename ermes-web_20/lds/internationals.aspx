﻿<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="internationals.aspx.vb" Inherits="ermes_web_20.internationals" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>


<form id="form" runat="server"  method="post" action="lds/internationals.aspx">
    <h3><asp:literal runat="server" text ="International LDS" ID="clock_channel" meta:resourcekey="clock_channelResource1"></asp:literal></h3>
    <div class="innerLR">
        <div class="box-generic">
            <div class="tab-content">
                <div  class="box-generic">
                    <!-- riga -->
                    <div id ="div_ch1" class="row-fluid">
                        	<div class="span12">
                                <h5 style="padding-top:10px"><asp:literal ID = "Label7"  text="Time Format" runat="server" meta:resourcekey="Label7Resource1"></asp:literal></h5>
<div class="controlli_box">
                                    <asp:radiobutton ID="time_format_24_enable"  runat="server"  GroupName="GROUP1" meta:resourcekey="time_format_24_enableResource1"></asp:radiobutton>
</div>
<div class="controlli_testo_box">
                                    <asp:literal ID="time_format_24" runat="server" text ="Europe IS" meta:resourcekey="time_format_24Resource1"></asp:literal>
</div>
<div class="controlli_box">
                                    <asp:radiobutton ID="time_format_12_enable"  runat="server"  GroupName="GROUP1" meta:resourcekey="time_format_12_enableResource1"></asp:radiobutton>
</div>
<div class="controlli_testo_box">
                                    <asp:literal ID="time_format_12" runat="server" text ="USA" meta:resourcekey="time_format_12Resource1"></asp:literal>
</div>
                            </div>

                        </div>
                    <!-- fine riga -->
                   
                    <!-- riga -->
                    <div id ="div_ch3" class="row-fluid">
                        	<div class="span2">
                                <h5 style="padding-top:10px"><asp:literal ID = "Literal2"  text="Date Time" runat="server" meta:resourcekey="Literal2Resource1"></asp:literal></h5>
                                <div id="clock_formato_12_ggmmaa">
                                <asp:textbox ID="clock_12_ggmmaa" onblur="javascript: Changed_channel_clock( 'clock_12_ggmmaa','div_ch3', 19);" onchange="javascript: Changed_channel_clock( 'clock_12_ggmmaa','div_ch3', 19);" class="span12"  runat="server" style=" position: relative; z-index: 100000; top: 0px; left: 0px;" meta:resourcekey="clock_12_ggmmaaResource1"></asp:textbox>
                                 </div>
                                
                                <div id="clock_formato_24_ggmmaa">
                                <asp:textbox ID="clock_24_ggmmaa" onblur="javascript: Changed_channel_clock( 'clock_24_ggmmaa','div_ch3', 16);" onchange="javascript: Changed_channel_clock( 'clock_24_ggmmaa','div_ch3', 16);" class="span12"  runat="server" style=" position: relative; z-index: 100000; top: 0px; left: 0px;" meta:resourcekey="clock_24_ggmmaaResource1"></asp:textbox>
                                 </div>

                                
                            </div>

                        </div>
                    <!-- fine riga -->

                    </div>
                </div>

                       <div id="salva" class="btn-primary">
                   <b class="btn-primary btn-icon glyphicons ok"><asp:button runat="server" ID="save_international_new" class="btn-primary" data-layout="center" data-type="confirm" data-toggle="notyfy" text="Salva e carica i dati" Font-Bold="True" meta:resourcekey="save_international_newResource1" /><i></i></b>
                </div>

            </div>
        </div>
    <script type="text/javascript" src="ld/validator_ld_international.js"></script>
    <script src="theme/scripts/demo/calendar_new.js"></script>
    <link href="bootstrap/css/jquery-ui-timepicker-addon.css" rel="stylesheet" />
        <script type="text/javascript" src="common/validator_general_notify.js"></script>
<script src="theme/scripts/demo/notifications.js"></script>
    </form>
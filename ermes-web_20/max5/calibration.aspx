<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="calibration.aspx.vb" Inherits="ermes_web_20.calibration" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>


<form id="form" runat="server"  method="post" action="max5/calibration.aspx">


    <h3><asp:literal runat="server" text ="Calibration Max5" ID="calibration_channel" meta:resourcekey="calibration_channelResource1"></asp:literal></h3>
    <div class="innerLR">
        <div class="box-generic">
            <div class="tab-content">
                <div  class="box-generic">
                <!-- riga -->
                <div id ="div_ch1" class="row-fluid">
               	<div class="span2">
              <h5 style="padding-top:10px"><asp:literal ID = "Label7"  text="Channel" runat="server" meta:resourcekey="Label7Resource1"></asp:literal></h5>
                    <asp:radiobutton ID="ch1_probe_enale" style="margin: 5px 10px 10px 0px;" runat="server"  GroupName="GROUP1" meta:resourcekey="ch1_probe_enaleResource1"></asp:radiobutton>
                    <asp:literal ID="ch1_probe_enale_l" runat="server" text ="pH" meta:resourcekey="ch1_probe_enale_lResource1"></asp:literal>
                </div>
                    <div class="span2">
                        <h5 style="padding-top:10px"><asp:literal ID = "Literal1"  text="mV Probe" runat="server" meta:resourcekey="Literal1Resource1"></asp:literal></h5>
                        <div class="row-fluid">
                        <asp:literal ID = "ch1_probe_mv_value"  text="125" runat="server" meta:resourcekey="ch1_probe_mv_valueResource1"></asp:literal>
                            </div>
                        </div>
                    <div class="span2">
                        <h5 style="padding-top:10px"><asp:literal ID = "Literal2"  text="Probe Value" runat="server" meta:resourcekey="Literal2Resource1"></asp:literal></h5>
                        <div class="row-fluid">
                        <asp:literal ID = "ch1_probe_value"  text="7.57" runat="server" meta:resourcekey="ch1_probe_valueResource1"></asp:literal>
                            </div>
                        </div>
                     <div class="span2">

                <div id="div_ch1_1" class="control-group">
                <h5 style="padding-top:10px" class="control-label"><asp:literal ID = "Literal3"  text="New Value" runat="server" meta:resourcekey="Literal3Resource1"></asp:literal></h5>
                <div class="row-fluid">
                    
                <asp:textbox ID="ch1_new_value" class="span12"  runat="server" onblur="javascript: Changed_channel( 'ch1_new_value','div_ch1_1',max_ch1_value, min_ch1_value,ch1_fix);"   MaxLength="5" meta:resourcekey="ch1_new_valueResource1"></asp:textbox>
                   </div>
                </div>
                 </div>
                </div>
 <!-- fine riga -->
                 <!-- riga -->
                <div id ="div_ch2" class="row-fluid">
               	<div class="span2">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal4"  text="Channel" runat="server" meta:resourcekey="Literal4Resource1"></asp:literal></h5>
                    <asp:radiobutton ID="ch2_probe_enale" style="margin: 5px 10px 10px 0px;" runat="server"  GroupName="GROUP1" meta:resourcekey="ch2_probe_enaleResource1"></asp:radiobutton>
                    <asp:literal ID="ch2_probe_enale_l" runat="server" text ="mV" meta:resourcekey="ch2_probe_enale_lResource1"></asp:literal>
                </div>
                    <div class="span2">
                        <h5 style="padding-top:10px"><asp:literal ID = "Literal6"  text="mV Probe" runat="server" meta:resourcekey="Literal6Resource1"></asp:literal></h5>
                        <div class="row-fluid">
                        <asp:literal ID = "ch2_probe_mv_value"  text="125" runat="server" meta:resourcekey="ch2_probe_mv_valueResource1"></asp:literal>
                            </div>
                        </div>
                    <div class="span2">
                        <h5 style="padding-top:10px"><asp:literal ID = "Literal7"  text="Probe Value" runat="server" meta:resourcekey="Literal7Resource1"></asp:literal></h5>
                        <div class="row-fluid">
                        <asp:literal ID = "ch2_probe_value"  text="7.57" runat="server" meta:resourcekey="ch2_probe_valueResource1"></asp:literal>
                            </div>
                        </div>
                     <div class="span2">

                <div id="div_ch2_1" class="control-group">
                <h5 style="padding-top:10px" class="control-label"><asp:literal ID = "Literal8"  text="New Value" runat="server" meta:resourcekey="Literal8Resource1"></asp:literal></h5>
                <div class="row-fluid">
                    
                <asp:textbox ID="ch2_new_value" class="span12"  runat="server" onblur="javascript: Changed_channel( 'ch2_new_value','div_ch2_1',max_ch2_value, min_ch2_value,ch2_fix);"  MaxLength="5" meta:resourcekey="ch2_new_valueResource1"></asp:textbox>
                   </div>
                </div>
                 </div>
                </div>
 <!-- fine riga -->
                <!-- riga -->
                <div id ="div_ch3" class="row-fluid">
               	<div class="span2">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal5"  text="Channel" runat="server" meta:resourcekey="Literal5Resource1"></asp:literal></h5>
                    <asp:radiobutton ID="ch3_probe_enale" style="margin: 5px 10px 10px 0px;" runat="server"  GroupName="GROUP1" meta:resourcekey="ch3_probe_enaleResource1"></asp:radiobutton>
                    <asp:literal ID="ch3_probe_enale_l" runat="server" text ="Cl2" meta:resourcekey="ch3_probe_enale_lResource1"></asp:literal>
                </div>
                    <div class="span2">
                        <h5 style="padding-top:10px"><asp:literal ID = "Literal10"  text="mV Probe" runat="server" meta:resourcekey="Literal10Resource1"></asp:literal></h5>
                        <div class="row-fluid">
                        <asp:literal ID = "ch3_probe_mv_value"  text="125" runat="server" meta:resourcekey="ch3_probe_mv_valueResource1"></asp:literal>
                            </div>
                        </div>
                    <div class="span2">
                        <h5 style="padding-top:10px"><asp:literal ID = "Literal11"  text="Probe Value" runat="server" meta:resourcekey="Literal11Resource1"></asp:literal></h5>
                        <div class="row-fluid">
                        <asp:literal ID = "ch3_probe_value"  text="7.57" runat="server" meta:resourcekey="ch3_probe_valueResource1"></asp:literal>
                            </div>
                        </div>
                     <div class="span2">

                <div id="div_ch3_1" class="control-group">
                <h5 style="padding-top:10px" class="control-label"><asp:literal ID = "Literal12"  text="New Value" runat="server" meta:resourcekey="Literal12Resource1"></asp:literal></h5>
                <div class="row-fluid">
                    
                <asp:textbox ID="ch3_new_value" class="span12"  runat="server" onblur="javascript: Changed_channel( 'ch3_new_value','div_ch3_1',max_ch3_value, min_ch3_value,ch3_fix);"  MaxLength="5" meta:resourcekey="ch3_new_valueResource1"></asp:textbox>
                   </div>
                </div>
                 </div>
                </div>
 <!-- fine riga -->
                <!-- riga -->
                <div id ="div_ch4" class="row-fluid">
               	<div class="span2">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal9"  text="Channel" runat="server" meta:resourcekey="Literal9Resource1"></asp:literal></h5>
                    <asp:radiobutton ID="ch4_probe_enale" style="margin: 5px 10px 10px 0px;" runat="server"  GroupName="GROUP1" meta:resourcekey="ch4_probe_enaleResource1"></asp:radiobutton>
                    <asp:literal ID="ch4_probe_enale_l" runat="server" text ="mV" meta:resourcekey="ch4_probe_enale_lResource1"></asp:literal>
                </div>
                    <div class="span2">
                        <h5 style="padding-top:10px"><asp:literal ID = "Literal14"  text="mV Probe" runat="server" meta:resourcekey="Literal14Resource1"></asp:literal></h5>
                        <div class="row-fluid">
                        <asp:literal ID = "ch4_probe_mv_value"  text="125" runat="server" meta:resourcekey="ch4_probe_mv_valueResource1"></asp:literal>
                            </div>
                        </div>
                    <div class="span2">
                        <h5 style="padding-top:10px"><asp:literal ID = "Literal15"  text="Probe Value" runat="server" meta:resourcekey="Literal15Resource1"></asp:literal></h5>
                        <div class="row-fluid">
                        <asp:literal ID = "ch4_probe_value"  text="7.57" runat="server" meta:resourcekey="ch4_probe_valueResource1"></asp:literal>
                            </div>
                        </div>
                     <div class="span2">

                <div id="div_ch4_1" class="control-group">
                <h5 style="padding-top:10px" class="control-label"><asp:literal ID = "Literal16"  text="New Value" runat="server" meta:resourcekey="Literal16Resource1"></asp:literal></h5>
                <div class="row-fluid">
                    
                <asp:textbox ID="ch4_new_value" class="span12"  runat="server" onblur="javascript: Changed_channel( 'ch4_new_value','div_ch4_1',max_ch4_value, min_ch4_value,ch4_fix);"  MaxLength="5" meta:resourcekey="ch4_new_valueResource1"></asp:textbox>
                   </div>
                </div>
                 </div>
                </div>
 <!-- fine riga -->
                <!-- riga -->
                <div id ="div_ch5" class="row-fluid">
               	<div class="span2">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal13"  text="Channel" runat="server" meta:resourcekey="Literal13Resource1"></asp:literal></h5>
                    <asp:radiobutton ID="ch5_probe_enale" style="margin: 5px 10px 10px 0px;" runat="server"  GroupName="GROUP1" meta:resourcekey="ch5_probe_enaleResource1"></asp:radiobutton>
                    <asp:literal ID="ch5_probe_enale_l" runat="server" text ="mV" meta:resourcekey="ch5_probe_enale_lResource1"></asp:literal>
                </div>
                    <div class="span2">
                        <h5 style="padding-top:10px"><asp:literal ID = "Literal18"  text="mV Probe" runat="server" meta:resourcekey="Literal18Resource1"></asp:literal></h5>
                        <div class="row-fluid">
                        <asp:literal ID = "ch5_probe_mv_value"  text="125" runat="server" meta:resourcekey="ch5_probe_mv_valueResource1"></asp:literal>
                            </div>
                        </div>
                    <div class="span2">
                        <h5 style="padding-top:10px"><asp:literal ID = "Literal19"  text="Probe Value" runat="server" meta:resourcekey="Literal19Resource1"></asp:literal></h5>
                        <div class="row-fluid">
                        <asp:literal ID = "ch5_probe_value"  text="7.57" runat="server" meta:resourcekey="ch5_probe_valueResource1"></asp:literal>
                            </div>
                        </div>
                     <div class="span2">

                <div id="div_ch5_1" class="control-group">
                <h5 style="padding-top:10px" class="control-label"><asp:literal ID = "Literal20"  text="New Value" runat="server" meta:resourcekey="Literal20Resource1"></asp:literal></h5>
                <div class="row-fluid">
                    
                <asp:textbox ID="ch5_new_value" class="span12"  runat="server" onblur="javascript: Changed_channel( 'ch5_new_value','div_ch5_1',max_ch5_value, min_ch5_value,ch5_fix);"  MaxLength="5" meta:resourcekey="ch5_new_valueResource1"></asp:textbox>
                   </div>
                </div>
                 </div>
                </div>
 <!-- fine riga -->                                    
                </div>
                </div>
                       <div id="salva" class="btn-primary">
                   <b class="btn-primary btn-icon glyphicons ok"><asp:button runat="server" ID="save_calibration_new" class="btn-primary" data-layout="center" data-type="confirm" data-toggle="notyfy"  text="Salva e carica i dati" Font-Bold="True" meta:resourcekey="save_temperature_newResource1" /><i></i></b>
                </div>

            </div>
        </div>
    <script type="text/javascript" src="max5/validator_max5.js"></script>
     <script type="text/javascript" src="common/validator_general_notify.js"></script>
    <script src="theme/scripts/demo/notifications.js"></script>
    </form>
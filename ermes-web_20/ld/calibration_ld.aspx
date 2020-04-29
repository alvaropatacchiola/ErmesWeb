<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="calibration_ld.aspx.vb" Inherits="ermes_web_20.calibration_ld" %>

<form id="form" runat="server"  method="post" action="ld/calibration_ld.aspx">


    <h3><asp:literal runat="server" text ="Calibration LD" ID="calibration_channel" meta:resourcekey="calibration_channelResource1"></asp:literal></h3>
    <div class="innerLR">
        <div class="box-generic">
            <div class="tab-content">
                <div  class="box-generic">
                <!-- riga -->
                <div id ="div_ch1" class="row-fluid">
               	<div class="span2">
              <h5 style="padding-top:10px"><asp:literal ID = "Label7"  text="Channel" runat="server" meta:resourcekey="Label7Resource1"></asp:literal></h5>
                    
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
                        <asp:literal ID = "ch1_probe_value"  text="7.56" runat="server" meta:resourcekey="ch1_probe_valueResource1"></asp:literal>
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
                
 <!-- fine riga -->
                <!-- riga -->
                
 <!-- fine riga -->
                <!-- riga -->
                
 <!-- fine riga -->                                    
                </div>
                </div>
                       <div id="salva" style="background-color:#a4c408"  class="control-group">
                   <b class="btn-primary btn-icon glyphicons ok"><asp:button runat="server" ID="save_calibration_newld" class="btn-primary" data-layout="center" data-type="confirm" data-toggle="notyfy"  text="Salva e carica i dati" Font-Bold="True" meta:resourcekey="save_temperature_newldResource1" /><i></i></b>
                </div>

            </div>
        </div>
    <script type="text/javascript" src="ld/validator_ld_calibration.js"></script>
     <script type="text/javascript" src="common/validator_general_notify.js"></script>
    <script src="theme/scripts/demo/notifications.js"></script>
    </form>
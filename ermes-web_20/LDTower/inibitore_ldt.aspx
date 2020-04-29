<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="inibitore_ldt.aspx.vb" Inherits="ermes_web_20.inibitore_ldt" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>

<form id="form" runat="server" method="post" action="LDTower/inibitore_ldt.aspx">           

    <h3><asp:literal runat="server" text ="Inhibitor CoolTrol" ID="message_channel" meta:resourcekey="message_channelResource1"></asp:literal></h3>
    <div class="innerLR">
        <div class="box-generic">
                <div class="tab-content">
                 <!-- tab 1 start-->
			<div class="tab-pane active" id="tab_ld_sp1_1">
                <div  class="box-generic">
                                 <!-- riga -->
                <div class="row-fluid">
               	<div class="span12">
              <h5 style="padding-top:10px"><asp:literal ID = "Label7"  text="Water Meter" runat="server" meta:resourcekey="Label7Resource1"></asp:literal></h5>

    <div class="row-fluid">
               	<div class="span3">
                    <asp:radiobutton ID="WM_inhib"  runat="server"  GroupName="GROUP1" meta:resourcekey="WM_inhibResource1"></asp:radiobutton> 
                    <asp:literal runat="server" text ="Enable" meta:resourcekey="LiteralResource1"></asp:literal>
                </div>
  
    </div>
 

                                <!-- riga -->
<div id ="enable_value_WM">
                <div class="row-fluid">
               	<div class="span3">
                       <div id="riga1_value_min_inhib" class="control-group">
                           <h5 style="padding-top:10px"><asp:literal ID = "Literal4"  text="Cycle Time (min)" runat="server" meta:resourcekey="Literal4Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_min_inhib" onblur="javascript: Changed_channel( 'value_min_inhib','riga1_value_min_inhib',99, 0,0 );" class="span12"  runat="server" MaxLength="2" meta:resourcekey="value_min_inhibResource1" ></asp:textbox>
                </div>
                       </div>
                
                   
                </div>

                 <!-- fine riga -->
                      <!-- riga -->

                <div class="row-fluid">
               	<div class="span3">
                       <div id="riga1_value_sec_inhib" class="control-group">
                           <h5 style="padding-top:10px"><asp:literal ID = "Literal1"  text="Cycle Time (sec)" runat="server" meta:resourcekey="Literal1Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_sec_inhib" onblur="javascript: Changed_channel( 'value_sec_inhib','riga1_value_sec_inhib',99, 0,0 );" class="span12"  runat="server" MaxLength="2" meta:resourcekey="value_sec_inhibResource1" ></asp:textbox>
                </div>
                       </div>

                </div>

                 <!-- fine riga -->
                      <!-- riga -->

                <div class="row-fluid">
               	    <div class="span3">
                       <div id="riga1_value_count_inhib" class="control-group">                        <!-- CHIEDERE SE BISOGNA INSERIRE LA VIRGOLA NEL CONTATORE!!! -->
                           <h5 style="padding-top:10px"><asp:literal ID = "Literal2"  text="Counter" runat="server" meta:resourcekey="Literal2Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_counter_inhib" onblur="javascript: Changed_channel( 'value_counter_inhib','riga1_value_count_inhib', 9999, 0, 0 );" class="span12"  runat="server" MaxLength="4" meta:resourcekey="value_counter_inhibResource1" ></asp:textbox>
                        </div>
                    </div>

                </div>
        </div>
            <!-- fine tab -->             

             <h5 style="padding-top:10px"><asp:literal ID = "Literal3"  text="Water Meter PPM" runat="server" meta:resourcekey="Label3Resource1"></asp:literal></h5>

        <div class="row-fluid">
               	<div class="span3">
                    <asp:radiobutton ID="WM_ppm_inhib"  runat="server"  GroupName="GROUP1" meta:resourcekey="WM_ppm_inhibResource1"></asp:radiobutton>
                    <asp:literal runat="server" text ="Enable" meta:resourcekey="LiteralResource2"></asp:literal>
        </div>
        </div>


<div id ="enable_value_water_meter_ppm">
<!-- riga -->

                <div class="row-fluid">
               	<div class="span3">
                       <div id="riga_water_meter_ppm" class="control-group">                    <!-- controllare il valore dei PPM!!!  -->
                           <h5 style="padding-top:10px"><asp:literal ID = "Literal12"  text="PPM" runat="server" meta:resourcekey="Literal12Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_water_meter_ppm" onblur="javascript: Changed_channel( 'value_water_meter_ppm','riga_water_meter_ppm',max_us, 0,0 );" class="span12"  runat="server" MaxLength="4" meta:resourcekey="value_water_meter_ppmResource1" ></asp:textbox>
                </div>
                       </div>

                   
                </div>
                 <!-- fine riga -->

<!-- riga -->
                <div class="row-fluid">
               	<div class="span3">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal14"  text="Mode" runat="server" meta:resourcekey="Literal14Resource1"></asp:literal></h5>
                    <asp:radiobutton ID="enable_water_meter_ppm_cc_st" style="margin: 5px 10px 10px 0px;" runat="server"  GroupName="GROUP2" Checked="True" meta:resourcekey="enable_water_meter_ppm_cc_stResource1"></asp:radiobutton>
                    <asp:literal runat="server" text ="cc/st" meta:resourcekey="LiteralResource8"></asp:literal>
                    <asp:radiobutton ID="enable_water_meter_ppm_l_h" style="margin: 5px 10px 10px 0px;" runat="server"  GroupName="GROUP2" meta:resourcekey="enable_water_meter_ppm_l_hResource1"></asp:radiobutton>
                    <asp:literal runat="server" text ="l/h" meta:resourcekey="LiteralResource9"></asp:literal>

                </div>
                </div>
<!-- fine riga -->

    <!-- riga -->
<div id="div_enable_water_meter_ppm_cc_st">
    <div class="row-fluid">
               	<div class="span3">
                       <div id="riga_water_meter_ppm_cc_st" class="control-group">
                           <h5 style="padding-top:10px"><asp:literal ID = "Literal15"  text="cc/st" runat="server" meta:resourcekey="Literal15Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_water_meter_ppm_cc_st" onblur="javascript: Changed_channel( 'value_water_meter_ppm_cc_st','riga_water_meter_ppm_cc_st', 999, 0, 0);" class="span12"  runat="server" MaxLength="5" meta:resourcekey="value_water_meter_ppm_cc_stResource1" ></asp:textbox>
                </div>
                       </div>

                   
                </div>
 </div>
       <!-- fine riga -->
     <!-- riga -->
<div id="div_enable_water_meter_ppm_l_h">
    <div class="row-fluid">
               	<div class="span3">
                       <div id="riga_water_meter_ppm_l_h" class="control-group">
                           <h5 style="padding-top:10px"><asp:literal ID = "Literal16"  text="l/h" runat="server" meta:resourcekey="Literal16Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_water_meter_ppm_l_h" onblur="javascript: Changed_channel( 'value_water_meter_ppm_l_h','riga_water_meter_ppm_l_h',999, 0,0 );" class="span12"  runat="server" MaxLength="3" meta:resourcekey="value_water_meter_ppm_l_hResource1" ></asp:textbox>
                </div>
                       </div>

                   
                </div>
 </div>
       <!-- fine riga -->



                

                </div>
</div>
                 <!-- fine riga -->

<!-- riga -->
                <div class="row-fluid">
               	<div class="span3">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal17"  text="Mode during Bleed" runat="server" meta:resourcekey="Literal17Resource1"></asp:literal></h5>
                    <asp:radiobutton ID="mode_d_bleed_feed" style="margin: 5px 10px 10px 0px;" runat="server"  GroupName="GROUP3" Checked="True" meta:resourcekey="mode_d_bleed_feedResource1"></asp:radiobutton>
                    <asp:literal runat="server" text ="Feed" meta:resourcekey="LiteralResource18"></asp:literal>
                    <asp:radiobutton ID="mode_d_bleed_lock" style="margin: 5px 10px 10px 0px;" runat="server"  GroupName="GROUP3" meta:resourcekey="mode_d_bleed_lockResource1"></asp:radiobutton>
                    <asp:literal runat="server" text ="Lock" meta:resourcekey="LiteralResource19"></asp:literal>

                </div>
                </div>
<!-- fine riga -->



<!-- tab 1 stop-->
                </div>
             </div>
             <div id="salva" class="btn-primary">
                   <b class="btn-primary btn-icon glyphicons ok"><asp:button runat="server" ID="save_inibldt_new" class="btn-primary" data-layout="center" data-type="confirm" data-toggle="notyfy" text="Salva e carica i dati" Font-Bold="True" meta:resourcekey="save_inibldt_newResource1" /><i></i></b>
                </div>
            </div>
        </div>
         </div>
        </div>       


    <script type="text/javascript" src="LDTower/validator_inibitore_ldt.js"></script>
            <script type="text/javascript" src="common/validator_general_notify.js"></script>
<script src="theme/scripts/demo/notifications.js"></script>

    </form>


<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="option_ldt.aspx.vb" Inherits="ermes_web_20.option_ldt" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>

<form id="form" runat="server"  method="post" action="LDTower/option_ldt.aspx">     <!-- CAMBIARE L'INDIRIZZO DEL FILE!!!! -->   
       
    <h3><asp:literal runat="server" text ="Option CoolTrol" ID="message_channel" meta:resourcekey="message_channelResource1"></asp:literal></h3>
    <div class="innerLR">
        <div class="box-generic">
            <div class="tabsbar tabsbar-2">
			<ul class="row-fluid row-merge">
            
                <li class="span2 active" ><a id="tab_tower_sp1" href="#tab_tower_sp1_1"  data-toggle="tab"><asp:literal text="Option"  runat="server" ID="tabtower1_1" meta:resourcekey="tabtower1_1Resource1" ></asp:literal></a></li>
                <li class="span2"><a id="tab_tower_sp2" href="#tab_tower_sp2_2" data-toggle="tab"><asp:literal text="mA Option" runat="server" ID="tabtower1_2" meta:resourcekey="tabtower1_2Resource1"></asp:literal></a></li>
			</ul>
		</div>

            <div class="tab-content">
                <!-- tab 1 start-->
			<div class="tab-pane active" id="tab_tower_sp1_1">
                <div  class="box-generic">
    <!-- riga -->

                <div class="row-fluid">
               	<div class="span3">
                       <div id="riga_option_tau" class="control-group">
                                <h5 style="padding-top:10px"><asp:literal ID = "Literal6"  text="Tau" runat="server" meta:resourcekey="Literal6Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_option_tau" onblur="javascript: Changed_channel( 'value_option_tau','riga_option_tau',30, 0,0 );" class="span12"  runat="server" MaxLength="2" meta:resourcekey="value_option_tauResource1" ></asp:textbox>
                    </div>
                       </div>

                    <div class="span3">
                       <div id="riga_option_coefficiente_temperatura" class="control-group">
                    <h5 style="padding-top:10px"><asp:literal ID = "Literal5"  text="Coefficient Temperature(%)" runat="server" meta:resourcekey="Literal5Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_option_coefficiente_temperatura" onblur="javascript: Changed_channel( 'value_option_coefficiente_temperatura','riga_option_coefficiente_temperatura',5, 0,1 );" class="span12"  runat="server" MaxLength="3" meta:resourcekey="value_option_coefficiente_temperaturaResource1" ></asp:textbox>
                </div>
                       </div>
                </div>
                 <!-- fine riga -->


 <!-- riga -->

                <div class="row-fluid">
               	<div class="span3">
                       <div id="riga_option_startup_delay" class="control-group">
                                <h5 style="padding-top:10px"><asp:literal ID = "Literal1"  text="Startup Delay(min)" runat="server" meta:resourcekey="Literal1Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_option_startup_delay" onblur="javascript: Changed_channel( 'value_option_startup_delay','riga_option_startup_delay',99, 0,0 );" class="span12"  runat="server" MaxLength="2" meta:resourcekey="value_option_startup_delayResource1" ></asp:textbox>
                </div>
                       </div>

                    <div class="span3">
                       <div id="riga_option_flow" class="control-group">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal2"  text="Flow" runat="server" meta:resourcekey="Literal2Resource1"></asp:literal></h5>
                           <asp:dropdownlist runat="server" ID="value_option_flow" meta:resourcekey="value_option_flowResource1">
                               <asp:ListItem Value="0" meta:resourcekey="ListItemResource1">Normal</asp:ListItem>
                               <asp:ListItem Value="1" meta:resourcekey="ListItemResource2">Reverse</asp:ListItem>
                               <asp:ListItem Value="2" meta:resourcekey="ListItemResource3">Disable</asp:ListItem>
                           </asp:dropdownlist>
                       </div>
                       </div>
                </div>
                 <!-- fine riga -->
                        
<!-- riga -->

                <div class="row-fluid">
                    <div class="span3">

                       <div id="riga_option_alarm_out" class="control-group">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal8"  text="Alarm Out" runat="server" meta:resourcekey="Literal8Resource1"></asp:literal></h5>
                          <asp:radiobutton ID="option_alarm_out_no" style="margin: 5px 10px 10px 0px;" runat="server"  GroupName="GROUP1" meta:resourcekey="option_alarm_out_noResource1"></asp:radiobutton>
                            <asp:literal runat="server" text ="N.O." meta:resourcekey="LiteralResource25"></asp:literal>
                            <asp:radiobutton ID="option_alarm_out_nc" style="margin: 5px 10px 10px 0px;" runat="server"  GroupName="GROUP1" meta:resourcekey="option_alarm_out_ncResource1"></asp:radiobutton>
                            <asp:literal runat="server" text ="N.C." meta:resourcekey="LiteralResource26"></asp:literal>
                       </div>
                       </div>
                </div>
                 <!-- fine riga -->
   
                    </div>
                </div>
<!-- tab 1 stop-->

<!-- tab 2 start-->
			<div class="tab-pane" id="tab_tower_sp2_2">
                <div  class="box-generic">
    <!-- riga -->

                <div class="row-fluid">
               	<div class="span3">
                       <div id="riga_option_ma_out" class="control-group">
                                <h5 style="padding-top:10px"><asp:literal ID = "Literal9"  text="mA Output" runat="server" meta:resourcekey="Literal9Resource1"></asp:literal></h5>
                           <asp:dropdownlist runat="server" ID="value_ma_out" meta:resourcekey="value_ma_outResource1">
                               <asp:ListItem Value="0" meta:resourcekey="ListItemResource11">0 - 20 mA</asp:ListItem>
                               <asp:ListItem Value="1" meta:resourcekey="ListItemResource12">4 - 20 mA</asp:ListItem>
                           </asp:dropdownlist>

                </div>
                       </div>
                </div>
                 <!-- fine riga -->


 <!-- riga -->

                <div class="row-fluid">
               	<div class="span3">
                       <div id="riga_option_temperature_ma_h" class="control-group">
                                <h5 style="padding-top:10px"><asp:literal ID = "Literal10"  text="Temperature mA High" runat="server" meta:resourcekey="Literal10Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_option_temperature_ma_h" onblur="javascript: Changed_channel( 'value_option_temperature_ma_h','riga_option_temperature_ma_h',max_temperature, 0,0 );" class="span12"  runat="server" MaxLength="3" meta:resourcekey="value_option_temperature_ma_hResource1" ></asp:textbox>
                </div>
                       </div>

                    <div class="span3">
                       <div id="riga_option_temperature_ma_l" class="control-group">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal11"  text="Temperature mA Low" runat="server" meta:resourcekey="Literal11Resource1"></asp:literal></h5>
                          <asp:textbox ID="value_option_temperature_ma_l" onblur="javascript: Changed_channel( 'value_option_temperature_ma_l','riga_option_temperature_ma_l',max_temperature, 0,0 );" class="span12"  runat="server" MaxLength="3" meta:resourcekey="value_option_temperature_ma_lResource1" ></asp:textbox>
                       </div>
                       </div>
                </div>
                 <!-- fine riga -->
                        
<!-- riga -->
                <div class="row-fluid">
               	<div class="span3">
                       <div id="riga_option_ch1_ma_h" class="control-group">
                                <h5 style="padding-top:10px"><asp:literal ID = "Literal12"  text="Cd mA High" runat="server" meta:resourcekey="Literal12Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_option_ch1_ma_h" onblur="javascript: Changed_channel( 'value_option_ch1_ma_h','riga_option_ch1_ma_h',max_ch1, 0,0 );" class="span12"  runat="server" MaxLength="4" meta:resourcekey="value_option_ch1_ma_hResource1" ></asp:textbox>
                        </div>
                </div>

                    <div class="span3">
                       <div id="riga_option_ch1_ma_l" class="control-group">
                        <h5 style="padding-top:10px"><asp:literal ID = "Literal13"  text="Cd mA Low" runat="server" meta:resourcekey="Literal13Resource1"></asp:literal></h5>
                          <asp:textbox ID="value_option_ch1_ma_l" onblur="javascript: Changed_channel( 'value_option_ch1_ma_l','riga_option_ch1_ma_l',max_ch1, 0,0 );" class="span12"  runat="server" MaxLength="4" meta:resourcekey="value_option_ch1_ma_lResource1" ></asp:textbox>
                       </div>
                    </div>
                </div>

<!-- fine riga -->

<!-- riga -->

                <div class="row-fluid">
               	<div class="span3">
                
                       <div id="riga_option_inhib_wm" class="control-group">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal3"  text="Inhibitor WM" runat="server" meta:resourcekey="Literal3Resource1"></asp:literal></h5>
                           <asp:dropdownlist runat="server" ID="value_option_inhib_wm" meta:resourcekey="value_option_inhib_wmResource1">
                               <asp:ListItem Value="0" meta:resourcekey="ListItemResource1">WM1</asp:ListItem>
                               <asp:ListItem Value="1" meta:resourcekey="ListItemResource2">WM2</asp:ListItem>
                               <asp:ListItem Value="2" meta:resourcekey="ListItemResource3">WM1+WM2</asp:ListItem>
                           </asp:dropdownlist>
                       </div>
                </div>
                </div>

            <div class="row-fluid">
                <div class="span3">

                       <div id="riga_en_dis_option_ma_out" class="control-group">
                        <h5 style="padding-top:10px"><asp:literal ID = "Literal4"  text="mA Out on Alarm" runat="server" meta:resourcekey="Literal4Resource1"></asp:literal></h5>
                          <asp:radiobutton ID="option_enable_ma_out" style="margin: 5px 10px 10px 0px;" runat="server"  GroupName="GROUP2" meta:resourcekey="option_enable_ma_outResource1"></asp:radiobutton>
                            <asp:literal runat="server" text ="Enable" meta:resourcekey="LiteralResource25"></asp:literal>
                            <asp:radiobutton ID="option_disable_ma_out" style="margin: 5px 10px 10px 0px;" runat="server"  GroupName="GROUP2" meta:resourcekey="option_disable_ma_outResource1"></asp:radiobutton>
                            <asp:literal runat="server" text ="Disable" meta:resourcekey="LiteralResource26"></asp:literal>
                       </div>
                </div>

                

<!-- fine riga -->

                 
                   
                </div>
                </div>

<!-- tab 2 stop-->
                </div>
                        <div id="salva" class="btn-primary">
                   <b class="btn-primary btn-icon glyphicons ok"><asp:button runat="server" ID="save_option_ldtower_new" class="btn-primary" data-layout="center" data-type="confirm" data-toggle="notyfy" text="Salva e carica i dati" Font-Bold="True" meta:resourcekey="save_option_ldtower_newResource1" /><i></i></b>

        </div>

            </div>
        </div>
        </div>


    <script type="text/javascript" src="LDTower/validator_option_ldt.js"></script>
                               <script type="text/javascript" src="common/validator_general_notify.js"></script>
<script src="theme/scripts/demo/notifications.js"></script>
</form>

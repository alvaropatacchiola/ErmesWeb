<%@ Page Language="vb" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="setpoint_ch.aspx.vb" Inherits="ermes_web_20.setpoint_ch" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>




<form id="form" runat="server" method="post" action="max5/setpoint_ch.aspx" >

          <!-- inizio FORM-->
            <h3><asp:literal runat="server" text ="Setpoint CH1 pH" ID="setpoint_channel" meta:resourcekey="setpoint_channelResource1"></asp:literal></h3>
            <div class="innerLR">
           <div class="box-generic">
               
		<!-- Tabs Heading -->
		<div class="tabsbar tabsbar-2" >
			<ul class="row-fluid row-merge">
            
<li class="span1 active" style="min-width:80px;" ><a id="tab_1" href="#tab1-4"  data-toggle="tab"><asp:literal text="RelayA"  runat="server" ID="tab1" meta:resourcekey="tab1Resource1" ></asp:literal></a></li>
<li class="span1" style="min-width:80px;"><a id="tab_2" href="#tab2-4" data-toggle="tab"><asp:literal text="RelayB" runat="server" ID="tab2" meta:resourcekey="tab2Resource1"></asp:literal></a></li>
<li class="span1" style="min-width:80px;"><a id="tab_3" href="#tab3-4" data-toggle="tab"><asp:literal text="PulseA" runat="server" ID="tab3" meta:resourcekey="tab3Resource1"></asp:literal></a></li>
<li class="span1" style="min-width:80px;"><a id="tab_4" href="#tab4-4" data-toggle="tab"><asp:literal text="PulseB" runat="server" ID="tab4" meta:resourcekey="tab4Resource1"></asp:literal></a></li>
<li class="span1" style="min-width:80px;"><a id="tab_5" href="#tab5-4" data-toggle="tab"><asp:literal text="mA" runat="server" ID="tab5" meta:resourcekey="tab5Resource1"></asp:literal></a></li>
<li class="span1" style="min-width:80px;"><a id="tab_6" href="#tab6-4" data-toggle="tab"><asp:literal text="AlarmA" runat="server" ID="tab6" meta:resourcekey="tab6Resource1"></asp:literal></a></li>
<li class="span1" style="min-width:80px;"><a id="tab_7" href="#tab7-4" data-toggle="tab"><asp:literal text="AlarmB" runat="server" ID="tab7" meta:resourcekey="tab7Resource1"></asp:literal></a></li>
<li class="span1" style="min-width:80px;"><a id="tab_8" href="#tab8-4" data-toggle="tab"><asp:literal text="Dosing" runat="server" ID="tab8" meta:resourcekey="tab8Resource1"></asp:literal></a></li>
<li class="span1" style="min-width:80px;"><a id="tab_9" href="#tab9-4" data-toggle="tab"><asp:literal text="Reading" runat="server" ID="tab9" meta:resourcekey="tab9Resource1"></asp:literal></a></li>

			</ul>
		</div>
		<!-- // Tabs Heading END -->
		
		<div class="tab-content">

			<!-- Tab content -->
<!-- tab 1 start-->
			<div class="tab-pane active" id="tab1-4">
				
				<div  class="box-generic">
                <!-- riga -->
                <div class="row-fluid">
               	<div class="span3">
              <h5 style="padding-top:10px"><asp:literal ID = "Label7"  text="RelayA" runat="server" meta:resourcekey="Label7Resource1"></asp:literal></h5>
                    <asp:radiobutton ID="enable_aa" style="margin: 5px 10px 10px 0px;" runat="server"  GroupName="GROUP1" meta:resourcekey="enable_aaResource1"></asp:radiobutton>
                    <asp:literal runat="server" text ="Enable" meta:resourcekey="LiteralResource1"></asp:literal>
                    <asp:radiobutton ID="disable_aa" style="margin: 5px 10px 10px 0px;" runat="server"  GroupName="GROUP1" meta:resourcekey="disable_aaResource1"></asp:radiobutton>
                       <asp:literal runat="server" text ="Disable" meta:resourcekey="LiteralResource2"></asp:literal>
                </div>
                </div>
                 <!-- fine riga -->
                <!-- riga -->
<div id ="div_enable_aa">
                <div class="row-fluid">
               	<div  class="span3">

                <h5 style="padding-top:10px"><asp:literal ID = "Label42"  text="Working mode" runat="server" meta:resourcekey="Label42Resource1"></asp:literal></h5>
                    <asp:radiobutton ID="on_off_aa" style="margin: 5px 10px 10px 0px;"  runat="server" GroupName="GROUP2" meta:resourcekey="on_off_aaResource1"></asp:radiobutton>
                       <asp:literal runat="server" text ="ON/OFF" meta:resourcekey="LiteralResource3"></asp:literal>
                    <asp:radiobutton ID="pwm_aa" style="margin: 5px 10px 10px 0px;"  runat="server"  GroupName="GROUP2" meta:resourcekey="pwm_aaResource1"></asp:radiobutton>
                       <asp:literal runat="server" text ="PWM" meta:resourcekey="LiteralResource4"></asp:literal>
                    <asp:radiobutton ID="pid_aa" style="margin: 5px 10px 10px 0px;"  runat="server"  GroupName="GROUP2" meta:resourcekey="pid_aaResource1"></asp:radiobutton>
                       <asp:literal runat="server" text ="PID" meta:resourcekey="LiteralResource5"></asp:literal>
                </div>
                </div>
                 <!-- fine riga -->
                 <!-- riga -->
                <div  class="row-fluid">
                <div class="span2">
                <div id="riga_aa_1_1" class="control-group">
                <h5 style="padding-top:10px" class="control-label"><asp:literal ID = "Label12"  text="Value ON" runat="server" meta:resourcekey="Label12Resource1"></asp:literal></h5>
                <div class="row-fluid">
                    
                <asp:textbox ID="value_on_aa_id" class="span12"  runat="server"  onblur="javascript: Changed_channel( 'value_on_aa_id','riga_aa_1_1',max_ch_value, min_ch_value,max_fix_value );" MaxLength="5" meta:resourcekey="value_on_aa_idResource1"></asp:textbox>
                   </div>
                </div>
                 </div>
                <div id="percent_on_aa" class="span2">
                    <div id="riga_aa_1_2" class="control-group">
                <asp:label  ID = "label_percent_aa_1"  text="<h5 class='control-label' style='padding-top:10px'>%</h5> " runat="server" meta:resourcekey="label_percent_aa_1Resource1"></asp:label>
                <asp:textbox ID="value_perc1_aa_id" class="span12" onblur="javascript: Changed_channel( 'value_perc1_aa_id','riga_aa_1_2',max_percent_value,min_percent_value,0 );"  runat="server" MaxLength="3" meta:resourcekey="value_perc1_aa_idResource1"></asp:textbox>
                        </div>
                </div>
                </div>
                 <!-- fine riga -->
                 <!-- fine riga -->
                 <!-- riga -->
                <div  class="row-fluid">
               	<div  class="span2">
                <div id="riga_aa_2_1" class="control-group">
                <h5 style="padding-top:10px" class="control-label"><asp:literal ID = "label43"  text="Value OFF" runat="server" meta:resourcekey="label43Resource1"></asp:literal></h5>
                <div class="row-fluid">
                <asp:textbox ID="value_off_aa_id" class="span12"  onblur="javascript: Changed_channel( 'value_off_aa_id','riga_aa_2_1',max_ch_value,min_ch_value,max_fix_value );" runat="server" MaxLength="5" meta:resourcekey="value_off_aa_idResource1"></asp:textbox>
                
                </div>
                </div>
                </div>
                <div id="percent_off_aa" class="span2">
                  <div id="riga_aa_2_2" class="control-group">
                <asp:label  ID = "label_percent_aa_2"  text="<h5 class='control-label' style='padding-top:10px'>%</h5>" runat="server" meta:resourcekey="label_percent_aa_2Resource1"></asp:label>
                
                <asp:textbox ID="value_perc2_aa_id" class="span12" onblur="javascript: Changed_channel( 'value_perc2_aa_id','riga_aa_2_2',max_percent_value,min_percent_value,0);" runat="server" MaxLength="3" meta:resourcekey="value_perc2_aa_idResource1"></asp:textbox>
                        </div>
                </div>
                </div>
                 <!-- fine riga -->
                   <!-- riga -->
                <div  class="row-fluid">
               	<div class="span2">
                <h5 style="padding-top:10px"><asp:literal ID = "label46"  text="Out Relay" runat="server" meta:resourcekey="label46Resource1"></asp:literal></h5>
                 <asp:dropdownlist ID="index_relay_aa" class="span12" runat="server" meta:resourcekey="index_relay_aaResource1">
                     <asp:ListItem Value="0" meta:resourcekey="ListItemResource1">X</asp:ListItem>
                     <asp:ListItem Value="1" meta:resourcekey="ListItemResource2">Relay 1</asp:ListItem>
                     <asp:ListItem Value="2" meta:resourcekey="ListItemResource3">Relay 2</asp:ListItem>
                     <asp:ListItem Value="3" meta:resourcekey="ListItemResource4">Relay 3</asp:ListItem>
                     <asp:ListItem Value="4" meta:resourcekey="ListItemResource5">Relay 4</asp:ListItem>
                     <asp:ListItem Value="5" meta:resourcekey="ListItemResource6">Relay 5</asp:ListItem>
                     <asp:ListItem Value="6" meta:resourcekey="ListItemResource7">Relay 6</asp:ListItem>
                    </asp:dropdownlist>
               	</div>
                  <div class="span2">
                <h5 style="padding-top:10px"><asp:literal ID = "id_aa_name_relay"  text="Name Relay" runat="server" meta:resourcekey="id_aa_name_relayResource1"></asp:literal></h5>
                    <asp:textbox ID="id_aa_name_relay_t" class="span12" runat="server" MaxLength="10" meta:resourcekey="id_aa_name_relay_tResource1"></asp:textbox>
                  </div>
                </div>
                 <!-- fine riga -->
                      <!-- riga -->
                <div class="row-fluid">
               	<div class="span2">
                <h5 style="padding-top:10px"><asp:literal ID = "label47"  text="Input" runat="server" meta:resourcekey="label47Resource1"></asp:literal></h5> 
                       
                    <asp:dropdownlist ID="index_level_aa" class="span12" runat="server" meta:resourcekey="index_level_aaResource1">
                        <asp:ListItem Value="0" meta:resourcekey="ListItemResource8">X</asp:ListItem>
                        <asp:ListItem Value="1" meta:resourcekey="ListItemResource9">Input 1</asp:ListItem>
                        <asp:ListItem Value="2" meta:resourcekey="ListItemResource10">Input 2</asp:ListItem>
                        <asp:ListItem Value="3" meta:resourcekey="ListItemResource11">Input 3</asp:ListItem>
                        <asp:ListItem Value="4" meta:resourcekey="ListItemResource12">Input 4</asp:ListItem>
                        <asp:ListItem Value="5" meta:resourcekey="ListItemResource13">Input 5</asp:ListItem>
                    </asp:dropdownlist>
                           
                </div>
                  <div class="span2">
                <h5 style="padding-top:10px"><asp:literal ID = "id_aa_name_input"  text="Name Input" runat="server" meta:resourcekey="id_aa_name_inputResource1"></asp:literal></h5>
                    <asp:textbox ID="id_aa_name_input_t" class="span12" runat="server" MaxLength="10" meta:resourcekey="id_aa_name_input_tResource1"></asp:textbox>
                </div>
                  <div class="span2">
                <h5 style="padding-top:10px"><asp:literal ID = "label48"  text="Stop On Input" runat="server" meta:resourcekey="label48Resource1"></asp:literal></h5>
                      
                    <asp:dropdownlist ID="stop_input_aa" class="span12" runat="server" meta:resourcekey="stop_input_aaResource1">
                        <asp:ListItem Value="0" meta:resourcekey="ListItemResource14">Yes</asp:ListItem>
                        <asp:ListItem Value="1" meta:resourcekey="ListItemResource15">No</asp:ListItem>
                      </asp:dropdownlist>
           
                </div>
                 <div class="span2">
                <h5 style="padding-top:10px"><asp:literal ID = "Literal15"  text="MSG Input" runat="server" meta:resourcekey="Literal15Resource1"></asp:literal></h5>
                     
                <asp:checkbox ID="sms_check_aa" style="margin: 5px 10px 10px 0px;" runat="server" meta:resourcekey="sms_check_aaResource1" ></asp:checkbox>
             
                </div>
                </div>
                 <!-- fine riga -->
                 
                </div>
                
                </div>
			<!-- // Tab content END -->
			
			</div>
<!-- tab 1 stop-->
<!-- tab 2 start-->
			<div class="tab-pane" id="tab2-4">
				<div  class="box-generic">
                <!-- riga -->
                <div class="row-fluid">
               	<div class="span3">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal1"  text="RelayB" runat="server" meta:resourcekey="Literal1Resource1"></asp:literal></h5>
                    <asp:radiobutton ID="enable_ab" style="margin: 5px 10px 10px 0px;" runat="server"  GroupName="GROUP3" meta:resourcekey="enable_abResource1"></asp:radiobutton>
                    <asp:literal runat="server" text ="Enable" meta:resourcekey="LiteralResource6"></asp:literal>
                    <asp:radiobutton ID="disable_ab" style="margin: 5px 10px 10px 0px;" runat="server"  GroupName="GROUP3" meta:resourcekey="disable_abResource1"></asp:radiobutton>
                       <asp:literal runat="server" text ="Disable" meta:resourcekey="LiteralResource7"></asp:literal>
                </div>
                </div>
                 <!-- fine riga -->
                <!-- riga -->
<div id ="div_enable_ab">
                <div class="row-fluid">
               	<div  class="span3">

                <h5 style="padding-top:10px"><asp:literal ID = "Literal4"  text="Working mode" runat="server" meta:resourcekey="Literal4Resource1"></asp:literal></h5>
                    <asp:radiobutton ID="on_off_ab" style="margin: 5px 10px 10px 0px;"  runat="server" GroupName="GROUP4" meta:resourcekey="on_off_abResource1"></asp:radiobutton>
                       <asp:literal runat="server" text ="ON/OFF" meta:resourcekey="LiteralResource8"></asp:literal>
                    <asp:radiobutton ID="pwm_ab" style="margin: 5px 10px 10px 0px;"  runat="server"  GroupName="GROUP4" meta:resourcekey="pwm_abResource1"></asp:radiobutton>
                       <asp:literal runat="server" text ="PWM" meta:resourcekey="LiteralResource9"></asp:literal>
                    <asp:radiobutton ID="pid_ab" style="margin: 5px 10px 10px 0px;"  runat="server"  GroupName="GROUP4" meta:resourcekey="pid_abResource1"></asp:radiobutton>
                       <asp:literal runat="server" text ="PID" meta:resourcekey="LiteralResource10"></asp:literal>
                </div>
                </div>
                 <!-- fine riga -->
                 <!-- riga -->
                <div  class="row-fluid">
                <div class="span2">
                <div id="riga_ab_1_1" class="control-group">
                <h5 style="padding-top:10px" class="control-label"><asp:literal ID = "Literal8"  text="Value ON" runat="server" meta:resourcekey="Literal8Resource1"></asp:literal></h5>
                <div class="row-fluid">
                    
                <asp:textbox ID="value_on_ab_id" class="span12"  runat="server"  onblur="javascript: Changed_channel( 'value_on_ab_id','riga_ab_1_1',max_ch_value, min_ch_value );" MaxLength="5" meta:resourcekey="value_on_ab_idResource1"></asp:textbox>
                   </div>
                </div>
                 </div>
                <div id="percent_on_ab" class="span2">
                    <div id="riga_ab_1_2" class="control-group">
                <asp:label  ID = "label_percent_ab_1"  text="<h5 class='control-label' style='padding-top:10px'>%</h5> " runat="server" meta:resourcekey="label_percent_ab_1Resource1"></asp:label>
                <asp:textbox ID="value_perc1_ab_id" class="span12" onblur="javascript: Changed_channel( 'value_perc1_ab_id','riga_ab_1_2',max_percent_value,min_percent_value,0 );"  runat="server" MaxLength="3" meta:resourcekey="value_perc1_ab_idResource1"></asp:textbox>
                        </div>
                </div>
                </div>
                 <!-- fine riga -->
                 <!-- fine riga -->
                 <!-- riga -->
                <div  class="row-fluid">
               	<div  class="span2">
                <div id="riga_ab_2_1" class="control-group">
                <h5 style="padding-top:10px" class="control-label"><asp:literal ID = "Literal9"  text="Value OFF" runat="server" meta:resourcekey="Literal9Resource1"></asp:literal></h5>
                <div class="row-fluid">
                <asp:textbox ID="value_off_ab_id" class="span12"  onblur="javascript: Changed_channel( 'value_off_ab_id','riga_ab_2_1',max_ch_value,min_ch_value,max_fix_value );" runat="server" MaxLength="5" meta:resourcekey="value_off_ab_idResource1"></asp:textbox>
                
                </div>
                </div>
                </div>
                <div id="percent_off_ab" class="span2">
                  <div id="riga_ab_2_2" class="control-group">
                <asp:label  ID = "label_percent_ab_2"  text="<h5 class='control-label' style='padding-top:10px'>%</h5>" runat="server" meta:resourcekey="label_percent_ab_2Resource1"></asp:label>
                
                <asp:textbox ID="value_perc2_ab_id" class="span12" onblur="javascript: Changed_channel( 'value_perc2_ab_id','riga_ab_2_2',max_percent_value,min_percent_value,0);" runat="server" MaxLength="3" meta:resourcekey="value_perc2_ab_idResource1"></asp:textbox>
                        </div>
                </div>
                </div>
                 <!-- fine riga -->
                   <!-- riga -->
                <div  class="row-fluid">
               	<div class="span2">
                <h5 style="padding-top:10px"><asp:literal ID = "Literal10"  text="Out Relay" runat="server" meta:resourcekey="Literal10Resource1"></asp:literal></h5>
                 <asp:dropdownlist ID="index_relay_ab" class="span12" runat="server" meta:resourcekey="index_relay_abResource1">
                     <asp:ListItem Value="0" meta:resourcekey="ListItemResource16">X</asp:ListItem>
                     <asp:ListItem Value="1" meta:resourcekey="ListItemResource17">Relay 1</asp:ListItem>
                     <asp:ListItem Value="2" meta:resourcekey="ListItemResource18">Relay 2</asp:ListItem>
                     <asp:ListItem Value="3" meta:resourcekey="ListItemResource19">Relay 3</asp:ListItem>
                     <asp:ListItem Value="4" meta:resourcekey="ListItemResource20">Relay 4</asp:ListItem>
                     <asp:ListItem Value="5" meta:resourcekey="ListItemResource21">Relay 5</asp:ListItem>
                     <asp:ListItem Value="6" meta:resourcekey="ListItemResource22">Relay 6</asp:ListItem>
                    </asp:dropdownlist>
               	</div>
                  <div class="span2">
                <h5 style="padding-top:10px"><asp:literal ID = "id_ab_name_relay"  text="Name Relay" runat="server" meta:resourcekey="id_ab_name_relayResource1"></asp:literal></h5>
                    <asp:textbox ID="id_ab_name_relay_t" class="span12" runat="server" MaxLength="10" meta:resourcekey="id_ab_name_relay_tResource1"></asp:textbox>
                  </div>
                </div>
                 <!-- fine riga -->
                      <!-- riga -->
                <div class="row-fluid">
               	<div class="span2">
                <h5 style="padding-top:10px"><asp:literal ID = "Literal11"  text="Input" runat="server" meta:resourcekey="Literal11Resource1"></asp:literal></h5> 
                       
                    <asp:dropdownlist ID="index_level_ab" class="span12" runat="server" meta:resourcekey="index_level_abResource1">
                        <asp:ListItem Value="0" meta:resourcekey="ListItemResource23">X</asp:ListItem>
                        <asp:ListItem Value="1" meta:resourcekey="ListItemResource24">Input 1</asp:ListItem>
                        <asp:ListItem Value="2" meta:resourcekey="ListItemResource25">Input 2</asp:ListItem>
                        <asp:ListItem Value="3" meta:resourcekey="ListItemResource26">Input 3</asp:ListItem>
                        <asp:ListItem Value="4" meta:resourcekey="ListItemResource27">Input 4</asp:ListItem>
                        <asp:ListItem Value="5" meta:resourcekey="ListItemResource28">Input 5</asp:ListItem>
                    </asp:dropdownlist>
                           
                </div>
                  <div class="span2">
                <h5 style="padding-top:10px"><asp:literal ID = "id_ab_name_input"  text="Name Input" runat="server" meta:resourcekey="id_ab_name_inputResource1"></asp:literal></h5>
                    <asp:textbox ID="id_ab_name_input_t" class="span12" runat="server" MaxLength="10" meta:resourcekey="id_ab_name_input_tResource1"></asp:textbox>
                </div>
                  <div class="span2">
                <h5 style="padding-top:10px"><asp:literal ID = "Literal12"  text="Stop On Input" runat="server" meta:resourcekey="Literal12Resource1"></asp:literal></h5>
                      
                    <asp:dropdownlist ID="stop_input_ab" class="span12" runat="server" meta:resourcekey="stop_input_abResource1">
                        <asp:ListItem Value="0" meta:resourcekey="ListItemResource29">Yes</asp:ListItem>
                        <asp:ListItem Value="1" meta:resourcekey="ListItemResource30">No</asp:ListItem>
                      </asp:dropdownlist>
           
                </div>
                 <div class="span2">
                <h5 style="padding-top:10px"><asp:literal ID = "Literal13"  text="MSG Input" runat="server" meta:resourcekey="Literal13Resource1"></asp:literal></h5>
                     
                <asp:checkbox ID="sms_check_ab" style="margin: 5px 10px 10px 0px;" runat="server" meta:resourcekey="sms_check_abResource1" ></asp:checkbox>
             
                </div>
                </div>
                 <!-- fine riga -->
                 
                </div>
                
                </div>
			<!-- // Tab content END -->				

			</div>
<!-- tab 2 stop-->
<!-- tab 3 start-->
			<div class="tab-pane" id="tab3-4">
				
				<div  class="box-generic">
                <!-- riga -->
                <div class="row-fluid">
               	<div class="span3">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal2"  text="PulseA" runat="server" meta:resourcekey="Literal2Resource1"></asp:literal></h5>
                    <asp:radiobutton ID="enable_pa" style="margin: 5px 10px 10px 0px;" runat="server"  GroupName="GROUP5" meta:resourcekey="enable_paResource1"></asp:radiobutton>
                    <asp:literal runat="server" text ="Enable" meta:resourcekey="LiteralResource11"></asp:literal>
                    <asp:radiobutton ID="disable_pa" style="margin: 5px 10px 10px 0px;" runat="server"  GroupName="GROUP5" meta:resourcekey="disable_paResource1"></asp:radiobutton>
                       <asp:literal runat="server" text ="Disable" meta:resourcekey="LiteralResource12"></asp:literal>
                </div>
                </div>
                 <!-- fine riga -->
                <!-- riga -->
<div id ="div_enable_pa">
                 <!-- fine riga -->
                 <!-- riga -->
                <div  class="row-fluid">
                <div class="span2">
                <div id="riga_pa_1_1" class="control-group">
                <h5 style="padding-top:10px" class="control-label"><asp:literal ID = "Literal17"  text="Value Pulse 1" runat="server" meta:resourcekey="Literal17Resource1"></asp:literal></h5>
                <div class="row-fluid">
                    
                <asp:textbox ID="value_on_pa_id" class="span12"  runat="server"  onblur="javascript: Changed_channel( 'value_on_pa_id','riga_pa_1_1',max_ch_value, min_ch_value,max_fix_value );" MaxLength="5" meta:resourcekey="value_on_pa_idResource1"></asp:textbox>
                   </div>
                </div>
                 </div>
                <div id="percent_on_pa" class="span2">
                    <div id="riga_pa_1_2" class="control-group">
                <asp:label  ID = "label_percent_pa_1"  text="<h5 class='control-label' style='padding-top:10px'>Pulse/minute</h5> " runat="server" meta:resourcekey="label_percent_pa_1Resource1"></asp:label>
                <asp:textbox ID="value_perc1_pa_id" class="span12" onblur="javascript: Changed_channel( 'value_perc1_pa_id','riga_pa_1_2',max_pulse_value,min_pulse_value,0 );"  runat="server" MaxLength="3" meta:resourcekey="value_perc1_pa_idResource1"></asp:textbox>
                        </div>
                </div>
                </div>
                 <!-- fine riga -->
                 <!-- fine riga -->
                 <!-- riga -->
                <div  class="row-fluid">
               	<div  class="span2">
                <div id="riga_pa_2_1" class="control-group">
                <h5 style="padding-top:10px" class="control-label"><asp:literal ID = "Literal18"  text="Value Pulse 2" runat="server" meta:resourcekey="Literal18Resource1"></asp:literal></h5>
                <div class="row-fluid">
                <asp:textbox ID="value_off_pa_id" class="span12"  onblur="javascript: Changed_channel( 'value_off_pa_id','riga_pa_2_1',max_ch_value,min_ch_value,max_fix_value );" runat="server" MaxLength="5" meta:resourcekey="value_off_pa_idResource1"></asp:textbox>
                
                </div>
                </div>
                </div>
                <div id="percent_off_pa" class="span2">
                  <div id="riga_pa_2_2" class="control-group">
                <asp:label  ID = "label_percent_pa_2"  text="<h5 class='control-label' style='padding-top:10px'>Pulse / minute</h5>" runat="server" meta:resourcekey="label_percent_pa_2Resource1"></asp:label>
                
                <asp:textbox ID="value_perc2_pa_id" class="span12" onblur="javascript: Changed_channel( 'value_perc2_pa_id','riga_pa_2_2',max_pulse_value,min_pulse_value,0);" runat="server" MaxLength="3" meta:resourcekey="value_perc2_pa_idResource1"></asp:textbox>
                        </div>
                </div>
                </div>
                 <!-- fine riga -->
                   <!-- riga -->
                <div  class="row-fluid">
               	<div class="span2">
                <h5 style="padding-top:10px"><asp:literal ID = "Literal19"  text="Out Pulse" runat="server" meta:resourcekey="Literal19Resource1"></asp:literal></h5>
                 <asp:dropdownlist ID="index_pulse_pa" class="span12" runat="server" meta:resourcekey="index_pulse_paResource1">
                     <asp:ListItem Value="0" meta:resourcekey="ListItemResource31">X</asp:ListItem>
                     <asp:ListItem Value="1" meta:resourcekey="ListItemResource32">Pulse 1</asp:ListItem>
                     <asp:ListItem Value="2" meta:resourcekey="ListItemResource33">Pulse 2</asp:ListItem>
                     <asp:ListItem Value="3" meta:resourcekey="ListItemResource34">Pulse 3</asp:ListItem>
                     <asp:ListItem Value="4" meta:resourcekey="ListItemResource35">Pulse 4</asp:ListItem>
                     <asp:ListItem Value="5" meta:resourcekey="ListItemResource36">Pulse 5</asp:ListItem>
                     <asp:ListItem Value="6" meta:resourcekey="ListItemResource37">Pulse 6</asp:ListItem>
                    </asp:dropdownlist>
               	</div>
                  <div class="span2">
                <h5 style="padding-top:10px"><asp:literal ID = "id_pa_name_pulse"  text="Name Pulse" runat="server" meta:resourcekey="id_pa_name_pulseResource1"></asp:literal></h5>
                    <asp:textbox ID="id_pa_name_pulse_t" class="span12" runat="server" MaxLength="10" meta:resourcekey="id_pa_name_pulse_tResource1"></asp:textbox>
                  </div>
                </div>
                 <!-- fine riga -->
                      <!-- riga -->
                <div class="row-fluid">
               	<div class="span2">
                <h5 style="padding-top:10px"><asp:literal ID = "Literal20"  text="Input" runat="server" meta:resourcekey="Literal20Resource1"></asp:literal></h5> 
                       
                    <asp:dropdownlist ID="index_level_pa" class="span12" runat="server" meta:resourcekey="index_level_paResource1">
                        <asp:ListItem Value="0" meta:resourcekey="ListItemResource38">X</asp:ListItem>
                        <asp:ListItem Value="1" meta:resourcekey="ListItemResource39">Input 1</asp:ListItem>
                        <asp:ListItem Value="2" meta:resourcekey="ListItemResource40">Input 2</asp:ListItem>
                        <asp:ListItem Value="3" meta:resourcekey="ListItemResource41">Input 3</asp:ListItem>
                        <asp:ListItem Value="4" meta:resourcekey="ListItemResource42">Input 4</asp:ListItem>
                        <asp:ListItem Value="5" meta:resourcekey="ListItemResource43">Input 5</asp:ListItem>
                    </asp:dropdownlist>
                           
                </div>
                  <div class="span2">
                <h5 style="padding-top:10px"><asp:literal ID = "id_pa_name_input"  text="Name Input" runat="server" meta:resourcekey="id_pa_name_inputResource1"></asp:literal></h5>
                    <asp:textbox ID="id_pa_name_input_t" class="span12" runat="server" MaxLength="10" meta:resourcekey="id_pa_name_input_tResource1"></asp:textbox>
                </div>
                  <div class="span2">
                <h5 style="padding-top:10px"><asp:literal ID = "Literal21"  text="Stop On Input" runat="server" meta:resourcekey="Literal21Resource1"></asp:literal></h5>
                      
                    <asp:dropdownlist ID="stop_input_pa" class="span12" runat="server" meta:resourcekey="stop_input_paResource1">
                        <asp:ListItem Value="0" meta:resourcekey="ListItemResource44">Yes</asp:ListItem>
                        <asp:ListItem Value="1" meta:resourcekey="ListItemResource45">No</asp:ListItem>
                      </asp:dropdownlist>
           
                </div>
                 <div class="span2">
                <h5 style="padding-top:10px"><asp:literal ID = "Literal22"  text="MSG Input" runat="server" meta:resourcekey="Literal22Resource1"></asp:literal></h5>
                     
                <asp:checkbox ID="sms_check_pa" style="margin: 5px 10px 10px 0px;" runat="server" meta:resourcekey="sms_check_paResource1" ></asp:checkbox>
             
                </div>
                </div>
                 <!-- fine riga -->
                 
                </div>
                
                </div>
			<!-- // Tab content END -->
			
			</div>
<!-- tab 3 stop-->
<!-- tab 4 start-->
			<div class="tab-pane" id="tab4-4">
				
				<div  class="box-generic">
                <!-- riga -->
                <div class="row-fluid">
               	<div class="span3">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal3"  text="PulseB" runat="server" meta:resourcekey="Literal3Resource1"></asp:literal></h5>
                    <asp:radiobutton ID="enable_pb" style="margin: 5px 10px 10px 0px;" runat="server"  GroupName="GROUP6" meta:resourcekey="enable_pbResource1"></asp:radiobutton>
                    <asp:literal runat="server" text ="Enable" meta:resourcekey="LiteralResource13"></asp:literal>
                    <asp:radiobutton ID="disable_pb" style="margin: 5px 10px 10px 0px;" runat="server"  GroupName="GROUP6" meta:resourcekey="disable_pbResource1"></asp:radiobutton>
                       <asp:literal runat="server" text ="Disable" meta:resourcekey="LiteralResource14"></asp:literal>
                </div>
                </div>
                 <!-- fine riga -->
                <!-- riga -->
<div id ="div_enable_pb">
                 <!-- fine riga -->
                 <!-- riga -->
                <div  class="row-fluid">
                <div class="span2">
                <div id="riga_pb_1_1" class="control-group">
                <h5 style="padding-top:10px" class="control-label"><asp:literal ID = "Literal7"  text="Value Pulse 1" runat="server" meta:resourcekey="Literal7Resource1"></asp:literal></h5>
                <div class="row-fluid">
                    
                <asp:textbox ID="value_on_pb_id" class="span12"  runat="server"  onblur="javascript: Changed_channel( 'value_on_pb_id','riga_pb_1_1',max_ch_value, min_ch_value,max_fix_value );" MaxLength="5" meta:resourcekey="value_on_pb_idResource1"></asp:textbox>
                   </div>
                </div>
                 </div>
                <div id="percent_on_pb" class="span2">
                    <div id="riga_pb_1_2" class="control-group">
                <asp:label  ID = "label_percent_pb_1"  text="<h5 class='control-label' style='padding-top:10px'>Pulse/minute</h5> " runat="server" meta:resourcekey="label_percent_pb_1Resource1"></asp:label>
                <asp:textbox ID="value_perc1_pb_id" class="span12" onblur="javascript: Changed_channel( 'value_perc1_pb_id','riga_pb_1_2',max_pulse_value,min_pulse_value,0 );"  runat="server" MaxLength="3" meta:resourcekey="value_perc1_pb_idResource1"></asp:textbox>
                        </div>
                </div>
                </div>
                 <!-- fine riga -->
                 <!-- fine riga -->
                 <!-- riga -->
                <div  class="row-fluid">
               	<div  class="span2">
                <div id="riga_pb_2_1" class="control-group">
                <h5 style="padding-top:10px" class="control-label"><asp:literal ID = "Literal14"  text="Value Pulse 2" runat="server" meta:resourcekey="Literal14Resource1"></asp:literal></h5>
                <div class="row-fluid">
                <asp:textbox ID="value_off_pb_id" class="span12"  onblur="javascript: Changed_channel( 'value_off_pb_id','riga_pb_2_1',max_ch_value,min_ch_value,max_fix_value );" runat="server" MaxLength="5" meta:resourcekey="value_off_pb_idResource1"></asp:textbox>
                
                </div>
                </div>
                </div>
                <div id="percent_off_pb" class="span2">
                  <div id="riga_pb_2_2" class="control-group">
                <asp:label  ID = "label_percent_pb_2"  text="<h5 class='control-label' style='padding-top:10px'>Pulse / minute</h5>" runat="server" meta:resourcekey="label_percent_pb_2Resource1"></asp:label>
                
                <asp:textbox ID="value_perc2_pb_id" class="span12" onblur="javascript: Changed_channel( 'value_perc2_pb_id','riga_pb_2_2',max_pulse_value,min_pulse_value,0);" runat="server" MaxLength="3" meta:resourcekey="value_perc2_pb_idResource1"></asp:textbox>
                        </div>
                </div>
                </div>
                 <!-- fine riga -->
                   <!-- riga -->
                <div  class="row-fluid">
               	<div class="span2">
                <h5 style="padding-top:10px"><asp:literal ID = "Literal16"  text="Out Pulse" runat="server" meta:resourcekey="Literal16Resource1"></asp:literal></h5>
                 <asp:dropdownlist ID="index_pulse_pb" class="span12" runat="server" meta:resourcekey="index_pulse_pbResource1">
                     <asp:ListItem Value="0" meta:resourcekey="ListItemResource46">X</asp:ListItem>
                     <asp:ListItem Value="1" meta:resourcekey="ListItemResource47">Pulse 1</asp:ListItem>
                     <asp:ListItem Value="2" meta:resourcekey="ListItemResource48">Pulse 2</asp:ListItem>
                     <asp:ListItem Value="3" meta:resourcekey="ListItemResource49">Pulse 3</asp:ListItem>
                     <asp:ListItem Value="4" meta:resourcekey="ListItemResource50">Pulse 4</asp:ListItem>
                     <asp:ListItem Value="5" meta:resourcekey="ListItemResource51">Pulse 5</asp:ListItem>
                     <asp:ListItem Value="6" meta:resourcekey="ListItemResource52">Pulse 6</asp:ListItem>
                    </asp:dropdownlist>
               	</div>
                  <div class="span2">
                <h5 style="padding-top:10px"><asp:literal ID = "id_pb_name_pulse"  text="Name Pulse" runat="server" meta:resourcekey="id_pb_name_pulseResource1"></asp:literal></h5>
                    <asp:textbox ID="id_pb_name_pulse_t" class="span12" runat="server" MaxLength="10" meta:resourcekey="id_pb_name_pulse_tResource1"></asp:textbox>
                  </div>
                </div>
                 <!-- fine riga -->
                      <!-- riga -->
                <div class="row-fluid">
               	<div class="span2">
                <h5 style="padding-top:10px"><asp:literal ID = "Literal23"  text="Input" runat="server" meta:resourcekey="Literal23Resource1"></asp:literal></h5> 
                       
                    <asp:dropdownlist ID="index_level_pb" class="span12" runat="server" meta:resourcekey="index_level_pbResource1">
                        <asp:ListItem Value="0" meta:resourcekey="ListItemResource53">X</asp:ListItem>
                        <asp:ListItem Value="1" meta:resourcekey="ListItemResource54">Input 1</asp:ListItem>
                        <asp:ListItem Value="2" meta:resourcekey="ListItemResource55">Input 2</asp:ListItem>
                        <asp:ListItem Value="3" meta:resourcekey="ListItemResource56">Input 3</asp:ListItem>
                        <asp:ListItem Value="4" meta:resourcekey="ListItemResource57">Input 4</asp:ListItem>
                        <asp:ListItem Value="5" meta:resourcekey="ListItemResource58">Input 5</asp:ListItem>
                    </asp:dropdownlist>
                           
                </div>
                  <div class="span2">
                <h5 style="padding-top:10px"><asp:literal ID = "id_pb_name_input"  text="Name Input" runat="server" meta:resourcekey="id_pb_name_inputResource1"></asp:literal></h5>
                    <asp:textbox ID="id_pb_name_input_t" class="span12" runat="server" MaxLength="10" meta:resourcekey="id_pb_name_input_tResource1"></asp:textbox>
                </div>
                  <div class="span2">
                <h5 style="padding-top:10px"><asp:literal ID = "Literal24"  text="Stop On Input" runat="server" meta:resourcekey="Literal24Resource1"></asp:literal></h5>
                      
                    <asp:dropdownlist ID="stop_input_pb" class="span12" runat="server" meta:resourcekey="stop_input_pbResource1">
                        <asp:ListItem Value="0" meta:resourcekey="ListItemResource59">Yes</asp:ListItem>
                        <asp:ListItem Value="1" meta:resourcekey="ListItemResource60">No</asp:ListItem>
                      </asp:dropdownlist>
           
                </div>
                 <div class="span2">
                <h5 style="padding-top:10px"><asp:literal ID = "Literal25"  text="MSG Input" runat="server" meta:resourcekey="Literal25Resource1"></asp:literal></h5>
                     
                <asp:checkbox ID="sms_check_pb" style="margin: 5px 10px 10px 0px;" runat="server" meta:resourcekey="sms_check_pbResource1" ></asp:checkbox>
             
                </div>
                </div>
                 <!-- fine riga -->
                 
                </div>
                
                </div>
			<!-- // Tab content END -->
			
			</div>
<!-- tab 4 stop-->
<!-- tab 5 start-->
			<div class="tab-pane" id="tab5-4">
				
				<div id ="tab_ma" class="box-generic" >
                <!-- riga -->
                <div class="row-fluid">
               	<div class="span3">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal5"  text="mA" runat="server" meta:resourcekey="Literal5Resource1"></asp:literal></h5>
                    <asp:radiobutton ID="enable_ma" style="margin: 5px 10px 10px 0px;" runat="server"  GroupName="GROUP7" meta:resourcekey="enable_maResource1"></asp:radiobutton>
                    <asp:literal runat="server" text ="Enable" meta:resourcekey="LiteralResource15"></asp:literal>
                    <asp:radiobutton ID="disable_ma" style="margin: 5px 10px 10px 0px;" runat="server"  GroupName="GROUP7" meta:resourcekey="disable_maResource1"></asp:radiobutton>
                       <asp:literal runat="server" text ="Disable" meta:resourcekey="LiteralResource16"></asp:literal>
                </div>
                </div>
                 <!-- fine riga -->
                <!-- riga -->
<div id ="div_enable_ma">
                 <!-- fine riga -->
                 <!-- riga -->
                <div  class="row-fluid">
                <div class="span2">
                <div id="riga_ma_1_1" class="control-group">
                <h5 style="padding-top:10px" class="control-label"><asp:literal ID = "Literal27"  text="Value 1" runat="server" meta:resourcekey="Literal27Resource1"></asp:literal></h5>
                <div class="row-fluid">
                    
                <asp:textbox ID="value_on_ma_id" class="span12"  runat="server"  onblur="javascript: Changed_channel( 'value_on_ma_id','riga_ma_1_1',max_ch_value, min_ch_value,max_fix_value );" MaxLength="5" meta:resourcekey="value_on_ma_idResource1"></asp:textbox>
                   </div>
                </div>
                 </div>
                <div id="percent_on_ma" class="span2">
                    <div id="riga_ma_1_2" class="control-group">
                <asp:label  ID = "label_percent_ma_1"  text="<h5 class='control-label' style='padding-top:10px'>mA</h5> " runat="server" meta:resourcekey="label_percent_ma_1Resource1"></asp:label>
                <asp:textbox ID="value_perc1_ma_id" class="span12" onblur="javascript: Changed_channel( 'value_perc1_ma_id','riga_ma_1_2',max_ma_value,min_ma_value,1 );"  runat="server" MaxLength="3" meta:resourcekey="value_perc1_ma_idResource1"></asp:textbox>
                        </div>
                </div>
                </div>
                 <!-- fine riga -->
                 <!-- fine riga -->
                 <!-- riga -->
                <div  class="row-fluid">
               	<div  class="span2">
                <div id="riga_ma_2_1" class="control-group">
                <h5 style="padding-top:10px" class="control-label"><asp:literal ID = "Literal28"  text="Value 2" runat="server" meta:resourcekey="Literal28Resource1"></asp:literal></h5>
                <div class="row-fluid">
                <asp:textbox ID="value_off_ma_id" class="span12"  onblur="javascript: Changed_channel( 'value_off_ma_id','riga_ma_2_1',max_ch_value,min_ch_value,max_fix_value );" runat="server" MaxLength="5" meta:resourcekey="value_off_ma_idResource1"></asp:textbox>
                
                </div>
                </div>
                </div>
                <div id="percent_off_ma" class="span2">
                  <div id="riga_ma_2_2" class="control-group">
                <asp:label  ID = "label_percent_ma_2"  text="<h5 class='control-label' style='padding-top:10px'>mA</h5>" runat="server" meta:resourcekey="label_percent_ma_2Resource1"></asp:label>
                
                <asp:textbox ID="value_perc2_ma_id" class="span12" onblur="javascript: Changed_channel( 'value_perc2_ma_id','riga_ma_2_2',max_ma_value,min_ma_value,1);" runat="server" MaxLength="3" meta:resourcekey="value_perc2_ma_idResource1"></asp:textbox>
                        </div>
                </div>
                </div>
                 <!-- fine riga -->
                   <!-- riga -->
                <div  class="row-fluid">
               	<div class="span2">
                <h5 style="padding-top:10px"><asp:literal ID = "Literal29"  text="Out mA" runat="server" meta:resourcekey="Literal29Resource1"></asp:literal></h5>
                 <asp:dropdownlist ID="index_pulse_ma" class="span12" runat="server" meta:resourcekey="index_pulse_maResource1">
                     <asp:ListItem Value="0" meta:resourcekey="ListItemResource61">X</asp:ListItem>
                     <asp:ListItem Value="1" meta:resourcekey="ListItemResource62">mA 1</asp:ListItem>
                     <asp:ListItem Value="2" meta:resourcekey="ListItemResource63">mA 2</asp:ListItem>
                     <asp:ListItem Value="3" meta:resourcekey="ListItemResource64">mA 3</asp:ListItem>
                     <asp:ListItem Value="4" meta:resourcekey="ListItemResource65">mA 4</asp:ListItem>
                     <asp:ListItem Value="5" meta:resourcekey="ListItemResource66">mA 5</asp:ListItem>
                    </asp:dropdownlist>
               	</div>
                  <div class="span2">
                <h5 style="padding-top:10px"><asp:literal ID = "id_ma_name_pulse"  text="Name mA" runat="server" meta:resourcekey="id_ma_name_pulseResource1"></asp:literal></h5>
                    <asp:textbox ID="id_ma_name_pulse_t" class="span12" runat="server" MaxLength="10" meta:resourcekey="id_ma_name_pulse_tResource1"></asp:textbox>
                  </div>
                </div>
                 <!-- fine riga -->
                      <!-- riga -->
                <div class="row-fluid">
               	<div class="span2">
                <h5 style="padding-top:10px"><asp:literal ID = "Literal30"  text="Input" runat="server" meta:resourcekey="Literal30Resource1"></asp:literal></h5> 
                       
                    <asp:dropdownlist ID="index_level_ma" class="span12" runat="server" meta:resourcekey="index_level_maResource1">
                        <asp:ListItem Value="0" meta:resourcekey="ListItemResource67">X</asp:ListItem>
                        <asp:ListItem Value="1" meta:resourcekey="ListItemResource68">Input 1</asp:ListItem>
                        <asp:ListItem Value="2" meta:resourcekey="ListItemResource69">Input 2</asp:ListItem>
                        <asp:ListItem Value="3" meta:resourcekey="ListItemResource70">Input 3</asp:ListItem>
                        <asp:ListItem Value="4" meta:resourcekey="ListItemResource71">Input 4</asp:ListItem>
                        <asp:ListItem Value="5" meta:resourcekey="ListItemResource72">Input 5</asp:ListItem>
                    </asp:dropdownlist>
                           
                </div>
                  <div class="span2">
                <h5 style="padding-top:10px"><asp:literal ID = "id_ma_name_input"  text="Name Input" runat="server" meta:resourcekey="id_ma_name_inputResource1"></asp:literal></h5>
                    <asp:textbox ID="id_ma_name_input_t" class="span12" runat="server" MaxLength="10" meta:resourcekey="id_ma_name_input_tResource1"></asp:textbox>
                </div>
                  <div class="span2">
                <h5 style="padding-top:10px"><asp:literal ID = "Literal31"  text="Stop On Input" runat="server" meta:resourcekey="Literal31Resource1"></asp:literal></h5>
                      
                    <asp:dropdownlist ID="stop_input_ma" class="span12" runat="server" meta:resourcekey="stop_input_maResource1">
                        <asp:ListItem Value="0" meta:resourcekey="ListItemResource73">Yes</asp:ListItem>
                        <asp:ListItem Value="1" meta:resourcekey="ListItemResource74">No</asp:ListItem>
                      </asp:dropdownlist>
           
                </div>
                 <div class="span2">
                <h5 style="padding-top:10px"><asp:literal ID = "Literal32"  text="MSG Input" runat="server" meta:resourcekey="Literal32Resource1"></asp:literal></h5>
                     
                <asp:checkbox ID="sms_check_ma" style="margin: 5px 10px 10px 0px;" runat="server" meta:resourcekey="sms_check_maResource1" ></asp:checkbox>
             
                </div>
                </div>
                 <!-- fine riga -->
                 
                </div>
                
                </div>
			<!-- // Tab content END -->
			
			</div>
<!-- tab 5 stop-->
     

  <!-- tab 6 start-->
			<div class="tab-pane" id="tab6-4">
				
				<div id ="tab_aa1" class="box-generic" >
                <!-- riga -->
                <div class="row-fluid">
               	<div class="span3">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal6"  text="Alarm A" runat="server" meta:resourcekey="Literal6Resource1"></asp:literal></h5>
                    <asp:radiobutton ID="enable_aa1" style="margin: 5px 10px 10px 0px;" runat="server"  GroupName="GROUP8" meta:resourcekey="enable_aa1Resource1"></asp:radiobutton>
                    <asp:literal runat="server" text ="Enable" meta:resourcekey="LiteralResource17"></asp:literal>
                    <asp:radiobutton ID="disable_aa1" style="margin: 5px 10px 10px 0px;" runat="server"  GroupName="GROUP8" meta:resourcekey="disable_aa1Resource1"></asp:radiobutton>
                       <asp:literal runat="server" text ="Disable" meta:resourcekey="LiteralResource18"></asp:literal>
                </div>
                </div>
                 <!-- fine riga -->
                <!-- riga -->
<div id ="div_enable_aa1">
                 <!-- fine riga -->
                 <!-- riga -->
                <div  class="row-fluid">
                <div class="span3">
                <div>
                <h5 style="padding-top:10px" class="control-label"><asp:literal ID = "Literal34"  text="Alarm" runat="server" meta:resourcekey="Literal34Resource1"></asp:literal></h5>
                <div class="row-fluid">
                    <asp:dropdownlist id ="alarm_aa1" runat="server" meta:resourcekey="alarm_aa1Resource1">
                        <asp:ListItem Value="1" meta:resourcekey="ListItemResource75">Start</asp:ListItem>
                        <asp:ListItem Value="2" meta:resourcekey="ListItemResource76">Stop</asp:ListItem>
                    </asp:dropdownlist>
                   </div>
                </div>
                 </div>
                <div  class="span3">
                    <div >
                <h5 style="padding-top:10px" class="control-label"><asp:literal ID = "Literal26"  text="Range" runat="server" meta:resourcekey="Literal26Resource1"></asp:literal></h5>
                <div class="row-fluid">
                    <asp:dropdownlist id ="range_aa1" runat="server" meta:resourcekey="range_aa1Resource1">
                        <asp:ListItem Value="0" meta:resourcekey="ListItemResource77">></asp:ListItem>
                        <asp:ListItem Value="1" meta:resourcekey="ListItemResource78"><</asp:ListItem>
                    </asp:dropdownlist>
                   </div>
                        </div>
                </div>
	            <div  class="span3">
                <div id="riga_aa1_1_1" class="control-group">
                <h5 style="padding-top:10px" class="control-label"><asp:literal ID = "Literal35"  text="Value" runat="server" meta:resourcekey="Literal35Resource1"></asp:literal></h5>
                <div class="row-fluid">
                <asp:textbox ID="value_alarm_aa1_id" class="span12"  onblur="javascript: Changed_channel( 'value_alarm_aa1_id','riga_aa1_1_1',max_ch_value,min_ch_value,max_fix_value );" runat="server" MaxLength="5" meta:resourcekey="value_alarm_aa1_idResource1"></asp:textbox>
                
                </div>
                </div>
                </div>
                </div>
                 <!-- fine riga -->
                 <!-- riga -->
                <div  class="row-fluid">
               
                <div  class="span3">
                  <div  class="control-group">
                      <h5 style="padding-top:10px" class="control-label"><asp:literal ID = "Literal37"  text="Delay" runat="server" meta:resourcekey="Literal37Resource1"></asp:literal></h5>
                      <div class="row-fluid">
                          <asp:textbox id = "value_aa1_delay" runat="server" MaxLength="2" meta:resourcekey="value_aa1_delayResource1"></asp:textbox>
                          </div>
                        </div>
                </div>
                <div  class="span3">
                  <div  class="control-group">
                      <h5 style="padding-top:10px" class="control-label"><asp:literal ID = "value_aa1_name_l"  text="Name" runat="server" meta:resourcekey="value_aa1_name_lResource1"></asp:literal></h5>
                      <div class="row-fluid">
                      <asp:textbox id = "value_aa1_name" runat="server" MaxLength="10" meta:resourcekey="value_aa1_nameResource1"></asp:textbox>
                          </div>
                        </div>
                </div>
                </div>
                 <!-- fine riga -->
                 <!-- riga -->
                <div  class="row-fluid">
               
                <div  class="span2">
                  <div  class="control-group">
                      <h5 style="padding-top:10px" class="control-label"><asp:literal ID = "Literal33"  text="MSG Input" runat="server" meta:resourcekey="Literal33Resource1"></asp:literal></h5>
                      <div class="row-fluid">
                      <asp:checkbox ID="sms_check_aa1" style="margin: 5px 10px 10px 0px;" runat="server" meta:resourcekey="sms_check_aa1Resource1" ></asp:checkbox>
                          </div>
                        </div>
                </div>
                <div  class="span2">
                  <div  class="control-group">
                      <h5 style="padding-top:10px" class="control-label"><asp:literal ID = "stop_setpoint_aa1_l"  text="Stop SetPoint" runat="server" meta:resourcekey="stop_setpoint_aa1_lResource1"></asp:literal></h5>
                      <div class="row-fluid">
                      <asp:checkbox ID="stop_setpoint_aa1" style="margin: 5px 10px 10px 0px;" runat="server" meta:resourcekey="stop_setpoint_aa1Resource1" ></asp:checkbox>
                          </div>
                        </div>
                </div>
                </div>
                 <!-- fine riga -->
                
                  
                </div>
                
                </div>
			<!-- // Tab content END -->
			
			</div>
<!-- tab 6 stop-->
<!-- tab 7 start-->
			<div class="tab-pane" id="tab7-4">
				
				<div id ="tab_ab1" class="box-generic" >
                <!-- riga -->
                <div class="row-fluid">
               	<div class="span3">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal36"  text="Alarm B" runat="server" meta:resourcekey="Literal36Resource1"></asp:literal></h5>
                    <asp:radiobutton ID="enable_ab1" style="margin: 5px 10px 10px 0px;" runat="server"  GroupName="GROUP9" meta:resourcekey="enable_ab1Resource1"></asp:radiobutton>
                    <asp:literal runat="server" text ="Enable" meta:resourcekey="LiteralResource19"></asp:literal>
                    <asp:radiobutton ID="disable_ab1" style="margin: 5px 10px 10px 0px;" runat="server"  GroupName="GROUP9" meta:resourcekey="disable_ab1Resource1"></asp:radiobutton>
                       <asp:literal runat="server" text ="Disable" meta:resourcekey="LiteralResource20"></asp:literal>
                </div>
                </div>
                 <!-- fine riga -->
                <!-- riga -->
<div id ="div_enable_ab1">
                 <!-- fine riga -->
                 <!-- riga -->
                <div  class="row-fluid">
                <div class="span3">
                <div>
                <h5 style="padding-top:10px" class="control-label"><asp:literal ID = "Literal39"  text="Alarm" runat="server" meta:resourcekey="Literal39Resource1"></asp:literal></h5>
                <div class="row-fluid">
                    <asp:dropdownlist id ="alarm_ab1" runat="server" meta:resourcekey="alarm_ab1Resource1">
                        <asp:ListItem Value="1" meta:resourcekey="ListItemResource79">Start</asp:ListItem>
                        <asp:ListItem Value="2" meta:resourcekey="ListItemResource80">Stop</asp:ListItem>
                    </asp:dropdownlist>
                   </div>
                </div>
                 </div>
                <div  class="span3">
                    <div >
                <h5 style="padding-top:10px" class="control-label"><asp:literal ID = "Literal41"  text="Range" runat="server" meta:resourcekey="Literal41Resource1"></asp:literal></h5>
                <div class="row-fluid">
                    <asp:dropdownlist id ="range_ab1" runat="server" meta:resourcekey="range_ab1Resource1">
                        <asp:ListItem Value="0" meta:resourcekey="ListItemResource81">></asp:ListItem>
                        <asp:ListItem Value="1" meta:resourcekey="ListItemResource82"><</asp:ListItem>
                    </asp:dropdownlist>
                   </div>
                        </div>
                </div>
	            <div  class="span3">
                <div id="riga_ab1_1_1" class="control-group">
                <h5 style="padding-top:10px" class="control-label"><asp:literal ID = "Literal42"  text="Value" runat="server" meta:resourcekey="Literal42Resource1"></asp:literal></h5>
                <div class="row-fluid">
                <asp:textbox ID="value_alarm_ab1_id" class="span12"  onblur="javascript: Changed_channel( 'value_alarm_ab1_id','riga_ab1_1_1',max_ch_value,min_ch_value,max_fix_value );" runat="server" MaxLength="5" meta:resourcekey="value_alarm_ab1_idResource1"></asp:textbox>
                
                </div>
                </div>
                </div>
                </div>
                 <!-- fine riga -->
                 <!-- riga -->
                <div  class="row-fluid">
               
                <div  class="span3">
                  <div  class="control-group">
                      <h5 style="padding-top:10px" class="control-label"><asp:literal ID = "Literal45"  text="Delay" runat="server" meta:resourcekey="Literal45Resource1"></asp:literal></h5>
                      <div class="row-fluid">
                          <asp:textbox id = "value_ab1_delay" runat="server" MaxLength="2" meta:resourcekey="value_ab1_delayResource1"></asp:textbox>
                          </div>
                        </div>
                </div>
                <div  class="span3">
                  <div  class="control-group">
                      <h5 style="padding-top:10px" class="control-label"><asp:literal ID = "value_ab1_name_l"  text="Name" runat="server" meta:resourcekey="value_ab1_name_lResource1"></asp:literal></h5>
                      <div class="row-fluid">
                      <asp:textbox id = "value_ab1_name" runat="server" MaxLength="10" meta:resourcekey="value_ab1_nameResource1"></asp:textbox>
                          </div>
                        </div>
                </div>
                </div>
                 <!-- fine riga -->

                 <!-- riga -->
                <div  class="row-fluid">
               
                <div  class="span2">
                  <div  class="control-group">
                      <h5 style="padding-top:10px" class="control-label"><asp:literal ID = "Literal43"  text="MSG Input" runat="server" meta:resourcekey="Literal43Resource1"></asp:literal></h5>
                      <div class="row-fluid">
                      <asp:checkbox ID="sms_check_ab1" style="margin: 5px 10px 10px 0px;" runat="server" meta:resourcekey="sms_check_ab1Resource1" ></asp:checkbox>
                          </div>
                        </div>
                </div>
                <div  class="span2">
                  <div  class="control-group">
                      <h5 style="padding-top:10px" class="control-label"><asp:literal ID = "stop_setpoint_ab1_l"  text="Stop SetPoint" runat="server" meta:resourcekey="stop_setpoint_ab1_lResource1"></asp:literal></h5>
                      <div class="row-fluid">
                      <asp:checkbox ID="stop_setpoint_ab1" style="margin: 5px 10px 10px 0px;" runat="server" meta:resourcekey="stop_setpoint_ab1Resource1" ></asp:checkbox>
                          </div>
                        </div>
                </div>
                </div>
                 <!-- fine riga -->
                
                  
                </div>
                
                </div>
			<!-- // Tab content END -->
			
			</div>
<!-- tab 7 stop-->

<!-- tab 8 start-->
			<div class="tab-pane" id="tab8-4">
				
				<div id ="tab_ad" class="box-generic" >
                <!-- riga -->
                <div class="row-fluid">
               	<div class="span3">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal38"  text="Alarm Dosing" runat="server" meta:resourcekey="Literal38Resource1"></asp:literal></h5>
                    <asp:radiobutton ID="enable_ad" style="margin: 5px 10px 10px 0px;" runat="server"  GroupName="GROUP10" meta:resourcekey="enable_adResource1"></asp:radiobutton>
                    <asp:literal runat="server" text ="Enable" meta:resourcekey="LiteralResource21"></asp:literal>
                    <asp:radiobutton ID="disable_ad" style="margin: 5px 10px 10px 0px;" runat="server"  GroupName="GROUP10" meta:resourcekey="disable_adResource1"></asp:radiobutton>
                       <asp:literal runat="server" text ="Disable" meta:resourcekey="LiteralResource22"></asp:literal>
                </div>
                </div>
                 <!-- fine riga -->
                <!-- riga -->
<div id ="div_enable_ad">
                 <!-- fine riga -->
                 <!-- riga -->
                <div  class="row-fluid">
                               
	            <div  class="span3">
                <div id="riga_ad_1_1" class="control-group">
                <h5 style="padding-top:10px" class="control-label"><asp:literal ID = "Literal48"  text="Hour" runat="server" meta:resourcekey="Literal48Resource1"></asp:literal></h5>
                <div class="row-fluid">
                <asp:textbox ID="value_alarm_ore_ad_id" class="span12"  onblur="javascript: Changed_channel( 'value_alarm_ore_ad_id','riga_ad_1_1',9,0,0 );"  runat="server" MaxLength="1" meta:resourcekey="value_alarm_ore_ad_idResource1"></asp:textbox>
                
                </div>
                </div>
                </div>

	            <div  class="span3">
                <div id="riga_ad_1_2" class="control-group">
                <h5 style="padding-top:10px" class="control-label"><asp:literal ID = "Literal40"  text="Minutes" runat="server" meta:resourcekey="Literal40Resource1"></asp:literal></h5>
                <div class="row-fluid">
                <asp:textbox ID="value_alarm_min_ad_id" class="span12"  onblur="javascript: Changed_channel( 'value_alarm_min_ad_id','riga_ad_1_2',99,0,0 );" runat="server" MaxLength="2" meta:resourcekey="value_alarm_min_ad_idResource1"></asp:textbox>
                
                </div>
                </div>
                </div>


                </div>
                 <!-- fine riga -->
                
          <!-- riga -->
                <div  class="row-fluid">
                               
	            <div  class="span3">
                <div id="Div1" class="control-group">
                <h5 style="padding-top:10px" class="control-label"><asp:literal ID = "value_ad_name_l"  text="Name" runat="server" meta:resourcekey="value_ad_name_lResource1"></asp:literal></h5>
                <div class="row-fluid">
                <asp:textbox ID="value_ad_name" class="span12"   runat="server" MaxLength="10" meta:resourcekey="value_ad_nameResource1"></asp:textbox>
                    </div>
                </div>
                </div>
                </div>

	             <!-- fine riga -->
                 <!-- riga -->
                <div  class="row-fluid">
               
                <div  class="span2">
                  <div  class="control-group">
                      <h5 style="padding-top:10px" class="control-label"><asp:literal ID = "Literal50"  text="MSG Input" runat="server" meta:resourcekey="Literal50Resource1"></asp:literal></h5>
                      <div class="row-fluid">
                      <asp:checkbox ID="sms_check_ad" style="margin: 5px 10px 10px 0px;" runat="server" meta:resourcekey="sms_check_adResource1" ></asp:checkbox>
                          </div>
                        </div>
                </div>
                <div  class="span2">
                  <div  class="control-group">
                      <h5 style="padding-top:10px" class="control-label"><asp:literal ID = "stop_setpoint_ad_l"  text="Stop SetPoint" runat="server" meta:resourcekey="stop_setpoint_ad_lResource1"></asp:literal></h5>
                      <div class="row-fluid">
                      <asp:checkbox ID="stop_setpoint_ad" style="margin: 5px 10px 10px 0px;" runat="server" meta:resourcekey="stop_setpoint_adResource1" ></asp:checkbox>
                          </div>
                        </div>
                </div>
                </div>
                 <!-- fine riga -->
                
                  
                </div>
                
                </div>
			<!-- // Tab content END -->
			
			</div>
<!-- tab 8 stop-->
<!-- tab 9 start-->
			<div class="tab-pane" id="tab9-4">
				
				<div id ="tab_ar" class="box-generic" >
                <!-- riga -->
                <div class="row-fluid">
               	<div class="span3">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal44"  text="Alarm Reading" runat="server" meta:resourcekey="Literal44Resource1"></asp:literal></h5>
                    <asp:radiobutton ID="enable_ar" style="margin: 5px 10px 10px 0px;" runat="server"  GroupName="GROUP11" meta:resourcekey="enable_arResource1"></asp:radiobutton>
                    <asp:literal runat="server" text ="Enable" meta:resourcekey="LiteralResource23"></asp:literal>
                    <asp:radiobutton ID="disable_ar" style="margin: 5px 10px 10px 0px;" runat="server"  GroupName="GROUP11" meta:resourcekey="disable_arResource1"></asp:radiobutton>
                       <asp:literal runat="server" text ="Disable" meta:resourcekey="LiteralResource24"></asp:literal>
                </div>
                </div>
                 <!-- fine riga -->
                <!-- riga -->
<div id ="div_enable_ar">
                 <!-- fine riga -->
                 <!-- riga -->
                <div  class="row-fluid">
                               
	            <div  class="span3">
                <div id="riga_ar_1_1" class="control-group">
                <h5 style="padding-top:10px" class="control-label"><asp:literal ID = "Literal49"  text="Hour" runat="server" meta:resourcekey="Literal49Resource1"></asp:literal></h5>
                <div class="row-fluid">
                <asp:textbox ID="value_alarm_ore_ar_id" class="span12"  onblur="javascript: Changed_channel( 'value_alarm_ore_ar_id','riga_ar_1_1',9,0,0 );"  runat="server" MaxLength="1" meta:resourcekey="value_alarm_ore_ar_idResource1"></asp:textbox>
                
                </div>
                </div>
                </div>

	            <div  class="span3">
                <div id="riga_ar_1_2" class="control-group">
                <h5 style="padding-top:10px" class="control-label"><asp:literal ID = "Literal51"  text="Minutes" runat="server" meta:resourcekey="Literal51Resource1"></asp:literal></h5>
                <div class="row-fluid">
                <asp:textbox ID="value_alarm_min_ar_id" class="span12"  onblur="javascript: Changed_channel( 'value_alarm_min_ar_id','riga_ar_1_2',99,0,0 );" runat="server" MaxLength="2" meta:resourcekey="value_alarm_min_ar_idResource1"></asp:textbox>
                
                </div>
                </div>
                </div>


                </div>
                 <!-- fine riga -->
                
          <!-- riga -->
                <div  class="row-fluid">
                               
	            <div  class="span3">
                <div id="Div2" class="control-group">
                <h5 style="padding-top:10px" class="control-label"><asp:literal ID = "value_ar_name_l"  text="Name" runat="server" meta:resourcekey="value_ar_name_lResource1"></asp:literal></h5>
                <div class="row-fluid">
                <asp:textbox ID="value_ar_name" class="span12"   runat="server" MaxLength="10" meta:resourcekey="value_ar_nameResource1"></asp:textbox>
                    </div>
                </div>
                </div>
                </div>

	             <!-- fine riga -->
                 <!-- riga -->
                <div  class="row-fluid">
               
                <div  class="span2">
                  <div  class="control-group">
                      <h5 style="padding-top:10px" class="control-label"><asp:literal ID = "Literal52"  text="MSG Input" runat="server" meta:resourcekey="Literal52Resource1"></asp:literal></h5>
                      <div class="row-fluid">
                      <asp:checkbox ID="sms_check_ar" style="margin: 5px 10px 10px 0px;" runat="server" meta:resourcekey="sms_check_arResource1" ></asp:checkbox>
                          </div>
                        </div>
                </div>
                <div  class="span2">
                  <div  class="control-group">
                      <h5 style="padding-top:10px" class="control-label"><asp:literal ID = "stop_setpoint_ar_l"  text="Stop SetPoint" runat="server" meta:resourcekey="stop_setpoint_ar_lResource1"></asp:literal></h5>
                      <div class="row-fluid">
                      <asp:checkbox ID="stop_setpoint_ar" style="margin: 5px 10px 10px 0px;" runat="server" meta:resourcekey="stop_setpoint_arResource1" ></asp:checkbox>
                          </div>
                        </div>
                </div>
                </div>
                 <!-- fine riga -->
                
                  
                </div>
                
                </div>
			<!-- // Tab content END -->
			
			</div>
<!-- tab 9 stop-->
		</div>

               <div id="salva" class="btn-primary">
                   <b class="btn-primary btn-icon glyphicons ok"><asp:button runat="server" ID="save_setpoint_new" class="btn-primary" data-layout="center" data-type="confirm" data-toggle="notyfy"  text="Salva e carica i dati" Font-Bold="True" style="margin-bottom: 0px" meta:resourcekey="save_setpoint_newResource1" /><i></i></b>
                </div>
               

			</div>

<!-- fine TIMER -->
            </div>
    <script type="text/javascript" src="max5/validator_max5.js"></script>
    <script type="text/javascript" src="common/validator_general_notify.js"></script>
    <script src="theme/scripts/demo/notifications.js"></script>
</form>

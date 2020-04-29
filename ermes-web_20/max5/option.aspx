<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="option.aspx.vb" Inherits="ermes_web_20._option" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>


<form id="form" runat="server" method="post" action="max5/option.aspx">

    <h3><asp:literal runat="server" text ="Option Max 5" ID="option_channel" meta:resourcekey="option_channelResource1"></asp:literal></h3>

     <div class="innerLR">
         <div class="box-generic">
             		<!-- Tabs Heading -->
		<div class="tabsbar tabsbar-2">
			<ul class="row-fluid row-merge">
            
<li class="span2 active" ><a id="tab_1_1" href="#tab1-4_1"  data-toggle="tab"><asp:literal text="LogSetup"  runat="server" ID="tab1_1" meta:resourcekey="tab1_1Resource1" ></asp:literal></a></li>
<li class="span2"><a id="tab_2_1" href="#tab2-4_1" data-toggle="tab"><asp:literal text="ProbeClean" runat="server" ID="tab2_1" meta:resourcekey="tab2_1Resource1"></asp:literal></a></li>
<li class="span2"><a id="tab_3_1" href="#tab3-4_1" data-toggle="tab"><asp:literal text="FlowMeter" runat="server" ID="tab3_1" meta:resourcekey="tab3_1Resource1"></asp:literal></a></li>
<li class="span2"><a id="tab_4_1" href="#tab4-4_1" data-toggle="tab"><asp:literal text="General" runat="server" ID="tab4_1" meta:resourcekey="tab4_1Resource1"></asp:literal></a></li>

			</ul>
		</div>
		<!-- // Tabs Heading END -->
             <div class="tab-content">

                 <!-- tab 1 start-->
			<div class="tab-pane active" id="tab1-4_1">
                <div  class="box-generic">
                                    <!-- riga -->
                <div class="row-fluid">
               	<div class="span3">
              <h5 style="padding-top:10px"><asp:literal ID = "Label7"  text="Log Setup" runat="server" meta:resourcekey="Label7Resource1"></asp:literal></h5>
                    <asp:radiobutton ID="enable_log" style="margin: 5px 10px 10px 0px;" runat="server"  GroupName="GROUP1" meta:resourcekey="enable_logResource1"></asp:radiobutton>
                    <asp:literal runat="server" text ="Enable" meta:resourcekey="LiteralResource1"></asp:literal>
                    <asp:radiobutton ID="disable_log" style="margin: 5px 10px 10px 0px;" runat="server"  GroupName="GROUP1" meta:resourcekey="disable_logResource1"></asp:radiobutton>
                       <asp:literal runat="server" text ="Disable" meta:resourcekey="LiteralResource2"></asp:literal>
                </div>
                </div>
                 <!-- fine riga -->
<div id ="div_enable_log">
                     <!-- riga -->
                <div  class="row-fluid">
                <div class="span2">
                <div id="riga_log_1_1" class="control-group">
                <h5 style="padding-top:10px" class="control-label"><asp:literal ID = "Label12"  text="Log Start(Hour)" runat="server" meta:resourcekey="Label12Resource1"></asp:literal></h5>
                <div class="row-fluid">
                    
                <asp:textbox ID="value_start_hr_id" class="span12"  runat="server"  onblur="javascript: Changed_channel( 'value_start_hr_id','riga_log_1_1',23, 0,0);" MaxLength="2" meta:resourcekey="value_start_hr_idResource1"></asp:textbox>
                   </div>
                </div>
                 </div>
                <div  class="span2">
                    <div id="riga_log_1_2" class="control-group">
                <asp:label  ID = "label_log_min_1"  text="<h5 class='control-label' style='padding-top:10px'>Log Start(Min)</h5> " runat="server" meta:resourcekey="label_log_min_1Resource1"></asp:label>
                <asp:textbox ID="value_start_min_id" class="span12" onblur="javascript: Changed_channel( 'value_start_min_id','riga_log_1_2',59,0,0 );"  runat="server" MaxLength="2" meta:resourcekey="value_start_min_idResource1"></asp:textbox>
                        </div>
                </div>
                </div>
                 <!-- fine riga -->
                         <!-- riga -->
                <div  class="row-fluid">
                <div class="span2">
                <div id="riga_log_2_1" class="control-group">
                <h5 style="padding-top:10px" class="control-label"><asp:literal ID = "Literal1"  text="Every(Hour)" runat="server" meta:resourcekey="Literal1Resource1"></asp:literal></h5>
                <div class="row-fluid">
                    
                <asp:textbox ID="value_every_hr_id" class="span12"  runat="server"  onblur="javascript: Changed_channel( 'value_every_hr_id','riga_log_2_1',23, 0,0 );" MaxLength="2" meta:resourcekey="value_every_hr_idResource1"></asp:textbox>
                   </div>
                </div>
                 </div>
                <div  class="span2">
                    <div id="riga_log_2_2" class="control-group">
                <asp:label  ID = "label_log_hr_1"  text="<h5 class='control-label' style='padding-top:10px'>Every(Min)</h5> " runat="server" meta:resourcekey="label_log_hr_1Resource1"></asp:label>
                <asp:textbox ID="value_every_min_id" class="span12" onblur="javascript: Changed_channel( 'value_every_min_id','riga_log_2_2',59,0,0 );"  runat="server" MaxLength="2" meta:resourcekey="value_every_min_idResource1"></asp:textbox>
                        </div>
                </div>
                </div>
    <!-- fine riga -->

    <!-- riga -->
                <div  class="row-fluid">
                <div class="span2">
                <div id="riga_log_3_1" class="control-group">
                <h5 style="padding-top:10px" class="control-label"><asp:literal ID = "Literal2"  text="Filter(Min)" runat="server" meta:resourcekey="Literal2Resource1"></asp:literal></h5>
                <div class="row-fluid">
                    
                <asp:textbox ID="value_filter_min_id" class="span12"  runat="server"  onblur="javascript: Changed_channel( 'value_filter_min_id','riga_log_3_1',59, 0,0);" MaxLength="2" meta:resourcekey="value_filter_min_idResource1"></asp:textbox>
                   </div>
                </div>
                 </div>

				 </div>
    <!-- fine riga -->
</div>
                    </div>
                </div>
                 <!-- tab 1 end-->
<!-- tab 2 cycle-->
			<div class="tab-pane" id="tab2-4_1">
                <div  class="box-generic">
                                    <!-- riga -->
                <div class="row-fluid">
               	<div class="span3">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal3"  text="Probe Clean" runat="server" meta:resourcekey="Literal3Resource1"></asp:literal></h5>
                    <asp:radiobutton ID="enable_clean" style="margin: 5px 10px 10px 0px;" runat="server"  GroupName="GROUP2" meta:resourcekey="enable_cleanResource1"></asp:radiobutton>
                    <asp:literal runat="server" text ="Enable" meta:resourcekey="LiteralResource3"></asp:literal>
                    <asp:radiobutton ID="disable_clean" style="margin: 5px 10px 10px 0px;" runat="server"  GroupName="GROUP2" meta:resourcekey="disable_cleanResource1"></asp:radiobutton>
                       <asp:literal runat="server" text ="Disable" meta:resourcekey="LiteralResource4"></asp:literal>
                </div>
                </div>
                 <!-- fine riga -->
<div id ="div_enable_clean">
                     <!-- riga -->
                <div  class="row-fluid">
                <div class="span2">
                <div id="riga_clean_1_1" class="control-group">
                <h5 style="padding-top:10px" class="control-label"><asp:literal ID = "Literal6"  text="Cycle Time(Hour)" runat="server" meta:resourcekey="Literal6Resource1"></asp:literal></h5>
                <div class="row-fluid">
                    
                <asp:textbox ID="value_cycle_hr_id" class="span12"  runat="server"  onblur="javascript: Changed_channel( 'value_cycle_hr_id','riga_clean_1_1',99, 0,0);" MaxLength="2" meta:resourcekey="value_cycle_hr_idResource1"></asp:textbox>
                   </div>
                </div>
                 </div>
                <div  class="span2">
                    <div id="riga_clean_1_2" class="control-group">
                <asp:label  ID = "label_clean_min_1"  text="<h5 class='control-label' style='padding-top:10px'>Cycle Time(Min)</h5> " runat="server" meta:resourcekey="label_clean_min_1Resource1"></asp:label>
                <asp:textbox ID="value_cycle_min_id" class="span12" onblur="javascript: Changed_channel( 'value_cycle_min_id','riga_clean_1_2',59,0,0 );"  runat="server" MaxLength="2" meta:resourcekey="value_cycle_min_idResource1"></asp:textbox>
                        </div>
                </div>
                </div>
                 <!-- fine riga -->
                         <!-- riga -->
                <div  class="row-fluid">
                <div class="span2">
                <div id="riga_clean_2_1" class="control-group">
                <h5 style="padding-top:10px" class="control-label"><asp:literal ID = "Literal7"  text="Clean Time(Min)" runat="server" meta:resourcekey="Literal7Resource1"></asp:literal></h5>
                <div class="row-fluid">
                    
                <asp:textbox ID="value_cleant_hr_id" class="span12"  runat="server"  onblur="javascript: Changed_channel( 'value_cleant_hr_id','riga_clean_2_1',59, 0,0 );" MaxLength="2" meta:resourcekey="value_cleant_hr_idResource1"></asp:textbox>
                   </div>
                </div>
                 </div>
                <div  class="span2">
                    <div id="riga_clean_2_2" class="control-group">
                <asp:label  ID = "label_clean_hr_1"  text="<h5 class='control-label' style='padding-top:10px'>Clean Time(Sec)</h5> " runat="server" meta:resourcekey="label_clean_hr_1Resource1"></asp:label>
                <asp:textbox ID="value_cleant_min_id" class="span12" onblur="javascript: Changed_channel( 'value_cleant_min_id','riga_clean_2_2',59,0,0 );"  runat="server" MaxLength="2" meta:resourcekey="value_cleant_min_idResource1"></asp:textbox>
                        </div>
                </div>
                </div>
    <!-- fine riga -->

    <!-- riga -->
                <div  class="row-fluid">
                <div class="span2">
                <div id="riga_clean_3_1" class="control-group">
                <h5 style="padding-top:10px" class="control-label"><asp:literal ID = "Literal8"  text="Restore(Min)" runat="server" meta:resourcekey="Literal8Resource1"></asp:literal></h5>
                <div class="row-fluid">
                    
                <asp:textbox ID="value_restore_min_id" class="span12"  runat="server"  onblur="javascript: Changed_channel( 'value_restore_min_id','riga_clean_3_1',99, 0,0);" MaxLength="2" meta:resourcekey="value_restore_min_idResource1"></asp:textbox>
                   </div>
                </div>
                 </div>
            <div  class="span2">
                    <div >
                <h5 style="padding-top:10px" class="control-label"><asp:literal ID = "Literal41"  text="Clean ON Alarm" runat="server" meta:resourcekey="Literal41Resource1"></asp:literal></h5>
                <div class="row-fluid">
                    <asp:dropdownlist id ="clean_alarm" runat="server" meta:resourcekey="clean_alarmResource1">
                        <asp:ListItem Value="0" meta:resourcekey="ListItemResource1">OFF</asp:ListItem>
                        <asp:ListItem Value="1" meta:resourcekey="ListItemResource2">ON</asp:ListItem>
                    </asp:dropdownlist>
                   </div>
                        </div>
                </div>
				 </div>
    <!-- fine riga -->
</div>
                    </div>
                </div>
                 <!-- tab 2 end-->
<!-- tab 3 flow meter-->
			<div class="tab-pane" id="tab3-4_1">
                <div  class="box-generic">
                                    <!-- riga -->
                <div class="row-fluid">
               	<div class="span3">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal4"  text="Flow Meter Unit" runat="server" meta:resourcekey="Literal4Resource1"></asp:literal></h5>
                    <asp:radiobutton ID="enable_litri" style="margin: 5px 10px 10px 0px;" runat="server"  GroupName="GROUP3" meta:resourcekey="enable_litriResource1"></asp:radiobutton>
                    <asp:literal id = "litre_label" runat="server" text ="Litre" meta:resourcekey="litre_labelResource1"></asp:literal>
                    <asp:radiobutton ID="enable_galloni" style="margin: 5px 10px 10px 0px;" runat="server"  GroupName="GROUP3" meta:resourcekey="enable_galloniResource1"></asp:radiobutton>
                       <asp:literal runat="server" text ="Gallons" meta:resourcekey="LiteralResource5"></asp:literal>
                </div>
                </div>
                 <!-- fine riga -->
<!-- riga -->
                <div  class="row-fluid">
                <div class="span3">
                <div id="riga_flow_1_1" class="control-group">
                <h5 style="padding-top:10px" class="control-label"><asp:literal ID = "Literal10"  text="Flow Meter Rate" runat="server" meta:resourcekey="Literal10Resource1"></asp:literal></h5>
                <div class="row-fluid">
                    
                <asp:textbox ID="value_flow_rate_id" class="span12"  runat="server"  onblur="javascript: Changed_channel('value_flow_rate_id', 'riga_flow_1_1', max_flowmeter, 0, my_fix_flowmeter);" MaxLength="6" meta:resourcekey="value_flow_rate_idResource1"></asp:textbox>
                   </div>
                </div>
                 </div>
    <div  class="span3">
                    <div >
                <h5 style="padding-top:10px" class="control-label"><asp:literal ID = "Literal11"  text="Rate Unit" runat="server" meta:resourcekey="Literal11Resource1"></asp:literal></h5>
                <div class="row-fluid">
                    <asp:dropdownlist id ="Dropdownlist1" runat="server" meta:resourcekey="Dropdownlist1Resource1">
                        <asp:ListItem Value="0" meta:resourcekey="ListItemResource3">Pulse/Litre</asp:ListItem>
                        <asp:ListItem Value="1" meta:resourcekey="ListItemResource4">Litre/Pulse</asp:ListItem>
                    </asp:dropdownlist>
                   </div>
                        </div>
                </div>                
</div>  
<!-- fine riga -->
   <!-- riga -->
                <div  class="row-fluid">
                <div class="span3">
                <div id="riga_flow_2_1" class="control-group">
                <h5 style="padding-top:10px" class="control-label"><asp:literal ID = "Literal5"  text="SetPoint Low Flow(m3/h)" runat="server" meta:resourcekey="Literal5Resource1"></asp:literal></h5>
                <div class="row-fluid">
                    
                <asp:textbox ID="value_flow_setpoint_id" class="span12"  runat="server"  onblur="javascript: Changed_channel('value_flow_setpoint_id', 'riga_flow_2_1', 999.9, 0, 1);" MaxLength="5" meta:resourcekey="value_flow_setpoint_idResource1"></asp:textbox>
                   </div>
                </div>
                 </div>
   <div class="span3">
                <div id="riga_flow_2_2" class="control-group">
                <h5 style="padding-top:10px" class="control-label"><asp:literal ID = "Literal9"  text="20mA @ Flow(m3/h)" runat="server" meta:resourcekey="Literal9Resource1"></asp:literal></h5>
                <div class="row-fluid">
                    
                <asp:textbox ID="value_flow_ma_id" class="span12"  runat="server"  onblur="javascript:  Changed_channel('value_flow_ma_id', 'riga_flow_2_2', 999.9, 0, 1);" MaxLength="5" meta:resourcekey="value_flow_ma_idResource1"></asp:textbox>
                   </div>
                </div>
	</div>                
</div>  
<!-- fine riga -->
                 <!-- riga -->
                <div  class="row-fluid">
               
                <div  class="span2">
                  <div  class="control-group">
                      <h5 style="padding-top:10px" class="control-label"><asp:literal ID = "Literal43"  text="SMS Low Flow" runat="server" meta:resourcekey="Literal43Resource1"></asp:literal></h5>
                      <div class="row-fluid">
                      <asp:checkbox ID="sms_low_flow" style="margin: 5px 10px 10px 0px;" runat="server" meta:resourcekey="sms_low_flowResource1" ></asp:checkbox>
                          </div>
                        </div>
                </div>
</div>  
<!-- fine riga -->                      

</div>
                    </div>
<!-- tab 3 end-->
<!-- tab 3 flow meter-->
			<div class="tab-pane" id="tab4-4_1">
                <div  class="box-generic">
<!-- riga -->
                <div class="row-fluid">
               	<div class="span3">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal12"  text="Flow Detect" runat="server" meta:resourcekey="Literal12Resource1"></asp:literal></h5>
                    <asp:radiobutton ID="direct_id" style="margin: 5px 10px 10px 0px;" runat="server"  GroupName="GROUP4" meta:resourcekey="direct_idResource1"></asp:radiobutton>
                    <asp:literal runat="server" text ="Direct" meta:resourcekey="LiteralResource6"></asp:literal>
                    <asp:radiobutton ID="inverse_id" style="margin: 5px 10px 10px 0px;" runat="server"  GroupName="GROUP4" meta:resourcekey="inverse_idResource1"></asp:radiobutton>
                       <asp:literal runat="server" text ="Reverse" meta:resourcekey="LiteralResource7"></asp:literal>
                    <asp:radiobutton ID="disable_id" style="margin: 5px 10px 10px 0px;" runat="server"  GroupName="GROUP4" meta:resourcekey="disable_idResource1"></asp:radiobutton>
                       <asp:literal runat="server" text ="Disable" meta:resourcekey="LiteralResource8"></asp:literal>
				   </div>

                    <div  class="span3">
                  <div  class="control-group">
                      <h5 style="padding-top:10px" class="control-label"><asp:literal ID = "Literal13"  text="SMS Flow Alarm" runat="server" meta:resourcekey="Literal13Resource1"></asp:literal></h5>
                      <div class="row-fluid">
                      <asp:checkbox ID="Checkbox1" style="margin: 5px 10px 10px 0px;" runat="server" meta:resourcekey="Checkbox1Resource1" ></asp:checkbox>
                          </div>
                        </div>
                </div>
                </div>
<!-- fine riga -->
 <!-- riga -->
            <div class="row-fluid">
               	<div class="span3">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal14"  text="Alarm Setup" runat="server" meta:resourcekey="Literal14Resource1"></asp:literal></h5>
                    <asp:radiobutton ID="continuous_id" style="margin: 5px 10px 10px 0px;" runat="server"  GroupName="GROUP5" meta:resourcekey="continuous_idResource1"></asp:radiobutton>
                    <asp:literal runat="server" text ="Continuous" meta:resourcekey="LiteralResource9"></asp:literal>
                    <asp:radiobutton ID="timed_id" style="margin: 5px 10px 10px 0px;" runat="server"  GroupName="GROUP5" meta:resourcekey="timed_idResource1"></asp:radiobutton>
                       <asp:literal runat="server" text ="Timed" meta:resourcekey="LiteralResource10"></asp:literal>
				   </div>

                    <div  class="span3">
                  <div  id="riga_alarm_timed_min" class="control-group">
                      <h5 style="padding-top:10px" class="control-label"><asp:literal ID = "Literal17"  text="Timed(min)" runat="server" meta:resourcekey="Literal17Resource1"></asp:literal></h5>
                      <div class="row-fluid">
                <asp:textbox ID="value_timed_min_id" class="span12"  runat="server"  onblur="javascript: Changed_channel( 'value_timed_min_id','riga_alarm_timed_min',99, 0,1);" MaxLength="2" meta:resourcekey="value_timed_min_idResource1"></asp:textbox>

                          </div>
                        </div>
                </div>
  <div  class="span3">
                  <div  id="riga_alarm_timed_sec" class="control-group">
                      <h5 style="padding-top:10px" class="control-label"><asp:literal ID = "Literal18"  text="Timed(sec)" runat="server" meta:resourcekey="Literal18Resource1"></asp:literal></h5>
                      <div class="row-fluid">
                <asp:textbox ID="value_timed_sec_id" class="span12"  runat="server"  onblur="javascript: Changed_channel( 'value_timed_sec_id','riga_alarm_timed_sec',99, 0,1);" MaxLength="2" meta:resourcekey="value_timed_sec_idResource1"></asp:textbox>

                          </div>
                        </div>
                </div>				
                </div>
<!-- fine riga -->                
<!-- riga -->
            <div class="row-fluid">
             
			<div  class="span2">
                  <div  id="riga_delay_min" class="control-group">
                      <h5 style="padding-top:10px" class="control-label"><asp:literal ID = "Literal15"  text="Delay(min)" runat="server" meta:resourcekey="Literal15Resource1"></asp:literal></h5>
                      <div class="row-fluid">
                <asp:textbox ID="value_delay_min_id" class="span12"  runat="server"  onblur="javascript: Changed_channel( 'value_delay_min_id','riga_delay_min',99, 0,1);" MaxLength="2" meta:resourcekey="value_delay_min_idResource1"></asp:textbox>

                          </div>
                        </div>
                </div>				
                </div>
<!-- fine riga -->
<!-- riga -->
            <div class="row-fluid">
             
			<div  class="span2">
                  <div  id="riga_tau_const" class="control-group">
                      <h5 style="padding-top:10px" class="control-label"><asp:literal ID = "Literal16"  text="Tau(constant)" runat="server" meta:resourcekey="Literal16Resource1"></asp:literal></h5>
                      <div class="row-fluid">
                <asp:textbox ID="value_tau_const_id" class="span12"  runat="server"  onblur="javascript: Changed_channel( 'value_tau_const_id','riga_tau_const',99, 0,1);" MaxLength="2" meta:resourcekey="value_tau_const_idResource1"></asp:textbox>

                          </div>
                        </div>
                </div>				
                </div>
<!-- fine riga -->
</div>
                    </div>
<!-- tab 3 end-->
                 </div>
         
               <div id="salva" class="btn-primary">
                   <b class="btn-primary btn-icon glyphicons ok"><asp:button runat="server" ID="save_option_new" class="btn-primary"  data-layout="center" data-type="confirm" data-toggle="notyfy" text="Salva e carica i dati" Font-Bold="True" meta:resourcekey="save_option_newResource1" /><i></i></b>
                </div>

             </div>

     </div>
    <script type="text/javascript" src="max5/validator_max5.js"></script>
            <script type="text/javascript" src="common/validator_general_notify.js"></script>
    <script src="theme/scripts/demo/notifications.js"></script>

</form>
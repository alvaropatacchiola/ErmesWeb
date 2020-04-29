<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="timer.aspx.vb" Inherits="ermes_web_20.timer" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>

<form id="form" runat="server" method="post" action="max5/timer.aspx">
    <h3><asp:literal runat="server" text ="Timer Max 5" ID="timer_channel" meta:resourcekey="timer_channelResource1"></asp:literal></h3>
    <div class="innerLR">
      <div class="box-generic">
             		<!-- Tabs Heading -->
<div class="tabsbar tabsbar-2">
			<ul class="row-fluid row-merge">
            
<li class="span2 active" ><a id="tab_1_2" href="#tab1-4_2"  data-toggle="tab"><asp:literal text="Timer1"  runat="server" ID="tab1_2" meta:resourcekey="tab1_2Resource1" ></asp:literal></a></li>
<li class="span2"><a id="tab_2_2" href="#tab2-4_2" data-toggle="tab"><asp:literal text="Timer2" runat="server" ID="tab2_2" meta:resourcekey="tab2_2Resource1"></asp:literal></a></li>
<li class="span2"><a id="tab_3_2" href="#tab3-4_2" data-toggle="tab"><asp:literal text="Timer3" runat="server" ID="tab3_2" meta:resourcekey="tab3_2Resource1"></asp:literal></a></li>
<li class="span2"><a id="tab_4_2" href="#tab4-4_2" data-toggle="tab"><asp:literal text="Timer4" runat="server" ID="tab4_2" meta:resourcekey="tab4_2Resource1"></asp:literal></a></li>
<li class="span2"><a id="tab_5_2" href="#tab5-4_2" data-toggle="tab"><asp:literal text="Timer5" runat="server" ID="tab5_2" meta:resourcekey="tab5_2Resource1"></asp:literal></a></li>
			</ul>
		</div>
		<!-- // Tabs Heading END -->
          <div class="tab-content">
              <!-- tab 1 start-->
			<div class="tab-pane active" id="tab1-4_2">
                <div  class="box-generic">
                                    <!-- riga -->
                <div class="row-fluid">
               	<div class="span3">
              <h5 style="padding-top:10px"><asp:literal ID = "Label7"  text="Timer1" runat="server" meta:resourcekey="Label7Resource1"></asp:literal></h5>
                    <asp:radiobutton ID="enable_timer1" style="margin: 5px 10px 10px 0px;" runat="server"  GroupName="GROUP1" meta:resourcekey="enable_timer1Resource1"></asp:radiobutton>
                    <asp:literal runat="server" text ="Enable" meta:resourcekey="LiteralResource1"></asp:literal>
                    <asp:radiobutton ID="disable_timer1" style="margin: 5px 10px 10px 0px;" runat="server"  GroupName="GROUP1" meta:resourcekey="disable_timer1Resource1"></asp:radiobutton>
                       <asp:literal runat="server" text ="Disable" meta:resourcekey="LiteralResource2"></asp:literal>
                </div>
                </div>
                 <!-- fine riga -->
<div id ="div_enable_timer1">
                     <!-- riga -->
                <div  class="row-fluid">
                <div class="span3">
                <div id="riga_timer_1_1" class="control-group">
                <h5 style="padding-top:10px" class="control-label"><asp:literal ID = "Literal1"  text="Timer1 Start(gg-mm-aa)" runat="server" meta:resourcekey="Literal1Resource1"></asp:literal></h5>
                <div class="row-fluid">
                    
                <asp:textbox ID="timer_1_start" onblur="javascript: Changed_channel_timer( 'timer_1_start','riga_timer_1_1', lunghezza_data);" onchange="javascript: Changed_channel_timer( 'timer_1_start','riga_timer_1_1', lunghezza_data);" class="span12"  runat="server" style=" position: relative; z-index: 100000;" meta:resourcekey="timer_1_startResource1"></asp:textbox>
                   </div>
                </div>
                 </div>
                <div  class="span3">
                    <div id="riga_timer_1_2" class="control-group">
                <asp:label  ID = "label_timer_1_2"  text="<h5 class='control-label' style='padding-top:10px'>Timer1 Stop(hh-mm)</h5> " runat="server" meta:resourcekey="label_timer_1_2Resource1"></asp:label>
                <asp:textbox ID="timer_1_stop"  onblur="javascript: Changed_channel_timer( 'timer_1_stop','riga_timer_1_2', lunghezza_ora);" onchange="javascript: Changed_channel_timer( 'timer_1_stop','riga_timer_1_2', lunghezza_ora);" class="span12"   runat="server" meta:resourcekey="timer_1_stopResource1"></asp:textbox>
                        </div>
                </div>
                </div>
                 <!-- fine riga -->
                         <!-- riga -->
                <div  class="row-fluid">
                <div class="span2">
                <div id="riga_timer_2_1" class="control-group">
                <h5 style="padding-top:10px" class="control-label"><asp:literal ID = "Literal3"  text="Repeat(gg)" runat="server" meta:resourcekey="Literal3Resource1"></asp:literal></h5>
                <div class="row-fluid">
                    
                <asp:textbox ID="value_timer1_gg_id" onblur="javascript: Changed_channel_timer_value( 'value_timer1_gg_id','riga_timer_2_1',30, 0,1);" class="span12"  runat="server" MaxLength="2" meta:resourcekey="value_timer1_gg_idResource1" Height="22px"  ></asp:textbox>
                   </div>
                </div>
                 </div>
                </div>
    <!-- fine riga -->

    <!-- riga -->
                <div  class="row-fluid">
                <div class="span3">
                <div id="riga_timer_3_1" class="control-group">
                <h5 style="padding-top:10px" class="control-label"><asp:literal ID = "Literal4"  text="Relay or Pulse" runat="server" meta:resourcekey="Literal4Resource1"></asp:literal></h5>
                <div class="row-fluid">
                    
                    <asp:dropdownlist runat="server" ID="timer1_relay_pulse" meta:resourcekey="timer1_relay_pulseResource1">
                        <asp:ListItem Value="0" meta:resourcekey="ListItemResource1">X</asp:ListItem>
                        <asp:ListItem Value="1" meta:resourcekey="ListItemResource2">Relay 1</asp:ListItem>
                        <asp:ListItem Value="2" meta:resourcekey="ListItemResource3">Relay 2</asp:ListItem>
                        <asp:ListItem Value="3" meta:resourcekey="ListItemResource4">Relay 3</asp:ListItem>
                        <asp:ListItem Value="4" meta:resourcekey="ListItemResource5">Relay 4</asp:ListItem>
                        <asp:ListItem Value="5" meta:resourcekey="ListItemResource6">Relay 5</asp:ListItem>
                        <asp:ListItem Value="6" meta:resourcekey="ListItemResource7">Relay 6</asp:ListItem>
                        <asp:ListItem Value="7" meta:resourcekey="ListItemResource8">Pulse 1</asp:ListItem>
                        <asp:ListItem Value="8" meta:resourcekey="ListItemResource9">Pulse 2</asp:ListItem>
                        <asp:ListItem Value="9" meta:resourcekey="ListItemResource10">Pulse 3</asp:ListItem>
                        <asp:ListItem Value="10" meta:resourcekey="ListItemResource11">Pulse 4</asp:ListItem>
                        <asp:ListItem Value="11" meta:resourcekey="ListItemResource12">Pulse 5</asp:ListItem>
                        <asp:ListItem Value="12" meta:resourcekey="ListItemResource13">Pulse 6</asp:ListItem>
                    </asp:dropdownlist>
                   </div>
                </div>
                 </div>
            <div class="span3">
                <div id="riga_timer_3_2" class="control-group">
                <h5 style="padding-top:10px" class="control-label"><asp:literal ID = "Literal2"  text="Pulse/minute" runat="server" meta:resourcekey="Literal2Resource1"></asp:literal></h5>
                <div class="row-fluid">
                    
                <asp:textbox ID="value_timer1_pulse_minute_id" class="span12"  runat="server"  onblur="javascript: Changed_channel_timer_value( 'value_timer1_pulse_minute_id','riga_timer_3_2',180, 0,0 );" MaxLength="3" meta:resourcekey="value_timer1_pulse_minute_idResource1"></asp:textbox>
                   </div>
                </div>
                 </div>
				 </div>
    <!-- fine riga -->
<!-- riga -->
                <div  class="row-fluid">
 <div class="span2">
                <div id="riga_timer_4_1" class="control-group">
                <h5 style="padding-top:10px" class="control-label"><asp:literal ID = "Literal5"  text="Name Timer" runat="server" meta:resourcekey="Literal5Resource1"></asp:literal></h5>
                <div class="row-fluid">
                    
                <asp:textbox ID="value_timer1_name_id" class="span12"  runat="server"   MaxLength="10" meta:resourcekey="value_timer1_name_idResource1"></asp:textbox>
                   </div>
                </div>
                 </div>
			 </div>
    <!-- fine riga -->    
</div>
                    </div>
                </div>
<!-- tab 1 end-->
      <!-- tab 2 start-->
			<div class="tab-pane" id="tab2-4_2">
                <div  class="box-generic">
                                    <!-- riga -->
                <div class="row-fluid">
               	<div class="span3">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal6"  text="Timer2" runat="server" meta:resourcekey="Literal6Resource1"></asp:literal></h5>
                    <asp:radiobutton ID="enable_timer2" style="margin: 5px 10px 10px 0px;" runat="server"  GroupName="GROUP2" meta:resourcekey="enable_timer2Resource1"></asp:radiobutton>
                    <asp:literal runat="server" text ="Enable" meta:resourcekey="LiteralResource3"></asp:literal>
                    <asp:radiobutton ID="disable_timer2" style="margin: 5px 10px 10px 0px;" runat="server"  GroupName="GROUP2" meta:resourcekey="disable_timer2Resource1"></asp:radiobutton>
                       <asp:literal runat="server" text ="Disable" meta:resourcekey="LiteralResource4"></asp:literal>
                </div>
                </div>
                 <!-- fine riga -->
<div id ="div_enable_timer2">
                     <!-- riga -->
                <div  class="row-fluid">
                <div class="span1">
                <div id="riga_timer2_1_1" class="control-group">
                <h5 style="padding-top:10px" class="control-label"><asp:literal ID = "Literal9"  text="Mon" runat="server" meta:resourcekey="Literal9Resource1"></asp:literal></h5>
                <div class="row-fluid">
                    
                <asp:checkbox ID="timer2_lunedi" style="margin: 5px 10px 10px 0px;" runat="server" meta:resourcekey="timer2_lunediResource1" ></asp:checkbox>
                   </div>
                </div>
                 </div>
                
                    <div class="span1">
                <div id="riga_timer2_1_2" class="control-group">
                <h5 style="padding-top:10px" class="control-label"><asp:literal ID = "Literal7"  text="Tue" runat="server" meta:resourcekey="Literal7Resource1"></asp:literal></h5>
                <div class="row-fluid">
                    
                <asp:checkbox ID="timer2_martedi" style="margin: 5px 10px 10px 0px;" runat="server" meta:resourcekey="timer2_martediResource1" ></asp:checkbox>
                   </div>
                </div>
                 </div>

                      <div class="span1">
                <div id="riga_timer2_1_3" class="control-group">
                <h5 style="padding-top:10px" class="control-label"><asp:literal ID = "Literal8"  text="Wed" runat="server" meta:resourcekey="Literal8Resource1"></asp:literal></h5>
                <div class="row-fluid">
                    
                <asp:checkbox ID="timer2_mercoledi" style="margin: 5px 10px 10px 0px;" runat="server" meta:resourcekey="timer2_mercolediResource1" ></asp:checkbox>
                   </div>
                </div>
                 </div>

                      <div class="span1">
                <div id="riga_timer2_1_4" class="control-group">
                <h5 style="padding-top:10px" class="control-label"><asp:literal ID = "Literal14"  text="Thu" runat="server" meta:resourcekey="Literal14Resource1"></asp:literal></h5>
                <div class="row-fluid">
                    
                <asp:checkbox ID="timer2_giovedi" style="margin: 5px 10px 10px 0px;" runat="server" meta:resourcekey="timer2_giovediResource1" ></asp:checkbox>
                   </div>
                </div>
                 </div>

                    <div class="span1">
                <div id="riga_timer2_1_5" class="control-group">
                <h5 style="padding-top:10px" class="control-label"><asp:literal ID = "Literal15"  text="Fri" runat="server" meta:resourcekey="Literal15Resource1"></asp:literal></h5>
                <div class="row-fluid">
                    
                <asp:checkbox ID="timer2_venerdi" style="margin: 5px 10px 10px 0px;" runat="server" meta:resourcekey="timer2_venerdiResource1" ></asp:checkbox>
                   </div>
                </div>
                 </div>

                     <div class="span1">
                <div id="riga_timer2_1_6" class="control-group">
                <h5 style="padding-top:10px" class="control-label"><asp:literal ID = "Literal16"  text="Sat" runat="server" meta:resourcekey="Literal16Resource1"></asp:literal></h5>
                <div class="row-fluid">
                    
                <asp:checkbox ID="timer2_sabato" style="margin: 5px 10px 10px 0px;" runat="server" meta:resourcekey="timer2_sabatoResource1" ></asp:checkbox>
                   </div>
                </div>
                 </div>

                     <div class="span1">
                <div id="riga_timer2_1_7" class="control-group">
                <h5 style="padding-top:10px" class="control-label"><asp:literal ID = "Literal17"  text="Sun" runat="server" meta:resourcekey="Literal17Resource1"></asp:literal></h5>
                <div class="row-fluid">
                    
                <asp:checkbox ID="timer2_domenica" style="margin: 5px 10px 10px 0px;" runat="server" meta:resourcekey="timer2_domenicaResource1" ></asp:checkbox>
                   </div>
                </div>
                 </div>

                </div>
                 <!-- fine riga -->
                         <!-- riga -->
                <div  class="row-fluid">
<div class="span3">
                <div id="riga_timer2_2_1" class="control-group">
                <h5 style="padding-top:10px" class="control-label"><asp:literal ID = "Literal10"  text="Time1" runat="server" meta:resourcekey="Literal10Resource1"></asp:literal></h5>
                <div class="row-fluid">
                    
                <asp:checkbox ID="time2_1" style="margin: 5px 10px 10px 0px;" runat="server" meta:resourcekey="time2_1Resource1" ></asp:checkbox>
                   </div>
                </div>
                 </div>

<div class="span3">
                <div id="riga_timer2_2_2" class="control-group">
                <h5 style="padding-top:10px" class="control-label"><asp:literal ID = "Literal18"  text="Start(HH:MM)" runat="server" meta:resourcekey="Literal18Resource1"></asp:literal></h5>
                <div class="row-fluid">
                    
                <asp:textbox ID="timer2_start_1" onblur   ="javascript: Changed_channel_timer( 'timer2_start_1','riga_timer2_2_2', lunghezza_ora);" onchange = "javascript: Changed_channel_timer( 'timer2_start_1','riga_timer2_2_2', lunghezza_ora);" class="span12"  runat="server" meta:resourcekey="timer2_start_1Resource1"  ></asp:textbox>
                   </div>
                </div>
                 </div>
<div class="span3">
                <div id="riga_timer2_2_3" class="control-group">
                <h5 style="padding-top:10px" class="control-label"><asp:literal ID = "Literal19"  text="Stop(HH:MM)" runat="server" meta:resourcekey="Literal19Resource1"></asp:literal></h5>
                <div class="row-fluid">
                    
                <asp:textbox ID="timer2_stop_1" onblur  ="javascript: Changed_channel_timer( 'timer2_stop_1','riga_timer2_2_3', lunghezza_ora);" onchange = "javascript: Changed_channel_timer( 'timer2_stop_1','riga_timer2_2_3', lunghezza_ora);" class="span12"  runat="server" meta:resourcekey="timer2_stop_1Resource1"  ></asp:textbox>
                   </div>
                </div>
                 </div>

                </div>
    <!-- fine riga -->

<!-- riga -->
<div  class="row-fluid">
 <div class="span3">
                <div id="Div1" class="control-group">
                <h5 style="padding-top:10px" class="control-label"><asp:literal ID = "Literal20"  text="Time2" runat="server" meta:resourcekey="Literal20Resource1"></asp:literal></h5>
                <div class="row-fluid">
                    
                <asp:checkbox ID="time2_2" style="margin: 5px 10px 10px 0px;" runat="server" meta:resourcekey="time2_2Resource1" ></asp:checkbox>
                   </div>
                </div>
                 </div>
 <div class="span3">
                <div id="riga_timer2_3_2" class="control-group">
                <h5 style="padding-top:10px" class="control-label"><asp:literal ID = "Literal21"  text="Start(HH:MM)" runat="server" meta:resourcekey="Literal21Resource1"></asp:literal></h5>
                <div class="row-fluid">
                    
                <asp:textbox ID="timer2_start_2" onblur="javascript: Changed_channel_timer( 'timer2_start_2','riga_timer2_3_2', lunghezza_ora);" onchange ="javascript: Changed_channel_timer( 'timer2_start_2','riga_timer2_3_2', lunghezza_ora);" class="span12"  runat="server" meta:resourcekey="timer2_start_2Resource1"  ></asp:textbox>
                   </div>
                </div>
                 </div>
<div class="span3">
                <div id="riga_timer2_3_3" class="control-group">
                <h5 style="padding-top:10px" class="control-label"><asp:literal ID = "Literal22"  text="Stop(HH:MM)" runat="server" meta:resourcekey="Literal22Resource1"></asp:literal></h5>
                <div class="row-fluid">
                    
                <asp:textbox ID="timer2_stop_2" onblur="javascript: Changed_channel_timer( 'timer2_stop_2','riga_timer2_3_3', lunghezza_ora);" onchange ="javascript: Changed_channel_timer( 'timer2_stop_2','riga_timer2_3_3', lunghezza_ora);" class="span12"  runat="server" meta:resourcekey="timer2_stop_2Resource1"  ></asp:textbox>
                   </div>
                </div>
                 </div>
                </div>
    <!-- fine riga -->

<!-- riga -->
<div  class="row-fluid">
 <div class="span3">
                <div id="Div3" class="control-group">
                <h5 style="padding-top:10px" class="control-label"><asp:literal ID = "Literal23"  text="Time3" runat="server" meta:resourcekey="Literal23Resource1"></asp:literal></h5>
                <div class="row-fluid">
                    
                <asp:checkbox ID="time2_3" style="margin: 5px 10px 10px 0px;" runat="server" meta:resourcekey="time2_3Resource1" ></asp:checkbox>
                   </div>
                </div>
                 </div>
 <div class="span3">
                <div id="riga_timer2_4_2" class="control-group">
                <h5 style="padding-top:10px" class="control-label"><asp:literal ID = "Literal24"  text="Start(HH:MM)" runat="server" meta:resourcekey="Literal24Resource1"></asp:literal></h5>
                <div class="row-fluid">
                    
                <asp:textbox ID="timer2_start_3" onblur="javascript: Changed_channel_timer( 'timer2_start_3','riga_timer2_4_2', lunghezza_ora);" onchange="javascript: Changed_channel_timer( 'timer2_start_3','riga_timer2_4_2', lunghezza_ora);" class="span12"  runat="server" meta:resourcekey="timer2_start_3Resource1"  ></asp:textbox>
                   </div>
                </div>
                 </div>
<div class="span3">
                <div id="riga_timer2_4_3" class="control-group">
                <h5 style="padding-top:10px" class="control-label"><asp:literal ID = "Literal25"  text="Stop(HH:MM)" runat="server" meta:resourcekey="Literal25Resource1"></asp:literal></h5>
                <div class="row-fluid">
                    
                <asp:textbox ID="timer2_stop_3" onblur="javascript: Changed_channel_timer( 'timer2_stop_3','riga_timer2_4_3', lunghezza_ora);" onchange="javascript: Changed_channel_timer( 'timer2_stop_3','riga_timer2_4_3', lunghezza_ora);" class="span12"  runat="server" meta:resourcekey="timer2_stop_3Resource1"  ></asp:textbox>
                   </div>
                </div>
                 </div>
                </div>
    <!-- fine riga -->
				 
    <!-- riga -->
<div  class="row-fluid">
 <div class="span3">
                <div id="riga_timer2_5_1" class="control-group">
                <h5 style="padding-top:10px" class="control-label"><asp:literal ID = "Literal26"  text="Time4" runat="server" meta:resourcekey="Literal26Resource1"></asp:literal></h5>
                <div class="row-fluid">
                    
                <asp:checkbox ID="time2_4" style="margin: 5px 10px 10px 0px;" runat="server" meta:resourcekey="time2_4Resource1" ></asp:checkbox>
                   </div>
                </div>
                 </div>
 <div class="span3">
                <div id="riga_timer2_5_2" class="control-group">
                <h5 style="padding-top:10px" class="control-label"><asp:literal ID = "Literal27"  text="Start(HH:MM)" runat="server" meta:resourcekey="Literal27Resource1"></asp:literal></h5>
                <div class="row-fluid">
                    
                <asp:textbox ID="timer2_start_4" onblur="javascript: Changed_channel_timer( 'timer2_start_4','riga_timer2_5_2', lunghezza_ora);" onchange="javascript: Changed_channel_timer( 'timer2_start_4','riga_timer2_5_2', lunghezza_ora);" class="span12"  runat="server" meta:resourcekey="timer2_start_4Resource1"  ></asp:textbox>
                   </div>
                </div>
                 </div>
<div class="span3">
                <div id="riga_timer2_5_3" class="control-group">
                <h5 style="padding-top:10px" class="control-label"><asp:literal ID = "Literal28"  text="Stop(HH:MM)" runat="server" meta:resourcekey="Literal28Resource1"></asp:literal></h5>
                <div class="row-fluid">
                    
                <asp:textbox ID="timer2_stop_4" class="span12" onblur="javascript: Changed_channel_timer( 'timer2_stop_4','riga_timer2_5_3', lunghezza_ora);" onchange ="javascript: Changed_channel_timer( 'timer2_stop_4','riga_timer2_5_3', lunghezza_ora);"  runat="server" meta:resourcekey="timer2_stop_4Resource1"  ></asp:textbox>
                   </div>
                </div>
                 </div>
                </div>
    <!-- fine riga -->				 

    <!-- riga -->
<div  class="row-fluid">
 <div class="span3">
                <div id="riga_timer2_6_1" class="control-group">
                <h5 style="padding-top:10px" class="control-label"><asp:literal ID = "Literal29"  text="Time5" runat="server" meta:resourcekey="Literal29Resource1"></asp:literal></h5>
                <div class="row-fluid">
                    
                <asp:checkbox ID="time2_5" style="margin: 5px 10px 10px 0px;" runat="server" meta:resourcekey="time2_5Resource1" ></asp:checkbox>
                   </div>
                </div>
                 </div>
 <div class="span3">
                <div id="riga_timer2_6_2" class="control-group">
                <h5 style="padding-top:10px" class="control-label"><asp:literal ID = "Literal30"  text="Start(HH:MM)" runat="server" meta:resourcekey="Literal30Resource1"></asp:literal></h5>
                <div class="row-fluid">
                    
                <asp:textbox ID="timer2_start_5" onblur="javascript: Changed_channel_timer( 'timer2_start_5','riga_timer2_6_2', lunghezza_ora);" onchange ="javascript: Changed_channel_timer( 'timer2_start_5','riga_timer2_6_2', lunghezza_ora);" class="span12"  runat="server" meta:resourcekey="timer2_start_5Resource1"  ></asp:textbox>
                   </div>
                </div>
                 </div>
<div class="span3">
                <div id="riga_timer2_6_3" class="control-group">
                <h5 style="padding-top:10px" class="control-label"><asp:literal ID = "Literal31"  text="Stop(HH:MM)" runat="server" meta:resourcekey="Literal31Resource1"></asp:literal></h5>
                <div class="row-fluid">
                    
                <asp:textbox ID="timer2_stop_5" onblur="javascript: Changed_channel_timer( 'timer2_stop_5','riga_timer2_6_3', lunghezza_ora);" onchange="javascript: Changed_channel_timer( 'timer2_stop_5','riga_timer2_6_3', lunghezza_ora);" class="span12"  runat="server" meta:resourcekey="timer2_stop_5Resource1"  ></asp:textbox>
                   </div>
                </div>
                 </div>
                </div>
    <!-- fine riga -->
				 

    <!-- riga -->
                <div  class="row-fluid">
                <div class="span3">
                <div id="riga_timer2_7_1" class="control-group">
                <h5 style="padding-top:10px" class="control-label"><asp:literal ID = "Literal11"  text="Relay or Pulse" runat="server" meta:resourcekey="Literal11Resource1"></asp:literal></h5>
                <div class="row-fluid">
                    
                    <asp:dropdownlist runat="server" ID="timer2_relay_pulse" meta:resourcekey="timer2_relay_pulseResource1">
                        <asp:ListItem Value="0" meta:resourcekey="ListItemResource14">X</asp:ListItem>
                        <asp:ListItem Value="1" meta:resourcekey="ListItemResource15">Relay 1</asp:ListItem>
                        <asp:ListItem Value="2" meta:resourcekey="ListItemResource16">Relay 2</asp:ListItem>
                        <asp:ListItem Value="3" meta:resourcekey="ListItemResource17">Relay 3</asp:ListItem>
                        <asp:ListItem Value="4" meta:resourcekey="ListItemResource18">Relay 4</asp:ListItem>
                        <asp:ListItem Value="5" meta:resourcekey="ListItemResource19">Relay 5</asp:ListItem>
                        <asp:ListItem Value="6" meta:resourcekey="ListItemResource20">Relay 6</asp:ListItem>
                        <asp:ListItem Value="7" meta:resourcekey="ListItemResource21">Pulse 1</asp:ListItem>
                        <asp:ListItem Value="8" meta:resourcekey="ListItemResource22">Pulse 2</asp:ListItem>
                        <asp:ListItem Value="9" meta:resourcekey="ListItemResource23">Pulse 3</asp:ListItem>
                        <asp:ListItem Value="10" meta:resourcekey="ListItemResource24">Pulse 4</asp:ListItem>
                        <asp:ListItem Value="11" meta:resourcekey="ListItemResource25">Pulse 5</asp:ListItem>
                        <asp:ListItem Value="12" meta:resourcekey="ListItemResource26">Pulse 6</asp:ListItem>
                    </asp:dropdownlist>
                   </div>
                </div>
                 </div>
            <div class="span3">
                <div id="riga_timer2_7_2" class="control-group">
                <h5 style="padding-top:10px" class="control-label"><asp:literal ID = "Literal12"  text="Pulse/minute" runat="server" meta:resourcekey="Literal12Resource1"></asp:literal></h5>
                <div class="row-fluid">
                    
                <asp:textbox ID="value_timer2_pulse_minute_id" class="span12"  runat="server"  onblur="javascript: Changed_channel_timer_value( 'value_timer2_pulse_minute_id','riga_timer2_7_2',180, 0,0 );" MaxLength="3" meta:resourcekey="value_timer2_pulse_minute_idResource1"></asp:textbox>
                   </div>
                </div>
                 </div>
				 </div>
    <!-- fine riga -->
<!-- riga -->
                <div  class="row-fluid">
 <div class="span2">
                <div id="riga_timer2_8_1" class="control-group">
                <h5 style="padding-top:10px" class="control-label"><asp:literal ID = "Literal13"  text="Name Timer" runat="server" meta:resourcekey="Literal13Resource1"></asp:literal></h5>
                <div class="row-fluid">
                    
                <asp:textbox ID="value_timer2_name_id" class="span12"  runat="server"   MaxLength="10" meta:resourcekey="value_timer2_name_idResource1"></asp:textbox>
                   </div>
                </div>
                 </div>
			 </div>
    <!-- fine riga -->    
</div>
                    </div>
                </div>
<!-- tab 2 end-->
<!-- tab 3 start-->
			<div class="tab-pane" id="tab3-4_2">
                <div  class="box-generic">
                                    <!-- riga -->
                <div class="row-fluid">
               	<div class="span3">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal32"  text="Timer3" runat="server" meta:resourcekey="Literal32Resource1"></asp:literal></h5>
                    <asp:radiobutton ID="enable_timer3" style="margin: 5px 10px 10px 0px;" runat="server"  GroupName="GROUP3" meta:resourcekey="enable_timer3Resource1"></asp:radiobutton>
                    <asp:literal runat="server" text ="Enable" meta:resourcekey="LiteralResource5"></asp:literal>
                    <asp:radiobutton ID="disable_timer3" style="margin: 5px 10px 10px 0px;" runat="server"  GroupName="GROUP3" meta:resourcekey="disable_timer3Resource1"></asp:radiobutton>
                       <asp:literal runat="server" text ="Disable" meta:resourcekey="LiteralResource6"></asp:literal>
                </div>
                </div>
                 <!-- fine riga -->
<div id ="div_enable_timer3">
                     <!-- riga -->
                <div  class="row-fluid">
                <div class="span1">
                <div id="riga_timer3_1_1" class="control-group">
                <h5 style="padding-top:10px" class="control-label"><asp:literal ID = "Literal35"  text="Mon" runat="server" meta:resourcekey="Literal35Resource1"></asp:literal></h5>
                <div class="row-fluid">
                    
                <asp:checkbox ID="timer3_lunedi" style="margin: 5px 10px 10px 0px;" runat="server" meta:resourcekey="timer3_lunediResource1" ></asp:checkbox>
                   </div>
                </div>
                 </div>
                
                    <div class="span1">
                <div id="riga_timer3_1_2" class="control-group">
                <h5 style="padding-top:10px" class="control-label"><asp:literal ID = "Literal36"  text="Tue" runat="server" meta:resourcekey="Literal36Resource1"></asp:literal></h5>
                <div class="row-fluid">
                    
                <asp:checkbox ID="timer3_martedi" style="margin: 5px 10px 10px 0px;" runat="server" meta:resourcekey="timer3_martediResource1" ></asp:checkbox>
                   </div>
                </div>
                 </div>

                      <div class="span1">
                <div id="riga_timer3_1_3" class="control-group">
                <h5 style="padding-top:10px" class="control-label"><asp:literal ID = "Literal37"  text="Wed" runat="server" meta:resourcekey="Literal37Resource1"></asp:literal></h5>
                <div class="row-fluid">
                    
                <asp:checkbox ID="timer3_mercoledi" style="margin: 5px 10px 10px 0px;" runat="server" meta:resourcekey="timer3_mercolediResource1" ></asp:checkbox>
                   </div>
                </div>
                 </div>

                      <div class="span1">
                <div id="riga_timer3_1_4" class="control-group">
                <h5 style="padding-top:10px" class="control-label"><asp:literal ID = "Literal38"  text="Thu" runat="server" meta:resourcekey="Literal38Resource1"></asp:literal></h5>
                <div class="row-fluid">
                    
                <asp:checkbox ID="timer3_giovedi" style="margin: 5px 10px 10px 0px;" runat="server" meta:resourcekey="timer3_giovediResource1" ></asp:checkbox>
                   </div>
                </div>
                 </div>

                    <div class="span1">
                <div id="riga_timer3_1_5" class="control-group">
                <h5 style="padding-top:10px" class="control-label"><asp:literal ID = "Literal39"  text="Fri" runat="server" meta:resourcekey="Literal39Resource1"></asp:literal></h5>
                <div class="row-fluid">
                    
                <asp:checkbox ID="timer3_venerdi" style="margin: 5px 10px 10px 0px;" runat="server" meta:resourcekey="timer3_venerdiResource1" ></asp:checkbox>
                   </div>
                </div>
                 </div>

                     <div class="span1">
                <div id="riga_timer3_1_6" class="control-group">
                <h5 style="padding-top:10px" class="control-label"><asp:literal ID = "Literal40"  text="Sat" runat="server" meta:resourcekey="Literal40Resource1"></asp:literal></h5>
                <div class="row-fluid">
                    
                <asp:checkbox ID="timer3_sabato" style="margin: 5px 10px 10px 0px;" runat="server" meta:resourcekey="timer3_sabatoResource1" ></asp:checkbox>
                   </div>
                </div>
                 </div>

                     <div class="span1">
                <div id="riga_timer3_1_7" class="control-group">
                <h5 style="padding-top:10px" class="control-label"><asp:literal ID = "Literal41"  text="Sun" runat="server" meta:resourcekey="Literal41Resource1"></asp:literal></h5>
                <div class="row-fluid">
                    
                <asp:checkbox ID="timer3_domenica" style="margin: 5px 10px 10px 0px;" runat="server" meta:resourcekey="timer3_domenicaResource1" ></asp:checkbox>
                   </div>
                </div>
                 </div>

                </div>
                 <!-- fine riga -->
                         <!-- riga -->
                <div  class="row-fluid">
<div class="span3">
                <div id="riga_timer3_2_1" class="control-group">
                <h5 style="padding-top:10px" class="control-label"><asp:literal ID = "Literal42"  text="Time1" runat="server" meta:resourcekey="Literal42Resource1"></asp:literal></h5>
                <div class="row-fluid">
                    
                <asp:checkbox ID="time3_1" style="margin: 5px 10px 10px 0px;" runat="server" meta:resourcekey="time3_1Resource1" ></asp:checkbox>
                   </div>
                </div>
                 </div>

<div class="span3">
                <div id="riga_timer3_2_2" class="control-group">
                <h5 style="padding-top:10px" class="control-label"><asp:literal ID = "Literal43"  text="Start(HH:MM)" runat="server" meta:resourcekey="Literal43Resource1"></asp:literal></h5>
                <div class="row-fluid">
                    
                <asp:textbox ID="timer3_start_1" onblur="javascript: Changed_channel_timer( 'timer3_start_1','riga_timer3_2_2', lunghezza_ora);" onchange ="javascript: Changed_channel_timer( 'timer3_start_1','riga_timer3_2_2', lunghezza_ora);" class="span12"  runat="server" meta:resourcekey="timer3_start_1Resource1"  ></asp:textbox>
                   </div>
                </div>
                 </div>
<div class="span3">
                <div id="riga_timer3_2_3" class="control-group">
                <h5 style="padding-top:10px" class="control-label"><asp:literal ID = "Literal44"  text="Stop(HH:MM)" runat="server" meta:resourcekey="Literal44Resource1"></asp:literal></h5>
                <div class="row-fluid">
                    
                <asp:textbox ID="timer3_stop_1" onblur="javascript: Changed_channel_timer( 'timer3_stop_1','riga_timer3_2_3', lunghezza_ora);" onchange ="javascript: Changed_channel_timer( 'timer3_stop_1','riga_timer3_2_3', lunghezza_ora);"  class="span12"  runat="server" meta:resourcekey="timer3_stop_1Resource1"  ></asp:textbox>
                   </div>
                </div>
                 </div>

                </div>
    <!-- fine riga -->

<!-- riga -->
<div  class="row-fluid">
 <div class="span3">
                <div id="Div4" class="control-group">
                <h5 style="padding-top:10px" class="control-label"><asp:literal ID = "Literal45"  text="Time2" runat="server" meta:resourcekey="Literal45Resource1"></asp:literal></h5>
                <div class="row-fluid">
                    
                <asp:checkbox ID="time3_2" style="margin: 5px 10px 10px 0px;" runat="server" meta:resourcekey="time3_2Resource1" ></asp:checkbox>
                   </div>
                </div>
                 </div>
 <div class="span3">
                <div id="riga_timer3_3_2" class="control-group">
                <h5 style="padding-top:10px" class="control-label"><asp:literal ID = "Literal46"  text="Start(HH:MM)" runat="server" meta:resourcekey="Literal46Resource1"></asp:literal></h5>
                <div class="row-fluid">
                    
                <asp:textbox ID="timer3_start_2" onblur="javascript: Changed_channel_timer( 'timer3_start_2','riga_timer3_3_2', lunghezza_ora);" onchange ="javascript: Changed_channel_timer(  'timer3_start_2','riga_timer3_3_2', lunghezza_ora);" class="span12"  runat="server" meta:resourcekey="timer3_start_2Resource1"  ></asp:textbox>
                   </div>
                </div>
                 </div>
<div class="span3">
                <div id="riga_timer3_3_3" class="control-group">
                <h5 style="padding-top:10px" class="control-label"><asp:literal ID = "Literal47"  text="Stop(HH:MM)" runat="server" meta:resourcekey="Literal47Resource1"></asp:literal></h5>
                <div class="row-fluid">
                    
                <asp:textbox ID="timer3_stop_2" onblur="javascript: Changed_channel_timer( 'timer3_stop_2','riga_timer3_3_3', lunghezza_ora);" onchange ="javascript: Changed_channel_timer( 'timer3_stop_2','riga_timer3_3_3', lunghezza_ora);" class="span12"  runat="server" meta:resourcekey="timer3_stop_2Resource1"  ></asp:textbox>
                   </div>
                </div>
                 </div>
                </div>
    <!-- fine riga -->

<!-- riga -->
<div  class="row-fluid">
 <div class="span3">
                <div id="Div6" class="control-group">
                <h5 style="padding-top:10px" class="control-label"><asp:literal ID = "Literal48"  text="Time3" runat="server" meta:resourcekey="Literal48Resource1"></asp:literal></h5>
                <div class="row-fluid">
                    
                <asp:checkbox ID="time3_3" style="margin: 5px 10px 10px 0px;" runat="server" meta:resourcekey="time3_3Resource1" ></asp:checkbox>
                   </div>
                </div>
                 </div>
 <div class="span3">
                <div id="riga_timer3_4_2" class="control-group">
                <h5 style="padding-top:10px" class="control-label"><asp:literal ID = "Literal49"  text="Start(HH:MM)" runat="server" meta:resourcekey="Literal49Resource1"></asp:literal></h5>
                <div class="row-fluid">
                    
                <asp:textbox ID="timer3_start_3" onblur="javascript: Changed_channel_timer( 'timer3_start_3','riga_timer3_4_2', lunghezza_ora);" onchange ="javascript: Changed_channel_timer( 'timer3_start_3','riga_timer3_4_2', lunghezza_ora);" class="span12"  runat="server" meta:resourcekey="timer3_start_3Resource1"  ></asp:textbox>
                   </div>
                </div>
                 </div>
<div class="span3">
                <div id="riga_timer3_4_3" class="control-group">
                <h5 style="padding-top:10px" class="control-label"><asp:literal ID = "Literal50"  text="Stop(HH:MM)" runat="server" meta:resourcekey="Literal50Resource1"></asp:literal></h5>
                <div class="row-fluid">
                    
                <asp:textbox ID="timer3_stop_3" onblur="javascript: Changed_channel_timer( 'timer3_stop_3','riga_timer3_4_3', lunghezza_ora);" onchange ="javascript: Changed_channel_timer( 'timer3_stop_3','riga_timer3_4_3', lunghezza_ora);" class="span12"  runat="server" meta:resourcekey="timer3_stop_3Resource1"  ></asp:textbox>
                   </div>
                </div>
                 </div>
                </div>
    <!-- fine riga -->
				 
    <!-- riga -->
<div  class="row-fluid">
 <div class="span3">
                <div id="riga_timer3_5_1" class="control-group">
                <h5 style="padding-top:10px" class="control-label"><asp:literal ID = "Literal51"  text="Time4" runat="server" meta:resourcekey="Literal51Resource1"></asp:literal></h5>
                <div class="row-fluid">
                    
                <asp:checkbox ID="time3_4" style="margin: 5px 10px 10px 0px;" runat="server" meta:resourcekey="time3_4Resource1" ></asp:checkbox>
                   </div>
                </div>
                 </div>
 <div class="span3">
                <div id="riga_timer3_5_2" class="control-group">
                <h5 style="padding-top:10px" class="control-label"><asp:literal ID = "Literal52"  text="Start(HH:MM)" runat="server" meta:resourcekey="Literal52Resource1"></asp:literal></h5>
                <div class="row-fluid">
                    
                <asp:textbox ID="timer3_start_4" onblur="javascript: Changed_channel_timer( 'timer3_start_4','riga_timer3_5_2', lunghezza_ora);" onchange ="javascript: Changed_channel_timer( 'timer3_start_4','riga_timer3_5_2', lunghezza_ora);" class="span12"  runat="server" meta:resourcekey="timer3_start_4Resource1"  ></asp:textbox>
                   </div>
                </div>
                 </div>
<div class="span3">
                <div id="riga_timer3_5_3" class="control-group">
                <h5 style="padding-top:10px" class="control-label"><asp:literal ID = "Literal53"  text="Stop(HH:MM)" runat="server" meta:resourcekey="Literal53Resource1"></asp:literal></h5>
                <div class="row-fluid">
                    
                <asp:textbox ID="timer3_stop_4" onblur="javascript: Changed_channel_timer( 'timer3_stop_4','riga_timer3_5_3', lunghezza_ora);" onchange ="javascript: Changed_channel_timer('timer3_stop_4','riga_timer3_5_3', lunghezza_ora);" class="span12"  runat="server" meta:resourcekey="timer3_stop_4Resource1"  ></asp:textbox>
                   </div>
                </div>
                 </div>
                </div>
    <!-- fine riga -->				 

    <!-- riga -->
<div  class="row-fluid">
 <div class="span3">
                <div id="riga_timer3_6_1" class="control-group">
                <h5 style="padding-top:10px" class="control-label"><asp:literal ID = "Literal54"  text="Time5" runat="server" meta:resourcekey="Literal54Resource1"></asp:literal></h5>
                <div class="row-fluid">
                    
                <asp:checkbox ID="time3_5" style="margin: 5px 10px 10px 0px;" runat="server" meta:resourcekey="time3_5Resource1" ></asp:checkbox>
                   </div>
                </div>
                 </div>
 <div class="span3">
                <div id="riga_timer3_6_2" class="control-group">
                <h5 style="padding-top:10px" class="control-label"><asp:literal ID = "Literal55"  text="Start(HH:MM)" runat="server" meta:resourcekey="Literal55Resource1"></asp:literal></h5>
                <div class="row-fluid">
                    
                <asp:textbox ID="timer3_start_5" onblur="javascript: Changed_channel_timer( 'timer3_start_5','riga_timer3_6_2', lunghezza_ora);" onchange ="javascript: Changed_channel_timer('timer3_start_5','riga_timer3_6_2', lunghezza_ora);" class="span12"  runat="server" meta:resourcekey="timer3_start_5Resource1"  ></asp:textbox>
                   </div>
                </div>
                 </div>
<div class="span3">
                <div id="riga_timer3_6_3" class="control-group">
                <h5 style="padding-top:10px" class="control-label"><asp:literal ID = "Literal56"  text="Stop(HH:MM)" runat="server" meta:resourcekey="Literal56Resource1"></asp:literal></h5>
                <div class="row-fluid">
                    
                <asp:textbox ID="timer3_stop_5" onblur="javascript: Changed_channel_timer( 'timer3_stop_5','riga_timer3_6_3', lunghezza_ora);" onchange ="javascript: Changed_channel_timer('timer3_stop_5','riga_timer3_6_3', lunghezza_ora);" class="span12"  runat="server" meta:resourcekey="timer3_stop_5Resource1"  ></asp:textbox>
                   </div>
                </div>
                 </div>
                </div>
    <!-- fine riga -->
				 

    <!-- riga -->
                <div  class="row-fluid">
                <div class="span3">
                <div id="riga_timer3_3_1" class="control-group">
                <h5 style="padding-top:10px" class="control-label"><asp:literal ID = "Literal57"  text="Relay or Pulse" runat="server" meta:resourcekey="Literal57Resource1"></asp:literal></h5>
                <div class="row-fluid">
                    
                    <asp:dropdownlist runat="server" ID="timer3_relay_pulse" meta:resourcekey="timer3_relay_pulseResource1">
                        <asp:ListItem Value="0" meta:resourcekey="ListItemResource27">X</asp:ListItem>
                        <asp:ListItem Value="1" meta:resourcekey="ListItemResource28">Relay 1</asp:ListItem>
                        <asp:ListItem Value="2" meta:resourcekey="ListItemResource29">Relay 2</asp:ListItem>
                        <asp:ListItem Value="3" meta:resourcekey="ListItemResource30">Relay 3</asp:ListItem>
                        <asp:ListItem Value="4" meta:resourcekey="ListItemResource31">Relay 4</asp:ListItem>
                        <asp:ListItem Value="5" meta:resourcekey="ListItemResource32">Relay 5</asp:ListItem>
                        <asp:ListItem Value="6" meta:resourcekey="ListItemResource33">Relay 6</asp:ListItem>
                        <asp:ListItem Value="7" meta:resourcekey="ListItemResource34">Pulse 1</asp:ListItem>
                        <asp:ListItem Value="8" meta:resourcekey="ListItemResource35">Pulse 2</asp:ListItem>
                        <asp:ListItem Value="9" meta:resourcekey="ListItemResource36">Pulse 3</asp:ListItem>
                        <asp:ListItem Value="10" meta:resourcekey="ListItemResource37">Pulse 4</asp:ListItem>
                        <asp:ListItem Value="11" meta:resourcekey="ListItemResource38">Pulse 5</asp:ListItem>
                        <asp:ListItem Value="12" meta:resourcekey="ListItemResource39">Pulse 6</asp:ListItem>
                    </asp:dropdownlist>
                   </div>
                </div>
                 </div>
            <div class="span3">
                <div id="riga_timer3_7_2" class="control-group">
                <h5 style="padding-top:10px" class="control-label"><asp:literal ID = "Literal58"  text="Pulse/minute" runat="server" meta:resourcekey="Literal58Resource1"></asp:literal></h5>
                <div class="row-fluid">
                    
                <asp:textbox ID="value_timer3_pulse_minute_id" class="span12"  runat="server"  onblur="javascript: Changed_channel_timer_value( 'value_timer3_pulse_minute_id','riga_timer3_3_2',180, 0,0 );" MaxLength="3" meta:resourcekey="value_timer3_pulse_minute_idResource1"></asp:textbox>
                   </div>
                </div>
                 </div>
				 </div>
    <!-- fine riga -->
<!-- riga -->
                <div  class="row-fluid">
 <div class="span2">
                <div id="riga_timer3_4_1" class="control-group">
                <h5 style="padding-top:10px" class="control-label"><asp:literal ID = "Literal59"  text="Name Timer" runat="server" meta:resourcekey="Literal59Resource1"></asp:literal></h5>
                <div class="row-fluid">
                    
                <asp:textbox ID="value_timer3_name_id" class="span12"  runat="server"   MaxLength="10" meta:resourcekey="value_timer3_name_idResource1"></asp:textbox>
                   </div>
                </div>
                 </div>
			 </div>
    <!-- fine riga -->    
</div>
                    </div>
                </div>
<!-- tab 3 end-->
      <!-- tab 4 start-->
			<div class="tab-pane" id="tab4-4_2">
                <div  class="box-generic">
                                    <!-- riga -->
                <div class="row-fluid">
               	<div class="span3">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal33"  text="Timer4" runat="server" meta:resourcekey="Literal33Resource1"></asp:literal></h5>
                    <asp:radiobutton ID="enable_timer4" style="margin: 5px 10px 10px 0px;" runat="server"  GroupName="GROUP4" meta:resourcekey="enable_timer4Resource1"></asp:radiobutton>
                    <asp:literal runat="server" text ="Enable" meta:resourcekey="LiteralResource7"></asp:literal>
                    <asp:radiobutton ID="disable_timer4" style="margin: 5px 10px 10px 0px;" runat="server"  GroupName="GROUP4" meta:resourcekey="disable_timer4Resource1"></asp:radiobutton>
                       <asp:literal runat="server" text ="Disable" meta:resourcekey="LiteralResource8"></asp:literal>
                </div>
                </div>
                 <!-- fine riga -->
<div id ="div_enable_timer4">
                     <!-- riga -->
                <div  class="row-fluid">
                <div class="span1">
                <div id="riga_timer4_1_1" class="control-group">
                <h5 style="padding-top:10px" class="control-label"><asp:literal ID = "Literal61"  text="Mon" runat="server" meta:resourcekey="Literal61Resource1"></asp:literal></h5>
                <div class="row-fluid">
                    
                <asp:checkbox ID="timer4_lunedi" style="margin: 5px 10px 10px 0px;" runat="server" meta:resourcekey="timer4_lunediResource1" ></asp:checkbox>
                   </div>
                </div>
                 </div>
                
                    <div class="span1">
                <div id="riga_timer4_1_2" class="control-group">
                <h5 style="padding-top:10px" class="control-label"><asp:literal ID = "Literal62"  text="Tue" runat="server" meta:resourcekey="Literal62Resource1"></asp:literal></h5>
                <div class="row-fluid">
                    
                <asp:checkbox ID="timer4_martedi" style="margin: 5px 10px 10px 0px;" runat="server" meta:resourcekey="timer4_martediResource1" ></asp:checkbox>
                   </div>
                </div>
                 </div>

                      <div class="span1">
                <div id="riga_timer4_1_3" class="control-group">
                <h5 style="padding-top:10px" class="control-label"><asp:literal ID = "Literal63"  text="Wed" runat="server" meta:resourcekey="Literal63Resource1"></asp:literal></h5>
                <div class="row-fluid">
                    
                <asp:checkbox ID="timer4_mercoledi" style="margin: 5px 10px 10px 0px;" runat="server" meta:resourcekey="timer4_mercolediResource1" ></asp:checkbox>
                   </div>
                </div>
                 </div>

                      <div class="span1">
                <div id="riga_timer4_1_4" class="control-group">
                <h5 style="padding-top:10px" class="control-label"><asp:literal ID = "Literal64"  text="Thu" runat="server" meta:resourcekey="Literal64Resource1"></asp:literal></h5>
                <div class="row-fluid">
                    
                <asp:checkbox ID="timer4_giovedi" style="margin: 5px 10px 10px 0px;" runat="server" meta:resourcekey="timer4_giovediResource1" ></asp:checkbox>
                   </div>
                </div>
                 </div>

                    <div class="span1">
                <div id="riga_timer4_1_5" class="control-group">
                <h5 style="padding-top:10px" class="control-label"><asp:literal ID = "Literal65"  text="Fri" runat="server" meta:resourcekey="Literal65Resource1"></asp:literal></h5>
                <div class="row-fluid">
                    
                <asp:checkbox ID="timer4_venerdi" style="margin: 5px 10px 10px 0px;" runat="server" meta:resourcekey="timer4_venerdiResource1" ></asp:checkbox>
                   </div>
                </div>
                 </div>

                     <div class="span1">
                <div id="riga_timer4_1_6" class="control-group">
                <h5 style="padding-top:10px" class="control-label"><asp:literal ID = "Literal66"  text="Sat" runat="server" meta:resourcekey="Literal66Resource1"></asp:literal></h5>
                <div class="row-fluid">
                    
                <asp:checkbox ID="timer4_sabato" style="margin: 5px 10px 10px 0px;" runat="server" meta:resourcekey="timer4_sabatoResource1" ></asp:checkbox>
                   </div>
                </div>
                 </div>

                     <div class="span1">
                <div id="riga_timer4_1_7" class="control-group">
                <h5 style="padding-top:10px" class="control-label"><asp:literal ID = "Literal67"  text="Sun" runat="server" meta:resourcekey="Literal67Resource1"></asp:literal></h5>
                <div class="row-fluid">
                    
                <asp:checkbox ID="timer4_domenica" style="margin: 5px 10px 10px 0px;" runat="server" meta:resourcekey="timer4_domenicaResource1" ></asp:checkbox>
                   </div>
                </div>
                 </div>

                </div>
                 <!-- fine riga -->
                         <!-- riga -->
                <div  class="row-fluid">
<div class="span3">
                <div id="riga_timer4_2_1" class="control-group">
                <h5 style="padding-top:10px" class="control-label"><asp:literal ID = "Literal68"  text="Time1" runat="server" meta:resourcekey="Literal68Resource1"></asp:literal></h5>
                <div class="row-fluid">
                    
                <asp:checkbox ID="time4_1" style="margin: 5px 10px 10px 0px;" runat="server" meta:resourcekey="time4_1Resource1" ></asp:checkbox>
                   </div>
                </div>
                 </div>

<div class="span3">
                <div id="riga_timer4_2_2" class="control-group">
                <h5 style="padding-top:10px" class="control-label"><asp:literal ID = "Literal69"  text="Start(HH:MM)" runat="server" meta:resourcekey="Literal69Resource1"></asp:literal></h5>
                <div class="row-fluid">
                    
                <asp:textbox ID="timer4_start_1" onblur="javascript: Changed_channel_timer( 'timer4_start_1','riga_timer4_2_2', lunghezza_ora);" onchange ="javascript: Changed_channel_timer('timer4_start_1','riga_timer4_2_2', lunghezza_ora);" class="span12"  runat="server" meta:resourcekey="timer4_start_1Resource1"  ></asp:textbox>
                   </div>
                </div>
                 </div>
<div class="span3">
                <div id="riga_timer4_2_3" class="control-group">
                <h5 style="padding-top:10px" class="control-label"><asp:literal ID = "Literal70"  text="Stop(HH:MM)" runat="server" meta:resourcekey="Literal70Resource1"></asp:literal></h5>
                <div class="row-fluid">
                    
                <asp:textbox ID="timer4_stop_1" onblur="javascript: Changed_channel_timer( 'timer4_stop_1','riga_timer4_2_3', lunghezza_ora);" onchange ="javascript: Changed_channel_timer('timer4_stop_1','riga_timer4_2_3', lunghezza_ora);" class="span12"  runat="server" meta:resourcekey="timer4_stop_1Resource1"  ></asp:textbox>
                   </div>
                </div>
                 </div>

                </div>
    <!-- fine riga -->

<!-- riga -->
<div  class="row-fluid">
 <div class="span3">
                <div id="Div7" class="control-group">
                <h5 style="padding-top:10px" class="control-label"><asp:literal ID = "Literal71"  text="Time2" runat="server" meta:resourcekey="Literal71Resource1"></asp:literal></h5>
                <div class="row-fluid">
                    
                <asp:checkbox ID="time4_2" style="margin: 5px 10px 10px 0px;" runat="server" meta:resourcekey="time4_2Resource1" ></asp:checkbox>
                   </div>
                </div>
                 </div>
 <div class="span3">
                <div id="riga_timer4_3_2" class="control-group">
                <h5 style="padding-top:10px" class="control-label"><asp:literal ID = "Literal72"  text="Start(HH:MM)" runat="server" meta:resourcekey="Literal72Resource1"></asp:literal></h5>
                <div class="row-fluid">
                    
                <asp:textbox ID="timer4_start_2" onblur="javascript: Changed_channel_timer( 'timer4_start_2','riga_timer4_3_2', lunghezza_ora);" onchange ="javascript: Changed_channel_timer('timer4_start_2','riga_timer4_3_2', lunghezza_ora);" class="span12"  runat="server" meta:resourcekey="timer4_start_2Resource1"  ></asp:textbox>
                   </div>
                </div>
                 </div>
<div class="span3">
                <div id="riga_timer4_3_3" class="control-group">
                <h5 style="padding-top:10px" class="control-label"><asp:literal ID = "Literal73"  text="Stop(HH:MM)" runat="server" meta:resourcekey="Literal73Resource1"></asp:literal></h5>
                <div class="row-fluid">
                    
                <asp:textbox ID="timer4_stop_2" onblur="javascript: Changed_channel_timer( 'timer4_stop_2','riga_timer4_3_3', lunghezza_ora);" onchange ="javascript: Changed_channel_timer('timer4_stop_2','riga_timer4_3_3', lunghezza_ora);" class="span12"  runat="server" meta:resourcekey="timer4_stop_2Resource1"  ></asp:textbox>
                   </div>
                </div>
                 </div>
                </div>
    <!-- fine riga -->

<!-- riga -->
<div  class="row-fluid">
 <div class="span3">
                <div id="Div9" class="control-group">
                <h5 style="padding-top:10px" class="control-label"><asp:literal ID = "Literal74"  text="Time3" runat="server" meta:resourcekey="Literal74Resource1"></asp:literal></h5>
                <div class="row-fluid">
                    
                <asp:checkbox ID="time4_3" style="margin: 5px 10px 10px 0px;" runat="server" meta:resourcekey="time4_3Resource1" ></asp:checkbox>
                   </div>
                </div>
                 </div>
 <div class="span3">
                <div id="riga_timer4_4_2" class="control-group">
                <h5 style="padding-top:10px" class="control-label"><asp:literal ID = "Literal75"  text="Start(HH:MM)" runat="server" meta:resourcekey="Literal75Resource1"></asp:literal></h5>
                <div class="row-fluid">
                    
                <asp:textbox ID="timer4_start_3"  onblur="javascript: Changed_channel_timer( 'timer4_start_3','riga_timer4_4_2', lunghezza_ora);" onchange ="javascript: Changed_channel_timer('timer4_start_3','riga_timer4_4_2', lunghezza_ora);"  class="span12"  runat="server" meta:resourcekey="timer4_start_3Resource1"  ></asp:textbox>
                   </div>
                </div>
                 </div>
<div class="span3">
                <div id="riga_timer4_4_3" class="control-group">
                <h5 style="padding-top:10px" class="control-label"><asp:literal ID = "Literal76"  text="Stop(HH:MM)" runat="server" meta:resourcekey="Literal76Resource1"></asp:literal></h5>
                <div class="row-fluid">
                    
                <asp:textbox ID="timer4_stop_3" onblur="javascript: Changed_channel_timer( 'timer4_stop_3','riga_timer4_4_3', lunghezza_ora);" onchange ="javascript: Changed_channel_timer('timer4_stop_3','riga_timer4_4_3', lunghezza_ora);" class="span12"  runat="server" meta:resourcekey="timer4_stop_3Resource1"  ></asp:textbox>
                   </div>
                </div>
                 </div>
                </div>
    <!-- fine riga -->
				 
    <!-- riga -->
<div  class="row-fluid">
 <div class="span3">
                <div id="riga_timer4_5_1" class="control-group">
                <h5 style="padding-top:10px" class="control-label"><asp:literal ID = "Literal77"  text="Time4" runat="server" meta:resourcekey="Literal77Resource1"></asp:literal></h5>
                <div class="row-fluid">
                    
                <asp:checkbox ID="time4_4" style="margin: 5px 10px 10px 0px;" runat="server" meta:resourcekey="time4_4Resource1" ></asp:checkbox>
                   </div>
                </div>
                 </div>
 <div class="span3">
                <div id="riga_timer4_5_2" class="control-group">
                <h5 style="padding-top:10px" class="control-label"><asp:literal ID = "Literal78"  text="Start(HH:MM)" runat="server" meta:resourcekey="Literal78Resource1"></asp:literal></h5>
                <div class="row-fluid">
                    
                <asp:textbox ID="timer4_start_4"  onblur="javascript: Changed_channel_timer( 'timer4_start_4','riga_timer4_5_2', lunghezza_ora);" onchange ="javascript: Changed_channel_timer('timer4_start_4','riga_timer4_5_2', lunghezza_ora);" class="span12"  runat="server" meta:resourcekey="timer4_start_4Resource1"  ></asp:textbox>
                   </div>
                </div>
                 </div>
<div class="span3">
                <div id="riga_timer4_5_3" class="control-group">
                <h5 style="padding-top:10px" class="control-label"><asp:literal ID = "Literal79"  text="Stop(HH:MM)" runat="server" meta:resourcekey="Literal79Resource1"></asp:literal></h5>
                <div class="row-fluid">
                    
                <asp:textbox ID="timer4_stop_4" onblur="javascript: Changed_channel_timer( 'timer4_stop_4','riga_timer4_5_3', lunghezza_ora);" onchange ="javascript: Changed_channel_timer( 'timer4_stop_4','riga_timer4_5_3', lunghezza_ora);" class="span12"  runat="server" meta:resourcekey="timer4_stop_4Resource1"  ></asp:textbox>
                   </div>
                </div>
                 </div>
                </div>
    <!-- fine riga -->				 

    <!-- riga -->
<div  class="row-fluid">
 <div class="span3">
                <div id="riga_timer4_6_1" class="control-group">
                <h5 style="padding-top:10px" class="control-label"><asp:literal ID = "Literal80"  text="Time5" runat="server" meta:resourcekey="Literal80Resource1"></asp:literal></h5>
                <div class="row-fluid">
                    
                <asp:checkbox ID="time4_5" style="margin: 5px 10px 10px 0px;" runat="server" meta:resourcekey="time4_5Resource1" ></asp:checkbox>
                   </div>
                </div>
                 </div>
 <div class="span3">
                <div id="riga_timer4_6_2" class="control-group">
                <h5 style="padding-top:10px" class="control-label"><asp:literal ID = "Literal81"  text="Start(HH:MM)" runat="server" meta:resourcekey="Literal81Resource1"></asp:literal></h5>
                <div class="row-fluid">
                    
                <asp:textbox ID="timer4_start_5" onblur="javascript: Changed_channel_timer( 'timer4_start_5','riga_timer4_6_2', lunghezza_ora);" onchange ="javascript: Changed_channel_timer(  'timer4_start_5','riga_timer4_6_2', lunghezza_ora);" class="span12"  runat="server" meta:resourcekey="timer4_start_5Resource1"  ></asp:textbox>
                   </div>
                </div>
                 </div>
<div class="span3">
                <div id="riga_timer4_6_3" class="control-group">
                <h5 style="padding-top:10px" class="control-label"><asp:literal ID = "Literal82"  text="Stop(HH:MM)" runat="server" meta:resourcekey="Literal82Resource1"></asp:literal></h5>
                <div class="row-fluid">
                    
                <asp:textbox ID="timer4_stop_5" onblur="javascript: Changed_channel_timer( 'timer4_stop_5','riga_timer4_6_3', lunghezza_ora);" onchange ="javascript: Changed_channel_timer(  'timer4_stop_5','riga_timer4_6_3', lunghezza_ora);" class="span12"  runat="server" meta:resourcekey="timer4_stop_5Resource1"  ></asp:textbox>
                   </div>
                </div>
                 </div>
                </div>
    <!-- fine riga -->
				 

    <!-- riga -->
                <div  class="row-fluid">
                <div class="span3">
                <div id="riga_timer4_3_1" class="control-group">
                <h5 style="padding-top:10px" class="control-label"><asp:literal ID = "Literal83"  text="Relay or Pulse" runat="server" meta:resourcekey="Literal83Resource1"></asp:literal></h5>
                <div class="row-fluid">
                    
                    <asp:dropdownlist runat="server" ID="timer4_relay_pulse" meta:resourcekey="timer4_relay_pulseResource1">
                        <asp:ListItem Value="0" meta:resourcekey="ListItemResource40">X</asp:ListItem>
                        <asp:ListItem Value="1" meta:resourcekey="ListItemResource41">Relay 1</asp:ListItem>
                        <asp:ListItem Value="2" meta:resourcekey="ListItemResource42">Relay 2</asp:ListItem>
                        <asp:ListItem Value="3" meta:resourcekey="ListItemResource43">Relay 3</asp:ListItem>
                        <asp:ListItem Value="4" meta:resourcekey="ListItemResource44">Relay 4</asp:ListItem>
                        <asp:ListItem Value="5" meta:resourcekey="ListItemResource45">Relay 5</asp:ListItem>
                        <asp:ListItem Value="6" meta:resourcekey="ListItemResource46">Relay 6</asp:ListItem>
                        <asp:ListItem Value="7" meta:resourcekey="ListItemResource47">Pulse 1</asp:ListItem>
                        <asp:ListItem Value="8" meta:resourcekey="ListItemResource48">Pulse 2</asp:ListItem>
                        <asp:ListItem Value="9" meta:resourcekey="ListItemResource49">Pulse 3</asp:ListItem>
                        <asp:ListItem Value="10" meta:resourcekey="ListItemResource50">Pulse 4</asp:ListItem>
                        <asp:ListItem Value="11" meta:resourcekey="ListItemResource51">Pulse 5</asp:ListItem>
                        <asp:ListItem Value="12" meta:resourcekey="ListItemResource52">Pulse 6</asp:ListItem>
                    </asp:dropdownlist>
                   </div>
                </div>
                 </div>
            <div class="span3">
                <div id="riga_timer4_7_2" class="control-group">
                <h5 style="padding-top:10px" class="control-label"><asp:literal ID = "Literal84"  text="Pulse/minute" runat="server" meta:resourcekey="Literal84Resource1"></asp:literal></h5>
                <div class="row-fluid">
                    
                <asp:textbox ID="value_timer4_pulse_minute_id" class="span12"  runat="server"  onblur="javascript: Changed_channel_timer_value( 'value_timer4_pulse_minute_id','riga_timer4_3_2',180, 0,0 );" MaxLength="3" meta:resourcekey="value_timer4_pulse_minute_idResource1"></asp:textbox>
                   </div>
                </div>
                 </div>
				 </div>
    <!-- fine riga -->
<!-- riga -->
                <div  class="row-fluid">
 <div class="span2">
                <div id="riga_timer4_4_1" class="control-group">
                <h5 style="padding-top:10px" class="control-label"><asp:literal ID = "Literal85"  text="Name Timer" runat="server" meta:resourcekey="Literal85Resource1"></asp:literal></h5>
                <div class="row-fluid">
                    
                <asp:textbox ID="value_timer4_name_id" class="span12"  runat="server"   MaxLength="10" meta:resourcekey="value_timer4_name_idResource1"></asp:textbox>
                   </div>
                </div>
                 </div>
			 </div>
    <!-- fine riga -->    
</div>
                    </div>
                </div>
<!-- tab 4 end-->
    <!-- tab 5 start-->
			<div class="tab-pane" id="tab5-4_2">
                <div  class="box-generic">
                                    <!-- riga -->
                <div class="row-fluid">
               	<div class="span3">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal34"  text="Timer5" runat="server" meta:resourcekey="Literal34Resource1"></asp:literal></h5>
                    <asp:radiobutton ID="enable_timer5" style="margin: 5px 10px 10px 0px;" runat="server"  GroupName="GROUP5" meta:resourcekey="enable_timer5Resource1"></asp:radiobutton>
                    <asp:literal runat="server" text ="Enable" meta:resourcekey="LiteralResource9"></asp:literal>
                    <asp:radiobutton ID="disable_timer5" style="margin: 5px 10px 10px 0px;" runat="server"  GroupName="GROUP5" meta:resourcekey="disable_timer5Resource1"></asp:radiobutton>
                       <asp:literal runat="server" text ="Disable" meta:resourcekey="LiteralResource10"></asp:literal>
                </div>
                </div>
                 <!-- fine riga -->
<div id ="div_enable_timer5">
                     <!-- riga -->
                <div  class="row-fluid">
                <div class="span1">
                <div id="riga_timer5_1_1" class="control-group">
                <h5 style="padding-top:10px" class="control-label"><asp:literal ID = "Literal87"  text="Mon" runat="server" meta:resourcekey="Literal87Resource1"></asp:literal></h5>
                <div class="row-fluid">
                    
                <asp:checkbox ID="timer5_lunedi" style="margin: 5px 10px 10px 0px;" runat="server" meta:resourcekey="timer5_lunediResource1" ></asp:checkbox>
                   </div>
                </div>
                 </div>
                
                    <div class="span1">
                <div id="riga_timer5_1_2" class="control-group">
                <h5 style="padding-top:10px" class="control-label"><asp:literal ID = "Literal88"  text="Tue" runat="server" meta:resourcekey="Literal88Resource1"></asp:literal></h5>
                <div class="row-fluid">
                    
                <asp:checkbox ID="timer5_martedi" style="margin: 5px 10px 10px 0px;" runat="server" meta:resourcekey="timer5_martediResource1" ></asp:checkbox>
                   </div>
                </div>
                 </div>

                      <div class="span1">
                <div id="riga_timer5_1_3" class="control-group">
                <h5 style="padding-top:10px" class="control-label"><asp:literal ID = "Literal89"  text="Wed" runat="server" meta:resourcekey="Literal89Resource1"></asp:literal></h5>
                <div class="row-fluid">
                    
                <asp:checkbox ID="timer5_mercoledi" style="margin: 5px 10px 10px 0px;" runat="server" meta:resourcekey="timer5_mercolediResource1" ></asp:checkbox>
                   </div>
                </div>
                 </div>

                      <div class="span1">
                <div id="riga_timer5_1_4" class="control-group">
                <h5 style="padding-top:10px" class="control-label"><asp:literal ID = "Literal90"  text="Thu" runat="server" meta:resourcekey="Literal90Resource1"></asp:literal></h5>
                <div class="row-fluid">
                    
                <asp:checkbox ID="timer5_giovedi" style="margin: 5px 10px 10px 0px;" runat="server" meta:resourcekey="timer5_giovediResource1" ></asp:checkbox>
                   </div>
                </div>
                 </div>

                    <div class="span1">
                <div id="riga_timer5_1_5" class="control-group">
                <h5 style="padding-top:10px" class="control-label"><asp:literal ID = "Literal91"  text="Fri" runat="server" meta:resourcekey="Literal91Resource1"></asp:literal></h5>
                <div class="row-fluid">
                    
                <asp:checkbox ID="timer5_venerdi" style="margin: 5px 10px 10px 0px;" runat="server" meta:resourcekey="timer5_venerdiResource1" ></asp:checkbox>
                   </div>
                </div>
                 </div>

                     <div class="span1">
                <div id="riga_timer5_1_6" class="control-group">
                <h5 style="padding-top:10px" class="control-label"><asp:literal ID = "Literal92"  text="Sat" runat="server" meta:resourcekey="Literal92Resource1"></asp:literal></h5>
                <div class="row-fluid">
                    
                <asp:checkbox ID="timer5_sabato" style="margin: 5px 10px 10px 0px;" runat="server" meta:resourcekey="timer5_sabatoResource1" ></asp:checkbox>
                   </div>
                </div>
                 </div>

                     <div class="span1">
                <div id="riga_timer5_1_7" class="control-group">
                <h5 style="padding-top:10px" class="control-label"><asp:literal ID = "Literal93"  text="Sun" runat="server" meta:resourcekey="Literal93Resource1"></asp:literal></h5>
                <div class="row-fluid">
                    
                <asp:checkbox ID="timer5_domenica" style="margin: 5px 10px 10px 0px;" runat="server" meta:resourcekey="timer5_domenicaResource1" ></asp:checkbox>
                   </div>
                </div>
                 </div>

                </div>
                 <!-- fine riga -->
                         <!-- riga -->
                <div  class="row-fluid">
<div class="span3">
                <div id="riga_timer5_2_1" class="control-group">
                <h5 style="padding-top:10px" class="control-label"><asp:literal ID = "Literal94"  text="Time1" runat="server" meta:resourcekey="Literal94Resource1"></asp:literal></h5>
                <div class="row-fluid">
                    
                <asp:checkbox ID="time5_1" style="margin: 5px 10px 10px 0px;" runat="server" meta:resourcekey="time5_1Resource1" ></asp:checkbox>
                   </div>
                </div>
                 </div>

<div class="span3">
                <div id="riga_timer5_2_2" class="control-group">
                <h5 style="padding-top:10px" class="control-label"><asp:literal ID = "Literal95"  text="Start(HH:MM)" runat="server" meta:resourcekey="Literal95Resource1"></asp:literal></h5>
                <div class="row-fluid">
                    
                <asp:textbox ID="timer5_start_1" onblur="javascript: Changed_channel_timer( 'timer5_start_1','riga_timer5_2_2', lunghezza_ora);" onchange ="javascript: Changed_channel_timer( 'timer5_start_1','riga_timer5_2_2', lunghezza_ora);" class="span12"  runat="server" meta:resourcekey="timer5_start_1Resource1"  ></asp:textbox>
                   </div>
                </div>
                 </div>
<div class="span3">
                <div id="riga_timer5_2_3" class="control-group">
                <h5 style="padding-top:10px" class="control-label"><asp:literal ID = "Literal96"  text="Stop(HH:MM)" runat="server" meta:resourcekey="Literal96Resource1"></asp:literal></h5>
                <div class="row-fluid">
                    
                <asp:textbox ID="timer5_stop_1" onblur="javascript: Changed_channel_timer( 'timer5_stop_1','riga_timer5_2_3', lunghezza_ora);" onchange ="javascript: Changed_channel_timer( 'timer5_stop_1','riga_timer5_2_3', lunghezza_ora);" class="span12"  runat="server" meta:resourcekey="timer5_stop_1Resource1"  ></asp:textbox>
                   </div>
                </div>
                 </div>

                </div>
    <!-- fine riga -->

<!-- riga -->
<div  class="row-fluid">
 <div class="span3">
                <div id="Div10" class="control-group">
                <h5 style="padding-top:10px" class="control-label"><asp:literal ID = "Literal97"  text="Time2" runat="server" meta:resourcekey="Literal97Resource1"></asp:literal></h5>
                <div class="row-fluid">
                    
                <asp:checkbox ID="time5_2" style="margin: 5px 10px 10px 0px;" runat="server" meta:resourcekey="time5_2Resource1" ></asp:checkbox>
                   </div>
                </div>
                 </div>
 <div class="span3">
                <div id="riga_timer5_3_2" class="control-group">
                <h5 style="padding-top:10px" class="control-label"><asp:literal ID = "Literal98"  text="Start(HH:MM)" runat="server" meta:resourcekey="Literal98Resource1"></asp:literal></h5>
                <div class="row-fluid">
                    
                <asp:textbox ID="timer5_start_2" onblur="javascript: Changed_channel_timer( 'timer5_start_2','riga_timer5_3_2', lunghezza_ora);" onchange ="javascript: Changed_channel_timer(  'timer5_start_2','riga_timer5_3_2', lunghezza_ora);"  class="span12"  runat="server" meta:resourcekey="timer5_start_2Resource1"  ></asp:textbox>
                   </div>
                </div>
                 </div>
<div class="span3">
                <div id="riga_timer5_3_3" class="control-group">
                <h5 style="padding-top:10px" class="control-label"><asp:literal ID = "Literal99"  text="Stop(HH:MM)" runat="server" meta:resourcekey="Literal99Resource1"></asp:literal></h5>
                <div class="row-fluid">
                    
                <asp:textbox ID="timer5_stop_2"  onblur="javascript: Changed_channel_timer( 'timer5_stop_2','riga_timer5_3_3', lunghezza_ora);" onchange ="javascript: Changed_channel_timer('timer5_stop_2','riga_timer5_3_3', lunghezza_ora);" class="span12"  runat="server" meta:resourcekey="timer5_stop_2Resource1"  ></asp:textbox>
                   </div>
                </div>
                 </div>
                </div>
    <!-- fine riga -->

<!-- riga -->
<div  class="row-fluid">
 <div class="span3">
                <div id="Div12" class="control-group">
                <h5 style="padding-top:10px" class="control-label"><asp:literal ID = "Literal100"  text="Time3" runat="server" meta:resourcekey="Literal100Resource1"></asp:literal></h5>
                <div class="row-fluid">
                    
                <asp:checkbox ID="time5_3" style="margin: 5px 10px 10px 0px;" runat="server" meta:resourcekey="time5_3Resource1" ></asp:checkbox>
                   </div>
                </div>
                 </div>
 <div class="span3">
                <div id="riga_timer5_4_2" class="control-group">
                <h5 style="padding-top:10px" class="control-label"><asp:literal ID = "Literal101"  text="Start(HH:MM)" runat="server" meta:resourcekey="Literal101Resource1"></asp:literal></h5>
                <div class="row-fluid">
                    
                <asp:textbox ID="timer5_start_3" onblur="javascript: Changed_channel_timer( 'timer5_start_3','riga_timer5_4_2', lunghezza_ora);" onchange ="javascript: Changed_channel_timer('timer5_start_3','riga_timer5_4_2', lunghezza_ora);" class="span12"  runat="server" meta:resourcekey="timer5_start_3Resource1"  ></asp:textbox>
                   </div>
                </div>
                 </div>
<div class="span3">
                <div id="riga_timer5_4_3" class="control-group">
                <h5 style="padding-top:10px" class="control-label"><asp:literal ID = "Literal102"  text="Stop(HH:MM)" runat="server" meta:resourcekey="Literal102Resource1"></asp:literal></h5>
                <div class="row-fluid">
                    
                <asp:textbox ID="timer5_stop_3" onblur="javascript: Changed_channel_timer( 'timer5_stop_3','riga_timer5_4_3', lunghezza_ora);" onchange ="javascript: Changed_channel_timer('timer5_stop_3','riga_timer5_4_3', lunghezza_ora);" class="span12"  runat="server" meta:resourcekey="timer5_stop_3Resource1"  ></asp:textbox>
                   </div>
                </div>
                 </div>
                </div>
    <!-- fine riga -->
				 
    <!-- riga -->
<div  class="row-fluid">
 <div class="span3">
                <div id="riga_timer5_5_1" class="control-group">
                <h5 style="padding-top:10px" class="control-label"><asp:literal ID = "Literal103"  text="Time4" runat="server" meta:resourcekey="Literal103Resource1"></asp:literal></h5>
                <div class="row-fluid">
                    
                <asp:checkbox ID="time5_4" style="margin: 5px 10px 10px 0px;" runat="server" meta:resourcekey="time5_4Resource1" ></asp:checkbox>
                   </div>
                </div>
                 </div>
 <div class="span3">
                <div id="riga_timer5_5_2" class="control-group">
                <h5 style="padding-top:10px" class="control-label"><asp:literal ID = "Literal104"  text="Start(HH:MM)" runat="server" meta:resourcekey="Literal104Resource1"></asp:literal></h5>
                <div class="row-fluid">
                    
                <asp:textbox ID="timer5_start_4" onblur="javascript: Changed_channel_timer( 'timer5_start_4','riga_timer5_5_2', lunghezza_ora);" onchange ="javascript: Changed_channel_timer( 'timer5_start_4','riga_timer5_5_2', lunghezza_ora);" class="span12"  runat="server" meta:resourcekey="timer5_start_4Resource1"  ></asp:textbox>
                   </div>
                </div>
                 </div>
<div class="span3">
                <div id="riga_timer5_5_3" class="control-group">
                <h5 style="padding-top:10px" class="control-label"><asp:literal ID = "Literal105"  text="Stop(HH:MM)" runat="server" meta:resourcekey="Literal105Resource1"></asp:literal></h5>
                <div class="row-fluid">
                    
                <asp:textbox ID="timer5_stop_4"  onblur="javascript: Changed_channel_timer( 'timer5_stop_4','riga_timer5_5_3', lunghezza_ora);" onchange ="javascript: Changed_channel_timer( 'timer5_stop_4','riga_timer5_5_3', lunghezza_ora);" class="span12"  runat="server" meta:resourcekey="timer5_stop_4Resource1"  ></asp:textbox>
                   </div>
                </div>
                 </div>
                </div>
    <!-- fine riga -->				 

    <!-- riga -->
<div  class="row-fluid">
 <div class="span3">
                <div id="riga_timer5_6_1" class="control-group">
                <h5 style="padding-top:10px" class="control-label"><asp:literal ID = "Literal106"  text="Time5" runat="server" meta:resourcekey="Literal106Resource1"></asp:literal></h5>
                <div class="row-fluid">
                    
                <asp:checkbox ID="time5_5" style="margin: 5px 10px 10px 0px;" runat="server" meta:resourcekey="time5_5Resource1" ></asp:checkbox>
                   </div>
                </div>
                 </div>
 <div class="span3">
                <div id="riga_timer5_6_2" class="control-group">
                <h5 style="padding-top:10px" class="control-label"><asp:literal ID = "Literal107"  text="Start(HH:MM)" runat="server" meta:resourcekey="Literal107Resource1"></asp:literal></h5>
                <div class="row-fluid">
                    
                <asp:textbox ID="timer5_start_5" onblur="javascript: Changed_channel_timer( 'timer5_start_5','riga_timer5_6_2', lunghezza_ora);" onchange ="javascript: Changed_channel_timer( 'timer5_start_5','riga_timer5_6_2', lunghezza_ora);" class="span12"  runat="server" meta:resourcekey="timer5_start_5Resource1"  ></asp:textbox>
                   </div>
                </div>
                 </div>
<div class="span3">
                <div id="riga_timer5_6_3" class="control-group">
                <h5 style="padding-top:10px" class="control-label"><asp:literal ID = "Literal108"  text="Stop(HH:MM)" runat="server" meta:resourcekey="Literal108Resource1"></asp:literal></h5>
                <div class="row-fluid">
                    
                <asp:textbox ID="timer5_stop_5" onblur="javascript: Changed_channel_timer( 'timer5_stop_5','riga_timer5_6_3', lunghezza_ora);" onchange ="javascript: Changed_channel_timer( 'timer5_stop_5','riga_timer5_6_3', lunghezza_ora);" class="span12"  runat="server" meta:resourcekey="timer5_stop_5Resource1"  ></asp:textbox>
                   </div>
                </div>
                 </div>
                </div>
    <!-- fine riga -->
				 

    <!-- riga -->
                <div  class="row-fluid">
                <div class="span3">
                <div id="riga_timer5_3_1" class="control-group">
                <h5 style="padding-top:10px" class="control-label"><asp:literal ID = "Literal109"  text="Relay or Pulse" runat="server" meta:resourcekey="Literal109Resource1"></asp:literal></h5>
                <div class="row-fluid">
                    
                    <asp:dropdownlist runat="server" ID="timer5_relay_pulse" meta:resourcekey="timer5_relay_pulseResource1">
                        <asp:ListItem Value="0" meta:resourcekey="ListItemResource53">X</asp:ListItem>
                        <asp:ListItem Value="1" meta:resourcekey="ListItemResource54">Relay 1</asp:ListItem>
                        <asp:ListItem Value="2" meta:resourcekey="ListItemResource55">Relay 2</asp:ListItem>
                        <asp:ListItem Value="3" meta:resourcekey="ListItemResource56">Relay 3</asp:ListItem>
                        <asp:ListItem Value="4" meta:resourcekey="ListItemResource57">Relay 4</asp:ListItem>
                        <asp:ListItem Value="5" meta:resourcekey="ListItemResource58">Relay 5</asp:ListItem>
                        <asp:ListItem Value="6" meta:resourcekey="ListItemResource59">Relay 6</asp:ListItem>
                        <asp:ListItem Value="7" meta:resourcekey="ListItemResource60">Pulse 1</asp:ListItem>
                        <asp:ListItem Value="8" meta:resourcekey="ListItemResource61">Pulse 2</asp:ListItem>
                        <asp:ListItem Value="9" meta:resourcekey="ListItemResource62">Pulse 3</asp:ListItem>
                        <asp:ListItem Value="10" meta:resourcekey="ListItemResource63">Pulse 4</asp:ListItem>
                        <asp:ListItem Value="11" meta:resourcekey="ListItemResource64">Pulse 5</asp:ListItem>
                        <asp:ListItem Value="12" meta:resourcekey="ListItemResource65">Pulse 6</asp:ListItem>
                    </asp:dropdownlist>
                   </div>
                </div>
                 </div>
            <div class="span3">
                <div id="riga_timer5_7_2" class="control-group">
                <h5 style="padding-top:10px" class="control-label"><asp:literal ID = "Literal110"  text="Pulse/minute" runat="server" meta:resourcekey="Literal110Resource1"></asp:literal></h5>
                <div class="row-fluid">
                    
                <asp:textbox ID="value_timer5_pulse_minute_id" class="span12"  runat="server"  onblur="javascript: Changed_channel_timer_value( 'value_timer5_pulse_minute_id','riga_timer5_3_2',180, 0,0 );" MaxLength="3" meta:resourcekey="value_timer5_pulse_minute_idResource1"></asp:textbox>
                   </div>
                </div>
                 </div>
				 </div>
    <!-- fine riga -->
<!-- riga -->
                <div  class="row-fluid">
 <div class="span2">
                <div id="riga_timer5_4_1" class="control-group">
                <h5 style="padding-top:10px" class="control-label"><asp:literal ID = "Literal111"  text="Name Timer" runat="server" meta:resourcekey="Literal111Resource1"></asp:literal></h5>
                <div class="row-fluid">
                    
                <asp:textbox ID="value_timer5_name_id" class="span12"  runat="server"   MaxLength="10" meta:resourcekey="value_timer5_name_idResource1"></asp:textbox>
                   </div>
                </div>
                 </div>
			 </div>
    <!-- fine riga -->    
</div>
                    </div>
                </div>
<!-- tab 5 end-->
          </div>
           <div id="salva" class="btn-primary">
                   <b class="btn-primary btn-icon glyphicons ok"><asp:button runat="server" ID="save_timer_new" class="btn-primary" data-layout="center" data-type="confirm" data-toggle="notyfy"  text="Salva e carica i dati" Font-Bold="True" meta:resourcekey="save_timer_newResource1" /><i></i></b>
                </div>
      </div>

        </div>
    	<!-- DateTimePicker Plugin -->
    <script type="text/javascript" src="max5/validator_max5_timer.js"></script>
    <script src="theme/scripts/demo/calendar_new.js"></script>
    <link href="bootstrap/css/jquery-ui-timepicker-addon.css" rel="stylesheet" />
     <script type="text/javascript" src="common/validator_general_notify.js"></script>
    <script src="theme/scripts/demo/notifications.js"></script>
	 <script type="text/javascript">
	    
    </script> 
    
    </form>
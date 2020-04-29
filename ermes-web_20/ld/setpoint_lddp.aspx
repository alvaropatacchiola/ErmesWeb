<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="setpoint_lddp.aspx.vb" Inherits="ermes_web_20.setpoint_lddp" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>

<form id="form" runat="server"  method="post" action="ld/setpoint_lddp.aspx">
    <h3><asp:literal runat="server" text ="SetPoint LD" ID="message_channel" meta:resourcekey="message_channelResource1"></asp:literal></h3>
    <div class="innerLR">
        <div class="box-generic">
                        	<!-- Tabs Heading -->
<div class="tabsbar tabsbar-2">
			<ul class="row-fluid row-merge">
            
                <li class="span1 active" ><a id="tab_ld_sp1" href="#tab_ld_sp1_1"  data-toggle="tab"><asp:literal text="pH Pulse1"  runat="server" ID="tabld1_1" meta:resourcekey="tabld1_1Resource1" ></asp:literal></a></li>
                <li class="span1"><a id="tab_ld_sp2" href="#tab_ld_sp2_2" data-toggle="tab"><asp:literal text="pH Pulse2" runat="server" ID="tabld1_2" meta:resourcekey="tabld1_2Resource1"></asp:literal></a></li>
                <li class="span1"><a id="tab_ld_sp3" href="#tab_ld_sp3_3" data-toggle="tab"><asp:literal text="pH Relay" runat="server" ID="tabld1_3" meta:resourcekey="tabld1_3Resource1"></asp:literal></a></li>
                <li class="span1"><a id="tab_ld_sp4" href="#tab_ld_sp4_4" data-toggle="tab"><asp:literal text="Cl pulse" runat="server" ID="tabld1_4" meta:resourcekey="tabld1_4Resource1"></asp:literal></a></li>
                <li class="span1"><a id="tab_ld_sp5" href="#tab_ld_sp5_5" data-toggle="tab"><asp:literal text="Cl Relay" runat="server" ID="tabld1_5" meta:resourcekey="tabld1_5Resource1"></asp:literal></a></li>
			    <li class="span1"><a id="tab_ld_sp6" href="#tab_ld_sp5_6" data-toggle="tab"><asp:literal text="PID"      runat="server" ID="tabld1_6" meta:resourcekey="tabld1_6Resource1"></asp:literal></a></li>
			    <li class="span1"><a id="tab_ld_sp7" href="#tab_ld_sp5_7" data-toggle="tab"><asp:literal text="Feed Forward" runat="server" ID="tabld1_7" meta:resourcekey="tabld1_7Resource1"></asp:literal></a></li>
			    <li class="span1"><a id="tab_ld_sp8" href="#tab_ld_sp5_8" data-toggle="tab"><asp:literal text="Water Meter" runat="server" ID="tabld1_8" meta:resourcekey="tabld1_8Resource1"></asp:literal></a></li>
			    <li class="span1"><a id="tab_ld_sp9" href="#tab_ld_sp5_9" data-toggle="tab"><asp:literal text="Set Strokes" runat="server" ID="tabld1_9" meta:resourcekey="tabld1_9Resource1"></asp:literal></a></li>
			
            
            </ul>
		</div>
		<!-- // Tabs Heading END -->
<div class="tab-content">
    <!-- tab 1 start-->
			<div class="tab-pane active" id="tab_ld_sp1_1">
                <div  class="box-generic">
                                 <!-- riga -->
                <div class="row-fluid">
               	<div class="span12">
              <h5 style="padding-top:10px"><asp:literal ID = "Label7"  text="pH Pulse 1" runat="server" meta:resourcekey="Label7Resource1"></asp:literal></h5>
                       <div class="controlli_box"> 
                            <asp:radiobutton ID="on_off_ph_pulse1" runat="server"  GroupName="GROUP1" meta:resourcekey="on_off_ph_pulse1Resource1"></asp:radiobutton>
                       </div>
                       <div class="controlli_testo_box" > 
                                <asp:literal runat="server" text ="On / Off" meta:resourcekey="LiteralResource1"></asp:literal>
                      </div>
                       <div class="controlli_box"> 
                            <asp:radiobutton ID="proportional_ph_pulse1"  runat="server"  GroupName="GROUP1" meta:resourcekey="proportional_ph_pulse1Resource1"></asp:radiobutton>
                       </div>
                        <div class="controlli_testo_box" > 
                            <asp:literal runat="server" text ="Proportional" meta:resourcekey="LiteralResource2"></asp:literal>
                        </div>
                           <div class="controlli_box"> 
                                <asp:radiobutton ID="off_ph_pulse1"  runat="server"  GroupName="GROUP1" meta:resourcekey="off_ph_pulse1Resource2"></asp:radiobutton>
                            </div>
                        <div class="controlli_testo_box" > 
                                <asp:literal runat="server" text ="Off" meta:resourcekey="LiteralResource3"></asp:literal>
                        </div>
                        <div class="controlli_box">
                                            <asp:radiobutton ID="Prop_WM_ph_pulse1"  runat="server"  GroupName="GROUP1" meta:resourcekey="Prop_WM_ph_pulse1Resource2"></asp:radiobutton>
                        </div>
                        <div class="controlli_testo_box">
                                               <asp:literal runat="server" text ="Prop+WM" meta:resourcekey="LiteralResource4"></asp:literal>
                        </div>
                        <div class="controlli_box">
                                            <asp:radiobutton ID="PID_ph_pulse1"  runat="server"  GroupName="GROUP1" meta:resourcekey="PID_ph_pulse1Resource2"></asp:radiobutton>
                        </div>
                        <div class="controlli_testo_box">
                                               <asp:literal runat="server" text ="PID" meta:resourcekey="LiteralResource5"></asp:literal>
                        </div>

                       <div class="controlli_box">
                                            <asp:radiobutton ID="LINEA_ph_pulse1"  runat="server"  GroupName="GROUP1" meta:resourcekey="LINEA_ph_pulse1Resource2"></asp:radiobutton>
                        </div>
                        <div class="controlli_testo_box">
                                               <asp:literal runat="server" text ="Line" meta:resourcekey="LiteralResource5A"></asp:literal>
                        </div>

                </div>
                </div>
                 <!-- fine riga -->
                                <!-- riga -->
<div id ="disable_ph_pulse1">
                <div class="row-fluid">
               	<div class="span2">
                       <div id="riga1_ph_pulse1_1" class="control-group">
                           <div id="label1_ph_pulse1_proportional">
                                <h5 style="padding-top:10px"><asp:literal ID = "Literal1"  text="pH" runat="server" meta:resourcekey="Literal1Resource1"></asp:literal></h5>
                           </div>
                           <div id="label1_ph_pulse1_on_off">
                                <h5 style="padding-top:10px"><asp:literal ID = "Literal6"  text="pH ON" runat="server" meta:resourcekey="Literal6Resource1"></asp:literal></h5>
                           </div>
                       <asp:textbox ID="value1_ph_pulse1_1" onblur="javascript: Changed_channel( 'value1_ph_pulse1_1','riga1_ph_pulse1_1',max_ch1_value, min_ch1_value,max_fix_value1 );" class="span12"  runat="server" meta:resourcekey="value1_ph_pulse1_1Resource1" ></asp:textbox>
                </div>
                       </div>

                    <div class="span2">
                       <div id="riga2_ph_pulse1_1" class="control-group">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal3"  text="Pulse / Minute" runat="server" meta:resourcekey="Literal3Resource1"></asp:literal></h5>
                       <asp:textbox ID="value2_ph_pulse1_1" onblur="javascript: Changed_channel( 'value2_ph_pulse1_1','riga2_ph_pulse1_1',180, 0,0 );" class="span12"  runat="server" MaxLength="3" meta:resourcekey="value2_ph_pulse1_1Resource1" ></asp:textbox>
                </div>
                       </div>
                </div>
                 <!-- fine riga -->

  
<!-- riga -->
                <div class="row-fluid">
               	<div class="span2">
                       <div id="riga1_ph_pulse1_2" class="control-group">
                           <div id="label2_ph_pulse1_proportional">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal2"  text="pH" runat="server" meta:resourcekey="Literal2Resource1"></asp:literal></h5>
                               </div>
                           <div id="label2_ph_pulse1_on_off">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal7"  text="pH OFF" runat="server" meta:resourcekey="Literal7Resource1"></asp:literal></h5>
                               </div>

                       <asp:textbox ID="value1_ph_pulse1_2" onblur="javascript: Changed_channel( 'value1_ph_pulse1_2','riga1_ph_pulse1_2',max_ch1_value, min_ch1_value,max_fix_value1 );" class="span12"  runat="server" meta:resourcekey="value1_ph_pulse1_2Resource1" ></asp:textbox>
                </div>
                       </div>

                    <div class="span2">
                       <div id="riga2_ph_pulse1_2" class="control-group">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal4"  text="Pulse / Minute" runat="server" meta:resourcekey="Literal4Resource1"></asp:literal></h5>
                       <asp:textbox ID="value2_ph_pulse1_2"  onblur="javascript: Changed_channel( 'value2_ph_pulse1_2','riga2_ph_pulse1_2',180, 0,0 );" class="span12"  runat="server" MaxLength="3" meta:resourcekey="value2_ph_pulse1_2Resource1" ></asp:textbox>
                </div>
                       </div>
                </div>
                 <!-- fine riga -->                                
<!-- riga -->
                <div class="row-fluid">
               	<div class="span2">
                       <div id="riga1_ph_pulse1_3" class="control-group">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal5"  text="Pulse Speed (min)" runat="server" meta:resourcekey="Literal5Resource1"></asp:literal></h5>
                       <asp:textbox ID="value2_ph_pulse1_3" onblur="javascript: Changed_channel( 'value2_ph_pulse1_3','riga1_ph_pulse1_3',99, 0,0 );"  class="span12"  runat="server" MaxLength="2" meta:resourcekey="value2_ph_pulse1_3Resource1" ></asp:textbox>
                </div>
                       </div>
                </div>
                 <!-- fine riga -->  


      <!-- riga -->
                <div class="row-fluid">
               	<div class="span2">
                       <div id="riga1_ph_pulse_perc4" class="control-group">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal99"  text="% at 0 mc/h" runat="server" meta:resourcekey="Literal99Resource1"></asp:literal></h5>
                       <asp:textbox ID="value2_ph_pulse_perc4" onblur="javascript: Changed_channel( 'value2_ph_pulse_perc4','riga1_ph_pulse_perc4',99, 0,0 );"  class="span12"  runat="server" MaxLength="2" meta:resourcekey="value2_ph_pulse_perc4Resource1" ></asp:textbox>
                </div>
                       </div>
                </div>
                 <!-- fine riga -->  

     
    <!-- riga -->
                <div class="row-fluid">
               	<div class="span2">
                       <div id="riga1_ph_pulse_perc3" class="control-group">
                           
                           
              <h5 style="padding-top:10px"><asp:literal ID = "Literal97"  text="% " runat="server" meta:resourcekey="Literal97Resource1"></asp:literal></h5>
                               

                       <asp:textbox ID="value2_ph_pulse_perc3" onblur="javascript: Changed_channel( 'value2_ph_pulse_perc3','riga1_ph_pulse_perc3',100, 1,0 );" class="span12"  runat="server" meta:resourcekey="value2_ph_pulse_perc3Resource1" ></asp:textbox>
                </div>
                       </div>
    </div>
    <!-- fine riga --> 

     <!-- riga -->
                <div class="row-fluid">
                    <div class="span2">
                       <div id="riga2_ph_pulse_mch" class="control-group">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal96"  text="mc/h" runat="server" meta:resourcekey="Literal96Resource1"></asp:literal></h5>
                       <asp:textbox ID="value2_ph_pulse_mch"  onblur="javascript: Changed_channel( 'value2_ph_pulse_mch','riga2_ph_pulse_mch',599, 1,2 );" class="span12"  runat="server" MaxLength="5" meta:resourcekey="value2_ph_pulse_mchResource1" ></asp:textbox>
                </div>
                       </div>
                </div>
                 <!-- fine riga -->


                       <!-- riga -->
                <div class="row-fluid">
               	<div class="span2">
                      


                            <div id="riga2_ph_pulse_range" class="control-group">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal20"  text="Range" runat="server" meta:resourcekey="Literal95Resource1"></asp:literal></h5>
                           </div>
                           <div id="riga2_ph_pulse_ccstk">
                                <h5 style="padding-top:10px"><asp:literal ID = "Literal36"  text="cc/stk" runat="server" meta:resourcekey="Literal36Resource1"></asp:literal></h5>
                           </div>


                       <asp:textbox ID="value2_ph_pulse_range" onblur="javascript: Changed_channel( 'value2_ph_pulse_range','riga2_ph_pulse_range',999, 0,1 );"  class="span12"  runat="server" MaxLength="4" meta:resourcekey="value2_ph_pulse_rangeResource1" ></asp:textbox>
                </div>
                       </div>
                <%--</div>--%>
                 <!-- fine riga -->  

    <!-- riga -->
                <div class="row-fluid">
               	<div class="span2">
                       <div id="riga2_ph_pulse_setpoint" class="control-group">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal94"  text="Setpoint" runat="server" meta:resourcekey="Literal94BResource1"></asp:literal></h5>
                       <asp:textbox ID="value2_ph_pulse_setpoint" onblur="Changed_channel( 'value2_ph_pulse_setpoint','riga2_ph_pulse_setpoint',max_ch1_value, min_ch1_value,max_fix_value1 );"  class="span12"  runat="server" MaxLength="4" meta:resourcekey="value2_ph_pulse_setpointResource1" ></asp:textbox>
                </div>
                       </div>
                </div>
                 <!-- fine riga --> 
     <!-- riga -->
                <div class="row-fluid">
               	<div class="span2">
                       <div id="riga_ph_pulse_conc" class="control-group">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal19"  text="Conc[%]" runat="server" meta:resourcekey="Literal94Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_ph_pulse_conc" onblur="Changed_channel( 'value_ph_pulse_conc','riga_ph_pulse_conc',999, 0,1 );"  class="span12"  runat="server" MaxLength="4" meta:resourcekey="value_ph_pulse_concResource1" ></asp:textbox>
                </div>
                       </div>
                </div>
                 <!-- fine riga --> 

    </div>
                    </div>
                </div>
<!-- tab 1 stop-->
    <!-- tab 2 start-->
			<div class="tab-pane" id="tab_ld_sp2_2">
                <div  class="box-generic">
                                 <!-- riga -->
                <div class="row-fluid">
               	<div class="span12">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal8"  text="pH Pulse 2" runat="server" meta:resourcekey="Literal8Resource1"></asp:literal></h5>
                       <div class="controlli_box"> 
                    <asp:radiobutton ID="on_off_ph_pulse2" runat="server"  GroupName="GROUP2" meta:resourcekey="on_off_ph_pulse2Resource1"></asp:radiobutton>
                           </div>
                       <div class="controlli_testo_box" > 
                    <asp:literal runat="server" text ="On / Off" meta:resourcekey="LiteralResource4A"></asp:literal>
                           </div>
                           <div class="controlli_box"> 
                    <asp:radiobutton ID="proportional_ph_pulse2"  runat="server"  GroupName="GROUP2" meta:resourcekey="proportional_ph_pulse2Resource1"></asp:radiobutton>
                               </div>
                           <div class="controlli_testo_box" > 
                       <asp:literal runat="server" text ="Proportional" meta:resourcekey="LiteralResource2"></asp:literal>
                               </div>
                               <div class="controlli_box"> 
                    <asp:radiobutton ID="off_ph_pulse2"  runat="server"  GroupName="GROUP2" meta:resourcekey="off_ph_pulse2Resource2"></asp:radiobutton>
                                   </div>
                               <div class="controlli_testo_box" > 
                       <asp:literal runat="server" text ="Off" meta:resourcekey="LiteralResource6"></asp:literal>
                                   </div>

                       <div class="controlli_box">
                                            <asp:radiobutton ID="Prop_WM_ph_pulse2"  runat="server"  GroupName="GROUP2" meta:resourcekey="Prop_WM_ph_pulse2Resource2"></asp:radiobutton>
                        </div>
                        <div class="controlli_testo_box">
                                               <asp:literal runat="server" text ="Prop+WM" meta:resourcekey="LiteralResource4"></asp:literal>
                        </div>
                        <div class="controlli_box">
                                            <asp:radiobutton ID="PID_ph_pulse2"  runat="server"  GroupName="GROUP2" meta:resourcekey="PID_ph_pulse2Resource2"></asp:radiobutton>
                        </div>
                        <div class="controlli_testo_box">
                                               <asp:literal runat="server" text ="PID" meta:resourcekey="LiteralResource5"></asp:literal>
                        </div>

                       <div class="controlli_box">
                                            <asp:radiobutton ID="LINEA_ph_pulse2"  runat="server"  GroupName="GROUP2" meta:resourcekey="LINEA_ph_pulse2Resource2"></asp:radiobutton>
                        </div>
                        <div class="controlli_testo_box">
                                               <asp:literal runat="server" text ="Line" meta:resourcekey="LiteralResource5A"></asp:literal>
                        </div>

                </div>
                </div>
                 <!-- fine riga -->
                                <!-- riga -->
<div id ="disable_ph_pulse2">
                <div class="row-fluid">
               	<div class="span2">
                       <div id="riga1_ph_pulse2_1" class="control-group">
                           <div id="label1_ph_pulse2_proportional">
                                <h5 style="padding-top:10px"><asp:literal ID = "Literal12"  text="pH" runat="server" meta:resourcekey="Literal12Resource1"></asp:literal></h5>
                           </div>
                           <div id="label1_ph_pulse2_on_off">
                                <h5 style="padding-top:10px"><asp:literal ID = "Literal13"  text="pH ON" runat="server" meta:resourcekey="Literal13Resource1"></asp:literal></h5>
                           </div>
                       <asp:textbox ID="value1_ph_pulse2_1" onblur="javascript: Changed_channel( 'value1_ph_pulse2_1','riga1_ph_pulse2_1',max_ch1_value, min_ch1_value,max_fix_value1 );"  class="span12"  runat="server" meta:resourcekey="value1_ph_pulse2_1Resource1" ></asp:textbox>
                </div>
                       </div>

                    <div class="span2">
                       <div id="riga2_ph_pulse2_1" class="control-group">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal14"  text="Pulse / Minute" runat="server" meta:resourcekey="Literal14Resource1"></asp:literal></h5>
                       <asp:textbox ID="value2_ph_pulse2_1" onblur="javascript: Changed_channel( 'value2_ph_pulse2_1','riga2_ph_pulse2_1',180, 0,0 );"  class="span12"  runat="server" MaxLength="3" meta:resourcekey="value2_ph_pulse2_1Resource1" ></asp:textbox>
                </div>
                       </div>
                </div>
                 <!-- fine riga -->
<!-- riga -->
                <div class="row-fluid">
               	<div class="span2">
                       <div id="riga1_ph_pulse2_2" class="control-group">
                           <div id="label2_ph_pulse2_proportional">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal15"  text="pH" runat="server" meta:resourcekey="Literal15Resource1"></asp:literal></h5>
                               </div>
                           <div id="label2_ph_pulse2_on_off">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal16"  text="pH OFF" runat="server" meta:resourcekey="Literal16Resource1"></asp:literal></h5>
                               </div>

                       <asp:textbox ID="value1_ph_pulse2_2" onblur="javascript: Changed_channel( 'value1_ph_pulse2_2','riga1_ph_pulse2_2',max_ch1_value, min_ch1_value,max_fix_value1 );"  class="span12"  runat="server" meta:resourcekey="value1_ph_pulse2_2Resource1" ></asp:textbox>
                </div>
                       </div>

                    <div class="span2">
                       <div id="riga2_ph_pulse2_2" class="control-group">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal17"  text="Pulse / Minute" runat="server" meta:resourcekey="Literal17Resource1"></asp:literal></h5>
                       <asp:textbox ID="value2_ph_pulse2_2" onblur="javascript: Changed_channel( 'value2_ph_pulse2_2','riga2_ph_pulse2_2',180, 0,0 );"  class="span12"  runat="server" MaxLength="3" meta:resourcekey="value2_ph_pulse2_2Resource1" ></asp:textbox>
                </div>
                       </div>
                </div>
                 <!-- fine riga -->                                
<!-- riga -->
                <div class="row-fluid">
               	<div class="span2">
                       <div id="riga1_ph_pulse2_3" class="control-group">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal18"  text="Pulse Speed (min)" runat="server" meta:resourcekey="Literal18Resource1"></asp:literal></h5>
                       <asp:textbox ID="value2_ph_pulse2_3" onblur="javascript: Changed_channel( 'value2_ph_pulse2_3','riga1_ph_pulse2_3',99, 0,0 );"  class="span12"  runat="server" MaxLength="2" meta:resourcekey="value2_ph_pulse2_3Resource1" ></asp:textbox>
                </div>
                       </div>
                </div>
                 <!-- fine riga -->  

    <!-- riga -->
                <div class="row-fluid">
               	<div class="span2">
                       <div id="riga1_ph_pulse2_perc4" class="control-group">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal37"  text="% at 0 mc/h" runat="server" meta:resourcekey="Literal99Resource1"></asp:literal></h5>
                       <asp:textbox ID="value2_ph_pulse2_perc4" onblur="javascript: Changed_channel( 'value2_ph_pulse2_perc4','riga1_ph_pulse2_perc4',99, 0,0 );"  class="span12"  runat="server" MaxLength="2" meta:resourcekey="value2_ph_pulse2_perc4Resource1" ></asp:textbox>
                </div>
                       </div>
                </div>
                 <!-- fine riga -->  

     
    <!-- riga -->
                <div class="row-fluid">
               	<div class="span2">
                       <div id="riga1_ph_pulse2_perc3" class="control-group">
                           
                           
              <h5 style="padding-top:10px"><asp:literal ID = "Literal46"  text="% " runat="server" meta:resourcekey="Literal97Resource1"></asp:literal></h5>
                               

                       <asp:textbox ID="value2_ph_pulse2_perc3" onblur="javascript: Changed_channel( 'value2_ph_pulse2_perc3','riga1_ph_pulse2_perc3',100, 1,0 );" class="span12"  runat="server" meta:resourcekey="value2_ph_pulse_perc3Resource1" ></asp:textbox>
                </div>
                       </div>
    </div>
    <!-- fine riga --> 

     <!-- riga -->
                <div class="row-fluid">
                    <div class="span2">
                       <div id="riga2_ph_pulse2_mch" class="control-group">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal47"  text="mc/h" runat="server" meta:resourcekey="Literal96Resource1"></asp:literal></h5>
                       <asp:textbox ID="value2_ph_pulse2_mch"  onblur="javascript: Changed_channel( 'value2_ph_pulse2_mch','riga2_ph_pulse2_mch',599, 1,2 );" class="span12"  runat="server" MaxLength="5" meta:resourcekey="value2_ph_pulse_mchResource1" ></asp:textbox>
                </div>
                       </div>
                </div>
                 <!-- fine riga -->


                       <!-- riga -->
                <div class="row-fluid">
               	<div class="span2">
                      


                            <div id="riga2_ph_pulse2_range" class="control-group">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal48"  text="Range" runat="server" meta:resourcekey="Literal95Resource1"></asp:literal></h5>
                           </div>
                           <div id="riga2_ph_pulse2_ccstk">
                                <h5 style="padding-top:10px"><asp:literal ID = "Literal49"  text="cc/stk" runat="server" meta:resourcekey="Literal36Resource1"></asp:literal></h5>
                           </div>


                       <asp:textbox ID="value2_ph_pulse2_range" onblur="javascript: Changed_channel( 'value2_ph_pulse2_range','riga2_ph_pulse2_range',999, 0,1 );"  class="span12"  runat="server" MaxLength="4" meta:resourcekey="value2_ph_pulse_rangeResource1" ></asp:textbox>
                </div>
                       </div>
                <%--</div>--%>
                 <!-- fine riga -->  

    <!-- riga -->
                <div class="row-fluid">
               	<div class="span2">
                       <div id="riga2_ph_pulse2_setpoint" class="control-group">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal50"  text="Setpoint" runat="server" meta:resourcekey="Literal94BResource1"></asp:literal></h5>
                       <asp:textbox ID="value2_ph_pulse2_setpoint" onblur="Changed_channel( 'value2_ph_pulse2_setpoint','riga2_ph_pulse2_setpoint',max_ch1_value, min_ch1_value,max_fix_value1 );"  class="span12"  runat="server" MaxLength="4" meta:resourcekey="value2_ph_pulse_setpointResource1" ></asp:textbox>
                </div>
                       </div>
                </div>
                 <!-- fine riga --> 
     <!-- riga -->
                <div class="row-fluid">
               	<div class="span2">
                       <div id="riga_ph_pulse2_conc" class="control-group">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal51"  text="Conc[%]" runat="server" meta:resourcekey="Literal94Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_ph_pulse2_conc" onblur="Changed_channel( 'value_ph_pulse2_conc','riga_ph_pulse2_conc',999, 0,1 );"  class="span12"  runat="server" MaxLength="4" meta:resourcekey="value_ph_pulse_concResource1" ></asp:textbox>
                </div>
                       </div>
                </div>
                 <!-- fine riga --> 

    </div>
                    </div>
                </div>
<!-- tab 2 stop-->
        <!-- tab 3 start-->
			<div class="tab-pane" id="tab_ld_sp3_3">
                <div  class="box-generic">
                                 <!-- riga -->
                <div class="row-fluid">
               	<div class="span12">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal9"  text="pH Relay" runat="server" meta:resourcekey="Literal9Resource1"></asp:literal></h5>
                       <div class="controlli_box"> 
                    <asp:radiobutton ID="on_off_ph_relay"  runat="server"  GroupName="GROUP5" meta:resourcekey="on_off_ph_relayResource1"></asp:radiobutton>
                       </div>
                       <div class="controlli_testo_box"> 
                    <asp:literal runat="server" text ="On / Off" meta:resourcekey="LiteralResource7"></asp:literal>
                           </div>
                           <div class="controlli_box"> 
                    <asp:radiobutton ID="proportional_ph_relay"  runat="server"  GroupName="GROUP5" meta:resourcekey="proportional_ph_relayResource1"></asp:radiobutton>
                               </div>
                           <div class="controlli_testo_box"> 
                       <asp:literal runat="server" text ="Proportional PWM" meta:resourcekey="LiteralResource8"></asp:literal>
                               </div>
                               <div class="controlli_box"> 
                    <asp:radiobutton ID="fixed_ph_relay"  runat="server"  GroupName="GROUP5" meta:resourcekey="fixed_ph_relayResource1"></asp:radiobutton>
                                   </div>
                               <div class="controlli_testo_box"> 
                       <asp:literal runat="server" text ="Fixed PWM" meta:resourcekey="LiteralResource9"></asp:literal>
                                   </div>
                                   <div class="controlli_box"> 
					   <asp:radiobutton ID="off_ph_relay"  runat="server"  GroupName="GROUP5" meta:resourcekey="off_ph_relayResource2"></asp:radiobutton>
                                       </div>
                                   <div class="controlli_testo_box"> 
					<asp:literal runat="server" text ="Off" meta:resourcekey="LiteralResource10"></asp:literal>
                                       </div>

                       <div class="controlli_box">
                    <asp:radiobutton ID="Prop_WM_ph_relay"  runat="server"  GroupName="GROUP5" meta:resourcekey="Prop_WM_ph_relayResource2"></asp:radiobutton>
</div>
<div class="controlli_testo_box">
                       <asp:literal runat="server" text ="Prop+WM" meta:resourcekey="LiteralResource4"></asp:literal>
</div>
<div class="controlli_box">
                    <asp:radiobutton ID="PID_ph_relay"  runat="server"  GroupName="GROUP5" meta:resourcekey="PID_ph_relayResource2"></asp:radiobutton>
</div>
<div class="controlli_testo_box">
                       <asp:literal runat="server" text ="PID" meta:resourcekey="LiteralResource5"></asp:literal>
</div>

                </div>
                </div>
                 <!-- fine riga -->
                                <!-- riga -->
<div id ="disable_ph_relay">
                <div class="row-fluid">
               	<div class="span2">
                       <div id="riga1_ph_relay_1" class="control-group">
                           <div id="label1_ph_relay_else">
                                <h5 style="padding-top:10px"><asp:literal ID = "Literal21"  text="pH" runat="server" meta:resourcekey="Literal21Resource1"></asp:literal></h5>
                           </div>
                           <div id="label1_ph_relay_on_off">
                                <h5 style="padding-top:10px"><asp:literal ID = "Literal22"  text="pH ON" runat="server" meta:resourcekey="Literal22Resource1"></asp:literal></h5>
                           </div>
                       <asp:textbox ID="value1_ph_relay_1" onblur="javascript: Changed_channel( 'value1_ph_relay_1','riga1_ph_relay_1',max_ch1_value, min_ch1_value,max_fix_value1 );"   class="span12"  runat="server" meta:resourcekey="value1_ph_relay_1Resource1" ></asp:textbox>
                </div>
                       </div>

                    <div class="span2">
                       <div id="riga2_ph_relay_1" class="control-group">
					   <div id="label1_ph_relay_proportionalpwm">
							<h5 style="padding-top:10px"><asp:literal ID = "Literal23"  text="%" runat="server" meta:resourcekey="Literal23Resource1"></asp:literal></h5>
						</div>
					   <div id="label1_ph_relay_fixedpwm">
							<h5 style="padding-top:10px"><asp:literal ID = "Literal24"  text="sec" runat="server" meta:resourcekey="Literal24Resource1"></asp:literal></h5>
						</div>

						<asp:textbox ID="value2_ph_relay_1" onblur="javascript: Changed_channel( 'value2_ph_relay_1','riga2_ph_relay_1',100, 0,0 );"  class="span12"  runat="server" MaxLength="3" meta:resourcekey="value2_ph_relay_1Resource1" ></asp:textbox>
                </div>
                       </div>
                </div>
                 <!-- fine riga -->
<!-- riga -->
                <div class="row-fluid">
               	<div class="span2">
                       <div id="riga1_ph_relay_2" class="control-group">
                           <div id="label2_ph_relay_else">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal25"  text="pH" runat="server" meta:resourcekey="Literal25Resource1"></asp:literal></h5>
                               </div>
                           <div id="label2_ph_relay_on_off">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal26"  text="pH OFF" runat="server" meta:resourcekey="Literal26Resource1"></asp:literal></h5>
                               </div>

                       <asp:textbox ID="value1_ph_relay_2" onblur="javascript: Changed_channel( 'value1_ph_relay_2','riga1_ph_relay_2',max_ch1_value, min_ch1_value,max_fix_value1 );" class="span12"  runat="server" meta:resourcekey="value1_ph_relay_2Resource1" ></asp:textbox>
                </div>
                       </div>

                    <div class="span2">
                       <div id="riga2_ph_relay_2" class="control-group">
					   <div id="label2_ph_relay_proportionalpwm">
								<h5 style="padding-top:10px"><asp:literal ID = "Literal27"  text="%" runat="server" meta:resourcekey="Literal27Resource1"></asp:literal></h5>
						</div>		
					   <div id="label2_ph_relay_fixedpwm">
								<h5 style="padding-top:10px"><asp:literal ID = "Literal28"  text="sec" runat="server" meta:resourcekey="Literal28Resource1"></asp:literal></h5>
						</div>		

						<asp:textbox ID="value2_ph_relay_2"  onblur="javascript: Changed_channel( 'value2_ph_relay_2','riga2_ph_relay_2',100, 0,0 );" class="span12"  runat="server" MaxLength="3" meta:resourcekey="value2_ph_relay_2Resource1" ></asp:textbox>
                </div>
                       </div>
                </div>
                 <!-- fine riga -->    
    
    
    <!-- riga -->
                <div class="row-fluid">
               	<div class="span2">
                       <div id="riga1_ph_relay_perc4" class="control-group">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal59"  text="% at 0 mc/h" runat="server" meta:resourcekey="Literal99Resource1"></asp:literal></h5>
                       <asp:textbox ID="value2_ph_relay_perc4" onblur="javascript: Changed_channel( 'value2_ph_relay_perc4','riga1_ph_relay_perc4',99, 0,0 );"  class="span12"  runat="server" MaxLength="2" meta:resourcekey="value2_ph_relay_perc4Resource1" ></asp:textbox>
                </div>
                       </div>
                </div>
                 <!-- fine riga -->  

     
    <!-- riga -->
                <div class="row-fluid">
               	<div class="span2">
                       <div id="riga1_ph_relay_perc3" class="control-group">
                           
                           
              <h5 style="padding-top:10px"><asp:literal ID = "Literal60"  text="% " runat="server" meta:resourcekey="Literal97Resource1"></asp:literal></h5>
                               

                       <asp:textbox ID="value2_ph_relay_perc3" onblur="javascript: Changed_channel( 'value2_ph_relay_perc3','riga1_ph_relay_perc3',100, 1,0 );" class="span12"  runat="server" meta:resourcekey="value2_ph_relay_perc3Resource1" ></asp:textbox>
                </div>
                       </div>
    </div>
    <!-- fine riga --> 

     <!-- riga -->
                <div class="row-fluid">
                    <div class="span2">
                       <div id="riga2_ph_relay_mch" class="control-group">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal61"  text="mc/h" runat="server" meta:resourcekey="Literal96Resource1"></asp:literal></h5>
                       <asp:textbox ID="value2_ph_realy_mch"  onblur="javascript: Changed_channel( 'value2_ph_realy_mch','riga2_ph_relay_mch',599, 1,2 );" class="span12"  runat="server" MaxLength="5" meta:resourcekey="value2_ph_realy_mchResource1" ></asp:textbox>
                </div>
                       </div>
                </div>
                 <!-- fine riga -->


                       <!-- riga -->
                <div class="row-fluid">
               	<div class="span2">
                      


                            <div id="riga2_ph_relay_range" class="control-group">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal62"  text="Range" runat="server" meta:resourcekey="Literal95Resource1"></asp:literal></h5>
                           </div>
                           <div id="riga2_ph_relay_ccstk">
                                <h5 style="padding-top:10px"><asp:literal ID = "Literal63"  text="cc/stk" runat="server" meta:resourcekey="Literal36Resource1"></asp:literal></h5>
                           </div>


                       <asp:textbox ID="value2_ph_relay_range" onblur="javascript: Changed_channel( 'value2_ph_relay_range','riga2_ph_pulse2_range',999, 0,1 );"  class="span12"  runat="server" MaxLength="4" meta:resourcekey="value2_ph_relay_rangeResource1" ></asp:textbox>
                </div>
                       </div>
                <%--</div>--%>
                 <!-- fine riga -->  

    <!-- riga -->
                <div class="row-fluid">
               	<div class="span2">
                       <div id="riga2_ph_relay2_setpoint" class="control-group">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal64"  text="Setpoint" runat="server" meta:resourcekey="Literal64Resource1"></asp:literal></h5>
                       <asp:textbox ID="value2_ph_relay2_setpoint" onblur="Changed_channel( 'value2_ph_relay2_setpoint','riga2_ph_relay2_setpoint',max_ch1_value, min_ch1_value,max_fix_value1 );"  class="span12"  runat="server" MaxLength="4" meta:resourcekey="value2_ph_relay2_setpointResource1" ></asp:textbox>
                </div>
                       </div>
                </div>
                 <!-- fine riga --> 
    
                                
    </div>
                    </div>
                </div>
<!-- tab 3 stop-->
<!-- tab 4 start-->
			<div class="tab-pane" id="tab_ld_sp4_4">
                <div  class="box-generic">
                                 <!-- riga -->
                <div class="row-fluid">
               	<div class="span12">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal10"  text="Cl Pulse 1" runat="server" meta:resourcekey="Literal10Resource1"></asp:literal></h5>
                       <div class="controlli_box"> 
                    <asp:radiobutton ID="on_off_cl_pulse1"  runat="server"  GroupName="GROUP6" meta:resourcekey="on_off_cl_pulse1Resource1"></asp:radiobutton>
                           </div>
                       <div class="controlli_testo_box"> 
                    <asp:literal runat="server" text ="On / Off" meta:resourcekey="LiteralResource11"></asp:literal>
                           </div>
                           <div class="controlli_box"> 
                    <asp:radiobutton ID="proportional_cl_pulse1"  runat="server"  GroupName="GROUP6" meta:resourcekey="proportional_cl_pulse1Resource1"></asp:radiobutton>
                               </div>
                           <div class="controlli_testo_box"> 
                       <asp:literal runat="server" text ="Proportional" meta:resourcekey="LiteralResource12"></asp:literal>
                               </div>
                               <div class="controlli_box"> 
                    <asp:radiobutton ID="off_cl_pulse1"  runat="server"  GroupName="GROUP6" meta:resourcekey="off_cl_pulse1Resource2"></asp:radiobutton>
                                   </div>
                               <div class="controlli_testo_box"> 
                       <asp:literal runat="server" text ="Off" meta:resourcekey="LiteralResource13"></asp:literal>
                                   </div>

                       <div class="controlli_box">
                                            <asp:radiobutton ID="Prop_WM_cl_pulse1"  runat="server"  GroupName="GROUP6" meta:resourcekey="Prop_WM_cl_pulse1Resource2"></asp:radiobutton>
                        </div>
                        <div class="controlli_testo_box">
                                               <asp:literal runat="server" text ="Prop+WM" meta:resourcekey="LiteralResource4"></asp:literal>
                        </div>
                        <div class="controlli_box">
                                            <asp:radiobutton ID="PID_cl_pulse1"  runat="server"  GroupName="GROUP6" meta:resourcekey="PID_cl_pulse1Resource2"></asp:radiobutton>
                        </div>
                        <div class="controlli_testo_box">
                                               <asp:literal runat="server" text ="PID" meta:resourcekey="LiteralResource5"></asp:literal>
                        </div>

                       <div class="controlli_box">
                                            <asp:radiobutton ID="LINEA_cl_pulse1"  runat="server"  GroupName="GROUP6" meta:resourcekey="LINEA_cl_pulse1Resource2"></asp:radiobutton>
                        </div>
                        <div class="controlli_testo_box">
                                               <asp:literal runat="server" text ="Line" meta:resourcekey="LiteralResource5A"></asp:literal>
                        </div>

                </div>
                </div>
                 <!-- fine riga -->
                                <!-- riga -->
<div id ="disable_cl_pulse1">
                <div class="row-fluid">
               	<div class="span2">
                       <div id="riga1_cl_pulse1_1" class="control-group">
                           <div id="label1_cl_pulse1_proportional">
                                <h5 style="padding-top:10px"><asp:literal ID = "Literal29"  text="Cl" runat="server" meta:resourcekey="Literal29Resource1"></asp:literal></h5>
                           </div>
                           <div id="label1_cl_pulse1_on_off">
                                <h5 style="padding-top:10px"><asp:literal ID = "Literal30"  text="Cl ON" runat="server" meta:resourcekey="Literal30Resource1"></asp:literal></h5>
                           </div>
                       <asp:textbox ID="value1_cl_pulse1_1"  onblur="javascript: Changed_channel( 'value1_cl_pulse1_1','riga1_cl_pulse1_1',max_ch2_value, min_ch2_value,max_fix_value2 );" class="span12"  runat="server" meta:resourcekey="value1_cl_pulse1_1Resource1" ></asp:textbox>
                </div>
                       </div>

                    <div class="span2">
                       <div id="riga2_cl_pulse1_1" class="control-group">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal31"  text="Pulse / Minute" runat="server" meta:resourcekey="Literal31Resource1"></asp:literal></h5>
                       <asp:textbox ID="value2_cl_pulse1_1" onblur="javascript: Changed_channel( 'value2_cl_pulse1_1','riga2_cl_pulse1_1',180, 0,0 );"  class="span12"  runat="server" MaxLength="3" meta:resourcekey="value2_cl_pulse1_1Resource1" ></asp:textbox>
                </div>
                       </div>
                </div>
                 <!-- fine riga -->
<!-- riga -->
                <div class="row-fluid">
               	<div class="span2">
                       <div id="riga1_cl_pulse1_2" class="control-group">
                           <div id="label2_cl_pulse1_proportional">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal32"  text="Cl" runat="server" meta:resourcekey="Literal32Resource1"></asp:literal></h5>
                               </div>
                           <div id="label2_cl_pulse1_on_off">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal33"  text="Cl OFF" runat="server" meta:resourcekey="Literal33Resource1"></asp:literal></h5>
                               </div>

                       <asp:textbox ID="value1_cl_pulse1_2" onblur="javascript: Changed_channel( 'value1_cl_pulse1_2','riga1_cl_pulse1_2',max_ch2_value, min_ch2_value,max_fix_value2 );"  class="span12"  runat="server" meta:resourcekey="value1_cl_pulse1_2Resource1" ></asp:textbox>
                </div>
                       </div>

                    <div class="span2">
                       <div id="riga2_cl_pulse1_2" class="control-group">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal34"  text="Pulse / Minute" runat="server" meta:resourcekey="Literal34Resource1"></asp:literal></h5>
                       <asp:textbox ID="value2_cl_pulse1_2" onblur="javascript: Changed_channel( 'value2_cl_pulse1_2','riga2_cl_pulse1_2',180, 0,0 );" class="span12"  runat="server" MaxLength="3" meta:resourcekey="value2_cl_pulse1_2Resource1" ></asp:textbox>
                </div>
                       </div>
                </div>
                 <!-- fine riga -->                                
<!-- riga -->
                <div class="row-fluid">
               	<div class="span2">
                       <div id="riga1_cl_pulse1_3" class="control-group">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal35"  text="Pulse Speed (min)" runat="server" meta:resourcekey="Literal35Resource1"></asp:literal></h5>
                       <asp:textbox ID="value2_cl_pulse1_3" onblur="javascript: Changed_channel( 'value2_cl_pulse1_3','riga1_cl_pulse1_3',99, 0,0 );"  class="span12"  runat="server" MaxLength="2" meta:resourcekey="value2_cl_pulse1_3Resource1" ></asp:textbox>
                </div>
                       </div>
                </div>
                 <!-- fine riga --> 
    
     <!-- riga -->
                <div class="row-fluid">
               	<div class="span2">
                       <div id="riga1_cl_pulse_perc4" class="control-group">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal52"  text="% at 0 mc/h" runat="server" meta:resourcekey="Literal99Resource1"></asp:literal></h5>
                       <asp:textbox ID="value2_cl_pulse_perc4" onblur="javascript: Changed_channel( 'value2_cl_pulse_perc4','riga1_cl_pulse_perc4',99, 0,0 );"  class="span12"  runat="server" MaxLength="2" meta:resourcekey="value2_cl_pulse_perc4Resource1" ></asp:textbox>
                </div>
                       </div>
                </div>
                 <!-- fine riga -->  

     
    <!-- riga -->
                <div class="row-fluid">
               	<div class="span2">
                       <div id="riga1_cl_pulse_perc3" class="control-group">
                           
                           
              <h5 style="padding-top:10px"><asp:literal ID = "Literal53"  text="% " runat="server" meta:resourcekey="Literal97Resource1"></asp:literal></h5>
                               

                       <asp:textbox ID="value2_cl_pulse_perc3" onblur="javascript: Changed_channel( 'value2_cl_pulse_perc3','riga1_cl_pulse_perc3',100, 1,0 );" class="span12"  runat="server" meta:resourcekey="value2_cl_pulse_perc3Resource1" ></asp:textbox>
                </div>
                       </div>
    </div>
    <!-- fine riga --> 

     <!-- riga -->
                <div class="row-fluid">
                    <div class="span2">
                       <div id="riga2_cl_pulse_mch" class="control-group">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal54"  text="mc/h" runat="server" meta:resourcekey="Literal96Resource1"></asp:literal></h5>
                       <asp:textbox ID="value2_cl_pulse_mch"  onblur="javascript: Changed_channel( 'value2_cl_pulse_mch','riga2_cl_pulse_mch',599, 1,2 );" class="span12"  runat="server" MaxLength="5" meta:resourcekey="value2_cl_pulse_mchResource1" ></asp:textbox>
                </div>
                       </div>
                </div>
                 <!-- fine riga -->


                       <!-- riga -->
                <div class="row-fluid">
               	<div class="span2">
                      


                            <div id="riga2_cl_pulse_range" class="control-group">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal55"  text="Range" runat="server" meta:resourcekey="Literal95Resource1"></asp:literal></h5>
                           </div>
                           <div id="riga2_cl_pulse_ccstk">
                                <h5 style="padding-top:10px"><asp:literal ID = "Literal56"  text="cc/stk" runat="server" meta:resourcekey="Literal36Resource1"></asp:literal></h5>
                           </div>


                       <asp:textbox ID="value2_cl_pulse_range" onblur="javascript: Changed_channel( 'value2_cl_pulse_range','riga2_cl_pulse_range',999, 0,1 );"  class="span12"  runat="server" MaxLength="4" meta:resourcekey="value2_cl_pulse_rangeResource1" ></asp:textbox>
                </div>
                       </div>
                <%--</div>--%>
                 <!-- fine riga -->  

    <!-- riga -->
                <div class="row-fluid">
               	<div class="span2">
                       <div id="riga2_cl_pulse_setpoint" class="control-group">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal57"  text="Setpoint" runat="server" meta:resourcekey="Literal64Resource1"></asp:literal></h5>
                       <asp:textbox ID="value2_cl_pulse_setpoint" onblur="Changed_channel( 'value2_cl_pulse_setpoint','riga2_cl_pulse_setpoint',max_ch2_value, min_ch2_value,max_fix_value2 );"  class="span12"  runat="server" MaxLength="4" meta:resourcekey="value2_cl_pulse_setpointResource1" ></asp:textbox>
                </div>
                       </div>
                </div>
                 <!-- fine riga --> 
     <!-- riga -->
                <div class="row-fluid">
               	<div class="span2">
                       <div id="riga_cl_pulse_conc" class="control-group">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal58"  text="Conc[%]" runat="server" meta:resourcekey="Literal94Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_cl_pulse_conc" onblur="Changed_channel( 'value_cl_pulse_conc','riga_cl_pulse_conc',999, 0,1 );"  class="span12"  runat="server" MaxLength="4" meta:resourcekey="value_cl_pulse_concResource1" ></asp:textbox>
                </div>
                       </div>
                </div>
                 <!-- fine riga -->  
    </div>
                    </div>
                </div>
<!-- tab 4 stop-->
           <!-- tab 5 start-->
			<div class="tab-pane" id="tab_ld_sp5_5">
                <div  class="box-generic">
                                 <!-- riga -->
                <div class="row-fluid">
               	<div class="span12">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal11"  text="cL Relay" runat="server" meta:resourcekey="Literal11Resource1"></asp:literal></h5>
                       <div class="controlli_box"> 
                    <asp:radiobutton ID="on_off_cl_relay"  runat="server"  GroupName="GROUP7" meta:resourcekey="on_off_cl_relayResource1"></asp:radiobutton>
                           </div>
                       <div class="controlli_testo_box"> 
                    <asp:literal runat="server" text ="On / Off" meta:resourcekey="LiteralResource14"></asp:literal>
                           </div>
                           <div class="controlli_box"> 
                    <asp:radiobutton ID="proportional_cl_relay"  runat="server"  GroupName="GROUP7" meta:resourcekey="proportional_cl_relayResource1"></asp:radiobutton>
                               </div>
                           <div class="controlli_testo_box"> 
                       <asp:literal runat="server" text ="Proportional PWM" meta:resourcekey="LiteralResource15"></asp:literal>
                               </div>
                               <div class="controlli_box"> 
                    <asp:radiobutton ID="fixed_cl_relay"  runat="server"  GroupName="GROUP7" meta:resourcekey="fixed_cl_relayResource1"></asp:radiobutton>
                                   </div>
                               <div class="controlli_testo_box"> 
                       <asp:literal runat="server" text ="Fixed PWM" meta:resourcekey="LiteralResource16"></asp:literal>
                                   </div>
                                   <div class="controlli_box"> 
					   <asp:radiobutton ID="off_cl_relay"  runat="server"  GroupName="GROUP7" meta:resourcekey="off_cl_relayResource2"></asp:radiobutton>
                                       </div>
                                   <div class="controlli_testo_box"> 
					<asp:literal runat="server" text ="Off" meta:resourcekey="LiteralResource17"></asp:literal>
                                       </div>

                       <div class="controlli_box">
                    <asp:radiobutton ID="Prop_WM_cl_relay"  runat="server"  GroupName="GROUP7" meta:resourcekey="Prop_WM_cl_relayResource2"></asp:radiobutton>
</div>
<div class="controlli_testo_box">
                       <asp:literal runat="server" text ="Prop+WM" meta:resourcekey="LiteralResource4"></asp:literal>
</div>
<div class="controlli_box">
                    <asp:radiobutton ID="PID_cl_relay"  runat="server"  GroupName="GROUP7" meta:resourcekey="PID_cl_relayResource2"></asp:radiobutton>
</div>
<div class="controlli_testo_box">
                       <asp:literal runat="server" text ="PID" meta:resourcekey="LiteralResource5"></asp:literal>
</div>

                </div>
                </div>
                 <!-- fine riga -->
                                <!-- riga -->
<div id ="disable_cl_relay">
                <div class="row-fluid">
               	<div class="span2">
                       <div id="riga1_cl_relay_1" class="control-group">
                           <div id="label1_cl_relay_else">
                                <h5 style="padding-top:10px"><asp:literal ID = "Literal38"  text="cL" runat="server" meta:resourcekey="Literal38Resource1"></asp:literal></h5>
                           </div>
                           <div id="label1_cl_relay_on_off">
                                <h5 style="padding-top:10px"><asp:literal ID = "Literal39"  text="cL ON" runat="server" meta:resourcekey="Literal39Resource1"></asp:literal></h5>
                           </div>
                       <asp:textbox ID="value1_cl_relay_1" onblur="javascript: Changed_channel( 'value1_cl_relay_1','riga1_cl_relay_1',max_ch2_value, min_ch2_value,max_fix_value2 );"  class="span12"  runat="server" meta:resourcekey="value1_cl_relay_1Resource1" ></asp:textbox>
                </div>
                       </div>

                    <div class="span2">
                       <div id="riga2_cl_relay_1" class="control-group">
					   <div id="label1_cl_relay_proportionalpwm">
							<h5 style="padding-top:10px"><asp:literal ID = "Literal40"  text="%" runat="server" meta:resourcekey="Literal40Resource1"></asp:literal></h5>
						</div>
					   <div id="label1_cl_relay_fixedpwm">
							<h5 style="padding-top:10px"><asp:literal ID = "Literal41"  text="sec" runat="server" meta:resourcekey="Literal41Resource1"></asp:literal></h5>
						</div>

						<asp:textbox ID="value2_cl_relay_1" onblur="javascript: Changed_channel( 'value2_cl_relay_1','riga2_cl_relay_1',100, 0,0 );"  class="span12"  runat="server" MaxLength="3" meta:resourcekey="value2_cl_relay_1Resource1" ></asp:textbox>
                </div>
                       </div>
                </div>
                 <!-- fine riga -->
<!-- riga -->
                <div class="row-fluid">
               	<div class="span2">
                       <div id="riga1_cl_relay_2" class="control-group">
                           <div id="label2_cl_relay_else">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal42"  text="cL" runat="server" meta:resourcekey="Literal42Resource1"></asp:literal></h5>
                               </div>
                           <div id="label2_cl_relay_on_off">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal43"  text="cL OFF" runat="server" meta:resourcekey="Literal43Resource1"></asp:literal></h5>
                               </div>

                       <asp:textbox ID="value1_cl_relay_2" onblur="javascript: Changed_channel( 'value1_cl_relay_2','riga1_cl_relay_2',max_ch2_value, min_ch2_value,max_fix_value2 );" class="span12"  runat="server" meta:resourcekey="value1_cl_relay_2Resource1" ></asp:textbox>
                </div>
                       </div>

                    <div class="span2">
                       <div id="riga2_cl_relay_2" class="control-group">
					   <div id="label2_cl_relay_proportionalpwm">
								<h5 style="padding-top:10px"><asp:literal ID = "Literal44"  text="%" runat="server" meta:resourcekey="Literal44Resource1"></asp:literal></h5>
						</div>		
					   <div id="label2_cl_relay_fixedpwm">
								<h5 style="padding-top:10px"><asp:literal ID = "Literal45"  text="sec" runat="server" meta:resourcekey="Literal45Resource1"></asp:literal></h5>
						</div>		

						<asp:textbox ID="value2_cl_relay_2" onblur="javascript: Changed_channel( 'value2_cl_relay_2','riga2_cl_relay_2',100, 0,0 );" class="span12"  runat="server" MaxLength="3" meta:resourcekey="value2_cl_relay_2Resource1" ></asp:textbox>
                </div>
                       </div>
                </div>
                 <!-- fine riga -->      
    
     <!-- riga -->
                <div class="row-fluid">
               	<div class="span2">
                       <div id="riga1_cl_relay_perc4" class="control-group">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal65"  text="% at 0 mc/h" runat="server" meta:resourcekey="Literal99Resource1"></asp:literal></h5>
                       <asp:textbox ID="value2_cl_relay_perc4" onblur="javascript: Changed_channel( 'value2_cl_relay_perc4','riga1_cl_relay_perc4',99, 0,0 );"  class="span12"  runat="server" MaxLength="2" meta:resourcekey="value2_cl_relay_perc4Resource1" ></asp:textbox>
                </div>
                       </div>
                </div>
                 <!-- fine riga -->  

     
    <!-- riga -->
                <div class="row-fluid">
               	<div class="span2">
                       <div id="riga1_cl_relay_perc3" class="control-group">
                           
                           
              <h5 style="padding-top:10px"><asp:literal ID = "Literal66"  text="% " runat="server" meta:resourcekey="Literal97Resource1"></asp:literal></h5>
                               

                       <asp:textbox ID="value2_cl_relay_perc3" onblur="javascript: Changed_channel( 'value2_cl_relay_perc3','riga1_cl_relay_perc3',100, 1,0 );" class="span12"  runat="server" meta:resourcekey="value2_cl_relay_perc3Resource1" ></asp:textbox>
                </div>
                       </div>
    </div>
    <!-- fine riga --> 

     <!-- riga -->
                <div class="row-fluid">
                    <div class="span2">
                       <div id="riga2_cl_relay_mch" class="control-group">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal67"  text="mc/h" runat="server" meta:resourcekey="Literal96Resource1"></asp:literal></h5>
                       <asp:textbox ID="value2_cl_realy_mch"  onblur="javascript: Changed_channel( 'value2_cl_realy_mch','riga2_cl_relay_mch',599, 1,2 );" class="span12"  runat="server" MaxLength="5" meta:resourcekey="value2_ph_realy_mchResource1" ></asp:textbox>
                </div>
                       </div>
                </div>
                 <!-- fine riga -->


                       <!-- riga -->
                <div class="row-fluid">
               	<div class="span2">
                      


                            <div id="riga2_cl_relay_range" class="control-group">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal68"  text="Range" runat="server" meta:resourcekey="Literal95Resource1"></asp:literal></h5>
                           </div>
                           <div id="riga2_cl_relay_ccstk">
                                <h5 style="padding-top:10px"><asp:literal ID = "Literal69"  text="cc/stk" runat="server" meta:resourcekey="Literal36Resource1"></asp:literal></h5>
                           </div>


                       <asp:textbox ID="value2_cl_relay_range" onblur="javascript: Changed_channel( 'value2_cl_relay_range','riga2_cl_relay_range',999, 0,1 );"  class="span12"  runat="server" MaxLength="4" meta:resourcekey="value2_cl_relay_rangeResource1" ></asp:textbox>
                </div>
                       </div>
                <%--</div>--%>
                 <!-- fine riga -->  

    <!-- riga -->
                <div class="row-fluid">
               	<div class="span2">
                       <div id="riga2_cl_relay2_setpoint" class="control-group">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal70"  text="Setpoint" runat="server" meta:resourcekey="Literal94BResource1"></asp:literal></h5>
                       <asp:textbox ID="value2_cl_relay2_setpoint" onblur="Changed_channel( 'value2_cl_relay2_setpoint','riga2_cl_relay_setpoint',max_ch2_value, min_ch2_value,max_fix_value2);"  class="span12"  runat="server" MaxLength="4" meta:resourcekey="value2_cl_relay2_setpointResource1" ></asp:textbox>
                </div>
                       </div>
                </div>
                 <!-- fine riga --> 
                              
    </div>
                    </div>
                </div>
<!-- tab 5 stop-->

    
<!-- tab 6 start-->
			<div class="tab-pane " id="tab_ld_sp5_6">
                <div  class="box-generic">
                                 <!-- riga -->
                <div class="row-fluid">
               	<div class="span12">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal78"  text="Mode" runat="server" meta:resourcekey="Label78Resource1"></asp:literal></h5>
<div class="controlli_box">
                    <asp:radiobutton ID="CL_P"  runat="server"  GroupName="GROUP9" meta:resourcekey="mode_piuResource1"></asp:radiobutton>
</div>
<div class="controlli_testo_box">
                    <asp:literal runat="server" text ="Mode ch2:+" meta:resourcekey="LiteralclpResource1"></asp:literal>
</div>
<div class="controlli_box">
                    <asp:radiobutton ID="CL_M"  runat="server"  GroupName="GROUP9" meta:resourcekey="mode_menoResource1"></asp:radiobutton>
</div>

<div class="controlli_testo_box">
                       <asp:literal runat="server" text ="Mode ch2:-" meta:resourcekey="LiteralclmResource2"></asp:literal>
</div>

                       
<div class="controlli_box">
                    <asp:radiobutton ID="PH_P"  runat="server"  GroupName="GROUP9A" meta:resourcekey="mode_piuResource1"></asp:radiobutton>
</div>
<div class="controlli_testo_box">
                    <asp:literal runat="server" text ="Mode ch1:+" meta:resourcekey="LiteralpHpResource1"></asp:literal>
</div>
<div class="controlli_box">
                    <asp:radiobutton ID="PH_M"  runat="server"  GroupName="GROUP9A" meta:resourcekey="mode_menoResource1"></asp:radiobutton>
</div>
<div class="controlli_testo_box">
                       <asp:literal runat="server" text ="Mode ch1:-" meta:resourcekey="LiteralpHmResource2"></asp:literal>
</div>
                </div>
                </div>
                 <!-- fine riga -->
                                <!-- riga -->
<div id ="Div2">
                <div class="row-fluid">
               	<div class="span2">
                       <div id="Div3" class="control-group">
                           
                           <div id="riga_time_int">
                                <h5 style="padding-top:10px"><asp:literal ID = "LiteralInt"  text="Time Integral:" runat="server" meta:resourcekey="LiteralIntResource1"></asp:literal></h5>
                           </div>
                       <asp:textbox ID="value_time_int" onblur="javascript: Changed_channel( 'value_time_int','riga_time_int',50000, 60,0 );" class="span12"  runat="server" meta:resourcekey="value_time_intResource1" ></asp:textbox>
                </div>
                       </div>

                    <div class="span2">
                       <div id="riga_time_der" class="control-group">
              <h5 style="padding-top:10px"><asp:literal ID = "Literalder"  text="Time Der:" runat="server" meta:resourcekey="LiteralderResource1"></asp:literal></h5>
                       <asp:textbox ID="value_time_der" onblur="javascript: Changed_channel( 'value_time_der','riga_time_int',2000, 2,0 );" class="span12"  runat="server" MaxLength="3" meta:resourcekey="value_time_derResource1" ></asp:textbox>
                </div>
                       </div>
                </div>
                 <!-- fine riga -->
                             



    


    </div>
                    </div>
                </div>
<!-- tab 6 stop-->

    <!-- tab 7 start-->
			<div class="tab-pane " id="tab_ld_sp5_7">
                <div  class="box-generic">
                                 <!-- riga -->
                <div class="row-fluid">
               	<div class="span12">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal71"  text="Mode" runat="server" meta:resourcekey="Label67Resource1"></asp:literal></h5>
<div class="controlli_box">
                    <asp:radiobutton ID="Additive"  runat="server"  GroupName="GROUP12" meta:resourcekey="AdditiveResource1"></asp:radiobutton>
</div>
<div class="controlli_testo_box">
                    <asp:literal runat="server" text ="Additive" meta:resourcekey="LiteralAddResource1"></asp:literal>
</div>
<div class="controlli_box">
                    <asp:radiobutton ID="Multiplicative"  runat="server"  GroupName="GROUP12" meta:resourcekey="MultiplicativeResource1"></asp:radiobutton>
</div>
<div class="controlli_testo_box">
                       <asp:literal runat="server" text ="Multiplicative" meta:resourcekey="LiteralMultResource2"></asp:literal>
</div>
                       <div class="controlli_box">
                    <asp:radiobutton ID="Disable"  runat="server"  GroupName="GROUP12" meta:resourcekey="DisableResource1"></asp:radiobutton>
</div>
<div class="controlli_testo_box">
                       <asp:literal runat="server" text ="Disable" meta:resourcekey="LiteralDisResource2"></asp:literal>
</div>

                </div>
                </div>
                 <!-- fine riga -->
                                <!-- riga -->
<div id ="Div4">
                <div class="row-fluid">
               	<div class="span2">
                       <div id="Div5" class="control-group">
                           
                           <div id="riga_perc">
                                <h5 style="padding-top:10px"><asp:literal ID = "Literal72"  text="Value %:" runat="server" meta:resourcekey="Literal70Resource1"></asp:literal></h5>
                           </div>
                       <asp:textbox ID="value_perc" onblur="javascript: Changed_channel( 'value_perc','riga_perc',100, 0,0 );" class="span12"  runat="server" meta:resourcekey="value_percResource1" ></asp:textbox>
                </div>
                       </div>

                    <div class="span2">
                       <div id="riga_mch" class="control-group">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal73"  text="mc/h:" runat="server" meta:resourcekey="Literal71Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_mch" onblur="javascript: Changed_channel( 'value_mch','riga_mch',5900, 1,1 );" class="span12"  runat="server" MaxLength="5" meta:resourcekey="value_mchResource1" ></asp:textbox>
                </div>
                       </div>
                </div>
                 <!-- fine riga -->
                             



    


    </div>
                    </div>
                </div>
<!-- tab 7 stop-->

 <!-- tab 8 start-->
			<div class="tab-pane " id="tab_ld_sp5_8">
                <div  class="box-generic">
                                 <!-- riga -->
                <div class="row-fluid">
               	<div class="span12">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal76"  text="Mode" runat="server" meta:resourcekey="Label76Resource1"></asp:literal></h5>
<div class="controlli_box">
                    <asp:radiobutton ID="ModeP_L"  runat="server"  GroupName="GROUP10" meta:resourcekey="P_LResource1"></asp:radiobutton>
</div>
<div class="controlli_testo_box">
                    <asp:literal runat="server" text ="Pulse/Litri" meta:resourcekey="Literal75Resource1"></asp:literal>
</div>
<div class="controlli_box">
                    <asp:radiobutton ID="ModeL_P"  runat="server"  GroupName="GROUP10" meta:resourcekey="L_PResource1"></asp:radiobutton>
</div>
<div class="controlli_testo_box">
                       <asp:literal runat="server" text ="Litri/Pulse" meta:resourcekey="Literal74Resource2"></asp:literal>
</div>
<div class="controlli_box">
                    <asp:radiobutton ID="Mode0_20"  runat="server"  GroupName="GROUP10" meta:resourcekey="mA0_20Resource1"></asp:radiobutton>
</div>
<div class="controlli_testo_box">
                       <asp:literal runat="server" text ="0/20 mA" meta:resourcekey="Literal73Resource2"></asp:literal>
</div>
<div class="controlli_box">
                    <asp:radiobutton ID="Mode4_20"  runat="server"  GroupName="GROUP10" meta:resourcekey="mA4_20_PResource1"></asp:radiobutton>
</div>
<div class="controlli_testo_box">
                       <asp:literal runat="server" text ="4/20 mA" meta:resourcekey="Literal72Resource2"></asp:literal>
</div>

<%--<div class="controlli_box">
                    <asp:radiobutton ID="Reset_yes"  runat="server"  GroupName="GROUP11" meta:resourcekey="Reset_yesResource1"></asp:radiobutton>
</div>
<div class="controlli_testo_box">
                       <asp:literal runat="server" text ="Reset Yes" meta:resourcekey="Literal71Resource2"></asp:literal>
</div>

<div class="controlli_box">
                    <asp:radiobutton ID="Reset_no"  runat="server"  GroupName="GROUP11" meta:resourcekey="Reset_noResource1"></asp:radiobutton>
</div>
<div class="controlli_testo_box">
                       <asp:literal runat="server" text ="Reset No" meta:resourcekey="Literal70Resource2"></asp:literal>
</div>--%>

                </div>
                </div>
                 <!-- fine riga -->
                                <!-- riga -->
<div id ="Div9">
                <div class="row-fluid">
               	<div class="span2">
                       <div id="Div6" class="control-group">
                           
                           <div id="riga_wm">
                                <h5 style="padding-top:10px"><asp:literal ID = "Literal74"  text="mc/h:" runat="server" meta:resourcekey="Literal60Resource1"></asp:literal></h5>
                           </div>
                       <asp:textbox ID="value_wm" onblur="javascript: Changed_channel( 'value_wm','riga_wm',5900, 0,1 );" class="span12"  runat="server" meta:resourcekey="value_wmResource1" ></asp:textbox>
                </div>
                       </div>

                    <div class="span2">
                       <div id="riga_timeout" class="control-group">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal75"  text="Timeout:" runat="server" meta:resourcekey="Literal59Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_timeout" onblur="javascript: Changed_channel( 'value_timeout','riga_timeout',999, 1,0 );" class="span12"  runat="server" MaxLength="5" meta:resourcekey="value_mchResource1" ></asp:textbox>
                </div>
                       </div>
                </div>
                 <!-- fine riga -->

    </div>
                    </div>
                </div>
<!-- tab 8 stop-->


    <!-- tab 9 start-->
			<div class="tab-pane " id="tab_ld_sp5_9">
                <div  class="box-generic">
                                 
                                <!-- riga -->
<div id ="Div2">
                <div class="row-fluid">
               	<div class="span2">
                       <div id="Div3" class="control-group">
                           
                           <div id="riga_stk_ph">
                                <h5 style="padding-top:10px"><asp:literal ID = "Literalstk1"  text="STK Ch1:" runat="server" meta:resourcekey="Literalstk1Resource1"></asp:literal></h5>
                           </div>
                       <asp:textbox ID="value_stk_ph" onblur="javascript: Changed_channel( 'value_stk_ph','riga_stk_ph',180, 1,0 );" class="span12"  runat="server" meta:resourcekey="value_stk_phResource1" ></asp:textbox>
                </div>
                       </div>

                    <div class="span2">
                       <div id="riga_stk_cl" class="control-group">
              <h5 style="padding-top:10px"><asp:literal ID = "Literalstk2"  text="STK Ch2:" runat="server" meta:resourcekey="Literalstk2Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_stk_cl" onblur="javascript: Changed_channel( 'value_stk_cl','riga_stk_cl',180, 1,0 );" class="span12"  runat="server" MaxLength="3" meta:resourcekey="value_stk_clResource1" ></asp:textbox>
                </div>
                       </div>


                    <div class="span2">
                       <div id="riga_var" class="control-group">
              <h5 style="padding-top:10px"><asp:literal ID = "LiteralVar"  text="Var [%]:" runat="server" meta:resourcekey="LiteralVarResource1"></asp:literal></h5>
                       <asp:textbox ID="value_var" onblur="javascript: Changed_channel( 'value_var','riga_var',999, 0,0 );" class="span12"  runat="server" MaxLength="3" meta:resourcekey="value_varResource1" ></asp:textbox>
                </div>
                       </div>

                </div>
                 <!-- fine riga -->
                             



    


    </div>
                    </div>
                </div>
<!-- tab 9 stop-->

    </div>
                                   <div id="salva" class="btn-primary">
                   <b class="btn-primary btn-icon glyphicons ok"><asp:button runat="server" ID="save_setpointlddp_new" class="btn-primary" data-layout="center" data-type="confirm" data-toggle="notyfy"  text="Salva e carica i dati" Font-Bold="True" meta:resourcekey="save_setpointlddp_newResource1" /><i></i></b>

            </div>
        </div>
        </div>
<script type="text/javascript" src="ld/validator_lddp_setpoint.js"></script>
<script type="text/javascript" src="common/validator_general_notify.js"></script>
<script src="theme/scripts/demo/notifications.js"></script>

</form>

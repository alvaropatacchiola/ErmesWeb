<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="setpoint_ltb.aspx.vb" Inherits="ermes_web_20.setpoint_ltb" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>
<form id="form" runat="server"  method="post" action="ltb/setpoint_ltb.aspx">
    <h3><asp:literal runat="server" text =" " ID="message_channel" meta:resourcekey="message_channelResource1" ></asp:literal></h3>
    <div class="innerLR">
        <div class="box-generic">
                        	<!-- Tabs Heading -->
<div class="tabsbar tabsbar-2">
			<ul class="row-fluid row-merge">
            
                <li class="span2 active" ><a id="tab_ld_sp1" href="#tab_ld_sp1_1"  data-toggle="tab"><asp:literal text="Mode"  runat="server" ID="tabld1_1" meta:resourcekey="tabld1_1Resource1"   ></asp:literal></a></li>
                <li class="span2"><a id="tab_ld_sp2" href="#tab_ld_sp2_2" data-toggle="tab"><asp:literal text="Proportional (WM)" runat="server" ID="tabld1_2" meta:resourcekey="tabld1_2Resource1"  ></asp:literal></a></li>
                <li class="span2"><a id="tab_ld_sp3" href="#tab_ld_sp3_3" data-toggle="tab"><asp:literal text="Constant" runat="server" ID="tabld1_3" meta:resourcekey="tabld1_3Resource1"  ></asp:literal></a></li>
                <li class="span2"><a id="tab_ld_sp4" href="#tab_ld_sp4_4" data-toggle="tab"><asp:literal text="Proportional (WM) + Reading" runat="server" ID="tabld1_4" meta:resourcekey="tabld1_4Resource1"  ></asp:literal></a></li>
                <li class="span2"><a id="tab_ld_sp5" href="#tab_ld_sp5_5" data-toggle="tab"><asp:literal text="Reading" runat="server" ID="tabld1_5" meta:resourcekey="tabld1_5Resource1"  ></asp:literal></a></li>
                
<asp:placeholder runat="server" ID="enable_tab_propmA">

			    <li class="span2"><a id="tab_ld_sp6" href="#tab_ld_sp6_6" data-toggle="tab"><asp:literal text="Proportional (mA)" runat="server" ID="tabld1_6" meta:resourcekey="tabld1_6Resource1"  ></asp:literal></a></li>
<li class="span2"><a id="tab_ld_sp7" href="#tab_ld_sp7_7" data-toggle="tab"><asp:literal text="EXT IS" runat="server" ID="tabld1_7" meta:resourcekey="tabld1_7Resource1"  ></asp:literal></a></li>
</asp:placeholder>
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
             <!-- <h5 style="padding-top:10px"><asp:literal ID = "Label7"  text="Mode" runat="server" meta:resourcekey="Label7Resource1"></asp:literal></h5>-->
                       <div class="controlli_box"> 
                            <asp:radiobutton ID="Proportional" runat="server"  GroupName="GROUP1" meta:resourcekey="proportionalResource1" ></asp:radiobutton>
                       </div>
                       <div class="controlli_testo_box" > 
                                <asp:literal runat="server" text ="Proportional" meta:resourcekey="LiteralResource1" ></asp:literal>
                      </div>
                       <div class="controlli_box"> 
                            <asp:radiobutton ID="Constant"  runat="server"  GroupName="GROUP1" meta:resourcekey="ConstantResource1" ></asp:radiobutton>
                       </div>
                        <div class="controlli_testo_box" > 
                            <asp:literal runat="server" text ="Constant" meta:resourcekey="LiteralResource2" ></asp:literal>
                        </div>
                           <div class="controlli_box"> 
                                <asp:radiobutton ID="PropRead"  runat="server"  GroupName="GROUP1" meta:resourcekey="PropReadResource2" ></asp:radiobutton>
                            </div>
                        <div class="controlli_testo_box" > 
                                <asp:literal runat="server" text ="Proportional and Reading" meta:resourcekey="LiteralResource3" ></asp:literal>
                        </div>
                        <div class="controlli_box"> 
                            <asp:radiobutton ID="Reading" runat="server"  GroupName="GROUP1" meta:resourcekey="ReadingResource1" ></asp:radiobutton>
                       </div>
                       <div class="controlli_testo_box" > 
                                <asp:literal runat="server" text ="Reading" meta:resourcekey="LiteralResource55" ></asp:literal>
                      </div>

                       <div class="controlli_box"> 
                            <asp:radiobutton ID="PropmA" runat="server"  GroupName="GROUP1" meta:resourcekey="PropmAResource1" ></asp:radiobutton>
                       </div>
                       <div class="controlli_testo_box" > 
                                <asp:literal runat="server" ID="PropmA_testo" text ="PropmA" meta:resourcekey="LiteralResource56" ></asp:literal>
                      </div>

                       <div class="controlli_box"> 
                            <asp:radiobutton ID="ExtIS" runat="server"  GroupName="GROUP1" meta:resourcekey="ExtISResource1" ></asp:radiobutton>
                       </div>
                       <div class="controlli_testo_box" > 
                                <asp:literal runat="server" ID="ExtIS_testo" text ="ExtIS" meta:resourcekey="LiteralResource57" ></asp:literal>
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
                
<!-- tab 1 stop-->
    <!-- tab 2 start-->
    
			<div class="tab-pane" id="tab_ld_sp2_2">
                <div  class="box-generic">
                    <!-- riga -->
                    <div id ="riga1_ppm_proportional" class="row-fluid">
                        	<div class="span3">
                                <h5 style="padding-top:10px"><asp:literal ID = "Literal5"  text="Proportional ppm" runat="server" meta:resourcekey="LiteralResource19"></asp:literal></h5>
                                <asp:textbox ID="value_ppm_proportional" onblur="javascript: Changed_channel( 'value_ppm_proportional','riga1_ppm_proportional',9, 0,2 );" class="span12"  runat="server" style=" position: relative; z-index: 100000; top: 0px; left: 0px;" MaxLength="4" meta:resourcekey="value_ppm_proportionalResource1"></asp:textbox>
                            </div>

                     </div>


                    <!-- fine riga -->
                    <!-- riga -->
                    
                    <!-- fine riga -->
                 <!-- fine riga -->
                                <!-- riga -->
 <!-- <div id ="enable_proportional">  -->
               
                 <!-- fine riga -->
<!-- riga -->
                 <!-- fine riga -->                                
<!-- riga -->
               
                 <!-- fine riga -->  
     </div> 
                    </div>
               
     
<!-- tab 2 stop-->
        <!-- tab 3 start-->
			<div class="tab-pane" id="tab_ld_sp3_3">
                <div  class="box-generic">
                    <!-- riga -->
                    <div id ="riga_constant" class="row-fluid">
                        	<div class="span3">
                                <h5 style="padding-top:10px"><asp:literal ID = "Literal2"  text="Constant P/m" runat="server" meta:resourcekey="LiteralResource20"></asp:literal></h5>
                                <asp:textbox ID="value_constant" onblur="javascript: Changed_channel( 'value_constant','riga_constant',180, 0,0 );" class="span12"  runat="server" style=" position: relative; z-index: 100000; top: 0px; left: 0px;" MaxLength="4" meta:resourcekey="value_constantResource1"></asp:textbox>
                            </div>

                     </div>

                    <asp:placeholder runat="server" ID="Button_Yes_No">
                     <div class="row-fluid">
                        	<div class="span3">
                                <h5 style="padding-top:10px"><asp:literal ID = "Set_Timer"  text="Timer" runat="server" meta:resourcekey="LiteralResource20B"></asp:literal></h5>

                          <div class="span1">
                                <div class="controlli_box"> 
                                       <asp:radiobutton ID="Timer_YES" runat="server" GroupName="GROUP2"  meta:resourcekey="Timer_YESResource1" ></asp:radiobutton>
                                </div>
                               <div class="controlli_testo_box" > 
                                        <asp:literal runat="server" text ="Yes"  ></asp:literal>
                              </div>
                                <div class="controlli_box"> 
                                       <asp:radiobutton ID="Timer_NO" runat="server" GroupName="GROUP2"  meta:resourcekey="Timer_YESResource1" ></asp:radiobutton>
                                </div>
                               <div class="controlli_testo_box" > 
                                        <asp:literal runat="server" text ="No"  ></asp:literal>
                              </div>

                                  
                       </div>
                 </div>
                </div>
                         </asp:placeholder>  
              <asp:placeholder runat="server" ID="enable_Timer">
                 <div class="row-fluid">
                 <div id="riga_start_feed" class="control-group">
                            <h5 style="padding-top:10px"><asp:literal ID = "Literal1B"  text="Start" runat="server" meta:resourcekey="Literal36Resource1B"></asp:literal></h5>
                            <asp:textbox ID="value_start_timer"  class="span3"  runat="server" meta:resourcekey="value_start_timer_res" ></asp:textbox>
                </div>
                <div id="riga_stop_feed" class="control-group">
                        <h5 style="padding-top:10px"><asp:literal ID = "Literal10"  text="Stop" runat="server" meta:resourcekey="Literal36Resource2B"></asp:literal></h5>
                       <asp:textbox ID="value_stop_timer"  class="span3"  runat="server" meta:resourcekey="value_stop_timer_res" ></asp:textbox>
                </div>
                            </div>
                  </asp:placeholder>  
                     



                     </div> 


             
                    </div>
<!-- tab 3 stop-->
<!-- tab 4 start-->
			    <div class="tab-pane" id="tab_ld_sp4_4">
                <div  class="box-generic">
                                 <!-- riga -->
                
                 <!-- fine riga -->
                                <!-- riga -->
<div id ="enable_prop_read">
                <div class="row-fluid">
               	<div class="span2">
                       <div id="riga1_mgl_propread" class="control-group">
                           <!--<div id="label1_mgl_propread"> -->
                             <!--   <h5 style="padding-top:10px"><asp:literal ID = "Literal1"  text="Proportional and reading" runat="server" meta:resourcekey="Literal38Resource1"></asp:literal></h5>-->
                          <!-- </div> -->
                          <!-- <div id="label2_mgl_propread">-->
                                <h5 style="padding-top:10px"><asp:literal ID = "Literal3"  text="mg/l" runat="server" meta:resourcekey="Literal39Resource1" ></asp:literal></h5>
                          <!-- </div>-->
                       <asp:textbox ID="value1_mgl_propread" onblur="javascript: Changed_channel( 'value1_mgl_propread','riga1_mgl_propread',max_ch2_value, min_ch2_value,max_fix_value2 );"  class="span12"  runat="server" meta:resourcekey="value1_mgl_propreadResource1" ></asp:textbox>
                </div>
                       </div>

                    <div class="span2">
                      <!-- <div id="riga1_pm_propread" class="control-group">-->
                       
					   <div id="label1_pm_propread">
							<h5 style="padding-top:10px"><asp:literal ID = "Literal4"  text="P/m" runat="server" meta:resourcekey="Literal40Resource1" ></asp:literal></h5>
						 <!-- </div>-->
					  

						<asp:textbox ID="value1_pm_propread" onblur="javascript: Changed_channel( 'value1_pm_propread','riga1_pm_propread',180, 0,0 );"  class="span12"  runat="server" MaxLength="3" meta:resourcekey="value1_pm_propreadResource1"  ></asp:textbox>
                </div>
                       </div>
                </div>
                 <!-- fine riga -->
<!-- riga -->
                <div class="row-fluid">
               <div class="span2">
                       <div id="riga2_mgl_propread" class="control-group">
                           
                           <div id="label2_mgl_propread">
                                <h5 style="padding-top:10px"><asp:literal ID = "Literal6"  text="mg/l" runat="server" meta:resourcekey="Literal39Resource1" ></asp:literal></h5>
                           </div>
                       <asp:textbox ID="value2_mgl_propread" onblur="javascript: Changed_channel( 'value2_mgl_propread','riga2_mgl_propread',max_ch2_value, min_ch2_value,max_fix_value2 );"  class="span12"  runat="server" meta:resourcekey="value2_mgl_propreadResource1"  ></asp:textbox>
                </div>
                       </div>

                    <div class="span2">
                       <div id="riga2_pm_propread" class="control-group">
					   <div id="label2_pm_propread">
							<h5 style="padding-top:10px"><asp:literal ID = "Literal7"  text="P/m" runat="server" meta:resourcekey="Literal40Resource1" ></asp:literal></h5>
						</div>
					  

						<asp:textbox ID="value2_pm_propread" onblur="javascript: Changed_channel( 'value2_pm_propread','riga2_pm_propread',180, 0,0 );"  class="span12"  runat="server" MaxLength="3" meta:resourcekey="value2_pm_propreadResource1"  ></asp:textbox>
                </div>
                       </div>
                </div>
                 <!-- fine riga -->   
    <!-- riga -->
                <div class="row-fluid">
               <div class="span2">
                       <div id="riga3_perc_propread" class="control-group">
                           
                           <div id="label_perc_propread">
                                <h5 style="padding-top:10px"><asp:literal ID = "Literal8"  text="%" runat="server" meta:resourcekey="Literal41Resource1" ></asp:literal></h5>
                           </div>
                       <asp:textbox ID="value_perc_propread" onblur="javascript: Changed_channel( 'value_perc_propread','riga3_perc_propread',100, 0,0 );"  class="span12"  runat="server" meta:resourcekey="value_perc_propreadResource1"  ></asp:textbox>
                </div>
                       </div>

                    <div class="span2">
                       <div id="riga4_mch_propread" class="control-group">
					   <div id="label_mch_propread">
							<h5 style="padding-top:10px"><asp:literal ID = "Literal9"  text="mc/h" runat="server" meta:resourcekey="Literal42Resource1" ></asp:literal></h5>
						</div>
					  

						<asp:textbox ID="value_mch_propread" onblur="javascript: Changed_channel( 'value_mch_propread','riga4_mch_propread',650, 0,2 );"  class="span12"  runat="server" MaxLength="6" meta:resourcekey="value_mch_propreadResource1"  ></asp:textbox>
                </div>
                       </div>
                </div>
                 <!-- fine riga -->                                
    </div>
                 <!-- fine riga -->                                
<!-- riga -->
             </div>  
                 <!-- fine riga -->  
   
       </div>              
                      
<!-- tab 4 stop-->
           <!-- tab 5 start-->
		<div class="tab-pane" id="tab_ld_sp5_5">
                <div  class="box-generic">
                                 <!-- riga -->
                
                 <!-- fine riga -->
                                <!-- riga -->
<div id ="enable_reading">
                <div class="row-fluid">
               	<div class="span2">
                       <div id="riga1_mgl_reading" class="control-group">
                           <div id="label1_mgl_reading">
                               <!-- <h5 style="padding-top:10px"><asp:literal ID = "Literal51"  text="Reading" runat="server" meta:resourcekey="Literal38Resource1"></asp:literal></h5> -->
                           </div>
                           <div id="label2_mgl_reading">
                                <h5 style="padding-top:10px"><asp:literal ID = "Literal52"  text="mg/l" runat="server" meta:resourcekey="Literal43Resource1" ></asp:literal></h5>
                           </div>
                       <asp:textbox ID="value1_mgl_reading" onblur="javascript: Changed_channel( 'value1_mgl_reading','riga1_mgl_reading',max_ch2_value, min_ch2_value,max_fix_value2 );"  class="span12"  runat="server" meta:resourcekey="value1_mgl_readingResource1"  ></asp:textbox>
                </div>
                       </div>

                    <div class="span2">
                       <div id="riga1_pm_reading" class="control-group">
					   <div id="label1_pm_reading">
							<h5 style="padding-top:10px"><asp:literal ID = "Literal53"  text="P/m" runat="server" meta:resourcekey="Literal44Resource1" ></asp:literal></h5>
						</div>
					  

						<asp:textbox ID="value1_pm_reading" onblur="javascript: Changed_channel( 'value1_pm_reading','riga1_pm_reading',180, 0,0 );"  class="span12"  runat="server" MaxLength="3" meta:resourcekey="value1_pm_readingResource1"  ></asp:textbox>
                </div>
                       </div>
                </div>
                 <!-- fine riga -->
<!-- riga -->
                <div class="row-fluid">
               <div class="span2">
                       <div id="riga2_mgl_reading" class="control-group">
                           
                           <div id="label3_mgl_reading">
                                <h5 style="padding-top:10px"><asp:literal ID = "Literal60"  text="mg/l" runat="server" meta:resourcekey="Literal45Resource1" ></asp:literal></h5>
                           </div>
                       <asp:textbox ID="value2_mgl_reading" onblur="javascript: Changed_channel( 'value2_mgl_reading','riga2_mgl_reading',max_ch2_value, min_ch2_value,max_fix_value2 );"  class="span12"  runat="server" meta:resourcekey="value2_mgl_readingResource1"  ></asp:textbox>
                </div>
                       </div>

                    <div class="span2">
                       <div id="riga2_pm_reading" class="control-group">
					   <div id="label2_pm_reading">
							<h5 style="padding-top:10px"><asp:literal ID = "Literal70"  text="P/m" runat="server" meta:resourcekey="Literal46Resource1" ></asp:literal></h5>
						</div>
					  

						<asp:textbox ID="value2_pm_reading" onblur="javascript: Changed_channel( 'value2_pm_reading','riga2_pm_reading',180, 0,0 );"  class="span12"  runat="server" MaxLength="3" meta:resourcekey="value2_pm_readingResource1"  ></asp:textbox>
                </div>
                       </div>
                </div>
                 <!-- fine riga -->                                
    </div>
                    </div>
                </div>
        
        
<!-- tab 5 stop-->
<!-- tab 6 start-->
		<div class="tab-pane" id="tab_ld_sp6_6">
                <div  class="box-generic">
                                 <!-- riga -->
                
                 <!-- fine riga -->
                                <!-- riga -->
<asp:placeholder runat="server" ID="enable_propmA">
                  
<div id ="enable_PropmA">
                <div class="row-fluid">
               	<div class="span2">
                       <div id="riga1_mA_propmA" class="control-group">
                           <div id="label1_mA_propmA">
                              
                           </div>
                           <div id="label2_mA_propmA">
                                <h5 style="padding-top:10px"><asp:literal ID = "Literal80"  text="mA" runat="server" meta:resourcekey="Literal80Resource1" ></asp:literal></h5>
                           </div>
                       <asp:textbox ID="value1_mA_propmA" onblur="javascript: Changed_channel( 'value1_mA_propmA','riga1_mA_propmA',20, 0,2 );"  class="span12"  runat="server" meta:resourcekey="value1_mA_propmAResource1"  ></asp:textbox>
                </div>
                       </div>

                   


                    <div class="span2">
                       <div id="riga1_pm_propmA" class="control-group">
					   <div id="label1_pm_propmA">
							<h5 style="padding-top:10px"><asp:literal ID = "Literal81"  text="P/m" runat="server" meta:resourcekey="Literal81Resource1" ></asp:literal></h5>
						</div>
					  

						<asp:textbox ID="value1_pm_propmA" onblur="javascript: Changed_channel( 'value1_pm_propmA','riga1_pm_propmA',180, 0,0 );"  class="span12"  runat="server" MaxLength="3" meta:resourcekey="value1_pm_propmAResource1"  ></asp:textbox>
                </div>
                       </div>

                     </div> <!-- <CHIUDE div class="row-fluid"> -->
   
               
                 <!-- fine riga -->
<!-- riga -->
                <div class="row-fluid">
               <div class="span2">
                       <div id="riga2_mA_propmA" class="control-group">
                           
                           <div id="label3_mA_propmA">
                                <h5 style="padding-top:10px"><asp:literal ID = "Literal82"  text="mA" runat="server" meta:resourcekey="Literal82Resource1" ></asp:literal></h5>
                           </div>
                       <asp:textbox ID="value2_mA_propmA" onblur="javascript: Changed_channel( 'value2_mA_propmA','riga2_mA_propmA',20, 0,2 );"  class="span12"  runat="server" meta:resourcekey="value2_mA_propmAResource1"  ></asp:textbox>
                </div>
                       </div>

                    <div class="span2">
                       <div id="riga2_pm_propmA" class="control-group">
					   <div id="label2_pm_propmA">
							<h5 style="padding-top:10px"><asp:literal ID = "Literal83"  text="P/m" runat="server" meta:resourcekey="Literal83Resource1" ></asp:literal></h5>
						</div>
					  

						<asp:textbox ID="value2_pm_propmA" onblur="javascript: Changed_channel( 'value2_pm_propmA','riga2_pm_propmA',180, 0,0 );"  class="span12"  runat="server" MaxLength="3" meta:resourcekey="value2_pm_propmAResource1"  ></asp:textbox>
                </div>
                       </div>
                </div>
                 <!-- fine riga -->                                
   
     </div><!-- < CHIUDE div id ="enable_PropmA"> -->    
                                
                </div><!-- CHIUDE <div  class="box-generic"> -->
      </div><!-- CHIUDE "tab-pane" id="tab_ld_sp6_6"> -->
</asp:placeholder>
<!-- tab 6 stop-->
  
                                   <div id="salva" class="btn-primary">
                   <b class="btn-primary btn-icon glyphicons ok"><asp:button runat="server" ID="save_setpointltb_new" class="btn-primary" data-layout="center" data-type="confirm" data-toggle="notyfy"  text="Salva e carica i dati" Font-Bold="True" meta:resourcekey="save_setpointltb_newResource1"  /><i></i></b>

            </div>
        </div>
       
<script type="text/javascript" src="ltb/validator_ltb_setpoint.js?v=1.11"></script>
                   <script src="theme/scripts/demo/calendar_new.js"></script>
    <link href="bootstrap/css/jquery-ui-timepicker-addon.css" rel="stylesheet" />

<script type="text/javascript" src="common/validator_general_notify.js"></script>
<script src="theme/scripts/demo/notifications.js"></script>

</form>

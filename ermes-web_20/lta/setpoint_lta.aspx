<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="setpoint_lta.aspx.vb" Inherits="ermes_web_20.setpoint_lta" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>
<form id="form" runat="server"  method="post" action="lta/setpoint_lta.aspx">
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

                <li class="span2"><a id="tab_ld_sp7" href="#tab_ld_sp7_7" data-toggle="tab"><asp:literal text="mA Outputs" runat="server" ID="tabld1_7" meta:resourcekey="tabld1_7Resource1"  ></asp:literal></a></li>

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
                                <asp:literal runat="server"  ID="PropRead_testo" text ="Proportional and Reading" meta:resourcekey="LiteralResource3" ></asp:literal>
                        </div>
                        <div class="controlli_box"> 
                            <asp:radiobutton ID="Reading" runat="server"  GroupName="GROUP1" meta:resourcekey="ReadingResource1" ></asp:radiobutton>
                       </div>
                       <div class="controlli_testo_box" > 
                                <asp:literal runat="server"  ID="Reading_testo" text ="Reading " meta:resourcekey="LiteralResource55" ></asp:literal>
                      </div>

                       <div class="controlli_box"> 
                            <asp:radiobutton ID="Batch" runat="server"  GroupName="GROUP1" meta:resourcekey="BatchResource1" ></asp:radiobutton>
                       </div>
                       <div class="controlli_testo_box" > 
                                <asp:literal runat="server" ID="Batch_testo" text ="Batch" meta:resourcekey="LiteralResource56" ></asp:literal>
                      </div>

                       <div class="controlli_box"> 
                            <asp:radiobutton ID="AnalogOut" runat="server"  GroupName="GROUP2" meta:resourcekey="AnalogOutResource1" ></asp:radiobutton>
                       </div>
                       <div class="controlli_testo_box" > 
                                <asp:literal runat="server" ID="AnalogOut_testo" text ="Analog Outputs" meta:resourcekey="LiteralResource57" ></asp:literal>
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
                                <h5 style="padding-top:10px"><asp:literal ID = "Literal6"  text="Constant 1 %" runat="server" meta:resourcekey="LiteralResource20"></asp:literal></h5>
                                <asp:textbox ID="value_constant" onblur="javascript: Changed_channel( 'value_constant','riga_constant',100, 1,0 );" class="span12"  runat="server" style=" position: relative; z-index: 100000; top: 0px; left: 0px;" MaxLength="4" meta:resourcekey="value_constantResource1"></asp:textbox>
                            </div>
                         </div>
                     

                   
                    <div id ="riga_constant2" class="row-fluid">
                        	<div class="span3">
                                <h5 style="padding-top:10px"><asp:literal ID = "Literal61"  text="Constant 2 %" runat="server" meta:resourcekey="LiteralResource21"></asp:literal></h5>
                                <asp:textbox ID="value_constant2" onblur="javascript: Changed_channel( 'value_constant2','riga_constant2',100, 1,0 );" class="span12"  runat="server" style=" position: relative; z-index: 100000; top: 0px; left: 0px;" MaxLength="4" meta:resourcekey="value_constant2Resource1"></asp:textbox>
                            </div>
                         </div>
              

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
                                <h5 style="padding-top:10px"><asp:literal ID = "Literal7"  text="mg/l" runat="server" meta:resourcekey="Literal39Resource1" ></asp:literal></h5>
                          <!-- </div>-->
                       <asp:textbox ID="value1_mgl_propread" onblur="javascript: Changed_channel( 'value1_mgl_propread','riga1_mgl_propread',max_ch2_value, min_ch2_value,max_fix_value2 );"  class="span12"  runat="server" meta:resourcekey="value1_mgl_propreadResource1" ></asp:textbox>
                </div>
                       </div>

                    <div class="span2">
                      <!-- <div id="riga1_pm_propread" class="control-group">-->
                       
					   <div id="label1_pm_propread">
							<h5 style="padding-top:10px"><asp:literal ID = "Literal8"  text="100 %" runat="server" meta:resourcekey="Literal44Resource1" ></asp:literal></h5>
						 <!-- </div>-->
					  

						<%--<asp:textbox ID="value1_pm_propread" onblur="javascript: Changed_channel( 'value1_pm_propread','riga1_pm_propread',180, 0,0 );"  class="span12"  runat="server" MaxLength="3" meta:resourcekey="value1_pm_propreadResource1"  ></asp:textbox>--%>
                </div>
                       </div>
                </div>
                 <!-- fine riga -->
<!-- riga -->
                <div class="row-fluid">
               <div class="span2">
                       <div id="riga2_mgl_propread" class="control-group">
                           
                           <div id="label2_mgl_propread">
                                <h5 style="padding-top:10px"><asp:literal ID = "Literal9"  text="mg/l" runat="server" meta:resourcekey="Literal39Resource1" ></asp:literal></h5>
                           </div>
                       <asp:textbox ID="value2_mgl_propread" onblur="javascript: Changed_channel( 'value2_mgl_propread','riga2_mgl_propread',max_ch2_value, min_ch2_value,max_fix_value2 );"  class="span12"  runat="server" meta:resourcekey="value2_mgl_propreadResource1"  ></asp:textbox>
                </div>
                       </div>

                    <div class="span2">
                       <div id="riga2_pm_propread" class="control-group">
					   <div id="label2_pm_propread">
							<h5 style="padding-top:10px"><asp:literal ID = "Literal10"  text="0 %" runat="server" meta:resourcekey="Literal46Resource1" ></asp:literal></h5>
						</div>
					  

						<%--<asp:textbox ID="value2_pm_propread" onblur="javascript: Changed_channel( 'value2_pm_propread','riga2_pm_propread',180, 0,0 );"  class="span12"  runat="server" MaxLength="3" meta:resourcekey="value2_pm_propreadResource1"  ></asp:textbox>--%>
                </div>
                       </div>
                </div>
                 <!-- fine riga -->   
    <!-- riga -->
                <div class="row-fluid">
               

                    
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
							<h5 style="padding-top:10px"><asp:literal ID = "Literal53"  text="100 %" runat="server" meta:resourcekey="Literal44Resource1" ></asp:literal></h5>
						</div>
					  

						<%--<asp:textbox ID="value1_pm_reading" onblur="javascript: Changed_channel( 'value1_pm_reading','riga1_pm_reading',180, 0,0 );"  class="span12"  runat="server" MaxLength="3" meta:resourcekey="value1_pm_readingResource1"  ></asp:textbox>--%>
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
							<h5 style="padding-top:10px"><asp:literal ID = "Literal70"  text="0 %" runat="server" meta:resourcekey="Literal46Resource1" ></asp:literal></h5>
						</div>
					  

						<%--<asp:textbox ID="value2_pm_reading" onblur="javascript: Changed_channel( 'value2_pm_reading','riga2_pm_reading',180, 0,0 );"  class="span12"  runat="server" MaxLength="3" meta:resourcekey="value2_pm_readingResource1"  ></asp:textbox>--%>
                </div>
                       </div>
                </div>
                 <!-- fine riga -->                                
    </div>
                    </div>
                </div>
        
        
<!-- tab 5 stop-->



        <!-- tab 7 start-->
		<div class="tab-pane" id="tab_ld_sp7_7">
                <div  class="box-generic">
                                 <!-- riga -->
                
                 <!-- fine riga -->
                                <!-- riga -->
<div id ="Div3">
                <div class="row-fluid">
               

                         

                      

                       <div class="span2">
                           <div id ="riga_cap" class="row-fluid">
                        	
                                <h5 style="padding-top:10px"><asp:literal ID = "Literal1_riga_cap"  text="mA Output Capacity" runat="server" meta:resourcekey="Literalcap_mAResource19"></asp:literal></h5>
                                <%--<asp:textbox ID="Textbox1" onblur="javascript: Changed_channel( 'valore_cap_20mA','riga_val_cap_20mA',4000, 0,0 );" class="span12"  runat="server" style=" position: relative; z-index: 100000; top: 0px; left: 0px;" MaxLength="4" meta:resourcekey="valore_cap_20mAResource1"></asp:textbox>
                            --%>

                     </div>

                        <div id ="riga_val_cap_20mA" class="row-fluid">
                        	
                                <h5 style="padding-top:10px"><asp:literal ID = "Literal_riga_cap_20mA"  text="20 mA at [g/h]:" runat="server" meta:resourcekey="Literalcap_mAResource19"></asp:literal></h5>
                                <asp:textbox ID="valore_cap_20mA" onblur="javascript: Changed_channel( 'valore_cap_20mA','riga_val_cap_20mA',4000, 0,0 );" class="span12"  runat="server" style=" position: relative; z-index: 100000; top: 0px; left: 0px;" MaxLength="4" meta:resourcekey="valore_cap_20mAResource1"></asp:textbox>
                            

                     </div>


                            <div class="controlli_box"> 
                            <asp:radiobutton ID="Cap0_20_mA" runat="server"  GroupName="GROUP3" meta:resourcekey="CapmAResource1" ></asp:radiobutton>
                       </div>
                       <div class="controlli_testo_box" > 
                                <asp:literal runat="server" text ="0/20 mA" meta:resourcekey="Cap0_20_mAResource1" ></asp:literal>
                      </div>
                       <div class="controlli_box"> 
                            <asp:radiobutton ID="Cap4_20_mA"  runat="server"  GroupName="GROUP3" meta:resourcekey="CapmAResource3" ></asp:radiobutton>
                       </div>
                        <div class="controlli_testo_box" > 
                            <asp:literal runat="server" text ="4/20 mA" meta:resourcekey="Cap4_20_mAResource2" ></asp:literal>
                        </div>

 </div>
                    

                      
                    

                    	<div class="span2">

                             <div id ="riga_read" class="row-fluid">
                        	
                                <h5 style="padding-top:10px"><asp:literal ID = "Literalriga_read"  text="mA Output Reading" runat="server" meta:resourcekey="Literalread_mAResource19"></asp:literal></h5>
                                <%--<asp:textbox ID="Textbox1" onblur="javascript: Changed_channel( 'valore_cap_20mA','riga_val_cap_20mA',4000, 0,0 );" class="span12"  runat="server" style=" position: relative; z-index: 100000; top: 0px; left: 0px;" MaxLength="4" meta:resourcekey="valore_cap_20mAResource1"></asp:textbox>
                            --%>

                     </div>

                            <div id ="riga_val_read_0_4mA" class="row-fluid">
                        	
                                <h5 style="padding-top:10px"><asp:literal ID = "Literalriga_val_read_0_4mA"  text="0/4 mA at [ppm]:" runat="server" meta:resourcekey="Literalcap_mAResource19"></asp:literal></h5>
                                <asp:textbox ID="valore_read_0_4mA" onblur="javascript: Changed_channel( 'valore_read_0_4mA','riga_val_read_0_4mA',max_ch2_value, min_ch2_value,max_fix_value2 );" class="span12"  runat="server" style=" position: relative; z-index: 100000; top: 0px; left: 0px;" MaxLength="5" meta:resourcekey="valore_read_0_4mAResource1"></asp:textbox>
                            

                     </div>

                            <div id ="riga_val_read_20mA" class="row-fluid">
                        	
                                <h5 style="padding-top:10px"><asp:literal ID = "Literalriga_val_read_20mA"  text="20 mA at [ppm]:" runat="server" meta:resourcekey="Literalcap_mAResource19"></asp:literal></h5>
                                <asp:textbox ID="valore_read_20mA" onblur="javascript: Changed_channel( 'valore_read_20mA','riga_val_read_20mA',max_ch2_value, min_ch2_value,max_fix_value2 );" class="span12"  runat="server" style=" position: relative; z-index: 100000; top: 0px; left: 0px;" MaxLength="5" meta:resourcekey="valore_read_20mAResource1"></asp:textbox>
                            

                     </div>


                       <div class="controlli_box"> 
                            <asp:radiobutton ID="Read0_20_mA" runat="server"  GroupName="GROUP4" meta:resourcekey="CapReadResource1" ></asp:radiobutton>
                       </div>
                       <div class="controlli_testo_box" > 
                                <asp:literal runat="server" text ="0/20 mA" meta:resourcekey="Read0_20_mAResource1" ></asp:literal>
                      </div>
                       <div class="controlli_box"> 
                            <asp:radiobutton ID="Read4_20_mA"  runat="server"  GroupName="GROUP4" meta:resourcekey="CapReadResource3" ></asp:radiobutton>
                       </div>
                        <div class="controlli_testo_box" > 
                            <asp:literal runat="server" text ="4/20 mA" meta:resourcekey="Read4_20_mAResource2" ></asp:literal>
                        </div>

                      
                            </div> 
                          
                           </div> 
                          
                 <!-- fine riga -->
                               
 </div>
                    </div>
                </div>
                   
        
        
<!-- tab 7 stop-->

  
                                   <div id="salva" class="btn-primary">
                   <b class="btn-primary btn-icon glyphicons ok"><asp:button runat="server" ID="save_setpointlta_new" class="btn-primary" data-layout="center" data-type="confirm" data-toggle="notyfy"  text="Salva e carica i dati" Font-Bold="True" meta:resourcekey="save_setpointlta_newResource1"  /><i></i></b>

            
        </div>
       </div>
<script type="text/javascript" src="lta/validator_lta_setpoint.js"></script>
<script type="text/javascript" src="common/validator_general_notify.js"></script>
<script src="theme/scripts/demo/notifications.js"></script>

</form>

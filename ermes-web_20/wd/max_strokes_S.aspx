<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="max_strokes_S.aspx.vb" Inherits="ermes_web_20.max_strokes_S" %>

<form id="form" runat="server"  method="post" action="wd/max_strokes_S.aspx">
        
    <h3><asp:literal runat="server" text ="Max Strokes Settings" ID="message_channel"></asp:literal></h3>
    <div class="innerLR">
        <div class="box-generic">
                        	<!-- Tabs Heading -->
<div class="tabsbar tabsbar-2">
			<ul class="row-fluid row-merge">
            
                <li class="span2 active" ><a id="tab_ld_sp1" href="#tab_ld_sp1_1"  data-toggle="tab"><asp:literal text="pH Strokes"  runat="server" ID="tabld1_1" ></asp:literal></a></li>
               
                
			</ul>
		</div>
		<!-- // Tabs Heading END -->
<div class="tab-content">
    <!-- tab 1 start-->
			<div class="tab-pane active" id="tab_ld_sp1_1">
                <div  class="box-generic">
                                 <!-- riga -->
                <div class="row-fluid">
               	<div class="span3">
              <h5 style="padding-top:10px"><asp:literal ID = "Label7"  text=" " runat="server"></asp:literal></h5>
                 <div id="Div1">
                                <h5 style="padding-top:10px"><asp:literal ID = "Literal6"  text=" " runat="server"></asp:literal></h5>
                           </div>   

                </div>
                </div>
                 <!-- fine riga -->
                                <!-- riga -->
<div id ="disable_ph_pulse1">
                <div class="row-fluid">
               	<div class="span2">
                       <div id="riga1_ph_stk" class="control-group">
                           <div id="label1_ph_pulse1_proportional">
                                <h5 style="padding-top:10px"><asp:literal ID = "Literal4"  text=" " runat="server"></asp:literal></h5>
                           </div>
                           <div id="label1_ph_pulse1_on_off">
                                <h5 style="padding-top:10px"><asp:literal ID = "Literal1"  text="Strokes pH:" runat="server"></asp:literal></h5>
                           </div>
                       <asp:textbox ID="value1_ph_stk" onblur="javascript: Changed_channel( 'value1_ph_stk','riga1_ph_stk',180, 1,0 );" class="span12"  runat="server" ></asp:textbox>
                </div>
                       </div>

                    <div class="span2">
                       <div id="riga2_ph_pulse1_1" class="control-group">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal5"  text="  " runat="server"></asp:literal></h5>
                       
                </div>
                       </div>
                </div>
                 <!-- fine riga -->
<!-- riga -->
                <div class="row-fluid">
               	<div class="span2">
                       <div id="riga1_ph_pulse1_2" class="control-group">
                           <div id="label2_ph_pulse1_proportional">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal7"  text=" " runat="server"></asp:literal></h5>
                               </div>
                           <div id="label2_ph_pulse1_on_off">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal8"  text=" " runat="server"></asp:literal></h5>
                               </div>

                </div>
                       </div>

                    <div class="span2">
                       <div id="riga2_ph_pulse1_2" class="control-group">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal9"  text="  " runat="server"></asp:literal></h5>
                </div>
                       </div>
                </div>
                 <!-- fine riga -->                                
<!-- riga -->
                <div class="row-fluid">
               	<div class="span2">
                       <div id="riga1_ph_pulse1_3" class="control-group">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal10"  text=" " runat="server"></asp:literal></h5>
                </div>
                       </div>
                </div>
                 <!-- fine riga -->  
    </div>
                    </div>
                </div>
<!-- tab 1 stop-->
   
        
<!-- tab 4 start-->
			
<!-- tab 4 stop-->
           
    </div>
                                   <div id="salva" class="btn-primary">
                   <b class="btn-primary btn-icon glyphicons ok"><asp:button runat="server" ID="save_maxstrokesS_new" class="btn-primary"  data-layout="center" data-type="confirm" data-toggle="notyfy"  text="Salva e carica i dati" Font-Bold="True" /><i></i></b>

            </div>
        </div>
        </div>
<script type="text/javascript" src="wd/validator_max_strokes_S.js"></script>
<script type="text/javascript" src="common/validator_general_notify.js"></script>
<script src="theme/scripts/demo/notifications.js"></script>

</form>
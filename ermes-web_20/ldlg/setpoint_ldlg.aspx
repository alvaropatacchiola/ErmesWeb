<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="setpoint_ldlg.aspx.vb" Inherits="ermes_web_20.setpoint_ldlg" %>


<form id="form" runat="server"  method="post" action="ldlg/setpoint_ldlg.aspx">
    <h3><asp:literal runat="server" text ="Level 1" ID="message_channel"></asp:literal></h3>
    <div class="innerLR">
        <div class="box-generic">
                        	<!-- Tabs Heading -->
		<!-- // Tabs Heading END -->
<div class="tab-content">
    <!-- tab 1 start-->
			<div class="tab-pane active" id="tab_ld_sp1_1">
                <div  class="box-generic">

                                <!-- riga -->
<div id ="disable_ph_pulse1">
                <div class="row-fluid">
               	<div class="span2">
                       <div id="riga1_name" class="control-group">
                           <div id="label1_level_name">
                                <h5 style="padding-top:10px"><asp:literal ID = "Literal4"  text="Name" runat="server" ></asp:literal></h5>
                           </div>
                       <asp:textbox ID="value_name" onblur="javascript: Changed_channel_str( 'value_name','riga1_name' );" class="span12"  runat="server"  MaxLength="15"  ></asp:textbox>
                </div>
                       </div>

                </div>
                 <!-- fine riga -->
<!-- riga -->
                <div class="row-fluid">
<asp:placeholder runat="server" id ="wm_enable">
       <div class="span2">
                       <div id="riga1_pulse_litre" class="control-group">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal2"  text="P/L or L/P" runat="server" ></asp:literal></h5>
                 <asp:dropdownlist ID="value_pulse_litre" class="span12" runat="server">
                     <asp:ListItem Value="0" >P/L</asp:ListItem>
                     <asp:ListItem Value="1" >L/P</asp:ListItem>
                    </asp:dropdownlist>

                </div>
                       </div>
</asp:placeholder>
               	<div class="span2">
                       <div id="riga1_pulse" class="control-group">
                           <div id="label_pulse">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal8"  text="ml/pulse" runat="server"  ></asp:literal></h5>
                               </div>

                       <asp:textbox ID="value_pulse" onblur="javascript: Changed_channel( 'value_pulse','riga1_pulse',max_pulse, 0,virgole );" class="span12"  runat="server"  ></asp:textbox>
                </div>
                       </div>

                   
                </div>
                 <!-- fine riga -->                                
<!-- riga -->
                <div class="row-fluid">
               
       <div class="span2">
                       <div id="riga1_enable" class="control-group">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal1"  text="Enable" runat="server" ></asp:literal></h5>
                 <asp:dropdownlist ID="value_enable" class="span12" runat="server">
                     <asp:ListItem Value="0"  >No</asp:ListItem>
                     <asp:ListItem Value="1"  >Yes</asp:ListItem>
                    </asp:dropdownlist>

                </div>
                       </div>
                </div>
                 <!-- fine riga -->  
    </div>
                    </div>
                </div>
<!-- tab 1 stop-->
 
    </div>
                                   <div id="salva" class="btn-primary">
                   <b class="btn-primary btn-icon glyphicons ok"><asp:button runat="server" ID="save_setpointldlg_new" class="btn-primary" data-layout="center" data-type="confirm" data-toggle="notyfy"  text="Salva e carica i dati" Font-Bold="True"  /><i></i></b>

            </div>
        </div>
        </div>
<script type="text/javascript" src="ldlg/validator_ldlg_setpoint.js"></script>
<script type="text/javascript" src="common/validator_general_notify.js"></script>
<script src="theme/scripts/demo/notifications.js"></script>

</form>

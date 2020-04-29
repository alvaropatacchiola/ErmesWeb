<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="wmeter_ld4.aspx.vb" Inherits="ermes_web_20.w_meter_ld4" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>
<form id="form" runat="server" method="post" action="ld4/wmeter_ld4.aspx">
    <h3><asp:literal runat="server" text ="Water Meter LD" ID="message_channel" meta:resourcekey="message_channelResource1"></asp:literal></h3>
    <div class="innerLR">
        <div class="box-generic">
            <div class="tabsbar tabsbar-2">
			<ul class="row-fluid row-merge">
            
                <li class="span2 active" ><a id="tab_ld_sp1" href="#tab_ld_sp1_1"  data-toggle="tab"><asp:literal text="General"  runat="server" ID="tabld1_1" meta:resourcekey="tabld1_1Resource1" ></asp:literal></a></li>
                
			</ul>
		</div>
            <div class="tab-content">
<!-- tab 1 start-->
			<div class="tab-pane active" id="tab_ld_sp1_1">
                <div  class="box-generic">
<!-- riga -->
                <div class="row-fluid">
               	<div class="span3">
                      <div id="riga1_valore" >
                           <h5 style="padding-top:10px"><asp:literal ID = "Literal1"  text="Value" runat="server" meta:resourcekey="Literal1Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_meter" onblur="javascript: Changed_channel( 'value_meter','riga1_valore',599, 0,0 );" class="span12"  runat="server" MaxLength="6" meta:resourcekey="value_ph_feeding_delayResource1" ></asp:textbox>
                </div>
                   
                </div>
                </div>
                 <!-- fine riga -->
<!-- riga -->
                <div class="controlli_box">
                   <asp:radiobutton ID="checkreset"  runat="server" meta:resourcekey="check_reset_idResource1" GroupName="resetwm" ></asp:radiobutton>
</div>   
                    <div class="controlli_testo_box">
                       <asp:literal runat="server" text ="Reset" meta:resourcekey="LiteralResource4"></asp:literal>
</div>

                </div>
                 <!-- fine riga -->
<!-- riga -->
                    <asp:placeholder runat="server" ID="enable_priority">
                <div class="row-fluid">
               	<div class="span12">
              <h5 style="padding-top:10px"><asp:literal ID = "Label7"  text="Mode" runat="server" meta:resourcekey="Label7Resource1"></asp:literal></h5>
<div class="controlli_box">
                    <asp:radiobutton ID="litri"  runat="server"  GroupName="GROUP1" meta:resourcekey="litriResource1"></asp:radiobutton>
</div>
<div class="controlli_testo_box">
                    <asp:literal runat="server" text ="L/P" meta:resourcekey="LiteralResource1"></asp:literal>
</div>
<div class="controlli_box">
                    <asp:radiobutton ID="pulse"  runat="server"  GroupName="GROUP1" meta:resourcekey="pulseResource1"></asp:radiobutton>
</div>
<div class="controlli_testo_box">
                       <asp:literal runat="server" text ="P/L" meta:resourcekey="LiteralResource2"></asp:literal>
</div>
                </div>
                </div>
                        </asp:placeholder>
                 <!-- fine riga -->
                      <div class="row-fluid">
               	<div class="span3">
                      <div id="m3h_valore" >
                           <h5 style="padding-top:10px"><asp:literal ID = "Literal2"  text="Alarm Flow meter m3h:" runat="server" meta:resourcekey="Literal1Resource1"></asp:literal></h5>
                       <asp:textbox ID="m3h" onblur="javascript: Changed_channel( 'm3h','m3h_valore',5999, 0,0 );" class="span12"  runat="server" MaxLength="6" meta:resourcekey="value_m3hResource1" ></asp:textbox>
                </div>
                   
                </div>
                </div>                               

                    </div>
                </div>
<!-- tab 1 stop-->
<!-- tab 2 start-->
			
                <!-- tab 2 stop-->  
                </div>
<div id="salva" class="btn-primary">
                   <b class="btn-primary btn-icon glyphicons ok"><asp:button runat="server" ID="save_meter_new_ld4" class="btn-primary" data-layout="center" data-type="confirm" data-toggle="notyfy" text="Salva e carica i dati" Font-Bold="True" meta:resourcekey="save_meter_new_ld4Resource1" /><i></i></b>
                </div>
            </div>
        <script type="text/javascript" src="ld4/validator_ld4_meter.js"></script>
        <script type="text/javascript" src="common/validator_general_notify.js"></script>
        <script src="theme/scripts/demo/notifications.js"></script>

        </div>
    </form>

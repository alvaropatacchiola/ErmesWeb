<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="alert.aspx.vb" Inherits="ermes_web_20.alert" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>


<form id="form" runat="server" method="post" action="wd/alert.aspx">
    <h3><asp:literal runat="server" text ="Alert" ID="message_channel" meta:resourcekey="message_channelResource1"></asp:literal></h3>
    <div class="innerLR">
        <div class="box-generic">
            <div class="tabsbar tabsbar-2">
			<ul class="row-fluid row-merge">
            
                <li class="span2 active" ><a id="tab_ld_sp1" href="#tab_ld_sp1_1"  data-toggle="tab"><asp:literal text="General"  runat="server" ID="tabld1_1" meta:resourcekey="tabld1_1Resource1" ></asp:literal></a></li>
                <!-- <li class="span2"><a id="tab_ld_sp2" href="#tab_ld_sp2_2" data-toggle="tab"><asp:literal text="Password" runat="server" ID="tabld1_2" meta:resourcekey="tabld1_2Resource1"></asp:literal></a></li> -->
			</ul>
		</div>
            <div class="tab-content">
<!-- tab 1 start-->
			<div class="tab-pane active" id="tab_ld_sp1_1">
                <div  class="box-generic">
<!-- riga -->
                <div class="row-fluid">
               	<div class="span3">
                      <div id="riga1_filtro_value" class="control-group">
                           <h5 style="padding-top:10px"><asp:literal ID = "Literal1"  text="Filter:" runat="server" meta:resourcekey="Literal1Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_filtro" onblur="javascript: Changed_channel( 'value_filtro','riga1_filtro_value',999, 0,0 );" class="span12"  runat="server"  meta:resourcekey="value_filtroResource1" ></asp:textbox>
                </div>
                   
                </div>

                    	<div class="span3">
                      <div id="riga1_probe_value" class="control-group">
                           <h5 style="padding-top:10px"><asp:literal ID = "Literalprobe"  text="Probe:" runat="server" meta:resourcekey="LiteralprobeResource1"></asp:literal></h5>
                       <asp:textbox ID="value_probe" onblur="javascript: Changed_channel( 'value_probe','riga1_probe_value',999, 0,0 );" class="span12"  runat="server"  meta:resourcekey="value_probeResource1" ></asp:textbox>
                </div>
                   
                </div>

                    <div class="span3">
                      <div id="riga1_manut_value" class="control-group">
                           <h5 style="padding-top:10px"><asp:literal ID = "Literalmanut"  text="Maintenance:" runat="server" meta:resourcekey="LiteralmanutResource1"></asp:literal></h5>
                       <asp:textbox ID="value_manut" onblur="javascript: Changed_channel( 'value_manut','riga1_manut_value',999, 0,0 );" class="span12"  runat="server"  meta:resourcekey="value_manutResource1" ></asp:textbox>
                </div>
                   
                </div>
                </div>
                 <!-- fine riga -->
<!-- riga -->
               <!-- <div class="row-fluid">
               <div class="span3">
                      <div id="riga1_ph_tau" class="control-group">
                          <h5 style="padding-top:10px"><asp:literal ID = "Literal2"  text="Tau " runat="server"></asp:literal></h5>
                       <asp:textbox ID="value_ph_tau" onblur="javascript: Changed_channel( 'value_ph_tau','riga1_ph_tau',30, 0,0 );" class="span12"  runat="server" MaxLength="2" ></asp:textbox>
                </div>
                   
                </div>
                </div> -->
                 <!-- fine riga -->
<!-- riga -->
                    
                 <!-- fine riga -->
                                                    

                    </div>
                </div>
<!-- tab 1 stop-->

		
                </div>
<div id="salva" class="btn-primary">
                   <b class="btn-primary btn-icon glyphicons ok"><asp:button runat="server" ID="save_alert_new" class="btn-primary" data-layout="center" data-type="confirm" data-toggle="notyfy" text="Salva e carica i dati" Font-Bold="True" meta:resourcekey="save_alert_newResource1" /><i></i></b>
                </div>
            </div>
        <script type="text/javascript" src="wd/validator_alert.js"></script>
         <script type="text/javascript" src="common/validator_general_notify.js"></script>
        <script src="theme/scripts/demo/notifications.js"></script>

        </div>
    </form>

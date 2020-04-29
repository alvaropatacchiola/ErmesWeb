<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="manual.aspx.vb" Inherits="ermes_web_20.manual" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>



<form id="form" runat="server"  method="post" action="max5/manual.aspx">
    <h3><asp:literal runat="server" text ="Manual Max 5" ID="message_channel" meta:resourcekey="message_channelResource1"></asp:literal></h3>
    <div class="innerLR">
        <div class="box-generic">
            	<!-- Tabs Heading -->
<div class="tabsbar tabsbar-2">
			<ul class="row-fluid row-merge">
            
                <li class="span2 active" ><a id="tab_1_3" href="#tab1-5_3"  data-toggle="tab"><asp:literal text="Manual Relay"  runat="server" ID="tab1_3" meta:resourcekey="tab1_3Resource1" ></asp:literal></a></li>
                <li class="span2"><a id="tab_2_3" href="#tab2-5_3" data-toggle="tab"><asp:literal text="Manual Pulse" runat="server" ID="tab2_3" meta:resourcekey="tab2_3Resource1"></asp:literal></a></li>
			</ul>
		</div>
		<!-- // Tabs Heading END -->

            <div class="tab-content">
<!-- tab 1 start-->
			<div class="tab-pane active" id="tab1-5_3">
                <div  class="box-generic">
                                <!-- riga -->
                <div class="row-fluid">
               	<div class="span2">
               <div id="div1" class="control-group">
              <h5 style="padding-top:10px"><asp:literal ID = "Label7"  text="Relay 1" runat="server" meta:resourcekey="Label7Resource1"></asp:literal></h5>
                   <asp:checkbox ID="check_relay1_id" style="margin: 5px 10px 10px 0px;" runat="server" meta:resourcekey="check_relay1_idResource1" ></asp:checkbox>
                       
                </div>
                </div>
	<div class="span2">
               <div id="riga_relay1_1" class="control-group">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal5"  text="Min" runat="server" meta:resourcekey="Literal5Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_relay1_id"  class="span12"  runat="server" MaxLength="2" meta:resourcekey="value_relay1_idResource1"  ></asp:textbox>
                </div>
                </div>
                </div>
                 <!-- fine riga -->
<!-- riga -->
                <div class="row-fluid">
               	<div class="span2">
               <div id="div5" class="control-group">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal10"  text="Relay 2" runat="server" meta:resourcekey="Literal10Resource1"></asp:literal></h5>
                   <asp:checkbox ID="check_relay2_id" style="margin: 5px 10px 10px 0px;" runat="server" meta:resourcekey="check_relay2_idResource1" ></asp:checkbox>
                       
                </div>
                </div>
	<div class="span2">
               <div id="riga_relay2_1" class="control-group">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal11"  text="Min" runat="server" meta:resourcekey="Literal11Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_relay2_id"  class="span12"  runat="server" MaxLength="2" meta:resourcekey="value_relay2_idResource1"  ></asp:textbox>
                </div>
                </div>
                </div>
<!-- fine riga -->
<!-- riga -->
                <div class="row-fluid">
               	<div class="span2">
               <div id="div2" class="control-group">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal1"  text="Relay 3" runat="server" meta:resourcekey="Literal1Resource1"></asp:literal></h5>
                   <asp:checkbox ID="check_relay3_id" style="margin: 5px 10px 10px 0px;" runat="server" meta:resourcekey="check_relay3_idResource1" ></asp:checkbox>
                       
                </div>
                </div>
	<div class="span2">
               <div id="riga_relay3_1" class="control-group">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal6"  text="Min" runat="server" meta:resourcekey="Literal6Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_relay3_id"  class="span12"  runat="server" MaxLength="2" meta:resourcekey="value_relay3_idResource1"  ></asp:textbox>
                </div>
                </div>
                </div>
<!-- fine riga -->
   <!-- riga -->
                <div class="row-fluid">
               	<div class="span2">
               <div id="div3" class="control-group">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal2"  text="Relay 4" runat="server" meta:resourcekey="Literal2Resource1"></asp:literal></h5>
                   <asp:checkbox ID="check_relay4_id" style="margin: 5px 10px 10px 0px;" runat="server" meta:resourcekey="check_relay4_idResource1" ></asp:checkbox>
                       
                </div>
                </div>
	<div class="span2">
               <div id="riga_relay4_1" class="control-group">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal7"  text="Min" runat="server" meta:resourcekey="Literal7Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_relay4_id"  class="span12"  runat="server" MaxLength="2" meta:resourcekey="value_relay4_idResource1"  ></asp:textbox>
                </div>
                </div>
                </div>
<!-- fine riga -->
<!-- riga -->
                <div class="row-fluid">
               	<div class="span2">
               <div id="div4" class="control-group">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal8"  text="Relay 5" runat="server" meta:resourcekey="Literal8Resource1"></asp:literal></h5>
                   <asp:checkbox ID="check_relay5_id" style="margin: 5px 10px 10px 0px;" runat="server" meta:resourcekey="check_relay5_idResource1" ></asp:checkbox>
                       
                </div>
                </div>
	<div class="span2">
               <div id="riga_relay5_1" class="control-group">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal9"  text="Min" runat="server" meta:resourcekey="Literal9Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_relay5_id"  class="span12"  runat="server" MaxLength="2" meta:resourcekey="value_relay5_idResource1"  ></asp:textbox>
                </div>
                </div>
                </div>
<!-- fine riga -->
<!-- riga -->
                <div class="row-fluid">
               	<div class="span2">
               <div id="div6" class="control-group">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal12"  text="Relay 6" runat="server" meta:resourcekey="Literal12Resource1"></asp:literal></h5>
                   <asp:checkbox ID="check_relay6_id" style="margin: 5px 10px 10px 0px;" runat="server" meta:resourcekey="check_relay6_idResource1" ></asp:checkbox>
                       
                </div>
                </div>
	<div class="span2">
               <div id="riga_relay6_1" class="control-group">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal13"  text="Min" runat="server" meta:resourcekey="Literal13Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_relay6_id"  class="span12"  runat="server" MaxLength="18" meta:resourcekey="value_relay6_idResource1"  ></asp:textbox>
                </div>
                </div>
                </div>
<!-- fine riga -->
                    </div>
                </div>
<!-- tab 1 stop-->
<!-- tab 2 start-->
			<div class="tab-pane" id="tab2-5_3">
                <div  class="box-generic">
<!-- riga -->
                <div class="row-fluid">
               	<div class="span2">
               <div id="div7" class="control-group">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal3"  text="Pulse 1" runat="server" meta:resourcekey="Literal3Resource1"></asp:literal></h5>
                   <asp:checkbox ID="check_pulse1_id" style="margin: 5px 10px 10px 0px;" runat="server" meta:resourcekey="check_pulse1_idResource1" ></asp:checkbox>
                       
                </div>
                </div>
	<div class="span2">
               <div id="riga_pulse1_1" class="control-group">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal4"  text="Min" runat="server" meta:resourcekey="Literal4Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_pulse1_id"  class="span12"  runat="server" MaxLength="2" meta:resourcekey="value_pulse1_idResource1"  ></asp:textbox>
                </div>
                </div>
                </div>
                 <!-- fine riga -->
<!-- riga -->
                <div class="row-fluid">
               	<div class="span2">
               <div id="div8" class="control-group">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal14"  text="Pulse 2" runat="server" meta:resourcekey="Literal14Resource1"></asp:literal></h5>
                   <asp:checkbox ID="check_pulse2_id" style="margin: 5px 10px 10px 0px;" runat="server" meta:resourcekey="check_pulse2_idResource1" ></asp:checkbox>
                       
                </div>
                </div>
	<div class="span2">
               <div id="riga_pulse2_1" class="control-group">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal15"  text="Min" runat="server" meta:resourcekey="Literal15Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_pulse2_id"  class="span12"  runat="server" MaxLength="2" meta:resourcekey="value_pulse2_idResource1"  ></asp:textbox>
                </div>
                </div>
                </div>
<!-- fine riga -->
<!-- riga -->
                <div class="row-fluid">
               	<div class="span2">
               <div id="div9" class="control-group">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal16"  text="Pulse 3" runat="server" meta:resourcekey="Literal16Resource1"></asp:literal></h5>
                   <asp:checkbox ID="check_pulse3_id" style="margin: 5px 10px 10px 0px;" runat="server" meta:resourcekey="check_pulse3_idResource1" ></asp:checkbox>
                       
                </div>
                </div>
	<div class="span2">
               <div id="riga_pulse3_1" class="control-group">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal17"  text="Min" runat="server" meta:resourcekey="Literal17Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_pulse3_id"  class="span12"  runat="server" MaxLength="2" meta:resourcekey="value_pulse3_idResource1"  ></asp:textbox>
                </div>
                </div>
                </div>
<!-- fine riga -->
   <!-- riga -->
                <div class="row-fluid">
               	<div class="span2">
               <div id="div10" class="control-group">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal18"  text="Pulse 4" runat="server" meta:resourcekey="Literal18Resource1"></asp:literal></h5>
                   <asp:checkbox ID="check_pulse4_id" style="margin: 5px 10px 10px 0px;" runat="server" meta:resourcekey="check_pulse4_idResource1" ></asp:checkbox>
                       
                </div>
                </div>
	<div class="span2">
               <div id="riga_pulse4_1" class="control-group">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal19"  text="Min" runat="server" meta:resourcekey="Literal19Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_pulse4_id"  class="span12"  runat="server" MaxLength="2" meta:resourcekey="value_pulse4_idResource1"  ></asp:textbox>
                </div>
                </div>
                </div>
<!-- fine riga -->
<!-- riga -->
                <div class="row-fluid">
               	<div class="span2">
               <div id="div11" class="control-group">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal20"  text="Pulse 5" runat="server" meta:resourcekey="Literal20Resource1"></asp:literal></h5>
                   <asp:checkbox ID="check_pulse5_id" style="margin: 5px 10px 10px 0px;" runat="server" meta:resourcekey="check_pulse5_idResource1" ></asp:checkbox>
                       
                </div>
                </div>
	<div class="span2">
               <div id="riga_pulse5_1" class="control-group">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal21"  text="Min" runat="server" meta:resourcekey="Literal21Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_pulse5_id"  class="span12"  runat="server" MaxLength="2" meta:resourcekey="value_pulse5_idResource1"  ></asp:textbox>
                </div>
                </div>
                </div>
<!-- fine riga -->
<!-- riga -->
                <div class="row-fluid">
               	<div class="span2">
               <div id="div12" class="control-group">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal22"  text="Pulse 6" runat="server" meta:resourcekey="Literal22Resource1"></asp:literal></h5>
                   <asp:checkbox ID="check_pulse6_id" style="margin: 5px 10px 10px 0px;" runat="server" meta:resourcekey="check_pulse6_idResource1" ></asp:checkbox>
                       
                </div>
                </div>
	<div class="span2">
               <div id="riga_pulse6_1" class="control-group">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal23"  text="Min" runat="server" meta:resourcekey="Literal23Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_pulse6_id"  class="span12"  runat="server" MaxLength="18" meta:resourcekey="value_pulse6_idResource1"  ></asp:textbox>
                </div>
                </div>
                </div>
<!-- fine riga -->
                    </div>
                </div>
<!-- tab 2 stop-->

                </div>

                       <div id="salva" class="btn-primary">
                   <b class="btn-primary btn-icon glyphicons ok"><asp:button runat="server" ID="save_manual_new" class="btn-primary" data-layout="center" data-type="confirm" data-toggle="notyfy"  text="Salva e carica i dati" Font-Bold="True" meta:resourcekey="save_manual_newResource1" /><i></i></b>
                </div>


            </div>
        </div>
    
    <script type="text/javascript" src="max5/validator_max5_manual.js"></script>
       <script type="text/javascript" src="common/validator_general_notify.js"></script>
    <script src="theme/scripts/demo/notifications.js"></script>
    </form>
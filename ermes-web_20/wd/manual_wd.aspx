<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="manual_wd.aspx.vb" Inherits="ermes_web_20.manual_wd" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>




<form id="form" runat="server"  method="post" action="wd/manual_wd.aspx">
    <h3><asp:literal runat="server" text ="Manual WD" ID="message_channel" meta:resourcekey="message_channelResource1"></asp:literal></h3>
    <div class="innerLR">
        <div class="box-generic">
            	<!-- Tabs Heading -->
<div class="tabsbar tabsbar-2">
			<ul class="row-fluid row-merge">
            
                
                <li class="span2"><a id="tab_2_3" href="#tab2-5_3" data-toggle="tab"><asp:literal text="Manual " runat="server" ID="tab2_3" meta:resourcekey="tab2_3Resource1"></asp:literal></a></li>
			</ul>
		</div>
		<!-- // Tabs Heading END -->

            <div class="tab-content">
<!-- tab 1 start-->
<!-- tab 1 stop-->
<!-- tab 2 start-->
			<div class="tab-pane" id="tab2-5_3">
                <div  class="box-generic">
<!-- riga -->
                <div class="row-fluid">
               	<div class="span2">
               <div id="div7" class="control-group">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal3"  text="Pulse 1" runat="server" meta:resourcekey="Literal3Resource1"></asp:literal></h5>
                   <asp:radiobutton ID="check_pulse1_id" style="margin: 5px 10px 10px 0px;" runat="server" meta:resourcekey="check_pulse1_idResource1" GroupName="manuald" ></asp:radiobutton>
                       
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
                   <asp:radiobutton ID="check_pulse2_id" style="margin: 5px 10px 10px 0px;" runat="server" meta:resourcekey="check_pulse2_idResource1" GroupName="manuald" ></asp:radiobutton>
                       
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
                
<!-- fine riga -->
   <!-- riga -->
                
<!-- fine riga -->
<!-- riga -->
                
<!-- fine riga -->
<!-- riga -->
                
<!-- fine riga -->
                    </div>
                </div>
<!-- tab 2 stop-->

                </div>

                       <div id="salva" class="btn-primary">
                   <b class="btn-primary btn-icon glyphicons ok"><asp:button runat="server" ID="save_manual_newwd" class="btn-primary" data-layout="center" data-type="confirm" data-toggle="notyfy"  text="Salva e carica i dati" Font-Bold="True" meta:resourcekey="save_manual_newwdResource1" /><i></i></b>
                </div>


            </div>
        </div>
    
    <script type="text/javascript" src="wd/validator_wd_manual.js"></script>
       <script type="text/javascript" src="common/validator_general_notify.js"></script>
    <script src="theme/scripts/demo/notifications.js"></script>
    </form>

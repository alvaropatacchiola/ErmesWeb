<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="message_ltb.aspx.vb" Inherits="ermes_web_20.message_ltb" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>
<form id="form" runat="server" method="post" action="ltb/message_ltb.aspx">
    <h3><asp:literal runat="server" text ="Message LTB" ID="message_channel" meta:resourcekey="message_channelResource1"></asp:literal></h3>
    <div class="innerLR">
        <div class="box-generic">
            	<!-- Tabs Heading -->
<div class="tabsbar tabsbar-2">
			<ul class="row-fluid row-merge">
            
                <li class="span2 active" ><a id="tab_1_3" href="#tab1-5_3"  data-toggle="tab"><asp:literal text="SMS Alarm"  runat="server" ID="tab1_3" meta:resourcekey="tab1_3Resource1" ></asp:literal></a></li>
                <li class="span2"><a id="tab_2_3" href="#tab2-5_3" data-toggle="tab"><asp:literal text="Mail Alarm" runat="server" ID="tab2_3" meta:resourcekey="tab2_3Resource1"></asp:literal></a></li>
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
               <div id="riga_sms_1" class="control-group">
              <h5 style="padding-top:10px"><asp:literal ID = "Label7"  text="SMS Number 1" runat="server" meta:resourcekey="Label7Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_sms1_id"  class="span12"  runat="server" MaxLength="18" meta:resourcekey="value_sms1_idResource1"  ></asp:textbox>
                </div>
                </div>
                </div>
                 <!-- fine riga -->
                                <!-- riga -->
                <div class="row-fluid">
               	<div class="span2">
                       <div id="riga_sms_2" class="control-group">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal1"  text="SMS Number 2" runat="server" meta:resourcekey="Literal1Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_sms2_id"  class="span12"  runat="server" MaxLength="18" meta:resourcekey="value_sms2_idResource1"  ></asp:textbox>
                </div>
                       </div>
                </div>
                 <!-- fine riga -->
                                <!-- riga -->
                <div class="row-fluid">
               	<div class="span2">
                       <div id="riga_sms_3" class="control-group">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal2"  text="SMS Number 3" runat="server" meta:resourcekey="Literal2Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_sms3_id"  class="span12"  runat="server" MaxLength="18" meta:resourcekey="value_sms3_idResource1"  ></asp:textbox>
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
               <div id="riga_mail_1" class="control-group">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal3"  text="E-Mail Number 1" runat="server" meta:resourcekey="Literal3Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_mail1_id"  class="span12" onblur="javascript: keypress_check_mail( 'value_mail1_id','riga_mail_1');" runat="server" MaxLength="40" meta:resourcekey="value_mail1_idResource1"  ></asp:textbox>
                </div>
                </div>
                </div>
                 <!-- fine riga -->
                                <!-- riga -->
                <div class="row-fluid">
               	<div class="span2">
                       <div id="riga_mail_2" class="control-group">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal4"  text="E-Mail Number 2" runat="server" meta:resourcekey="Literal4Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_mail2_id" onblur="javascript: keypress_check_mail( 'value_mail2_id','riga_mail_2');" class="span12"  runat="server" MaxLength="40" meta:resourcekey="value_mail2_idResource1"  ></asp:textbox>
                </div>
                       </div>
                </div>
                 <!-- fine riga -->
                    </div>
                </div>
<!-- tab 2 stop-->

                </div>

                       <div id="salva" class="btn-primary">
                   <b class="btn-primary btn-icon glyphicons ok"><asp:button runat="server" ID="save_message_newltb" class="btn-primary" data-layout="center" data-type="confirm" data-toggle="notyfy" text="Salva e carica i dati" Font-Bold="True" meta:resourcekey="save_message_newltbResource1" /><i></i></b>
                </div>


            </div>
        </div>
    <script type="text/javascript" src="ltb/validator_ltb_message.js"></script>
     <script type="text/javascript" src="common/validator_general_notify.js"></script>
    <script src="theme/scripts/demo/notifications.js"></script>
    </form>
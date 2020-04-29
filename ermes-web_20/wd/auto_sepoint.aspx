<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="auto_sepoint.aspx.vb" Inherits="ermes_web_20.auto_sepoint" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>

<form id="form" runat="server" method="post" action="wd/auto_sepoint.aspx">
    <h3><asp:literal runat="server" text ="Auto Setpoint WD" ID="message_channel" meta:resourcekey="message_channelResource1"></asp:literal></h3>
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
                      <div id="riga1_ph_value" class="control-group">
                           <h5 style="padding-top:10px"><asp:literal ID = "Literal1"  text="pH:" runat="server" meta:resourcekey="Literal1Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_ph" onblur="javascript: Changed_channel( 'value_ph','riga1_ph_value',max_ch1_value, min_ch1_value,max_fix_value1 );" class="span12"  runat="server"  meta:resourcekey="value_phResource1" ></asp:textbox>
                </div>
                   
                </div>

                    <div class="span3">
                      <div id="riga1_mV_value" class="control-group">
                           <h5 style="padding-top:10px"><asp:literal ID = "LiteralmV"  text="mV:" runat="server" meta:resourcekey="LiteralmVResource1"></asp:literal></h5>
                       <asp:textbox ID="value_mV" onblur="javascript: Changed_channel( 'value_mV','riga1_mV_value',max_ch2_value, min_ch2_value,max_fix_value2 );" class="span12"  runat="server"  meta:resourcekey="value_mVResource1" ></asp:textbox>
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
                    <asp:placeholder runat="server" ID="enable_priority">
                <div class="row-fluid">
               	<div class="span3">
              <h5 style="padding-top:10px"><asp:literal ID = "Label7"  text="Mode" runat="server" meta:resourcekey="Label7Resource1"></asp:literal></h5>
                    <asp:radiobutton ID="phplus" style="margin: 5px 10px 10px 0px;" runat="server"  GroupName="GROUP1" meta:resourcekey="pHplusResource1"></asp:radiobutton>
                    <asp:literal runat="server" text ="pH +" meta:resourcekey="LiteralResource1"></asp:literal>
                    <asp:radiobutton ID="phmeno" style="margin: 5px 10px 10px 0px;" runat="server"  GroupName="GROUP1" meta:resourcekey="pHmenoResource1"></asp:radiobutton>
                       <asp:literal runat="server" text ="pH -" meta:resourcekey="LiteralResource2"></asp:literal>
                </div>
                </div>
                        </asp:placeholder>
                 <!-- fine riga -->
                                                    

                    </div>
                </div>
<!-- tab 1 stop-->

		
                </div>
<div id="salva" class="btn-primary">
                   <b class="btn-primary btn-icon glyphicons ok"><asp:button runat="server" ID="save_auto_setpoint_new" class="btn-primary" data-layout="center" data-type="confirm" data-toggle="notyfy" text="Salva e carica i dati" Font-Bold="True" meta:resourcekey="save_auto_setpoint_newResource1" /><i></i></b>
                </div>
            </div>
        <script type="text/javascript" src="wd/validator_auto_setpoint.js"></script>
         <script type="text/javascript" src="common/validator_general_notify.js"></script>
        <script src="theme/scripts/demo/notifications.js"></script>

        </div>
    </form>

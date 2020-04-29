<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="range_alarms.aspx.vb" Inherits="ermes_web_20.range_alarms" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>

<form id="form" runat="server"  method="post" action="lds/range_alarms.aspx">
    <h3><asp:literal runat="server" text ="Range Alarm LDS" ID="message_channel" meta:resourcekey="message_channelResource1"></asp:literal></h3>
    <div class="innerLR">
        <div class="box-generic">
            <div class="box-generic">
                	<!-- Tabs Heading -->

		<!-- // Tabs Heading END -->
                <div class="tab-content">

<!-- tab 1 start-->
			<div class="tab-pane active" id="tab_ld_sp1_1">
                <div  class="box-generic">
                                 <!-- riga -->
                <div class="row-fluid">
               	<div class="span12">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal3"  text="High Range Alarm Cl" runat="server" meta:resourcekey="Literal3Resource1"></asp:literal></h5>
<div class="controlli_box">
                    <asp:radiobutton ID="cl_alarm_high_disable"  runat="server"  GroupName="GROUP4" meta:resourcekey="cl_alarm_high_disableResource1"></asp:radiobutton>
</div>
<div class="controlli_testo_box">
                    <asp:literal runat="server" text ="Disable High" meta:resourcekey="LiteralResource1"></asp:literal>
</div>
<div class="controlli_box">
                    <asp:radiobutton ID="cl_alarm_high_enable"  runat="server"  GroupName="GROUP4" meta:resourcekey="cl_alarm_high_enableResource1"></asp:radiobutton>
</div>
<div class="controlli_testo_box">
                       <asp:literal runat="server" text ="Enable High" meta:resourcekey="LiteralResource2"></asp:literal>
</div>
                </div>
                </div>
                 <!-- fine riga -->
                                <!-- riga -->
<div id ="enable_value_cl_alarm_high">
                <div class="row-fluid">
               	<div class="span3">
                       <div id="riga1_cl_alarm_high" class="control-group">
                           <h5 style="padding-top:10px"><asp:literal ID = "Literal7"  text="Min/max - High Cl" runat="server" meta:resourcekey="Literal7Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_cl_alarm_high" onblur="javascript: Changed_channel( 'value_cl_alarm_high','riga1_cl_alarm_high',max_cl_value, min_cl_value,max_fix_value_cl );" class="span12"  runat="server" MaxLength="5" meta:resourcekey="value_cl_alarm_highResource1" ></asp:textbox>
                </div>
                       </div>

                   
                </div>
</div>
                 <!-- fine riga -->
<!-- riga -->
                <div class="row-fluid">
               	<div class="span12">
                       <h5 style="padding-top:10px"><asp:literal ID = "Literal6"  text="Low Range Alarm Cl" runat="server" meta:resourcekey="Literal6Resource1"></asp:literal></h5>
<div class="controlli_box">
                    <asp:radiobutton ID="cl_alarm_low_disable"  runat="server"  GroupName="GROUP5" meta:resourcekey="cl_alarm_low_disableResource1"></asp:radiobutton>
</div>
<div class="controlli_testo_box">
                    <asp:literal runat="server" text ="Disable Low" meta:resourcekey="LiteralResource3"></asp:literal>
</div>
<div class="controlli_box">
                    <asp:radiobutton ID="cl_alarm_low_enable"  runat="server"  GroupName="GROUP5" meta:resourcekey="cl_alarm_low_enableResource1"></asp:radiobutton>
</div>
<div class="controlli_testo_box">
                       <asp:literal runat="server" text ="Enable Low" meta:resourcekey="LiteralResource4"></asp:literal>
</div>
                       </div>

                    
                </div>
                 <!-- fine riga -->                                
                                   <!-- riga -->
<div id ="enable_value_cl_alarm_low">
                <div class="row-fluid">
               	<div class="span3">
                       <div id="riga1_cl_alarm_low" class="control-group">
                           <h5 style="padding-top:10px"><asp:literal ID = "Literal10"  text="Min/max - Low Cl" runat="server" meta:resourcekey="Literal10Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_cl_alarm_low" onblur="javascript: Changed_channel( 'value_cl_alarm_low','riga1_cl_alarm_low',max_cl_value, min_cl_value,max_fix_value_cl );" class="span12"  runat="server" MaxLength="5" meta:resourcekey="value_cl_alarm_lowResource1" ></asp:textbox>
                </div>
                       </div>

                   
                </div>
</div>
                 <!-- fine riga -->
<!-- riga -->
<div id ="enable_value_cl_alarm_stop">
                <div class="row-fluid">
               	<div class="span12">
                       <h5 style="padding-top:10px"><asp:literal ID = "Literal8"  text="Mode" runat="server" meta:resourcekey="Literal8Resource1"></asp:literal></h5>
<div class="controlli_box">
                    <asp:radiobutton ID="cl_alarm_mode_dose"  runat="server"  GroupName="GROUP6" meta:resourcekey="cl_alarm_mode_doseResource1"></asp:radiobutton>
</div>
<div class="controlli_testo_box">
                    <asp:literal runat="server" text ="Dose" meta:resourcekey="LiteralResource5"></asp:literal>
</div>
<div class="controlli_box">
                    <asp:radiobutton ID="cl_alarm_mode_stop"  runat="server"  GroupName="GROUP6" meta:resourcekey="cl_alarm_mode_stopResource1"></asp:radiobutton>
</div>
<div class="controlli_box">
                       <asp:literal runat="server" text ="Stop" meta:resourcekey="LiteralResource6"></asp:literal>
</div>
                       </div>

                    
                </div>
<!-- fine riga -->                                
<!-- riga -->

                <div class="row-fluid">
               	<div class="span3">
                       <div id="riga1_cl_alarm_stop" class="control-group">
                           <h5 style="padding-top:10px"><asp:literal ID = "Literal13"  text="Time (min)" runat="server" meta:resourcekey="Literal13Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_cl_alarm_stop" onblur="javascript: Changed_channel( 'value_cl_alarm_stop','riga1_cl_alarm_stop',99, 0,0 );" class="span12"  runat="server" MaxLength="2" meta:resourcekey="value_cl_alarm_stopResource1" ></asp:textbox>
                </div>
                       </div>

                   
                </div>
</div>
<!-- fine riga -->

                    </div>
                </div>
<!-- tab 1 stop-->
                    </div>
                </div>
                 <div id="salva" class="btn-primary">
                   <b class="btn-primary btn-icon glyphicons ok"><asp:button runat="server" ID="save_rangealarmlds_new" class="btn-primary" data-layout="center" data-type="confirm" data-toggle="notyfy" text="Salva e carica i dati" Font-Bold="True" meta:resourcekey="save_rangealarmlds_newResource1" /><i></i></b>
                </div>

            </div>
        </div>
    <script type="text/javascript" src="lds/validator_lds_rangealarm.js"></script>
        <script type="text/javascript" src="common/validator_general_notify.js"></script>
    <script src="theme/scripts/demo/notifications.js"></script>

    </form>
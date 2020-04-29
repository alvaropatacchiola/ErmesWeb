<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ma_outputs.aspx.vb" Inherits="ermes_web_20.ma_outputs" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>

<form id="form" runat="server" method="post" action="lds/ma_outputs.aspx">
    <h3><asp:literal runat="server" text ="mA Output LDS" ID="message_channel" meta:resourcekey="message_channelResource1"></asp:literal></h3>
    <div class="innerLR">
        <div class="box-generic">
            <div class="box-generic">
                                       	<!-- Tabs Heading -->
<div class="tabsbar tabsbar-2">
			<ul class="row-fluid row-merge">
            
                <li class="span2 active" ><a id="tab_ld_sp1" href="#tab_ld_sp1_1"  data-toggle="tab"><asp:literal text="cL"  runat="server" ID="tabld1_1" meta:resourcekey="tabld1_1Resource1" ></asp:literal></a></li>
                <li class="span2"><a id="tab_ld_sp2" href="#tab_ld_sp2_2" data-toggle="tab"><asp:literal text="Temperature" runat="server" ID="tabld1_2" meta:resourcekey="tabld1_2Resource1"></asp:literal></a></li>
			</ul>
		</div>
		<!-- // Tabs Heading END -->

                <div class="tab-content">

<!-- tab 2 start-->
			<div class="tab-pane active" id="tab_ld_sp1_1">
                <div  class="box-generic">
                                 <!-- riga -->
                <div class="row-fluid">
               	<div class="span12">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal1"  text="cL mA" runat="server" meta:resourcekey="Literal1Resource1"></asp:literal></h5>
<div class="controlli_box">
                    <asp:radiobutton ID="cl_0_20"  runat="server"  GroupName="GROUP2" meta:resourcekey="cl_0_20Resource1"></asp:radiobutton>
</div>
<div class="controlli_testo_box">
                    <asp:literal runat="server" text ="0 / 20 mA" meta:resourcekey="LiteralResource1"></asp:literal>
</div>
<div class="controlli_box">
                    <asp:radiobutton ID="cl_4_20"  runat="server"  GroupName="GROUP2" meta:resourcekey="cl_4_20Resource1"></asp:radiobutton>
</div>
<div class="controlli_testo_box">
                       <asp:literal runat="server" text ="4 / 20 mA" meta:resourcekey="LiteralResource2"></asp:literal>
</div>
                </div>
                </div>
                 <!-- fine riga -->
                                <!-- riga -->
                <div class="row-fluid">
               	<div class="span3">
                       <div id="riga1_cl_ma_max" class="control-group">
                           <h5 style="padding-top:10px"><asp:literal ID = "Literal5"  text="max mA" runat="server" meta:resourcekey="Literal5Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_cl_ma_max" onblur="javascript: Changed_channel( 'value_cl_ma_max','riga1_cl_ma_max',max_cl_value, min_cl_value,max_fix_value_cl );" class="span12"  runat="server" meta:resourcekey="value_cl_ma_maxResource1" ></asp:textbox>
                </div>
                       </div>

                   
                </div>
                 <!-- fine riga -->
<!-- riga -->
                <div class="row-fluid">
               	<div class="span3">
                       <div id="riga1_cl_ma_min" class="control-group">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal6"  text="min mA" runat="server" meta:resourcekey="Literal6Resource1"></asp:literal></h5>

                       <asp:textbox ID="value_cl_ma_min" onblur="javascript: Changed_channel( 'value_cl_ma_min','riga1_cl_ma_min',max_cl_value, min_cl_value,max_fix_value_cl );" class="span12"  runat="server" meta:resourcekey="value_cl_ma_minResource1" ></asp:textbox>
                </div>
                       </div>

                    
                </div>
                 <!-- fine riga -->                                
    
                    </div>
                </div>
<!-- tab 2 stop-->
<!-- tab 3 start-->
			<div class="tab-pane" id="tab_ld_sp2_2">
                <div  class="box-generic">
                                 <!-- riga -->
                <div class="row-fluid">
               	<div class="span12">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal4"  text="Temperature mA" runat="server" meta:resourcekey="Literal4Resource1"></asp:literal></h5>
<div class="controlli_box">
                    <asp:radiobutton ID="temperature_0_20"  runat="server"  GroupName="GROUP3" meta:resourcekey="temperature_0_20Resource1"></asp:radiobutton>
</div>
<div class="controlli_testo_box">
                    <asp:literal runat="server" text ="0 / 20 mA" meta:resourcekey="LiteralResource3"></asp:literal>
</div>
<div class="controlli_box">
                    <asp:radiobutton ID="temperature_4_20"  runat="server"  GroupName="GROUP3" meta:resourcekey="temperature_4_20Resource1"></asp:radiobutton>
</div>
<div class="controlli_testo_box">
                       <asp:literal runat="server" text ="4 / 20 mA" meta:resourcekey="LiteralResource4"></asp:literal>
</div>
                </div>
                </div>
                 <!-- fine riga -->
                                <!-- riga -->
                <div class="row-fluid">
               	<div class="span3">
                       <div id="riga1_temperature_ma_max" class="control-group">
                           <h5 style="padding-top:10px"><asp:literal ID = "Literal9"  text="max Temperature (°C)" runat="server" meta:resourcekey="Literal9Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_temperature_ma_max" onblur="javascript: Changed_channel( 'value_temperature_ma_max','riga1_temperature_ma_max',max_temperature_value, min_temperature_value,max_fix_value_temperature );" class="span12"  runat="server" meta:resourcekey="value_temperature_ma_maxResource1" ></asp:textbox>
                </div>
                       </div>

                   
                </div>
                 <!-- fine riga -->
<!-- riga -->
                <div class="row-fluid">
               	<div class="span3">
                       <div id="riga1_temperature_ma_min" class="control-group">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal10"  text="min Temperature (°C)" runat="server" meta:resourcekey="Literal10Resource1"></asp:literal></h5>

                       <asp:textbox ID="value_temperature_ma_min" onblur="javascript: Changed_channel( 'value_temperature_ma_min','riga1_temperature_ma_min',max_temperature_value, min_temperature_value,max_fix_value_temperature );" class="span12"  runat="server" meta:resourcekey="value_temperature_ma_minResource1" ></asp:textbox>
                </div>
                       </div>

                    
                </div>
                 <!-- fine riga -->                                
    
                    </div>
                </div>
<!-- tab 3 stop-->

                    </div>

                <div id="salva" class="btn-primary">
                   <b class="btn-primary btn-icon glyphicons ok"><asp:button runat="server" ID="save_maoutputlds_new" class="btn-primary" data-layout="center" data-type="confirm" data-toggle="notyfy" text="Salva e carica i dati" Font-Bold="True" meta:resourcekey="save_maoutputlds_newResource1" /><i></i></b>
                </div>
            </div>
        </div>
    <script type="text/javascript" src="lds/validator_lds_maoutput.js"></script>
            <script type="text/javascript" src="common/validator_general_notify.js"></script>
<script src="theme/scripts/demo/notifications.js"></script>

    </form>

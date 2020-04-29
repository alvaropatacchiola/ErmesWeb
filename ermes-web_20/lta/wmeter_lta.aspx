<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="wmeter_lta.aspx.vb" Inherits="ermes_web_20.wmeter_lta" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>
<form id="form" runat="server" method="post" action="lta/wmeter_lta.aspx">
    <h3><asp:literal runat="server" text ="Water Meter" ID="message_channel" meta:resourcekey="message_channelResource1"></asp:literal></h3>
    <div class="innerLR">
        <div class="box-generic">
            <div class="box-generic">
                                       	<!-- Tabs Heading -->
<!--<div class="tabsbar tabsbar-2">
			<ul class="row-fluid row-merge">
            
                <li class="span2 active" ><a id="tab_ld_sp1" href="#tab_ld_sp1_1"  data-toggle="tab"><asp:literal text="pH"  runat="server" ID="tabld1_1" meta:resourcekey="tabld1_1Resource1" ></asp:literal></a></li>
                <li class="span2"><a id="tab_ld_sp2" href="#tab_ld_sp2_2" data-toggle="tab"><asp:literal text="cL" runat="server" ID="tabld1_2" meta:resourcekey="tabld1_2Resource1"></asp:literal></a></li>
                <li class="span2"><a id="tab_ld_sp3" href="#tab_ld_sp3_3" data-toggle="tab"><asp:literal text="Temperature" runat="server" ID="tabld1_3" meta:resourcekey="tabld1_3Resource1"></asp:literal></a></li>
                <asp:placeholder runat="server" ID="terzo_canale_ma_tab">
                <li  class="span2"><a id="tab_ld_sp4" href="#tab_ld_sp4_4" data-toggle="tab"><asp:literal text="mV" runat="server" ID="tabld1_4" meta:resourcekey="tabld1_4Resource1"></asp:literal></a></li>
                </asp:placeholder>
			</ul>
		</div>-->
		<!-- // Tabs Heading END -->

                <div class="tab-content">
                       <!-- tab 1 start-->
			<div class="tab-pane active" id="tab_ld_sp1_1">
                <div  class="box-generic">
                                 <!-- riga -->
                <div class="row-fluid">
               	<div class="span12">
              <h5 style="padding-top:10px"><asp:literal ID = "Label7"  text="Mode" runat="server" meta:resourcekey="Label7Resource1" ></asp:literal></h5>
<div class="controlli_box">
                    <asp:radiobutton ID="imp_lit"  runat="server"  GroupName="GROUP1" meta:resourcekey="imp_litResource1" ></asp:radiobutton>
</div>
<div class="controlli_testo_box">
                    <asp:literal runat="server" text ="Imp / Lit" meta:resourcekey="LiteralResource1"></asp:literal>
</div>
<div class="controlli_box">
                    <asp:radiobutton ID="lit_imp"  runat="server"  GroupName="GROUP1" meta:resourcekey="lit_impResource1"></asp:radiobutton>
</div>
<div class="controlli_testo_box">
                       <asp:literal runat="server" text ="Lit / Imp" meta:resourcekey="LiteralResource2" ></asp:literal>
</div>

                       <div class="controlli_box">
                    <asp:radiobutton ID="mA"  runat="server"  GroupName="GROUP1" meta:resourcekey="mAResource1" ></asp:radiobutton>
</div>
<div class="controlli_testo_box">
                       <asp:literal runat="server" text ="mA" meta:resourcekey="LiteralResource3" ></asp:literal>
</div>



                </div>
                </div>
                 <!-- fine riga -->
                                <!-- riga -->
                <div class="row-fluid">
               	<div class="span3">
                       <div id="riga1_value" class="control-group">
                           <h5 style="padding-top:10px"><asp:literal ID = "Literal4"  text="Value" runat="server" meta:resourcekey="Literal4Resource1" ></asp:literal></h5>
                       <asp:textbox ID="value_wm" onblur="javascript: Changed_channel( 'value_wm','riga1_value',1200, 0,1 );" class="span12"  runat="server" MaxLength="6" meta:resourcekey="value_ph_ma_maxResource1" ></asp:textbox>
                </div>
                       </div>

                   
                </div>
                 <!-- fine riga -->
<!-- riga -->
                    

                    <div class="row-fluid">
               	<div class="span12">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal5"  text="Resolution" runat="server" meta:resourcekey="Label8Resource1" ></asp:literal></h5>
<div class="controlli_box">
                    <asp:radiobutton ID="ZeromA"  runat="server"  GroupName="GROUP2" meta:resourcekey="ZeromAResource1" ></asp:radiobutton>
</div>
<div class="controlli_testo_box">
                    <asp:literal runat="server" text ="0 / 20 mA" meta:resourcekey="LiteralResource21"></asp:literal>
</div>
<div class="controlli_box">
                    <asp:radiobutton ID="QuattromA"  runat="server"  GroupName="GROUP2" meta:resourcekey="QuattromAResource1"></asp:radiobutton>
</div>
<div class="controlli_testo_box">
                       <asp:literal runat="server" text ="4 / 20 mA" meta:resourcekey="LiteralResource22" ></asp:literal>
</div>

                  



                </div>
                </div>

                <div class="row-fluid">
               	<div class="span3">
                       <div id="riga1_resolution" class="control-group">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal8"  text="Max Flow [cmb/h]" runat="server" meta:resourcekey="Literal7Resource1" ></asp:literal></h5>

                       <asp:textbox ID="value_resol" onblur="javascript: Changed_channel( 'value_resol','riga1_resolution',9999, 0,1 );" class="span12"  runat="server" MaxLength="6" meta:resourcekey="value_ph_ma_minResource1" ></asp:textbox>
                </div>
                       </div>

                    
                </div>
                 <!-- fine riga -->                                
    
                    
                    <!-- riga -->
                <div class="row-fluid">
               	<div class="span3">
                       <div id="riga1_timeout" class="control-group">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal9"  text="Timeout" runat="server" meta:resourcekey="Literal8Resource1" ></asp:literal></h5>

                       <asp:textbox ID="value_timeout" onblur="javascript: Changed_channel( 'value_timeout','riga1_timeout',20, 0,0 );" class="span12"  runat="server" MaxLength="3" meta:resourcekey="value_ph_ma_minResource1"  ></asp:textbox>
                </div>
                       </div>

                    
                </div>
                 <!-- fine riga -->  

                    
                    <div 
                    </div>
                </div>
<!-- tab 1 stop-->
<!-- tab 2 start-->
			
<!-- tab 2 stop-->
<!-- tab 3 start-->
			
<!-- tab 3 stop-->
<!-- tab 4 start-->
				
<!-- tab 4 stop-->
                    </div>

                <div id="salva" class="btn-primary">
                   <b class="btn-primary btn-icon glyphicons ok"><asp:button runat="server" ID="save_wmeterlta_new" class="btn-primary" data-layout="center" data-type="confirm" data-toggle="notyfy" text="Salva e carica i dati" Font-Bold="True" meta:resourcekey="save_wmeterlta_newResource1" /><i></i></b>
                </div>
            </div>
        </div>
    <script type="text/javascript" src="lta/validator_lta_wmeter.js"></script>
    <script type="text/javascript" src="common/validator_general_notify.js"></script>
<script src="theme/scripts/demo/notifications.js"></script>

    </form>
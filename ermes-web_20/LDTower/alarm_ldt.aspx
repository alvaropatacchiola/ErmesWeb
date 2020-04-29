<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="alarm_ldt.aspx.vb" Inherits="ermes_web_20.alarm_ldt" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>

<form id="form" runat="server"  method="post" action="LDTower/alarm_ldt.aspx">        

    <h3><asp:literal runat="server" text ="Alarm CoolTrol" ID="message_channel" meta:resourcekey="message_channelResource1"></asp:literal></h3>
<div class="innerLR">
    <div class="box-generic">
       
        <div class="tab-content">
                <div  class="box-generic">
<!-- riga -->

                <div class="row-fluid">
               	<div class="span3">
                       <div class="control-group">
                           <h5 style="padding-top:10px"><asp:literal ID = "Label7"  text="Low Conductivity" runat="server" meta:resourcekey="Label7Resource1"></asp:literal></h5>
                    <asp:radiobutton ID="cond_low_off" style="margin: 5px 10px 10px 0px;" runat="server"  GroupName="GROUP1" meta:resourcekey="cond_low_offResource1"></asp:radiobutton>
                    <asp:literal runat="server" text ="Off" meta:resourcekey="LiteralResource1"></asp:literal>
                    <asp:radiobutton ID="cond_low_track" style="margin: 5px 10px 10px 0px;" runat="server"  GroupName="GROUP1" meta:resourcekey="cond_low_trackResource1"></asp:radiobutton>
                       <asp:literal runat="server" text ="Track" meta:resourcekey="LiteralResource2"></asp:literal>
                    <asp:radiobutton ID="cond_low_absolute" style="margin: 5px 10px 10px 0px;" runat="server"  GroupName="GROUP1" meta:resourcekey="cond_low_absoluteResource1"></asp:radiobutton>
                       <asp:literal runat="server" text ="Absolute" meta:resourcekey="LiteralResource3"></asp:literal>

                </div>
                       </div>
<div id ="enable_cond_low_abs">

 	            <div class="span3">
                       <div id="riga_cond_low_abs" class="control-group">
                        <h5 style="padding-top:10px"><asp:literal ID = "Literal4"  text="uS" runat="server" meta:resourcekey="Literal4Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_cond_low_abs" onblur="javascript: Changed_channel( 'value_cond_low_abs','riga_cond_low_abs',max_cond, 0,0);" class="span12"  runat="server" MaxLength="4" meta:resourcekey="value_cond_low_absResource1" ></asp:textbox>
                        </div>
                </div>
      </div>

<div id ="enable_cond_low_track">
                  <div class="span3">
                       <div id="riga_cond_low_track" class="control-group">
                        <h5 style="padding-top:10px"><asp:literal ID = "Literal1"  text="uS" runat="server" meta:resourcekey="Literal1Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_cond_low_track" onblur="javascript: Changed_channel( 'value_cond_low_track','riga_cond_low_track',max_cond, 0,0);" class="span12"  runat="server" MaxLength="4" meta:resourcekey="value_cond_low_trackResource1" ></asp:textbox>
                </div>
                       </div>
            </div>        
                     
                </div>
<!-- fine riga -->
<!-- riga -->

          <div class="row-fluid">
               	<div class="span3">
                       <div class="control-group">
                           <h5 style="padding-top:10px"><asp:literal ID = "Literal5"  text="High Conductivity" runat="server" meta:resourcekey="Literal5Resource1"></asp:literal></h5>
                    <asp:radiobutton ID="cond_high_off" style="margin: 5px 10px 10px 0px;" runat="server"  GroupName="GROUP2" meta:resourcekey="cond_high_offResource1"></asp:radiobutton>
                    <asp:literal runat="server" text ="Off" meta:resourcekey="LiteralResource4"></asp:literal>
                    <asp:radiobutton ID="cond_high_track" style="margin: 5px 10px 10px 0px;" runat="server"  GroupName="GROUP2" meta:resourcekey="cond_high_trackResource1"></asp:radiobutton>
                       <asp:literal runat="server" text ="Track" meta:resourcekey="LiteralResource5"></asp:literal>
                    <asp:radiobutton ID="cond_high_absolute" style="margin: 5px 10px 10px 0px;" runat="server"  GroupName="GROUP2" meta:resourcekey="cond_high_absoluteResource1"></asp:radiobutton>
                       <asp:literal runat="server" text ="Absolute" meta:resourcekey="LiteralResource6"></asp:literal>

                </div>
                       </div>
        <div id ="enable_cond_high_abs">
 	            <div class="span3">
                       <div id="riga_cond_high_abs" class="control-group">
                        <h5 style="padding-top:10px"><asp:literal ID = "Literal9"  text="uS" runat="server" meta:resourcekey="Literal9Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_cond_high_abs" onblur="javascript: Changed_channel( 'value_cond_high_abs','riga_cond_high_abs',max_cond, 0,0 );" class="span12"  runat="server" MaxLength="4" meta:resourcekey="value_cond_high_absResource1" ></asp:textbox>
                </div>
            </div>

        </div>
            <div id ="enable_cond_high_track">
                     <div class="span3">
                       <div id="riga_cond_high_track" class="control-group">
                        <h5 style="padding-top:10px"><asp:literal ID = "Literal2"  text="uS" runat="server" meta:resourcekey="Literal2Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_cond_high_track" onblur="javascript: Changed_channel( 'value_cond_high_track','riga_cond_high_track',max_cond, 0,0 );" class="span12"  runat="server" MaxLength="4" meta:resourcekey="value_cond_high_trackResource1" ></asp:textbox>
                        </div>
                       </div>
                   
                </div>
         </div>

<!-- fine riga -->

<!-- riga -->
  <div class="row-fluid">
 	            <div class="span3">
                       <div class="control-group">
                           <h5 style="padding-top:10px"><asp:literal ID = "Literal33"  text="Chemical Levels" runat="server" meta:resourcekey="Literal33Resource1"></asp:literal></h5>
                    <asp:radiobutton ID="chemical_levels_out_no" style="margin: 5px 10px 10px 0px;" runat="server"  GroupName="GROUP3" meta:resourcekey="chemical_levels_out_noResource1"></asp:radiobutton>
                    <asp:literal runat="server" text ="N.O." meta:resourcekey="LiteralResource21"></asp:literal>
                    <asp:radiobutton ID="chemical_levels_out_nc" style="margin: 5px 10px 10px 0px;" runat="server"  GroupName="GROUP3" meta:resourcekey="chemical_levels_out_ncResource1"></asp:radiobutton>
                       <asp:literal runat="server" text ="N.C." meta:resourcekey="LiteralResource22"></asp:literal>
                </div>
                       </div>
            </div>

<!-- fine riga -->

<!-- riga -->
                <div class="row-fluid">
               	<div class="span3">
                       <div class="control-group">
                           <h5 style="padding-top:10px"><asp:literal ID = "Literal30"  text=" Bleed Timeout" runat="server" meta:resourcekey="Literal30Resource1"></asp:literal></h5>
                    <asp:radiobutton ID="bleed_timeout_stop" style="margin: 5px 10px 10px 0px;" runat="server"  GroupName="GROUP4" meta:resourcekey="bleed_timeout_stopResource1"></asp:radiobutton>
                    <asp:literal runat="server" text ="Stop" meta:resourcekey="LiteralResource19"></asp:literal>
                    <asp:radiobutton ID="bleed_timeout_no" style="margin: 5px 10px 10px 0px;" runat="server"  GroupName="GROUP4" meta:resourcekey="bleed_timeout_noResource1"></asp:radiobutton>
                       <asp:literal runat="server" text ="No" meta:resourcekey="LiteralResource20"></asp:literal>

                </div>
                       </div>

                </div>

             
               
<!-- fine riga -->
   


<!-- riga -->

                <div class="row-fluid">
               	<div class="span3">
                       <div class="control-group">
                           <h5 style="padding-top:10px"><asp:literal ID = "Literal36"  text="No Flow" runat="server" meta:resourcekey="Literal36Resource1"></asp:literal></h5>
                    <asp:radiobutton ID="no_flow_stop" style="margin: 5px 10px 10px 0px;" runat="server"  GroupName="GROUP5" meta:resourcekey="no_flow_stopResource1"></asp:radiobutton>
                    <asp:literal runat="server" text ="Stop" meta:resourcekey="LiteralResource23"></asp:literal>
                    <asp:radiobutton ID="no_flow_no" style="margin: 5px 10px 10px 0px;" runat="server"  GroupName="GROUP5" meta:resourcekey="no_flow_noResource1"></asp:radiobutton>
                       <asp:literal runat="server" text ="No" meta:resourcekey="LiteralResource24"></asp:literal>
                </div>
                       </div>

                </div>

                <div class="row-fluid">
 	            <div class="span3">
                       <div class="control-group">
                           <h5 style="padding-top:10px"><asp:literal ID = "Literal39"  text="Out Alarm" runat="server" meta:resourcekey="Literal39Resource1"></asp:literal></h5>
                    <asp:radiobutton ID="out_alarm_enable" style="margin: 5px 10px 10px 0px;" runat="server"  GroupName="GROUP6" meta:resourcekey="out_alarm_enableResource1"></asp:radiobutton>
                    <asp:literal runat="server" text ="Enable" meta:resourcekey="LiteralResource25"></asp:literal>
                    <asp:radiobutton ID="out_alarm_disable" style="margin: 5px 10px 10px 0px;" runat="server"  GroupName="GROUP6" meta:resourcekey="out_alarm_disableResource1"></asp:radiobutton>
                       <asp:literal runat="server" text ="Disable" meta:resourcekey="LiteralResource26"></asp:literal>
                </div>
                       </div>
                   
                </div>
<!-- fine riga -->
    </div>
                 
</div>

            </div>
                    <div id="salva" class="btn-primary">
                   <b class="btn-primary btn-icon glyphicons ok"><asp:button runat="server" ID="save_alarm_ldtower_new" class="btn-primary" data-layout="center" data-type="confirm" data-toggle="notyfy" text="Salva e carica i dati" Font-Bold="True" meta:resourcekey="save_alarm_ldtower_newResource1" /><i></i></b>

        </div>

        </div>
 



    <!--------------------------- DA MODIFICARE L'INDIRIZZO DEL FILE VALIDATOR -------------------------------------------->


    <script type="text/javascript" src="LDTower/validator_alarm_ldt.js"></script>
                                <script type="text/javascript" src="common/validator_general_notify.js"></script>
<script src="theme/scripts/demo/notifications.js"></script>

</form>

<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Self_clean.aspx.vb" Inherits="ermes_web_20.Self_clean" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>
<form id="form" runat="server"  method="post" action="lds/Self_clean.aspx">
    <h3><asp:literal runat="server" text ="Log Setup" ID="message_channel" meta:resourcekey="message_channelResource1"></asp:literal></h3>
    <div class="innerLR">
        <div class="box-generic">
            <div class="box-generic">
                <div class="tab-content">
                 <!-- tab 1 start-->
			<div class="tab-pane active" id="tab_ld_sp1_1">
                <div  class="box-generic">
                                 <!-- riga -->
                <div class="row-fluid">
               	<div class="span12">
              <h5 style="padding-top:10px"><asp:literal ID = "Label7"  text="Cycle Time:" runat="server" meta:resourcekey="Label7Resource1"></asp:literal></h5>
<div class="controlli_box">
                    <asp:radiobutton ID="Self0h"  runat="server"  GroupName="GROUP1" meta:resourcekey="Self0hResource1"></asp:radiobutton>
</div>

<div class="controlli_testo_box">
                    <asp:literal runat="server" text ="0 hours" meta:resourcekey="LiteralResource1"></asp:literal>
</div>
<div class="controlli_box">
                    <asp:radiobutton ID="Self2h"  runat="server"  GroupName="GROUP1" meta:resourcekey="Self2hResource1"></asp:radiobutton>
</div>
<div class="controlli_testo_box">
                       <asp:literal runat="server" text ="2 hours" meta:resourcekey="LiteralResource2"></asp:literal>
</div>
<div class="controlli_box">
                    <asp:radiobutton ID="Self6h"  runat="server"  GroupName="GROUP1" meta:resourcekey="Self6hResource1"></asp:radiobutton>
</div>
<div class="controlli_testo_box">
                       <asp:literal runat="server" text ="6 hours" meta:resourcekey="LiteralResource3"></asp:literal>
</div>
<div class="controlli_box">
                    <asp:radiobutton ID="Self12h"  runat="server"  GroupName="GROUP1" meta:resourcekey="Self12hResource1"></asp:radiobutton>
</div>
<div class="controlli_testo_box">
                       <asp:literal runat="server" text ="12 hours" meta:resourcekey="LiteralResource4"></asp:literal>
</div>
<div class="controlli_box">
                    <asp:radiobutton ID="Self1D"  runat="server"  GroupName="GROUP1" meta:resourcekey="Self1DResource1"></asp:radiobutton>
</div>
<div class="controlli_testo_box">
                       <asp:literal runat="server" text ="1 day" meta:resourcekey="LiteralResource5"></asp:literal>
</div>
                       <div class="controlli_box">
                    <asp:radiobutton ID="Self2D"  runat="server"  GroupName="GROUP1" meta:resourcekey="Self2DResource1"></asp:radiobutton>
</div>
<div class="controlli_testo_box">
                       <asp:literal runat="server" text ="2 days" meta:resourcekey="LiteralResource6"></asp:literal>
</div>
                       <div class="controlli_box">
                    <asp:radiobutton ID="Self3D"  runat="server"  GroupName="GROUP1" meta:resourcekey="Self3DResource1"></asp:radiobutton>
</div>
<div class="controlli_testo_box">
                       <asp:literal runat="server" text ="3 days" meta:resourcekey="LiteralResource7"></asp:literal>
</div>
                       <div class="controlli_box">
                    <asp:radiobutton ID="Self4D"  runat="server"  GroupName="GROUP1" meta:resourcekey="Self4DResource1"></asp:radiobutton>
</div>
<div class="controlli_testo_box">
                       <asp:literal runat="server" text ="4 days" meta:resourcekey="LiteralResource8"></asp:literal>
</div>
                       <div class="controlli_box">
                    <asp:radiobutton ID="Self5D"  runat="server"  GroupName="GROUP1" meta:resourcekey="Self5DResource1"></asp:radiobutton>
</div>
<div class="controlli_testo_box">
                       <asp:literal runat="server" text ="5 days" meta:resourcekey="LiteralResource9"></asp:literal>
</div>
                       <div class="controlli_box">
                    <asp:radiobutton ID="Self6D"  runat="server"  GroupName="GROUP1" meta:resourcekey="Self6DResource1"></asp:radiobutton>
</div>
<div class="controlli_testo_box">
                       <asp:literal runat="server" text ="6 days" meta:resourcekey="LiteralResource10"></asp:literal>
</div>
                       <div class="controlli_box">
                    <asp:radiobutton ID="Self7D"  runat="server"  GroupName="GROUP1" meta:resourcekey="Self7DResource1"></asp:radiobutton>
</div>
<div class="controlli_testo_box">
                       <asp:literal runat="server" text ="7 days" meta:resourcekey="LiteralResource11"></asp:literal>
</div>
                       <div class="controlli_box">
                    <asp:radiobutton ID="Self8D"  runat="server"  GroupName="GROUP1" meta:resourcekey="Self8DResource1"></asp:radiobutton>
</div>
<div class="controlli_testo_box">
                       <asp:literal runat="server" text ="8 days" meta:resourcekey="LiteralResource12"></asp:literal>
</div>
                       <div class="controlli_box">
                    <asp:radiobutton ID="Self9D"  runat="server"  GroupName="GROUP1" meta:resourcekey="Self9DResource1"></asp:radiobutton>
</div>
<div class="controlli_testo_box">
                       <asp:literal runat="server" text ="9 days" meta:resourcekey="LiteralResource13"></asp:literal>
</div>
                       <div class="controlli_box">
                    <asp:radiobutton ID="Self10D"  runat="server"  GroupName="GROUP1" meta:resourcekey="Self10DResource1"></asp:radiobutton>
</div>
<div class="controlli_testo_box">
                       <asp:literal runat="server" text ="10 days" meta:resourcekey="LiteralResource14"></asp:literal>
</div>



                </div>
                </div>
                 <!-- fine riga -->
                                <!-- riga -->

             
</div>
                 <!-- fine riga -->

<!-- tab 1 stop-->


     
               

                        <div class="row-fluid">
               	<div class="span3">
                       <div id="riga1_clean" class="control-group">
                           <h5 style="padding-top:10px"><asp:literal ID = "Literal1"  text="Clean Time min:" runat="server" meta:resourcekey="CleanResource2"></asp:literal></h5>
                       <asp:textbox ID="value_clean" onblur="javascript: Changed_channel( 'value_clean','riga1_clean',999, 0,0 );" class="span12"  runat="server" MaxLength="3" meta:resourcekey="value_cleanResource1" ></asp:textbox>
                </div>
                       </div>

                   
                </div>


                   <div class="row-fluid">
               	<div class="span3">
                       <div id="riga1_restore" class="control-group">
                           <h5 style="padding-top:10px"><asp:literal ID = "Literal5"  text="Restore Time min:" runat="server" meta:resourcekey="RestoreResource1"></asp:literal></h5>
                       <asp:textbox ID="value_restore" onblur="javascript: Changed_channel( 'value_restore','riga1_restore',999, 0,0 );" class="span12"  runat="server" MaxLength="3" meta:resourcekey="value_restoreResource1" ></asp:textbox>
                </div>
                       </div>

                   
                </div>

<div class="row-fluid">
               	<div class="span3">

<div class="controlli_box">
                    <asp:radiobutton ID="CleanAlarmYes"  runat="server"  GroupName="GROUP2" meta:resourcekey="CleanResource1"></asp:radiobutton>
</div>
<div class="controlli_testo_box">
                       <asp:literal runat="server" text ="Clean on Alarm:Yes" meta:resourcekey="LiteralResource25"></asp:literal>
</div>
<div class="controlli_box">
                    <asp:radiobutton ID="CleanAlarmNo"  runat="server"  GroupName="GROUP2" meta:resourcekey="CleanResource1"></asp:radiobutton>
</div>
<div class="controlli_testo_box">
                       <asp:literal runat="server" text ="Clean on Alarm:No" meta:resourcekey="LiteralResource26"></asp:literal>
</div>
</div>
    </div>

               
             </div>
             <div id="salva" class="btn-primary">
                   <b class="btn-primary btn-icon glyphicons ok"><asp:button runat="server" ID="save_Self_new" class="btn-primary" data-layout="center" data-type="confirm" data-toggle="notyfy" text="Salva e carica i dati" Font-Bold="True" meta:resourcekey="save_Self_newResource1" /><i></i></b>
                </div>
            </div>
        </div>
    <script type="text/javascript" src="lds/validator_Self.js"></script>
   <script src="theme/scripts/demo/calendar_new.js"></script>
    <link href="bootstrap/css/jquery-ui-timepicker-addon.css" rel="stylesheet" />
 <script type="text/javascript" src="common/validator_general_notify.js"></script>
<script src="theme/scripts/demo/notifications.js"></script>

    </form>

<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="cicli_ltb.aspx.vb" Inherits="ermes_web_20.cicli_ltb" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>
<form id="form" runat="server" method="post" action="ltb/cicli_ltb.aspx">
    <h3><asp:literal runat="server" text =" " ID="message_channel" meta:resourcekey="message_channelResource1"></asp:literal></h3>
    <div class="innerLR">
        <div class="box-generic">
            <div class="box-generic">
                <div class="tab-content">
                 <!-- tab 1 start-->
			<div class="tab-pane active" id="tab_ld_sp1_1">
                <div  class="box-generic">
                                 <!-- riga -->
                
                 <!-- fine riga -->
                                <!-- riga -->
<div id ="enable_value_cicli">
                <div class="row-fluid">
               	<div class="span3">
                       <div id="riga1_cicli" class="control-group">
                           <h5 style="padding-top:10px"><asp:literal ID = "Literal4"  text="Cicli" runat="server" meta:resourcekey="Literal4Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_cicli" onblur="javascript: Changed_channel( 'value_cicli','riga1_cicli',9999999999, 0,0 );" class="span12"  runat="server" MaxLength="10" meta:resourcekey="value_cicliResource1" ></asp:textbox>
                </div>
                       </div>

                   
                </div>
</div>
                 <!-- fine riga -->

    <asp:placeholder runat="server" ID="enable_cc_HCl">
                <div class="row-fluid">
               	<div class="span3">
                       <div id="riga2_cc_HCl" class="control-group">
                           <h5 style="padding-top:10px"><asp:literal ID = "Literal1"  text="HCl cc:" runat="server" meta:resourcekey="Literal4Resource1B"></asp:literal></h5>
                       <asp:textbox ID="value_cc_HCl" onblur="javascript: Changed_channel( 'value_cicli','riga1_cicli',9999999999, 0,0 );" class="span12"  runat="server" MaxLength="10" meta:resourcekey="value_cicliResource1B" ></asp:textbox>
                </div>
                       </div>

                   
                </div>
</asp:placeholder>  
                 <!-- fine riga -->

    <asp:placeholder runat="server" ID="enable_cc_NaCl">
     <div class="row-fluid">
               	<div class="span3">
                       <div id="riga3_cc_NaCl" class="control-group">
                           <h5 style="padding-top:10px"><asp:literal ID = "Literal2"  text="NaCl cc:" runat="server" meta:resourcekey="Literal4Resource1C"></asp:literal></h5>
                       <asp:textbox ID="value_cc_NaCl" onblur="javascript: Changed_channel( 'value_cicli','riga1_cicli',9999999999, 0,0 );" class="span12"  runat="server" MaxLength="10" meta:resourcekey="value_cicliResource1C" ></asp:textbox>
                </div>
                       </div>

                   
                </div>


</asp:placeholder>  
                 <!-- fine riga -->

<!-- tab 1 stop-->


                  
                </div>
             </div>
             <div id="salva" class="btn-primary">
                   <b class="btn-primary btn-icon glyphicons ok"><asp:button runat="server" ID="save_cicli_ltb_new" class="btn-primary" data-layout="center" data-type="confirm" data-toggle="notyfy" text="Reset Cicli" Font-Bold="True" meta:resourcekey="save_cicli_ltb_newResource1" /><i></i></b>
                </div>
            </div>
        </div>
    <script type="text/javascript" src="ltb/validator_ltb_cicli.js"></script>
            <script type="text/javascript" src="common/validator_general_notify.js"></script>
<script src="theme/scripts/demo/notifications.js"></script>

    </form>

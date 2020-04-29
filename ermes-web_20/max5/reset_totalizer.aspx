<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="reset_totalizer.aspx.vb" Inherits="ermes_web_20.reset_totalizer" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>



<form id="form" runat="server" method="post" action="max5/reset_totalizer.aspx">


    <h3><asp:literal runat="server" text ="Reset Totalizer" ID="calibration_channel" meta:resourcekey="calibration_channelResource1"></asp:literal></h3>
    <div class="innerLR">
        <div class="box-generic">
            <div class="tab-content">
                <div  class="box-generic">
                <!-- riga -->
                <div id ="div_ch1" class="row-fluid">
               	<div class="span2">
                    <asp:checkbox ID="reset_totalizer_check" style="margin: 5px 10px 10px 0px;" runat="server" meta:resourcekey="reset_totalizer_checkResource1"  ></asp:checkbox>
                    <asp:literal ID="reset_totalizer_label" runat="server" text ="Reset Totalizer" meta:resourcekey="reset_totalizer_labelResource1"></asp:literal>
                </div>
                    
                   
                     
                </div>
 <!-- fine riga -->
                                  
                </div>
                </div>
                </div>

                       <div id="salva" class="btn-primary">
                   <b class="btn-primary btn-icon glyphicons ok"><asp:button runat="server" ID="save_totalizer_new" class="btn-primary" data-layout="center" data-type="confirm" data-toggle="notyfy"  text="Salva e carica i dati" Font-Bold="True" meta:resourcekey="save_totalizer_newResource1" /><i></i></b>
                </div>

            </div>
        </div>
    <script type="text/javascript" src="max5/validator_max5_totalizer.js"></script>
     <script type="text/javascript" src="common/validator_general_notify.js"></script>
    <script src="theme/scripts/demo/notifications.js"></script>

    </form>

<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/main.Master" CodeBehind="M0101.aspx.vb" Inherits="ermes_web_20.M0101" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript" src="M0101.js?v=1.9"></script>
    <script type="text/javascript">
        var NserialNumber = "00000000000000001";
        var NarrayReadRealTime = [1];
        var NarrayReadSetpoint = [1, 2, 3, 4, 5, 6];
        var PompaOggetto = new OggettoPompa({ serialNumber: NserialNumber, arrayReadRealTime: NarrayReadRealTime, arrayReadAll: NarrayReadSetpoint });
        PompaOggetto.createConnection();
    </script>

    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="content" style="background-color:#dfdfdf;">
        <div class="row-fluid">
            <div class="span12">
                <div> 
                   <h1 id='messages'>Load data..</h1>
                 </div>
                <div> 
                   <h1 id='messages1'></h1>
                 </div>

            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="script_footer" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="script_at_end" runat="server">
</asp:Content>

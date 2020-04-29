<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/main.Master" CodeBehind="log_usb_plant.aspx.vb" Inherits="ermes_web_20.log_usb_plant" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div id="content">

        </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="script_footer" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="script_at_end" runat="server">
    <script type="text/javascript">
        var target = document.getElementById('content');
     var spinner = new Spinner(opts).spin(target);
        </script>
</asp:Content>

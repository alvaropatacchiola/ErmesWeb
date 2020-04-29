<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/main.Master" CodeBehind="drag_usb_log.aspx.vb" Inherits="ermes_web_20.drag_usb_log" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="theme/scripts/plugins/forms/dropzone/css/dropzone.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div id="content">
   
         <asp:Literal ID="Literal1" runat="server"></asp:Literal>

	

	
				</div>

      

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="script_footer" runat="server">
    
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="script_at_end" runat="server">
    <script src="theme/scripts/plugins/forms/dropzone/dropzone.js"></script>
    <script type="text/javascript">
        function remove_form() {


            $("#form1").contents().unwrap();
            $("#dropzone").after('<form action="drag_usb_log.aspx?file=1" class="dropzone clickable" id="demo-upload">');
           }
        </script>
</asp:Content>

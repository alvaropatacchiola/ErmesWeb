<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/main.Master" CodeBehind="modifica_impianto.aspx.vb" Inherits="ermes_web_20.modifica_impianto" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>
<%@ MasterType VirtualPath="~/main.Master"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="content">
        <h3 class="heading-mosaic"><asp:Literal ID="Literal1" runat="server" Text="Modifica Impianto." meta:resourcekey="Literal1Resource1"></asp:Literal></h3>
        
        <div class="innerAll">
           <h5 > <asp:Literal ID="Literal3" runat="server" Text="Seleziona Impianto da Modificare." meta:resourcekey="Literal3Resource1"></asp:Literal></h5>
    <div class="accordion" id="accordion2">
        <asp:Literal ID="Literal2" runat="server" meta:resourcekey="Literal2Resource1"></asp:Literal>
</div>

            </div>
        </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="script_footer" runat="server">
</asp:Content>

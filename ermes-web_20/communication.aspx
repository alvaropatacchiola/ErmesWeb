<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/main.Master" CodeBehind="communication.aspx.vb" Inherits="ermes_web_20.communication" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
            <div id="principale_alert" style="z-index:10000; position:absolute" >
    </div>

     <div id="content">
        <h3 class="heading-mosaic"><asp:Literal ID="Literal1" runat="server" Text="Comunicazioni" meta:resourcekey="Literal1Resource1" ></asp:Literal></h3>
        
        <div class="innerAll">
           <h5 > <asp:Literal ID="Literal3" runat="server" Text="Elenco comunicazioni Ermes-Server" meta:resourcekey="Literal3Resource1" ></asp:Literal></h5>
                <div class="slim-scroll chat-items" data-scroll-height="240px" style="overflow: hidden; width: auto; height: 240px;">
                    <asp:Literal ID="Literal2" runat="server" meta:resourcekey="Literal2Resource1" ></asp:Literal>
                </div>

            </div>
        </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="script_footer" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="script_at_end" runat="server">
</asp:Content>

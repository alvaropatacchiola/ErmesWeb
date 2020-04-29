<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/main.Master" CodeBehind="dashboardNew.aspx.vb" Inherits="ermes_web_20.dashboardNew" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>
<%@ MasterType VirtualPath="~/main.Master"%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
    <link href="theme/css/dashboardNewCss.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div id="content" style="background-color:#dfdfdf;">
    
       <asp:Literal ID="Literal_script" runat="server" meta:resourcekey="Literal_scriptResource1" ></asp:Literal>              
    <div id="content-notification" class="notyfy_container_error i-am-new"></div>

    <asp:PlaceHolder ID="impianti_yes" runat="server">
          <asp:Label ID="Label1" runat="server" Text="Label" meta:resourcekey="Label1Resource1"></asp:Label>
    </asp:PlaceHolder>
<asp:PlaceHolder ID="impianti_no" runat="server" Visible="False">
     <div class="hero-unit well">
    <asp:Literal ID="Literal2" runat="server" Text="<h3>Non hai ancora un impianto attivo!</h3>" meta:resourcekey="Literal2Resource1" ></asp:Literal>
		
		<hr class="separator"/>
		<!-- Row -->
		<div class="row-fluid row-merge">
		
			<!-- Column -->
			<div class="span6">
				<div class="innerAll center">
                    <asp:Literal ID="Literal3" runat="server" Text="<p>Il tuo account è attivo e sarà utilizzabile per un periodo limitato di <strong>48 ore</strong>, aggiungi un nuovo impianto per rendere la tua iscrizione ad ERMES definitiva.</p>" meta:resourcekey="Literal3Resource1" ></asp:Literal>
					
				</div>
			</div>
			<!-- // Column END -->
			
			<!-- Column -->
			<div class="span6">
				<div class="innerAll center">
					 
					<div class="row-fluid">
						<div class="span6">
                            <asp:Literal ID="Literal4" runat="server" Text="<a href='addimpianto.aspx?layout_type=fluid&amp;menu_position=menu-left&amp;style=style-dark' class='btn btn-icon-stacked btn-block btn-success glyphicons cogwheel'><i></i><span>aggiungi</span><span class='strong'>un nuovo impianto</span></a>" meta:resourcekey="Literal4Resource1" ></asp:Literal>
						  
						</div>
						<div class="span6">
                            <asp:Literal ID="Literal5" runat="server" Text="<a href='#?layout_type=fluid&amp;menu_position=menu-left&amp;style=style-dark' class='btn btn-icon-stacked btn-block btn-danger glyphicons circle_question_mark'><i></i><span>bisogno di aiuto?</span><span class='strong'>leggi la Guida</span></a>" meta:resourcekey="Literal5Resource1" ></asp:Literal>
							</div>
					</div>
				</div>
			</div>
          </div>
         </div>
			<!-- // Column END -->
</asp:PlaceHolder>
</div>
                        

        



</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="script_footer" runat="server">
    <script type="text/javascript" src="Centurio/centurioRealTime.js?v=1.6"></script>
    <asp:Literal ID="javaScriptLiteral" runat="server" meta:resourcekey="javaScriptLiteralResource1"></asp:Literal>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="script_at_end" runat="server">
</asp:Content>

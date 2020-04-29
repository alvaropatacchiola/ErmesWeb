<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/main.Master" CodeBehind="dashboard.aspx.vb" Inherits="ermes_web_20.dashboard" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>
<%@ MasterType VirtualPath="~/main.Master"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta http-equiv='refresh' content='600'/>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="content">
        <asp:Literal ID="Literal_script" runat="server" meta:resourcekey="Literal_scriptResource1">
    </asp:Literal>              
<div id="content-notification" class="notyfy_container_error i-am-new"></div>


	
<h3 class="heading-mosaic">Dashboard</h3>
        <div class="innerAll">
<!-- inizio LISTA STRUMENTI-->
<asp:PlaceHolder ID="impianti_yes" runat="server">
	<asp:Literal ID="Literal1" runat="server" meta:resourcekey="Literal1Resource1">

	</asp:Literal>
</asp:PlaceHolder>
            
<asp:PlaceHolder ID="impianti_no" runat="server" Visible="False">
     <div class="hero-unit well">
    <asp:Literal ID="Literal2" runat="server" Text="<h3>Non hai ancora un impianto attivo!</h3>" meta:resourcekey="Literal2Resource1"></asp:Literal>
		
		<hr class="separator"/>
		<!-- Row -->
		<div class="row-fluid row-merge">
		
			<!-- Column -->
			<div class="span6">
				<div class="innerAll center">
                    <asp:Literal ID="Literal3" runat="server" Text="<p>Il tuo account è attivo e sarà utilizzabile per un periodo limitato di <strong>48 ore</strong>, aggiungi un nuovo impianto per rendere la tua iscrizione ad ERMES definitiva.</p>" meta:resourcekey="Literal3Resource1"></asp:Literal>
					
				</div>
			</div>
			<!-- // Column END -->
			
			<!-- Column -->
			<div class="span6">
				<div class="innerAll center">
					 
					<div class="row-fluid">
						<div class="span6">
                            <asp:Literal ID="Literal4" runat="server" Text="<a href='addimpianto.aspx?layout_type=fluid&amp;menu_position=menu-left&amp;style=style-dark' class='btn btn-icon-stacked btn-block btn-success glyphicons cogwheel'><i></i><span>aggiungi</span><span class='strong'>un nuovo impianto</span></a>" meta:resourcekey="Literal4Resource1"></asp:Literal>
						  
						</div>
						<div class="span6">
                            <asp:Literal ID="Literal5" runat="server" Text="<a href='#?layout_type=fluid&amp;menu_position=menu-left&amp;style=style-dark' class='btn btn-icon-stacked btn-block btn-danger glyphicons circle_question_mark'><i></i><span>bisogno di aiuto?</span><span class='strong'>leggi la Guida</span></a>" meta:resourcekey="Literal5Resource1"></asp:Literal>
							</div>
					</div>
				</div>
			</div>
          </div>
         </div>
			<!-- // Column END -->
            </asp:PlaceHolder>

		
		</div>
        
        
        
		<div class="clearfix"></div>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="script_at_end" runat="server">
</asp:Content>

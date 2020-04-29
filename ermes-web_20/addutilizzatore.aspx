<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/main.Master" CodeBehind="addutilizzatore.aspx.vb" Inherits="ermes_web_20.addutilizzatore" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>
<%@ MasterType VirtualPath="~/main.Master"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div id="principale_alert" style="z-index:10000; position:absolute" >
    </div>

    <div id="content">
        <h3 class="heading-mosaic"><asp:Literal ID="Literal1" runat="server" Text="Aggiungi Utilizzatore" meta:resourcekey="Literal1Resource1" ></asp:Literal></h3>
        <div class="innerAll">
            <div class="widget">
                <div class="widget-body">
                    <div class="row-fluid">
                        <!-- gruppo-->
							<div class="span3">
								<strong><asp:Literal ID="Literal7" runat="server" Text="Dati Utilizzatore" meta:resourcekey="Literal7Resource1" ></asp:Literal> </strong>
								<p class="muted"><asp:Literal ID="Literal8" runat="server" Text="Aggiungi Un utilizzatore per i tuoi Impianti" meta:resourcekey="Literal8Resource1" ></asp:Literal></p>
							</div>
							<div class="span9">
                                <!--
                                <p><asp:Literal ID="Literal9" runat="server" Text="Nome" ></asp:Literal></p>
								<asp:TextBox ID="inputNome" class="span6" placeholder="Inserisci il nome ..." runat="server"></asp:TextBox>
                                    -->
								<div class="separator"></div>
                                <p><asp:Literal ID="Literal2" runat="server" Text="Nome Utilizzatore" meta:resourcekey="Literal2Resource1" ></asp:Literal></p>
                                <asp:TextBox ID="nome_utilizzatore" ClientIDMode="Static" class="span6"  runat="server" meta:resourcekey="nome_utilizzatoreResource1"  ></asp:TextBox>

								<div class="separator"></div>
                                <p><asp:Literal ID="Literal10" runat="server" Text="Username Utilizzatore" meta:resourcekey="Literal10Resource1" ></asp:Literal></p>
                                <asp:TextBox ID="username_utilizzatore" ClientIDMode="Static" class="span6"  runat="server" meta:resourcekey="username_utilizzatoreResource1"  ></asp:TextBox>
                                								
                                <div class="separator"></div>
                             	<p><asp:Literal ID="Literal11" runat="server" Text="Password Utlizzatore" meta:resourcekey="Literal11Resource1" ></asp:Literal></p>
                                <asp:TextBox ID="password_utilizzatore" ClientIDMode="Static"  class="span6" runat="server" meta:resourcekey="password_utilizzatoreResource1" ></asp:TextBox>
                                
                               
                                <div class="separator"></div>
                             	<p><asp:Literal ID="Literal4" runat="server" Text="Modifica Sepoint" meta:resourcekey="Literal4Resource1" Visible="False" ></asp:Literal></p>
                                <asp:checkbox ID="modifica_setpoint" ClientIDMode="Static"  class="span6"  runat="server" meta:resourcekey="modifica_setpointResource1" Visible="False"  ></asp:checkbox>

							</div>
                        </div>
                    <!-- end gruppo-->


						</div>
                 <div id="salva" class="btn-primary">
                   <b class="btn-primary btn-icon glyphicons ok"><asp:button runat="server" ClientIDMode="Static" ID="save_aggiungi_utilizzatore_new" class="btn-primary" data-layout="center" data-type="confirm" data-toggle="notyfy"  text="Aggiungi Utilizzatore" Font-Bold="True" meta:resourcekey="save_aggiungi_utilizzatore_newResource1"  /><i></i></b>

            </div>
                    </div>
                </div>
            </div>

    <script type="text/javascript" src="common/validator_general_addutilizzatore.js"></script>
    <script type="text/javascript" src="common/validator_general_notify.js"></script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="script_footer" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="script_at_end" runat="server">
     <script src="theme/scripts/demo/notifications.js"></script>
      <script >
          var sPageURL = window.location.search.substring(1);
          var i = 0;
          var val;
          var indice = 0;
          var pagina_split = sPageURL.split('&');
          for (i = 0; i < pagina_split.length; i++) {
              val = pagina_split[i].split("=");
              if (val[0] == 'result') {
                  var risultato = parseInt(val[1]);
                  if (risultato == 1) { //risposta corretta
                      result_setpoint_change(add_account_ok);
                  }
                  if (risultato == 2) { //strumento occupato
                      result_setpoint_change(utilizzatore_duplicato);
                  }

              }
          }
</script>
</asp:Content>

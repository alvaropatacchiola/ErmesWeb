<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/main.Master" CodeBehind="modifica_utente.aspx.vb" Inherits="ermes_web_20.modifica_utente" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>
<%@ MasterType VirtualPath="~/main.Master"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="principale_alert" style="z-index:10000; position:absolute" >
    </div>

    <div id="content">
        <h3 class="heading-mosaic"><asp:Literal ID="Literal1" runat="server" Text="Modifica Account" meta:resourcekey="Literal1Resource1" ></asp:Literal></h3>
        <div class="innerAll">
            <div class="widget">
                <div class="widget-body">
                    <div class="row-fluid">
                        <!-- gruppo-->
							<div class="span3">
								<strong><asp:Literal ID="Literal7" runat="server" Text="Dati Account" meta:resourcekey="Literal7Resource1" ></asp:Literal> </strong>
								<p class="muted"><asp:Literal ID="Literal8" runat="server" Text="Modifica  i dati Personali del tuo Account" meta:resourcekey="Literal8Resource1" ></asp:Literal></p>
							</div>
							<div class="span9">
                                <!--
                                <p><asp:Literal ID="Literal9" runat="server" Text="Nome" ></asp:Literal></p>
								<asp:TextBox ID="inputNome" class="span6" placeholder="Inserisci il nome ..." runat="server"></asp:TextBox>
                                    -->
								<div class="separator"></div>
                                <p><asp:Literal ID="Literal10" runat="server" Text="Azienda/Persona" meta:resourcekey="Literal10Resource1" ></asp:Literal></p>
                                <asp:TextBox ID="inputcompany" ClientIDMode="Static" class="span6"  runat="server" meta:resourcekey="inputcompanyResource1"  ></asp:TextBox>
                                								
                                <div class="separator"></div>
                             	<p><asp:Literal ID="Literal11" runat="server" Text="Username" meta:resourcekey="Literal11Resource1" ></asp:Literal></p>
                                <asp:TextBox ID="Username" ClientIDMode="Static"  class="span6" runat="server" meta:resourcekey="UsernameResource1" ></asp:TextBox>
                                
                                <div class="separator"></div>
                             	<p><asp:Literal ID="Literal2" runat="server" Text="Password" meta:resourcekey="Literal2Resource1" ></asp:Literal></p>
                                <asp:TextBox ID="password" ClientIDMode="Static" class="span6"  runat="server"  TextMode="Password" meta:resourcekey="passwordResource1" ></asp:TextBox>

                                <div class="separator"></div>
                             	<p><asp:Literal ID="Literal3" runat="server" Text="Conferma Password" meta:resourcekey="Literal3Resource1" ></asp:Literal></p>
                                <asp:TextBox ID="confirm_password" ClientIDMode="Static"  class="span6"  runat="server"  TextMode="Password" meta:resourcekey="confirm_passwordResource1"></asp:TextBox>

                                <div class="separator"></div>
                             	<p><asp:Literal ID="Literal4" runat="server" Text="email" meta:resourcekey="Literal4Resource1" ></asp:Literal></p>
                                <asp:TextBox ID="email_val" ClientIDMode="Static"  class="span6"  runat="server" meta:resourcekey="email_valResource1"  ></asp:TextBox>

							</div>
                        </div>
                    <!-- end gruppo-->


						</div>
                 <div id="salva" class="btn-primary">
                   <b class="btn-primary btn-icon glyphicons ok"><asp:button runat="server" ClientIDMode="Static" ID="save_modifica_account_new" class="btn-primary" data-layout="center" data-type="confirm" data-toggle="notyfy"  text="Modifica Account" Font-Bold="True" meta:resourcekey="save_modifica_account_newResource1"  /><i></i></b>

            </div>
                    </div>
                </div>
            </div>

    <script type="text/javascript" src="common/validator_general_modificautente.js"></script>
    <script type="text/javascript" src="common/validator_general_notify.js"></script>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="script_at_end" runat="server">
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
                      result_setpoint_change(modify_account_ok);
                  }
                  if (risultato == 2) { //strumento occupato
                      result_setpoint_change(modify_account_error);
                  }

              }
          }
</script>
</asp:Content>

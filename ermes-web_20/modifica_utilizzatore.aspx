﻿<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/main.Master" CodeBehind="modifica_utilizzatore.aspx.vb" Inherits="ermes_web_20.modifica_utilizzatore" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>
<%@ MasterType VirtualPath="~/main.Master"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <div id="principale_alert" style="z-index:10000; position:absolute" >
    </div>

     <div id="content">
        <h3 class="heading-mosaic"><asp:Literal ID="Literal1" runat="server" Text="Modifica Utilizzatore." meta:resourcekey="Literal1Resource1"></asp:Literal></h3>
        
        <div class="innerAll">
           <h5 > <asp:Literal ID="Literal3" runat="server" Text="Seleziona L'Utilizzatore da Modificare." meta:resourcekey="Literal3Resource1" ></asp:Literal></h5>
    <div class="accordion" id="accordion2">
        <asp:Literal ID="Literal2" runat="server" meta:resourcekey="Literal2Resource1" ></asp:Literal>
</div>

            </div>
        </div>
        <script type="text/javascript" src="common/validator_general_modificautilizzatore.js"></script>
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

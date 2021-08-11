<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MainNew.Master" CodeBehind="communicationAssets.aspx.vb" Inherits="ermes_web_20.communicationAssets" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="content-wrapper">
    <div class="content">  <!-- Search impianti-->
        <div class="row no-gutters">
            <div class="col-xl-12">
                <div class="card card-default chat">
                    <div class="card-header">
                          <h2><asp:Literal ID="comunicazioni" runat="server" Text="Communications" meta:resourcekey="comunicazioniResource1"></asp:Literal></h2>
                     </div>
                    <div class="card-body pb-0" data-simplebar style="height: 363px;">
                        <asp:Literal ID="communicationList" runat="server" meta:resourcekey="communicationListResource1"></asp:Literal>
                        <!--
                        <div class="media media-chat">
                                                      <img src="assets/img/user/user-sm-01.jpg" class="rounded-circle" alt="Avata Image">

                            <div class="media-body">
                              <div class="text-content">
                                <span class="message">Da lunedì 10 aprile è infatti disponibile la nuova dashboard ERMES, per avere una lettura ancora più immediata di tutti i parametri e le informazioni che riguardano i tuoi impianti gestiti a distanza. Anche da mobile, grazie alla nuova interfaccia, il controllo remoto sui tuoi impianti non è mai stato così semplice e immediato.</span>
                                <time class="time">06/04/2017</time>
                              </div>
                            </div>
                          </div>
                        -->
                    </div>
                 </div>
            </div>
         </div>
    </div>
</div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="script_footerAssets" runat="server">
</asp:Content>

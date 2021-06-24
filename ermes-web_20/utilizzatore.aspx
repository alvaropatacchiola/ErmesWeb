<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MainNew.Master" CodeBehind="utilizzatore.aspx.vb" Inherits="ermes_web_20.utilizzatore" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>
<%@ MasterType VirtualPath="~/MainNew.Master"%>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content-wrapper">
   <div class="content">    
       <div class="row">
          <div class="col-xl-12">
              <div class="card card-default">
                  <div class="card-header">
                              <h2><asp:Literal ID="Literal8" runat="server" Text="Modifica Utilizzatore per i tuoi Impianti" meta:resourcekey="Literal8Resource1" ></asp:Literal></h2>
                   </div>
                  <div class="card-body">
                  <form>
                      <div class="form-group ">
                          <label for="exampleFormControlPassword4" ><asp:Literal ID="Literal2" runat="server" Text="Nome Utilizzatore" meta:resourcekey="Literal2Resource1" ></asp:Literal></label>
                          <asp:TextBox CssClass="form-control border-success" ID="nome_utilizzatore" ClientIDMode="Static" class="span6"  runat="server" meta:resourcekey="nome_utilizzatoreResource1"  ></asp:TextBox>
                      </div>
                      <div class="form-group ">
                          <label for="exampleFormControlPassword4" ><asp:Literal ID="Literal10" runat="server" Text="Username Utilizzatore" meta:resourcekey="Literal10Resource1" ></asp:Literal></label>
                          <asp:TextBox CssClass="form-control border-success" ID="username_utilizzatore" ClientIDMode="Static" class="span6"  runat="server" meta:resourcekey="username_utilizzatoreResource1"  ></asp:TextBox>
                      </div>
                      <div class="form-group ">
                          <label for="exampleFormControlPassword4" ><asp:Literal ID="Literal11" runat="server" Text="Password Utlizzatore" meta:resourcekey="Literal11Resource1" ></asp:Literal></label>
                          <asp:TextBox CssClass="form-control border-success" ID="password_utilizzatore" ClientIDMode="Static"  class="span6" runat="server" meta:resourcekey="password_utilizzatoreResource1" ></asp:TextBox>
                      </div>
                    <div class="form-footer ModeSendLoad" style="display: none;" >
                                                                <div class="progress mb-3" >
																      <div  class="progress-bar progress-bar-striped progress-bar-animated" role="progressbar" style="width: 60%" aria-valuenow="25" aria-valuemin="0" aria-valuemax="100"></div>
													            </div>
                                                            </div>
													        <div class="form-footer">
														        <!-- TASTO LOADING 
														        <a class="ladda-button btn btn-primary btn-ladda"  data-style="expand-right">
                                                                    -->
                                                                    <asp:button CssClass="ladda-button btn btn-primary btn-ladda" runat="server" ClientIDMode="Static"  ID="save_aggiungi_utilizzatore_new"  data-layout="center" data-type="confirm" data-toggle="notyfy"  text="Salva Utilizzatore" Font-Bold="True" meta:resourcekey="save_aggiungi_utilizzatore_newResource1" />
														        <!--</a>-->
														        <!-- END TASTO LOADING -->
													        </div>
                  </form>
                 </div>
               </div>
          </div>
       </div>            
   </div>
</div>
    <script type="text/javascript" src="common/validator_utilizzatore.js?v=1.4"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="script_footerAssets" runat="server">
</asp:Content>

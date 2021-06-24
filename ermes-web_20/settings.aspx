<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MainNew.Master" CodeBehind="settings.aspx.vb" Inherits="ermes_web_20.settings" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>
<%@ MasterType VirtualPath="~/MainNew.Master"%>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content-wrapper">
          <div class="content"><!-- Card Profile -->
            <div class="row">
  
              <div class="col-xl-12">
                <!-- Account Settings -->
                <div class="card card-default">
                  <div class="card-header">
                    <h2 class="mb-5"><asp:Literal ID="Literal8" runat="server" Text="Modifica  i dati Personali del tuo Account" meta:resourcekey="Literal8Resource1"  ></asp:Literal></h2>

                  </div>

                  <div class="card-body">

                    <form>
			
                      <div class="row mb-2">
                        <div class="col-lg-6">
                          <div class="form-group">
                            <label for="firstName"><asp:Literal ID="Literal10" runat="server" Text="Azienda/Persona" meta:resourcekey="Literal10Resource1" ></asp:Literal></label>
                            <asp:TextBox ID="inputcompany" ClientIDMode="Static"  runat="server"   CssClass="form-control" meta:resourcekey="inputcompanyResource1"></asp:TextBox>
                          </div>
                        </div>

                        <div class="col-lg-6">
                          <div class="form-group">
                            <label for="lastName"><asp:Literal ID="Literal11" runat="server" Text="Username" meta:resourcekey="Literal11Resource1" ></asp:Literal></label>
                            <asp:TextBox ID="Username" ClientIDMode="Static" runat="server" CssClass="form-control" meta:resourcekey="UsernameResource1"></asp:TextBox>
                          </div>
                        </div>
                      </div>

                      <div class="form-group mb-4">
                        <label for="userName"><asp:Literal ID="Literal2" runat="server" Text="Password" meta:resourcekey="Literal2Resource1" ></asp:Literal></label>
                        <asp:TextBox ID="password" ClientIDMode="Static" CssClass="form-control"  runat="server"  TextMode="Password" meta:resourcekey="passwordResource1" ></asp:TextBox>
                      </div>
                      <div class="form-group mb-4">
                        <label for="newPassword"><asp:Literal ID="Literal3" runat="server" Text="Conferma Password" meta:resourcekey="Literal3Resource1" ></asp:Literal></label>
                        <asp:TextBox ID="confirm_password" ClientIDMode="Static"  CssClass="form-control"  runat="server"  TextMode="Password" meta:resourcekey="confirm_passwordResource1" ></asp:TextBox>
                      </div>

                      <div class="form-group mb-4">
                        <label for="email"><asp:Literal ID="Literal4" runat="server" Text="email" meta:resourcekey="Literal4Resource1" ></asp:Literal></label>
                        <asp:TextBox ID="email_val" ClientIDMode="Static"  CssClass="form-control"  runat="server" meta:resourcekey="email_valResource1"  ></asp:TextBox>
                      </div>
                      <div class="d-flex justify-content-end mt-6">
                        <asp:button runat="server" ClientIDMode="Static" ID="save_modifica_account_new" CssClass="btn btn-primary mb-2 btn-pill" data-layout="center" data-type="confirm" data-toggle="notyfy"  text="Modifica Account" Font-Bold="True" meta:resourcekey="save_modifica_account_newResource1" />
                      </div>
                    </form>
                  </div>
                </div>




              </div>

            </div>

          </div>
    </div>
    <script type="text/javascript" src="common/validator_settings.js?v=1.0"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="script_footerAssets" runat="server">
</asp:Content>

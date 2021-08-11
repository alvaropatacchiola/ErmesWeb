<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MainNew.Master" CodeBehind="picker.aspx.vb" Inherits="ermes_web_20.picker" %>
<%@ MasterType VirtualPath="~/MainNew.Master"%>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div class="content-wrapper">
          <div class="content"><!-- Card Profile -->
            <div class="row">
  
              <div class="col-xl-12">
                <!-- Account Settings -->
                <div class="card card-default">
                  <div class="card-header">
                    <h2 class="mb-5"><asp:Literal ID="Literal8" runat="server" Text="Customize your ERMES theme"   ></asp:Literal></h2>

                  </div>

                  <div class="card-body">
                      <h4>CUSTOM LOGO</h4><br>
                      <form>
                          <div class="col-sm-8 col-lg-12">
				            <div class="form-group row mb-6">
                                <div style="margin:0 0 20px 0"><asp:Literal ID="logoAssents" runat="server" Text='<img src="assets/img/logo.png" alt="Mono">'></asp:Literal></div>
                        <label for="coverImage" class="col-sm-4 col-lg-6 col-form-label"></label><br>
                          <div class="custom-file mb-1">
				  
                              <asp:FileUpload accept=".jpg,.ipeg,.png" ClientIDMode="Static" ID="FileUpload1" runat="server"  /><!--CssClass="custom-file-input" -->
                              
                            <div class="invalid-feedback">Example invalid custom file feedback</div>
                          </div>
                          <span class="d-block " style="font-style: italic; font-size: 12px;">Upload a new cover image, JPG 128x128</span>
                        </div>
                      </div>
<div id="text">
    <label>Insert your Company Name:</label>
    <!--<input id="slide" type="text" value=""onchange="updateText(this.value);" />-->
    <asp:TextBox  ClientIDMode="Static" ID="slide" runat="server" onchange="updateText(this.value);" MaxLength="30"></asp:TextBox>
    </div>
                          <br><br><h4>CUSTOM THEME COLORS</h4><br>
                        <div class="row mb-2">
			                                     <div class="col-lg-4">
				                                     <div class="form-group">
					                                     <label>Body Color</label><br><br>
					                                     <!--<input type="color" id="color_body">-->
                                                         <asp:TextBox type="color" ClientIDMode="Static" ID="color_body" runat="server"></asp:TextBox>
                                    <a class="color_button_body">Change</a>
				                                     </div>
                                                <br><br>
							                         <div class="form-group">
					                                     <label>Primary Color</label><br><br>
					                                     <!--<input type="color" id="color_body">-->
                                                         <asp:TextBox type="color" ClientIDMode="Static" ID="color_primary" runat="server"></asp:TextBox>
                                                            <a class="color_button_primary">Change</a>
				                                     </div>		  
		                                      </div>
			                                     <div class="col-lg-4">
				                                     <div class="form-group">
			                                      <label>Sidebar background color<</label><br><br>
					                                    <!--<input type="color" id="color">-->
                                                         <asp:TextBox ID="color" type="color" ClientIDMode="Static" runat="server"></asp:TextBox>
					                                    <a class="color_button">Change</a>
				                                     </div>
                                                     
							                         <br><br>
							                         <div class="form-group">
					                                     <label>Sidebar links Color</label><br><br>
					                                     <!--<input type="color" id="color_body">-->
                                                         <asp:TextBox type="color" ClientIDMode="Static" ID="color_links" runat="server"></asp:TextBox>
                                                            <a class="color_button_links">Change</a>
				                                     </div>		</div>

		                                      </div>
                        <div class="d-flex justify-content-end mt-6">
                            <asp:button runat="server" ClientIDMode="Static" ID="save_modifica_account_new" CssClass="btn btn-primary mb-2 btn-pill" data-layout="center" data-type="confirm" data-toggle="notyfy"  text="Modifica" Font-Bold="True" meta:resourcekey="save_modifica_account_newResource1" />
                      </div>
                        </form>
                  </div>
                    </div>

              </div>

            </div>

          </div>
    </div>
    <script type="text/javascript" src="common/validator_picker.js?v=1.0"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="script_footerAssets" runat="server">
</asp:Content>

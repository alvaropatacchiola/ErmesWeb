<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MainNew.Master" CodeBehind="dashboardAssets.aspx.vb" Inherits="ermes_web_20.dashboardAssets" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>
<%@ MasterType VirtualPath="~/MainNew.Master"%>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<script type = "text/javascript" src="pompe/pumpsCommunication.js?v=1.46"></script>
<div class="content-wrapper">
    <div class="content">  <!-- Search impianti-->
        <div class="input-group mb-3">
            <div class="input-group-prepend">
                <span class="input-group-text mdi mdi-cloud-search" id="basic-addon1"></span>
            </div>
            <input type="text" id="quicksearch"  class="form-control" placeholder="Search your Plant here" aria-label="Username" aria-describedby="basic-addon1">
        </div>
        <!--End search impianti -->
	    <!--Filtri Bottoni-->
        <div id="filters" class="button-group">  
            <button type="button" class="btn btn-outline-primary is-checked" data-filter="*"><asp:Literal ID="filterAll" runat="server" Text="show all" meta:resourcekey="filterAllResource1"></asp:Literal></button>
            <button type="button" class="btn btn-outline-secondary" data-filter=".pompa"><asp:Literal ID="filterPompa" runat="server" Text="Pompa" meta:resourcekey="filterPompaResource1"></asp:Literal></button>
			<button type="button" class="btn btn-outline-secondary" data-filter=".strumento"><asp:Literal ID="filterStrumento" runat="server" Text="Strumento di controllo" meta:resourcekey="filterStrumentoResource1"></asp:Literal></button>
            <button type="button" class="btn btn-outline-secondary" data-filter=".impiantoacceso"><asp:Literal ID="filterOn" runat="server" Text="Impianti accesi" meta:resourcekey="filterOnResource1"></asp:Literal></button>
            <button type="button" class="btn btn-outline-secondary" data-filter=".impiantospento"><asp:Literal ID="filterOff" runat="server" Text="Impianti spenti" meta:resourcekey="filterOffResource1"></asp:Literal></button>
		    <button type="button" class="btn btn-outline-secondary" data-filter=".allarme"><asp:Literal ID="filterAlarm" runat="server" Text="Impianti in allarme" meta:resourcekey="filterAlarmResource1"></asp:Literal></button>
        </div>
        <!-- End Filtri Bottoni-->
        <!-- Impianti -->
        <div class="row grid">
                    <asp:Literal ID="listaStrumenti" runat="server" meta:resourcekey="listaStrumentiResource1"></asp:Literal>

					  
                   
                  </div> 
			      <!-- End Impianti -->

				<!-- LOG AND COMMUNICATION -->
               
				<!-- END LOG AND COMMUNICATION -->


                
                
                


                

              

              <!-- Stock Modal -->
              <div class="modal fade modal-stock" id="modal-stock" aria-labelledby="modal-stock" aria-hidden="true">
                <div class="modal-dialog modal-xl modal-dialog-centered" role="document">
                  <form action="#">
                    <div class="modal-content">
                      <div class="modal-header align-items-center p3 p-md-5">
                        <h2 class="modal-title" id="exampleModalGridTitle">Add Stock</h2>
                        <div>
                          <button type="button" class="btn btn-light btn-pill mr-1 mr-md-2" data-dismiss="modal"> cancel </button>
                          <button type="submit" class="btn btn-primary  btn-pill" data-dismiss="modal"> save </button>
                        </div>

                      </div>
                      <div class="modal-body p3 p-md-5">
                        <div class="row">
                          <div class="col-lg-8">
                            <h3 class="h5 mb-5">Product Information</h3>
                            <div class="form-group mb-5">
                              <label for="new-product">Product Title</label>
                              <input type="text" class="form-control" id="new-product" placeholder="Add Product">
                            </div>
                            <div class="form-row mb-4">
                              <div class="col">
                                <label for="price">Price</label>
                                <div class="input-group">
                                  <div class="input-group-prepend">
                                    <span class="input-group-text" id="basic-addon1">$</span>
                                  </div>
                                  <input type="text" class="form-control" id="price" placeholder="Price" aria-label="Price"
                                    aria-describedby="basic-addon1">
                                </div>
                              </div>
                              <div class="col">
                                <label for="sale-price">Sale Price</label>
                                <div class="input-group">
                                  <div class="input-group-prepend">
                                    <span class="input-group-text" id="basic-addon1">$</span>
                                  </div>
                                  <input type="text" class="form-control" id="sale-price" placeholder="Sale Price" aria-label="SalePrice"
                                    aria-describedby="basic-addon1">
                                </div>
                              </div>
                            </div>

                            <div class="product-type mb-3 ">
                              <label class="d-block" for="sale-price">Product Type <i class="mdi mdi-help-circle-outline"></i> </label>
                              <div>

                                <div class="custom-control custom-radio d-inline-block mr-3 mb-3">
                                  <input type="radio" id="customRadio1" name="customRadio" class="custom-control-input" checked="checked">
                                  <label class="custom-control-label" for="customRadio1">Physical Good</label>
                                </div>

                                <div class="custom-control custom-radio d-inline-block mr-3 mb-3">
                                  <input type="radio" id="customRadio2" name="customRadio" class="custom-control-input">
                                  <label class="custom-control-label" for="customRadio2">Digital Good</label>
                                </div>

                                <div class="custom-control custom-radio d-inline-block mr-3 mb-3">
                                  <input type="radio" id="customRadio3" name="customRadio" class="custom-control-input">
                                  <label class="custom-control-label" for="customRadio3">Service</label>
                                </div>

                              </div>
                            </div>

                            <div class="editor">
                              <label class="d-block" for="sale-price">Description <i class="mdi mdi-help-circle-outline"></i></label>
                              <div id="standalone">
                                <div id="toolbar">
                                  <span class="ql-formats">
                                    <select class="ql-font"></select>
                                    <select class="ql-size"></select>
                                  </span>
                                  <span class="ql-formats">
                                    <button class="ql-bold"></button>
                                    <button class="ql-italic"></button>
                                    <button class="ql-underline"></button>
                                  </span>
                                  <span class="ql-formats">
                                    <select class="ql-color"></select>
                                  </span>
                                  <span class="ql-formats">
                                    <button class="ql-blockquote"></button>
                                  </span>
                                  <span class="ql-formats">
                                    <button class="ql-list" value="ordered"></button>
                                    <button class="ql-list" value="bullet"></button>
                                    <button class="ql-indent" value="-1"></button>
                                    <button class="ql-indent" value="+1"></button>
                                  </span>
                                  <span class="ql-formats">
                                    <button class="ql-direction" value="rtl"></button>
                                    <select class="ql-align"></select>
                                  </span>
                                </div>
                              </div>
                              <div id="editor"></div>

                              <div class="custom-control custom-checkbox d-inline-block mt-2">
                                <input type="checkbox" class="custom-control-input" id="customCheck2">
                                <label class="custom-control-label" for="customCheck2">Hide product from published site</label>
                              </div>

                            </div>

                          </div>
                          <div class="col-lg-4">
                            <div class="custom-file">
                              <input type="file" class="custom-file-input" id="customFile" placeholder="please imgae here">
                              <span class="upload-image">Click here to <span class="text-primary">add product image.</span> </span>
                            </div>
                          </div>
                        </div>
                      </div>

                    </div>
                  </form>
                </div>
              </div>
</div>
          
        </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="script_footerAssets" runat="server">
    <script type="text/javascript" src="Centurio/centurioRealTimeAssets.js?v=1.7"></script>
    
    <asp:Literal ID="javaScriptLiteral" runat="server" meta:resourcekey="javaScriptLiteralResource1"></asp:Literal>
</asp:Content>

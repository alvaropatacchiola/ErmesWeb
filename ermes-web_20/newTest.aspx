<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/produzione.Master" CodeBehind="newTest.aspx.vb" Inherits="ermes_web_20.newTest" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
       <div id="content">
        <h3 class="heading-mosaic"><asp:Literal ID="Literal1" runat="server" Text="Nuova Comunicazione"  ></asp:Literal></h3>
        <div class="innerAll">
            <div class="widget">

                <div class="widget-body">
                    <div class="row-fluid">
                        <!-- gruppo-->
							<div class="span3">
								<strong><asp:Literal ID="Literal7" runat="server" Text="Serial Number Scanner"  ></asp:Literal> </strong>
								<p class="muted"><asp:Literal ID="Literal8" runat="server" Text="Serial Number  Mediante Scanner" ></asp:Literal></p>
							</div>
							<div class="span9">
                                <!--
                                <p><asp:Literal ID="Literal9" runat="server" Text="Nome" ></asp:Literal></p>
								<asp:TextBox ID="inputNome" class="span6" placeholder="Inserisci il nome ..." runat="server"></asp:TextBox>
                                    -->
								<div class="separator"></div>
                                <p><asp:Literal ID="Literal2" runat="server" Text="Serial Number Scanner"  ></asp:Literal></p>
                                <asp:TextBox ID="codice_dispositivo" ClientIDMode="Static" class="span6"  runat="server"  ></asp:TextBox>
							</div>
                        </div>
                    <!-- end gruppo-->
                    <div class="row-fluid">
							<div class="span3">
								<strong><asp:Literal ID="serial1" runat="server" Text="Serial Number Manuale"  ></asp:Literal> </strong>
								<p class="muted"><asp:Literal ID="serial11" runat="server" Text="Inserisci il Serialnumber manualmente" ></asp:Literal></p>
							</div>
							<div class="span9">

								<div class="separator"></div>
                                <p><asp:Literal ID="serial2" runat="server" Text="Serial Number Manuale"  ></asp:Literal></p>
                                <asp:TextBox ID="TextBox1" ClientIDMode="Static" class="span6"  runat="server"  ></asp:TextBox>
							</div>

                    </div>

						</div>

                <div>
                    &nbsp;
                    </div>
                 <div id="Salva1" class="btn-primary">
                   <b class="btn-primary btn-icon glyphicons ok"><asp:button runat="server" ClientIDMode="Static" ID="Button1" class="btn-primary" data-layout="center"  text="Reparto Pannelli" Font-Bold="True"   /><i></i></b>

            </div>
                <div>
                    &nbsp;
                    </div>
                                <div>
                    &nbsp;
                    </div>
             <div id="salva" class="btn-primary">
                   <b class="btn-primary btn-icon glyphicons ok"><asp:button runat="server" ClientIDMode="Static" ID="save_aggiungi_utilizzatore_new" class="btn-primary" data-layout="center"  text="Reparto Elettronica" Font-Bold="True"   /><i></i></b>

            </div>

                    </div>
                </div>
    
            </div>
</asp:Content>

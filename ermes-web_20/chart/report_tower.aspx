<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="report_tower.aspx.vb" Inherits="ermes_web_20.report_tower" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>
<form id="form_log" runat="server" method="post" onsubmit="return get_action();" >
    

  <div class="innerLR">

    		<!-- ************************************ --> <!-- Widget --> 

      <div class="widget"> <!-- Widget heading --> 
<div class="widget" data-toggle="collapse-widget" data-collapse-closed="false">
	<div id="head_log" class="widget-head"><h4 class="heading"><asp:literal text="Report Settings" runat="server"  ID="report_setting_id" meta:resourcekey="report_setting_idResource1"></asp:literal></h4><span class="collapse-toggle"></span></div>
	<div id="log_collapse" class="widget-body uniformjs in collapse" style="height: auto;">
<div  class="box-generic">
<style type="text/css">
labellog {
    display: block;
	padding-top:2px;
    padding-left: 15px;
    text-indent: -15px;
}
inputlog {
    width: 13px;
    height: 13px;
    padding: 0;
    margin:0;
    vertical-align: bottom;
    position: relative;
    top: -1px;
    *overflow: hidden;
}
#checkboxCh{
	float:left;
	margin-right:10px;
	}
</style>

    <!-- riga -->

                    <div class="row-fluid">
                        <asp:PlaceHolder ID="ch1_enable" runat="server">
                            <div class="span12">
                                <h5 style="padding-top:10px">
                                    <asp:Literal ID="Literal1" runat="server" text="Ch1 Select" meta:resourcekey="Literal1Resource1"></asp:Literal>
                                </h5>
                                <div id="checkboxCh">
                                    <asp:CheckBox ID="ch1_val" runat="server" Checked="True" class="inputlog" meta:resourcekey="ch1_valResource1" />
                                </div>
                                <div id="checkboxCh">
                                    <asp:Label ID="ch1_val_label" runat="server" class="labellog" Text="ch1" meta:resourcekey="ch1_val_labelResource1"></asp:Label>
                                </div>
                                <div id="checkboxCh">
                                    <asp:CheckBox ID="ch1_high" runat="server" class="inputlog" meta:resourcekey="ch1_highResource1" />
                                </div>
                                <div id="checkboxCh">
                                    <asp:Label ID="ch1_high_label" runat="server" class="labellog" Text="High" meta:resourcekey="ch1_high_labelResource1"></asp:Label>
                                </div>
                                <div id="checkboxCh">
                                    <asp:CheckBox ID="ch1_low" runat="server" class="inputlog" meta:resourcekey="ch1_lowResource1" />
                                </div>
                                <div id="checkboxCh">
                                    <asp:Label ID="ch1_low_label" runat="server" class="labellog" Text="Low" meta:resourcekey="ch1_low_labelResource1"></asp:Label>
                                </div>
                                <div id="checkboxCh">
                                    <asp:CheckBox ID="ch1_bleed" runat="server" class="inputlog" meta:resourcekey="ch1_bleedResource1" />
                                </div>
                                <div id="checkboxCh">
                                    <asp:Label ID="ch1_bleed_label" runat="server" class="labellog" Text="Probe Fail" meta:resourcekey="ch1_bleed_labelResource1"></asp:Label>
                                </div>
                                <div id="checkboxCh">
                                    <asp:CheckBox ID="ch1_livello_inhibitor" runat="server" class="inputlog" meta:resourcekey="ch1_livello_inhibitorResource1" />
                                </div>
                                <div id="checkboxCh">
                                    <asp:Label ID="ch1_livello_inhibitor_label" runat="server" class="labellog" Text="Level Inhibitor" meta:resourcekey="ch1_livello_inhibitor_labelResource1"></asp:Label>
                                </div>
                                <div id="checkboxCh">
                                    <asp:CheckBox ID="ch1_livello_prebiocide1" runat="server" class="inputlog" meta:resourcekey="ch1_livello_prebiocide1Resource1" />
                                </div>
                                <div id="checkboxCh">
                                    <asp:Label ID="ch1_livello_prebiocide1_label" runat="server" class="labellog" Text="Prebiocide 1" meta:resourcekey="ch1_livello_prebiocide1_labelResource1"></asp:Label>
                                </div>
                                <div id="checkboxCh">
                                    <asp:CheckBox ID="ch1_livello_prebiocide2" runat="server" class="inputlog" meta:resourcekey="ch1_livello_prebiocide2Resource1" />
                                </div>
                                <div id="checkboxCh">
                                    <asp:Label ID="ch1_livello_prebiocide2_label" runat="server" class="labellog" Text="Prebiocide 2" meta:resourcekey="ch1_livello_prebiocide2_labelResource1"></asp:Label>
                                </div>

                                <div id="checkboxCh">
                                    <asp:CheckBox ID="ch1_livello_biocide1" runat="server" class="inputlog" meta:resourcekey="ch1_livello_biocide1Resource1" />
                                </div>
                                <div id="checkboxCh">
                                    <asp:Label ID="ch1_livello_biocide1_label" runat="server" class="labellog" Text="Biocide 1" meta:resourcekey="ch1_livello_biocide1_labelResource1"></asp:Label>
                                </div>
                                <div id="checkboxCh">
                                    <asp:CheckBox ID="ch1_livello_biocide2" runat="server" class="inputlog" meta:resourcekey="ch1_livello_biocide2Resource1" />
                                </div>
                                <div id="checkboxCh">
                                    <asp:Label ID="ch1_livello_biocide2_label" runat="server" class="labellog" Text="Biocide 2" meta:resourcekey="ch1_livello_biocide2_labelResource1"></asp:Label>
                                </div>

                            </div>
                        </asp:PlaceHolder>
        <!-- fine riga -->
                    </div>
                    <div class="row-fluid">
        <!-- riga -->
                        <asp:PlaceHolder ID="ch2_enable" runat="server">
                            <div class="span6">
                                <h5 style="padding-top:10px">
                                    <asp:Literal ID="Literal2" runat="server" text="Ch2 Select" meta:resourcekey="Literal2Resource1"></asp:Literal>
                                </h5>
                                <div id="checkboxCh">
                                    <asp:CheckBox ID="ch2_val" runat="server" class="inputlog" meta:resourcekey="ch2_valResource1" />
                                </div>
                                <div id="checkboxCh">
                                    <asp:Label ID="ch2_val_label" runat="server" class="labellog" Text="ch2" meta:resourcekey="ch2_val_labelResource1"></asp:Label>
                                </div>
                                <div id="checkboxCh">
                                    <asp:CheckBox ID="ch2_high" runat="server" class="inputlog" meta:resourcekey="ch2_highResource1" />
                                </div>
                                <div id="checkboxCh">
                                    <asp:Label ID="ch2_high_label" runat="server" class="labellog" Text="High" meta:resourcekey="ch2_high_labelResource1"></asp:Label>
                                </div>
                                <div id="checkboxCh">
                                    <asp:CheckBox ID="ch2_low" runat="server" class="inputlog" meta:resourcekey="ch2_lowResource1" />
                                </div>
                                <div id="checkboxCh">
                                    <asp:Label ID="ch2_low_label" runat="server" class="labellog" Text="Low" meta:resourcekey="ch2_low_labelResource1"></asp:Label>
                                </div>
                                <div id="checkboxCh">
                                    <asp:CheckBox ID="ch2_livello" runat="server" class="inputlog" meta:resourcekey="ch2_livelloResource1" />
                                </div>
                                <div id="checkboxCh">
                                    <asp:Label ID="ch2_livello_label" runat="server" class="labellog" Text="Level" meta:resourcekey="ch2_livello_labelResource1"></asp:Label>
                                </div>
                               
                            </div>
                        </asp:PlaceHolder>
                    </div>
        <!-- fine riga -->
        <!-- riga -->
                    <div class="row-fluid">
                        <asp:PlaceHolder ID="ch3_enable" runat="server">
                            <div class="span6">
                                <h5 style="padding-top:10px">
                                    <asp:Literal ID="Literal3" runat="server" text="Ch3 Select" meta:resourcekey="Literal3Resource1"></asp:Literal>
                                </h5>
                                <div id="checkboxCh">
                                    <asp:CheckBox ID="ch3_val" runat="server" class="inputlog" meta:resourcekey="ch3_valResource1" />
                                </div>
                                <div id="checkboxCh">
                                    <asp:Label ID="ch3_val_label" runat="server" class="labellog" Text="ch3" meta:resourcekey="ch3_val_labelResource1"></asp:Label>
                                </div>
                                <div id="checkboxCh">
                                    <asp:CheckBox ID="ch3_high" runat="server" class="inputlog" meta:resourcekey="ch3_highResource1" />
                                </div>
                                <div id="checkboxCh">
                                    <asp:Label ID="ch3_high_label" runat="server" class="labellog" Text="High" meta:resourcekey="ch3_high_labelResource1"></asp:Label>
                                </div>
                                <div id="checkboxCh">
                                    <asp:CheckBox ID="ch3_low" runat="server" class="inputlog" meta:resourcekey="ch3_lowResource1" />
                                </div>
                                <div id="checkboxCh">
                                    <asp:Label ID="ch3_low_label" runat="server" class="labellog" Text="Low" meta:resourcekey="ch3_low_labelResource1"></asp:Label>
                                </div>
                                <div id="checkboxCh">
                                    <asp:CheckBox ID="ch3_livello" runat="server" class="inputlog" meta:resourcekey="ch3_livelloResource1" />
                                </div>
                                <div id="checkboxCh">
                                    <asp:Label ID="ch3_livello_label" runat="server" class="labellog" Text="Level" meta:resourcekey="ch3_livello_labelResource1"></asp:Label>
                                </div>

                            </div>
                        </asp:PlaceHolder>

        <!-- fine riga -->
       
        <!-- riga -->
                        <asp:PlaceHolder ID="Placeholder1" runat="server">
                            <div class="span6">
                                <h5 style="padding-top:10px">
                                    <asp:Literal ID="Literal6" runat="server" text="Input" meta:resourcekey="Literal6Resource1"></asp:Literal>
                                </h5>
                                <div id="checkboxCh">
                                    <asp:CheckBox ID="flow_select" runat="server" Checked="True" class="inputlog" meta:resourcekey="flow_selectResource1" />
                                </div>
                                <div id="checkboxCh">
                                    <asp:Label ID="label_flow_select" runat="server" class="labellog" Text="Flow" meta:resourcekey="label_flow_selectResource1"></asp:Label>
                                </div>
                                <div id="checkboxCh">
                                    <asp:CheckBox ID="temperature_select" runat="server" class="inputlog" meta:resourcekey="temperature_selectResource1" />
                                </div>
                                <div id="checkboxCh">
                                    <asp:Label ID="label_temperature_select" runat="server" class="labellog" Text="Temperature" meta:resourcekey="label_temperature_selectResource1"></asp:Label>
                                </div>
                            </div>
                            </div>
                        </asp:PlaceHolder>
        <!-- fine riga -->
             <!-- riga -->
<div class="row-fluid">
        <div class="span6">
            <h5 style="padding-top:10px"><asp:literal ID = "Literal11"  text="Log Range" runat="server" meta:resourcekey="Literal11Resource1"></asp:literal></h5>
         <div id="checkboxCh"><h5 style="padding-top:10px"><asp:literal ID = "Literal10"  text="From" runat="server" meta:resourcekey="Literal10Resource1"></asp:literal></h5></div>
         <div id="checkboxCh"><asp:textbox ID="graph_log_from"   class="span12"  runat="server" meta:resourcekey="graph_log_fromResource1"  ></asp:textbox></div>
         <div id="checkboxCh"><h5 style="padding-top:10px"><asp:literal ID = "Literal12"  text="To" runat="server" meta:resourcekey="Literal12Resource1"></asp:literal></h5></div>
         <div id="checkboxCh"><asp:textbox ID="graph_log_to"   class="span12"  runat="server" meta:resourcekey="graph_log_toResource1"  ></asp:textbox></div>

              </div>
    </div> 
	</div>
	</div>
       <div id="salva" class="btn-primary">
                   <b class="btn-primary btn-icon glyphicons ok"><asp:button runat="server" ID="refresh_report" class="btn-primary"  text="Refresh Report" Font-Bold="True" meta:resourcekey="refresh_reportResource1" /><i></i></b>

            </div>

	</div> 
          <asp:Button ID="pdf_id" runat="server" Text="PDF" meta:resourcekey="pdf_idResource1"   />
          <asp:Button ID="excel_id" runat="server" Text="EXCEL" meta:resourcekey="excel_idResource1"  />
          <asp:Panel ID="pnlPerson" runat="server" meta:resourcekey="pnlPersonResource1">

          <div class="widget-body">
               <!-- Table --> <table class="dynamicTable table table-striped table-bordered table-condensed"> 
                   <!-- Table heading --> 
                  <asp:Literal runat="server" ID="report_head" meta:resourcekey="report_headResource1"></asp:Literal>
                   <!-- // Table heading END -->
                   <!-- Table body --> 
                        <asp:Literal runat="server" ID="report_body" meta:resourcekey="report_bodyResource1"></asp:Literal>
                   
                   <!-- // Table body END -->

                              </table> 
              <!-- // Table END --> 
                 </div> 
              </asp:Panel>
              </div>
       <!-- // Widget END -->
       

      </div>
      </div>
      <asp:Button ID="refresh_log_server" runat="server" BackColor="Transparent" BorderColor="Transparent" meta:resourcekey="refresh_log_serverResource1"  />
    <asp:literal runat="server" ID="literal_script" meta:resourcekey="literal_scriptResource1"></asp:literal>

    	<script src="theme/scripts/plugins/tables/DataTables/media/js/jquery.dataTables.min.js"></script>
	<script type="text/javascript" src="chart/report_manage_tower.js"></script>
    <script src="theme/scripts/plugins/tables/DataTables/media/js/DT_bootstrap.js"></script>
	
	<!-- Tables Demo Script -->
	<script src="theme/scripts/demo/tables.js"></script>
    
    </form>
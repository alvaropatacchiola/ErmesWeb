﻿<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="report_ld4.aspx.vb" Inherits="ermes_web_20.report_ld4" %>

<form id="form_log" runat="server" method="post" onsubmit="return get_action();">
    

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
            
<asp:placeholder runat="server" ID="ch1_enable">
          <div class="span7">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal1"  text="Ch1 Select" runat="server" ></asp:literal></h5>
                    <div id="checkboxCh"><asp:checkbox Checked="True" runat="server" ID="ch1_val" class="inputlog" ></asp:checkbox></div>
                    <div id="checkboxCh"><asp:Label runat="server" ID="ch1_val_label" class="labellog" Text="ch1"></asp:Label> </div> 
                    <div id="checkboxCh"><asp:checkbox runat="server" ID="ch1_feed" class="inputlog" ></asp:checkbox></div>
                    <div id="checkboxCh"><asp:Label runat="server" ID="ch1_feed_label" class="labellog" Text="Min/Max" ></asp:Label> </div> 
                    <div id="checkboxCh"><asp:checkbox runat="server" ID="ch1_dos" class="inputlog" ></asp:checkbox></div>
                    <div id="checkboxCh"><asp:Label runat="server" ID="ch1_dos_label"  class="labellog" Text="Dos Alarm" ></asp:Label> </div> 
                    <div id="checkboxCh"><asp:checkbox runat="server" ID="ch1_probe" class="inputlog" ></asp:checkbox></div>
                    <div id="checkboxCh"><asp:Label runat="server" ID="ch1_probe_label"  class="labellog" Text="Probe Fail" ></asp:Label> </div> 
                    <div id="checkboxCh"><asp:checkbox runat="server" ID="ch1_livello1" class="inputlog" ></asp:checkbox></div>
                    <div id="checkboxCh"><asp:Label runat="server" ID="ch1_livello1_label"  class="labellog" Text="Level 1" ></asp:Label> </div> 
              </div> 
                </asp:placeholder>
        <!-- fine riga -->
            </div>
<div class="row-fluid">
        <!-- riga -->
            <asp:placeholder runat="server" ID="ch2_enable">
          <div class="span6">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal2"  text="Ch2 Select" runat="server" ></asp:literal></h5>
               <div id="checkboxCh"><asp:checkbox runat="server" ID="ch2_val" class="inputlog" ></asp:checkbox></div>
                    <div id="checkboxCh"><asp:Label runat="server" ID="ch2_val_label" class="labellog" Text="ch2" ></asp:Label> </div> 
                    <div id="checkboxCh"><asp:checkbox runat="server" ID="ch2_feed" class="inputlog" ></asp:checkbox></div>
                    <div id="checkboxCh"><asp:Label runat="server" ID="ch2_feed_label" class="labellog" Text="Min/Max" ></asp:Label> </div> 
                    <div id="checkboxCh"><asp:checkbox runat="server" ID="ch2_dos" class="inputlog" ></asp:checkbox></div>
                    <div id="checkboxCh"><asp:Label runat="server" ID="ch2_dos_label"  class="labellog" Text="Dos Alarm" ></asp:Label> </div> 
                    <div id="checkboxCh"><asp:checkbox runat="server" ID="ch2_probe" class="inputlog" ></asp:checkbox></div>
                    <div id="checkboxCh"><asp:Label runat="server" ID="ch2_probe_label"  class="labellog" Text="Probe Fail" ></asp:Label> </div> 
                    <div id="checkboxCh"><asp:checkbox runat="server" ID="ch2_level1" class="inputlog"></asp:checkbox></div>
                    <div id="checkboxCh"><asp:Label runat="server" ID="ch2_level2_label"  class="labellog" Text="Level 1" ></asp:Label> </div> 
            </div>
                </asp:placeholder>
</div>
        <!-- fine riga -->

        <!-- riga -->
<div class="row-fluid">            
            <asp:placeholder runat="server" ID="ch3_enable">
          <div class="span6">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal3"  text="Ch3 Select" runat="server" meta:resourcekey="Literal3Resource1"></asp:literal></h5>
              
                                <div id="checkboxCh"><asp:checkbox runat="server" ID="ch3_val" class="inputlog" ></asp:checkbox></div>
                    <div id="checkboxCh"><asp:Label runat="server" ID="ch3_val_label" class="labellog" Text="ch3" ></asp:Label> </div> 
                    <div id="checkboxCh"><asp:checkbox runat="server" ID="ch3_feed" class="inputlog" ></asp:checkbox></div>
                    <div id="checkboxCh"><asp:Label runat="server" ID="ch3_feed_label" class="labellog" Text="Min/Max" ></asp:Label> </div> 

              </div>
             </asp:placeholder>
</div>
        <!-- fine riga -->
        <!-- riga -->
<div class="row-fluid">            
            <asp:placeholder runat="server" ID="ch4_enable">
          <div class="span6">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal4"  text="Ch3 Select" runat="server" meta:resourcekey="Literal3Resource1"></asp:literal></h5>
              
                                <div id="checkboxCh"><asp:checkbox runat="server" ID="ch4_val" class="inputlog" ></asp:checkbox></div>
                    <div id="checkboxCh"><asp:Label runat="server" ID="ch4_val_label" class="labellog" Text="ch4" ></asp:Label> </div> 
                    <div id="checkboxCh"><asp:checkbox runat="server" ID="ch4_feed" class="inputlog" ></asp:checkbox></div>
                    <div id="checkboxCh"><asp:Label runat="server" ID="ch4_feed_label" class="labellog" Text="Min/Max" ></asp:Label> </div> 

              </div>
             </asp:placeholder>
</div>
        <!-- fine riga -->

<div class="row-fluid">         
        <!-- riga -->
            <asp:placeholder runat="server" ID="Placeholder1">
        
          <div class="span6">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal6"  text="Input" runat="server" ></asp:literal></h5>
              <div id="checkboxCh"><asp:checkbox Checked="True" runat="server" ID="flow_select" class="inputlog" ></asp:checkbox></div>
              <div id="checkboxCh"><asp:Label runat="server" ID="label_flow_select" class="labellog" Text="Flow" ></asp:Label> </div>
              <div id="checkboxCh"><asp:checkbox runat="server" ID="temperature_select" class="inputlog" ></asp:checkbox></div>
              <div id="checkboxCh"><asp:Label runat="server" ID="label_temperature_select" class="labellog" Text="Temperature" ></asp:Label> </div>
              <div id="checkboxCh"><asp:checkbox runat="server" ID="m3h" class="inputlog" ></asp:checkbox></div>
              <div id="checkboxCh"><asp:Label runat="server" ID="m3h_label" class="labellog" Text="m3/h" ></asp:Label> </div>
              <div id="checkboxCh"><asp:checkbox runat="server" ID="flow_mtr" class="inputlog" ></asp:checkbox></div>
              <div id="checkboxCh"><asp:Label runat="server" ID="label_flow_meter" class="labellog" Text="FlowMeterLow" ></asp:Label> </div>

              </div>
                </asp:placeholder>
            </div>
                
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
	<script type="text/javascript" src="chart/report_manage_ld4.js"></script>
    <script src="theme/scripts/plugins/tables/DataTables/media/js/DT_bootstrap.js"></script>
	
	<!-- Tables Demo Script -->
	<script src="theme/scripts/demo/tables.js"></script>
    
    </form>

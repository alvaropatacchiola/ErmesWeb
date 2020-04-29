<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/main.Master" CodeBehind="usb_log_graph.aspx.vb" Inherits="ermes_web_20.usb_log_graph" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="chart/js/css/jquery.dataTables.css" rel="stylesheet" />
    <link href="chart/js/css/dataTables.tableTools.css" rel="stylesheet" />
    
    <script type="text/javascript" src="chart/localCent/jquery.dataTables.js"></script>
<script type="text/javascript" src="chart/localCent/jquery.dataTables.min.js"></script>
<script type="text/javascript" src="chart/localCent/dataTables.buttons.min.js"></script>
<script type="text/javascript" src="chart/localCent/buttons.flash.min.js"></script>
<script type="text/javascript" src="chart/localCent/jszip.min.js"></script>
<script type="text/javascript" src="chart/localCent/pdfmake.min.js"></script>
<script type="text/javascript" src="chart/localCent/vfs_fonts.js"></script>
<script type="text/javascript" src="chart/localCent/buttons.html5.min.js"></script>
<script type="text/javascript" src="chart/localCent/buttons.print.min.js"></script>
<link href="chart/localCent/buttons.dataTables.min.css" rel="stylesheet" />

   <!-- <script src="chart/js/jquery.dataTables.js"></script>
    <script src="chart/js/dataTables.tableTools.js"></script> -->
   

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="content">
        <h3 class="heading-mosaic"><asp:Literal ID="Literal4" runat="server" Text="Log Graph." ></asp:Literal></h3>

<asp:PlaceHolder ID="tower_enable" runat="server">
        <div class="innerLR">

        <div class="widget">
            <div id="head_log" class="widget-head">
                <h4 class="heading glyphicons show_thumbnails_with_lines"><asp:literal text="Log Settings" runat="server"  ID="log_setting_id" meta:resourcekey="log_setting_idResource1"></asp:literal></h4>
                <!--
                <span class="collapse-toggle"></span>
                -->
                <span style=" position: relative; height: 29px; width: 30px; display: block; cursor: pointer; float: right; margin-right: -10px;">
                    
                    <img src="chart/js/images/arrow_sort_down.png">

                </span>
                
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</div>
            <div id="log_collapse" class="widget-body list" style="height: auto;">
                <div class="box-generic">
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

                            <div class="span12" id="ch1_enable">
                                <h5 style="padding-top:10px">
                                    <asp:Literal ID="Literal1" runat="server" text="Ch1 Select" meta:resourcekey="Literal1Resource1"></asp:Literal>
                                </h5>
                                <div id="checkboxCh">
                                    <asp:CheckBox ID="ch1_val" runat="server" Checked="True" class="inputlog" meta:resourcekey="ch1_valResource1" ClientIDMode="Static" />
                                </div>
                                <div id="checkboxCh">
                                    <asp:Label ID="ch1_val_label" runat="server" class="labellog" Text="ch1" meta:resourcekey="ch1_val_labelResource1" ClientIDMode="Static"></asp:Label>
                                </div>
                                <div id="checkboxCh">
                                    <asp:CheckBox ID="ch1_high" runat="server" class="inputlog" meta:resourcekey="ch1_highResource1" ClientIDMode="Static" />
                                </div>
                                <div id="checkboxCh">
                                    <asp:Label ID="ch1_high_label" runat="server" class="labellog" Text="High" meta:resourcekey="ch1_high_labelResource1" ClientIDMode="Static"></asp:Label>
                                </div>
                                <div id="checkboxCh">
                                    <asp:CheckBox ID="ch1_low" runat="server" class="inputlog" meta:resourcekey="ch1_lowResource1" ClientIDMode="Static" />
                                </div>
                                <div id="checkboxCh">
                                    <asp:Label ID="ch1_low_label" runat="server" class="labellog" Text="Low" meta:resourcekey="ch1_low_labelResource1" ClientIDMode="Static"></asp:Label>
                                </div>
                                <div id="checkboxCh">
                                    <asp:CheckBox ID="ch1_bleed" runat="server" class="inputlog" meta:resourcekey="ch1_bleedResource1" ClientIDMode="Static" />
                                </div>
                                <div id="checkboxCh">
                                    <asp:Label ID="ch1_bleed_label" runat="server" class="labellog" Text="Probe Fail" meta:resourcekey="ch1_bleed_labelResource1" ClientIDMode="Static"></asp:Label>
                                </div>
                                <div id="checkboxCh">
                                    <asp:CheckBox ID="ch1_livello_inhibitor" runat="server" class="inputlog" meta:resourcekey="ch1_livello_inhibitorResource1" ClientIDMode="Static" />
                                </div>
                                <div id="checkboxCh">
                                    <asp:Label ID="ch1_livello_inhibitor_label" runat="server" class="labellog" Text="Level Inhibitor" meta:resourcekey="ch1_livello_inhibitor_labelResource1" ClientIDMode="Static"></asp:Label>
                                </div>
                                <div id="checkboxCh">
                                    <asp:CheckBox ID="ch1_livello_prebiocide1" runat="server" class="inputlog" meta:resourcekey="ch1_livello_prebiocide1Resource1" ClientIDMode="Static" />
                                </div>
                                <div id="checkboxCh">
                                    <asp:Label ID="ch1_livello_prebiocide1_label" runat="server" class="labellog" Text="Prebiocide 1" meta:resourcekey="ch1_livello_prebiocide1_labelResource1" ClientIDMode="Static"></asp:Label>
                                </div>
                                <div id="checkboxCh">
                                    <asp:CheckBox ID="ch1_livello_prebiocide2" runat="server" class="inputlog" meta:resourcekey="ch1_livello_prebiocide2Resource1" ClientIDMode="Static" />
                                </div>
                                <div id="checkboxCh">
                                    <asp:Label ID="ch1_livello_prebiocide2_label" runat="server" class="labellog" Text="Prebiocide 2" meta:resourcekey="ch1_livello_prebiocide2_labelResource1" ClientIDMode="Static"></asp:Label>
                                </div>

                                <div id="checkboxCh">
                                    <asp:CheckBox ID="ch1_livello_biocide1" runat="server" class="inputlog" meta:resourcekey="ch1_livello_biocide1Resource1" ClientIDMode="Static" />
                                </div>
                                <div id="checkboxCh">
                                    <asp:Label ID="ch1_livello_biocide1_label" runat="server" class="labellog" Text="Biocide 1" meta:resourcekey="ch1_livello_biocide1_labelResource1" ClientIDMode="Static"></asp:Label>
                                </div>
                                <div id="checkboxCh">
                                    <asp:CheckBox ID="ch1_livello_biocide2" runat="server" class="inputlog" meta:resourcekey="ch1_livello_biocide2Resource1" ClientIDMode="Static" />
                                </div>
                                <div id="checkboxCh">
                                    <asp:Label ID="ch1_livello_biocide2_label" runat="server" class="labellog" Text="Biocide 2" meta:resourcekey="ch1_livello_biocide2_labelResource1" ClientIDMode="Static"></asp:Label>
                                </div>

                            </div>

        <!-- fine riga -->
                    </div>
                    <div class="row-fluid">
        <!-- riga -->

                            <div class="span6" id="ch2_enable">
                                <h5 style="padding-top:10px">
                                    <asp:Literal ID="Literal2" runat="server" text="Ch2 Select" meta:resourcekey="Literal2Resource1"></asp:Literal>
                                </h5>
                                <div id="checkboxCh">
                                    <asp:CheckBox ID="ch2_val" runat="server" class="inputlog" meta:resourcekey="ch2_valResource1" ClientIDMode="Static" Checked="False" />
                                </div>
                                <div id="checkboxCh">
                                    <asp:Label ID="ch2_val_label" runat="server" class="labellog" Text="ch2" meta:resourcekey="ch2_val_labelResource1" ClientIDMode="Static"></asp:Label>
                                </div>
                                <div id="checkboxCh">
                                    <asp:CheckBox ID="ch2_high" runat="server" class="inputlog" meta:resourcekey="ch2_highResource1" ClientIDMode="Static" />
                                </div>
                                <div id="checkboxCh">
                                    <asp:Label ID="ch2_high_label" runat="server" class="labellog" Text="High" meta:resourcekey="ch2_high_labelResource1" ClientIDMode="Static"></asp:Label>
                                </div>
                                <div id="checkboxCh">
                                    <asp:CheckBox ID="ch2_low" runat="server" class="inputlog" meta:resourcekey="ch2_lowResource1" ClientIDMode="Static" />
                                </div>
                                <div id="checkboxCh">
                                    <asp:Label ID="ch2_low_label" runat="server" class="labellog" Text="Low" meta:resourcekey="ch2_low_labelResource1" ClientIDMode="Static"></asp:Label>
                                </div>
                                <div id="checkboxCh">
                                    <asp:CheckBox ID="ch2_livello" runat="server" class="inputlog" meta:resourcekey="ch2_livelloResource1" ClientIDMode="Static" />
                                </div>
                                <div id="checkboxCh">
                                    <asp:Label ID="ch2_livello_label" runat="server" class="labellog" Text="Level" meta:resourcekey="ch2_livello_labelResource1" ClientIDMode="Static"></asp:Label>
                                </div>
                               
                            </div>
                        
                    </div>
        <!-- fine riga -->
        <!-- riga -->
                    <div class="row-fluid">
                            <div class="span6" id="ch3_enable">
                                <h5 style="padding-top:10px">
                                    <asp:Literal ID="Literal3" runat="server" text="Ch3 Select" meta:resourcekey="Literal3Resource1"></asp:Literal>
                                </h5>
                                <div id="checkboxCh">
                                    <asp:CheckBox ID="ch3_val" runat="server" class="inputlog" meta:resourcekey="ch3_valResource1" ClientIDMode="Static" />
                                </div>
                                <div id="checkboxCh">
                                    <asp:Label ID="ch3_val_label" runat="server" class="labellog" Text="ch3" meta:resourcekey="ch3_val_labelResource1" ClientIDMode="Static"></asp:Label>
                                </div>
                                <div id="checkboxCh">
                                    <asp:CheckBox ID="ch3_high" runat="server" class="inputlog" meta:resourcekey="ch3_highResource1" ClientIDMode="Static" />
                                </div>
                                <div id="checkboxCh">
                                    <asp:Label ID="ch3_high_label" runat="server" class="labellog" Text="High" meta:resourcekey="ch3_high_labelResource1" ClientIDMode="Static"></asp:Label>
                                </div>
                                <div id="checkboxCh">
                                    <asp:CheckBox ID="ch3_low" runat="server" class="inputlog" meta:resourcekey="ch3_lowResource1" ClientIDMode="Static" />
                                </div>
                                <div id="checkboxCh">
                                    <asp:Label ID="ch3_low_label" runat="server" class="labellog" Text="Low" meta:resourcekey="ch3_low_labelResource1" ClientIDMode="Static"></asp:Label>
                                </div>
                                <div id="checkboxCh">
                                    <asp:CheckBox ID="ch3_livello" runat="server" class="inputlog" meta:resourcekey="ch3_livelloResource1" ClientIDMode="Static" />
                                </div>
                                <div id="checkboxCh">
                                    <asp:Label ID="ch3_livello_label" runat="server" class="labellog" Text="Level" meta:resourcekey="ch3_livello_labelResource1" ClientIDMode="Static"></asp:Label>
                                </div>

                            </div>

        <!-- fine riga -->
       
        <!-- riga -->
                        <asp:PlaceHolder ID="Placeholder1" runat="server">
                            <div class="span6">
                                <h5 style="padding-top:10px">
                                    <asp:Literal ID="Literal6" runat="server" text="Input" meta:resourcekey="Literal6Resource1"></asp:Literal>
                                </h5>
                                <div id="checkboxCh">
                                    <asp:CheckBox ID="flow_select" runat="server" Checked="True" class="inputlog" meta:resourcekey="flow_selectResource1" ClientIDMode="Static" />
                                </div>
                                <div id="checkboxCh">
                                    <asp:Label ID="label_flow_select" runat="server" class="labellog" Text="Flow" meta:resourcekey="label_flow_selectResource1" ClientIDMode="Static"></asp:Label>
                                </div>
                                <div id="checkboxCh">
                                    <asp:CheckBox ID="temperature_select" runat="server" class="inputlog" meta:resourcekey="temperature_selectResource1" ClientIDMode="Static" />
                                </div>
                                <div id="checkboxCh">
                                    <asp:Label ID="label_temperature_select" runat="server" class="labellog" Text="Temperature" meta:resourcekey="label_temperature_selectResource1" ClientIDMode="Static"></asp:Label>
                                </div>
                                <div id="checkboxCh">
                                    <asp:CheckBox ID="wmi_select" runat="server" class="inputlog" meta:resourcekey="wmi_selectResource1" ClientIDMode="Static" />
                                </div>
                                <div id="checkboxCh">
                                    <asp:Label ID="label_wmi_select" runat="server" class="labellog" Text="WMI" meta:resourcekey="label_wmi_selectResource1" ClientIDMode="Static"></asp:Label>
                                </div>
                                <div id="checkboxCh">
                                    <asp:CheckBox ID="wmb_select" runat="server" class="inputlog" meta:resourcekey="wmb_selectResource1" ClientIDMode="Static" />
                                </div>
                                <div id="checkboxCh">
                                    <asp:Label ID="label_wmb_select" runat="server" class="labellog" Text="WMB" meta:resourcekey="label_wmb_selectResource1" ClientIDMode="Static"></asp:Label>
                                </div>

                            </div>
                            </div>
                        </asp:PlaceHolder>
        <!-- fine riga -->
     <!-- riga -->
<div class="row-fluid">
        <div class="span6">
            <h5 style="padding-top:10px"><asp:literal ID = "Literal40"  text="Filter" runat="server" meta:resourcekey="Literal11Resource1"></asp:literal></h5>
         <div id="checkboxCh"><asp:CheckBox ID="select_filter" runat="server" class="inputlog"  ClientIDMode="Static" /></div>
         <div id="checkboxCh"><asp:literal ID = "label_filter"  Text="Alarm" runat="server"></asp:literal></div>

              </div>
    </div> 
        
        <!-- fine riga -->

     <!-- riga -->
<div class="row-fluid">
        <div class="span6">
            <h5 style="padding-top:10px"><asp:literal ID = "Literal11"  text="Log Range" runat="server" meta:resourcekey="Literal11Resource1"></asp:literal></h5>
         <div id="checkboxCh"><h5 style="padding-top:10px"><asp:literal ID = "Literal10"  text="From" runat="server" meta:resourcekey="Literal10Resource1"></asp:literal></h5></div>
         <div id="checkboxCh"><asp:textbox ID="graph_log_from"   class="span12"  runat="server" meta:resourcekey="graph_log_fromResource1"  ClientIDMode="Static"></asp:textbox></div>
         <div id="checkboxCh"><h5 style="padding-top:10px"><asp:literal ID = "Literal9"  text="To" runat="server" meta:resourcekey="Literal9Resource1"></asp:literal></h5></div>
         <div id="checkboxCh"><asp:textbox ID="graph_log_to"   class="span12"  runat="server" meta:resourcekey="graph_log_toResource1"  ClientIDMode="Static"></asp:textbox></div>

              </div>
    </div> 
        
        <!-- fine riga -->
	                </div>
                    <div id="salva" class="btn-primary">
                        <b class="btn-primary btn-icon glyphicons ok">
                        <asp:Button ID="refresh_graph" runat="server" class="btn-primary" Font-Bold="True" text="Refresh Graph" meta:resourcekey="refresh_graphResource1" ClientIDMode="Static" />
                        </b>
                    </div>
                </div>
            </div>
            <div id="chart_div" style="height: 700px; min-width: 500px">
                <div id="principale" class="innerLR" >

         
</div>
            </div>
    <h3 class="heading-mosaic"><asp:Literal ID="Literal5" runat="server" Text="Report." ></asp:Literal></h3>
            <div id="chart_table" >
            </div>

           <asp:Button ID="refresh_log_server" runat="server" BackColor="Transparent" BorderColor="Transparent" meta:resourcekey="refresh_log_serverResource1"  />
    <asp:literal runat="server" ID="literal_script" meta:resourcekey="literal_scriptResource1"></asp:literal>
    
    <script type="text/javascript" src="chart/chart_manage_tower_usb.js?v=1.1"></script>
     <div id="indietro" class="btn-primary">
        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/log_usb_list.aspx" meta:resourcekey="HyperLink1Resource1"><b style="width:100%" class="btn-primary btn-icon glyphicons circle_arrow_left"  ><i></i>Back</b></asp:HyperLink></div>
</div>

        </div>
    
   </div> 
</asp:PlaceHolder>
<asp:PlaceHolder ID="ld_enable" runat="server">
<div class="innerLR">

      

  <div class="widget" >
	<div id="head_log" class="widget-head"><h4 class="heading glyphicons show_thumbnails_with_lines"><asp:literal text="Log Settings" runat="server"  ID="Literal7" meta:resourcekey="log_setting_idResource1"></asp:literal></h4>
<span style=" position: relative; height: 29px; width: 30px; display: block; cursor: pointer; float: right; margin-right: -10px;">
                    
                    <img src="chart/js/images/arrow_sort_down.png">

                </span>
	&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</div>
	<div id="log_collapse" class="widget-body list" style="height: auto;">
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
            
<!--<asp:placeholder runat="server" ID="ch1_enable_ld">-->
          <div class="span7" id="ch1_enable_ld">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal8"  text="Ch1 Select" runat="server" meta:resourcekey="Literal1Resource1"></asp:literal></h5>
                    <div id="checkboxCh"><asp:checkbox Checked="True" runat="server" ID="ch1_val_ld" class="inputlog" meta:resourcekey="ch1_valResource1" ClientIDMode="Static"></asp:checkbox></div>
                    <div id="checkboxCh"><asp:Label runat="server" ID="ch1_val_label_ld" class="labellog" Text="ch1" meta:resourcekey="ch1_val_labelResource1" ClientIDMode="Static"></asp:Label> </div> 
                    <div id="checkboxCh"><asp:checkbox runat="server" ID="ch1_feed" class="inputlog" meta:resourcekey="ch1_feedResource1" ClientIDMode="Static"></asp:checkbox></div>
                    <div id="checkboxCh"><asp:Label runat="server" ID="ch1_feed_label" class="labellog" Text="Feed Limit" meta:resourcekey="ch1_feed_labelResource1" ClientIDMode="Static"></asp:Label> </div> 
                    <div id="checkboxCh"><asp:checkbox runat="server" ID="ch1_dos" class="inputlog" meta:resourcekey="ch1_dosResource1" ClientIDMode="Static"></asp:checkbox></div>
                    <div id="checkboxCh"><asp:Label runat="server" ID="ch1_dos_label"  class="labellog" Text="Dos Alarm" meta:resourcekey="ch1_dos_labelResource1" ClientIDMode="Static"></asp:Label> </div> 
                    <div id="checkboxCh"><asp:checkbox runat="server" ID="ch1_probe" class="inputlog" meta:resourcekey="ch1_probeResource1" ClientIDMode="Static"></asp:checkbox></div>
                    <div id="checkboxCh"><asp:Label runat="server" ID="ch1_probe_label"  class="labellog" Text="Probe Fail" meta:resourcekey="ch1_probe_labelResource1" ClientIDMode="Static"></asp:Label> </div> 
                    <div id="checkboxCh"><asp:checkbox runat="server" ID="ch1_livello1" class="inputlog" meta:resourcekey="ch1_livello1Resource1" ClientIDMode="Static"></asp:checkbox></div>
                    <div id="checkboxCh"><asp:Label runat="server" ID="ch1_livello1_label"  class="labellog" Text="Level 1" meta:resourcekey="ch1_livello1_labelResource1" ClientIDMode="Static"></asp:Label> </div> 
                    <div id="checkboxCh"><asp:checkbox runat="server" ID="ch1_livello2" class="inputlog" meta:resourcekey="ch1_livello2Resource1" ClientIDMode="Static"></asp:checkbox></div>
                    <div id="checkboxCh"><asp:Label runat="server" ID="ch1_livello2_label"  class="labellog" Text="Level 2" meta:resourcekey="ch1_livello2_labelResource1" ClientIDMode="Static"></asp:Label> </div> 
              </div> 
               <!-- </asp:placeholder>-->
        <!-- fine riga -->
            </div>
<div class="row-fluid">
        <!-- riga -->
        <!--    <asp:placeholder runat="server" ID="ch2_enable_ld">-->
          <div class="span6" id="ch2_enable_ld">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal12"  text="Ch2 Select" runat="server" meta:resourcekey="Literal2Resource1"></asp:literal></h5>
               <div id="checkboxCh"><asp:checkbox Checked="True" runat="server" ID="ch2_val_ld" class="inputlog" meta:resourcekey="ch2_valResource1" ClientIDMode="Static"></asp:checkbox></div>
                    <div id="checkboxCh"><asp:Label runat="server" ID="ch2_val_label_ld" class="labellog" Text="ch2" meta:resourcekey="ch2_val_labelResource1" ClientIDMode="Static"></asp:Label> </div> 
                    <div id="checkboxCh"><asp:checkbox runat="server" ID="ch2_feed" class="inputlog" meta:resourcekey="ch2_feedResource1" ClientIDMode="Static"></asp:checkbox></div>
                    <div id="checkboxCh"><asp:Label runat="server" ID="ch2_feed_label" class="labellog" Text="Feed Limit" meta:resourcekey="ch2_feed_labelResource1" ClientIDMode="Static"></asp:Label> </div> 
                    <div id="checkboxCh"><asp:checkbox runat="server" ID="ch2_dos" class="inputlog" meta:resourcekey="ch2_dosResource1" ClientIDMode="Static"></asp:checkbox></div>
                    <div id="checkboxCh"><asp:Label runat="server" ID="ch2_dos_label"  class="labellog" Text="Dos Alarm" meta:resourcekey="ch2_dos_labelResource1" ClientIDMode="Static"></asp:Label> </div> 
                    <div id="checkboxCh"><asp:checkbox runat="server" ID="ch2_probe" class="inputlog" meta:resourcekey="ch2_probeResource1" ClientIDMode="Static"></asp:checkbox></div>
                    <div id="checkboxCh"><asp:Label runat="server" ID="ch2_probe_label"  class="labellog" Text="Probe Fail" meta:resourcekey="ch2_probe_labelResource1" ClientIDMode="Static"></asp:Label> </div> 
                    <div id="checkboxCh"><asp:checkbox runat="server" ID="ch2_level1" class="inputlog" meta:resourcekey="ch2_level1Resource1" ClientIDMode="Static"></asp:checkbox></div>
                    <div id="checkboxCh"><asp:Label runat="server" ID="ch2_level2_label"  class="labellog" Text="Level 1" meta:resourcekey="ch2_level2_labelResource1" ClientIDMode="Static"></asp:Label> </div> 
            </div>
                <!--</asp:placeholder>-->
</div>
        <!-- fine riga -->
        <!-- riga -->
<div class="row-fluid">            
            <!--<asp:placeholder runat="server" ID="ch3_enable_ld">-->
          <div class="span6" id="ch3_enable_ld">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal13"  text="Ch3 Select" runat="server" meta:resourcekey="Literal3Resource1"></asp:literal></h5>
              
                                <div id="checkboxCh"><asp:checkbox runat="server" ID="ch3_val_ld" class="inputlog" meta:resourcekey="ch3_valResource1" ClientIDMode="Static"></asp:checkbox></div>
                    <div id="checkboxCh"><asp:Label runat="server" ID="ch3_val_label_ld" class="labellog" Text="ch3" meta:resourcekey="ch3_val_labelResource1" ClientIDMode="Static"></asp:Label> </div> 

              </div>
             <!--</asp:placeholder>-->

        <!-- fine riga -->
<!--<asp:placeholder runat="server" ID="flow_meter_enable">-->
    <div class="row-fluid" id="flow_meter_enable">  
          <div class="span6">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal256"  text="Flow Meter" runat="server" ></asp:literal></h5>
              <div id="checkboxCh"><asp:checkbox  runat="server" ID="m3h_ld" class="inputlog" ClientIDMode="Static"></asp:checkbox></div>
              <div id="checkboxCh"><asp:Label runat="server" ID="m3h_label_ld" class="labellog" Text="m3/h" ClientIDMode="Static"></asp:Label> </div>
              <div id="checkboxCh"><asp:checkbox runat="server" ID="totalizer_ld" class="inputlog" ClientIDMode="Static"></asp:checkbox></div>
              <div id="checkboxCh"><asp:Label runat="server" ID="totalizer_label_ld" class="labellog" Text="Totalizer" ClientIDMode="Static"></asp:Label> </div>
              </div>

        </div>
<!--</asp:placeholder>     -->     
        <!-- riga -->
        
          <div class="span6">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal14"  text="Input" runat="server" meta:resourcekey="Literal6Resource1"></asp:literal></h5>
              <div id="checkboxCh"><asp:checkbox Checked="True" runat="server" ID="flow_select_ld" class="inputlog" meta:resourcekey="flow_selectResource1" ClientIDMode="Static"></asp:checkbox></div>
              <div id="checkboxCh"><asp:Label runat="server" ID="label_flow_select_ld" class="labellog" Text="Flow" meta:resourcekey="label_flow_selectResource1" ClientIDMode="Static"></asp:Label> </div>
<div id="stby_enable">
              <div id="checkboxCh"><asp:checkbox  runat="server" ID="stby_ld" class="inputlog" ClientIDMode="Static"></asp:checkbox></div>
              <div id="checkboxCh"><asp:Label runat="server" ID="stby_label_ld" class="labellog" Text="Stby" ClientIDMode="Static"></asp:Label> </div>
</div>  

              <div id="checkboxCh"><asp:checkbox runat="server" ID="temperature_select_ld" class="inputlog" meta:resourcekey="temperature_selectResource1" ClientIDMode="Static"></asp:checkbox></div>
              <div id="checkboxCh"><asp:Label runat="server" ID="label_temperature_select_ld" class="labellog" Text="Temperature" meta:resourcekey="label_temperature_selectResource1" ClientIDMode="Static"></asp:Label> </div>
              </div>
            </div>
        <!-- fine riga -->
          <!-- riga -->
<div class="row-fluid">
        <div class="span6">
            <h5 style="padding-top:10px"><asp:literal ID = "Literal15"  text="Log Range" runat="server" meta:resourcekey="Literal11Resource1"></asp:literal></h5>
         <div id="checkboxCh"><h5 style="padding-top:10px"><asp:literal ID = "Literal16"  text="From" runat="server" meta:resourcekey="Literal10Resource1"></asp:literal></h5></div>
         <div id="checkboxCh"><asp:textbox ID="graph_log_from_ld"   class="span12"  runat="server" meta:resourcekey="graph_log_fromResource1"  ClientIDMode="Static"></asp:textbox></div>
         <div id="checkboxCh"><h5 style="padding-top:10px"><asp:literal ID = "Literal17"  text="To" runat="server" meta:resourcekey="Literal9Resource1"></asp:literal></h5></div>
         <div id="checkboxCh"><asp:textbox ID="graph_log_to_ld"   class="span12"  runat="server" meta:resourcekey="graph_log_toResource1"  ClientIDMode="Static"></asp:textbox></div>

              </div>
    </div> 
        
        <!-- fine riga -->
	</div>
       <div id="salva"   class="btn-primary">
                   <b class="btn-primary btn-icon glyphicons ok"><asp:button runat="server" ID="refresh_graph_ld" class="btn-primary"  text="Refresh Graph" Font-Bold="True" meta:resourcekey="refresh_graphResource1" ClientIDMode="Static" /><i></i></b>

            </div>

	</div>
</div>
    <div id="chart_div" style="height: 700px; min-width: 500px">
        <div id="principale" class="innerLR" >

         
</div>
    </div>
    <h3 class="heading-mosaic"><asp:Literal ID="Literal19" runat="server" Text="Report." ></asp:Literal></h3>
            <div id="chart_table_ld" >
            </div>

          <asp:Button ID="refresh_log_server_ld" runat="server" BackColor="Transparent" BorderColor="Transparent" meta:resourcekey="refresh_log_serverResource1"  />
    <asp:literal runat="server" ID="literal_script_ld" ></asp:literal>

    <script type="text/javascript" src="chart/chart_manage_ld_usb.js?v=1.1"></script>
     <div id="Div1" class="btn-primary">
        <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/log_usb_list.aspx" meta:resourcekey="HyperLink1Resource1"><b style="width:100%" class="btn-primary btn-icon glyphicons circle_arrow_left"  ><i></i>torna all'impianto</b></asp:HyperLink></div>
</div>

       </div> 	
        </asp:PlaceHolder> 
<asp:PlaceHolder ID="max5_enable" runat="server">   
<div class="innerLR">

      
      
  <div class="widget" >
	<div id="head_log" class="widget-head"><h4 class="heading glyphicons show_thumbnails_with_lines"><asp:literal text="Log Settings" runat="server"  ID="Literal27" meta:resourcekey="log_setting_idResource1"></asp:literal></h4>
<span style=" position: relative; height: 29px; width: 30px; display: block; cursor: pointer; float: right; margin-right: -10px;">
                    
                    <img src="chart/js/images/arrow_sort_down.png">

                </span>
	&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</div>
	<div id="log_collapse" class="widget-body list" style="height: auto;">
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
            
<asp:placeholder runat="server" ID="ch1_enable_max5">
          <div class="span12">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal29"  text="Ch1 Select" runat="server" meta:resourcekey="Literal1Resource1"></asp:literal></h5>
                    <div id="checkboxCh"><asp:checkbox Checked="True" ClientIDMode="Static" runat="server" ID="ch1_val_max5" class="inputlog" meta:resourcekey="ch1_valResource1"></asp:checkbox></div>
                    <div id="checkboxCh"><asp:Label runat="server" ID="ch1_val_label_max5" class="labellog" Text="ch1" meta:resourcekey="ch1_val_labelResource1"></asp:Label> </div> 


<asp:placeholder runat="server" ID="ch1_aa_enable">
                    <div id="checkboxCh"><asp:checkbox runat="server" ClientIDMode="Static" ID="ch1_aa" class="inputlog" meta:resourcekey="ch1_aaResource1"></asp:checkbox></div>
                    <div id="checkboxCh"><asp:Label runat="server" ID="ch1_aa_label" class="labellog" Text="Alarm Aa" meta:resourcekey="ch1_aa_labelResource1"></asp:Label> </div> 
</asp:placeholder>
<asp:placeholder runat="server" ID="ch1_ab_enable">
                    <div id="checkboxCh"><asp:checkbox runat="server" ClientIDMode="Static" ID="ch1_ab" class="inputlog" meta:resourcekey="ch1_abResource1"></asp:checkbox></div>
                    <div id="checkboxCh"><asp:Label runat="server" ID="ch1_ab_label"  class="labellog" Text="Alarm Ab" meta:resourcekey="ch1_ab_labelResource1"></asp:Label> </div> 
</asp:placeholder>
<asp:placeholder runat="server" ID="ch1_ad_enable">
                    <div id="checkboxCh"><asp:checkbox runat="server" ClientIDMode="Static" ID="ch1_ad" class="inputlog" meta:resourcekey="ch1_adResource1"></asp:checkbox></div>
                    <div id="checkboxCh"><asp:Label runat="server" ID="ch1_ad_label"  class="labellog" Text="Alarm Ad" meta:resourcekey="ch1_ad_labelResource1"></asp:Label> </div> 
</asp:placeholder>
<asp:placeholder runat="server" ID="ch1_ar_enable">
                    <div id="checkboxCh"><asp:checkbox runat="server" ClientIDMode="Static" ID="ch1_ar" class="inputlog" meta:resourcekey="ch1_arResource1"></asp:checkbox></div>
                    <div id="checkboxCh"><asp:Label runat="server" ID="ch1_ar_label"  class="labellog" Text="Alarm Ar" meta:resourcekey="ch1_ar_labelResource1"></asp:Label> </div> 
</asp:placeholder>
              </div> 
                </asp:placeholder>
        <!-- fine riga -->
</div>
<div class="row-fluid">
        <!-- riga -->
            <asp:placeholder runat="server" ID="ch2_enable_max5">
          <div class="span12">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal30"  text="Ch2 Select" runat="server" meta:resourcekey="Literal2Resource1"></asp:literal></h5>
               <div id="checkboxCh"><asp:checkbox runat="server"  ClientIDMode="Static" ID="ch2_val_max5" class="inputlog" meta:resourcekey="ch2_valResource1"></asp:checkbox></div>
                    <div id="checkboxCh"><asp:Label runat="server" ID="ch2_val_label_max5" class="labellog" Text="ch2" meta:resourcekey="ch2_val_labelResource1"></asp:Label> </div> 


<asp:placeholder runat="server" ID="ch2_aa_enable">
                    <div id="checkboxCh"><asp:checkbox runat="server" ClientIDMode="Static" ID="ch2_aa" class="inputlog" meta:resourcekey="ch2_aaResource1"></asp:checkbox></div>
                    <div id="checkboxCh"><asp:Label runat="server" ID="ch2_aa_label" class="labellog" Text="Alarm Aa" meta:resourcekey="ch2_aa_labelResource1"></asp:Label> </div> 
</asp:placeholder>
<asp:placeholder runat="server" ID="ch2_ab_enable">
                    <div id="checkboxCh"><asp:checkbox runat="server" ClientIDMode="Static" ID="ch2_ab" class="inputlog" meta:resourcekey="ch2_abResource1"></asp:checkbox></div>
                    <div id="checkboxCh"><asp:Label runat="server" ID="ch2_ab_label"  class="labellog" Text="Alarm Ab" meta:resourcekey="ch2_ab_labelResource1"></asp:Label> </div> 
</asp:placeholder>
<asp:placeholder runat="server" ID="ch2_ad_enable">
                    <div id="checkboxCh"><asp:checkbox runat="server" ClientIDMode="Static" ID="ch2_ad" class="inputlog" meta:resourcekey="ch2_adResource1"></asp:checkbox></div>
                    <div id="checkboxCh"><asp:Label runat="server" ID="ch2_ad_label"  class="labellog" Text="Alarm Ad" meta:resourcekey="ch2_ad_labelResource1"></asp:Label> </div> 
</asp:placeholder>
<asp:placeholder runat="server" ID="ch2_ar_enable">
                    <div id="checkboxCh"><asp:checkbox runat="server" ClientIDMode="Static" ID="ch2_ar" class="inputlog" meta:resourcekey="ch2_arResource1"></asp:checkbox></div>
                    <div id="checkboxCh"><asp:Label runat="server" ID="ch2_ar_label"  class="labellog" Text="Alarm Ar" meta:resourcekey="ch2_ar_labelResource1"></asp:Label> </div> 
</asp:placeholder>
            </div>
                </asp:placeholder>
</div>
        <!-- fine riga -->
        <!-- riga -->
<div class="row-fluid">            
            <asp:placeholder runat="server" ID="ch3_enable_max5">
          <div class="span12">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal31"  text="Ch3 Select" runat="server" meta:resourcekey="Literal3Resource1"></asp:literal></h5>
              
                    <div id="checkboxCh"><asp:checkbox runat="server" ClientIDMode="Static" ID="ch3_val_max5" class="inputlog" meta:resourcekey="ch3_valResource1"></asp:checkbox></div>
                    <div id="checkboxCh"><asp:Label runat="server" ID="ch3_val_label_max5" class="labellog" Text="ch3" meta:resourcekey="ch3_val_labelResource1"></asp:Label> </div> 

         
<asp:placeholder runat="server" ID="ch3_aa_enable">              
                    <div id="checkboxCh"><asp:checkbox runat="server" ClientIDMode="Static" ID="ch3_aa" class="inputlog" meta:resourcekey="ch3_aaResource1"></asp:checkbox></div>
                    <div id="checkboxCh"><asp:Label runat="server" ID="ch3_aa_label" class="labellog" Text="Alarm Aa" meta:resourcekey="ch3_aa_labelResource1"></asp:Label> </div> 
</asp:placeholder>
<asp:placeholder runat="server" ID="ch3_ab_enable">
                    <div id="checkboxCh"><asp:checkbox runat="server" ClientIDMode="Static" ID="ch3_ab" class="inputlog" meta:resourcekey="ch3_abResource1"></asp:checkbox></div>
                    <div id="checkboxCh"><asp:Label runat="server" ID="ch3_ab_label"  class="labellog" Text="Alarm Ab" meta:resourcekey="ch3_ab_labelResource1"></asp:Label> </div> 
</asp:placeholder>
<asp:placeholder runat="server" ID="ch3_ad_enable">
                    <div id="checkboxCh"><asp:checkbox runat="server" ClientIDMode="Static" ID="ch3_ad" class="inputlog" meta:resourcekey="ch3_adResource1"></asp:checkbox></div>
                    <div id="checkboxCh"><asp:Label runat="server" ID="ch3_ad_label"  class="labellog" Text="Alarm Ad" meta:resourcekey="ch3_ad_labelResource1"></asp:Label> </div> 
</asp:placeholder>
<asp:placeholder runat="server" ID="ch3_ar_enable">
                    <div id="checkboxCh"><asp:checkbox runat="server" ClientIDMode="Static" ID="ch3_ar" class="inputlog" meta:resourcekey="ch3_arResource1"></asp:checkbox></div>
                    <div id="checkboxCh"><asp:Label runat="server" ID="ch3_ar_label"  class="labellog" Text="Alarm Ar" meta:resourcekey="ch3_ar_labelResource1"></asp:Label> </div>
</asp:placeholder>
              </div>
             </asp:placeholder>

        <!-- fine riga -->
</div>
<div class="row-fluid">  
        <!-- riga -->
            
<asp:placeholder runat="server" ID="ch4_enable_max5">
          <div class="span12">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal32"  text="Ch4 Select" runat="server" meta:resourcekey="Literal4Resource1"></asp:literal></h5>
                     <div id="checkboxCh"><asp:checkbox runat="server" ClientIDMode="Static" ID="ch4_val_max5" class="inputlog" meta:resourcekey="ch4_valResource1"></asp:checkbox></div>
                    <div id="checkboxCh"><asp:Label runat="server" ID="ch4_val_label_max5" class="labellog" Text="ch4" meta:resourcekey="ch4_val_labelResource1"></asp:Label> </div> 
        
<asp:placeholder runat="server" ID="ch4_aa_enable">                                  
              <div id="checkboxCh"><asp:checkbox runat="server" ClientIDMode="Static" ID="ch4_aa" class="inputlog" meta:resourcekey="ch4_aaResource1"></asp:checkbox></div>
                    <div id="checkboxCh"><asp:Label runat="server" ID="ch4_aa_label" class="labellog" Text="Alarm Aa" meta:resourcekey="ch4_aa_labelResource1"></asp:Label> </div> 
</asp:placeholder>
<asp:placeholder runat="server" ID="ch4_ab_enable">                    
                    <div id="checkboxCh"><asp:checkbox runat="server" ClientIDMode="Static" ID="ch4_ab" class="inputlog" meta:resourcekey="ch4_abResource1"></asp:checkbox></div>
                    <div id="checkboxCh"><asp:Label runat="server" ID="ch4_ab_label"  class="labellog" Text="Alarm Ab" meta:resourcekey="ch4_ab_labelResource1"></asp:Label> </div> 
</asp:placeholder>
<asp:placeholder runat="server" ID="ch4_ad_enable">                    
                    <div id="checkboxCh"><asp:checkbox runat="server" ClientIDMode="Static" ID="ch4_ad" class="inputlog" meta:resourcekey="ch4_adResource1"></asp:checkbox></div>
                    <div id="checkboxCh"><asp:Label runat="server" ID="ch4_ad_label"  class="labellog" Text="Alarm Ad" meta:resourcekey="ch4_ad_labelResource1"></asp:Label> </div> 
</asp:placeholder>
<asp:placeholder runat="server" ID="ch4_ar_enable">                    
                    <div id="checkboxCh"><asp:checkbox runat="server" ClientIDMode="Static" ID="ch4_ar" class="inputlog" meta:resourcekey="ch4_arResource1"></asp:checkbox></div>
                    <div id="checkboxCh"><asp:Label runat="server" ID="ch4_ar_label"  class="labellog" Text="Alarm Ar" meta:resourcekey="ch4_ar_labelResource1"></asp:Label> </div>
</asp:placeholder>
              </div>
</asp:placeholder>
    </div>
        <!-- fine riga -->
        <!-- riga -->
    <div class="row-fluid">
            <asp:placeholder runat="server" ID="ch5_enable_max5">
        
          <div class="span12">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal33"  text="Ch5 Select" runat="server" meta:resourcekey="Literal5Resource1"></asp:literal></h5>
                    <div id="checkboxCh"><asp:checkbox runat="server" ClientIDMode="Static" ID="ch5_val_max5" class="inputlog" meta:resourcekey="ch5_valResource1"></asp:checkbox></div>
                    <div id="checkboxCh"><asp:Label runat="server" ID="ch5_val_label_max5" class="labellog" Text="ch5" meta:resourcekey="ch5_val_labelResource1"></asp:Label> </div> 

<asp:placeholder runat="server" ID="ch5_aa_enable">
                    <div id="checkboxCh"><asp:checkbox runat="server" ClientIDMode="Static" ID="ch5_aa" class="inputlog" meta:resourcekey="ch5_aaResource1"></asp:checkbox></div>
                    <div id="checkboxCh"><asp:Label runat="server" ID="ch5_aa_label" class="labellog" Text="Alarm Aa" meta:resourcekey="ch5_aa_labelResource1"></asp:Label> </div> 
</asp:placeholder>
<asp:placeholder runat="server" ID="ch5_ab_enable">
                    <div id="checkboxCh"><asp:checkbox runat="server" ClientIDMode="Static" ID="ch5_ab" class="inputlog" meta:resourcekey="ch5_abResource1"></asp:checkbox></div>
                    <div id="checkboxCh"><asp:Label runat="server" ID="ch5_ab_label"  class="labellog" Text="Alarm Ab" meta:resourcekey="ch5_ab_labelResource1"></asp:Label> </div> 
</asp:placeholder>
<asp:placeholder runat="server" ID="ch5_ad_enable">
                    <div id="checkboxCh"><asp:checkbox runat="server" ClientIDMode="Static" ID="ch5_ad" class="inputlog" meta:resourcekey="ch5_adResource1"></asp:checkbox></div>
                    <div id="checkboxCh"><asp:Label runat="server" ID="ch5_ad_label"  class="labellog" Text="Alarm Ad" meta:resourcekey="ch5_ad_labelResource1"></asp:Label> </div> 
</asp:placeholder>
<asp:placeholder runat="server" ID="ch5_ar_enable">
                    <div id="checkboxCh"><asp:checkbox runat="server" ClientIDMode="Static" ID="ch5_ar" class="inputlog" meta:resourcekey="ch5_arResource1"></asp:checkbox></div>
                    <div id="checkboxCh"><asp:Label runat="server" ID="ch5_ar_label"  class="labellog" Text="Alarm Ar" meta:resourcekey="ch5_ar_labelResource1"></asp:Label> </div>
</asp:placeholder>
              </div>
            
                </asp:placeholder>
        <!-- fine riga -->
        <!-- riga 
            <asp:placeholder runat="server" ID="Placeholder7" >
        
          <div class="span6">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal34"  text="Input" runat="server" meta:resourcekey="Literal6Resource1"></asp:literal></h5>
              <div id="Div106"><asp:checkbox Checked="True" runat="server" ID="Checkbox4" class="inputlog" meta:resourcekey="flow_selectResource1"></asp:checkbox></div>
              <div id="Div107"><asp:Label runat="server" ID="label4" class="labellog" Text="Flow Alarm" meta:resourcekey="label_flow_selectResource1"></asp:Label> </div>
              <div id="Div108"><asp:checkbox runat="server" ID="level1_select" class="inputlog" meta:resourcekey="level1_selectResource1" Visible="False"></asp:checkbox></div>
              <div id="Div109"><asp:Label runat="server" ID="label_level1_select" class="labellog" Text="Level1" meta:resourcekey="label_level1_selectResource1" Visible="False"></asp:Label> </div>
              <div id="Div110"><asp:checkbox runat="server" ID="level2_select" class="inputlog" meta:resourcekey="level2_selectResource1" Visible="False"></asp:checkbox></div>
              <div id="Div111"><asp:Label runat="server" ID="label_level2_select" class="labellog" Text="Level2" meta:resourcekey="label_level2_selectResource1" Visible="False"></asp:Label> </div>
              <div id="Div112"><asp:checkbox runat="server" ID="level3_select" class="inputlog" meta:resourcekey="level3_selectResource1" Visible="False"></asp:checkbox></div>
              <div id="Div113"><asp:Label runat="server" ID="label_level3_select" class="labellog" Text="Level3" meta:resourcekey="label_level3_selectResource1" Visible="False"></asp:Label> </div>
              <div id="Div114"><asp:checkbox runat="server" ID="level4_select" class="inputlog" meta:resourcekey="level4_selectResource1" Visible="False"></asp:checkbox></div>
              <div id="Div115"><asp:Label runat="server" ID="label_level4_select" class="labellog" Text="Level4" meta:resourcekey="label_level4_selectResource1" Visible="False"></asp:Label> </div>
              
              </div>
                </asp:placeholder>
            </div>
                
        <!-- fine riga -->
        <div class="row-fluid">
            <!-- riga -->
            <asp:placeholder runat="server" ID="Placeholder8">
        
          <div class="span6">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal35"  text="Temperature" runat="server" meta:resourcekey="Literal7Resource1"></asp:literal></h5>
              <div id="checkboxCh"><asp:checkbox Checked="True" runat="server" ClientIDMode="Static" ID="temperature_max5" class="inputlog" meta:resourcekey="temperature_selectResource1"></asp:checkbox></div>
              <div id="checkboxCh"><asp:Label runat="server" ID="temperature_select_label" class="labellog" Text="Temperature" meta:resourcekey="temperature_select_labelResource1"></asp:Label> </div>
              <div id="checkboxCh"><asp:checkbox  runat="server" ClientIDMode="Static" ID="flow_meter_max5" class="inputlog" meta:resourcekey="flow_meter_lowResource1"></asp:checkbox></div>
              <div id="checkboxCh"><asp:Label runat="server" ID="flow_meter_label_max5" class="labellog" Text="Flow Meter" meta:resourcekey="Label2Resource1"></asp:Label> </div>
            
              
              </div>
                </asp:placeholder>
            </div>
           <!-- riga -->
<div class="row-fluid">
        <div class="span6">
            <h5 style="padding-top:10px"><asp:literal ID = "Literal37"  text="Log Range" runat="server" meta:resourcekey="Literal11Resource1"></asp:literal></h5>
         <div id="checkboxCh"><h5 style="padding-top:10px"><asp:literal ID = "Literal38"  text="From" runat="server" meta:resourcekey="Literal10Resource1"></asp:literal></h5></div>
         <div id="checkboxCh"><asp:textbox ID="graph_log_from_max5" ClientIDMode="Static"  class="span12"  runat="server" meta:resourcekey="graph_log_fromResource1"  ></asp:textbox></div>
         <div id="checkboxCh"><h5 style="padding-top:10px"><asp:literal ID = "Literal39"  text="To" runat="server" meta:resourcekey="Literal9Resource1"></asp:literal></h5></div>
         <div id="checkboxCh"><asp:textbox ID="graph_log_to_max5" ClientIDMode="Static"  class="span12"  runat="server" meta:resourcekey="graph_log_toResource1"  ></asp:textbox></div>

              </div>
    </div> 
        
        <!-- fine riga -->

	</div>
       <div id="checkboxCh"  class="btn-primary">
                   <b class="btn-primary btn-icon glyphicons ok"><asp:button runat="server" ID="refresh_graph_max5" class="btn-primary"  text="Refresh Graph" Font-Bold="True" meta:resourcekey="refresh_graphResource1" /><i></i></b>

            </div>

	</div>
</div>
    <div id="chart_div" style="height: 700px; min-width: 500px">
        
        <div id="principale" class="innerLR" >

         
</div>
        
    </div>
<div id="chart_table_max5" >

</div>
    <asp:Button ID="refresh_log_server_max5" runat="server" BackColor="Transparent" BorderColor="Transparent" meta:resourcekey="refresh_log_serverResource1"  />
    <asp:literal runat="server" ID="literal_script_max5" meta:resourcekey="literal_scriptResource1"></asp:literal>
  

    <script type="text/javascript" src="chart/chart_manage_max5_usb.js?v=1.1"></script>
     
     
   </div> 	
        </asp:PlaceHolder> 
    
 <asp:PlaceHolder ID="wd_enable" runat="server">   
  <div class="innerLR">

      

  <div class="widget" >
	<div id="head_log" class="widget-head"><h4 class="heading glyphicons show_thumbnails_with_lines"><asp:literal text="Log Settings" runat="server"  ID="Literal18" meta:resourcekey="log_setting_idResource1"></asp:literal></h4>

<span style=" position: relative; height: 29px; width: 30px; display: block; cursor: pointer; float: right; margin-right: -10px;">
                    
                    <img src="chart/js/images/arrow_sort_down.png">

                </span>
	&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</div>
	<div id="log_collapse" class="widget-body list" style="height: auto;">
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
            
<asp:placeholder runat="server" ID="ch1_enable_wd">
          <div class="span7">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal20"  text="Ch1 Select" runat="server" meta:resourcekey="Literal1Resource1"></asp:literal></h5>
                    <div id="checkboxCh"><asp:checkbox Checked="True" runat="server" ID="ch1_val_wd"  ClientIDMode="Static" class="inputlog" meta:resourcekey="ch1_valResource1"></asp:checkbox></div>
                    <div id="checkboxCh"><asp:Label runat="server" ID="ch1_val_label_wd" class="labellog" Text="ch1" meta:resourcekey="ch1_val_labelResource1"></asp:Label> </div>
<asp:placeholder runat="server" ID="ch1_dos_enable_wd">               
                    <div id="checkboxCh"><asp:checkbox runat="server" ID="ch1_dos_wd" class="inputlog"  ClientIDMode="Static" meta:resourcekey="ch1_dosResource1"></asp:checkbox></div>
                    <div id="checkboxCh"><asp:Label runat="server" ID="ch1_dos_label_wd"  class="labellog" Text="Dos Alarm" meta:resourcekey="ch1_dos_labelResource1"></asp:Label> </div> 
</asp:placeholder>
<asp:placeholder runat="server" ID="ch1_probe_enable_wd">
                    <div id="checkboxCh"><asp:checkbox runat="server" ID="ch1_probe_wd"  ClientIDMode="Static" class="inputlog" meta:resourcekey="ch1_probeResource1"></asp:checkbox></div>
                    <div id="checkboxCh"><asp:Label runat="server" ID="ch1_probe_label_wd"  class="labellog" Text="Probe Fail" meta:resourcekey="ch1_probe_labelResource1"></asp:Label> </div> 
</asp:placeholder>
<asp:placeholder runat="server" ID="ch1_livello1_enable_wd">
                    <div id="checkboxCh"><asp:checkbox runat="server"  ClientIDMode="Static" ID="ch1_livello1_wd" class="inputlog" meta:resourcekey="ch1_livello1Resource1"></asp:checkbox></div>
                    <div id="checkboxCh"><asp:Label runat="server" ID="ch1_livello1_label_wd"  class="labellog" Text="Level 1" meta:resourcekey="ch1_livello1_labelResource1"></asp:Label> </div> 
</asp:placeholder>
<asp:placeholder runat="server" ID="ch1_rele_enable_wd">
                       <div id="checkboxCh"><asp:checkbox runat="server"  ClientIDMode="Static" ID="ch1_rele1_wd" class="inputlog" ></asp:checkbox></div>
                    <div id="checkboxCh"><asp:Label runat="server" ID="ch1_rele1_label_wd"  class="labellog" Text="Rele 1" ></asp:Label> </div> 
</asp:placeholder>
<asp:placeholder runat="server" ID="soglia_ph_enable_wd">
              <div id="checkboxCh"><asp:checkbox Checked="True"  ClientIDMode="Static" runat="server" ID="soglia_ph_wd" class="inputlog"></asp:checkbox></div>
              <div id="checkboxCh"><asp:Label runat="server" ID="label_soglia_ph_wd" class="labellog" Text="Alarm Limit pH"></asp:Label> </div>
</asp:placeholder>

              </div> 
                </asp:placeholder>
        <!-- fine riga -->
            </div>
<div class="row-fluid">
        <!-- riga -->
            <asp:placeholder runat="server" ID="ch2_enable_wd">
          <div class="span6">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal21"  text="Ch2 Select" runat="server" meta:resourcekey="Literal2Resource1"></asp:literal></h5>
               <div id="checkboxCh"><asp:checkbox runat="server" ID="ch2_val_wd" class="inputlog"  ClientIDMode="Static" meta:resourcekey="ch2_valResource1"></asp:checkbox></div>
                    <div id="checkboxCh"><asp:Label runat="server" ID="ch2_val_label_wd" class="labellog" Text="ch2" meta:resourcekey="ch2_val_labelResource1"></asp:Label> </div> 
<asp:placeholder runat="server" ID="ch2_dos_enable_wd">
                    <div id="checkboxCh"><asp:checkbox runat="server" ID="ch2_dos_wd" class="inputlog"  ClientIDMode="Static" meta:resourcekey="ch2_dosResource1"></asp:checkbox></div>
                    <div id="checkboxCh"><asp:Label runat="server" ID="ch2_dos_label_wd"  class="labellog" Text="Dos Alarm" meta:resourcekey="ch2_dos_labelResource1"></asp:Label> </div> 
</asp:placeholder>
<asp:placeholder runat="server" ID="ch2_probe_enable_wd">
                    <div id="checkboxCh"><asp:checkbox runat="server" ID="ch2_probe_wd"  ClientIDMode="Static" class="inputlog" meta:resourcekey="ch2_probeResource1"></asp:checkbox></div>
                    <div id="checkboxCh"><asp:Label runat="server" ID="ch2_probe_label_wd"  class="labellog" Text="Probe Fail" meta:resourcekey="ch2_probe_labelResource1"></asp:Label> </div> 
</asp:placeholder>
<asp:placeholder runat="server" ID="ch2_level1_enable_wd">
                    <div id="checkboxCh"><asp:checkbox runat="server"  ClientIDMode="Static" ID="ch2_level1_wd" class="inputlog" meta:resourcekey="ch2_level1Resource1"></asp:checkbox></div>
                    <div id="checkboxCh"><asp:Label runat="server" ID="ch2_level2_label_wd"  class="labellog" Text="Level 1" meta:resourcekey="ch2_level2_labelResource1"></asp:Label> </div> 
</asp:placeholder>
<asp:placeholder runat="server" ID="ch2_rele_enable_wd">
                       <div id="checkboxCh"><asp:checkbox runat="server"  ClientIDMode="Static" ID="ch1_rele2_wd" class="inputlog" ></asp:checkbox></div>
                    <div id="checkboxCh"><asp:Label runat="server" ID="ch1_rele2_label_wd"  class="labellog" Text="Rele 1" ></asp:Label> </div> 
</asp:placeholder>
<asp:placeholder runat="server" ID="soglia_mv_enable_wd">
              <div id="checkboxCh"><asp:checkbox Checked="True"  ClientIDMode="Static" runat="server" ID="soglia_mv_wd" class="inputlog"></asp:checkbox></div>
              <div id="checkboxCh"><asp:Label runat="server" ID="label_soglia_mv_wd" class="labellog" Text="Alarm Limit mV"></asp:Label> </div>
</asp:placeholder>

            </div>
                </asp:placeholder>
</div>
        <!-- fine riga -->
        <!-- riga -->
<div class="row-fluid">            
            <asp:placeholder runat="server" ID="ch3_enable_wd">
          <div class="span6">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal22"  text="Ch3 Select" runat="server" meta:resourcekey="Literal3Resource1"></asp:literal></h5>
              
                                <div id="Div19"><asp:checkbox runat="server"  ClientIDMode="Static" ID="ch3_val_wd" class="inputlog" meta:resourcekey="ch3_valResource1"></asp:checkbox></div>
                    <div id="checkboxCh"><asp:Label runat="server" ID="ch3_val_label_wd" class="labellog" Text="ch3" meta:resourcekey="ch3_val_labelResource1"></asp:Label> </div> 

              </div>
             </asp:placeholder>

        <!-- fine riga -->
       
        <!-- riga -->
            <asp:placeholder runat="server" ID="Placeholder6">
        
          <div class="span6">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal23"  text="Input" runat="server" meta:resourcekey="Literal6Resource1"></asp:literal></h5>
<asp:placeholder runat="server" ID="flow_select_enable_wd">
              <div id="checkboxCh"><asp:checkbox Checked="True"  ClientIDMode="Static" runat="server" ID="flow_select_wd" class="inputlog" meta:resourcekey="flow_selectResource1"></asp:checkbox></div>
              <div id="checkboxCh"><asp:Label runat="server" ID="label_flow_select_wd" class="labellog" Text="Flow" meta:resourcekey="label_flow_selectResource1"></asp:Label> </div>
</asp:placeholder>
<asp:placeholder runat="server" ID="pipe_all_enable_wd">
              <div id="checkboxCh"><asp:checkbox Checked="False"  ClientIDMode="Static" runat="server" ID="pipe_all_wd" class="inputlog"></asp:checkbox></div>
              <div id="checkboxCh"><asp:Label runat="server" ID="label_pipe_all_wd" class="labellog" Text="Alarm Rohrbruch"></asp:Label> </div>
</asp:placeholder>
<asp:placeholder runat="server" ID="timeout1_enable_wd" Visible="False">
              <div id="checkboxCh"><asp:checkbox Checked="False"  ClientIDMode="Static" runat="server" ID="timeout1_wd" class="inputlog"></asp:checkbox></div>
              <div id="checkboxCh"><asp:Label runat="server" ID="label_timeout1_wd" class="labellog" Text="Timeout1"></asp:Label> </div>
</asp:placeholder>
<asp:placeholder runat="server" ID="timeout2_enable_wd" Visible="False">
              <div id="checkboxCh"><asp:checkbox Checked="False"  ClientIDMode="Static" runat="server" ID="timeout2_wd" class="inputlog"></asp:checkbox></div>
              <div id="checkboxCh"><asp:Label runat="server" ID="label_timeout2_wd" class="labellog" Text="Timeout 2"></asp:Label> </div>
</asp:placeholder>
<asp:placeholder runat="server" ID="sefl_ac_enable_wd">
              <div id="checkboxCh"><asp:checkbox Checked="False"  ClientIDMode="Static" runat="server" ID="sefl_ac_wd" class="inputlog"></asp:checkbox></div>
              <div id="checkboxCh"><asp:Label runat="server" ID="label_sefl_ac_wd" class="labellog" Text="Alarm Dosier pH"></asp:Label> </div>
</asp:placeholder>
<asp:placeholder runat="server" ID="sefl_cl_enable_wd">
              <div id="checkboxCh"><asp:checkbox Checked="False"  ClientIDMode="Static" runat="server" ID="sefl_cl_wd" class="inputlog"></asp:checkbox></div>
              <div id="checkboxCh"><asp:Label runat="server" ID="label_sefl_cl_wd" class="labellog" Text="Alarm Dosier mV"></asp:Label> </div>
</asp:placeholder>
              </div>
                </asp:placeholder>
            </div>
                
        <!-- fine riga -->
         <!-- riga -->
<div class="row-fluid">
        <div class="span6">
            <h5 style="padding-top:10px"><asp:literal ID = "Literal44"  text="   " runat="server" meta:resourcekey="Literal6Resource1"></asp:literal></h5>
<asp:placeholder runat="server" ID="pump1_enable_wd">
              <div id="checkboxCh"><asp:checkbox Checked="True"  ClientIDMode="Static" runat="server" ID="pump1_wd" class="inputlog"></asp:checkbox></div>
              <div id="checkboxCh"><asp:Label runat="server" ID="label_pump1_wd" class="labellog" Text="Pumpe 1"></asp:Label> </div>
</asp:placeholder>
<asp:placeholder runat="server" ID="pump2_enable_wd">
              <div id="checkboxCh"><asp:checkbox Checked="False"  ClientIDMode="Static" runat="server" ID="pump2_wd" class="inputlog"></asp:checkbox></div>
              <div id="checkboxCh"><asp:Label runat="server" ID="label_pump2_wd" class="labellog" Text="Pumpe 2"></asp:Label> </div>
</asp:placeholder>
<asp:placeholder runat="server" ID="wm1_enable_wd">
              <div id="checkboxCh"><asp:checkbox Checked="False"  ClientIDMode="Static" runat="server" ID="wm1_wd" class="inputlog"></asp:checkbox></div>
              <div id="checkboxCh"><asp:Label runat="server" ID="label_wm1_wd" class="labellog" Text="Wasser 1"></asp:Label> </div>
</asp:placeholder>
<asp:placeholder runat="server" ID="wm2_enable_wd">
              <div id="checkboxCh"><asp:checkbox Checked="False"  ClientIDMode="Static" runat="server" ID="wm2_wd" class="inputlog"></asp:checkbox></div>
              <div id="checkboxCh"><asp:Label runat="server" ID="label_wm2_wd" class="labellog" Text="Wasser 2"></asp:Label> </div>
</asp:placeholder>
<asp:placeholder runat="server" ID="wm1t_enable_wd">
              <div id="checkboxCh"><asp:checkbox Checked="False"  ClientIDMode="Static" runat="server" ID="wm1t_wd" class="inputlog"></asp:checkbox></div>
              <div id="checkboxCh"><asp:Label runat="server" ID="label_wm1t_wd" class="labellog" Text="Wasser 1 T"></asp:Label> </div>
</asp:placeholder>
<asp:placeholder runat="server" ID="wm2t_enable_wd">
              <div id="checkboxCh"><asp:checkbox Checked="False"  ClientIDMode="Static" runat="server" ID="wm2t_wd" class="inputlog"></asp:checkbox></div>
              <div id="checkboxCh"><asp:Label runat="server" ID="label_wm2t_wd" class="labellog" Text="Wasser 2 T"></asp:Label> </div>
</asp:placeholder>
              </div>
    </div> 
        
        <!-- fine riga -->

         <!-- riga -->
<div class="row-fluid">
        <div class="span6">
            <h5 style="padding-top:10px"><asp:literal ID = "Literal24"  text="Log Range" runat="server" meta:resourcekey="Literal11Resource1"></asp:literal></h5>
         <div id="checkboxCh"><h5 style="padding-top:10px"><asp:literal ID = "Literal25"  text="From" runat="server" meta:resourcekey="Literal10Resource1"></asp:literal></h5></div>
         <div id="checkboxCh"><asp:textbox  ClientIDMode="Static" ID="graph_log_from_wd"   class="span12"  runat="server" meta:resourcekey="graph_log_fromResource1"  ></asp:textbox></div>
         <div id="checkboxCh"><h5 style="padding-top:10px"><asp:literal ID = "Literal26"  text="To" runat="server" meta:resourcekey="Literal9Resource1"></asp:literal></h5></div>
         <div id="checkboxCh"><asp:textbox ID="graph_log_to_wd"   class="span12"  runat="server" meta:resourcekey="graph_log_toResource1"  ClientIDMode="Static"></asp:textbox></div>

              </div>
    </div> 
        
        <!-- fine riga -->
	</div>
       <div id="salva" class="btn-primary">
                   <b class="btn-primary btn-icon glyphicons ok"><asp:button runat="server" ID="refresh_graph_wd" class="btn-primary"  text="Refresh Graph" Font-Bold="True" meta:resourcekey="refresh_graphResource1" /><i></i></b>

            </div>

	</div>
</div>
    <div id="chart_div" style="height: 700px; min-width: 500px">
        <div id="principale" class="innerLR" >

         
</div>
    </div>
    <h3 class="heading-mosaic"><asp:Literal ID="Literal28" runat="server" Text="Report." ></asp:Literal></h3>
            <div id="chart_table_wd" >
            </div>

       <asp:Button ID="refresh_log_server_wd" runat="server" BackColor="Transparent" BorderColor="Transparent" meta:resourcekey="refresh_log_serverResource1"  ClientIDMode="Static" />
    <asp:literal runat="server" ID="literal_script_wd" ></asp:literal>

    <script type="text/javascript" src="chart/chart_manage_wd_usb.js?v=1.1"></script>
     <div id="Div2" class="btn-primary">
        <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/log_usb_list.aspx" meta:resourcekey="HyperLink1Resource1"><b style="width:100%" class="btn-primary btn-icon glyphicons circle_arrow_left"  ><i></i>torna all'impianto</b></asp:HyperLink></div>
</div>

   </div>              
       </asp:PlaceHolder> 
   

    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="script_footer" runat="server">
    <script type="text/javascript">
        var opts = {
            lines: 13, // The number of lines to draw
            length: 9, // The length of each line
            width: 4, // The line thickness
            radius: 8, // The radius of the inner circle
            corners: 1, // Corner roundness (0..1)
            rotate: 0, // The rotation offset
            direction: 1, // 1: clockwise, -1: counterclockwise
            color: color_general, // #rgb or #rrggbb or array of colors
            speed: 1, // Rounds per second
            trail: 60, // Afterglow percentage
            shadow: false, // Whether to render a shadow
            hwaccel: false, // Whether to use hardware acceleration
            className: 'spinner', // The CSS class to assign to the spinner
            zIndex: 2e9, // The z-index (defaults to 2000000000)
            top: 'auto', // Top position relative to parent in px
            left: 'auto' // Left position relative to parent in px
        };
        //$(document).ready(function () {
        
        var target = document.getElementById('principale');
        var spinner = new Spinner(opts).spin(target);
        </script> 
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="script_at_end" runat="server">
    <script type="text/javascript">
        
        
        </script>
</asp:Content>

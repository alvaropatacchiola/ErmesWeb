﻿<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="log_ld4.aspx.vb" Inherits="ermes_web_20.log_ld4" %>

<form id="form_log" runat="server"  method="post" onsubmit="return get_action();">
  <div class="innerLR">

      

  <div class="widget" >
	<div id="head_log" class="widget-head"><h4 class="heading glyphicons show_thumbnails_with_lines"><asp:literal text="Log Settings" runat="server"  ID="log_setting_id" meta:resourcekey="log_setting_idResource1"></asp:literal></h4>
 <span style=" position: relative; height: 29px; width: 30px; display: block; cursor: pointer; float: right; margin-right: -10px;">
                    
                    <img src="chart/js/images/arrow_sort_down.png">

                </span>
	</div>
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
            
<asp:placeholder runat="server" ID="ch1_enable">
          <div class="span7">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal1"  text="Ch1 Select" runat="server" meta:resourcekey="Literal1Resource1"></asp:literal></h5>
                    <div id="checkboxCh"><asp:checkbox Checked="True" runat="server" ID="ch1_val" class="inputlog" meta:resourcekey="ch1_valResource1"></asp:checkbox></div>
                    <div id="checkboxCh"><asp:Label runat="server" ID="ch1_val_label" class="labellog" Text="ch1" meta:resourcekey="ch1_val_labelResource1"></asp:Label> </div> 
                    <div id="checkboxCh"><asp:checkbox runat="server" ID="ch1_feed" class="inputlog" meta:resourcekey="ch1_feedResource1"></asp:checkbox></div>
                    <div id="checkboxCh"><asp:Label runat="server" ID="ch1_feed_label" class="labellog" Text="Min/Max" ></asp:Label> </div> 
                    <div id="checkboxCh"><asp:checkbox runat="server" ID="ch1_dos" class="inputlog" meta:resourcekey="ch1_dosResource1"></asp:checkbox></div>
                    <div id="checkboxCh"><asp:Label runat="server" ID="ch1_dos_label"  class="labellog" Text="Dos Alarm" meta:resourcekey="ch1_dos_labelResource1"></asp:Label> </div> 
                    <div id="checkboxCh"><asp:checkbox runat="server" ID="ch1_probe" class="inputlog" meta:resourcekey="ch1_probeResource1"></asp:checkbox></div>
                    <div id="checkboxCh"><asp:Label runat="server" ID="ch1_probe_label"  class="labellog" Text="Probe Fail" meta:resourcekey="ch1_probe_labelResource1"></asp:Label> </div> 
                    <div id="checkboxCh"><asp:checkbox runat="server" ID="ch1_livello1" class="inputlog" meta:resourcekey="ch1_livello1Resource1"></asp:checkbox></div>
                    <div id="checkboxCh"><asp:Label runat="server" ID="ch1_livello1_label"  class="labellog" Text="Level 1" meta:resourcekey="ch1_livello1_labelResource1"></asp:Label> </div> 
              </div> 
                </asp:placeholder>
        <!-- fine riga -->
            </div>
<div class="row-fluid">
        <!-- riga -->
            <asp:placeholder runat="server" ID="ch2_enable">
          <div class="span6">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal2"  text="Ch2 Select" runat="server" meta:resourcekey="Literal2Resource1"></asp:literal></h5>
               <div id="checkboxCh"><asp:checkbox runat="server" ID="ch2_val" class="inputlog" meta:resourcekey="ch2_valResource1"></asp:checkbox></div>
                    <div id="checkboxCh"><asp:Label runat="server" ID="ch2_val_label" class="labellog" Text="ch2" meta:resourcekey="ch2_val_labelResource1"></asp:Label> </div> 
                    <div id="checkboxCh"><asp:checkbox runat="server" ID="ch2_feed" class="inputlog" meta:resourcekey="ch2_feedResource1"></asp:checkbox></div>
                    <div id="checkboxCh"><asp:Label runat="server" ID="ch2_feed_label" class="labellog" Text="Min/Max"></asp:Label> </div> 
                    <div id="checkboxCh"><asp:checkbox runat="server" ID="ch2_dos" class="inputlog" meta:resourcekey="ch2_dosResource1"></asp:checkbox></div>
                    <div id="checkboxCh"><asp:Label runat="server" ID="ch2_dos_label"  class="labellog" Text="Dos Alarm" meta:resourcekey="ch2_dos_labelResource1"></asp:Label> </div> 
                    <div id="checkboxCh"><asp:checkbox runat="server" ID="ch2_probe" class="inputlog" meta:resourcekey="ch2_probeResource1"></asp:checkbox></div>
                    <div id="checkboxCh"><asp:Label runat="server" ID="ch2_probe_label"  class="labellog" Text="Probe Fail" meta:resourcekey="ch2_probe_labelResource1"></asp:Label> </div> 
                    <div id="checkboxCh"><asp:checkbox runat="server" ID="ch2_level1" class="inputlog" meta:resourcekey="ch2_level1Resource1"></asp:checkbox></div>
                    <div id="checkboxCh"><asp:Label runat="server" ID="ch2_level2_label"  class="labellog" Text="Level 1" meta:resourcekey="ch2_level2_labelResource1"></asp:Label> </div> 
            </div>
                </asp:placeholder>
</div>
        <!-- fine riga -->
        <!-- riga -->
<div class="row-fluid">            
            <asp:placeholder runat="server" ID="ch3_enable">
          <div class="span6">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal3"  text="Ch3 Select" runat="server" meta:resourcekey="Literal3Resource1"></asp:literal></h5>
              
                     <div id="checkboxCh"><asp:checkbox runat="server" ID="ch3_val" class="inputlog" meta:resourcekey="ch3_valResource1"></asp:checkbox></div>
                    <div id="checkboxCh"><asp:Label runat="server" ID="ch3_val_label" class="labellog" Text="ch3" meta:resourcekey="ch3_val_labelResource1"></asp:Label> </div> 
                    <div id="checkboxCh"><asp:checkbox runat="server" ID="ch3_feed" class="inputlog" ></asp:checkbox></div>
                    <div id="checkboxCh"><asp:Label runat="server" ID="ch3_feed_label" class="labellog" Text="Min/Max" ></asp:Label> </div> 

              </div>
             </asp:placeholder>

        <!-- fine riga -->
</div>  
<div class="row-fluid">            
            <asp:placeholder runat="server" ID="ch4_enable">
          <div class="span6">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal4"  text="Ch4 Select" runat="server" ></asp:literal></h5>
              
                     <div id="checkboxCh"><asp:checkbox runat="server" ID="ch4_val" class="inputlog" ></asp:checkbox></div>
                    <div id="checkboxCh"><asp:Label runat="server" ID="ch4_val_label" class="labellog" Text="ch3" ></asp:Label> </div> 
                    <div id="checkboxCh"><asp:checkbox runat="server" ID="ch4_feed" class="inputlog" ></asp:checkbox></div>
                    <div id="checkboxCh"><asp:Label runat="server" ID="ch4_feed_label" class="labellog" Text="Min/Max" ></asp:Label> </div> 

              </div>
             </asp:placeholder>

        <!-- fine riga -->
</div>  
<div class="row-fluid">            
        <!-- riga -->
            <asp:placeholder runat="server" ID="Placeholder1">
        
          <div class="span6">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal6"  text="Input" runat="server"></asp:literal></h5>
              <div id="checkboxCh"><asp:checkbox Checked="True" runat="server" ID="flow_select" class="inputlog" ></asp:checkbox></div>
              <div id="checkboxCh"><asp:Label runat="server" ID="label_flow_select" class="labellog" Text="Flow"></asp:Label> </div>
              <div id="checkboxCh"><asp:checkbox runat="server" ID="temperature_select" class="inputlog" ></asp:checkbox></div>
              <div id="checkboxCh"><asp:Label runat="server" ID="label_temperature_select" class="labellog" Text="Temperature" ></asp:Label> </div>
              <div id="checkboxCh"><asp:checkbox runat="server" ID="m3h" class="inputlog" ></asp:checkbox></div>
              <div id="checkboxCh"><asp:Label runat="server" ID="label_m3h" class="labellog" Text="m3/h" ></asp:Label> </div>
              <div id="checkboxCh"><asp:checkbox runat="server" ID="flow_mtr" class="inputlog" ></asp:checkbox></div>
              <div id="checkboxCh"><asp:Label runat="server" ID="label_flow_meter" class="labellog" Text="FlowMeterLow" ></asp:Label> </div>

              </div>
            </div>
                </asp:placeholder>
        <!-- fine riga -->
          <!-- riga -->
<div class="row-fluid">
        <div class="span6">
            <h5 style="padding-top:10px"><asp:literal ID = "Literal11"  text="Log Range" runat="server" ></asp:literal></h5>
         <div id="checkboxCh"><h5 style="padding-top:10px"><asp:literal ID = "Literal10"  text="From" runat="server" ></asp:literal></h5></div>
         <div id="checkboxCh"><asp:textbox ID="graph_log_from"   class="span12"  runat="server"   ></asp:textbox></div>
         <div id="checkboxCh"><h5 style="padding-top:10px"><asp:literal ID = "Literal9"  text="To" runat="server"></asp:literal></h5></div>
         <div id="checkboxCh"><asp:textbox ID="graph_log_to"   class="span12"  runat="server"   ></asp:textbox></div>

              </div>
    </div> 
        
        <!-- fine riga -->
	</div>
       <div id="salva"   class="btn-primary">
                   <b class="btn-primary btn-icon glyphicons ok"><asp:button runat="server" ID="refresh_graph" class="btn-primary"  text="Refresh Graph" Font-Bold="True" meta:resourcekey="refresh_graphResource1" /><i></i></b>

            </div>

	</div>
</div>
    <div id="chart_div" style="height: 700px; min-width: 500px">
        
    </div>
<div id="chart_table" >

</div>

          <asp:Button ID="refresh_log_server" runat="server" BackColor="Transparent" BorderColor="Transparent" meta:resourcekey="refresh_log_serverResource1"  />
    <asp:literal runat="server" ID="literal_script" meta:resourcekey="literal_scriptResource1"></asp:literal>

    <script type="text/javascript" src="chart/chart_manage_ld4.js"></script>
   </div> 	
      
      
</form>
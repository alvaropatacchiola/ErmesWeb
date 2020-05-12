<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="log_lta_ltu_ltd.aspx.vb" Inherits="ermes_web_20.log_lta_ltu_ltd" %>


<form id="form_log" runat="server" method="post" onsubmit="return get_action();">
  <div class="innerLR">

      

  <div class="widget" >
	<div id="head_log" class="widget-head"><h4 class="heading glyphicons show_thumbnails_with_lines"><asp:literal text="Log Settings" runat="server"  ID="log_setting_id" meta:resourcekey="log_setting_idResource1" ></asp:literal></h4>
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
          <div class="span6">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal4"  text="Acid" runat="server"  ></asp:literal></h5>
               <div id="checkboxCh"><asp:checkbox runat="server" ID="Lev_Acid_L" class="inputlog" Checked="True"  ></asp:checkbox></div>
                    <div id="checkboxCh"><asp:Label runat="server" ID="Lev_Acid_L_label" class="labellog" Text="Level Acid"  ></asp:Label> </div> 
                    <div id="checkboxCh"><asp:checkbox runat="server" ID="Flow_Acid_L" class="inputlog"  ></asp:checkbox></div>
                    <div id="checkboxCh"><asp:Label runat="server" ID="Flow_Acid_L_label"  class="labellog" Text="Flow Control Acid" ></asp:Label> </div> 
            </div>
</div>
  <!-- fine riga -->
    <!-- riga -->
<asp:placeholder runat="server" id="lta_ltu">
        <div class="row-fluid">    
                  <div class="span6">
                      <h5 style="padding-top:10px"><asp:literal ID = "Literal3"  text="Water" runat="server"  ></asp:literal></h5>
                            <div id="checkboxCh"><asp:checkbox runat="server" ID="Flow_Self_Water_L" class="inputlog"  ></asp:checkbox></div>
                            <div id="checkboxCh"><asp:Label runat="server" ID="Flow_Self_Water_L_label" class="labellog" Text="Contact SEFL Water"  ></asp:Label> </div> 
                            <div id="checkboxCh"><asp:checkbox runat="server" ID="Lev_Water_L" class="inputlog" ></asp:checkbox></div>
                            <div id="checkboxCh"><asp:Label runat="server" ID="Lev_Water_L_label" class="labellog" Text="Level Water" ></asp:Label> </div> 
                      </div>
        </div>
</asp:placeholder>
        <!-- fine riga -->
    <!-- riga -->
<div class="row-fluid">    
          <div class="span6">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal1"  text="Chlorite" runat="server"  ></asp:literal></h5>
              
                    <div id="checkboxCh"><asp:checkbox runat="server" ID="Flow_Chlorite_L" class="inputlog" Checked="True"  ></asp:checkbox></div>
                    <div id="checkboxCh"><asp:Label runat="server" ID="Flow_Chlorite_L_label" class="labellog" Text="Contact SEFL Chlorite" ></asp:Label> </div> 
                    <div id="checkboxCh"><asp:checkbox runat="server" ID="Lev_Chlorite_L" class="inputlog"  ></asp:checkbox></div>
                    <div id="checkboxCh"><asp:Label runat="server" ID="Lev_Chlorite_L_label" class="labellog" Text="Level Chlorit"  ></asp:Label> </div> 
              </div>
</div>
        <!-- fine riga -->
    <!-- riga -->
<div class="row-fluid">    
          <div class="span12">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal2"  text="Common" runat="server"  ></asp:literal></h5>
              
                    <div id="checkboxCh"><asp:checkbox runat="server" ID="Overf" class="inputlog" Checked="True"  ></asp:checkbox></div>
                    <div id="checkboxCh"><asp:Label runat="server" ID="Overf_label" class="labellog" Text="Overflow" ></asp:Label> </div> 
<asp:placeholder runat="server" id="ltd_ltu">
                    <div id="checkboxCh"><asp:checkbox runat="server" ID="Flow_Water_dil_L" class="inputlog"  ></asp:checkbox></div>
                    <div id="checkboxCh"><asp:Label runat="server" ID="Flow_Water_dil_L_label" class="labellog" Text="Diluition Water"  ></asp:Label> </div> 
                    <div id="checkboxCh"><asp:checkbox runat="server" ID="Level_SW" class="inputlog" ></asp:checkbox></div>
                    <div id="checkboxCh"><asp:Label runat="server" ID="Level_SW_label" class="labellog" Text="Reactor Leakage" ></asp:Label> </div> 
                    <div id="checkboxCh"><asp:checkbox runat="server" ID="BypassB" class="inputlog" ></asp:checkbox></div>
                    <div id="checkboxCh"><asp:Label runat="server" ID="BypassB_label" class="labellog" Text="Pre-Dilution Line Water" ></asp:Label> </div> 
</asp:placeholder>
                    <div id="checkboxCh"><asp:checkbox runat="server" ID="TimeOut_L" class="inputlog" ></asp:checkbox></div>
                    <div id="checkboxCh"><asp:Label runat="server" ID="TimeOut_L_label" class="labellog" Text="Timeout" ></asp:Label> </div> 
                    <div id="checkboxCh"><asp:checkbox runat="server" ID="Service_F_L" class="inputlog" ></asp:checkbox></div>
                    <div id="checkboxCh"><asp:Label runat="server" ID="Service_F_L_label" class="labellog" Text="Service" ></asp:Label> </div> 
                    <div id="checkboxCh"><asp:checkbox runat="server" ID="Lim_Dioxide" class="inputlog" ></asp:checkbox></div>
                    <div id="checkboxCh"><asp:Label runat="server" ID="Lim_Dioxide_label" class="labellog" Text="Dioxide Air Alarm" ></asp:Label> </div> 
                    <div id="checkboxCh"><asp:checkbox runat="server" ID="Lev_Alflow" class="inputlog" ></asp:checkbox></div>
                    <div id="checkboxCh"><asp:Label runat="server" ID="Lev_Alflow_label" class="labellog" Text="Probe Flow" ></asp:Label> </div> 
<asp:placeholder runat="server" id="ltu_release">
                    <div id="checkboxCh"><asp:checkbox runat="server" ID="flow1" class="inputlog" ></asp:checkbox></div>
                    <div id="checkboxCh"><asp:Label runat="server" ID="flow1_label" class="labellog" Text="m3h" ></asp:Label> </div> 
                    <div id="checkboxCh"><asp:checkbox runat="server" ID="clo2" class="inputlog" ></asp:checkbox></div>
                    <div id="checkboxCh"><asp:Label runat="server" ID="clo2_label" class="labellog" Text="ClO2" ></asp:Label> </div> 
                    <div id="checkboxCh"><asp:checkbox runat="server" ID="naso" class="inputlog" ></asp:checkbox></div>
                    <div id="checkboxCh"><asp:Label runat="server" ID="naso_label" class="labellog" Text="ClO2 Air" ></asp:Label> </div> 
                    <div id="checkboxCh"><asp:checkbox runat="server" ID="temperature_lt" class="inputlog" ></asp:checkbox></div>
                    <div id="checkboxCh"><asp:Label runat="server" ID="temperature_lt_label" class="labellog" Text="Temperature" ></asp:Label> </div> 

</asp:placeholder>
              <asp:placeholder runat="server" id="ltu_release_nuovoHW">
                    <div id="checkboxCh"><asp:checkbox runat="server" ID="MinMax" class="inputlog" ></asp:checkbox></div>
                    <div id="checkboxCh"><asp:Label runat="server" ID="MinMax_Label" class="labellog" Text="Min Max" ></asp:Label> </div> 
                    

</asp:placeholder>
              </div>
</div>

        <!-- fine riga -->
<asp:placeholder runat="server" id="lta_release" Visible="False">
    <div class="row-fluid">    
          <div class="span12">
                    <h5 style="padding-top:10px"><asp:literal ID = "Literal7"  text="Totaliser" runat="server"  ></asp:literal></h5>
                    <div id="checkboxCh"><asp:checkbox runat="server" ID="totAcido" class="inputlog" ></asp:checkbox></div>
                    <div id="checkboxCh"><asp:Label runat="server" ID="totAcido_label" class="labellog" Text="Acid" ></asp:Label> </div> 
                    <div id="checkboxCh"><asp:checkbox runat="server" ID="totCloro" class="inputlog" ></asp:checkbox></div>
                    <div id="checkboxCh"><asp:Label runat="server" ID="totCloro_label" class="labellog" Text="Chlorine" ></asp:Label> </div> 
                    <div id="checkboxCh"><asp:checkbox runat="server" ID="totWater" class="inputlog" ></asp:checkbox></div>
                    <div id="checkboxCh"><asp:Label runat="server" ID="totWater_label" class="labellog" Text="Water" ></asp:Label> </div> 
              </div>
</div>
    <div class="row-fluid">    
          <div class="span12">
                    <h5 style="padding-top:10px"><asp:literal ID = "Literal5"  text="Daily Totaliser" runat="server"  ></asp:literal></h5>
                    <div id="checkboxCh"><asp:checkbox runat="server" ID="totAcidoDay" class="inputlog" ></asp:checkbox></div>
                    <div id="checkboxCh"><asp:Label runat="server" ID="totAcidoDay_label" class="labellog" Text="Acid" ></asp:Label> </div> 
                    <div id="checkboxCh"><asp:checkbox runat="server" ID="totCloroDay" class="inputlog" ></asp:checkbox></div>
                    <div id="checkboxCh"><asp:Label runat="server" ID="totCloroDay_label" class="labellog" Text="Chlorine" ></asp:Label> </div> 
                    <div id="checkboxCh"><asp:checkbox runat="server" ID="totWaterDay" class="inputlog" ></asp:checkbox></div>
                    <div id="checkboxCh"><asp:Label runat="server" ID="totWaterDay_label" class="labellog" Text="Water" ></asp:Label> </div> 
              </div>
</div>
<div class="row-fluid">    
        <div class="span12">
                    <h5 style="padding-top:10px"><asp:literal ID = "Literal6"  text="PPM" runat="server"  ></asp:literal></h5>
                    <div id="checkboxCh"><asp:checkbox runat="server" ID="setpoint" class="inputlog" ></asp:checkbox></div>
                    <div id="checkboxCh"><asp:Label runat="server" ID="setpoint_label" class="labellog" Text="Setpoint" ></asp:Label> </div> 
         </div>
</div>

</asp:placeholder>
       

                
        <!-- fine riga -->

         <!-- riga -->
<div class="row-fluid">
        <div class="span6">
            <h5 style="padding-top:10px"><asp:literal ID = "Literal11"  text="Log Range" runat="server" meta:resourcekey="Literal11Resource1" ></asp:literal></h5>
         <div id="checkboxCh"><h5 style="padding-top:10px"><asp:literal ID = "Literal10"  text="From" runat="server" meta:resourcekey="Literal10Resource1" ></asp:literal></h5></div>
         <div id="checkboxCh"><asp:textbox ID="graph_log_from"   class="span12"  runat="server" meta:resourcekey="graph_log_fromResource1"  ></asp:textbox></div>
         <div id="checkboxCh"><h5 style="padding-top:10px"><asp:literal ID = "Literal9"  text="To" runat="server" meta:resourcekey="Literal9Resource1" ></asp:literal></h5></div>
         <div id="checkboxCh"><asp:textbox ID="graph_log_to"   class="span12"  runat="server"  ClientIDMode="Static" meta:resourcekey="graph_log_toResource1"  ></asp:textbox></div>

              </div>
    </div> 
        
        <!-- fine riga -->
	</div>
       <div id="salva" class="btn-primary">
                   <b class="btn-primary btn-icon glyphicons ok"><asp:button runat="server" ID="refresh_graph" class="btn-primary"  text="Refresh Graph" Font-Bold="True" meta:resourcekey="refresh_graphResource1" /><i></i></b>

            </div>
        </div>
	</div>
</div>
    
    <div id="chart_div" style="height: 700px; min-width: 500px">
        
    </div>
 <div id="chart_table" >

</div>
       <asp:Button ID="refresh_log_server" runat="server" BackColor="Transparent" BorderColor="Transparent" meta:resourcekey="refresh_log_serverResource1"  />
    <asp:literal runat="server" ID="literal_script" meta:resourcekey="literal_scriptResource1" ></asp:literal>

    <script type="text/javascript" src="chart/chart_manage_lta_ltu_ltd.js?v=1.0"></script>
   </div> 	
      
      
</form>

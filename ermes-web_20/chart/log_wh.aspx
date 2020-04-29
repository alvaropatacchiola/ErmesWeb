<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="log_wh.aspx.vb" Inherits="ermes_web_20.log_wh" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>

<form id="form_log" runat="server" method="post" onsubmit="return get_action();">
  <div class="innerLR">

      

  <div class="widget" >
	<div id="head_log" class="widget-head"><h4 class="heading glyphicons show_thumbnails_with_lines">w<asp:literal text="Log Settings" runat="server"  ID="log_setting_id" meta:resourcekey="log_setting_idResource1"></asp:literal></h4>
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
          <div class="span12">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal1"  text="Ch1 Select" runat="server" meta:resourcekey="Literal1Resource1"></asp:literal></h5>
                    <div id="checkboxCh"><asp:checkbox Checked="True" runat="server" ID="ch1_val" class="inputlog" meta:resourcekey="ch1_valResource1"></asp:checkbox></div>
                    <div id="checkboxCh"><asp:Label runat="server" ID="ch1_val_label" class="labellog" Text="ch1" meta:resourcekey="ch1_val_labelResource1"></asp:Label> </div> 
                    <div id="checkboxCh"><asp:checkbox runat="server" ID="ch1_dos" class="inputlog" meta:resourcekey="ch1_dosResource1"></asp:checkbox></div>
                    <div id="checkboxCh"><asp:Label runat="server" ID="ch1_dos_label"  class="labellog" Text="Dos Alarm" meta:resourcekey="ch1_dos_labelResource1"></asp:Label> </div> 
                    <div id="checkboxCh"><asp:checkbox runat="server" ID="ch1_probe" class="inputlog" meta:resourcekey="ch1_probeResource1"></asp:checkbox></div>
                    <div id="checkboxCh"><asp:Label runat="server" ID="ch1_probe_label"  class="labellog" Text="Probe Fail" meta:resourcekey="ch1_probe_labelResource1"></asp:Label> </div> 
                    <div id="checkboxCh"><asp:checkbox runat="server" ID="ch1_livello1" class="inputlog" meta:resourcekey="ch1_livello1Resource1"></asp:checkbox></div>
                    <div id="checkboxCh"><asp:Label runat="server" ID="ch1_livello1_label"  class="labellog" Text="Level 1" meta:resourcekey="ch1_livello1_labelResource1"></asp:Label> </div> 
                    <div id="checkboxCh"><asp:checkbox runat="server" ID="ch1_pulse1" class="inputlog" meta:resourcekey="ch1_pulse1Resource1" ></asp:checkbox></div>
                    <div id="checkboxCh"><asp:Label runat="server" ID="ch1_pulse1_label"  class="labellog" Text="Pulse 1" meta:resourcekey="ch1_pulse1_labelResource1" ></asp:Label> </div> 
                    <div id="checkboxCh"><asp:checkbox runat="server" ID="ch1_pulse2" class="inputlog" meta:resourcekey="ch1_pulse2Resource1" ></asp:checkbox></div>
                    <div id="checkboxCh"><asp:Label runat="server" ID="ch1_pulse2_label"  class="labellog" Text="Pulse 2" meta:resourcekey="ch1_pulse2_labelResource1" ></asp:Label> </div> 
                    <div id="checkboxCh"><asp:checkbox runat="server" ID="ch1_rele" class="inputlog" meta:resourcekey="ch1_releResource1" ></asp:checkbox></div>
                    <div id="checkboxCh"><asp:Label runat="server" ID="ch1_rele_label"  class="labellog" Text="Rele" meta:resourcekey="ch1_rele_labelResource1" ></asp:Label> </div> 

              </div> 
                </asp:placeholder>
        <!-- fine riga -->
            </div>
<div class="row-fluid">
        <!-- riga -->
            <asp:placeholder runat="server" ID="ch2_enable">
          <div class="span12">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal2"  text="Ch2 Select" runat="server" meta:resourcekey="Literal2Resource1"></asp:literal></h5>
               <div id="checkboxCh"><asp:checkbox runat="server" ID="ch2_val" class="inputlog" meta:resourcekey="ch2_valResource1"></asp:checkbox></div>
                    <div id="checkboxCh"><asp:Label runat="server" ID="ch2_val_label" class="labellog" Text="ch2" meta:resourcekey="ch2_val_labelResource1"></asp:Label> </div> 
                    <div id="checkboxCh"><asp:checkbox runat="server" ID="ch2_dos" class="inputlog" meta:resourcekey="ch2_dosResource1"></asp:checkbox></div>
                    <div id="checkboxCh"><asp:Label runat="server" ID="ch2_dos_label"  class="labellog" Text="Dos Alarm" meta:resourcekey="ch2_dos_labelResource1"></asp:Label> </div> 
                    <div id="checkboxCh"><asp:checkbox runat="server" ID="ch2_probe" class="inputlog" meta:resourcekey="ch2_probeResource1"></asp:checkbox></div>
                    <div id="checkboxCh"><asp:Label runat="server" ID="ch2_probe_label"  class="labellog" Text="Probe Fail" meta:resourcekey="ch2_probe_labelResource1"></asp:Label> </div> 
                    <div id="checkboxCh"><asp:checkbox runat="server" ID="ch2_level1" class="inputlog" meta:resourcekey="ch2_level1Resource1"></asp:checkbox></div>
                    <div id="checkboxCh"><asp:Label runat="server" ID="ch2_level2_label"  class="labellog" Text="Level 1" meta:resourcekey="ch2_level2_labelResource1"></asp:Label> </div> 
                    <div id="checkboxCh"><asp:checkbox runat="server" ID="ch2_pulse" class="inputlog" meta:resourcekey="ch2_pulseResource1" ></asp:checkbox></div>
                    <div id="checkboxCh"><asp:Label runat="server" ID="ch2_pulse_label"  class="labellog" Text="Pulse" meta:resourcekey="ch2_pulse_labelResource1" ></asp:Label> </div> 
                    <div id="checkboxCh"><asp:checkbox runat="server" ID="ch2_rele" class="inputlog" meta:resourcekey="ch2_releResource1" ></asp:checkbox></div>
                    <div id="checkboxCh"><asp:Label runat="server" ID="ch2_rele_label"  class="labellog" Text="Rele" meta:resourcekey="ch2_rele_labelResource1" ></asp:Label> </div> 
              </asp:placeholder>
            </div>
                
</div>
        <!-- fine riga -->
<div class="row-fluid">
        <!-- riga -->
</div>
        <!-- fine riga -->
        <!-- riga -->
<div class="row-fluid">            
            <asp:placeholder runat="server" ID="timer_enable">
          <div class="span12">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal4"  text="Timer" runat="server" meta:resourcekey="Literal4Resource1"></asp:literal></h5>
               <div id="checkboxCh"><asp:checkbox runat="server" ID="timer_sonda_ch1" class="inputlog" meta:resourcekey="timer_sonda_ch1Resource1" ></asp:checkbox></div>
                    <div id="checkboxCh"><asp:Label runat="server" ID="timer_sonda_ch1_label" class="labellog" Text="TimerProbe Ch1" meta:resourcekey="timer_sonda_ch1_labelResource1" ></asp:Label> </div> 
                    <div id="checkboxCh"><asp:checkbox runat="server" ID="timer_sonda_ch2" class="inputlog" meta:resourcekey="timer_sonda_ch2Resource1" ></asp:checkbox></div>
                    <div id="checkboxCh"><asp:Label runat="server" ID="timer_sonda_ch2_label"  class="labellog" Text="TimerProbe Ch2" meta:resourcekey="timer_sonda_ch2_labelResource1"></asp:Label> </div> 
                    <div id="checkboxCh"><asp:checkbox runat="server" ID="timer_pagamento" class="inputlog" meta:resourcekey="timer_pagamentoResource1"></asp:checkbox></div>
                    <div id="checkboxCh"><asp:Label runat="server" ID="timer_pagamento_label"  class="labellog" Text="Timer Pagamento" meta:resourcekey="timer_pagamento_labelResource1" ></asp:Label> </div> 
                    <div id="checkboxCh"><asp:checkbox runat="server" ID="timer_manutenzione" class="inputlog" meta:resourcekey="timer_manutenzioneResource1" > </asp:checkbox></div>
                    <div id="checkboxCh"><asp:Label runat="server" ID="timer_manutenzione_label"  class="labellog" Text="Timer manutenzione" meta:resourcekey="timer_manutenzione_labelResource1" ></asp:Label> </div> 
                    <div id="checkboxCh"><asp:checkbox runat="server" ID="timer_filtro" class="inputlog" meta:resourcekey="timer_filtroResource1" > </asp:checkbox></div>
                    <div id="checkboxCh"><asp:Label runat="server" ID="timer_filtro_label"  class="labellog" Text="Timer Filtro" meta:resourcekey="timer_filtro_labelResource1" ></asp:Label> </div> 

            </div>
                </asp:placeholder>
            <asp:placeholder runat="server" ID="ch3_enable">
          <div class="span6">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal3"  text="Ch3 Select" runat="server" meta:resourcekey="Literal3Resource1"></asp:literal></h5>
              
                                <div id="checkboxCh"><asp:checkbox runat="server" ID="ch3_val" class="inputlog" meta:resourcekey="ch3_valResource1"></asp:checkbox></div>
                    <div id="checkboxCh"><asp:Label runat="server" ID="ch3_val_label" class="labellog" Text="ch3" meta:resourcekey="ch3_val_labelResource1"></asp:Label> </div> 

              </div>
             </asp:placeholder>
</div>
        <!-- fine riga -->
       

                
        <!-- fine riga -->
        <!-- riga -->
<div class="row-fluid">   
        <!-- riga -->
            <asp:placeholder runat="server" ID="Placeholder1">
        
          <div class="span6">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal6"  text="Input" runat="server" meta:resourcekey="Literal6Resource1"></asp:literal></h5>
              <div id="checkboxCh"><asp:checkbox Checked="True" runat="server" ID="flow_select" class="inputlog" meta:resourcekey="flow_selectResource1"></asp:checkbox></div>
              <div id="checkboxCh"><asp:Label runat="server" ID="label_flow_select" class="labellog" Text="Flow" meta:resourcekey="label_flow_selectResource1"></asp:Label> </div>
              <div id="checkboxCh"><asp:checkbox Checked="True" runat="server" ID="stby_select" class="inputlog" meta:resourcekey="stby_selectResource1" ></asp:checkbox></div>
              <div id="checkboxCh"><asp:Label runat="server" ID="label_stby_select" class="labellog" Text="Stby" meta:resourcekey="label_stby_selectResource1" ></asp:Label> </div>

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
         <div id="checkboxCh"><h5 style="padding-top:10px"><asp:literal ID = "Literal9"  text="To" runat="server" meta:resourcekey="Literal9Resource1"></asp:literal></h5></div>
         <div id="checkboxCh"><asp:textbox ID="graph_log_to"   class="span12"  runat="server" meta:resourcekey="graph_log_toResource1" ClientIDMode="Static"  ></asp:textbox></div>

              </div>
    </div> 
        
        <!-- fine riga -->
	</div>
       <div id="salva" class="btn-primary">
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

    <script type="text/javascript" src="chart/chart_manage_wh.js"></script>
   </div> 	
      
      
</form>
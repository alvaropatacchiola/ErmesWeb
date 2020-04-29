<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="report_max5.aspx.vb" Inherits="ermes_web_20.report" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>
<form id="form_log" runat="server"  method="post" onsubmit="return get_action();" >
    

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
          <div class="span12">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal1"  text="Ch1 Select" runat="server" meta:resourcekey="Literal1Resource1"></asp:literal></h5>
                    <div id="checkboxCh"><asp:checkbox Checked="True" runat="server" ID="ch1_val" class="inputlog" meta:resourcekey="ch1_valResource1"></asp:checkbox></div>
                    <div id="checkboxCh"><asp:Label runat="server" ID="ch1_val_label" class="labellog" Text="ch1" meta:resourcekey="ch1_val_labelResource1"></asp:Label> </div> 

<asp:placeholder runat="server" ID="ch1_da_enable">
                    <div id="checkboxCh"><asp:checkbox runat="server" ID="ch1_da" class="inputlog" ></asp:checkbox></div>
                    <div id="checkboxCh"><asp:Label runat="server" ID="ch1_da_label" class="labellog" Text="Digital Da" ></asp:Label> </div> 
</asp:placeholder>
<asp:placeholder runat="server" ID="ch1_db_enable">
                    <div id="checkboxCh"><asp:checkbox runat="server" ID="ch1_db" class="inputlog" ></asp:checkbox></div>
                    <div id="checkboxCh"><asp:Label runat="server" ID="ch1_db_label" class="labellog" Text="Digital Db" ></asp:Label> </div> 
</asp:placeholder>
<asp:placeholder runat="server" ID="ch1_pa_enable">
                    <div id="checkboxCh"><asp:checkbox runat="server" ID="ch1_pa" class="inputlog" ></asp:checkbox></div>
                    <div id="checkboxCh"><asp:Label runat="server" ID="ch1_pa_label" class="labellog" Text="Proportional Pa" ></asp:Label> </div> 
</asp:placeholder>
<asp:placeholder runat="server" ID="ch1_pb_enable">
                    <div id="checkboxCh"><asp:checkbox runat="server" ID="ch1_pb" class="inputlog" ></asp:checkbox></div>
                    <div id="checkboxCh"><asp:Label runat="server" ID="ch1_pb_label" class="labellog" Text="Proportional Pb" ></asp:Label> </div> 
</asp:placeholder>
<asp:placeholder runat="server" ID="ch1_ma_enable">
                    <div id="checkboxCh"><asp:checkbox runat="server" ID="ch1_ma" class="inputlog" ></asp:checkbox></div>
                    <div id="checkboxCh"><asp:Label runat="server" ID="ch1_ma_label" class="labellog" Text="mA" ></asp:Label> </div> 
</asp:placeholder>
<asp:placeholder runat="server" ID="ch1_aa_enable">
                    <div id="checkboxCh"><asp:checkbox runat="server" ID="ch1_aa" class="inputlog" meta:resourcekey="ch1_aaResource1"></asp:checkbox></div>
                    <div id="checkboxCh"><asp:Label runat="server" ID="ch1_aa_label" class="labellog" Text="Alarm Aa" meta:resourcekey="ch1_aa_labelResource1"></asp:Label> </div> 
</asp:placeholder>
<asp:placeholder runat="server" ID="ch1_ab_enable">
                    <div id="checkboxCh"><asp:checkbox runat="server" ID="ch1_ab" class="inputlog" meta:resourcekey="ch1_abResource1"></asp:checkbox></div>
                    <div id="checkboxCh"><asp:Label runat="server" ID="ch1_ab_label"  class="labellog" Text="Alarm Ab" meta:resourcekey="ch1_ab_labelResource1"></asp:Label> </div> 
</asp:placeholder>
<asp:placeholder runat="server" ID="ch1_ad_enable">
                    <div id="checkboxCh"><asp:checkbox runat="server" ID="ch1_ad" class="inputlog" meta:resourcekey="ch1_adResource1"></asp:checkbox></div>
                    <div id="checkboxCh"><asp:Label runat="server" ID="ch1_ad_label"  class="labellog" Text="Alarm Ad" meta:resourcekey="ch1_ad_labelResource1"></asp:Label> </div> 
</asp:placeholder>
<asp:placeholder runat="server" ID="ch1_ar_enable">
                    <div id="checkboxCh"><asp:checkbox runat="server" ID="ch1_ar" class="inputlog" meta:resourcekey="ch1_arResource1"></asp:checkbox></div>
                    <div id="checkboxCh"><asp:Label runat="server" ID="ch1_ar_label"  class="labellog" Text="Alarm Ar" meta:resourcekey="ch1_ar_labelResource1"></asp:Label> </div> 
</asp:placeholder>
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
<asp:placeholder runat="server" ID="ch2_da_enable">
                    <div id="checkboxCh"><asp:checkbox runat="server" ID="ch2_da" class="inputlog" ></asp:checkbox></div>
                    <div id="checkboxCh"><asp:Label runat="server" ID="ch2_da_label" class="labellog" Text="Digital Da" ></asp:Label> </div> 
</asp:placeholder>
<asp:placeholder runat="server" ID="ch2_db_enable">
                    <div id="checkboxCh"><asp:checkbox runat="server" ID="ch2_db" class="inputlog" ></asp:checkbox></div>
                    <div id="checkboxCh"><asp:Label runat="server" ID="ch2_db_label" class="labellog" Text="Digital Db" ></asp:Label> </div> 
</asp:placeholder>
<asp:placeholder runat="server" ID="ch2_pa_enable">
                    <div id="checkboxCh"><asp:checkbox runat="server" ID="ch2_pa" class="inputlog" ></asp:checkbox></div>
                    <div id="checkboxCh"><asp:Label runat="server" ID="ch2_pa_label" class="labellog" Text="Proportional Pa" ></asp:Label> </div> 
</asp:placeholder>
<asp:placeholder runat="server" ID="ch2_pb_enable">
                    <div id="checkboxCh"><asp:checkbox runat="server" ID="ch2_pb" class="inputlog" ></asp:checkbox></div>
                    <div id="checkboxCh"><asp:Label runat="server" ID="ch2_pb_label" class="labellog" Text="Proportional Pb" ></asp:Label> </div> 
</asp:placeholder>
<asp:placeholder runat="server" ID="ch2_ma_enable">
                    <div id="checkboxCh"><asp:checkbox runat="server" ID="ch2_ma" class="inputlog" ></asp:checkbox></div>
                    <div id="checkboxCh"><asp:Label runat="server" ID="ch2_ma_label" class="labellog" Text="mA" ></asp:Label> </div> 
</asp:placeholder>
<asp:placeholder runat="server" ID="ch2_aa_enable">
                    <div id="checkboxCh"><asp:checkbox runat="server" ID="ch2_aa" class="inputlog" meta:resourcekey="ch2_aaResource1"></asp:checkbox></div>
                    <div id="checkboxCh"><asp:Label runat="server" ID="ch2_aa_label" class="labellog" Text="Alarm Aa" meta:resourcekey="ch2_aa_labelResource1"></asp:Label> </div> 
</asp:placeholder>
<asp:placeholder runat="server" ID="ch2_ab_enable">
                    <div id="checkboxCh"><asp:checkbox runat="server" ID="ch2_ab" class="inputlog" meta:resourcekey="ch2_abResource1"></asp:checkbox></div>
                    <div id="checkboxCh"><asp:Label runat="server" ID="ch2_ab_label"  class="labellog" Text="Alarm Ab" meta:resourcekey="ch2_ab_labelResource1"></asp:Label> </div> 
</asp:placeholder>
<asp:placeholder runat="server" ID="ch2_ad_enable">
                    <div id="checkboxCh"><asp:checkbox runat="server" ID="ch2_ad" class="inputlog" meta:resourcekey="ch2_adResource1"></asp:checkbox></div>
                    <div id="checkboxCh"><asp:Label runat="server" ID="ch2_ad_label"  class="labellog" Text="Alarm Ad" meta:resourcekey="ch2_ad_labelResource1"></asp:Label> </div> 
</asp:placeholder>
<asp:placeholder runat="server" ID="ch2_ar_enable">
                    <div id="checkboxCh"><asp:checkbox runat="server" ID="ch2_ar" class="inputlog" meta:resourcekey="ch2_arResource1"></asp:checkbox></div>
                    <div id="checkboxCh"><asp:Label runat="server" ID="ch2_ar_label"  class="labellog" Text="Alarm Ar" meta:resourcekey="ch2_ar_labelResource1"></asp:Label> </div> 
</asp:placeholder>
            </div>
                </asp:placeholder>
</div>
        <!-- fine riga -->
        <!-- riga -->
<div class="row-fluid">            
            <asp:placeholder runat="server" ID="ch3_enable">
          <div class="span12">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal3"  text="Ch3 Select" runat="server" meta:resourcekey="Literal3Resource1"></asp:literal></h5>
              
                    <div id="checkboxCh"><asp:checkbox runat="server" ID="ch3_val" class="inputlog" meta:resourcekey="ch3_valResource1"></asp:checkbox></div>
                    <div id="checkboxCh"><asp:Label runat="server" ID="ch3_val_label" class="labellog" Text="ch3" meta:resourcekey="ch3_val_labelResource1"></asp:Label> </div> 
<asp:placeholder runat="server" ID="ch3_da_enable">                    
                    <div id="checkboxCh"><asp:checkbox runat="server" ID="ch3_da" class="inputlog" ></asp:checkbox></div>
                    <div id="checkboxCh"><asp:Label runat="server" ID="ch3_da_label" class="labellog" Text="Digital Da" ></asp:Label> </div> 
</asp:placeholder>
<asp:placeholder runat="server" ID="ch3_db_enable">
                    <div id="checkboxCh"><asp:checkbox runat="server" ID="ch3_db" class="inputlog" ></asp:checkbox></div>
                    <div id="checkboxCh"><asp:Label runat="server" ID="ch3_db_label" class="labellog" Text="Digital Db" ></asp:Label> </div> 
</asp:placeholder>
<asp:placeholder runat="server" ID="ch3_pa_enable">
                    <div id="checkboxCh"><asp:checkbox runat="server" ID="ch3_pa" class="inputlog" ></asp:checkbox></div>
                    <div id="checkboxCh"><asp:Label runat="server" ID="ch3_pa_label" class="labellog" Text="Proportional Pa" ></asp:Label> </div> 
</asp:placeholder>
<asp:placeholder runat="server" ID="ch3_pb_enable">
                    <div id="checkboxCh"><asp:checkbox runat="server" ID="ch3_pb" class="inputlog" ></asp:checkbox></div>
                    <div id="checkboxCh"><asp:Label runat="server" ID="ch3_pb_label" class="labellog" Text="Proportional Pb" ></asp:Label> </div> 
</asp:placeholder>
<asp:placeholder runat="server" ID="ch3_ma_enable">
                    <div id="checkboxCh"><asp:checkbox runat="server" ID="ch3_ma" class="inputlog" ></asp:checkbox></div>
                    <div id="checkboxCh"><asp:Label runat="server" ID="ch3_ma_label" class="labellog" Text="mA" ></asp:Label> </div> 
</asp:placeholder>     
<asp:placeholder runat="server" ID="ch3_aa_enable">  
                    <div id="checkboxCh"><asp:checkbox runat="server" ID="ch3_aa" class="inputlog" meta:resourcekey="ch3_aaResource1"></asp:checkbox></div>
                    <div id="checkboxCh"><asp:Label runat="server" ID="ch3_aa_label" class="labellog" Text="Alarm Aa" meta:resourcekey="ch3_aa_labelResource1"></asp:Label> </div> 
</asp:placeholder>
<asp:placeholder runat="server" ID="ch3_ab_enable">
                    <div id="checkboxCh"><asp:checkbox runat="server" ID="ch3_ab" class="inputlog" meta:resourcekey="ch3_abResource1"></asp:checkbox></div>
                    <div id="checkboxCh"><asp:Label runat="server" ID="ch3_ab_label"  class="labellog" Text="Alarm Ab" meta:resourcekey="ch3_ab_labelResource1"></asp:Label> </div> 
</asp:placeholder>
<asp:placeholder runat="server" ID="ch3_ad_enable">
                    <div id="checkboxCh"><asp:checkbox runat="server" ID="ch3_ad" class="inputlog" meta:resourcekey="ch3_adResource1"></asp:checkbox></div>
                    <div id="checkboxCh"><asp:Label runat="server" ID="ch3_ad_label"  class="labellog" Text="Alarm Ad" meta:resourcekey="ch3_ad_labelResource1"></asp:Label> </div> 
</asp:placeholder>
<asp:placeholder runat="server" ID="ch3_ar_enable">
                    <div id="checkboxCh"><asp:checkbox runat="server" ID="ch3_ar" class="inputlog" meta:resourcekey="ch3_arResource1"></asp:checkbox></div>
                    <div id="checkboxCh"><asp:Label runat="server" ID="ch3_ar_label"  class="labellog" Text="Alarm Ar" meta:resourcekey="ch3_ar_labelResource1"></asp:Label> </div>
</asp:placeholder>
              </div>
             </asp:placeholder>

        <!-- fine riga -->
</div>
<div class="row-fluid">    
        <!-- riga -->
            
                <asp:placeholder runat="server" ID="ch4_enable">
          <div class="span12">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal4"  text="Ch4 Select" runat="server" meta:resourcekey="Literal4Resource1"></asp:literal></h5>
                    <div id="checkboxCh"><asp:checkbox runat="server" ID="ch4_val" class="inputlog" meta:resourcekey="ch4_valResource1"></asp:checkbox></div>
                    <div id="checkboxCh"><asp:Label runat="server" ID="ch4_val_label" class="labellog" Text="ch4" meta:resourcekey="ch4_val_labelResource1"></asp:Label> </div> 
<asp:placeholder runat="server" ID="ch4_da_enable">                                        
                    <div id="checkboxCh"><asp:checkbox runat="server" ID="ch4_da" class="inputlog" ></asp:checkbox></div>
                    <div id="checkboxCh"><asp:Label runat="server" ID="ch4_da_label" class="labellog" Text="Digital Da" ></asp:Label> </div> 
</asp:placeholder>
<asp:placeholder runat="server" ID="ch4_db_enable">                    
                    <div id="checkboxCh"><asp:checkbox runat="server" ID="ch4_db" class="inputlog" ></asp:checkbox></div>
                    <div id="checkboxCh"><asp:Label runat="server" ID="ch4_db_label" class="labellog" Text="Digital Db" ></asp:Label> </div> 
</asp:placeholder>
<asp:placeholder runat="server" ID="ch4_pa_enable">                    
                    <div id="checkboxCh"><asp:checkbox runat="server" ID="ch4_pa" class="inputlog" ></asp:checkbox></div>
                    <div id="checkboxCh"><asp:Label runat="server" ID="ch4_pa_label" class="labellog" Text="Proportional Pa" ></asp:Label> </div> 
</asp:placeholder>
<asp:placeholder runat="server" ID="ch4_pb_enable">                    
                    <div id="checkboxCh"><asp:checkbox runat="server" ID="ch4_pb" class="inputlog" ></asp:checkbox></div>
                    <div id="checkboxCh"><asp:Label runat="server" ID="ch4_pb_label" class="labellog" Text="Proportional Pb" ></asp:Label> </div> 
</asp:placeholder>
<asp:placeholder runat="server" ID="ch4_ma_enable">                    
                    <div id="checkboxCh"><asp:checkbox runat="server" ID="ch4_ma" class="inputlog" ></asp:checkbox></div>
                    <div id="checkboxCh"><asp:Label runat="server" ID="ch4_ma_label" class="labellog" Text="mA" ></asp:Label> </div> 
</asp:placeholder> 
<asp:placeholder runat="server" ID="ch4_aa_enable">                                     
              <div id="checkboxCh"><asp:checkbox runat="server" ID="ch4_aa" class="inputlog" meta:resourcekey="ch4_aaResource1"></asp:checkbox></div>
                    <div id="checkboxCh"><asp:Label runat="server" ID="ch4_aa_label" class="labellog" Text="Alarm Aa" meta:resourcekey="ch4_aa_labelResource1"></asp:Label> </div> 
</asp:placeholder>
<asp:placeholder runat="server" ID="ch4_ab_enable">
                    <div id="checkboxCh"><asp:checkbox runat="server" ID="ch4_ab" class="inputlog" meta:resourcekey="ch4_abResource1"></asp:checkbox></div>
                    <div id="checkboxCh"><asp:Label runat="server" ID="ch4_ab_label"  class="labellog" Text="Alarm Ab" meta:resourcekey="ch4_ab_labelResource1"></asp:Label> </div> 
</asp:placeholder>
<asp:placeholder runat="server" ID="ch4_ad_enable"> 
                    <div id="checkboxCh"><asp:checkbox runat="server" ID="ch4_ad" class="inputlog" meta:resourcekey="ch4_adResource1"></asp:checkbox></div>
                    <div id="checkboxCh"><asp:Label runat="server" ID="ch4_ad_label"  class="labellog" Text="Alarm Ad" meta:resourcekey="ch4_ad_labelResource1"></asp:Label> </div> 
</asp:placeholder>
<asp:placeholder runat="server" ID="ch4_ar_enable">  
                    <div id="checkboxCh"><asp:checkbox runat="server" ID="ch4_ar" class="inputlog" meta:resourcekey="ch4_arResource1"></asp:checkbox></div>
                    <div id="checkboxCh"><asp:Label runat="server" ID="ch4_ar_label"  class="labellog" Text="Alarm Ar" meta:resourcekey="ch4_ar_labelResource1"></asp:Label> </div>
</asp:placeholder>
              </div>
            
                </asp:placeholder>
    </div>
        <!-- fine riga -->
        <!-- riga -->
<div class="row-fluid">
        <asp:placeholder runat="server" ID="ch5_enable">

          <div class="span12">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal5"  text="Ch5 Select" runat="server" meta:resourcekey="Literal5Resource1"></asp:literal></h5>
                    <div id="checkboxCh"><asp:checkbox runat="server" ID="ch5_val" class="inputlog" meta:resourcekey="ch5_valResource1"></asp:checkbox></div>
                    <div id="checkboxCh"><asp:Label runat="server" ID="ch5_val_label" class="labellog" Text="ch5" meta:resourcekey="ch5_val_labelResource1"></asp:Label> </div> 

<asp:placeholder runat="server" ID="ch5_da_enable">
                     <div id="checkboxCh"><asp:checkbox runat="server" ID="ch5_da" class="inputlog" ></asp:checkbox></div>
                    <div id="checkboxCh"><asp:Label runat="server" ID="ch5_da_label" class="labellog" Text="Digital Da" ></asp:Label> </div> 
</asp:placeholder>
<asp:placeholder runat="server" ID="ch5_db_enable">
                    <div id="checkboxCh"><asp:checkbox runat="server" ID="ch5_db" class="inputlog" ></asp:checkbox></div>
                    <div id="checkboxCh"><asp:Label runat="server" ID="ch5_db_label" class="labellog" Text="Digital Db" ></asp:Label> </div> 
</asp:placeholder>
<asp:placeholder runat="server" ID="ch5_pa_enable">
                    <div id="checkboxCh"><asp:checkbox runat="server" ID="ch5_pa" class="inputlog" ></asp:checkbox></div>
                    <div id="checkboxCh"><asp:Label runat="server" ID="ch5_pa_label" class="labellog" Text="Proportional Pa" ></asp:Label> </div> 
</asp:placeholder>
<asp:placeholder runat="server" ID="ch5_pb_enable">
                    <div id="checkboxCh"><asp:checkbox runat="server" ID="ch5_pb" class="inputlog" ></asp:checkbox></div>
                    <div id="checkboxCh"><asp:Label runat="server" ID="ch5_pb_label" class="labellog" Text="Proportional Pb" ></asp:Label> </div> 
</asp:placeholder>
<asp:placeholder runat="server" ID="ch5_ma_enable">
                    <div id="checkboxCh"><asp:checkbox runat="server" ID="ch5_ma" class="inputlog" ></asp:checkbox></div>
                    <div id="checkboxCh"><asp:Label runat="server" ID="ch5_ma_label" class="labellog" Text="mA" ></asp:Label> </div> 
</asp:placeholder>
<asp:placeholder runat="server" ID="ch5_aa_enable">
                    <div id="checkboxCh"><asp:checkbox runat="server" ID="ch5_aa" class="inputlog" meta:resourcekey="ch5_aaResource1"></asp:checkbox></div>
                    <div id="checkboxCh"><asp:Label runat="server" ID="ch5_aa_label" class="labellog" Text="Alarm Aa" meta:resourcekey="ch5_aa_labelResource1"></asp:Label> </div> 
</asp:placeholder>
<asp:placeholder runat="server" ID="ch5_ab_enable">
                    <div id="checkboxCh"><asp:checkbox runat="server" ID="ch5_ab" class="inputlog" meta:resourcekey="ch5_abResource1"></asp:checkbox></div>
                    <div id="checkboxCh"><asp:Label runat="server" ID="ch5_ab_label"  class="labellog" Text="Alarm Ab" meta:resourcekey="ch5_ab_labelResource1"></asp:Label> </div> 
</asp:placeholder>
<asp:placeholder runat="server" ID="ch5_ad_enable">
                    <div id="checkboxCh"><asp:checkbox runat="server" ID="ch5_ad" class="inputlog" meta:resourcekey="ch5_adResource1"></asp:checkbox></div>
                    <div id="checkboxCh"><asp:Label runat="server" ID="ch5_ad_label"  class="labellog" Text="Alarm Ad" meta:resourcekey="ch5_ad_labelResource1"></asp:Label> </div> 
</asp:placeholder>
<asp:placeholder runat="server" ID="ch5_ar_enable">
                    <div id="checkboxCh"><asp:checkbox runat="server" ID="ch5_ar" class="inputlog" meta:resourcekey="ch5_arResource1"></asp:checkbox></div>
                    <div id="checkboxCh"><asp:Label runat="server" ID="ch5_ar_label"  class="labellog" Text="Alarm Ar" meta:resourcekey="ch5_ar_labelResource1"></asp:Label> </div>
</asp:placeholder>
              </div>
            
                </asp:placeholder>
        <!-- fine riga -->
</div>
<div class="row-fluid">
        <!-- riga -->
            <asp:placeholder runat="server" ID="Placeholder1">
        
          <div class="span6">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal6"  text="Input" runat="server" meta:resourcekey="Literal6Resource1"></asp:literal></h5>
              <div id="checkboxCh"><asp:checkbox Checked="True" runat="server" ID="flow_select" class="inputlog" meta:resourcekey="flow_selectResource1"></asp:checkbox></div>
              <div id="checkboxCh"><asp:Label runat="server" ID="label_flow_select" class="labellog" Text="Flow" meta:resourcekey="label_flow_selectResource1"></asp:Label> </div>
              <div id="checkboxCh"><asp:checkbox runat="server" ID="level1_select" class="inputlog" meta:resourcekey="level1_selectResource1"></asp:checkbox></div>
              <div id="checkboxCh"><asp:Label runat="server" ID="label_level1_select" class="labellog" Text="Level1" meta:resourcekey="label_level1_selectResource1"></asp:Label> </div>
              <div id="checkboxCh"><asp:checkbox runat="server" ID="level2_select" class="inputlog" meta:resourcekey="level2_selectResource1"></asp:checkbox></div>
              <div id="checkboxCh"><asp:Label runat="server" ID="label_level2_select" class="labellog" Text="Level2" meta:resourcekey="label_level2_selectResource1"></asp:Label> </div>
              <div id="checkboxCh"><asp:checkbox runat="server" ID="level3_select" class="inputlog" meta:resourcekey="level3_selectResource1"></asp:checkbox></div>
              <div id="checkboxCh"><asp:Label runat="server" ID="label_level3_select" class="labellog" Text="Level3" meta:resourcekey="label_level3_selectResource1"></asp:Label> </div>
              <div id="checkboxCh"><asp:checkbox runat="server" ID="level4_select" class="inputlog" meta:resourcekey="level4_selectResource1"></asp:checkbox></div>
              <div id="checkboxCh"><asp:Label runat="server" ID="label_level4_select" class="labellog" Text="Level4" meta:resourcekey="label_level4_selectResource1"></asp:Label> </div>
               </div>
  </asp:placeholder>
</div>
<div class="row-fluid">
      <asp:placeholder runat="server" ID="Placeholder2">
        
          <div class="span6">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal7"  text="Temperature" runat="server" meta:resourcekey="Literal7Resource1"></asp:literal></h5>
              <div id="checkboxCh"><asp:checkbox Checked="False" runat="server" ID="temperature_select" class="inputlog" meta:resourcekey="temperature_selectResource1"></asp:checkbox></div>
              <div id="checkboxCh"><asp:Label runat="server" ID="temperature_select_label" class="labellog" Text="temperature" meta:resourcekey="temperature_select_labelResource1"></asp:Label> </div>
           
               </div>
  </asp:placeholder>
     <div class="span6">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal15"  text="FlowMeter" runat="server" meta:resourcekey="Literal15Resource1"></asp:literal></h5>
              <div id="checkboxCh"><asp:checkbox  runat="server" ID="flow_meter" class="inputlog" meta:resourcekey="flow_meterResource1"></asp:checkbox></div>
              <div id="checkboxCh"><asp:Label runat="server" ID="flow_meter_label" class="labellog" Text="Flow m3/h" meta:resourcekey="flow_meter_labelResource1"></asp:Label> </div>
<asp:placeholder runat="server" ID="flow_meter_low_enable">
              <div id="checkboxCh"><asp:checkbox  runat="server" ID="flow_meter_low" class="inputlog" meta:resourcekey="flow_meter_lowResource1"></asp:checkbox></div>
              <div id="checkboxCh"><asp:Label runat="server" ID="flow_meter_low_label" class="labellog" Text="Flow Meter Low" meta:resourcekey="flow_meter_low_labelResource1"></asp:Label> </div>
</asp:placeholder>    
            </div>
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
        
        <!-- fine riga -->
        <!-- riga 
<div class="row-fluid">
        <div class="span3">
         <h5 style="padding-top:10px"><asp:literal ID = "Literal8"  text="From" runat="server"></asp:literal></h5>
         <asp:textbox ID="report_log_from"   class="span12"  runat="server"  ></asp:textbox>
         <h5 style="padding-top:10px"><asp:literal ID = "Literal9"  text="To" runat="server"></asp:literal></h5>
         <asp:textbox ID="report_log_to"   class="span12"  runat="server"  ></asp:textbox>

          <asp:Button ID="range_report" runat="server" Text="Update Range"  />
              </div>
    </div> 
        -->
        <!-- fine riga -->
	</div>
       <div id="salva" class="btn-primary">
                   <b class="btn-primary btn-icon glyphicons ok"><asp:button runat="server" ID="refresh_report" class="btn-primary"  text="Refresh Report" Font-Bold="True" meta:resourcekey="refresh_reportResource1" /><i></i></b>

            </div>

	</div> 

<div class="row-fluid">
        <div class="span3">
          <asp:Button ID="pdf_id" runat="server" Text="PDF"  OnClick="btnExport_Click" meta:resourcekey="pdf_idResource1" />
          <asp:Button ID="excel_id" runat="server" Text="EXCEL" meta:resourcekey="excel_idResource1"  />
          
              </div>
    </div> 
<asp:Panel ID="pnlPerson" runat="server" meta:resourcekey="pnlPersonResource1">          
                    <div class="widget-body">
               <!-- Table --> <table class="dynamicTable table table-striped table-bordered table-condensed"> 
                   <!-- Table heading --> 
                  <asp:Literal runat="server" ID="report_head" meta:resourcekey="report_headResource1"></asp:Literal>
                   <!-- // Table heading END -->
                   <!-- Table body --> 
                        <asp:Literal runat="server" ID="report_body"></asp:Literal>
                   <asp:Literal runat="server" ID="report_body1"></asp:Literal>
                   <asp:Literal runat="server" ID="report_body2"></asp:Literal>
                   <asp:Literal runat="server" ID="report_body3"></asp:Literal>
                   <asp:Literal runat="server" ID="report_body4"></asp:Literal>
                   <asp:Literal runat="server" ID="report_body5"></asp:Literal>
                   <asp:Literal runat="server" ID="report_body6"></asp:Literal>
                   <asp:Literal runat="server" ID="report_body7"></asp:Literal>
                   <asp:Literal runat="server" ID="report_body8"></asp:Literal>
                   <asp:Literal runat="server" ID="report_body9"></asp:Literal>
                   <asp:Literal runat="server" ID="report_body10"></asp:Literal>
                   <asp:Literal runat="server" ID="report_body11"></asp:Literal>
                   <asp:Literal runat="server" ID="report_body12"></asp:Literal>
                   <asp:Literal runat="server" ID="report_body13"></asp:Literal>
                   <asp:Literal runat="server" ID="report_body14"></asp:Literal>
                   <asp:Literal runat="server" ID="report_body15"></asp:Literal>
                   <asp:Literal runat="server" ID="report_body16"></asp:Literal>
                   <asp:Literal runat="server" ID="report_body17"></asp:Literal>
                   <asp:Literal runat="server" ID="report_body18"></asp:Literal>
                   <asp:Literal runat="server" ID="report_body19"></asp:Literal>
                   <asp:Literal runat="server" ID="report_body20"></asp:Literal>
                   <asp:Literal runat="server" ID="report_body21"></asp:Literal>
                   <asp:Literal runat="server" ID="report_body22"></asp:Literal>
                   <asp:Literal runat="server" ID="report_body23"></asp:Literal>
                   <asp:Literal runat="server" ID="report_body24"></asp:Literal>
                   <asp:Literal runat="server" ID="report_body25"></asp:Literal>

                   
                   <!-- // Table body END -->

                              </table> 
              <!-- // Table END --> 
                 </div> 
              </asp:Panel>
              </div>
       <!-- // Widget END -->
       

      </div>
    <asp:Button ID="refresh_log_server" runat="server" BackColor="Transparent" BorderColor="Transparent" meta:resourcekey="refresh_log_serverResource1"  />
    <asp:literal runat="server" ID="literal_script" meta:resourcekey="literal_scriptResource1"></asp:literal>
    	<script src="theme/scripts/plugins/tables/DataTables/media/js/jquery.dataTables.min.js"></script>
	<script type="text/javascript" src="chart/report_manage_max5.js"></script>
    <script src="theme/scripts/plugins/tables/DataTables/media/js/DT_bootstrap.js"></script>
	
	<!-- Tables Demo Script -->
	<script src="theme/scripts/demo/tables.js"></script>
    
    </form>
<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="log_max5.aspx.vb" Inherits="ermes_web_20.log" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>

<form id="form_log"  runat="server" method="post" onsubmit="return get_action();"  >
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
        <!-- riga -->
            <asp:placeholder runat="server" ID="Placeholder1" >
        
          <div class="span6">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal6"  text="Input" runat="server" meta:resourcekey="Literal6Resource1"></asp:literal></h5>
              <div id="checkboxCh"><asp:checkbox Checked="True" runat="server" ID="flow_select" class="inputlog" meta:resourcekey="flow_selectResource1"></asp:checkbox></div>
              <div id="checkboxCh"><asp:Label runat="server" ID="label_flow_select" class="labellog" Text="Flow " meta:resourcekey="label_flow_selectResource1"></asp:Label> </div>
          <asp:placeholder runat="server" ID="flow2Doppia">
                <div id="checkboxCh"><asp:checkbox  runat="server" ID="flow_select2" class="inputlog" meta:resourcekey="flow_selectResource1"></asp:checkbox></div>
              <div id="checkboxCh"><asp:Label runat="server" ID="label_flow_select2" class="labellog" Text="Flow " meta:resourcekey="label_flow_selectResource1"></asp:Label> </div>
        </asp:placeholder>
              <div id="checkboxCh"><asp:checkbox runat="server" ID="level1_select" class="inputlog" meta:resourcekey="level1_selectResource1" Visible="False"></asp:checkbox></div>
              <div id="checkboxCh"><asp:Label runat="server" ID="label_level1_select" class="labellog" Text="Level1" meta:resourcekey="label_level1_selectResource1" Visible="False"></asp:Label> </div>
              <div id="checkboxCh"><asp:checkbox runat="server" ID="level2_select" class="inputlog" meta:resourcekey="level2_selectResource1" Visible="False"></asp:checkbox></div>
              <div id="checkboxCh"><asp:Label runat="server" ID="label_level2_select" class="labellog" Text="Level2" meta:resourcekey="label_level2_selectResource1" Visible="False"></asp:Label> </div>
              <div id="checkboxCh"><asp:checkbox runat="server" ID="level3_select" class="inputlog" meta:resourcekey="level3_selectResource1" Visible="False"></asp:checkbox></div>
              <div id="checkboxCh"><asp:Label runat="server" ID="label_level3_select" class="labellog" Text="Level3" meta:resourcekey="label_level3_selectResource1" Visible="False"></asp:Label> </div>
              <div id="checkboxCh"><asp:checkbox runat="server" ID="level4_select" class="inputlog" meta:resourcekey="level4_selectResource1" Visible="False"></asp:checkbox></div>
              <div id="checkboxCh"><asp:Label runat="server" ID="label_level4_select" class="labellog" Text="Level4" meta:resourcekey="label_level4_selectResource1" Visible="False"></asp:Label> </div>
              
              </div>
                </asp:placeholder>
            </div>
                
        <!-- fine riga -->
        <div class="row-fluid">
            <!-- riga -->
            <asp:placeholder runat="server" ID="Placeholder2">
        
          <div class="span6">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal7"  text="Temperature" runat="server" meta:resourcekey="Literal7Resource1"></asp:literal></h5>
              <div id="checkboxCh"><asp:checkbox Checked="True" runat="server" ID="temperature_select" class="inputlog" meta:resourcekey="temperature_selectResource1"></asp:checkbox></div>
              <div id="checkboxCh"><asp:Label runat="server" ID="temperature_select_label" class="labellog" Text="Temperature" meta:resourcekey="temperature_select_labelResource1"></asp:Label> </div>
            <asp:placeholder runat="server" ID="temperature2">
                
                  <div id="checkboxCh"><asp:checkbox Checked="True" runat="server" ID="temperature_select2" class="inputlog" meta:resourcekey="temperature_selectResource1"></asp:checkbox></div>
                   <div id="checkboxCh"><asp:Label runat="server" ID="temperature_select_label2" class="labellog" Text="Temperature" meta:resourcekey="temperature_select_labelResource1"></asp:Label> </div>
              </asp:placeholder>
              </div>
                </asp:placeholder>
          <div class="span6">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal8"  text="FlowMeter" runat="server" meta:resourcekey="Literal8Resource1"></asp:literal></h5>
              <div id="checkboxCh"><asp:checkbox  runat="server" ID="flow_meter" class="inputlog" meta:resourcekey="flow_meterResource1"></asp:checkbox></div>
              <div id="checkboxCh"><asp:Label runat="server" ID="flow_meter_label" class="labellog" Text="Flow m3/h" meta:resourcekey="flow_meter_labelResource1"></asp:Label> </div>

<asp:placeholder runat="server" ID="flow_meter_low_enable">
              <div id="checkboxCh"><asp:checkbox  runat="server" ID="flow_meter_low" class="inputlog" meta:resourcekey="flow_meter_lowResource1"></asp:checkbox></div>
              <div id="checkboxCh"><asp:Label runat="server" ID="Label2" class="labellog" Text="Flow Meter Low" meta:resourcekey="Label2Resource1"></asp:Label> </div>
</asp:placeholder>            
              
              </div>

            </div>
           <!-- riga -->
<div class="row-fluid">
        <div class="span6">
            <h5 style="padding-top:10px"><asp:literal ID = "Literal11"  text="Log Range" runat="server" meta:resourcekey="Literal11Resource1"></asp:literal></h5>
         <div id="checkboxCh"><h5 style="padding-top:10px"><asp:literal ID = "Literal10"  text="From" runat="server" meta:resourcekey="Literal10Resource1"></asp:literal></h5></div>
         <div id="checkboxCh"><asp:textbox ID="graph_log_from"   class="span12"  runat="server" meta:resourcekey="graph_log_fromResource1"  ></asp:textbox></div>
         <div id="checkboxCh"><h5 style="padding-top:10px"><asp:literal ID = "Literal9"  text="To" runat="server" meta:resourcekey="Literal9Resource1"></asp:literal></h5></div>
         <div id="checkboxCh"><asp:textbox ID="graph_log_to"   class="span12"  runat="server" meta:resourcekey="graph_log_toResource1"  ></asp:textbox></div>

              </div>
    </div> 
        
        <!-- fine riga -->

	</div>
       <div id="salva"  class="btn-primary">
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
    <script src="theme/scripts/demo/notifications.js"></script>

      <script src="theme/scripts/demo/calendar_new.js"></script>
    <link href="bootstrap/css/jquery-ui-timepicker-addon.css" rel="stylesheet" />

   

    <script type="text/javascript" src="chart/chart_manage_max5.js"></script>
     
     
   </div> 	
      
      
</form>
    <!--
        GOOGLE CHART
    <script type='text/javascript' src='http://www.google.com/jsapi'></script>
    <script type='text/javascript'>
        google.load('visualization', '1', { 'packages': ['annotatedtimeline'] });
        google.setOnLoadCallback(drawChart);
        function drawChart() {
            var data = new google.visualization.DataTable();
            data.addColumn('date', 'Date');
            data.addColumn('number', 'Sold Pencils');
            data.addRows([
              [new Date(2009, 1, 1), 30000],
              [new Date(2009, 1, 2), 14045],
              [new Date(2009, 1, 3), 55022],
              [new Date(2009, 1, 4), 75284],
              [new Date(2009, 1, 5), 41476],
              [new Date(2009, 1, 6), 33322],
                  [new Date(2009, 2, 6), 15],
              [new Date(2009, 2, 7), 15],
              [new Date(2009, 2, 8), 15],
                  [new Date(2009, 2, 9), 15],
                      [new Date(2009, 2, 10), 15],
            ]);



            var chart = new google.visualization.AnnotatedTimeLine(document.getElementById('chart_div'));
            chart.draw(data, {
                //'allValuesSuffix': '%', // A suffix that is added to all values
                'colors': ['blue', 'red', '#0000bb'], // The colors to be used
                'displayAnnotations': true,
                'displayExactValues': true, // Do not truncate values (i.e. using K suffix)
                'displayRangeSelector': true, // Do not sow the range selector
                'displayZoomButtons': false, // DO not display the zoom buttons
                'displayLegendValues': true,
                'fill': 30, // Fill the area below the lines with 20% opacity
                'legendPosition': 'newRow', // Can be sameRow
                //'max': 100000, // Override the automatic default
                //'min':  100000, // Override the automatic default
                'scaleColumns': [0, 1], // Have two scales, by the first and second lines
                'scaleType': 'allmaximized', // See docs...
                'thickness': 2, // Make the lines thicker
                'zoomStartTime': new Date(2009, 1, 2), //NOTE: month 1 = Feb (javascript to blame)
                'zoomEndTime': new Date(2009, 2, 5) //NOTE: month 1 = Feb (javascript to blame)
            });
            google.visualization.events.addListener(chart, 'rangechange', cambia_range);


            var data1 = new google.visualization.DataTable();
            data1.addColumn('date', 'Date');
            data1.addColumn('number', 'Sold Pencils');
            data1.addRows([
              [new Date(2009, 1, 1), 0],
              [new Date(2009, 1, 2), 0],
              [new Date(2009, 1, 3), 0],
              [new Date(2009, 1, 4), 0],
              [new Date(2009, 1, 4), 1],
              [new Date(2009, 1, 5), 1],
              [new Date(2009, 1, 6), 1],
                  [new Date(2009, 2, 6), 1],
                  [new Date(2009, 2, 7), 1],
              [new Date(2009, 2, 7), 0],
              [new Date(2009, 2, 8), 0],
                  [new Date(2009, 2, 9), 0],
                      [new Date(2009, 2, 10), 0],

            ]);

            var chart1 = new google.visualization.AnnotatedTimeLine(document.getElementById('chart_flow'));
            chart1.draw(data1, {
                //'allValuesSuffix': '%', // A suffix that is added to all values
                'colors': ['blue', 'red', '#0000bb'], // The colors to be used
                'displayAnnotations': true,
                'displayExactValues': true, // Do not truncate values (i.e. using K suffix)
                'displayRangeSelector': false, // Do not sow the range selector
                'displayZoomButtons': false, // DO not display the zoom buttons
                'displayLegendValues': true,
                'fill': 30, // Fill the area below the lines with 20% opacity
                'legendPosition': 'newRow', // Can be sameRow
                //'max': 100000, // Override the automatic default
                //'min':  100000, // Override the automatic default
                'scaleColumns': [0,1], // Have two scales, by the first and second lines
                'scaleType': 'fixed', // See docs...
                'thickness': 2, // Make the lines thicker
                'zoomStartTime': new Date(2009, 1, 2), //NOTE: month 1 = Feb (javascript to blame)
                'zoomEndTime': new Date(2009, 2, 5) //NOTE: month 1 = Feb (javascript to blame)
            });

            function cambia_range() {
                var range = chart.getVisibleChartRange();
                chart1.setVisibleChartRange(range['start'], range['end']);
                
            }

        }

        
    </script>
        -->


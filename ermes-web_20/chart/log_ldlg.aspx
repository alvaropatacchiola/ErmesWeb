<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="log_ldlg.aspx.vb" Inherits="ermes_web_20.log_ldlg" %>

<form id="form_log" runat="server" >
  <div class="innerLR">

      

  <div class="widget" >
	<div id="head_log" class="widget-head"><h4 class="heading glyphicons show_thumbnails_with_lines"><asp:literal text="Log Settings" runat="server"  ID="log_setting_id" ></asp:literal></h4>
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
            

          <div class="span7">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal1"  text="Input" runat="server" ></asp:literal></h5>
<asp:placeholder runat="server" ID="ch1_pump_enable" Visible="False">
                    <div id="checkboxCh"><asp:checkbox Checked="True" runat="server" ID="pump1_val" class="inputlog"  ></asp:checkbox></div>
                    <div id="checkboxCh"><asp:Label runat="server" ID="pump1_val_label" class="labellog" Text="Level1"  ></asp:Label> </div> 
</asp:placeholder>
<asp:placeholder runat="server" ID="ch2_pump_enable" Visible="False">
                    <div id="checkboxCh"><asp:checkbox Checked="True" runat="server" ID="pump2_val" class="inputlog" ></asp:checkbox></div>
                    <div id="checkboxCh"><asp:Label runat="server" ID="pump2_val_label" class="labellog" Text="Level2"  ></asp:Label> </div> 
</asp:placeholder>
<asp:placeholder runat="server" ID="ch3_pump_enable" Visible="False">
                    <div id="checkboxCh"><asp:checkbox Checked="True" runat="server" ID="pump3_val" class="inputlog"  ></asp:checkbox></div>
                    <div id="checkboxCh"><asp:Label runat="server" ID="pump3_val_label" class="labellog" Text="Level3"  ></asp:Label> </div> 
</asp:placeholder>
<asp:placeholder runat="server" ID="ch4_pump_enable" Visible="False">
                    <div id="checkboxCh"><asp:checkbox Checked="True" runat="server" ID="pump4_val" class="inputlog"  ></asp:checkbox></div>
                    <div id="checkboxCh"><asp:Label runat="server" ID="pump4_val_label" class="labellog" Text="Level4"  ></asp:Label> </div> 
</asp:placeholder>
<asp:placeholder runat="server" ID="ch5_pump_enable" Visible="False">
                    <div id="checkboxCh"><asp:checkbox Checked="True" runat="server" ID="pump5_val" class="inputlog"  ></asp:checkbox></div>
                    <div id="checkboxCh"><asp:Label runat="server" ID="pump5_val_label" class="labellog" Text="Level5"  ></asp:Label> </div> 
</asp:placeholder>
              </div> 

        <!-- fine riga -->
        <!-- riga -->

        <div class="row-fluid">
            

          <div class="span7">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal3"  text="Input" runat="server" ></asp:literal></h5>
<asp:placeholder runat="server" ID="ch1_wm_enable" Visible="False">
                    <div id="checkboxCh"><asp:checkbox Checked="True" runat="server" ID="wm1_val" class="inputlog"  ></asp:checkbox></div>
                    <div id="checkboxCh"><asp:Label runat="server" ID="wm1_val_label" class="labellog" Text="Level1"  ></asp:Label> </div> 
</asp:placeholder>
<asp:placeholder runat="server" ID="ch2_wm_enable" Visible="False">
                    <div id="checkboxCh"><asp:checkbox Checked="True" runat="server" ID="wm2_val" class="inputlog" ></asp:checkbox></div>
                    <div id="checkboxCh"><asp:Label runat="server" ID="wm2_val_label" class="labellog" Text="Level2"  ></asp:Label> </div> 
</asp:placeholder>
<asp:placeholder runat="server" ID="ch3_wm_enable" Visible="False">
                    <div id="checkboxCh"><asp:checkbox Checked="True" runat="server" ID="wm3_val" class="inputlog"  ></asp:checkbox></div>
                    <div id="checkboxCh"><asp:Label runat="server" ID="wm3_val_label" class="labellog" Text="Level3"  ></asp:Label> </div> 
</asp:placeholder>
<asp:placeholder runat="server" ID="ch4_wm_enable" Visible="False">
                    <div id="checkboxCh"><asp:checkbox Checked="True" runat="server" ID="wm4_val" class="inputlog"  ></asp:checkbox></div>
                    <div id="checkboxCh"><asp:Label runat="server" ID="wm4_val_label" class="labellog" Text="Level4"  ></asp:Label> </div> 
</asp:placeholder>
<asp:placeholder runat="server" ID="ch5_wm_enable" Visible="False">
                    <div id="checkboxCh"><asp:checkbox Checked="True" runat="server" ID="wm5_val" class="inputlog"  ></asp:checkbox></div>
                    <div id="checkboxCh"><asp:Label runat="server" ID="wm5_val_label" class="labellog" Text="Level5"  ></asp:Label> </div> 
</asp:placeholder>
              </div> 

        <!-- fine riga -->
        <!-- riga -->

        <div class="row-fluid">
            

          <div class="span7">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal4"  text="Input" runat="server" ></asp:literal></h5>
<asp:placeholder runat="server" ID="delta_enable" Visible="False">
                    <div id="checkboxCh"><asp:checkbox Checked="True" runat="server" ID="delta_val" class="inputlog"  ></asp:checkbox></div>
                    <div id="checkboxCh"><asp:Label runat="server" ID="delta_val_label" class="labellog" Text="Level1"  ></asp:Label> </div> 
                    <div id="checkboxCh"><asp:checkbox Checked="True" runat="server" ID="percent_val" class="inputlog"  ></asp:checkbox></div>
                    <div id="checkboxCh"><asp:Label runat="server" ID="percent_val_label" class="labellog" Text="Percent"  ></asp:Label> </div> 

</asp:placeholder>

              </div> 

        <!-- fine riga -->
            </div>
<div class="row-fluid">
        <!-- riga -->
          <div class="span6">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal2"  text="Data Log" runat="server"  ></asp:literal></h5>
               <div id="checkboxCh"><asp:radiobutton runat="server" ID="all_val" class="inputlog" GroupName="log_val" Checked="True" ></asp:radiobutton></div>
                    <div id="checkboxCh"><asp:Label runat="server" ID="all_val_label" class="labellog" Text="All"  ></asp:Label> </div> 

               <div id="checkboxCh"><asp:radiobutton runat="server" ID="day_val" class="inputlog" GroupName="log_val" ></asp:radiobutton></div>
                    <div id="checkboxCh"><asp:Label runat="server" ID="day_val_label" class="labellog" Text="Day"  ></asp:Label> </div> 
               <div id="checkboxCh"><asp:radiobutton runat="server" ID="month_val" class="inputlog" GroupName="log_val"></asp:radiobutton></div>
                    <div id="checkboxCh"><asp:Label runat="server" ID="month_val_label" class="labellog" Text="Month"  ></asp:Label> </div> 
               <div id="checkboxCh"><asp:radiobutton runat="server" ID="year_val" class="inputlog" GroupName="log_val" ></asp:radiobutton></div>
                    <div id="checkboxCh"><asp:Label runat="server" ID="year_val_label" class="labellog" Text="Year" ></asp:Label> </div> 

            </div>
</div>
        <!-- fine riga -->
             
      
         
	</div>
<div class="row-fluid">
       <div id="salva"   class="btn-primary">
                   <b class="btn-primary btn-icon glyphicons ok"><asp:button runat="server" ID="refresh_graph" class="btn-primary"  text="Refresh Graph" Font-Bold="True" /><i></i></b>

            </div>
</div>
	</div>
</div>
        </div> 
    <div id="chart_div" style="height: 700px; min-width: 500px">
        
    </div>
<div id="chart_table" >

</div>

          <asp:Button ID="refresh_log_server" runat="server" BackColor="Transparent" BorderColor="Transparent"  />
    <asp:literal runat="server" ID="literal_script" ></asp:literal>

    <script type="text/javascript" src="chart/chart_manage_ldlg.js?v=1.1"></script>
   	
      
      
</form>
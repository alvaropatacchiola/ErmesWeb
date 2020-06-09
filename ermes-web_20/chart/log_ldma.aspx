<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="log_ldma.aspx.vb" Inherits="ermes_web_20.log_ldma" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>

<form id="form_log" runat="server" >
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
            

          <div class="span7">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal1"  text="Input" runat="server" meta:resourcekey="Literal1Resource1"></asp:literal></h5>
<asp:placeholder runat="server" ID="ch1_enable" Visible="False">
                    <div id="checkboxCh"><asp:checkbox Checked="True" runat="server" ID="level1_val" class="inputlog" meta:resourcekey="level1_valResource1" ></asp:checkbox></div>
                    <div id="checkboxCh"><asp:Label runat="server" ID="level1_val_label" class="labellog" Text="Level1" meta:resourcekey="level1_val_labelResource1" ></asp:Label> </div> 
</asp:placeholder>
<asp:placeholder runat="server" ID="ch2_enable" Visible="False">
                    <div id="checkboxCh"><asp:checkbox Checked="True" runat="server" ID="level2_val" class="inputlog" meta:resourcekey="level2_valResource1" ></asp:checkbox></div>
                    <div id="checkboxCh"><asp:Label runat="server" ID="level2_val_label" class="labellog" Text="Level2" meta:resourcekey="level2_val_labelResource1" ></asp:Label> </div> 
</asp:placeholder>
<asp:placeholder runat="server" ID="ch3_enable" Visible="False">
                    <div id="checkboxCh"><asp:checkbox Checked="True" runat="server" ID="level3_val" class="inputlog" meta:resourcekey="level3_valResource1" ></asp:checkbox></div>
                    <div id="checkboxCh"><asp:Label runat="server" ID="level3_val_label" class="labellog" Text="Level3" meta:resourcekey="level3_val_labelResource1" ></asp:Label> </div> 
</asp:placeholder>
<asp:placeholder runat="server" ID="ch4_enable" Visible="False">
                    <div id="checkboxCh"><asp:checkbox Checked="True" runat="server" ID="level4_val" class="inputlog" meta:resourcekey="level4_valResource1" ></asp:checkbox></div>
                    <div id="checkboxCh"><asp:Label runat="server" ID="level4_val_label" class="labellog" Text="Level4" meta:resourcekey="level4_val_labelResource1" ></asp:Label> </div> 
</asp:placeholder>
<asp:placeholder runat="server" ID="ch5_enable" Visible="False">
                    <div id="checkboxCh"><asp:checkbox Checked="True" runat="server" ID="level5_val" class="inputlog" meta:resourcekey="level5_valResource1" ></asp:checkbox></div>
                    <div id="checkboxCh"><asp:Label runat="server" ID="level5_val_label" class="labellog" Text="Level5" meta:resourcekey="level5_val_labelResource1" ></asp:Label> </div> 
</asp:placeholder>
              </div> 

        <!-- fine riga -->
            </div>
<div class="row-fluid">
        <!-- riga -->
          <div class="span6">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal2"  text="Data Log" runat="server" meta:resourcekey="Literal2Resource1" ></asp:literal></h5>
               <div id="checkboxCh"><asp:radiobutton runat="server" ID="all_val" class="inputlog" GroupName="log_val" Checked="True" meta:resourcekey="all_valResource1"></asp:radiobutton></div>
                    <div id="checkboxCh"><asp:Label runat="server" ID="all_val_label" class="labellog" Text="All" meta:resourcekey="all_val_labelResource1" ></asp:Label> </div> 

               <div id="checkboxCh"><asp:radiobutton runat="server" ID="day_val" class="inputlog" GroupName="log_val" meta:resourcekey="day_valResource1"></asp:radiobutton></div>
                    <div id="checkboxCh"><asp:Label runat="server" ID="day_val_label" class="labellog" Text="Day" meta:resourcekey="day_val_labelResource1" ></asp:Label> </div> 
               <div id="checkboxCh"><asp:radiobutton runat="server" ID="month_val" class="inputlog" GroupName="log_val" meta:resourcekey="month_valResource1"></asp:radiobutton></div>
                    <div id="checkboxCh"><asp:Label runat="server" ID="month_val_label" class="labellog" Text="Month" meta:resourcekey="month_val_labelResource1" ></asp:Label> </div> 
               <div id="checkboxCh"><asp:radiobutton runat="server" ID="year_val" class="inputlog" GroupName="log_val" meta:resourcekey="year_valResource1" ></asp:radiobutton></div>
                    <div id="checkboxCh"><asp:Label runat="server" ID="year_val_label" class="labellog" Text="Year" meta:resourcekey="year_val_labelResource1" ></asp:Label> </div> 

            </div>
</div>
        <!-- fine riga -->
             
      
         
	</div>
<div class="row-fluid">
       <div id="salva"   class="btn-primary">
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
    <asp:literal runat="server" ID="literal_script" meta:resourcekey="literal_scriptResource1"></asp:literal>

    <script type="text/javascript" src="chart/chart_manage_ldma.js?v=1.1"></script>
   </div> 	
      
      
</form>
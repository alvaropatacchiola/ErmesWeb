<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="log_tower.aspx.vb" Inherits="ermes_web_20.log_tower" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>

<form id="form_log" runat="server"  method="post" onsubmit="return get_action();">
    <div class="innerLR">
        <div class="widget" >
            <div id="head_log" class="widget-head">
                <h4 class="heading glyphicons show_thumbnails_with_lines"><asp:literal text="Log Settings" runat="server"  ID="log_setting_id" meta:resourcekey="log_setting_idResource1"></asp:literal></h4>
                <span style=" position: relative; height: 29px; width: 30px; display: block; cursor: pointer; float: right; margin-right: -10px;">
                    
                    <img src="chart/js/images/arrow_sort_down.png">

                </span>
            </div>
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
                            <div class="span12">
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
                                <div id="checkboxCh">
                                    <asp:CheckBox ID="wmi" runat="server" class="inputlog" />
                                </div>
                                <div id="checkboxCh">
                                    <asp:Label ID="wmi_label" runat="server" class="labellog" Text="WaterMeterInput" meta:resourcekey="label_wmi_selectResource1" ></asp:Label>
                                </div>
                                <div id="checkboxCh">
                                    <asp:CheckBox ID="wmb" runat="server" class="inputlog" />
                                </div>
                                <div id="checkboxCh">
                                    <asp:Label ID="wmb_label" runat="server" class="labellog" Text="WaterMeterBleed" meta:resourcekey="label_wmb_selectResource1" ></asp:Label>
                                </div>

                            </div>
                            </div>
                        </asp:PlaceHolder>

                <asp:PlaceHolder ID="Placeholder2" runat="server">
                            <div class="span12">
                                <h5 style="padding-top:10px">
                                    <asp:Literal ID="Literal4" runat="server" text="Power On"></asp:Literal>
                                </h5>
                                <div id="checkboxCh">
                                    <asp:CheckBox ID="Power_On" runat="server" Checked="False" Text="Power On" class="inputlog"  />
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
         <div id="checkboxCh"><h5 style="padding-top:10px"><asp:literal ID = "Literal9"  text="To" runat="server" meta:resourcekey="Literal9Resource1"></asp:literal></h5></div>
         <div id="checkboxCh"><asp:textbox ID="graph_log_to"   class="span12"  runat="server" meta:resourcekey="graph_log_toResource1"  ></asp:textbox></div>

              </div>
    </div> 
        
        <!-- fine riga -->
	                </div>
                    <div id="salva" class="btn-primary">
                        <b class="btn-primary btn-icon glyphicons ok">
                        <asp:Button ID="refresh_graph" runat="server" class="btn-primary" Font-Bold="True" text="Refresh Graph" meta:resourcekey="refresh_graphResource1" />
                        </b>
                    </div>
                </div>
            </div>
            <div id="chart_div" style="height: 700px; min-width: 500px">
            </div>
<div id="chart_table" >

</div>

           <asp:Button ID="refresh_log_server" runat="server" BackColor="Transparent" BorderColor="Transparent" meta:resourcekey="refresh_log_serverResource1"  />
    <asp:literal runat="server" ID="literal_script" meta:resourcekey="literal_scriptResource1"></asp:literal>

    <script type="text/javascript" src="chart/chart_manage_tower.js"></script>
        </div>
    </div>
</form>



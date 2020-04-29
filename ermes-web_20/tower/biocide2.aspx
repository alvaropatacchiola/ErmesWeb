<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="biocide2.aspx.vb" Inherits="ermes_web_20.biocide2" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>

<form id="form" runat="server"  method="post" action="tower/biocide2.aspx">
    <h3><asp:literal runat="server" text ="Biocide2 Tower" ID="message_channel" meta:resourcekey="message_channelResource1"></asp:literal></h3>
<div class="innerLR">
    <div class="box-generic">
        <!-- Tabs Heading -->
<div class="tabsbar tabsbar-2">
			<ul class="row-fluid row-merge">
            
                <li class="span2 active" ><a id="tab_tower_sp1" href="#tab_tower_sp1_1"  data-toggle="tab"><asp:literal text="Biocide 1"  runat="server" ID="tabtower1_1" meta:resourcekey="tabtower1_1Resource1" ></asp:literal></a></li>
                <li class="span2"><a id="tab_tower_sp2" href="#tab_tower_sp2_2" data-toggle="tab"><asp:literal text="Week 1" runat="server" ID="tabtower1_2" meta:resourcekey="tabtower1_2Resource1"></asp:literal></a></li>
                <li class="span2"><a id="tab_tower_sp3" href="#tab_tower_sp3_3" data-toggle="tab"><asp:literal text="Week 2" runat="server" ID="tabtower1_3" meta:resourcekey="tabtower1_3Resource1"></asp:literal></a></li>
                <li class="span2"><a id="tab_tower_sp4" href="#tab_tower_sp4_4" data-toggle="tab"><asp:literal text="Week 3" runat="server" ID="tabtower1_4" meta:resourcekey="tabtower1_4Resource1"></asp:literal></a></li>
                <li class="span2"><a id="tab_tower_sp5" href="#tab_tower_sp5_5" data-toggle="tab"><asp:literal text="Week 4" runat="server" ID="tabtower1_5" meta:resourcekey="tabtower1_5Resource1"></asp:literal></a></li>
			</ul>
		</div>
		<!-- // Tabs Heading END -->
        <div class="tab-content">
    <!-- tab 1 start-->
			<div class="tab-pane active" id="tab_tower_sp1_1">
                <div  class="box-generic">
                                 <!-- riga -->
                <div class="row-fluid">
               	<div class="span3">
              <h5 style="padding-top:10px"><asp:literal ID = "Label7"  text="Pre Bleed" runat="server" meta:resourcekey="Label7Resource1"></asp:literal></h5>
                    <asp:radiobutton ID="pre_bleed_time" style="margin: 5px 10px 10px 0px;" runat="server"  GroupName="GROUP1" meta:resourcekey="pre_bleed_timeResource1"></asp:radiobutton>
                    <asp:literal runat="server" text ="Time" meta:resourcekey="LiteralResource1"></asp:literal>
                    <asp:radiobutton ID="pre_bleed_us" style="margin: 5px 10px 10px 0px;" runat="server"  GroupName="GROUP1" meta:resourcekey="pre_bleed_usResource1"></asp:radiobutton>
                       <asp:literal runat="server" text ="uS" meta:resourcekey="LiteralResource2"></asp:literal>

                </div>
                </div>
                 <!-- fine riga -->
                                <!-- riga -->
<div id ="enable_pre_bleed_time">
                <div class="row-fluid">
               	<div class="span2">
                       <div id="riga_pre_bleed_time_hr" class="control-group">
                                <h5 style="padding-top:10px"><asp:literal ID = "Literal6"  text="Hour" runat="server" meta:resourcekey="Literal6Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_pre_bleed_time_hr" onblur="javascript: Changed_channel( 'value_pre_bleed_time_hr','riga_pre_bleed_time_hr',99, 0,0 );" class="span12"  runat="server" MaxLength="2" meta:resourcekey="value_pre_bleed_time_hrResource1" ></asp:textbox>
                </div>
                       </div>

                    <div class="span2">
                       <div id="riga_pre_bleed_time_min" class="control-group">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal5"  text="Minute" runat="server" meta:resourcekey="Literal5Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_pre_bleed_time_min" onblur="javascript: Changed_channel( 'value_pre_bleed_time_min','riga_pre_bleed_time_min',59, 0,0 );" class="span12"  runat="server" MaxLength="2" meta:resourcekey="value_pre_bleed_time_minResource1" ></asp:textbox>
                </div>
                       </div>
                </div>
                 <!-- fine riga -->
</div>
<div id ="enable_pre_bleed_us">
<!-- riga -->
                <div class="row-fluid">
               	<div class="span2">
                       <div id="riga_pre_bleed_us" class="control-group">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal8"  text="0 uS" runat="server" meta:resourcekey="Literal8Resource1"></asp:literal></h5>


                       <asp:textbox ID="value_pre_bleed_us" onblur="javascript: Changed_channel( 'value_pre_bleed_us','riga_pre_bleed_us',max_us, 0,0 );" class="span12"  runat="server" MaxLength="4" meta:resourcekey="value_pre_bleed_usResource1" ></asp:textbox>
                </div>
                       </div>
                                      
                </div>
                 <!-- fine riga -->   
</div>                             
<!-- riga -->
                <div class="row-fluid">
               	<div class="span2">
                       <div id="riga_pre_biocide_hr" class="control-group">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal10"  text="Pre Biocide (Hr)" runat="server" meta:resourcekey="Literal10Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_pre_biocide_hr" onblur="javascript: Changed_channel( 'value_pre_biocide_hr','riga_pre_biocide_hr',99, 0,0 );"  class="span12"  runat="server" MaxLength="2" meta:resourcekey="value_pre_biocide_hrResource1" ></asp:textbox>
                </div>
                       </div>
<div class="span2">
                       <div id="riga_pre_biocide_min" class="control-group">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal3"  text="Pre Biocide (Min)" runat="server" meta:resourcekey="Literal3Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_pre_biocide_min" onblur="javascript: Changed_channel( 'value_pre_biocide_min','riga_pre_biocide_min',59, 0,0 );"  class="span12"  runat="server" MaxLength="2" meta:resourcekey="value_pre_biocide_minResource1" ></asp:textbox>
                </div>
                       </div>
                </div>
                 <!-- fine riga -->  
<!-- riga -->
                <div class="row-fluid">
               	<div class="span2">
                       <div id="riga_pre_lockout_hr" class="control-group">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal4"  text="LockOut (Hr)" runat="server" meta:resourcekey="Literal4Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_pre_lockout_hr" onblur="javascript: Changed_channel( 'value_pre_lockout_hr','riga_pre_lockout_hr',99, 0,0 );"  class="span12"  runat="server" MaxLength="2" meta:resourcekey="value_pre_lockout_hrResource1" ></asp:textbox>
                </div>
                       </div>
<div class="span2">
                       <div id="riga_pre_lockout_min" class="control-group">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal7"  text="LockOut (Min)" runat="server" meta:resourcekey="Literal7Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_pre_lockout_min" onblur="javascript: Changed_channel( 'value_pre_lockout_min','riga_pre_lockout_min',59, 0,0 );"  class="span12"  runat="server" MaxLength="2" meta:resourcekey="value_pre_lockout_minResource1" ></asp:textbox>
                </div>
    
                       </div>
                </div>
                 <!-- fine riga -->  
    
                    </div>
                </div>
<!-- tab 1 stop-->
 <!-- tab 2 start-->
			<div class="tab-pane" id="tab_tower_sp2_2">
                <h5 style="padding-top:10px"><asp:literal ID = "Literal67"  text="Week1 Inactive" runat="server" meta:resourcekey="Literal67Resource1"></asp:literal></h5>
                <asp:placeholder runat="server" ID="week1_enable">
                <div  class="box-generic">
                                 <!-- riga -->
                <div class="row-fluid">
               	<div class="span3">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal9"  text="Biocide2 Week1" runat="server" meta:resourcekey="Literal9Resource1"></asp:literal></h5>
                    <asp:checkbox ID="biocide1_week1_lunedi" runat="server" meta:resourcekey="biocide1_week1_lunediResource1"></asp:checkbox>
                    <asp:literal runat="server" text ="Monday" meta:resourcekey="LiteralResource3"></asp:literal>
                </div>
                </div>
                 <!-- fine riga -->
                                <!-- riga -->
<div id ="enable_biocide1_week1_lunedi">
                <div class="row-fluid">
               	<div class="span2">
                       <div id="riga_biocide1_week1_lunedi_hr" class="control-group">
                                <h5 style="padding-top:10px"><asp:literal ID = "Literal12"  text="Hour" runat="server" meta:resourcekey="Literal12Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_biocide1_week1_lunedi_hr" onblur="javascript: Changed_channel( 'value_biocide1_week1_lunedi_hr','riga_biocide1_week1_lunedi_hr',99, 0,0 );" class="span12"  runat="server" MaxLength="2" meta:resourcekey="value_biocide1_week1_lunedi_hrResource1" ></asp:textbox>
                </div>
                       </div>

                    <div class="span2">
                       <div id="riga_biocide1_week1_lunedi_min" class="control-group">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal13"  text="Minute" runat="server" meta:resourcekey="Literal13Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_biocide1_week1_lunedi_min" onblur="javascript: Changed_channel( 'value_biocide1_week1_lunedi_min','riga_biocide1_week1_lunedi_min',59, 0,0 );" class="span12"  runat="server" MaxLength="2" meta:resourcekey="value_biocide1_week1_lunedi_minResource1" ></asp:textbox>
                </div>
                       </div>
<div class="span2">
                       <div id="riga_biocide1_week1_lunedi_feed" class="control-group">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal14"  text="Feed" runat="server" meta:resourcekey="Literal14Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_biocide1_week1_lunedi_feed" onblur="javascript: Changed_channel_timer( 'value_biocide1_week1_lunedi_feed','riga_biocide1_week1_lunedi_feed', lunghezza_time);" onchange = "javascript: Changed_channel_timer( 'value_biocide1_week1_lunedi_feed','riga_biocide1_week1_lunedi_feed', lunghezza_time);" class="span12"  runat="server" meta:resourcekey="value_biocide1_week1_lunedi_feedResource1" ></asp:textbox>
                </div>
                       </div>					   
                </div>
</div>
                 <!-- fine riga -->

 <!-- riga -->
                <div class="row-fluid">
               	<div class="span3">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal15" runat="server" meta:resourcekey="Literal15Resource1"></asp:literal></h5>
                    <asp:checkbox ID="biocide1_week1_martedi" runat="server" meta:resourcekey="biocide1_week1_martediResource1"></asp:checkbox>
                    <asp:literal runat="server" text ="Tuesday" meta:resourcekey="LiteralResource4"></asp:literal>
                </div>
                </div>
                 <!-- fine riga -->
                                <!-- riga -->
<div id ="enable_biocide1_week1_martedi">
                <div class="row-fluid">
               	<div class="span2">
                       <div id="riga_biocide1_week1_martedi_hr" class="control-group">
                                <h5 style="padding-top:10px"><asp:literal ID = "Literal17"  text="Hour" runat="server" meta:resourcekey="Literal17Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_biocide1_week1_martedi_hr" onblur="javascript: Changed_channel( 'value_biocide1_week1_martedi_hr','riga_biocide1_week1_martedi_hr',99, 0,0 );" class="span12"  runat="server" MaxLength="2" meta:resourcekey="value_biocide1_week1_martedi_hrResource1" ></asp:textbox>
                </div>
                       </div>

                    <div class="span2">
                       <div id="riga_biocide1_week1_martedi_min" class="control-group">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal18"  text="Minute" runat="server" meta:resourcekey="Literal18Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_biocide1_week1_martedi_min" onblur="javascript: Changed_channel( 'value_biocide1_week1_martedi_min','riga_biocide1_week1_martedi_min',59, 0,0 );" class="span12"  runat="server" MaxLength="2" meta:resourcekey="value_biocide1_week1_martedi_minResource1" ></asp:textbox>
                </div>
                       </div>
<div class="span2">
                       <div id="riga_biocide1_week1_martedi_feed" class="control-group">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal19"  text="Feed" runat="server" meta:resourcekey="Literal19Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_biocide1_week1_martedi_feed" onblur="javascript: Changed_channel_timer( 'value_biocide1_week1_martedi_feed','riga_biocide1_week1_martedi_feed', lunghezza_time);" onchange = "javascript: Changed_channel_timer( 'value_biocide1_week1_martedi_feed','riga_biocide1_week1_martedi_feed', lunghezza_time);" class="span12"  runat="server" meta:resourcekey="value_biocide1_week1_martedi_feedResource1" ></asp:textbox>
                </div>
                       </div>					   
                </div>
				
</div>
				<!-- fine riga -->
 <!-- riga -->
                <div class="row-fluid">
               	<div class="span3">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal20" runat="server" meta:resourcekey="Literal20Resource1"></asp:literal></h5>
                    <asp:checkbox ID="biocide1_week1_mercoledi" runat="server" meta:resourcekey="biocide1_week1_mercolediResource1"></asp:checkbox>
                    <asp:literal runat="server" text ="Wednsday" meta:resourcekey="LiteralResource5"></asp:literal>
                </div>
                </div>
                 <!-- fine riga -->
                                <!-- riga -->
<div id ="enable_biocide1_week1_mercoledi">
                <div class="row-fluid">
               	<div class="span2">
                       <div id="riga_biocide1_week1_mercoledi_hr" class="control-group">
                                <h5 style="padding-top:10px"><asp:literal ID = "Literal22"  text="Hour" runat="server" meta:resourcekey="Literal22Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_biocide1_week1_mercoledi_hr" onblur="javascript: Changed_channel( 'value_biocide1_week1_mercoledi_hr','riga_biocide1_week1_mercoledi_hr',99, 0,0 );" class="span12"  runat="server" MaxLength="2" meta:resourcekey="value_biocide1_week1_mercoledi_hrResource1" ></asp:textbox>
                </div>
                       </div>

                    <div class="span2">
                       <div id="riga_biocide1_week1_mercoledi_min" class="control-group">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal23"  text="Minute" runat="server" meta:resourcekey="Literal23Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_biocide1_week1_mercoledi_min" onblur="javascript: Changed_channel( 'value_biocide1_week1_mercoledi_min','riga_biocide1_week1_mercoledi_min',59, 0,0 );" class="span12"  runat="server" MaxLength="2" meta:resourcekey="value_biocide1_week1_mercoledi_minResource1" ></asp:textbox>
                </div>
                       </div>
<div class="span2">
                       <div id="riga_biocide1_week1_mercoledi_feed" class="control-group">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal24"  text="Feed" runat="server" meta:resourcekey="Literal24Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_biocide1_week1_mercoledi_feed" onblur="javascript: Changed_channel_timer( 'value_biocide1_week1_mercoledi_feed','riga_biocide1_week1_mercoledi_feed', lunghezza_time);" onchange = "javascript: Changed_channel_timer( 'value_biocide1_week1_mercoledi_feed','riga_biocide1_week1_mercoledi_feed', lunghezza_time);" class="span12"  runat="server" meta:resourcekey="value_biocide1_week1_mercoledi_feedResource1" ></asp:textbox>
                </div>
                       </div>					   
                </div>
				
</div>
				<!-- fine riga -->
 <!-- riga -->
                <div class="row-fluid">
               	<div class="span3">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal25" runat="server" meta:resourcekey="Literal25Resource1"></asp:literal></h5>
                    <asp:checkbox ID="biocide1_week1_giovedi" runat="server" meta:resourcekey="biocide1_week1_giovediResource1"></asp:checkbox>
                    <asp:literal runat="server" text ="Thursday" meta:resourcekey="LiteralResource6"></asp:literal>
                </div>
                </div>
                 <!-- fine riga -->
                                <!-- riga -->
<div id ="enable_biocide1_week1_giovedi">
                <div class="row-fluid">
               	<div class="span2">
                       <div id="riga_biocide1_week1_giovedi_hr" class="control-group">
                                <h5 style="padding-top:10px"><asp:literal ID = "Literal27"  text="Hour" runat="server" meta:resourcekey="Literal27Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_biocide1_week1_giovedi_hr" onblur="javascript: Changed_channel( 'value_biocide1_week1_giovedi_hr','riga_biocide1_week1_giovedi_hr',99, 0,0 );" class="span12"  runat="server" MaxLength="2" meta:resourcekey="value_biocide1_week1_giovedi_hrResource1" ></asp:textbox>
                </div>
                       </div>

                    <div class="span2">
                       <div id="riga_biocide1_week1_giovedi_min" class="control-group">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal28"  text="Minute" runat="server" meta:resourcekey="Literal28Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_biocide1_week1_giovedi_min" onblur="javascript: Changed_channel( 'value_biocide1_week1_giovedi_min','riga_biocide1_week1_giovedi_min',59, 0,0 );" class="span12"  runat="server" MaxLength="2" meta:resourcekey="value_biocide1_week1_giovedi_minResource1" ></asp:textbox>
                </div>
                       </div>
<div class="span2">
                       <div id="riga_biocide1_week1_giovedi_feed" class="control-group">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal29"  text="Feed" runat="server" meta:resourcekey="Literal29Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_biocide1_week1_giovedi_feed" onblur="javascript: Changed_channel_timer( 'value_biocide1_week1_giovedi_feed','riga_biocide1_week1_giovedi_feed', lunghezza_time);" onchange = "javascript: Changed_channel_timer( 'value_biocide1_week1_giovedi_feed','riga_biocide1_week1_giovedi_feed', lunghezza_time);" class="span12"  runat="server" meta:resourcekey="value_biocide1_week1_giovedi_feedResource1" ></asp:textbox>
                </div>
                       </div>					   
                </div>
				
</div>
				<!-- fine riga -->
     <!-- riga -->
                <div class="row-fluid">
               	<div class="span3">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal30" runat="server" meta:resourcekey="Literal30Resource1"></asp:literal></h5>
                    <asp:checkbox ID="biocide1_week1_venerdi" runat="server" meta:resourcekey="biocide1_week1_venerdiResource1"></asp:checkbox>
                    <asp:literal runat="server" text ="Friday" meta:resourcekey="LiteralResource7"></asp:literal>
                </div>
                </div>
                 <!-- fine riga -->
                                <!-- riga -->
<div id ="enable_biocide1_week1_venerdi">
                <div class="row-fluid">
               	<div class="span2">
                       <div id="riga_biocide1_week1_venerdi_hr" class="control-group">
                                <h5 style="padding-top:10px"><asp:literal ID = "Literal32"  text="Hour" runat="server" meta:resourcekey="Literal32Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_biocide1_week1_venerdi_hr" onblur="javascript: Changed_channel( 'value_biocide1_week1_venerdi_hr','riga_biocide1_week1_venerdi_hr',99, 0,0 );" class="span12"  runat="server" MaxLength="2" meta:resourcekey="value_biocide1_week1_venerdi_hrResource1" ></asp:textbox>
                </div>
                       </div>

                    <div class="span2">
                       <div id="riga_biocide1_week1_venerdi_min" class="control-group">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal33"  text="Minute" runat="server" meta:resourcekey="Literal33Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_biocide1_week1_venerdi_min" onblur="javascript: Changed_channel( 'value_biocide1_week1_venerdi_min','riga_biocide1_week1_venerdi_min',59, 0,0 );" class="span12"  runat="server" MaxLength="2" meta:resourcekey="value_biocide1_week1_venerdi_minResource1" ></asp:textbox>
                </div>
                       </div>
<div class="span2">
                       <div id="riga_biocide1_week1_venerdi_feed" class="control-group">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal34"  text="Feed" runat="server" meta:resourcekey="Literal34Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_biocide1_week1_venerdi_feed" onblur="javascript: Changed_channel_timer( 'value_biocide1_week1_venerdi_feed','riga_biocide1_week1_venerdi_feed', lunghezza_time);" onchange = "javascript: Changed_channel_timer( 'value_biocide1_week1_venerdi_feed','riga_biocide1_week1_venerdi_feed', lunghezza_time);" class="span12"  runat="server" meta:resourcekey="value_biocide1_week1_venerdi_feedResource1" ></asp:textbox>
                </div>
                       </div>					   
                </div>
				
</div>
				<!-- fine riga -->
 <!-- riga -->
                <div class="row-fluid">
               	<div class="span3">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal35" runat="server" meta:resourcekey="Literal35Resource1"></asp:literal></h5>
                    <asp:checkbox ID="biocide1_week1_sabato" runat="server" meta:resourcekey="biocide1_week1_sabatoResource1"></asp:checkbox>
                    <asp:literal runat="server" text ="Saturday" meta:resourcekey="LiteralResource8"></asp:literal>
                </div>
                </div>
                 <!-- fine riga -->
                                <!-- riga -->
<div id ="enable_biocide1_week1_sabato">
                <div class="row-fluid">
               	<div class="span2">
                       <div id="riga_biocide1_week1_sabato_hr" class="control-group">
                                <h5 style="padding-top:10px"><asp:literal ID = "Literal37"  text="Hour" runat="server" meta:resourcekey="Literal37Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_biocide1_week1_sabato_hr" onblur="javascript: Changed_channel( 'value_biocide1_week1_sabato_hr','riga_biocide1_week1_sabato_hr',99, 0,0 );" class="span12"  runat="server" MaxLength="2" meta:resourcekey="value_biocide1_week1_sabato_hrResource1" ></asp:textbox>
                </div>
                       </div>

                    <div class="span2">
                       <div id="riga_biocide1_week1_sabato_min" class="control-group">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal38"  text="Minute" runat="server" meta:resourcekey="Literal38Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_biocide1_week1_sabato_min" onblur="javascript: Changed_channel( 'value_biocide1_week1_sabato_min','riga_biocide1_week1_sabato_min',59, 0,0 );" class="span12"  runat="server" MaxLength="2" meta:resourcekey="value_biocide1_week1_sabato_minResource1" ></asp:textbox>
                </div>
                       </div>
<div class="span2">
                       <div id="riga_biocide1_week1_sabato_feed" class="control-group">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal39"  text="Feed" runat="server" meta:resourcekey="Literal39Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_biocide1_week1_sabato_feed" onblur="javascript: Changed_channel_timer( 'value_biocide1_week1_sabato_feed','riga_biocide1_week1_sabato_feed', lunghezza_time);" onchange = "javascript: Changed_channel_timer( 'value_biocide1_week1_sabato_feed','riga_biocide1_week1_sabato_feed', lunghezza_time);" class="span12"  runat="server" meta:resourcekey="value_biocide1_week1_sabato_feedResource1" ></asp:textbox>
                </div>
                       </div>					   
                </div>
				
</div>
				<!-- fine riga -->
 <!-- riga -->
                <div class="row-fluid">
               	<div class="span3">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal40" runat="server" meta:resourcekey="Literal40Resource1"></asp:literal></h5>
                    <asp:checkbox ID="biocide1_week1_domenica" runat="server" meta:resourcekey="biocide1_week1_domenicaResource1"></asp:checkbox>
                    <asp:literal runat="server" text ="Sunday" meta:resourcekey="LiteralResource9"></asp:literal>
                </div>
                </div>
                 <!-- fine riga -->
                                <!-- riga -->
<div id ="enable_biocide1_week1_domenica">
                <div class="row-fluid">
               	<div class="span2">
                       <div id="riga_biocide1_week1_domenica_hr" class="control-group">
                                <h5 style="padding-top:10px"><asp:literal ID = "Literal42"  text="Hour" runat="server" meta:resourcekey="Literal42Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_biocide1_week1_domenica_hr" onblur="javascript: Changed_channel( 'value_biocide1_week1_domenica_hr','riga_biocide1_week1_domenica_hr',99, 0,0 );" class="span12"  runat="server" MaxLength="2" meta:resourcekey="value_biocide1_week1_domenica_hrResource1" ></asp:textbox>
                </div>
                       </div>

                    <div class="span2">
                       <div id="riga_biocide1_week1_domenica_min" class="control-group">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal43"  text="Minute" runat="server" meta:resourcekey="Literal43Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_biocide1_week1_domenica_min" onblur="javascript: Changed_channel( 'value_biocide1_week1_domenica_min','riga_biocide1_week1_domenica_min',59, 0,0 );" class="span12"  runat="server" MaxLength="2" meta:resourcekey="value_biocide1_week1_domenica_minResource1" ></asp:textbox>
                </div>
                       </div>
<div class="span2">
                       <div id="riga_biocide1_week1_domenica_feed" class="control-group">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal44"  text="Feed" runat="server" meta:resourcekey="Literal44Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_biocide1_week1_domenica_feed" onblur="javascript: Changed_channel_timer( 'value_biocide1_week1_domenica_feed','riga_biocide1_week1_domenica_feed', lunghezza_time);" onchange = "javascript: Changed_channel_timer( 'value_biocide1_week1_domenica_feed','riga_biocide1_week1_domenica_feed', lunghezza_time);" class="span12"  runat="server" meta:resourcekey="value_biocide1_week1_domenica_feedResource1" ></asp:textbox>
                </div>
                       </div>					   
                </div>
				
</div>
				<!-- fine riga -->

                    </div>
                </asp:placeholder>
                </div>
<!-- tab 2 stop-->
            <!-- tab 3 start-->
			<div class="tab-pane" id="tab_tower_sp3_3">
                <h5 style="padding-top:10px"><asp:literal ID = "Literal95"  text="Week2 Inactive" runat="server" meta:resourcekey="Literal95Resource1"></asp:literal></h5>
                <asp:placeholder runat="server" ID="week2_enable">
                <div  class="box-generic">
                                 <!-- riga -->
                <div class="row-fluid">
               	<div class="span3">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal45"  text="Biocide2 Week2" runat="server" meta:resourcekey="Literal45Resource1"></asp:literal></h5>
                    <asp:checkbox ID="biocide1_week2_lunedi" runat="server" meta:resourcekey="biocide1_week2_lunediResource1"></asp:checkbox>
                    <asp:literal runat="server" text ="Monday" meta:resourcekey="LiteralResource10"></asp:literal>
                </div>
                </div>
                 <!-- fine riga -->
                                <!-- riga -->
<div id ="enable_biocide1_week2_lunedi">
                <div class="row-fluid">
               	<div class="span2">
                       <div id="riga_biocide1_week2_lunedi_hr" class="control-group">
                                <h5 style="padding-top:10px"><asp:literal ID = "Literal47"  text="Hour" runat="server" meta:resourcekey="Literal47Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_biocide1_week2_lunedi_hr" onblur="javascript: Changed_channel( 'value_biocide1_week2_lunedi_hr','riga_biocide1_week2_lunedi_hr',99, 0,0 );" class="span12"  runat="server" MaxLength="2" meta:resourcekey="value_biocide1_week2_lunedi_hrResource1" ></asp:textbox>
                </div>
                       </div>

                    <div class="span2">
                       <div id="riga_biocide1_week2_lunedi_min" class="control-group">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal48"  text="Minute" runat="server" meta:resourcekey="Literal48Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_biocide1_week2_lunedi_min" onblur="javascript: Changed_channel( 'value_biocide1_week2_lunedi_min','riga_biocide1_week2_lunedi_min',59, 0,0 );" class="span12"  runat="server" MaxLength="2" meta:resourcekey="value_biocide1_week2_lunedi_minResource1" ></asp:textbox>
                </div>
                       </div>
<div class="span2">
                       <div id="riga_biocide1_week2_lunedi_feed" class="control-group">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal49"  text="Feed" runat="server" meta:resourcekey="Literal49Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_biocide1_week2_lunedi_feed" onblur="javascript: Changed_channel_timer( 'value_biocide1_week2_lunedi_feed','riga_biocide1_week2_lunedi_feed', lunghezza_time);" onchange = "javascript: Changed_channel_timer( 'value_biocide1_week2_lunedi_feed','riga_biocide1_week2_lunedi_feed', lunghezza_time);" class="span12"  runat="server" meta:resourcekey="value_biocide1_week2_lunedi_feedResource1" ></asp:textbox>
                </div>
                       </div>					   
                </div>
</div>
                 <!-- fine riga -->

 <!-- riga -->
                <div class="row-fluid">
               	<div class="span3">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal50" runat="server" meta:resourcekey="Literal50Resource1"></asp:literal></h5>
                    <asp:checkbox ID="biocide1_week2_martedi" runat="server" meta:resourcekey="biocide1_week2_martediResource1"></asp:checkbox>
                    <asp:literal runat="server" text ="Tuesday" meta:resourcekey="LiteralResource11"></asp:literal>
                </div>
                </div>
                 <!-- fine riga -->
                                <!-- riga -->
<div id ="enable_biocide1_week2_martedi">
                <div class="row-fluid">
               	<div class="span2">
                       <div id="riga_biocide1_week2_martedi_hr" class="control-group">
                                <h5 style="padding-top:10px"><asp:literal ID = "Literal52"  text="Hour" runat="server" meta:resourcekey="Literal52Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_biocide1_week2_martedi_hr" onblur="javascript: Changed_channel( 'value_biocide1_week2_martedi_hr','riga_biocide1_week2_martedi_hr',99, 0,0 );" class="span12"  runat="server" MaxLength="2" meta:resourcekey="value_biocide1_week2_martedi_hrResource1" ></asp:textbox>
                </div>
                       </div>

                    <div class="span2">
                       <div id="riga_biocide1_week2_martedi_min" class="control-group">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal53"  text="Minute" runat="server" meta:resourcekey="Literal53Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_biocide1_week2_martedi_min" onblur="javascript: Changed_channel( 'value_biocide1_week2_martedi_min','riga_biocide1_week2_martedi_min',59, 0,0 );" class="span12"  runat="server" MaxLength="2" meta:resourcekey="value_biocide1_week2_martedi_minResource1" ></asp:textbox>
                </div>
                       </div>
<div class="span2">
                       <div id="riga_biocide1_week2_martedi_feed" class="control-group">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal54"  text="Feed" runat="server" meta:resourcekey="Literal54Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_biocide1_week2_martedi_feed" onblur="javascript: Changed_channel_timer( 'value_biocide1_week2_martedi_feed','riga_biocide1_week2_martedi_feed', lunghezza_time);" onchange = "javascript: Changed_channel_timer( 'value_biocide1_week2_martedi_feed','riga_biocide1_week2_martedi_feed', lunghezza_time);" class="span12"  runat="server" meta:resourcekey="value_biocide1_week2_martedi_feedResource1" ></asp:textbox>
                </div>
                       </div>					   
                </div>
				
</div>
				<!-- fine riga -->
 <!-- riga -->
                <div class="row-fluid">
               	<div class="span3">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal55" runat="server" meta:resourcekey="Literal55Resource1"></asp:literal></h5>
                    <asp:checkbox ID="biocide1_week2_mercoledi" runat="server" meta:resourcekey="biocide1_week2_mercolediResource1"></asp:checkbox>
                    <asp:literal runat="server" text ="Wednsday" meta:resourcekey="LiteralResource12"></asp:literal>
                </div>
                </div>
                 <!-- fine riga -->
                                <!-- riga -->
<div id ="enable_biocide1_week2_mercoledi">
                <div class="row-fluid">
               	<div class="span2">
                       <div id="riga_biocide1_week2_mercoledi_hr" class="control-group">
                                <h5 style="padding-top:10px"><asp:literal ID = "Literal57"  text="Hour" runat="server" meta:resourcekey="Literal57Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_biocide1_week2_mercoledi_hr" onblur="javascript: Changed_channel( 'value_biocide1_week2_mercoledi_hr','riga_biocide1_week2_mercoledi_hr',99, 0,0 );" class="span12"  runat="server" MaxLength="2" meta:resourcekey="value_biocide1_week2_mercoledi_hrResource1" ></asp:textbox>
                </div>
                       </div>

                    <div class="span2">
                       <div id="riga_biocide1_week2_mercoledi_min" class="control-group">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal58"  text="Minute" runat="server" meta:resourcekey="Literal58Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_biocide1_week2_mercoledi_min" onblur="javascript: Changed_channel( 'value_biocide1_week2_mercoledi_min','riga_biocide1_week2_mercoledi_min',59, 0,0 );" class="span12"  runat="server" MaxLength="2" meta:resourcekey="value_biocide1_week2_mercoledi_minResource1" ></asp:textbox>
                </div>
                       </div>
<div class="span2">
                       <div id="riga_biocide1_week2_mercoledi_feed" class="control-group">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal59"  text="Feed" runat="server" meta:resourcekey="Literal59Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_biocide1_week2_mercoledi_feed" onblur="javascript: Changed_channel_timer( 'value_biocide1_week2_mercoledi_feed','riga_biocide1_week2_mercoledi_feed', lunghezza_time);" onchange = "javascript: Changed_channel_timer( 'value_biocide1_week2_mercoledi_feed','riga_biocide1_week2_mercoledi_feed', lunghezza_time);" class="span12"  runat="server" meta:resourcekey="value_biocide1_week2_mercoledi_feedResource1" ></asp:textbox>
                </div>
                       </div>					   
                </div>
				
</div>
				<!-- fine riga -->
 <!-- riga -->
                <div class="row-fluid">
               	<div class="span3">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal60" runat="server" meta:resourcekey="Literal60Resource1"></asp:literal></h5>
                    <asp:checkbox ID="biocide1_week2_giovedi" runat="server" meta:resourcekey="biocide1_week2_giovediResource1"></asp:checkbox>
                    <asp:literal runat="server" text ="Thursday" meta:resourcekey="LiteralResource13"></asp:literal>
                </div>
                </div>
                 <!-- fine riga -->
                                <!-- riga -->
<div id ="enable_biocide1_week2_giovedi">
                <div class="row-fluid">
               	<div class="span2">
                       <div id="riga_biocide1_week2_giovedi_hr" class="control-group">
                                <h5 style="padding-top:10px"><asp:literal ID = "Literal62"  text="Hour" runat="server" meta:resourcekey="Literal62Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_biocide1_week2_giovedi_hr" onblur="javascript: Changed_channel( 'value_biocide1_week2_giovedi_hr','riga_biocide1_week2_giovedi_hr',99, 0,0 );" class="span12"  runat="server" MaxLength="2" meta:resourcekey="value_biocide1_week2_giovedi_hrResource1" ></asp:textbox>
                </div>
                       </div>

                    <div class="span2">
                       <div id="riga_biocide1_week2_giovedi_min" class="control-group">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal63"  text="Minute" runat="server" meta:resourcekey="Literal63Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_biocide1_week2_giovedi_min" onblur="javascript: Changed_channel( 'value_biocide1_week2_giovedi_min','riga_biocide1_week2_giovedi_min',59, 0,0 );" class="span12"  runat="server" MaxLength="2" meta:resourcekey="value_biocide1_week2_giovedi_minResource1" ></asp:textbox>
                </div>
                       </div>
<div class="span2">
                       <div id="riga_biocide1_week2_giovedi_feed" class="control-group">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal64"  text="Feed" runat="server" meta:resourcekey="Literal64Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_biocide1_week2_giovedi_feed" onblur="javascript: Changed_channel_timer( 'value_biocide1_week2_giovedi_feed','riga_biocide1_week2_giovedi_feed', lunghezza_time);" onchange = "javascript: Changed_channel_timer( 'value_biocide1_week2_giovedi_feed','riga_biocide1_week2_giovedi_feed', lunghezza_time);" class="span12"  runat="server" meta:resourcekey="value_biocide1_week2_giovedi_feedResource1" ></asp:textbox>
                </div>
                       </div>					   
                </div>
				
</div>
				<!-- fine riga -->
     <!-- riga -->
                <div class="row-fluid">
               	<div class="span3">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal65" runat="server" meta:resourcekey="Literal65Resource1"></asp:literal></h5>
                    <asp:checkbox ID="biocide1_week2_venerdi" runat="server" meta:resourcekey="biocide1_week2_venerdiResource1"></asp:checkbox>
                    <asp:literal runat="server" text ="Friday" meta:resourcekey="LiteralResource14"></asp:literal>
                </div>
                </div>
                 <!-- fine riga -->
                                <!-- riga -->
<div id ="enable_biocide1_week2_venerdi">
                <div class="row-fluid">
               	<div class="span2">
                       <div id="riga_biocide1_week2_venerdi_hr" class="control-group">
                                <h5 style="padding-top:10px"><asp:literal ID = "Literal68"  text="Hour" runat="server" meta:resourcekey="Literal68Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_biocide1_week2_venerdi_hr" onblur="javascript: Changed_channel( 'value_biocide1_week2_venerdi_hr','riga_biocide1_week2_venerdi_hr',99, 0,0 );" class="span12"  runat="server" MaxLength="2" meta:resourcekey="value_biocide1_week2_venerdi_hrResource1" ></asp:textbox>
                </div>
                       </div>

                    <div class="span2">
                       <div id="riga_biocide1_week2_venerdi_min" class="control-group">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal69"  text="Minute" runat="server" meta:resourcekey="Literal69Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_biocide1_week2_venerdi_min" onblur="javascript: Changed_channel( 'value_biocide1_week2_venerdi_min','riga_biocide1_week2_venerdi_min',59, 0,0 );" class="span12"  runat="server" MaxLength="2" meta:resourcekey="value_biocide1_week2_venerdi_minResource1" ></asp:textbox>
                </div>
                       </div>
<div class="span2">
                       <div id="riga_biocide1_week2_venerdi_feed" class="control-group">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal70"  text="Feed" runat="server" meta:resourcekey="Literal70Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_biocide1_week2_venerdi_feed" onblur="javascript: Changed_channel_timer( 'value_biocide1_week2_venerdi_feed','riga_biocide1_week2_venerdi_feed', lunghezza_time);" onchange = "javascript: Changed_channel_timer( 'value_biocide1_week2_venerdi_feed','riga_biocide1_week2_venerdi_feed', lunghezza_time);" class="span12"  runat="server" meta:resourcekey="value_biocide1_week2_venerdi_feedResource1" ></asp:textbox>
                </div>
                       </div>					   
                </div>
				
</div>
				<!-- fine riga -->
 <!-- riga -->
                <div class="row-fluid">
               	<div class="span3">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal71" runat="server" meta:resourcekey="Literal71Resource1"></asp:literal></h5>
                    <asp:checkbox ID="biocide1_week2_sabato" runat="server" meta:resourcekey="biocide1_week2_sabatoResource1"></asp:checkbox>
                    <asp:literal runat="server" text ="Saturday" meta:resourcekey="LiteralResource15"></asp:literal>
                </div>
                </div>
                 <!-- fine riga -->
                                <!-- riga -->
<div id ="enable_biocide1_week2_sabato">
                <div class="row-fluid">
               	<div class="span2">
                       <div id="riga_biocide1_week2_sabato_hr" class="control-group">
                                <h5 style="padding-top:10px"><asp:literal ID = "Literal73"  text="Hour" runat="server" meta:resourcekey="Literal73Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_biocide1_week2_sabato_hr" onblur="javascript: Changed_channel( 'value_biocide1_week2_sabato_hr','riga_biocide1_week2_sabato_hr',99, 0,0 );" class="span12"  runat="server" MaxLength="2" meta:resourcekey="value_biocide1_week2_sabato_hrResource1" ></asp:textbox>
                </div>
                       </div>

                    <div class="span2">
                       <div id="riga_biocide1_week2_sabato_min" class="control-group">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal74"  text="Minute" runat="server" meta:resourcekey="Literal74Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_biocide1_week2_sabato_min" onblur="javascript: Changed_channel( 'value_biocide1_week2_sabato_min','riga_biocide1_week2_sabato_min',59, 0,0 );" class="span12"  runat="server" MaxLength="2" meta:resourcekey="value_biocide1_week2_sabato_minResource1" ></asp:textbox>
                </div>
                       </div>
<div class="span2">
                       <div id="riga_biocide1_week2_sabato_feed" class="control-group">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal75"  text="Feed" runat="server" meta:resourcekey="Literal75Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_biocide1_week2_sabato_feed" onblur="javascript: Changed_channel_timer( 'value_biocide1_week2_sabato_feed','riga_biocide1_week2_sabato_feed', lunghezza_time);" onchange = "javascript: Changed_channel_timer( 'value_biocide1_week2_sabato_feed','riga_biocide1_week2_sabato_feed', lunghezza_time);" class="span12"  runat="server" meta:resourcekey="value_biocide1_week2_sabato_feedResource1" ></asp:textbox>
                </div>
                       </div>					   
                </div>
				
</div>
				<!-- fine riga -->
 <!-- riga -->
                <div class="row-fluid">
               	<div class="span3">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal76" runat="server" meta:resourcekey="Literal76Resource1"></asp:literal></h5>
                    <asp:checkbox ID="biocide1_week2_domenica" runat="server" meta:resourcekey="biocide1_week2_domenicaResource1"></asp:checkbox>
                    <asp:literal runat="server" text ="Sunday" meta:resourcekey="LiteralResource16"></asp:literal>
                </div>
                </div>
                 <!-- fine riga -->
                                <!-- riga -->
<div id ="enable_biocide1_week2_domenica">
                <div class="row-fluid">
               	<div class="span2">
                       <div id="riga_biocide1_week2_domenica_hr" class="control-group">
                                <h5 style="padding-top:10px"><asp:literal ID = "Literal78"  text="Hour" runat="server" meta:resourcekey="Literal78Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_biocide1_week2_domenica_hr" onblur="javascript: Changed_channel( 'value_biocide1_week2_domenica_hr','riga_biocide1_week2_domenica_hr',99, 0,0 );" class="span12"  runat="server" MaxLength="2" meta:resourcekey="value_biocide1_week2_domenica_hrResource1" ></asp:textbox>
                </div>
                       </div>

                    <div class="span2">
                       <div id="riga_biocide1_week2_domenica_min" class="control-group">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal79"  text="Minute" runat="server" meta:resourcekey="Literal79Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_biocide1_week2_domenica_min" onblur="javascript: Changed_channel( 'value_biocide1_week2_domenica_min','riga_biocide1_week2_domenica_min',59, 0,0 );" class="span12"  runat="server" MaxLength="2" meta:resourcekey="value_biocide1_week2_domenica_minResource1" ></asp:textbox>
                </div>
                       </div>
<div class="span2">
                       <div id="riga_biocide1_week2_domenica_feed" class="control-group">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal80"  text="Feed" runat="server" meta:resourcekey="Literal80Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_biocide1_week2_domenica_feed" onblur="javascript: Changed_channel_timer( 'value_biocide1_week2_domenica_feed','riga_biocide1_week2_domenica_feed', lunghezza_time);" onchange = "javascript: Changed_channel_timer( 'value_biocide1_week2_domenica_feed','riga_biocide1_week2_domenica_feed', lunghezza_time);" class="span12"  runat="server" meta:resourcekey="value_biocide1_week2_domenica_feedResource1" ></asp:textbox>
                </div>
                       </div>					   
                </div>
				
</div>
				<!-- fine riga -->

                    </div>
                    </asp:placeholder>
                </div>
<!-- tab 3 stop-->
            <!-- tab 4 start-->
			<div class="tab-pane" id="tab_tower_sp4_4">
                <h5 style="padding-top:10px"><asp:literal ID = "Literal103"  text="Week3 Inactive" runat="server" meta:resourcekey="Literal103Resource1"></asp:literal></h5>
                <asp:placeholder runat="server" ID="week3_enable">
                <div  class="box-generic">
                                 <!-- riga -->
                <div class="row-fluid">
               	<div class="span3">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal81"  text="Biocide2 week3" runat="server" meta:resourcekey="Literal81Resource1"></asp:literal></h5>
                    <asp:checkbox ID="biocide1_week3_lunedi" runat="server" meta:resourcekey="biocide1_week3_lunediResource1"></asp:checkbox>
                    <asp:literal runat="server" text ="Monday" meta:resourcekey="LiteralResource17"></asp:literal>
                </div>
                </div>
                 <!-- fine riga -->
                                <!-- riga -->
<div id ="enable_biocide1_week3_lunedi">
                <div class="row-fluid">
               	<div class="span2">
                       <div id="riga_biocide1_week3_lunedi_hr" class="control-group">
                                <h5 style="padding-top:10px"><asp:literal ID = "Literal83"  text="Hour" runat="server" meta:resourcekey="Literal83Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_biocide1_week3_lunedi_hr" onblur="javascript: Changed_channel( 'value1_ph_pulse1_1','riga1_ph_pulse1_1',max_ch1_value, min_ch1_value,max_fix_value1 );" class="span12"  runat="server" MaxLength="2" meta:resourcekey="value_biocide1_week3_lunedi_hrResource1" ></asp:textbox>
                </div>
                       </div>

                    <div class="span2">
                       <div id="riga_biocide1_week3_lunedi_min" class="control-group">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal84"  text="Minute" runat="server" meta:resourcekey="Literal84Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_biocide1_week3_lunedi_min" onblur="javascript: Changed_channel( 'value2_ph_pulse1_1','riga2_ph_pulse1_1',180, 0,0 );" class="span12"  runat="server" MaxLength="2" meta:resourcekey="value_biocide1_week3_lunedi_minResource1" ></asp:textbox>
                </div>
                       </div>
<div class="span2">
                       <div id="riga_biocide1_week3_lunedi_feed" class="control-group">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal85"  text="Feed" runat="server" meta:resourcekey="Literal85Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_biocide1_week3_lunedi_feed" onblur="javascript: Changed_channel( 'value2_ph_pulse1_1','riga2_ph_pulse1_1',180, 0,0 );" class="span12"  runat="server" meta:resourcekey="value_biocide1_week3_lunedi_feedResource1" ></asp:textbox>
                </div>
                       </div>					   
                </div>
</div>
                 <!-- fine riga -->

 <!-- riga -->
                <div class="row-fluid">
               	<div class="span3">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal86" runat="server" meta:resourcekey="Literal86Resource1"></asp:literal></h5>
                    <asp:checkbox ID="biocide1_week3_martedi" runat="server" meta:resourcekey="biocide1_week3_martediResource1"></asp:checkbox>
                    <asp:literal runat="server" text ="Tuesday" meta:resourcekey="LiteralResource18"></asp:literal>
                </div>
                </div>
                 <!-- fine riga -->
                                <!-- riga -->
<div id ="enable_biocide1_week3_martedi">
                <div class="row-fluid">
               	<div class="span2">
                       <div id="riga_biocide1_week3_martedi_hr" class="control-group">
                                <h5 style="padding-top:10px"><asp:literal ID = "Literal88"  text="Hour" runat="server" meta:resourcekey="Literal88Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_biocide1_week3_martedi_hr" onblur="javascript: Changed_channel( 'value1_ph_pulse1_1','riga1_ph_pulse1_1',max_ch1_value, min_ch1_value,max_fix_value1 );" class="span12"  runat="server" MaxLength="2" meta:resourcekey="value_biocide1_week3_martedi_hrResource1" ></asp:textbox>
                </div>
                       </div>

                    <div class="span2">
                       <div id="riga_biocide1_week3_martedi_min" class="control-group">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal89"  text="Minute" runat="server" meta:resourcekey="Literal89Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_biocide1_week3_martedi_min" onblur="javascript: Changed_channel( 'value2_ph_pulse1_1','riga2_ph_pulse1_1',180, 0,0 );" class="span12"  runat="server" MaxLength="2" meta:resourcekey="value_biocide1_week3_martedi_minResource1" ></asp:textbox>
                </div>
                       </div>
<div class="span2">
                       <div id="riga_biocide1_week3_martedi_feed" class="control-group">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal90"  text="Feed" runat="server" meta:resourcekey="Literal90Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_biocide1_week3_martedi_feed" onblur="javascript: Changed_channel( 'value2_ph_pulse1_1','riga2_ph_pulse1_1',180, 0,0 );" class="span12"  runat="server" meta:resourcekey="value_biocide1_week3_martedi_feedResource1" ></asp:textbox>
                </div>
                       </div>					   
                </div>
				
</div>
				<!-- fine riga -->
 <!-- riga -->
                <div class="row-fluid">
               	<div class="span3">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal91" runat="server" meta:resourcekey="Literal91Resource1"></asp:literal></h5>
                    <asp:checkbox ID="biocide1_week3_mercoledi" runat="server" meta:resourcekey="biocide1_week3_mercolediResource1"></asp:checkbox>
                    <asp:literal runat="server" text ="Wednsday" meta:resourcekey="LiteralResource19"></asp:literal>
                </div>
                </div>
                 <!-- fine riga -->
                                <!-- riga -->
<div id ="enable_biocide1_week3_mercoledi">
                <div class="row-fluid">
               	<div class="span2">
                       <div id="riga_biocide1_week3_mercoledi_hr" class="control-group">
                                <h5 style="padding-top:10px"><asp:literal ID = "Literal93"  text="Hour" runat="server" meta:resourcekey="Literal93Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_biocide1_week3_mercoledi_hr" onblur="javascript: Changed_channel( 'value1_ph_pulse1_1','riga1_ph_pulse1_1',max_ch1_value, min_ch1_value,max_fix_value1 );" class="span12"  runat="server" MaxLength="2" meta:resourcekey="value_biocide1_week3_mercoledi_hrResource1" ></asp:textbox>
                </div>
                       </div>

                    <div class="span2">
                       <div id="riga_biocide1_week3_mercoledi_min" class="control-group">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal94"  text="Minute" runat="server" meta:resourcekey="Literal94Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_biocide1_week3_mercoledi_min" onblur="javascript: Changed_channel( 'value2_ph_pulse1_1','riga2_ph_pulse1_1',180, 0,0 );" class="span12"  runat="server" MaxLength="2" meta:resourcekey="value_biocide1_week3_mercoledi_minResource1" ></asp:textbox>
                </div>
                       </div>
<div class="span2">
                       <div id="riga_biocide1_week3_mercoledi_feed" class="control-group">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal96"  text="Feed" runat="server" meta:resourcekey="Literal96Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_biocide1_week3_mercoledi_feed" onblur="javascript: Changed_channel( 'value2_ph_pulse1_1','riga2_ph_pulse1_1',180, 0,0 );" class="span12"  runat="server" meta:resourcekey="value_biocide1_week3_mercoledi_feedResource1" ></asp:textbox>
                </div>
                       </div>					   
                </div>
				
</div>
				<!-- fine riga -->
 <!-- riga -->
                <div class="row-fluid">
               	<div class="span3">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal97" runat="server" meta:resourcekey="Literal97Resource1"></asp:literal></h5>
                    <asp:checkbox ID="biocide1_week3_giovedi" runat="server" meta:resourcekey="biocide1_week3_giovediResource1"></asp:checkbox>
                    <asp:literal runat="server" text ="Thursday" meta:resourcekey="LiteralResource20"></asp:literal>
                </div>
                </div>
                 <!-- fine riga -->
                                <!-- riga -->
<div id ="enable_biocide1_week3_giovedi">
                <div class="row-fluid">
               	<div class="span2">
                       <div id="riga_biocide1_week3_giovedi_hr" class="control-group">
                                <h5 style="padding-top:10px"><asp:literal ID = "Literal99"  text="Hour" runat="server" meta:resourcekey="Literal99Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_biocide1_week3_giovedi_hr" onblur="javascript: Changed_channel( 'value1_ph_pulse1_1','riga1_ph_pulse1_1',max_ch1_value, min_ch1_value,max_fix_value1 );" class="span12"  runat="server" MaxLength="2" meta:resourcekey="value_biocide1_week3_giovedi_hrResource1" ></asp:textbox>
                </div>
                       </div>

                    <div class="span2">
                       <div id="riga_biocide1_week3_giovedi_min" class="control-group">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal100"  text="Minute" runat="server" meta:resourcekey="Literal100Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_biocide1_week3_giovedi_min" onblur="javascript: Changed_channel( 'value2_ph_pulse1_1','riga2_ph_pulse1_1',180, 0,0 );" class="span12"  runat="server" MaxLength="2" meta:resourcekey="value_biocide1_week3_giovedi_minResource1" ></asp:textbox>
                </div>
                       </div>
<div class="span2">
                       <div id="riga_biocide1_week3_giovedi_feed" class="control-group">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal101"  text="Feed" runat="server" meta:resourcekey="Literal101Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_biocide1_week3_giovedi_feed" onblur="javascript: Changed_channel( 'value2_ph_pulse1_1','riga2_ph_pulse1_1',180, 0,0 );" class="span12"  runat="server" meta:resourcekey="value_biocide1_week3_giovedi_feedResource1" ></asp:textbox>
                </div>
                       </div>					   
                </div>
				
</div>
				<!-- fine riga -->
     <!-- riga -->
                <div class="row-fluid">
               	<div class="span3">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal102" runat="server" meta:resourcekey="Literal102Resource1"></asp:literal></h5>
                    <asp:checkbox ID="biocide1_week3_venerdi" runat="server" meta:resourcekey="biocide1_week3_venerdiResource1"></asp:checkbox>
                    <asp:literal runat="server" text ="Friday" meta:resourcekey="LiteralResource21"></asp:literal>
                </div>
                </div>
                 <!-- fine riga -->
                                <!-- riga -->
<div id ="enable_biocide1_week3_venerdi">
                <div class="row-fluid">
               	<div class="span2">
                       <div id="riga_biocide1_week3_venerdi_hr" class="control-group">
                                <h5 style="padding-top:10px"><asp:literal ID = "Literal105"  text="Hour" runat="server" meta:resourcekey="Literal105Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_biocide1_week3_venerdi_hr" onblur="javascript: Changed_channel( 'value1_ph_pulse1_1','riga1_ph_pulse1_1',max_ch1_value, min_ch1_value,max_fix_value1 );" class="span12"  runat="server" MaxLength="2" meta:resourcekey="value_biocide1_week3_venerdi_hrResource1" ></asp:textbox>
                </div>
                       </div>

                    <div class="span2">
                       <div id="riga_biocide1_week3_venerdi_min" class="control-group">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal106"  text="Minute" runat="server" meta:resourcekey="Literal106Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_biocide1_week3_venerdi_min" onblur="javascript: Changed_channel( 'value2_ph_pulse1_1','riga2_ph_pulse1_1',180, 0,0 );" class="span12"  runat="server" MaxLength="2" meta:resourcekey="value_biocide1_week3_venerdi_minResource1" ></asp:textbox>
                </div>
                       </div>
<div class="span2">
                       <div id="riga_biocide1_week3_venerdi_feed" class="control-group">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal107"  text="Feed" runat="server" meta:resourcekey="Literal107Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_biocide1_week3_venerdi_feed" onblur="javascript: Changed_channel( 'value2_ph_pulse1_1','riga2_ph_pulse1_1',180, 0,0 );" class="span12"  runat="server" meta:resourcekey="value_biocide1_week3_venerdi_feedResource1" ></asp:textbox>
                </div>
                       </div>					   
                </div>
				
</div>
				<!-- fine riga -->
 <!-- riga -->
                <div class="row-fluid">
               	<div class="span3">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal108" runat="server" meta:resourcekey="Literal108Resource1"></asp:literal></h5>
                    <asp:checkbox ID="biocide1_week3_sabato" runat="server" meta:resourcekey="biocide1_week3_sabatoResource1"></asp:checkbox>
                    <asp:literal runat="server" text ="Saturday" meta:resourcekey="LiteralResource22"></asp:literal>
                </div>
                </div>
                 <!-- fine riga -->
                                <!-- riga -->
<div id ="enable_biocide1_week3_sabato">
                <div class="row-fluid">
               	<div class="span2">
                       <div id="riga_biocide1_week3_sabato_hr" class="control-group">
                                <h5 style="padding-top:10px"><asp:literal ID = "Literal110"  text="Hour" runat="server" meta:resourcekey="Literal110Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_biocide1_week3_sabato_hr" onblur="javascript: Changed_channel( 'value1_ph_pulse1_1','riga1_ph_pulse1_1',max_ch1_value, min_ch1_value,max_fix_value1 );" class="span12"  runat="server" MaxLength="2" meta:resourcekey="value_biocide1_week3_sabato_hrResource1" ></asp:textbox>
                </div>
                       </div>

                    <div class="span2">
                       <div id="riga_biocide1_week3_sabato_min" class="control-group">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal111"  text="Minute" runat="server" meta:resourcekey="Literal111Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_biocide1_week3_sabato_min" onblur="javascript: Changed_channel( 'value2_ph_pulse1_1','riga2_ph_pulse1_1',180, 0,0 );" class="span12"  runat="server" MaxLength="2" meta:resourcekey="value_biocide1_week3_sabato_minResource1" ></asp:textbox>
                </div>
                       </div>
<div class="span2">
                       <div id="riga_biocide1_week3_sabato_feed" class="control-group">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal112"  text="Feed" runat="server" meta:resourcekey="Literal112Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_biocide1_week3_sabato_feed" onblur="javascript: Changed_channel( 'value2_ph_pulse1_1','riga2_ph_pulse1_1',180, 0,0 );" class="span12"  runat="server" meta:resourcekey="value_biocide1_week3_sabato_feedResource1" ></asp:textbox>
                </div>
                       </div>					   
                </div>
				
</div>
				<!-- fine riga -->
 <!-- riga -->
                <div class="row-fluid">
               	<div class="span3">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal113" runat="server" meta:resourcekey="Literal113Resource1"></asp:literal></h5>
                    <asp:checkbox ID="biocide1_week3_domenica" runat="server" meta:resourcekey="biocide1_week3_domenicaResource1"></asp:checkbox>
                    <asp:literal runat="server" text ="Sunday" meta:resourcekey="LiteralResource23"></asp:literal>
                </div>
                </div>
                 <!-- fine riga -->
                                <!-- riga -->
<div id ="enable_biocide1_week3_domenica">
                <div class="row-fluid">
               	<div class="span2">
                       <div id="riga_biocide1_week3_domenica_hr" class="control-group">
                                <h5 style="padding-top:10px"><asp:literal ID = "Literal115"  text="Hour" runat="server" meta:resourcekey="Literal115Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_biocide1_week3_domenica_hr" onblur="javascript: Changed_channel( 'value1_ph_pulse1_1','riga1_ph_pulse1_1',max_ch1_value, min_ch1_value,max_fix_value1 );" class="span12"  runat="server" MaxLength="2" meta:resourcekey="value_biocide1_week3_domenica_hrResource1" ></asp:textbox>
                </div>
                       </div>

                    <div class="span2">
                       <div id="riga_biocide1_week3_domenica_min" class="control-group">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal116"  text="Minute" runat="server" meta:resourcekey="Literal116Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_biocide1_week3_domenica_min" onblur="javascript: Changed_channel( 'value2_ph_pulse1_1','riga2_ph_pulse1_1',180, 0,0 );" class="span12"  runat="server" MaxLength="2" meta:resourcekey="value_biocide1_week3_domenica_minResource1" ></asp:textbox>
                </div>
                       </div>
<div class="span2">
                       <div id="riga_biocide1_week3_domenica_feed" class="control-group">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal117"  text="Feed" runat="server" meta:resourcekey="Literal117Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_biocide1_week3_domenica_feed" onblur="javascript: Changed_channel( 'value2_ph_pulse1_1','riga2_ph_pulse1_1',180, 0,0 );" class="span12"  runat="server" meta:resourcekey="value_biocide1_week3_domenica_feedResource1" ></asp:textbox>
                </div>
                       </div>					   
                </div>
				
</div>
				<!-- fine riga -->

                    </div>
                    </asp:placeholder>
                </div>
<!-- tab 4 stop-->
            <!-- tab 5 start-->
			<div class="tab-pane" id="tab_tower_sp5_5">
                <h5 style="padding-top:10px"><asp:literal ID = "Literal118"  text="Week4 Inactive" runat="server" meta:resourcekey="Literal118Resource1"></asp:literal></h5>
                <asp:placeholder runat="server" ID="week4_enable">
                <div  class="box-generic">
                                 <!-- riga -->
                <div class="row-fluid">
               	<div class="span3">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal119"  text="Biocide2 week4" runat="server" meta:resourcekey="Literal119Resource1"></asp:literal></h5>
                    <asp:checkbox ID="biocide1_week4_lunedi" runat="server" meta:resourcekey="biocide1_week4_lunediResource1"></asp:checkbox>
                    <asp:literal runat="server" text ="Monday" meta:resourcekey="LiteralResource24"></asp:literal>
                </div>
                </div>
                 <!-- fine riga -->
                                <!-- riga -->
<div id ="enable_biocide1_week4_lunedi">
                <div class="row-fluid">
               	<div class="span2">
                       <div id="riga_biocide1_week4_lunedi_hr" class="control-group">
                                <h5 style="padding-top:10px"><asp:literal ID = "Literal121"  text="Hour" runat="server" meta:resourcekey="Literal121Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_biocide1_week4_lunedi_hr" onblur="javascript: Changed_channel( 'value1_ph_pulse1_1','riga1_ph_pulse1_1',max_ch1_value, min_ch1_value,max_fix_value1 );" class="span12"  runat="server" MaxLength="2" meta:resourcekey="value_biocide1_week4_lunedi_hrResource1" ></asp:textbox>
                </div>
                       </div>

                    <div class="span2">
                       <div id="riga_biocide1_week4_lunedi_min" class="control-group">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal122"  text="Minute" runat="server" meta:resourcekey="Literal122Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_biocide1_week4_lunedi_min" onblur="javascript: Changed_channel( 'value2_ph_pulse1_1','riga2_ph_pulse1_1',180, 0,0 );" class="span12"  runat="server" MaxLength="2" meta:resourcekey="value_biocide1_week4_lunedi_minResource1" ></asp:textbox>
                </div>
                       </div>
<div class="span2">
                       <div id="riga_biocide1_week4_lunedi_feed" class="control-group">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal123"  text="Feed" runat="server" meta:resourcekey="Literal123Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_biocide1_week4_lunedi_feed" onblur="javascript: Changed_channel( 'value2_ph_pulse1_1','riga2_ph_pulse1_1',180, 0,0 );" class="span12"  runat="server" meta:resourcekey="value_biocide1_week4_lunedi_feedResource1" ></asp:textbox>
                </div>
                       </div>					   
                </div>
</div>
                 <!-- fine riga -->

 <!-- riga -->
                <div class="row-fluid">
               	<div class="span3">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal124"  text="" runat="server" meta:resourcekey="Literal124Resource1"></asp:literal></h5>
                    <asp:checkbox ID="biocide1_week4_martedi" runat="server" meta:resourcekey="biocide1_week4_martediResource1"></asp:checkbox>
                    <asp:literal runat="server" text ="Tuesday" meta:resourcekey="LiteralResource25"></asp:literal>
                </div>
                </div>
                 <!-- fine riga -->
                                <!-- riga -->
<div id ="enable_biocide1_week4_martedi">
                <div class="row-fluid">
               	<div class="span2">
                       <div id="riga_biocide1_week4_martedi_hr" class="control-group">
                                <h5 style="padding-top:10px"><asp:literal ID = "Literal126"  text="Hour" runat="server" meta:resourcekey="Literal126Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_biocide1_week4_martedi_hr" onblur="javascript: Changed_channel( 'value1_ph_pulse1_1','riga1_ph_pulse1_1',max_ch1_value, min_ch1_value,max_fix_value1 );" class="span12"  runat="server" MaxLength="2" meta:resourcekey="value_biocide1_week4_martedi_hrResource1" ></asp:textbox>
                </div>
                       </div>

                    <div class="span2">
                       <div id="riga_biocide1_week4_martedi_min" class="control-group">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal127"  text="Minute" runat="server" meta:resourcekey="Literal127Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_biocide1_week4_martedi_min" onblur="javascript: Changed_channel( 'value2_ph_pulse1_1','riga2_ph_pulse1_1',180, 0,0 );" class="span12"  runat="server" MaxLength="2" meta:resourcekey="value_biocide1_week4_martedi_minResource1" ></asp:textbox>
                </div>
                       </div>
<div class="span2">
                       <div id="riga_biocide1_week4_martedi_feed" class="control-group">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal128"  text="Feed" runat="server" meta:resourcekey="Literal128Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_biocide1_week4_martedi_feed" onblur="javascript: Changed_channel( 'value2_ph_pulse1_1','riga2_ph_pulse1_1',180, 0,0 );" class="span12"  runat="server" meta:resourcekey="value_biocide1_week4_martedi_feedResource1" ></asp:textbox>
                </div>
                       </div>					   
                </div>
				
</div>
				<!-- fine riga -->
 <!-- riga -->
                <div class="row-fluid">
               	<div class="span3">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal129"  text="" runat="server" meta:resourcekey="Literal129Resource1"></asp:literal></h5>
                    <asp:checkbox ID="biocide1_week4_mercoledi" runat="server" meta:resourcekey="biocide1_week4_mercolediResource1"></asp:checkbox>
                    <asp:literal runat="server" text ="Wednsday" meta:resourcekey="LiteralResource26"></asp:literal>
                </div>
                </div>
                 <!-- fine riga -->
                                <!-- riga -->
<div id ="enable_biocide1_week4_mercoledi">
                <div class="row-fluid">
               	<div class="span2">
                       <div id="riga_biocide1_week4_mercoledi_hr" class="control-group">
                                <h5 style="padding-top:10px"><asp:literal ID = "Literal131"  text="Hour" runat="server" meta:resourcekey="Literal131Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_biocide1_week4_mercoledi_hr" onblur="javascript: Changed_channel( 'value1_ph_pulse1_1','riga1_ph_pulse1_1',max_ch1_value, min_ch1_value,max_fix_value1 );" class="span12"  runat="server" MaxLength="2" meta:resourcekey="value_biocide1_week4_mercoledi_hrResource1" ></asp:textbox>
                </div>
                       </div>

                    <div class="span2">
                       <div id="riga_biocide1_week4_mercoledi_min" class="control-group">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal132"  text="Minute" runat="server" meta:resourcekey="Literal132Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_biocide1_week4_mercoledi_min" onblur="javascript: Changed_channel( 'value2_ph_pulse1_1','riga2_ph_pulse1_1',180, 0,0 );" class="span12"  runat="server" MaxLength="2" meta:resourcekey="value_biocide1_week4_mercoledi_minResource1" ></asp:textbox>
                </div>
                       </div>
<div class="span2">
                       <div id="riga_biocide1_week4_mercoledi_feed" class="control-group">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal133"  text="Feed" runat="server" meta:resourcekey="Literal133Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_biocide1_week4_mercoledi_feed" onblur="javascript: Changed_channel( 'value2_ph_pulse1_1','riga2_ph_pulse1_1',180, 0,0 );" class="span12"  runat="server" meta:resourcekey="value_biocide1_week4_mercoledi_feedResource1" ></asp:textbox>
                </div>
                       </div>					   
                </div>
				
</div>
				<!-- fine riga -->
 <!-- riga -->
                <div class="row-fluid">
               	<div class="span3">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal134"  text="" runat="server" meta:resourcekey="Literal134Resource1"></asp:literal></h5>
                    <asp:checkbox ID="biocide1_week4_giovedi" runat="server" meta:resourcekey="biocide1_week4_giovediResource1"></asp:checkbox>
                    <asp:literal runat="server" text ="Thursday" meta:resourcekey="LiteralResource27"></asp:literal>
                </div>
                </div>
                 <!-- fine riga -->
                                <!-- riga -->
<div id ="enable_biocide1_week4_giovedi">
                <div class="row-fluid">
               	<div class="span2">
                       <div id="riga_biocide1_week4_giovedi_hr" class="control-group">
                                <h5 style="padding-top:10px"><asp:literal ID = "Literal136"  text="Hour" runat="server" meta:resourcekey="Literal136Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_biocide1_week4_giovedi_hr" onblur="javascript: Changed_channel( 'value1_ph_pulse1_1','riga1_ph_pulse1_1',max_ch1_value, min_ch1_value,max_fix_value1 );" class="span12"  runat="server" MaxLength="2" meta:resourcekey="value_biocide1_week4_giovedi_hrResource1" ></asp:textbox>
                </div>
                       </div>

                    <div class="span2">
                       <div id="riga_biocide1_week4_giovedi_min" class="control-group">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal137"  text="Minute" runat="server" meta:resourcekey="Literal137Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_biocide1_week4_giovedi_min" onblur="javascript: Changed_channel( 'value2_ph_pulse1_1','riga2_ph_pulse1_1',180, 0,0 );" class="span12"  runat="server" MaxLength="2" meta:resourcekey="value_biocide1_week4_giovedi_minResource1" ></asp:textbox>
                </div>
                       </div>
<div class="span2">
                       <div id="riga_biocide1_week4_giovedi_feed" class="control-group">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal138"  text="Feed" runat="server" meta:resourcekey="Literal138Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_biocide1_week4_giovedi_feed" onblur="javascript: Changed_channel( 'value2_ph_pulse1_1','riga2_ph_pulse1_1',180, 0,0 );" class="span12"  runat="server" meta:resourcekey="value_biocide1_week4_giovedi_feedResource1" ></asp:textbox>
                </div>
                       </div>					   
                </div>
				
</div>
				<!-- fine riga -->
     <!-- riga -->
                <div class="row-fluid">
               	<div class="span3">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal139"  text="" runat="server" meta:resourcekey="Literal139Resource1"></asp:literal></h5>
                    <asp:checkbox ID="biocide1_week4_venerdi" runat="server" meta:resourcekey="biocide1_week4_venerdiResource1"></asp:checkbox>
                    <asp:literal runat="server" text ="Friday" meta:resourcekey="LiteralResource28"></asp:literal>
                </div>
                </div>
                 <!-- fine riga -->
                                <!-- riga -->
<div id ="enable_biocide1_week4_venerdi">
                <div class="row-fluid">
               	<div class="span2">
                       <div id="riga_biocide1_week4_venerdi_hr" class="control-group">
                                <h5 style="padding-top:10px"><asp:literal ID = "Literal141"  text="Hour" runat="server" meta:resourcekey="Literal141Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_biocide1_week4_venerdi_hr" onblur="javascript: Changed_channel( 'value1_ph_pulse1_1','riga1_ph_pulse1_1',max_ch1_value, min_ch1_value,max_fix_value1 );" class="span12"  runat="server" MaxLength="2" meta:resourcekey="value_biocide1_week4_venerdi_hrResource1" ></asp:textbox>
                </div>
                       </div>

                    <div class="span2">
                       <div id="riga_biocide1_week4_venerdi_min" class="control-group">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal142"  text="Minute" runat="server" meta:resourcekey="Literal142Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_biocide1_week4_venerdi_min" onblur="javascript: Changed_channel( 'value2_ph_pulse1_1','riga2_ph_pulse1_1',180, 0,0 );" class="span12"  runat="server" MaxLength="2" meta:resourcekey="value_biocide1_week4_venerdi_minResource1" ></asp:textbox>
                </div>
                       </div>
<div class="span2">
                       <div id="riga_biocide1_week4_venerdi_feed" class="control-group">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal143"  text="Feed" runat="server" meta:resourcekey="Literal143Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_biocide1_week4_venerdi_feed" onblur="javascript: Changed_channel( 'value2_ph_pulse1_1','riga2_ph_pulse1_1',180, 0,0 );" class="span12"  runat="server" meta:resourcekey="value_biocide1_week4_venerdi_feedResource1" ></asp:textbox>
                </div>
                       </div>					   
                </div>
				
</div>
				<!-- fine riga -->
 <!-- riga -->
                <div class="row-fluid">
               	<div class="span3">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal144"  text="" runat="server" meta:resourcekey="Literal144Resource1"></asp:literal></h5>
                    <asp:checkbox ID="biocide1_week4_sabato" runat="server" meta:resourcekey="biocide1_week4_sabatoResource1"></asp:checkbox>
                    <asp:literal runat="server" text ="Saturday" meta:resourcekey="LiteralResource29"></asp:literal>
                </div>
                </div>
                 <!-- fine riga -->
                                <!-- riga -->
<div id ="enable_biocide1_week4_sabato">
                <div class="row-fluid">
               	<div class="span2">
                       <div id="riga_biocide1_week4_sabato_hr" class="control-group">
                                <h5 style="padding-top:10px"><asp:literal ID = "Literal146"  text="Hour" runat="server" meta:resourcekey="Literal146Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_biocide1_week4_sabato_hr" onblur="javascript: Changed_channel( 'value1_ph_pulse1_1','riga1_ph_pulse1_1',max_ch1_value, min_ch1_value,max_fix_value1 );" class="span12"  runat="server" MaxLength="2" meta:resourcekey="value_biocide1_week4_sabato_hrResource1" ></asp:textbox>
                </div>
                       </div>

                    <div class="span2">
                       <div id="riga_biocide1_week4_sabato_min" class="control-group">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal147"  text="Minute" runat="server" meta:resourcekey="Literal147Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_biocide1_week4_sabato_min" onblur="javascript: Changed_channel( 'value2_ph_pulse1_1','riga2_ph_pulse1_1',180, 0,0 );" class="span12"  runat="server" MaxLength="2" meta:resourcekey="value_biocide1_week4_sabato_minResource1" ></asp:textbox>
                </div>
                       </div>
<div class="span2">
                       <div id="riga_biocide1_week4_sabato_feed" class="control-group">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal148"  text="Feed" runat="server" meta:resourcekey="Literal148Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_biocide1_week4_sabato_feed" onblur="javascript: Changed_channel( 'value2_ph_pulse1_1','riga2_ph_pulse1_1',180, 0,0 );" class="span12"  runat="server" meta:resourcekey="value_biocide1_week4_sabato_feedResource1" ></asp:textbox>
                </div>
                       </div>					   
                </div>
				
</div>
				<!-- fine riga -->
 <!-- riga -->
                <div class="row-fluid">
               	<div class="span3">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal149"  text="" runat="server" meta:resourcekey="Literal149Resource1"></asp:literal></h5>
                    <asp:checkbox ID="biocide1_week4_domenica" runat="server" meta:resourcekey="biocide1_week4_domenicaResource1"></asp:checkbox>
                    <asp:literal runat="server" text ="Sunday" meta:resourcekey="LiteralResource30"></asp:literal>
                </div>
                </div>
                 <!-- fine riga -->
                                <!-- riga -->
<div id ="enable_biocide1_week4_domenica">
                <div class="row-fluid">
               	<div class="span2">
                       <div id="riga_biocide1_week4_domenica_hr" class="control-group">
                                <h5 style="padding-top:10px"><asp:literal ID = "Literal151"  text="Hour" runat="server" meta:resourcekey="Literal151Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_biocide1_week4_domenica_hr" onblur="javascript: Changed_channel( 'value1_ph_pulse1_1','riga1_ph_pulse1_1',max_ch1_value, min_ch1_value,max_fix_value1 );" class="span12"  runat="server" MaxLength="2" meta:resourcekey="value_biocide1_week4_domenica_hrResource1" ></asp:textbox>
                </div>
                       </div>

                    <div class="span2">
                       <div id="riga_biocide1_week4_domenica_min" class="control-group">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal152"  text="Minute" runat="server" meta:resourcekey="Literal152Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_biocide1_week4_domenica_min" onblur="javascript: Changed_channel( 'value2_ph_pulse1_1','riga2_ph_pulse1_1',180, 0,0 );" class="span12"  runat="server" MaxLength="2" meta:resourcekey="value_biocide1_week4_domenica_minResource1" ></asp:textbox>
                </div>
                       </div>
<div class="span2">
                       <div id="riga_biocide1_week4_domenica_feed" class="control-group">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal153"  text="Feed" runat="server" meta:resourcekey="Literal153Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_biocide1_week4_domenica_feed" onblur="javascript: Changed_channel( 'value2_ph_pulse1_1','riga2_ph_pulse1_1',180, 0,0 );" class="span12"  runat="server" meta:resourcekey="value_biocide1_week4_domenica_feedResource1" ></asp:textbox>
                </div>
                       </div>					   
                </div>
				
</div>
				<!-- fine riga -->

                    </div>
                    </asp:placeholder>
                </div>
<!-- tab 5 stop-->
            </div>
            <div id="salva" class="btn-primary">
                   <b class="btn-primary btn-icon glyphicons ok"><asp:button runat="server" ID="save_biocide1tower_new" class="btn-primary" data-layout="center" data-type="confirm" data-toggle="notyfy" text="Salva e carica i dati" Font-Bold="True" meta:resourcekey="save_biocide1tower_newResource1" /><i></i></b>

        </div>
    </div>
    <script type="text/javascript" src="tower/validator_tower_biocide.js"></script>
       <script src="theme/scripts/demo/calendar_new.js"></script>
    <link href="bootstrap/css/jquery-ui-timepicker-addon.css" rel="stylesheet" />
                    <script type="text/javascript" src="common/validator_general_notify.js"></script>
<script src="theme/scripts/demo/notifications.js"></script>


    </form>
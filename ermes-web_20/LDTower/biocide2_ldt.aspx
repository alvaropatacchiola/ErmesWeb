<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="biocide2_ldt.aspx.vb" Inherits="ermes_web_20.biocide2_ldt" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>
<head>
    <style type="text/css">
        .NuovoStile1 {
            background-color: #000000;
        }
        .NuovoStile2 {
            background-color: #000000;
            background-repeat: repeat;
            background-attachment: fixed;
            background-position: center top;
        }
    </style>
</head>
<form id="form" runat="server"  method="post" action="LDTower/biocide2_ldt.aspx">              <!-- CAMBIARE L'INDIRIZZO DEL FILE!!!! -->   


    <h3><asp:literal runat="server" text ="Biocide2 CoolTrol" ID="message_channel" meta:resourcekey="message_channelResource1"></asp:literal></h3>
<div class="innerLR">
    <div class="box-generic">
        <!-- Tabs Heading -->
<div class="tabsbar tabsbar-2">
			<ul class="row-fluid row-merge">
            
                <li class="span1 active" ><a id="tab_tower_sp1" href="#tab_tower_sp1_1"  data-toggle="tab"><asp:literal text="Biocide 2"  runat="server" ID="tabtower1_1" meta:resourcekey="tabtower1_1Resource1" ></asp:literal></a></li>
                <li class="span1"><a id="tab_tower_sp2" href="#tab_tower_sp2_2" data-toggle="tab"><asp:literal text="Day 1" runat="server" ID="tabtower1_2" meta:resourcekey="tabtower1_2Resource1"></asp:literal></a></li>
                <li class="span1"><a id="tab_tower_sp3" href="#tab_tower_sp3_3" data-toggle="tab"><asp:literal text="Day 2" runat="server" ID="tabtower1_3" meta:resourcekey="tabtower1_3Resource1"></asp:literal></a></li>
                <li class="span1"><a id="tab_tower_sp4" href="#tab_tower_sp4_4" data-toggle="tab"><asp:literal text="Day 3" runat="server" ID="tabtower1_4" meta:resourcekey="tabtower1_4Resource1"></asp:literal></a></li>
                <li class="span1"><a id="tab_tower_sp5" href="#tab_tower_sp5_5" data-toggle="tab"><asp:literal text="Day 4" runat="server" ID="tabtower1_5" meta:resourcekey="tabtower1_5Resource1"></asp:literal></a></li>
		        <li class="span1"><a id="tab_tower_sp6" href="#tab_tower_sp6_6" data-toggle="tab"><asp:literal text="Day 5" runat="server" ID="Literal1_6" meta:resourcekey="tabtower1_6Resource1"></asp:literal></a></li>
                <li class="span1"><a id="tab_tower_sp7" href="#tab_tower_sp7_7" data-toggle="tab"><asp:literal text="Day 6" runat="server" ID="Literal1_7" meta:resourcekey="tabtower1_7Resource1"></asp:literal></a></li>
                <li class="span1"><a id="tab_tower_sp8" href="#tab_tower_sp8_8" data-toggle="tab"><asp:literal text="Day 7" runat="server" ID="Literal1_8" meta:resourcekey="tabtower1_8Resource1"></asp:literal></a></li>
             </ul>
		</div>
		<!-- // Tabs Heading END -->
        <div class="tab-content">
    <!-- tab 1 start-->
			<div class="tab-pane active" id="tab_tower_sp1_1">
                <div  class="box-generic">


  <!----------------------- BIOCIDE 2 ----------------------------->

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
              <h5 style="padding-top:10px"><asp:literal ID = "Literal8"  text="uS" runat="server" meta:resourcekey="Literal8Resource1"></asp:literal></h5>

                                                         <!-- CONTROLLARE IL VALORE DELLA CONDUCIBILITA VISUALIZZATA -->
                       <asp:textbox ID="value_pre_bleed_us" onblur="javascript: Changed_channel( 'value_pre_bleed_us','riga_pre_bleed_us',max_us, 0,0 );" class="span12"  runat="server" MaxLength="4" meta:resourcekey="value_pre_bleed_usResource1" ></asp:textbox>
                </div>
                       </div>
                                      
                </div>
                 <!-- fine riga -->   
</div>                             
<!-- riga -->
                <div class="row-fluid">
               	<div class="span2">
                       <div id="riga_circulation_hr" class="control-group">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal10"  text="Circulation (Hr)" runat="server" meta:resourcekey="Literal10Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_circulation_hr" onblur="javascript: Changed_channel( 'value_circulation_hr','riga_circulation_hr',99, 0,0 );"  class="span12"  runat="server" MaxLength="2" meta:resourcekey="value_circulation_hrResource1" ></asp:textbox>
                </div>
                       </div>
                <div class="span2">
                       <div id="riga_circulation_min" class="control-group">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal3"  text="Circulation (Min)" runat="server" meta:resourcekey="Literal3Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_circulation_min" onblur="javascript: Changed_channel( 'value_circulation_min','riga_circulation_min',59, 0,0 );"  class="span12"  runat="server" MaxLength="2" meta:resourcekey="value_circulation_minResource1" ></asp:textbox>
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

            <!------------- END BIOCIDE 2 ---------------->



      <!----------------- INIZIO GIORNO 1 ------------------------>


 <!-- tab 2 start-->
			<div class="tab-pane" id="tab_tower_sp2_2">
             
                <asp:placeholder runat="server" ID="day1_enable">
                <div  class="box-generic">
                 <!-- riga -->
                <div class="row-fluid">
               	<div class="span3">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal9"  text="Biocide2 Day1" runat="server" meta:resourcekey="Literal9Resource1"></asp:literal></h5>
                    <asp:checkbox ID="biocide_day1_first" runat="server" meta:resourcekey="biocide_day1_firstResource1"></asp:checkbox>
                    <asp:literal runat="server" text ="First" meta:resourcekey="LiteralResource3"></asp:literal>
                </div>
                </div>
                 <!-- fine riga -->
                      
  <!------ PRIMO INTERVENTO --------->   
                      
             <!-- riga -->
<div id ="enable_biocide_day1_first">

        <!-- IMPOSTAZIONE INTERVALLO DI TEMPO DELL'INTERVENTO -->
         <div class="row-fluid">
               	<div class="span2">
                       <div id="riga_biocide_count_day1_first_hr" class="control-group">
                                <h5 style="padding-top:10px"><asp:literal ID = "Literal12"  text="Counter Hour" runat="server" meta:resourcekey="Literal12Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_biocide_count_day1_first_hr" onblur="javascript: Changed_channel( 'value_biocide_count_day1_first_hr','riga_biocide_count_day1_first_hr',99, 0,0 );" class="span12"  runat="server" MaxLength="2" meta:resourcekey="value_biocide_day1_first_hrResource1" ></asp:textbox>
                </div>
                       </div>

                    <div class="span2">
                       <div id="riga_biocide_count_day1_first_min" class="control-group">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal13"  text="Counter Minute" runat="server" meta:resourcekey="Literal13Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_biocide_count_day1_first_min" onblur="javascript: Changed_channel( 'value_biocide_count_day1_first_min','riga_biocide_count_day1_first_min',59, 0,0 );" class="span12"  runat="server" MaxLength="2" meta:resourcekey="value_biocide_day1_first_minResource1" ></asp:textbox>
                        </div>
                 </div>
           				   
        </div>
            
         <!-- IMPOSTAZIONE ORARIO -->

         <div class="row-fluid">
               	<div class="span2">
                       <div id="riga_biocide_time_day1_first_hr" class="control-group">
                                <h5 style="padding-top:10px"><asp:literal ID = "Literal14"  text="Time Hour" runat="server" meta:resourcekey="Literal14Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_biocide_time_day1_first_hr" onblur="javascript: Changed_channel( 'value_biocide_time_day1_first_hr','riga_biocide_time_day1_first_hr',99, 0,0 );" class="span12"  runat="server" MaxLength="2" meta:resourcekey="value_biocide_time_day1_first_hrResource1" ></asp:textbox>
                </div>
                       </div>

                    <div class="span2">
                       <div id="riga_biocide_time_day1_first_min" class="control-group">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal15"  text="Time Minute" runat="server" meta:resourcekey="Literal15Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_biocide_time_day1_first_min" onblur="javascript: Changed_channel( 'value_biocide_time_day1_first_min','riga_biocide_time_day1_first_min',59, 0,0 );" class="span12"  runat="server" MaxLength="2" meta:resourcekey="value_biocide_time_day1_first_minResource1" ></asp:textbox>
                        </div>
                 </div>

             <!--  SCELTA AM-PM  -->
<asp:PlaceHolder id="enable_ampm_day1_first" runat="server">

              <h5 style="padding-top:10px"><asp:literal ID = "Literal16"  text="AM/PM" runat="server" meta:resourcekey="Literal16Resource1"></asp:literal></h5>
                    <asp:radiobutton ID="am_day1_first" style="margin: 5px 10px 10px 0px;" runat="server"  GroupName="GROUP2" meta:resourcekey="am_day1_firstResource1"></asp:radiobutton>
                    <asp:literal runat="server" text ="AM" meta:resourcekey="LiteralResource1"></asp:literal>
                    <asp:radiobutton ID="pm_day1_first" style="margin: 5px 10px 10px 0px;" runat="server"  GroupName="GROUP2" meta:resourcekey="pm_day1_firstResource1"></asp:radiobutton>
                    <asp:literal runat="server" text ="PM" meta:resourcekey="LiteralResource1"></asp:literal>
 </asp:PlaceHolder>	          				   
        </div>
</div>
                 <!-- fine riga -->




 <!-- riga -->
                <div class="row-fluid">
               	<div class="span3">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal19" runat="server" meta:resourcekey="Literal19Resource1"></asp:literal></h5>
                    <asp:checkbox ID="biocide_day1_second" runat="server" meta:resourcekey="biocide_day1_secondResource1"></asp:checkbox>
                    <asp:literal runat="server" text ="Second" meta:resourcekey="LiteralResource4"></asp:literal>
                </div>
                </div>
                 <!-- fine riga -->




                <!-- riga -->


     <!-------------------- SECONDO INTERVENTO ----------------------->


<div id ="enable_biocide_day1_second">

    <!-- IMPOSTAZIONE INTERVALLO DI TEMPO DELL'INTERVENTO -->
                <div class="row-fluid">
               	<div class="span2">
                       <div id="riga_biocide_count_day1_second_hr" class="control-group">         
                                <h5 style="padding-top:10px"><asp:literal ID = "Literal21"  text="Counter Hour" runat="server" meta:resourcekey="Literal21Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_biocide_count_day1_second_hr" onblur="javascript: Changed_channel( 'value_biocide_count_day1_second_hr','riga_biocide_count_day1_second_hr',99, 0,0 );" class="span12"  runat="server" MaxLength="2" meta:resourcekey="value_biocide_count_day1_second_hrResource1" ></asp:textbox>
                </div>
                       </div>

                    <div class="span2">
                       <div id="riga_biocide_count_day1_second_min" class="control-group">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal22"  text="Counter Minute" runat="server" meta:resourcekey="Literal22Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_biocide_count_day1_second_min" onblur="javascript: Changed_channel( 'value_biocide_count_day1_second_hr','riga_biocide_count_day1_second_min',59, 0,0 );" class="span12"  runat="server" MaxLength="2" meta:resourcekey="value_biocide_count_day1_second_hrResource1" ></asp:textbox>
                </div>
                       </div>
					   
                </div>

     <!-- IMPOSTAZIONE ORARIO -->

         <div class="row-fluid">
               	<div class="span2">
                       <div id="riga_biocide_time_day1_second_hr" class="control-group">
                                <h5 style="padding-top:10px"><asp:literal ID = "Literal23"  text="Time Hour" runat="server" meta:resourcekey="Literal23Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_biocide_time_day1_second_hr" onblur="javascript: Changed_channel( 'value_biocide_time_day1_second_hr','riga_biocide_time_day1_second_hr',99, 0,0 );" class="span12"  runat="server" MaxLength="2" meta:resourcekey="value_biocide_time_day1_second_hrResource1" ></asp:textbox>
                </div>
                       </div>

                    <div class="span2">
                       <div id="riga_biocide_time_day1_second_min" class="control-group">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal24"  text="Time Minute" runat="server" meta:resourcekey="Literal24Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_biocide_time_day1_second_min" onblur="javascript: Changed_channel( 'value_biocide_time_day1_second_min','riga_biocide_time_day1_second_min',59, 0,0 );" class="span12"  runat="server" MaxLength="2" meta:resourcekey="value_biocide_time_day1_second_minResource1" ></asp:textbox>
                        </div>
                 </div>

             <!--  SCELTA AM-PM  -->
<asp:PlaceHolder id="enable_ampm_day1_second" runat="server">

              <h5 style="padding-top:10px"><asp:literal ID = "Literal25"  text="AM/PM" runat="server" meta:resourcekey="Literal25Resource1"></asp:literal></h5>
                    <asp:radiobutton ID="am_day1_second" style="margin: 5px 10px 10px 0px;" runat="server"  GroupName="GROUP3" meta:resourcekey="am_day1_secondResource1"></asp:radiobutton>
                    <asp:literal runat="server" text ="AM" meta:resourcekey="LiteralResource1"></asp:literal>
                    <asp:radiobutton ID="pm_day1_second" style="margin: 5px 10px 10px 0px;" runat="server"  GroupName="GROUP3" meta:resourcekey="pm_day1_secondResource1"></asp:radiobutton>
                    <asp:literal runat="server" text ="PM" meta:resourcekey="LiteralResource1"></asp:literal>
</asp:PlaceHolder>			   
        </div>
				
</div>
				<!-- fine riga -->

     <!------------------------- TERZO INTERVENTO ---------------------->

 <!-- riga -->
                <div class="row-fluid">
               	<div class="span3">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal28" runat="server" meta:resourcekey="Literal28Resource1"></asp:literal></h5>
                    <asp:checkbox ID="biocide_day1_third" runat="server" meta:resourcekey="biocide_day1_thirdResource1"></asp:checkbox>
                    <asp:literal runat="server" text ="Third" meta:resourcekey="LiteralResource5"></asp:literal>
                </div>
                </div>
                 <!-- fine riga -->
                                <!-- riga -->
<div id ="enable_biocide_day1_third">

    <!-- IMPOSTAZIONE INTERVALLO DI TEMPO DELL'INTERVENTO -->
                <div class="row-fluid">
               	<div class="span2">
                       <div id="riga_biocide_count_day1_third_hr" class="control-group">
                                <h5 style="padding-top:10px"><asp:literal ID = "Literal30"  text="Counter Hour" runat="server" meta:resourcekey="Literal30Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_biocide_count_day1_third_hr" onblur="javascript: Changed_channel( 'value_biocide_count_day1_third_hr','riga_biocide_count_day1_third_hr',99, 0,0 );" class="span12"  runat="server" MaxLength="2" meta:resourcekey="value_biocide_count_day1_third_hrResource1" ></asp:textbox>
                </div>
                       </div>

                    <div class="span2">
                       <div id="riga_biocide_count_day1_third_min" class="control-group">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal31"  text="Counter Minute" runat="server" meta:resourcekey="Literal31Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_biocide_count_day1_third_min" onblur="javascript: Changed_channel( 'value_biocide_count_day1_third_min','riga_biocide_count_day1_third_min',59, 0,0 );" class="span12"  runat="server" MaxLength="2" meta:resourcekey="value_biocide_count_day1_third_minResource1" ></asp:textbox>
                       </div>
                    </div>					   
                </div>
				
    <!-- IMPOSTAZIONE ORARIO -->
            <div class="row-fluid">
               	<div class="span2">
                       <div id="riga_biocide_time_day1_third_hr" class="control-group">
                                <h5 style="padding-top:10px"><asp:literal ID = "Literal32"  text="Time Hour" runat="server" meta:resourcekey="Literal32Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_biocide_time_day1_third_hr" onblur="javascript: Changed_channel( 'value_biocide_time_day1_third_hr','riga_biocide_time_day1_third_hr',99, 0,0 );" class="span12"  runat="server" MaxLength="2" meta:resourcekey="value_biocide_time_day1_third_hrResource1" ></asp:textbox>
                </div>
                       </div>

                    <div class="span2">
                       <div id="riga_biocide_time_day1_third_min" class="control-group">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal33"  text="Time Minute" runat="server" meta:resourcekey="Literal33Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_biocide_time_day1_third_min" onblur="javascript: Changed_channel( 'value_biocide_time_day1_third_min','riga_biocide_time_day1_third_min',59, 0,0 );" class="span12"  runat="server" MaxLength="2" meta:resourcekey="value_biocide_time_day1_third_minResource1" ></asp:textbox>
                       </div>
                    </div>	
                
                <!--  SCELTA AM-PM  -->
<asp:PlaceHolder id="enable_ampm_day1_third" runat="server">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal34"  text="AM/PM" runat="server" meta:resourcekey="Literal34Resource1"></asp:literal></h5>
                    <asp:radiobutton ID="am_day1_third" style="margin: 5px 10px 10px 0px;" runat="server"  GroupName="GROUP4" meta:resourcekey="am_day1_thirdResource1"></asp:radiobutton>
                    <asp:literal runat="server" text ="AM" meta:resourcekey="LiteralResource1"></asp:literal>
                    <asp:radiobutton ID="pm_day1_third" style="margin: 5px 10px 10px 0px;" runat="server"  GroupName="GROUP4" meta:resourcekey="pm_day1_thirdResource1"></asp:radiobutton>
                    <asp:literal runat="server" text ="PM" meta:resourcekey="LiteralResource1"></asp:literal>				   
 </asp:PlaceHolder>         
    
     </div>


</div>
				<!-- fine riga -->



             <!-------------------------QUARTO INTERVENTO ---------------------->

 <!-- riga -->

                <div class="row-fluid">
               	<div class="span3">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal37" runat="server" meta:resourcekey="Literal37Resource1"></asp:literal></h5>
                    <asp:checkbox ID="biocide_day1_fourth" runat="server" meta:resourcekey="biocide_day1_fourthResource1"></asp:checkbox>
                    <asp:literal runat="server" text ="Fourth" meta:resourcekey="LiteralResource6"></asp:literal>
                </div>
                </div>
                <!-- fine riga -->


                <!-- riga -->
<div id ="enable_biocide_day1_fourth">

    <!-- IMPOSTAZIONE INTERVALLO DI TEMPO DELL'INTERVENTO -->
                <div class="row-fluid">
               	<div class="span2">
                       <div id="riga_biocide_count_day1_fourth_hr" class="control-group">
                                <h5 style="padding-top:10px"><asp:literal ID = "Literal39"  text="Counter Hour" runat="server" meta:resourcekey="Literal39Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_biocide_count_day1_fourth_hr" onblur="javascript: Changed_channel( 'value_biocide_count_day1_fourth_hr','riga_biocide_count_day1_fourth_hr',99, 0,0 );" class="span12"  runat="server" MaxLength="2" meta:resourcekey="value_biocide_count_day1_fourth_hrResource1" ></asp:textbox>
                </div>
                       </div>

                    <div class="span2">
                       <div id="riga_biocide_count_day1_fourth_min" class="control-group">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal40"  text="Counter Minute" runat="server" meta:resourcekey="Literal40Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_biocide_count_day1_fourth_min" onblur="javascript: Changed_channel( 'value_biocide_count_day1_fourth_min','riga_biocide_count_day1_fourth_min',59, 0,0 );" class="span12"  runat="server" MaxLength="2" meta:resourcekey="value_biocide_count_day1_fourth_minResource1" ></asp:textbox>
                </div>
                       </div>
	   
                </div>

    <!-- IMPOSTAZIONE ORARIO -->
            <div class="row-fluid">
               	<div class="span2">
                       <div id="riga_biocide_time_day1_fourth_hr" class="control-group">
                                <h5 style="padding-top:10px"><asp:literal ID = "Literal41"  text="Time Hour" runat="server" meta:resourcekey="Literal41Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_biocide_time_day1_fourth_hr" onblur="javascript: Changed_channel( 'value_biocide_time_day1_fourth_hr','riga_biocide_time_day1_fourth_hr',99, 0,0 );" class="span12"  runat="server" MaxLength="2" meta:resourcekey="value_biocide_time_day1_fourth_hrResource1" ></asp:textbox>
                </div>
                       </div>

                    <div class="span2">
                       <div id="riga_biocide_time_day1_fourth_min" class="control-group">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal42"  text="Time Minute" runat="server" meta:resourcekey="Literal42Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_biocide_time_day1_fourth_min" onblur="javascript: Changed_channel( 'value_biocide_time_day1_fourth_min','riga_biocide_time_day1_fourth_min',59, 0,0 );" class="span12"  runat="server" MaxLength="2" meta:resourcekey="value_biocide_time_day1_fourth_minResource1" ></asp:textbox>
                </div>
                       </div>
	   
             <!--  SCELTA AM-PM  -->
<asp:PlaceHolder id="enable_ampm_day1_fourth" runat="server">
            <h5 style="padding-top:10px"><asp:literal ID = "Literal43"  text="AM/PM" runat="server" meta:resourcekey="Literal43Resource1"></asp:literal></h5>
            <asp:radiobutton ID="am_day1_fourth" style="margin: 5px 10px 10px 0px;" runat="server"  GroupName="GROUP5" meta:resourcekey="am_day1_fourthResource1"></asp:radiobutton>
            <asp:literal runat="server" text ="AM" meta:resourcekey="LiteralResource1"></asp:literal>
            <asp:radiobutton ID="pm_day1_fourth" style="margin: 5px 10px 10px 0px;" runat="server"  GroupName="GROUP5" meta:resourcekey="pm_day1_fourthResource1"></asp:radiobutton>
            <asp:literal runat="server" text ="PM" meta:resourcekey="LiteralResource1"></asp:literal>				
</asp:PlaceHolder>
              </div>
				
</div>
				<!-- fine riga -->

      <!-------------------------END QUARTO INTERVENTO ---------------------->|
   

                    </div>
                </asp:placeholder>
                </div>

     <!-------------------------END GIORNO 1 ---------------------->|
<!-- tab 2 stop-->





     <!----------------------------------------------------------------->|
     <!-------------------------INIZIO GIORNO 2 ------------------------->
    <!----------------------------------------------------------------->|



            <!-- tab 3 start-->
			<div class="tab-pane" id="tab_tower_sp3_3">
               <asp:placeholder runat="server" ID="day2_enable">
                <div  class="box-generic">
                                 <!-- riga -->
                <div class="row-fluid">
               	<div class="span3">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal46"  text="Biocide2 Day2" runat="server" meta:resourcekey="Literal46Resource1"></asp:literal></h5>
                    <asp:checkbox ID="biocide_day2_first" runat="server" meta:resourcekey="biocide_day2_firstResource1"></asp:checkbox>
                    <asp:literal runat="server" text ="First" meta:resourcekey="LiteralResource10"></asp:literal>
                </div>
                </div>
                 <!-- fine riga -->


         <!-------------------------PRIMO INTERVENTO ---------------------->

             <!-- riga -->
<div id ="enable_biocide_day2_first">

    <!-- IMPOSTAZIONE INTERVALLO DI TEMPO DELL'INTERVENTO -->

                <div class="row-fluid">
               	<div class="span2">
                       <div id="riga_biocide_count_day2_first_hr" class="control-group">
                                <h5 style="padding-top:10px"><asp:literal ID = "Literal48"  text="Counter Hour" runat="server" meta:resourcekey="Literal48Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_biocide_count_day2_first_hr" onblur="javascript: Changed_channel( 'value_biocide_count_day2_first_hr','riga_biocide_count_day2_first_hr',99, 0,0 );" class="span12"  runat="server" MaxLength="2" meta:resourcekey="value_biocide_count_day2_first_hrResource1" ></asp:textbox>
                </div>
                       </div>

                    <div class="span2">
                       <div id="riga_biocide_count_day2_first_min" class="control-group">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal49"  text="Counter Minute" runat="server" meta:resourcekey="Literal49Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_biocide_count_day2_first_min" onblur="javascript: Changed_channel( 'value_biocide_count_day2_first_min','riga_biocide_count_day2_first_min',59, 0,0 );" class="span12"  runat="server" MaxLength="2" meta:resourcekey="value_biocide_count_day2_first_minResource1" ></asp:textbox>
                </div>
                       </div>
				   
                </div>


    <!----- IMPOSTAZIONE DELL'ORARIO ----->


            <div class="row-fluid">
               	<div class="span2">
                       <div id="riga_biocide_time_day2_first_hr" class="control-group">
                                <h5 style="padding-top:10px"><asp:literal ID = "Literal50"  text="Time Hour" runat="server" meta:resourcekey="Literal50Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_biocide_time_day2_first_hr" onblur="javascript: Changed_channel( 'value_biocide_time_day2_first_hr','riga_biocide_time_day2_first_hr',99, 0,0 );" class="span12"  runat="server" MaxLength="2" meta:resourcekey="value_biocide_time_day2_first_hrResource1" ></asp:textbox>
                </div>
                       </div>

                    <div class="span2">
                       <div id="riga_biocide_time_day2_first_min" class="control-group">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal51"  text="Time Minute" runat="server" meta:resourcekey="Literal51Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_biocide_time_day2_first_min" onblur="javascript: Changed_channel( 'value_biocide_time_day2_first_min','riga_biocide_time_day2_first_min',59, 0,0 );" class="span12"  runat="server" MaxLength="2" meta:resourcekey="value_biocide_time_day2_first_minResource1" ></asp:textbox>
                </div>
                       </div>
	   
                 <!--  SCELTA AM-PM  -->
<asp:PlaceHolder id="enable_ampm_day2_first" runat="server">
                <h5 style="padding-top:10px"><asp:literal ID = "Literal52"  text="AM/PM" runat="server" meta:resourcekey="Literal52Resource1"></asp:literal></h5>
                <asp:radiobutton ID="am_day2_first" style="margin: 5px 10px 10px 0px;" runat="server"  GroupName="GROUP6" meta:resourcekey="am_day2_firstResource1"></asp:radiobutton>
                <asp:literal runat="server" text ="AM" meta:resourcekey="LiteralResource1"></asp:literal>
                <asp:radiobutton ID="pm_day2_first" style="margin: 5px 10px 10px 0px;" runat="server"  GroupName="GROUP6" meta:resourcekey="pm_day2_firstResource1"></asp:radiobutton>
                <asp:literal runat="server" text ="PM" meta:resourcekey="LiteralResource1"></asp:literal>				
</asp:PlaceHolder>
              </div>
</div>
                 <!-- fine riga -->
          <!-------------------------FINE PRIMO INTERVENTO ---------------------->




  <!-------------------------SECONDO INTERVENTO ---------------------->


 <!-- riga -->
                <div class="row-fluid">
               	<div class="span3">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal55" runat="server" meta:resourcekey="Literal55Resource1"></asp:literal></h5>
                    <asp:checkbox ID="biocide_day2_second" runat="server" meta:resourcekey="biocide_day2_secondResource1"></asp:checkbox>
                    <asp:literal runat="server" text ="Second" meta:resourcekey="LiteralResource11"></asp:literal>
                </div>
                </div>
                 <!-- fine riga -->
                                <!-- riga -->
<div id ="enable_biocide_day2_second">
                <div class="row-fluid">
               	<div class="span2">
                       <div id="riga_biocide_count_day2_second_hr" class="control-group">
                                <h5 style="padding-top:10px"><asp:literal ID = "Literal57"  text="Counter Hour" runat="server" meta:resourcekey="Literal57Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_biocide_count_day2_second_hr" onblur="javascript: Changed_channel( 'value_biocide_count_day2_second_hr','riga_biocide_count_day2_second_hr',99, 0,0 );" class="span12"  runat="server" MaxLength="2" meta:resourcekey="value_biocide_count_day2_second_hrResource1" ></asp:textbox>
                </div>
                       </div>

                    <div class="span2">
                       <div id="riga_biocide_count_day2_second_min" class="control-group">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal58"  text="Counter Minute" runat="server" meta:resourcekey="Literal58Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_biocide_count_day2_second_min" onblur="javascript: Changed_channel( 'value_biocide_count_day2_second_min','riga_biocide_count_day2_second_min',59, 0,0 );" class="span12"  runat="server" MaxLength="2" meta:resourcekey="value_biocide_count_day2_second_minResource1" ></asp:textbox>
                </div>
                       </div>
				   
                </div>
			 <!----- IMPOSTAZIONE DELL'ORARIO ----->


            <div class="row-fluid">
               	<div class="span2">
                       <div id="riga_biocide_time_day2_second_hr" class="control-group">
                                <h5 style="padding-top:10px"><asp:literal ID = "Literal59"  text="Time Hour" runat="server" meta:resourcekey="Literal59Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_biocide_time_day2_second_hr" onblur="javascript: Changed_channel( 'value_biocide_time_day2_second_hr','riga_biocide_time_day2_second_hr',99, 0,0 );" class="span12"  runat="server" MaxLength="2" meta:resourcekey="value_biocide_time_day2_second_hrResource1" ></asp:textbox>
                </div>
                       </div>

                    <div class="span2">
                       <div id="riga_biocide_time_day2_second_min" class="control-group">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal60"  text="Time Minute" runat="server" meta:resourcekey="Literal60Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_biocide_time_day2_second_min" onblur="javascript: Changed_channel( 'value_biocide_time_day2_second_min','riga_biocide_time_day2_second_min',59, 0,0 );" class="span12"  runat="server" MaxLength="2" meta:resourcekey="value_biocide_time_day2_second_minResource1" ></asp:textbox>
                </div>
                       </div>
	   
                 <!--  SCELTA AM-PM  -->
<asp:PlaceHolder id="enable_ampm_day2_second" runat="server">
                <h5 style="padding-top:10px"><asp:literal ID = "Literal61"  text="AM/PM" runat="server" meta:resourcekey="Literal61Resource1"></asp:literal></h5>
                <asp:radiobutton ID="am_day2_second" style="margin: 5px 10px 10px 0px;" runat="server"  GroupName="GROUP7" meta:resourcekey="am_day2_secondResource1"></asp:radiobutton>
                <asp:literal runat="server" text ="AM" meta:resourcekey="LiteralResource1"></asp:literal>
                <asp:radiobutton ID="pm_day2_second" style="margin: 5px 10px 10px 0px;" runat="server"  GroupName="GROUP7" meta:resourcekey="pm_day2_secondResource1"></asp:radiobutton>
                <asp:literal runat="server" text ="PM" meta:resourcekey="LiteralResource1"></asp:literal>				
</asp:PlaceHolder>
              </div>	
</div>
				<!-- fine riga -->

 <!-------------------------FINE SECONDO INTERVENTO ---------------------->




 <!-------------------------TERZO INTERVENTO ---------------------->


 <!-- riga -->
                <div class="row-fluid">
               	<div class="span3">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal64" runat="server" meta:resourcekey="Literal64Resource1"></asp:literal></h5>
                    <asp:checkbox ID="biocide_day2_third" runat="server" meta:resourcekey="biocide_day2_thirdResource1"></asp:checkbox>
                    <asp:literal runat="server" text ="Third" meta:resourcekey="LiteralResource12"></asp:literal>
                </div>
                </div>
                 <!-- fine riga -->


                 <!-- riga -->
<div id ="enable_biocide_day2_third">

    <!-- IMPOSTAZIONE INTERVALLO DI TEMPO DELL'INTERVENTO -->
          
          <div class="row-fluid">
               	<div class="span2">
                       <div id="riga_biocide_count_day2_third_hr" class="control-group">
                                <h5 style="padding-top:10px"><asp:literal ID = "Literal66"  text="Counter Hour" runat="server" meta:resourcekey="Literal66Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_biocide_count_day2_third_hr" onblur="javascript: Changed_channel( 'value_biocide_count_day2_third_hr','riga_biocide_count_day2_third_hr',99, 0,0 );" class="span12"  runat="server" MaxLength="2" meta:resourcekey="value_biocide_count_day2_third_hrResource1" ></asp:textbox>
                        </div>
                </div>

                    <div class="span2">
                       <div id="riga_biocide_count_day2_third_min" class="control-group">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal68"  text="Counter Minute" runat="server" meta:resourcekey="Literal68Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_biocide_count_day2_third_min" onblur="javascript: Changed_channel( 'value_biocide_count_day2_third_min','riga_biocide_count_day2_third_min',59, 0,0 );" class="span12"  runat="server" MaxLength="2" meta:resourcekey="value_biocide_count_day2_third_minResource1" ></asp:textbox>
                       </div>
                     </div>				   
                </div>
		
    <!----- IMPOSTAZIONE DELL'ORARIO ----->


            <div class="row-fluid">
               	<div class="span2">
                       <div id="riga_biocide_time_day2_third_hr" class="control-group">
                                <h5 style="padding-top:10px"><asp:literal ID = "Literal69"  text="Time Hour" runat="server" meta:resourcekey="Literal69Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_biocide_time_day2_third_hr" onblur="javascript: Changed_channel( 'value_biocide_time_day2_third_hr','riga_biocide_time_day2_third_hr',99, 0,0 );" class="span12"  runat="server" MaxLength="2" meta:resourcekey="value_biocide_time_day2_third_hrResource1" ></asp:textbox>
                        </div>
                 </div>

                    <div class="span2">
                       <div id="riga_biocide_time_day2_third_min" class="control-group">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal70"  text="Time Minute" runat="server" meta:resourcekey="Literal70Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_biocide_time_day2_third_min" onblur="javascript: Changed_channel( 'value_biocide_time_day2_third_min','riga_biocide_time_day2_third_min',59, 0,0 );" class="span12"  runat="server" MaxLength="2" meta:resourcekey="value_biocide_time_day2_third_minResource1" ></asp:textbox>
                        </div>
                    </div>
	   
                 <!--  SCELTA AM-PM  -->
<asp:PlaceHolder id="enable_ampm_day2_third" runat="server">
                <h5 style="padding-top:10px"><asp:literal ID = "Literal71"  text="AM/PM" runat="server" meta:resourcekey="Literal71Resource1"></asp:literal></h5>
                <asp:radiobutton ID="am_day2_third" style="margin: 5px 10px 10px 0px;" runat="server"  GroupName="GROUP8" meta:resourcekey="am_day2_thirdResource1"></asp:radiobutton>
                <asp:literal runat="server" text ="AM" meta:resourcekey="LiteralResource1"></asp:literal>
                <asp:radiobutton ID="pm_day2_third" style="margin: 5px 10px 10px 0px;" runat="server"  GroupName="GROUP8" meta:resourcekey="pm_day2_thirdResource1"></asp:radiobutton>
                <asp:literal runat="server" text ="PM" meta:resourcekey="LiteralResource1"></asp:literal>				
</asp:PlaceHolder>
              </div>
    		
</div>
				<!-- fine riga -->


 <!-------------------------FINE TERZO INTERVENTO ---------------------->




    <!-------------------------QUARTO INTERVENTO ---------------------->


 <!-- riga -->
                <div class="row-fluid">
               	<div class="span3">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal74" runat="server" meta:resourcekey="Literal74Resource1"></asp:literal></h5>
                    <asp:checkbox ID="biocide_day2_fourth" runat="server" meta:resourcekey="biocide_day2_fourthResource1"></asp:checkbox>
                    <asp:literal runat="server" text ="Fourth" meta:resourcekey="LiteralResource13"></asp:literal>
                </div>
                </div>
                 <!-- fine riga -->
               <!-- riga -->
<div id ="enable_biocide_day2_fourth">
    
    <!-- IMPOSTAZIONE INTERVALLO DI TEMPO DELL'INTERVENTO -->
          
                <div class="row-fluid">
               	<div class="span2">
                       <div id="riga_biocide_count_day2_fourth_hr" class="control-group">
                                <h5 style="padding-top:10px"><asp:literal ID = "Literal76"  text="Counter Hour" runat="server" meta:resourcekey="Literal76Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_biocide_count_day2_fourth_hr" onblur="javascript: Changed_channel( 'value_biocide_count_day2_fourth_hr','riga_biocide_count_day2_fourth_hr',99, 0,0 );" class="span12"  runat="server" MaxLength="2" meta:resourcekey="value_biocide_count_day2_fourth_hrResource1" ></asp:textbox>
                </div>
                       </div>

                    <div class="span2">
                       <div id="riga_biocide_count_day2_fourth_min" class="control-group">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal77"  text="Counter Minute" runat="server" meta:resourcekey="Literal77Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_biocide_count_day2_fourth_min" onblur="javascript: Changed_channel( 'value_biocide_count_day2_fourth_min','riga_biocide_count_day2_fourth_min',59, 0,0 );" class="span12"  runat="server" MaxLength="2" meta:resourcekey="value_biocide_count_day2_fourth_minResource1" ></asp:textbox>
                </div>
                       </div>					   
                </div>

       <!----- IMPOSTAZIONE DELL'ORARIO ----->


            <div class="row-fluid">
               	<div class="span2">
                       <div id="riga_biocide_time_day2_fourth_hr" class="control-group">
                                <h5 style="padding-top:10px"><asp:literal ID = "Literal78"  text="Time Hour" runat="server" meta:resourcekey="Literal78Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_biocide_time_day2_fourth_hr" onblur="javascript: Changed_channel( 'value_biocide_time_day2_fourth_hr','riga_biocide_time_day2_fourth_hr',99, 0,0 );" class="span12"  runat="server" MaxLength="2" meta:resourcekey="value_biocide_time_day2_fourth_hrResource1" ></asp:textbox>
                        </div>
                 </div>

                    <div class="span2">
                       <div id="riga_biocide_time_day2_fourth_min" class="control-group">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal79"  text="Time Minute" runat="server" meta:resourcekey="Literal79Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_biocide_time_day2_fourth_min" onblur="javascript: Changed_channel( 'value_biocide_time_day2_fourth_min','riga_biocide_time_day2_fourth_min',59, 0,0 );" class="span12"  runat="server" MaxLength="2" meta:resourcekey="value_biocide_time_day2_fourth_minResource1" ></asp:textbox>
                        </div>
                    </div>
	   
                 <!--  SCELTA AM-PM  -->
<asp:PlaceHolder id="enable_ampm_day2_fourth" runat="server">
                <h5 style="padding-top:10px"><asp:literal ID = "Literal80"  text="AM/PM" runat="server" meta:resourcekey="Literal80Resource1"></asp:literal></h5>
                <asp:radiobutton ID="am_day2_fourth" style="margin: 5px 10px 10px 0px;" runat="server"  GroupName="GROUP9" meta:resourcekey="am_day2_fourthResource1"></asp:radiobutton>
                <asp:literal runat="server" text ="AM" meta:resourcekey="LiteralResource1"></asp:literal>
                <asp:radiobutton ID="pm_day2_fourth" style="margin: 5px 10px 10px 0px;" runat="server"  GroupName="GROUP9" meta:resourcekey="pm_day2_fourthResource1"></asp:radiobutton>
                <asp:literal runat="server" text ="PM" meta:resourcekey="LiteralResource1"></asp:literal>				
</asp:PlaceHolder>
              </div>

				
</div>


     <!-------------------------FINE QUARTO INTERVENTO ---------------------->

				<!-- fine riga -->
   
                    </div>
                    </asp:placeholder>
                </div>
<!-- tab 3 stop-->



<!--------------------------------------------------------------->
<!-------------------------INIZIO GIORNO 3 --------------------- >
<!--------------------------------------------------------------->




            <!-- tab 4 start-->
			<div class="tab-pane" id="tab_tower_sp4_4">
                <asp:placeholder runat="server" ID="day3_enable">
                <div  class="box-generic">



 <!-------------------------PRIMO INTERVENTO ---------------------->

                                 <!-- riga -->
                <div class="row-fluid">
               	<div class="span3">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal83"  text="Biocide2 day3" runat="server" meta:resourcekey="Literal83Resource1"></asp:literal></h5>
                    <asp:checkbox ID="biocide_day3_first" runat="server" meta:resourcekey="biocide_day3_firstResource1"></asp:checkbox>
                    <asp:literal runat="server" text ="First" meta:resourcekey="LiteralResource17"></asp:literal>
                </div>
                </div>
                 <!-- fine riga -->
                                <!-- riga -->
<div id ="enable_biocide_day3_first">

      <!-- IMPOSTAZIONE INTERVALLO DI TEMPO DELL'INTERVENTO -->

                <div class="row-fluid">
               	<div class="span2">
                       <div id="riga_biocide_count_day3_first_hr" class="control-group">
                                <h5 style="padding-top:10px"><asp:literal ID = "Literal85"  text="Counter Hour" runat="server" meta:resourcekey="Literal85Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_biocide_count_day3_first_hr" onblur="javascript: Changed_channel( 'value_biocide_count_day3_first_hr','riga_biocide_count_day3_first_hr',99, 0,0 );" class="span12"  runat="server" MaxLength="2" meta:resourcekey="riga_biocide_count_day3_first_hrResource1" ></asp:textbox>
                </div>
                       </div>

                    <div class="span2">
                       <div id="riga_biocide_count_day3_first_min" class="control-group">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal86"  text="Counter Minute" runat="server" meta:resourcekey="Literal86Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_biocide_count_day3_first_min" onblur="javascript: Changed_channel( 'value_biocide_count_day3_first_min','riga_biocide_count_day3_first_min',59, 0,0 );" class="span12"  runat="server" MaxLength="2" meta:resourcekey="value_biocide_count_day3_first_minResource1" ></asp:textbox>
                </div>
                       </div>
				   
                </div>


    <!----- IMPOSTAZIONE DELL'ORARIO ----->


            <div class="row-fluid">
               	<div class="span2">
                       <div id="riga_biocide_time_day3_first_hr" class="control-group">
                                <h5 style="padding-top:10px"><asp:literal ID = "Literal87"  text="Time Hour" runat="server" meta:resourcekey="Literal87Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_biocide_time_day3_first_hr" onblur="javascript: Changed_channel( 'value_biocide_time_day3_first_hr','riga_biocide_time_day3_first_hr',99, 0,0 );" class="span12"  runat="server" MaxLength="2" meta:resourcekey="value_biocide_time_day3_first_hrResource1" ></asp:textbox>
                    </div>
                </div>

                    <div class="span2">
                       <div id="riga_biocide_time_day3_first_min" class="control-group">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal88"  text="Time Minute" runat="server" meta:resourcekey="Literal88Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_biocide_time_day3_first_min" onblur="javascript: Changed_channel( 'value_biocide_time_day3_first_min','riga_biocide_time_day3_first_min',59, 0,0 );" class="span12"  runat="server" MaxLength="2" meta:resourcekey="value_biocide_time_day3_first_minResource1" ></asp:textbox>
                </div>
                       </div>
	   
                 <!--  SCELTA AM-PM  -->
<asp:PlaceHolder id="enable_ampm_day3_first" runat="server">
                <h5 style="padding-top:10px"><asp:literal ID = "Literal89"  text="AM/PM" runat="server" meta:resourcekey="Literal89Resource1"></asp:literal></h5>
                <asp:radiobutton ID="am_day3_first" style="margin: 5px 10px 10px 0px;" runat="server"  GroupName="GROUP10" meta:resourcekey="am_day3_firstResource1"></asp:radiobutton>
                <asp:literal runat="server" text ="AM" meta:resourcekey="LiteralResource1"></asp:literal>
                <asp:radiobutton ID="pm_day3_first" style="margin: 5px 10px 10px 0px;" runat="server"  GroupName="GROUP10" meta:resourcekey="pm_day3_firstResource1"></asp:radiobutton>
                <asp:literal runat="server" text ="PM" meta:resourcekey="LiteralResource1"></asp:literal>				
</asp:PlaceHolder>
              </div>
</div>
                 <!-- fine riga -->


   <!-------------------------FINE PRIMO INTERVENTO ---------------------->


  <!-------------------------SECONDO INTERVENTO ---------------------->


 <!-- riga -->
                <div class="row-fluid">
               	<div class="span3">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal92" runat="server" meta:resourcekey="Literal92Resource1"></asp:literal></h5>
                    <asp:checkbox ID="biocide_day3_second" runat="server" meta:resourcekey="biocide_day3_secondResource1"></asp:checkbox>
                    <asp:literal runat="server" text ="Second" meta:resourcekey="LiteralResource11"></asp:literal>
                </div>
                </div>
                 <!-- fine riga -->
                                <!-- riga -->
<div id ="enable_biocide_day3_second">
                <div class="row-fluid">
               	<div class="span2">
                       <div id="riga_biocide_count_day3_second_hr" class="control-group">
                                <h5 style="padding-top:10px"><asp:literal ID = "Literal94"  text="Counter Hour" runat="server" meta:resourcekey="Literal94Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_biocide_count_day3_second_hr" onblur="javascript: Changed_channel( 'value_biocide_count_day3_second_hr','riga_biocide_count_day3_second_hr',99, 0,0 );" class="span12"  runat="server" MaxLength="2" meta:resourcekey="value_biocide_count_day3_second_hrResource1" ></asp:textbox>
                </div>
                       </div>

                    <div class="span2">
                       <div id="riga_biocide_count_day3_second_min" class="control-group">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal96"  text="Counter Minute" runat="server" meta:resourcekey="Literal96Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_biocide_count_day3_second_min" onblur="javascript: Changed_channel( 'value_biocide_count_day3_second_min','riga_biocide_count_day3_second_min',59, 0,0 );" class="span12"  runat="server" MaxLength="2" meta:resourcekey="value_biocide_count_day3_second_minResource1" ></asp:textbox>
                </div>
                       </div>
				   
                </div>
			 <!----- IMPOSTAZIONE DELL'ORARIO ----->


            <div class="row-fluid">
               	<div class="span2">
                       <div id="riga_biocide_time_day3_second_hr" class="control-group">
                                <h5 style="padding-top:10px"><asp:literal ID = "Literal97"  text="Time Hour" runat="server" meta:resourcekey="Literal97Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_biocide_time_day3_second_hr" onblur="javascript: Changed_channel( 'value_biocide_time_day3_second_hr','riga_biocide_time_day3_second_hr',99, 0,0 );" class="span12"  runat="server" MaxLength="2" meta:resourcekey="value_biocide_time_day3_second_hrResource1" ></asp:textbox>
                </div>
                       </div>

                    <div class="span2">
                       <div id="riga_biocide_time_day3_second_min" class="control-group">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal98"  text="Time Minute" runat="server" meta:resourcekey="Literal98Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_biocide_time_day3_second_min" onblur="javascript: Changed_channel( 'value_biocide_time_day3_second_min','riga_biocide_time_day3_second_min',59, 0,0 );" class="span12"  runat="server" MaxLength="2" meta:resourcekey="value_biocide_time_day3_second_minResource1" ></asp:textbox>
                </div>
                       </div>
	   
                 <!--  SCELTA AM-PM  -->
<asp:PlaceHolder id="enable_ampm_day3_second" runat="server">
                <h5 style="padding-top:10px"><asp:literal ID = "Literal99"  text="AM/PM" runat="server" meta:resourcekey="Literal99Resource1"></asp:literal></h5>
                <asp:radiobutton ID="am_day3_second" style="margin: 5px 10px 10px 0px;" runat="server"  GroupName="GROUP11" meta:resourcekey="am_day3_secondResource1"></asp:radiobutton>
                <asp:literal runat="server" text ="AM" meta:resourcekey="LiteralResource1"></asp:literal>
                <asp:radiobutton ID="pm_day3_second" style="margin: 5px 10px 10px 0px;" runat="server"  GroupName="GROUP11" meta:resourcekey="pm_day3_secondResource1"></asp:radiobutton>
                <asp:literal runat="server" text ="PM" meta:resourcekey="LiteralResource1"></asp:literal>				
</asp:PlaceHolder>
              </div>	
</div>
				<!-- fine riga -->

 <!-------------------------FINE SECONDO INTERVENTO ---------------------->




 <!-------------------------TERZO INTERVENTO ---------------------->


 <!-- riga -->
                <div class="row-fluid">
               	<div class="span3">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal102" runat="server" meta:resourcekey="Literal102Resource1"></asp:literal></h5>
                    <asp:checkbox ID="biocide_day3_third" runat="server" meta:resourcekey="biocide_day3_thirdResource1"></asp:checkbox>
                    <asp:literal runat="server" text ="Third" meta:resourcekey="LiteralResource12"></asp:literal>
                </div>
                </div>
                 <!-- fine riga -->


                 <!-- riga -->
<div id ="enable_biocide_day3_third">

    <!-- IMPOSTAZIONE INTERVALLO DI TEMPO DELL'INTERVENTO -->
          
          <div class="row-fluid">
               	<div class="span2">
                       <div id="riga_biocide_count_day3_third_hr" class="control-group">
                                <h5 style="padding-top:10px"><asp:literal ID = "Literal105"  text="Counter Hour" runat="server" meta:resourcekey="Literal105Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_biocide_count_day3_third_hr" onblur="javascript: Changed_channel( 'value_biocide_count_day3_third_hr','riga_biocide_count_day3_third_hr',99, 0,0 );" class="span12"  runat="server" MaxLength="2" meta:resourcekey="value_biocide_count_day3_third_hrResource1" ></asp:textbox>
                        </div>
                </div>

                    <div class="span2">
                       <div id="riga_biocide_count_day3_third_min" class="control-group">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal106"  text="Counter Minute" runat="server" meta:resourcekey="Literal106Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_biocide_count_day3_third_min" onblur="javascript: Changed_channel( 'value_biocide_count_day3_third_min','riga_biocide_count_day3_third_min',59, 0,0 );" class="span12"  runat="server" MaxLength="2" meta:resourcekey="value_biocide_count_day3_third_minResource1" ></asp:textbox>
                       </div>
                     </div>				   
                </div>
		
    <!----- IMPOSTAZIONE DELL'ORARIO ----->


            <div class="row-fluid">
               	<div class="span2">
                       <div id="riga_biocide_time_day3_third_hr" class="control-group">
                                <h5 style="padding-top:10px"><asp:literal ID = "Literal107"  text="Time Hour" runat="server" meta:resourcekey="Literal107Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_biocide_time_day3_third_hr" onblur="javascript: Changed_channel( 'value_biocide_time_day3_third_hr','riga_biocide_time_day3_third_hr',99, 0,0 );" class="span12"  runat="server" MaxLength="2" meta:resourcekey="value_biocide_time_day3_third_hrResource1" ></asp:textbox>
                        </div>
                 </div>

                    <div class="span2">
                       <div id="riga_biocide_time_day3_third_min" class="control-group">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal108"  text="Time Minute" runat="server" meta:resourcekey="Literal108Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_biocide_time_day3_third_min" onblur="javascript: Changed_channel( 'value_biocide_time_day3_third_min','riga_biocide_time_day3_third_min',59, 0,0 );" class="span12"  runat="server" MaxLength="2" meta:resourcekey="value_biocide_time_day3_third_minResource1" ></asp:textbox>
                        </div>
                    </div>
	   
                 <!--  SCELTA AM-PM  -->
<asp:PlaceHolder id="enable_ampm_day3_third" runat="server">
                <h5 style="padding-top:10px"><asp:literal ID = "Literal109"  text="AM/PM" runat="server" meta:resourcekey="Literal109Resource1"></asp:literal></h5>
                <asp:radiobutton ID="am_day3_third" style="margin: 5px 10px 10px 0px;" runat="server"  GroupName="GROUP12" meta:resourcekey="am_day3_thirdResource1"></asp:radiobutton>
                <asp:literal runat="server" text ="AM" meta:resourcekey="LiteralResource1"></asp:literal>
                <asp:radiobutton ID="pm_day3_third" style="margin: 5px 10px 10px 0px;" runat="server"  GroupName="GROUP12" meta:resourcekey="pm_day3_thirdResource1"></asp:radiobutton>
                <asp:literal runat="server" text ="PM" meta:resourcekey="LiteralResource1"></asp:literal>				
</asp:PlaceHolder>
              </div>
    		
</div>
				<!-- fine riga -->


 <!-------------------------FINE TERZO INTERVENTO ---------------------->




    <!-------------------------QUARTO INTERVENTO ---------------------->


 <!-- riga -->
                <div class="row-fluid">
               	<div class="span3">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal112" runat="server" meta:resourcekey="Literal112Resource1"></asp:literal></h5>
                    <asp:checkbox ID="biocide_day3_fourth" runat="server" meta:resourcekey="biocide_day3_fourthResource1"></asp:checkbox>
                    <asp:literal runat="server" text ="Fourth" meta:resourcekey="LiteralResource13"></asp:literal>
                </div>
                </div>
                 <!-- fine riga -->
               <!-- riga -->
<div id ="enable_biocide_day3_fourth">
    
    <!-- IMPOSTAZIONE INTERVALLO DI TEMPO DELL'INTERVENTO -->
          
                <div class="row-fluid">
               	<div class="span2">
                       <div id="riga_biocide_count_day3_fourth_hr" class="control-group">
                                <h5 style="padding-top:10px"><asp:literal ID = "Literal114"  text="Counter Hour" runat="server" meta:resourcekey="Literal114Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_biocide_count_day3_fourth_hr" onblur="javascript: Changed_channel( 'value_biocide_count_day3_fourth_hr','riga_biocide_count_day3_fourth_hr',99, 0,0 );" class="span12"  runat="server" MaxLength="2" meta:resourcekey="value_biocide_count_day3_fourth_hrResource1" ></asp:textbox>
                </div>
                       </div>

                    <div class="span2">
                       <div id="riga_biocide_count_day3_fourth_min" class="control-group">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal115"  text="Counter Minute" runat="server" meta:resourcekey="Literal115Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_biocide_count_day3_fourth_min" onblur="javascript: Changed_channel( 'value_biocide_count_day3_fourth_min','riga_biocide_count_day3_fourth_min',59, 0,0 );" class="span12"  runat="server" MaxLength="2" meta:resourcekey="value_biocide_count_day3_fourth_minResource1" ></asp:textbox>
                </div>
                       </div>					   
                </div>

       <!----- IMPOSTAZIONE DELL'ORARIO ----->


            <div class="row-fluid">
               	<div class="span2">
                       <div id="riga_biocide_time_day3_fourth_hr" class="control-group">
                                <h5 style="padding-top:10px"><asp:literal ID = "Literal116"  text="Time Hour" runat="server" meta:resourcekey="Literal116Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_biocide_time_day3_fourth_hr" onblur="javascript: Changed_channel( 'value_biocide_time_day3_fourth_hr','riga_biocide_time_day3_fourth_hr',99, 0,0 );" class="span12"  runat="server" MaxLength="2" meta:resourcekey="value_biocide_time_day3_fourth_hrResource1" ></asp:textbox>
                        </div>
                 </div>

                    <div class="span2">
                       <div id="riga_biocide_time_day3_fourth_min" class="control-group">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal117"  text="Time Minute" runat="server" meta:resourcekey="Literal117Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_biocide_time_day3_fourth_min" onblur="javascript: Changed_channel( 'value_biocide_time_day3_fourth_min','riga_biocide_time_day3_fourth_min',59, 0,0 );" class="span12"  runat="server" MaxLength="2" meta:resourcekey="value_biocide_time_day3_fourth_minResource1" ></asp:textbox>
                        </div>
                    </div>
	   
                 <!--  SCELTA AM-PM  -->
<asp:PlaceHolder id="enable_ampm_day3_fourth" runat="server">
                <h5 style="padding-top:10px"><asp:literal ID = "Literal118"  text="AM/PM" runat="server" meta:resourcekey="Literal118Resource1"></asp:literal></h5>
                <asp:radiobutton ID="am_day3_fourth" style="margin: 5px 10px 10px 0px;" runat="server"  GroupName="GROUP13" meta:resourcekey="am_day3_fourthResource1"></asp:radiobutton>
                <asp:literal runat="server" text ="AM" meta:resourcekey="LiteralResource1"></asp:literal>
                <asp:radiobutton ID="pm_day3_fourth" style="margin: 5px 10px 10px 0px;" runat="server"  GroupName="GROUP13" meta:resourcekey="pm_day3_fourthResource1"></asp:radiobutton>
                <asp:literal runat="server" text ="PM" meta:resourcekey="LiteralResource1"></asp:literal>				
</asp:PlaceHolder>
              </div>

				
</div>


     <!-------------------------FINE QUARTO INTERVENTO ---------------------->

				<!-- fine riga -->

                    </div>
                    </asp:placeholder>
                </div>
<!-- tab 4 stop-->




<!--------------------------------------------------------------->
<!-------------------------INIZIO GIORNO 4 --------------------- >
<!--------------------------------------------------------------->




            <!-- tab 5 start-->
			<div class="tab-pane" id="tab_tower_sp5_5">
                <asp:placeholder runat="server" ID="day4_enable">
                <div  class="box-generic">



 <!-------------------------PRIMO INTERVENTO ---------------------->

                                 <!-- riga -->
                <div class="row-fluid">
               	<div class="span3">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal122"  text="Biocide2 day4" runat="server" meta:resourcekey="Literal122Resource1"></asp:literal></h5>
                    <asp:checkbox ID="biocide_day4_first" runat="server" meta:resourcekey="biocide_day4_firstResource1"></asp:checkbox>
                    <asp:literal runat="server" text ="First" meta:resourcekey="LiteralResource17"></asp:literal>
                </div>
                </div>
                 <!-- fine riga -->
                                <!-- riga -->
<div id ="enable_biocide_day4_first">

      <!-- IMPOSTAZIONE INTERVALLO DI TEMPO DELL'INTERVENTO -->

                <div class="row-fluid">
               	<div class="span2">
                       <div id="riga_biocide_count_day4_first_hr" class="control-group">
                                <h5 style="padding-top:10px"><asp:literal ID = "Literal124"  text="Counter Hour" runat="server" meta:resourcekey="Literal124Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_biocide_count_day4_first_hr" onblur="javascript: Changed_channel( 'value_biocide_count_day4_first_hr','riga_biocide_count_day4_first_hr',99, 0,0 );" class="span12"  runat="server" MaxLength="2" meta:resourcekey="riga_biocide_count_day4_first_hrResource1" ></asp:textbox>
                </div>
                       </div>

                    <div class="span2">
                       <div id="riga_biocide_count_day4_first_min" class="control-group">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal125"  text="Counter Minute" runat="server" meta:resourcekey="Literal125Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_biocide_count_day4_first_min" onblur="javascript: Changed_channel( 'value_biocide_count_day4_first_min','riga_biocide_count_day4_first_min',59, 0,0 );" class="span12"  runat="server" MaxLength="2" meta:resourcekey="value_biocide_count_day4_first_minResource1" ></asp:textbox>
                </div>
                       </div>
				   
                </div>


    <!----- IMPOSTAZIONE DELL'ORARIO ----->


            <div class="row-fluid">
               	<div class="span2">
                       <div id="riga_biocide_time_day4_first_hr" class="control-group">
                                <h5 style="padding-top:10px"><asp:literal ID = "Literal126"  text="Time Hour" runat="server" meta:resourcekey="Literal126Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_biocide_time_day4_first_hr" onblur="javascript: Changed_channel( 'value_biocide_time_day4_first_hr','riga_biocide_time_day4_first_hr',99, 0,0 );" class="span12"  runat="server" MaxLength="2" meta:resourcekey="value_biocide_time_day4_first_hrResource1" ></asp:textbox>
                    </div>
                </div>

                    <div class="span2">
                       <div id="riga_biocide_time_day4_first_min" class="control-group">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal127"  text="Time Minute" runat="server" meta:resourcekey="Literal127Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_biocide_time_day4_first_min" onblur="javascript: Changed_channel( 'value_biocide_time_day4_first_min','riga_biocide_time_day4_first_min',59, 0,0 );" class="span12"  runat="server" MaxLength="2" meta:resourcekey="value_biocide_time_day4_first_minResource1" ></asp:textbox>
                </div>
                       </div>
	   
                 <!--  SCELTA AM-PM  -->
<asp:PlaceHolder id="enable_ampm_day4_first" runat="server">
                <h5 style="padding-top:10px"><asp:literal ID = "Literal128"  text="AM/PM" runat="server" meta:resourcekey="Literal128Resource1"></asp:literal></h5>
                <asp:radiobutton ID="am_day4_first" style="margin: 5px 10px 10px 0px;" runat="server"  GroupName="GROUP14" meta:resourcekey="am_day4_firstResource1"></asp:radiobutton>
                <asp:literal runat="server" text ="AM" meta:resourcekey="LiteralResource1"></asp:literal>
                <asp:radiobutton ID="pm_day4_first" style="margin: 5px 10px 10px 0px;" runat="server"  GroupName="GROUP14" meta:resourcekey="pm_day4_firstResource1"></asp:radiobutton>
                <asp:literal runat="server" text ="PM" meta:resourcekey="LiteralResource1"></asp:literal>				
</asp:PlaceHolder>
              </div>
</div>
                 <!-- fine riga -->


   <!-------------------------FINE PRIMO INTERVENTO ---------------------->


  <!-------------------------SECONDO INTERVENTO ---------------------->


 <!-- riga -->
                <div class="row-fluid">
               	<div class="span3">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal131" runat="server" meta:resourcekey="Literal131Resource1"></asp:literal></h5>
                    <asp:checkbox ID="biocide_day4_second" runat="server" meta:resourcekey="biocide_day4_secondResource1"></asp:checkbox>
                    <asp:literal runat="server" text ="Second" meta:resourcekey="LiteralResource11"></asp:literal>
                </div>
                </div>
                 <!-- fine riga -->
                                <!-- riga -->
<div id ="enable_biocide_day4_second">
                <div class="row-fluid">
               	<div class="span2">
                       <div id="riga_biocide_count_day4_second_hr" class="control-group">
                                <h5 style="padding-top:10px"><asp:literal ID = "Literal133"  text="Counter Hour" runat="server" meta:resourcekey="Literal133Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_biocide_count_day4_second_hr" onblur="javascript: Changed_channel( 'value_biocide_count_day4_second_hr','riga_biocide_count_day4_second_hr',99, 0,0 );" class="span12"  runat="server" MaxLength="2" meta:resourcekey="value_biocide_count_day4_second_hrResource1" ></asp:textbox>
                </div>
                       </div>

                    <div class="span2">
                       <div id="riga_biocide_count_day4_second_min" class="control-group">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal134"  text="Counter Minute" runat="server" meta:resourcekey="Literal134Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_biocide_count_day4_second_min" onblur="javascript: Changed_channel( 'value_biocide_count_day4_second_min','riga_biocide_count_day4_second_min',59, 0,0 );" class="span12"  runat="server" MaxLength="2" meta:resourcekey="value_biocide_count_day4_second_minResource1" ></asp:textbox>
                </div>
                       </div>
				   
                </div>
			 <!----- IMPOSTAZIONE DELL'ORARIO ----->


            <div class="row-fluid">
               	<div class="span2">
                       <div id="riga_biocide_time_day4_second_hr" class="control-group">
                                <h5 style="padding-top:10px"><asp:literal ID = "Literal135"  text="Time Hour" runat="server" meta:resourcekey="Literal135Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_biocide_time_day4_second_hr" onblur="javascript: Changed_channel( 'value_biocide_time_day4_second_hr','riga_biocide_time_day4_second_hr',99, 0,0 );" class="span12"  runat="server" MaxLength="2" meta:resourcekey="value_biocide_time_day4_second_hrResource1" ></asp:textbox>
                </div>
                       </div>

                    <div class="span2">
                       <div id="riga_biocide_time_day4_second_min" class="control-group">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal136"  text="Time Minute" runat="server" meta:resourcekey="Literal136Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_biocide_time_day4_second_min" onblur="javascript: Changed_channel( 'value_biocide_time_day4_second_min','riga_biocide_time_day4_second_min',59, 0,0 );" class="span12"  runat="server" MaxLength="2" meta:resourcekey="value_biocide_time_day4_second_minResource1" ></asp:textbox>
                </div>
                       </div>
	   
                 <!--  SCELTA AM-PM  -->
<asp:PlaceHolder id="enable_ampm_day4_second" runat="server">
                <h5 style="padding-top:10px"><asp:literal ID = "Literal137"  text="AM/PM" runat="server" meta:resourcekey="Literal137Resource1"></asp:literal></h5>
                <asp:radiobutton ID="am_day4_second" style="margin: 5px 10px 10px 0px;" runat="server"  GroupName="GROUP15" meta:resourcekey="am_day4_secondResource1"></asp:radiobutton>
                <asp:literal runat="server" text ="AM" meta:resourcekey="LiteralResource1"></asp:literal>
                <asp:radiobutton ID="pm_day4_second" style="margin: 5px 10px 10px 0px;" runat="server"  GroupName="GROUP15" meta:resourcekey="pm_day4_secondResource1"></asp:radiobutton>
                <asp:literal runat="server" text ="PM" meta:resourcekey="LiteralResource1"></asp:literal>				
</asp:PlaceHolder>
              </div>	
</div>
				<!-- fine riga -->

 <!-------------------------FINE SECONDO INTERVENTO ---------------------->




 <!-------------------------TERZO INTERVENTO ---------------------->


 <!-- riga -->
                <div class="row-fluid">
               	<div class="span3">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal140" runat="server" meta:resourcekey="Literal140Resource1"></asp:literal></h5>
                    <asp:checkbox ID="biocide_day4_third" runat="server" meta:resourcekey="biocide_day4_thirdResource1"></asp:checkbox>
                    <asp:literal runat="server" text ="Third" meta:resourcekey="LiteralResource12"></asp:literal>
                </div>
                </div>
                 <!-- fine riga -->


                 <!-- riga -->
<div id ="enable_biocide_day4_third">

    <!-- IMPOSTAZIONE INTERVALLO DI TEMPO DELL'INTERVENTO -->
          
          <div class="row-fluid">
               	<div class="span2">
                       <div id="riga_biocide_count_day4_third_hr" class="control-group">
                                <h5 style="padding-top:10px"><asp:literal ID = "Literal142"  text="Counter Hour" runat="server" meta:resourcekey="Literal142Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_biocide_count_day4_third_hr" onblur="javascript: Changed_channel( 'value_biocide_count_day4_third_hr','riga_biocide_count_day4_third_hr',99, 0,0 );" class="span12"  runat="server" MaxLength="2" meta:resourcekey="value_biocide_count_day4_third_hrResource1" ></asp:textbox>
                        </div>
                </div>

                    <div class="span2">
                       <div id="riga_biocide_count_day4_third_min" class="control-group">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal143"  text="Counter Minute" runat="server" meta:resourcekey="Literal143Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_biocide_count_day4_third_min" onblur="javascript: Changed_channel( 'value_biocide_count_day4_third_min','riga_biocide_count_day4_third_min',59, 0,0 );" class="span12"  runat="server" MaxLength="2" meta:resourcekey="value_biocide_count_day4_third_minResource1" ></asp:textbox>
                       </div>
                     </div>				   
                </div>
		
    <!----- IMPOSTAZIONE DELL'ORARIO ----->


            <div class="row-fluid">
               	<div class="span2">
                       <div id="riga_biocide_time_day4_third_hr" class="control-group">
                                <h5 style="padding-top:10px"><asp:literal ID = "Literal144"  text="Time Hour" runat="server" meta:resourcekey="Literal144Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_biocide_time_day4_third_hr" onblur="javascript: Changed_channel( 'value_biocide_time_day4_third_hr','riga_biocide_time_day4_third_hr',99, 0,0 );" class="span12"  runat="server" MaxLength="2" meta:resourcekey="value_biocide_time_day4_third_hrResource1" ></asp:textbox>
                        </div>
                 </div>

                    <div class="span2">
                       <div id="riga_biocide_time_day4_third_min" class="control-group">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal145"  text="Time Minute" runat="server" meta:resourcekey="Literal145Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_biocide_time_day4_third_min" onblur="javascript: Changed_channel( 'value_biocide_time_day4_third_min','riga_biocide_time_day4_third_min',59, 0,0 );" class="span12"  runat="server" MaxLength="2" meta:resourcekey="value_biocide_time_day4_third_minResource1" ></asp:textbox>
                        </div>
                    </div>
	   
                 <!--  SCELTA AM-PM  -->
<asp:PlaceHolder id="enable_ampm_day4_third" runat="server">
                <h5 style="padding-top:10px"><asp:literal ID = "Literal146"  text="AM/PM" runat="server" meta:resourcekey="Literal146Resource1"></asp:literal></h5>
                <asp:radiobutton ID="am_day4_third" style="margin: 5px 10px 10px 0px;" runat="server"  GroupName="GROUP16" meta:resourcekey="am_day4_thirdResource1"></asp:radiobutton>
                <asp:literal runat="server" text ="AM" meta:resourcekey="LiteralResource1"></asp:literal>
                <asp:radiobutton ID="pm_day4_third" style="margin: 5px 10px 10px 0px;" runat="server"  GroupName="GROUP16" meta:resourcekey="pm_day4_thirdResource1"></asp:radiobutton>
                <asp:literal runat="server" text ="PM" meta:resourcekey="LiteralResource1"></asp:literal>				
</asp:PlaceHolder>
              </div>
    		
</div>
				<!-- fine riga -->


 <!-------------------------FINE TERZO INTERVENTO ---------------------->




    <!-------------------------QUARTO INTERVENTO ---------------------->


 <!-- riga -->
                <div class="row-fluid">
               	<div class="span3">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal149" runat="server" meta:resourcekey="Literal149Resource1"></asp:literal></h5>
                    <asp:checkbox ID="biocide_day4_fourth" runat="server" meta:resourcekey="biocide_day4_fourthResource1"></asp:checkbox>
                    <asp:literal runat="server" text ="Fourth" meta:resourcekey="LiteralResource13"></asp:literal>
                </div>
                </div>
                 <!-- fine riga -->
               <!-- riga -->
<div id ="enable_biocide_day4_fourth">
    
    <!-- IMPOSTAZIONE INTERVALLO DI TEMPO DELL'INTERVENTO -->
          
                <div class="row-fluid">
               	<div class="span2">
                       <div id="riga_biocide_count_day4_fourth_hr" class="control-group">
                                <h5 style="padding-top:10px"><asp:literal ID = "Literal151"  text="Counter Hour" runat="server" meta:resourcekey="Literal151Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_biocide_count_day4_fourth_hr" onblur="javascript: Changed_channel( 'value_biocide_count_day4_fourth_hr','riga_biocide_count_day4_fourth_hr',99, 0,0 );" class="span12"  runat="server" MaxLength="2" meta:resourcekey="value_biocide_count_day4_fourth_hrResource1" ></asp:textbox>
                </div>
                       </div>

                    <div class="span2">
                       <div id="riga_biocide_count_day4_fourth_min" class="control-group">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal152"  text="Counter Minute" runat="server" meta:resourcekey="Literal152Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_biocide_count_day4_fourth_min" onblur="javascript: Changed_channel( 'value_biocide_count_day4_fourth_min','riga_biocide_count_day4_fourth_min',59, 0,0 );" class="span12"  runat="server" MaxLength="2" meta:resourcekey="value_biocide_count_day4_fourth_minResource1" ></asp:textbox>
                </div>
                       </div>					   
                </div>

       <!----- IMPOSTAZIONE DELL'ORARIO ----->


            <div class="row-fluid">
               	<div class="span2">
                       <div id="riga_biocide_time_day4_fourth_hr" class="control-group">
                                <h5 style="padding-top:10px"><asp:literal ID = "Literal153"  text="Time Hour" runat="server" meta:resourcekey="Literal153Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_biocide_time_day4_fourth_hr" onblur="javascript: Changed_channel( 'value_biocide_time_day4_fourth_hr','riga_biocide_time_day4_fourth_hr',99, 0,0 );" class="span12"  runat="server" MaxLength="2" meta:resourcekey="value_biocide_time_day4_fourth_hrResource1" ></asp:textbox>
                        </div>
                 </div>

                    <div class="span2">
                       <div id="riga_biocide_time_day4_fourth_min" class="control-group">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal154"  text="Time Minute" runat="server" meta:resourcekey="Literal154Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_biocide_time_day4_fourth_min" onblur="javascript: Changed_channel( 'value_biocide_time_day4_fourth_min','riga_biocide_time_day4_fourth_min',59, 0,0 );" class="span12"  runat="server" MaxLength="2" meta:resourcekey="value_biocide_time_day4_fourth_minResource1" ></asp:textbox>
                        </div>
                    </div>
	   
                 <!--  SCELTA AM-PM  -->
<asp:PlaceHolder id="enable_ampm_day4_fourth" runat="server">
                <h5 style="padding-top:10px"><asp:literal ID = "Literal155"  text="AM/PM" runat="server" meta:resourcekey="Literal155Resource1"></asp:literal></h5>
                <asp:radiobutton ID="am_day4_fourth" style="margin: 5px 10px 10px 0px;" runat="server"  GroupName="GROUP17" meta:resourcekey="am_day4_fourthResource1"></asp:radiobutton>
                <asp:literal runat="server" text ="AM" meta:resourcekey="LiteralResource1"></asp:literal>
                <asp:radiobutton ID="pm_day4_fourth" style="margin: 5px 10px 10px 0px;" runat="server"  GroupName="GROUP17" meta:resourcekey="pm_day4_fourthResource1"></asp:radiobutton>
                <asp:literal runat="server" text ="PM" meta:resourcekey="LiteralResource1"></asp:literal>				
</asp:PlaceHolder>
              </div>

				
</div>


     <!-------------------------FINE QUARTO INTERVENTO ---------------------->

				<!-- fine riga -->

                    </div>
                    </asp:placeholder>
                </div>
<!-- tab 5 stop-->




<!--------------------------------------------------------------->
<!-------------------------INIZIO GIORNO 5 --------------------- >
<!--------------------------------------------------------------->




            <!-- tab 6 start-->
			<div class="tab-pane" id="tab_tower_sp6_6">
                <asp:placeholder runat="server" ID="day5_enable">
                <div  class="box-generic">



 <!-------------------------PRIMO INTERVENTO ---------------------->

                                 <!-- riga -->
                <div class="row-fluid">
               	<div class="span3">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal159"  text="Biocide2 day5" runat="server" meta:resourcekey="Literal159Resource1"></asp:literal></h5>
                    <asp:checkbox ID="biocide_day5_first" runat="server" meta:resourcekey="biocide_day5_firstResource1"></asp:checkbox>
                    <asp:literal runat="server" text ="First" meta:resourcekey="LiteralResource17"></asp:literal>
                </div>
                </div>
                 <!-- fine riga -->
                                <!-- riga -->
<div id ="enable_biocide_day5_first">

      <!-- IMPOSTAZIONE INTERVALLO DI TEMPO DELL'INTERVENTO -->

                <div class="row-fluid">
               	<div class="span2">
                       <div id="riga_biocide_count_day5_first_hr" class="control-group">
                                <h5 style="padding-top:10px"><asp:literal ID = "Literal161"  text="Counter Hour" runat="server" meta:resourcekey="Literal161Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_biocide_count_day5_first_hr" onblur="javascript: Changed_channel( 'value_biocide_count_day5_first_hr','riga_biocide_count_day5_first_hr',99, 0,0 );" class="span12"  runat="server" MaxLength="2" meta:resourcekey="riga_biocide_count_day5_first_hrResource1" ></asp:textbox>
                </div>
                       </div>

                    <div class="span2">
                       <div id="riga_biocide_count_day5_first_min" class="control-group">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal162"  text="Counter Minute" runat="server" meta:resourcekey="Literal162Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_biocide_count_day5_first_min" onblur="javascript: Changed_channel( 'value_biocide_count_day5_first_min','riga_biocide_count_day5_first_min',59, 0,0 );" class="span12"  runat="server" MaxLength="2" meta:resourcekey="value_biocide_count_day5_first_minResource1" ></asp:textbox>
                </div>
                       </div>
				   
                </div>


    <!----- IMPOSTAZIONE DELL'ORARIO ----->


            <div class="row-fluid">
               	<div class="span2">
                       <div id="riga_biocide_time_day5_first_hr" class="control-group">
                                <h5 style="padding-top:10px"><asp:literal ID = "Literal163"  text="Time Hour" runat="server" meta:resourcekey="Literal163Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_biocide_time_day5_first_hr" onblur="javascript: Changed_channel( 'value_biocide_time_day5_first_hr','riga_biocide_time_day5_first_hr',99, 0,0 );" class="span12"  runat="server" MaxLength="2" meta:resourcekey="value_biocide_time_day5_first_hrResource1" ></asp:textbox>
                    </div>
                </div>

                    <div class="span2">
                       <div id="riga_biocide_time_day5_first_min" class="control-group">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal164"  text="Time Minute" runat="server" meta:resourcekey="Literal164Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_biocide_time_day5_first_min" onblur="javascript: Changed_channel( 'value_biocide_time_day5_first_min','riga_biocide_time_day5_first_min',59, 0,0 );" class="span12"  runat="server" MaxLength="2" meta:resourcekey="value_biocide_time_day5_first_minResource1" ></asp:textbox>
                </div>
                       </div>
	   
                 <!--  SCELTA AM-PM  -->
<asp:PlaceHolder id="enable_ampm_day5_first" runat="server">
                <h5 style="padding-top:10px"><asp:literal ID = "Literal165"  text="AM/PM" runat="server" meta:resourcekey="Literal165Resource1"></asp:literal></h5>
                <asp:radiobutton ID="am_day5_first" style="margin: 5px 10px 10px 0px;" runat="server"  GroupName="GROUP18" meta:resourcekey="am_day5_firstResource1"></asp:radiobutton>
                <asp:literal runat="server" text ="AM" meta:resourcekey="LiteralResource1"></asp:literal>
                <asp:radiobutton ID="pm_day5_first" style="margin: 5px 10px 10px 0px;" runat="server"  GroupName="GROUP18" meta:resourcekey="pm_day5_firstResource1"></asp:radiobutton>
                <asp:literal runat="server" text ="PM" meta:resourcekey="LiteralResource1"></asp:literal>				
</asp:PlaceHolder>
              </div>
</div>
                 <!-- fine riga -->


   <!-------------------------FINE PRIMO INTERVENTO ---------------------->


  <!-------------------------SECONDO INTERVENTO ---------------------->


 <!-- riga -->
                <div class="row-fluid">
               	<div class="span3">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal168" runat="server" meta:resourcekey="Literal168Resource1"></asp:literal></h5>
                    <asp:checkbox ID="biocide_day5_second" runat="server" meta:resourcekey="biocide_day5_secondResource1"></asp:checkbox>
                    <asp:literal runat="server" text ="Second" meta:resourcekey="LiteralResource11"></asp:literal>
                </div>
                </div>
                 <!-- fine riga -->
                                <!-- riga -->
<div id ="enable_biocide_day5_second">
                <div class="row-fluid">
               	<div class="span2">
                       <div id="riga_biocide_count_day5_second_hr" class="control-group">
                                <h5 style="padding-top:10px"><asp:literal ID = "Literal170"  text="Counter Hour" runat="server" meta:resourcekey="Literal170Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_biocide_count_day5_second_hr" onblur="javascript: Changed_channel( 'value_biocide_count_day5_second_hr','riga_biocide_count_day5_second_hr',99, 0,0 );" class="span12"  runat="server" MaxLength="2" meta:resourcekey="value_biocide_count_day5_second_hrResource1" ></asp:textbox>
                </div>
                       </div>

                    <div class="span2">
                       <div id="riga_biocide_count_day5_second_min" class="control-group">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal171"  text="Counter Minute" runat="server" meta:resourcekey="Literal171Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_biocide_count_day5_second_min" onblur="javascript: Changed_channel( 'value_biocide_count_day5_second_min','riga_biocide_count_day5_second_min',59, 0,0 );" class="span12"  runat="server" MaxLength="2" meta:resourcekey="value_biocide_count_day5_second_minResource1" ></asp:textbox>
                </div>
                       </div>
				   
                </div>
			 <!----- IMPOSTAZIONE DELL'ORARIO ----->


            <div class="row-fluid">
               	<div class="span2">
                       <div id="riga_biocide_time_day5_second_hr" class="control-group">
                                <h5 style="padding-top:10px"><asp:literal ID = "Literal172"  text="Time Hour" runat="server" meta:resourcekey="Literal172Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_biocide_time_day5_second_hr" onblur="javascript: Changed_channel( 'value_biocide_time_day5_second_hr','riga_biocide_time_day5_second_hr',99, 0,0 );" class="span12"  runat="server" MaxLength="2" meta:resourcekey="value_biocide_time_day5_second_hrResource1" ></asp:textbox>
                </div>
                       </div>

                    <div class="span2">
                       <div id="riga_biocide_time_day5_second_min" class="control-group">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal173"  text="Time Minute" runat="server" meta:resourcekey="Literal173Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_biocide_time_day5_second_min" onblur="javascript: Changed_channel( 'value_biocide_time_day5_second_min','riga_biocide_time_day5_second_min',59, 0,0 );" class="span12"  runat="server" MaxLength="2" meta:resourcekey="value_biocide_time_day5_second_minResource1" ></asp:textbox>
                        </div>
                   </div>
	   
                 <!--  SCELTA AM-PM  -->
<asp:PlaceHolder id="enable_ampm_day5_second" runat="server">
                <h5 style="padding-top:10px"><asp:literal ID = "Literal174"  text="AM/PM" runat="server" meta:resourcekey="Literal174Resource1"></asp:literal></h5>
                <asp:radiobutton ID="am_day5_second" style="margin: 5px 10px 10px 0px;" runat="server"  GroupName="GROUP19" meta:resourcekey="am_day5_secondResource1"></asp:radiobutton>
                <asp:literal runat="server" text ="AM" meta:resourcekey="LiteralResource1"></asp:literal>
                <asp:radiobutton ID="pm_day5_second" style="margin: 5px 10px 10px 0px;" runat="server"  GroupName="GROUP19" meta:resourcekey="pm_day5_secondResource1"></asp:radiobutton>
                <asp:literal runat="server" text ="PM" meta:resourcekey="LiteralResource1"></asp:literal>				
</asp:PlaceHolder>
              </div>	
</div>
				<!-- fine riga -->

 <!-------------------------FINE SECONDO INTERVENTO ---------------------->




 <!-------------------------TERZO INTERVENTO ---------------------->


 <!-- riga -->
                <div class="row-fluid">
               	<div class="span3">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal177" runat="server" meta:resourcekey="Literal177Resource1"></asp:literal></h5>
                    <asp:checkbox ID="biocide_day5_third" runat="server" meta:resourcekey="biocide_day5_thirdResource1"></asp:checkbox>
                    <asp:literal runat="server" text ="Third" meta:resourcekey="LiteralResource12"></asp:literal>
                </div>
                </div>
                 <!-- fine riga -->


                 <!-- riga -->
<div id ="enable_biocide_day5_third">

    <!-- IMPOSTAZIONE INTERVALLO DI TEMPO DELL'INTERVENTO -->
          
          <div class="row-fluid">
               	<div class="span2">
                       <div id="riga_biocide_count_day5_third_hr" class="control-group">
                                <h5 style="padding-top:10px"><asp:literal ID = "Literal179"  text="Counter Hour" runat="server" meta:resourcekey="Literal179Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_biocide_count_day5_third_hr" onblur="javascript: Changed_channel( 'value_biocide_count_day5_third_hr','riga_biocide_count_day5_third_hr',99, 0,0 );" class="span12"  runat="server" MaxLength="2" meta:resourcekey="value_biocide_count_day5_third_hrResource1" ></asp:textbox>
                        </div>
                </div>

                    <div class="span2">
                       <div id="riga_biocide_count_day5_third_min" class="control-group">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal180"  text="Counter Minute" runat="server" meta:resourcekey="Literal180Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_biocide_count_day5_third_min" onblur="javascript: Changed_channel( 'value_biocide_count_day5_third_min','riga_biocide_count_day5_third_min',59, 0,0 );" class="span12"  runat="server" MaxLength="2" meta:resourcekey="value_biocide_count_day5_third_minResource1" ></asp:textbox>
                       </div>
                     </div>				   
                </div>
		
    <!----- IMPOSTAZIONE DELL'ORARIO ----->


            <div class="row-fluid">
               	<div class="span2">
                       <div id="riga_biocide_time_day5_third_hr" class="control-group">
                                <h5 style="padding-top:10px"><asp:literal ID = "Literal181"  text="Time Hour" runat="server" meta:resourcekey="Literal181Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_biocide_time_day5_third_hr" onblur="javascript: Changed_channel( 'value_biocide_time_day5_third_hr','riga_biocide_time_day5_third_hr',99, 0,0 );" class="span12"  runat="server" MaxLength="2" meta:resourcekey="value_biocide_time_day5_third_hrResource1" ></asp:textbox>
                        </div>
                 </div>

                    <div class="span2">
                       <div id="riga_biocide_time_day5_third_min" class="control-group">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal182"  text="Time Minute" runat="server" meta:resourcekey="Literal182Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_biocide_time_day5_third_min" onblur="javascript: Changed_channel( 'value_biocide_time_day5_third_min','riga_biocide_time_day5_third_min',59, 0,0 );" class="span12"  runat="server" MaxLength="2" meta:resourcekey="value_biocide_time_day5_third_minResource1" ></asp:textbox>
                        </div>
                    </div>
	   
                 <!--  SCELTA AM-PM  -->
<asp:PlaceHolder id="enable_ampm_day5_third" runat="server">
                <h5 style="padding-top:10px"><asp:literal ID = "Literal183"  text="AM/PM" runat="server" meta:resourcekey="Literal183Resource1"></asp:literal></h5>
                <asp:radiobutton ID="am_day5_third" style="margin: 5px 10px 10px 0px;" runat="server"  GroupName="GROUP20" meta:resourcekey="am_day5_thirdResource1"></asp:radiobutton>
                <asp:literal runat="server" text ="AM" meta:resourcekey="LiteralResource1"></asp:literal>
                <asp:radiobutton ID="pm_day5_third" style="margin: 5px 10px 10px 0px;" runat="server"  GroupName="GROUP20" meta:resourcekey="pm_day5_thirdResource1"></asp:radiobutton>
                <asp:literal runat="server" text ="PM" meta:resourcekey="LiteralResource1"></asp:literal>				
</asp:PlaceHolder>
              </div>
    		
</div>
				<!-- fine riga -->


 <!-------------------------FINE TERZO INTERVENTO ---------------------->




    <!-------------------------QUARTO INTERVENTO ---------------------->


 <!-- riga -->
                <div class="row-fluid">
               	<div class="span3">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal186" runat="server" meta:resourcekey="Literal186Resource1"></asp:literal></h5>
                    <asp:checkbox ID="biocide_day5_fourth" runat="server" meta:resourcekey="biocide_day5_fourthResource1"></asp:checkbox>
                    <asp:literal runat="server" text ="Fourth" meta:resourcekey="LiteralResource13"></asp:literal>
                </div>
                </div>
                 <!-- fine riga -->
               <!-- riga -->
<div id ="enable_biocide_day5_fourth">
    
    <!-- IMPOSTAZIONE INTERVALLO DI TEMPO DELL'INTERVENTO -->
          
                <div class="row-fluid">
               	<div class="span2">
                       <div id="riga_biocide_count_day5_fourth_hr" class="control-group">
                                <h5 style="padding-top:10px"><asp:literal ID = "Literal188"  text="Counter Hour" runat="server" meta:resourcekey="Literal188Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_biocide_count_day5_fourth_hr" onblur="javascript: Changed_channel( 'value_biocide_count_day5_fourth_hr','riga_biocide_count_day5_fourth_hr',99, 0,0 );" class="span12"  runat="server" MaxLength="2" meta:resourcekey="value_biocide_count_day5_fourth_hrResource1" ></asp:textbox>
                </div>
                       </div>

                    <div class="span2">
                       <div id="riga_biocide_count_day5_fourth_min" class="control-group">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal189"  text="Counter Minute" runat="server" meta:resourcekey="Literal189Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_biocide_count_day5_fourth_min" onblur="javascript: Changed_channel( 'value_biocide_count_day5_fourth_min','riga_biocide_count_day5_fourth_min',59, 0,0 );" class="span12"  runat="server" MaxLength="2" meta:resourcekey="value_biocide_count_day5_fourth_minResource1" ></asp:textbox>
                </div>
                       </div>					   
                </div>

       <!----- IMPOSTAZIONE DELL'ORARIO ----->


            <div class="row-fluid">
               	<div class="span2">
                       <div id="riga_biocide_time_day5_fourth_hr" class="control-group">
                                <h5 style="padding-top:10px"><asp:literal ID = "Literal190"  text="Time Hour" runat="server" meta:resourcekey="Literal190Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_biocide_time_day5_fourth_hr" onblur="javascript: Changed_channel( 'value_biocide_time_day5_fourth_hr','riga_biocide_time_day5_fourth_hr',99, 0,0 );" class="span12"  runat="server" MaxLength="2" meta:resourcekey="value_biocide_time_day5_fourth_hrResource1" ></asp:textbox>
                        </div>
                 </div>

                    <div class="span2">
                       <div id="riga_biocide_time_day5_fourth_min" class="control-group">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal191"  text="Time Minute" runat="server" meta:resourcekey="Literal191Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_biocide_time_day5_fourth_min" onblur="javascript: Changed_channel( 'value_biocide_time_day5_fourth_min','riga_biocide_time_day5_fourth_min',59, 0,0 );" class="span12"  runat="server" MaxLength="2" meta:resourcekey="value_biocide_time_day5_fourth_minResource1" ></asp:textbox>
                        </div>
                    </div>
	   
                 <!--  SCELTA AM-PM  -->
<asp:PlaceHolder id="enable_ampm_day5_fourth" runat="server">
                <h5 style="padding-top:10px"><asp:literal ID = "Literal192"  text="AM/PM" runat="server" meta:resourcekey="Literal192Resource1"></asp:literal></h5>
                <asp:radiobutton ID="am_day5_fourth" style="margin: 5px 10px 10px 0px;" runat="server"  GroupName="GROUP21" meta:resourcekey="am_day5_fourthResource1"></asp:radiobutton>
                <asp:literal runat="server" text ="AM" meta:resourcekey="LiteralResource1"></asp:literal>
                <asp:radiobutton ID="pm_day5_fourth" style="margin: 5px 10px 10px 0px;" runat="server"  GroupName="GROUP21" meta:resourcekey="pm_day5_fourthResource1"></asp:radiobutton>
                <asp:literal runat="server" text ="PM" meta:resourcekey="LiteralResource1"></asp:literal>				
</asp:PlaceHolder>
              </div>

				
</div>


     <!-------------------------FINE QUINTO INTERVENTO ---------------------->

				<!-- fine riga -->

                    </div>
                    </asp:placeholder>
                </div>
<!-- tab 6 stop-->




<!--------------------------------------------------------------->
<!-------------------------INIZIO GIORNO 6 --------------------- >
<!--------------------------------------------------------------->




            <!-- tab 7 start-->
			<div class="tab-pane" id="tab_tower_sp7_7">
                <asp:placeholder runat="server" ID="day6_enable">
                <div  class="box-generic">



 <!-------------------------PRIMO INTERVENTO ---------------------->

                                 <!-- riga -->
                <div class="row-fluid">
               	<div class="span3">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal196"  text="Biocide2 day6" runat="server" meta:resourcekey="Literal196Resource1"></asp:literal></h5>
                    <asp:checkbox ID="biocide_day6_first" runat="server" meta:resourcekey="biocide_day6_firstResource1"></asp:checkbox>
                    <asp:literal runat="server" text ="First" meta:resourcekey="LiteralResource17"></asp:literal>
                </div>
                </div>
                 <!-- fine riga -->
                                <!-- riga -->
<div id ="enable_biocide_day6_first">

      <!-- IMPOSTAZIONE INTERVALLO DI TEMPO DELL'INTERVENTO -->

                <div class="row-fluid">
               	<div class="span2">
                       <div id="riga_biocide_count_day6_first_hr" class="control-group">
                                <h5 style="padding-top:10px"><asp:literal ID = "Literal198"  text="Counter Hour" runat="server" meta:resourcekey="Literal198Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_biocide_count_day6_first_hr" onblur="javascript: Changed_channel( 'value_biocide_count_day6_first_hr','riga_biocide_count_day6_first_hr',99, 0,0 );" class="span12"  runat="server" MaxLength="2" meta:resourcekey="riga_biocide_count_day6_first_hrResource1" ></asp:textbox>
                </div>
                       </div>

                    <div class="span2">
                       <div id="riga_biocide_count_day6_first_min" class="control-group">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal199"  text="Counter Minute" runat="server" meta:resourcekey="Literal199Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_biocide_count_day6_first_min" onblur="javascript: Changed_channel( 'value_biocide_count_day6_first_min','riga_biocide_count_day6_first_min',59, 0,0 );" class="span12"  runat="server" MaxLength="2" meta:resourcekey="value_biocide_count_day6_first_minResource1" ></asp:textbox>
                </div>
                       </div>
				   
                </div>


    <!----- IMPOSTAZIONE DELL'ORARIO ----->


            <div class="row-fluid">
               	<div class="span2">
                       <div id="riga_biocide_time_day6_first_hr" class="control-group">
                                <h5 style="padding-top:10px"><asp:literal ID = "Literal200"  text="Time Hour" runat="server" meta:resourcekey="Literal200Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_biocide_time_day6_first_hr" onblur="javascript: Changed_channel( 'value_biocide_time_day6_first_hr','riga_biocide_time_day6_first_hr',99, 0,0 );" class="span12"  runat="server" MaxLength="2" meta:resourcekey="value_biocide_time_day6_first_hrResource1" ></asp:textbox>
                    </div>
                </div>

                    <div class="span2">
                       <div id="riga_biocide_time_day6_first_min" class="control-group">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal201"  text="Time Minute" runat="server" meta:resourcekey="Literal201Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_biocide_time_day6_first_min" onblur="javascript: Changed_channel( 'value_biocide_time_day6_first_min','riga_biocide_time_day6_first_min',59, 0,0 );" class="span12"  runat="server" MaxLength="2" meta:resourcekey="value_biocide_time_day6_first_minResource1" ></asp:textbox>
                </div>
                       </div>
	   
                 <!--  SCELTA AM-PM  -->
<asp:PlaceHolder id="enable_ampm_day6_first" runat="server">
                <h5 style="padding-top:10px"><asp:literal ID = "Literal202"  text="AM/PM" runat="server" meta:resourcekey="Literal202Resource1"></asp:literal></h5>
                <asp:radiobutton ID="am_day6_first" style="margin: 5px 10px 10px 0px;" runat="server"  GroupName="GROUP22" meta:resourcekey="am_day6_firstResource1"></asp:radiobutton>
                <asp:literal runat="server" text ="AM" meta:resourcekey="LiteralResource1"></asp:literal>
                <asp:radiobutton ID="pm_day6_first" style="margin: 5px 10px 10px 0px;" runat="server"  GroupName="GROUP22" meta:resourcekey="pm_day6_firstResource1"></asp:radiobutton>
                <asp:literal runat="server" text ="PM" meta:resourcekey="LiteralResource1"></asp:literal>				
</asp:PlaceHolder>
              </div>
</div>
                 <!-- fine riga -->


   <!-------------------------FINE PRIMO INTERVENTO ---------------------->


  <!-------------------------SECONDO INTERVENTO ---------------------->


 <!-- riga -->
                <div class="row-fluid">
               	<div class="span3">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal205" runat="server" meta:resourcekey="Literal205Resource1"></asp:literal></h5>
                    <asp:checkbox ID="biocide_day6_second" runat="server" meta:resourcekey="biocide_day6_secondResource1"></asp:checkbox>
                    <asp:literal runat="server" text ="Second" meta:resourcekey="LiteralResource11"></asp:literal>
                </div>
                </div>
                 <!-- fine riga -->
                                <!-- riga -->
<div id ="enable_biocide_day6_second">
                <div class="row-fluid">
               	<div class="span2">
                       <div id="riga_biocide_count_day6_second_hr" class="control-group">
                                <h5 style="padding-top:10px"><asp:literal ID = "Literal207"  text="Counter Hour" runat="server" meta:resourcekey="Literal207Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_biocide_count_day6_second_hr" onblur="javascript: Changed_channel( 'value_biocide_count_day6_second_hr','riga_biocide_count_day6_second_hr',99, 0,0 );" class="span12"  runat="server" MaxLength="2" meta:resourcekey="value_biocide_count_day6_second_hrResource1" ></asp:textbox>
                </div>
                       </div>

                    <div class="span2">
                       <div id="riga_biocide_count_day6_second_min" class="control-group">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal208"  text="Counter Minute" runat="server" meta:resourcekey="Literal208Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_biocide_count_day6_second_min" onblur="javascript: Changed_channel( 'value_biocide_count_day6_second_min','riga_biocide_count_day6_second_min',59, 0,0 );" class="span12"  runat="server" MaxLength="2" meta:resourcekey="value_biocide_count_day6_second_minResource1" ></asp:textbox>
                </div>
                       </div>
				   
                </div>
			 <!----- IMPOSTAZIONE DELL'ORARIO ----->


            <div class="row-fluid">
               	<div class="span2">
                       <div id="riga_biocide_time_day6_second_hr" class="control-group">
                                <h5 style="padding-top:10px"><asp:literal ID = "Literal209"  text="Time Hour" runat="server" meta:resourcekey="Literal209Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_biocide_time_day6_second_hr" onblur="javascript: Changed_channel( 'value_biocide_time_day6_second_hr','riga_biocide_time_day6_second_hr',99, 0,0 );" class="span12"  runat="server" MaxLength="2" meta:resourcekey="value_biocide_time_day6_second_hrResource1" ></asp:textbox>
                </div>
                       </div>

                    <div class="span2">
                       <div id="riga_biocide_time_day6_second_min" class="control-group">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal210"  text="Time Minute" runat="server" meta:resourcekey="Literal210Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_biocide_time_day6_second_min" onblur="javascript: Changed_channel( 'value_biocide_time_day6_second_min','riga_biocide_time_day6_second_min',59, 0,0 );" class="span12"  runat="server" MaxLength="2" meta:resourcekey="value_biocide_time_day6_second_minResource1" ></asp:textbox>
                        </div>
                   </div>
	   
                 <!--  SCELTA AM-PM  -->
<asp:PlaceHolder id="enable_ampm_day6_second" runat="server">
                <h5 style="padding-top:10px"><asp:literal ID = "Literal211"  text="AM/PM" runat="server" meta:resourcekey="Literal211Resource1"></asp:literal></h5>
                <asp:radiobutton ID="am_day6_second" style="margin: 5px 10px 10px 0px;" runat="server"  GroupName="GROUP23" meta:resourcekey="am_day6_secondResource1"></asp:radiobutton>
                <asp:literal runat="server" text ="AM" meta:resourcekey="LiteralResource1"></asp:literal>
                <asp:radiobutton ID="pm_day6_second" style="margin: 5px 10px 10px 0px;" runat="server"  GroupName="GROUP23" meta:resourcekey="pm_day6_secondResource1"></asp:radiobutton>
                <asp:literal runat="server" text ="PM" meta:resourcekey="LiteralResource1"></asp:literal>				
</asp:PlaceHolder>
              </div>	
</div>
				<!-- fine riga -->

 <!-------------------------FINE SECONDO INTERVENTO ---------------------->




 <!-------------------------TERZO INTERVENTO ---------------------->


 <!-- riga -->
                <div class="row-fluid">
               	<div class="span3">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal214" runat="server" meta:resourcekey="Literal214Resource1"></asp:literal></h5>
                    <asp:checkbox ID="biocide_day6_third" runat="server" meta:resourcekey="biocide_day6_thirdResource1"></asp:checkbox>
                    <asp:literal runat="server" text ="Third" meta:resourcekey="LiteralResource12"></asp:literal>
                </div>
                </div>
                 <!-- fine riga -->


                 <!-- riga -->
<div id ="enable_biocide_day6_third">

    <!-- IMPOSTAZIONE INTERVALLO DI TEMPO DELL'INTERVENTO -->
          
          <div class="row-fluid">
               	<div class="span2">
                       <div id="riga_biocide_count_day6_third_hr" class="control-group">
                                <h5 style="padding-top:10px"><asp:literal ID = "Literal216"  text="Counter Hour" runat="server" meta:resourcekey="Literal216Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_biocide_count_day6_third_hr" onblur="javascript: Changed_channel( 'value_biocide_count_day6_third_hr','riga_biocide_count_day6_third_hr',99, 0,0 );" class="span12"  runat="server" MaxLength="2" meta:resourcekey="value_biocide_count_day6_third_hrResource1" ></asp:textbox>
                        </div>
                </div>

                    <div class="span2">
                       <div id="riga_biocide_count_day6_third_min" class="control-group">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal217"  text="Counter Minute" runat="server" meta:resourcekey="Literal217Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_biocide_count_day6_third_min" onblur="javascript: Changed_channel( 'value_biocide_count_day6_third_min','riga_biocide_count_day6_third_min',59, 0,0 );" class="span12"  runat="server" MaxLength="2" meta:resourcekey="value_biocide_count_day6_third_minResource1" ></asp:textbox>
                       </div>
                     </div>				   
                </div>
		
    <!----- IMPOSTAZIONE DELL'ORARIO ----->


            <div class="row-fluid">
               	<div class="span2">
                       <div id="riga_biocide_time_day6_third_hr" class="control-group">
                                <h5 style="padding-top:10px"><asp:literal ID = "Literal218"  text="Time Hour" runat="server" meta:resourcekey="Literal218Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_biocide_time_day6_third_hr" onblur="javascript: Changed_channel( 'value_biocide_time_day6_third_hr','riga_biocide_time_day6_third_hr',99, 0,0 );" class="span12"  runat="server" MaxLength="2" meta:resourcekey="value_biocide_time_day6_third_hrResource1" ></asp:textbox>
                        </div>
                 </div>

                    <div class="span2">
                       <div id="riga_biocide_time_day6_third_min" class="control-group">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal219"  text="Time Minute" runat="server" meta:resourcekey="Literal219Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_biocide_time_day6_third_min" onblur="javascript: Changed_channel( 'value_biocide_time_day6_third_min','riga_biocide_time_day6_third_min',59, 0,0 );" class="span12"  runat="server" MaxLength="2" meta:resourcekey="value_biocide_time_day6_third_minResource1" ></asp:textbox>
                        </div>
                    </div>
	   
                 <!--  SCELTA AM-PM  -->
<asp:PlaceHolder id="enable_ampm_day6_third" runat="server">
                <h5 style="padding-top:10px"><asp:literal ID = "Literal220"  text="AM/PM" runat="server" meta:resourcekey="Literal220Resource1"></asp:literal></h5>
                <asp:radiobutton ID="am_day6_third" style="margin: 5px 10px 10px 0px;" runat="server"  GroupName="GROUP24" meta:resourcekey="am_day6_thirdResource1"></asp:radiobutton>
                <asp:literal runat="server" text ="AM" meta:resourcekey="LiteralResource1"></asp:literal>
                <asp:radiobutton ID="pm_day6_third" style="margin: 5px 10px 10px 0px;" runat="server"  GroupName="GROUP24" meta:resourcekey="pm_day6_thirdResource1"></asp:radiobutton>
                <asp:literal runat="server" text ="PM" meta:resourcekey="LiteralResource1"></asp:literal>				
</asp:PlaceHolder>
              </div>
    		
</div>
				<!-- fine riga -->


 <!-------------------------FINE TERZO INTERVENTO ---------------------->




    <!-------------------------QUARTO INTERVENTO ---------------------->


 <!-- riga -->
                <div class="row-fluid">
               	<div class="span3">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal223" runat="server" meta:resourcekey="Literal223Resource1"></asp:literal></h5>
                    <asp:checkbox ID="biocide_day6_fourth" runat="server" meta:resourcekey="biocide_day6_fourthResource1"></asp:checkbox>
                    <asp:literal runat="server" text ="Fourth" meta:resourcekey="LiteralResource13"></asp:literal>
                </div>
                </div>
                 <!-- fine riga -->
               <!-- riga -->
<div id ="enable_biocide_day6_fourth">
    
    <!-- IMPOSTAZIONE INTERVALLO DI TEMPO DELL'INTERVENTO -->
          
                <div class="row-fluid">
               	<div class="span2">
                       <div id="riga_biocide_count_day6_fourth_hr" class="control-group">
                                <h5 style="padding-top:10px"><asp:literal ID = "Literal225"  text="Counter Hour" runat="server" meta:resourcekey="Literal225Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_biocide_count_day6_fourth_hr" onblur="javascript: Changed_channel( 'value_biocide_count_day6_fourth_hr','riga_biocide_count_day6_fourth_hr',99, 0,0 );" class="span12"  runat="server" MaxLength="2" meta:resourcekey="value_biocide_count_day6_fourth_hrResource1" ></asp:textbox>
                </div>
                       </div>

                    <div class="span2">
                       <div id="riga_biocide_count_day6_fourth_min" class="control-group">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal226"  text="Counter Minute" runat="server" meta:resourcekey="Literal226Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_biocide_count_day6_fourth_min" onblur="javascript: Changed_channel( 'value_biocide_count_day6_fourth_min','riga_biocide_count_day6_fourth_min',59, 0,0 );" class="span12"  runat="server" MaxLength="2" meta:resourcekey="value_biocide_count_day6_fourth_minResource1" ></asp:textbox>
                </div>
                       </div>					   
                </div>

       <!----- IMPOSTAZIONE DELL'ORARIO ----->


            <div class="row-fluid">
               	<div class="span2">
                       <div id="riga_biocide_time_day6_fourth_hr" class="control-group">
                                <h5 style="padding-top:10px"><asp:literal ID = "Literal227"  text="Time Hour" runat="server" meta:resourcekey="Literal227Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_biocide_time_day6_fourth_hr" onblur="javascript: Changed_channel( 'value_biocide_time_day6_fourth_hr','riga_biocide_time_day6_fourth_hr',99, 0,0 );" class="span12"  runat="server" MaxLength="2" meta:resourcekey="value_biocide_time_day6_fourth_hrResource1" ></asp:textbox>
                        </div>
                 </div>

                    <div class="span2">
                       <div id="riga_biocide_time_day6_fourth_min" class="control-group">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal228"  text="Time Minute" runat="server" meta:resourcekey="Literal228Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_biocide_time_day6_fourth_min" onblur="javascript: Changed_channel( 'value_biocide_time_day6_fourth_min','riga_biocide_time_day6_fourth_min',59, 0,0 );" class="span12"  runat="server" MaxLength="2" meta:resourcekey="value_biocide_time_day6_fourth_minResource1" ></asp:textbox>
                        </div>
                    </div>
	   
                 <!--  SCELTA AM-PM  -->
<asp:PlaceHolder id="enable_ampm_day6_fourth" runat="server">
                <h5 style="padding-top:10px"><asp:literal ID = "Literal229"  text="AM/PM" runat="server" meta:resourcekey="Literal229Resource1"></asp:literal></h5>
                <asp:radiobutton ID="am_day6_fourth" style="margin: 5px 10px 10px 0px;" runat="server"  GroupName="GROUP25" meta:resourcekey="am_day6_fourthResource1"></asp:radiobutton>
                <asp:literal runat="server" text ="AM" meta:resourcekey="LiteralResource1"></asp:literal>
                <asp:radiobutton ID="pm_day6_fourth" style="margin: 5px 10px 10px 0px;" runat="server"  GroupName="GROUP25" meta:resourcekey="pm_day6_fourthResource1"></asp:radiobutton>
                <asp:literal runat="server" text ="PM" meta:resourcekey="LiteralResource1"></asp:literal>				
</asp:PlaceHolder>
              </div>

				
</div>


     <!-------------------------FINE QUARTO INTERVENTO ---------------------->

				<!-- fine riga -->

                    </div>
                    </asp:placeholder>
                </div>
<!-- tab 6 stop-->




<!--------------------------------------------------------------->
<!-------------------------INIZIO GIORNO 7 --------------------- >
<!--------------------------------------------------------------->




            <!-- tab 7 start-->
			<div class="tab-pane" id="tab_tower_sp8_8">
                <asp:placeholder runat="server" ID="day7_enable">
                <div  class="box-generic">



 <!-------------------------PRIMO INTERVENTO ---------------------->

                                 <!-- riga -->
                <div class="row-fluid">
               	<div class="span3">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal233"  text="Biocide2 day7" runat="server" meta:resourcekey="Literal233Resource1"></asp:literal></h5>
                    <asp:checkbox ID="biocide_day7_first" runat="server" meta:resourcekey="biocide_day7_firstResource1"></asp:checkbox>
                    <asp:literal runat="server" text ="First" meta:resourcekey="LiteralResource17"></asp:literal>
                </div>
                </div>
                 <!-- fine riga -->
                                <!-- riga -->
<div id ="enable_biocide_day7_first">

      <!-- IMPOSTAZIONE INTERVALLO DI TEMPO DELL'INTERVENTO -->

                <div class="row-fluid">
               	<div class="span2">
                       <div id="riga_biocide_count_day7_first_hr" class="control-group">
                                <h5 style="padding-top:10px"><asp:literal ID = "Literal235"  text="Counter Hour" runat="server" meta:resourcekey="Literal235Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_biocide_count_day7_first_hr" onblur="javascript: Changed_channel( 'value_biocide_count_day7_first_hr','riga_biocide_count_day7_first_hr',99, 0,0 );" class="span12"  runat="server" MaxLength="2" meta:resourcekey="riga_biocide_count_day7_first_hrResource1" ></asp:textbox>
                </div>
                       </div>

                    <div class="span2">
                       <div id="riga_biocide_count_day7_first_min" class="control-group">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal236"  text="Counter Minute" runat="server" meta:resourcekey="Literal236Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_biocide_count_day7_first_min" onblur="javascript: Changed_channel( 'value_biocide_count_day7_first_min','riga_biocide_count_day7_first_min',59, 0,0 );" class="span12"  runat="server" MaxLength="2" meta:resourcekey="value_biocide_count_day7_first_minResource1" ></asp:textbox>
                </div>
                       </div>
				   
                </div>


    <!----- IMPOSTAZIONE DELL'ORARIO ----->


            <div class="row-fluid">
               	<div class="span2">
                       <div id="riga_biocide_time_day7_first_hr" class="control-group">
                                <h5 style="padding-top:10px"><asp:literal ID = "Literal237"  text="Time Hour" runat="server" meta:resourcekey="Literal237Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_biocide_time_day7_first_hr" onblur="javascript: Changed_channel( 'value_biocide_time_day7_first_hr','riga_biocide_time_day7_first_hr',99, 0,0 );" class="span12"  runat="server" MaxLength="2" meta:resourcekey="value_biocide_time_day7_first_hrResource1" ></asp:textbox>
                    </div>
                </div>

                    <div class="span2">
                       <div id="riga_biocide_time_day7_first_min" class="control-group">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal238"  text="Time Minute" runat="server" meta:resourcekey="Literal238Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_biocide_time_day7_first_min" onblur="javascript: Changed_channel( 'value_biocide_time_day7_first_min','riga_biocide_time_day7_first_min',59, 0,0 );" class="span12"  runat="server" MaxLength="2" meta:resourcekey="value_biocide_time_day7_first_minResource1" ></asp:textbox>
                </div>
                       </div>
	   
                 <!--  SCELTA AM-PM  -->
<asp:PlaceHolder id="enable_ampm_day7_first" runat="server">
                <h5 style="padding-top:10px"><asp:literal ID = "Literal239"  text="AM/PM" runat="server" meta:resourcekey="Literal239Resource1"></asp:literal></h5>
                <asp:radiobutton ID="am_day7_first" style="margin: 5px 10px 10px 0px;" runat="server"  GroupName="GROUP26" meta:resourcekey="am_day7_firstResource1"></asp:radiobutton>
                <asp:literal runat="server" text ="AM" meta:resourcekey="LiteralResource1"></asp:literal>
                <asp:radiobutton ID="pm_day7_first" style="margin: 5px 10px 10px 0px;" runat="server"  GroupName="GROUP26" meta:resourcekey="pm_day7_firstResource1"></asp:radiobutton>
                <asp:literal runat="server" text ="PM" meta:resourcekey="LiteralResource1"></asp:literal>				
</asp:PlaceHolder>
              </div>
</div>
                 <!-- fine riga -->


   <!-------------------------FINE PRIMO INTERVENTO ---------------------->


  <!-------------------------SECONDO INTERVENTO ---------------------->


 <!-- riga -->
                <div class="row-fluid">
               	<div class="span3">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal242" runat="server" meta:resourcekey="Literal242Resource1"></asp:literal></h5>
                    <asp:checkbox ID="biocide_day7_second" runat="server" meta:resourcekey="biocide_day7_secondResource1"></asp:checkbox>
                    <asp:literal runat="server" text ="Second" meta:resourcekey="LiteralResource11"></asp:literal>
                </div>
                </div>
                 <!-- fine riga -->
                                <!-- riga -->
<div id ="enable_biocide_day7_second">
                <div class="row-fluid">
               	<div class="span2">
                       <div id="riga_biocide_count_day7_second_hr" class="control-group">
                                <h5 style="padding-top:10px"><asp:literal ID = "Literal244"  text="Counter Hour" runat="server" meta:resourcekey="Literal244Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_biocide_count_day7_second_hr" onblur="javascript: Changed_channel( 'value_biocide_count_day7_second_hr','riga_biocide_count_day7_second_hr',99, 0,0 );" class="span12"  runat="server" MaxLength="2" meta:resourcekey="value_biocide_count_day7_second_hrResource1" ></asp:textbox>
                </div>
                       </div>

                    <div class="span2">
                       <div id="riga_biocide_count_day7_second_min" class="control-group">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal245"  text="Counter Minute" runat="server" meta:resourcekey="Literal245Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_biocide_count_day7_second_min" onblur="javascript: Changed_channel( 'value_biocide_count_day7_second_min','riga_biocide_count_day7_second_min',59, 0,0 );" class="span12"  runat="server" MaxLength="2" meta:resourcekey="value_biocide_count_day7_second_minResource1" ></asp:textbox>
                </div>
                       </div>
				   
                </div>
			 <!----- IMPOSTAZIONE DELL'ORARIO ----->


            <div class="row-fluid">
               	<div class="span2">
                       <div id="riga_biocide_time_day7_second_hr" class="control-group">
                                <h5 style="padding-top:10px"><asp:literal ID = "Literal246"  text="Time Hour" runat="server" meta:resourcekey="Literal246Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_biocide_time_day7_second_hr" onblur="javascript: Changed_channel( 'value_biocide_time_day7_second_hr','riga_biocide_time_day7_second_hr',99, 0,0 );" class="span12"  runat="server" MaxLength="2" meta:resourcekey="value_biocide_time_day7_second_hrResource1" ></asp:textbox>
                </div>
                       </div>

                    <div class="span2">
                       <div id="riga_biocide_time_day7_second_min" class="control-group">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal247"  text="Time Minute" runat="server" meta:resourcekey="Literal247Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_biocide_time_day7_second_min" onblur="javascript: Changed_channel( 'value_biocide_time_day7_second_min','riga_biocide_time_day7_second_min',59, 0,0 );" class="span12"  runat="server" MaxLength="2" meta:resourcekey="value_biocide_time_day7_second_minResource1" ></asp:textbox>
                        </div>
                   </div>
	   
                 <!--  SCELTA AM-PM  -->
<asp:PlaceHolder id="enable_ampm_day7_second" runat="server">
                <h5 style="padding-top:10px"><asp:literal ID = "Literal248"  text="AM/PM" runat="server" meta:resourcekey="Literal248Resource1"></asp:literal></h5>
                <asp:radiobutton ID="am_day7_second" style="margin: 5px 10px 10px 0px;" runat="server"  GroupName="GROUP27" meta:resourcekey="am_day7_secondResource1"></asp:radiobutton>
                <asp:literal runat="server" text ="AM" meta:resourcekey="LiteralResource1"></asp:literal>
                <asp:radiobutton ID="pm_day7_second" style="margin: 5px 10px 10px 0px;" runat="server"  GroupName="GROUP27" meta:resourcekey="pm_day7_secondResource1"></asp:radiobutton>
                <asp:literal runat="server" text ="PM" meta:resourcekey="LiteralResource1"></asp:literal>				
</asp:PlaceHolder>
              </div>	
</div>
				<!-- fine riga -->

 <!-------------------------FINE SECONDO INTERVENTO ---------------------->




 <!-------------------------TERZO INTERVENTO ---------------------->


 <!-- riga -->
                <div class="row-fluid">
               	<div class="span3">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal251" runat="server" meta:resourcekey="Literal251Resource1"></asp:literal></h5>
                    <asp:checkbox ID="biocide_day7_third" runat="server" meta:resourcekey="biocide_day7_thirdResource1"></asp:checkbox>
                    <asp:literal runat="server" text ="Third" meta:resourcekey="LiteralResource12"></asp:literal>
                </div>
                </div>
                 <!-- fine riga -->


                 <!-- riga -->
<div id ="enable_biocide_day7_third">

    <!-- IMPOSTAZIONE INTERVALLO DI TEMPO DELL'INTERVENTO -->
          
          <div class="row-fluid">
               	<div class="span2">
                       <div id="riga_biocide_count_day7_third_hr" class="control-group">
                                <h5 style="padding-top:10px"><asp:literal ID = "Literal253"  text="Counter Hour" runat="server" meta:resourcekey="Literal253Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_biocide_count_day7_third_hr" onblur="javascript: Changed_channel( 'value_biocide_count_day7_third_hr','riga_biocide_count_day7_third_hr',99, 0,0 );" class="span12"  runat="server" MaxLength="2" meta:resourcekey="value_biocide_count_day7_third_hrResource1" ></asp:textbox>
                        </div>
                </div>

                    <div class="span2">
                       <div id="riga_biocide_count_day7_third_min" class="control-group">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal254"  text="Counter Minute" runat="server" meta:resourcekey="Literal254Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_biocide_count_day7_third_min" onblur="javascript: Changed_channel( 'value_biocide_count_day7_third_min','riga_biocide_count_day7_third_min',59, 0,0 );" class="span12"  runat="server" MaxLength="2" meta:resourcekey="value_biocide_count_day7_third_minResource1" ></asp:textbox>
                       </div>
                     </div>				   
                </div>
		
    <!----- IMPOSTAZIONE DELL'ORARIO ----->


            <div class="row-fluid">
               	<div class="span2">
                       <div id="riga_biocide_time_day7_third_hr" class="control-group">
                                <h5 style="padding-top:10px"><asp:literal ID = "Literal255"  text="Time Hour" runat="server" meta:resourcekey="Literal255Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_biocide_time_day7_third_hr" onblur="javascript: Changed_channel( 'value_biocide_time_day7_third_hr','riga_biocide_time_day7_third_hr',99, 0,0 );" class="span12"  runat="server" MaxLength="2" meta:resourcekey="value_biocide_time_day7_third_hrResource1" ></asp:textbox>
                        </div>
                 </div>

                    <div class="span2">
                       <div id="riga_biocide_time_day7_third_min" class="control-group">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal256"  text="Time Minute" runat="server" meta:resourcekey="Literal256Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_biocide_time_day7_third_min" onblur="javascript: Changed_channel( 'value_biocide_time_day7_third_min','riga_biocide_time_day7_third_min',59, 0,0 );" class="span12"  runat="server" MaxLength="2" meta:resourcekey="value_biocide_time_day7_third_minResource1" ></asp:textbox>
                        </div>
                    </div>
	   
                 <!--  SCELTA AM-PM  -->
<asp:PlaceHolder id="enable_ampm_day7_third" runat="server">
                <h5 style="padding-top:10px"><asp:literal ID = "Literal257"  text="AM/PM" runat="server" meta:resourcekey="Literal257Resource1"></asp:literal></h5>
                <asp:radiobutton ID="am_day7_third" style="margin: 5px 10px 10px 0px;" runat="server"  GroupName="GROUP28" meta:resourcekey="am_day7_thirdResource1"></asp:radiobutton>
                <asp:literal runat="server" text ="AM" meta:resourcekey="LiteralResource1"></asp:literal>
                <asp:radiobutton ID="pm_day7_third" style="margin: 5px 10px 10px 0px;" runat="server"  GroupName="GROUP28" meta:resourcekey="pm_day7_thirdResource1"></asp:radiobutton>
                <asp:literal runat="server" text ="PM" meta:resourcekey="LiteralResource1"></asp:literal>				
</asp:PlaceHolder>
              </div>
    		
</div>
				<!-- fine riga -->


 <!-------------------------FINE TERZO INTERVENTO ---------------------->




    <!-------------------------QUARTO INTERVENTO ---------------------->


 <!-- riga -->
                <div class="row-fluid">
               	<div class="span3">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal260" runat="server" meta:resourcekey="Literal260Resource1"></asp:literal></h5>
                    <asp:checkbox ID="biocide_day7_fourth" runat="server" meta:resourcekey="biocide_day7_fourthResource1"></asp:checkbox>
                    <asp:literal runat="server" text ="Fourth" meta:resourcekey="LiteralResource13"></asp:literal>
                </div>
                </div>
                 <!-- fine riga -->
               <!-- riga -->
<div id ="enable_biocide_day7_fourth">
    
    <!-- IMPOSTAZIONE INTERVALLO DI TEMPO DELL'INTERVENTO -->
          
                <div class="row-fluid">
               	<div class="span2">
                       <div id="riga_biocide_count_day7_fourth_hr" class="control-group">
                                <h5 style="padding-top:10px"><asp:literal ID = "Literal262"  text="Counter Hour" runat="server" meta:resourcekey="Literal262Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_biocide_count_day7_fourth_hr" onblur="javascript: Changed_channel( 'value_biocide_count_day7_fourth_hr','riga_biocide_count_day7_fourth_hr',99, 0,0 );" class="span12"  runat="server" MaxLength="2" meta:resourcekey="value_biocide_count_day7_fourth_hrResource1" ></asp:textbox>
                </div>
                       </div>

                    <div class="span2">
                       <div id="riga_biocide_count_day7_fourth_min" class="control-group">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal263"  text="Counter Minute" runat="server" meta:resourcekey="Literal263Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_biocide_count_day7_fourth_min" onblur="javascript: Changed_channel( 'value_biocide_count_day7_fourth_min','riga_biocide_count_day7_fourth_min',59, 0,0 );" class="span12"  runat="server" MaxLength="2" meta:resourcekey="value_biocide_count_day7_fourth_minResource1" ></asp:textbox>
                </div>
                       </div>					   
                </div>

       <!----- IMPOSTAZIONE DELL'ORARIO ----->


            <div class="row-fluid">
               	<div class="span2">
                       <div id="riga_biocide_time_day7_fourth_hr" class="control-group">
                                <h5 style="padding-top:10px"><asp:literal ID = "Literal264"  text="Time Hour" runat="server" meta:resourcekey="Literal264Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_biocide_time_day7_fourth_hr" onblur="javascript: Changed_channel( 'value_biocide_time_day7_fourth_hr','riga_biocide_time_day7_fourth_hr',99, 0,0 );" class="span12"  runat="server" MaxLength="2" meta:resourcekey="value_biocide_time_day7_fourth_hrResource1" ></asp:textbox>
                        </div>
                 </div>

                    <div class="span2">
                       <div id="riga_biocide_time_day7_fourth_min" class="control-group">
              <h5 style="padding-top:10px"><asp:literal ID = "Literal265"  text="Time Minute" runat="server" meta:resourcekey="Literal265Resource1"></asp:literal></h5>
                       <asp:textbox ID="value_biocide_time_day7_fourth_min" onblur="javascript: Changed_channel( 'value_biocide_time_day7_fourth_min','riga_biocide_time_day7_fourth_min',59, 0,0 );" class="span12"  runat="server" MaxLength="2" meta:resourcekey="value_biocide_time_day7_fourth_minResource1" ></asp:textbox>
                        </div>
                    </div>
	   
                 <!--  SCELTA AM-PM  -->
<asp:PlaceHolder id="enable_ampm_day7_fourth" runat="server">
                <h5 style="padding-top:10px"><asp:literal ID = "Literal266"  text="AM/PM" runat="server" meta:resourcekey="Literal266Resource1"></asp:literal></h5>
                <asp:radiobutton ID="am_day7_fourth" style="margin: 5px 10px 10px 0px;" runat="server"  GroupName="GROUP26" meta:resourcekey="am_day7_fourthResource1"></asp:radiobutton>
                <asp:literal runat="server" text ="AM" meta:resourcekey="LiteralResource1"></asp:literal>
                <asp:radiobutton ID="pm_day7_fourth" style="margin: 5px 10px 10px 0px;" runat="server"  GroupName="GROUP26" meta:resourcekey="pm_day7_fourthResource1"></asp:radiobutton>
                <asp:literal runat="server" text ="PM" meta:resourcekey="LiteralResource1"></asp:literal>				
</asp:PlaceHolder>
              </div>

				
</div>


     <!-------------------------FINE QUARTO INTERVENTO ---------------------->

				<!-- fine riga -->

                    </div>
                    </asp:placeholder>
                </div>
<!-- tab 7 stop-->

            </div>
            <div id="salva" class="btn-primary">
                   <b class="btn-primary btn-icon glyphicons ok"><asp:button runat="server" ID="save_biocide_ldtower_new" class="btn-primary" data-layout="center" data-type="confirm" data-toggle="notyfy" text="Salva e carica i dati" Font-Bold="True" meta:resourcekey="save_biocide_ldtower_newResource1" /><i></i></b>

        </div>
    </div>           
    </div> 


    <script type="text/javascript" src="LDTower/validator_biocide_ldt.js"></script>
       <script src="theme/scripts/demo/calendar_new.js"></script>
    <link href="bootstrap/css/jquery-ui-timepicker-addon.css" rel="stylesheet" />
                <script type="text/javascript" src="common/validator_general_notify.js"></script>
<script src="theme/scripts/demo/notifications.js"></script>

    </form>


<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MainNew.Master" CodeBehind="M0201.aspx.vb" Inherits="ermes_web_20.M0201" %>
<%@ MasterType VirtualPath="~/MainNew.Master"%>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<link href="../chart/js/css/dataTables.tableTools.css" rel="stylesheet" />
<link href="../chart/js/css/jquery.dataTables.css" rel="stylesheet" />
<link href="../chart/localCent/buttons.dataTables.min.css?v=1.10" rel="stylesheet" />
<!--
    <link href="https://cdn.datatables.net/1.11.3/css/jquery.dataTables.min.css" rel="stylesheet" />
    <link href="https://cdn.datatables.net/buttons/2.0.1/css/buttons.dataTables.min.css" rel="stylesheet" />
    --->

<script type="text/javascript" src="../chart/localCent/jquery.dataTables.js"></script>
<script type="text/javascript" src="../chart/localCent/jquery.dataTables.min.js"></script>
<script type="text/javascript" src="../chart/localCent/dataTables.buttons.min.js"></script>
<script type="text/javascript" src="../chart/localCent/buttons.flash.min.js"></script>
<script type="text/javascript" src="../chart/localCent/jszip.min.js"></script>
<script type="text/javascript" src="../chart/localCent/pdfmake.min.js"></script>
<script type="text/javascript" src="../chart/localCent/vfs_fonts.js"></script>
<script type="text/javascript" src="../chart/localCent/buttons.html5.min.js"></script>
<script type="text/javascript" src="../chart/localCent/buttons.print.min.js"></script>
    
<!--
<script type="text/javascript" src="https://code.jquery.com/jquery-3.5.1.js"></script>
<script type="text/javascript" src="https://cdn.datatables.net/1.11.3/js/jquery.dataTables.min.js"></script>
<script type="text/javascript" src="https://cdn.datatables.net/buttons/2.0.1/js/dataTables.buttons.min.js"></script>
<script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/jszip/3.1.3/jszip.min.js"></script>
<script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/pdfmake/0.1.53/pdfmake.min.js"></script>
<script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/pdfmake/0.1.53/vfs_fonts.js"></script>
<script type="text/javascript" src="https://cdn.datatables.net/buttons/2.0.1/js/buttons.html5.min.js"></script>
<script type="text/javascript" src="https://cdn.datatables.net/buttons/2.0.1/js/buttons.print.min.js"></script>
    -->
    <div class="content-wrapper">
      <div class="content">                
          <div class="row">
              <div class="col-xl-12">
                  <div class="card card-default">
                      <div class="card-header">
                              <h2>
                                  <asp:Literal ID="plantName" runat="server"></asp:Literal></h2>
                       </div>
   					   <!-- DATI -->
					  <div class="card-body">
                          <h3 id='modalitaLavoro_SN'></h3><h2 id='portata_SN'><span class="little"></span></h2> <br/> 
                          <div class="list-group-item list-group-item-action " id='valore1_SN' data-toggle="tooltip" data-placement="top" title="" data-original-title="Tooltip on top"></div>
                          <div class="list-group-item list-group-item-action " id='valore2_SN' data-toggle="tooltip" data-placement="top" title="" data-original-title="Tooltip on top"></div>

                          <!-- <div class="list-group-item list-group-item-action " id='valore3_SN' data-toggle="tooltip" data-placement="top" title="" data-original-title="Tooltip on top"></div> -->
                          <!--
                            <div class="list-group-item list-group-item-action" id='valore1_SN' >0 <span class="badge badge-black badge-pill" tabindex="0" data-toggle="tooltip" title="PORTATA" > <i class="mdi mdi-information"></i></span></div>
                            <div class="list-group-item list-group-item-action" id='valore2_SN'>0 <span class="badge badge-black badge-pill" tabindex="0" data-toggle="tooltip" title="FREQUENZA">	 <i class="mdi mdi-signal-cellular-outline"></i></span></div>
                            <div class="list-group-item list-group-item-action" id='valore3_SN'>0 <span class="badge badge-black badge-pill" tabindex="0" data-toggle="tooltip" title="SLOW MODE">	 <i class="mdi mdi-eject"></i></span></div><br>
                              -->
                      </div>
   					   <!-- end DATI -->
					 <!-- SISTEMA NON CONNESSO 
                      <div id='statusNotConnection_SN' class="card-body pb-0">
                           <div class="alert alert-danger alert-icon" role="alert"><i class="mdi mdi-diameter-variant"></i> Not connected</div>
                      </div>
                         -->
				   <!--  END SISTEMA NON CONNESSO -->
                    <!-- SISTEMA  manutenzione -->
                     <div id='statusManutenzione_SN' class="card-body pb-0" style="display: none;">
                         <h3 data-translate="warningService"></h3>
                          <div class="list-group-item list-group-item-action " id='produzioneOre_SN' data-toggle="tooltip" data-placement="top" title="" data-original-title="Tooltip on top"></div>
                          <div class="list-group-item list-group-item-action " id='manutenzioneTra_SN' data-toggle="tooltip" data-placement="top" title="" data-original-title="Tooltip on top"></div>
                     </div>
                    <!-- end SISTEMA  manutenzione -->
				   <!-- SISTEMA  CONNESSO -->
					  <div id='statusConnection_SN' class="card-body pb-0" >
					  		<div class="alert alert-success alert-icon" role="alert"><i class="mdi mdi-checkbox-marked-outline"></i> Connected </div>
					  </div>	  
					<!-- SISTEMA  CONNESSO END -->
                    <!-- SISTEMA  STANDBY -->
					  <div id='statusStby_SN' class="card-body pb-0" style="display: none;">
					  		<div class="alert alert-light alert-icon black" role="alert"><i class="mdi mdi-power-standby"></i>Standby</div>
					  </div>
					<!-- SISTEMA  STANDBY END -->
                    <!-- RELEASE -->
					  <div id='swRealease_SN' class="card-body pb-0">
					 <span class="badge badge-secondary" data-translate="softwareRelease"  > </span>
                     <span class="badge badge-secondary" id="softwareReleaseNum"  ></span>
					  </div>
					<!-- END RELEASE -->
 				    <!-- INFO POMPA -->
					  <div class="row">
                          <!-- STATISTICHE -->
                          <div class="col-lg-6 col-xl-4 col-xxl-3">
							<div class="card card-default mt-7">
							  <div class="card-body text-center">
								  <div class="image mb-3 d-inline-flex mt-n8">
									<i class="mdi mdi-poll icon_plant"></i> 
								  </div>
								  <h5 class="card-title" data-translate="totalizzatori"></h5>
									 <div class="accordion accordion-header-border-bottom" id="accordionHeaderBorderBottom">
                                        <div class="card">
                                            <div class="card-header" id="headingBorderBottomOne">
                                                <h2 class="mb-0">
                                                    <button class="btn btn-link collapsed" type="button" data-toggle="collapse" data-target="#collapseBorderBottomOne" aria-expanded="false" aria-controls="collapseBorderBottomOne" data-translate="totIngresso">
                                                    </button>
                                                </h2>
                                            </div>
                                            <div id="collapseBorderBottomOne" class="collapse" aria-labelledby="headingBorderBottomOne"data-parent="#accordionHeaderBorderBottom">
                                                <div class="card-body">
		                                            <div class="alert alert-primary alert-outlined" role="alert">
    		                                            <span id="totaleIngresso"> 0mc </span><br>
  		                                            </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="card">
                                            <div class="card-header" id="headingBorderBottomTwo">
                                                <h2 class="mb-0">
                                                    <button class="btn btn-link collapsed" type="button" data-toggle="collapse" data-target="#collapseBorderBottomTwo" aria-expanded="false" aria-controls="collapseBorderBottomTwo" data-translate="totUscita">
                                                        
                                                    </button>
                                                </h2>
                                             </div>
                                             <div id="collapseBorderBottomTwo" class="collapse" aria-labelledby="headingBorderBottomTwo" data-parent="#accordionHeaderBorderBottom">
                                                <div class="card-body">
		                                            <div class="alert alert-primary alert-outlined" role="alert">
    		                                            <span id="totaleUscita">0mc</span><br>
  		                                            </div>
                                               </div>
                                            </div>
                                        </div>
                                    </div>
							        <div class="row justify-content-center">
								    </div>
							  </div>
							</div>
						  </div>
                          <!-- end STATISTICHE -->
                          <!-- ALLARMI -->
						  <div class="col-lg-6 col-xl-4 col-xxl-3">
							<div class="card card-default mt-7">
							  <div class="card-body text-center">
								  <div class="image mb-3 d-inline-flex mt-n8">
									<i class="mdi mdi-alert icon_plant red"></i> 
								  </div>
								  <h5 class="card-title" data-translate="allarmi"></h5>
								 <div class="row justify-content-center" id="prismaAlarmWarnigList">
								</div>
							  </div>
							</div>
						  </div>
						  <!-- END ALLARMI -->
                          <!-- RISERVA -->
						  <div class="col-lg-6 col-xl-4 col-xxl-3">
							<div class="card card-default mt-7">
							  <div class="card-body text-center">
								  <div class="image mb-3 d-inline-flex mt-n8">
									<i class="mdi mdi-circle-slice-1 icon_plant"></i> 
								  </div>
								  <h5 class="card-title" data-translate="outStatus"></h5>
									<div class="row justify-content-center" id="outStatusList">
                                        <!--
									    <div class="alert alert-primary alert-outlined" role="alert"><span id="prismaRiserva">0.000 L </span><br>
  		                                </div>
                                        -->
							        </div>
							    </div>
							  </div>
						  </div>
						  <!-- END RISERVA -->
                          <!-- PORTATA IST. CONTATORE -->
						  <div class="col-lg-6 col-xl-4 col-xxl-3">
							<div class="card card-default mt-7">
							  <div class="card-body text-center">
								  <div class="image mb-3 d-inline-flex mt-n8">
									<i class="mdi mdi-clock-start icon_plant"></i> 
								  </div>
								  <h5 class="card-title" data-translate="portataIstantanea"></h5>
									 <div class="accordion accordion-header-border-bottom" id="accordionHeaderBorderBottomPortata">
                                        <div class="card">
                                            <div class="card-header" id="headingBorderBottomOnePortata">
                                                <h2 class="mb-0">
                                                    <button class="btn btn-link collapsed" type="button" data-toggle="collapse" data-target="#collapseBorderBottomOnePortata" aria-expanded="false" aria-controls="collapseBorderBottomOnePortata" data-translate="totIngresso">
                                                    </button>
                                                </h2>
                                            </div>
                                            <div id="collapseBorderBottomOnePortata" class="collapse" aria-labelledby="headingBorderBottomOnePortata"data-parent="#accordionHeaderBorderBottomPortata">
                                                <div class="card-body">
		                                            <div class="alert alert-primary alert-outlined" role="alert">
    		                                            <span id="portataIngresso"> 0 </span><br>
  		                                            </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="card">
                                            <div class="card-header" id="headingBorderBottomTwoPortata">
                                                <h2 class="mb-0">
                                                    <button class="btn btn-link collapsed" type="button" data-toggle="collapse" data-target="#collapseBorderBottomTwoPortata" aria-expanded="false" aria-controls="collapseBorderBottomTwoPortata" data-translate="totUscita">
                                                        
                                                    </button>
                                                </h2>
                                             </div>
                                             <div id="collapseBorderBottomTwoPortata" class="collapse" aria-labelledby="headingBorderBottomTwoPortata" data-parent="#accordionHeaderBorderBottomPortata">
                                                <div class="card-body">
		                                            <div class="alert alert-primary alert-outlined" role="alert">
    		                                            <span id="portataUscita">0</span><br>
  		                                            </div>
                                               </div>
                                            </div>
                                        </div>
                                    </div>
							        <div class="row justify-content-center">
								    </div>
							    </div>
							  </div>
						  </div>
						  <!-- END PORTATA IST. CONTATORE -->

                      </div>
  			        <!--end  INFO POMPA -->
                    </div>
                  <div class="card card-default">
                      <div class="card-body pb-0">
                          <!-- menu -->
                         <ul class="nav nav-pills mb-3" id="pills-tab2" role="tablist">
 						 <li class="nav-item">
							<a class="nav-link active" id="pills-home-tab" data-toggle="pill" href="#nav-tabs-home2" role="tab"aria-controls="nav-tabs" aria-selected="true">
							  <i class="mdi mdi-plus-circle"></i><span data-translate="probeSettings"> </span></a>
						 </li>
 						 <li class="nav-item">
                            <a class="nav-link" id="nav-profile-tab" data-toggle="pill" href="#nav-profile2" role="tab"aria-controls="nav-profile" aria-selected="false">
                            <i class="mdi mdi-plus-circle"></i> <span data-translate="inputsSetup"></span></a>
                        </li>
 						 <li class="nav-item">
                            <a class="nav-link" id="nav-profile-tab3" data-toggle="pill" href="#nav-profile3" role="tab"aria-controls="nav-profile" aria-selected="false">
                            <i class="mdi"></i> <span data-translate="alarmSetup"></span></a>
                        </li>
 						 <li class="nav-item">
                            <a class="nav-link" id="nav-profile-tab4" data-toggle="pill" href="#nav-profile4" role="tab"aria-controls="nav-profile" aria-selected="false">
                            <i class="mdi"></i> <span data-translate="washingSetup"></span></a>
                        </li>
 						 <li class="nav-item">
                            <a class="nav-link" id="nav-profile-tab5" data-toggle="pill" href="#nav-profile5" role="tab"aria-controls="nav-profile" aria-selected="false">
                            <i class="mdi"></i> <span data-translate="delaySetup"></span></a>
                        </li>
 						 <li class="nav-item">
                            <a class="nav-link" id="nav-profile-tab6" data-toggle="pill" href="#nav-profile6" role="tab"aria-controls="nav-profile" aria-selected="false">
                            <i class="mdi"></i> <span data-translate="maintenanceSetup"></span></a>
                        </li>
 						 <li class="nav-item">
                            <a class="nav-link" id="nav-profile-tab7" data-toggle="pill" href="#nav-profile7" role="tab"aria-controls="nav-profile" aria-selected="false">
                            <i class="mdi"></i> <span data-translate="settingsSetup"></span></a>
                        </li>
 						 <li class="nav-item">
                            <a class="nav-link" id="nav-profile-tab8" data-toggle="pill" href="#nav-profile8" role="tab"aria-controls="nav-profile" aria-selected="false">
                            <i class="mdi"></i> <span data-translate="maoutputsSetup"></span></a>
                        </li>
 						 <li class="nav-item">
                            <a class="nav-link" id="nav-profile-tab9" data-toggle="pill" href="#nav-profile9" role="tab"aria-controls="nav-profile" aria-selected="false">
                            <i class="mdi"></i> <span data-translate="logSetup"></span></a>
                        </li>
 						 <li class="nav-item">
                            <a class="nav-link" id="nav-profile-tab10" data-toggle="pill" href="#nav-profile10" role="tab"aria-controls="nav-profile" aria-selected="false">
                            <i class="mdi mdi-plus-circle"></i> <span data-translate="messageSetup"></span></a>
                        </li>
 						 <li class="nav-item">
                            <a class="nav-link" id="nav-profile-tab11" data-toggle="pill" href="#nav-profile11" role="tab"aria-controls="nav-profile" aria-selected="false">
                            <i class="mdi mdi-plus-circle"></i> <span data-translate="action"></span></a>
                        </li>

  					  </ul>
                          <!-- end menu -->
                          <div class="tab-content mt-5" id="nav-tabContent">
                              <!-- contenuto probe settings -->
                              <div class="tab-pane fade show active" id="nav-tabs-home2" role="tabpanel" aria-labelledby="nav-home-tab">
                                  <div class="card-body">
                                      <ul class="nav nav-underline-active-primary mb-3" id="tab" role="tablist">
	    								<li class="nav-item">
											<a class="nav-link active" id="nav-profile-setpointSondaIngresso" data-toggle="pill" href="#nav-tabs-setpointIngresso" role="tab" aria-controls="nav-tabs" aria-selected="false">
												<i class="mdi mdi-arrow-right-drop-circle-outline"></i> <span data-translate="inputSonda"></span></a>
										</li>
										<li class="nav-item">
											<a class="nav-link" id="nav-profile-setpointSondaUscita" data-toggle="pill" href="#nav-tabs-setpointUscita" role="tab" aria-controls="nav-tabs" aria-selected="false">
												<i class="mdi mdi-arrow-right-drop-circle-outline"></i><span data-translate="outputSonda"> </span></a>
										 </li>
										<li class="nav-item">
											<a class="nav-link" id="nav-profile-setpointSondaTemperatura" data-toggle="pill" href="#nav-tabs-setpointTemperatura" role="tab" aria-controls="nav-tabs" aria-selected="false">
												<i class="mdi mdi-arrow-right-drop-circle-outline"></i><span data-translate="temperaturaSonda"> </span></a>
										 </li>

                                      </ul>
                                      <div class="tab-content mt-5" id="tabSubAdvanced" >
                                          <!-- setpoint sonda ingresso-->
                                          <div class="tab-pane fade show active " id="nav-tabs-setpointIngresso" role="tabpanel" aria-labelledby="nav-home-tab">
                                              <form>
                                                            <div class="form-group" aria-haspopup="True">
															        <input type="checkbox" class="custom-control-input" id="setpointIngressoEnable"  onclick="$(this).prop('checked') ? $('#setpointIngressoGroup').show() : $('#setpointIngressoGroup').hide()">
															        <label class="custom-control-label" for="setpointIngressoEnable" data-translate="setpointIngressoEnable"></label>
													        </div>
                                                            <div id ="setpointIngressoGroup">
													            <div class="form-group" aria-haspopup="True">
														            <label for="exampleFormControlPassword4" data-translate="probeSettings" ></label>
                                                                    <label for="exampleFormControlPassword4" id="setpointIngressoUnit" > </label>
														            <input type="number" class="form-control border-success numerico" id="setpointIngressoSetpoint" min ="0" max ="0" step="0" labelMSG="setpointIngressoInfo" labelMSGError="setpointIngressoAlarm" decimal ="0" maxlength="0"  placeholder="">
													            </div>
                                                        <div class="custom-control custom-radio d-inline-block mr-3 mb-3">
															    <label for="exampleFormControlSelect15" data-translate="setpointIngressoDelayMin"></label>
															    <select class="form-control rounded-0 bg-light timeInsert" id="setpointIngressoDelayMin">
															    </select>
                                                        </div>
                                                        <div class="custom-control custom-radio d-inline-block mr-3 mb-3">
															    <label for="exampleFormControlSelect15" data-translate="setpointIngressoDelaySec"></label>
															    <select class="form-control rounded-0 bg-light timeInsert" id="setpointIngressoDelaySec">

															    </select>
                                                        </div>
                                                            <div class="form-group" aria-haspopup="True">
															        <input type="checkbox" class="custom-control-input" id="setpointIngressoStop"  >
															        <label class="custom-control-label" for="setpointIngressoStop" data-translate="setpointIngressoStop"></label>
													        </div>

                                                            </div>
                                                    <div class="form-footer ModeSendLoad"  style="display: none;">
                                                        <div class="progress mb-3" >
																  <div  class="progress-bar progress-bar-striped progress-bar-animated" role="progressbar" style="width: 25%" aria-valuenow="25" aria-valuemin="0" aria-valuemax="100"></div>
													    </div>
                                                    </div>
													<div class="form-footer">
														<!-- TASTO LOADING -->
														<a class="ladda-button btn btn-primary btn-ladda" id="setpointIngressoSend" data-style="expand-right">
  															<span class="ladda-label" data-translate="saveSetpoint"></span>
  															<span class="ladda-spinner" data-translate="loadingSetpoint" style="display: none;"></span>
														</a>
														<!-- END TASTO LOADING -->
													</div>
                                              </form>
                                          </div>
                                          <!-- end setpoint sonda ingresso-->
                                          <!-- setpoint sonda uscita-->
                                          <div class="tab-pane fade show " id="nav-tabs-setpointUscita" role="tabpanel" aria-labelledby="nav-home-tab">
                                              <form>
                                                            <div class="form-group" aria-haspopup="True">
															        <input type="checkbox" class="custom-control-input" id="setpointUscitaEnable" checked="checked" onclick="$(this).prop('checked') ? $('#setpointUscitaGroup').show() : $('#setpointUscitaGroup').hide()">
															        <label class="custom-control-label" for="setpointUscitaEnable" data-translate="setpointIngressoEnable"></label>
													        </div>
                                                            <div id ="setpointUscitaGroup">
													            <div class="form-group" aria-haspopup="True">
														            <label for="exampleFormControlPassword4" data-translate="probeSettings" ></label>
                                                                    <label for="exampleFormControlPassword4" id="setpointUscitaUnit" > </label>
														            <input type="number" class="form-control border-success numerico" id="setpointUscitaSetpoint" min ="0" max ="0" step="0" labelMSG="setpointUscitaInfo" labelMSGError="setpointUscitaAlarm" decimal ="0" maxlength="0"  placeholder="">
													            </div>
                                                        <div class="custom-control custom-radio d-inline-block mr-3 mb-3">
															    <label for="exampleFormControlSelect15" data-translate="setpointUscitaDelayMin"></label>
															    <select class="form-control rounded-0 bg-light timeInsert" id="setpointUscitaDelayMin">

															    </select>
                                                        </div>
                                                        <div class="custom-control custom-radio d-inline-block mr-3 mb-3">
															    <label for="exampleFormControlSelect15" data-translate="setpointUscitaDelaySec"></label>
															    <select class="form-control rounded-0 bg-light timeInsert" id="setpointUscitaDelaySec">

															    </select>
                                                        </div>
                                                            <div class="form-group" aria-haspopup="True">
															        <input type="checkbox" class="custom-control-input" id="setpointUscitaAfterWash"  >
															        <label class="custom-control-label" for="setpointUscitaAfterWash" data-translate="setpointUscitaAfterWash"></label>
													        </div>
                                                            <div class="form-group" aria-haspopup="True">
															        <input type="checkbox" class="custom-control-input" id="setpointUscitaStop"  >
															        <label class="custom-control-label" for="setpointUscitaStop" data-translate="setpointUscitaStop"></label>
													        </div>

                                                            </div>
                                                    <div class="form-footer ModeSendLoad"  style="display: none;">
                                                        <div class="progress mb-3" >
																  <div  class="progress-bar progress-bar-striped progress-bar-animated" role="progressbar" style="width: 25%" aria-valuenow="25" aria-valuemin="0" aria-valuemax="100"></div>
													    </div>
                                                    </div>
													<div class="form-footer">
														<!-- TASTO LOADING -->
														<a class="ladda-button btn btn-primary btn-ladda" id="setpointUscitaSend" data-style="expand-right">
  															<span class="ladda-label" data-translate="saveSetpoint"></span>
  															<span class="ladda-spinner" data-translate="loadingSetpoint" style="display: none;"></span>
														</a>
														<!-- END TASTO LOADING -->
													</div>

                                              </form>
                                          </div>
                                          <!-- end setpoint sonda uscita-->
                                          <!-- setpoint sonda temperatura-->
                                          <div class="tab-pane fade show  " id="nav-tabs-setpointTemperatura" role="tabpanel" aria-labelledby="nav-home-tab">
                                              <form>
                                                            <div class="form-group" aria-haspopup="True">
															        <input type="checkbox" class="custom-control-input" id="setpointTemperaturaEnable" checked="checked" onclick="$(this).prop('checked') ? $('#setpointTemperaturaGroup').show() : $('#setpointTemperaturaGroup').hide()">
															        <label class="custom-control-label" for="setpointTemperaturaEnable" data-translate="setpointIngressoEnable"></label>
													        </div>
                                                            <div id ="setpointTemperaturaGroup">
													            <div class="form-group" aria-haspopup="True">
														            <label for="exampleFormControlPassword4" data-translate="probeSettings" ></label>
                                                                    <label for="exampleFormControlPassword4" id="setpointTemperaturaUnit" > </label>
														            <input type="number" class="form-control border-success numerico" id="setpointTemperaturaSetpoint" min ="0" max ="250" step="0.1" labelMSG="setpointTemperaturaInfo" labelMSGError="setpointTemperaturaAlarm" decimal ="1" maxlength="5"  placeholder="">
													            </div>
                                                        <div class="custom-control custom-radio d-inline-block mr-3 mb-3">
															    <label for="exampleFormControlSelect15" data-translate="setpointIngressoDelayMin"></label>
															    <select class="form-control rounded-0 bg-light timeInsert" id="setpointTemperaturaDelayMin">

															    </select>
                                                        </div>
                                                        <div class="custom-control custom-radio d-inline-block mr-3 mb-3">
															    <label for="exampleFormControlSelect15" data-translate="setpointIngressoDelaySec"></label>
															    <select class="form-control rounded-0 bg-light timeInsert" id="setpointTemperaturaDelaySec">

															    </select>
                                                        </div>
                                                            <div class="form-group" aria-haspopup="True">
															        <input type="checkbox" class="custom-control-input" id="setpointTemperaturaStop"  >
															        <label class="custom-control-label" for="setpointTemperaturaStop" data-translate="setpointIngressoStop"></label>
													        </div>

                                                            </div>
                                                    <div class="form-footer ModeSendLoad"  style="display: none;">
                                                        <div class="progress mb-3" >
																  <div  class="progress-bar progress-bar-striped progress-bar-animated" role="progressbar" style="width: 25%" aria-valuenow="25" aria-valuemin="0" aria-valuemax="100"></div>
													    </div>
                                                    </div>
													<div class="form-footer">
														<!-- TASTO LOADING -->
														<a class="ladda-button btn btn-primary btn-ladda" id="setpointTemperaturaSend" data-style="expand-right">
  															<span class="ladda-label" data-translate="saveSetpoint"></span>
  															<span class="ladda-spinner" data-translate="loadingSetpoint" style="display: none;"></span>
														</a>
														<!-- END TASTO LOADING -->
													</div>
                                              </form>
                                          </div>
                                          <!-- end setpoint sonda temperatura-->
                                      </div>
                                  </div>
                              </div>
                              <!-- end contenuto probe settings -->
                              <!-- contenuto input setup -->
                              <div class="tab-pane fade" id="nav-profile2" role="tabpanel" aria-labelledby="nav-home-tab">
                                  <div class="card-body">
                                      <ul class="nav nav-underline-active-primary mb-3" id="tab" role="tablist">
	    								<li class="nav-item">
											<a class="nav-link active" id="nav-profile-inputLevel" data-toggle="pill" href="#nav-tabs-inputLevel" role="tab" aria-controls="nav-tabs" aria-selected="false">
												<i class="mdi mdi-arrow-right-drop-circle-outline"></i> <span data-translate="inputLevel"></span></a>
										</li>
										<li class="nav-item">
											<a class="nav-link" id="nav-profile-inputPressure" data-toggle="pill" href="#nav-tabs-inputPressure" role="tab" aria-controls="nav-tabs" aria-selected="false">
												<i class="mdi mdi-arrow-right-drop-circle-outline"></i><span data-translate="inputPressure"> </span></a>
										 </li>
										<li class="nav-item">
											<a class="nav-link" id="nav-profile-inputTempPump" data-toggle="pill" href="#nav-tabs-inputTempPump" role="tab" aria-controls="nav-tabs" aria-selected="false">
												<i class="mdi mdi-arrow-right-drop-circle-outline"></i><span data-translate="inputTempPump"> </span></a>
										 </li>
										<li class="nav-item">
											<a class="nav-link" id="nav-profile-inputFilter" data-toggle="pill" href="#nav-tabs-inputFilter" role="tab" aria-controls="nav-tabs" aria-selected="false">
												<i class="mdi mdi-arrow-right-drop-circle-outline"></i><span data-translate="inputFilter"> </span></a>
										 </li>
										<li class="nav-item">
											<a class="nav-link" id="nav-profile-inputGeneral" data-toggle="pill" href="#nav-tabs-inputGeneral" role="tab" aria-controls="nav-tabs" aria-selected="false">
												<i class="mdi mdi-arrow-right-drop-circle-outline"></i><span data-translate="inputGeneral"> </span></a>
										 </li>
										<li class="nav-item">
											<a class="nav-link" id="nav-profile-inputStandby" data-toggle="pill" href="#nav-tabs-inputStandby" role="tab" aria-controls="nav-tabs" aria-selected="false">
												<i class="mdi mdi-arrow-right-drop-circle-outline"></i><span data-translate="inputStandby"> </span></a>
										 </li>
										<li class="nav-item">
											<a class="nav-link" id="nav-profile-inputWaterMeter" data-toggle="pill" href="#nav-tabs-inputWaterMeter" role="tab" aria-controls="nav-tabs" aria-selected="false">
												<i class="mdi mdi-arrow-right-drop-circle-outline"></i><span data-translate="inputWaterMeter"> </span></a>
										 </li>
										<li class="nav-item">
											<a class="nav-link" id="nav-profile-inputDosingAlarm" data-toggle="pill" href="#nav-tabs-inputDosingAlarm" role="tab" aria-controls="nav-tabs" aria-selected="false">
												<i class="mdi mdi-arrow-right-drop-circle-outline"></i><span data-translate="inputDosingAlarm"> </span></a>
										 </li>

                                      </ul>
                                      <div class="tab-content mt-5" id="tabSubAdvanced1" >
                                          <!-- input livello-->
                                          <div class="tab-pane fade show active " id="nav-tabs-inputLevel" role="tabpanel" aria-labelledby="nav-home-tab">
                                              <form>
                                                            <div class="form-group" aria-haspopup="True">
															        <input type="checkbox" class="custom-control-input" id="inputLevelLowEnable"  onclick="$(this).prop('checked') ? $('#inputLevelLowGroup').show() : $('#inputLevelLowGroup').hide()">
															        <label class="custom-control-label" for="inputLevelLowEnable" data-translate="inputLevelLowEnable"></label>
													        </div>
                                                            <div id ="inputLevelLowGroup">
                                                                <div class="custom-control custom-radio d-inline-block mr-3 mb-3">
															            <label for="exampleFormControlSelect15" data-translate="contactSetpoint"></label>
															            <select class="form-control rounded-0 bg-light " id ="inputLevelLowContact">
																            <option value ="1" data-translate="ncContactSetpoint"></option>
																            <option value ="0" data-translate="noContactSetpoint"></option>
															            </select>
													            </div>
                                                                <div class="custom-control custom-radio d-inline-block mr-3 mb-3">
															    <label for="exampleFormControlSelect15" data-translate="setpointUscitaDelaySec"></label>
															    <select class="form-control rounded-0 bg-light timeInsert" id="inputLevelLowDelaySec">

															    </select>
                                                        </div>
                                                            
                                                            </div>
                                                            <div class="form-group" aria-haspopup="True">
															        <input type="checkbox" class="custom-control-input" id="inputLevelHighEnable"  onclick="$(this).prop('checked') ? $('#inputLevelHighGroup').show() : $('#inputLevelHighGroup').hide()">
															        <label class="custom-control-label" for="inputLevelHighEnable" data-translate="inputLevelHighEnable"></label>
													        </div>
                                                            <div id ="inputLevelHighGroup">
                                                                <div class="custom-control custom-radio d-inline-block mr-3 mb-3">
															            <label for="exampleFormControlSelect15" data-translate="contactSetpoint"></label>
															            <select class="form-control rounded-0 bg-light " id ="inputLevelHighContact">
																            <option value ="1" data-translate="ncContactSetpoint"></option>
																            <option value ="0" data-translate="noContactSetpoint"></option>
															            </select>
													            </div>
                                                                <div class="custom-control custom-radio d-inline-block mr-3 mb-3">
															    <label for="exampleFormControlSelect15" data-translate="setpointUscitaDelaySec"></label>
															    <select class="form-control rounded-0 bg-light timeInsert" id="inputLevelHighDelaySec">

															    </select>
                                                                </div>
                                                            </div>
                                                    <div class="form-footer ModeSendLoad"  style="display: none;">
                                                        <div class="progress mb-3" >
																  <div  class="progress-bar progress-bar-striped progress-bar-animated" role="progressbar" style="width: 25%" aria-valuenow="25" aria-valuemin="0" aria-valuemax="100"></div>
													    </div>
                                                    </div>
													<div class="form-footer">
														<!-- TASTO LOADING -->
														<a class="ladda-button btn btn-primary btn-ladda" id="inputLevelSend" data-style="expand-right">
  															<span class="ladda-label" data-translate="saveSetpoint"></span>
  															<span class="ladda-spinner" data-translate="loadingSetpoint" style="display: none;"></span>
														</a>
														<!-- END TASTO LOADING -->
													</div>
                                              </form>
                                          </div>
                                          <!-- end input livello-->
                                          <!-- input pressure-->
                                          <div class="tab-pane fade show " id="nav-tabs-inputPressure" role="tabpanel" aria-labelledby="nav-home-tab">
                                              <form>
                                                            <div class="form-group" aria-haspopup="True">
															        <input type="checkbox" class="custom-control-input" id="inputPressureMinEnable"  onclick="$(this).prop('checked') ? $('#inputPressureMinGroup').show() : $('#inputPressureMinGroup').hide()">
															        <label class="custom-control-label" for="inputPressureMinEnable" data-translate="inputPressureMinEnable"></label>
													        </div>
                                                            <div id ="inputPressureMinGroup">
                                                                <div class="custom-control custom-radio d-inline-block mr-3 mb-3">
															            <label for="exampleFormControlSelect15" data-translate="contactSetpoint"></label>
															            <select class="form-control rounded-0 bg-light " id ="inputPressureMinContact">
																            <option value ="1" data-translate="ncContactSetpoint"></option>
																            <option value ="0" data-translate="noContactSetpoint"></option>
															            </select>
													            </div>
                                                                <div class="custom-control custom-radio d-inline-block mr-3 mb-3">
															    <label for="exampleFormControlSelect15" data-translate="setpointUscitaDelaySec"></label>
															    <select class="form-control rounded-0 bg-light timeInsert" id="inputPressureMinDelaySec">

															    </select>
                                                        </div>
													            <div class="form-group" aria-haspopup="True">
														            <label for="exampleFormControlPassword4" data-translate="inputPressureRetry" ></label>
														            <input type="number" class="form-control border-success numerico" id="inputPressureRetry" min ="0" max ="9" step="1" labelMSG="inputPressureRetryInfo" labelMSGError="inputPressureRetryAlarm" decimal ="0" maxlength="1"  placeholder="">
													            </div>
                                                            <div class="form-group" aria-haspopup="True">
															        <input type="checkbox" class="custom-control-input" id="inputPressureMinWash"  >
															        <label class="custom-control-label" for="inputPressureMinWash" data-translate="inputPressureMinWash"></label>
													        </div>
                                                            
                                                            </div>
                                                            <div class="form-group" aria-haspopup="True">
															        <input type="checkbox" class="custom-control-input" id="inputPressureMaxEnable"  onclick="$(this).prop('checked') ? $('#inputPressureMaxGroup').show() : $('#inputPressureMaxGroup').hide()">
															        <label class="custom-control-label" for="inputPressureMaxEnable" data-translate="inputPressureMaxEnable"></label>
													        </div>
                                                            <div id ="inputPressureMaxGroup">
                                                                <div class="custom-control custom-radio d-inline-block mr-3 mb-3">
															            <label for="exampleFormControlSelect15" data-translate="contactSetpoint"></label>
															            <select class="form-control rounded-0 bg-light " id ="inputPressureMaxContact">
																            <option value ="1" data-translate="ncContactSetpoint"></option>
																            <option value ="0" data-translate="noContactSetpoint"></option>
															            </select>
													            </div>
                                                                <div class="custom-control custom-radio d-inline-block mr-3 mb-3">
															    <label for="exampleFormControlSelect15" data-translate="setpointUscitaDelaySec"></label>
															    <select class="form-control rounded-0 bg-light timeInsert" id="inputPressureMaxDelaySec">

															    </select>
                                                                </div>
                                                            </div>
                                                    <div class="form-footer ModeSendLoad"  style="display: none;">
                                                        <div class="progress mb-3" >
																  <div  class="progress-bar progress-bar-striped progress-bar-animated" role="progressbar" style="width: 25%" aria-valuenow="25" aria-valuemin="0" aria-valuemax="100"></div>
													    </div>
                                                    </div>
													<div class="form-footer">
														<!-- TASTO LOADING -->
														<a class="ladda-button btn btn-primary btn-ladda" id="inputPressureSend" data-style="expand-right">
  															<span class="ladda-label" data-translate="saveSetpoint"></span>
  															<span class="ladda-spinner" data-translate="loadingSetpoint" style="display: none;"></span>
														</a>
														<!-- END TASTO LOADING -->
													</div>
                                              </form>
                                           </div>
                                          <!-- end input pressure-->
                                          <!-- input temp pump-->
                                          <div class="tab-pane fade show " id="nav-tabs-inputTempPump" role="tabpanel" aria-labelledby="nav-home-tab">
                                              <form>
                                                            <div class="form-group" aria-haspopup="True">
															        <input type="checkbox" class="custom-control-input" id="inputTempPumpEnable"  onclick="$(this).prop('checked') ? $('#inputTempPumpGroup').show() : $('#inputTempPumpGroup').hide()">
															        <label class="custom-control-label" for="inputTempPumpEnable" data-translate="setpointIngressoEnable"></label>
													        </div>
                                                            <div id ="inputTempPumpGroup">
                                                                <div class="custom-control custom-radio d-inline-block mr-3 mb-3">
															            <label for="exampleFormControlSelect15" data-translate="contactSetpoint"></label>
															            <select class="form-control rounded-0 bg-light " id ="inputTempPumpContact">
																            <option value ="1" data-translate="ncContactSetpoint"></option>
																            <option value ="0" data-translate="noContactSetpoint"></option>
															            </select>
													            </div>
                                                                <div class="custom-control custom-radio d-inline-block mr-3 mb-3">
															    <label for="exampleFormControlSelect15" data-translate="setpointUscitaDelaySec"></label>
															    <select class="form-control rounded-0 bg-light timeInsert" id="inputTempPumpDelaySec">

															    </select>
                                                        </div>
                                                            
                                                            </div>
                                                    <div class="form-footer ModeSendLoad"  style="display: none;">
                                                        <div class="progress mb-3" >
																  <div  class="progress-bar progress-bar-striped progress-bar-animated" role="progressbar" style="width: 25%" aria-valuenow="25" aria-valuemin="0" aria-valuemax="100"></div>
													    </div>
                                                    </div>
													<div class="form-footer">
														<!-- TASTO LOADING -->
														<a class="ladda-button btn btn-primary btn-ladda" id="inputTempPumpSend" data-style="expand-right">
  															<span class="ladda-label" data-translate="saveSetpoint"></span>
  															<span class="ladda-spinner" data-translate="loadingSetpoint" style="display: none;"></span>
														</a>
														<!-- END TASTO LOADING -->
													</div>
                                              </form>
                                          </div>
                                          <!-- end input temp pump-->
                                          <!-- input filtro-->
                                          <div class="tab-pane fade show " id="nav-tabs-inputFilter" role="tabpanel" aria-labelledby="nav-home-tab">
                                              <form>
                                                            <div class="form-group" aria-haspopup="True">
															        <input type="checkbox" class="custom-control-input" id="inputFilterEnable"  onclick="$(this).prop('checked') ? $('#inputFilterGroup').show() : $('#inputFilterGroup').hide()">
															        <label class="custom-control-label" for="inputFilterEnable" data-translate="setpointIngressoEnable"></label>
													        </div>
                                                            <div id ="inputFilterGroup">
                                                                <div class="custom-control custom-radio d-inline-block mr-3 mb-3">
															            <label for="exampleFormControlSelect15" data-translate="contactSetpoint"></label>
															            <select class="form-control rounded-0 bg-light " id ="inputFilterContact">
																            <option value ="1" data-translate="ncContactSetpoint"></option>
																            <option value ="0" data-translate="noContactSetpoint"></option>
															            </select>
													            </div>
                                                                <div class="custom-control custom-radio d-inline-block mr-3 mb-3">
															    <label for="exampleFormControlSelect15" data-translate="setpointUscitaDelaySec"></label>
															    <select class="form-control rounded-0 bg-light timeInsert" id="inputFilterDelaySec">

															    </select>
                                                        </div>
                                                            
                                                            </div>
                                                    <div class="form-footer ModeSendLoad"  style="display: none;">
                                                        <div class="progress mb-3" >
																  <div  class="progress-bar progress-bar-striped progress-bar-animated" role="progressbar" style="width: 25%" aria-valuenow="25" aria-valuemin="0" aria-valuemax="100"></div>
													    </div>
                                                    </div>
													<div class="form-footer">
														<!-- TASTO LOADING -->
														<a class="ladda-button btn btn-primary btn-ladda" id="inputFilterSend" data-style="expand-right">
  															<span class="ladda-label" data-translate="saveSetpoint"></span>
  															<span class="ladda-spinner" data-translate="loadingSetpoint" style="display: none;"></span>
														</a>
														<!-- END TASTO LOADING -->
													</div>
                                              </form>
                                          </div>
                                          <!-- end input filtro-->
                                          <!-- input General-->
                                          <div class="tab-pane fade show " id="nav-tabs-inputGeneral" role="tabpanel" aria-labelledby="nav-home-tab">
                                              <form>
                                                            <div class="form-group" aria-haspopup="True">
															        <input type="checkbox" class="custom-control-input" id="inputGeneralEnable"  onclick="$(this).prop('checked') ? $('#inputGeneralGroup').show() : $('#inputGeneralGroup').hide()">
															        <label class="custom-control-label" for="inputGeneralEnable" data-translate="setpointIngressoEnable"></label>
													        </div>
                                                            <div id ="inputGeneralGroup">
                                                                <div class="custom-control custom-radio d-inline-block mr-3 mb-3">
															            <label for="exampleFormControlSelect15" data-translate="contactSetpoint"></label>
															            <select class="form-control rounded-0 bg-light " id ="inputGeneralContact">
																            <option value ="1" data-translate="ncContactSetpoint"></option>
																            <option value ="0" data-translate="noContactSetpoint"></option>
															            </select>
													            </div>
                                                                <div class="custom-control custom-radio d-inline-block mr-3 mb-3">
															    <label for="exampleFormControlSelect15" data-translate="setpointUscitaDelaySec"></label>
															    <select class="form-control rounded-0 bg-light timeInsert" id="inputGeneralDelaySec">

															    </select>
                                                        </div>
  												                <div class="form-group" aria-haspopup="True">
														                <label for="exampleFormControlPassword4" data-translate="inputGeneralLabel" ></label>
                                                                        <input type="text" class="form-control border-success " id="inputGeneralLabel"  labelMSG="mailInfo" labelMSGError="mailAlarm" maxlength="8"  placeholder="">
												                </div>
                                                            
                                                            </div>
                                                    <div class="form-footer ModeSendLoad"  style="display: none;">
                                                        <div class="progress mb-3" >
																  <div  class="progress-bar progress-bar-striped progress-bar-animated" role="progressbar" style="width: 25%" aria-valuenow="25" aria-valuemin="0" aria-valuemax="100"></div>
													    </div>
                                                    </div>
													<div class="form-footer">
														<!-- TASTO LOADING -->
														<a class="ladda-button btn btn-primary btn-ladda" id="inputGeneralSend" data-style="expand-right">
  															<span class="ladda-label" data-translate="saveSetpoint"></span>
  															<span class="ladda-spinner" data-translate="loadingSetpoint" style="display: none;"></span>
														</a>
														<!-- END TASTO LOADING -->
													</div>
                                              </form>
                                          </div>
                                          <!-- end input General-->
                                          <!-- input standby-->
                                          <div class="tab-pane fade show " id="nav-tabs-inputStandby" role="tabpanel" aria-labelledby="nav-home-tab">
                                              <form>
                                                            <div class="form-group" aria-haspopup="True">
															        <input type="checkbox" class="custom-control-input" id="inputStandbyEnable"  onclick="$(this).prop('checked') ? $('#inputStandbyGroup').show() : $('#inputStandbyGroup').hide()">
															        <label class="custom-control-label" for="inputStandbyEnable" data-translate="setpointIngressoEnable"></label>
													        </div>
                                                            <div id ="inputStandbyGroup">
                                                                <div class="custom-control custom-radio d-inline-block mr-3 mb-3">
															            <label for="exampleFormControlSelect15" data-translate="contactSetpoint"></label>
															            <select class="form-control rounded-0 bg-light " id ="inputStandbyContact">
																            <option value ="1" data-translate="ncContactSetpoint"></option>
																            <option value ="0" data-translate="noContactSetpoint"></option>
															            </select>
													            </div>
                                                                <div class="custom-control custom-radio d-inline-block mr-3 mb-3">
															    <label for="exampleFormControlSelect15" data-translate="setpointUscitaDelaySec"></label>
															    <select class="form-control rounded-0 bg-light timeInsert" id="inputStandbyDelaySec">

															    </select>
                                                        </div>
                                                            
                                                            </div>
                                                    <div class="form-footer ModeSendLoad"  style="display: none;">
                                                        <div class="progress mb-3" >
																  <div  class="progress-bar progress-bar-striped progress-bar-animated" role="progressbar" style="width: 25%" aria-valuenow="25" aria-valuemin="0" aria-valuemax="100"></div>
													    </div>
                                                    </div>
													<div class="form-footer">
														<!-- TASTO LOADING -->
														<a class="ladda-button btn btn-primary btn-ladda" id="inputStandbySend" data-style="expand-right">
  															<span class="ladda-label" data-translate="saveSetpoint"></span>
  															<span class="ladda-spinner" data-translate="loadingSetpoint" style="display: none;"></span>
														</a>
														<!-- END TASTO LOADING -->
													</div>
                                              </form>
                                          </div>
                                          <!-- end input standby-->
                                          <!-- input water meter-->
                                          <div class="tab-pane fade show " id="nav-tabs-inputWaterMeter" role="tabpanel" aria-labelledby="nav-home-tab">
                                              <form>
                                                            <div class="form-group" aria-haspopup="True">
															        <input type="checkbox" class="custom-control-input" id="inputWaterMeterInputEnable"  onclick="$(this).prop('checked') ? $('#inputWaterMeterInputGroup').show() : $('#inputWaterMeterInputGroup').hide()">
															        <label class="custom-control-label" for="inputWaterMeterInputEnable" data-translate="inputWaterMeterInputEnable"></label>
													        </div>
                                                            <div id ="inputWaterMeterInputGroup">
                                                                <div class="custom-control custom-radio d-inline-block mr-3 mb-3">
															        <label for="exampleFormControlSelect15" data-translate="waterMeterSetpoint"></label>
															        <select class="form-control rounded-0 bg-light" id ="inputWaterMeterInputSetpoint" >
                                                                        <option value ="0" data-translate="waterMeter020Setpoint"></option>
                                                                        <option value ="1" data-translate="waterMeter420Setpoint"></option>
																        <option value ="2" data-translate="waterMeterLitrePulseSetpoint"></option>
																        <option value ="3" data-translate="waterMeterPulseLitreSetpoint"></option>
															        </select>
													            </div>
                                                                <div class="custom-control custom-radio d-inline-block mr-3 mb-3">
														            <label for="exampleFormControlPassword4" data-translate="waterMeterKSetpoint" ></label>
														            <input type="number" class="form-control border-success numerico" id ="inputWaterMeterInputKSetpoint"  min ="0.0" max ="9999.99" step="0.01" labelMSG="waterMeterKInfo" labelMSGError="waterMeterKAlarm" decimal ="2" maxlength="7"  placeholder="">
        													    </div>                                                                
                                                                <div class="form-group" aria-haspopup="True">
														            <label for="exampleFormControlPassword4" data-translate="waterMeterTimeoutSetpoint" ></label>
                                                                    <label for="exampleFormControlPassword4" > sec</label>
														            <input type="number" class="form-control border-success numerico" id ="inputWaterMeterInputTimeoutSetpoint"  min ="0" max ="999" step="1" labelMSG="waterMeterTimeoutInfo" labelMSGError="waterMeterTimeoutAlarm" decimal ="0" maxlength="3"  placeholder="">
        													    </div>                                                                
                                                            </div>

                                                            <div class="form-group" aria-haspopup="True">
															        <input type="checkbox" class="custom-control-input" id="inputWaterMeterOutputEnable"  onclick="$(this).prop('checked') ? $('#inputWaterMeterOutputGroup').show() : $('#inputWaterMeterOutputGroup').hide()">
															        <label class="custom-control-label" for="inputWaterMeterOutputEnable" data-translate="inputWaterMeterOutputEnable"></label>
													        </div>
                                                            <div id ="inputWaterMeterOutputGroup">
                                                                <div class="custom-control custom-radio d-inline-block mr-3 mb-3">
															        <label for="exampleFormControlSelect15" data-translate="waterMeterSetpoint"></label>
															        <select class="form-control rounded-0 bg-light" id ="inputWaterMeterOutputSetpoint" >
                                                                        <option value ="0" data-translate="waterMeter020Setpoint"></option>
                                                                        <option value ="1" data-translate="waterMeter420Setpoint"></option>
																        <option value ="2" data-translate="waterMeterLitrePulseSetpoint"></option>
																        <option value ="3" data-translate="waterMeterPulseLitreSetpoint"></option>
															        </select>
													            </div>
                                                                <div class="custom-control custom-radio d-inline-block mr-3 mb-3">
														            <label for="exampleFormControlPassword4" data-translate="waterMeterKSetpoint" ></label>
														            <input type="number" class="form-control border-success numerico" id ="inputWaterMeterOutputKSetpoint"  min ="0.0" max ="9999.99" step="0.01" labelMSG="waterMeterKInfo" labelMSGError="waterMeterKAlarm" decimal ="2" maxlength="7"  placeholder="">
        													    </div>                                                                
                                                                <div class="form-group" aria-haspopup="True">
														            <label for="exampleFormControlPassword4" data-translate="waterMeterTimeoutSetpoint" ></label>
                                                                    <label for="exampleFormControlPassword4" > sec</label>
														            <input type="number" class="form-control border-success numerico" id ="inputWaterMeterOutputTimeoutSetpoint"  min ="0" max ="999" step="1" labelMSG="waterMeterTimeoutInfo" labelMSGError="waterMeterTimeoutAlarm" decimal ="0" maxlength="3"  placeholder="">
        													    </div>                                                                
                                                            </div>

                                                    <div class="form-footer ModeSendLoad"  style="display: none;">
                                                        <div class="progress mb-3" >
																  <div  class="progress-bar progress-bar-striped progress-bar-animated" role="progressbar" style="width: 25%" aria-valuenow="25" aria-valuemin="0" aria-valuemax="100"></div>
													    </div>
                                                    </div>
													<div class="form-footer">
														<!-- TASTO LOADING -->
														<a class="ladda-button btn btn-primary btn-ladda" id="inputWaterMeterSend" data-style="expand-right">
  															<span class="ladda-label" data-translate="saveSetpoint"></span>
  															<span class="ladda-spinner" data-translate="loadingSetpoint" style="display: none;"></span>
														</a>
														<!-- END TASTO LOADING -->
													</div>
                                              </form>
                                          </div>
                                          <!-- end input water meter-->


                                          <!-- input allarme dosaggio-->
                                          <div class="tab-pane fade show " id="nav-tabs-inputDosingAlarm" role="tabpanel" aria-labelledby="nav-home-tab">
                                              <form>
                                                            <div class="form-group" aria-haspopup="True">
															        <input type="checkbox" class="custom-control-input" id="inputDosingAlarmEnable"  onclick="$(this).prop('checked') ? $('#inputDosingAlarmGroup').show() : $('#inputDosingAlarmGroup').hide()">
															        <label class="custom-control-label" for="inputDosingAlarmEnable" data-translate="setpointIngressoEnable"></label>
													        </div>
                                                            <div id ="inputDosingAlarmGroup">
                                                                <div class="custom-control custom-radio d-inline-block mr-3 mb-3">
															            <label for="exampleFormControlSelect15" data-translate="contactSetpoint"></label>
															            <select class="form-control rounded-0 bg-light " id ="inputDosingAlarmContact">
																            <option value ="1" data-translate="ncContactSetpoint"></option>
																            <option value ="0" data-translate="noContactSetpoint"></option>
															            </select>
													            </div>
                                                                <div class="custom-control custom-radio d-inline-block mr-3 mb-3">
															    <label for="exampleFormControlSelect15" data-translate="setpointUscitaDelaySec"></label>
															    <select class="form-control rounded-0 bg-light timeInsert" id="inputDosingAlarmDelaySec">

															    </select>
                                                        </div>
                                                            
                                                            </div>
                                                    <div class="form-footer ModeSendLoad"  style="display: none;">
                                                        <div class="progress mb-3" >
																  <div  class="progress-bar progress-bar-striped progress-bar-animated" role="progressbar" style="width: 25%" aria-valuenow="25" aria-valuemin="0" aria-valuemax="100"></div>
													    </div>
                                                    </div>
													<div class="form-footer">
														<!-- TASTO LOADING -->
														<a class="ladda-button btn btn-primary btn-ladda" id="inputDosingAlarmSend" data-style="expand-right">
  															<span class="ladda-label" data-translate="saveSetpoint"></span>
  															<span class="ladda-spinner" data-translate="loadingSetpoint" style="display: none;"></span>
														</a>
														<!-- END TASTO LOADING -->
													</div>
                                              </form>
                                          </div>
                                          <!-- end input allarme dosaggio-->

                                      </div>
                                  </div>
                              </div>
                              <!-- end contenuto input setup -->
                              <!-- contenuto alarm setup -->
                              <div class="tab-pane fade" id="nav-profile3" role="tabpanel" aria-labelledby="nav-home-tab">
                                  <div class="card-body">
                                      <div class="tab-content mt-5" id="tabSubAdvanced2" >
                                          <div class="tab-pane fade show active " id="nav-tabs-alarmSettings" role="tabpanel" aria-labelledby="nav-home-tab">
                                              <form>
                                                            <div class="form-group" aria-haspopup="True">
															        <input type="checkbox" class="custom-control-input" id="alarmSettingsEnable"  onclick="$(this).prop('checked') ? $('#alarmSettingsGroup').show() : $('#alarmSettingsGroup').hide()">
															        <label class="custom-control-label" for="alarmSettingsEnable" data-translate="setpointIngressoEnable"></label>
													        </div>
                                                            <div id ="alarmSettingsGroup">
                                                                <div class="custom-control custom-radio d-inline-block mr-3 mb-3">
															            <label for="exampleFormControlSelect15" data-translate="contactSetpoint"></label>
															            <select class="form-control rounded-0 bg-light " id ="alarmSettingsContact">
																            <option value ="1" data-translate="ncContactSetpoint"></option>
																            <option value ="0" data-translate="noContactSetpoint"></option>
															            </select>
													            </div>
                                                            </div>
                                                    <div class="form-footer ModeSendLoad"  style="display: none;">
                                                        <div class="progress mb-3" >
																  <div  class="progress-bar progress-bar-striped progress-bar-animated" role="progressbar" style="width: 25%" aria-valuenow="25" aria-valuemin="0" aria-valuemax="100"></div>
													    </div>
                                                    </div>
													<div class="form-footer">
														<!-- TASTO LOADING -->
														<a class="ladda-button btn btn-primary btn-ladda" id="alarmSettingsSend" data-style="expand-right">
  															<span class="ladda-label" data-translate="saveSetpoint"></span>
  															<span class="ladda-spinner" data-translate="loadingSetpoint" style="display: none;"></span>
														</a>
														<!-- END TASTO LOADING -->
													</div>
                                              </form>
                                          </div>
                                       </div>
                                  </div>
                              </div>
                               <!-- contenuto alarm setup -->
                              <div class="tab-pane fade" id="nav-profile4" role="tabpanel" aria-labelledby="nav-home-tab">
                                  <div class="card-body">
                                      <div class="tab-content mt-5" id="tabSubAdvanced3" >
                                          <div class="tab-pane fade show active " id="nav-tabs-washPumpSettings" role="tabpanel" aria-labelledby="nav-home-tab">
                                              <form>
                                                            <div class="form-group" aria-haspopup="True">
															        <input type="checkbox" class="custom-control-input" id="washSettingsEnable"  onclick="$(this).prop('checked') ? $('#washSettingsGroup').show() : $('#washSettingsGroup').hide()">
															        <label class="custom-control-label" for="washSettingsEnable" data-translate="setpointIngressoEnable"></label>
													        </div>
                                                            <div id ="washSettingsGroup">
                                                                <div class="form-group" aria-haspopup="True">
															            <input type="checkbox" class="custom-control-input" id="washPumpSettingsEnable">
															            <label class="custom-control-label" for="washPumpSettingsEnable" data-translate="washPumpSettingsEnable"></label>
													            </div>
                                                                <div class="form-group" aria-haspopup="True">
															            <input type="checkbox" class="custom-control-input" id="washEvInSettingsEnable">
															            <label class="custom-control-label" for="washEvInSettingsEnable" data-translate="washEvInSettingsEnable"></label>
													            </div>
                                                                <div class="custom-control custom-radio d-inline-block mr-3 mb-3">
															            <label for="exampleFormControlSelect15" data-translate="washPumpSettingsStartProdMin"></label>
															            <select class="form-control rounded-0 bg-light timeInsert" id="washPumpSettingsStartProdMin">

															            </select>
                                                                </div>
                                                                <div class="custom-control custom-radio d-inline-block mr-3 mb-3">
															            <label for="exampleFormControlSelect15" data-translate="washPumpSettingsStartProdSec"></label>
															            <select class="form-control rounded-0 bg-light timeInsert" id="washPumpSettingsStartProdSec">

															            </select>
                                                                </div>
                                                                <div class="form-group" aria-haspopup="True">
                                                                        <div class="custom-control custom-radio d-inline-block mr-3 mb-3">
															                    <label for="exampleFormControlSelect15" data-translate="washPumpSettingsEndProdMin"></label>
															                    <select class="form-control rounded-0 bg-light timeInsert" id="washPumpSettingsEndProdMin">

															                    </select>
                                                                        </div>
                                                                        <div class="custom-control custom-radio d-inline-block mr-3 mb-3">
															                    <label for="exampleFormControlSelect15" data-translate="washPumpSettingsEndProdSec"></label>
															                    <select class="form-control rounded-0 bg-light timeInsert" id="washPumpSettingsEndProdSec">

															                    </select>
                                                                        </div>
                                                                </div>
                                                                <div class="form-group" aria-haspopup="True">
                                                                    <div class="custom-control custom-radio d-inline-block mr-3 mb-3" aria-haspopup="True">
														                <label for="exampleFormControlPassword4" data-translate="washPumpSettingsCycleHr" ></label>
                                                                        <label for="exampleFormControlPassword4"  > Hr</label>
														                <input type="number" class="form-control border-success numerico" id="washPumpSettingsCycleHr" min ="0" max ="99" step="1" labelMSG="washPumpSettingsCycleHrInfo" labelMSGError="washPumpSettingsCycleHrAlarm" decimal ="0" maxlength="2"  placeholder="">
													                </div>
                                                                        <div class="custom-control custom-radio d-inline-block mr-3 mb-3">
															                    <label for="exampleFormControlSelect15" data-translate="washPumpSettingsCycleMin"></label>
															                    <select class="form-control rounded-0 bg-light timeInsert" id="washPumpSettingsCycleMin">

															                    </select>
                                                                        </div>
                                                                        <div class="custom-control custom-radio d-inline-block mr-3 mb-3">
															                    <label for="exampleFormControlSelect15" data-translate="washPumpSettingsCycleSec"></label>
															                    <select class="form-control rounded-0 bg-light timeInsert" id="washPumpSettingsCycleSec">

															                    </select>
                                                                        </div>
                                                                </div>
                                                                <div class="form-group" aria-haspopup="True">
                                                                    <div class="custom-control custom-radio d-inline-block mr-3 mb-3" aria-haspopup="True">
														                <label for="exampleFormControlPassword4" data-translate="washPumpSettingsRinsingHr" ></label>
                                                                        <label for="exampleFormControlPassword4"  > dd</label>
														                <input type="number" class="form-control border-success numerico" id="washPumpSettingsRinsingHr" min ="0" max ="99" step="1" labelMSG="washPumpSettingsCycleHrInfo" labelMSGError="washPumpSettingsCycleHrAlarm" decimal ="0" maxlength="2"  placeholder="">
													                </div>
                                                                        <div class="custom-control custom-radio d-inline-block mr-3 mb-3">
															                    <label for="exampleFormControlSelect15" data-translate="washPumpSettingsRinsingMin"></label>
															                    <select class="form-control rounded-0 bg-light timeInsert" id="washPumpSettingsRinsingMin">

															                    </select>
                                                                        </div>
                                                                        <div class="custom-control custom-radio d-inline-block mr-3 mb-3">
															                    <label for="exampleFormControlSelect15" data-translate="washPumpSettingsRinsingSec"></label>
															                    <select class="form-control rounded-0 bg-light timeInsert" id="washPumpSettingsRinsingSec">

															                    </select>
                                                                        </div>
                                                                </div>

                                                            </div>
                                                    <div class="form-footer ModeSendLoad"  style="display: none;">
                                                        <div class="progress mb-3" >
																  <div  class="progress-bar progress-bar-striped progress-bar-animated" role="progressbar" style="width: 25%" aria-valuenow="25" aria-valuemin="0" aria-valuemax="100"></div>
													    </div>
                                                    </div>
													<div class="form-footer">
														<!-- TASTO LOADING -->
														<a class="ladda-button btn btn-primary btn-ladda" id="washPumpSettingsSend" data-style="expand-right">
  															<span class="ladda-label" data-translate="saveSetpoint"></span>
  															<span class="ladda-spinner" data-translate="loadingSetpoint" style="display: none;"></span>
														</a>
														<!-- END TASTO LOADING -->
													</div>
                                            </form>
                                        </div>
                                   </div>
                                </div>
                             </div>
                              <!-- end contenuto alarm setup -->
                              <!-- contenuto delay setup -->
                              <div class="tab-pane fade" id="nav-profile5" role="tabpanel" aria-labelledby="nav-home-tab">
                                  <div class="card-body">
                                      <div class="tab-content mt-5" id="tabSubAdvanced4" >
                                          <div class="tab-pane fade show active " id="nav-tabs-delaySettings" role="tabpanel" aria-labelledby="nav-home-tab">
                                              <form>
                                                   <div class="form-group" aria-haspopup="True">
														            <label for="exampleFormControlPassword4" data-translate="delaySettingsPumpOn" ></label>
                                                                    <label for="exampleFormControlPassword4" > sec</label>
														            <input type="number" class="form-control border-success numerico" id="delaySettingsPumpOn" min ="0" max ="99" step="1" labelMSG="delaySettingsPumpInfo" labelMSGError="delaySettingsPumpAlarm" decimal ="0" maxlength="2"  placeholder="">
									               </div>
                                                   <div class="form-group" aria-haspopup="True">
														            <label for="exampleFormControlPassword4" data-translate="delaySettingsEvInOff" ></label>
                                                                    <label for="exampleFormControlPassword4" > sec</label>
														            <input type="number" class="form-control border-success numerico" id="delaySettingsEvInOff" min ="0" max ="99" step="1" labelMSG="delaySettingsPumpInfo" labelMSGError="delaySettingsPumpAlarm" decimal ="0" maxlength="2"  placeholder="">
									               </div>
                                                   <div class="form-group" aria-haspopup="True">
														            <label for="exampleFormControlPassword4" data-translate="delaySettingsDosingOn" ></label>
                                                                    <label for="exampleFormControlPassword4" > sec</label>
														            <input type="number" class="form-control border-success numerico" id="delaySettingsDosingOn" min ="0" max ="99" step="1" labelMSG="delaySettingsPumpInfo" labelMSGError="delaySettingsPumpAlarm" decimal ="0" maxlength="2"  placeholder="">
									               </div>
                                                   <div class="form-group" aria-haspopup="True">
														            <label for="exampleFormControlPassword4" data-translate="delaySettingsPumpOff" ></label>
                                                                    <label for="exampleFormControlPassword4" > sec</label>
														            <input type="number" class="form-control border-success numerico" id="delaySettingsPumpOff" min ="0" max ="99" step="1" labelMSG="delaySettingsPumpInfo" labelMSGError="delaySettingsPumpAlarm" decimal ="0" maxlength="2"  placeholder="">
									               </div>
                                                    <div class="form-footer ModeSendLoad"  style="display: none;">
                                                        <div class="progress mb-3" >
																  <div  class="progress-bar progress-bar-striped progress-bar-animated" role="progressbar" style="width: 25%" aria-valuenow="25" aria-valuemin="0" aria-valuemax="100"></div>
													    </div>
                                                    </div>
													<div class="form-footer">
														<!-- TASTO LOADING -->
														<a class="ladda-button btn btn-primary btn-ladda" id="delaySettingsSend" data-style="expand-right">
  															<span class="ladda-label" data-translate="saveSetpoint"></span>
  															<span class="ladda-spinner" data-translate="loadingSetpoint" style="display: none;"></span>
														</a>
														<!-- END TASTO LOADING -->
													</div>

                                              </form>
                                          </div>
                                      </div>
                                    </div>
                                </div>
                              <!-- end contenuto delay setup -->
                              <!-- contenuto manutenzione setup -->
                              <div class="tab-pane fade" id="nav-profile6" role="tabpanel" aria-labelledby="nav-home-tab">
                                  <div class="card-body">
                                      <div class="tab-content mt-5" id="tabSubAdvanced5" >
                                          <div class="tab-pane fade show active " id="nav-tabs-manutenzioneSettings" role="tabpanel" aria-labelledby="nav-home-tab">
                                              <form>
                                                  <div class="form-group" aria-haspopup="True">
															        <input type="checkbox" class="custom-control-input" id="manutenzioneMsg">
															        <label class="custom-control-label" for="manutenzioneMsg" data-translate="message"></label>
												  </div>
                                                   <div class="form-group" aria-haspopup="True">
														            <label for="exampleFormControlPassword4" data-translate="range" ></label>
                                                                    <label for="exampleFormControlPassword4" > Hr</label>
														            <input type="number" class="form-control border-success numerico" id="manutenzioneRange" min ="0" max ="9999" step="1" labelMSG="manutenzioneRangeInfo" labelMSGError="manutenzioneRangeAlarm" decimal ="0" maxlength="4"  placeholder="">
									               </div>
                                                  <div class="form-group" aria-haspopup="True">
															        <input type="checkbox" class="custom-control-input" id="manutenzioneResetServ">
															        <label class="custom-control-label" for="manutenzioneResetServ" data-translate="manutenzioneResetServ"></label>
												  </div>
                                                  <div class="form-group" aria-haspopup="True">
															        <input type="checkbox" class="custom-control-input" id="manutenzioneResetHr">
															        <label class="custom-control-label" for="manutenzioneResetHr" data-translate="manutenzioneResetHr"></label>
												  </div>
                                                    <div class="form-footer ModeSendLoad"  style="display: none;">
                                                        <div class="progress mb-3" >
																  <div  class="progress-bar progress-bar-striped progress-bar-animated" role="progressbar" style="width: 25%" aria-valuenow="25" aria-valuemin="0" aria-valuemax="100"></div>
													    </div>
                                                    </div>
													<div class="form-footer">
														<!-- TASTO LOADING -->
														<a class="ladda-button btn btn-primary btn-ladda" id="manutenzioneSettingsSend" data-style="expand-right">
  															<span class="ladda-label" data-translate="saveSetpoint"></span>
  															<span class="ladda-spinner" data-translate="loadingSetpoint" style="display: none;"></span>
														</a>
														<!-- END TASTO LOADING -->
													</div>

                                              </form>
                                         </div>
                                     </div>
                                  </div>
                               </div>
                              <!-- end contenuto manutenzione setup -->
                              <!-- contenuto datetime setup -->
                              <div class="tab-pane fade" id="nav-profile7" role="tabpanel" aria-labelledby="nav-home-tab">
                                  <div class="card-body">
                                      <div class="tab-content mt-5" id="tabSubAdvanced6" >
                                          <div class="tab-pane fade show active " id="nav-tabs-dateTimeSettings" role="tabpanel" aria-labelledby="nav-home-tab">
                                              <form>
                                                    <div class="custom-control custom-radio d-inline-block mr-3 mb-3">
															            <label for="exampleFormControlSelect15" data-translate="formatTime"></label>
															            <select class="form-control rounded-0 bg-light " id ="formatTime">
																            <option value ="0" >Europe IS</option>
																            <option value ="1" >USA</option>
															            </select>
										            </div>
                                                                <div class="form-group" aria-haspopup="True">
                                                                    <label class="text-dark font-weight-medium" for="" data-translate="date"></label>
															            <div class="input-group mb-3">
															              <div class="input-group-prepend">
																            <span class="input-group-text mdi mdi-calendar" id="basic-addon1"></span>
															              </div>
															              <input type="text" id="dateSetpoint" class="form-control" data-mask="00/00/0000" labelMSG="dateggmmaaInfo" labelMSGError="dateggmmaaAlarm" placeholder="00/00/0000">
															            </div>
                                                                </div>
                                                                <div class="form-group" aria-haspopup="True">
                                                                    <label for="exampleFormControlPassword4" data-translate="time"></label>
                                                                    <div class="input-group mb-3">
                                                                        <div class="input-group-prepend">
                                                                            <span class="input-group-text mdi mdi-clock" id="basic-addon1"></span>
                                                                         </div>
                                                                         <input type="text" class="form-control" id="timeSetpoint" data-mask="00:00" labelMSG="weekTimeInfo" labelMSGError="weekTimeAlarm" placeholder="00:00">
                                                                      </div>
                                                                 </div>
                                                  <div class="form-footer ModeSendLoad"  style="display: none;">
                                                                <div class="progress mb-3" >
																      <div  class="progress-bar progress-bar-striped progress-bar-animated" role="progressbar" style="width: 25%" aria-valuenow="25" aria-valuemin="0" aria-valuemax="100"></div>
													            </div>
                                                            </div>
													        <div class="form-footer">
														        <!-- TASTO LOADING -->
														        <a class="ladda-button btn btn-primary btn-ladda" id="dateTimeSettingsSend" data-style="expand-right">
  															        <span class="ladda-label" data-translate="saveSetpoint"></span>
  															        <span class="ladda-spinner" data-translate="loadingSetpoint" style="display: none;"></span>
														        </a>
														        <!-- END TASTO LOADING -->
													        </div>
                                              </form>
                                          </div>
                                     </div>
                                  </div>
                              </div>
                              <!-- end contenuto datetime setup -->
                              <!-- contenuto OUT Ma -->
                              <div class="tab-pane fade" id="nav-profile8" role="tabpanel" aria-labelledby="nav-home-tab">
                                  <div class="card-body">
                                      <div class="tab-content mt-5" id="tabSubAdvanced7" >
                                          <div class="tab-pane fade show active " id="nav-tabs-outMASettings" role="tabpanel" aria-labelledby="nav-home-tab">
                                              <form>
                                                                <div class="custom-control custom-radio d-inline-block mr-3 mb-3">
															        <label for="exampleFormControlSelect15" data-translate="totIngresso"></label>
															        <select class="form-control rounded-0 bg-light" id ="outMAOutput1Settings" >
                                                                        <option value ="0" data-translate="waterMeter020Setpoint"></option>
                                                                        <option value ="1" data-translate="waterMeter420Setpoint"></option>
															        </select>
													            </div>
													            <div class="form-group" aria-haspopup="True">
														            <label for="exampleFormControlPassword4" data-translate="outMAMax" ></label>
                                                                    <label for="exampleFormControlPassword4" id="outMAOutput1MaMAxUnit" > </label>
														            <input type="number" class="form-control border-success numerico" id="outMAOutput1MaMAxSetpoint" min ="0" max ="0" step="0" labelMSG="setpointIngressoInfo" labelMSGError="setpointIngressoAlarm" decimal ="0" maxlength="0"  placeholder="">
													            </div>
													            <div class="form-group" aria-haspopup="True">
														            <label for="exampleFormControlPassword4" data-translate="outMAMin" ></label>
                                                                    <label for="exampleFormControlPassword4" id="outMAOutput1MaMinUnit" > </label>
														            <input type="number" class="form-control border-success numerico" id="outMAOutput1MaMinSetpoint" min ="0" max ="0" step="0" labelMSG="setpointIngressoInfo" labelMSGError="setpointIngressoAlarm" decimal ="0" maxlength="0"  placeholder="">
													            </div>
                                                                <div class="form-group" aria-haspopup="True">
															            <input type="checkbox" class="custom-control-input" id="outMAOutput1MaMinAlarm">
															            <label class="custom-control-label" for="outMAOutput1MaMinAlarm" data-translate="outMAOutput1MaMinAlarm"></label>
													            </div>

                                                                <div class="custom-control custom-radio d-inline-block mr-3 mb-3">
															        <label for="exampleFormControlSelect15" data-translate="totUscita"></label>
															        <select class="form-control rounded-0 bg-light" id ="outMAOutput2Settings" >
                                                                        <option value ="0" data-translate="waterMeter020Setpoint"></option>
                                                                        <option value ="1" data-translate="waterMeter420Setpoint"></option>
															        </select>
													            </div>
													            <div class="form-group" aria-haspopup="True">
														            <label for="exampleFormControlPassword4" data-translate="outMAMax" ></label>
                                                                    <label for="exampleFormControlPassword4" id="outMAOutput2MaMAxUnit" > </label>
														            <input type="number" class="form-control border-success numerico" id="outMAOutput2MaMAxSetpoint" min ="0" max ="0" step="0" labelMSG="setpointIngressoInfo" labelMSGError="setpointIngressoAlarm" decimal ="0" maxlength="0"  placeholder="">
													            </div>
													            <div class="form-group" aria-haspopup="True">
														            <label for="exampleFormControlPassword4" data-translate="outMAMin" ></label>
                                                                    <label for="exampleFormControlPassword4" id="outMAOutput2MaMinUnit" > </label>
														            <input type="number" class="form-control border-success numerico" id="outMAOutput2MaMinSetpoint" min ="0" max ="0" step="0" labelMSG="setpointIngressoInfo" labelMSGError="setpointIngressoAlarm" decimal ="0" maxlength="0"  placeholder="">
													            </div>
                                                                <div class="form-group" aria-haspopup="True">
															            <input type="checkbox" class="custom-control-input" id="outMAOutput2MaMinAlarm">
															            <label class="custom-control-label" for="outMAOutput2MaMinAlarm" data-translate="outMAOutput1MaMinAlarm"></label>
													            </div>
                                                              <div class="form-footer ModeSendLoad"  style="display: none;">
                                                                <div class="progress mb-3" >
																      <div  class="progress-bar progress-bar-striped progress-bar-animated" role="progressbar" style="width: 25%" aria-valuenow="25" aria-valuemin="0" aria-valuemax="100"></div>
													            </div>
                                                            </div>
													        <div class="form-footer">
														        <!-- TASTO LOADING -->
														        <a class="ladda-button btn btn-primary btn-ladda" id="outMASettingSend" data-style="expand-right">
  															        <span class="ladda-label" data-translate="saveSetpoint"></span>
  															        <span class="ladda-spinner" data-translate="loadingSetpoint" style="display: none;"></span>
														        </a>
														        <!-- END TASTO LOADING -->
													        </div>
                                              </form>
                                          </div>
                                     </div>
                                  </div>
                              </div>
                              <!-- END contenuto OUT Ma -->
                              <!-- contenuto log settings-->
                              <div class="tab-pane fade" id="nav-profile9" role="tabpanel" aria-labelledby="nav-home-tab">
                                  <div class="card-body">
                                      <div class="tab-content mt-5" id="tabSubAdvanced8" >
                                          <div class="tab-pane fade show active " id="nav-tabs-logSettings" role="tabpanel" aria-labelledby="nav-home-tab">
                                              <form>
                                                            <div class="form-group" aria-haspopup="True">
															        <input type="checkbox" class="custom-control-input" id="logSettingsEnable"  onclick="$(this).prop('checked') ? $('#logSettingsGroup').show() : $('#logSettingsGroup').hide()">
															        <label class="custom-control-label" for="logSettingsEnable" data-translate="setpointIngressoEnable"></label>
													        </div>
                                                            <div id ="logSettingsGroup">
                                                                        <div class="custom-control custom-radio d-inline-block mr-3 mb-3">
															                    <label for="exampleFormControlSelect15" data-translate="logSettingsHour"></label>
															                    <select class="form-control rounded-0 bg-light" id="logSettingsHour">
                                                                                    <option value ="0">00</option>
                                                                                    <option value ="1">01</option>
                                                                                    <option value ="2">02</option>
                                                                                    <option value ="3">03</option>
                                                                                    <option value ="4">04</option>
                                                                                    <option value ="5">05</option>
                                                                                    <option value ="6">06</option>
                                                                                    <option value ="7">07</option>
                                                                                    <option value ="8">08</option>
                                                                                    <option value ="9">09</option>
                                                                                    <option value ="10">10</option>
                                                                                    <option value ="11">11</option>
                                                                                    <option value ="12">12</option>
                                                                                    <option value ="13">13</option>
                                                                                    <option value ="14">14</option>
                                                                                    <option value ="15">15</option>
                                                                                    <option value ="16">16</option>
                                                                                    <option value ="17">17</option>
                                                                                    <option value ="18">18</option>
                                                                                    <option value ="19">19</option>
                                                                                    <option value ="20">20</option>
                                                                                    <option value ="21">21</option>
                                                                                    <option value ="22">22</option>
                                                                                    <option value ="23">23</option>
															                    </select>
                                                                        </div>
                                                                        <div class="custom-control custom-radio d-inline-block mr-3 mb-3">
															                    <label for="exampleFormControlSelect15" data-translate="logSettingsMin"></label>
															                    <select class="form-control rounded-0 bg-light timeInsert" id="logSettingsMin">

															                    </select>
                                                                        </div>

                                                            </div>
                                                              <div class="form-footer ModeSendLoad"  style="display: none;">
                                                                <div class="progress mb-3" >
																      <div  class="progress-bar progress-bar-striped progress-bar-animated" role="progressbar" style="width: 25%" aria-valuenow="25" aria-valuemin="0" aria-valuemax="100"></div>
													            </div>
                                                            </div>
													        <div class="form-footer">
														        <!-- TASTO LOADING -->
														        <a class="ladda-button btn btn-primary btn-ladda" id="logSettingsSend" data-style="expand-right">
  															        <span class="ladda-label" data-translate="saveSetpoint"></span>
  															        <span class="ladda-spinner" data-translate="loadingSetpoint" style="display: none;"></span>
														        </a>
														        <!-- END TASTO LOADING -->
													        </div>

                                              </form>
                                           </div>
                                     </div>
                                   </div>
                              </div>
                              <!-- end log settings -->
                              <!-- contenuto message -->
                              <div class="tab-pane fade" id="nav-profile10" role="tabpanel" aria-labelledby="nav-home-tab">
                                  <div class="card-body">
                                      <ul class="nav nav-underline-active-primary mb-3" id="tab1" role="tablist">
	    								<li class="nav-item">
											<a class="nav-link active" id="nav-profile-smsMessage" data-toggle="pill" href="#nav-tabs-smsMessage" role="tab" aria-controls="nav-tabs" aria-selected="false">
										    <i class="mdi mdi-arrow-right-drop-circle-outline"></i> <span data-translate="smsMessage"></span></a>
										</li>
	    								<li class="nav-item">
											<a class="nav-link " id="nav-profile-mailMessage" data-toggle="pill" href="#nav-tabs-mailMessage" role="tab" aria-controls="nav-tabs" aria-selected="false">
										    <i class="mdi mdi-arrow-right-drop-circle-outline"></i> <span data-translate="mailSetting"></span></a>
										</li>
	    								<li class="nav-item">
											<a class="nav-link " id="nav-profile-activeMessage" data-toggle="pill" href="#nav-tabs-activeMessage" role="tab" aria-controls="nav-tabs" aria-selected="false">
										    <i class="mdi mdi-arrow-right-drop-circle-outline"></i> <span data-translate="activeMessage"></span></a>
										</li>
                                      </ul>
                                      <div class="tab-content mt-5" id="tabSubAdvanced11" >
                                          <div class="tab-pane fade show active " id="nav-tabs-smsMessage" role="tabpanel" aria-labelledby="nav-home-tab">
                                              <form>
												                <div class="form-group" aria-haspopup="True">
														                <label for="exampleFormControlPassword4" data-translate="sms1" ></label>
                                                                        <input type="text" class="form-control border-success sms" id="sms1Alarm"  labelMSG="smsInfo" labelMSGError="smsAlarm" maxlength="14"  placeholder="">
												                </div>
												                <div class="form-group" aria-haspopup="True">
														                <label for="exampleFormControlPassword4" data-translate="sms2" ></label>
                                                                        <input type="text" class="form-control border-success sms" id="sms2Alarm"  labelMSG="smsInfo" labelMSGError="smsAlarm" maxlength="14"  placeholder="">
												                </div>
                                                  <!--
												                <div class="form-group" aria-haspopup="True">
														                <label for="exampleFormControlPassword4" data-translate="sms3" ></label>
                                                                        <input type="text" class="form-control border-success sms" id="sms3Alarm"  labelMSG="smsInfo" labelMSGError="smsAlarm" maxlength="14"  placeholder="">
												                </div>
                                                  -->
														    <div class="form-footer ModeSendLoad"  style="display: none;">
                                                                <div class="progress mb-3" >
																      <div  class="progress-bar progress-bar-striped progress-bar-animated" role="progressbar" style="width: 25%" aria-valuenow="25" aria-valuemin="0" aria-valuemax="100"></div>
													            </div>
                                                            </div>
													        <div class="form-footer">
														        <!-- TASTO LOADING -->
														        <a class="ladda-button btn btn-primary btn-ladda" id="smsMessageSend" data-style="expand-right">
  															        <span class="ladda-label" data-translate="saveSetpoint"></span>
  															        <span class="ladda-spinner" data-translate="loadingSetpoint" style="display: none;"></span>
														        </a>
														        <!-- END TASTO LOADING -->
													        </div>

                                              </form>

                                           </div>
                                          <div class="tab-pane fade show " id="nav-tabs-mailMessage" role="tabpanel" aria-labelledby="nav-home-tab">
                                              <form>
												                <div class="form-group" aria-haspopup="True">
														                <label for="exampleFormControlPassword4" data-translate="mail1" ></label>
                                                                        <input type="text" class="form-control border-success mail" id="mail1Alarm"  labelMSG="mailInfo" labelMSGError="mailAlarm" maxlength="33"  placeholder="">
												                </div>
												                <div class="form-group" aria-haspopup="True">
														                <label for="exampleFormControlPassword4" data-translate="mail2" ></label>
                                                                        <input type="text" class="form-control border-success mail" id="mail2Alarm"  labelMSG="mailInfo" labelMSGError="mailAlarm" maxlength="33"  placeholder="">
												                </div>
														    <div class="form-footer ModeSendLoad"  style="display: none;">
                                                                <div class="progress mb-3" >
																      <div  class="progress-bar progress-bar-striped progress-bar-animated" role="progressbar" style="width: 25%" aria-valuenow="25" aria-valuemin="0" aria-valuemax="100"></div>
													            </div>
                                                            </div>
													        <div class="form-footer">
														        <!-- TASTO LOADING -->
														        <a class="ladda-button btn btn-primary btn-ladda" id="mailMessageSend" data-style="expand-right">
  															        <span class="ladda-label" data-translate="saveSetpoint"></span>
  															        <span class="ladda-spinner" data-translate="loadingSetpoint" style="display: none;"></span>
														        </a>
														        <!-- END TASTO LOADING -->
													        </div>

                                              </form>
                                           </div>
                                          <div class="tab-pane fade show " id="nav-tabs-activeMessage" role="tabpanel" aria-labelledby="nav-home-tab">
                                              <form>
                                                                  <div class="form-group" aria-haspopup="True">
                                                                      <label class="custom-label"  data-translate="activeMessage"></label>
                                                                   </div>
                                                                    <div Class="custom-control custom-checkbox d-inline-block mr-3 mb-3">
                                                                        <input type="checkbox" class="custom-control-input" id="highConductivityOutputEnable" >
															            <label class="custom-control-label" for="highConductivityOutputEnable" data-translate="highConductivityOutput"></label>
                                                                    </div>
                                                                    <div Class="custom-control custom-checkbox d-inline-block mr-3 mb-3">
                                                                        <input type="checkbox" class="custom-control-input" id="highConductivityInputEnable" >
															            <label class="custom-control-label" for="highConductivityInputEnable" data-translate="highConductivityInput"></label>
                                                                    </div>
                                                                    <div Class="custom-control custom-checkbox d-inline-block mr-3 mb-3">
                                                                        <input type="checkbox" class="custom-control-input" id="highTemperatureEnable" >
															            <label class="custom-control-label" for="highTemperatureEnable" data-translate="highTemperature"></label>
                                                                    </div>
                                                                    <div Class="custom-control custom-checkbox d-inline-block mr-3 mb-3">
                                                                        <input type="checkbox" class="custom-control-input" id="inputTempPump1Enable" >
															            <label class="custom-control-label" for="inputTempPump1Enable" data-translate="inputTempPump"></label>
                                                                    </div>
                                                                    <div Class="custom-control custom-checkbox d-inline-block mr-3 mb-3">
                                                                        <input type="checkbox" class="custom-control-input" id="inputPressureHighEnable" >
															            <label class="custom-control-label" for="inputPressureHighEnable" data-translate="inputPressureHigh"></label>
                                                                    </div>
                                                                    <div Class="custom-control custom-checkbox d-inline-block mr-3 mb-3">
                                                                        <input type="checkbox" class="custom-control-input" id="inputPressureLowEnable" >
															            <label class="custom-control-label" for="inputPressureLowEnable" data-translate="inputPressureLow"></label>
                                                                    </div>
                                                                    <div Class="custom-control custom-checkbox d-inline-block mr-3 mb-3">
                                                                        <input type="checkbox" class="custom-control-input" id="inputStbyEnable" >
															            <label class="custom-control-label" for="inputStbyEnable" data-translate="inputStandby"></label>
                                                                    </div>
                                                                    <div Class="custom-control custom-checkbox d-inline-block mr-3 mb-3">
                                                                        <input type="checkbox" class="custom-control-input" id="inputDosingAlarm1Enable" >
															            <label class="custom-control-label" for="inputDosingAlarm1Enable" data-translate="inputDosingAlarm"></label>
                                                                    </div>
                                                                    <div Class="custom-control custom-checkbox d-inline-block mr-3 mb-3">
                                                                        <input type="checkbox" class="custom-control-input" id="inputFilter1Enable" >
															            <label class="custom-control-label" for="inputFilter1Enable" data-translate="inputFilter"></label>
                                                                    </div>
                                                                    <div Class="custom-control custom-checkbox d-inline-block mr-3 mb-3">
                                                                        <input type="checkbox" class="custom-control-input" id="genericAlarmEnable" >
															            <label class="custom-control-label" for="genericAlarmEnable" data-translate="genericAlarm"></label>
                                                                    </div>
                                                                    <div Class="custom-control custom-checkbox d-inline-block mr-3 mb-3">
                                                                        <input type="checkbox" class="custom-control-input" id="inputLevelEnable" >
															            <label class="custom-control-label" for="inputLevelEnable" data-translate="inputLevel"></label>
                                                                    </div>


														    <div class="form-footer ModeSendLoad"  style="display: none;">
                                                                <div class="progress mb-3" >
																      <div  class="progress-bar progress-bar-striped progress-bar-animated" role="progressbar" style="width: 25%" aria-valuenow="25" aria-valuemin="0" aria-valuemax="100"></div>
													            </div>
                                                            </div>
													        <div class="form-footer">
														        <!-- TASTO LOADING -->
														        <a class="ladda-button btn btn-primary btn-ladda" id="activeMessageSend" data-style="expand-right">
  															        <span class="ladda-label" data-translate="saveSetpoint"></span>
  															        <span class="ladda-spinner" data-translate="loadingSetpoint" style="display: none;"></span>
														        </a>
														        <!-- END TASTO LOADING -->
													        </div>
                                              </form>
                                           </div>
                                      </div>
                                  </div>
                              </div>
                              <!-- end contenuto message -->
                              <!-- contenuto action -->
                              <div class="tab-pane fade" id="nav-profile11" role="tabpanel" aria-labelledby="nav-home-tab">
                                  <div class="card-body">
                                      <div class="tab-content mt-5" id="tabSubAdvanced10" >
                                          <div class="tab-pane fade show active " id="nav-tabs-action" role="tabpanel" aria-labelledby="nav-home-tab">
                                              <form>
                                                            <div class="form-group" aria-haspopup="True">
															        <input type="checkbox" class="custom-control-input" id="actionResetAlarm">
															        <label class="custom-control-label" for="actionResetAlarm" data-translate="resetAlarm"></label>
													        </div>
                                                            <div class="form-group" aria-haspopup="True">
															        <input type="checkbox" class="custom-control-input" id="actionOnOff">
															        <label class="custom-control-label" for="actionOnOff" id="actionOnLabel" data-translate="onPump" style="display: none;"></label>
                                                                    <label class="custom-control-label" for="actionOnOff" id="actionOffLabel" data-translate="offPump"style="display: none;"></label>
													        </div>
                                                              <div class="form-footer ModeSendLoad"  style="display: none;">
                                                                <div class="progress mb-3" >
																      <div  class="progress-bar progress-bar-striped progress-bar-animated" role="progressbar" style="width: 25%" aria-valuenow="25" aria-valuemin="0" aria-valuemax="100"></div>
													            </div>
                                                            </div>
													        <div class="form-footer">
														        <!-- TASTO LOADING -->
														        <a class="ladda-button btn btn-primary btn-ladda" id="actionSend" data-style="expand-right">
  															        <span class="ladda-label" data-translate="saveSetpoint"></span>
  															        <span class="ladda-spinner" data-translate="loadingSetpoint" style="display: none;"></span>
														        </a>
														        <!-- END TASTO LOADING -->
													        </div>
                                              </form>
                                          </div>
                                      </div>
                                  </div>
                              </div>
                              <!-- end contenuto action -->
                          </div>
                      </div>
                  </div>
                  <!-- LOG GRAPH POMPA -->
                  <div class="card card-default">
                      <div class="card-header">
                          <h2>LOG</h2>
                      </div>
                      
                      <div class="card-body " id ="mainLogGraph">
                          <form>
                              <h5 class="card-title">Measure</h5>
                                  <div class="custom-control custom-checkbox d-inline-block mr-3 mb-3">
									  <input type="checkbox" class="custom-control-input refreshLog" id="logGraphConductivityInput" checked="checked">
									  <label class="custom-control-label" for="logGraphConductivityInput" data-translate="titleIngresso"></label>
 								  </div>
                                  <div class="custom-control custom-checkbox d-inline-block mr-3 mb-3">
									  <input type="checkbox" class="custom-control-input refreshLog" id="logGraphConductivityOutput" checked="checked">
									  <label class="custom-control-label" for="logGraphConductivityOutput" data-translate="titleUscita"></label>
 								  </div>
                                  <div class="custom-control custom-checkbox d-inline-block mr-3 mb-3">
									  <input type="checkbox" class="custom-control-input refreshLog" id="logGraphTemperatura" >
									  <label class="custom-control-label" for="logGraphTemperatura" data-translate="temperaturaSonda"></label>
 								  </div>
                          </form>
                          <hr>
                          <form>
                              <h5 class="card-title">Alarm</h5>
                                    <div Class="custom-control custom-checkbox d-inline-block mr-3 mb-3">
                                        <input type="checkbox" class="custom-control-input refreshLog" id="logGraphHighConductivityOutputEnable" >
                                        <label class="custom-control-label" for="logGraphHighConductivityOutputEnable" data-translate="highConductivityOutput"></label>
                                    </div>
                                    <div Class="custom-control custom-checkbox d-inline-block mr-3 mb-3">
                                        <input type="checkbox" class="custom-control-input refreshLog" id="logGraphHighConductivityInputEnable" >
                                        <label class="custom-control-label" for="logGraphHighConductivityInputEnable" data-translate="highConductivityInput"></label>
                                    </div>
                                    <div Class="custom-control custom-checkbox d-inline-block mr-3 mb-3">
                                        <input type="checkbox" class="custom-control-input refreshLog" id="logGraphHighTemperatureEnable" >
                                        <label class="custom-control-label" for="logGraphHighTemperatureEnable" data-translate="highTemperature"></label>
                                    </div>
                                    <div Class="custom-control custom-checkbox d-inline-block mr-3 mb-3">
                                        <input type="checkbox" class="custom-control-input refreshLog" id="logGraphInputTempPumpEnable" >
                                        <label class="custom-control-label" for="logGraphInputTempPumpEnable" data-translate="inputTempPump"></label>
                                    </div>
                                   <div Class="custom-control custom-checkbox d-inline-block mr-3 mb-3">
                                        <input type="checkbox" class="custom-control-input refreshLog" id="logGraphInputPressureHighEnable" >
                                        <label class="custom-control-label" for="logGraphInputPressureHighEnable" data-translate="inputPressureHigh"></label>
                                   </div>
                                   <div Class="custom-control custom-checkbox d-inline-block mr-3 mb-3">
                                        <input type="checkbox" class="custom-control-input refreshLog" id="logGraphInputPressureLowEnable" >
                                        <label class="custom-control-label" for="logGraphInputPressureLowEnable" data-translate="inputPressureLow"></label>
                                    </div>
                                  <div Class="custom-control custom-checkbox d-inline-block mr-3 mb-3">
                                       <input type="checkbox" class="custom-control-input refreshLog" id="logGraphInputStbyEnable" >
                                        <label class="custom-control-label" for="logGraphInputStbyEnable" data-translate="inputStandby"></label>
                                   </div>
                                    <div Class="custom-control custom-checkbox d-inline-block mr-3 mb-3">
                                        <input type="checkbox" class="custom-control-input refreshLog" id="logGraphInputDosingAlarmEnable" >
                                        <label class="custom-control-label" for="logGraphInputDosingAlarmEnable" data-translate="inputDosingAlarm"></label>
                                    </div>
                                    <div Class="custom-control custom-checkbox d-inline-block mr-3 mb-3">
                                        <input type="checkbox" class="custom-control-input refreshLog" id="logGraphInputFilterEnable" >
                                        <label class="custom-control-label" for="logGraphInputFilterEnable" data-translate="inputFilter"></label>
                                    </div>
                                    <div Class="custom-control custom-checkbox d-inline-block mr-3 mb-3">
                                        <input type="checkbox" class="custom-control-input refreshLog" id="logGraphGenericAlarmEnable" >
                                        <label class="custom-control-label" for="logGraphGenericAlarmEnable" data-translate="genericAlarm"></label>
                                    </div>
                                  <div Class="custom-control custom-checkbox d-inline-block mr-3 mb-3">
                                       <input type="checkbox" class="custom-control-input refreshLog" id="logGraphInputLevelEnable" >
                                        <label class="custom-control-label" for="logGraphInputLevelEnable" data-translate="inputLevel"></label>
                                   </div>
                          </form>
                          <hr>
                          <form>
                              <h5 class="card-title">Output</h5>
                                  <div class="custom-control custom-checkbox d-inline-block mr-3 mb-3">
									  <input type="checkbox" class="custom-control-input refreshLog" id="logGraphEvIngresso" >
									  <label class="custom-control-label" for="logGraphEvIngresso" data-translate="evIngresso"></label>
 								  </div>
                                  <div class="custom-control custom-checkbox d-inline-block mr-3 mb-3">
									  <input type="checkbox" class="custom-control-input refreshLog" id="logGraphEvUscita" >
									  <label class="custom-control-label" for="logGraphEvUscita" data-translate="evUscita"></label>
 								  </div>
                                  <div class="custom-control custom-checkbox d-inline-block mr-3 mb-3">
									  <input type="checkbox" class="custom-control-input refreshLog" id="logGraphEvScarico" >
									  <label class="custom-control-label" for="logGraphEvScarico" data-translate="evScarico"></label>
 								  </div>
                                  <div class="custom-control custom-checkbox d-inline-block mr-3 mb-3">
									  <input type="checkbox" class="custom-control-input refreshLog" id="logGraphPompaOsmosi" >
									  <label class="custom-control-label" for="logGraphPompaOsmosi" data-translate="pompaOsmosi"></label>
 								  </div>
                                  <div class="custom-control custom-checkbox d-inline-block mr-3 mb-3">
									  <input type="checkbox" class="custom-control-input refreshLog" id="logGraphPompaDosaggio" >
									  <label class="custom-control-label" for="logGraphPompaDosaggio" data-translate="pompaDosaggio"></label>
 								  </div>
                                  <div class="custom-control custom-checkbox d-inline-block mr-3 mb-3">
									  <input type="checkbox" class="custom-control-input refreshLog" id="logGraphOutAlarm" >
									  <label class="custom-control-label" for="logGraphOutAlarm" data-translate="outAlarm"></label>
 								  </div>
                          </form>
                          <hr>
                          <form>
                              <h5 class="card-title">Water Meter</h5>
                                  <div class="custom-control custom-checkbox d-inline-block mr-3 mb-3">
									  <input type="checkbox" class="custom-control-input refreshLog" id="logGraphTotUscita" >
									  <label class="custom-control-label" for="logGraphTotUscita" data-translate="totUscitaT"></label>
 								  </div>
                                  <div class="custom-control custom-checkbox d-inline-block mr-3 mb-3">
									  <input type="checkbox" class="custom-control-input refreshLog" id="logGraphTotIngresso" >
									  <label class="custom-control-label" for="logGraphTotIngresso" data-translate="totIngressoT"></label>
 								  </div>
                                  <div class="custom-control custom-checkbox d-inline-block mr-3 mb-3">
									  <input type="checkbox" class="custom-control-input refreshLog" id="logGraphFlowMeterIngresso" >
									  <label class="custom-control-label" for="logGraphFlowMeterIngresso" data-translate="portataIstantaneaIngresso"></label>
 								  </div>
                                  <div class="custom-control custom-checkbox d-inline-block mr-3 mb-3">
									  <input type="checkbox" class="custom-control-input refreshLog" id="logGraphFlowMeterUscita" >
									  <label class="custom-control-label" for="logGraphFlowMeterUscita" data-translate="portataIstantaneaUscita"></label>
 								  </div>
                          </form>
                          <hr>
						  <form>
                              <h5 class="card-title">Range</h5>
								<div class="custom-radio d-inline-block mr-3 mb-3">
								    <label for="exampleFormControlSelect15" data-translate="days">Days</label>
									    <select class="form-control rounded-0 bg-light" id="logDaySelect">
                                            <option value="1">1</option><option value="2">2</option><option value="3">3</option><option value="4">4</option><option value="5">5</option><option value="6">6</option><option value="7">7</option><option value="8">8</option><option value="9">9</option><option value="10">10</option><option value="11">11</option><option value="12">12</option><option value="13">13</option><option value="14">14</option><option value="15">15</option><option value="16">16</option><option value="17">17</option><option value="18">18</option><option value="19">19</option><option value="20">20</option><option value="21">21</option><option value="22">22</option><option value="23">23</option><option value="24">24</option><option value="25">25</option><option value="26">26</option><option value="27">27</option><option value="28">28</option><option value="29">29</option><option value="30">30</option><option value="31">31</option>
									    </select>
                                 </div>
                          </form>
                          <hr>
                          <form>
                              <h5 class="card-title">Status</h5>
								<div class="custom-radio d-inline-block mr-3 mb-3">
                                    <div class="sk-three-bounce" id="statusReadLogAnimation" style="display: none;">
                                            <div class="bounce1"></div>
                                            <div class="bounce2"></div>
                                            <div class="bounce3"></div>
                                     </div>
								    <label for="exampleFormControlSelect15" id="statusReadLog"></label>
                                 </div>
                          
                          </form>
                          <hr>
                          <div id="chart_div">
                          </div>
                          <hr>
                          <div id="chart_table" class="display" style="width:100%">
                          </div>
                      </div>
                   </div>
                  <!-- END LOG GRAPH POMPA -->
              </div>
          </div>
      </div>
    </div>

    <script type="text/javascript" src="M0201.js?v=1.50"></script>
    <script type="text/javascript" src="traduzioni/T0201.js?v=1.44"></script>
    <asp:Literal ID="javaScriptHeader" runat="server"></asp:Literal>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="script_footerAssets" runat="server">
</asp:Content>

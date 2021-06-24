<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MainNew.Master" CodeBehind="M0101.aspx.vb" Inherits="ermes_web_20.M0101" %>
<%@ MasterType VirtualPath="~/MainNew.Master"%>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content-wrapper">
      <div class="content">                
          <div class="row">
              <div class="col-xl-12">
                  <div class="card card-default">
                      <div class="card-header">
                              <h2>LDOSIN - 20117930500000001</h2>
                       </div>
   					   <!-- DATI -->
					  <div class="card-body">
                          <h3 id='modalitaLavoro_SN'></h3><h2 id='portata_SN'><span class="little"></span></h2> <br/> 
                          <div class="list-group-item list-group-item-action " id='valore1_SN' data-toggle="tooltip" data-placement="top" title="" data-original-title="Tooltip on top"></div>
                          <div class="list-group-item list-group-item-action " id='valore2_SN' data-toggle="tooltip" data-placement="top" title="" data-original-title="Tooltip on top"></div>
                          <div class="list-group-item list-group-item-action " id='valore3_SN' data-toggle="tooltip" data-placement="top" title="" data-original-title="Tooltip on top"></div>
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
				   <!-- SISTEMA  CONNESSO -->
					  <div id='statusConnection_SN' class="card-body pb-0">
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
								  <h5 class="card-title" data-translate="statistiche"></h5>
									 <div class="accordion accordion-header-border-bottom" id="accordionHeaderBorderBottom">
                                        <div class="card">
                                            <div class="card-header" id="headingBorderBottomOne">
                                                <h2 class="mb-0">
                                                    <button class="btn btn-link collapsed" type="button" data-toggle="collapse" data-target="#collapseBorderBottomOne" aria-expanded="false" aria-controls="collapseBorderBottomOne" data-translate="totali">
                                                    </button>
                                                </h2>
                                            </div>
                                            <div id="collapseBorderBottomOne" class="collapse" aria-labelledby="headingBorderBottomOne"data-parent="#accordionHeaderBorderBottom">
                                                <div class="card-body">
		                                            <div class="alert alert-primary alert-outlined" role="alert">
    		                                            <strong data-translate="dosato"> </strong><span id="dosatoTotale"> 1.78 1L </span><br>
  		                                            </div>
		                                            <div class="alert alert-primary alert-outlined" role="alert">
    		                                            <strong data-translate="contatore"> </strong><span id="contatoreTotale">0mc</span> <br>
  		                                            </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="card">
                                            <div class="card-header" id="headingBorderBottomTwo">
                                                <h2 class="mb-0">
                                                    <button class="btn btn-link collapsed" type="button" data-toggle="collapse" data-target="#collapseBorderBottomTwo" aria-expanded="false" aria-controls="collapseBorderBottomTwo" data-translate="parziali">
                                                        
                                                    </button>
                                                </h2>
                                             </div>
                                             <div id="collapseBorderBottomTwo" class="collapse" aria-labelledby="headingBorderBottomTwo" data-parent="#accordionHeaderBorderBottom">
                                                <div class="card-body">
                                                    <div class="alert alert-primary alert-outlined" role="alert" >
    		                                            <strong data-translate="dosato"></strong><span id="dosatoParziale">0ml</span> <br>
  		                                            </div>
		                                            <div class="alert alert-primary alert-outlined" role="alert">
    		                                            <strong data-translate="contatore"> </strong><span id="contatoreParziale">0mc</span><br>
  		                                            </div>
		                                            <div class="alert alert-primary alert-outlined" role="alert">
    		                                            <strong data-translate="dosato" > </strong><span id="dosatoParzialeUltime24">24h:0ml </span><br>
  		                                            </div>
		                                            <div class="alert alert-primary alert-outlined" role="alert">
    		                                            <strong data-translate="contatore" > </strong><span id="contatoreParzialeUltime24">24h:0mc </span><br>
  		                                            </div>
		                                            <div class="alert alert-primary alert-outlined" role="alert">
    		                                            <strong data-translate="dal" > </strong> <i class="mdi mdi-calendar-multiselect"></i><span id="dalParzialeData">  </span><i class="mdi mdi-clock" ></i><span id="dalParzialeOra">   </span><br>
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
								  <h5 class="card-title" data-translate="riserva"></h5>
									<div class="row justify-content-center">
									    <div class="alert alert-primary alert-outlined" role="alert"><span id="prismaRiserva">0.000 L </span><br>
  		                                </div>
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
									<div class="row justify-content-center">
									    <div class="alert alert-primary alert-outlined" role="alert"><span id="prismaPortataIstantanea">0.000 L </span><br>
  		                                </div>
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
				   <!-- menu modalità lavoro e more -->
					   <ul class="nav nav-pills mb-3" id="pills-tab2" role="tablist">
 						 <li class="nav-item">
							<a class="nav-link active" id="pills-home-tab" data-toggle="pill" href="#nav-tabs-home2" role="tab"aria-controls="nav-tabs" aria-selected="true">
							  <i class="mdi mdi-wrench"></i><span data-translate="workingMode"> </span></a>
						 </li>
 						 <li class="nav-item">
                            <a class="nav-link" id="nav-profile-tab" data-toggle="pill" href="#nav-profile2" role="tab"aria-controls="nav-profile" aria-selected="false">
                            <i class="mdi mdi-plus-circle"></i> <span data-translate="more"></span></a>
                        </li>
  					  </ul>
				      <!-- end menu modalità lavoro e more -->
					  <!-- contenuto modalità lavoro e more -->
    				  <div class="tab-content mt-5" id="nav-tabContent">
					   <!-- contenuto modalità lavoro -->
						  <div class="tab-pane fade show active" id="nav-tabs-home2" role="tabpanel" aria-labelledby="nav-home-tab">
							  <div class="card-body">
    							  <ul class="nav nav-underline-active-primary mb-3" id="tabAdvanced" role="tablist">
	    								<li class="nav-item">
											<a class="nav-link " id="nav-profile-constant" data-toggle="pill" href="#nav-tabs-constant" role="tab" aria-controls="nav-tabs" aria-selected="false">
												<i class="mdi mdi-arrow-right-drop-circle-outline"></i> <span data-translate="modalita0"></span></a>
										</li>
										<li class="nav-item">
											<a class="nav-link" id="nav-profile-ccpulse" data-toggle="pill" href="#nav-tabs-ccpulse" role="tab" aria-controls="nav-tabs" aria-selected="false">
												<i class="mdi mdi-arrow-right-drop-circle-outline"></i><span data-translate="modalita1"> </span></a>
										 </li>
										 <li class="nav-item">
											<a class="nav-link" id="nav-profile-ppm" data-toggle="pill" href="#nav-tabs-ppm" role="tab" aria-controls="nav-tabs" aria-selected="false">
												<i class="mdi mdi-arrow-right-drop-circle-outline"></i><span data-translate="modalita2"></span></a>
										 </li>
										 <li class="nav-item">
											<a class="nav-link" id="nav-profile-perc" data-toggle="pill" href="#nav-tabs-perc" role="tab" aria-controls="nav-tabs" aria-selected="false">
												<i class="mdi mdi-arrow-right-drop-circle-outline"></i><span data-translate="modalita3"></span></a>
										 </li>
										 <li class="nav-item">
											<a class="nav-link" id="nav-profile-mlq" data-toggle="pill" href="#nav-tabs-mlq" role="tab"	aria-controls="nav-tabs" aria-selected="false">
												<i class="mdi mdi-arrow-right-drop-circle-outline"></i><span data-translate="modalita4"></span></a>
										 </li>
										 <li class="nav-item">
											<a class="nav-link" id="nav-profile-batch" data-toggle="pill" href="#nav-tabs-batch" role="tab" aria-controls="nav-tabs" aria-selected="false">
												<i class="mdi mdi-arrow-right-drop-circle-outline"></i><span data-translate="modalita5"></span></a>
										 </li>
										 <li class="nav-item">
											<a class="nav-link" id="nav-profile-volt" data-toggle="pill" href="#nav-tabs-volt" role="tab" aria-controls="nav-tabs" aria-selected="false">
												<i class="mdi mdi-arrow-right-drop-circle-outline"></i><span data-translate="modalita6"></span></a>
										 </li>
										 <li class="nav-item">
											<a class="nav-link" id="nav-profile-ma" data-toggle="pill" href="#nav-tabs-ma" role="tab"aria-controls="nav-tabs" aria-selected="false">
												<i class="mdi mdi-arrow-right-drop-circle-outline"></i><span data-translate="modalita7"></span></a>
										 </li>
										  <li class="nav-item">
											 <a class="nav-link" id="nav-profile-pulse" data-toggle="pill" href="#nav-tabs-pulse" role="tab" aria-controls="nav-tabs" aria-selected="false">
												<i class="mdi mdi-arrow-right-drop-circle-outline"></i><span data-translate="modalita8"></span></a>
										  </li>
										  <li class="nav-item">
											 <a class="nav-link" id="nav-profile-pausework" data-toggle="pill" href="#nav-tabs-pausework" role="tab" aria-controls="nav-tabs" aria-selected="false">
												<i class="mdi mdi-arrow-right-drop-circle-outline"></i> <span data-translate="modalita9"></span></a>
										  </li>
										  <li class="nav-item">
											 <a class="nav-link" id="nav-profile-weekly" data-toggle="pill" href="#nav-tabs-weekly" role="tab" aria-controls="nav-tabs" aria-selected="false">
												<i class="mdi mdi-arrow-right-drop-circle-outline"></i><span data-translate="modalita10"></span></a>
										  </li>
									</ul>
									 <!-- end menu modalità lavoro -->
									 <!-- menu settings modalità lavoro -->
                                      <!-- modalita costante -->
									  <div class="tab-content mt-5" id="tabSubAdvanced" >
											<div class="tab-pane fade show " id="nav-tabs-constant" role="tabpanel" aria-labelledby="nav-home-tab">
												<form>
													<div class="form-group ">
														<label for="exampleFormControlPassword4" data-translate="constantSetpoint" ></label>
                                                        <label for="exampleFormControlPassword4"  id="constantDosaggioUnit"></label>
														<input type="number" class="form-control border-success numerico" id="constantDosaggio" min ="0.000" max ="99.000" labelMSG="constantDos" labelMSGError="constantDosAlarm" step="0.001" decimal ="3" maxlength="6" data-mask="00.000" placeholder="">
                                                        <!--border-info border-warning border-danger 
                                                        <div class="text-success small mt-1">
                                                            Looks good!
                                                       </div>
                                                            -->
                                                        <!--text-info text-warning text-danger -->
													</div>
                                                    <div class="form-footer ModeSendLoad"  style="display: none;">
                                                        <div class="progress mb-3" >
																  <div  class="progress-bar progress-bar-striped progress-bar-animated" role="progressbar" style="width: 25%" aria-valuenow="25" aria-valuemin="0" aria-valuemax="100"></div>
													    </div>
                                                    </div>
													<div class="form-footer">
														<!-- TASTO LOADING -->
														<a class="ladda-button btn btn-primary btn-ladda" id="constantModeSend" data-style="expand-right">
  															<span class="ladda-label" data-translate="saveSetpoint"></span>
  															<span class="ladda-spinner" data-translate="loadingSetpoint" style="display: none;"></span>
														</a>
														<!-- END TASTO LOADING -->
													</div>
												  </form>
												</div>
                                      <!-- end modalita costante -->
                                      <!-- modalita cc Pulse -->
    										<div class="tab-pane fade show " id="nav-tabs-ccpulse" role="tabpanel" aria-labelledby="nav-home-tab">
												<form>
                                                       <div class="custom-control custom-checkbox d-inline-block mr-3 mb-3">
															<input type="checkbox" class="custom-control-input" id="diluizioneSet" checked="checked">
															<label class="custom-control-label" for="diluizioneSet" data-translate="diluizioneSetpoint"></label>
														</div>
													<div class="form-group" aria-haspopup="True">
														<label for="exampleFormControlPassword4" data-translate="ccPulseSetpoint" ></label>
                                                        <label for="exampleFormControlPassword4" > ml/Pulse</label>
														<input type="number" class="form-control border-success numerico" id="ccPulseSetpoint" min ="0.0000" max ="99.0000" step="0.0001" labelMSG="ccPulseInfo" labelMSGError="ccPulseAlarm" decimal ="4" maxlength="7" data-mask="00.0000" placeholder="">
                                                        <!--border-info border-warning border-danger 
                                                        <div class="text-success small mt-1">
                                                            Looks good!
                                                       </div>
                                                            -->
                                                        <!--text-info text-warning text-danger -->
													</div>
                                                     <div class="custom-control custom-radio d-inline-block mr-3 mb-3">
															<label for="exampleFormControlSelect15" data-translate="waterMeterSetpoint"></label>
															<select class="form-control rounded-0 bg-light" id ="waterMeterCCPulseSetpoint" >
																<option value ="0" data-translate="waterMeterPulseLitreSetpoint"></option>
																<option value ="1" data-translate="waterMeterLitrePulseSetpoint"></option>
															</select>
													</div>
													<div class="custom-control custom-radio d-inline-block mr-3 mb-3">
														<label for="exampleFormControlPassword4" data-translate="waterMeterKSetpoint" ></label>
														<input type="number" class="form-control border-success numerico" id ="waterMeterKCCPulseSetpoint"  min ="0.0" max ="1200.0" step="0.1" labelMSG="waterMeterKInfo" labelMSGError="waterMeterKAlarm" decimal ="1" maxlength="6" data-mask="0000.0" placeholder="">
                                                        <!--border-info border-warning border-danger 
                                                        <div class="text-success small mt-1">
                                                            Looks good!
                                                       </div>
                                                            -->
                                                        <!--text-info text-warning text-danger -->
													</div>
													<div class="form-footer ModeSendLoad"  style="display: none;">
                                                        <div class="progress mb-3" >
																  <div  class="progress-bar progress-bar-striped progress-bar-animated" role="progressbar" style="width: 25%" aria-valuenow="25" aria-valuemin="0" aria-valuemax="100"></div>
													    </div>
                                                    </div>
													<div class="form-footer">
														<!-- TASTO LOADING -->
														<a class="ladda-button btn btn-primary btn-ladda " id="ccpulseModeSend" data-style="expand-right">
  															<span class="ladda-label" data-translate="saveSetpoint"></span>
  															<span class="ladda-spinner" data-translate="loadingSetpoint" style="display: none;"></span>
														</a>
														<!-- END TASTO LOADING -->
													</div>
												  </form>
											</div>
                                        <!-- end modalita ccpulse -->
                                       <!-- modalita ppm -->
    										<div class="tab-pane fade show " id="nav-tabs-ppm" role="tabpanel" aria-labelledby="nav-home-tab">
												<form>
													<div class="form-group" aria-haspopup="True">
														<label for="exampleFormControlPassword4" data-translate="ppmSetpoint" ></label>
                                                        <label for="exampleFormControlPassword4" > ppm</label>
														<input type="number" class="form-control border-success numerico" id="ppmSetpoint" min ="0.01" max ="9999.99" step="0.01" labelMSG="ppmInfo" labelMSGError="ppmAlarm" decimal ="2" maxlength="7" data-mask="0000.00" placeholder="">
													</div>
													<div class="form-group" aria-haspopup="True">
														<label for="exampleFormControlPassword4" data-translate="concentrazioneSetpoint" ></label>
                                                        <label for="exampleFormControlPassword4" > %</label>
														<input type="number" class="form-control border-success numerico" id="concentrazioneSetpoint" min ="0.1" max ="100.0" step="0.1" labelMSG="concentrazioneInfo" labelMSGError="concentrazioneAlarm" decimal ="1" maxlength="5" data-mask="000.0" placeholder="">
													</div>
                                                     <div class="custom-control custom-radio d-inline-block mr-3 mb-3">
															<label for="exampleFormControlSelect15" data-translate="waterMeterSetpoint"></label>
															<select class="form-control rounded-0 bg-light " id ="waterMeterPPMSetpoint">
																<option value ="0" data-translate="waterMeterPulseLitreSetpoint"></option>
																<option value ="1" data-translate="waterMeterLitrePulseSetpoint"></option>
															</select>
													</div>
													<div class="custom-control custom-radio d-inline-block mr-3 mb-3">
														<label for="exampleFormControlPassword4" data-translate="waterMeterKSetpoint" ></label>
														<input type="number" class="form-control border-success numerico" id ="waterMeterKPPMSetpoint"  min ="0.0" max ="1200.0" step="0.1" labelMSG="waterMeterKInfo" labelMSGError="waterMeterKAlarm" decimal ="1" maxlength="6" data-mask="0000.0" placeholder="">
                                                        <!--border-info border-warning border-danger 
                                                        <div class="text-success small mt-1">
                                                            Looks good!
                                                       </div>
                                                            -->
                                                        <!--text-info text-warning text-danger -->
													</div>
                                                    <div class="form-group" aria-haspopup="True">
															<input type="checkbox" class="custom-control-input" id="upkeepPPMSet" checked="checked" onclick="$(this).prop('checked') ? $('#ppmUpkeepGroup').show() : $('#ppmUpkeepGroup').hide()">
															<label class="custom-control-label" for="upkeepPPMSet" data-translate="upkeepSetpoint"></label>
													</div>
                                                    <div id ="ppmUpkeepGroup">
                                                        <div class="custom-control custom-radio d-inline-block mr-3 mb-3">
															    <label for="exampleFormControlSelect15" data-translate="timeoutUpkeepOreSetpoint"></label>
															    <select class="form-control rounded-0 bg-light" id="timeoutUpkeepPPMOreSetpoint">
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
                                                                    <option value ="24">24</option>
															    </select>
                                                        </div>
                                                        <div class="custom-control custom-radio d-inline-block mr-3 mb-3">
															    <label for="exampleFormControlSelect15" data-translate="timeoutUpkeepMinutiSetpoint"></label>
															    <select class="form-control rounded-0 bg-light" id="timeoutUpkeepPPMMinutiSetpoint">
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
                                                                    <option value ="24">24</option>
                                                                    <option value ="25">25</option>
                                                                    <option value ="26">26</option>
                                                                    <option value ="27">27</option>
                                                                    <option value ="28">28</option>
                                                                    <option value ="29">29</option>
                                                                    <option value ="30">30</option>
                                                                    <option value ="31">31</option>
                                                                    <option value ="32">32</option>
                                                                    <option value ="33">33</option>
                                                                    <option value ="34">34</option>
                                                                    <option value ="35">35</option>
                                                                    <option value ="36">36</option>
                                                                    <option value ="37">37</option>
                                                                    <option value ="38">38</option>
                                                                    <option value ="39">39</option>
                                                                    <option value ="40">40</option>
                                                                    <option value ="41">41</option>
                                                                    <option value ="42">42</option>
                                                                    <option value ="43">43</option>
                                                                    <option value ="44">44</option>
                                                                    <option value ="45">45</option>
                                                                    <option value ="46">46</option>
                                                                    <option value ="47">47</option>
                                                                    <option value ="48">48</option>
                                                                    <option value ="49">49</option>
                                                                    <option value ="50">50</option>
                                                                    <option value ="51">51</option>
                                                                    <option value ="52">52</option>
                                                                    <option value ="53">53</option>
                                                                    <option value ="54">54</option>
                                                                    <option value ="55">55</option>
                                                                    <option value ="56">56</option>
                                                                    <option value ="57">57</option>
                                                                    <option value ="58">58</option>
                                                                    <option value ="59">59</option>
															    </select>
                                                        </div>
													    <div class="form-group ">
														    <label for="exampleFormControlPassword4" data-translate="constantSetpoint" ></label>
                                                            <label for="exampleFormControlPassword4"  id="upkeepDosaggioPPMUnit"></label>
														    <input type="number" class="form-control border-success numerico" id="upkeepDosaggioPPM" min ="0.000" max ="99.000" labelMSG="constantDos" labelMSGError="constantDosAlarm" step="0.001" decimal ="3" maxlength="6" data-mask="00.000" placeholder="">
                                                            <!--border-info border-warning border-danger 
                                                            <div class="text-success small mt-1">
                                                                Looks good!
                                                           </div>
                                                                -->
                                                            <!--text-info text-warning text-danger -->
													    </div>
                                                    </div>
                                                    <div class="form-footer ModeSendLoad"  style="display: none;">
                                                        <div class="progress mb-3" >
																  <div  class="progress-bar progress-bar-striped progress-bar-animated" role="progressbar" style="width: 25%" aria-valuenow="25" aria-valuemin="0" aria-valuemax="100"></div>
													    </div>
                                                    </div>
													<div class="form-footer">
														<!-- TASTO LOADING -->
														<a class="ladda-button btn btn-primary btn-ladda" id="ppmModeSend" data-style="expand-right">
  															<span class="ladda-label" data-translate="saveSetpoint"></span>
  															<span class="ladda-spinner" data-translate="loadingSetpoint" style="display: none;"></span>
														</a>
														<!-- END TASTO LOADING -->
													</div>
												  </form>
											</div>
                                       <!-- end modalita ppm -->
                                       <!-- modalita perc -->
    										<div class="tab-pane fade show " id="nav-tabs-perc" role="tabpanel" aria-labelledby="nav-home-tab">
												<form>
													<div class="form-group" aria-haspopup="True">
														<label for="exampleFormControlPassword4" data-translate="percSetpoint" ></label>
                                                        <label for="exampleFormControlPassword4" > %</label>
														<input type="number" class="form-control border-success numerico" id="percSetpoint" min ="0.01" max ="100.00" step="0.01" labelMSG="percInfo" labelMSGError="percAlarm" decimal ="2" maxlength="6" data-mask="000.00" placeholder="">
													</div>
													<div class="form-group" aria-haspopup="True">
														<label for="exampleFormControlPassword4" data-translate="concentrazioneSetpoint" ></label>
                                                        <label for="exampleFormControlPassword4" > %</label>
														<input type="number" class="form-control border-success numerico" id="concentrazionePercSetpoint" min ="0.1" max ="100.0" step="0.1" labelMSG="concentrazioneInfo" labelMSGError="concentrazioneAlarm" decimal ="1" maxlength="5" data-mask="000.0" placeholder="">
													</div>
                                                     <div class="custom-control custom-radio d-inline-block mr-3 mb-3">
															<label for="exampleFormControlSelect15" data-translate="waterMeterSetpoint"></label>
															<select class="form-control rounded-0 bg-light " id ="waterMeterPercSetpoint">
																<option value ="0" data-translate="waterMeterPulseLitreSetpoint"></option>
																<option value ="1" data-translate="waterMeterLitrePulseSetpoint"></option>
															</select>
													</div>
													<div class="custom-control custom-radio d-inline-block mr-3 mb-3">
														<label for="exampleFormControlPassword4" data-translate="waterMeterKSetpoint" ></label>
														<input type="number" class="form-control border-success numerico " id ="waterMeterKPercSetpoint"  min ="0.0" max ="1200.0" step="0.1" labelMSG="waterMeterKInfo" labelMSGError="waterMeterKAlarm" decimal ="1" maxlength="6" data-mask="0000.0" placeholder="">
                                                        <!--border-info border-warning border-danger 
                                                        <div class="text-success small mt-1">
                                                            Looks good!
                                                       </div>
                                                            -->
                                                        <!--text-info text-warning text-danger -->
													</div>
                                                    <div class="form-group" aria-haspopup="True">
															<input type="checkbox" class="custom-control-input " id="upkeepPercSet" checked="checked" onclick="$(this).prop('checked') ? $('#percUpkeepGroup').show() : $('#percUpkeepGroup').hide()">
															<label class="custom-control-label" for="upkeepPercSet" data-translate="upkeepSetpoint"></label>
													</div>
                                                    <div id ="percUpkeepGroup">
                                                        <div class="custom-control custom-radio d-inline-block mr-3 mb-3">
															    <label for="exampleFormControlSelect15" data-translate="timeoutUpkeepOreSetpoint"></label>
															    <select class="form-control rounded-0 bg-light" id="timeoutUpkeepOrePercSetpoint">
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
                                                                    <option value ="24">24</option>
															    </select>
                                                        </div>
                                                        <div class="custom-control custom-radio d-inline-block mr-3 mb-3">
															    <label for="exampleFormControlSelect15" data-translate="timeoutUpkeepMinutiSetpoint"></label>
															    <select class="form-control rounded-0 bg-light" id="timeoutUpkeepMinutiPercSetpoint">
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
                                                                    <option value ="24">24</option>
                                                                    <option value ="25">25</option>
                                                                    <option value ="26">26</option>
                                                                    <option value ="27">27</option>
                                                                    <option value ="28">28</option>
                                                                    <option value ="29">29</option>
                                                                    <option value ="30">30</option>
                                                                    <option value ="31">31</option>
                                                                    <option value ="32">32</option>
                                                                    <option value ="33">33</option>
                                                                    <option value ="34">34</option>
                                                                    <option value ="35">35</option>
                                                                    <option value ="36">36</option>
                                                                    <option value ="37">37</option>
                                                                    <option value ="38">38</option>
                                                                    <option value ="39">39</option>
                                                                    <option value ="40">40</option>
                                                                    <option value ="41">41</option>
                                                                    <option value ="42">42</option>
                                                                    <option value ="43">43</option>
                                                                    <option value ="44">44</option>
                                                                    <option value ="45">45</option>
                                                                    <option value ="46">46</option>
                                                                    <option value ="47">47</option>
                                                                    <option value ="48">48</option>
                                                                    <option value ="49">49</option>
                                                                    <option value ="50">50</option>
                                                                    <option value ="51">51</option>
                                                                    <option value ="52">52</option>
                                                                    <option value ="53">53</option>
                                                                    <option value ="54">54</option>
                                                                    <option value ="55">55</option>
                                                                    <option value ="56">56</option>
                                                                    <option value ="57">57</option>
                                                                    <option value ="58">58</option>
                                                                    <option value ="59">59</option>
															    </select>
                                                        </div>
													    <div class="form-group ">
														    <label for="exampleFormControlPassword4" data-translate="constantSetpoint" ></label>
                                                            <label for="exampleFormControlPassword4"  id="upkeepDosaggioPercUnit"></label>
														    <input type="number" class="form-control border-success numerico" id="upkeepDosaggioPerc" min ="0.000" max ="99.000" labelMSG="constantDos" labelMSGError="constantDosAlarm" step="0.001" decimal ="3" maxlength="6" data-mask="00.000" placeholder="">
                                                            <!--border-info border-warning border-danger 
                                                            <div class="text-success small mt-1">
                                                                Looks good!
                                                           </div>
                                                                -->
                                                            <!--text-info text-warning text-danger -->
													    </div>
                                                    </div>
                                                    <div class="form-footer ModeSendLoad"  style="display: none;">
                                                        <div class="progress mb-3" >
																  <div  class="progress-bar progress-bar-striped progress-bar-animated" role="progressbar" style="width: 25%" aria-valuenow="25" aria-valuemin="0" aria-valuemax="100"></div>
													    </div>
                                                    </div>
													<div class="form-footer">
														<!-- TASTO LOADING -->
														<a class="ladda-button btn btn-primary btn-ladda" id="percModeSend" data-style="expand-right">
  															<span class="ladda-label" data-translate="saveSetpoint"></span>
  															<span class="ladda-spinner" data-translate="loadingSetpoint" style="display: none;"></span>
														</a>
														<!-- END TASTO LOADING -->
													</div>

												  </form>
											</div>
                                       <!-- end modalita perc -->
                                       <!-- modalita MLQ -->
    										<div class="tab-pane fade show " id="nav-tabs-mlq" role="tabpanel" aria-labelledby="nav-home-tab">
												<form>
													<div class="form-group" aria-haspopup="True">
														<label for="exampleFormControlPassword4" data-translate="mlqSetpoint" ></label>
                                                        <label for="exampleFormControlPassword4" > ppm</label>
														<input type="number" class="form-control border-success numerico" id="mlqSetpoint" min ="0.01" max ="1000.00" step="0.01" labelMSG="mlqInfo" labelMSGError="mlqAlarm" decimal ="2" maxlength="7" data-mask="0000.00" placeholder="">
													</div>
													<div class="form-group" aria-haspopup="True">
														<label for="exampleFormControlPassword4" data-translate="concentrazioneSetpoint" ></label>
                                                        <label for="exampleFormControlPassword4" > %</label>
														<input type="number" class="form-control border-success numerico" id="concentrazionemlqSetpoint" min ="0.1" max ="100.0" step="0.1" labelMSG="concentrazioneInfo" labelMSGError="concentrazioneAlarm" decimal ="1" maxlength="5" data-mask="000.0" placeholder="">
													</div>
                                                     <div class="custom-control custom-radio d-inline-block mr-3 mb-3">
															<label for="exampleFormControlSelect15" data-translate="waterMeterSetpoint"></label>
															<select class="form-control rounded-0 bg-light " id ="waterMetermlqSetpoint">
																<option value ="0" data-translate="waterMeterPulseLitreSetpoint"></option>
																<option value ="1" data-translate="waterMeterLitrePulseSetpoint"></option>
															</select>
													</div>
													<div class="custom-control custom-radio d-inline-block mr-3 mb-3">
														<label for="exampleFormControlPassword4" data-translate="waterMeterKSetpoint" ></label>
														<input type="number" class="form-control border-success numerico " id ="waterMeterKmlqSetpoint"  min ="0.0" max ="1200.0" step="0.1" labelMSG="waterMeterKInfo" labelMSGError="waterMeterKAlarm" decimal ="1" maxlength="6" data-mask="0000.0" placeholder="">
                                                        <!--border-info border-warning border-danger 
                                                        <div class="text-success small mt-1">
                                                            Looks good!
                                                       </div>
                                                            -->
                                                        <!--text-info text-warning text-danger -->
													</div>
                                                    <div class="form-group" aria-haspopup="True">
															<input type="checkbox" class="custom-control-input " id="upkeepmlqSet" checked="checked" onclick="$(this).prop('checked') ? $('#mlqUpkeepGroup').show() : $('#mlqUpkeepGroup').hide()">
															<label class="custom-control-label" for="upkeepmlqSet" data-translate="upkeepSetpoint"></label>
													</div>
                                                    <div id ="mlqUpkeepGroup">
                                                        <div class="custom-control custom-radio d-inline-block mr-3 mb-3">
															    <label for="exampleFormControlSelect15" data-translate="timeoutUpkeepOreSetpoint"></label>
															    <select class="form-control rounded-0 bg-light" id="timeoutUpkeepOremlqSetpoint">
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
                                                                    <option value ="24">24</option>
															    </select>
                                                        </div>
                                                        <div class="custom-control custom-radio d-inline-block mr-3 mb-3">
															    <label for="exampleFormControlSelect15" data-translate="timeoutUpkeepMinutiSetpoint"></label>
															    <select class="form-control rounded-0 bg-light" id="timeoutUpkeepMinutimlqSetpoint">
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
                                                                    <option value ="24">24</option>
                                                                    <option value ="25">25</option>
                                                                    <option value ="26">26</option>
                                                                    <option value ="27">27</option>
                                                                    <option value ="28">28</option>
                                                                    <option value ="29">29</option>
                                                                    <option value ="30">30</option>
                                                                    <option value ="31">31</option>
                                                                    <option value ="32">32</option>
                                                                    <option value ="33">33</option>
                                                                    <option value ="34">34</option>
                                                                    <option value ="35">35</option>
                                                                    <option value ="36">36</option>
                                                                    <option value ="37">37</option>
                                                                    <option value ="38">38</option>
                                                                    <option value ="39">39</option>
                                                                    <option value ="40">40</option>
                                                                    <option value ="41">41</option>
                                                                    <option value ="42">42</option>
                                                                    <option value ="43">43</option>
                                                                    <option value ="44">44</option>
                                                                    <option value ="45">45</option>
                                                                    <option value ="46">46</option>
                                                                    <option value ="47">47</option>
                                                                    <option value ="48">48</option>
                                                                    <option value ="49">49</option>
                                                                    <option value ="50">50</option>
                                                                    <option value ="51">51</option>
                                                                    <option value ="52">52</option>
                                                                    <option value ="53">53</option>
                                                                    <option value ="54">54</option>
                                                                    <option value ="55">55</option>
                                                                    <option value ="56">56</option>
                                                                    <option value ="57">57</option>
                                                                    <option value ="58">58</option>
                                                                    <option value ="59">59</option>
															    </select>
                                                        </div>
													    <div class="form-group ">
														    <label for="exampleFormControlPassword4" data-translate="constantSetpoint" ></label>
                                                            <label for="exampleFormControlPassword4"  id="upkeepDosaggiomlqUnit"></label>
														    <input type="number" class="form-control border-success numerico" id="upkeepDosaggiomlq" min ="0.000" max ="99.000" labelMSG="constantDos" labelMSGError="constantDosAlarm" step="0.001" decimal ="3" maxlength="6" data-mask="00.000" placeholder="">
                                                            <!--border-info border-warning border-danger 
                                                            <div class="text-success small mt-1">
                                                                Looks good!
                                                           </div>
                                                                -->
                                                            <!--text-info text-warning text-danger -->
													    </div>
                                                    </div>
                                                    <div class="form-footer ModeSendLoad"  style="display: none;">
                                                        <div class="progress mb-3" >
																  <div  class="progress-bar progress-bar-striped progress-bar-animated" role="progressbar" style="width: 25%" aria-valuenow="25" aria-valuemin="0" aria-valuemax="100"></div>
													    </div>
                                                    </div>
													<div class="form-footer">
														<!-- TASTO LOADING -->
														<a class="ladda-button btn btn-primary btn-ladda" id="mlqModeSend" data-style="expand-right">
  															<span class="ladda-label" data-translate="saveSetpoint"></span>
  															<span class="ladda-spinner" data-translate="loadingSetpoint" style="display: none;"></span>
														</a>
														<!-- END TASTO LOADING -->
													</div>

												  </form>
											</div>
                                       <!-- end modalita MLQ -->
                                       <!-- modalita Batch -->
    										<div class="tab-pane fade show " id="nav-tabs-batch" role="tabpanel" aria-labelledby="nav-home-tab">
												<form>
													<div class="form-group" aria-haspopup="True">
														<label for="exampleFormControlPassword4" data-translate="batchSetpoint" ></label>
                                                        <label for="exampleFormControlPassword4" id="batchUnit"> </label>
														<input type="number" class="form-control border-success numerico" id="batchSetpoint" min ="0.000" max ="100.000" step="0.001" labelMSG="batchInfo" labelMSGError="batchAlarm" decimal ="3" maxlength="7" data-mask="000.000" placeholder="">
													</div>
                                                     <div class="custom-control custom-radio d-inline-block mr-3 mb-3">
															<label for="exampleFormControlSelect15" data-translate="contactSetpoint"></label>
															<select class="form-control rounded-0 bg-light " id ="contactSetpoint">
																<option value ="1" data-translate="ncContactSetpoint"></option>
																<option value ="0" data-translate="noContactSetpoint"></option>
															</select>
													</div>
                                                    <div class="form-footer ModeSendLoad"  style="display: none;">
                                                        <div class="progress mb-3" >
																  <div  class="progress-bar progress-bar-striped progress-bar-animated" role="progressbar" style="width: 25%" aria-valuenow="25" aria-valuemin="0" aria-valuemax="100"></div>
													    </div>
                                                    </div>
													<div class="form-footer">
														<!-- TASTO LOADING -->
														<a class="ladda-button btn btn-primary btn-ladda" id="batchModeSend" data-style="expand-right">
  															<span class="ladda-label" data-translate="saveSetpoint"></span>
  															<span class="ladda-spinner" data-translate="loadingSetpoint" style="display: none;"></span>
														</a>
														<!-- END TASTO LOADING -->
													</div>

                                                </form>
                                            </div>
                                       <!-- end modalita Batch -->
                                       <!-- modalita Volt -->
    										<div class="tab-pane fade show " id="nav-tabs-volt" role="tabpanel" aria-labelledby="nav-home-tab">
												<form>
                                                    <div class="custom-control custom-radio d-inline-block mr-6 mb-6">
   														<label for="exampleFormControlPassword4" data-translate="voltHighSetpoint" ></label>
                                                        <label for="exampleFormControlPassword4"  >V</label>
														<input type="number" class="form-control border-success numerico" id="voltHighSetpoint" min ="0.0" max ="10.0" labelMSG="voltInfo" labelMSGError="voltAlarm" step="0.1" decimal ="1" maxlength="4" data-mask="00.0" placeholder="">
                                                     </div>
                                                    <div class="custom-control custom-radio d-inline-block mr-6 mb-6">
														<label for="exampleFormControlPassword4" data-translate="constantSetpoint" ></label>
                                                        <label for="exampleFormControlPassword4"  id="voltHighDosaggioUnit"></label>
														<input type="number" class="form-control border-success numerico" id="voltHighDosaggio" min ="0.000" max ="99.000" labelMSG="constantDos" labelMSGError="constantDosAlarm" step="0.001" decimal ="3" maxlength="6" data-mask="00.000" placeholder="">
                                                    </div>
                                                    <div class="form-group" aria-haspopup="True">
                                                        <div class="custom-control custom-radio d-inline-block mr-6 mb-6">
   														    <label for="exampleFormControlPassword4" data-translate="voltLowSetpoint" ></label>
                                                            <label for="exampleFormControlPassword4"  >V</label>
														    <input type="number" class="form-control border-success numerico" id="voltLowSetpoint" min ="0.0" max ="10.0" labelMSG="voltInfo" labelMSGError="voltAlarm" step="0.1" decimal ="1" maxlength="4" data-mask="00.0" placeholder="">
                                                         </div>
                                                        <div class="custom-control custom-radio d-inline-block mr-6 mb-6">
														    <label for="exampleFormControlPassword4" data-translate="constantSetpoint" ></label>
                                                            <label for="exampleFormControlPassword4"  id="voltLowDosaggioUnit"></label>
														    <input type="number" class="form-control border-success numerico" id="voltLowDosaggio" min ="0.000" max ="99.000" labelMSG="constantDos" labelMSGError="constantDosAlarm" step="0.001" decimal ="3" maxlength="6" data-mask="00.000" placeholder="">
                                                        </div>
                                                    </div>
                                                    <div class="form-footer ModeSendLoad"  style="display: none;">
                                                        <div class="progress mb-3" >
																  <div  class="progress-bar progress-bar-striped progress-bar-animated" role="progressbar" style="width: 25%" aria-valuenow="25" aria-valuemin="0" aria-valuemax="100"></div>
													    </div>
                                                    </div>
													<div class="form-footer">
														<!-- TASTO LOADING -->
														<a class="ladda-button btn btn-primary btn-ladda" id="voltModeSend" data-style="expand-right">
  															<span class="ladda-label" data-translate="saveSetpoint"></span>
  															<span class="ladda-spinner" data-translate="loadingSetpoint" style="display: none;"></span>
														</a>
														<!-- END TASTO LOADING -->
													</div>

                                                </form>
                                            </div>
                                       <!-- end modalita Volt -->
                                       <!-- modalita mA -->
    										<div class="tab-pane fade show " id="nav-tabs-ma" role="tabpanel" aria-labelledby="nav-home-tab">
												<form>
                                                    <div class="custom-control custom-radio d-inline-block mr-6 mb-6">
   														<label for="exampleFormControlPassword4" data-translate="maHighSetpoint" ></label>
                                                        <label for="exampleFormControlPassword4"  >mA</label>
														<input type="number" class="form-control border-success numerico" id="maHighSetpoint" min ="0.0" max ="20.0" labelMSG="maInfo" labelMSGError="maAlarm" step="0.1" decimal ="1" maxlength="4" data-mask="00.0" placeholder="">
                                                     </div>
                                                    <div class="custom-control custom-radio d-inline-block mr-6 mb-6">
														<label for="exampleFormControlPassword4" data-translate="constantSetpoint" ></label>
                                                        <label for="exampleFormControlPassword4"  id="maHighDosaggioUnit"></label>
														<input type="number" class="form-control border-success numerico" id="maHighDosaggio" min ="0.000" max ="99.000" labelMSG="constantDos" labelMSGError="constantDosAlarm" step="0.001" decimal ="3" maxlength="6" data-mask="00.000" placeholder="">
                                                    </div>
                                                    <div class="form-group" aria-haspopup="True">
                                                        <div class="custom-control custom-radio d-inline-block mr-6 mb-6">
   														    <label for="exampleFormControlPassword4" data-translate="maLowSetpoint" ></label>
                                                            <label for="exampleFormControlPassword4"  >mA</label>
														    <input type="number" class="form-control border-success numerico" id="maLowSetpoint" min ="0.0" max ="20.0" labelMSG="maInfo" labelMSGError="maAlarm" step="0.1" decimal ="1" maxlength="4" data-mask="00.0" placeholder="">
                                                         </div>
                                                        <div class="custom-control custom-radio d-inline-block mr-6 mb-6">
														    <label for="exampleFormControlPassword4" data-translate="constantSetpoint" ></label>
                                                            <label for="exampleFormControlPassword4"  id="maLowDosaggioUnit"></label>
														    <input type="number" class="form-control border-success numerico" id="maLowDosaggio" min ="0.000" max ="99.000" labelMSG="constantDos" labelMSGError="constantDosAlarm" step="0.001" decimal ="3" maxlength="6" data-mask="00.000" placeholder="">
                                                        </div>
                                                    </div>
                                                    <div class="form-footer ModeSendLoad"  style="display: none;">
                                                        <div class="progress mb-3" >
																  <div  class="progress-bar progress-bar-striped progress-bar-animated" role="progressbar" style="width: 25%" aria-valuenow="25" aria-valuemin="0" aria-valuemax="100"></div>
													    </div>
                                                    </div>
													<div class="form-footer">
														<!-- TASTO LOADING -->
														<a class="ladda-button btn btn-primary btn-ladda" id="maModeSend" data-style="expand-right">
  															<span class="ladda-label" data-translate="saveSetpoint"></span>
  															<span class="ladda-spinner" data-translate="loadingSetpoint" style="display: none;"></span>
														</a>
														<!-- END TASTO LOADING -->
													</div>

                                                </form>
                                            </div>
                                       <!-- end modalita mA -->
                                       <!-- modalita pulse -->
    										<div class="tab-pane fade show " id="nav-tabs-pulse" role="tabpanel" aria-labelledby="nav-home-tab">
												<form>
                                                    <div class="custom-control custom-radio d-inline-block mr-6 mb-6">
   														<label for="exampleFormControlPassword4" data-translate="pulseHighSetpoint" ></label>
                                                        <label for="exampleFormControlPassword4"  >P/m</label>
														<input type="number" class="form-control border-success numerico" id="pulseHighSetpoint" min ="0" max ="7200" labelMSG="pulseInfo" labelMSGError="pulseAlarm" step="1" decimal ="0" maxlength="4" data-mask="0000" placeholder="">
                                                     </div>
                                                    <div class="custom-control custom-radio d-inline-block mr-6 mb-6">
														<label for="exampleFormControlPassword4" data-translate="constantSetpoint" ></label>
                                                        <label for="exampleFormControlPassword4"  id="pulseHighDosaggioUnit"></label>
														<input type="number" class="form-control border-success numerico" id="pulseHighDosaggio" min ="0.000" max ="99.000" labelMSG="constantDos" labelMSGError="constantDosAlarm" step="0.001" decimal ="3" maxlength="6" data-mask="00.000" placeholder="">
                                                    </div>
                                                    <div class="form-group" aria-haspopup="True">
                                                        <div class="custom-control custom-radio d-inline-block mr-6 mb-6">
   														    <label for="exampleFormControlPassword4" data-translate="pulseLowSetpoint" ></label>
                                                            <label for="exampleFormControlPassword4"  >P/m</label>
														    <input type="number" class="form-control border-success numerico" id="pulseLowSetpoint" min ="0" max ="7200" labelMSG="pulseInfo" labelMSGError="pulseAlarm" step="1" decimal ="0" maxlength="4" data-mask="0000" placeholder="">
                                                         </div>
                                                        <div class="custom-control custom-radio d-inline-block mr-6 mb-6">
														    <label for="exampleFormControlPassword4" data-translate="constantSetpoint" ></label>
                                                            <label for="exampleFormControlPassword4"  id="pulseLowDosaggioUnit"></label>
														    <input type="number" class="form-control border-success numerico" id="pulseLowDosaggio" min ="0.000" max ="99.000" labelMSG="constantDos" labelMSGError="constantDosAlarm" step="0.001" decimal ="3" maxlength="6" data-mask="00.000" placeholder="">
                                                        </div>
                                                    </div>

                                                    <div class="form-footer ModeSendLoad"  style="display: none;">
                                                        <div class="progress mb-3" >
																  <div  class="progress-bar progress-bar-striped progress-bar-animated" role="progressbar" style="width: 25%" aria-valuenow="25" aria-valuemin="0" aria-valuemax="100"></div>
													    </div>
                                                    </div>
													<div class="form-footer">
														<!-- TASTO LOADING -->
														<a class="ladda-button btn btn-primary btn-ladda" id="pulseModeSend" data-style="expand-right">
  															<span class="ladda-label" data-translate="saveSetpoint"></span>
  															<span class="ladda-spinner" data-translate="loadingSetpoint" style="display: none;"></span>
														</a>
														<!-- END TASTO LOADING -->
													</div>

                                                </form>
                                            </div>
                                       <!-- end modalita pulse -->
                                       <!-- modalita pause lavoro -->
                                           <div class="tab-pane fade show " id="nav-tabs-pausework" role="tabpanel" aria-labelledby="nav-home-tab">
                                               <form>
                                                   	<div class="form-group" aria-haspopup="True">
														<label for="exampleFormControlPassword4" data-translate="lavoroSetpoint" ></label>
                                                        <label for="exampleFormControlPassword4" > min</label>
														<input type="number" class="form-control border-success numerico" id="lavoroSetpoint" min ="0" max ="999" step="1" labelMSG="pausaInfo" labelMSGError="pausaAlarm" decimal ="0" maxlength="3" data-mask="000" placeholder="">
													</div>
                                                   	<div class="form-group" aria-haspopup="True">
														<label for="exampleFormControlPassword4" data-translate="pausaSetpoint" ></label>
                                                        <label for="exampleFormControlPassword4" > min</label>
														<input type="number" class="form-control border-success numerico" id="pausaSetpoint" min ="0" max ="999" step="1" labelMSG="pausaInfo" labelMSGError="pausaAlarm" decimal ="0" maxlength="3" data-mask="000" placeholder="">
													</div>
													<div class="form-group ">
														<label for="exampleFormControlPassword4" data-translate="constantSetpoint" ></label>
                                                        <label for="exampleFormControlPassword4"  id="pausalavoroDosaggioUnit"></label>
														<input type="number" class="form-control border-success numerico" id="pausalavoroDosaggio" min ="0.000" max ="99.000" labelMSG="constantDos" labelMSGError="constantDosAlarm" step="0.001" decimal ="3" maxlength="6" data-mask="00.000" placeholder="">
													</div>
                                                    <div class="form-footer ModeSendLoad"  style="display: none;">
                                                        <div class="progress mb-3" >
																  <div  class="progress-bar progress-bar-striped progress-bar-animated" role="progressbar" style="width: 25%" aria-valuenow="25" aria-valuemin="0" aria-valuemax="100"></div>
													    </div>
                                                    </div>
													<div class="form-footer">
														<!-- TASTO LOADING -->
														<a class="ladda-button btn btn-primary btn-ladda" id="pauseworkModeSend" data-style="expand-right">
  															<span class="ladda-label" data-translate="saveSetpoint"></span>
  															<span class="ladda-spinner" data-translate="loadingSetpoint" style="display: none;"></span>
														</a>
														<!-- END TASTO LOADING -->
													</div>

                                               </form>
                                           </div>
                                       <!-- --------------end modalita pause lavoro -->
                                       <!-- modalita weekly -->

                                          <div class="tab-pane fade show " id="nav-tabs-weekly" role="tabpanel" aria-labelledby="nav-home-tab">
                                              <form>
                                                  <asp:Literal ID="weeklyLoadServer" runat="server"></asp:Literal>
                                                    <div class="form-footer ModeSendLoad"  style="display: none;">
                                                        <div class="progress mb-3" >
																  <div  class="progress-bar progress-bar-striped progress-bar-animated" role="progressbar" style="width: 25%" aria-valuenow="25" aria-valuemin="0" aria-valuemax="100"></div>
													    </div>
                                                    </div>
													<div class="form-footer">
														<!-- TASTO LOADING -->
														<a class="ladda-button btn btn-primary btn-ladda" id="weeklyModeSend" data-style="expand-right">
  															<span class="ladda-label" data-translate="saveSetpoint"></span>
  															<span class="ladda-spinner" data-translate="loadingSetpoint" style="display: none;"></span>
														</a>
														<!-- END TASTO LOADING -->
													</div>

                                              </form>
                                          </div>
    
                                       <!-- end modalita weekly -->
                                      </div>
							        </div>

						  </div>
							 <!-- end contenuto  modalità lavoro -->
							<!-- contenuto modalità more -->
						  <div class="tab-pane fade" id="nav-profile2" role="tabpanel" aria-labelledby="nav-profile-tab">
												<div class="card-body">
												  <ul class="nav nav-underline-active-primary mb-3" id="pills-tab2" role="tablist">
														<li class="nav-item">
															<a class="nav-link active" id="nav-profile-pumpCapacity" data-toggle="pill" href="#nav-tabs-pumpCapacity" role="tab"
																aria-controls="nav-tabs" aria-selected="false">
															<i class="mdi mdi-arrow-right-drop-circle-outline" ></i><span data-translate="pumpCapacity"> </span></a>
														</li>
														<li class="nav-item">
															<a class="nav-link" id="nav-profile-levelAlamr" data-toggle="pill" href="#nav-tabs-levelAlamr" role="tab"
																aria-controls="nav-tabs" aria-selected="false">
															<i class="mdi mdi-arrow-right-drop-circle-outline"></i><span data-translate="levelAlamr"> </span></a>
														</li>
														<li class="nav-item">
															<a class="nav-link" id="nav-profile-standby" data-toggle="pill" href="#nav-tabs-standby" role="tab"
																aria-controls="nav-tabs" aria-selected="false">
															<i class="mdi mdi-arrow-right-drop-circle-outline"></i><span data-translate="standby"> </span></a>
														</li>
														<li class="nav-item">
															<a class="nav-link" id="nav-profile-externalInput" data-toggle="pill" href="#nav-tabs-externalInput" role="tab"
																aria-controls="nav-tabs" aria-selected="false">
															<i class="mdi mdi-arrow-right-drop-circle-outline"></i> <span data-translate="externalInput"> </span></a>
														</li>
														<li class="nav-item">
															<a class="nav-link" id="nav-profile-waterMeter" data-toggle="pill" href="#nav-tabs-waterMeter" role="tab"
																aria-controls="nav-tabs" aria-selected="false">
															<i class="mdi mdi-arrow-right-drop-circle-outline"></i> <span data-translate="waterMeterSetpoint"> </span></a>
														</li>
														<li class="nav-item">
															<a class="nav-link" id="nav-profile-timeOut" data-toggle="pill" href="#nav-tabs-timeOut" role="tab"
																aria-controls="nav-tabs" aria-selected="false">
															<i class="mdi mdi-arrow-right-drop-circle-outline"></i> <span data-translate="timeOut"> </span></a>
														</li>
														<li class="nav-item">
															<a class="nav-link" id="nav-profile-overflow" data-toggle="pill" href="#nav-tabs-overflow" role="tab"
																aria-controls="nav-tabs" aria-selected="false">
															<i class="mdi mdi-arrow-right-drop-circle-outline"></i> <span data-translate="overflow"> </span></a>
														</li>
														<li class="nav-item">
															<a class="nav-link" id="nav-profile-units" data-toggle="pill" href="#nav-tabs-units" role="tab"
																aria-controls="nav-tabs" aria-selected="false">
															<i class="mdi mdi-arrow-right-drop-circle-outline"></i> <span data-translate="units"> </span></a>
														</li>
														<li class="nav-item">
															<a class="nav-link" id="nav-profile-dateTime" data-toggle="pill" href="#nav-tabs-dateTime" role="tab"
																aria-controls="nav-tabs" aria-selected="false">
															<i class="mdi mdi-arrow-right-drop-circle-outline"></i> <span data-translate="dateTime"> </span></a>
														</li>
														<li class="nav-item">
															<a class="nav-link" id="nav-profile-powerOnDelay" data-toggle="pill" href="#nav-tabs-powerOnDelay" role="tab"
																aria-controls="nav-tabs" aria-selected="false">
															<i class="mdi mdi-arrow-right-drop-circle-outline"></i> <span data-translate="powerOnDelay"> </span></a>
														</li>
														<li class="nav-item">
															<a class="nav-link" id="nav-profile-alarmOut" data-toggle="pill" href="#nav-tabs-alarmOut" role="tab"
																aria-controls="nav-tabs" aria-selected="false">
															<i class="mdi mdi-arrow-right-drop-circle-outline"></i> <span data-translate="alarmOut"> </span></a>
														</li>
								
												  </ul>
												  <!-- end menu modalità lavoro -->
												  <!-- menu settings modalità lavoro -->
                                                    <!-- pump capacity -->
												  <div class="tab-content mt-5" id="tabSubMore">
													   <div class="tab-pane fade show active" id="nav-tabs-pumpCapacity" role="tabpanel" aria-labelledby="nav-home-tab">
														<form>
													        <div class="form-group ">
														        <label for="exampleFormControlPassword4" data-translate="pumpCapacityFlow" ></label>
                                                                <label for="exampleFormControlPassword4"  id="pumpCapacityUnit"></label>
														        <input type="number" class="form-control border-success numerico" id="pumpCapacityFlow" min ="0.000" max ="99.000" labelMSG="constantDos" labelMSGError="constantDosAlarm" step="0.001" decimal ="3" maxlength="6" data-mask="00.000" placeholder="">
													        </div>
													        <div class="form-group" aria-haspopup="True">
														        <label for="exampleFormControlPassword4" data-translate="pumpCapacitySlowMode" ></label>
                                                                <label for="exampleFormControlPassword4" > %</label>
														        <input type="number" class="form-control border-success numerico" id="pumpCapacitySlowMode" min ="1" max ="100" step="1" labelMSG="pumpCapacitySlowModeInfo" labelMSGError="pumpCapacitySlowModeAlarm" decimal ="0" maxlength="3" data-mask="000" placeholder="">
													        </div>
														    <div class="form-footer ModeSendLoad"  style="display: none;">
                                                                <div class="progress mb-3" >
																      <div  class="progress-bar progress-bar-striped progress-bar-animated" role="progressbar" style="width: 25%" aria-valuenow="25" aria-valuemin="0" aria-valuemax="100"></div>
													            </div>
                                                            </div>
													        <div class="form-footer">
														        <!-- TASTO LOADING -->
														        <a class="ladda-button btn btn-primary btn-ladda" id="pumpCapacityModeSend" data-style="expand-right">
  															        <span class="ladda-label" data-translate="saveSetpoint"></span>
  															        <span class="ladda-spinner" data-translate="loadingSetpoint" style="display: none;"></span>
														        </a>
														        <!-- END TASTO LOADING -->
													        </div>
													</form>
													</div>
                                                    <!-- end pump capacity -->
                                                    <!-- level Alarm -->
    												   <div class="tab-pane fade show " id="nav-tabs-levelAlamr" role="tabpanel" aria-labelledby="nav-home-tab">
														<form>
                                                            <div class="form-group" aria-haspopup="True">
															        <input type="checkbox" class="custom-control-input" id="levelAlarmEnable" checked="checked" onclick="$(this).prop('checked') ? $('#levelAlarmGroup').show() : $('#levelAlarmGroup').hide()">
															        <label class="custom-control-label" for="levelAlarmEnable" data-translate="levelAlamr"></label>
													        </div>
                                                            <div id ="levelAlarmGroup">
													            <div class="form-group" aria-haspopup="True">
														            <label for="exampleFormControlPassword4" data-translate="levelAlarmRiserva" ></label>
                                                                    <label for="exampleFormControlPassword4" id="levelAlarmRiservaUnit" > </label>
														            <input type="number" class="form-control border-success numerico" id="levelAlarmRiserva" min ="0" max ="100.000" step="0.001" labelMSG="levelAlarmRiservaInfo" labelMSGError="levelAlarmRiservaAlarm" decimal ="3" maxlength="7" data-mask="000.000" placeholder="">
													            </div>
                                                                 <div class="custom-control custom-radio d-inline-block mr-3 mb-3">
															            <label for="exampleFormControlSelect15" data-translate="contactSetpoint"></label>
															            <select class="form-control rounded-0 bg-light " id ="levelAlarmRiservaContact">
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
														        <a class="ladda-button btn btn-primary btn-ladda" id="levelAlamrModeSend" data-style="expand-right">
  															        <span class="ladda-label" data-translate="saveSetpoint"></span>
  															        <span class="ladda-spinner" data-translate="loadingSetpoint" style="display: none;"></span>
														        </a>
														        <!-- END TASTO LOADING -->
													        </div>

													    </form>
													</div>
                                                      <!-- end level Alarm -->
                                                    <!-- Stand by -->
    												   <div class="tab-pane fade show " id="nav-tabs-standby" role="tabpanel" aria-labelledby="nav-home-tab">
														<form>
                                                            <div class="form-group" aria-haspopup="True">
															        <input type="checkbox" class="custom-control-input" id="standbyEnable" checked="checked" onclick="$(this).prop('checked') ? $('#standbyGroup').show() : $('#standbyGroup').hide()">
															        <label class="custom-control-label" for="standbyEnable" data-translate="standby"></label>
													        </div>
                                                            <div id ="standbyGroup">
                                                                 <div class="custom-control custom-radio d-inline-block mr-3 mb-3">
															            <label for="exampleFormControlSelect15" data-translate="contactSetpoint"></label>
															            <select class="form-control rounded-0 bg-light " id ="standbyContact">
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
														        <a class="ladda-button btn btn-primary btn-ladda" id="standbyModeSend" data-style="expand-right">
  															        <span class="ladda-label" data-translate="saveSetpoint"></span>
  															        <span class="ladda-spinner" data-translate="loadingSetpoint" style="display: none;"></span>
														        </a>
														        <!-- END TASTO LOADING -->
													        </div>

													    </form>
													</div>
                                                      <!-- end Stand by -->
                                                    <!-- external Input -->
    												   <div class="tab-pane fade show " id="nav-tabs-externalInput" role="tabpanel" aria-labelledby="nav-home-tab">
														<form>
                                                            <div class="form-group" aria-haspopup="True">
															        <input type="checkbox" class="custom-control-input" id="externalInputEnable" checked="checked" onclick="$(this).prop('checked') ? $('#externalInputGroup').show() : $('#externalInputGroup').hide()">
															        <label class="custom-control-label" for="standbyEnable" data-translate="modalita12"></label>
													        </div>
                                                            <div id ="externalInputGroup">
                                                                 <div class="custom-control custom-radio d-inline-block mr-3 mb-3">
															            <label for="exampleFormControlSelect15" data-translate="contactSetpoint"></label>
															            <select class="form-control rounded-0 bg-light " id ="externalInputContact">
																            <option value ="1" data-translate="ncContactSetpoint"></option>
																            <option value ="0" data-translate="noContactSetpoint"></option>
															            </select>
													            </div>
													            <div class="form-group" aria-haspopup="True">
														            <label for="exampleFormControlPassword4" data-translate="batchSetpoint" ></label>
                                                                    <label for="exampleFormControlPassword4" id="externalInputQuantityUnit" > </label>
                                                                    <input type="number" class="form-control border-success numerico" id="externalInputQuantity" min ="0.000" max ="100.000" step="0.001" labelMSG="constantDosInfo" labelMSGError="constantDosAlarm" decimal ="3" maxlength="7" data-mask="000.000" placeholder="">
													            </div>
                                                            </div>
														    <div class="form-footer ModeSendLoad"  style="display: none;">
                                                                <div class="progress mb-3" >
																      <div  class="progress-bar progress-bar-striped progress-bar-animated" role="progressbar" style="width: 25%" aria-valuenow="25" aria-valuemin="0" aria-valuemax="100"></div>
													            </div>
                                                            </div>
													        <div class="form-footer">
														        <!-- TASTO LOADING -->
														        <a class="ladda-button btn btn-primary btn-ladda" id="externalInputModeSend" data-style="expand-right">
  															        <span class="ladda-label" data-translate="saveSetpoint"></span>
  															        <span class="ladda-spinner" data-translate="loadingSetpoint" style="display: none;"></span>
														        </a>
														        <!-- END TASTO LOADING -->
													        </div>

													    </form>
													</div>
                                                      <!-- end Stand by -->
                                                    <!-- water meter -->
    												   <div class="tab-pane fade show " id="nav-tabs-waterMeter" role="tabpanel" aria-labelledby="nav-home-tab">
														<form>
                                                             <div class="custom-control custom-radio d-inline-block mr-3 mb-3">
															        <label for="exampleFormControlSelect15" data-translate="waterMeterSetpoint"></label>
															        <select class="form-control rounded-0 bg-light " id ="waterMeterMoreSetpoint">
																        <option value ="0" data-translate="waterMeterPulseLitreSetpoint"></option>
																        <option value ="1" data-translate="waterMeterLitrePulseSetpoint"></option>
															        </select>
													        </div>
													        <div class="custom-control custom-radio d-inline-block mr-3 mb-3">
														        <label for="exampleFormControlPassword4" data-translate="waterMeterKSetpoint" ></label>
														        <input type="number" class="form-control border-success numerico " id ="waterMeterKMoreSetpoint"  min ="0.0" max ="1200.0" step="0.1" labelMSG="waterMeterKInfo" labelMSGError="waterMeterKAlarm" decimal ="1" maxlength="6" data-mask="0000.0" placeholder="">
                                                                <!--text-info text-warning text-danger -->
													        </div>
														    <div class="form-footer ModeSendLoad"  style="display: none;">
                                                                <div class="progress mb-3" >
																      <div  class="progress-bar progress-bar-striped progress-bar-animated" role="progressbar" style="width: 25%" aria-valuenow="25" aria-valuemin="0" aria-valuemax="100"></div>
													            </div>
                                                            </div>
													        <div class="form-footer">
														        <!-- TASTO LOADING -->
														        <a class="ladda-button btn btn-primary btn-ladda" id="waterMeterModeSend" data-style="expand-right">
  															        <span class="ladda-label" data-translate="saveSetpoint"></span>
  															        <span class="ladda-spinner" data-translate="loadingSetpoint" style="display: none;"></span>
														        </a>
														        <!-- END TASTO LOADING -->
													        </div>

                                                        </form>
                                                       </div>
                                                      <!-- end water meter -->
                                                      <!-- timeout -->
    												   <div class="tab-pane fade show " id="nav-tabs-timeOut" role="tabpanel" aria-labelledby="nav-home-tab">
														<form>
													            <div class="form-group" aria-haspopup="True">
														            <label for="exampleFormControlPassword4" data-translate="timeOut" ></label>
                                                                    <label for="exampleFormControlPassword4"  > sec</label>
                                                                    <input type="number" class="form-control border-success numerico" id="timeOut" min ="000" max ="120" step="1" labelMSG="timeOutInfo" labelMSGError="timeOutAlarm" decimal ="0" maxlength="3" data-mask="000" placeholder="">
													            </div>
														    <div class="form-footer ModeSendLoad"  style="display: none;">
                                                                <div class="progress mb-3" >
																      <div  class="progress-bar progress-bar-striped progress-bar-animated" role="progressbar" style="width: 25%" aria-valuenow="25" aria-valuemin="0" aria-valuemax="100"></div>
													            </div>
                                                            </div>
													        <div class="form-footer">
														        <!-- TASTO LOADING -->
														        <a class="ladda-button btn btn-primary btn-ladda" id="timeOutModeSend" data-style="expand-right">
  															        <span class="ladda-label" data-translate="saveSetpoint"></span>
  															        <span class="ladda-spinner" data-translate="loadingSetpoint" style="display: none;"></span>
														        </a>
														        <!-- END TASTO LOADING -->
													        </div>
                                                        </form>
                                                       </div>
                                                      <!-- end timeout -->
                                                      <!-- overflow -->
       												   <div class="tab-pane fade show " id="nav-tabs-overflow" role="tabpanel" aria-labelledby="nav-home-tab">
														<form>
                                                                 <div class="custom-control custom-radio d-inline-block mr-3 mb-3">
															            <label for="exampleFormControlSelect15" data-translate="overflow"></label>
															            <select class="form-control rounded-0 bg-light " id ="overflowSetpoint">
																            <option value ="1" data-translate="alarmWork"></option>
																            <option value ="0" data-translate="alarmStop"></option>
															            </select>
													            </div>
														    <div class="form-footer ModeSendLoad"  style="display: none;">
                                                                <div class="progress mb-3" >
																      <div  class="progress-bar progress-bar-striped progress-bar-animated" role="progressbar" style="width: 25%" aria-valuenow="25" aria-valuemin="0" aria-valuemax="100"></div>
													            </div>
                                                            </div>
													        <div class="form-footer">
														        <!-- TASTO LOADING -->
														        <a class="ladda-button btn btn-primary btn-ladda" id="overflowModeSend" data-style="expand-right">
  															        <span class="ladda-label" data-translate="saveSetpoint"></span>
  															        <span class="ladda-spinner" data-translate="loadingSetpoint" style="display: none;"></span>
														        </a>
														        <!-- END TASTO LOADING -->
													        </div>

                                                        </form>
                                                       </div>
                                                      <!-- end overflow -->
                                                      <!-- units -->
       												   <div class="tab-pane fade show " id="nav-tabs-units" role="tabpanel" aria-labelledby="nav-home-tab">
														<form>
                                                                 <div class="custom-control custom-radio d-inline-block mr-3 mb-3">
															            <label for="exampleFormControlSelect15" data-translate="units"></label>
															            <select class="form-control rounded-0 bg-light " id ="unitsSetpoint">
																            <option value ="1" data-translate="gallons"></option>
																            <option value ="0" data-translate="litres"></option>
															            </select>
													            </div>
														    <div class="form-footer ModeSendLoad"  style="display: none;">
                                                                <div class="progress mb-3" >
																      <div  class="progress-bar progress-bar-striped progress-bar-animated" role="progressbar" style="width: 25%" aria-valuenow="25" aria-valuemin="0" aria-valuemax="100"></div>
													            </div>
                                                            </div>
													        <div class="form-footer">
														        <!-- TASTO LOADING -->
														        <a class="ladda-button btn btn-primary btn-ladda" id="unitsModeSend" data-style="expand-right">
  															        <span class="ladda-label" data-translate="saveSetpoint"></span>
  															        <span class="ladda-spinner" data-translate="loadingSetpoint" style="display: none;"></span>
														        </a>
														        <!-- END TASTO LOADING -->
													        </div>

                                                        </form>
                                                       </div>
                                                      <!-- end units -->
                                                      <!-- date Time -->
       												   <div class="tab-pane fade show " id="nav-tabs-dateTime" role="tabpanel" aria-labelledby="nav-home-tab">
														<form>
                                                                 <div class="custom-control custom-radio d-inline-block mr-3 mb-3">
															            <label for="exampleFormControlSelect15" data-translate="formatDate"></label>
															            <select class="form-control rounded-0 bg-light " id ="formatDate">
																            <option value ="0" >dd/mm/yy</option>
																            <option value ="1" >mm/dd/yy</option>
                                                                            <option value ="2" >yy/mm/dd</option>
															            </select>
													            </div>
                                                                 <div class="custom-control custom-radio d-inline-block mr-3 mb-3">
															            <label for="exampleFormControlSelect15" data-translate="formatTime"></label>
															            <select class="form-control rounded-0 bg-light " id ="formatTime">
																            <option value ="0" >12</option>
																            <option value ="1" >24</option>
															            </select>
													            </div>
                                                                <div class="form-group" aria-haspopup="True">
                                                                    <label class="text-dark font-weight-medium" for="" data-translate="date"></label>
															            <div class="input-group mb-3">
															              <div class="input-group-prepend">
																            <span class="input-group-text mdi mdi-calendar" id="basic-addon1"></span>
															              </div>
															              <input type="text" id="dateSetpoint" class="form-control" data-mask="00/00/00" labelMSG="dateggmmaaInfo" labelMSGError="dateggmmaaAlarm" placeholder="00/00/00">
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
														        <a class="ladda-button btn btn-primary btn-ladda" id="dateTimeModeSend" data-style="expand-right">
  															        <span class="ladda-label" data-translate="saveSetpoint"></span>
  															        <span class="ladda-spinner" data-translate="loadingSetpoint" style="display: none;"></span>
														        </a>
														        <!-- END TASTO LOADING -->
													        </div>

                                                        </form>
                                                       </div>
                                                      <!-- end date Time -->
                                                      <!-- poweron delay -->  
       												   <div class="tab-pane fade show " id="nav-tabs-powerOnDelay" role="tabpanel" aria-labelledby="nav-home-tab">
														<form>
													            <div class="form-group" aria-haspopup="True">
														            <label for="exampleFormControlPassword4" data-translate="powerOnDelay" ></label>
                                                                    <label for="exampleFormControlPassword4"  > min</label>
                                                                    <input type="number" class="form-control border-success numerico" id="powerOnDelay" min ="00" max ="10" step="1" labelMSG="powerOnDelayInfo" labelMSGError="powerOnDelayAlarm" decimal ="0" maxlength="2" data-mask="00" placeholder="">
													            </div>
														    <div class="form-footer ModeSendLoad"  style="display: none;">
                                                                <div class="progress mb-3" >
																      <div  class="progress-bar progress-bar-striped progress-bar-animated" role="progressbar" style="width: 25%" aria-valuenow="25" aria-valuemin="0" aria-valuemax="100"></div>
													            </div>
                                                            </div>
													        <div class="form-footer">
														        <!-- TASTO LOADING -->
														        <a class="ladda-button btn btn-primary btn-ladda" id="powerOnDelayModeSend" data-style="expand-right">
  															        <span class="ladda-label" data-translate="saveSetpoint"></span>
  															        <span class="ladda-spinner" data-translate="loadingSetpoint" style="display: none;"></span>
														        </a>
														        <!-- END TASTO LOADING -->
													        </div>

                                                        </form>
                                                       </div>
                                                      <!-- end poweron delay -->                                                    
                                                      <!-- alarm out -->  
       												   <div class="tab-pane fade show " id="nav-tabs-alarmOut" role="tabpanel" aria-labelledby="nav-home-tab">
														<form>
                                                            <div class="form-group" aria-haspopup="True">
															        <input type="checkbox" class="custom-control-input" id="alarmOutEnable" checked="checked" onclick="$(this).prop('checked') ? $('#alarmOutGroup').show() : $('#alarmOutGroup').hide()">
															        <label class="custom-control-label" for="alarmOutEnable" data-translate="alarmOut"></label>
													        </div>
                                                            <div id ="alarmOutGroup">
                                                                 <div class="custom-control custom-radio d-inline-block mr-3 mb-3">
															            <label for="exampleFormControlSelect15" data-translate="contactSetpoint"></label>
															            <select class="form-control rounded-0 bg-light " id ="alarmOutContact">
																            <option value ="1" data-translate="ncContactSetpoint"></option>
																            <option value ="0" data-translate="noContactSetpoint"></option>
															            </select>
													            </div>
                                                                <div class="form-group" aria-haspopup="True">
                                                                    <div Class="custom-control custom-checkbox d-inline-block mr-3 mb-3">
                                                                        <input type="checkbox" class="custom-control-input" id="alarmOutLevelEnable" >
															            <label class="custom-control-label" for="alarmOutLevelEnable" data-translate="levelAlamr"></label>
                                                                    </div>
                                                                </div>
                                                                <div class="form-group" aria-haspopup="True">
                                                                    <div Class="custom-control custom-checkbox d-inline-block mr-3 mb-3">
                                                                        <input type="checkbox" class="custom-control-input" id="alarmOutStandbyEnable" >
															            <label class="custom-control-label" for="alarmOutStandbyEnable" data-translate="standby"></label>
                                                                    </div>
                                                                </div>
                                                                <div class="form-group" aria-haspopup="True">
                                                                    <div Class="custom-control custom-checkbox d-inline-block mr-3 mb-3">
                                                                        <input type="checkbox" class="custom-control-input" id="alarmOutOverflowEnable" >
															            <label class="custom-control-label" for="alarmOutOverflowEnable" data-translate="overflow"></label>
                                                                    </div>
                                                                </div>
                                                                <div class="form-group" aria-haspopup="True">
                                                                    <div Class="custom-control custom-checkbox d-inline-block mr-3 mb-3">
                                                                        <input type="checkbox" class="custom-control-input" id="alarmOutHighTempEnable" >
															            <label class="custom-control-label" for="alarmOutHighTempEnable" data-translate="highTemperature"></label>
                                                                    </div>
                                                                </div>
                                                                <div class="form-group" aria-haspopup="True">
                                                                    <div Class="custom-control custom-checkbox d-inline-block mr-3 mb-3">
                                                                        <input type="checkbox" class="custom-control-input" id="alarmOutNoInputEnable" >
															            <label class="custom-control-label" for="alarmOutNoInputEnable" data-translate="noInput"></label>
                                                                    </div>
                                                                </div>
                                                                <div class="form-group" aria-haspopup="True">
                                                                    <div Class="custom-control custom-checkbox d-inline-block mr-3 mb-3">
                                                                        <input type="checkbox" class="custom-control-input" id="alarmOutOverPressureEnable" >
															            <label class="custom-control-label" for="alarmOutOverPressureEnable" data-translate="overpressure"></label>
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
														        <a class="ladda-button btn btn-primary btn-ladda" id="alarmOutModeSend" data-style="expand-right">
  															        <span class="ladda-label" data-translate="saveSetpoint"></span>
  															        <span class="ladda-spinner" data-translate="loadingSetpoint" style="display: none;"></span>
														        </a>
														        <!-- END TASTO LOADING -->
													        </div>

                                                        </form>
                                                       </div>
                                                      <!-- end alarm out -->                                                    
												  </div>
									</div>
						  </div>
							<!-- end contenuto modalità more -->
						</div>
						   
					  </div>
					  
					  <!-- end modalità lavoro e more -->
					  
					
              </div>
      </div>
    </div>

    <script type="text/javascript" src="M0101.js?v=1.36"></script>
    <script type="text/javascript" src="traduzioni/T0101.js?v=1.25"></script>

    <asp:Literal ID="javaScriptHeader" runat="server"></asp:Literal>

</asp:Content>

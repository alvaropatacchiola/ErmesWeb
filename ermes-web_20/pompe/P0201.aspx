<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="P0201.aspx.vb" Inherits="ermes_web_20.P0201" %>

<script type="text/javascript" src="pompe/P0201.js?v=1.10"></script>
<script type="text/javascript" src="pompe/traduzioni/T0201.js?v=1.12"></script>

<div class="card card-default card-mini ">
    <div class="card-header green" id='headerColor_SN'>
							<h5 id='pumpLabel_SN'>LD OSIN</h5>
                          <div class="dropdown">
                            <a class="dropdown-toggle icon-burger-mini" href="#" role="button" id="dropdownMenuLink" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                            </a>

                            <div class="dropdown-menu dropdown-menu-right" aria-labelledby="dropdownMenuLink">
                              <a class="dropdown-item" href="#">Edit plant</a>
                              <a class="dropdown-item" href="#">Delete plant</a>
                           
                            </div>
                          </div>
                          <div class="sub-title">
                            <span id='plantName_SN' class="mr-1"> </span><i id='iconStatus_SN' class="mdi mdi-check-decagram"></i>
                          </div>
         </div>
         
         <div id='statusConnection_SN' class="list-group-item list-group-item-action" style="display: none;"><i class="mdi mdi-power-plug-off"></i> Not connected<span class="badge badge-red badge-pill">	<i class="mdi mdi-arrow-down-bold white"></i></span></div>

         <div class="card-body"> <h3 id='modalitaLavoro_SN'></h3><h2 id='portata_SN'> <span class="little"></span></h2> <br />
             <div class="list-group">
                          <div class="list-group-item list-group-item-action " id='valore1_SN' ></div>
                          <div class="list-group-item list-group-item-action " id='valore2_SN' ></div>
                 <!--         <div class="list-group-item list-group-item-action " id='valore3_SN' ></div>-->
                 <!--
                <div class="list-group-item list-group-item-action" id='valore1_SN' >0 <span class="badge badge-black badge-pill" tabindex="0" data-toggle="tooltip" title="PORTATA" > <i class="mdi mdi-information"></i></span></div>
                <div class="list-group-item list-group-item-action" id='valore2_SN'>0 <span class="badge badge-black badge-pill" tabindex="0" data-toggle="tooltip" title="FREQUENZA">	 <i class="mdi mdi-signal-cellular-outline"></i></span></div>
                <div class="list-group-item list-group-item-action" id='valore3_SN'>0 <span class="badge badge-black badge-pill" tabindex="0" data-toggle="tooltip" title="SLOW MODE">	 <i class="mdi mdi-eject"></i></span></div><br>
                     -->
             </div>
             <a id='hrefNext_SN' href="#" class="btn btn-block btn-outline-primary">Vai all 'impianto</a>
         </div>
    </div>

var labelJson = "";
var jsonParseLabel;

//in caso di variazione filtri rettificare la classe
var classeStrumento = ["impiantoacceso", "impiantospento", "allarme"];

function get_data(serialNumber, stringJson, stringGlobal, nomeLabel, stringDecimal, stringLabel, resultPipe, resultConfigurationInput, stringJsonGlobalInputOutput, sistemaUSA, traduzioneModifica, traduzioneElimina, traduzioneVaiImpianto, nomeImpiantoDB, href,start) {
    var intestazione = '';
    var check_connected = false;
    var classReplace = "aaaaaaaa bbbbbbbb cccccccc";

    if (start) {
        //$("#" + serialNumber + "_main").replaceWith("<div Class=\"col-xl-3 col-sm-6 plant strumento \" id=\"" + serialNumber + "_ricerca\"></div>")
        $("#" + serialNumber + "_main").replaceWith("<div Class=\"col-xl-3 col-sm-6 plant strumento \" id=\"" + serialNumber + "_ricerca\"></div>")
    }

    //intestazione = "<div Class=\"col-xl-3 col-sm-6 plant strumento aaaaaaaa bbbbbbbb cccccccc \" id=\"" + serialNumber + "_ricerca\"><div Class=\"card card-default card-mini \">"
    intestazione = "<div Class=\"card card-default card-mini \">"
    //intestazione = "<div id=\"" + serialNumber + "_ricerca\" Class=\"col-xl-3 col-sm-6 plant strumento \"><div Class=\"card card-default card-mini \">"

    //dddddddd da sostituire con colore 
    intestazione = intestazione + "<div Class=\"card-header dddddddd\" id=\"" + serialNumber + "_headerAlarm\">"

    intestazione = intestazione + "<h4 id=\"" + serialNumber + "_label\">"+serialNumber+"</h4>"
    intestazione = intestazione + "<div Class=\"dropdown\">"
    intestazione = intestazione + "<a Class=\"dropdown-toggle icon-burger-mini\" href=\"#\" role=\"button\" id=\"dropdownMenuLink\" data-toggle=\"dropdown\" aria-haspopup=\"true\" aria-expanded=\"false\"></a>"
    intestazione = intestazione + "<div Class=\"dropdown-menu dropdown-menu-right\" aria-labelledby=\"dropdownMenuLink\">"
    intestazione = intestazione + "<a Class=\"dropdown-item\" href=\"plant.aspx?codice=" + serialNumber + "\">" + traduzioneModifica + "</a>"
    intestazione = intestazione + "<a Class=\"dropdown-item\" href=\"#\">" + traduzioneElimina + "</a>"
    intestazione = intestazione + "</div></div><div Class=\"sub-title\" >"
    //eeeeeeee da sostituitre  mdi-power-plug-off se disconnesso mdi-check-decagram se connesso
    intestazione = intestazione + "<span Class=\"mr-1\">" + nomeImpiantoDB + " </span><i class=\"mdi eeeeeeee\"></i>"
    intestazione = intestazione + "</div></div>"

    //ffffffff da sostituire con eventuale stato di non connessione o allarme di flusso
    //<div Class="list-group-item list-group-item-action"><i class="mdi mdi-power-plug-off"></i> Not connected<span class="badge badge-red badge-pill">	<i class="mdi mdi-arrow-down-bold white"></i></span></div>
    intestazione = intestazione + "ffffffff"
    intestazione = intestazione + "<div Class=\" card-body\"><div class=\" list-group\">"

    

    var jsonParseAlarm = JSON.parse(stringJson)
    var jsonParse;
    for (i = 0; i < jsonParseAlarm.variable.length; i++) {
        intestazione = intestazione + "<div Class=\"list-group-item list-group-item-action  \" id=\"" + serialNumber + "_" + jsonParseAlarm.variable[i]["chiaveG"] + "_alarmColor\"><text id=\"" + serialNumber + "_" + jsonParseAlarm.variable[i]["chiaveG"] + "\">**</text><text>&nbsp<text><strong id=\"" + serialNumber + "_" + jsonParseAlarm.variable[i]["chiaveP"] + "\">0</strong></div>"
    }


    $.ajax({
        type: "POST",
        url: "Centurio/centurioReal.aspx/getRealTime",
        //data: {check1: $("#rms_all").is(':checked') ,check1_1: $("#rms_medio").is(':checked'),  check1_2:  $("#rms_max").is(':checked') ,check2 : $("#picco_all").is(':checked') , check2_1 : $("#picco_medio").is(':checked') , check2_2 : $("#picco_max").is(':checked') , check3: $("#vm_rms_all").is(':checked') , check3_1: $("#vm_rms_medio").is(':checked') , check3_2 : $("#vm_rms_max").is(':checked') , check4 : $("#vm_picco_all").is(':checked') , check4_1 : $("#vm_picco_medio").is(':checked') , check4_2: $("#vm_picco_max").is(':checked')   },
        //data: { check1: false, check1_1: true, check1_2: false, check2: false, check2_1: true, check2_2: false, check3: false, check3_1:true, check3_2:false, check4: false, check4_1:true, check4_2:false },
        data: "{'serialNumber':'" + JSON.stringify(serialNumber) + "'}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        //timeout: 6000, //3 second timeout
        success: function (response) {
            
            //alert(response.d)
            
            
            
            var i = 0;
            jsonParse = JSON.parse(response.d)
            if (jsonParse.errore == "ok") {
                check_connected = true;
            }
            else//non connesso
            {
                check_connected = false;
            }
            intestazione = intestazione + "</div><a href=\"" + href + "\" class=\"btn btn-block gggggggg\" id=\"" + serialNumber + "_href\">" + traduzioneVaiImpianto + "</a>"
            //intestazione = intestazione + "</div></div></div>"
            intestazione = intestazione + "</div></div>"

            if (!check_connected) {// non connesso
                //intestazione = intestazione.replace("aaaaaaaa", "")
                //intestazione = intestazione.replace("bbbbbbbb", "impiantospento")
                //intestazione = intestazione.replace("cccccccc", "")
                classReplace = classReplace.replace("aaaaaaaa", "")
                classReplace = classReplace.replace("bbbbbbbb", "impiantospento")
                classReplace = classReplace.replace("cccccccc", "")
                //dddddddd da sostituire con colore 
                intestazione = intestazione.replace("dddddddd", "red") // se non connesso è rosso
                //eeeeeeee da sostituitre  mdi-alert-octagon se disconnesso mdi-check-decagram se connesso
                intestazione = intestazione.replace("eeeeeeee", "mdi-alert-octagon") // se non connesso è rosso
                //ffffffff da sostituire con eventuale stato di non connessione o allarme di flusso
                intestazione = intestazione.replace("ffffffff", "<div Class=\"list-group-item list-group-item-action\"><i class=\"mdi mdi-power-plug-off\"></i>Not Connected<span class=\"badge badge-red badge-pill\">	<i class=\"mdi mdi-arrow-down-bold white\"></i></span></div>")
                //gggggggg colore del pulsante vai allimpianto
                intestazione = intestazione.replace("gggggggg", "btn-outline-danger")
            }
            else {
                jsonParseLabel = JSON.parse(stringLabel);
                var jsonParseDecimal = JSON.parse(stringDecimal);
                var jsonParseAlarmGlobal = JSON.parse(stringGlobal);
                var i = 0;
                var m = 0;
                var allarmeGlobal = false;
                var allarmeGlobalStr = "";
                if (jsonParseAlarmGlobal.variable.length > 0) {
                    for (m = 0; m < jsonParseAlarmGlobal.variable[0]["valore"].length; m++) {
                        var tag = jsonParseAlarmGlobal.variable[0]["valore"][m]["variabile"];

                        // console.log("tagLabel:" + tagLabel)
                        var k = 0;
                        for (k = 0; k < jsonParse.variable.length; k++) {
                            if ((jsonParse.variable[k]["chiave"] == tag) && ((jsonParse.variable[k]["valore"].indexOf('true') >= 0) || (parseInt(jsonParse.variable[k]["valore"])) == 1)) {
                                allarmeGlobal = true
                                console.log("tag:" + tag)
                                console.log(stringGlobal)
                                allarmeGlobalStr = createLabelGlobal(tag);
                                break;
                            }
                        }
                        for (k = 0; k < jsonParse.variable.length; k++) {
                            if ((jsonParse.variable[k]["chiave"] == "labelCenturioR")) {
                                labelCenturio = jsonParse.variable[k]["valore"];
                                console.log(labelCenturio)
                                break;
                            }
                        }
                        if (allarmeGlobal) break;
                    }
                }

                classReplace = classReplace.replace("aaaaaaaa", "impiantoacceso")
                classReplace = classReplace.replace("bbbbbbbb", "")
                if ((allarmeGlobal)) {
                    classReplace = classReplace.replace("cccccccc", "allarme")
                    intestazione = intestazione.replace("dddddddd", "red")
                    intestazione = intestazione.replace("eeeeeeee", "mdi-alert-octagon")
                    intestazione = intestazione.replace("ffffffff", "<div Class=\"list-group-item list-group-item-action\"><i class=\"mdi mdi-stack-overflow\"></i>" + allarmeGlobalStr + "<span class=\"badge badge-red badge-pill\">	<i class=\"mdi mdi-arrow-down-bold white\"></i></span></div>")
                    //gggggggg colore del pulsante vai allimpianto
                    intestazione = intestazione.replace("gggggggg", "btn-outline-danger")
                }
                else {
                    classReplace = classReplace.replace("cccccccc", "")
                    intestazione = intestazione.replace("dddddddd", "green")
                    intestazione = intestazione.replace("eeeeeeee", "mdi-check-decagram")
                    intestazione = intestazione.replace("ffffffff", "")
                    //gggggggg colore del pulsante vai allimpianto
                    intestazione = intestazione.replace("gggggggg", "btn-outline-primary")
                }
            }
            //$("#" + serialNumber + "_ricerca").replaceWith(intestazione)
            var i;
            for (i = 0; i < classeStrumento.length; ++i) {
                // do something with `substr[i]`
                $("#" + serialNumber + "_ricerca").removeClass(classeStrumento[i]);
            }
            $("#" + serialNumber + "_ricerca").addClass(classReplace);

            $("#" + serialNumber + "_ricerca").html(intestazione)

            if ((check_connected) && (!allarmeGlobal)) {// non connesso
                $("#" + serialNumber + "_label").text(labelCenturio);
                for (i = 0; i < jsonParse.variable.length; i++) {
                    var labelTagChiave = "#" + serialNumber + "_" + jsonParse.variable[i]["chiave"]
                    var labelTagValore = jsonParse.variable[i]["valore"]

                    if (jsonParseDecimal.variable.length > 0) {//è il caso di elementi non centurio
                        var m = 0;
                        for (m = 0; m < jsonParseDecimal.variable.length; m++) {
                            if (jsonParse.variable[i]["chiave"] == jsonParseDecimal.variable[m]["chiaveP"]) {

                                labelTagValore = numeroDecimali(jsonParseDecimal.variable[m]["minimo"], jsonParseDecimal.variable[m]["massimo"], jsonParseDecimal.variable[m]["decimali"], jsonParse.variable[i]["valore"])
                            }
                            if (jsonParse.variable[i]["chiave"] == jsonParseDecimal.variable[m]["chiaveG"]) {
                                labelTagValore = jsonParseDecimal.variable[m]["unitEu"];
                                break;
                            }
                        }
                    }
                    //console.log("Primo:" + labelTagChiave + "," + labelTagValore)
                    try {
                        $(labelTagChiave).text(labelTagValore);
                    }
                    catch (ex) {
                    }
                }
                //controlloo allarme
                for (i = 0; i < jsonParseAlarm.variable.length; i++) {
                    var labelTagChiaveG = "#" + serialNumber + "_" + jsonParseAlarm.variable[i]["chiaveG"] + "_alarmColor";
                    //var labelTagChiaveP = "#" + serialNumber + "_" + jsonParseAlarm.variable[i]["chiaveP"]
                    var j = 0
                    var allarme = false;

                    for (j = 0; j < jsonParseAlarm.variable[i]["valore"].length; j++) {
                        var tag = jsonParseAlarm.variable[i]["valore"][j]["variabile"];

                        var k = 0;
                        for (k = 0; k < jsonParse.variable.length; k++) {

                            if ((jsonParse.variable[k]["chiave"] == tag) && ((jsonParse.variable[k]["valore"].indexOf('true') >= 0)/*||(parseInt(jsonParse.variable[k]["valore"])) == 1*/)) {
                                //if ((jsonParse.variable[k]["chiave"] == tag) && (parseInt(jsonParse.variable[k]["valore"])) == 1) {

                                allarme = true
                                break;
                            }
                        }
                        if (allarme) break;

                    }

                    
                    $(labelTagChiaveG).removeClass("red");
                    //$(labelTagChiaveP).removeClass("alarm");
                    if (allarme) {
                        if (!$("#" + serialNumber + "_headerAlarm").hasClass("red")) {
                            console.log("inserisco allarme")
                            $("#" + serialNumber + "_headerAlarm").addClass("red");
                        }
                        if (!$("#" + serialNumber + "_ricerca").hasClass("allarme")) {
                            $("#" + serialNumber + "_ricerca").addClass("allarme");
                        }
                        if (!$("#" + serialNumber + "_href").hasClass("btn-outline-danger")) {
                            $("#" + serialNumber + "_href").addClass("btn-outline-danger");
                        }
                        $(labelTagChiaveG).addClass("red");
                        // $(labelTagChiaveP).addClass("alarm");
                    }

                }
                //---end controllo allarme

            }
            
            //gestione strumento connesso
        },
            failure: function (response) {
                alert(response.d);
            }

    });

}

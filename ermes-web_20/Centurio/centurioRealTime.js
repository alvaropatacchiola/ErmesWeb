

var labelJson = "";
var jsonParseLabel;

var labelCenturio = "";
/*setInterval(explode, 4000);
get_data("00000000000000000");
function explode() {
    get_data("00000000000000000");
}
*/
function numeroDecimali(minimoTemp, massimoTemp,decimaliTemp,valoreTemp)
{
    var minimoInt = parseInt(minimoTemp);
    var massimoInt = parseInt(massimoTemp);
    var decimaliInt = parseInt(decimaliTemp);
    var valoreInt = parseInt(valoreTemp);
    var valoreCaloclato = 0;
    
    if (valoreInt < minimoInt) return '----';
    if (valoreInt > massimoInt) return '++++';

    switch (decimaliInt)
    {
        case 0:
            valoreCaloclato = valoreInt;
            break;
        case 1:
            valoreCaloclato = valoreInt / 10;
            break;
        case 2:
            valoreCaloclato = valoreInt / 100;
            break;
        case 3:
            valoreCaloclato = valoreInt / 1000;
            break;

    }
    
    valoreCaloclato = valoreCaloclato.toFixed(decimaliInt);
    
    return valoreCaloclato.toString()
}
function createLabelGlobal(idLabelTemp) {
   // console.log("label:" + idLabelTemp)
        try {

            for (var key in jsonParseLabel) {
                if (idLabelTemp == key) {
                    return jsonParseLabel[key];
                }
            }
        }
        catch (ex) {
        }
    return "";
}
function get_data(serialNumber, stringJson, stringGlobal, nomeLabel, stringDecimal, stringLabel, resultPipe, resultConfigurationInput, stringJsonGlobalInputOutput,sistemaUSA) {

    // alert(stringGlobal)
    //console.log(stringJsonGlobalInputOutput)
    
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
            var jsonParse;
            //alert(response.d)
            //console.log(response.d)
            jsonParse = JSON.parse(response.d)
            var htmlCodeNotConnected = '';
            var i = 0;
            //gestione strumento connesso
            

            htmlCodeNotConnected = htmlCodeNotConnected + '<div class="row-fluid regular-gray" id="' + serialNumber + '_main"' + '>'

            htmlCodeNotConnected = htmlCodeNotConnected + '<div Class="row-fluid" >'
            htmlCodeNotConnected = htmlCodeNotConnected + '<div Class="span12 border"><span class="idnumero">'+serialNumber+' </span><span Class="nome" id="' + serialNumber + '_label"></span>'
            htmlCodeNotConnected = htmlCodeNotConnected + '<span Class="pull-right" style="margin-right: 10px;"><h4 class="glyphicons single circle_arrow_right"><i></i></h4></span></div>'
            htmlCodeNotConnected = htmlCodeNotConnected + '</div>'
            htmlCodeNotConnected = htmlCodeNotConnected + '<div Class="row-fluid">'
            htmlCodeNotConnected = htmlCodeNotConnected + '<div Class="span12">'

            var jsonParseAlarm = JSON.parse(stringJson)
            jsonParseLabel = JSON.parse(stringLabel);
            var jsonParseDecimal = JSON.parse(stringDecimal);
            // alert(stringDecimal)
            //console.log(labelJson)
           // alert(jsonParseDecimal.variable.length)
            
            if (jsonParseDecimal.variable.length > 0) {//è il caso di elementi non centurio
                for (i = 0; i < jsonParseDecimal.variable.length; i++) {
                    htmlCodeNotConnected = htmlCodeNotConnected + '<div Class="span2"> <span Class="unita " id="' + serialNumber + '_' + jsonParseDecimal.variable[i]["chiaveG"] + '" >**</span>'
                    htmlCodeNotConnected = htmlCodeNotConnected + '<span Class="misura " id="' + serialNumber + '_' + jsonParseDecimal.variable[i]["chiaveP"] + '">**</span></div>'
                }
            }
            else{
                for (i = 0; i < jsonParseAlarm.variable.length; i++) {
                    htmlCodeNotConnected = htmlCodeNotConnected + '<div Class="span2"> <span Class="unita " id="' + serialNumber + '_' + jsonParseAlarm.variable[i]["chiaveG"] + '" >**</span>'
                    htmlCodeNotConnected = htmlCodeNotConnected + '<span Class="misura " id="' + serialNumber + '_' + jsonParseAlarm.variable[i]["chiaveP"] + '">**</span></div>'
                }
            }
            htmlCodeNotConnected = htmlCodeNotConnected + '</div>'
            htmlCodeNotConnected = htmlCodeNotConnected + '</div>'

            htmlCodeNotConnected = htmlCodeNotConnected + '</div>'
            
            //alert(jsonParseDecimal.hasOwnProperty('chiaveP'))

            if (jsonParse.errore == "ok") {
                var i = 0;

                $("#" + serialNumber + "_main").replaceWith( htmlCodeNotConnected)
                //verifico la presenza di un allarme generale
                var jsonParseAlarmGlobal = JSON.parse(stringGlobal);
                var m = 0;
                var allarmeGlobal = false;
                var allarmeGlobalStr = "";
                
                if (jsonParseAlarmGlobal.variable.length > 0) {
                    for (m = 0; m < jsonParseAlarmGlobal.variable[0]["valore"].length; m++) {
                        var tag = jsonParseAlarmGlobal.variable[0]["valore"][m]["variabile"];
                        
                       // console.log("tagLabel:" + tagLabel)
                        var k = 0;
                        for (k = 0; k < jsonParse.variable.length; k++) {
                            if ((jsonParse.variable[k]["chiave"] == tag) && ((jsonParse.variable[k]["valore"].indexOf('true') >= 0)||(parseInt(jsonParse.variable[k]["valore"])) == 1)) {
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
                //allarme global del gruppo In out
                try {
                    if (allarmeGlobal == false) {//allarme gruppo global precedenza
                        console.log(stringJsonGlobalInputOutputT)
                        jsonParseAlarmGlobal = JSON.parse(stringJsonGlobalInputOutputT);
                        if (jsonParseAlarmGlobal.variable.length > 0) {
                            //console.log("tagLabel:" + jsonParseAlarmGlobal.variable.length)
                            for (m = 0; m < jsonParseAlarmGlobal.variable.length; m++) {
                                var tag = jsonParseAlarmGlobal.variable[m]["variabile"];


                                var k = 0;
                                for (k = 0; k < jsonParse.variable.length; k++) {
                                    if ((jsonParse.variable[k]["chiave"] == tag) && (parseInt(jsonParse.variable[k]["valore"])) == 1) {
                                        allarmeGlobal = true
                                        //console.log("tagLabel:" + tag)
                                        allarmeGlobalStr = createLabelGlobal(tag);
                                        break;
                                    }
                                }
                                if (allarmeGlobal) break;
                            }
                        }
                    }
                }
                catch (ex) {
                }

                //end verifica presenza allarme generale
                if (allarmeGlobal) {
                    htmlCodeNotConnected = '<div class="row-fluid noflow" id="' + serialNumber + '_main"' + '>'
                    htmlCodeNotConnected = htmlCodeNotConnected + '<div Class="span8"><span class="idnumero">' + serialNumber + ' </span><span Class="strumento">'+labelCenturio +'</span></div>'
                    htmlCodeNotConnected = htmlCodeNotConnected + '<div Class="span4"><span class="strumento">'+allarmeGlobalStr+'</span><span class="pull-right" style="margin-right: 10px;"><h4 class="glyphicons single circle_arrow_right"><i></i></h4></span></div>'
                    htmlCodeNotConnected = htmlCodeNotConnected + '</div>'
                    // $("#" + serialNumber + "_main").replaceWith(htmlCodeNotConnected)
                    $("#" + serialNumber + "_main").replaceWith(htmlCodeNotConnected )
                }
                else {//non esiste allarme generale
                    //console.log("ciao" + labelCenturio)
                    /*var definitivo = htmlCodeNotConnected.replace("[xxxlabelxxxx]", labelCenturio);
                    htmlCodeNotConnected = definitivo;
                    console.log("ciao" + htmlCodeNotConnected)*/
                    $("#" + serialNumber + "_label").text(labelCenturio);
                    //[xxxlabelxxxx]
               // alert(jsonParse.variable.length)
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

                                        try {
                                            $(labelTagChiave).text(labelTagValore);
                                        }
                                        catch (ex) {
                                        }
                                    }
                                    //controllo allarme
                
                                    for (i = 0; i < jsonParseAlarm.variable.length; i++) {
                                        var labelTagChiaveG = "#" + serialNumber + "_" + jsonParseAlarm.variable[i]["chiaveG"]
                                        var labelTagChiaveP = "#" + serialNumber + "_" + jsonParseAlarm.variable[i]["chiaveP"]
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

                    
                                        $(labelTagChiaveG).removeClass("alarm");
                                        $(labelTagChiaveP).removeClass("alarm");
                                        if (allarme) {
                                            
                                            $(labelTagChiaveG).addClass("alarm");
                                            $(labelTagChiaveP).addClass("alarm");
                                        }
                     
                                    }
                }//end non esiste allarme generale
                
            }
            //console.log($('#a').text())
            var attributosupinfPrec = "";
            
            $("#leftMenuCenturio").find("a[id*='_left']").each(function () {
                var id = $(this).attr("id").replace("_left","")
                try {
                if (id == serialNumber){
                    $(this).attr("href", "mainCenturio.aspx?serial=" + serialNumber + "&codice=" + resultPipe + "&sistemaUSA=" + sistemaUSA + "&configuration=" + resultConfigurationInput);
                        var attributoinf = $(this).attr("inf");
                        var attributosup = $(this).attr("sup");

                       // $("#" + attributosup + "_sup").attr('style', 'color:red;')
                        //$("#" + attributoinf + "_inf").attr('style', 'color:red;')

                        if (allarmeGlobal) {
                            $("#" + attributosup + "_sup").attr('style', 'color:red;')
                            $("#" + attributoinf + "_inf").attr('style', 'color:red;')
                            $(this).attr('style', 'color:red;');
                        }
                        else
                            $(this).attr('style', 'color:white;');
                            }
                }
                catch (err) {
                 
                }
                //console.log("trovato:" + attributosupinf )
            });
            if (jsonParse.errore == "invalidSerial") {
                $("#" + serialNumber + "_main").removeClass("notconnected")
                $("#" + serialNumber + "_main").addClass("notconnected")
                htmlCodeNotConnected = '<div class="row-fluid notconnected" id="' + serialNumber + '_main"' + '>'
                htmlCodeNotConnected = htmlCodeNotConnected + '<div Class="span8"><span class="idnumero">' + serialNumber + ' </span><span Class="strumento">label</span></div>'
                htmlCodeNotConnected = htmlCodeNotConnected + '<div Class="span4"><span class="strumento">Not Connected</span><span class="pull-right" style="margin-right: 10px;"><h4 class="glyphicons single circle_arrow_right"><i></i></h4></span></div>'
                htmlCodeNotConnected = htmlCodeNotConnected + '</div>'
                // $("#" + serialNumber + "_main").replaceWith(htmlCodeNotConnected)
                $("#" + serialNumber + "_main").replaceWith( htmlCodeNotConnected )
            }

            //gestione non connesso
           //$("#" + serialNumber + "_main").removeClass("notconnected")
            //$("#" + serialNumber + "_main").addClass("notconnected")
           /* htmlCodeNotConnected = '<div class="row-fluid notconnected" id="' + serialNumber + '_main"'+ '>'
            htmlCodeNotConnected = htmlCodeNotConnected + '<div Class="span8"><span class="idnumero">' + serialNumber + ' </span><span Class="strumento">label</span></div>'
            htmlCodeNotConnected = htmlCodeNotConnected + '<div Class="span4"><span class="strumento">Non Connesso</span><span class="pull-right" style="margin-right: 10px;"><h4 class="glyphicons single circle_arrow_right"><i></i></h4></span></div>'
            htmlCodeNotConnected = htmlCodeNotConnected + '</div>'
            // $("#" + serialNumber + "_main").replaceWith(htmlCodeNotConnected)
            $("#" + serialNumber + "_main").replaceWith(htmlCodeNotConnected)
            
            //gestione alalrme generale globale, in questo caso no flow
            htmlCodeNotConnected = '<div class="row-fluid noflow" id="' + serialNumber + '_main"' + '>'
            htmlCodeNotConnected = htmlCodeNotConnected + '<div Class="span8"><span class="idnumero">' + serialNumber + ' </span><span Class="strumento">label</span></div>'
            htmlCodeNotConnected = htmlCodeNotConnected + '<div Class="span4"><span class="strumento">No Flow</span><span class="pull-right" style="margin-right: 10px;"><h4 class="glyphicons single circle_arrow_right"><i></i></h4></span></div>'
            htmlCodeNotConnected = htmlCodeNotConnected + '</div>'
            // $("#" + serialNumber + "_main").replaceWith(htmlCodeNotConnected)
            $("#" + serialNumber + "_main").replaceWith(htmlCodeNotConnected)*/
            
            
           // upgrate_chart();
        },
        failure: function (response) {
            alert(response.d);
        }

    });

}
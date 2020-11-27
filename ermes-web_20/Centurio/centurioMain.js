var valoriAggiornati = false;
var serialNumberGlobal = '';
var sistemaUSA = '';
var jsonParse;
var jsonParseDecimal;
var jsonParseDecimalStr= "";
var labelJson = "";
var jsonParseLabel;
var jsonParseLog;
var jsonParseLDLog;
var arrayOggettiHeader = [];
var arrayOggettiCanale = [];
var arrayOggettiFooter = [];
var timerStringID = '';
var timerStringValue = '';
var timerStringValuePrec = '';
var arraySetpointChange = [];
var arraySetpointActionChange = [];
var indiceSetpointSend = 0;
var arrayRelay = [0, 0, 0, 0, 0, 0, 0, 0, 0]
var arrayInput = [0, 0, 0, 0, 0, 0, 0, 0, 0]
var arrayOpto = [0, 0, 0, 0, 0, 0, 0, 0, 0]
var arrayMA = [0, 0, 0, 0, 0, 0, 0, 0, 0]
var reloadSetpoint = false;
var reloadLDLOG = false;
var strumentoTouch = true;
var timerCalibration;
var opts = {
    lines: 13, // The number of lines to draw
    length: 9, // The length of each line
    width: 4, // The line thickness
    radius: 8, // The radius of the inner circle
    corners: 1, // Corner roundness (0..1)
    rotate: 0, // The rotation offset
    direction: 1, // 1: clockwise, -1: counterclockwise
    color: color_general, // #rgb or #rrggbb or array of colors
    speed: 1, // Rounds per second
    trail: 60, // Afterglow percentage
    shadow: true, // Whether to render a shadow
    hwaccel: false, // Whether to use hardware acceleration
    className: 'spinner', // The CSS class to assign to the spinner
    zIndex: 2e9, // The z-index (defaults to 2000000000)
    top: 'auto', // Top position relative to parent in px
    left: 'auto' // Left position relative to parent in px
};

//var target = document.getElementById('principale');
var target = 'principale';
var spinner;
function setCookie(stringa)
{
    console.log("cookieWrite:"+stringa)
    $.cookie(serialNumberGlobal, stringa, { expires: 365 });
}
function readCookie(serialNumberTemp)
{
    var cookieStringaTemp = $.cookie(serialNumberTemp);
    console.log("cookieread:"+serialNumberTemp +","+ cookieStringaTemp)
    if (cookieStringaTemp != null){
        var cookieStringaTempSplit = cookieStringaTemp.split(",");
        var k =0;
        for (k=0;k<cookieStringaTempSplit.length;k++){
            $( "#" + cookieStringaTempSplit[k]).prop('checked', true)
        }
    }
}
function getValoreLabelJson(tipoCanale, numeroSonda) {
    var indiceCancvas = 0;

    for (indiceCancvas = 0; indiceCancvas < jsonParseDecimal.variable.length; indiceCancvas++) {
        if ((jsonParseDecimal.variable[indiceCancvas]["tipoCanale"] == tipoCanale) && (jsonParseDecimal.variable[indiceCancvas]["numeroSonda"] == numeroSonda)) {
            return jsonParseDecimal.variable[indiceCancvas]["unitEu"];
        }
    }
    return ""
}
function getValoreCurrentJson(tipoCanale, numeroSonda,valore) {
    var indiceCancvas = 0;
    var valoreCaloclato = 0;



    for (indiceCancvas = 0; indiceCancvas < jsonParseDecimal.variable.length; indiceCancvas++) {
        if ((jsonParseDecimal.variable[indiceCancvas]["tipoCanale"] == tipoCanale) && (jsonParseDecimal.variable[indiceCancvas]["numeroSonda"] == numeroSonda)) {
            var decimaliInt = parseInt(jsonParseDecimal.variable[indiceCancvas]["decimali"]);

            valoreCaloclato = valore / numeroDecimali(jsonParseDecimal.variable[indiceCancvas]["decimali"]);

            valoreCaloclato = valoreCaloclato.toFixed(decimaliInt);
            //alert("massimo:" + valoreCaloclato)
            return valoreCaloclato;
        }
    }
    return valoreCaloclato;

}
function getValoreFullScaleJson(tipoCanale, numeroSonda) {
    var indiceCancvas = 0;
    var valoreCaloclato = 0;

    
    

    for (indiceCancvas = 0; indiceCancvas < jsonParseDecimal.variable.length; indiceCancvas++) {
        if ((jsonParseDecimal.variable[indiceCancvas]["tipoCanale"] == tipoCanale) && (jsonParseDecimal.variable[indiceCancvas]["numeroSonda"] == numeroSonda)) {
            var decimaliInt = parseInt(jsonParseDecimal.variable[indiceCancvas]["decimali"]);
            //console.log("scala:" + parseInt(jsonParseDecimal.variable[indiceCancvas]["massimo"]))
           // console.log((jsonParseDecimal.variable[indiceCancvas]["massimo"]))
            //valoreCaloclato = parseInt(jsonParseDecimal.variable[indiceCancvas]["massimo"]) / numeroDecimali(jsonParseDecimal.variable[indiceCancvas]["decimali"]);
            
            // valoreCaloclato = valoreCaloclato.toFixed(decimaliInt);
            valoreCaloclato = parseInt(jsonParseDecimal.variable[indiceCancvas]["massimo"]);
            //alert("massimo:" + valoreCaloclato)
            return valoreCaloclato;
         }
    }
    return valoreCaloclato;
}
function makeValoreSend(decimali,floatValue)
{
    floatValue = floatValue.toFixed(decimali);
    floatValue = floatValue * numeroDecimali(decimali);
    return floatValue.toString();

}
function numeroDecimali(decimaliTemp) {
    //var minimoInt = parseInt(minimoTemp);
    //var massimoInt = parseInt(massimoTemp);
    var decimaliInt = parseInt(decimaliTemp);
    //var valoreInt = parseInt(valoreTemp);
    //var valoreCaloclato = 0;

//    if (valoreInt < minimoInt) return '----';
  //  if (valoreInt > massimoInt) return '++++';
    

    switch (decimaliInt) {
        case 0:
            return 1;
            break;
        case 1:
            //valoreCaloclato = valoreInt / 10;
            return 10;
            break;
        case 2:
            //valoreCaloclato = valoreInt / 100;
            return 100;
            break;
        case 3:
            //valoreCaloclato = valoreInt / 1000;
            return 1000;
            break;

    }
    return 1;
    //valoreCaloclato = valoreCaloclato.toFixed(decimaliInt);

    
}
function carica_spinner(targetNew) {
    var target2 = document.getElementById(targetNew);
    if (spinner) spinner.stop();
    spinner = new Spinner(opts).spin(target2);

}
function stop_spinner() {
    if (spinner) spinner.stop();
}
function leggiDatiGraficoLDLOG(listaIngressi) {
    carica_spinner(target);
    $.ajax({
        type: "POST",
        url: "Centurio/centurioReal.aspx/leggiDatiGraficoLDLOG",
        //data: {check1: $("#rms_all").is(':checked') ,check1_1: $("#rms_medio").is(':checked'),  check1_2:  $("#rms_max").is(':checked') ,check2 : $("#picco_all").is(':checked') , check2_1 : $("#picco_medio").is(':checked') , check2_2 : $("#picco_max").is(':checked') , check3: $("#vm_rms_all").is(':checked') , check3_1: $("#vm_rms_medio").is(':checked') , check3_2 : $("#vm_rms_max").is(':checked') , check4 : $("#vm_picco_all").is(':checked') , check4_1 : $("#vm_picco_medio").is(':checked') , check4_2: $("#vm_picco_max").is(':checked')   },
        //data: { check1: false, check1_1: true, check1_2: false, check2: false, check2_1: true, check2_2: false, check3: false, check3_1:true, check3_2:false, check4: false, check4_1:true, check4_2:false },
        //data: "{'serialNumber':'" + JSON.stringify(serialNumber) + "','dateFrom':'" + JSON.stringify(stringSend) + "'}",
        data: "{'serialNumber':'" + JSON.stringify(serialNumberGlobal) + "','listaInput':'" + JSON.stringify(listaIngressi) + "'}",
        //data: "{'serialNumber':'" + JSON.stringify(serialNumberGlobal) + "','dateFrom':'" + dateFrom.getFullYear().toString() + "/" + (dateFrom.getMonth() + 1).toString() + "/" + (dateFrom.getDate()).toString() + "','dateTo':'" + dateTo.getFullYear().toString() + "/" + (dateTo.getMonth() + 1).toString() + "/" + (dateTo.getDate()).toString() + "'}",
        //da reimpostare
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        //timeout: 6000, //3 second timeout
        success: function (response) {
            stop_spinner();
            jsonParseLDLog = JSON.parse(response.d);
            reloadLDLOG = true;
            //console.log(response.d)
            aggiornLDGrafico();
            
        },
        failure: function (response) {
            alert(response.d);
            stop_spinner();
        }

    });
}
function leggiDatiGrafico() {
    
    var dateTo = $.datepicker.parseDate("dd-mm-yy", $("#logFrom").val());
    var dateFrom = new Date();
    dateFrom.setDate(dateTo.getDate() - parseInt($("#logTypeDays").val()));
    dateTo.setDate(dateTo.getDate() + 1);
    //console.log(dateFrom + "," + dateTo);
    carica_spinner(target);

        $.ajax({
            type: "POST",
            url: "Centurio/centurioReal.aspx/readLog",
            //data: {check1: $("#rms_all").is(':checked') ,check1_1: $("#rms_medio").is(':checked'),  check1_2:  $("#rms_max").is(':checked') ,check2 : $("#picco_all").is(':checked') , check2_1 : $("#picco_medio").is(':checked') , check2_2 : $("#picco_max").is(':checked') , check3: $("#vm_rms_all").is(':checked') , check3_1: $("#vm_rms_medio").is(':checked') , check3_2 : $("#vm_rms_max").is(':checked') , check4 : $("#vm_picco_all").is(':checked') , check4_1 : $("#vm_picco_medio").is(':checked') , check4_2: $("#vm_picco_max").is(':checked')   },
            //data: { check1: false, check1_1: true, check1_2: false, check2: false, check2_1: true, check2_2: false, check3: false, check3_1:true, check3_2:false, check4: false, check4_1:true, check4_2:false },
            //data: "{'serialNumber':'" + JSON.stringify(serialNumber) + "','dateFrom':'" + JSON.stringify(stringSend) + "'}",
            //data: "{'serialNumber':'"+JSON.stringify(serialNumberGlobal)+"','dateFrom':'" + (dateFrom.getDate()).toString() + "/" + (dateFrom.getMonth() + 1).toString() + "/" + dateFrom.getFullYear().toString() + "','dateTo':'" + (dateTo.getDate()).toString() + "/" + (dateTo.getMonth() + 1).toString() + "/" + dateTo.getFullYear().toString() + "'}",
            data: "{'serialNumber':'" + JSON.stringify(serialNumberGlobal) + "','dateFrom':'" + dateFrom.getFullYear().toString() + "/" + (dateFrom.getMonth() + 1).toString() + "/" + (dateFrom.getDate()).toString() + "','dateTo':'" + dateTo.getFullYear().toString() + "/" + (dateTo.getMonth() + 1).toString() + "/" + (dateTo.getDate()).toString() + "'}",
            //da reimpostare
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            //timeout: 6000, //3 second timeout
            success: function (response) {
                jsonParseLog = JSON.parse(response.d);
                //console.log(response.d)
                aggiornGrafico();
                stop_spinner();
            },
            failure: function (response) {
                alert(response.d);
                stop_spinner();
            }

        });
}
function aggiornLDGrafico()
{
    var series_chart = [];
    var yaxis_chart = [];
    var altezza = 50;
    var numero_asse = 0;
    var idLog = "";
    if (jsonParseLDLog.errore == "ok") {
        $("[ldlog*='ldlog']").each(function () { // cerco se è selezionato un ld log grafico giornaliero
            //listaIngressi = listaIngressi + virgola + $(this).attr("id").replace("_log_check", "")
            //virgola = ","
            var reference = $(this).attr("reference");
            var label = "";
            if ($("#" + reference + "_log_check").is(':checked')) {
                 idLog = $(this).attr("id").replace("_log_check", "");
                 if ($("#radiodayldlog").is(':checked')) {// check il day
                     idLog = idLog + "day";
                     label = $("#radiodayldlog").next().html() + " " + $("#" + reference + "_log_check").next().html();
                 }
                 if ($("#radiomonthldlog").is(':checked')) {// check il day
                     idLog = idLog + "month";
                     label = $("#radiomonthldlog").next().html() + " " + $("#" + reference + "_log_check").next().html();
                 }
                 if ($("#radioyearldlog").is(':checked')) {// check il day
                     idLog = idLog + "year";
                     label = $("#radioyearldlog").next().html() + " " + $("#" + reference + "_log_check").next().html();
                 }

                 var k = 0;
                 var arrayLogTemp = []
                 for (k = 0; k < jsonParseLDLog[idLog].length; k++) {
                     arrayLogTemp.push([parseInt(jsonParseLDLog[idLog][k].data), parseFloat(jsonParseLDLog[idLog][k].valoreP)]);
                 }
                 arrayLogTemp.sort();
                 series_chart.push(createGraphLineSeries(arrayLogTemp, numero_asse, label));
                 numero_asse = numero_asse + 1;
                 
                 yaxis_chart.push(createGraphLineY(label, altezza, 200));
                 if ($("#mergeGraph").is(':checked')) {
                     //altezza = 300;
                 }
                 else {
                     altezza = altezza + 300;
                 }
             }
        });
        var arrayTabella = [];
        var indiceK = 0;
        while (indiceK < jsonParseLDLog[idLog].length) {
            var arrayRiga = [];
            var date = new Date(parseInt(jsonParseLDLog[idLog][indiceK].data));

            date = convertUTCDateToLocalDate(date);

            var theyear = date.getFullYear()
            var themonth = date.getMonth() + 1;
            var thetoday = date.getDate();
            var ore = date.getHours();
            var minuti = date.getMinutes();
            //var data_confronto = parseDate(thetoday + "/" + themonth + "/" + theyear, 'dd/mm/yy');
            if (idLog.indexOf("day") >=0) {
                arrayRiga.push(get_numero_string(thetoday) + "/" + get_numero_string(themonth) + "/" + get_numero_string(theyear));
            }
            if (idLog.indexOf("month") >= 0) {
                arrayRiga.push( get_numero_string(themonth) + "/" + get_numero_string(theyear));
            }
            if (idLog.indexOf("year") >= 0) {
                arrayRiga.push( get_numero_string(theyear));
            }
            //arrayRiga.push(jsonParseLog[indiceK].data);
            //for (var indice in jsonParseLog)
            $("[ldlog*='ldlog']").each(function () { // cerco se è selezionato un ld log grafico giornaliero
                //listaIngressi = listaIngressi + virgola + $(this).attr("id").replace("_log_check", "")
                //virgola = ","
                var reference = $(this).attr("reference");
                var label = "";
                var idLogTemp=""
                if ($("#" + reference + "_log_check").is(':checked')) {
                    idLogTemp = $(this).attr("id").replace("_log_check", "");
                    if ($("#radiodayldlog").is(':checked')) {// check il day
                        idLogTemp = idLogTemp + "day";
                        label = $("#radiodayldlog").next().html();
                    }
                    if ($("#radiomonthldlog").is(':checked')) {// check il day
                        idLogTemp = idLogTemp + "month";
                        label = $("#radiomonthldlog").next().html() + " " + $("#" + reference + "_log_check").next().html();
                    }
                    if ($("#radioyearldlog").is(':checked')) {// check il day
                        idLogTemp = idLogTemp + "year";
                        label = $("#radioyearldlog").next().html() + " " + $("#" + reference + "_log_check").next().html();
                    }
                    arrayRiga.push(jsonParseLDLog[idLogTemp][indiceK].valoreP);
                }
            });
            /*$("#mainLogGraph").find("input").each(function () {
                if (parseInt($("#logTypeAlarmEvery").val()) == parseInt(jsonParseLog["typeLog"][indiceK].valoreP)) {
                    //if ($("#" + indice + "_log_check").is(':checked')) {
                    if ($(this).is(':checked')) {
                        //var tipoGrafico = $("#" + indice + "_log_check").attr("graph")
                        var idLog = $(this).attr("id").replace("_log_check", "");
                        var tipoGrafico = $(this).attr("graph")
                        if (tipoGrafico === "line") {
                            arrayRiga.push(jsonParseLog[idLog][indiceK].valoreP);
                        }
                        if (tipoGrafico === "step") {
                            arrayRiga.push(on_off(jsonParseLog[idLog][indiceK].valoreP));
                        }
                    }


                }
            });*/
            arrayTabella.push(arrayRiga)
            indiceK = indiceK + 1;
        }
        if ($("#mergeGraph").is(':checked'))
            $("#chart_div_ldLog").height(500);
        else
            $("#chart_div_ldLog").height(altezza + (numero_asse * 100));
        create_chartLDLOG(series_chart, "Centurio", yaxis_chart);
        draw_tabellaLDLOG(arrayTabella);
    }
}
function aggiornGrafico()
{
    if (jsonParseLog.errore == "ok") {
        var series_chart = [];
        var yaxis_chart = [];
        var numero_asse = 0;
        var stringaCookie="";
        var altezza = 50;
        reloadSetpoint = false;
        
      

        $("#mainLogGraph").find("input").each(function () {


            if ($(this).is(':checked')) {
                var tipoGrafico = $(this).attr("graph")

                stringaCookie = stringaCookie + $(this).attr("id") + ",";//stringa cookie

                if (tipoGrafico === "line") {
                    var idLog = $(this).attr("id").replace("_log_check", "");

                    var setpointEn = $(this).attr("setpointen").split(",");
                    var setpointMin = $(this).attr("setpointmin").split(",");
                    var setpointMax = $(this).attr("setpointmax").split(",");
                    var setpointLabel = $(this).attr("setpointlabel").split(",");
                    var minLog = 0;
                    var maxLog = 0;
                    var plotLineRange = [];
                    minLog = getValoreJson($(this).attr("minLog"));
                    maxLog = getValoreJson($(this).attr("maxLog"));
                    //gestione dei range
                    

                    
                    if ($("#setpointGraph").is(':checked')) {
                        for (k = 0; k < setpointEn.length; k++) {
                            var minRate = 0;
                            var maxRate = 0;
                            var labelMaxMinRate = "";
                            
                            if (getValoreJson(setpointEn[k]) > 0) {// setpoint abiolitato
                                //console.log(setpointEn[k].indexOf("bleed"))
                                if (setpointEn[k].indexOf("bleed") >= 0) {// caso del bleed
                                    if (getValoreJson(setpointMin[k]) > 0) { //deadband positivo
                                        minRate = getValoreJson(setpointMax[k]);
                                        maxRate = minRate + getValoreJson(setpointMin[k]);
                                        //valore1 = 0;
                                    }
                                    else {//deadband negativo
                                        maxRate = getValoreJson(setpointMax[k]);
                                        minRate = maxRate - getValoreJson(setpointMin[k]);
                                        //console.log("bleed dead1:" + valore2)
                                        //valore2 = this.maxSetpoint1;
                                    }
                                }
                                else {
                                    var minText = getValoreJson(setpointMin[k]);
                                    var maxText = getValoreJson(setpointMax[k]);

                                    if (minText.indexOf("|") > 0){
                                        minText = minText.split("|")[0];
                                        maxText = maxText.split("|")[0];
                                    }
                                    if (minText > maxText) {
                                        maxRate = minText;
                                        minRate = maxText;
                                    }
                                    else {
                                        maxRate = maxText;
                                        minRate = minText;
                                    }

                                }
                                labelMaxMinRate = getValoreJson(setpointLabel[k]);
                                
                                console.log("rateValue:" + minRate + " " + maxRate + " " + setpointMin[k])
                                plotLineRange.push(createLineRange(labelMaxMinRate, minRate, "green"))
                                plotLineRange.push(createLineRange(labelMaxMinRate, maxRate, "red"))

                            }



                        }
                    }
                    //var idLog = $(this).next().html();
                    //jsonParseLog[idLog] //array valory
                    var k = 0;
                    var arrayLogTemp = []
                    for (k = 0; k < jsonParseLog[idLog].length; k++) {
                        if (parseInt($("#logTypeAlarmEvery").val()) == parseInt(jsonParseLog["typeLog"][k].valoreP)) {
                            //console.log("typoLog:" + jsonParseLog["typeLog"][k].valoreP)
                            arrayLogTemp.push([parseInt(jsonParseLog[idLog][k].data), parseFloat(jsonParseLog[idLog][k].valoreP)]);

                        }

                    }
                    //console.log("stampaDati:" + arrayLogTemp[0])
                    //createGraphLineSeries(jsonParseLog[$(this).attr("id")])
                    //var arrayLogTemp = [jsonParseLog[idLog]];
                    arrayLogTemp.sort();
                    series_chart.push(createGraphLineSeries(arrayLogTemp, numero_asse, $(this).next().html()));
                    numero_asse = numero_asse + 1;
                    /*if ($("#mergeGraph").is(':checked')) {

                    }
                    else{
                        numero_asse = numero_asse + 1;
                    }*/
                    if (plotLineRange.length > 0) {
                        yaxis_chart.push(createGraphLineYPlot($(this).next().html(), altezza, 200, plotLineRange,minLog,maxLog));
                    }
                    else
                        yaxis_chart.push(createGraphLineY($(this).next().html(), altezza, 200));
                    if ($("#mergeGraph").is(':checked')) {
                        //altezza = 300;
                    }
                    else {
                        altezza = altezza + 300;
                    }

                    
                    //console.log($(this).attr("graph"), jsonParseLog[idLog]);

                }


                if ((tipoGrafico === "step")&&(!($("#mergeGraph").is(':checked')))) {
                     var idLog = $(this).attr("id").replace("_log_check", "");
                    //alert($(this).next().html());
                    
                    
                    //jsonParseLog[idLog] //array valory
                    var k = 0;
                    var arrayLogTemp = []
                    for (k = 0; k < jsonParseLog[idLog].length; k++) {
                        arrayLogTemp.push([parseInt(jsonParseLog[idLog][k].data), parseInt(jsonParseLog[idLog][k].valoreP)]);

                    }
                    //console.log("stampaDati:" + arrayLogTemp[0])
                    //createGraphLineSeries(jsonParseLog[$(this).attr("id")])
                    //var arrayLogTemp = [jsonParseLog[idLog]];
                    arrayLogTemp.sort();
                    //console.log(strStepTemp)
                    series_chart.push(createGraphStepSeries(arrayLogTemp, numero_asse, $(this).next().html()), createGraphStepSeries1(arrayLogTemp, numero_asse, $(this).next().html()))
                    numero_asse = numero_asse + 1;
                    yaxis_chart.push(createGraphLineY($(this).next().html(), altezza, 200));
                    altezza = altezza + 300;
                    //console.log($(this).attr("graph"), jsonParseLog[idLog]);

                }
            }
        });

        setCookie(stringaCookie);

        //creazione Tabella
        var indiceK = 0;
        var arrayTabella = [];

        while (indiceK < jsonParseLog["typeLog"].length ) {
            var arrayRiga = [];
            var date = new Date(parseInt(jsonParseLog["typeLog"][indiceK].data));
            
            date = convertUTCDateToLocalDate(date);

            var theyear = date.getFullYear()
            var themonth = date.getMonth() + 1;
            var thetoday = date.getDate();
            var ore = date.getHours();
            var minuti = date.getMinutes();
            //var data_confronto = parseDate(thetoday + "/" + themonth + "/" + theyear, 'dd/mm/yy');
            if (parseInt($("#logTypeAlarmEvery").val()) == parseInt(jsonParseLog["typeLog"][indiceK].valoreP)) {
                arrayRiga.push(get_numero_string(thetoday) + "/" + get_numero_string(themonth) + "/" + get_numero_string(theyear) + " " + get_numero_string(ore) + ":" + get_numero_string(minuti));
            }
            //arrayRiga.push(jsonParseLog[indiceK].data);
                //for (var indice in jsonParseLog)
            $("#mainLogGraph").find("input").each(function () {
                if (parseInt($("#logTypeAlarmEvery").val()) == parseInt(jsonParseLog["typeLog"][indiceK].valoreP)) {
                    //if ($("#" + indice + "_log_check").is(':checked')) {
                    if ($(this).is(':checked')) {
                        //var tipoGrafico = $("#" + indice + "_log_check").attr("graph")
                        var idLog = $(this).attr("id").replace("_log_check", "");
                        var tipoGrafico = $(this).attr("graph")
                        if (tipoGrafico === "line") {
                            arrayRiga.push(jsonParseLog[idLog][indiceK].valoreP);
                        }
                        if (tipoGrafico === "step") {
                            arrayRiga.push(on_off(jsonParseLog[idLog][indiceK].valoreP));
                        }
                    }


                }
            });
                if (parseInt($("#logTypeAlarmEvery").val()) == parseInt(jsonParseLog["typeLog"][indiceK].valoreP)) {
                    arrayTabella.push(arrayRiga)
                }
                indiceK = indiceK + 1;
        }
        if ($("#mergeGraph").is(':checked'))
            $("#chart_div").height(500);
        else
            $("#chart_div").height(altezza + (numero_asse * 100));
        create_chart(series_chart, "Centurio", yaxis_chart);
        //console.log("dati:" + arrayTabella[0][2])
        draw_tabella(arrayTabella);

        for (var k in jsonParseLog) {

            // console.log(k, jsonParseLog[k]);
        }
    }
}
function get_numero_string(numero_valore) {
    if (numero_valore < 10)
        return "0" + numero_valore;
    else
        return numero_valore;
}
function on_off(ingresso) {
    if (ingresso == 1)
        return "ON"
    else
        return "OFF"
}
function convertUTCDateToLocalDate(convertdLocalTime) {


    var hourOffset = convertdLocalTime.getTimezoneOffset() / 60;

    convertdLocalTime.setHours(convertdLocalTime.getHours() + hourOffset);

    return convertdLocalTime;
}
function createGraphLineSeries(arrayStepTemp, numero_asse, strStepTemp) {
    return ({
        name: strStepTemp,
        id: 'ch1_val_series',
        data: arrayStepTemp,
        yAxis: numero_asse,
        marker: {
            enabled: true,
            radius: 3
        },
        tooltip: {
            valueDecimals: 2
        }
    });
}
function createLineRange(textTitleMin, rate, color)
{
    return ({
        value: rate,
        color: color,
        //dashStyle: 'line',
        width: 2,
        label: {
            text: textTitleMin
        }
    });
}
function createGraphLineYPlot(strStepTemp, altezzaTemp, dimensione, plotLineRange, minPlot, maxPlot) {
    return ({
        title: {
            text: strStepTemp
        },
        opposite: false,
        id: 'ch2_val',
        plotLines: plotLineRange,
        //min: minPlot,
        //max: maxPlot,
        top: altezzaTemp,
        height: dimensione,
        lineWidth: 2
    });

}
function createGraphLineY(strStepTemp, altezzaTemp, dimensione) {
    return ({
        title: {
            text: strStepTemp
        },
        opposite: false,
        id: 'ch2_val',
        top: altezzaTemp,
        height: dimensione,
        lineWidth: 2
    });
}
function createGraphStepSeries(arrayStepTemp, numero_asse, strStepTemp) {

    
    return ({
        id: strStepTemp,
        name: strStepTemp,
        data: arrayStepTemp,
        step: true,
        type: 'scatter',
        tooltip: {
            pointFormat: function () {
                return false;
            },
            valueDecimals: 0
        },
        lineWidth: 2,
        tooltip: {
            pointFormat: function () {
                return false;
            },
            valueDecimals: 0
        },
        lineWidth: 2,
        yAxis: numero_asse
    });
}
function createGraphStepSeries1(arrayStepTemp, numero_asse, strStepTemp) {
    return ({
        id: strStepTemp,
        name: strStepTemp,
        data: arrayStepTemp,
        //type:'line',
        step: true,
        shadow: false,
        color: 'rgba(255,255,255,0.1)',
        tooltip: {
            //pointFormat: '<span style="#FFFFF">{series.name}:<b>{point.y}</b></span>',
            // formatter: '<span style="#FFFFF">{series.name}:<b>{point.y}</b></span>',
            pointFormat: '<span style="#FFFFF">{series.name}:<b>{point.y}</b></span><br/>',
            /*formatter: function () {
                    if (this.y == 1) {
                        return '<span style="#FFFFF">ciao:<b>ON</b></span><br/>';
                    }
                    else {
                        return '<span style="#FFFFF">ciao:<b>OFF</b></span><br/>';
                    }
                },*/

            valueDecimals: 0
        },
        lineWidth: 2,
        shared: true,
        yAxis: numero_asse
    });
}
function create_chart(series_val, Text_graph, yAxis) {
    $('#chart_div').highcharts('StockChart', {
        rangeSelector: {
            enabled: false
        },
        title: {
            text: Text_graph
        },
        yAxis: yAxis,
        plotOptions: {
            scatter: {
                marker: {
                    radius: 1.2
                }
            }
        },
        series: series_val
    });
}
function create_chartLDLOG(series_val, Text_graph, yAxis) {
    $('#chart_div_ldLog').highcharts('StockChart', {
        rangeSelector: {
            enabled: false
        },
        title: {
            text: Text_graph
        },
        yAxis: yAxis,
        plotOptions: {
            scatter: {
                marker: {
                    radius: 1.2
                }
            }
        },
        series: series_val
    });
}
function draw_tabella(header_value) {
    var chart = $('#chart_div').highcharts();
    var series_chart = chart.series;
    var header_array = [];
    //var header_value = [];
    var oggetto = {};
    var string_array = "";
    var string_array_precedent = "";
    var i = 0;
    oggetto = { "title": "Date" }
    header_array.push(oggetto)

    $.each(series_chart, function (row, series_chart_temp) {
        if ((series_chart_temp.name.indexOf("Navigator") < 0) && ((series_chart_temp.type != "scatter"))) {
            // if (string_array == "") {
            // string_array = string_array + '[{ "title": "' + series_chart_temp.name + '" }'
            //string_array = string_array + '"title": "' + series_chart_temp.name + '"'
            oggetto = { "title": series_chart_temp.name };
            header_array.push(oggetto);
            
            //header_value.push(point.);
        }
        string_array_precedent = series_chart_temp.name;
    });

    $('#chart_table').html('<table cellpadding="0" cellspacing="0" border="0" class="display dynamicTable table table-striped table-bordered table-condensed" id="example"></table>');

    $('#example').dataTable({
        dom: 'lfBrtip',
        buttons: [
            'copy', 'csv', 'excel', 'pdf', 'print'
        ],
        bSort: false,
        data: header_value,
        columns: header_array
    });
}
function draw_tabellaLDLOG(header_value) {
    var chart = $('#chart_div_ldLog').highcharts();
    var series_chart = chart.series;
    var header_array = [];
    //var header_value = [];
    var oggetto = {};
    var string_array = "";
    var string_array_precedent = "";
    var i = 0;
    oggetto = { "title": "Date" }
    header_array.push(oggetto)

    $.each(series_chart, function (row, series_chart_temp) {
        if ((series_chart_temp.name.indexOf("Navigator") < 0) && ((series_chart_temp.type != "scatter"))) {
            // if (string_array == "") {
            // string_array = string_array + '[{ "title": "' + series_chart_temp.name + '" }'
            //string_array = string_array + '"title": "' + series_chart_temp.name + '"'
            oggetto = { "title": series_chart_temp.name };
            header_array.push(oggetto);

            //header_value.push(point.);
        }
        string_array_precedent = series_chart_temp.name;
    });

    $('#chart_table_ldLog').html('<table cellpadding="0" cellspacing="0" border="0" class="display dynamicTable table table-striped table-bordered table-condensed" id="example_ldLog"></table>');

    $('#example_ldLog').dataTable({
        dom: 'lfBrtip',
        buttons: [
            'copy', 'csv', 'excel', 'pdf', 'print'
        ],
        bSort: false,
        data: header_value,
        columns: header_array
    });
}
$('a[href="#mainLogGraph"]').click(function () {
    leggiDatiGrafico();
});
var incrementoCalibrazioneGlobal=0;
$('input[typeAction="remoteCalib"]').click(function () {
    //leggiDatiGrafico();
    var idLavoro = $(this).attr("id");
    var idDatoDaPrendere = $(this).attr("getValue");
    if (incrementoCalibrazioneGlobal >= 1) return;// se sto nella procedura di calibrazione esco
    var resultrStatusCalibrazione=0;

    var calib = $(this).attr("calib");
    var valore = $(this).val();
    
    /*sistemazione minimo e massimo valore*/
    var myNumber;
    var minimo;
    var massimo;
    var decimali;
    var sendTemp=false;
    if ($("#" + idDatoDaPrendere).is("input")){
                attributi = $("#" + idDatoDaPrendere).attr("minB");
                if (attributi.indexOf("[") >= 0) {
                    calcolaMinimoMassimo("#" + idDatoDaPrendere, attributi);
                }
                /*end sistemazione minimo e massimo valore*/
                /*prendo i valori di minimo e di massimo*/
                minimo = $("#" + idDatoDaPrendere).attr("min");
                massimo = $("#" + idDatoDaPrendere).attr("max");
                decimali = parseInt($("#" + idDatoDaPrendere).attr("decimali"))
                /*end prendo i valori di minimo e di massimo*/

                $("#" + $("#" + idDatoDaPrendere).attr("id") + "_div").removeClass("control-group");
                $("#" + $("#" + idDatoDaPrendere).attr("id") + "_div").removeClass("control-group error");
                
    }
    else
        sendTemp = true;

    myNumber = parseFloat($("#" + idDatoDaPrendere).val());
    $("#" + idLavoro + "_label").css("color","black")
    $("#" + idLavoro + "_label").text("Wait Calibration")
    if (validaNumero(myNumber, parseFloat(massimo), parseFloat(minimo), decimali, $("#" + idDatoDaPrendere)) ||(sendTemp))
    {
        incrementoCalibrazioneGlobal =1;
        varsCountDown[idLavoro+ "_countdown"].start();
        $("#" + idLavoro + "_count").show();
        //avvio fase di calibrazione
        console.log("actionCali:" + $(this).attr("actionValue") +","+ $("#" + idDatoDaPrendere).find(":selected").val())
        resultrStatusCalibrazione = sendCalibrationAction($(this).attr("actionValue"),$("#" + idDatoDaPrendere).val(),idLavoro)
     
    }

    console.log("azione:" + $(this).attr("id")+"," + $("#" + idDatoDaPrendere).val(),$(this).attr("actionValue"))
});
function countdownCalibration(idLavoro,risultatoCalibrazione)
{
    console.log("intervallo:",idLavoro,risultatoCalibrazione)
    incrementoCalibrazioneGlobal++;
    
    if (risultatoCalibrazione == 255)
    {
        incrementoCalibrazioneGlobal =0;
        varsCountDown[idLavoro+ "_countdown"].stop();
        $("#" + idLavoro + "_label").css("color","red")
        $("#" + idLavoro + "_label").text("Calibration Error")
    } 
    else
    {
        /*if (incrementoCalibrazioneGlobal == 2)
            varsCountDown[idLavoro+ "_countdown"].start();*/
        if (risultatoCalibrazione < 3)
            sendCalibrationAction("statusCalibration","0",idLavoro)
        else{
            varsCountDown[idLavoro+ "_countdown"].stop();
            if (risultatoCalibrazione == 3){//calibrazione OK
                incrementoCalibrazioneGlobal =0;
                $("#" + idLavoro + "_label").css("color","green")
                $("#" + idLavoro + "_label").text("Calibration OK")
            }
            else{//calibrazione error
                incrementoCalibrazioneGlobal =0;
                $("#" + idLavoro + "_label").css("color","red")
                $("#" + idLavoro + "_label").text("Calibration ERROR")
            }
        }
    }
    //timerCalibration = setTimeout(countdownCalibration(idCountdowVal,idLavoro),10000);
    /*var resultrStatusCalibrazione =0;
    resultrStatusCalibrazione = sendCalibrationAction("statusCalibration","0")
    console.log("read status:" + resultrStatusCalibrazione)
    if (resultrStatusCalibrazione == 3){
        varsCountDown[idCountdowVal].stop();
        clearInterval(timerCalibration);
        $("#" + idLavoro + "_label").css("color","green")
        $("#" + idLavoro + "_label").text("Calibration OK")
    }
    if (resultrStatusCalibrazione > 3){
        clearInterval(timerCalibration);
        $("#" + idLavoro + "_label").css("color","red")
        $("#" + idLavoro + "_label").text("Calibration Error")
    }*/
    
}
$("#refreshLog").click(function () {
    var ldLogpresente = $("#radiodisableldlog").is(':checked');
    var ldLogattivo = $("#radiodisableldlog");
    //var ldLogpresente = $("#radiodisableldlog").attr("id");
    //console.log(ldLogpresente)
    if (reloadSetpoint) {
        leggiDatiGrafico();
    }
    /*$("[ldlog*='daily']").each(function () { // cerco se è selezionato un ld log grafico giornaliero
        if ($(this).is(':checked')) {
            console.log($(this).attr("id"))
        }
    });*/
    if (((ldLogpresente != undefined) && (ldLogpresente)) || (ldLogattivo.length == 0)) {
        $("#chart_div_ldLog").hide();
        $("#chart_table_ldLog").hide();
        $("#chart_div").show();
        $("#chart_table").show();
        aggiornGrafico();
    }
    else {
        var listaIngressi = "";
        var virgola = ""
        $("[ldlog*='ldlog']").each(function () { // cerco se è selezionato un ld log grafico giornaliero
            listaIngressi = listaIngressi + virgola +  $(this).attr("id").replace("_log_check", "") 
            virgola = ","
           /* if ($(this).is(':checked')) {
                console.log($(this).attr("id"))
            }*/
        });
        if (reloadLDLOG)
            aggiornLDGrafico();
        else
            leggiDatiGraficoLDLOG(listaIngressi)
        $("#chart_div_ldLog").show();
        $("#chart_table_ldLog").show();
        $("#chart_div").hide();
        $("#chart_table").hide();

    }

    //console.log($.datepicker.parseDate("dd-mm-yy", $("#logFrom").val()))
    return false;
});
//gestione log
function updateSetpointWeek(id, valore, giornoSettimana, indice_sub) {
    var aggiungi = true;
   /* while (valore.indexOf(",") >= 0)
        valore = valore.replace(",", ":");
    while (valore.indexOf(":") >= 0)
        valore = valore.replace(":", "\,");*/

    jQuery(arraySetpointChange).each(function (i, item) {
        //console.log(item)
        var jsonParseSetpoint = JSON.parse(item)
        if (jsonParseSetpoint.id == id) { // oggetto presente
            var valoreV = jsonParseSetpoint.valoreVisualizzato
            var valoreD = jsonParseSetpoint.descrizione
            if (valoreV.indexOf(giornoSettimana) < 0)
                valoreV = valoreV + "," + giornoSettimana
            if (valoreD.indexOf(indice_sub) < 0) {
                valoreD = valoreD + " " + indice_sub
                //valoreV = valoreV + valoreD
            }
            jsonString = "{\"id\":\"" + id + "\",\"valore\":\"" + valore + "\",\"valoreVisualizzato\":\"" + valoreV + "\",\"descrizione\":\"\",\"errore\":\"\",\"errorTex\":\"\"}"
            arraySetpointChange[i] = jsonString;
            aggiungi = false;
        }
    });
    if (aggiungi) {
        var jsonString = "";

        jsonString = "{\"id\":\"" + id + "\",\"valore\":\"" + valore + "\",\"valoreVisualizzato\":\"" + giornoSettimana + " \",\"descrizione\":\"\",\"errore\":\"\",\"errorTex\":\"\"}"

        arraySetpointChange.push(jsonString);
    }
}
function updateSetpointModeComponenti(oggettoInteressanto, subOggetto, check)
{
    var aggiungi = true;
    //console.log($(oggettoInteressanto).attr("path"))
    jQuery(arraySetpointChange).each(function (i, item) {
        //array del tipo [{id:path, valore:valore,descrizione:descrizione,errore:true/false,erroreText:erroremessaggio}]

        var jsonParseSetpoint = JSON.parse(item)

        
        if (jsonParseSetpoint.id == $(oggettoInteressanto).attr("path")) { // oggetto presente

            //var erroreTemp;
            /*if ($("#" +identificativoOggetto + "_div").hasClass("control-group error"))
                erroreTemp = true;
            else
                erroreTemp = false;
                */
            var jsonString = "";
            if (check) // per select option
                jsonString = "{\"id\":\"" + $(oggettoInteressanto).attr("path") + "\",\"valore\":\"" + $(oggettoInteressanto).attr("modecomponenti") + "\",\"valoreVisualizzato\":\"" + $(subOggetto).find(":selected").val() + "\",\"descrizione\":\"" + $(subOggetto).attr("data-original-title") + "\",\"errore\":" + $(subOggetto).hasClass("control-group error") + ",\"errorTex\":\"" + $(subOggetto).attr("error") + "\"}"
            else
                jsonString = "{\"id\":\"" + $(oggettoInteressanto).attr("path") + "\",\"valore\":\"" + $(oggettoInteressanto).attr("modecomponenti") + "\",\"valoreVisualizzato\":\"" + $(oggettoInteressanto).attr("modecomponenti") + "\",\"descrizione\":\"" + $(subOggetto).text() + "\",\"errore\":" + $(subOggetto).hasClass("control-group error") + ",\"errorTex\":\"" + $(subOggetto).attr("error") + "\"}"

            

            arraySetpointChange[i] = jsonString;
            aggiungi = false;
        }

    });
    if (aggiungi) {
        var jsonString = "";

        if (check) // per select option
            jsonString = "{\"id\":\"" + $(oggettoInteressanto).attr("path") + "\",\"valore\":\"" + $(oggettoInteressanto).attr("modecomponenti") + "\",\"valoreVisualizzato\":\"" + $(subOggetto).find(":selected").val() + "\",\"descrizione\":\"" + $(subOggetto).attr("data-original-title") + "\",\"errore\":" + $(subOggetto).hasClass("control-group error") + ",\"errorTex\":\"" + $(subOggetto).attr("error") + "\"}"
        else
            jsonString = "{\"id\":\"" + $(oggettoInteressanto).attr("path") + "\",\"valore\":\"" + $(oggettoInteressanto).attr("modecomponenti") + "\",\"valoreVisualizzato\":\"" + $(oggettoInteressanto).attr("modecomponenti") + "\",\"descrizione\":\"" + $(subOggetto).text() + "\",\"errore\":" + $(subOggetto).hasClass("control-group error") + ",\"errorTex\":\"" + $(subOggetto).attr("error") + "\"}"

        arraySetpointChange.push(jsonString);
    }

}
function updateSetpointSelectOreMinuti(identificativoOggetto) {
    var aggiungi = true;
    var valoreInviato;
    //console.log(identificativoOggetto)

    jQuery(arraySetpointChange).each(function (i, item) {
        //array del tipo [{id:path, valore:valore,descrizione:descrizione,errore:true/false,erroreText:erroremessaggio}]

        var jsonParseSetpoint = JSON.parse(item)


        if (jsonParseSetpoint.id == identificativoOggetto.replace("#", "")) { // oggetto presente

            //var erroreTemp;
            /*if ($("#" +identificativoOggetto + "_div").hasClass("control-group error"))
                erroreTemp = true;
            else
                erroreTemp = false;
                */
            var jsonString = "";
            if ((parseInt($(identificativoOggetto).find(":selected").val())) < 10)
                valoreInviato =  "0" + $(identificativoOggetto).find(":selected").val()
            else
                valoreInviato = $(identificativoOggetto).find(":selected").val()

            valoreInviato = valoreInviato + "\,"

            if ((parseInt($(identificativoOggetto + "_1").find(":selected").val())) < 10)
                valoreInviato = valoreInviato + "0" + $(identificativoOggetto + "_1").find(":selected").val()
            else
                valoreInviato = valoreInviato + $(identificativoOggetto + "_1").find(":selected").val()

            jsonString = "{\"id\":\"" + identificativoOggetto.replace("#", "") + "\",\"valore\":\"" + valoreInviato + "\",\"valoreVisualizzato\":\"" + $(identificativoOggetto).find(":selected").text() + "\," + $(identificativoOggetto + "_1").find(":selected").val() + "\",\"descrizione\":\"" + $(identificativoOggetto).attr("data-original-title") + "\",\"errore\":" + $(identificativoOggetto).hasClass("control-group error") + ",\"errorTex\":\"" + $(identificativoOggetto).attr("error") + "\"}"



            arraySetpointChange[i] = jsonString;
            aggiungi = false;
        }

    });
    if (aggiungi) {
        var jsonString = "";

        jsonString = "{\"id\":\"" + identificativoOggetto.replace("#", "") + "\",\"valore\":\"" + $(identificativoOggetto).find(":selected").val() + "\," + $(identificativoOggetto + "_1").find(":selected").val() + "\",\"valoreVisualizzato\":\"" + $(identificativoOggetto).find(":selected").text() + "\," + $(identificativoOggetto + "_1").find(":selected").val() + "\",\"descrizione\":\"" + $(identificativoOggetto).attr("data-original-title") + "\",\"errore\":" + $(identificativoOggetto).hasClass("control-group error") + ",\"errorTex\":\"" + $(identificativoOggetto).attr("error") + "\"}"

        arraySetpointChange.push(jsonString);
    }
}
function updateSetpointSelect(identificativoOggetto, oggettoInteressanto) {
    var aggiungi = true;
    
    
    //detemino se esiste un action

    if (verificaAction(identificativoOggetto.substring(0, identificativoOggetto.lastIndexOf("_")))) {
        //console.log("esiste Action")
        return;
    }
        

    jQuery(arraySetpointChange).each(function (i, item) {
        //array del tipo [{id:path, valore:valore,descrizione:descrizione,errore:true/false,erroreText:erroremessaggio}]

        var jsonParseSetpoint = JSON.parse(item)


        if (jsonParseSetpoint.id == identificativoOggetto) { // oggetto presente

            //var erroreTemp;
            /*if ($("#" +identificativoOggetto + "_div").hasClass("control-group error"))
                erroreTemp = true;
            else
                erroreTemp = false;
                */
            var jsonString = "";
            jsonString = "{\"id\":\"" + identificativoOggetto + "\",\"valore\":\"" + $(oggettoInteressanto).find(":selected").val() + "\",\"valoreVisualizzato\":\"" + $(oggettoInteressanto).find(":selected").text() + "\",\"descrizione\":\"" + $(oggettoInteressanto).attr("data-original-title") + "\",\"errore\":" + $(oggettoInteressanto).hasClass("control-group error") + ",\"errorTex\":\"" + $(oggettoInteressanto).attr("error") + "\"}"



            arraySetpointChange[i] = jsonString;
            aggiungi = false;
        }

    });
    if (aggiungi) {
        var jsonString = "";

        jsonString = "{\"id\":\"" + identificativoOggetto + "\",\"valore\":\"" + $(oggettoInteressanto).find(":selected").val() + "\",\"valoreVisualizzato\":\"" + $(oggettoInteressanto).find(":selected").text() + "\",\"descrizione\":\"" + $(oggettoInteressanto).attr("data-original-title") + "\",\"errore\":" + $(oggettoInteressanto).hasClass("control-group error") + ",\"errorTex\":\"" + $(oggettoInteressanto).attr("error") + "\"}"

        arraySetpointChange.push(jsonString);
    }
}
function verificaAction(identificativoOggetto)
{
    var aggiungi = true;

    
    var actionlistavalore = $("#" + identificativoOggetto).attr("actionlistavalore"); // serve per la gestione del week al biocide
    

    

    if ((actionlistavalore != undefined) && (actionlistavalore!= "")) {
        var valoreChange = ""
        //console.log("entro" + $("#" + identificativoOggetto).attr("id"))
        $("#" + identificativoOggetto).find("input").each(function () {
            valoreChange = valoreChange + $(this).val() + " ";
        });
        $("#" + identificativoOggetto).find("select").each(function () {
            valoreChange = valoreChange + $(this).val() + " ";
        });
        jQuery(arraySetpointActionChange).each(function (i, item) {
            //array del tipo [{id:path, valore:valore,descrizione:descrizione,errore:true/false,erroreText:erroremessaggio}]

            var jsonParseSetpoint = JSON.parse(item)


            if (jsonParseSetpoint.id == $("#" + identificativoOggetto).attr("actionlistavalore")) { // oggetto presente

                //var erroreTemp;
                /*if ($("#" +identificativoOggetto + "_div").hasClass("control-group error"))
                    erroreTemp = true;
                else
                    erroreTemp = false;
                    */
                var jsonString = "{\"id\":\"" + $("#" + identificativoOggetto).attr("actionlistavalore") + "\",\"valore\":\"" + valoreChange + "\",\"valoreVisualizzato\":\"" + valoreChange + "\",\"descrizione\":\"\",\"errore\":\"\",\"errorTex\":\"\"}"

                arraySetpointActionChange[i] = jsonString;
                aggiungi = false;
            }

        });
        if (aggiungi) {

            var jsonString = "{\"id\":\"" + $("#" + identificativoOggetto).attr("actionlistavalore") + "\",\"valore\":\"" + valoreChange + "\",\"valoreVisualizzato\":\"" + valoreChange + "\",\"descrizione\":\"\",\"errore\":\"\",\"errorTex\":\"\"}"
            arraySetpointActionChange.push(jsonString);
        }
        return true;
    }
    return false;

}
function updateSetpoint(identificativoOggetto,oggettoInteressanto)
{
    var aggiungi = true;
    var valoreInviato;

    

    if (verificaAction(identificativoOggetto.substring(0, identificativoOggetto.lastIndexOf("_"))))
        return;

    
    //console.log($(oggettoInteressanto).val())

    jQuery(arraySetpointChange).each(function(i, item){
        //array del tipo [{id:path, valore:valore,descrizione:descrizione,errore:true/false,erroreText:erroremessaggio}]
        
        var jsonParseSetpoint = JSON.parse(item)
        
        
        if (jsonParseSetpoint.id == identificativoOggetto){ // oggetto presente
              
            //var erroreTemp;
            /*if ($("#" +identificativoOggetto + "_div").hasClass("control-group error"))
                erroreTemp = true;
            else
                erroreTemp = false;
                */
            //console.log($(oggettoInteressanto).attr("min") + "," + $(oggettoInteressanto).attr("max") + "," + strumentoTouch);
            if (strumentoTouch)
                valoreInviato = $(oggettoInteressanto).val()
            else {
                
                if ((($(oggettoInteressanto).attr("min") == "null") || ($(oggettoInteressanto).attr("min") == "timeDataOraR")) && ($(oggettoInteressanto).attr("max") == "null"))
                    valoreInviato = $(oggettoInteressanto).val()
                else
                    valoreInviato = makeValoreSend(parseInt($(oggettoInteressanto).attr("decimali")), parseFloat($(oggettoInteressanto).val()));
            }
           var jsonString = "{\"id\":\"" + identificativoOggetto + "\",\"valore\":\"" + valoreInviato + "\",\"valoreVisualizzato\":\"" + $(oggettoInteressanto).val() + "\",\"descrizione\":\"" + $(oggettoInteressanto).attr("data-original-title") + "\",\"errore\":" + $("#" + identificativoOggetto + "_div").hasClass("control-group error") + ",\"errorTex\":\"" + $(oggettoInteressanto).attr("error") + "\"}"

            arraySetpointChange[i] = jsonString;
            aggiungi = false;
        }
       
    });
    if (aggiungi){
        if (strumentoTouch)
            valoreInviato = $(oggettoInteressanto).val()
        else {
            if ((($(oggettoInteressanto).attr("min") == "null") || ($(oggettoInteressanto).attr("min") == "timeDataOraR")) && ($(oggettoInteressanto).attr("max") == "null"))
                valoreInviato = $(oggettoInteressanto).val()
            else
                valoreInviato = makeValoreSend(parseInt($(oggettoInteressanto).attr("decimali")), parseFloat($(oggettoInteressanto).val()));
        }
        var jsonString = "{\"id\":\"" + identificativoOggetto + "\",\"valore\":\"" + valoreInviato + "\",\"valoreVisualizzato\":\"" + $(oggettoInteressanto).val() + "\",\"descrizione\":\"" + $(oggettoInteressanto).attr("data-original-title") + "\",\"errore\":" + $("#" + identificativoOggetto + "_div").hasClass("control-group error") + ",\"errorTex\":\"" + $(oggettoInteressanto).attr("error") + "\"}"
        arraySetpointChange.push(jsonString);
    }
}
function updateSetpointMulti(identificativoOggetto, oggettoInteressanto) {
    var aggiungi = true;
    //console.log(identificativoOggetto)
    if (verificaAction(identificativoOggetto.substring(0, identificativoOggetto.lastIndexOf("_"))))
        return;

    jQuery(arraySetpointChange).each(function (i, item) {
        //array del tipo [{id:path, valore:valore,descrizione:descrizione,errore:true/false,erroreText:erroremessaggio}]

        var jsonParseSetpoint = JSON.parse(item)


        if (jsonParseSetpoint.id == identificativoOggetto) { // oggetto presente

            //var erroreTemp;
            /*if ($("#" +identificativoOggetto + "_div").hasClass("control-group error"))
                erroreTemp = true;
            else
                erroreTemp = false;
                */
            var jsonString = "{\"id\":\"" + identificativoOggetto + "\",\"valore\":\"" + $("#" + identificativoOggetto).val() + "|" + $("#" + identificativoOggetto + "_1").val() + "\",\"valoreVisualizzato\":\"" + $("#" + identificativoOggetto).val() + " " + $("#" + identificativoOggetto + "_1").val() + "\",\"descrizione\":\"" + $("#" + identificativoOggetto).attr("data-original-title") + "\",\"errore\":" + $("#" + identificativoOggetto + "_div").hasClass("control-group error") + ",\"errorTex\":\"" + $(oggettoInteressanto).attr("error") + "\"}"

            arraySetpointChange[i] = jsonString;
            aggiungi = false;
        }

    });
    if (aggiungi) {

        var jsonString = "{\"id\":\"" + identificativoOggetto + "\",\"valore\":\"" + $("#" + identificativoOggetto).val() + "|" + $("#" + identificativoOggetto + "_1").val() + "\",\"valoreVisualizzato\":\"" + $("#" + identificativoOggetto).val() + " " + $("#" + identificativoOggetto + "_1").val() + "\",\"descrizione\":\"" + $("#" + identificativoOggetto).attr("data-original-title") + "\",\"errore\":" + $("#" + identificativoOggetto + "_div").hasClass("control-group error") + ",\"errorTex\":\"" + $(oggettoInteressanto).attr("error") + "\"}"
        arraySetpointChange.push(jsonString);
    }
}

$("input").change(function () {
    var minimo = $(this).attr("min");
    var massimo = $(this).attr("max");
    var multi = $(this).attr("multi");
    var decimali = parseInt($(this).attr("decimali"))
    var calib = $(this).attr("calib");
    var valore = $(this).val();
    $("#" + $(this).attr("id") + "_div").removeClass("control-group");
    $("#" + $(this).attr("id") + "_div").removeClass("control-group error");
    $(this).next('p').remove();

    

    if ((minimo == "0,0,0,0") || (minimo == "minlog") || (minimo == "timeDataOraR") || (minimo == "timeDataOraS")|| (calib == "ok")) {//caso week

    }
    else {
        if ((minimo == "null") && (massimo == "null")) {
        }
        else {
            var myNumber;
            myNumber = parseFloat($(this).val());
            validaNumero(myNumber, parseFloat(massimo), parseFloat(minimo), decimali, $(this));
            //console.log(valore)
        }
        // alert("change")
        if (multi == "ok") {
            var attributeId = $(this).attr("id")
            updateSetpointMulti(attributeId.replace("_1", ""), $["#" + attributeId.replace("_1", "")])
        }
        else
            updateSetpoint($(this).attr("id"), this);
    }
});
function validaNumero(myNumber, max_ch, min_ch, decimali, oggetto) {
    myNumber = myNumber.toFixed(decimali);
    if ((isNaN(myNumber)) || (myNumber > max_ch) || (myNumber < min_ch)) {
        $(oggetto).after('<p class="error help-block"><span class="label label-important">*'+$(oggetto).attr("error")+'</span></p>');

        $("#" + $(oggetto).attr("id") + "_div").addClass("control-group error");
        return false
    }
    return true

}
$("input").keypress(function (event) {
    //if (event.which == 13) {
      //  event.preventDefault();
    // }
    
    var minimo = $(this).attr("min");
    var multi = $(this).attr("multi");
    var massimo = $(this).attr("max");
    var calib = $(this).attr("calib");
    var decimali = parseInt($(this).attr("decimali"))
    var c = String.fromCharCode(event.which);
    var valore = $(this).val() + c;

    //$(this).val(valore);
    //console.log("caratterescritto:" + valore)

    $("#" + $(this).attr("id") + "_div").removeClass("control-group");
    $("#" + $(this).attr("id") + "_div").removeClass("control-group error");
    $(this).next('p').remove();

    if ((minimo == "0,0,0,0") || (minimo == "minlog") || (minimo == "timeDataOraR") || (minimo == "timeDataOraS")|| (calib == "ok")) {//caso week

    }
    else{
            if ((minimo == "null") && (massimo == "null")) { // condizione in cui devo inserire un testo
                //alert(valore.length + ":" + decimali)
                if (valore.length > decimali)
                    return false;
            }
            else {// vuol dire che ci sono dei numeri
                //console.log(valore)
                if (keypress_channel(event)) {
                    var myNumber;
                    myNumber = parseFloat(valore);
                    validaNumero(myNumber, parseFloat(massimo), parseFloat(minimo), decimali, $(this));
                }
                else {
                    return false;
                }
            }
        try {
            if ($(this).attr("action") == "setpoint") {
                //console.log("aggiungo Setpoint:" + $(this).attr("id"))
                if (multi == "ok") {
                    var attributeId = $(this).attr("id")
                    updateSetpointMulti(attributeId.replace("_1", ""), $["#" + attributeId.replace("_1", "")])

                }
                else
                    updateSetpoint($(this).attr("id"), this);
            }
                
        }
        catch (ex) {

        }

    }

});
function validateMinimoMassimo(stringValue,postFisso)
{
    var risultatoFinale = "";
    if (stringValue.indexOf("[") >= 0) {
        risultatoFinale = stringValue.replace("[", "");
        risultatoFinale = risultatoFinale.replace("]", "");

    }
}
function keypress_channel(evt) {
    var charCode = (evt.which) ? evt.which : event.keyCode
    //console.log("caratterePremuto:" + charCode)
    if ((charCode == 46)||(charCode == 45)) return true;// carattere . e -
    if (charCode > 31 && (charCode < 48 || charCode > 57))
        return false;

    return true;

}
var previousSelect = 0;
$("select").focus(function () {
    // Store the current value on focus, before it changes
    previousSelect = this.value;
})
  .change(function () {
      var str = "";


      if (valoriAggiornati == false) return false;

      var masterPath = $(this).attr("masterpath");
      var count = $(this).attr("count");
      var calibrazione = $(this).attr("calib");
      var modeComponentiStr = $("#" + masterPath).attr("modecomponenti");
      var patStr = $("#" + masterPath).attr("path");
      var min = $(this).attr("min"); // serve per la gestione del week al biocide
      var typeOfList = $(this).attr("typeoflist"); // serve per la gestione del week al biocide

      if (calibrazione == "ok") return ""; // nel caso della calibrazione non devo aggiornare

      if (min != undefined) {
          if (min == "minlog") {//caso del log
              reloadSetpoint = true;
              return "";
          }
          aggiornaWeek($(this).attr("mainid"));
      }
      else{
                  if (modeComponentiStr != undefined) {
                      if (modeComponentiStr.indexOf("ALPHAall") >= 0) {
                          //console.log("alpha")
                          if (count == "0") {//si tratta della prima combo box
                              var selectActivitySplit = modeComponentiStr.split("|");
                              if (selectActivitySplit.length > 0) {
                                  var selectActivitySplitSub = selectActivitySplit[1].split(",");
                                  var j = 0;
                                  var strFinal = "ALPHAall|";
                                  if ($(this).val() == "1") {
                                      strFinal = strFinal + "0"
                                      for (j = 1; j < selectActivitySplitSub.length; j++) {
                                          strFinal = strFinal + ",1"
                                      }
                                  }
                                  else{
                                      strFinal = strFinal + "1"
                                      for (j = 1; j < selectActivitySplitSub.length; j++) {
                                          strFinal = strFinal + ",0"
                                      }
                                  }
                              }
                              //console.log(patStr);
                              alphaallModeComponenti(patStr, strFinal)
                              updateSetpointModeComponenti($("#"+masterPath),$(this),true);
                          }
                      }
                      if ((modeComponentiStr.indexOf("BETA") >= 0) && ((count == "0") || (count == "13"))) {// per il beta
                         // console.log("beta")
                          var strFinal = "BETA|";
                          var selectActivity = modeComponentiStr.replace("BETA|","").split(",");
                          if (count == "0"){
                              if ($(this).val() == 0) {// se disabilito
                                  strFinal = strFinal + "1,1"
                              }
                              else
                                  strFinal = strFinal + "1,0"
                              strFinal = strFinal + "," + selectActivity[2] + "," + selectActivity[3] + "," + selectActivity[4] + "," + selectActivity[5]
                              //console.log("modecomponenti" + strFinal)
                              $("#" + masterPath).attr("modecomponenti", strFinal);
                          }
                          if (count == "13") {
                              strFinal = strFinal + selectActivity[0] + "," + selectActivity[1] + "," + selectActivity[2] + "," + selectActivity[3]
                              if ($(this).val() == 0) {// se disabilito
                                  strFinal = strFinal + ",1,1"
                              }
                              else
                                  strFinal = strFinal + ",0,1"
                              $("#" + masterPath).attr("modecomponenti", strFinal);
                          }
                          
                          betaModeComponenti(masterPath, strFinal);
                          updateSetpointModeComponenti($("#" + masterPath), $(this), true);
                      }
                  }

              if ($(this).attr("id").indexOf("_modework") >= 0){
                  selectActionValue($(this).attr("id"), $(this).val());
                  $("#" + $(this).attr("path")).find("select").each(function () {
                      //$("#" + $(this).attr("id")).removeClass("active");
                      var selectOutIn = $(this).attr("typeoflist");
                      if (selectOutIn != undefined) {//quando disabilito i setpoind azzero anche le uscite
                          if ((selectOutIn == "relay") || (selectOutIn == "input") || (selectOutIn == "opto")) {
                              //console.log("invioComando:" + $(this).attr("id"))
                              //$(this).find('option:nth-child(\'0 \')').prop('selected', true);
                              previousSelect = this.value;
                              $(this).val(0);
                              inputOutput(currenteSelectVal, selectOutIn, previousSelect);
                              updateSetpointSelect($(this).attr("id"), $(this));
                          }
                      }
                     // console.log(selectOutIn);
                  });
              }
          try {
              /*
              var cat = $("#" + $(this).attr("path")).find("select").attr("typeoflist");
              console.log("select:action:" + cat.length)
              */


              if ($(this).attr("action") == "setpoint") {
                  var idSelect = $(this).attr("oreminuti");
                  

                  if ((idSelect != undefined) && (idSelect != "")) {//caso di ore e minuti o minuti e secondi
                      var idSelectID = $(this).attr("id").replace("_1", "");
                      
                      if ((idSelect == "ore")||(idSelect == "minuti")) { 
                          updateSetpointSelectOreMinuti("#" + idSelectID);
                      }
                  }
                  else {
                      //console.log("relay")
                      //console.log("relay")
                      if (typeOfList != undefined) { // caso relay or opto or input
                          var currenteSelectVal = $(this).val();
                          inputOutput(currenteSelectVal, typeOfList, previousSelect);

                      }
                      updateSetpointSelect($(this).attr("id"), $(this));
                  }
              }

          }
          catch (ex) {

          }
          //alert($(this).text());
          //alert($(this).val());
          //alert($(this).attr("attrib"));
          //$("div").text(str);
          // alert(str)
      }

  })
  .change();


function inputOutput(currentVal, typeOfList, previousSelect) {

    var currenteSelectVal = currentVal;
    if (currenteSelectVal != previousSelect) {
        if (typeOfList == "relay") {
            arrayRelay[previousSelect] = 0;
            arrayRelay[currenteSelectVal] = 1;
        }
        if (typeOfList == "input") {
            arrayInput[previousSelect] = 0;
            arrayInput[currenteSelectVal] = 1;
        }
        if (typeOfList == "opto") {
            arrayOpto[previousSelect] = 0;
            arrayOpto[currenteSelectVal] = 1;
        }
        if (typeOfList == "opto") {
            arrayMA[previousSelect] = 0;
            arrayMA[currenteSelectVal] = 1;
        }
    }
    aggiornamentoListaOptoInputRelay();

}
function orModeComponenti(orChiave,orValue) {
    $("[modecomponenti]").each(function () {
        if (($(this).attr("modecomponenti").indexOf("OR") >= 0) && (orChiave.indexOf($(this).attr("id")) >= 0)) {
            var selectActivitySplit = orValue.split("|");
            var pathGenetral = $(this).attr("id");
            var idPaneActive = "";
            
            if (selectActivitySplit.length > 0) {
                var selectActivitySplitSub = selectActivitySplit[1].split(",");
                var countLiActivate = 0;
                $("#" + pathGenetral).find("li[id*='" + pathGenetral + "']").each(function () {
                    $("#" + $(this).attr("id")).removeClass("active");
                    
                    if ((selectActivitySplitSub[countLiActivate] == "1")) {
                        
                        $("#" + $(this).attr("id")).addClass("active");
                        idPaneActive = $(this).attr("id").replace("_li", "");
                    }
                    countLiActivate = countLiActivate + 1;
                });
                countLiActivate = 0;
                $("#" + idPaneActive).addClass("active");
            }
        }
    });
}
$("a").click(function () {
    //console.log("click")
    try{
        var typeSetpoint =  $(this).attr("type");
        if (typeSetpoint == "setpoint") {
            var masterPath = $(this).attr("master");
            
            if ($("#" + masterPath).attr("modecomponenti").indexOf("OR") >= 0) {//caso OR
                var indicePath = parseInt($(this).attr("indice"));
                var indiceSplit = 0;
                var orType = $("#" + masterPath).attr("modecomponenti").replace("OR|", "").split(",")
                
               // var orTypeSplit = orType.split(",");
                var orDefinitivo = "OR|";
                var virgola = ""
                
                for (indiceSplit = 0; indiceSplit < orType.length; indiceSplit++) {
                    if (indicePath ==  indiceSplit)
                        orDefinitivo = orDefinitivo + virgola + "1"
                    else
                        orDefinitivo = orDefinitivo + virgola + "0"
                    virgola = ",";
                }
                $("#" + masterPath).attr("modecomponenti", orDefinitivo);
                updateSetpointModeComponenti($("#" + masterPath), $(this),false);
                //console.log(orDefinitivo)
            }
        }
        /*if (typeSetpoint == "weekItem") {// caso del week del biocide modifica un orario
            console.log("modifica")
        }
        if (typeSetpoint == "weekItemPiu") {// caso del week del biocide aggiungi orario
            console.log("aggiungi orario")
        }*/

    }
    catch (ex) {
        
    }
});
function aggiornaWeekValueTen(indice_sub,indice,valore,id,newValore,giornoSettimana){
    var newValoreNew = newValore.replace(":", ",");//replace all
    var splitValueItemNano = valore.split("|");
    var finalValue = "";
    var finalValueFinal = "";
    var i = 0;
    var j = 0;
    
    while (newValoreNew.indexOf(":") >= 0)
        newValoreNew = newValoreNew.replace(":", ",");
    

    for (j = 0; j < splitValueItemNano.length-1; j++) {
        var splitValueItem = splitValueItemNano[j].split("?");
        finalValue = "";
        for (i = 0; i < 10; i++) {
            if ((i == indice_sub)&&(j==indice)) {
                finalValue = finalValue + newValoreNew
            }
            else {
                if ((splitValueItem.length > 1)||(i==0))
                    finalValue = finalValue + splitValueItem[i]
                else {
                        finalValue = finalValue + "00,00,00,00"
                    }
            }
            finalValue = finalValue + "?";
        }
        finalValueFinal = finalValueFinal + finalValue + "|"
    }
    updateSetpointWeek(id.replace("#", ""), finalValueFinal, giornoSettimana, indice_sub)

    //console.log(id + ":" + indice + ":" + indice_sub)
    //console.log(finalValueFinal)
    preparaWeek(id, finalValueFinal, giornoSettimana);
    

}
function functionWeekItem(indice_sub,indice,valore,id,giornoSettimana,hr,min,thr,tmin) {
    
    bootbox.confirm(listWeekDetails(giornoSettimana,hr, min, thr, tmin), function (result) {

        if (result) {
            /* bootbox.alert(progressBar(), function(result) 
             {
                 $.gritter.add({
                     title: 'Callback!',
                     text: "I'm just a BootBox Alert callback!"
                 });
             });
             */
            //bootbox.dialog({ message:progressBar() });
            //bootbox.dialog(progressBar());
            aggiornaWeekValueTen(indice_sub, indice, valore, id, $("#weekItemTenSub").val() + ":" + $("#weekItemTenSubHr").val() + ":" + $("#weekItemTenSubMin").val(), giornoSettimana)
            //console.log($("#weekItemTenSub").val() + ":" + $("#weekItemTenSubHr").val() + ":" + $("#weekItemTenSubMin").val())
            bootbox.hideAll();
        }
        else {
          /*  $.gritter.add({
                title: 'Callback!',
                text: "BootBox Confirm Callback with result: " + result
            });*/
        }
    });
    activate_time_picker("weekItemTenSub");
    return false;
}
function alphaallModeComponenti(alphaallChiave,alphaallValue) {
    
    $("[modecomponenti]").each(function () {
        if (($(this).attr("modecomponenti").indexOf("ALPHAall") >= 0)&&(alphaallChiave.indexOf($(this).attr("id")) >= 0)) {
            var selectActivitySplit = alphaallValue.split("|");
            var pathGenetral = $(this).attr("id");

            if (selectActivitySplit.length > 0) {
                var selectActivitySplitSub = selectActivitySplit[1].split(",");
                var countLiActivate = 0;
                $(this).attr("modecomponenti", alphaallValue);
                $("#" + pathGenetral).find("li[id*='" + pathGenetral + "']").each(function () {
                    $("#" + $(this).attr("id")).show();
                    if ((selectActivitySplitSub[countLiActivate] == "0") && (countLiActivate > 0)) {
                        $("#" + $(this).attr("id")).hide();
                    }
                    countLiActivate = countLiActivate + 1;
                });
            }
        }
    });
}
function betaModeComponenti(alphaallChiave, alphaallValue) {

    $("[modecomponenti]").each(function () {
        if (($(this).attr("modecomponenti").indexOf("BETA") >= 0) && (alphaallChiave.indexOf($(this).attr("id")) >= 0)) {
            var selectActivitySplit = alphaallValue.split("|");
            var pathGenetral = $(this).attr("id");

            if (selectActivitySplit.length > 0) {
                var selectActivitySplitSub = selectActivitySplit[1].split(",");
                var countLiActivate = 0;
                $(this).attr("modecomponenti", alphaallValue);
                $("#" + pathGenetral).find("li[id*='" + pathGenetral + "']").each(function () {
                    $("#" + $(this).attr("id")).show();
                    if ((selectActivitySplitSub[countLiActivate] == "0") && (countLiActivate > 0)) {
                        $("#" + $(this).attr("id")).hide();
                    }
                    // alert(countLiActivate)
                    countLiActivate = countLiActivate + 1;
                });
            }
        }
        //alert($(this).attr("modecomponenti"));
    });
}

function selectActionValue(idSelectValue, valueSelect) {

    var selectActivity = $("#" + idSelectValue).attr("attrib");
    var pathGenetral = $("#" + idSelectValue).attr("path");
    var selectActivitySplit ;
    if (selectActivity != "null") {
        selectActivitySplit = selectActivity.split(",");
    }
    //var currentVal = $(this).val();
    var currentVal = valueSelect;
    var i = 0;
    $("#" + pathGenetral).find("div[id*='" + pathGenetral + "']").each(function () {
        $("#" + $(this).attr("id")).show();
        
        if (selectActivity != "null") {
            for (i = 0; i < selectActivitySplit.length; i++) {
                var selectActivitySecondSplit = selectActivitySplit[i].split(">");

                if (selectActivitySecondSplit[0] == currentVal) {
                    var j = 0;
                    for (j = 1; j < selectActivitySecondSplit.length; j++) {
                        //console.log($(this).attr("id") + " " + selectActivitySecondSplit[j])
                        if ($(this).attr("id").indexOf(selectActivitySecondSplit[j]) >= 0) {
                            //console.log($(this).attr("id"))
                            $("#" + $(this).attr("id")).hide();
                        }
                    }
                }
            }
        }
        else {
            if ($(this).attr("id").indexOf("modeworkEnableDisable") < 0) {
                if (currentVal == 0)
                    $("#" + $(this).attr("id")).hide();
            }
        }
    });
}


$("#modals-bootbox-confirm").click(function () {
    bootbox.confirm(listSetpoint(), function(result) 
    {

        if (result){
           /* bootbox.alert(progressBar(), function(result) 
            {
                $.gritter.add({
                    title: 'Callback!',
                    text: "I'm just a BootBox Alert callback!"
                });
            });
            */
            //bootbox.dialog({ message:progressBar() });
            bootbox.dialog(progressBar() );
        }
        else{
            $.gritter.add({
                title: 'Callback!',
                text: "BootBox Confirm Callback with result: "+ result
            });
        }
    });
    return false;
});
function listSetpoint()
{
    var strFinal="";
    strFinal = strFinal + "<div class = \"widget\">"
    strFinal = strFinal + "<div class=\"widget-head\">"
    strFinal = strFinal + "<h4 class=\"heading glyphicons history\"><i></i>List Update</h4>"
    strFinal = strFinal + "</div>" // end widget head
    strFinal = strFinal + "<div class=\"widget-body center\">"
    //strFinal = strFinal + "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.aaaaaaaaaaaaaaaaaaaaaaaaasf egt eeeeeeeeetrt             retyeryery rey eryrrrrrrrrrrrrrrrrrrrrrrrrr reyeryeryerererererererererererererererererererererer re ery              reyerrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrr eryery eryyyyyyyyyyyyyyyyyyyy";
    //strFinal = strFinal + "<ul>"
    //strFinal = strFinal + "<li Class=\" glyphicons no-js ok_2\"><i></i> value1</li>"
    //strFinal = strFinal + "<li Class=\" glyphicons no-js ok_2\"><i></i> value2</li>"
    // strFinal = strFinal + "</ul>"

    jQuery(arraySetpointChange).each(function(i, item){
        var jsonParseSetpoint = JSON.parse(item)
        
            if (jsonParseSetpoint.errore){
                strFinal = strFinal + "<span class=\"gritter-add-sticky btn btn-default btn-block btn-icon-stacked glyphicons remove\" style=\"color:red;\"><i></i><strong>"+jsonParseSetpoint.valoreVisualizzato + "</strong><span>"+jsonParseSetpoint.errorTex+"</span></span>"
            }
            else{
                strFinal = strFinal + "<span class=\"gritter-add-sticky btn btn-default btn-block btn-icon-stacked glyphicons ok_2\"><i></i><strong>" + jsonParseSetpoint.valoreVisualizzato + "</strong><span>" + jsonParseSetpoint.descrizione + "</span></span>"
            }
    })

    jQuery(arraySetpointActionChange).each(function (i, item) {
        var jsonParseSetpoint = JSON.parse(item)

        if (jsonParseSetpoint.errore) {
            strFinal = strFinal + "<span class=\"gritter-add-sticky btn btn-default btn-block btn-icon-stacked glyphicons remove\" style=\"color:red;\"><i></i><strong>" + jsonParseSetpoint.valoreVisualizzato + "</strong><span>" + jsonParseSetpoint.errorTex + "</span></span>"
        }
        else {
            strFinal = strFinal + "<span class=\"gritter-add-sticky btn btn-default btn-block btn-icon-stacked glyphicons ok_2\"><i></i><strong>" + jsonParseSetpoint.valoreVisualizzato + "</strong><span>" + jsonParseSetpoint.descrizione + "</span></span>"
        }
    })
    strFinal = strFinal + "</div>" // end widget body
    strFinal = strFinal + "</div>" // end widget
    return strFinal;
}
function progressBar()
{
   // return "<div class='widget'><div class='widget-head progress progress-primary' id='widget-progress-bar'> 		<div class='bar'>Lorem ipsum <strong>dolor</strong> 		<strong class='steps-percent'>100%</strong></div>	</div></div>" ;
    var strFinal="";

    var lunghezzaArray = arraySetpointChange.length;
    var lunghezzaArrayAction = arraySetpointActionChange.length;
    
    //console.log("lunghezzaArray:" + lunghezzaArray)
    strFinal = "<div class=\"widget-sidebar-stats\">";
    if ((lunghezzaArray <= 0) && (lunghezzaArrayAction <= 0)) {
        strFinal = strFinal + "<span>No Data Modified </span>"
        strFinal = strFinal + "<div><button id=\"modals-bootbox-close\" class=\"btn btn-primary\" style=\"margin-top:5px\">Close</button></div>"
    }
    else{
            strFinal = strFinal + "<span id=\"modals-bootbox-confirm-text\">Saving <strong id=\"modals-bootbox-confirm-percent\" class=\"pull-right\">5% </strong></span>"
            strFinal = strFinal + "<div class=\"progress progress-success\">"
            strFinal = strFinal + "<div class=\"bar\" id=\"modals-bootbox-confirm-percent-progress\" style=\"width: 0%;\"></div>";
            strFinal = strFinal + "</div>";
    
            indiceSetpointSend = 0;
            if (lunghezzaArrayAction <= 0)
                setTimeout(sendSetpoint, 1000);
            else
                setTimeout(sendSetpointAction, 1000);
            strFinal = strFinal + "<button id=\"modals-bootbox-close\" class=\"btn btn-primary\" style=\"margin-top:5px;display:none\">Close</button>"
    }
    
    //strFinal = strFinal + "<span class=\"btn btn-block btn-success\">Success</span>"
    
    strFinal = strFinal + "<div class=\"clearfix\"></div>";

    // java script'
    strFinal = strFinal + "<div class=\"clearfix\"></div>";

    strFinal = strFinal +"<script type=\"text/javascript\">"
    strFinal = strFinal +"function closeAllbootbox(){"
    strFinal = strFinal +"bootbox.hideAll();"
    strFinal = strFinal +"}"
    strFinal = strFinal +"$( \"#modals-bootbox-close\" ).click(function() {"
    strFinal = strFinal +    "bootbox.hideAll();"
    strFinal = strFinal +"});"

    strFinal = strFinal +"</script>"

    strFinal = strFinal + "</div>";

    return strFinal;
}
function escapeRegExp(str) {
    return str.replace(/([.*+?^=!:${}()|\[\]\/\\])/g, "\\$1");
}
function replaceAll(str, find, replace) {
    return str.replace(new RegExp(escapeRegExp(find), 'g'), replace);
}
/*
function closeAllbootbox(){
    bootbox.hideAll();
}
*/
function sendCalibrationAction(actionText,actionValue,idLavoro) {
    var stringSend = "";
    stringSend = stringSend + replaceAll(actionText, "_", ">") + ":" + actionValue.replace(":", ",") + "$";
    stringSend = stringSend + "&";
    $.ajax({
        type: "POST",
        url: "Centurio/centurioReal.aspx/saveSetpointAction",
        //data: {check1: $("#rms_all").is(':checked') ,check1_1: $("#rms_medio").is(':checked'),  check1_2:  $("#rms_max").is(':checked') ,check2 : $("#picco_all").is(':checked') , check2_1 : $("#picco_medio").is(':checked') , check2_2 : $("#picco_max").is(':checked') , check3: $("#vm_rms_all").is(':checked') , check3_1: $("#vm_rms_medio").is(':checked') , check3_2 : $("#vm_rms_max").is(':checked') , check4 : $("#vm_picco_all").is(':checked') , check4_1 : $("#vm_picco_medio").is(':checked') , check4_2: $("#vm_picco_max").is(':checked')   },
        //data: { check1: false, check1_1: true, check1_2: false, check2: false, check2_1: true, check2_2: false, check3: false, check3_1:true, check3_2:false, check4: false, check4_1:true, check4_2:false },
        data: "{'serialNumber':'" + JSON.stringify(serialNumberGlobal) + "','setpoint':'" + JSON.stringify(stringSend) + "'}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        //timeout: 6000, //3 second timeout
        success: function (response) {
            var jsonResponse = JSON.parse(response.d);
            var valoreCalibrazioneRestituire=0;
            console.log("close window:"+parseInt(jsonResponse.count) + "," + jsonResponse.errore)
            if (jsonResponse.errore == "ok") {//risposta positiva
                console.log("close window1:"+parseInt(jsonResponse.count) + "," + jsonResponse.errore)
                valoreCalibrazioneRestituire =  parseInt(jsonResponse.count)
            }
            if (jsonResponse.errore == "error") {//risposta positiva
                valoreCalibrazioneRestituire =  254;
            }
            countdownCalibration(idLavoro,valoreCalibrazioneRestituire)
        },
        failure: function (response) {
            countdownCalibration(idLavoro,255)
            alert(response.d);
        }

    });
    //return 255;
}
function sendSetpointAction() {
    var stringSend = "";
    var i = 0;
    var lunghezzaArray = arraySetpointActionChange.length;
    for (i = 0; i < lunghezzaArray; i++) {
        var jsonParseSetpoint = JSON.parse(arraySetpointActionChange[indiceSetpointSend]);
        //console.log(jsonParseSetpoint.id)
        stringSend = stringSend + replaceAll(jsonParseSetpoint.id, "_", ">") + ":" + jsonParseSetpoint.valore.replace(":", ",") + "$"
        if (stringSend.indexOf("communication>message"))
            stringSend = stringSend.replace("communication>message", "communication_message")

        //console.log("stringaSend:" + stringSend)
        //communication_communication_message_mail_mail2

    }
    stringSend = stringSend + "&";
    
    $.ajax({
        type: "POST",
        url: "Centurio/centurioReal.aspx/saveSetpointAction",
        //data: {check1: $("#rms_all").is(':checked') ,check1_1: $("#rms_medio").is(':checked'),  check1_2:  $("#rms_max").is(':checked') ,check2 : $("#picco_all").is(':checked') , check2_1 : $("#picco_medio").is(':checked') , check2_2 : $("#picco_max").is(':checked') , check3: $("#vm_rms_all").is(':checked') , check3_1: $("#vm_rms_medio").is(':checked') , check3_2 : $("#vm_rms_max").is(':checked') , check4 : $("#vm_picco_all").is(':checked') , check4_1 : $("#vm_picco_medio").is(':checked') , check4_2: $("#vm_picco_max").is(':checked')   },
        //data: { check1: false, check1_1: true, check1_2: false, check2: false, check2_1: true, check2_2: false, check3: false, check3_1:true, check3_2:false, check4: false, check4_1:true, check4_2:false },
        data: "{'serialNumber':'" + JSON.stringify(serialNumberGlobal) + "','setpoint':'" + JSON.stringify(stringSend) + "'}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        //timeout: 6000, //3 second timeout
        success: function (response) {
            $("#modals-bootbox-confirm-percent").text(((100 * (indiceSetpointSend)) / lunghezzaArray).toString() + "%");
            $("#modals-bootbox-confirm-percent-progress").css("width", ((100 * (indiceSetpointSend)) / lunghezzaArray).toString() + "%")

            var jsonResponse = JSON.parse(response.d);
            //console.log("close window:"+response.d)
            if (jsonResponse.errore == "ok") {//risposta positiva
                arraySetpointActionChange = [];//svuoto i setpoint
                if (arraySetpointChange.length > 0)
                //console.log("close window:"+numeroSetpointScritti)
                    setTimeout(sendSetpoint, 500);
                else
                {
                    $("#modals-bootbox-confirm-text").text("Saving OK");
                    $("#modals-bootbox-close").show();
                }
            }
            if (jsonResponse.errore == "error") {//risposta positiva
                $("#modals-bootbox-confirm-text").text("Save ERROR");
                $("#modals-bootbox-close").show();

            }

        },
        failure: function (response) {
            alert(response.d);
        }

    });
}
function sendSetpoint()
{
    var i=0;
    var stringSend = "";
    var almenoUnvalore = false;
    var lunghezzaArray = arraySetpointChange.length;

    //invio 5 setpoint alla volta;

    for (i=0;i<5;i++){
        var jsonParseSetpoint = JSON.parse(arraySetpointChange[indiceSetpointSend]);
        if (jsonParseSetpoint.errore == false) {
            almenoUnvalore = true;
            var modifyTemp = replaceAll(jsonParseSetpoint.id, "_", ">")
            modifyTemp = modifyTemp.replace("-", "[")
            modifyTemp = modifyTemp.replace("-", "]")
            stringSend = stringSend + modifyTemp + ":" + jsonParseSetpoint.valore.replace(":", ",") + "$"
            
            console.log(stringSend)
        }
        if (stringSend.indexOf("communication>message"))
            stringSend = stringSend.replace("communication>message", "communication_message")

        indiceSetpointSend++;
        if ((indiceSetpointSend) >=lunghezzaArray)
            i=6;
    }
    stringSend = stringSend +"&";
if (almenoUnvalore){
                $.ajax({
                    type: "POST",
                    url: "Centurio/centurioReal.aspx/saveSetpoint",
                    //data: {check1: $("#rms_all").is(':checked') ,check1_1: $("#rms_medio").is(':checked'),  check1_2:  $("#rms_max").is(':checked') ,check2 : $("#picco_all").is(':checked') , check2_1 : $("#picco_medio").is(':checked') , check2_2 : $("#picco_max").is(':checked') , check3: $("#vm_rms_all").is(':checked') , check3_1: $("#vm_rms_medio").is(':checked') , check3_2 : $("#vm_rms_max").is(':checked') , check4 : $("#vm_picco_all").is(':checked') , check4_1 : $("#vm_picco_medio").is(':checked') , check4_2: $("#vm_picco_max").is(':checked')   },
                    //data: { check1: false, check1_1: true, check1_2: false, check2: false, check2_1: true, check2_2: false, check3: false, check3_1:true, check3_2:false, check4: false, check4_1:true, check4_2:false },
                    data: "{'serialNumber':'" + JSON.stringify(serialNumberGlobal) + "','setpoint':'"+ JSON.stringify(stringSend) +"'}",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    //timeout: 6000, //3 second timeout
                    success: function (response) {
                        $("#modals-bootbox-confirm-percent").text(((100 * (indiceSetpointSend )) / lunghezzaArray ).toString() +"%");
                        $("#modals-bootbox-confirm-percent-progress").css("width",((100 * (indiceSetpointSend )) / lunghezzaArray ).toString() + "%")

                        var jsonResponse = JSON.parse(response.d);
                        //console.log("close window:"+response.d)
                        if (jsonResponse.errore == "ok"){//risposta positiva
                            var numeroSetpointScritti = parseInt(jsonResponse.count);
                            //console.log("close window:"+numeroSetpointScritti)
                            if (numeroSetpointScritti > 0){//da ottimizzare
                                if (indiceSetpointSend < lunghezzaArray)
                                    setTimeout(sendSetpoint, 500);
                                else {
                                    arraySetpointChange = [];//svuoto i setpoint
                                    $("#modals-bootbox-confirm-text").text("Saving OK");
                                    $("#modals-bootbox-close").show();
                                    //setTimeout(closeAllbootbox(), 4000);
                                }

                            }
                        }
                        if (jsonResponse.errore == "error"){//risposta positiva
                            $("#modals-bootbox-confirm-text").text("Save ERROR");
                            $("#modals-bootbox-close").show();

                        }

                    },
                    failure: function (response) {
                        alert(response.d);
                    }

                });
}
else {
    $("#modals-bootbox-confirm-text").text("Save ERROR");
    $("#modals-bootbox-close").show();
}

}
function activate_date_picker(id) {
    
    $("#" + id).datepicker({
        dateFormat: 'dd-mm-yy'
    });
   /* $('#'+id).datetimepicker({
        dateFormat: 'dd-mm-yy',
        timeFormat: 'hh:mm tt',
        addSliderAccess: true,
        sliderAccessArgs: { touchonly: false }
    });*/

   

}
$.datepicker.setDefaults({
    onSelect: function (dateText) {
        var min = $(this).attr("min")
       
        if (min == "minlog") {//data del log
            //alert("cambiato")
            reloadSetpoint = true;
        }
        else
            updateSetpoint($(this).attr("id"), this);
    }
});
function aggiornaWeek(id)
{
    var nuovoValore = "";
    var i = 0;

    for (i = 0; i < 7; i++) {
        var tempVal = ($("#" + id + "_time_" + i.toString()).val()).split(":")
        nuovoValore = nuovoValore + tempVal[0] + "," + tempVal[1] + "," + $("#" + id + "_feed_" + i.toString()).val() + "," + $("#" + id + "_1_feed_" + i.toString()).val() + "|"
    }
    $("#" + id).val(nuovoValore);
    updateSetpoint($("#" + id).attr("id"), $("#" + id));
}
$.timepicker.setDefaults({
    //dateFormat: 'dd/mm/yy',
    onSelect: function (dateText) {
        var min = $(this).attr("min")
        
        if (min == "0,0,0,0") {//week biocide
            var mainId = $(this).attr("mainid");
            aggiornaWeek(mainId);
        }
        if ((min == "timeDataOraR") || (min == "timeDataOraS")) { //time
            updateSetpoint($(this).attr("id"), this);
        }
    }
});

function activate_time_picker(id) {
    //console.log("time picker " + $("#weekItemTenSub").attr("id"))
    $("#" + id).timepicker({
        timeFormat: "HH:mm",
        
    });
    /* $('#'+id).datetimepicker({
         dateFormat: 'dd-mm-yy',
         timeFormat: 'hh:mm tt',
         addSliderAccess: true,
         sliderAccessArgs: { touchonly: false }
     });*/



}

function updateValori(response, firstValue) {

    try {
        
        jsonParse = JSON.parse(response.d)
        
       // jsonParse = JSON.parse(JSON.stringify(response.d));
    }
    catch (ex) {
        //jsonParse = JSON.parse(JSON.stringify(response.d));
    }

    
    try {
        
        jsonParseLabel = JSON.parse(labelJson);
    }
    catch (ex) {
    }

    

    //alert(labelJson )
    
    if (jsonParse.change == "1")// c' stato ubn cambiamento di setpoint
    {
     //   alert("changeSetpoint")
       /* $.notyfy({text:'Setpoint change into device',
            type: 'information' // alert|error|success|information|warning|primary|confirm
        });*/
        var resetIndex = 0;
        for (resetIndex = 0; resetIndex < arrayRelay.length; resetIndex++)
            arrayRelay[resetIndex] =0;
        for (resetIndex = 0; resetIndex < arrayInput.length; resetIndex++)
            arrayInput[resetIndex] =0;
        for (resetIndex = 0; resetIndex < arrayOpto.length; resetIndex++)
            arrayOpto[resetIndex] = 0;

        
        $.gritter.add({
            title: 'SetPoint changed',
            text: "Setpoint changed into device "
        });
    }
    
    /*
    bootbox.confirm("Are you sure?", function(result) 
    {
        $.gritter.add({
            title: 'Callback!',
            text: "BootBox Confirm Callback with result: "+ result
        });
    });
    */

    /*$.notyfy({text:'notyfy - Yet another jQuery notification plugin',
        type: 'information' // alert|error|success|information|warning|primary|confirm
    });*/
    if ((jsonParse.errore == "ok") || (jsonParse.errore == "disconnected")) {
        if (jsonParse.errore == "disconnected"){
            $("#notConnectedMain").show();
            clearInterval(refreshIntervalId);
        }
        else
                $("#notConnectedMain").hide();
        var k = 0;
        for (k = 0; k < jsonParse.variable.length; k++) {
            //console.log("setpoint:" + jsonParse.variable[k]["chiave"])
            try {
                 //$("#" + jsonParse.variable[k]["chiave"]).text(jsonParse.variable[k]["valore"]);

                if (((jsonParse.change == "1")||(firstValue))&&(jsonParse.variable[k]["chiave"].indexOf("_") >= 0)){ //modifica dei setpoint
                    if (jsonParse.variable[k]["chiave"].indexOf("[") >= 0) {
                        jsonParse.variable[k]["chiave"] = jsonParse.variable[k]["chiave"].replace("[", "-");
                        jsonParse.variable[k]["chiave"] = jsonParse.variable[k]["chiave"].replace("]", "-");
                        //console.log("newVAlue:" + jsonParse.variable[k]["chiave"])
                                    }

                                if (jsonParse.variable[k]["valore"].indexOf("OR|") >= 0) {
                                    orModeComponenti(jsonParse.variable[k]["chiave"],jsonParse.variable[k]["valore"]);
                                }
                                if (jsonParse.variable[k]["valore"].indexOf("ALPHAall|") >= 0) {
                                    alphaallModeComponenti(jsonParse.variable[k]["chiave"],jsonParse.variable[k]["valore"]);
                                }
                                if (jsonParse.variable[k]["valore"].indexOf("BETA|") >= 0) {
                                    betaModeComponenti(jsonParse.variable[k]["chiave"], jsonParse.variable[k]["valore"]);
                                }
                    
                                if ($("#" + jsonParse.variable[k]["chiave"]).is("select")) { // per select box
                                    if (jsonParse.variable[k]["valore"].indexOf(",") >= 0) { // time da impostare
                                        var splitTimeValue = (jsonParse.variable[k]["valore"]).split(",")
                                        //console.log("timeSplit:" + jsonParse.variable[k]["chiave"] + ":" + (parseInt(splitTimeValue[1])).toString())
                                        $("#" + jsonParse.variable[k]["chiave"] + "> [value=" + (parseInt(splitTimeValue[0])).toString() + "]").prop("selected", true);
                                        $("#" + jsonParse.variable[k]["chiave"] + "_1> [value=" + (parseInt(splitTimeValue[1])).toString() + "]").prop("selected", true);
                                    }
                                    else {
                                        var typrofList = $("#" + jsonParse.variable[k]["chiave"]).attr("typeoflist");
                                        //console.log(typrofList)
                                        try{
                                            if (typrofList == "opto")
                                                arrayOpto[parseInt(jsonParse.variable[k]["valore"])] = 1
                                            if (typrofList == "input")
                                                arrayInput[parseInt(jsonParse.variable[k]["valore"])] = 1
                                            if (typrofList == "relay")
                                                arrayRelay[parseInt(jsonParse.variable[k]["valore"])] = 1

                                        }
                                        catch (e)
                                        {

                                        }
                                        $("#" + jsonParse.variable[k]["chiave"] + "> [value=" + jsonParse.variable[k]["valore"] + "]").prop("selected", true);
                                        if (jsonParse.variable[k]["chiave"].indexOf("_modework") >= 0) {
                                            console.log("Action:" + jsonParse.variable[k]["chiave"])
                                            selectActionValue(jsonParse.variable[k]["chiave"], jsonParse.variable[k]["valore"]);
                                        }
                                    }
                                }
                                if ($("#" + jsonParse.variable[k]["chiave"]).is("input")) { // per input box
                                    //console.log(jsonParse.variable[k]["chiave"] + ":" + jsonParse.variable[k]["valore"])
                                    var attributi = $("#" + jsonParse.variable[k]["chiave"]).attr("min");
                                    
                                    if (attributi == "0,0,0,0") {//caso del
                                        //alert("week")
                                        preparaWeek("#" + jsonParse.variable[k]["chiave"], jsonParse.variable[k]["valore"],"");
                                    }
                                    else {
                                        if ((attributi == "timeDataOraR") || (attributi == "timeDataOraS")) {//caso del
                                            if (attributi == "timeDataOraR")
                                                preparaTimeR("#" + jsonParse.variable[k]["chiave"], jsonParse.variable[k]["valore"]);
                                            if (attributi == "timeDataOraS")
                                                preparaTimeS("#" + jsonParse.variable[k]["chiave"], jsonParse.variable[k]["valore"]);

                                        }
                                        else {
                                            var attributiMulti = $("#" + jsonParse.variable[k]["chiave"]).attr("multi");
                                            if (attributiMulti == "ok") {//caso del text input multi (tipo PWM)
                                                var valoreMultiSplit = jsonParse.variable[k]["valore"].split("|");
                                                $("#" + jsonParse.variable[k]["chiave"]).val(valoreMultiSplit[0]);
                                                attributi = $("#" + jsonParse.variable[k]["chiave"]).attr("minB");
                                                if (attributi.indexOf("[") >= 0) {
                                                    calcolaMinimoMassimo("#" + jsonParse.variable[k]["chiave"], attributi);
                                                }
                                                $("#" + jsonParse.variable[k]["chiave"] + "_1").val(valoreMultiSplit[1]);

                                                attributi = $("#" + jsonParse.variable[k]["chiave"] + "_1").attr("minB");
                                                if (attributi.indexOf("[") >= 0) {
                                                    calcolaMinimoMassimo("#" + jsonParse.variable[k]["chiave"] + "_1", attributi);
                                                }

                                                $("#" + jsonParse.variable[k]["chiave"] + "_1").val(valoreMultiSplit[1]);

                                            }
                                            else {
                                                attributi = $("#" + jsonParse.variable[k]["chiave"]).attr("minB");
                                                if (attributi.indexOf("[") >= 0) {
                                                    calcolaMinimoMassimo("#" + jsonParse.variable[k]["chiave"], attributi);
                                                }
                                                
                                                $("#" + jsonParse.variable[k]["chiave"]).val(jsonParse.variable[k]["valore"]);
                                            }
                                        }
                                    }
                                }

                    //aggiornamento lista setpoint relay opto input
                                aggiornamentoListaOptoInputRelay();
                    

                } // end modifica setpoint

                /**/
                //log
                if ($("#" + jsonParse.variable[k]["chiave"] + "_log").is("h5")) { // header canale Log
                    
                    if ((jsonParse.variable[k]["chiave"]).indexOf("_") > 0) {
                        $("#" + jsonParse.variable[k]["chiave"] + "_log").html(createLabelGlobal("" + jsonParse.variable[k]["chiave"]));
                    }
                else{
                        //$("#" + jsonParse.variable[k]["chiave"] + "_log").html(createLabelGlobal("[" + jsonParse.variable[k]["chiave"] + "]"));
                        $("#" + jsonParse.variable[k]["chiave"] + "_log").html(createMisura("[" + jsonParse.variable[k]["chiave"] + "]"));
                    }
                }
             /*   if ($("#" + jsonParse.variable[k]["chiave"] + "_log_label").is("span")) { // header canale Log
                    console.log("ciaoLog:" + jsonParse.variable[k]["chiave"])
                    if ((jsonParse.variable[k]["chiave"]).indexOf("_") > 0) {
                        
                        //$("#" + jsonParse.variable[k]["chiave"] + "_log_label").empty();
                        
                        $("#" + jsonParse.variable[k]["chiave"] + "_log_label").html(createLabelGlobal("" + jsonParse.variable[k]["chiave"]));
                    }
                    else {
                        
                        //$("#" + jsonParse.variable[k]["chiave"] + "_log_label").empty();
                        $("#" + jsonParse.variable[k]["chiave"] + "_log_label").html(createLabelGlobal("[" + jsonParse.variable[k]["chiave"] + "]"));
                    }
                }*/
                //data e ora
                if ($("#" + jsonParse.variable[k]["chiave"]).is("h3")) { // per data e ora
                    $("#" + jsonParse.variable[k]["chiave"]).html(jsonParse.variable[k]["valore"]);
                }
                if ($("#" + jsonParse.variable[k]["chiave"] + "_h3").is("h3")) { // per data e ora
                    
                    $("#" + jsonParse.variable[k]["chiave"] + "_h3").html(jsonParse.variable[k]["valore"]);
                }
            }

            catch (ex) {
            }

        }
        //inserimento etichetta misura
        $("[id*='misura']").each(function () {
            var misuraValue = $(this).attr("attrMisura");
            
            if (misuraValue.indexOf("!") >= 0) {// caso del multi
                var misuraValueSplit = misuraValue.split("!")
                var id = $(this).attr("id")

                $(this).html(createMisura(misuraValueSplit[0]) + " " + createMisura(misuraValueSplit[1]));
            }
            else {
                //console.log("aggiorna misura" + misuraValue)
                $(this).html(createMisura(misuraValue))
            }
            //console.log($(this).html())
        });
        //blocco OK

        //enable log
        $("[id$='_log_enable']").each(function () {
            var attributoEnable = $(this).attr("id").replace("_log_enable", "");
            var attributoEnableVal = getValoreJson(attributoEnable);
            if (attributoEnable.indexOf("tempSR")) {//caso della remperatura
                //console.log("enableTemperature:" + attributoEnable + "," + attributoEnableVal)
                if (attributoEnableVal == 0)
                    $(this).show();
                else
                    $(this).hide();
            }
            else {
                if (parseInt(attributoEnableVal) > 0)
                    $(this).show();
                else
                    $(this).hide();
            }
            
        });
        //label log
        //$("input[name$='letter']")
        $("[id$='_log_label']").each(function () {
            var attributoLabel = $(this).attr("id").replace("_log_label", "");
            var attributoLabelLDLOG = $(this).attr("ldlog");
            var labelCurrent = "";
            if (attributoLabel.indexOf("_") > 0) {
                var attributoUnitaMisura = $(this).attr("unit");
                labelCurrent = createLabelGlobal(attributoLabel)
                labelCurrent = labelCurrent + " " + attributoLabelLDLOG;
                if (attributoUnitaMisura != undefined)
                    labelCurrent = labelCurrent + " " + createMisura("[" + attributoUnitaMisura + "]");
                $(this).html(labelCurrent)
                $("#" + attributoLabel + "_log").html(labelCurrent)
            }
            else {
                labelCurrent = createLabelGlobal("[" + attributoLabel + "]")
                labelCurrent = labelCurrent + " " + attributoLabelLDLOG;
                if ((labelCurrent == "") || (labelCurrent == " "))
                    labelCurrent = createMisura("[" + attributoLabel + "]");
                //console.log("label:" + labelCurrent)
                $(this).html(labelCurrent)
                $("#" + attributoLabel + "_log").html(labelCurrent)
            }
        });
        $("[type*='pathName']").each(function () {
            //console.log($(this).text());
            var pathLabel = $(this).text().split(">");
            if (pathLabel[0].indexOf("]") > 0) {
                pathLabel[0] = pathLabel[0].replace("[", "");
                pathLabel[0] = pathLabel[0].replace("]", "");
                var pathLabelFinish = getValoreJson(pathLabel[0]);
                if (pathLabel.length > 1) {
                    pathLabelFinish = pathLabelFinish + " > " + pathLabel[1];
                }
                $(this).text(pathLabelFinish)
            }
        });

        //aggiornameto label del menu
        $("[type*='menuSopra']").each(function () {
            var labelTempJson = $(this).attr("attributo");
            labelTempJson = labelTempJson.replace("[", "");
            labelTempJson = labelTempJson.replace("]", "");
            //console.log("sopra:" + )
            $(this).text(getValoreJson(labelTempJson))
        });
        //aggiornameto main label
        $("[type*='mainLabel']").each(function () {
            var idMainLabel = $(this).attr("id").replace("_mainLabel", "");
            console.log(getValoreJson(idMainLabel))
            $("#" + idMainLabel + "_mainLabel").text(getValoreJson(idMainLabel));

        });
        //aggiornameto main label
        //aggiornameto temperature
        $("[type*='mainTemperature']").each(function () {
            var idTemperature = $(this).attr("id");
            var idTemperatureSetting = $(this).attr("attribute");
            if (strumentoTouch){
                if (parseInt(getValoreJson(idTemperatureSetting)) == 0) {//temperature Visible
                    $(this).next('span').remove();
                    if (sistemaUSA == "0")
                        $(this).after('<span>' + getValoreJson(idTemperature) + ' °C</span>');
                    else
                        $(this).after('<span>' + getValoreJson(idTemperature) + ' °F</span>');
                    //$(this).next().html( getValoreJson(idTemperature));
                    $(this).show();

                }
                else {
                    if (parseInt(getValoreJson(idTemperatureSetting)) == 3) {//3 sta per i consumi giornalieri del laser
                        $(this).next('span').remove();
                        if (sistemaUSA == "0")
                            $(this).after('<span>' + getValoreJson(idTemperature) + ' L</span>');
                        else
                            $(this).after('<span>' + getValoreJson(idTemperature) + ' gal</span>');
                        //$(this).next().html( getValoreJson(idTemperature));
                        $(this).show();
                    }
                    else
                        $(this).hide();
                }
            }
            else {
                $(this).next('span').remove();
                var temperatureTemp = parseInt(getValoreJson(idTemperature)) / 10;
                if (sistemaUSA == "0")
                    $(this).after('<span>' + temperatureTemp.toString() + ' °C</span>');
                else
                    $(this).after('<span>' + temperatureTemp.toString() + ' °F</span>');
                //$(this).next().html( getValoreJson(idTemperature));
                $(this).show();
            }
        });
        //aggiornameto status globali

        //aggiornamento textRead
        $("[type*='textRead']").each(function () {
            var idTextRead = $(this).attr("id");
            var labelTempJson = $(this).attr("attribute");
            labelTempJson = labelTempJson.replace("[", "");
            labelTempJson = labelTempJson.replace("]", "");

            var TextReadValue = getValoreJson(labelTempJson);
            $(this).text(TextReadValue);
            console.log("textRead:" + labelTempJson,TextReadValue)
        });
        //end aggiornamento textRead
        //generic
        var areainoutgenericEnable = false;
        $("[id*='areainoutgeneric']").each(function () {
            var statusCheck = $(this).attr("id").replace("areainoutgeneric", "");
            areainoutgenericEnable = false;
            resultcanaleValore =0;
            try {
                var labelArea = $(this).attr("label").replace("areainoutgeneric", "");
                
                if (labelArea.indexOf(",") >= 0) { // condizione di multi label dovuto ad uno stato di lavorazione
                    
                    resultcanaleValore = parseInt(getValoreJson(statusCheck))
                    labelArea = labelArea.replace("[","");
                    labelArea = labelArea.replace("]","");
                    var labelAreaSplit = labelArea.split(",")
                    if (resultcanaleValore > 0) {
                        areainoutgenericEnable = true;
                        $(this).text("");
                        if (labelAreaSplit[resultcanaleValore] == "runtimeWashing")
                            $(this).append("<i></i>" + createLabelGlobal("[" + labelAreaSplit[resultcanaleValore] + "]") + " " + getValoreJson(labelAreaSplit[resultcanaleValore]));
                        else
                            $(this).append("<i></i>" + createLabelGlobal("[" + labelAreaSplit[resultcanaleValore] + "]"));
                        $(this).show();
                    }
                    else
                        $(this).hide()

                }
                else {
                    var resultTextValore = getValoreJson(statusCheck);
                    console.log("valore:" + statusCheck + " " + resultTextValore)
                    //console.log(jsonParse.variable)
                    areainoutgenericEnable = true;
                    //console.log(resultTextValore)
                    $(this).text("");
                    $(this).append("<i></i>" + createLabelGlobal(labelArea) + " " + resultTextValore);
                    $(this).show();
                }
                
               /* if (resultcanaleValore) {
                    areainoutoutputEnable = true;
                    $(this).text("");
                    $(this).append("<i></i>" + createLabelGlobal(labelArea));
                    $(this).show();
                }
                else
                    $(this).hide();*/

                //console.log(createLabelGlobal(labelArea) + ":" + resultcanaleValore)

            }
            catch (ex) {
            }
        });
        if (areainoutgenericEnable)
            $("#areainoutgeneric").show();
        else
            $("#areainoutgeneric").hide();

        //allarmi
        var areainoutoutputEnable = false;
        $("[id*='areainoutoutput']").each(function () {
            var statusCheck = $(this).attr("id").replace("areainoutoutput", "");
            try {
                var labelArea = $(this).attr("label").replace("areainoutoutput", "");
                resultcanaleValore = parseInt(getValoreJson(statusCheck))
                if (resultcanaleValore) {
                    areainoutoutputEnable = true;
                    $(this).text("");
                    $(this).append("<i></i>" + createLabelGlobal(labelArea));
                    $(this).show();
                }
                else
                    $(this).hide();

                //console.log(createLabelGlobal(labelArea) + ":" + resultcanaleValore)

            }
            catch (ex) {
                }
        });
        if (areainoutoutputEnable)
            $("#areainoutoutput").show();
        else
            $("#areainoutoutput").hide();
        //input
        var areainoutinputEnable = false;
        $("[id*='areainoutinput']").each(function () {
            var statusCheck = $(this).attr("id").replace("areainoutinput", "");
            try {
                var labelArea = $(this).attr("label").replace("areainoutinput", "");
                resultcanaleValore = parseInt(getValoreJson(statusCheck))
                if (resultcanaleValore) {
                    areainoutinputEnable = true;
                    $(this).text("");
                    $(this).append("<i></i>" + createLabelGlobal(labelArea));
                    $(this).show();
                }
                else
                    $(this).hide();

                //console.log(createLabelGlobal(labelArea) + ":" + resultcanaleValore)

            }
            catch (ex) {
            }
        });
        if (areainoutinputEnable)
            $("#areainoutinput").show();
        else
            $("#areainoutinput").hide();
        //allarmi
        var areainoutalarmEnable = false;
        $("[id*='areainoutalarm']").each(function () {
            var statusCheck = $(this).attr("id").replace("areainoutalarm", "");
            try {
                var labelArea = $(this).attr("label").replace("areainoutalarm", "");
                resultcanaleValore = parseInt(getValoreJson(statusCheck))
                if (resultcanaleValore) {
                    areainoutalarmEnable = true;
                    $(this).text("");
                    $(this).append("<i></i>" + createLabelGlobal(labelArea));
                    $(this).show();
                }
                else
                    $(this).hide();

                //console.log(createLabelGlobal(labelArea) + ":" + resultcanaleValore)

            }
            catch (ex) {
            }
        });
        if (areainoutalarmEnable)
            $("#areainoutalarm").show();
        else
            $("#areainoutalarm").hide();

        //aggiornameto allarmi globali
        $("[id*='globalID']").each(function () {
            var resultcanaleValore = 0;
            var statusCheck = $(this).attr("id").replace("globalID", "");
            resultcanaleValore = parseInt(getValoreJson(statusCheck))
            var oggettoFiglio = $(this).find("h4")
            //console.log("flusso:" + $(oggettoFiglio).attr("id").replace("global", ""));
            if ($(oggettoFiglio).attr("id").replace("global", "") == "flowR")
                $(oggettoFiglio).text("No Flow");
            else
                $(oggettoFiglio).text(createLabelGlobal($(oggettoFiglio).attr("id").replace("global", "")));
            if (resultcanaleValore > 0)
                $(this).show();
            else
                $(this).hide();
        });

        //aggiornamento blocco header

        var headerIndex = 0;
        //alert("prova")
        for (headerIndex = 0; headerIndex < arrayOggettiHeader.length; headerIndex++) {
            var oggettoHeaderTemp = arrayOggettiHeader[headerIndex];
            var resultheaderValore = 0;
            var resultheaderText = "";
            var resultfooterText = "";
            resultheaderValore = parseFloat(getValoreJson(oggettoHeaderTemp.nomeValriabileGlobal));
            if (oggettoHeaderTemp.totalizzatoreGlobal != resultheaderValore) {
                oggettoHeaderTemp.totalizzatoreGlobal = resultheaderValore;
                oggettoHeaderTemp.disegnaContatore();
            }
            resultheaderValore = parseInt(getValoreJson(oggettoHeaderTemp.nomeAlalrmeGlobal));
            //console.log("allarme:" + getValoreJson(oggettoHeaderTemp.nomeAlalrmeGlobal) + "," + oggettoHeaderTemp.nomeAlalrmeGlobal)
            if (oggettoHeaderTemp.allarmeGlobal != resultheaderValore) {
                oggettoHeaderTemp.allarmeGlobal = resultheaderValore;
                oggettoHeaderTemp.disegnaContatore();
            }
            //piscina
            resultheaderValore = parseInt(getValoreJson(oggettoHeaderTemp.nomeAlertFlow));
            //console.log("allarme:" + resultheaderValore)
            if (oggettoHeaderTemp.alertFlowValue != resultheaderValore) {
                oggettoHeaderTemp.alertFlowValue = resultheaderValore;
                oggettoHeaderTemp.disegnaContatore();
            }

            //end piscina

            //flowmeterValue
            resultheaderValore = parseFloat(getValoreJson(oggettoHeaderTemp.nomeFlowGlobal));
            //console.log("allarme:" + oggettoHeaderTemp.nomeFlowGlobal)
            if (oggettoHeaderTemp.flowMeterValue != resultheaderValore) {
                oggettoHeaderTemp.flowMeterValue = resultheaderValore;
                oggettoHeaderTemp.disegnaContatore();
            }

            resultheaderText = createLabelGlobal(oggettoHeaderTemp.nomeLabelGlobal);
            //console.log(oggettoHeaderTemp.nomeLabelGlobal)
            if (oggettoHeaderTemp.labelGlobal != resultheaderText) {
                oggettoHeaderTemp.labelGlobal = resultheaderText;
                oggettoHeaderTemp.disegnaContatore();
            }
        }
        //end aggiornamento blocco header
        //aggiornamento footer
        var footerIndex = 0;
        var aggiornamento = false;
        //alert("prova")
        for (footerIndex = 0; footerIndex < arrayOggettiFooter.length; footerIndex++) {
            var oggettoFooterTemp = arrayOggettiFooter[footerIndex];
            resultfooterText = getValoreJson(oggettoFooterTemp.labelTimer);
            //console.log("label TimerVal:" + oggettoFooterTemp.labelTimer)
            if (oggettoFooterTemp.labelTimerVal != resultfooterText) {
                oggettoFooterTemp.labelTimerVal = resultfooterText;
                oggettoFooterTemp.updateCanvasTimer();
            }
        }
        if (arrayOggettiFooter.length > 0) {
            timerStringValue = getValoreJson(timerStringID)
            if (timerStringValue != timerStringValuePrec) {
                setInfoTime(timerStringValue);
                timerStringValuePrec = timerStringValue;
                aggiornamento = true;
            }
        }
        for (footerIndex = 0; footerIndex < arrayOggettiFooter.length; footerIndex++) {
            var oggettoFooterTemp = arrayOggettiFooter[footerIndex];
            if (aggiornamento)
                oggettoFooterTemp.updateCanvasTimer();
        }
        
        //labelTimer
        //aggiornamento blocco canale

        var canaleIndex = 0;
        for (canaleIndex = 0; canaleIndex < arrayOggettiCanale.length; canaleIndex++) {
            var oggettoCanaleTemp = arrayOggettiCanale[canaleIndex];
            var resultcanaleValore = 0;
            var resultcanaleValoreStr = "";
            var resultcanaleText = "";
            var allarmeTemp = false;
            var livelloTemp = false;
            var outTemp = false;
            var spanClass = 0;
            //area da modificare sotto al grafico ingressi e uscite
            $(oggettoCanaleTemp.idDivContainerSub).find("li[id*='body_']").each(function () {
                var statusCheck = $(this).attr("id").replace("body_", "");
                var typeVal = $(this).attr("type");

                if ((typeVal == "digital") || (typeVal == "alarm") || (typeVal == "level"))
                    resultcanaleValore = parseFloat(getValoreJson(statusCheck))
                if (typeVal == "proportional") {
                    var tempValue = "";
                    tempValue = getValoreJson(statusCheck);
                    resultcanaleValoreStr = tempValue;
                    tempValue = tempValue.replace("SPM", "");
                    tempValue = tempValue.replace("SPH", "");
                    resultcanaleValore = parseFloat(tempValue);
                    //console.log(statusCheck + ":" + tempValue)
                }
                

                if (resultcanaleValore > 0){
                    var label = createLabelGlobal($(this).attr("label"));
                    
                    if (typeVal == "alarm")allarmeTemp = true;
                    if (typeVal == "level")livelloTemp = true;
                    if ((typeVal == "digital")||(typeVal == "proportional")) outTemp = true;
                    if (typeVal == "proportional")
                        label = label + " " + resultcanaleValoreStr;
                    $(this).text("");
                    $(this).append("<i></i>" + label);
                    $(this).show();
                }
                else
                    $(this).hide();
                
                
            });
            
            

            //console.log($(this).attr("id") + ":ciao" )

            if (allarmeTemp){
                $(oggettoCanaleTemp.idDivContainerSub + "Alarm").css("visibility", "visible");
                $(oggettoCanaleTemp.idDivContainerSub + "Alarm").show();
                spanClass = spanClass + 1;
                
            }
            else{
                $(oggettoCanaleTemp.idDivContainerSub + "Alarm").css("visibility", "hidden");
                $(oggettoCanaleTemp.idDivContainerSub + "Alarm").hide();
                //oggettoCanaleTemp.ad =0;
            }
            if (livelloTemp){
                $(oggettoCanaleTemp.idDivContainerSub + "Level").css("visibility", "visible");
                $(oggettoCanaleTemp.idDivContainerSub + "Level").show();
                spanClass = spanClass + 1;
            }
            else{
                $(oggettoCanaleTemp.idDivContainerSub + "Level").css("visibility", "hidden");
                $(oggettoCanaleTemp.idDivContainerSub + "Level").hide();
                
            }
            if (outTemp){
                $(oggettoCanaleTemp.idDivContainerSub + "Out").css("visibility", "visible");
                $(oggettoCanaleTemp.idDivContainerSub + "Out").show();
                spanClass = spanClass  + 1;
            }
            else{
                $(oggettoCanaleTemp.idDivContainerSub + "Out").css("visibility", "hidden");
                $(oggettoCanaleTemp.idDivContainerSub + "Out").hide();
                
            }
            //console.log("spanclass:" + spanClass)
            if (allarmeTemp){
                oggettoCanaleTemp.ad=1;
            }
            else{
                if (livelloTemp){
                    oggettoCanaleTemp.leval1=1;
                    oggettoCanaleTemp.ad=0;
                }
                else{
                    oggettoCanaleTemp.leval1=0;
                    oggettoCanaleTemp.ad=0;
                }
            }
            if (spanClass == 0)
                spanClass = 12;
            else
                spanClass = 12 / spanClass;

            if (spanClass == 6) spanClass = 5;
            
            //$(oggettoCanaleTemp.idDivContainerSub + "Alarm").removeClass();
            $(oggettoCanaleTemp.idDivContainerSub + "Alarm").removeClass (function (index, className) {
                return (className.match (/\bspan\S+/g) || []).join(' ');
            });
            $(oggettoCanaleTemp.idDivContainerSub + "Alarm").addClass("span" + spanClass.toString());

            $(oggettoCanaleTemp.idDivContainerSub + "Level").removeClass (function (index, className) {
                return (className.match (/\bspan\S+/g) || []).join(' ');
            });
            $(oggettoCanaleTemp.idDivContainerSub + "Level").addClass("span" + spanClass.toString());
            
            $(oggettoCanaleTemp.idDivContainerSub + "Out").removeClass (function (index, className) {
                return (className.match (/\bspan\S+/g) || []).join(' ');
            });
            $(oggettoCanaleTemp.idDivContainerSub + "Out").addClass("span" + spanClass.toString());
            
            //end area da modificare sotto al grafico ingressi e uscite

            //area da modificare sotto al grafico ingressi e uscite
            if (strumentoTouch) {
                resultcanaleValore = parseFloat(getValoreJson(oggettoCanaleTemp.valuePhId));
            }
            else {
                resultcanaleValore = getValoreCurrentJson(getValoreJson(oggettoCanaleTemp.tipoCanaleid), getValoreJson(oggettoCanaleTemp.numeroSondaid), parseFloat(getValoreJson(oggettoCanaleTemp.valuePhId)));
                //console.log("currentValue:"  + parseFloat(getValoreJson(oggettoCanaleTemp.valuePhId)))
            }
            
            if (oggettoCanaleTemp.valuePh != resultcanaleValore) {
                oggettoCanaleTemp.valuePh = resultcanaleValore;
                //console.log(oggettoCanaleTemp.valuePh)
                oggettoCanaleTemp.updateCanale = true
            }
            if (strumentoTouch) {
                //console.log(oggettoCanaleTemp.labelpHId)
                resultcanaleText = (createLabelGlobal(oggettoCanaleTemp.labelpHId));
                //console.log(resultcanaleText + ":" + oggettoCanaleTemp.labelpHId)
            }
            else {
                //alert("arrivo:" + strumentoTouch)
                resultcanaleText = getValoreLabelJson(getValoreJson(oggettoCanaleTemp.tipoCanaleid), getValoreJson(oggettoCanaleTemp.numeroSondaid));
            }
            if (oggettoCanaleTemp.valuePh != resultcanaleText) {
                oggettoCanaleTemp.labelpH = resultcanaleText;
                oggettoCanaleTemp.updateCanale = true
            }
            //alert("arrivo:" + strumentoTouch)


          /*  this.factorDivideID = factorDivideID;
            this.factorDivide = 1;
            this.factorMinID = minscaleId;
            this.factorMin = 0;*/
            //factor divide
            /*if (strumentoTouch) {
                resultcanaleValore = parseFloat(getValoreJson(oggettoCanaleTemp.factorDivideID));
                console.log("divide:" + oggettoCanaleTemp.factorDivideID)
                if (oggettoCanaleTemp.factorDivide != resultcanaleValore) {
                    oggettoCanaleTemp.factorDivide = resultcanaleValore;
                    oggettoCanaleTemp.updateCanale = true
                }
            }*/
            //factor MINIMO
            if (strumentoTouch) {
                resultcanaleValore = parseFloat(getValoreJson(oggettoCanaleTemp.factorMinID));
                //console.log("minimo:" + resultcanaleValore)
                if (oggettoCanaleTemp.factorMin != resultcanaleValore) {
                    oggettoCanaleTemp.factorMin = resultcanaleValore;
                    oggettoCanaleTemp.updateCanale = true
                }
            }




            if (strumentoTouch) {
                resultcanaleValore = parseFloat(getValoreJson(oggettoCanaleTemp.fullscaleId));
            }
            else {
                //alert("arrivo:" + strumentoTouch)
                resultcanaleValore = getValoreFullScaleJson(getValoreJson(oggettoCanaleTemp.tipoCanaleid), getValoreJson(oggettoCanaleTemp.numeroSondaid));
                
            }
            if (oggettoCanaleTemp.fullscale != resultcanaleValore) {
                oggettoCanaleTemp.fullscale = resultcanaleValore;
                oggettoCanaleTemp.updateCanale = true
            }
            if (oggettoCanaleTemp.factorMin > oggettoCanaleTemp.fullscale) { //nel caso in cui il minimo è maggiore del massimo li inverto
                var minTemporaneo = oggettoCanaleTemp.factorMin;
                oggettoCanaleTemp.factorMin = oggettoCanaleTemp.fullscale;
                oggettoCanaleTemp.fullscale = minTemporaneo;
            }

            //oggettoCanaleTemp.initSetpoint(parseInt(getValoreJson(oggettoCanaleTemp.idDigitalID1)), parseInt(getValoreJson(oggettoCanaleTemp.idDigitalSp1ID1)), parseInt(getValoreJson(oggettoCanaleTemp.idDigitalSp21)));
            oggettoCanaleTemp.idDigitalSpLabel1 = createLabelGlobal(oggettoCanaleTemp.idDigitalSpLabelID1);
            if (oggettoCanaleTemp.idDigitalID1 != ""){
                if (oggettoCanaleTemp.idDigitalSp2ID1.indexOf("deadband") > 0) {// caso del dead band
                    oggettoCanaleTemp.initSetpoint(parseInt(getValoreJson(oggettoCanaleTemp.idDigitalID1)), parseFloat(getValoreJson(oggettoCanaleTemp.idDigitalSp1ID1)), parseFloat(getValoreJson(oggettoCanaleTemp.idDigitalSp2ID1)), 1, true, getValoreJson(oggettoCanaleTemp.idDigitalVal1));
                }
                else {
                    oggettoCanaleTemp.initSetpoint(parseInt(getValoreJson(oggettoCanaleTemp.idDigitalID1)), parseFloat(getValoreJson(oggettoCanaleTemp.idDigitalSp1ID1)), parseFloat(getValoreJson(oggettoCanaleTemp.idDigitalSp2ID1)), 1, false, getValoreJson(oggettoCanaleTemp.idDigitalVal1));
                }
            }
            oggettoCanaleTemp.idDigitalSpLabel2 = createLabelGlobal(oggettoCanaleTemp.idDigitalSpLabelID2);
            if (oggettoCanaleTemp.idDigitalID2 != "") {
                //console.log("setpoint:" + oggettoCanaleTemp.idDigitalSp2ID2 + ":" + parseFloat(getValoreJson(oggettoCanaleTemp.idDigitalID2)))
                    oggettoCanaleTemp.initSetpoint(parseInt(getValoreJson(oggettoCanaleTemp.idDigitalID2)), parseFloat(getValoreJson(oggettoCanaleTemp.idDigitalSp1ID2)), parseFloat(getValoreJson(oggettoCanaleTemp.idDigitalSp2ID2)), 2, false, getValoreJson(oggettoCanaleTemp.idDigitalVal2));
                }
            //gestione degli allarmi
            oggettoCanaleTemp.minAlarmpHLabel = createLabelGlobal(oggettoCanaleTemp.minAlarmpHLabelID);
            resultcanaleValore = parseInt(getValoreJson(oggettoCanaleTemp.minAlarmpHEnID));
            if (resultcanaleValore > 0){//canale abilitato
                oggettoCanaleTemp.minAlarmpH = parseFloat(getValoreJson(oggettoCanaleTemp.minAlarmpHID))
                //this.minAlarmpH = parseFloat(getValoreJson(oggettoCanaleTemp.minAlarmpHID))
            }
            else{
                oggettoCanaleTemp.minAlarmpH =0;
                oggettoCanaleTemp.minAlarmpHEn = 0;
            }
            oggettoCanaleTemp.maxAlarmpHLabel = createLabelGlobal(oggettoCanaleTemp.maxAlarmpHLabelID);
            resultcanaleValore = parseInt(getValoreJson(oggettoCanaleTemp.maxAlarmpHEnID));
            if (resultcanaleValore > 0){//canale abilitato
                oggettoCanaleTemp.maxAlarmpH = parseFloat(getValoreJson(oggettoCanaleTemp.maxAlarmpHID))
                //this.minAlarmpH = parseFloat(getValoreJson(oggettoCanaleTemp.minAlarmpHID))
            }
            else{
                oggettoCanaleTemp.maxAlarmpH =0;
                oggettoCanaleTemp.maxAlarmpHEn = 0;
            }
            

            if (oggettoCanaleTemp.updateCanale) {
                oggettoCanaleTemp.updateCanale = false;
                oggettoCanaleTemp.initCanvas();
            }
        }
        
        //end aggiornamento blocco canale
    }
    
    if (jsonParse.errore == "invalidSerial") {
        
        $("#notConnectedMain").show();
    }
    
}
function aggiornamentoListaOptoInputRelay(){
//aggiornamento lista setpoint relay opto input
                    $("[typeoflist*='opto']").each(function () {
                        var idSelectTemp = $(this).attr("id");
                        var sizeTempOption = $("#" + idSelectTemp + " option").size();
                        for (i = 1; i < sizeTempOption; i++) {
                            if ((arrayOpto[i] != 0) && (i != $(this).val())) {
                                //$("#" + idSelectTemp + " option[value='" + i.toString() + "']").hide();
                                $("#" + idSelectTemp + " option[value='" + i.toString() + "']").attr('disabled', '');
                            }
                            else {
                                //$("#" + idSelectTemp + " option[value='" + i.toString() + "']").show();
                                $("#" + idSelectTemp + " option[value='" + i.toString() + "']").removeAttr('disabled');
                            }
                        }
                        //console.log("opto:" + $("#" + idSelectTemp + " option").size());

                        //console.log("opto:" + $(this).val());

                    });
                    $("[typeoflist*='relay']").each(function () {
                        var idSelectTemp = $(this).attr("id");
                        var sizeTempOption = $("#" + idSelectTemp + " option").size();
                        for (i = 1; i < sizeTempOption; i++) {
                            if ((arrayRelay[i] != 0) && (i != $(this).val())) {
                                //$("#" + idSelectTemp + " option[value='" + i.toString() + "']").hide();
                                $("#" + idSelectTemp + " option[value='" + i.toString() + "']").attr('disabled', '');
                            }
                            else {
                                //$("#" + idSelectTemp + " option[value='" + i.toString() + "']").show();
                                $("#" + idSelectTemp + " option[value='" + i.toString() + "']").removeAttr('disabled');
                            }
                        }
                        //console.log("opto:" + $("#" + idSelectTemp + " option").size());

                        //console.log("opto:" + $(this).val());

                    });
                    $("[typeoflist*='input']").each(function () {
                        var idSelectTemp = $(this).attr("id");
                        var sizeTempOption = $("#" + idSelectTemp + " option").size();
                        for (i = 1; i < sizeTempOption; i++) {
                            if ((arrayInput[i] != 0) && (i != $(this).val())) {
                                //$("#" + idSelectTemp + " option[value='" + i.toString() + "']").hide();
                                $("#" + idSelectTemp + " option[value='" + i.toString() + "']").attr('disabled', '');
                            }
                            else {
                                //$("#" + idSelectTemp + " option[value='" + i.toString() + "']").show();
                                $("#" + idSelectTemp + " option[value='" + i.toString() + "']").removeAttr('disabled');
                            }
                        }
                        //console.log("opto:" + $("#" + idSelectTemp + " option").size());

                        //console.log("opto:" + $(this).val());

                    });
}
function createMisura(stringaMisura){
    if (stringaMisura.indexOf("]") >=0){
        var stringDef = stringaMisura.replace("*", "");
        stringDef = stringDef.replace(" ", "");
        // console.log(stringDef)
        /*DA MODIFICARE PER LE UNITà DI MISIRA*/
        
        if (stringDef == "[probeCh1]")
            return createLabelGlobal("ch1unitEuR")
        if (stringDef == "[probeCh2]")
            return createLabelGlobal("ch2unitEuR")
        if (stringDef == "[probeCh3]")
            return createLabelGlobal("ch3unitEuR")
        if (stringDef == "[probeCh4]")
            return createLabelGlobal("ch4unitEuR")
        if (stringDef == "[probeCh5]")
            return createLabelGlobal("ch5unitEuR")
        if (stringDef == "[probeCh6]")
            return createLabelGlobal("ch6unitEuR")
        if (stringDef == "[probeCh7]")
            return createLabelGlobal("ch7unitEuR")
        if (stringDef == "[probeCh8]")
            return createLabelGlobal("ch8unitEuR")
        if (stringDef == "[probeCh9]")
            return createLabelGlobal("ch9unitEuR")

        if (stringDef == "[ch1tempR]")
            return  sistemaUSA == "0" ? "°C" : "°F"
        if (stringDef == "[ch2tempR]")
            return sistemaUSA == "0" ? "°C" : "°F"
        if (stringDef == "[ch3tempR]")
            return sistemaUSA == "0" ? "°C" : "°F"
        if (stringDef == "[ch4tempR]")
            return sistemaUSA == "0" ? "°C" : "°F"
        if (stringDef == "[ch5tempR]")
            return sistemaUSA == "0" ? "°C" : "°F"
        if (stringDef == "[ch6tempR]")
            return sistemaUSA == "0" ? "°C" : "°F"

        if (stringDef == "[watermeter1R]")
            return sistemaUSA == "0" ? "m3" : "gal"
        if (stringDef == "[watermeter2R]")
            return sistemaUSA == "0" ? "m3" : "gal"

        if (stringDef == "[watermeter1lhR]")
            return sistemaUSA == "0" ? "m3/h" : "gal/h"
        if (stringDef == "[watermeter2lhR]")
            return sistemaUSA == "0" ? "m3/h" : "gal/h"
        return "";
    }
    else
        return stringaMisura
}
function preparaTimeR(id, valore) {
    var dt = new Date();
    //console.log(dt.getHours().toString())
    $(id).val(dt.getHours().toString() + ":" + dt.getMinutes().toString())

}
function preparaTimeS(id, valore) {
    var splitValue = valore.split(",");
    if (splitValue.length > 0) {
        $(id).val(splitValue[0] + ":" + splitValue[1])
    }

}
function listWeekDetails(giornoSettimana,hr, min, thr, tmin)
{
    var i=0;

    var htmllistWeekDetails = "";
    htmllistWeekDetails = htmllistWeekDetails + "<div Class=\"row-fluid\">"
    htmllistWeekDetails = htmllistWeekDetails + "<div Class=\"span2\">"
    htmllistWeekDetails = htmllistWeekDetails + "<h5>"+giornoSettimana+"</h5>"
    htmllistWeekDetails = htmllistWeekDetails + "</div>"
    htmllistWeekDetails = htmllistWeekDetails + "<div Class=\"span2\">"
    htmllistWeekDetails = htmllistWeekDetails + "<h5>Start Time</h5>"
    if (thr.toString().length < 2)
        thr = "0" + thr;
    if (tmin.toString().length < 2)
        tmin = "0" + tmin;
    //console.log("valore scriver:" + thr + ":" + tmin)

    htmllistWeekDetails = htmllistWeekDetails + "<input action=\"setpoint\" id=\"weekItemTenSub\"  type = \"text\" value=\"" + thr + ":" + tmin + "\"></input>"
    htmllistWeekDetails = htmllistWeekDetails + "</div>"
    htmllistWeekDetails = htmllistWeekDetails + "</div>"

    htmllistWeekDetails = htmllistWeekDetails + "<div Class=\"row-fluid\" >"
    htmllistWeekDetails = htmllistWeekDetails + "<div Class=\"span2\" >"
    htmllistWeekDetails = htmllistWeekDetails + "</div>"
    htmllistWeekDetails = htmllistWeekDetails + "<div Class=\"span2\" style=\"width:150px\">"
    htmllistWeekDetails = htmllistWeekDetails + "<h5>Feed Hr</h5>"
    htmllistWeekDetails = htmllistWeekDetails + "<select id=\"weekItemTenSubHr\" style=\"width:150px\">"
    for (i = 0; i <= 99; i++) {
        if (i == parseInt(hr))
            htmllistWeekDetails = htmllistWeekDetails + "<Option value=\"" + i.toString() + "\" selected>" + i.toString() + "</Option>"
        else
            htmllistWeekDetails = htmllistWeekDetails + "<Option value=\"" + i.toString() + "\" >" + i.toString() + "</Option>"
    }
    htmllistWeekDetails = htmllistWeekDetails + "</select >"

    htmllistWeekDetails = htmllistWeekDetails + "</div>"

    htmllistWeekDetails = htmllistWeekDetails + "<div Class=\"span2\" style=\"width:150px\">"
    htmllistWeekDetails = htmllistWeekDetails + "<h5>Feed Min</h5>"
    htmllistWeekDetails = htmllistWeekDetails + "<select id=\"weekItemTenSubMin\" style=\"width:150px\">"
    for (i = 0; i <= 99; i++) {
        if (i == parseInt(min))
            htmllistWeekDetails = htmllistWeekDetails + "<Option value=\"" + i.toString() + "\" selected>" + i.toString() + "</Option>"
        else
            htmllistWeekDetails = htmllistWeekDetails + "<Option value=\"" + i.toString() + "\" >" + i.toString() + "</Option>"
    }
    htmllistWeekDetails = htmllistWeekDetails + "</select >"
    htmllistWeekDetails = htmllistWeekDetails + "</div>"
    htmllistWeekDetails = htmllistWeekDetails + "</div>"

    return htmllistWeekDetails
}
function preparaWeek(id, valore,giornoSettimanaNew)
{
    var splitValue = valore.split("|");
    var i = 0;
    
    for (i = 0; i < splitValue.length; i++) {
        //console.log( id + "_" + i.toString() + "_x")
        //var typeId = $(id + "_" + i.toString() + "_x").attr("id"); // serve per la gestione del week al biocide
        var typeId = $(id + "_" + i.toString()).attr("id"); // serve per la gestione del week al biocide
        var giornoSettimana = $(id + "_" + i.toString() ).attr("dayofweek");
        
       // console.log("ariciao:" + typeId + "," + id + "," +i.toString()+","+valore)
        if (typeId != undefined) {// caso delle 10 programmazioni giornaliere
            var htmlWeek = ""//ricostruisco lunedi
            //var giornoSettimana = $(id + "_" + i.toString() + "_x").html();
            var weekTenDay = splitValue[i].split("?");
            var indexTemp = 0;
            htmlWeek = "<div class=\"span1  biocide_day\" id=\"" + id + "_" + i.toString() + "_x" + "\">" + giornoSettimana + "</div>"//ricostruisco lunedi
                giornoSettimanaNew = $(id + "_" + i.toString() + "_x").html();
            //console.log(giornoSettimanaNew)
            weekTenDay.forEach(function (item, index) {
                var weekTenDayItem = item.split(",");
                if ((parseInt(weekTenDayItem[0]) > 0) || (parseInt(weekTenDayItem[1]) > 0) || (parseInt(weekTenDayItem[2]) > 0) || (parseInt(weekTenDayItem[3]) > 0)) {
                    htmlWeek = htmlWeek + "<a type=\"weekItem\" onclick=\"return functionWeekItem(" + indexTemp + "," + i + ",'" + valore + "','" + id + "','" + giornoSettimana + "'," + weekTenDayItem[2] + "," + weekTenDayItem[3] + "," + weekTenDayItem[0] + "," + weekTenDayItem[1] + ");\" href = \"#\"><div class=\"span1 biocide\" style=\"margin-left:10px;color:black\">" + weekTenDayItem[2] + "h " + weekTenDayItem[3] + "m <br>" + weekTenDayItem[0] + ":" + weekTenDayItem[1] + "</div></a>"
                    indexTemp++;
                }
                
            });
            if (indexTemp < 10)
                htmlWeek = htmlWeek + "<a type=\"weekItemPiu\" href = \"#\" onclick=\"return functionWeekItem(" + indexTemp + "," + i + ",'" + valore + "','" + id + "','" + giornoSettimana + "','0','0','0','0');\"><div class=\"span1 biocide biocide_PLUS\" style=\"margin-left:10px;\" >\+</div>"
                //htmlWeek = htmlWeek + "<a  href = \"#\">\+</a>"

            //$(id + "_" + i.toString() + "_x").replaceWith(htmlWeek)
            $(id + "_" + i.toString() ).html(htmlWeek)
            
            //truncInfo($(id + "_" + i.toString() + "_x"));
            

        }
            else{
                if (splitValue[i].length > 0) {
                    var splitValueSub = splitValue[i].split(",");
                    var idTemp = "";
                    idTemp = id + "_time_" + i.toString();
                    $(idTemp).val(splitValueSub[0] + ":" + splitValueSub[1])
                    //console.log("week:" + idTemp)
                    //biocide_biocide1_week1_time_time_0
                }
            }
    }
}
function createLabelGlobal(idLabelTemp)
{

    if (idLabelTemp.indexOf("]") >=0){// devo andare a pescare la label nelle global
        try{
            
            for (var key in jsonParseLabel) {
                idLabelTemp = idLabelTemp.replace("[","")
                idLabelTemp = idLabelTemp.replace("]", "")
                
                if (idLabelTemp == key)
                {
                    //console.log("labelLog:" + jsonParseLabel[key])
                    return jsonParseLabel[key];
                }
            }
        }
        catch (ex) {
        }
    }
    else {
        
        return getValoreJson(idLabelTemp);
    }
    return "";
}
function parseBoolean(valorBoolean)
{
    if (valorBoolean == 'true') return 1;
    if (valorBoolean == 'false') return 0;
    return 0;
}
function getValoreJson(labelJson) {
    var k = 0;
    for (k = 0; k < jsonParse.variable.length; k++) {
        try {
            //console.log(jsonParse.variable[k]["chiave"] + ":" + jsonParse.variable[k]["valore"])
            if (jsonParse.variable[k]["chiave"] == labelJson){
                if (jsonParse.variable[k]["valore"] == 'true') return 1;
                if (jsonParse.variable[k]["valore"] == 'false') return 0;
                return jsonParse.variable[k]["valore"];
            }
        }
            catch (ex) {
            }
    }
    return "";
}
function calcolaMinimoMassimo(oggetto, attributi)
{
    var oggettoFinal = attributi.replace("[", "");
    //console.log("oggettofinal:" + attributi)
    oggettoFinal = oggettoFinal.replace("]", "");
    var k = 0;
    
    for (k = 0; k < jsonParse.variable.length; k++) {
        if (jsonParse.variable[k]["chiave"].indexOf(oggettoFinal+"dec") >= 0) {//caso numero decimali
            $(oggetto).attr("decimali", jsonParse.variable[k]["valore"]);
        }
        if (jsonParse.variable[k]["chiave"].indexOf(oggettoFinal + "min") >= 0) {//caso minimo
            $(oggetto).attr("min", jsonParse.variable[k]["valore"]);
        }
        if (jsonParse.variable[k]["chiave"].indexOf(oggettoFinal + "max") >= 0) {//caso massimo
            $(oggetto).attr("max", jsonParse.variable[k]["valore"]);
        }

    }
}


    
function get_data(serialNumber, firstValue) {

    if (firstValue){
        readCookie(serialNumber);
        bootbox.dialog();
        //bootbox.dialog("<div class = \"widget\"><div class=\"widget-head\" style=\"text-align:center\"><h4 id = \"spinnerLoadText\" class=\"heading\" >Loading .. </h4></div><div id = \"spinnerLoad\" class=\"widget-body\"><script type=\"text/javascript\">carica_spinner('spinnerLoad');</script></div></div>");
        bootbox.dialog("<img src=\"theme/images/loading.gif\">");

        $("#spinnerLoadText" ).text("Loading ..");

    }

    $.ajax({
        type: "POST",
        url: "Centurio/centurioReal.aspx/getAllData",
        //data: {check1: $("#rms_all").is(':checked') ,check1_1: $("#rms_medio").is(':checked'),  check1_2:  $("#rms_max").is(':checked') ,check2 : $("#picco_all").is(':checked') , check2_1 : $("#picco_medio").is(':checked') , check2_2 : $("#picco_max").is(':checked') , check3: $("#vm_rms_all").is(':checked') , check3_1: $("#vm_rms_medio").is(':checked') , check3_2 : $("#vm_rms_max").is(':checked') , check4 : $("#vm_picco_all").is(':checked') , check4_1 : $("#vm_picco_medio").is(':checked') , check4_2: $("#vm_picco_max").is(':checked')   },
        //data: { check1: false, check1_1: true, check1_2: false, check2: false, check2_1: true, check2_2: false, check3: false, check3_1:true, check3_2:false, check4: false, check4_1:true, check4_2:false },
        data: "{'serialNumber':'" + JSON.stringify(serialNumber) + "'}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        //timeout: 6000, //3 second timeout
        success: function (response) {

            valoriAggiornati = true;
            //alert(response.d)
            //console.log(response.d)
            updateValori(response, firstValue);
            if (firstValue){
                stop_spinner()
                bootbox.hideAll();
            }

        },
        failure: function (response) {
            alert(response.d);
        }

    });

}

//------------------------------BLOCCO HEAD --------------------------

function headerCanvas(idCanvas, nomeVariabile, nomeFlow, nomeAllarme, idLabelTot, idAlertFlow, idAlarmFlow)
{
    this.nomeValriabileGlobal = nomeVariabile;
    this.nomeFlowGlobal = nomeFlow;
    this.nomeAlalrmeGlobal = nomeAllarme;
    this.nomeLabelGlobal = idLabelTot;
    
    this.nomeAlertFlow = idAlertFlow;
    this.nomeAlarmFlow = idAlarmFlow;

    this.$myCanvas = $(idCanvas);
    this.portataGlobal = 0;
    this.totalizzatoreGlobal = 1;
    this.allarmeGlobal = 0;
    this.labelGlobal = "";
    this.idCanvasGlobal = idCanvas.replace("#", "");
    this.coloreGlobal = "#a4c408";
    this.coloreGlobalText = "black";
    
    this.flowMeterValue = 0;

    this.alertFlowValue = 0;
    this.alarmFlowValue = 0;

   
    //-----------------------------------------------------------------------------------------------------------------------
    // disegana cifrea
    this.disegnaCifraWM =function(xstart, ystart, numero) {
        var numeroString = numero.toString();
        var i = 0;
        var widthFont = 16;
        var heightFont = 22;
        var ystartFont = ystart;
        var punto = false;
        var offset = 2;

        
        for (i = 0; i < numeroString.length; i++) {
            offset = 2;

            if ((numeroString.substr(i, 1) == ".") || ((numeroString.substr(i, 1) == ","))) {
                widthFont = 9;
                heightFont = 9;
                ystartFont = ystart  + 5;
                
            }
            else {
                widthFont = 16;
                heightFont = 22;
                ystartFont = ystart-7;
            }

            this.$myCanvas
                    .addLayer({
                        type: 'rectangle',
                        name: 'cifra' + this.idCanvasGlobal + i.toString(),
                        fromCenter: false,
                        strokeStyle: 'white',
                        fillStyle: this.coloreGlobal,
                        strokeWidth: 2,
                        x: punto ? xstart + (i * 15) : xstart + (i * 16), y: ystartFont,
                        width: widthFont,
                        height: heightFont,
                    })
                    .drawLayers();
            if ((numeroString.substr(i, 1) != ".") && ((numeroString.substr(i, 1) != ","))) {
             /*   this.$myCanvas
							.addLayer({
							    type: 'rectangle',
							    name: 'cifraCentral' + i.toString(),
							    fromCenter: false,
							    strokeStyle: 'white',
							    fillStyle: 'white',
							    strokeWidth: 0,
							    x: this.$myCanvas.getLayer('cifra' + i.toString()).x,
							    y: this.$myCanvas.getLayer('cifra' + i.toString()).y + (this.$myCanvas.getLayer('cifra' + i.toString()).height / 2),
							    width: this.$myCanvas.getLayer('cifra' + i.toString()).width,
							    height: this.$myCanvas.getLayer('cifra' + i.toString()).height / 12,
							})
							.drawLayers();*/
                offset = 2;
                //punto = false;
            }
            else {
                offset = -11;
               
                punto = true;
            }
            this.$myCanvas
                        .addLayer({
                            type: 'text',
                            name: 'Text' + this.idCanvasGlobal + i.toString(),
                            fillStyle: 'white',
                            fromCenter: false,

                            fontSize: '14pt',
                            fontFamily: 'Open Sans, sans-serif',
                            //x: xLayer/*+((testo.length *  fontSize))*/, y: yLayer + (0 ) + 3,
                            x: this.$myCanvas.getLayer("cifra" + this.idCanvasGlobal + i.toString()).x + 2, y: this.$myCanvas.getLayer("cifra" + this.idCanvasGlobal + i.toString()).y + offset,
                            maxWidth: this.$myCanvas.getLayer("cifra" + this.idCanvasGlobal + i.toString()).width,
                            align: 'center',
                            text: numeroString.substr(i, 1)
                        })
                        .drawLayers();

        }

        //console.log(numeroString)
        this.$myCanvas
                    .addLayer({
                        type: 'text',
                        name: 'header' + this.idCanvasGlobal,
                        fillStyle: 'black',
                        fromCenter: false,

                        fontSize: '12pt',
                        fontFamily: 'Open Sans, sans-serif',
                        fontStyle: 'normal',
                        //x: xLayer/*+((testo.length *  fontSize))*/, y: yLayer + (0 ) + 3,
                        x: xstart, y: ystart - heightFont-2,
                        
                        align: 'center',
                        text: this.labelGlobal + (sistemaUSA == "0" ? " m3" : " gal") 
                    })
                    .drawLayers();

    }
    //----------------------------------------------------
    //end disegana cifrea
    this.disegnaContatore = function () {
        var xArcSetting = parseInt(this.$myCanvas.attr("width")) / 2;
        var radiusT = 75;
        var yArcSetting = 78;
        if (this.alertFlowValue) {
            this.coloreGlobalText = "#FFD35A"
            this.coloreGlobal = "#FFD35A";
        }
        else{
            this.coloreGlobalText = "black"
            this.coloreGlobal = "#a4c408";
        }

        if (this.allarmeGlobal) {
            this.coloreGlobal = "red";
            this.coloreGlobalText = "red";
        }
        else
            this.coloreGlobal = "#a4c408";
        this.$myCanvas.clearCanvas();
        this.$myCanvas.removeLayers();

        if (this.nomeFlowGlobal != "") {//caso di visualizzazione di solo totaloizzatore
            this.$myCanvas/*.drawArc({
                strokeStyle: '#cccccc',
                strokeWidth: 3,
                layer: true,
                x: xArcSetting, y: yArcSetting,
                fillStyle: '#cccccc',
                radius: radiusT,
                // start and end angles in degrees
                start: -90, end: 90
            })
            .drawSlice({
                strokeStyle: '#cccccc',
                layer: true,
                strokeWidth: 0,
                x: xArcSetting, y: yArcSetting,
                fillStyle: this.coloreGlobal,
                radius: radiusT,
                closed: true,
                //ccw: true,
                // start and end angles in degrees
                start: -90, end: 60
            })
            .drawArc({
                strokeStyle: '#cccccc',
                layer: true,
                strokeWidth: 2,
                x: xArcSetting, y: yArcSetting,
                radius: radiusT - 10,
                fillStyle: 'white',
                // start and end angles in degrees
                start: -90, end: 90
            })*/
            .drawText({
                layer: true,
                fillStyle: this.coloreGlobalText,
                fromCenter: false,
                fontSize: '12pt',
                fontFamily: 'Open Sans, sans-serif',
                //x: xArcSetting - radiusT / 2 + 2, y: yArcSetting - (50),
                x: xArcSetting - radiusT, y: yArcSetting - (50),
                fontStyle: 'normal',
                maxWidth: 120,
                align: 'center',
                text: this.labelGlobal + (sistemaUSA == "0" ? " m3/h" : " gal/h") 
            })
            .drawText({
                layer: true,
                fillStyle: this.coloreGlobalText,
                fromCenter: false,
                fontSize: '12pt',
                fontFamily: 'Open Sans, sans-serif',
                //x: xArcSetting - radiusT / 2 + 2, y: yArcSetting - 25,
                x: xArcSetting - radiusT, y: yArcSetting - 25,
                fontStyle: 'normal',
                maxWidth: 90,
                align: 'center',
                text: this.flowMeterValue
            });

            /*this.$myCanvas
                    .addLayer({
                        type: 'text',
                        name: 'name3' + this.idCanvasGlobal,
                        fillStyle: 'black',
                        fromCenter: false,
                        fontSize: '8pt',
                        fontFamily: 'Open Sans, sans-serif',
                        fontStyle: 'normal',
                        x: xArcSetting - radiusT, y: yArcSetting + 3,
                        maxWidth: 10,
                        align: 'center',
                        text: '0'
                    })
                    .addLayer({
                        type: 'text',
                        name: 'name4' + this.idCanvasGlobal,
                        fillStyle: 'black',
                        fromCenter: false,
                        fontSize: '8pt',
                        fontFamily: 'Open Sans, sans-serif',
                        fontStyle: 'normal',
                        x: xArcSetting + radiusT - 10, y: yArcSetting + 2,
                        maxWidth: 30,
                        align: 'center',
                        text: '300'
                    })
                    .drawLayers();*/
        }
        else {
            yArcSetting = (parseInt(this.$myCanvas.attr("height")) / 2) - 40;
           // alert(yArcSetting)
        }

        

        this.disegnaCifraWM(xArcSetting - radiusT, yArcSetting + 40, this.totalizzatoreGlobal);
    }

    
    
}


//------------------------------END BLOCCO HEAD --------------------------

//----------------------------BLOCCO BODY -----------------------------------
//function CanvasNew(idCanvas, idDiv, labelCanale, valueCanale, fullScaleValue, factorDivideValue, minValueAlarm, maxValueAlarm, riga1Enable, riga1Min, riga1Max, riga2Enable, riga2Min, riga2Max, riga3Enable, riga3Min, riga3Max, riga4Enable, riga4Min, riga4Max, da, db, pa, pb, level1, level2, level3, level4, ad, ar) {
//new CanvasNew('#bodyCanvas" + numeroHeader.ToString + "','#canale" + numeroHeader.ToString + "','#bodyCanvasSub" + numeroHeader.ToString + "','" + idGrandezza + "','" + idProbe + "','" + idMassimo + "','" + idMinimo + "','0'," + idDigital + "," + idDigitalspEn + "," + idDigitalsp1 + "," + idDigitalsp2 + "," + idDigitalLabel + "," + idAlarmEn + "," + idAlarmVal + "," + idAlarmLabel + "," + strumentoTouch.ToString + ",'" + tipoCanale + "','" + numeroSonda + "');"
function CanvasNew(idCanvas, idDiv, idDivSub, labelpHId, valuePhId, fullscaleId, minscaleId, factorDivideID, idDigital1Val, idDigital2Val, idDigital3Val, idDigital4Val, idDigital1, idDigital2, idDigital3, idDigital4, idDigitalSp11, idDigitalSp12, idDigitalSp13, idDigitalSp14, idDigitalSp21, idDigitalSp22, idDigitalSp23, idDigitalSp24, idDigitalSpL1, idDigitalSpL2, idDigitalSpL3, idDigitalSpL4, idMinAlarmEn, idMaxAlarmEn, idMinAlarm, idMaxAlarm, idMinAlarmLabel, idMaxAlarmLabel,strumentoType,tipoCanale,numeroSonda) {

    var indiceCancvas = 0;

    if (strumentoType == 1)
        strumentoTouch = true
    else
        strumentoTouch = false

    

    this.$myCanvasBody = $(idCanvas);
    this.idDivContainer = idDiv;
    this.idDivContainerSub = idDivSub;
    this.updateCanale = false;

    this.fullscale = 14;
    this.valuePh = 7.60;
    //tipoCanale,numeroSonda
    this.tipoCanaleid = tipoCanale;
    this.numeroSondaid = numeroSonda;
    //console.log("partenza:" + this.tipoCanaleid + this.numeroSondaid)
    //nel caso di strumento non touch devo recuperare le info dal file xml probe List
    //if (strumentoTouch) {
    //    for (indiceCancvas = 0; indiceCancvas < jsonParseDecimal.variable.length; indiceCancvas++) {
    //        if ((jsonParseDecimal.variable[indiceCancvas]["tipoCanale"] == tipoCanale) && (jsonParseDecimal.variable[indiceCancvas]["numeroSonda"] == numeroSonda)) {
    //            this.fullscaleId = jsonParseDecimal.variable[indiceCancvas]["massimo"];
    //            this.factorDivideID = numeroDecimali(jsonParseDecimal.variable[indiceCancvas]["decimali"]);
    //            valoreCaloclato = valoreCaloclato.toFixed(decimaliInt);
    //            this.valuePhId = valuePhId;
    //        }
    //    }
    //}
    //else {

        this.fullscaleId = fullscaleId
        if (factorDivideID == "0") { //caso centurio non c'è factor divide
            this.factorDivide = 1;
        }
        this.factorDivideID = factorDivideID;
        this.factorDivide = 1;
        this.factorMinID = minscaleId;
        this.factorMin = 0;

        this.valuePhId = valuePhId;
   // }



    //this.fullscale = fullScaleValue;

    //this.factorDivide = factorDivideValue;
    

    // this.valuePh = valueCanale;
    
    
    //alert("ciao:")
    //this.labelpH = labelCanale
    this.labelpH = "pH"
    this.labelpHId = labelpHId;
    //console.log(labelpHId)
    this.heightGlobal = 20;
    //this.minAlarmpH = minValueAlarm;
    this.minAlarmpHID =idMinAlarm
    this.minAlarmpH = 30;
    this.minAlarmpHLabelID = idMinAlarmLabel;
    this.minAlarmpHLabel = "";
    this.minAlarmpHEnID =idMinAlarmEn
    this.minAlarmpHEn = 0;

    this.maxAlarmpHID =idMaxAlarm
    this.maxAlarmpH = 90;
    this.maxAlarmpHLabelID = idMaxAlarmLabel;

    this.maxAlarmpHLabel = "";
    this.maxAlarmpHEnID =idMaxAlarmEn
    this.maxAlarmpHEn = 0;

    //console.log("alarmMax:" + this.maxAlarmpHEnID)

    this.idDigitalVal1 = idDigital1Val;
    
    this.da = "";
    this.idDigitalID1 = idDigital1;
    this.enableRiga1 = 0;
    this.idDigitalSp1ID1 = idDigitalSp11;
    this.minSetpoint1 = 0;
    this.idDigitalSp2ID1 = idDigitalSp21;
    this.maxSetpoint1 = 0;
    this.idDigitalSpLabelID1 = idDigitalSpL1;
    this.idDigitalSpLabel1 = ""

    this.idDigitalVal2 = idDigital2Val;
    this.idDigitalID2 = idDigital2;
    //this.idDigitalID2 = "";
    this.enableRiga2 = 0;
    this.idDigitalSp1ID2 = idDigitalSp12;
    this.minSetpoint2 = 0;
    this.idDigitalSp2ID2 = idDigitalSp22;
    this.maxSetpoint2 = 0;
    this.idDigitalSpLabelID2 = idDigitalSpL2;
    this.idDigitalSpLabel2 = ""

    this.idDigitalSpLabel3 = ""
    this.idDigitalSpLabel4 = ""
    //this.enableRiga1 = riga1Enable;
    

    //this.minSetpoint1 = riga1Min;
    
    //this.maxSetpoint1 = riga1Max;
    
    //this.leval1 = level1;
    this.leval1 = 0;

    //this.minSetpoint2 = riga2Min;
    this.minSetpoint2 = 0;
    //this.maxSetpoint2 = riga2Max;
    this.maxSetpoint2 = 0;
    //this.leval2 = level2;
    this.leval2 = 0;
    //this.minSetpoint3 = riga3Min;
    this.minSetpoint3 = 0;
    //this.maxSetpoint3 = riga3Max;
    this.maxSetpoint3 = 0;
    //this.leval3 = level3;
    this.leval3 = 0;
    //this.minSetpoint4 = riga4Min;
    this.minSetpoint4 = 0;
    //this.maxSetpoint4 = riga4Max;
    this.maxSetpoint4 = 0;
    //this.leval4 = level4;
    this.leval4 = 0;
    //this.ad = ad;
    this.ad = 0;
    //this.ar = ar;
    this.ar = 0;

    
    this.db = "";
    this.pa = "";
    this.pb = "";
   /* if (da == 1)
        this.da = "ON";
    if (da == 0)
        this.da = "OFF";
    if (db == 1)
        this.db = "ON";
    if (db == 0)
        this.db = "OFF";
    if (pa > 0)
        this.pa = pa.toString() + "Pm";
    else
        this.pa = "OFF";
    if (pb > 0)
        this.pb = pb.toString() + "Pm";
    else
        this.pb = "OFF";*/


    //this.enableRiga2 = riga2Enable;
    this.enableRiga2 = 0;

    //this.enableRiga3 = riga3Enable;
    this.enableRiga3 = 0;

    //this.enableRiga4 = riga4Enable;
    this.enableRiga4 = 0;


    //this.maxAlarmpH = maxValueAlarm;
    

    this.xCanvasLeft = 10;
    //ph min 4.50
    this.widthCanvasLeft = 0;
    this.widthCanvasLeftGrey = 0;

    //ph range 700, 760
    this.widthCanvasCenterGreen1 = 0;
    this.widthCanvasCenterGreen1 = 0;


    //ph range 700, 760


    //ph max 8.50
    this.widthCanvasRightRed = 0;

    this.widthCanvasRightGrey = 0;


    this.colorGrey = "";
    this.colorGreen = "";
    this.colorRed = "";
    this.colorOrange = "";
    this.yCanvas = "";

    //this.pippo = initCanvas;


    //this.initCanvas();
    

    this.initSetpoint = function(enable, valore1,valore2,posizione,bleedFunction,outStatus){
        
        var statusString = "";
        var minTemp = 0;
        
        if (enable > 0) {
            enable = 1;
            console.log("bleed deadStart:" + valore2)
            if (bleedFunction) {
                
                if (valore2 > 0) { //deadband positivo
                    valore2 = valore1 + valore2;
                    console.log("bleed dead:" + valore2)
                    //valore1 = 0;
                }
                else {//deadband negativo
                    
                    valore2 = valore1 + valore2;
                    console.log("bleed dead1:" + valore2+" " + valore1)
                    //valore2 = this.maxSetpoint1;
                }
            }
            if ((outStatus.indexOf("SPM") >= 0) || (outStatus.indexOf("SPH") >= 0)) statusString = outStatus
            if (outStatus == "0") statusString = "OFF";
            if (outStatus == "1") statusString = "ON";
        }
        else {
            enable = 0;
            statusString = "";
            valore1 = 0;
            valore2 = 0;
        }

        switch (posizione)
        {
            case 1:
                this.enableRiga1 = enable;
                this.da = statusString;
                if (valore1 < valore2 )
                {
                    this.minSetpoint1 = valore1;
                    this.maxSetpoint1 = valore2;
                }
            else
                {
                this.minSetpoint1 = valore2;
                this.maxSetpoint1 = valore1;
                }

                break;
            case 2:
                this.enableRiga2 = enable;
                this.db = statusString;
                if (valore1 < valore2 )
                {
                    this.minSetpoint2 = valore1;
                    this.maxSetpoint2 = valore2;
                }
                else
                {
                    this.minSetpoint2 = valore2;
                    this.maxSetpoint2 = valore1;
                }
                break;

        }
    }
   
    this.calcolaPixel = function (valore, sizeBox, maxRange, margin) {
        return ((sizeBox - margin) * valore) / maxRange;
    };

    //---------------------------------------function
    this.disegnaLabelLayer = function (xLayer, yLayer, testo, colore, widthTemp, name, heightLayer, fontSize) {
        //console.log(xLayer)
        //console.log(testo.length)
        if (xLayer < this.xCanvasLeft)
            xLayer = xLayer + this.xCanvasLeft + 20;
        this.$myCanvasBody
                    .addLayer({
                        type: 'rectangle',
                        name: name,
                        fillStyle: colore,
                        fromCenter: false,
                        x: xLayer, y: yLayer,
                        width: testo.length * (fontSize) + 20, height: heightLayer
                    })
                    .addLayer({
                        type: 'text',
                        name: name + 'Text',
                        fillStyle: 'black',
                        fromCenter: false,
                        fontStyle: 'bold',
                        fontSize: fontSize.toString() + 'pt',
                        fontFamily: 'Open Sans, sans-serif',
                        x: xLayer /*+((testo.length *  fontSize))*/ + 5, y: yLayer + (0) + 5,
                        maxWidth: testo.length * (fontSize),
                        align: 'center',
                        text: testo
                    })
                    .drawLayers();

        this.$myCanvasBody.setLayer(name, {
            width: this.$myCanvasBody.getLayer(name + 'Text').width + 10
        })
       .drawLayers();
    };
    //---------------------------------------function
    this.disegnaLabel = function (xTesto, yTesto, testo, colore, widthTemp) {
        this.$myCanvasBody
        .drawRect({
            layer: true,
            //fillStyle: colorGrey,
            fillStyle: colore,
            strokeWidth: 2,
            x: xTesto + 5, y: yTesto + 12,
            //width: this.$myCanvasBody.measureText('myText').width , 
            //height: this.$myCanvasBody.measureText('myText').height 
            width: widthTemp,

            height: 15

        })
        .drawText({
            layer: true,
            //name: 'myText',
            fillStyle: 'black',
            strokeWidth: 2,
            x: xTesto + 5, y: yTesto + 12,
            fontSize: '8pt',
            fontFamily: 'Verdana, sans-serif',
            maxWidth: widthTemp,
            //fromCenter:false,
            text: testo
        });

    };
    //---------------------------------------function
    this.disegnaTriangolo90 = function (xTriangolo, yTriangolo, left, nomeTemp) {
        var triangolo90;
        if (left) {
            xTriangolo = xTriangolo - 8;
            triangolo90 = {
                type: 'line',
                name: nomeTemp,
                fromCenter: false,
                strokeStyle: 'white',
                fillStyle: '#000',
                strokeWidth: 1,
                x1: xTriangolo + 0, y1: yTriangolo + 0,
                x2: xTriangolo + 8, y2: yTriangolo + 0,
                x3: xTriangolo + 8, y3: yTriangolo + 8,
                closed: true
            }
        }
        else {
            //xTriangolo = xTriangolo - 8;
            triangolo90 = {
                type: 'line',
                name: nomeTemp,
                fromCenter: false,
                strokeStyle: 'white',
                fillStyle: '#000',
                strokeWidth: 1,
                x1: xTriangolo + 0, y1: yTriangolo + 0,
                x2: xTriangolo + 0, y2: yTriangolo + 8,
                x3: xTriangolo + 8, y3: yTriangolo + 0,

                closed: true
            }
        }
        return triangolo90
    };
    //---------------------------------------function
    this.disegnaTesto = function (xTesto, yTesto, testo, fontSize, colore) {
        this.$myCanvasBody
        .drawText({
            layer: true,
            fromCenter: false,
            //name: 'myText',
            fillStyle: 'black',
            strokeWidth: 2,
            x: xTesto, y: yTesto,
            fontSize: fontSize.toString() + 'pt',
            fontFamily: 'Verdana, sans-serif',
            text: testo
        });

    };
    //---------------------------------------function
    this.disegnaBarraGraduata = function () {
        var i = 0;
        var labelNumeric;
        var positionNumeric;
        this.$myCanvasBody
                    .addLayer({
                        type: 'rectangle',
                        name: 'barraOrizzontale',
                        fillStyle: this.colorGrey,
                        fromCenter: false,
                        x: this.xCanvasLeft, y: this.$myCanvasBody.height() - 60,
                        width: this.$myCanvasBody.width() - (this.xCanvasLeft * 2), height: 2
                    })
                    .drawLayers();
        for (i = 0; i < 8; i++) {
            this.$myCanvasBody
                    .addLayer({
                        type: 'rectangle',
                        name: 'barraOrizzontale' + i.toString(),
                        fillStyle: this.colorGrey,
                        fromCenter: false,
                        x: this.$myCanvasBody.getLayer("barraOrizzontale").x + (i * (this.$myCanvasBody.getLayer("barraOrizzontale").width / 7)), y: this.xCanvasLeft,
                        width: 1, height: this.$myCanvasBody.getLayer("barraOrizzontale").y//this.$myCanvasBody.height() - (this.this.xCanvasLeft * 2) - this.xCanvasLeft
                    })
                    .drawLayers();
            if (this.fullscale <= 10) {
                var fixedFloat = ((this.fullscale * i) / 7) / this.factorDivide;
                var fixedFloat1 = fixedFloat.toFixed(1);
                labelNumeric = parseFloat(fixedFloat1);
            }
            else {
                labelNumeric = parseInt(((this.fullscale * i) / 7) / this.factorDivide);
            }
            positionNumeric = (labelNumeric.toString().length * 2) + 5;
            if ((i == 7) && (labelNumeric.toString().length > 2))
                positionNumeric = positionNumeric + 10;
            this.disegnaTesto(this.$myCanvasBody.getLayer("barraOrizzontale" + i.toString()).x - positionNumeric /*10*/, this.$myCanvasBody.getLayer("barraOrizzontale" + i.toString()).y + this.$myCanvasBody.getLayer("barraOrizzontale" + i.toString()).height, labelNumeric, 10, this.colorGrey);
        }
    };
    //---------------------------------------function
    this.disegnaLegenda = function (posizioneX, posizioneY, colore, testoLegenda) {
        var posizioneXLegenda = posizioneX + this.$myCanvasBody.getLayer("barraOrizzontale").x;
        var posizioneYLegenda = posizioneY + this.$myCanvasBody.getLayer("barraOrizzontale").y + 40;
        this.$myCanvasBody
        .drawRect({
            name: 'legend' + posizioneXLegenda.toString(),
            layer: true,
            fillStyle: colore,
            x: posizioneXLegenda, y: posizioneYLegenda,
            width: 10,
            height: 10
        });
        this.disegnaTesto(posizioneXLegenda + 10, posizioneYLegenda - 8, testoLegenda, 10, "black")
    };
    //---------------------------------------function
    this.aggiungiLayer = function (xCanvasLeftTemp, yCanvasTemp, lines, widthCanvasCenterGreenTemp, widthCanvasLeftGreyTemp, widthCanvasRightGreyTemp, minSetpointpHEnable, minSetpointpHTemp, maxSetpointpHTemp, testo, livello, dosing, reading,labelCanaleTemp) {
        var positionLinea = 0;
        var coloreGreyLocal;
        //if ()
        this.$myCanvasBody
                    .addLayer({
                        type: 'rectangle',
                        name: 'redBoxL' + yCanvasTemp.toString(),
                        fillStyle: this.colorRed,
                        fromCenter: false,
                        x: xCanvasLeftTemp, y: this.$myCanvasBody.height() - 70,
                        width: this.widthCanvasLeft, height: 10
                    })
                    .addLayer({
                        type: 'rectangle',
                        name: 'greyBoxL' + yCanvasTemp.toString(),
                        //fillStyle: livello == 1 ? this.colorOrange : this.colorGrey,
                        fillStyle:  this.colorGrey,
                        fromCenter: false,
                        //x: xCanvasLeftTemp + this.widthCanvasLeft, y: yCanvasTemp,
                        x: xCanvasLeftTemp , y: yCanvasTemp,
                        
                        width:this.widthCanvasLeft + widthCanvasLeftGreyTemp, height: this.heightGlobal
                    })
                    // Normally on top, but moved to the bottom
                    .addLayer({
                        type: 'rectangle',
                        name: 'greenBox' + yCanvasTemp.toString(),
                        fromCenter: false,
                        fillStyle: this.colorGreen,
                        x: xCanvasLeftTemp + this.widthCanvasLeft + widthCanvasLeftGreyTemp, y: yCanvasTemp,
                        //x: xCanvasLeftTemp  + widthCanvasLeftGreyTemp, y: yCanvasTemp,

                        width: widthCanvasCenterGreenTemp, height: this.heightGlobal
                    })
                    .addLayer({
                        type: 'rectangle',
                        name: 'greyBoxR' + yCanvasTemp.toString(),
                        fromCenter: false,
                        index: 0,
                        //fillStyle: livello == 1 ? this.colorOrange : this.colorGrey,
                        fillStyle: this.colorGrey,
                        x: xCanvasLeftTemp + this.widthCanvasLeft + widthCanvasLeftGreyTemp + widthCanvasCenterGreenTemp, y: yCanvasTemp,
                        //x: xCanvasLeftTemp  + widthCanvasLeftGreyTemp + widthCanvasCenterGreenTemp, y: yCanvasTemp,
                        width: widthCanvasRightGreyTemp + this.widthCanvasRightRed, height: this.heightGlobal
                    })
                    .addLayer({
                        type: 'rectangle',
                        name: 'redBoxR' + yCanvasTemp.toString(),
                        fillStyle: this.colorRed,
                        fromCenter: false,
                        x: xCanvasLeftTemp + this.widthCanvasLeft + widthCanvasLeftGreyTemp + widthCanvasCenterGreenTemp + widthCanvasRightGreyTemp, //y: yCanvasTemp,
                        y: this.$myCanvasBody.height() - 70,
                        //x: xCanvasLeftTemp + widthCanvasLeftGreyTemp + widthCanvasCenterGreenTemp + widthCanvasRightGreyTemp, y: yCanvasTemp,
                        width: this.widthCanvasRightRed, height: 10//height: this.heightGlobal
                    })
                    .drawLayers();

        positionLinea = xCanvasLeftTemp + this.calcolaPixel(this.valuePh, this.$myCanvasBody.width(), this.fullscale, xCanvasLeftTemp * 2);

        if (lines) {
            this.$myCanvasBody
                        .addLayer({
                            type: 'rectangle',
                            name: 'linesR',
                            fillStyle: 'black',
                            strokeStyle: 'white',
                            fromCenter: false,
                            x: xCanvasLeftTemp + this.calcolaPixel(this.valuePh, this.$myCanvasBody.width(), this.fullscale, xCanvasLeftTemp * 2), y: 40,
                            width: 3, height: 215
                        })
                        //rettangolini
                        .addLayer({
                            type: 'polygon',
                            name: 'linesRtriangle',
                            fromCenter: false,
                            strokeStyle: 'white',
                            fillStyle: 'black',
                            strokeWidth: 1,
                            //x: xCanvasLeft + this.widthCanvasLeft - 6, y: this.yCanvas + this.heightGlobal - 8,
                            x: this.$myCanvasBody.getLayer("linesR").x - 4, y: this.$myCanvasBody.getLayer("linesR").y - 12,
                            radius: 6,
                            rotate: 180,
                            sides: 3
                        })
                        .drawLayers();
        }

      /*  if ((this.minAlarmpH > 0)&&(lines)) {//se si vogliono gli allarmi nella stessa riga della uscita
            this.$myCanvasBody
                        .addLayer({
                            type: 'polygon',
                            name: 'polygonL' + yCanvasTemp.toString(),
                            fromCenter: false,
                            strokeStyle: 'white',
                            fillStyle: 'black',
                            strokeWidth: 1,
                            //x: xCanvasLeft + this.widthCanvasLeft - 6, y: this.yCanvas + this.heightGlobal - 8,
                            x: this.$myCanvasBody.getLayer("greyBoxL" + yCanvasTemp.toString()).x - 6, y: this.$myCanvasBody.getLayer("greyBoxL" + yCanvasTemp.toString()).y + this.heightGlobal - 8,
                            //x: this.xCanvasLeft, y: 10,
                            
                           radius: 6,
                            sides: 3
                        })
                    .drawLayers();
        }*/

        /*if (this.maxAlarmpH > 0) {se si vogliono gli allarmi nella stessa riga della uscita
            this.$myCanvasBody
                        .addLayer({
                            type: 'polygon',
                            name: 'polygonR' + yCanvasTemp.toString(),
                            fromCenter: false,
                            strokeStyle: 'white',
                            fillStyle: 'black',
                            strokeWidth: 1,
                            x: this.$myCanvasBody.getLayer("greyBoxR" + yCanvasTemp.toString()).x + this.$myCanvasBody.getLayer("greyBoxR" + yCanvasTemp.toString()).width - 6, y: this.$myCanvasBody.getLayer("greyBoxR" + yCanvasTemp.toString()).y + this.heightGlobal - 8,
                            radius: 6,
                            sides: 3
                        })
                .drawLayers();
        }*/
        if ((testo.length > 0) /*&& (lines)*/) {

            this.$myCanvasBody
                        .addLayer({
                            type: 'polygon',
                            name: 'polygonCentral' + yCanvasTemp.toString(),
                            fromCenter: false,
                            strokeStyle: 'white',
                            fillStyle: 'red',
                            strokeWidth: 1,
                            x: positionLinea + 3, y: yCanvasTemp + (this.heightGlobal / 2) - 6,
                            radius: 6,
                            rotate: -90,
                            sides: 3
                        })
                .drawLayers();
        }

        if (minSetpointpHEnable) {
            this.$myCanvasBody
                        .addLayer(this.disegnaTriangolo90(this.$myCanvasBody.getLayer("greenBox" + yCanvasTemp.toString()).x, this.$myCanvasBody.getLayer("greenBox" + yCanvasTemp.toString()).y, true, "greenLeft" + yCanvasTemp.toString()))
                        .addLayer(this.disegnaTriangolo90(this.$myCanvasBody.getLayer("greenBox" + yCanvasTemp.toString()).x + this.$myCanvasBody.getLayer("greenBox" + yCanvasTemp.toString()).width, this.$myCanvasBody.getLayer("greenBox" + yCanvasTemp.toString()).y, false, "greenRight" + yCanvasTemp.toString()))
                        .drawLayers();
        }

        if (this.minAlarmpH > 0) {
            this.disegnaLabel(this.$myCanvasBody.getLayer("redBoxL" + yCanvasTemp.toString()).x + this.$myCanvasBody.getLayer("redBoxL" + yCanvasTemp.toString()).width - 20, this.$myCanvasBody.getLayer("redBoxL" + yCanvasTemp.toString()).y - 22, (this.minAlarmpH / this.factorDivide).toString(), this.colorRed, 30)
            this.disegnaLabel(this.$myCanvasBody.getLayer("greyBoxL" + yCanvasTemp.toString()).x + this.minAlarmpHLabel.length * 3, this.$myCanvasBody.getLayer("redBoxL" + yCanvasTemp.toString()).y - 40, this.minAlarmpHLabel, "transparent", this.minAlarmpHLabel.length * 8)
        }
        if (this.maxAlarmpH > 0) {
            this.disegnaLabel(this.$myCanvasBody.getLayer("redBoxR" + yCanvasTemp.toString()).x + 10, this.$myCanvasBody.getLayer("redBoxR" + yCanvasTemp.toString()).y - 22, (this.maxAlarmpH / this.factorDivide).toString(), this.colorRed, 30)
            this.disegnaLabel(this.$myCanvasBody.getLayer("barraOrizzontale").width - this.maxAlarmpHLabel.length * 3, this.$myCanvasBody.getLayer("redBoxR" + yCanvasTemp.toString()).y - 40, this.maxAlarmpHLabel, "transparent", this.maxAlarmpHLabel.length * 8)
        }
            
        if (minSetpointpHEnable) {
            this.disegnaLabel(this.$myCanvasBody.getLayer("greenLeft" + yCanvasTemp.toString()).x1 - 16, this.$myCanvasBody.getLayer("greenLeft" + yCanvasTemp.toString()).y1 - 23, (minSetpointpHTemp / this.factorDivide).toString(), this.colorGreen, 30)
            this.disegnaLabel(this.$myCanvasBody.getLayer("greenRight" + yCanvasTemp.toString()).x1 + 15, this.$myCanvasBody.getLayer("greenRight" + yCanvasTemp.toString()).y1 - 23, (maxSetpointpHTemp / this.factorDivide).toString(), this.colorGreen, 30)
        }
        //disegna etichetta fianco
        // this.disegnaLabel(this.$myCanvasBody.getLayer("greyBoxL" + yCanvasTemp.toString()).x1 + 15, this.$myCanvasBody.getLayer("greyBoxL" + yCanvasTemp.toString()).y1 - 23, "Alavro", "black", 30)
        //alert(this.$myCanvasBody.getLayer("greyBoxL" + yCanvasTemp.toString()).x)
        this.disegnaLabel(this.$myCanvasBody.getLayer("greyBoxL" + yCanvasTemp.toString()).x + 15, this.$myCanvasBody.getLayer("greyBoxL" + yCanvasTemp.toString()).y - 40, labelCanaleTemp, "transparent", 60)

        if ((testo.length > 0)/*&&(lines)*/) {
            this.disegnaLabelLayer(this.$myCanvasBody.getLayer("polygonCentral" + yCanvasTemp.toString()).x + 10, this.$myCanvasBody.getLayer("polygonCentral" + yCanvasTemp.toString()).y - 3/*+ this.$myCanvasBody.getLayer("greenLeft").radius + 2*/, testo, "white", 45, "labelStatus" + yCanvasTemp.toString(), 16, 8)
        }

        if (lines)
            this.disegnaLabelLayer(this.$myCanvasBody.getLayer("linesRtriangle").x - (60 / 2), this.$myCanvasBody.getLayer("linesRtriangle").y - (25)/*+ this.$myCanvasBody.getLayer("greenLeft").radius + 2*/, this.labelpH + " " + (this.valuePh / this.factorDivide).toString(), ((this.ad == 1) || (this.ar == 1)) ? this.colorRed : ((this.leval1 == 1) ? this.colorOrange : this.colorGrey), 90, "labelChannel", 26, 12)

    };
    //---------------------------------------function
    this.updateCanvas = function () {
        this.disegnaBarraGraduata();
        var calcolo = 0;
        var somma = 0;
        var lines = false
        if (this.enableRiga1) {
            calcolo = calcolo 
        }
        if (this.enableRiga2)
            calcolo = calcolo + 70
        if (this.enableRiga3)
            calcolo = calcolo + 70
        if (this.enableRiga4)
            calcolo = calcolo + 70

        if (calcolo == 0) {

            

            if (this.maxAlarmpH > 0){
                this.widthCanvasRightGrey = this.calcolaPixel(this.maxAlarmpH, this.$myCanvasBody.width(), this.fullscale, this.xCanvasLeft * 2) - this.calcolaPixel(this.maxSetpoint1, this.$myCanvasBody.width(), this.fullscale, this.xCanvasLeft * 2);
                this.widthCanvasRightRed = (this.$myCanvasBody.getLayer("barraOrizzontale").width) - this.calcolaPixel(this.maxAlarmpH, this.$myCanvasBody.width(), this.fullscale, this.xCanvasLeft * 2); //- (this.widthCanvasCenterGreen1 + this.widthCanvasLeftGrey + this.widthCanvasLeft + this.widthCanvasRightGrey)
            }
            else
                this.widthCanvasRightGrey = this.calcolaPixel(this.fullscale, this.$myCanvasBody.width(), this.fullscale, this.xCanvasLeft * 2) - this.calcolaPixel(this.maxSetpoint1, this.$myCanvasBody.width(), this.fullscale, this.xCanvasLeft * 2);

            this.widthCanvasLeftGrey = this.calcolaPixel(this.minSetpoint1, this.$myCanvasBody.width(), this.fullscale, this.xCanvasLeft * 2) - this.widthCanvasLeft;
            this.aggiungiLayer(this.xCanvasLeft, this.yCanvas + 70, true, this.widthCanvasCenterGreen1, this.widthCanvasLeftGrey, this.widthCanvasRightGrey, this.enableRiga1, this.minSetpoint1, this.maxSetpoint1, this.da, this.leval1, this.ad, this.ar, this.idDigitalSpLabel1);
        }
        if (calcolo == 70) {
            if (this.enableRiga1) {
                
                if (this.maxAlarmpH > 0) {
                    this.widthCanvasRightGrey = this.calcolaPixel(this.maxAlarmpH, this.$myCanvasBody.width(), this.fullscale, this.xCanvasLeft * 2) - this.calcolaPixel(this.maxSetpoint1, this.$myCanvasBody.width(), this.fullscale, this.xCanvasLeft * 2);
                    this.widthCanvasRightRed = (this.$myCanvasBody.getLayer("barraOrizzontale").width) - this.calcolaPixel(this.maxAlarmpH, this.$myCanvasBody.width(), this.fullscale, this.xCanvasLeft * 2);// - (this.widthCanvasCenterGreen1 + this.widthCanvasLeftGrey + this.widthCanvasLeft + this.widthCanvasRightGrey)
                }
                else
                    this.widthCanvasRightGrey = this.calcolaPixel(this.fullscale, this.$myCanvasBody.width(), this.fullscale, this.xCanvasLeft * 2) - this.calcolaPixel(this.maxSetpoint1, this.$myCanvasBody.width(), this.fullscale, this.xCanvasLeft * 2);

                this.widthCanvasLeftGrey = this.calcolaPixel(this.minSetpoint1, this.$myCanvasBody.width(), this.fullscale, this.xCanvasLeft * 2) - this.widthCanvasLeft;
                this.aggiungiLayer(this.xCanvasLeft, this.yCanvas + 35, true, this.widthCanvasCenterGreen1, this.widthCanvasLeftGrey, this.widthCanvasRightGrey, this.enableRiga1, this.minSetpoint1, this.maxSetpoint1, this.da, this.leval1, this.ad, this.ar, this.idDigitalSpLabel1);
                //this.aggiungiLayer(this.xCanvasLeft, this.yCanvas + 70, true, this.widthCanvasCenterGreen1, this.widthCanvasLeftGrey, this.widthCanvasRightGrey, this.enableRiga1, this.minSetpoint1, this.maxSetpoint1, "", this.leval1, this.ad, this.ar);
                lines = true
            }
            
            if (this.enableRiga2) {
                //this.widthCanvasLeftGrey = this.calcolaPixel(this.minSetpoint2, this.$myCanvasBody.width(), this.fullscale, this.xCanvasLeft * 2) - this.widthCanvasLeft;
                //this.widthCanvasRightGrey = this.calcolaPixel(this.maxAlarmpH, this.$myCanvasBody.width(), this.fullscale, this.xCanvasLeft * 2) - this.calcolaPixel(this.maxSetpoint1, this.$myCanvasBody.width(), this.fullscale, this.xCanvasLeft * 2);
                if (this.maxAlarmpH > 0){
                    this.widthCanvasRightGrey = this.calcolaPixel(this.maxAlarmpH, this.$myCanvasBody.width(), this.fullscale, this.xCanvasLeft * 2) - this.calcolaPixel(this.maxSetpoint2, this.$myCanvasBody.width(), this.fullscale, this.xCanvasLeft * 2);
                    this.widthCanvasRightRed = (this.$myCanvasBody.getLayer("barraOrizzontale").width) - this.calcolaPixel(this.maxAlarmpH, this.$myCanvasBody.width(), this.fullscale, this.xCanvasLeft * 2);// - (this.widthCanvasCenterGreen1 + this.widthCanvasLeftGrey + this.widthCanvasLeft + this.widthCanvasRightGrey)
                }
                else
                    this.widthCanvasRightGrey = this.calcolaPixel(this.fullscale, this.$myCanvasBody.width(), this.fullscale, this.xCanvasLeft * 2) - this.calcolaPixel(this.maxSetpoint2, this.$myCanvasBody.width(), this.fullscale, this.xCanvasLeft * 2);

                this.widthCanvasLeftGrey = this.calcolaPixel(this.minSetpoint2, this.$myCanvasBody.width(), this.fullscale, this.xCanvasLeft * 2) - this.widthCanvasLeft;
                this.aggiungiLayer(this.xCanvasLeft, this.yCanvas + 70 + 35, true, this.widthCanvasCenterGreen2, this.widthCanvasLeftGrey, this.widthCanvasRightGrey, this.enableRiga2, this.minSetpoint2, this.maxSetpoint2,this.db, this.leval1, this.ad, this.ar, this.idDigitalSpLabel2);
                lines = true
            }
            if (this.enableRiga3) {
                this.widthCanvasLeftGrey = this.calcolaPixel(this.minSetpoint3, this.$myCanvasBody.width(), this.fullscale, this.xCanvasLeft * 2) - this.widthCanvasLeft;
                if (this.maxAlarmpH > 0)
                    this.widthCanvasRightGrey = this.calcolaPixel(this.maxAlarmpH, this.$myCanvasBody.width(), this.fullscale, this.xCanvasLeft * 2) - this.calcolaPixel(this.maxSetpoint3, this.$myCanvasBody.width(), this.fullscale, this.xCanvasLeft * 2);
                else
                    this.widthCanvasRightGrey = this.calcolaPixel(this.fullscale, this.$myCanvasBody.width(), this.fullscale, this.xCanvasLeft * 2) - this.calcolaPixel(this.maxSetpoint3, this.$myCanvasBody.width(), this.fullscale, this.xCanvasLeft * 2);
                this.aggiungiLayer(this.xCanvasLeft, this.yCanvas + 70, true, this.widthCanvasCenterGreen3, this.widthCanvasLeftGrey, this.widthCanvasRightGrey, this.enableRiga3, this.minSetpoint3, this.maxSetpoint3, this.pa, this.leval3, this.ad, this.ar, this.idDigitalSpLabel3);
                lines = true
            }
            if (this.enableRiga4) {
                this.widthCanvasLeftGrey = this.calcolaPixel(this.minSetpoint4, this.$myCanvasBody.width(), this.fullscale, this.xCanvasLeft * 2) - this.widthCanvasLeft;
                if (this.maxAlarmpH > 0)
                    this.widthCanvasRightGrey = this.calcolaPixel(this.maxAlarmpH, this.$myCanvasBody.width(), this.fullscale, this.xCanvasLeft * 2) - this.calcolaPixel(this.maxSetpoint4, this.$myCanvasBody.width(), this.fullscale, this.xCanvasLeft * 2);
                else
                    this.widthCanvasRightGrey = this.calcolaPixel(this.fullscale, this.$myCanvasBody.width(), this.fullscale, this.xCanvasLeft * 2) - this.calcolaPixel(this.maxSetpoint4, this.$myCanvasBody.width(), this.fullscale, this.xCanvasLeft * 2);
                this.aggiungiLayer(this.xCanvasLeft, this.yCanvas + 70, true, this.widthCanvasCenterGreen4, this.widthCanvasLeftGrey, this.widthCanvasRightGrey, this.enableRiga4, this.minSetpoint4, this.maxSetpoint4, this.pb, this.leval4, this.ad, this.ar, this.idDigitalSpLabel4);
                lines = true
            }

        }
        if (calcolo >= 140) {

            if (this.enableRiga1) {
                this.widthCanvasLeftGrey = this.calcolaPixel(this.minSetpoint1, this.$myCanvasBody.width(), this.fullscale, this.xCanvasLeft * 2) - this.widthCanvasLeft;
                if (this.maxAlarmpH > 0)
                    this.widthCanvasRightGrey = this.calcolaPixel(this.maxAlarmpH, this.$myCanvasBody.width(), this.fullscale, this.xCanvasLeft * 2) - this.calcolaPixel(this.maxSetpoint1, this.$myCanvasBody.width(), this.fullscale, this.xCanvasLeft * 2);
                else
                    this.widthCanvasRightGrey = this.calcolaPixel(this.fullscale, this.$myCanvasBody.width(), this.fullscale, this.xCanvasLeft * 2) - this.calcolaPixel(this.maxSetpoint1, this.$myCanvasBody.width(), this.fullscale, this.xCanvasLeft * 2);

                this.aggiungiLayer(this.xCanvasLeft, this.yCanvas + somma, lines, this.widthCanvasCenterGreen1, this.widthCanvasLeftGrey, this.widthCanvasRightGrey, this.enableRiga1, this.minSetpoint1, this.maxSetpoint1, "", this.leval1, this.ad, this.ar, this.idDigitalSpLabel1);
                somma = somma + 70;
                if (somma == 70) lines = true
            }
            if (this.enableRiga2) {
                this.widthCanvasLeftGrey = this.calcolaPixel(this.minSetpoint2, this.$myCanvasBody.width(), this.fullscale, this.xCanvasLeft * 2) - this.widthCanvasLeft;
                if (this.maxAlarmpH > 0)
                    this.widthCanvasRightGrey = this.calcolaPixel(this.maxAlarmpH, this.$myCanvasBody.width(), this.fullscale, this.xCanvasLeft * 2) - this.calcolaPixel(this.maxSetpoint2, this.$myCanvasBody.width(), this.fullscale, this.xCanvasLeft * 2);
                else
                    this.widthCanvasRightGrey = this.calcolaPixel(this.fullscale, this.$myCanvasBody.width(), this.fullscale, this.xCanvasLeft * 2) - this.calcolaPixel(this.maxSetpoint2, this.$myCanvasBody.width(), this.fullscale, this.xCanvasLeft * 2);

                this.aggiungiLayer(this.xCanvasLeft, this.yCanvas + somma, lines, this.widthCanvasCenterGreen2, this.widthCanvasLeftGrey, this.widthCanvasRightGrey, this.enableRiga2, this.minSetpoint2, this.maxSetpoint2, "", this.leval2, this.ad, this.ar, this.idDigitalSpLabel2);
                somma = somma + 70;
                if (somma == 70) lines = true

            }
            if (this.enableRiga3) {
                this.widthCanvasLeftGrey = this.calcolaPixel(this.minSetpoint3, this.$myCanvasBody.width(), this.fullscale, this.xCanvasLeft * 2) - this.widthCanvasLeft;
                if (this.maxAlarmpH > 0)
                    this.widthCanvasRightGrey = this.calcolaPixel(this.maxAlarmpH, this.$myCanvasBody.width(), this.fullscale, this.xCanvasLeft * 2) - this.calcolaPixel(this.maxSetpoint3, this.$myCanvasBody.width(), this.fullscale, this.xCanvasLeft * 2);
                else
                    this.widthCanvasRightGrey = this.calcolaPixel(this.fullscale, this.$myCanvasBody.width(), this.fullscale, this.xCanvasLeft * 2) - this.calcolaPixel(this.maxSetpoint3, this.$myCanvasBody.width(), this.fullscale, this.xCanvasLeft * 2);
                this.aggiungiLayer(this.xCanvasLeft, this.yCanvas + somma, lines, this.widthCanvasCenterGreen3, this.widthCanvasLeftGrey, this.widthCanvasRightGrey, this.enableRiga3, this.minSetpoint3, this.maxSetpoint3, "", this.leval3, this.ad, this.ar, this.idDigitalSpLabel3);
                somma = somma + 70;
                if (somma == 70) lines = true
            }
            if (this.enableRiga4) {
                this.widthCanvasLeftGrey = this.calcolaPixel(this.minSetpoint4, this.$myCanvasBody.width(), this.fullscale, this.xCanvasLeft * 2) - this.widthCanvasLeft;
                if (this.maxAlarmpH > 0)
                    this.widthCanvasRightGrey = this.calcolaPixel(this.maxAlarmpH, this.$myCanvasBody.width(), this.fullscale, this.xCanvasLeft * 2) - this.calcolaPixel(this.maxSetpoint4, this.$myCanvasBody.width(), this.fullscale, this.xCanvasLeft * 2);
                else
                    this.widthCanvasRightGrey = this.calcolaPixel(this.fullscale, this.$myCanvasBody.width(), this.fullscale, this.xCanvasLeft * 2) - this.calcolaPixel(this.maxSetpoint4, this.$myCanvasBody.width(), this.fullscale, this.xCanvasLeft * 2);
                this.aggiungiLayer(this.xCanvasLeft, this.yCanvas + somma, lines, this.widthCanvasCenterGreen4, this.widthCanvasLeftGrey, this.widthCanvasRightGrey, this.enableRiga4, this.minSetpoint4, this.maxSetpoint4, "", this.leval4, this.ad, this.ar, this.idDigitalSpLabel4);
                lines = false
            }
            
            //this.aggiungiLayer(this.xCanvasLeft, this.yCanvas, true, this.widthCanvasCenterGreen1);
            //this.aggiungiLayer(this.xCanvasLeft, this.yCanvas + 70, true, this.widthCanvasCenterGreen1);
        }

        if (calcolo == 210) {
            //this.aggiungiLayer(this.xCanvasLeft, this.yCanvas, true, this.widthCanvasCenterGreen1);
            //this.aggiungiLayer(this.xCanvasLeft, this.yCanvas + 70, true, this.widthCanvasCenterGreen1);
            //this.aggiungiLayer(this.xCanvasLeft, this.yCanvas + 140, true, this.widthCanvasCenterGreen1);
        }
        /* if ((this.minSetpoint1 > 0) ||(this.maxSetpoint1 > 0) ||
             (this.minSetpoint2 > 0) ||(this.maxSetpoint2 > 0) ||
             (this.minSetpoint3 > 0) ||(this.maxSetpoint3 > 0) 
             (this.minSetpoint4 > 0) ||(this.maxSetpoint4 > 0) 
             )*/
        this.disegnaLegenda(0, 0, this.colorGreen, "Range Setpoint");
        this.disegnaLegenda(150, 0, this.colorRed, "Alarm");
        this.disegnaLegenda(250, 0, this.colorOrange, "Level");

        //this.disegnaLegenda(0, 0, this.colorGrey, "Legenda1");

        //this.disegnaLegenda(200, 0, this.colorGreen, "Range Setpoint");

        //disegnaLabel(this.$myCanvasBody.getLayer("greenRight").x,this.$myCanvasBody.getLayer("greenRight").y + this.$myCanvasBody.getLayer("greenRight").radius + 2,"7.56",this.colorGreen)



        // Draw circle as wide as the tex;
    };
    //---------------------------------------function

    this.initCanvas = function () {

        //var xCanvasLeft = 10;
        /*
        var canvas = document.querySelector('canvas'),
        ctx = canvas.getContext('2d');
        fitToContainer(canvas);*/
        /* $('#myCanvas').width(700)
         $('#myCanvas').height(300)
         this.$myCanvasBody = $('#myCanvas');*/
        //$('#myCanvas').width($('#canale1').width())
        //$('#myCanvas').height($('#canale1').height())
        this.$myCanvasBody.clearCanvas();
        this.$myCanvasBody.removeLayers();


        this.$myCanvasBody.attr("width", $(this.idDivContainer).width())
        this.$myCanvasBody.css({
            "maxWidth": $(this.idDivContainer).width()
        });
        this.$myCanvasBody.attr("height", 300)

        //this.$myCanvasBody = $('#myCanvas');
        //ph min 4.50
        this.widthCanvasLeft = this.calcolaPixel(this.minAlarmpH, this.$myCanvasBody.width(), this.fullscale, this.xCanvasLeft * 2);

        this.widthCanvasCenterGreen1 = this.calcolaPixel(this.maxSetpoint1, this.$myCanvasBody.width(), this.fullscale, this.xCanvasLeft * 2) - this.calcolaPixel(this.minSetpoint1, this.$myCanvasBody.width(), this.fullscale, this.xCanvasLeft * 2);
        this.widthCanvasCenterGreen2 = this.calcolaPixel(this.maxSetpoint2, this.$myCanvasBody.width(), this.fullscale, this.xCanvasLeft * 2) - this.calcolaPixel(this.minSetpoint2, this.$myCanvasBody.width(), this.fullscale, this.xCanvasLeft * 2);
        this.widthCanvasCenterGreen3 = this.calcolaPixel(this.maxSetpoint3, this.$myCanvasBody.width(), this.fullscale, this.xCanvasLeft * 2) - this.calcolaPixel(this.minSetpoint3, this.$myCanvasBody.width(), this.fullscale, this.xCanvasLeft * 2);
        this.widthCanvasCenterGreen4 = this.calcolaPixel(this.maxSetpoint4, this.$myCanvasBody.width(), this.fullscale, this.xCanvasLeft * 2) - this.calcolaPixel(this.minSetpoint4, this.$myCanvasBody.width(), this.fullscale, this.xCanvasLeft * 2);

        // this.widthCanvasLeftGrey = this.calcolaPixel(this.minSetpointpH, this.$myCanvasBody.width(), this.fullscale, this.xCanvasLeft * 2) - this.widthCanvasLeft;



        //this.widthCanvasRightGrey = this.calcolaPixel(this.maxAlarmpH, this.$myCanvasBody.width(), this.fullscale, this.xCanvasLeft * 2) - (this.widthCanvasCenterGreen + this.widthCanvasLeftGrey + this.widthCanvasLeft);

        //ph max 8.50
        //this.widthCanvasRightRed = (this.$myCanvasBody.width() - 20) - this.calcolaPixel(this.maxAlarmpH, this.$myCanvasBody.width(), this.fullscale, this.xCanvasLeft * 2)


        

        /*colori
        */

        this.colorGrey = '#cccccc';
        this.colorGreen = '#a4c408';
        this.colorRed = "#c33";
        this.colorOrange = "orange";
        this.yCanvas = 60;

        this.updateCanvas();

    };
    //---------------------------------------function
    this.explode = function () {
        //updateCanvas(this.this.widthCanvasLeftGrey);
        //this.$myCanvasBody.removeLayer('linesR').drawLayers();
        this.$myCanvasBody.setLayer('linesR', {
            //fillStyle: '#36b',
            //rotate: 30,
            x: '+=3',
            x: '+=3'
        })
      .drawLayers();
        this.$myCanvasBody.setLayer('labelStatus', {
            //fillStyle: '#36b',
            //rotate: 30,
            x: '+=3'
        })
      .drawLayers();
        this.$myCanvasBody.setLayer('linesRtriangle', {
            //fillStyle: '#36b',
            //rotate: 30,
            x: '+=3'
        })
      .drawLayers();


        this.$myCanvasBody.setLayer('labelStatusText', {
            //fillStyle: '#36b',
            //rotate: 30,
            x: '+=3'
        })
      .drawLayers();


        this.$myCanvasBody.setLayer('polygonCentral', {
            //fillStyle: '#36b',
            //rotate: 30,
            x: this.$myCanvasBody.getLayer("linesR").x + 3
        })
      .drawLayers();

        this.$myCanvasBody.setLayer('labelChannel', {
            //fillStyle: '#36b',
            //rotate: 30,
            x: '+=3'
        })
      .drawLayers();
        this.$myCanvasBody.setLayer('labelChannelText', {
            //fillStyle: '#36b',
            //rotate: 30,
            x: '+=3'
        })
      .drawLayers();


    };
    //setTimeout(explode, 2000);
    //setInterval(explode, 2000);

   /* $(window).resize(function () {

        this.$myCanvasBody.clearCanvas();
        //$('canvas').clearCanvas();
        // Remove all layers
        this.$myCanvasBody.removeLayers()
        //$('canvas').removeLayers();
        initCanvas();
    });*/
  //  this.$myCanvasBody.clearCanvas();
  //  this.$myCanvasBody.removeLayers();

    //this.initCanvas();
}
//----------------------------END BLOCCO BODY--------------------------------
// ---------------------------BLOCCO FOOTER
function footerCanvas(idCanvas,idDivFooter, labelTimer) {

    this.$myCanvasFooter = $(idCanvas);
    this.labelTimer = labelTimer
    
    this.labelTimerVal = ""
    this.timerIDVal = ""

    this.labelTimerTimeLeft = '';
    this.labelTimerTimeLeftValue = '';
    this.labelTimerDEF = '';
    this.endAngle = 0;
    this.footerCanvasWith = $(idDivFooter).width();
    this.colorTextFooter = 'black';
    
    this.$myCanvasFooter.attr("width", this.footerCanvasWith)
    this.$myCanvasFooter.css({
        "maxWidth": this.footerCanvasWith
    });

    this.calcolaLunghezzaTesto = function (labelTimer) {
        var labelTimerLunghezza = 0;
        if ((labelTimer.length % 2) == 0)
            labelTimerLunghezza = labelTimer.length;
        else
            labelTimerLunghezza = labelTimer.length - 1;
        return labelTimerLunghezza;
    }


    this.initCanvasTimer = function (xArcSettingTemp, yArcSettingTemp) {
        var xArcSetting = xArcSettingTemp;
                var radiusT = 60;
                var yArcSetting = yArcSettingTemp;


        this.$myCanvasFooter.drawArc({
                    strokeStyle: '#cccccc',
                    strokeWidth: 0,
                    layer: true,
                    x: xArcSetting, y: yArcSetting,
                    fillStyle: 'black',
                    radius: radiusT,
                    // start and end angles in degrees
                    start: 0, end: 360
                })
                .drawSlice({
                    strokeStyle: '#a4c408',
                    layer: true,
                    strokeWidth: this.endAngle == 0 ? 0 : 1,
                    x: xArcSetting, y: yArcSetting,
                    fillStyle: '#a4c408',
                    radius: radiusT,
                    closed: true,
                    //ccw: true,
                    // start and end angles in degrees
                    start: 0, end: this.endAngle
                })
                .drawArc({
                    strokeStyle: '#cccccc',
                    layer: true,
                    strokeWidth: 0,
                    x: xArcSetting, y: yArcSetting,
                    radius: radiusT - 8,
                    fillStyle: 'white',
                    // start and end angles in degrees
                    start: 0, end: 360
                });
                //var labelTimer = 'Label';
                var labelTimerLunghezza = this.calcolaLunghezzaTesto(this.labelTimerDEF);
                var labelTimerTimeLeftLunghezza = /*calcolaLunghezzaTesto(labelTimerTimeLeft)*/6;
                var labelTimerTimeLeftValueLunghezza = /*calcolaLunghezzaTesto(labelTimerTimeLeft)*/6;

        this.$myCanvasFooter
                        .addLayer({
                            type: 'text',
                            name: 'name1',
                            fillStyle: this.colorTextFooter,
                            fromCenter: false,
                            fontSize: '12pt',
                            fontFamily: 'Open Sans, sans-serif',
                            x: xArcSetting - ((labelTimerLunghezza / 2) * 5), y: yArcSetting + radiusT + 5,
                            maxWidth: 60,
                            align: 'center',
                            text: this.labelTimerDEF
                        })
                        .addLayer({
                            type: 'text',
                            name: 'name2',
                            fillStyle: this.colorTextFooter,
                            fromCenter: false,
                            fontSize: '10pt',
                            fontFamily: 'Open Sans, sans-serif',
                            x: xArcSetting - ((labelTimerTimeLeftLunghezza / 2) * 10), y: yArcSetting - 15,
                            maxWidth: 60,
                            align: 'center',
                            text: this.labelTimerTimeLeft
                        })
                        .addLayer({
                            type: 'text',
                            name: 'name3',
                            fillStyle: this.colorTextFooter,
                            fromCenter: false,
                            fontSize: '10pt',
                            fontFamily: 'Open Sans, sans-serif',
                            x: xArcSetting - ((labelTimerTimeLeftValueLunghezza / 2) * 10), y: yArcSetting + 15,
                            maxWidth: 60,
                            align: 'center',
                            text: this.labelTimerTimeLeftValue
                        })
                            .drawLayers();

    }
    this.updateCanvasTimer = function () {
        this.$myCanvasFooter.clearCanvas();
        this.$myCanvasFooter.removeLayers();
        
        //this.setInfoTime(this.timerIDVal);
        this.initCanvasTimer(this.footerCanvasWith / 2, 65);
    }
    this.initCanvasTimer(this.footerCanvasWith / 2, 65);
   

}

function setInfoTime (valTime) {
    //  0000,0000,0,0,0,0
    //  0000 feed time
    //  0000 tempo rimanente
    //   0 out digital number
    //   0 out digital status
    //   0 out proportional number
    //   0 out proportional pulse
    var index = 0;

    var valTimeSplit = valTime.split("|")

    //console.log(valTime)
    if (valTimeSplit.length >= 6) {

        //for (index = 0; index < valTimeSplit.length - 1; index++) {
        for (index = 0; index < 6; index++) {
            var valTimeSplitSingle = valTimeSplit[index].split(",");
            var feedTime = 0; var remaingTime = 0;
            var percent = 0;

            if (valTimeSplitSingle.length >= 6) {
                if (((parseInt(valTimeSplitSingle[2], 10) > 0) || (parseInt(valTimeSplitSingle[4], 10) > 0)) &&
                        (parseInt(valTimeSplitSingle[0], 10))) { // controllo se ho dei dati impostati Ingressi e feed time
                    feedTime = parseInt(valTimeSplitSingle[0], 10);
                    remaingTime = parseInt(valTimeSplitSingle[1], 10);
                    if (feedTime >= remaingTime)
                        remaingTime = feedTime - remaingTime
                    else
                        remaingTime = 0;
                    percent = (360 * remaingTime) / feedTime;
                    var stringDef = ""
                    //
                    arrayOggettiFooter[index].labelTimerTimeLeft = "Time Left"
                    arrayOggettiFooter[index].labelTimerTimeLeftValue = getHourMinutes(feedTime - remaingTime);
                    arrayOggettiFooter[index].colorTextFooter = "#a4c408"
                    //
                    if ((parseInt(valTimeSplitSingle[2], 10) > 0)) {
                        if (parseInt(valTimeSplitSingle[3], 10) > 0)
                            stringDef = stringDef + "ON "
                        else
                            stringDef = stringDef + "OFF "
                    }
                    if ((parseInt(valTimeSplitSingle[4], 10) > 0)) {
                        stringDef = stringDef + valTimeSplitSingle[5] + " Pm"
                    }
                    stringDef = stringDef + ""
                    //
                    //mainModel_details_timer.setProperty(index, "pump", stringDef)
                    //this.labelTimer = stringDef
                    //
                }
                else {
                    if ((parseInt(valTimeSplitSingle[2], 10) > 0) || (parseInt(valTimeSplitSingle[4], 10) > 0)) {
                        arrayOggettiFooter[index].labelTimerTimeLeft = "OFF"
                        arrayOggettiFooter[index].labelTimerTimeLeftValue = ""
                        arrayOggettiFooter[index].colorTextFooter = "black"
                        stringDef = "OFF"
                    }
                    else {
                        arrayOggettiFooter[index].labelTimerTimeLeft = "DISABLED"
                        arrayOggettiFooter[index].labelTimerTimeLeftValue = ""
                        arrayOggettiFooter[index].colorTextFooter = "black"
                        stringDef = "DISABLED"
                    }
                }
            }
            //mainModel_details_timer.setProperty(index, "text", getListLabel("timer" + (index + 1).toString() + "X"))
            arrayOggettiFooter[index].labelTimerDEF = arrayOggettiFooter[index].labelTimerVal + " " + stringDef
            arrayOggettiFooter[index].endAngle = percent
            //console.log(arrayOggettiFooter[index].labelTimerDEF)
            //repeaterValue.itemAt(index).setCircle(percent);
        }
    }
}
function getHourMinutes (valTime) {
    if (valTime >= 60)
        return (Math.floor(valTime / 60)).toString() + "h : " + (valTime % 60).toString() + "m"
    else
        return (valTime).toString() + "m"
}
//----------------------------END BLOCCO FOOTER
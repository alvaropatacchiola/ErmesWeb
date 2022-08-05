var state = { "publish": 0, "loadAllData": 1, "notConnected": 2, "readData": 3, "readSetpoint": 4, "sendData": 5, "busy": 6 ,"readLog": 7};
var milliseconds = 5000; //ms di timeout nella attesa di risposta
var millisecondsRetry = 10000; //ms di timeout nel riprovare se è connsesa
var stringaConnessione = "ws://192.168.1.72/pompe/websocket.ashx"

var chartLDOSIN;
/*$(document).ready(function () {
    console.log("ready!");
});
*/
//function OggettoPompa(serialNumberTemp, arrayReadRealTimeTemp, arrayReadSetpointTemp)
var OggettoPompa = function (options) {

    var vars = {
        serialNumber: '',
        arrayReadRealTime: [],
        arrayReadAll: [],
        arrayRisposteAll: [],
        plantName: '',
        languageSet: ''
    };
    var varsInternal = {
        socket: null,
        stateConnection: state.publish,
        indexGlobalProtocollo: 0,
        indexGlobalProtocolloSendData: 0,
        waitPompaVar: null,
        waitConnectionPompa: null,
        numeroTentativiRichieste: 0,
        reader: null,
        indiceLetturaLog:1,
        codiceLetturaLog: 5,//codice di lettura dei log
        maxLogProtocollo: 4,//massimo numero di log in una risposta
        sizeLogProtocollo: 32,//dimensione in byte di ciascuno log
        primaLetturaLog: true,
        dataLogStart:new Date(1970,0,1,0,0),
        dataLogStop: new Date(1970, 0, 1, 0, 0),
        logDayCurrent: parseInt($("#logDaySelect").val()),

        logGraphConductivityInputArray: [],
        logGraphConductivityInputNumeroDecimali: 0,
        logGraphConductivityOutputArray: [],
        logGraphConductivityOutputNumeroDecimali:0,
        logGraphTemperaturaArray: [],
        logGraphTemperaturaNumeroDecimali: 0,
        logGraphHighConductivityOutputEnableArray: [],
        logGraphHighConductivityInputEnableArray: [],
        logGraphHighTemperatureEnableArray: [],
        logGraphInputTempPumpEnableArray: [],
        logGraphInputPressureHighEnableArray: [],
        logGraphInputPressureLowEnableArray: [],
        logGraphInputStbyEnableArray: [],
        logGraphInputDosingAlarmEnableArray: [],
        logGraphInputFilterEnableArray: [],
        logGraphGenericAlarmEnableArray: [],
        logGraphInputLevelEnableArray: [],
        logGraphEvIngressoArray: [],
        logGraphEvUscitaArray: [],
        logGraphEvScaricoArray: [],
        logGraphPompaOsmosiArray: [],
        logGraphPompaDosaggioArray: [],
        logGraphOutAlarmArray: [],
        logGraphTotUscitaArray: [],
        logGraphTotIngressoArray: [],
        logGraphFlowMeterIngressoArray: [],
        logGraphFlowMeterUscitaArray: [],

        languageJson: null,
        languageJsonWarningAlarm: null,
        languageJsonDataTranslate: null,
        languageJsonSettingsMessage : null,
        pumpCapacityGlobal: 0.0,
        arraySendData: [],
        statusSendData : false,
        arrayIndiciProgrammazioniSettimanali: [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0],
        counterConnection : 0
    };

    this.construct = function (options) {
        $.extend(vars, options);
        varsInternal.stateConnection = state.publish;
        varsInternal.languageJson = jQuery.parseJSON(t0201[vars.languageSet]);
        varsInternal.languageJsonWarningAlarm = jQuery.parseJSON(t0201AlarmWarning[vars.languageSet]);
        varsInternal.languageJsonSettingsMessage = jQuery.parseJSON(t0201MessageSetpointDataEntry[vars.languageSet]);
        
        varsInternal.languageJsonDataTranslate = jQuery.parseJSON(t0201DataTranslate[vars.languageSet]);
        
        $("[id*='_SN']").each(function () {
            //$("#" + $(this).attr("id")).removeClass("active");
            var selectionId = $(this).attr("id");
            
            if (selectionId != undefined) {
                $(this).attr("id", selectionId.replace("_SN", vars.serialNumber));
            }
        });
        //impostazione delle lingue statiche nella pagine
        $("[data-translate]").each(function () {
            $(this).text(varsInternal.languageJsonDataTranslate[$(this).attr("data-translate")])
            //console.log("translate:" + $(this).attr("data-translate"))
        });
        //impostazione dei tempi per ogni select box
        var htmlText = ""
        var indiceCostruzione =0;
        for (indiceCostruzione = 0;indiceCostruzione<60;indiceCostruzione++){
            htmlText = htmlText + "<option value =\""  + indiceCostruzione.toString() + "\">" + indiceCostruzione.toString() + "</option>"
        }
        $(".timeInsert").each(function () {
            $(this).html(htmlText)
            //console.log("translate:" + $(this).attr("data-translate"))
        });
        //-------impostazione delle lingue statiche nella pagine
        //$(".timeControll").each(function () {
 
        //-----------------
    };

    this.construct(options);

    this.closeConnection = function () {
        varsInternal.socket.close();
        varsInternal.counterConnection = 4;
    }

    this.createConnection = function () {
        manageConnection();
    }
    function manageConnection() {
        console.log("verifica:" + varsInternal.stateConnection)
        messaggioTesto("Check Connection.");

        if (typeof (WebSocket) !== 'undefined') {
            varsInternal.socket = new WebSocket(stringaConnessione);
        } else {
            varsInternal.socket = new MozWebSocket(stringaConnessione);
        }
        varsInternal.socket.onclose = function () {
            varsInternal.counterConnection = varsInternal.counterConnection + 1;
            varsInternal.socket = null;
            if (varsInternal.counterConnection < 3) {

                manageConnection();
                varsInternal.stateConnection = state.publish;
            }
        }
        varsInternal.socket.onopen = function () {
            //alert("send Publish")
            //appena aperta connessione comincio a scaricare i dati dalla pompa
            varsInternal.socket.send("PUBLISH" + vars.serialNumber);
        }
        varsInternal.socket.onerror = function (msg) {
            console.log ("error:" + msg)
        }
        varsInternal.socket.onmessage = function (msg) {
            varsInternal.reader = new FileReader();

            varsInternal.reader.onloadend = () => {
                var data = varsInternal.reader.result;
                var array = new Uint8Array(data);
                switch (varsInternal.stateConnection) {
                    case state.publish:
                        if (((uint8arrayToStringMethod(array).indexOf("PUBLISHOK")) >= 0) || ((uint8arrayToStringMethod(array).indexOf("bsyR")) >= 0)) {
                            varsInternal.numeroTentativiRichieste = 0;
                            varsInternal.stateConnection = state.loadAllData;
                            clearTimeout(varsInternal.waitPompaVar); // blocco timeout
                            varsInternal.socket.send(createArraytoSend(vars.arrayReadAll));
                        }
                        else {//problema di pubblicazione

                        }
                        break;
                    case state.busy:
                        if ((uint8arrayToStringMethod(array).indexOf("bsyR0")) >= 0) {//se bsyR0 vuol dire che connesso e non occupato
                            varsInternal.numeroTentativiRichieste = 0;
                            varsInternal.stateConnection = state.loadAllData;
                            clearTimeout(varsInternal.waitPompaVar); // blocco timeout
                            varsInternal.socket.send(createArraytoSend(vars.arrayReadAll));
                        }
                        break;
                    case state.loadAllData:

                        //piazzo i risultati di risposta negli array
                        if ((uint8arrayToStringMethod(array).indexOf("bsyR")) >= 0) {//se bsyR0 vuol dire che connesso e non occupato
                            /*if ((uint8arrayToStringMethod(array).indexOf("bsyR1")) >= 0) {//se bsyR0 vuol dire che connesso e non occupato
                                varsInternal.stateConnection = state.busy;
                                $("#modalitaLavoro" + vars.serialNumber).text(varsInternal.languageJson.pumpBusy);
                            }*/
                        }
                        else {
                            // - ------ controllo valori ricevuti rispettano cechsum
                            if (array[0] == 0xFF) { //verificco inizia per 
                                var checksumCalcolata = calcolaChecksum(array);
                                if (checksumCalcolata == array[array.length - 1]) { //verifico la checksum ricevuta
                                    console.log("checksum OK")
                                }
                                else {
                                    console.log("checksum errata")
                                    break;
                                }
                            }
                            else {
                                console.log("pacchetto errato")
                                break;
                            }

                            // - ------ - end ------ controllo valori ricevuti rispettano cechsum
                            varsInternal.numeroTentativiRichieste = 0;
                            //-----------------download dei setting della pompa o sync
                            $("#modalitaLavoro" + vars.serialNumber).text(varsInternal.languageJson.settingDownload);
                            //-----------------download dei setting della pompa o sync

                            //if (varsInternal.indexGlobalProtocollo > (vars.arrayRisposteAll).length)
                            //vars.arrayRisposteAll.push(array);//lo aggiungo se non presente
                            //else
                            vars.arrayRisposteAll[varsInternal.indexGlobalProtocollo] = array;//lo aggiorno se già presente
                            clearTimeout(varsInternal.waitPompaVar); // blocco timeout
                            varsInternal.indexGlobalProtocollo++;
                            if (varsInternal.indexGlobalProtocollo >= (vars.arrayReadAll).length) {
                                varsInternal.indexGlobalProtocollo = 0;
                                varsInternal.stateConnection = state.readData;

                                updateGraficaSetpoint();
                            }
                            varsInternal.socket.send(createArraytoSend(vars.arrayReadAll))
                        }
                        break;

                    case state.readData:
                        if (varsInternal.indexGlobalProtocollo >= (vars.arrayReadRealTime).length) {
                            varsInternal.indexGlobalProtocollo = 0;
                            var arrayData = [];
                            if (varsInternal.primaLetturaLog){//alla prima lettura vado a leggere qualche log
                                arrayData = addDataToArray(arrayData, varsInternal.indiceLetturaLog, 4);
                                varsInternal.stateConnection = state.readLog;
                                clearTimeout(varsInternal.waitPompaVar); // blocco timeout
                                varsInternal.socket.send(createArraytoSendLog(arrayData))
                                $("#statusReadLog").text("Load Log ..")
                                break;
                            }
                        }
                        if ((uint8arrayToStringMethod(array).indexOf("bsyR")) >= 0) {//se bsyR0 vuol dire che connesso e non occupato
                        }
                        else {
                            // - ------ controllo valori ricevuti rispettano cechsum
                            if (array[0] == 0xFF) { //verificco inizia per 
                                var checksumCalcolata = calcolaChecksum(array);
                                if (checksumCalcolata == array[array.length - 1]) { //verifico la checksum ricevuta
                                    console.log("checksum OK")
                                }
                                else {
                                    console.log("checksum errata")
                                    break;
                                }
                            }
                            else {
                                console.log("pacchetto errato")
                                break;
                            }

                            // - ------ - end ------ controllo valori ricevuti rispettano cechsum
                            //--------------------------------------------------
                            //$("#messages").text((arrayToData(vars.arrayRisposteAll[0], 11, 4) / 1000) + " l/h")
                            //$("#messages1").text((arrayToData(vars.arrayRisposteAll[0], 15, 4) / 1000) + " %")
                            //aggiornamento dati
                            varsInternal.numeroTentativiRichieste = 0;
                            vars.arrayRisposteAll[varsInternal.indexGlobalProtocollo] = array;//lo aggiorno se già presente


                            //status connection
                            //$("#statusConnection" + vars.serialNumber).show();//
                            //$("#statusNotConnection" + vars.serialNumber).hide();//

                            updateGrafica();

                            //controllo reload setpoint
                            if (arrayToData(vars.arrayRisposteAll[0], 3 + 81, 1)) {
                                console.log("Reload Setpoint")
                                varsInternal.stateConnection = state.loadAllData;
                                varsInternal.indexGlobalProtocollo = 0;
                                clearTimeout(varsInternal.waitPompaVar); // blocco timeout
                                varsInternal.socket.send(createArraytoSend(vars.arrayReadAll))
                                break;
                            }

                            clearTimeout(varsInternal.waitPompaVar); // blocco timeout

                            varsInternal.socket.send(createArraytoSend(vars.arrayReadAll))
                            varsInternal.indexGlobalProtocollo++;
                        }
                        break;
                    case state.sendData:
                        var varsInternalTemp = false;
                        if (array[2] == 0)//nella posizione 2 c'è la discriminazione da comando di lettura e scrittura
                            break;//se ci sono delle risposte di lettura attendo il completamento e poi scrivo
                        if ((uint8arrayToStringMethod(array).indexOf("bsyR")) >= 0) {//se bsyR0 vuol dire che connesso e non occupato
                        }
                        else {
                            console.log("risposta")
                            //varsInternal.indexGlobalProtocolloSendData;
                            varsInternal.indexGlobalProtocolloSendData++;
                            var calcoloPercenturale = (100 * (varsInternal.indexGlobalProtocolloSendData)) / varsInternal.arraySendData.length
                            $(".progress-bar-animated").css("width", calcoloPercenturale.toString() + "%")
                            $(".progress-bar-animated").css("aria - valuenow", calcoloPercenturale.toString() + "")

                            if (varsInternal.indexGlobalProtocolloSendData >= (varsInternal.arraySendData).length) {
                                varsInternal.indexGlobalProtocolloSendData = 0;
                                varsInternal.stateConnection = state.readData;
                                varsInternal.indexGlobalProtocollo = 0;
                                clearTimeout(varsInternal.waitPompaVar); // blocco timeout
                                varsInternal.socket.send(createArraytoSend(vars.arrayReadAll))
                                console.log("risposta Finito")
                                $(".ladda-label").show();
                                $(".ladda-spinner").hide();
                                varsInternal.statusSendData = false;

                                $(".ModeSendLoad").hide();
                                $(".progress-bar-animated").css("width", "0%")
                                $(".progress-bar-animated").css("aria - valuenow", "0")

                                break;
                            }
                        }
                        if (varsInternal.statusSendData) {//al primo invio devo attendere la stringa di liberazione del protociollo busy
                            varsInternalTemp = true;
                            varsInternal.statusSendData = false;
                        }
                        else {
                            if (array[2] == 1)//nella posizione 2 c'è la risposta al comando di scrittura
                                varsInternalTemp = true;
                        }
                        if (varsInternalTemp) {
                            clearTimeout(varsInternal.waitPompaVar); // blocco timeout
                            varsInternal.socket.send(varsInternal.arraySendData[varsInternal.indexGlobalProtocolloSendData])
                            //varsInternal.waitPompaVar = setTimeout(waitPompa, milliseconds);
                            varsInternal.waitPompaVar = setTimeout(waitPompa, 10000);//in invio dati inserisco un  timeout di 10 secondi
                            //console.log("array InviatoSend:" + varsInternal.arraySendData[varsInternal.indexGlobalProtocolloSendData] + ":"  )
                        }
                        break;
                    case state.readLog:
                        if (array[1] != varsInternal.codiceLetturaLog)//nella posizione 1 c'è un codice diverso da quello di lettura del log
                            break;//se ci sono delle risposte di lettura attendo il completamento e poi scrivo

                        if ((uint8arrayToStringMethod(array).indexOf("bsyR")) >= 0) {//se bsyR0 vuol dire che connesso e non occupato
                        }
                        else {

                            //varsInternal.primaLetturaLog = false;
                            if (array[0] == 0xFF) { //verificco inizia per 
                                var checksumCalcolata = calcolaChecksum(array);
                                if (checksumCalcolata == array[array.length - 1]) { //verifico la checksum ricevuta
                                    console.log("checksum LOG OK")
                                    $("#logDaySelect").prop("disabled", true);
                                    if (decodeLog(array)) {
                                        $("#statusReadLogAnimation").show();
                                        varsInternal.indiceLetturaLog = varsInternal.indiceLetturaLog + varsInternal.maxLogProtocollo;
                                    }
                                    else
                                    {
                                        $("#logDaySelect").prop("disabled", false);
                                        $("#statusReadLog").text("Complete.")
                                        $("#statusReadLogAnimation").hide();
                                        disegnaGrafico();
                                        varsInternal.indexGlobalProtocollo = 0;
                                        clearTimeout(varsInternal.waitPompaVar); // blocco timeout
                                        varsInternal.socket.send(createArraytoSend(vars.arrayReadAll))
                                        varsInternal.stateConnection = state.readData;
                                    }
                                }
                                else {
                                    console.log("checksum LOG errata")
                                }
                            }
                            else {
                                console.log("pacchetto LOG errato")
                            }

                            

                        }
                        varsInternal.numeroTentativiRichieste = 0;
                        var arrayData = [];
                        arrayData = addDataToArray(arrayData, varsInternal.indiceLetturaLog, 4);
                        clearTimeout(varsInternal.waitPompaVar); // blocco timeout
                        varsInternal.socket.send(createArraytoSendLog(arrayData))

                        break;
                }
                //var $el = document.createElement('p');
                //$el.innerHTML = array;
                //$messages.appendChild($el);
                //console.log("Result: " + array + "," + varsInternal.stateConnection + "," + uint8arrayToStringMethod(array) + "," + vars.serialNumber);
            };
            //console.log("Result: " + msg.data + "," + varsInternal.stateConnection + "," + uint8arrayToStringMethod(msg.data) + "," + vars.serialNumber);

            varsInternal.reader.readAsArrayBuffer(msg.data);
            //var $el = document.createElement('p');
            //$el.innerHTML = msg.data;
            //$messages.appendChild($el);
        };
    }
    function waitPompa() {
        varsInternal.numeroTentativiRichieste++;
        clearTimeout(varsInternal.waitPompaVar); // blocco timeout
        if (varsInternal.numeroTentativiRichieste > 14) {//dopo 14 tentativi di richiesta non andati a b uon fine
            varsInternal.stateConnection = state.notConnected;
            console.log("tentativi CFompletati")
            messaggioTesto("Error Protocol.");
        }
        else { //n riprovo con il protocollo
            console.log("tentativi" + varsInternal.numeroTentativiRichieste)
            if (varsInternal.stateConnection == state.loadAllData)
                varsInternal.socket.send(createArraytoSend(vars.arrayReadAll))
            if (varsInternal.stateConnection == state.readData)
                varsInternal.socket.send(createArraytoSend(vars.arrayReadAll))
            if (varsInternal.stateConnection == state.sendData) {
                varsInternal.waitPompaVar = setTimeout(waitPompa, milliseconds);
                varsInternal.socket.send(varsInternal.arraySendData[varsInternal.indexGlobalProtocolloSendData])
            }
            if (varsInternal.stateConnection == state.readLog) {
                varsInternal.waitPompaVar = setTimeout(waitPompa, milliseconds);
                var arrayData = [];
                arrayData = addDataToArray(arrayData, varsInternal.indiceLetturaLog, 4);
                varsInternal.socket.send(createArraytoSendLog(arrayData))
            }

        }

        //setTimeout(retryPompa, millisecondsRetry);
    }
    function timeoutConnessione() {
        console.log("pompa non connessa");
        messaggioTesto("Not Connected.");
    }
    function retryPompa() {
        varsInternal.indexGlobalProtocollo = 0;
        varsInternal.stateConnection = state.readData;
        if (varsInternal.stateConnection == state.loadAllData)
            varsInternal.socket.send(createArraytoSend(vars.arrayReadAll))
        if (varsInternal.stateConnection == state.readData)
            varsInternal.socket.send(createArraytoSend(vars.arrayReadAll))
        if (varsInternal.stateConnection == state.sendData) {
            varsInternal.waitPompaVar = setTimeout(waitPompa, 10000);
            varsInternal.socket.send(varsInternal.arraySendData[varsInternal.indexGlobalProtocolloSendData])
        }
        if (varsInternal.stateConnection == state.readLog) {
            varsInternal.waitPompaVar = setTimeout(waitPompa, milliseconds);
            var arrayData = [];
            arrayData = addDataToArray(arrayData, varsInternal.indiceLetturaLog, 4);
            varsInternal.socket.send(createArraytoSendLog(arrayData))
        }

        console.log("delay pompa suprato")
    }
    //----------------------------------------BLOCCO CALCOLI VARI
    function uint8arrayToStringMethod(myUint8Arr) {
        return String.fromCharCode.apply(null, myUint8Arr);
    }
    function createArraytoSend(arrayToSendMQTT) {
        var arrayDef = new Uint8Array(6);
        arrayDef[0] = 0xFF;
        arrayDef[1] = arrayToSendMQTT[varsInternal.indexGlobalProtocollo];
        arrayDef[2] = 0x00;
        arrayDef[3] = 0xFE;
        arrayDef[4] = 0xFF;
        arrayDef[5] = calcolaChecksum(arrayDef);
        varsInternal.waitPompaVar = setTimeout(waitPompa, milliseconds);
        //console.log("array InviatoNEW:" + arrayDef + ":" + varsInternal.indexGlobalProtocollo + ":" + (arrayToSendMQTT).length)
        return arrayDef;
    }
    function createArraytoSendLog(arrayAppend) {
        var arrayDef = new Uint8Array(new Uint8Array(arrayAppend.length + 6));
        var i = 0;

        arrayDef[0] = 0xFF;
        arrayDef[1] = varsInternal.codiceLetturaLog;
        arrayDef[2] = 0x00;
        arrayDef[3] = 0xFE;
        for (i = 0; i < arrayAppend.length; i++) {
            arrayDef[4 + i] = arrayAppend[i];
        }
        arrayDef[4+i] = 0xFF;
        arrayDef[5+i] = calcolaChecksum(arrayDef);
        varsInternal.waitPompaVar = setTimeout(waitPompa, milliseconds);
        //console.log("array InviatoNEW:" + arrayDef + ":" + varsInternal.indexGlobalProtocollo + ":" + (arrayDef).length)
        return arrayDef;
    }

    function calcolaChecksum(arrayInput) {
        var i = 0;
        var val_chksm = 0;
        for (i = 0; i <= arrayInput.length - 2; i++) {
            val_chksm ^= arrayInput[i];
        }
        return val_chksm;
    }
    function arrayToData(arrayInput, start, lunghezza) {
        var i = 0;
        var datoFinale = 0;
        if (lunghezza > 0) lunghezza = lunghezza - 1;
        for (i = start + lunghezza; i >= start ; i--) {
            datoFinale = datoFinale << 8;
            datoFinale = datoFinale | arrayInput[i];
            //console.log(arrayInput[i])
        }
        return datoFinale;
    }
    function messaggioTesto(stringaTesto) {
        $("#modalitaLavoro" + vars.serialNumber).text(stringaTesto);
    }
    // modifica grafica in funzione del protocollo
    function updateGrafica() {
        var testoModalitaLavoro = '';
        var testoUscitaConducibilita = '';
        var uscitaConducibilita = 0.0;
        var testoUnitadiMisuraUscitaConducibilita = '';
        var numeroSondaConversione = 0;
        var minutiSecondiLavaggio = ''

        var testoIngressoConducibilita = '';
        var ingressoConducibilita = 0.0;
        var testoUnitadiMisuraIngressoConducibilita = '';

        var temperatura = 0.0;
        var testoTemperatura = '';
        var unitaTemperatura = '';

        var testoUnitadiMisura = '';
        var testoFrequenza = '';
        var testoSlowMode = '';
        var testoPulseMinute = '';
        var statoWarning = false;
        var txtWarning = [];
        var statoStby = false;
        var txtStby = [];
        var statoAllarme = false;
        var txtAllarme = [];

        var statoUscite = false;
        var txtUscite = [];


        if ((vars.arrayRisposteAll).length > 0) {

            // --------------------conducibilità in uscita
            numeroSondaConversione = conversioneSondaConducibilita(arrayToData(vars.arrayRisposteAll[1], 3 + 13, 2))

            uscitaConducibilita = arrayToData(vars.arrayRisposteAll[0], 3 + 33, 2) / getFattoreDivisioneSonda(5, numeroSondaConversione);// conducibilità in uscita
            testoUscitaConducibilita = uscitaConducibilita.toFixed(getNumeroDecimaliSonda(5, numeroSondaConversione));
            testoUnitadiMisuraUscitaConducibilita = getValoreLabelJson(5, numeroSondaConversione);
            // --------------------end conducibilità in uscita
            // --------------------conducibilità in ingresso
            numeroSondaConversione = conversioneSondaConducibilita(arrayToData(vars.arrayRisposteAll[1], 3 + 3, 2))
            ingressoConducibilita = arrayToData(vars.arrayRisposteAll[0], 3 + 5, 2) / getFattoreDivisioneSonda(5, numeroSondaConversione);// conducibilità in uscita
            testoIngressoConducibilita = ingressoConducibilita.toFixed(getNumeroDecimaliSonda(5, numeroSondaConversione));
            testoUnitadiMisuraIngressoConducibilita = getValoreLabelJson(5, numeroSondaConversione);
            // --------------------end conducibilità in ingresso
            // --------------------temperature
            temperatura = arrayToData(vars.arrayRisposteAll[0], 3 + 3, 2) / 10;
            testoTemperatura = temperatura.toFixed(1);
            unitaTemperatura = "°C";
            // --------------------end temperature
            switch (arrayToData(vars.arrayRisposteAll[0], 3 + 1, 2)) { // gestione ON / OFF
                case 0:// OFF
                    testoModalitaLavoro = varsInternal.languageJson.pumpOff;
                    testoDosaggioIstantaneo = "0"
                    break;
                case 1:// ON
                    
                    switch (arrayToData(vars.arrayRisposteAll[0], 3 + 13, 2)) {
                        case 0://nessuna azione
                            testoModalitaLavoro = ""
                            break;
                        case 1://Produzione 
                            testoModalitaLavoro = varsInternal.languageJson.produzione;
                            break;
                        case 2://Attesa 
                            testoModalitaLavoro = varsInternal.languageJson.attesa;
                            break;
                        case 3://lavaggio 
                            testoModalitaLavoro = varsInternal.languageJson.lavaggio;
                            minutiSecondiLavaggio = arrayToData(vars.arrayRisposteAll[0], 3 + 7, 2).toString() + "Min " + arrayToData(vars.arrayRisposteAll[0], 3 + 9, 2).toString() + "Sec"
                            break;

                    }
                    break;

            }

        }
        
        // controlloo Alert
        if ((arrayToData(vars.arrayRisposteAll[0], 3 + 37, 2) == 1) ) {//warning manutenzione
            statoWarning = true;
            txtWarning.push(varsInternal.languageJsonWarningAlarm.warningService);
        }
        //----- end controllo alert
                // controlloo allarmi
        if ((arrayToData(vars.arrayRisposteAll[0], 3 + 11, 2) == 1)) {//Alarm temperatura
            statoAllarme = true;
            txtAllarme.push(varsInternal.languageJsonWarningAlarm.alarmTemperatura);
        }
        if ((arrayToData(vars.arrayRisposteAll[0], 3 + 15, 2) == 1)) {//Alarm Pressione Alta
            statoAllarme = true;
            txtAllarme.push(varsInternal.languageJsonWarningAlarm.alarmPressioneH);
        }
        if ((arrayToData(vars.arrayRisposteAll[0], 3 + 17, 2) > 0)) {//Alarm Pressione Bassa tentativi
            statoAllarme = true;
            txtAllarme.push(varsInternal.languageJsonWarningAlarm.alarmPressioneL + " " + arrayToData(vars.arrayRisposteAll[0], 3 + 17, 2) + " of " + arrayToData(vars.arrayRisposteAll[0], 3 + 85, 2));
        }
        if ((arrayToData(vars.arrayRisposteAll[0], 3 + 19, 2) == 1)) {//Alarm Pressione Bassa
            statoAllarme = true;
            txtAllarme.push(varsInternal.languageJsonWarningAlarm.alarmPressioneL);
        }
        if ((arrayToData(vars.arrayRisposteAll[0], 3 + 21, 2) == 1)) {//Alarmconducibilità in Alta
            statoAllarme = true;
            txtAllarme.push(varsInternal.languageJsonWarningAlarm.alarmCdInH);
        }
        if ((arrayToData(vars.arrayRisposteAll[0], 3 + 23, 2) == 1)) {//Alarmconducibilità out Alta
            statoAllarme = true;
            txtAllarme.push(varsInternal.languageJsonWarningAlarm.alarmCdOutH);
        }
        if ((arrayToData(vars.arrayRisposteAll[0], 3 + 27, 2) == 1)) {//Alarm Massimo dosaggio
            statoAllarme = true;
            txtAllarme.push(varsInternal.languageJsonWarningAlarm.alarmDosing);
        }
        if ((arrayToData(vars.arrayRisposteAll[0], 3 + 29, 2) == 1)) {//Alarm filter
            statoAllarme = true;
            txtAllarme.push(varsInternal.languageJsonWarningAlarm.alarmFilter);
        }
        if ((arrayToData(vars.arrayRisposteAll[0], 3 + 31, 2) == 1)) {//Alarm generic
            statoAllarme = true;
            txtAllarme.push(varsInternal.languageJsonWarningAlarm.alarmGeneric);
        }
        if ((arrayToData(vars.arrayRisposteAll[0], 3 + 51, 2) == 1)) {//Alarm level
            statoAllarme = true;
            txtAllarme.push(varsInternal.languageJsonWarningAlarm.levelAlarm);
        }
        if ((arrayToData(vars.arrayRisposteAll[0], 3 + 53, 2) == 1)) {//temperature alarm
            statoAllarme = true;
            txtAllarme.push(varsInternal.languageJsonWarningAlarm.temperatureAlarm);
        }

        //--------end controlloo allarmi
        // controlloo stby
        if ((arrayToData(vars.arrayRisposteAll[0], 3 + 25, 2) == 1)) {//warning Standby
            statoStby = true;
            txtStby.push(varsInternal.languageJsonWarningAlarm.alarmStby);
        }
        //-------end  controlloo stby
        //stato delle uscite
        var shiftOperation = arrayToData(vars.arrayRisposteAll[0], 3 + 49, 2);
        var shiftIndex = 0;
        
        for (shiftIndex = 0; shiftIndex < 8; shiftIndex++) {
            var checkedTemp = false;
            if (shiftOperation & 1) {
                checkedTemp = true;
            }
            console.log("stato Uscite :" + checkedTemp)
            switch (shiftIndex) {
                case 0://stato elettrovalvola in ingresso
                    if (checkedTemp) {
                        statoUscite = true;
                        txtUscite.push(varsInternal.languageJson.evIngresso)
                    }
                    break;
                case 1://stato elettrovalvola in uscita
                    if (checkedTemp) {
                        statoUscite = true;
                        txtUscite.push(varsInternal.languageJson.evUscita)
                    }
                    break;
                case 2://stato elettrovalvola scarico
                    if (checkedTemp) {
                        statoUscite = true;
                        txtUscite.push(varsInternal.languageJson.evScarico)
                    }
                    break;
                case 3://stato pompa osmosi
                    if (checkedTemp) {
                        statoUscite = true;
                        txtUscite.push(varsInternal.languageJson.pompaOsmosi)
                    }
                    break;
                case 4://stato pompa dosaggio
                    if (checkedTemp) {
                        statoUscite = true;
                        txtUscite.push(varsInternal.languageJson.pompaDosaggio)
                    }
                    break;
                case 5://stato uscita allarme
                    if (checkedTemp) {
                        statoUscite = true;
                        txtUscite.push(varsInternal.languageJson.outAlarm)
                    }
                    break;
            }
            shiftOperation = shiftOperation >> 1;
        }
        var htmlUscite = "";
        if (statoUscite) {
            var i;
            for (i = 0; i < txtUscite.length; ++i) {
                htmlUscite = htmlUscite + "<div class=\"alert alert-primary alert-outlined\" role=\"alert\">" + txtUscite[i] + "</div>"
            }
        }
        $("#outStatusList").html(htmlUscite);
        //console.log("stato delle uscite:" + outputStatus)
        //------end stato delle uscite
        // ---- status connectione e alarm 
        if ((statoAllarme) || (statoWarning)) {
            if (statoAllarme) {//allarme
                $("#statusConnection" + vars.serialNumber).html("<div class=\"alert alert-danger alert-icon\" role=\"alert\"><i class=\"mdi mdi-alert-octagon\"></i>Alarm</div>")
            }
            else {//warning
                $("#statusConnection" + vars.serialNumber).html("<div class=\"alert alert-light alert-icon yellow\" role=\"alert\"><i class=\"mdi mdi-alert\"></i>Warning</div>")
            }
        }
        else
            $("#statusConnection" + vars.serialNumber).html("<div class=\"alert alert-success alert-icon\" role=\"alert\"><i class=\"mdi mdi-checkbox-marked-outline\"></i>" + varsInternal.languageJson.statusConnectionOK + "</div>")
        if (statoStby) {
            $("#statusStby" + vars.serialNumber).show();
            $("#statusStby" + vars.serialNumber).html("<div class=\"alert alert-light alert-icon black\" role=\"alert\"><i class=\"mdi mdi-power-standby\"></i>" + txtStby + "</div>")
        }
        else {
            $("#statusStby" + vars.serialNumber).hide();
        }
        // elenco allarmi Prisma
        if ((statoAllarme) || (statoWarning) || (statoStby)) {
            var htmlAllarme = "";
            var i;
            if (statoAllarme) {
                for (i = 0; i < txtAllarme.length; ++i) {
                    htmlAllarme = htmlAllarme + "<div class=\"alert alert-danger alert-outlined\" role=\"alert\">" + txtAllarme[i] + "</div>"
                }
            }
            if (statoWarning) {
                for (i = 0; i < txtWarning.length; ++i) {
                    htmlAllarme = htmlAllarme + "<div class=\"alert alert-warning alert-outlined\" role=\"alert\">" + txtWarning[i] + "</div>"
                }
            }
            if (statoStby) {
                for (i = 0; i < txtStby.length; ++i) {
                    htmlAllarme = htmlAllarme + "<div class=\"alert alert-light alert-outlined\" role=\"alert\">" + txtStby[i] + "</div>"
                }
            }
            $("#prismaAlarmWarnigList").html(htmlAllarme);
        }
        else {
            $("#prismaAlarmWarnigList").html("<div class=\"alert alert-primary alert-outlined\" role=\"alert\">" + varsInternal.languageJsonWarningAlarm.noncisonoallarmi + "<br></div>")
        }
        //----end elenco allarmi prisma
        
        //manutenzione strumento
        console.log("oreLavoro : " + arrayToData(vars.arrayRisposteAll[2], 3 + 93, 2))
        if ((arrayToData(vars.arrayRisposteAll[2], 3 + 93, 2) > 0)) {//ore di manutenzione > 0
            $("#statusManutenzione" + vars.serialNumber).show();
            $("#produzioneOre" + vars.serialNumber).html(varsInternal.languageJson.produzione + " :" + arrayToData(vars.arrayRisposteAll[0], 3 + 75, 2).toString() + " Hr " + arrayToData(vars.arrayRisposteAll[0], 3 + 77, 2).toString() + " min");
            $("#manutenzioneTra" + vars.serialNumber).html("Hr " + varsInternal.languageJsonDataTranslate.warningService + " :" + arrayToData(vars.arrayRisposteAll[0], 3 + 35, 2).toString());
        }
        else
            $("#statusManutenzione" + vars.serialNumber).hide();

        // ---- status connectione e alarm 

        // totalizzatore Strumento

        //water metere input totalizzatore
        var dosatoParziale = arrayToData(vars.arrayRisposteAll[0], 3 + 55, 8);// 
        var dosatoParzialeStringa = makeCalcoloLitriOrGallons(arrayToData(vars.arrayRisposteAll[1], 3 + 115, 2), dosatoParziale);
        var unitaLitriOrGalloni = makeUnitLitriOrGallons(arrayToData(vars.arrayRisposteAll[0], 3 + 115, 2), dosatoParziale);

        $("#totaleIngresso").text(dosatoParzialeStringa + " " + unitaLitriOrGalloni)
        //------------------end water metere input totalizzatore

        //water metere output totalizzatore
        var dosatoParziale24 = arrayToData(vars.arrayRisposteAll[0], 3 + 65, 8);// 
        var dosatoParziale24Stringa = makeCalcoloLitriOrGallons(arrayToData(vars.arrayRisposteAll[1], 3 + 115, 2), dosatoParziale24);
        unitaLitriOrGalloni = makeUnitLitriOrGallons(arrayToData(vars.arrayRisposteAll[1], 3 + 115, 2), dosatoParziale24);
        $("#totaleUscita").text(dosatoParziale24Stringa + " " + unitaLitriOrGalloni)
        //-----------------end water metere output totalizzatore

        // ---------------end totalizzatore Strumento
       
        //water meter input
        var riserva = arrayToData(vars.arrayRisposteAll[0], 3 + 39, 4);// 
        var riservaStringa = makeCalcoloLitriOrGallonsHora(arrayToData(vars.arrayRisposteAll[1], 3 + 115, 2), riserva);
        unitaLitriOrGalloni = makeUnitLitriOrGallonsHora(arrayToData(vars.arrayRisposteAll[0], 3 + 115, 2), riserva);
        $("#portataIngresso").text(riservaStringa + " " + unitaLitriOrGalloni);
        //-----end riserva

        //water meter input
        riserva = arrayToData(vars.arrayRisposteAll[0], 3 + 43, 4);// 
        riservaStringa = makeCalcoloLitriOrGallonsHora(arrayToData(vars.arrayRisposteAll[1], 3 + 115, 2), riserva);
        unitaLitriOrGalloni = makeUnitLitriOrGallonsHora(arrayToData(vars.arrayRisposteAll[0], 3 + 115, 2), riserva);
        $("#portataUscita").text(riservaStringa + " " + unitaLitriOrGalloni);
        //-----end portata istantanea
        
        $("#modalitaLavoro" + vars.serialNumber).text(testoModalitaLavoro + minutiSecondiLavaggio);

        $("#portata" + vars.serialNumber).html(testoUscitaConducibilita + "<span class=\"little\">" + testoUnitadiMisuraUscitaConducibilita + "</span>");

        //$("#valore1" + vars.serialNumber).html(testoPulseMinute + "<span class=\"badge badge-black badge-pill\" tabindex=\"0\" data-toggle=\"tooltip\" title=\"" + varsInternal.languageJson.titlePortata + "\"><i class=\"mdi mdi-information\"></i></span>");
        $("#valore1" + vars.serialNumber).attr("data-original-title", varsInternal.languageJson.titleIngresso)
        $("#valore1" + vars.serialNumber).html(testoIngressoConducibilita + " " + testoUnitadiMisuraIngressoConducibilita);
        //$("#valore2" + vars.serialNumber).html(testoFrequenza + "<span class=\"badge badge-black badge-pill\" tabindex=\"0\" data-toggle=\"tooltip\" title=\"" + varsInternal.languageJson.titleFrequenza + "\"><i class=\"mdi mdi-signal-cellular-outline\"></i></span>");
        $("#valore2" + vars.serialNumber).attr("data-original-title", varsInternal.languageJson.titleTemperatura)
        $("#valore2" + vars.serialNumber).html(testoTemperatura + " " + unitaTemperatura);
        //$("#valore3" + vars.serialNumber).html(testoSlowMode + "<span class=\"badge badge-black badge-pill\" tabindex=\"0\" data-toggle=\"tooltip\" title=\"" + varsInternal.languageJson.titleSlow + "\">	 <i class=\"mdi mdi-eject\"></i></span>");

    }
    //grafica setpoint
    function updateGraficaSetpoint() {

        var swVersioneStr = (arrayToData(vars.arrayRisposteAll[0], 3 + 47, 2)).toString();
        var variabileDiAppoggio = 0.0;
        var testoDiAppoggio = "";
        var testoUnitaDiAppoggio = "";
        var numeroSondaConversione = 0;

        $("#softwareReleaseNum").text(swVersioneStr.substring(0, 1) + "." + swVersioneStr.substring(1, 2) + "." + swVersioneStr.substring(2, 3));

        // --- Setpoint Condicibilità Ingresso
        if (arrayToData(vars.arrayRisposteAll[1], 3 + 23, 2)) //setpoint abilitato
            {
                $("#setpointIngressoEnable").prop("checked", true)
                $("#setpointIngressoGroup").show();
            }
        else{
            $("#setpointIngressoEnable").prop("checked", false)
            $("#setpointIngressoGroup").hide();
        }

        //console.log("numero Sonda:" + )
        numeroSondaConversione = conversioneSondaConducibilita(arrayToData(vars.arrayRisposteAll[1], 3 + 3, 2))
        variabileDiAppoggio = arrayToData(vars.arrayRisposteAll[1], 3 + 21, 2) / getFattoreDivisioneSonda(5, numeroSondaConversione);// 
        testoDiAppoggio = variabileDiAppoggio.toFixed(getNumeroDecimaliSonda(5, numeroSondaConversione));
        testoUnitaDiAppoggio = getValoreLabelJson(5, numeroSondaConversione);
        $("#setpointIngressoSetpoint").val(testoDiAppoggio)
        $("#setpointIngressoUnit").text(testoUnitaDiAppoggio)
        costruisciTextBoxListaSonde("#setpointIngressoSetpoint", testoUnitaDiAppoggio, 5, numeroSondaConversione)
        
        $("#setpointIngressoDelayMin> [value=" + arrayToData(vars.arrayRisposteAll[1], 3 + 29, 2).toString() + "]").prop("selected", true)
        $("#setpointIngressoDelaySec> [value=" + arrayToData(vars.arrayRisposteAll[1], 3 + 31, 2).toString() + "]").prop("selected", true)

        if (arrayToData(vars.arrayRisposteAll[1], 3 + 27, 2)) //stop
        {
            $("#setpointIngressoStop").prop("checked", true)
        }
        else {
            $("#setpointIngressoStop").prop("checked", false)
        }
        // --- end Setpoint Condicibilità Ingresso
        // --- Setpoint Condicibilità uscita
        if (arrayToData(vars.arrayRisposteAll[1], 3 + 37, 2)) //setpoint abilitato
        {
            $("#setpointUscitaEnable").prop("checked", true)
            $("#setpointUscitaGroup").show();
        }
        else {
            $("#setpointUscitaEnable").prop("checked", false)
            $("#setpointUscitaGroup").hide();
        }

        numeroSondaConversione = conversioneSondaConducibilita(arrayToData(vars.arrayRisposteAll[1], 3 + 13, 2))
        variabileDiAppoggio = arrayToData(vars.arrayRisposteAll[1], 3 + 35, 2) / getFattoreDivisioneSonda(5, numeroSondaConversione);// 
        testoDiAppoggio = variabileDiAppoggio.toFixed(getNumeroDecimaliSonda(5, numeroSondaConversione));
        testoUnitaDiAppoggio = getValoreLabelJson(5, numeroSondaConversione);
        $("#setpointUscitaSetpoint").val(testoDiAppoggio)
        $("#setpointUscitaUnit").text(testoUnitaDiAppoggio)
        costruisciTextBoxListaSonde("#setpointUscitaSetpoint", testoUnitaDiAppoggio, 5, numeroSondaConversione)

        $("#setpointUscitaDelayMin> [value=" + arrayToData(vars.arrayRisposteAll[1], 3 + 43, 2).toString() + "]").prop("selected", true)
        $("#setpointUscitaDelaySec> [value=" + arrayToData(vars.arrayRisposteAll[1], 3 + 45, 2).toString() + "]").prop("selected", true)

        if (arrayToData(vars.arrayRisposteAll[1], 3 + 39, 2)) //lavaggio
        {
            $("#setpointUscitaAfterWash").prop("checked", true)
        }
        else {
            $("#setpointUscitaAfterWash").prop("checked", false)
        }

        if (arrayToData(vars.arrayRisposteAll[1], 3 + 41, 2)) //stop
        {
            $("#setpointUscitaStop").prop("checked", true)
        }
        else {
            $("#setpointUscitaStop").prop("checked", false)
        }
        // --- end Setpoint Condicibilità Uscita
        // --- Setpoint Temperatura
        if (arrayToData(vars.arrayRisposteAll[1], 3 + 51, 2)) //setpoint abilitato
        {
            $("#setpointTemperaturaEnable").prop("checked", true)
            $("#setpointTemperaturaGroup").show();
        }
        else {
            $("#setpointTemperaturaEnable").prop("checked", false)
            $("#setpointTemperaturaGroup").hide();
        }

        variabileDiAppoggio = arrayToData(vars.arrayRisposteAll[1], 3 + 49, 2) / 10;// 
        testoDiAppoggio = variabileDiAppoggio.toFixed(1);
        testoUnitaDiAppoggio = arrayToData(vars.arrayRisposteAll[1], 3 + 115, 2) == 0 ? "°C" : "°F";
        $("#setpointTemperaturaSetpoint").val(testoDiAppoggio)
        $("#setpointTemperaturaUnit").text(testoUnitaDiAppoggio)

        $("#setpointTemperaturaDelayMin> [value=" + arrayToData(vars.arrayRisposteAll[1], 3 + 57, 2).toString() + "]").prop("selected", true)
        $("#setpointTemperaturaDelaySec> [value=" + arrayToData(vars.arrayRisposteAll[1], 3 + 59, 2).toString() + "]").prop("selected", true)

        if (arrayToData(vars.arrayRisposteAll[1], 3 + 55, 2)) //stop
        {
            $("#setpointTemperaturaStop").prop("checked", true)
        }
        else {
            $("#setpointTemperaturaStop").prop("checked", false)
        }

        // --- end Setpoint Temperatura
        // --- impostazione ingressi
        //livelli
        setStatusIngressi("inputLevelLow", arrayToData(vars.arrayRisposteAll[1], 3 + 63, 2), arrayToData(vars.arrayRisposteAll[1], 3 + 65, 2), arrayToData(vars.arrayRisposteAll[1], 3 + 67, 2))
        setStatusIngressi("inputLevelHigh", arrayToData(vars.arrayRisposteAll[1], 3 + 71, 2), arrayToData(vars.arrayRisposteAll[1], 3 + 73, 2), arrayToData(vars.arrayRisposteAll[1], 3 + 75, 2))
        //pressione
        setStatusIngressi("inputPressureMin", arrayToData(vars.arrayRisposteAll[1], 3 + 79, 2), arrayToData(vars.arrayRisposteAll[1], 3 + 81, 2), arrayToData(vars.arrayRisposteAll[1], 3 + 83, 2))
        $("#inputPressureRetry").val(arrayToData(vars.arrayRisposteAll[1], 3 + 85, 2).toString())
        if (arrayToData(vars.arrayRisposteAll[1], 3 + 87, 2)) //stop
        {
            $("#inputPressureMinWash").prop("checked", true)
        }
        else {
            $("#inputPressureMinWash").prop("checked", false)
        }

        setStatusIngressi("inputPressureMax", arrayToData(vars.arrayRisposteAll[1], 3 + 91, 2), arrayToData(vars.arrayRisposteAll[1], 3 + 93, 2), arrayToData(vars.arrayRisposteAll[1], 3 + 95, 2))
        //temp pompa
        setStatusIngressi("inputTempPump", arrayToData(vars.arrayRisposteAll[1], 3 + 99, 2), arrayToData(vars.arrayRisposteAll[1], 3 + 101, 2), arrayToData(vars.arrayRisposteAll[1], 3 + 103, 2))
        //filter
        setStatusIngressi("inputFilter", arrayToData(vars.arrayRisposteAll[1], 3 + 107, 2), arrayToData(vars.arrayRisposteAll[1], 3 + 109, 2), arrayToData(vars.arrayRisposteAll[1], 3 + 111, 2))
        //generale
        setStatusIngressi("inputGeneral", arrayToData(vars.arrayRisposteAll[2], 3 + 103, 2), arrayToData(vars.arrayRisposteAll[2], 3 + 105, 2), arrayToData(vars.arrayRisposteAll[2], 3 + 107, 2))
        var maiText = "";
        var shiftIndex = 0;
        for (shiftIndex = 0; shiftIndex < 8; shiftIndex++) {
            if (arrayToData(vars.arrayRisposteAll[2], 3 + 109 + shiftIndex, 1) > 0)
                maiText = maiText + String.fromCharCode(arrayToData(vars.arrayRisposteAll[2], 3 + 109 + shiftIndex, 1))
        }
        maiText = maiText.replaceAll(" ", "")
        $("#inputGeneralLabel").val(maiText)
        //standby
        setStatusIngressi("inputStandby", arrayToData(vars.arrayRisposteAll[2], 3 + 1, 2), arrayToData(vars.arrayRisposteAll[2], 3 + 3, 2), arrayToData(vars.arrayRisposteAll[2], 3 + 5, 2))
        //water meter input
        if (arrayToData(vars.arrayRisposteAll[2], 3 + 9, 2)) //water meter input abilitato
        {
            $("#inputWaterMeterInputEnable").prop("checked", true)
            $("#inputWaterMeterInputGroup").show();
        }
        else {
            $("#inputWaterMeterInputEnable").prop("checked", false)
            $("#inputWaterMeterInputGroup").hide();
        }
        $("#inputWaterMeterInputSetpoint> [value=" + arrayToData(vars.arrayRisposteAll[2], 3 + 11, 2).toString() + "]").prop("selected", true)
        variabileDiAppoggio = arrayToData(vars.arrayRisposteAll[2], 3 + 13, 4) / 100;// 
        $("#inputWaterMeterInputKSetpoint").val(variabileDiAppoggio.toFixed(2))
        variabileDiAppoggio = arrayToData(vars.arrayRisposteAll[2], 3 + 17, 2)
        $("#inputWaterMeterInputTimeoutSetpoint").val(variabileDiAppoggio.toString())
        //water meter output
        if (arrayToData(vars.arrayRisposteAll[2], 3 + 21, 2)) //water meter output abilitato
        {
            $("#inputWaterMeterOutputEnable").prop("checked", true)
            $("#inputWaterMeterOutputGroup").show();
        }
        else {
            $("#inputWaterMeterOutputEnable").prop("checked", false)
            $("#inputWaterMeterOutputGroup").hide();
        }
        $("#inputWaterMeterOutputSetpoint> [value=" + arrayToData(vars.arrayRisposteAll[2], 3 + 23, 2).toString() + "]").prop("selected", true)
        variabileDiAppoggio = arrayToData(vars.arrayRisposteAll[2], 3 + 25, 4) / 100;// 
        $("#inputWaterMeterOutputKSetpoint").val(variabileDiAppoggio.toFixed(2))
        variabileDiAppoggio = arrayToData(vars.arrayRisposteAll[2], 3 + 29, 2)
        $("#inputWaterMeterOutputTimeoutSetpoint").val(variabileDiAppoggio.toString())

        //allarme dosaggio
        setStatusIngressi("inputDosingAlarm", arrayToData(vars.arrayRisposteAll[2], 3 + 33, 2), arrayToData(vars.arrayRisposteAll[2], 3 + 35, 2), arrayToData(vars.arrayRisposteAll[2], 3 + 37, 2))
        // --- end impostazione ingressi

        //impostazione allarme
        if (arrayToData(vars.arrayRisposteAll[2], 3 + 41, 2)) //water meter output abilitato
        {
            $("#alarmSettingsEnable").prop("checked", true)
            $("#alarmSettingsGroup").show();
        }
        else {
            $("#alarmSettingsEnable").prop("checked", false)
            $("#alarmSettingsGroup").hide();
        }
        $("#alarmSettingsContact> [value=" + arrayToData(vars.arrayRisposteAll[2], 3 + 43, 2).toString() + "]").prop("selected", true)

        //--- end impostazione allarme
        //impostazione wash
        if (arrayToData(vars.arrayRisposteAll[2], 3 + 47, 2)) //wash abilitato
        {
            $("#washSettingsEnable").prop("checked", true)
            $("#washSettingsGroup").show();
        }
        else {
            $("#washSettingsEnable").prop("checked", false)
            $("#washSettingsGroup").hide();
        }
        if (arrayToData(vars.arrayRisposteAll[2], 3 + 51, 2)) //ev
        {
            $("#washEvInSettingsEnable").prop("checked", true)
        }
        else {
            $("#washEvInSettingsEnable").prop("checked", false)
        }
        if (arrayToData(vars.arrayRisposteAll[2], 3 + 49, 2)) //pump
        {
            $("#washPumpSettingsEnable").prop("checked", true)
        }
        else {
            $("#washPumpSettingsEnable").prop("checked", false)
        }
        $("#washPumpSettingsStartProdMin> [value=" + arrayToData(vars.arrayRisposteAll[2], 3 + 53, 2).toString() + "]").prop("selected", true)
        $("#washPumpSettingsStartProdSec> [value=" + arrayToData(vars.arrayRisposteAll[2], 3 + 55, 2).toString() + "]").prop("selected", true)

        $("#washPumpSettingsEndProdMin> [value=" + arrayToData(vars.arrayRisposteAll[2], 3 + 57, 2).toString() + "]").prop("selected", true)
        $("#washPumpSettingsEndProdSec> [value=" + arrayToData(vars.arrayRisposteAll[2], 3 + 59, 2).toString() + "]").prop("selected", true)

        variabileDiAppoggio = arrayToData(vars.arrayRisposteAll[2], 3 + 61, 2)
        $("#washPumpSettingsCycleHr").val(variabileDiAppoggio.toString())
        $("#washPumpSettingsCycleMin> [value=" + arrayToData(vars.arrayRisposteAll[2], 3 + 63, 2).toString() + "]").prop("selected", true)
        $("#washPumpSettingsCycleSec> [value=" + arrayToData(vars.arrayRisposteAll[2], 3 + 65, 2).toString() + "]").prop("selected", true)

        variabileDiAppoggio = arrayToData(vars.arrayRisposteAll[2], 3 + 67, 2)
        $("#washPumpSettingsRinsingHr").val(variabileDiAppoggio.toString())
        $("#washPumpSettingsRinsingMin> [value=" + arrayToData(vars.arrayRisposteAll[2], 3 + 69, 2).toString() + "]").prop("selected", true)
        $("#washPumpSettingsRinsingSec> [value=" + arrayToData(vars.arrayRisposteAll[2], 3 + 71, 2).toString() + "]").prop("selected", true)
        //end impostazione wash

        //impostazione delay
        variabileDiAppoggio = arrayToData(vars.arrayRisposteAll[2], 3 + 75, 2)
        $("#delaySettingsPumpOn").val(variabileDiAppoggio.toString())
        variabileDiAppoggio = arrayToData(vars.arrayRisposteAll[2], 3 + 77, 2)
        $("#delaySettingsEvInOff").val(variabileDiAppoggio.toString())
        variabileDiAppoggio = arrayToData(vars.arrayRisposteAll[2], 3 + 79, 2)
        $("#delaySettingsDosingOn").val(variabileDiAppoggio.toString())
        variabileDiAppoggio = arrayToData(vars.arrayRisposteAll[2], 3 + 79, 2)
        $("#delaySettingsPumpOff").val(variabileDiAppoggio.toString())

        //-- end impostazione delay
        //impostazione manutenzione
        if (arrayToData(vars.arrayRisposteAll[2], 3 + 95, 2)) //
        {
            $("#manutenzioneMsg").prop("checked", true)
        }
        else {
            $("#manutenzioneMsg").prop("checked", false)
        }
        variabileDiAppoggio = arrayToData(vars.arrayRisposteAll[2], 3 + 93, 2)
        $("#manutenzioneRange").val(variabileDiAppoggio.toString())
        if (arrayToData(vars.arrayRisposteAll[2], 3 + 99, 2)) //
        {
            $("#manutenzioneResetServ").prop("checked", true)
        }
        else {
            $("#manutenzioneResetServ").prop("checked", false)
        }
        if (arrayToData(vars.arrayRisposteAll[2], 3 + 101, 2)) //
        {
            $("#manutenzioneResetHr").prop("checked", true)
        }
        else {
            $("#manutenzioneResetHr").prop("checked", false)
        }
        //-- end impostazione manutenzione
        //date time
        $("#formatTime> [value=" + arrayToData(vars.arrayRisposteAll[1], 3 + 115, 2).toString() + "]").prop("selected", true)
        $("#dateSetpoint").val(makeData(arrayToData(vars.arrayRisposteAll[1], 3 + 119, 2), arrayToData(vars.arrayRisposteAll[1], 3 + 121, 2), arrayToData(vars.arrayRisposteAll[1], 3 + 123, 2), arrayToData(vars.arrayRisposteAll[1], 3 + 115, 2)))
        alarmDateFormat(arrayToData(vars.arrayRisposteAll[1], 3 + 115, 2));
        $("#timeSetpoint").val(makeOre(arrayToData(vars.arrayRisposteAll[1], 3 + 125, 2), arrayToData(vars.arrayRisposteAll[1], 3 + 127, 2), arrayToData(vars.arrayRisposteAll[1], 3 + 115, 2), arrayToData(vars.arrayRisposteAll[1], 3 + 117, 2))); //time

        //--- end date time
        //setpoint uscita in corrente
        //ingresso
        $("#outMAOutput1Settings> [value=" + arrayToData(vars.arrayRisposteAll[2], 3 + 119, 2).toString() + "]").prop("selected", true)
        numeroSondaConversione = conversioneSondaConducibilita(arrayToData(vars.arrayRisposteAll[1], 3 + 3, 2))

        variabileDiAppoggio = arrayToData(vars.arrayRisposteAll[2], 3 + 121, 2) / getFattoreDivisioneSonda(5, numeroSondaConversione);// 

        testoDiAppoggio = variabileDiAppoggio.toFixed(getNumeroDecimaliSonda(5, numeroSondaConversione));
        testoUnitaDiAppoggio = getValoreLabelJson(5, numeroSondaConversione);
        $("#outMAOutput1MaMAxSetpoint").val(testoDiAppoggio)
        $("#outMAOutput1MaMAxUnit").text(testoUnitaDiAppoggio)
        costruisciTextBoxListaSonde("#outMAOutput1MaMAxSetpoint", testoUnitaDiAppoggio, 5, numeroSondaConversione)

        variabileDiAppoggio = arrayToData(vars.arrayRisposteAll[2], 3 + 123, 2) / getFattoreDivisioneSonda(5, numeroSondaConversione);// 
        testoDiAppoggio = variabileDiAppoggio.toFixed(getNumeroDecimaliSonda(5, numeroSondaConversione));
        testoUnitaDiAppoggio = getValoreLabelJson(5, numeroSondaConversione);
        $("#outMAOutput1MaMinSetpoint").val(testoDiAppoggio)
        $("#outMAOutput1MaMinUnit").text(testoUnitaDiAppoggio)
        costruisciTextBoxListaSonde("#outMAOutput1MaMinSetpoint", testoUnitaDiAppoggio, 5, numeroSondaConversione)

        if (arrayToData(vars.arrayRisposteAll[2], 3 + 125, 2)) //
        {
            $("#outMAOutput1MaMinAlarm").prop("checked", true)
        }
        else {
            $("#outMAOutput1MaMinAlarm").prop("checked", false)
        }
        //---end ingresso
        //uscita
        $("#outMAOutput2Settings> [value=" + arrayToData(vars.arrayRisposteAll[2], 3 + 129, 2).toString() + "]").prop("selected", true)
        numeroSondaConversione = conversioneSondaConducibilita(arrayToData(vars.arrayRisposteAll[1], 3 + 13, 2))

        variabileDiAppoggio = arrayToData(vars.arrayRisposteAll[2], 3 + 131, 2) / getFattoreDivisioneSonda(5, numeroSondaConversione);// 
        testoDiAppoggio = variabileDiAppoggio.toFixed(getNumeroDecimaliSonda(5, numeroSondaConversione));
        testoUnitaDiAppoggio = getValoreLabelJson(5, numeroSondaConversione);
        $("#outMAOutput2MaMAxSetpoint").val(testoDiAppoggio)
        $("#outMAOutput2MaMAxUnit").text(testoUnitaDiAppoggio)
        costruisciTextBoxListaSonde("#outMAOutput2MaMAxSetpoint", testoUnitaDiAppoggio, 5, numeroSondaConversione)

        variabileDiAppoggio = arrayToData(vars.arrayRisposteAll[2], 3 + 133, 2) / getFattoreDivisioneSonda(5, numeroSondaConversione);// 
        testoDiAppoggio = variabileDiAppoggio.toFixed(getNumeroDecimaliSonda(5, numeroSondaConversione));
        testoUnitaDiAppoggio = getValoreLabelJson(5, numeroSondaConversione);
        $("#outMAOutput2MaMinSetpoint").val(testoDiAppoggio)
        $("#outMAOutput2MaMinUnit").text(testoUnitaDiAppoggio)
        costruisciTextBoxListaSonde("#outMAOutput2MaMinSetpoint", testoUnitaDiAppoggio, 5, numeroSondaConversione)

        if (arrayToData(vars.arrayRisposteAll[2], 3 + 135, 2)) //
        {
            $("#outMAOutput2MaMinAlarm").prop("checked", true)
        }
        else {
            $("#outMAOutput2MaMinAlarm").prop("checked", false)
        }
        //---end uscita
        //end setpoint uscita in corrente
        //setpoint log setup
        if (arrayToData(vars.arrayRisposteAll[1], 3 + 131, 2)) //wash abilitato
        {
            $("#logSettingsEnable").prop("checked", true)
            $("#logSettingsGroup").show();
        }
        else {
            $("#logSettingsEnable").prop("checked", false)
            $("#logSettingsGroup").hide();
        }
        $("#logSettingsHour> [value=" + arrayToData(vars.arrayRisposteAll[1], 3 + 133, 2).toString() + "]").prop("selected", true)
        $("#logSettingsMin> [value=" + arrayToData(vars.arrayRisposteAll[1], 3 + 135, 2).toString() + "]").prop("selected", true)

        //--- end setpoint log setup
        //message settings
        var maiText = "";
        //sms
        maiText = ""
        for (shiftIndex = 0; shiftIndex < 14; shiftIndex++) {
            if (arrayToData(vars.arrayRisposteAll[3], 3 + 67 + shiftIndex, 1) > 0)
                maiText = maiText + String.fromCharCode(arrayToData(vars.arrayRisposteAll[3], 3 + 67 + shiftIndex, 1))
        }
        maiText = maiText.replaceAll(" ", "")
        $("#sms1Alarm").val(maiText)
        maiText = ""
        for (shiftIndex = 0; shiftIndex < 14; shiftIndex++) {
            if (arrayToData(vars.arrayRisposteAll[3], 3 + 81 + shiftIndex, 1) > 0)
                maiText = maiText + String.fromCharCode(arrayToData(vars.arrayRisposteAll[3], 3 + 81 + shiftIndex, 1))
        }
        maiText = maiText.replaceAll(" ", "")
        $("#sms2Alarm").val(maiText)
      /*  maiText = ""
        for (shiftIndex = 0; shiftIndex < 14; shiftIndex++) {
            if (arrayToData(vars.arrayRisposteAll[3], 3 + 95 + shiftIndex, 1) > 0)
                maiText = maiText + String.fromCharCode(arrayToData(vars.arrayRisposteAll[3], 3 + 95 + shiftIndex, 1))
        }
        maiText = maiText.replaceAll(" ", "")
        $("#sms3Alarm").val(maiText)
        */
        //mail
        maiText = ""
        for (shiftIndex = 0; shiftIndex < 33; shiftIndex++) {
            if (arrayToData(vars.arrayRisposteAll[3], 3 + 1 + shiftIndex, 1) > 0)
                maiText = maiText + String.fromCharCode(arrayToData(vars.arrayRisposteAll[3], 3 + 1 + shiftIndex, 1))
        }
        maiText = maiText.replaceAll(" ", "")
        $("#mail1Alarm").val(maiText)
        maiText = ""
        for (shiftIndex = 0; shiftIndex < 33; shiftIndex++) {
            if (arrayToData(vars.arrayRisposteAll[3], 3 + 34 + shiftIndex, 1) > 0)
                maiText = maiText + String.fromCharCode(arrayToData(vars.arrayRisposteAll[3], 3 + 34 + shiftIndex, 1))
        }
        maiText = maiText.replaceAll(" ", "")
        $("#mail2Alarm").val(maiText)

        var shiftIndex = 0;
        var shiftOperation = arrayToData(vars.arrayRisposteAll[3], 3 + 95, 2)
        
        for (shiftIndex = 0; shiftIndex < 11; shiftIndex++) {
            var checkedTemp = false;
            if (shiftOperation & 1) {
                checkedTemp = true;
            }
            switch (shiftIndex) {
                case 0:
                    $("#highConductivityOutputEnable").prop("checked", checkedTemp)
                    break;
                case 1:
                    $("#highConductivityInputEnable").prop("checked", checkedTemp)
                    break;
                case 2:
                    $("#highTemperatureEnable").prop("checked", checkedTemp)
                    break;
                case 3:
                    $("#inputTempPump1Enable").prop("checked", checkedTemp)
                    break;
                case 4:
                    $("#inputPressureHighEnable").prop("checked", checkedTemp)
                    break;

                case 5:
                    $("#inputPressureLowEnable").prop("checked", checkedTemp)
                    break;
                case 6:
                    $("#inputStbyEnable").prop("checked", checkedTemp)
                    break;
                case 7:
                    $("#inputDosingAlarm1Enable").prop("checked", checkedTemp)
                    break;
                case 8:
                    $("#inputFilter1Enable").prop("checked", checkedTemp)
                    break;
                case 9:
                    $("#genericAlarmEnable").prop("checked", checkedTemp)
                    break;
                case 10:
                    $("#inputLevelEnable").prop("checked", checkedTemp)
                    break;

            }
            shiftOperation = shiftOperation >> 1;
        }
        //-- end message settings
        //--gestione action
        if (arrayToData(vars.arrayRisposteAll[0], 3 + 1, 2)) //wash abilitato
        {
            $("#actionOnOff").prop("checked", true)
            $("#actionOnLabel").show();
            $("#actionOffLabel").hide();
        }
        else {
            $("#actionOnOff").prop("checked", false)
            $("#actionOnLabel").hide();
            $("#actionOffLabel").show();
        }


        //--end gestione action
    }
    /*-------------------------invio dati*/
    $("#setpointIngressoSend").click(function () {
        var arrayData = [];
        var valoreInviare = 0;
        var numeroSondaConversione = 0;
        varsInternal.arraySendData = [];
        
        numeroSondaConversione = conversioneSondaConducibilita(arrayToData(vars.arrayRisposteAll[1], 3 + 3, 2))
        valoreInviare = Math.floor(parseFloat($("#setpointIngressoSetpoint").val()) * getFattoreDivisioneSonda(5, numeroSondaConversione));
        arrayData = addDataToArray(arrayData, parseInt(valoreInviare), 2);

        if ($("#setpointIngressoEnable").is(':checked'))
            arrayData = addDataToArray(arrayData, 1, 2);//enable
        else
            arrayData = addDataToArray(arrayData, 0, 2);//disable

        arrayData = addDataToArray(arrayData, 0, 2);//option, metto a zero nel caso del setpoint in ingreso

        if ($("#setpointIngressoStop").is(':checked'))
            arrayData = addDataToArray(arrayData, 1, 2);//stop 
        else
            arrayData = addDataToArray(arrayData, 0, 2);//stop

        arrayData = addDataToArray(arrayData, parseInt($("#setpointIngressoDelayMin").val()), 2); //durata Ore
        arrayData = addDataToArray(arrayData, parseInt($("#setpointIngressoDelaySec").val()), 2); //durata Minuti

        varsInternal.arraySendData.push(makeArraySend(0x01, arrayData));//comando fine scrittura

        sendDataAnimation("setpointIngresso");

        
    });
    $("#setpointUscitaSend").click(function () {
        var arrayData = [];
        var valoreInviare = 0;
        var numeroSondaConversione = 0;
        varsInternal.arraySendData = [];

        numeroSondaConversione = conversioneSondaConducibilita(arrayToData(vars.arrayRisposteAll[1], 3 + 13, 2))
        valoreInviare = Math.floor(parseFloat($("#setpointUscitaSetpoint").val()) * getFattoreDivisioneSonda(5, numeroSondaConversione));
        arrayData = addDataToArray(arrayData, parseInt(valoreInviare), 2);

        if ($("#setpointUscitaEnable").is(':checked'))
            arrayData = addDataToArray(arrayData, 1, 2);//enable
        else
            arrayData = addDataToArray(arrayData, 0, 2);//disable

        if ($("#setpointUscitaAfterWash").is(':checked'))
            arrayData = addDataToArray(arrayData, 1, 2);//after wash
        else
            arrayData = addDataToArray(arrayData, 0, 2);//after wash

        if ($("#setpointUscitaStop").is(':checked'))
            arrayData = addDataToArray(arrayData, 1, 2);//stop 
        else
            arrayData = addDataToArray(arrayData, 0, 2);//stop

        arrayData = addDataToArray(arrayData, parseInt($("#setpointUscitaDelayMin").val()), 2); //durata Ore
        arrayData = addDataToArray(arrayData, parseInt($("#setpointUscitaDelaySec").val()), 2); //durata Minuti

        varsInternal.arraySendData.push(makeArraySend(0x02, arrayData));//comando fine scrittura

        sendDataAnimation("setpointUscita");
    });
    $("#setpointTemperaturaSend").click(function () {
        var arrayData = [];
        var valoreInviare = 0;
        var numeroSondaConversione = 0;
        varsInternal.arraySendData = [];

        //numeroSondaConversione = conversioneSondaConducibilita(arrayToData(vars.arrayRisposteAll[1], 3 + 3, 2))
        valoreInviare = Math.floor(parseFloat($("#setpointTemperaturaSetpoint").val()) * 10);
        arrayData = addDataToArray(arrayData, parseInt(valoreInviare), 2);

        if ($("#setpointTemperaturaEnable").is(':checked'))
            arrayData = addDataToArray(arrayData, 1, 2);//enable
        else
            arrayData = addDataToArray(arrayData, 0, 2);//disable

        arrayData = addDataToArray(arrayData, 0, 2);//option, metto a zero nel caso del setpoint in ingreso

        if ($("#setpointTemperaturaStop").is(':checked'))
            arrayData = addDataToArray(arrayData, 1, 2);//stop 
        else
            arrayData = addDataToArray(arrayData, 0, 2);//stop

        arrayData = addDataToArray(arrayData, parseInt($("#setpointTemperaturaDelayMin").val()), 2); //durata Ore
        arrayData = addDataToArray(arrayData, parseInt($("#setpointTemperaturaDelaySec").val()), 2); //durata Minuti

        varsInternal.arraySendData.push(makeArraySend(0x03, arrayData));//comando fine scrittura

        sendDataAnimation("setpointTemperatura");


    });
    $("#inputLevelSend").click(function () {
        var arrayData = [];
        if ($("#inputLevelLowEnable").is(':checked'))
            arrayData = addDataToArray(arrayData, 1, 2);//enable
        else
            arrayData = addDataToArray(arrayData, 0, 2);//disable
        arrayData = addDataToArray(arrayData, parseInt($("#inputLevelLowContact").val()), 2); //contact
        arrayData = addDataToArray(arrayData, parseInt($("#inputLevelLowDelaySec").val()), 2); //delay
        arrayData = addDataToArray(arrayData, 0, 2);//checksum poi ricalcolata dalla centralina

        if ($("#inputLevelHighEnable").is(':checked'))
            arrayData = addDataToArray(arrayData, 1, 2);//enable
        else
            arrayData = addDataToArray(arrayData, 0, 2);//disable
        arrayData = addDataToArray(arrayData, parseInt($("#inputLevelHighContact").val()), 2); //contact
        arrayData = addDataToArray(arrayData, parseInt($("#inputLevelHighDelaySec").val()), 2); //delay

        varsInternal.arraySendData.push(makeArraySend(0x04, arrayData));//comando fine scrittura
        sendDataAnimation("inputLevel");
    });

    $("#inputPressureSend").click(function () {
        var arrayData = [];

        if ($("#inputPressureMinEnable").is(':checked'))
            arrayData = addDataToArray(arrayData, 1, 2);//enable
        else
            arrayData = addDataToArray(arrayData, 0, 2);//disable
        arrayData = addDataToArray(arrayData, parseInt($("#inputPressureMinContact").val()), 2); //contact
        arrayData = addDataToArray(arrayData, parseInt($("#inputPressureMinDelaySec").val()), 2); //delay
        arrayData = addDataToArray(arrayData, parseInt($("#inputPressureRetry").val()), 2); //retry
        if ($("#inputPressureMinWash").is(':checked'))
            arrayData = addDataToArray(arrayData, 1, 2);//enable
        else
            arrayData = addDataToArray(arrayData, 0, 2);//disable
        arrayData = addDataToArray(arrayData, 0, 2);//checksum poi ricalcolata dalla centralina

        if ($("#inputPressureMaxEnable").is(':checked'))
            arrayData = addDataToArray(arrayData, 1, 2);//enable
        else
            arrayData = addDataToArray(arrayData, 0, 2);//disable
        arrayData = addDataToArray(arrayData, parseInt($("#inputPressureMaxContact").val()), 2); //contact
        arrayData = addDataToArray(arrayData, parseInt($("#inputPressureMaxDelaySec").val()), 2); //delay

        varsInternal.arraySendData.push(makeArraySend(0x05, arrayData));//comando fine scrittura
        sendDataAnimation("inputPressure");
    });
    $("#inputTempPumpSend").click(function () {
        var arrayData = [];
        if ($("#inputTempPumpEnable").is(':checked'))
            arrayData = addDataToArray(arrayData, 1, 2);//enable
        else
            arrayData = addDataToArray(arrayData, 0, 2);//disable
        arrayData = addDataToArray(arrayData, parseInt($("#inputTempPumpContact").val()), 2); //contact
        arrayData = addDataToArray(arrayData, parseInt($("#inputTempPumpDelaySec").val()), 2); //delay

        varsInternal.arraySendData.push(makeArraySend(0x06, arrayData));//comando fine scrittura
        sendDataAnimation("inputTempPump");
    });
    $("#inputFilterSend").click(function () {
        var arrayData = [];
        if ($("#inputFilterEnable").is(':checked'))
            arrayData = addDataToArray(arrayData, 1, 2);//enable
        else
            arrayData = addDataToArray(arrayData, 0, 2);//disable
        arrayData = addDataToArray(arrayData, parseInt($("#inputFilterContact").val()), 2); //contact
        arrayData = addDataToArray(arrayData, parseInt($("#inputFilterDelaySec").val()), 2); //delay

        varsInternal.arraySendData.push(makeArraySend(0x07, arrayData));//comando fine scrittura
        sendDataAnimation("inputFilterPump");
    });
    $("#inputGeneralSend").click(function () {
        var arrayData = [];
        if ($("#inputGeneralEnable").is(':checked'))
            arrayData = addDataToArray(arrayData, 1, 2);//enable
        else
            arrayData = addDataToArray(arrayData, 0, 2);//disable
        arrayData = addDataToArray(arrayData, parseInt($("#inputGeneralContact").val()), 2); //contact
        arrayData = addDataToArray(arrayData, parseInt($("#inputGeneralDelaySec").val()), 2); //delay

        var mailSend = $("#inputGeneralLabel").val()
        for (indiceInviare = 0; indiceInviare < 10; indiceInviare++) {
            var code = 0
            if (indiceInviare < mailSend.length)
                code = mailSend.charCodeAt(indiceInviare);

            arrayData = addDataToArray(arrayData, code, 1);
        }

        varsInternal.arraySendData.push(makeArraySend(0x08, arrayData));//comando fine scrittura
        sendDataAnimation("inputGeneral");
    });
    $("#inputStandbySend").click(function () {
        var arrayData = [];
        if ($("#inputStandbyEnable").is(':checked'))
            arrayData = addDataToArray(arrayData, 1, 2);//enable
        else
            arrayData = addDataToArray(arrayData, 0, 2);//disable
        arrayData = addDataToArray(arrayData, parseInt($("#inputStandbyContact").val()), 2); //contact
        arrayData = addDataToArray(arrayData, parseInt($("#inputStandbyDelaySec").val()), 2); //delay


        varsInternal.arraySendData.push(makeArraySend(0x09, arrayData));//comando fine scrittura
        sendDataAnimation("inputStandby");

    });
    $("#inputWaterMeterSend").click(function () {
        var arrayData = [];
        var valoreInviare = 0;
        if ($("#inputWaterMeterInputEnable").is(':checked'))
            arrayData = addDataToArray(arrayData, 1, 2);//enable
        else
            arrayData = addDataToArray(arrayData, 0, 2);//disable
        arrayData = addDataToArray(arrayData, parseInt($("#inputWaterMeterInputSetpoint").val()), 2); //contact
        valoreInviare = Math.floor(parseFloat($("#inputWaterMeterInputKSetpoint").val()) * 100);
        arrayData = addDataToArray(arrayData, parseInt(valoreInviare), 4);
        arrayData = addDataToArray(arrayData, parseInt($("#inputWaterMeterInputTimeoutSetpoint").val()), 2);
        arrayData = addDataToArray(arrayData, 0, 2);//checksum poi ricalcolata dalla centralina

        if ($("#inputWaterMeterOutputEnable").is(':checked'))
            arrayData = addDataToArray(arrayData, 1, 2);//enable
        else
            arrayData = addDataToArray(arrayData, 0, 2);//disable
        arrayData = addDataToArray(arrayData, parseInt($("#inputWaterMeterOutputSetpoint").val()), 2); //contact
        valoreInviare = Math.floor(parseFloat($("#inputWaterMeterOutputKSetpoint").val()) * 100);
        arrayData = addDataToArray(arrayData, parseInt(valoreInviare), 4);
        arrayData = addDataToArray(arrayData, parseInt($("#inputWaterMeterOutputTimeoutSetpoint").val()), 2);


        varsInternal.arraySendData.push(makeArraySend(0x0A, arrayData));//comando fine scrittura
        sendDataAnimation("inputWaterMeter");

    });
    $("#inputDosingAlarmSend").click(function () {
        var arrayData = [];
        if ($("#inputDosingAlarmEnable").is(':checked'))
            arrayData = addDataToArray(arrayData, 1, 2);//enable
        else
            arrayData = addDataToArray(arrayData, 0, 2);//disable
        arrayData = addDataToArray(arrayData, parseInt($("#inputDosingAlarmContact").val()), 2); //contact
        arrayData = addDataToArray(arrayData, parseInt($("#inputDosingAlarmDelaySec").val()), 2); //delay


        varsInternal.arraySendData.push(makeArraySend(0x0B, arrayData));//comando fine scrittura
        sendDataAnimation("inputDosingAlarm");

    });

    $("#alarmSettingsSend").click(function () {
        var arrayData = [];
        if ($("#alarmSettingsEnable").is(':checked'))
            arrayData = addDataToArray(arrayData, 1, 2);//enable
        else
            arrayData = addDataToArray(arrayData, 0, 2);//disable
        arrayData = addDataToArray(arrayData, parseInt($("#alarmSettingsContact").val()), 2); //contact

        varsInternal.arraySendData.push(makeArraySend(0x0C, arrayData));//comando fine scrittura
        sendDataAnimation("alarmSettings");

    });
    $("#washPumpSettingsSend").click(function () {
        var arrayData = [];
        if ($("#washSettingsEnable").is(':checked'))
            arrayData = addDataToArray(arrayData, 1, 2);//enable
        else
            arrayData = addDataToArray(arrayData, 0, 2);//disable

        if ($("#washPumpSettingsEnable").is(':checked'))
            arrayData = addDataToArray(arrayData, 1, 2);//enable
        else
            arrayData = addDataToArray(arrayData, 0, 2);//disable

        if ($("#washEvInSettingsEnable").is(':checked'))
            arrayData = addDataToArray(arrayData, 1, 2);//enable
        else
            arrayData = addDataToArray(arrayData, 0, 2);//disable

        arrayData = addDataToArray(arrayData, parseInt($("#washPumpSettingsStartProdMin").val()), 2); //contact
        arrayData = addDataToArray(arrayData, parseInt($("#washPumpSettingsStartProdSec").val()), 2); //contact

        arrayData = addDataToArray(arrayData, parseInt($("#washPumpSettingsEndProdMin").val()), 2); //contact
        arrayData = addDataToArray(arrayData, parseInt($("#washPumpSettingsEndProdSec").val()), 2); //contact

        arrayData = addDataToArray(arrayData, parseInt($("#washPumpSettingsCycleHr").val()), 2); //period
        arrayData = addDataToArray(arrayData, parseInt($("#washPumpSettingsCycleMin").val()), 2); //contact
        arrayData = addDataToArray(arrayData, parseInt($("#washPumpSettingsCycleSec").val()), 2); //contact

        arrayData = addDataToArray(arrayData, parseInt($("#washPumpSettingsRinsingHr").val()), 2); //period
        arrayData = addDataToArray(arrayData, parseInt($("#washPumpSettingsRinsingMin").val()), 2); //contact
        arrayData = addDataToArray(arrayData, parseInt($("#washPumpSettingsRinsingSec").val()), 2); //contact

        varsInternal.arraySendData.push(makeArraySend(0x0D, arrayData));//comando fine scrittura
        sendDataAnimation("washPumpSettings");

    });
    $("#delaySettingsSend").click(function () {
        var arrayData = [];

        arrayData = addDataToArray(arrayData, parseInt($("#delaySettingsPumpOn").val()), 2); //contact
        arrayData = addDataToArray(arrayData, parseInt($("#delaySettingsEvInOff").val()), 2); //contact
        arrayData = addDataToArray(arrayData, parseInt($("#delaySettingsDosingOn").val()), 2); //contact
        arrayData = addDataToArray(arrayData, parseInt($("#delaySettingsPumpOff").val()), 2); //contact

        varsInternal.arraySendData.push(makeArraySend(0x0E, arrayData));//comando fine scrittura
        sendDataAnimation("delaySettings");

    });

    $("#manutenzioneSettingsSend").click(function () {
        var arrayData = [];

        arrayData = addDataToArray(arrayData, parseInt($("#manutenzioneRange").val()), 2); //contact
        if ($("#manutenzioneMsg").is(':checked'))
            arrayData = addDataToArray(arrayData, 1, 2);//enable
        else
            arrayData = addDataToArray(arrayData, 0, 2);//disable

        if ($("#manutenzioneResetServ").is(':checked'))
            arrayData = addDataToArray(arrayData, 1, 2);//enable
        else
            arrayData = addDataToArray(arrayData, 0, 2);//disable

        if ($("#manutenzioneResetHr").is(':checked'))
            arrayData = addDataToArray(arrayData, 1, 2);//enable
        else
            arrayData = addDataToArray(arrayData, 0, 2);//disable


        varsInternal.arraySendData.push(makeArraySend(0x0F, arrayData));//comando fine scrittura
        sendDataAnimation("manutenzioneSettings");

    });
    $("#dateTimeSettingsSend").click(function () {
        var arrayData = [];

        var timecheck = $("#timeSetpoint").val();

        arrayData = addDataToArray(arrayData, parseInt($("#formatTime").val()), 2); //contact
        if ((timecheck.indexOf('am') != -1)||(timecheck.indexOf('AM') != -1)) {
            arrayData = addDataToArray(arrayData, 0, 2); //AM
        }
        else
            arrayData = addDataToArray(arrayData, 1, 2); //PM

        arrayData = addDateToArray($("#dateSetpoint").val(), arrayData, parseInt($("#formatTime").val()))
        arrayData = addTimeToArray($("#timeSetpoint").val(), arrayData);

        varsInternal.arraySendData.push(makeArraySend(0x10, arrayData));//comando fine scrittura
        sendDataAnimation("dateTimeSettings");

    });
    $("#outMASettingSend").click(function () {
        var arrayData = [];
        var valoreInviare = 0;
        var numeroSondaConversione = 0;

        arrayData = addDataToArray(arrayData, parseInt($("#outMAOutput1Settings").val()), 2); //contact
        numeroSondaConversione = conversioneSondaConducibilita(arrayToData(vars.arrayRisposteAll[1], 3 + 3, 2))
        valoreInviare = Math.floor(parseFloat($("#outMAOutput1MaMAxSetpoint").val()) * getFattoreDivisioneSonda(5, numeroSondaConversione));
        arrayData = addDataToArray(arrayData, parseInt(valoreInviare), 2);
        valoreInviare = Math.floor(parseFloat($("#outMAOutput1MaMinSetpoint").val()) * getFattoreDivisioneSonda(5, numeroSondaConversione));
        arrayData = addDataToArray(arrayData, parseInt(valoreInviare), 2);
        if ($("#outMAOutput1MaMinAlarm").is(':checked'))
            arrayData = addDataToArray(arrayData, 1, 2);//stop 
        else
            arrayData = addDataToArray(arrayData, 0, 2);//stop

        arrayData = addDataToArray(arrayData, 0, 2);//checksum poi ricalcolata dalla centralina

        arrayData = addDataToArray(arrayData, parseInt($("#outMAOutput2Settings").val()), 2); //contact
        numeroSondaConversione = conversioneSondaConducibilita(arrayToData(vars.arrayRisposteAll[1], 3 + 13, 2))
        valoreInviare = Math.floor(parseFloat($("#outMAOutput2MaMAxSetpoint").val()) * getFattoreDivisioneSonda(5, numeroSondaConversione));
        arrayData = addDataToArray(arrayData, parseInt(valoreInviare), 2);
        valoreInviare = Math.floor(parseFloat($("#outMAOutput2MaMinSetpoint").val()) * getFattoreDivisioneSonda(5, numeroSondaConversione));
        arrayData = addDataToArray(arrayData, parseInt(valoreInviare), 2);
        if ($("#outMAOutput2MaMinAlarm").is(':checked'))
            arrayData = addDataToArray(arrayData, 1, 2);//stop 
        else
            arrayData = addDataToArray(arrayData, 0, 2);//stop


        varsInternal.arraySendData.push(makeArraySend(0x11, arrayData));//comando fine scrittura
        sendDataAnimation("outMASetting");

    });
    $("#logSettingsSend").click(function () {
        var arrayData = [];
        if ($("#logSettingsEnable").is(':checked'))
            arrayData = addDataToArray(arrayData, 1, 2);//stop 
        else
            arrayData = addDataToArray(arrayData, 0, 2);//stop
        arrayData = addDataToArray(arrayData, parseInt($("#logSettingsHour").val()), 2); //contact
        arrayData = addDataToArray(arrayData, parseInt($("#logSettingsMin").val()), 2); //contact

        varsInternal.arraySendData.push(makeArraySend(0x12, arrayData));//comando fine scrittura
        sendDataAnimation("logSettings");
    });
    $("#smsMessageSend").click(function () {
        var arrayData = [];
        varsInternal.arraySendData = [];
        arrayData = [];

        var indiceInviare = 0;
        var mailSend = $("#sms1Alarm").val()
        for (indiceInviare = 0; indiceInviare < 14; indiceInviare++) {
            var code = 0
            if (indiceInviare < mailSend.length)
                code = mailSend.charCodeAt(indiceInviare);

            arrayData = addDataToArray(arrayData, code, 1);
        }
        mailSend = $("#sms2Alarm").val()
        for (indiceInviare = 0; indiceInviare < 14; indiceInviare++) {
            var code = 0
            if (indiceInviare < mailSend.length)
                code = mailSend.charCodeAt(indiceInviare);

            arrayData = addDataToArray(arrayData, code, 1);
        }
        /*
        mailSend = $("#sms3Alarm").val()
        for (indiceInviare = 0; indiceInviare < 14; indiceInviare++) {
            var code = 0
            if (indiceInviare < mailSend.length)
                code = mailSend.charCodeAt(indiceInviare);

            arrayData = addDataToArray(arrayData, code, 1);
        }*/

        varsInternal.arraySendData.push(makeArraySend(0x13, arrayData));

        sendDataAnimation("smsMessage");
    });
    $("#mailMessageSend").click(function () {
        var arrayData = [];
        varsInternal.arraySendData = [];
        arrayData = [];

        var indiceInviare = 0;
        var mailSend = $("#mail1Alarm").val()
        for (indiceInviare = 0; indiceInviare < 33; indiceInviare++) {
            var code = 0
            if (indiceInviare < mailSend.length)
                code = mailSend.charCodeAt(indiceInviare);

            arrayData = addDataToArray(arrayData, code, 1);
        }
        mailSend = $("#mail2Alarm").val()
        for (indiceInviare = 0; indiceInviare < 33; indiceInviare++) {
            var code = 0
            if (indiceInviare < mailSend.length)
                code = mailSend.charCodeAt(indiceInviare);

            arrayData = addDataToArray(arrayData, code, 1);
        }

        varsInternal.arraySendData.push(makeArraySend(0x14, arrayData));

        sendDataAnimation("mailMessage");
    });
    $("#activeMessageSend").click(function () {
        varsInternal.arraySendData = [];
        arrayData = [];
        var valoreInviare = 0;

        if ($("#inputLevelEnable").is(':checked'))
            valoreInviare = valoreInviare | 0x01;//enable
        valoreInviare = valoreInviare << 1;

        if ($("#genericAlarmEnable").is(':checked'))
            valoreInviare = valoreInviare | 0x01;//enable
        valoreInviare = valoreInviare << 1;
        if ($("#inputFilter1Enable").is(':checked'))
            valoreInviare = valoreInviare | 0x01;//enable
        valoreInviare = valoreInviare << 1;
        if ($("#inputDosingAlarm1Enable").is(':checked'))
            valoreInviare = valoreInviare | 0x01;//enable
        valoreInviare = valoreInviare << 1;

        if ($("#inputStbyEnable").is(':checked'))
            valoreInviare = valoreInviare | 0x01;//enable
        valoreInviare = valoreInviare << 1;

        if ($("#inputPressureLowEnable").is(':checked'))
            valoreInviare = valoreInviare | 0x01;//enable
        valoreInviare = valoreInviare << 1;
        if ($("#inputPressureHighEnable").is(':checked'))
            valoreInviare = valoreInviare | 0x01;//enable
        valoreInviare = valoreInviare << 1;

        if ($("#inputTempPump1Enable").is(':checked'))
            valoreInviare = valoreInviare | 0x01;//enable
        valoreInviare = valoreInviare << 1;

        if ($("#highTemperatureEnable").is(':checked'))
            valoreInviare = valoreInviare | 0x01;//enable
        valoreInviare = valoreInviare << 1;

        if ($("#highConductivityInputEnable").is(':checked'))
            valoreInviare = valoreInviare | 0x01;//enable
        valoreInviare = valoreInviare << 1;

        if ($("#highConductivityOutputEnable").is(':checked'))
            valoreInviare = valoreInviare | 0x01;//enable

        arrayData = addDataToArray(arrayData, valoreInviare, 2);

        varsInternal.arraySendData.push(makeArraySend(0x15, arrayData));

        sendDataAnimation("activeMessage");
    });

    $("#actionSend").click(function () {
        varsInternal.arraySendData = [];
        arrayData = [];

        if ($("#actionResetAlarm").is(':checked'))
            arrayData = addDataToArray(arrayData, 1, 1);
        else
            arrayData = addDataToArray(arrayData, 0, 1);
        if ($("#actionOnOff").is(':checked'))
            arrayData = addDataToArray(arrayData, 1, 1);
        else
            arrayData = addDataToArray(arrayData, 0, 1);

        varsInternal.arraySendData.push(makeArraySend(0x16, arrayData));

        sendDataAnimation("actionSend");
    });
    /*-------------------------end invio dati*/
    function makeArraySend(codice, arrayAppend) {
        var i = 0;
        //var arraySendDataTemp = [];
        //arraySendDataTemp = [];
        var arraySendDataTemp = new Uint8Array(arrayAppend.length + 6);

        arraySendDataTemp[0] = 0xFF;
        arraySendDataTemp[1] = codice;
        arraySendDataTemp[2] = 0x01;
        arraySendDataTemp[3] = 0xFE;
        for (i = 0; i < arrayAppend.length; i++) {
            arraySendDataTemp[4 + i] = arrayAppend[i];
        }
        arraySendDataTemp[4 + i] = 0xFF;
        arraySendDataTemp[5 + i] = calcolaChecksum(arraySendDataTemp);
        return arraySendDataTemp;
    }

    function addDataToArray(arrayData, intero, lunghezza) {
        var i = 0;
        var lunghezzaArrayTemp = arrayData.length;
        for (i = 0; i < lunghezza; i++) {
            arrayData[lunghezzaArrayTemp + i] = intero & 0xFF;
            intero = intero >> 8;
        }
        return arrayData;
    }
    function sendDataAnimation(idLogic) {
        var errore = false;
        $("#" + idLogic + "Send").next("div").remove();
        $("#nav-tabs-" + idLogic).find(".text-danger").each(function (index) {
            $("#" + idLogic + "Send").after("<div class=\"text-danger small mt-1\">" + varsInternal.languageJsonSettingsMessage["sendError"] + "</div>");
            errore = true;
        });


        //if ((varsInternal.stateConnection != state.sendData) && (!errore)) {
        if ((varsInternal.stateConnection == state.readData) && (!errore)) {

            $(".ladda-label").hide();
            $(".ladda-spinner").show();
            $(".ModeSendLoad").show();
            var calcoloPercenturale = (100 * (varsInternal.indexGlobalProtocolloSendData + 1)) / varsInternal.arraySendData.length
            $(".progress-bar-animated").css("width", calcoloPercenturale.toString() + "%")
            $(".progress-bar-animated").css("aria - valuenow", calcoloPercenturale.toString() + "")

            varsInternal.stateConnection = state.sendData;
            varsInternal.statusSendData = true;

            varsInternal.indexGlobalProtocolloSendData = 0;
        }
        else {
            if (varsInternal.stateConnection != state.readData) {
                $("#" + idLogic + "Send").after("<div class=\"text-danger small mt-1\">" + varsInternal.languageJsonSettingsMessage["sendBusy"] + "</div>");
            }
        }


    }
    function setStatusIngressi(id,check,contact,delay) {
        if (check) //low level
        {
            $("#" + id + "Enable").prop("checked", true)
            $("#" + id + "Group").show();
        }
        else {
            $("#" + id + "Enable").prop("checked", false)
            $("#" + id + "Group").hide();
        }
        $("#" + id + "Contact> [value=" + contact.toString() + "]").prop("selected", true)
        $("#" + id + "DelaySec> [value=" + delay.toString() + "]").prop("selected", true)
    }
    function costruisciTextBoxListaSonde(idTextBox, testoUnitaDiAppoggio,tipoSonda, numeroSondaConversione)
    {
        var testoDiAppoggio = '';

        testoDiAppoggio = varsInternal.languageJsonSettingsMessage[$(idTextBox).attr("labelMSGError")];
        testoDiAppoggio = testoDiAppoggio.replaceAll("yyyy", testoUnitaDiAppoggio)
        testoDiAppoggio = testoDiAppoggio.replaceAll("xxxx", getMinimoJson(tipoSonda, numeroSondaConversione))
        testoDiAppoggio = testoDiAppoggio.replaceAll("zzzz", getMassimoJson(tipoSonda, numeroSondaConversione))
        varsInternal.languageJsonSettingsMessage[$(idTextBox).attr("labelMSGError")] = testoDiAppoggio

        testoDiAppoggio = varsInternal.languageJsonSettingsMessage[$(idTextBox).attr("labelMSG")];
        testoDiAppoggio = testoDiAppoggio.replaceAll("yyyy", testoUnitaDiAppoggio)
        testoDiAppoggio = testoDiAppoggio.replaceAll("xxxx", getMinimoJson(tipoSonda, numeroSondaConversione))
        testoDiAppoggio = testoDiAppoggio.replaceAll("zzzz", getMassimoJson(tipoSonda, numeroSondaConversione))
        varsInternal.languageJsonSettingsMessage[$(idTextBox).attr("labelMSG")] = testoDiAppoggio

        $(idTextBox).attr("min", getMinimoJson(tipoSonda, numeroSondaConversione))
        $(idTextBox).attr("max", getMassimoJson(tipoSonda, numeroSondaConversione))
        $(idTextBox).attr("step", getStepJson(getFattoreDivisioneSonda(tipoSonda, numeroSondaConversione)))
        $(idTextBox).attr("maxlength", getMaxLenJson(getFattoreDivisioneSonda(tipoSonda, numeroSondaConversione)))
        $(idTextBox).attr("decimal", getNumeroDecimaliSonda(tipoSonda, numeroSondaConversione).toString())
    }
    function getValoreLabelJson(tipoCanale, numeroSonda) {
        var indiceCancvas = 0;

        for (indiceCancvas = 0; indiceCancvas < jsonParseListaSonde.variable.length; indiceCancvas++) {
            if ((jsonParseListaSonde.variable[indiceCancvas]["tipoCanale"] == tipoCanale) && (jsonParseListaSonde.variable[indiceCancvas]["numeroSonda"] == numeroSonda)) {
                return jsonParseListaSonde.variable[indiceCancvas]["unitEu"];
            }
        }
        return ""
    }
    function getMinimoJson(tipoCanale, numeroSonda) {
        var indiceCancvas = 0;

        for (indiceCancvas = 0; indiceCancvas < jsonParseListaSonde.variable.length; indiceCancvas++) {
            if ((jsonParseListaSonde.variable[indiceCancvas]["tipoCanale"] == tipoCanale) && (jsonParseListaSonde.variable[indiceCancvas]["numeroSonda"] == numeroSonda)) {
                return jsonParseListaSonde.variable[indiceCancvas]["minimo"];
            }
        }
        return ""
    }
    function getMassimoJson(tipoCanale, numeroSonda) {
        var indiceCancvas = 0;

        for (indiceCancvas = 0; indiceCancvas < jsonParseListaSonde.variable.length; indiceCancvas++) {
            if ((jsonParseListaSonde.variable[indiceCancvas]["tipoCanale"] == tipoCanale) && (jsonParseListaSonde.variable[indiceCancvas]["numeroSonda"] == numeroSonda)) {
                return jsonParseListaSonde.variable[indiceCancvas]["massimo"];
            }
        }
        return ""
    }
    function getStepJson(fattoreDivisioneTemp) {
        switch (fattoreDivisioneTemp) {
            case 1:
                return "1";
                break;
            case 10:
                return "0.1";
                break;
            case 100:
                return "0.01";
                break;
            case 1000:
                return "0.001";
                break;
        }
        return "1"
    }
    function getMaxLenJson(fattoreDivisioneTemp) {
        switch (fattoreDivisioneTemp) {
            case 1:
                return "4";
                break;
            case 10:
                return "5";
                break;
            case 100:
                return "5";
                break;
            case 1000:
                return "5";
                break;
        }
        return "4"
    }
    function conversioneSondaConducibilita(indiceConversione)
    {
        switch (indiceConversione) {
            case 0:
                return 24;
                break;
            case 1:
            case 2:
                return 25;
                break;
            case 3:
                return 26;
                break;
            case 4:
                return 27;
                break;

        }
        return 24;
    }
    function getFattoreDivisioneSonda(tipoCanale, numeroSonda) {
        var indiceCancvas = 0;

        for (indiceCancvas = 0; indiceCancvas < jsonParseListaSonde.variable.length; indiceCancvas++) {
            if ((jsonParseListaSonde.variable[indiceCancvas]["tipoCanale"] == tipoCanale) && (jsonParseListaSonde.variable[indiceCancvas]["numeroSonda"] == numeroSonda)) {
                switch (parseInt(jsonParseListaSonde.variable[indiceCancvas]["decimali"])) {
                    case 0:
                        return 1;
                        break;
                    case 1:
                        return 10;
                        break;
                    case 2:
                        return 100;
                        break;
                    case 3:
                        return 1000;
                        break;
                }
            }
        }
        return 1
    }
    function getNumeroDecimaliSonda(tipoCanale, numeroSonda) {
        var indiceCancvas = 0;

        for (indiceCancvas = 0; indiceCancvas < jsonParseListaSonde.variable.length; indiceCancvas++) {
            if ((jsonParseListaSonde.variable[indiceCancvas]["tipoCanale"] == tipoCanale) && (jsonParseListaSonde.variable[indiceCancvas]["numeroSonda"] == numeroSonda)) {
                return parseInt(jsonParseListaSonde.variable[indiceCancvas]["decimali"]);
            }
        }
        return 1
    }
    function makeCalcoloLitriOrGallons(unit, inputData) {
        //return unit == 1 ? (inputData / 1000).toFixed(3) : ((inputData / 1000 > 0 && inputData / 1000 < 1) ? inputData.toString() : (inputData / 1000).toFixed(3));
        return (inputData / 1000).toFixed(3) ;
    }
    function makeUnitLitriOrGallons(unit, inputData) {
        return unit == 1 ? "Gal" :  "mc" 
    }
    function makeCalcoloLitriOrGallonsHora(unit, inputData) {
        //return unit == 1 ? (inputData / 1000).toFixed(3) : ((inputData / 1000 > 0 && inputData / 1000 < 1) ? inputData.toString() : (inputData / 1000).toFixed(3));
        return (inputData / 100000).toFixed(2);
    }
    function makeUnitLitriOrGallonsHora(unit, inputData) {
        return unit == 1 ? "Gal/h" : "mc/h"
    }
    //-----------------------funzioni di controllo javascript per le form
    $("#actionOnOff").click(function () {
        if ($("#actionOnOff").is(':checked')){
            $("#actionOnLabel").show();
            $("#actionOffLabel").hide();
        }
        else{
            $("#actionOnLabel").hide();
            $("#actionOffLabel").show();
        }
    });
    $('.numerico').on('keypress keydown keyup', function () {
        var decimali = parseInt($(this).attr("decimal"));
        var minimo = parseFloat($(this).attr("min"))
        var massimo = parseFloat($(this).attr("max"))

        //controllo sulla lunghezza
        if (this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);
        //end controllo sulla lunghezza

        $(this).next("div").remove();
        if ((countDecimalAfterPoint($(this).val()) > decimali) || //controllo i decimali dopo la virgola
            (parseFloat($(this).val()) < minimo) ||
            (parseFloat($(this).val()) > massimo)
            )
            $(this).after("<div class=\"text-danger small mt-1\">" + varsInternal.languageJsonSettingsMessage[$(this).attr("labelMSGError")] + "</div>");
        else
            $(this).after("<div class=\"text-success small mt-1\">" + varsInternal.languageJsonSettingsMessage[$(this).attr("labelMSG")] + "</div>");

    });

    $('.mail').on('keypress keydown keyup', function () {
        var email_re = /^[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,4}$/i;
        var value_form = this.value;

        $(this).next("div").remove();
        if (value_form != ""){
                    if ((value_form.search(email_re) == -1)) {
                        $(this).after("<div class=\"text-danger small mt-1\">" + varsInternal.languageJsonSettingsMessage[$(this).attr("labelMSGError")] + "</div>");
                    }
                    else
                        $(this).after("<div class=\"text-success small mt-1\">" + varsInternal.languageJsonSettingsMessage[$(this).attr("labelMSG")] + "</div>");
        }
    });

    $('.sms').on('keypress keydown keyup', function () {
        var sms_re = /^[\+]?[(]?[0-9]{3}[)]?[-\s\.]?[0-9]{3}[-\s\.]?[0-9]{4,6}$/i;
        var value_form = this.value;

        $(this).next("div").remove();
        if ((value_form.search(sms_re) == -1)) {
            $(this).after("<div class=\"text-danger small mt-1\">" + varsInternal.languageJsonSettingsMessage[$(this).attr("labelMSGError")] + "</div>");
        }
        else
            $(this).after("<div class=\"text-success small mt-1\">" + varsInternal.languageJsonSettingsMessage[$(this).attr("labelMSG")] + "</div>");
    });


    

    function countDecimalAfterPoint(value) {
        if (value.includes('.')) {
            return value.split('.')[1].length;
        };
        if (value.includes(',')) {
            return value.split(',')[1].length;
        };
        return 0;
    }
    function makeData(giorno, mese, anno, formato) {
        switch (formato) {
            case 0://:gg/mm/aa
                return (giorno < 10 ? "0" : "") + giorno.toString() + "/" + (mese < 10 ? "0" : "") + mese.toString() + "/" + anno.toString()
                break;
            case 1://mm/gg/aa
                return (mese < 10 ? "0" : "") + mese.toString() + "/" + (giorno < 10 ? "0" : "") + giorno.toString() + "/" + anno.toString()
                break;
        }
    }
    function addDateToArray(dateTimeTemp, arrayData, formato) {
        var dateTimeSplit = dateTimeTemp.split("/")
        var lunghezzaArrayTemp = arrayData.length;
        var anno = 0;
        switch (formato) {
            case 0://:gg/mm/aa
                if (dateTimeSplit.length >= 3) {
                    arrayData[lunghezzaArrayTemp + 0] = parseInt(dateTimeSplit[0]);
                    arrayData[lunghezzaArrayTemp + 1] = 0;
                    arrayData[lunghezzaArrayTemp + 2] = parseInt(dateTimeSplit[1]);
                    arrayData[lunghezzaArrayTemp + 3] = 0;
                    anno = parseInt(dateTimeSplit[2]);
                    arrayData[lunghezzaArrayTemp + 4] = anno & 0xFF;
                    anno = anno >> 8;
                    arrayData[lunghezzaArrayTemp + 5] = anno & 0xFF;
                }
                break;
            case 1://mm/gg/aa
                if (dateTimeSplit.length >= 3) {
                    arrayData[lunghezzaArrayTemp + 0] = parseInt(dateTimeSplit[1]);
                    arrayData[lunghezzaArrayTemp + 1] = 0;
                    arrayData[lunghezzaArrayTemp + 2] = parseInt(dateTimeSplit[0]);
                    arrayData[lunghezzaArrayTemp + 3] = 0;
                    anno = parseInt(dateTimeSplit[2]);
                    arrayData[lunghezzaArrayTemp + 4] = anno & 0xFF;
                    anno = anno >> 8;
                    arrayData[lunghezzaArrayTemp + 5] = anno & 0xFF;
                }
                break;
        }
        return arrayData;
    }
    function makeOre(ore, minuti, formato,ampm) {
        switch (formato) {
            case 1://USA
                var suffix = ampm == 1 ? "PM" : "AM";
                return (ore < 10 ? "0" : "") + ore.toString() + ":" + (minuti < 10 ? "0" : "") + minuti.toString() + suffix
                //return ((ore + 11) % 12 + 1).toString() + ":" + (minuti < 10 ? "0" : "") + minuti.toString() + suffix
                break;
            case 0://EUROPA
                return (ore < 10 ? "0" : "") + ore.toString() + ":" + (minuti < 10 ? "0" : "") + minuti.toString()
                break;
        }
    }
    function addTimeToArray(dateTimeTemp, arrayData) {
        dateTimeTemp = convertToHour(dateTimeTemp);
        var dateTimeSplit = dateTimeTemp.split(":")
        var lunghezzaArrayTemp = arrayData.length;
        if (dateTimeSplit.length >= 2) {
            arrayData[lunghezzaArrayTemp + 0] = parseInt(dateTimeSplit[0]);
            arrayData[lunghezzaArrayTemp + 1] = 0;
            arrayData[lunghezzaArrayTemp + 2] = parseInt(dateTimeSplit[1]);
            arrayData[lunghezzaArrayTemp + 3] = 0;
        }
        return arrayData;
    }
    function convertToHour(time) {
        return time.replace(/(am|pm)/, '');
    }
    function alarmDateFormat(input) {

        switch (input) {
            case 0://gg/mm/aa
                $("#dateSetpoint").attr("labelMSG", "dateggmmaaInfo")
                $("#dateSetpoint").attr("labelMSGError", "dateggmmaaAlarm")
                break;
            case 1://mm/gg/aa
                $("#dateSetpoint").attr("labelMSG", "datemmggaaInfo")
                $("#dateSetpoint").attr("labelMSGError", "datemmggaaAlarm")
                break;
        }
    }
    $('#formatTime').change(function () {
        $("#dateSetpoint").val(makeData(arrayToData(vars.arrayRisposteAll[1], 3 + 119, 2), arrayToData(vars.arrayRisposteAll[1], 3 + 121, 2), arrayToData(vars.arrayRisposteAll[1], 3 + 123, 2), parseInt($(this).val())))
        alarmDateFormat(parseInt($(this).val()));

        alarmTimeFormat(parseInt($(this).val()));
        $("#timeSetpoint").val(makeOre(arrayToData(vars.arrayRisposteAll[1], 3 + 125, 2), arrayToData(vars.arrayRisposteAll[1], 3 + 127, 1), parseInt($(this).val()),0)); //time

    });
    $('#dateSetpoint').on('keypress keydown keyup', function () {
        var validateDate = false;
        switch (parseInt($('#formatTime').val())) {
            case 0://gg/mm/aa
                validateDate = validateDateggmmaa($(this).val());
                break;
            case 1://mm/gg/aa
                validateDate = validateDatemmggaa($(this).val());
                break;
            case 2://aa/mm/gg
                validateDate = validateDateaammgg($(this).val());
                break;
        }
        $(this).next("div").remove();
        if (validateDate)
            $(this).after("<div class=\"text-danger small mt-1\">" + varsInternal.languageJsonSettingsMessage[$(this).attr("labelMSGError")] + "</div>");
        else
            $(this).after("<div class=\"text-success small mt-1\">" + varsInternal.languageJsonSettingsMessage[$(this).attr("labelMSG")] + "</div>");
    });
    function alarmTimeFormat(input) {
        if (input == 1) {//USA
            $("#timeSetpoint").mask('00:00 ZM', {
                translation: {
                    'Z': {
                        pattern: /[AP]/
                    }
                },
                placeholder: "__:__ AM"
            });
            $("#timeSetpoint").attr("labelMSG", "weekTimeInfo12")
            $("#timeSetpoint").attr("labelMSGError", "weekTimeAlarm12")
        }
        else {//america
            $("#timeSetpoint").attr("labelMSG", "weekTimeInfo")
            $("#timeSetpoint").attr("labelMSGError", "weekTimeAlarm")
            $("#timeSetpoint").mask('00:00')
        }
    }
    $('#timeSetpoint').on('keypress keydown keyup', function () {
        var validateTime = false;
        switch (parseInt($('#formatTime').val())) {
            case 1://formato 12
                validateTime = validateTime12($(this).val());
                break;
            case 0://formato 24
                validateTime = validateTime24($(this).val());
                break;
        }
        $(this).next("div").remove();
        if (validateTime)
            $(this).after("<div class=\"text-danger small mt-1\">" + varsInternal.languageJsonSettingsMessage[$(this).attr("labelMSGError")] + "</div>");
        else
            $(this).after("<div class=\"text-success small mt-1\">" + varsInternal.languageJsonSettingsMessage[$(this).attr("labelMSG")] + "</div>");
    });
    function validateDateggmmaa(value) {
        var pattern = /^([0-2][0-9]|(3)[0-1])(\/)(((0)[0-9])|((1)[0-2]))(\/)\d{4}$/;
        //var validDate = $.value.match(pattern);
        var validDate = pattern.test(value);
        if (!validDate) {
            return true;
        } else {
            return false;
        }

    }
    function validateDatemmggaa(value) {
        var pattern = /^(((0)[0-9])|((1)[0-2]))(\/)([0-2][0-9]|(3)[0-1])(\/)\d{4}$/;
        var validDate = value.match(pattern);
        if (!validDate) {
            return true;
        } else {
            return false;
        }

    }
    function validateDateaammgg(value) {
        var pattern = /^\d{4}(\/)(((0)[0-9])|((1)[0-2]))(\/)([0-2][0-9]|(3)[0-1])$/;

        var validDate = value.match(pattern);
        if (!validDate) {
            return true;
        } else {
            return false;
        }

    }

    function validateTime12(value) {
        var validTime = value.match(/^(0?[1-9]|1[012])(:[0-5]\d) [APap][mM]$/);
        if (!validTime) {
            return true;
        } else {
            return false;
        }
    }
    function validateTime24(value) {
        if (!/^\d{2}:\d{2}$/.test(value)) return true;
        var parts = value.split(':');
        if (parts[0] > 23 || parts[1] > 59 || parts[2] > 59) return true;
        return false;
    }
    //-----------------------endfunzioni di controllo javascript per le form


    //gestione del grafico dei log
    function decodeLog(arrayLogTemp) {
        
        var indiceTempLog = 0;
        var numeroSondaConversione = 0;
        var logConducibilita = 0;

        
        varsInternal.sizeLogProtocollo
        for (indiceTempLog = 0; indiceTempLog < varsInternal.maxLogProtocollo; indiceTempLog++) {
            if (4 + ((varsInternal.sizeLogProtocollo * indiceTempLog) + (varsInternal.sizeLogProtocollo - 1)) < arrayLogTemp.length){//controllo la dimensione del pacchetto
                var timeLog = new Date(arrayLogTemp[4 + ((varsInternal.sizeLogProtocollo * indiceTempLog) + 2)] + 2000, arrayLogTemp[4 + ((varsInternal.sizeLogProtocollo * indiceTempLog) + 1)] - 1, arrayLogTemp[4 + ((varsInternal.sizeLogProtocollo * indiceTempLog) + 0)], arrayLogTemp[4 + ((varsInternal.sizeLogProtocollo * indiceTempLog) + 3)], arrayLogTemp[4 + ((varsInternal.sizeLogProtocollo * indiceTempLog) + 4)], 0, 0)
                
                if (varsInternal.primaLetturaLog) {
                    varsInternal.dataLogStart = timeLog;
                    varsInternal.primaLetturaLog = false;
                }
                varsInternal.dataLogStop = timeLog;
                var utc_timestamp = timeLog.getTimezoneOffset();
                timeLog.setMinutes(timeLog.getMinutes() - utc_timestamp);

                

                //console.log("lettura Log:" + days + "," + utc_timestamp)
                //-------------------------------------------------costruzione array dei log
                // --------------------conducibilità in ingresso
                numeroSondaConversione = conversioneSondaConducibilita(arrayToData(vars.arrayRisposteAll[1], 3 + 3, 2))
                varsInternal.logGraphConductivityInputNumeroDecimali = getNumeroDecimaliSonda(5, numeroSondaConversione)
                logConducibilita = arrayToData(arrayLogTemp, 4 + ((varsInternal.sizeLogProtocollo * indiceTempLog) + 7), 2) / getFattoreDivisioneSonda(5, numeroSondaConversione);// conducibilità in uscita
                varsInternal.logGraphConductivityInputArray.push([timeLog.getTime() , logConducibilita]);
                // --------------------end conducibilità in ingresso

                // --------------------conducibilità in uscita
                numeroSondaConversione = conversioneSondaConducibilita(arrayToData(vars.arrayRisposteAll[1], 3 + 13, 2))
                varsInternal.logGraphConductivityOutputNumeroDecimali = getNumeroDecimaliSonda(5, numeroSondaConversione)
                logConducibilita = arrayToData(arrayLogTemp, 4 + ((varsInternal.sizeLogProtocollo * indiceTempLog) + 5), 2) / getFattoreDivisioneSonda(5, numeroSondaConversione);// conducibilità in uscita
                varsInternal.logGraphConductivityOutputArray.push([timeLog.getTime() , logConducibilita]);
                
                // --------------------temperatutra
                temperatura = arrayToData(arrayLogTemp, 4 + ((varsInternal.sizeLogProtocollo * indiceTempLog) + 9), 2) / 10;
                varsInternal.logGraphTemperaturaNumeroDecimali = 1;
                varsInternal.logGraphTemperaturaArray.push([timeLog.getTime(), temperatura]);

                // --------------------allarmi
                var shiftOperation = arrayToData(arrayLogTemp, 4 + ((varsInternal.sizeLogProtocollo * indiceTempLog) + 27), 2);
                var shiftIndex = 0;
                for (shiftIndex = 0; shiftIndex < 11; shiftIndex++) {
                    var checkedTemp = 0;
                    if (shiftOperation & 1) {
                        checkedTemp = 1;
                    }
                    switch (shiftIndex) {
                        case 0://high cd uscita
                            varsInternal.logGraphHighConductivityOutputEnableArray.push([timeLog.getTime(), checkedTemp]);
                            break;
                        case 1://
                            varsInternal.logGraphHighConductivityInputEnableArray.push([timeLog.getTime(), checkedTemp]);
                            break;
                        case 2://
                            varsInternal.logGraphHighTemperatureEnableArray.push([timeLog.getTime(), checkedTemp]);
                            break;
                        case 3://
                            varsInternal.logGraphInputTempPumpEnableArray.push([timeLog.getTime(), checkedTemp]);
                            break;
                        case 4://
                            varsInternal.logGraphInputPressureHighEnableArray.push([timeLog.getTime(), checkedTemp]);
                            break;
                        case 5://
                            varsInternal.logGraphInputPressureLowEnableArray.push([timeLog.getTime(), checkedTemp]);
                            break;
                        case 6://
                            varsInternal.logGraphInputStbyEnableArray.push([timeLog.getTime(), checkedTemp]);
                            break;
                        case 7://
                            varsInternal.logGraphInputDosingAlarmEnableArray.push([timeLog.getTime(), checkedTemp]);
                            break;
                        case 8://
                            varsInternal.logGraphInputFilterEnableArray.push([timeLog.getTime(), checkedTemp]);
                            break;
                        case 9://
                            varsInternal.logGraphGenericAlarmEnableArray.push([timeLog.getTime(), checkedTemp]);
                            break;
                        case 10://
                            varsInternal.logGraphInputLevelEnableArray.push([timeLog.getTime(), checkedTemp]);
                            break;

                    }
                    shiftOperation = shiftOperation >> 1;
                }
                // --------------------uscite
                shiftOperation = arrayToData(arrayLogTemp, 4 + ((varsInternal.sizeLogProtocollo * indiceTempLog) + 30), 1);
                shiftIndex = 0;
                for (shiftIndex = 0; shiftIndex < 6; shiftIndex++) {
                    var checkedTemp = 0;
                    if (shiftOperation & 1) {
                        checkedTemp = 1;
                    }
                    switch (shiftIndex) {
                        case 0://high cd uscita
                            varsInternal.logGraphEvIngressoArray.push([timeLog.getTime(), checkedTemp]);
                            break;
                        case 1://
                            varsInternal.logGraphEvUscitaArray.push([timeLog.getTime(), checkedTemp]);
                            break;
                        case 2://
                            varsInternal.logGraphEvScaricoArray.push([timeLog.getTime(), checkedTemp]);
                            break;
                        case 3://
                            varsInternal.logGraphPompaOsmosiArray.push([timeLog.getTime(), checkedTemp]);
                            break;
                        case 4://
                            varsInternal.logGraphPompaDosaggioArray.push([timeLog.getTime(), checkedTemp]);
                            break;
                        case 5://
                            varsInternal.logGraphOutAlarmArray.push([timeLog.getTime(), checkedTemp]);
                            break;

                    }
                    shiftOperation = shiftOperation >> 1;
                }
                //totalizzatori

                logConducibilita = arrayToData(arrayLogTemp, 4 + ((varsInternal.sizeLogProtocollo * indiceTempLog) + 19), 4) / 10000
                varsInternal.logGraphTotUscitaArray.push([timeLog.getTime(), logConducibilita]);
                logConducibilita = arrayToData(arrayLogTemp, 4 + ((varsInternal.sizeLogProtocollo * indiceTempLog) + 23), 4) / 10000
                varsInternal.logGraphTotIngressoArray.push([timeLog.getTime(), logConducibilita]);

                logConducibilita = arrayToData(arrayLogTemp, 4 + ((varsInternal.sizeLogProtocollo * indiceTempLog) + 15), 4) / 100000
                varsInternal.logGraphFlowMeterIngressoArray.push([timeLog.getTime(), logConducibilita]);
                logConducibilita = arrayToData(arrayLogTemp, 4 + ((varsInternal.sizeLogProtocollo * indiceTempLog) + 11), 4) / 100000
                varsInternal.logGraphFlowMeterUscitaArray.push([timeLog.getTime(), logConducibilita]);

                //-------------------------------------------------costruzione array dei log
            }
            else {
                
                varsInternal.primaLetturaLog = false;
                varsInternal.logDayCurrent = parseInt($("#logDaySelect").val());
                return false
            }
        }

        //var diff = new Date(varsInternal.dataLogStart - varsInternal.dataLogStop);
        var diff = varsInternal.dataLogStart.getTime() - varsInternal.dataLogStop.getTime();

        //var utc_timestamp = diff.getTimezoneOffset();
        //diff.setMinutes(diff.getMinutes() - utc_timestamp +1);
        ///diff.setMinutes(diff.getMinutes() + utc_timestamp);
        //console.log("lettura Log:" + diff + "," + utc_timestamp)
        
        var days = diff ;

        //console.log("lettura Log:" + days)

        $("#statusReadLog").text("Load Log .. " + varsInternal.dataLogStop.getUTCDate() + "/" + (varsInternal.dataLogStop.getUTCMonth() + 1) + "/" + varsInternal.dataLogStop.getUTCFullYear() + " " + varsInternal.dataLogStop.getUTCHours() + ":" + varsInternal.dataLogStop.getUTCMinutes())

        if ((days < 0) || (days >= (parseInt($("#logDaySelect").val()) * 3600 * 24 * 1000))) {
            varsInternal.logDayCurrent = parseInt($("#logDaySelect").val());
            varsInternal.primaLetturaLog = false;
            return false
        }
        else
            return true
    }
    $(".refreshLog").click(function () {
        if (varsInternal.stateConnection == state.readData)
                    disegnaGrafico();
    });
    $("#logDaySelect").change(function () {
        var currentIndexSelect = parseInt($("#logDaySelect").val());

        if (currentIndexSelect > varsInternal.logDayCurrent)
        {//leggo altri log
            varsInternal.stateConnection = state.readLog;
            $("#statusReadLog").text("Load Log ..");
        }
        else {
            var newdate = new Date(varsInternal.dataLogStart);
            newdate.setDate(newdate.getDate() + parseInt($("#logDaySelect").val()));
            const xAxis = chartLDOSIN.xAxis[0];
            console.log("date:" + Date.UTC(varsInternal.dataLogStart) + "," + Date.UTC(newdate))
            xAxis.setExtremes(Date.UTC(varsInternal.dataLogStart.getFullYear(), varsInternal.dataLogStart.getMonth(), varsInternal.dataLogStart.getDate()), Date.UTC(newdate.getFullYear(), newdate.getMonth(), newdate.getDate()));
        }
        //logDayCurrent: parseInt($("#logDaySelect").val())
    });
        
    function disegnaGrafico()
    {
        var series_chart = [];
        var yaxis_chart = [];
        var arrayTabella = [];
        var indiceK = 0;

        var numero_asse = 0;
        var altezza = 50;
        if ($("#logGraphConductivityInput").is(':checked')) {
            varsInternal.logGraphConductivityInputArray.sort();
            series_chart.push(createGraphLineSeries(varsInternal.logGraphConductivityInputArray, numero_asse, varsInternal.languageJsonDataTranslate["titleIngresso"], varsInternal.logGraphConductivityInputNumeroDecimali));
                numero_asse = numero_asse + 1;
                yaxis_chart.push(createGraphLineY(varsInternal.languageJsonDataTranslate["titleIngresso"], altezza, 200));
                altezza = altezza + 300;
        }
        if ($("#logGraphConductivityOutput").is(':checked')) {
            varsInternal.logGraphConductivityOutputArray.sort();
            series_chart.push(createGraphLineSeries(varsInternal.logGraphConductivityOutputArray, numero_asse, varsInternal.languageJsonDataTranslate["titleUscita"], varsInternal.logGraphConductivityOutputNumeroDecimali));
            numero_asse = numero_asse + 1;
            yaxis_chart.push(createGraphLineY(varsInternal.languageJsonDataTranslate["titleUscita"], altezza, 200));
            altezza = altezza + 300;
        }
        if ($("#logGraphTemperatura").is(':checked')) {
            varsInternal.logGraphTemperaturaArray.sort();
            series_chart.push(createGraphLineSeries(varsInternal.logGraphTemperaturaArray, numero_asse, varsInternal.languageJsonDataTranslate["temperaturaSonda"], varsInternal.logGraphTemperaturaNumeroDecimali));
            numero_asse = numero_asse + 1;
            yaxis_chart.push(createGraphLineY(varsInternal.languageJsonDataTranslate["temperaturaSonda"], altezza, 200));
            altezza = altezza + 300;
        }

        //allarmi
        if ($("#logGraphHighConductivityOutputEnable").is(':checked')) {
            varsInternal.logGraphHighConductivityOutputEnableArray.sort();
            series_chart.push(createGraphStepSeries(varsInternal.logGraphHighConductivityOutputEnableArray, numero_asse, varsInternal.languageJsonDataTranslate["highConductivityOutput"]), createGraphStepSeries1(varsInternal.logGraphHighConductivityOutputEnableArray, numero_asse, varsInternal.languageJsonDataTranslate["highConductivityOutput"]))
            numero_asse = numero_asse + 1;
            yaxis_chart.push(createGraphLineY(varsInternal.languageJsonDataTranslate["highConductivityOutput"], altezza, 200));
            altezza = altezza + 300;
        }
        if ($("#logGraphHighConductivityInputEnable").is(':checked')) {
            varsInternal.logGraphHighConductivityInputEnableArray.sort();
            series_chart.push(createGraphStepSeries(varsInternal.logGraphHighConductivityInputEnableArray, numero_asse, varsInternal.languageJsonDataTranslate["highConductivityInput"]), createGraphStepSeries1(varsInternal.logGraphHighConductivityInputEnableArray, numero_asse, varsInternal.languageJsonDataTranslate["highConductivityInput"]))
            numero_asse = numero_asse + 1;
            yaxis_chart.push(createGraphLineY(varsInternal.languageJsonDataTranslate["highConductivityInput"], altezza, 200));
            altezza = altezza + 300;
        }
        if ($("#logGraphHighTemperatureEnable").is(':checked')) {
            varsInternal.logGraphHighTemperatureEnableArray.sort();
            series_chart.push(createGraphStepSeries(varsInternal.logGraphHighTemperatureEnableArray, numero_asse, varsInternal.languageJsonDataTranslate["highTemperature"]), createGraphStepSeries1(varsInternal.logGraphHighTemperatureEnableArray, numero_asse, varsInternal.languageJsonDataTranslate["highTemperature"]))
            numero_asse = numero_asse + 1;
            yaxis_chart.push(createGraphLineY(varsInternal.languageJsonDataTranslate["highTemperature"], altezza, 200));
            altezza = altezza + 300;
        }
        if ($("#logGraphInputTempPumpEnable").is(':checked')) {
            varsInternal.logGraphInputTempPumpEnableArray.sort();
            series_chart.push(createGraphStepSeries(varsInternal.logGraphInputTempPumpEnableArray, numero_asse, varsInternal.languageJsonDataTranslate["inputTempPump"]), createGraphStepSeries1(varsInternal.logGraphInputTempPumpEnableArray, numero_asse, varsInternal.languageJsonDataTranslate["inputTempPump"]))
            numero_asse = numero_asse + 1;
            yaxis_chart.push(createGraphLineY(varsInternal.languageJsonDataTranslate["inputTempPump"], altezza, 200));
            altezza = altezza + 300;
        }
        if ($("#logGraphInputPressureHighEnable").is(':checked')) {
            varsInternal.logGraphInputPressureHighEnableArray.sort();
            series_chart.push(createGraphStepSeries(varsInternal.logGraphInputPressureHighEnableArray, numero_asse, varsInternal.languageJsonDataTranslate["inputPressureHigh"]), createGraphStepSeries1(varsInternal.logGraphInputPressureHighEnableArray, numero_asse, varsInternal.languageJsonDataTranslate["inputPressureHigh"]))
            numero_asse = numero_asse + 1;
            yaxis_chart.push(createGraphLineY(varsInternal.languageJsonDataTranslate["inputPressureHigh"], altezza, 200));
            altezza = altezza + 300;
        }
        if ($("#logGraphInputPressureLowEnable").is(':checked')) {
            varsInternal.logGraphInputPressureLowEnableArray.sort();
            series_chart.push(createGraphStepSeries(varsInternal.logGraphInputPressureLowEnableArray, numero_asse, varsInternal.languageJsonDataTranslate["inputPressureLow"]), createGraphStepSeries1(varsInternal.logGraphInputPressureLowEnableArray, numero_asse, varsInternal.languageJsonDataTranslate["inputPressureLow"]))
            numero_asse = numero_asse + 1;
            yaxis_chart.push(createGraphLineY(varsInternal.languageJsonDataTranslate["inputPressureLow"], altezza, 200));
            altezza = altezza + 300;
        }
        if ($("#logGraphInputStbyEnable").is(':checked')) {
            varsInternal.logGraphInputStbyEnableArray.sort();
            series_chart.push(createGraphStepSeries(varsInternal.logGraphInputStbyEnableArray, numero_asse, varsInternal.languageJsonDataTranslate["inputStandby"]), createGraphStepSeries1(varsInternal.logGraphInputStbyEnableArray, numero_asse, varsInternal.languageJsonDataTranslate["inputStandby"]))
            numero_asse = numero_asse + 1;
            yaxis_chart.push(createGraphLineY(varsInternal.languageJsonDataTranslate["inputStandby"], altezza, 200));
            altezza = altezza + 300;
        }
        if ($("#logGraphInputDosingAlarmEnable").is(':checked')) {
            varsInternal.logGraphInputDosingAlarmEnableArray.sort();
            series_chart.push(createGraphStepSeries(varsInternal.logGraphInputDosingAlarmEnableArray, numero_asse, varsInternal.languageJsonDataTranslate["inputDosingAlarm"]), createGraphStepSeries1(varsInternal.logGraphInputDosingAlarmEnableArray, numero_asse, varsInternal.languageJsonDataTranslate["inputDosingAlarm"]))
            numero_asse = numero_asse + 1;
            yaxis_chart.push(createGraphLineY(varsInternal.languageJsonDataTranslate["inputDosingAlarm"], altezza, 200));
            altezza = altezza + 300;
        }
        if ($("#logGraphInputFilterEnable").is(':checked')) {
            varsInternal.logGraphInputFilterEnableArray.sort();
            series_chart.push(createGraphStepSeries(varsInternal.logGraphInputFilterEnableArray, numero_asse, varsInternal.languageJsonDataTranslate["inputFilter"]), createGraphStepSeries1(varsInternal.logGraphInputFilterEnableArray, numero_asse, varsInternal.languageJsonDataTranslate["inputFilter"]))
            numero_asse = numero_asse + 1;
            yaxis_chart.push(createGraphLineY(varsInternal.languageJsonDataTranslate["inputFilter"], altezza, 200));
            altezza = altezza + 300;
        }
        if ($("#logGraphGenericAlarmEnable").is(':checked')) {
            varsInternal.logGraphGenericAlarmEnableArray.sort();
            series_chart.push(createGraphStepSeries(varsInternal.logGraphGenericAlarmEnableArray, numero_asse, varsInternal.languageJsonDataTranslate["genericAlarm"]), createGraphStepSeries1(varsInternal.logGraphGenericAlarmEnableArray, numero_asse, varsInternal.languageJsonDataTranslate["genericAlarm"]))
            numero_asse = numero_asse + 1;
            yaxis_chart.push(createGraphLineY(varsInternal.languageJsonDataTranslate["genericAlarm"], altezza, 200));
            altezza = altezza + 300;
        }
        if ($("#logGraphInputLevelEnable").is(':checked')) {
            varsInternal.logGraphInputLevelEnableArray.sort();
            series_chart.push(createGraphStepSeries(varsInternal.logGraphInputLevelEnableArray, numero_asse, varsInternal.languageJsonDataTranslate["inputLevel"]), createGraphStepSeries1(varsInternal.logGraphInputLevelEnableArray, numero_asse, varsInternal.languageJsonDataTranslate["inputLevel"]))
            numero_asse = numero_asse + 1;
            yaxis_chart.push(createGraphLineY(varsInternal.languageJsonDataTranslate["inputLevel"], altezza, 200));
            altezza = altezza + 300;
        }

        //uscite
        if ($("#logGraphEvIngresso").is(':checked')) {
            varsInternal.logGraphEvIngressoArray.sort();
            series_chart.push(createGraphStepSeries(varsInternal.logGraphEvIngressoArray, numero_asse, varsInternal.languageJsonDataTranslate["evIngresso"]), createGraphStepSeries1(varsInternal.logGraphEvIngressoArray, numero_asse, varsInternal.languageJsonDataTranslate["evIngresso"]))
            numero_asse = numero_asse + 1;
            yaxis_chart.push(createGraphLineY(varsInternal.languageJsonDataTranslate["evIngresso"], altezza, 200));
            altezza = altezza + 300;
        }
        if ($("#logGraphEvUscita").is(':checked')) {
            varsInternal.logGraphEvUscitaArray.sort();
            series_chart.push(createGraphStepSeries(varsInternal.logGraphEvUscitaArray, numero_asse, varsInternal.languageJsonDataTranslate["evUscita"]), createGraphStepSeries1(varsInternal.logGraphEvUscitaArray, numero_asse, varsInternal.languageJsonDataTranslate["evUscita"]))
            numero_asse = numero_asse + 1;
            yaxis_chart.push(createGraphLineY(varsInternal.languageJsonDataTranslate["evUscita"], altezza, 200));
            altezza = altezza + 300;
        }
        if ($("#logGraphEvScarico").is(':checked')) {
            varsInternal.logGraphEvScaricoArray.sort();
            series_chart.push(createGraphStepSeries(varsInternal.logGraphEvScaricoArray, numero_asse, varsInternal.languageJsonDataTranslate["evScarico"]), createGraphStepSeries1(varsInternal.logGraphEvScaricoArray, numero_asse, varsInternal.languageJsonDataTranslate["evScarico"]))
            numero_asse = numero_asse + 1;
            yaxis_chart.push(createGraphLineY(varsInternal.languageJsonDataTranslate["evScarico"], altezza, 200));
            altezza = altezza + 300;
        }
        if ($("#logGraphPompaOsmosi").is(':checked')) {
            varsInternal.logGraphPompaOsmosiArray.sort();
            series_chart.push(createGraphStepSeries(varsInternal.logGraphPompaOsmosiArray, numero_asse, varsInternal.languageJsonDataTranslate["pompaOsmosi"]), createGraphStepSeries1(varsInternal.logGraphPompaOsmosiArray, numero_asse, varsInternal.languageJsonDataTranslate["pompaOsmosi"]))
            numero_asse = numero_asse + 1;
            yaxis_chart.push(createGraphLineY(varsInternal.languageJsonDataTranslate["pompaOsmosi"], altezza, 200));
            altezza = altezza + 300;
        }
        if ($("#logGraphPompaDosaggio").is(':checked')) {
            varsInternal.logGraphPompaDosaggioArray.sort();
            series_chart.push(createGraphStepSeries(varsInternal.logGraphPompaDosaggioArray, numero_asse, varsInternal.languageJsonDataTranslate["pompaDosaggio"]), createGraphStepSeries1(varsInternal.logGraphPompaDosaggioArray, numero_asse, varsInternal.languageJsonDataTranslate["pompaDosaggio"]))
            numero_asse = numero_asse + 1;
            yaxis_chart.push(createGraphLineY(varsInternal.languageJsonDataTranslate["pompaDosaggio"], altezza, 200));
            altezza = altezza + 300;
        }
        if ($("#logGraphOutAlarm").is(':checked')) {
            varsInternal.logGraphOutAlarmArray.sort();
            series_chart.push(createGraphStepSeries(varsInternal.logGraphOutAlarmArray, numero_asse, varsInternal.languageJsonDataTranslate["outAlarm"]), createGraphStepSeries1(varsInternal.logGraphOutAlarmArray, numero_asse, varsInternal.languageJsonDataTranslate["outAlarm"]))
            numero_asse = numero_asse + 1;
            yaxis_chart.push(createGraphLineY(varsInternal.languageJsonDataTranslate["outAlarm"], altezza, 200));
            altezza = altezza + 300;
        }

        if ($("#logGraphTotUscita").is(':checked')) {
            varsInternal.logGraphTotUscitaArray.sort();
            series_chart.push(createGraphLineSeries(varsInternal.logGraphTotUscitaArray, numero_asse, varsInternal.languageJsonDataTranslate["totUscitaT"], 1));
            numero_asse = numero_asse + 1;
            yaxis_chart.push(createGraphLineY(varsInternal.languageJsonDataTranslate["totUscitaT"], altezza, 200));
            altezza = altezza + 300;
        }
        if ($("#logGraphTotIngresso").is(':checked')) {
            varsInternal.logGraphTotIngressoArray.sort();
            series_chart.push(createGraphLineSeries(varsInternal.logGraphTotIngressoArray, numero_asse, varsInternal.languageJsonDataTranslate["totIngressoT"], 1));
            numero_asse = numero_asse + 1;
            yaxis_chart.push(createGraphLineY(varsInternal.languageJsonDataTranslate["totIngressoT"], altezza, 200));
            altezza = altezza + 300;
        }
        if ($("#logGraphFlowMeterIngresso").is(':checked')) {
            varsInternal.logGraphFlowMeterIngressoArray.sort();
            series_chart.push(createGraphLineSeries(varsInternal.logGraphFlowMeterIngressoArray, numero_asse, varsInternal.languageJsonDataTranslate["portataIstantaneaIngresso"], 2));
            numero_asse = numero_asse + 1;
            yaxis_chart.push(createGraphLineY(varsInternal.languageJsonDataTranslate["portataIstantaneaIngresso"], altezza, 200));
            altezza = altezza + 300;
        }
        if ($("#logGraphFlowMeterUscita").is(':checked')) {
            varsInternal.logGraphFlowMeterUscitaArray.sort();
            series_chart.push(createGraphLineSeries(varsInternal.logGraphFlowMeterUscitaArray, numero_asse, varsInternal.languageJsonDataTranslate["portataIstantaneaUscita"], 2));
            numero_asse = numero_asse + 1;
            yaxis_chart.push(createGraphLineY(varsInternal.languageJsonDataTranslate["portataIstantaneaUscita"], altezza, 200));
            altezza = altezza + 300;
        }
        /*if (altezza > 350)
            altezza = altezza - 300;*/
        //creazione tabella
        indiceK = varsInternal.logGraphConductivityInputArray.length - 1;
        while (indiceK >= 0) {
            var arrayRiga = [];
            var date = new Date(varsInternal.logGraphConductivityInputArray[indiceK][0]);
            date = convertUTCDateToLocalDate(date);
            var theyear = date.getFullYear()
            var themonth = date.getMonth() + 1;
            var thetoday = date.getDate();
            var ore = date.getHours();
            var minuti = date.getMinutes();
            arrayRiga.push(get_numero_string(thetoday) + "/" + get_numero_string(themonth) + "/" + get_numero_string(theyear) + " " + get_numero_string(ore) + ":" + get_numero_string(minuti));
            if ($("#logGraphConductivityInput").is(':checked')) {
                arrayRiga.push(varsInternal.logGraphConductivityInputArray[indiceK][1]);
            }
            if ($("#logGraphConductivityOutput").is(':checked')) {
                arrayRiga.push(varsInternal.logGraphConductivityOutputArray[indiceK][1]);
            }
            if ($("#logGraphTemperatura").is(':checked')) {
                arrayRiga.push(varsInternal.logGraphTemperaturaArray[indiceK][1]);
            }

            if ($("#logGraphHighConductivityOutputEnable").is(':checked')) {
                arrayRiga.push(on_off(varsInternal.logGraphHighConductivityOutputEnableArray[indiceK][1]));
            }
            if ($("#logGraphHighConductivityInputEnable").is(':checked')) {
                arrayRiga.push(on_off(varsInternal.logGraphHighConductivityInputEnableArray[indiceK][1]));
            }
            if ($("#logGraphHighTemperatureEnable").is(':checked')) {
                arrayRiga.push(on_off(varsInternal.logGraphHighTemperatureEnableArray[indiceK][1]));
            }
            if ($("#logGraphInputTempPumpEnable").is(':checked')) {
                arrayRiga.push(on_off(varsInternal.logGraphInputTempPumpEnableArray[indiceK][1]));
            }
            if ($("#logGraphInputPressureHighEnable").is(':checked')) {
                arrayRiga.push(on_off(varsInternal.logGraphInputPressureHighEnableArray[indiceK][1]));
            }
            if ($("#logGraphInputPressureLowEnable").is(':checked')) {
                arrayRiga.push(on_off(varsInternal.logGraphInputPressureLowEnableArray[indiceK][1]));
            }
            if ($("#logGraphInputStbyEnable").is(':checked')) {
                arrayRiga.push(on_off(varsInternal.logGraphInputStbyEnableArray[indiceK][1]));
            }
            if ($("#logGraphInputDosingAlarmEnable").is(':checked')) {
                arrayRiga.push(on_off(varsInternal.logGraphInputDosingAlarmEnableArray[indiceK][1]));
            }
            if ($("#logGraphInputFilterEnable").is(':checked')) {
                arrayRiga.push(on_off(varsInternal.logGraphInputFilterEnableArray[indiceK][1]));
            }
            if ($("#logGraphGenericAlarmEnable").is(':checked')) {
                arrayRiga.push(on_off(varsInternal.logGraphGenericAlarmEnableArray[indiceK][1]));
            }
            if ($("#logGraphInputLevelEnable").is(':checked')) {
                arrayRiga.push(on_off(varsInternal.logGraphInputLevelEnableArray[indiceK][1]));
            }
             //uscite
            if ($("#logGraphEvIngresso").is(':checked')) {
                arrayRiga.push(on_off(varsInternal.logGraphEvIngressoArray[indiceK][1]));
            }

            if ($("#logGraphEvUscita").is(':checked')) {
                arrayRiga.push(on_off(varsInternal.logGraphEvUscitaArray[indiceK][1]));
            }
            if ($("#logGraphEvScarico").is(':checked')) {
                arrayRiga.push(on_off(varsInternal.logGraphEvScaricoArray[indiceK][1]));
            }
            if ($("#logGraphPompaOsmosi").is(':checked')) {
                arrayRiga.push(on_off(varsInternal.logGraphPompaOsmosiArray[indiceK][1]));
            }
            if ($("#logGraphPompaDosaggio").is(':checked')) {
                arrayRiga.push(on_off(varsInternal.logGraphPompaDosaggioArray[indiceK][1]));
            }
            if ($("#logGraphOutAlarm").is(':checked')) {
                arrayRiga.push(on_off(varsInternal.logGraphOutAlarmArray[indiceK][1]));
            }

            if ($("#logGraphTotUscita").is(':checked')) {
                arrayRiga.push(varsInternal.logGraphTotUscitaArray[indiceK][1]);
            }
            if ($("#logGraphTotIngresso").is(':checked')) {
                arrayRiga.push(varsInternal.logGraphTotIngressoArray[indiceK][1]);
            }
            if ($("#logGraphFlowMeterIngresso").is(':checked')) {
                arrayRiga.push(varsInternal.logGraphFlowMeterIngressoArray[indiceK][1]);
            }
            if ($("#logGraphFlowMeterUscita").is(':checked')) {
                arrayRiga.push(varsInternal.logGraphFlowMeterUscitaArray[indiceK][1]);
            }

            arrayTabella.push(arrayRiga)
            indiceK = indiceK -1;
        }
        //creazione tabella
        $("#chart_div").height(altezza + (numero_asse * 100));
        create_chart(series_chart, "LD OSIN", yaxis_chart);
        draw_tabella(arrayTabella);

    }
    function create_chart(series_val, Text_graph, yAxis) {
        //$('#chart_div').highcharts('StockChart', {
		
		
        chartLDOSIN = Highcharts.stockChart('chart_div', {
            rangeSelector: {
                enabled: false
            },
            title: {
                text: Text_graph
            },
            yAxis: yAxis,
			 labels: {
      align: 'left',
      x: 0,
      y: -2
    },
           // plotOptions: {
//                scatter: {
//                    marker: {
//                        radius: 1.2
//                    }
//                }
//            },
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

        $('#chart_table').html('<table cellpadding="0" cellspacing="0" border="0" class="display dynamicTable table table-striped table-bordered table-condensed" id="tableChartLoad"></table>');
        //$('#chart_table').html('<table class="display" id="tableChartLoad"></table>');
        $('#tableChartLoad').dataTable({
            dom: 'lfBrtip',
            //dom: 'Bfrtip',
            buttons: [
               //'copy', 'csv', 'excel', 'pdf', 'print'
               'copy', 'csv', 'excel', 'pdf', 'print'
            ],
            bSort: false,
            data: header_value,
            columns: header_array
        });
    }
    function on_off(ingresso) {
        if (ingresso == 1)
            return "ON"
        else
            return "OFF"
    }
    function get_numero_string(numero_valore) {
        if (numero_valore < 10)
            return "0" + numero_valore;
        else
            return numero_valore;
    }
    function convertUTCDateToLocalDate(convertdLocalTime) {


        var hourOffset = convertdLocalTime.getTimezoneOffset() / 60;

        convertdLocalTime.setHours(convertdLocalTime.getHours() + hourOffset);

        return convertdLocalTime;
    }
    function createGraphLineSeries(arrayStepTemp, numero_asse, strStepTemp, numeroDecimaliLog) {
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
                valueDecimals: numeroDecimaliLog
            }
        });
    }
    function createGraphLineY(strStepTemp, altezzaTemp, dimensione) {
        return ({
            title: {
                  align: 'right',
      x: 100,
      y: -50
              //  text: strStepTemp
				
            },
            opposite: true,
            id: 'ch2_val',
            top: altezzaTemp,
            left:0,
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
    //--------------------------end gestione del grafico dei log

}
//------------------------------------------------------------------
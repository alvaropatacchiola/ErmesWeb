var state = { "publish": 0, "loadAllData": 1, "notConnected": 2, "readData": 3, "readSetpoint": 4, "sendData": 5, "busy": 6 };
var milliseconds = 5000; //ms di timeout nella attesa di risposta
var millisecondsRetry = 10000; //ms di timeout nel riprovare se è connsesa
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

        languageJson: null,
        languageJsonWarningAlarm: null,
        languageJsonDataTranslate: null,
        languageJsonSettingsMessage : null,
        pumpCapacityGlobal: 0.0,
        arraySendData: [],
        statusSendData : false,
        arrayIndiciProgrammazioniSettimanali:[0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0]
    };

    this.construct = function (options) {
        $.extend(vars, options);
        varsInternal.stateConnection = state.publish;
        varsInternal.languageJson = jQuery.parseJSON(t0101[vars.languageSet]);
        varsInternal.languageJsonWarningAlarm = jQuery.parseJSON(t0101AlarmWarning[vars.languageSet]);
        varsInternal.languageJsonSettingsMessage = jQuery.parseJSON(t0101MessageSetpointDataEntry[vars.languageSet]);
        
        varsInternal.languageJsonDataTranslate = jQuery.parseJSON(t0101DataTranslate[vars.languageSet]);
        
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
        
        //-------impostazione delle lingue statiche nella pagine
        //$(".timeControll").each(function () {
 
        //-----------------
    };

    this.construct(options);

    this.createConnection = function () {
        console.log("verifica:" + varsInternal.stateConnection)
        messaggioTesto("Check Connection.");

        if (typeof (WebSocket) !== 'undefined') {
            varsInternal.socket = new WebSocket("ws://localhost:10154/pompe/websocket.ashx");
        } else {
            varsInternal.socket = new MozWebSocket("ws://localhost:10154/pompe/websocket.ashx");
        }
        varsInternal.socket.onclose = function () {
            alert("socket closed")
        }
        varsInternal.socket.onopen = function () {
            //alert("send Publish")
            //appena aperta connessione comincio a scaricare i dati dalla pompa
            varsInternal.socket.send("PUBLISH" + vars.serialNumber);
        }
        varsInternal.socket.onmessage = function (msg) {
            varsInternal.reader = new FileReader();

            varsInternal.reader.onloadend = () => {
                var data = varsInternal.reader.result;
                var array = new Uint8Array(data);
                switch (varsInternal.stateConnection) {
                    case state.publish:
                        if (((uint8arrayToStringMethod(array).indexOf("PUBLISHOK")) >= 0) ||((uint8arrayToStringMethod(array).indexOf("bsyR")) >= 0)) {
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
                            if (arrayToData(vars.arrayRisposteAll[0], 3 + 112, 1))
                            {
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
                                $(".progress-bar-animated").css("width",  "0%")
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
        if (varsInternal.numeroTentativiRichieste > 4) {//dopo 4 tentativi di richiesta non andati a b uon fine
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
        console.log("array InviatoNEW:" + arrayDef + ":" + varsInternal.indexGlobalProtocollo + ":" + (arrayToSendMQTT).length)
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
        $("#messageStart" + vars.serialNumber).text(stringaTesto);
    }
    // modifica grafica in funzione del protocollo
    function updateGrafica() {
        var testoModalitaLavoro = '';
        var testoDosaggioIstantaneo = '';
        var dosaggioIstantaneo = 0.0;
        
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

        var startDelay = 0;
        var startDelayMinuti = 0;
        var startDelaySecondi = 0;

        if ((vars.arrayRisposteAll).length > 0) {

            startDelay = arrayToData(vars.arrayRisposteAll[0], 3 + 138, 1);
            startDelayMinuti = arrayToData(vars.arrayRisposteAll[0], 3 + 139, 1);
            startDelaySecondi = arrayToData(vars.arrayRisposteAll[0], 3 + 140, 1);

            dosaggioIstantaneo = arrayToData(vars.arrayRisposteAll[0], 3 + 8, 4);// valore del dosaggio istantaneo
            // se Galloni scrivo x.xxx gal/h se litri sscrivo: xxx ml/h se <1 altrimenti x.xxx l/h
            testoDosaggioIstantaneo = makeCalcoloLitriOrGallons(arrayToData(vars.arrayRisposteAll[0], 3 + 22, 1), dosaggioIstantaneo);//arrayToData(vars.arrayRisposteAll[0], 3 + 22, 1) == 1 ? (dosaggioIstantaneo / 1000).toFixed(3) : ((dosaggioIstantaneo / 1000 > 0 && dosaggioIstantaneo / 1000 < 1) ? dosaggioIstantaneo.toString() : (dosaggioIstantaneo / 1000).toFixed(3))
            testoUnitadiMisura = makeUnitLitriOrGallonsHora(arrayToData(vars.arrayRisposteAll[0], 3 + 22, 1), dosaggioIstantaneo); //arrayToData(vars.arrayRisposteAll[0], 3 + 22, 1) == 1 ? "Gal/h" : ((dosaggioIstantaneo / 1000 > 0 && dosaggioIstantaneo / 1000 < 1) ? "ml/h" : "l/h")

            //Velocità di rotazione del motore, con 1 ciffre decimali, espressa in %.Da0%a 100% 
            testoFrequenza = (arrayToData(vars.arrayRisposteAll[0], 3 + 12, 4) / 1000) == 100.0 ? "100 %" : (arrayToData(vars.arrayRisposteAll[0], 3 + 12, 4) / 1000).toFixed(3) + "%";
            //SLOW MODE
            testoSlowMode = (arrayToData(vars.arrayRisposteAll[0], 3 + 35, 1)).toFixed(1) + "%";
            //console.log(testoUnitadiMisura)
            switch (arrayToData(vars.arrayRisposteAll[1], 3 + 1, 1)) { // gestione ON / OFF
                case 0:// OFF
                    testoModalitaLavoro = varsInternal.languageJson.pumpOff;
                    testoDosaggioIstantaneo = "0"
                    break;
                case 1:// ON
                    if (startDelay > 0) {
                        testoModalitaLavoro = varsInternal.languageJson.startDelay
                        testoDosaggioIstantaneo = (startDelayMinuti < 10 ? "0" + startDelayMinuti.toString() : startDelayMinuti.toString()) + " . " + (startDelaySecondi < 10 ? "0" + startDelaySecondi.toString() : startDelaySecondi.toString())
                        testoUnitadiMisura = "";
                        break;
                    }
                    switch (arrayToData(vars.arrayRisposteAll[1], 3 + 2, 1)) { // gestione modalità di lavoro
                        case 0://Constant
                            testoModalitaLavoro = varsInternal.languageJson.modalita0;
                            //ok niente per cui nascosto
                            $("#valore1" + vars.serialNumber).hide();
                            break;
                        case 1://cc per pulse
                            testoModalitaLavoro = varsInternal.languageJson.modalita1;
                            //ok p/m netto
                            $("#valore1" + vars.serialNumber).show();
                            testoPulseMinute = arrayToData(vars.arrayRisposteAll[0], 3 + 117, 2).toString() + "P/m"
                            break;
                        case 2://ppm
                            testoModalitaLavoro = varsInternal.languageJson.modalita2;
                            //ok p/m netto
                            $("#valore1" + vars.serialNumber).show();
                            if (checkUpKeep())
                                testoPulseMinute = upKeepStr();
                            else
                                testoPulseMinute = arrayToData(vars.arrayRisposteAll[0], 3 + 117, 2).toString() + "P/m"
                            break;
                        case 3://perc
                            testoModalitaLavoro = varsInternal.languageJson.modalita3;
                            //ok p/m netto
                            $("#valore1" + vars.serialNumber).show();
                            if (checkUpKeep())
                                testoPulseMinute = upKeepStr();
                            else
                                testoPulseMinute = arrayToData(vars.arrayRisposteAll[0], 3 + 117, 2).toString() + "P/m"
                            break;
                        case 4://MLQ
                            testoModalitaLavoro = varsInternal.languageJson.modalita4;
                            //ok p/m netto
                            $("#valore1" + vars.serialNumber).show();
                            if (checkUpKeep())
                                testoPulseMinute = upKeepStr();
                            else
                                testoPulseMinute = arrayToData(vars.arrayRisposteAll[0], 3 + 117, 2).toString() + "P/m"
                            break;
                        case 5://batch
                            testoModalitaLavoro = varsInternal.languageJson.modalita5;
                            //ok litri o gal con tre decimali dopo la virgola con regola sotto a 1 scrivo ml galloni no.
                            //var litriOGalloni = arrayToData(varsInternal.arrayReadRealTimeResult[0], 3 + 117, 2);// valore del dosaggio istantaneo
                            var litriOGalloni = arrayToData(vars.arrayRisposteAll[0], 3 + 125, 8) / 10000;// valore del dosaggio istantaneo
                            testoPulseMinute = makeUnitLitriOrGallons(arrayToData(vars.arrayRisposteAll[0], 3 + 22, 1), litriOGalloni);//arrayToData(vars.arrayRisposteAll[0], 3 + 22, 1) == 1 ? (litriOGalloni / 1000).toFixed(3) + " Gal" : ((litriOGalloni / 1000 > 0 && litriOGalloni / 1000 < 1) ? litriOGalloni.toString() + " mL" : (litriOGalloni / 1000).toFixed(3) + " L")
                            $("#valore1" + vars.serialNumber).show();
                            break;
                        case 6://volt
                            testoModalitaLavoro = varsInternal.languageJson.modalita6;
                            //ok volt diviso 10 Volt
                            $("#valore1" + vars.serialNumber).show();
                            testoPulseMinute = (arrayToData(vars.arrayRisposteAll[0], 3 + 117, 2) / 10).toFixed(1) + "V"
                            break;
                        case 7://mA
                            testoModalitaLavoro = varsInternal.languageJson.modalita7;
                            //ok mA diviso 10 mA
                            $("#valore1" + vars.serialNumber).show();
                            testoPulseMinute = (arrayToData(vars.arrayRisposteAll[0], 3 + 117, 2) / 10).toFixed(1) + "mA"
                            break;
                        case 8://pulse
                            testoModalitaLavoro = varsInternal.languageJson.modalita8;
                            //ok p/m netto
                            $("#valore1" + vars.serialNumber).show();
                            testoPulseMinute = arrayToData(vars.arrayRisposteAll[0], 3 + 117, 2).toString() + "P/m"
                            break;
                        case 9://pause - work
                            testoModalitaLavoro = varsInternal.languageJson.modalita9;
                            //ok tempo in m:s
                            $("#valore1" + vars.serialNumber).show();
                            if (arrayToData(vars.arrayRisposteAll[0], 3 + 113, 1) == 1) {// sto in pause
                                testoPulseMinute = varsInternal.languageJson.pauseText + " " + arrayToData(vars.arrayRisposteAll[0], 3 + 121, 1).toString() + ":" + arrayToData(vars.arrayRisposteAll[0], 3 + 122, 1).toString()
                            }
                            else {//sto in lavoro
                                testoPulseMinute = varsInternal.languageJson.workText + " " + arrayToData(vars.arrayRisposteAll[0], 3 + 121, 1).toString() + ":" + arrayToData(vars.arrayRisposteAll[0], 3 + 122, 1).toString()
                            }
                            break;
                        case 10://weekly
                            testoModalitaLavoro = varsInternal.languageJson.modalita10;

                            $("#valore1" + vars.serialNumber).show();
                            //ok litri o gal con tre decimali dopo la virgola con regola sotto a 1 scrivo ml galloni no.
                            var litriOGalloni = arrayToData(vars.arrayRisposteAll[0], 3 + 125, 8) / 100;// valore del dosaggio istantaneo
                            if (arrayToData(vars.arrayRisposteAll[0], 3 + 114, 1) == 1) {//start
                                testoPulseMinute = makeUnitLitriOrGallons(arrayToData(vars.arrayRisposteAll[0], 3 + 22, 1), litriOGalloni);//arrayToData(vars.arrayRisposteAll[0], 3 + 22, 1) == 1 ? (litriOGalloni / 1000).toFixed(3) + " Gal" : ((litriOGalloni / 1000 > 0 && litriOGalloni / 1000 < 1) ? litriOGalloni.toString() + " mL" : (litriOGalloni / 1000).toFixed(3) + " L")
                            }
                            else {//stop  nex prog
                                testoPulseMinute = "Next Prog P" + (arrayToData(vars.arrayRisposteAll[0], 3 + 115, 1) + 1).toString()
                            }

                            break;
                        case 11://undefined
                            testoModalitaLavoro = varsInternal.languageJson.modalita11;
                            $("#valore1" + vars.serialNumber).hide();
                            break;
                        case 12://external input
                            testoModalitaLavoro = varsInternal.languageJson.modalita12;
                            //ok nulla
                            $("#valore1" + vars.serialNumber).hide();
                            break;

                    }
                    break;

            }

        }
        // controlloo Alert
        if ((arrayToData(vars.arrayRisposteAll[0], 3 + 1, 1) == 1) && (arrayToData(vars.arrayRisposteAll[0], 3 + 2, 1) == 0)) {//warning livello
            statoWarning = true;
            txtWarning.push(varsInternal.languageJsonWarningAlarm.warningLevel);
        }
        if ((arrayToData(vars.arrayRisposteAll[0], 3 + 4, 1) == 1) && (arrayToData(vars.arrayRisposteAll[0], 3 + 28, 1) == 1)) {//warning Overflow
            statoWarning = true;
            txtWarning.push(varsInternal.languageJsonWarningAlarm.warningOverflow);
        }
        //----- end controllo alert
        // controlloo allarmi
        if ((arrayToData(vars.arrayRisposteAll[0], 3 + 1, 1) == 1) && (arrayToData(vars.arrayRisposteAll[0], 3 + 2, 1) == 1)) {//Alarm livello
            statoAllarme = true;
            txtAllarme.push(varsInternal.languageJsonWarningAlarm.alarmLevel);
        }
        if ((arrayToData(vars.arrayRisposteAll[0], 3 + 4, 1) == 1) && (arrayToData(vars.arrayRisposteAll[0], 3 + 28, 1) == 0)) {//Alarm overflow
            statoAllarme = true;
            txtAllarme.push(varsInternal.languageJsonWarningAlarm.alarmOverflow);
        }
        if ((arrayToData(vars.arrayRisposteAll[0], 3 + 5, 1) == 1)) {//Alarm temperatura
            statoAllarme = true;
            txtAllarme.push(varsInternal.languageJsonWarningAlarm.alarmTemperatura);
        }
        if ((arrayToData(vars.arrayRisposteAll[0], 3 + 6, 1) == 1)) {//Alarm Input
            statoAllarme = true;
            txtAllarme.push(varsInternal.languageJsonWarningAlarm.alarmInput);
        }
        if ((arrayToData(vars.arrayRisposteAll[0], 3 + 7, 1) == 1)) {//Alarm Motore Bloccato
            statoAllarme = true;
            txtAllarme.push(varsInternal.languageJsonWarningAlarm.alarmMotoreBloccato);
        }
        //--------end controlloo allarmi
        // controlloo stby
        if ((arrayToData(vars.arrayRisposteAll[0], 3 + 3, 1) == 1)) {//warning Standby
            statoStby = true;
            txtStby.push(varsInternal.languageJsonWarningAlarm.alarmStby);
        }
        //-------end  controlloo stby
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
        if ((statoAllarme) || (statoWarning) ||(statoStby)) {
            var htmlAllarme = "";
            var i;
            if (statoAllarme){
                for (i = 0; i < txtAllarme.length; ++i) {
                    htmlAllarme = htmlAllarme + "<div class=\"alert alert-danger alert-outlined\" role=\"alert\">"+txtAllarme[i]+ "</div>"
                }
            }
            if (statoWarning){
                for (i = 0; i < txtWarning.length; ++i) {
                    htmlAllarme = htmlAllarme + "<div class=\"alert alert-warning alert-outlined\" role=\"alert\">"+txtWarning[i]+ "</div>"
                }
            }
            if (statoStby){
                for (i = 0; i < txtStby.length; ++i) {
                    htmlAllarme = htmlAllarme + "<div class=\"alert alert-light alert-outlined\" role=\"alert\">" + txtStby[i] + "</div>"
                }
            }
            $("#prismaAlarmWarnigList").html(htmlAllarme);
        }
        else{
            $("#prismaAlarmWarnigList").html("<div class=\"alert alert-primary alert-outlined\" role=\"alert\">"+varsInternal.languageJsonWarningAlarm.noncisonoallarmi+"<br></div>")
        }
        //----end elenco allarmi prisma


        // ---- status connectione e alarm 
        
        // Statistiche pompa

        //STATISTICHE PARZIALI -  Quantità  di prodotto dosata dalla data dell'ultimo reset delle statistiche
        var dosatoParziale = arrayToData(vars.arrayRisposteAll[0], 3 + 52, 8);// 
        var dosatoParzialeStringa = makeCalcoloLitriOrGallons(arrayToData(vars.arrayRisposteAll[0], 3 + 22, 1), dosatoParziale);
        var unitaLitriOrGalloni = makeUnitLitriOrGallons(arrayToData(vars.arrayRisposteAll[0], 3 + 22, 1), dosatoParziale);

        $("#dosatoParziale").text(dosatoParzialeStringa + " " + unitaLitriOrGalloni)
        //------------------end STATISTICHE PARZIALI -  Quantità  di prodotto dosata dalla data dell'ultimo reset delle statistiche

        //STATISTICHE PARZIALI - Quantità di liquido passata attraverso il contatore dalla data dell’ultimo reset delle statistiche. 
        var mcParziale = arrayToData(vars.arrayRisposteAll[0], 3 + 60, 8);// 
        var unitaMcOrGalloni = makeMcOrGallons(arrayToData(vars.arrayRisposteAll[0], 3 + 22, 1));
        $("contatoreParziale").text(mcParziale + " " + unitaMcOrGalloni)
        //-----------------end STATISTICHE PARZIALI - Quantità di liquido passata attraverso il contatore dalla data dell’ultimo reset delle statistiche. 

        //STATISTICHE PARZIALI -  Quantità di prodotto dosata dalle 00 alle 24 del giorno prima
        var dosatoParziale24 = arrayToData(vars.arrayRisposteAll[0], 3 + 68, 8);// 
        var dosatoParziale24Stringa = makeCalcoloLitriOrGallons(arrayToData(vars.arrayRisposteAll[0], 3 + 22, 1), dosatoParziale24);
        unitaLitriOrGalloni = makeUnitLitriOrGallons(arrayToData(vars.arrayRisposteAll[0], 3 + 22, 1), dosatoParziale24);
        $("dosatoParzialeUltime24").text("24h : " + dosatoParziale24Stringa + " " + unitaLitriOrGalloni)
        //-----------------end STATISTICHE PARZIALI -  Quantità di prodotto dosata dalle 00 alle 24 del giorno prima

        //STATISTICHE PARZIALI - Quantità  liquido  che passa attraverso il contatore dalle 00 alle 24 del giorno prima
        var mcParziale24 = arrayToData(vars.arrayRisposteAll[0], 3 + 76, 8);// 
        $("contatoreParzialeUltime24").text("24h : " + mcParziale24 + " " + unitaMcOrGalloni);
        //-----------------end STATISTICHE PARZIALI - Quantità  liquido  che passa attraverso il contatore dalle 00 alle 24 del giorno prima

        //var unitaMcOrGalloni = arrayToData(vars.arrayRisposteAll[0], 3 + 22, 1) == 1 ? "Gal" : ((dosaggioIstantaneo / 1000 > 0 && dosaggioIstantaneo / 1000 < 1) ? "mc" : "l")
        //STATISTICHE TOTALI - Quantità di prodotto dosato dalla messa in funzione della pompa
        var dosatoTotale = arrayToData(vars.arrayRisposteAll[0], 3 + 96, 8);// 
        
        var dosatoTotaleStringa = makeCalcoloLitriOrGallons(arrayToData(vars.arrayRisposteAll[0], 3 + 22, 1), dosatoTotale);
        unitaLitriOrGalloni = makeUnitLitriOrGallons(arrayToData(vars.arrayRisposteAll[0], 3 + 22, 1), dosatoTotale);
        $("#dosatoTotale").text(dosatoTotaleStringa + " " + unitaLitriOrGalloni)
        //-------------------end STATISTICHE TOTALI - Quantità di prodotto dosato dalla messa in funzione della pompa

        //STATISTICHE TOTALI - Quantità di liquido passato attraverso il contatore dalla messa in funzione della pompa
        var mcTotale = arrayToData(vars.arrayRisposteAll[0], 3 + 60, 8);// 
        $("#contatoreTotale").text(mcTotale + " " + unitaMcOrGalloni);
        //-----------------end STATISTICHE TOTALI - Quantità di liquido passato attraverso il contatore dalla messa in funzione della pompa
        //STATISTICHE PARZIALI -data e ora ultimo reset
        $("#dalParzialeData").text(makeData(arrayToData(vars.arrayRisposteAll[0], 3 + 90, 2), arrayToData(vars.arrayRisposteAll[0], 3 + 92, 2), arrayToData(vars.arrayRisposteAll[0], 3 + 94, 2), arrayToData(vars.arrayRisposteAll[1], 3 + 92, 1)));
        $("#dalParzialeOra").text(makeOre(arrayToData(vars.arrayRisposteAll[0], 3 + 84, 2), arrayToData(vars.arrayRisposteAll[0], 3 + 86, 2), arrayToData(vars.arrayRisposteAll[1], 3 + 93, 1)));

        //-----------------endSTATISTICHE PARZIALI -data e ora ultimo reset
        // ---------------end Statistiche pompa

        //riserva
        var riserva = arrayToData(vars.arrayRisposteAll[0], 3 + 18, 4);// 
        var riservaStringa = makeCalcoloLitriOrGallons(arrayToData(vars.arrayRisposteAll[0], 3 + 22, 1), riserva);
        unitaLitriOrGalloni = makeUnitLitriOrGallons(arrayToData(vars.arrayRisposteAll[0], 3 + 22, 1), riserva);
        $("#prismaRiserva").text(riservaStringa + " " + unitaLitriOrGalloni);
        //-----end riserva

        //portata istantanea
        var portataIstantanea = makePortataIstantanea(arrayToData(vars.arrayRisposteAll[0], 3 + 23, 1), arrayToData(vars.arrayRisposteAll[0], 3 + 117, 2), arrayToData(vars.arrayRisposteAll[0], 3 + 24, 2));
        $("#prismaPortataIstantanea").text(portataIstantanea);
        //-----end portata istantanea
        $("#modalitaLavoro" + vars.serialNumber).text(testoModalitaLavoro);

        $("#portata" + vars.serialNumber).html(testoDosaggioIstantaneo + "<span class=\"little\">" + testoUnitadiMisura + "</span>");

        //$("#valore1" + vars.serialNumber).html(testoPulseMinute + "<span class=\"badge badge-black badge-pill\" tabindex=\"0\" data-toggle=\"tooltip\" title=\"" + varsInternal.languageJson.titlePortata + "\"><i class=\"mdi mdi-information\"></i></span>");
        $("#valore1" + vars.serialNumber).attr("data-original-title", varsInternal.languageJson.titlePortata)
        $("#valore1" + vars.serialNumber).html(testoPulseMinute + "<span></span><i class=\"mdi mdi-information\"></i>");
        //$("#valore2" + vars.serialNumber).html(testoFrequenza + "<span class=\"badge badge-black badge-pill\" tabindex=\"0\" data-toggle=\"tooltip\" title=\"" + varsInternal.languageJson.titleFrequenza + "\"><i class=\"mdi mdi-signal-cellular-outline\"></i></span>");
        $("#valore2" + vars.serialNumber).attr("data-original-title", varsInternal.languageJson.titleFrequenza)
        $("#valore2" + vars.serialNumber).html(testoFrequenza + "<span></span><i class=\"mdi mdi-signal-cellular-outline\"></i>");
        //$("#valore3" + vars.serialNumber).html(testoSlowMode + "<span class=\"badge badge-black badge-pill\" tabindex=\"0\" data-toggle=\"tooltip\" title=\"" + varsInternal.languageJson.titleSlow + "\">	 <i class=\"mdi mdi-eject\"></i></span>");
        $("#valore3" + vars.serialNumber).attr("data-original-title", varsInternal.languageJson.titleSlow)
        $("#valore3" + vars.serialNumber).html(testoSlowMode + "<span></span><i class=\"mdi mdi-eject\"></i>");

    }
    //grafica setpoint
    function updateGraficaSetpoint()
    {
        var variabileDiAppoggio = 0.0;
        var litriOraGalloniOra = "";
        //software release
        
        $("#softwareReleaseNum").text((arrayToData(vars.arrayRisposteAll[1], 3 + 94, 1) / 10).toFixed(1));
        //end software release

        //impostazione grafica modalità di lavoro
        $("#tabAdvanced > .nav-item").each(function () {
            $(this).children().removeClass("active")
        });
        $("#tabSubAdvanced > .tab-pane").each(function () {
            $(this).removeClass("active")
            console.log("ciao")
        });
        switch (arrayToData(vars.arrayRisposteAll[1], 3 + 2, 1)) { // gestione modalità di lavoro
            case 0://Constant
                $("#nav-profile-constant").addClass("active")
                $("#nav-tabs-constant").addClass("active")
                break;
            case 1://cc per pulse
                $("#nav-profile-ccpulse").addClass("active")
                $("#nav-tabs-ccpulse").addClass("active")
                break;
            case 2://ppm
                $("#nav-profile-ppm").addClass("active")
                $("#nav-tabs-ppm").addClass("active")
                break;
            case 3://perc
                $("#nav-profile-perc").addClass("active")
                $("#nav-tabs-perc").addClass("active")
                break;
            case 4://MLQ
                $("#nav-profile-mlq").addClass("active")
                $("#nav-tabs-mlq").addClass("active")
                break;
            case 5://batch
                $("#nav-profile-batch").addClass("active")
                $("#nav-tabs-batch").addClass("active")
                break;
            case 6://volt
                $("#nav-profile-volt").addClass("active")
                $("#nav-tabs-volt").addClass("active")
                break;
            case 7://mA
                $("#nav-profile-ma").addClass("active")
                $("#nav-tabs-ma").addClass("active")
                break;
            case 8://pulse
                $("#nav-profile-pulse").addClass("active")
                $("#nav-tabs-pulse").addClass("active")
                break;
            case 9://pause - work
                $("#nav-profile-pausework").addClass("active")
                $("#nav-tabs-pausework").addClass("active")
                break;
            case 10://weekly
                $("#nav-profile-weekly").addClass("active")
                $("#nav-tabs-weekly").addClass("active")
                break;
            case 11://undefined

                break;
            case 12://external input
                $("#nav-profile-external").addClass("active")
                $("#nav-tabs-external").addClass("active")
                break;

        }

        //modalità costante
        variabileDiAppoggio = arrayToData(vars.arrayRisposteAll[1], 3 + 3, 4);// Quantità da dosare in modalità costante espressa in L/h (Gal/h), con tre cifre decimali. 
        litriOraGalloniOra = makeUnitLitriOrGallonsHora(arrayToData(vars.arrayRisposteAll[0], 3 + 22, 1), variabileDiAppoggio);
        $("#constantDosaggio").attr("placeholder",litriOraGalloniOra)
        $("#constantDosaggio").val((variabileDiAppoggio / 1000).toFixed(3))
        $("#constantDosaggioUnit").text( litriOraGalloniOra)
        //modalità costante

        //modalità cc pulse
        //diluizione
        if (arrayToData(vars.arrayRisposteAll[1], 3 + 95, 1) == 1)
        {
            $("#diluizioneSet").prop("checked", true)
        }
        else
            $("#diluizioneSet").prop("checked", false)

        variabileDiAppoggio = arrayToData(vars.arrayRisposteAll[1], 3 + 7, 4);//Quantità da  dosare espressa in ml per ogni impulso in ingresso, con quattro cifre decimali.
        $("#ccPulseSetpoint").attr("placeholder", "ml/Pulse")
        $("#ccPulseSetpoint").val((variabileDiAppoggio / 10000).toFixed(4))


        setWaterMeter("waterMeterCCPulseSetpoint", "waterMeterKCCPulseSetpoint")
        //waterMeterCCPulseSetpoint

        //end modalità cc pulse
        //modalita ppm

        variabileDiAppoggio = arrayToData(vars.arrayRisposteAll[1], 3 + 11, 4);// Quantità di prodotto da dosare in funzione della quantità di acqua in ingresso. Espresso in ppm (parti per milione) con due cifre decimali.
        $("#ppmSetpoint").val((variabileDiAppoggio / 100).toFixed(2))
        variabileDiAppoggio = arrayToData(vars.arrayRisposteAll[1], 3 + 15, 2);// Concentrazione del prodotto da dosare espressa in percentuale con una cifra decimale. Il valore può variare da 0,1% a 100,0% prodotto puro. 
        $("#concentrazioneSetpoint").val((variabileDiAppoggio / 10).toFixed(1))

        setWaterMeter("waterMeterPPMSetpoint", "waterMeterKPPMSetpoint")
        setUpKeepSetpoit("upkeepPPMSet", "ppmUpkeepGroup", "timeoutUpkeepPPMOreSetpoint", "timeoutUpkeepPPMMinutiSetpoint")

        variabileDiAppoggio = arrayToData(vars.arrayRisposteAll[1], 3 + 88, 4);// Quantità da dosare in modalità costante espressa in L/h (Gal/h), con tre cifre decimali. 
        litriOraGalloniOra = makeUnitLitriOrGallonsHora(arrayToData(vars.arrayRisposteAll[0], 3 + 22, 1), variabileDiAppoggio);
        $("#upkeepDosaggioPPM").attr("placeholder", litriOraGalloniOra)
        $("#upkeepDosaggioPPM").val((variabileDiAppoggio / 1000).toFixed(3))
        $("#upkeepDosaggioPPMUnit").text(litriOraGalloniOra)
        //end modalita ppm
        //modalita perc
        variabileDiAppoggio = arrayToData(vars.arrayRisposteAll[1], 3 + 17, 4);// Quantità di prodotto da dosare in funzione della quantità di acqua in ingresso.
        $("#percSetpoint").val((variabileDiAppoggio / 100).toFixed(2))
        variabileDiAppoggio = arrayToData(vars.arrayRisposteAll[1], 3 + 21, 2);// Concentrazione del prodotto da dosare espressa in percentuale con una cifra decimale. 
        $("#concentrazionePercSetpoint").val((variabileDiAppoggio / 10).toFixed(1))

        setWaterMeter("waterMeterPercSetpoint", "waterMeterKPercSetpoint")
        setUpKeepSetpoit("upkeepPercSet", "percUpkeepGroup", "timeoutUpkeepOrePercSetpoint", "timeoutUpkeepMinutiPercSetpoint")

        variabileDiAppoggio = arrayToData(vars.arrayRisposteAll[1], 3 + 88, 4);// Quantità da dosare in modalità costante espressa in L/h (Gal/h), con tre cifre decimali. 
        litriOraGalloniOra = makeUnitLitriOrGallonsHora(arrayToData(vars.arrayRisposteAll[0], 3 + 22, 1), variabileDiAppoggio);
        $("#upkeepDosaggioPerc").attr("placeholder", litriOraGalloniOra)
        $("#upkeepDosaggioPerc").val((variabileDiAppoggio / 1000).toFixed(3))
        $("#upkeepDosaggioPercUnit").text(litriOraGalloniOra)

        //-------------end grafica setpoint perc

        //modalita mlq
        variabileDiAppoggio = arrayToData(vars.arrayRisposteAll[1], 3 + 23, 4);// Quantità di prodotto da dosare in funzione della quantità di acqua in ingresso. Espresso in MLQ (millilitri x quintale) con due cifre decimali. 
        $("#mlqSetpoint").val((variabileDiAppoggio / 100).toFixed(2))
        variabileDiAppoggio = arrayToData(vars.arrayRisposteAll[1], 3 + 27, 2);// Concentrazione del prodotto da dosare espressa in percentuale con una cifra decimale. 
        $("#concentrazionemlqSetpoint").val((variabileDiAppoggio / 10).toFixed(1))

        setWaterMeter("waterMetermlqSetpoint", "waterMeterKmlqSetpoint")
        setUpKeepSetpoit("upkeepmlqSet", "mlqUpkeepGroup", "timeoutUpkeepOremlqSetpoint", "timeoutUpkeepMinutimlqSetpoint")

        variabileDiAppoggio = arrayToData(vars.arrayRisposteAll[1], 3 + 88, 4);// Quantità da dosare in modalità costante espressa in L/h (Gal/h), con tre cifre decimali. 
        litriOraGalloniOra = makeUnitLitriOrGallonsHora(arrayToData(vars.arrayRisposteAll[0], 3 + 22, 1), variabileDiAppoggio);
        $("#upkeepDosaggiomlq").attr("placeholder", litriOraGalloniOra)
        $("#upkeepDosaggiomlq").val((variabileDiAppoggio / 1000).toFixed(3))
        $("#upkeepDosaggiomlqcUnit").text(litriOraGalloniOra)

        //-------------end grafica setpoint mlq
        //modalità batch
        variabileDiAppoggio = arrayToData(vars.arrayRisposteAll[1], 3 + 73, 4);
        litriOraGalloniOra = makeUnitLitriOrGallons(arrayToData(vars.arrayRisposteAll[0], 3 + 22, 1), variabileDiAppoggio);
        $("#batchUnit").text(litriOraGalloniOra)
        $("#batchSetpoint").attr("placeholder", litriOraGalloniOra)
        $("#batchSetpoint").val((variabileDiAppoggio / 1000).toFixed(3))
        $("#contactSetpoint> [value=" + arrayToData(vars.arrayRisposteAll[1], 3 + 77, 1).toString() + "]").prop("selected", true) //1: N.C. - 0: N.O. 
        //-------------end modalità batch
        //modalità volt
        variabileDiAppoggio = arrayToData(vars.arrayRisposteAll[1], 3 + 29, 2);
        $("#voltHighSetpoint").val((variabileDiAppoggio / 10).toFixed(1))
        variabileDiAppoggio = arrayToData(vars.arrayRisposteAll[1], 3 + 33, 4);// Quantità da dosare in modalità costante espressa in L/h (Gal/h), con tre cifre decimali. 
        litriOraGalloniOra = makeUnitLitriOrGallonsHora(arrayToData(vars.arrayRisposteAll[0], 3 + 22, 1), variabileDiAppoggio);
        $("#voltHighDosaggio").attr("placeholder", litriOraGalloniOra)
        $("#voltHighDosaggio").val((variabileDiAppoggio / 1000).toFixed(3))
        $("#voltHighDosaggioUnit").text(litriOraGalloniOra)


        variabileDiAppoggio = arrayToData(vars.arrayRisposteAll[1], 3 + 31, 2);
        $("#voltLowSetpoint").val((variabileDiAppoggio / 10).toFixed(1))
        variabileDiAppoggio = arrayToData(vars.arrayRisposteAll[1], 3 + 37, 4);// Quantità da dosare in modalità costante espressa in L/h (Gal/h), con tre cifre decimali. 
        litriOraGalloniOra = makeUnitLitriOrGallonsHora(arrayToData(vars.arrayRisposteAll[0], 3 + 22, 1), variabileDiAppoggio);
        $("#voltLowDosaggio").attr("placeholder", litriOraGalloniOra)
        $("#voltLowDosaggio").val((variabileDiAppoggio / 1000).toFixed(3))
        $("#voltLowDosaggioUnit").text(litriOraGalloniOra)
        //-------------end modalità volt

        //modalità ma
        variabileDiAppoggio = arrayToData(vars.arrayRisposteAll[1], 3 + 41, 2);
        $("#maHighSetpoint").val((variabileDiAppoggio / 10).toFixed(1))
        variabileDiAppoggio = arrayToData(vars.arrayRisposteAll[1], 3 + 45, 4);// Quantità da dosare in modalità costante espressa in L/h (Gal/h), con tre cifre decimali. 
        litriOraGalloniOra = makeUnitLitriOrGallonsHora(arrayToData(vars.arrayRisposteAll[0], 3 + 22, 1), variabileDiAppoggio);
        $("#maHighDosaggio").attr("placeholder", litriOraGalloniOra)
        $("#maHighDosaggio").val((variabileDiAppoggio / 1000).toFixed(3))
        $("#maHighDosaggioUnit").text(litriOraGalloniOra)


        variabileDiAppoggio = arrayToData(vars.arrayRisposteAll[1], 3 + 43, 2);
        $("#maLowSetpoint").val((variabileDiAppoggio / 10).toFixed(1))
        variabileDiAppoggio = arrayToData(vars.arrayRisposteAll[1], 3 + 49, 4);// Quantità da dosare in modalità costante espressa in L/h (Gal/h), con tre cifre decimali. 
        litriOraGalloniOra = makeUnitLitriOrGallonsHora(arrayToData(vars.arrayRisposteAll[0], 3 + 22, 1), variabileDiAppoggio);
        $("#maLowDosaggio").attr("placeholder", litriOraGalloniOra)
        $("#maLowDosaggio").val((variabileDiAppoggio / 1000).toFixed(3))
        $("#maLowDosaggioUnit").text(litriOraGalloniOra)
        //-------------end modalità volt
        //modalità pulse
        variabileDiAppoggio = arrayToData(vars.arrayRisposteAll[1], 3 + 53, 2);
        $("#pulseHighSetpoint").val((variabileDiAppoggio).toFixed(0))
        variabileDiAppoggio = arrayToData(vars.arrayRisposteAll[1], 3 + 57, 4);// Quantità da dosare in modalità costante espressa in L/h (Gal/h), con tre cifre decimali. 
        litriOraGalloniOra = makeUnitLitriOrGallonsHora(arrayToData(vars.arrayRisposteAll[0], 3 + 22, 1), variabileDiAppoggio);
        $("#pulseHighDosaggio").attr("placeholder", litriOraGalloniOra)
        $("#pulseHighDosaggio").val((variabileDiAppoggio / 1000).toFixed(3))
        $("#pulseHighDosaggioUnit").text(litriOraGalloniOra)


        variabileDiAppoggio = arrayToData(vars.arrayRisposteAll[1], 3 + 55, 2);
        $("#pulseLowSetpoint").val((variabileDiAppoggio).toFixed(0))
        variabileDiAppoggio = arrayToData(vars.arrayRisposteAll[1], 3 + 61, 4);// Quantità da dosare in modalità costante espressa in L/h (Gal/h), con tre cifre decimali. 
        litriOraGalloniOra = makeUnitLitriOrGallonsHora(arrayToData(vars.arrayRisposteAll[0], 3 + 22, 1), variabileDiAppoggio);
        $("#pulseLowDosaggio").attr("placeholder", litriOraGalloniOra)
        $("#pulseLowDosaggio").val((variabileDiAppoggio / 1000).toFixed(3))
        $("#pulseLowDosaggioUnit").text(litriOraGalloniOra)
        //-------------end modalità pulse
        //modalità pausa Lavoro
        variabileDiAppoggio = arrayToData(vars.arrayRisposteAll[1], 3 + 65, 2);
        $("#lavoroSetpoint").val((variabileDiAppoggio).toFixed(0))
        variabileDiAppoggio = arrayToData(vars.arrayRisposteAll[1], 3 + 67, 2);
        $("#pausaSetpoint").val((variabileDiAppoggio).toFixed(0))

        variabileDiAppoggio = arrayToData(vars.arrayRisposteAll[1], 3 + 69, 4);// Quantità da dosare in modalità costante espressa in L/h (Gal/h), con tre cifre decimali. 
        litriOraGalloniOra = makeUnitLitriOrGallonsHora(arrayToData(vars.arrayRisposteAll[0], 3 + 22, 1), variabileDiAppoggio);
        $("#pausalavoroDosaggio").attr("placeholder", litriOraGalloniOra)
        $("#pausalavoroDosaggio").val((variabileDiAppoggio / 1000).toFixed(3))
        $("#pausalavoroDosaggioUnit").text(litriOraGalloniOra)

        //-------------end modalità Pausa LAvoro
        //modalità weekly
        if (arrayToData(vars.arrayRisposteAll[1], 3 + 93, 1) == 0) {//USA
                $(".timeControll").mask('00:00 ZM', {
                    translation: {
                        'Z': {
                            pattern: /[AP]/
                        }
                    },
                    placeholder: "__:__ AM"
                });
        }
        else {//america
            $(".timeControll").mask('00:00')
        }
        //--------------------------------------------------------------------------
        var j=0;
        var k = 0;
        var limitWeek = 7;

        var counterWeek = 1;
        for (j = 0; j < 4; j++) {
            if (j == 3) limitWeek = 3;
            for (k = 0; k < limitWeek; k++) {
                makeWeeklyProgram(arrayToData(vars.arrayRisposteAll[2 + j], 3 + (1 + k * 10), 1), arrayToData(vars.arrayRisposteAll[2 + j], 3 + (2 + k * 10), 1),arrayToData(vars.arrayRisposteAll[2 + j], 3 + (3 + k * 10), 1), arrayToData(vars.arrayRisposteAll[1], 3 + 93, 1),
                                   arrayToData(vars.arrayRisposteAll[2+j], 3 + (4+k*10), 1), arrayToData(vars.arrayRisposteAll[2+j], 3 + (5+k*10), 1), arrayToData(vars.arrayRisposteAll[2+j], 3 + (6+k*10), 4),
                                   arrayToData(vars.arrayRisposteAll[2 + j], 3 + (10 + k * 10), 1), "weeklyP" + (counterWeek).toString())
                counterWeek = counterWeek + 1;
            }
        }

        //--------------------------------------------------------------------------------------------------------------------------------------------------------------

        //------------end modalità weekly

        //more 
        //pump Capacity
        variabileDiAppoggio = arrayToData(vars.arrayRisposteAll[0], 3 + 31, 4);// Quantità da dosare in modalità costante espressa in L/h (Gal/h), con tre cifre decimali. 
        litriOraGalloniOra = makeUnitLitriOrGallonsHora(arrayToData(vars.arrayRisposteAll[0], 3 + 22, 1), variabileDiAppoggio);
        varsInternal.pumpCapacityGlobal = variabileDiAppoggio / 1000;
        $("#pumpCapacityFlow").attr("placeholder", litriOraGalloniOra)
        $("#pumpCapacityFlow").val((variabileDiAppoggio / 1000).toFixed(3))
        $("#pumpCapacityUnit").text(litriOraGalloniOra)

        variabileDiAppoggio = arrayToData(vars.arrayRisposteAll[0], 3 + 35, 1);
        $("#pumpCapacitySlowMode").val((variabileDiAppoggio).toFixed(0))

        //---------------end pump Capacity
        //level Alarm
        if (arrayToData(vars.arrayRisposteAll[0], 3 + 16, 1)) {//level alarm abilitato
            $("#levelAlarmEnable").prop("checked", true)
            $("#levelAlarmGroup").show();
        }
        else {
            $("#levelAlarmEnable").prop("checked", false)
            $("#levelAlarmGroup").hide();
        }
        variabileDiAppoggio = arrayToData(vars.arrayRisposteAll[0], 3 + 18, 4) / 1000;// Espresso in L (Gal), con una tre cifre decimali. Può variare da 0 (0 L) a 100000 (100,000 L). 
        litriOraGalloniOra = makeUnitLitriOrGallons(arrayToData(vars.arrayRisposteAll[0], 3 + 22, 1), variabileDiAppoggio);//arrayToData(vars.arrayRisposteAll[0], 3 + 22, 1) == 1 ? (litriOGalloni / 1000).toFixed(3) + " Gal" : ((litriOGalloni / 1000 > 0 && litriOGalloni / 1000 < 1) ? litriOGalloni.toString() + " mL" : (litriOGalloni / 1000).toFixed(3) + " L")
        $("#levelAlarmRiserva").val((variabileDiAppoggio).toFixed(3))
        $("#levelAlarmRiservaUnit").text(litriOraGalloniOra)

        $("#levelAlarmRiservaContact> [value=" + arrayToData(vars.arrayRisposteAll[0], 3 + 17, 1).toString() + "]").prop("selected", true)

        //end level Alarm
        //standby
        if (arrayToData(vars.arrayRisposteAll[0], 3 + 44, 1)) {//level alarm abilitato
            $("#standbyEnable").prop("checked", true)
            $("#standbyGroup").show();
        }
        else {
            $("#standbyEnable").prop("checked", false)
            $("#standbyGroup").hide();
        }
        $("#standbyContact> [value=" + arrayToData(vars.arrayRisposteAll[0], 3 + 45, 1).toString() + "]").prop("selected", true)
        //end standby
        //external input

        if (arrayToData(vars.arrayRisposteAll[0], 3 + 46, 1)) {
            $("#externalInputEnable").prop("checked", true)
            $("#externalInputGroup").show();
        }
        else {
            $("#externalInputEnable").prop("checked", false)
            $("#externalInputGroup").hide();
        }
        $("#externalInputContact> [value=" + arrayToData(vars.arrayRisposteAll[0], 3 + 47, 1).toString() + "]").prop("selected", true)
        variabileDiAppoggio = arrayToData(vars.arrayRisposteAll[0], 3 + 48, 4);// Quantità da dosare in modalità costante espressa in L/h (Gal/h), con tre cifre decimali. 
        litriOraGalloniOra = makeUnitLitriOrGallonsHora(arrayToData(vars.arrayRisposteAll[0], 3 + 22, 1), variabileDiAppoggio);
        $("#externalInputQuantity").attr("placeholder", litriOraGalloniOra)
        $("#externalInputQuantity").val((variabileDiAppoggio / 1000).toFixed(3))
        $("#externalInputQuantityUnit").text(litriOraGalloniOra)

        //end external input
        //water meter more menu
        setWaterMeter("waterMeterMoreSetpoint", "waterMeterKMoreSetpoint")
        //end water meter
        //timeout
        $("#timeOut").val((arrayToData(vars.arrayRisposteAll[0], 3 + 26, 2)).toFixed(0))
        //end timeout
        //overflow
        $("#overflowSetpoint> [value=" + arrayToData(vars.arrayRisposteAll[0], 3 + 28, 1).toString() + "]").prop("selected", true)
        //----end overflow
        //units
        $("#unitsSetpoint> [value=" + arrayToData(vars.arrayRisposteAll[0], 3 + 22, 1).toString() + "]").prop("selected", true)
        //----end units
        //date time
        $("#formatDate> [value=" + arrayToData(vars.arrayRisposteAll[1], 3 + 92, 1).toString() + "]").prop("selected", true)
        $("#formatTime> [value=" + arrayToData(vars.arrayRisposteAll[1], 3 + 93, 1).toString() + "]").prop("selected", true)

        $("#dateSetpoint").val(makeData(arrayToData(vars.arrayRisposteAll[0], 3 + 133, 1), arrayToData(vars.arrayRisposteAll[0], 3 + 134, 1), arrayToData(vars.arrayRisposteAll[0], 3 + 135, 1), arrayToData(vars.arrayRisposteAll[1], 3 + 92, 1)))
        alarmDateFormat(arrayToData(vars.arrayRisposteAll[1], 3 + 92, 1));
        $("#timeSetpoint").val(makeOre(arrayToData(vars.arrayRisposteAll[0], 3 + 136, 1), arrayToData(vars.arrayRisposteAll[0], 3 + 137, 1), arrayToData(vars.arrayRisposteAll[1], 3 + 93, 1))); //time
        //end date time
        //power on delay
        $("#powerOnDelay").val(arrayToData(vars.arrayRisposteAll[0], 3 + 29, 2))
        //end power on delay
        //alarm out
        if (arrayToData(vars.arrayRisposteAll[0], 3 + 36, 1)) {
            $("#alarmOutEnable").prop("checked", true)
            $("#alarmOutGroup").show();
        }
        else {
            $("#alarmOutEnable").prop("checked", false)
            $("#alarmOutGroup").hide();
        }

        $("#alarmOutContact> [value=" + arrayToData(vars.arrayRisposteAll[0], 3 + 37, 1).toString() + "]").prop("selected", true)
        if (arrayToData(vars.arrayRisposteAll[0], 3 + 38, 1)) 
            $("#alarmOutLevelEnable").prop("checked", true)
        else
            $("#alarmOutLevelEnable").prop("checked", true)
        if (arrayToData(vars.arrayRisposteAll[0], 3 + 39, 1)) 
            $("#alarmOutStandbyEnable").prop("checked", true)
        else
            $("#alarmOutStandbyEnable").prop("checked", true)
        if (arrayToData(vars.arrayRisposteAll[0], 3 + 40, 1)) 
            $("#alarmOutOverflowEnable").prop("checked", true)
        else
            $("#alarmOutOverflowEnable").prop("checked", true)
        if (arrayToData(vars.arrayRisposteAll[0], 3 + 41, 1)) 
            $("#alarmOutHighTempEnable").prop("checked", true)
        else
            $("#alarmOutHighTempEnable").prop("checked", true)
        if (arrayToData(vars.arrayRisposteAll[0], 3 + 42, 1)) 
            $("#alarmOutNoInputEnable").prop("checked", true)
        else
            $("#alarmOutNoInputEnable").prop("checked", true)
        if (arrayToData(vars.arrayRisposteAll[0], 3 + 43, 1)) 
            $("#alarmOutOverPressureEnable").prop("checked", true)
        else
            $("#alarmOutOverPressureEnable").prop("checked", true)

        //end alarm out
        //----------more 
    }
    //-------------end grafica setpoint





    //-----------------------funzioni di appoggio
    function makePortataIstantanea(unit, pulse, waterMeter) {
        var portataTemp = 0.0;
        if(unit == 0)   //pulse/litro   o pulse/gall
        {
            portataTemp = ((pulse * 600) * 1000) / waterMeter;
            console.log("portataIstantanea:" + portataTemp)
            //portataTemp = portataTemp / 1000;
            if (portataTemp > 1000){
                portataTemp = portataTemp / 1000;

                if (portataTemp > 1000) {
                    portataTemp = portataTemp / 1000;
                    return portataTemp.toFixed(3) + "mc/h";
                }
                else
                    return portataTemp.toFixed(3) + "l/h";
             }
            else
                return portataTemp.toString() + "ml/h";
        }
        else{   //litri/pulse  o galloni/pulse
            portataTemp = ((pulse * waterMeter * 60) * 1000) / 10;
            portataTemp = portataTemp / 1000;
            return portataTemp.toFixed(3) + "Gal/h";
        }
    }
    function makeMcOrGallons(unit) {
        return unit == 1 ? "Gal" : "mc"
    }
    function makeUnitLitriOrGallons(unit, inputData) {
        return unit == 1 ? "Gal" : ((inputData / 1000 > 0 && inputData / 1000 < 1) ? "ml" : "l")
    }
    function makeUnitLitriOrGallonsHora(unit, inputData) {
        return unit == 1 ? "Gal/h" : ((inputData / 1000 > 0 && inputData / 1000 < 1) ? "ml/h" : "l/h")
    }

    function makeCalcoloLitriOrGallons(unit,inputData)
    {
        return unit == 1 ? (inputData / 1000).toFixed(3) : ((inputData / 1000 > 0 && inputData / 1000 < 1) ? inputData.toString() : (inputData / 1000).toFixed(3));
    }
    function makeData(giorno,mese,anno,formato) {
        switch(formato)
        {
            case 0://:gg/mm/aa
                return (giorno < 10 ? "0" : "") + giorno.toString() + "/" + (mese < 10 ? "0" : "") + mese.toString() + "/" + anno.toString()
                break;
            case 1://mm/gg/aa
                return (mese < 10 ? "0" : "") + mese.toString() + "/" + (giorno < 10 ? "0" : "") + giorno.toString() + "/" + anno.toString()
                break;
            case 2://aa/mm/gg
                return anno.toString() + "/" + (mese < 10 ? "0" : "") + mese.toString() + "/" + (giorno < 10 ? "0" : "") + giorno.toString()
                break;
        }
    }
    function makeOre(ore, minuti, formato) {
        switch (formato) {
            case 0://USA
                var suffix = ore >= 12 ? "PM" : "AM";
                return ((ore + 11) % 12 + 1).toString() + ":" + (minuti < 10 ? "0" : "") + minuti.toString() + suffix
                break;
            case 1://EUROPA
                return (ore < 10 ? "0" : "") + ore.toString() + ":" + (minuti < 10 ? "0" : "") + minuti.toString()
                break;
        }
    }
    function checkUpKeepEnable() {
        if (arrayToData(vars.arrayRisposteAll[1], 3 + 85, 1) > 0) {//up keep enable
            return true
        }
        return false;

    }
    function checkUpKeep() {
        if (arrayToData(vars.arrayRisposteAll[1], 3 + 85, 1) > 0) {//up keep enable
            //if ((arrayToData(varsInternal.arrayReadRealTimeResult[0], 3 + 123, 1) > 0) || (arrayToData(varsInternal.arrayReadRealTimeResult[0], 3 + 124, 1) > 0))
            if (arrayToData(vars.arrayRisposteAll[0], 3 + 117, 2) == 0)//se non ci sono impulsi allora sono in upkee
                return true
        }
        return false;
    }
    function upKeepStr() {
        return varsInternal.languageJson.upKeepText + " : " + arrayToData(vars.arrayRisposteAll[0], 3 + 123, 1).toString() + "h " + arrayToData(vars.arrayRisposteAll[0], 3 + 124, 1).toString() + "m"
    }
    function setWaterMeter(selectString, kstring, OreSetpoint, MinutiSetpoint)
    {
        $("#"+selectString+"> [value=" + arrayToData(vars.arrayRisposteAll[0], 3 + 23, 1).toString() + "]").prop("selected", true)
        variabileDiAppoggio = arrayToData(vars.arrayRisposteAll[0], 3 + 24, 2); //Espresso in Impulsi/Litro (Impulsi/Gallone) o in Litri/Impulso (Gallone/Impulso) con una cifra decimale.
        if (arrayToData(vars.arrayRisposteAll[0], 3 + 22, 1) == 1) {//galloni
            $("#"+kstring).attr("max", "45420")
            $("#"+kstring).attr("labelMSG", "waterMeterKGalInfo")
            $("#" + kstring).attr("labelMSGError", "waterMeterKGalAlarm")
        }
        else {
            $("#" + kstring).attr("max", "1200.0")
            $("#"+kstring).attr("labelMSG", "waterMeterKInfo")
            $("#"+kstring).attr("labelMSGError", "waterMeterKAlarm")
        }
        $("#" + kstring).val((variabileDiAppoggio / 10).toFixed(1))
    }
    function setUpKeepSetpoit(upkeepset, UpkeepGroup, OreSetpoint, MinutiSetpoint) {
        if (checkUpKeepEnable()) {
            $("#"+upkeepset).prop("checked", true)
            $("#" + UpkeepGroup).show();
        }
        else {
            $("#" + upkeepset).prop("checked", false)
            $("#" + UpkeepGroup).hide();
        }
        $("#"+OreSetpoint+"> [value=" + arrayToData(vars.arrayRisposteAll[1], 3 + 86, 1).toString() + "]").prop("selected", true)
        $("#" + MinutiSetpoint + "> [value=" + arrayToData(vars.arrayRisposteAll[1], 3 + 87, 1).toString() + "]").prop("selected", true)
    }

    function makeWeeklyProgram(programEnableDisable, ore, minuti, formato, oreDurata,minutiDurata, weeklyDosaggio, weeklySettimana, nomeOggetto) {
        
        if (programEnableDisable == 1) { // weekly 1 abilitato
            $("#" + nomeOggetto).prop("checked", true)
            $("#" + nomeOggetto + "Group").show();
            $("#" + nomeOggetto + "Start").val(makeOre(ore, minuti, formato));
            $("#" + nomeOggetto + "OreSetpoint > [value=" + oreDurata.toString() + "]").prop("selected", true)
            $("#" + nomeOggetto + "MinutiSetpoint > [value=" + minutiDurata.toString() + "]").prop("selected", true)
            variabileDiAppoggio = weeklyDosaggio;// Quantità da dosare in modalità costante espressa in L/h (Gal/h), con tre cifre decimali. 
            litriOraGalloniOra = makeUnitLitriOrGallonsHora(arrayToData(vars.arrayRisposteAll[0], 3 + 22, 1), variabileDiAppoggio);
            $("#" + nomeOggetto + "Dosaggio").attr("placeholder", litriOraGalloniOra)
            $("#" + nomeOggetto + "Dosaggio").val((variabileDiAppoggio / 1000).toFixed(3))
            $("#" + nomeOggetto + "DosaggioUnit").text(litriOraGalloniOra)
            var shiftOperation = weeklySettimana;
            var shiftIndex = 0;
            for (shiftIndex = 0; shiftIndex < 7; shiftIndex++) {
                if (shiftOperation & 1) {
                    $("#"+nomeOggetto + shiftIndex.toString()+"D").prop("checked", true)
                }
                else {
                    $("#" + nomeOggetto + shiftIndex.toString() + "D").prop("checked", false)
                }
                shiftOperation = shiftOperation >> 1;
            }
        }
        else {
            console.log("weekly entro" + nomeOggetto)
            $("#" + nomeOggetto ).prop("checked", false)
            $("#"+nomeOggetto+"Group").hide();
            $("#"+nomeOggetto+"Start").text(0, 0, arrayToData(vars.arrayRisposteAll[1], 3 + 93, 1));
            $("#" + nomeOggetto + "OreSetpoint > [value=0]").prop("selected", true)
            $("#" + nomeOggetto + "MinutiSetpoint > [value=0]").prop("selected", true)
            $("#" + nomeOggetto + "Dosaggio").attr("placeholder", "l/h")
            $("#" + nomeOggetto + "Dosaggio").val("0,000")
            $("#" + nomeOggetto + "DosaggioUnit").text("l/h")
            var shiftOperation = 0;
            var shiftIndex = 0;
            for (shiftIndex = 0; shiftIndex < 7; shiftIndex++) {
                if (shiftOperation & 1) {
                    $("#"+nomeOggetto+ shiftIndex.toString()).prop("checked", true)
                }
                else {
                    $("#"+nomeOggetto+shiftIndex.toString()).prop("checked", false)
                }
            }

        }
    }
    //-----------------------end funzioni di appoggio

    //-----------------------funzioni di controllo javascript per le form
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

    

    $('#pumpCapacityFlow').on('keypress keydown keyup', function () {
        varsInternal.pumpCapacityGlobal = parseInt($('#pumpCapacityFlow').val());
    });
    $('#pumpCapacitySlowMode').on('keypress keydown keyup', function () {
        var slowPercTemp = parseInt($(this).val());
        var pumpCapacityTemp = varsInternal.pumpCapacityGlobal;
        pumpCapacityTemp = (pumpCapacityTemp * slowPercTemp) / 100;
        $("#pumpCapacityFlow").val(pumpCapacityTemp.toFixed(3));
    });
    //controllo formato data cambiato
    $('#formatDate').change(function () {
        $("#dateSetpoint").val(makeData(arrayToData(vars.arrayRisposteAll[0], 3 + 133, 1), arrayToData(vars.arrayRisposteAll[0], 3 + 134, 1), arrayToData(vars.arrayRisposteAll[0], 3 + 135, 1), parseInt($(this).val())))
        alarmDateFormat(parseInt($(this).val()));
    });
    $('#dateSetpoint').on('keypress keydown keyup', function () {
        var validateDate = false;
        switch (parseInt($('#formatDate').val())) {
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
    function alarmDateFormat(input)
    {
        
        switch(input)
        {
            case 0://gg/mm/aa
                $("#dateSetpoint").attr("labelMSG", "dateggmmaaInfo")
                $("#dateSetpoint").attr("labelMSGError", "dateggmmaaAlarm")
                break;
            case 1://mm/gg/aa
                $("#dateSetpoint").attr("labelMSG", "datemmggaaInfo")
                $("#dateSetpoint").attr("labelMSGError", "datemmggaaAlarm")
                break;
            case 2://aa/mm/gg
                $("#dateSetpoint").attr("labelMSG", "dateaammggInfo")
                $("#dateSetpoint").attr("labelMSGError", "dateaammggAlarm")
                break;
        }
    }
    function alarmTimeFormat(input) {
        if (input == 0) {//USA
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
    //controllo formato ora cambiato
    $('#formatTime').change(function () {
        alarmTimeFormat(parseInt($(this).val()));
        $("#timeSetpoint").val(makeOre(arrayToData(vars.arrayRisposteAll[0], 3 + 136, 1), arrayToData(vars.arrayRisposteAll[0], 3 + 137, 1), parseInt($(this).val()))); //time

    });
    $('#timeSetpoint').on('keypress keydown keyup', function () {
        var validateTime = false;
        switch (parseInt($('#formatTime').val())) {
            case 0://formato 12
                validateTime = validateTime12($(this).val());
                break;
            case 1://formato 24
                validateTime = validateTime24($(this).val());
                break;
        }
        $(this).next("div").remove();
        if (validateTime)
            $(this).after("<div class=\"text-danger small mt-1\">" + varsInternal.languageJsonSettingsMessage[$(this).attr("labelMSGError")] + "</div>");
        else
            $(this).after("<div class=\"text-success small mt-1\">" + varsInternal.languageJsonSettingsMessage[$(this).attr("labelMSG")] + "</div>");
    });
    //controllo daata e ora di partenza è falido
    $('.timeControll').on('keypress keydown keyup', function () {
        $(this).next("div").remove();
        if (arrayToData(vars.arrayRisposteAll[1], 3 + 93, 1) == 0) {//usa
            if (validateTime12(this.value)){
                if (!checkOverflowTime(this.id))
                    $(this).after("<div class=\"text-success small mt-1\">" + varsInternal.languageJsonSettingsMessage[$(this).attr("labelMSG") + "12"] + "</div>");
            }
            else
                $(this).after("<div class=\"text-danger small mt-1\">" + varsInternal.languageJsonSettingsMessage[$(this).attr("labelMSGError")+ "12"] + "</div>");    
        }
        else {
            if (!validateTime24(this.value)){
                if (!checkOverflowTime(this.id))
                    $(this).after("<div class=\"text-success small mt-1\">" + varsInternal.languageJsonSettingsMessage[$(this).attr("labelMSG")] + "</div>");
            }
            else
                $(this).after("<div class=\"text-danger small mt-1\">" + varsInternal.languageJsonSettingsMessage[$(this).attr("labelMSGError")] + "</div>");    
        }
       // console.log("testData:" + )

    });
    //devo verificare che la programmazione di un timer non salti il giorno successivo
    $('.timeControllSelect').change(function () {
        
        checkOverflowTime(this.id)
        //weeklyP2MinutiSetpoint
        //weeklyP2OreSetpoint
        //weeklyP2Start
    });
    $('.weeklyP').change(function () {
        var idTemp = parseInt($(this).attr("indice"))
        console.log("000000000000000000000000000" + idTemp)
        varsInternal.arrayIndiciProgrammazioniSettimanali[idTemp] = 1;
    });
    $('.weeklyP').on('keypress keydown keyup', function () {
        var idTemp = parseInt($(this).attr("indice"))
        varsInternal.arrayIndiciProgrammazioniSettimanali[idTemp] = 1;
        
    });
    function checkOverflowTime(idWeekly) {
        var indiceWeekly = idWeekly;
        indiceWeekly = indiceWeekly.replace("weeklyP", "")
        indiceWeekly = indiceWeekly.replace("MinutiSetpoint", "")
        indiceWeekly = indiceWeekly.replace("OreSetpoint", "")
        indiceWeekly = indiceWeekly.replace("Start", "")
        var timeSecond = timeToSeconds($("#weeklyP" + indiceWeekly + "Start").val());

        timeSecond = timeSecond + parseInt($("#weeklyP" + indiceWeekly + "OreSetpoint").val()) * 60 + parseInt($("#weeklyP" + indiceWeekly + "MinutiSetpoint").val())
        $("#weeklyP" + indiceWeekly + "Start").next("div").remove();
        if (timeSecond > 1440) {//controllo i minuti 1 giorno sono 1440, quindi se la data partenza trasformata in minuti e sommando le ore e i minuti di partenza non devono superare il giorno
            $("#weeklyP" + indiceWeekly + "Start").after("<div class=\"text-danger small mt-1\">" + varsInternal.languageJsonSettingsMessage["weekOverDay"] + "</div>");
            return true;
        }
        return false;
    }
    function timeToSeconds(time) {
        if ((time.indexOf("m") > 0) || (time.indexOf("M") > 0)) {
            convertTo24Hour(time)
        }

        time = time.split(/:/);

        return parseInt(time[0]) * 60 + parseInt(time[1]);
    }

    function convertTo24Hour(time) {
        var hours = parseInt(time.substr(0, 2));
        if(time.indexOf('am') != -1 && hours == 12) {
            time = time.replace('12', '0');
        }
        if(time.indexOf('pm')  != -1 && hours < 12) {
            time = time.replace(hours, (hours + 12));
        }
        return time.replace(/(am|pm)/, '');
    }
    function validateDateggmmaa(value)
    {
        var pattern = /^([0-2][0-9]|(3)[0-1])(\/)(((0)[0-9])|((1)[0-2]))(\/)\d{2}$/;
        //var validDate = $.value.match(pattern);
        var validDate = pattern.test(value);
        if (!validDate) {
            return true;
        } else {
            return false;
        }

    }
    function validateDatemmggaa(value) {
        var pattern = /^(((0)[0-9])|((1)[0-2]))(\/)([0-2][0-9]|(3)[0-1])(\/)\d{2}$/;
        var validDate = value.match(pattern);
        if (!validDate) {
            return true;
        } else {
            return false;
        }

    }
    function validateDateaammgg(value) {
        var pattern = /^\d{2}(\/)(((0)[0-9])|((1)[0-2]))(\/)([0-2][0-9]|(3)[0-1])$/;

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
    function countDecimalAfterPoint(value) {
        if (value.includes('.')) {
            return value.split('.')[1].length;
        };
        if (value.includes(',')) {
            return value.split(',')[1].length;
        };
        return 0;
    }
    //-----------------------endfunzioni di controllo javascript per le form


    /*-------------------------invio dati*/

    $("#constantModeSend").click(function () {
        var arrayData = [];
        var valoreInviare = Math.floor(parseFloat($("#constantDosaggio").val()) * 1000);
        varsInternal.arraySendData = [];

        arrayData = [];
        varsInternal.arraySendData.push(makeArraySend(0x0C,addDataToArray(arrayData, 0, 1))); //modalità costante 
        arrayData = [];
        arrayData = addDataToArray(arrayData, parseInt(valoreInviare), 4);//quantità da dosare
        varsInternal.arraySendData.push(makeArraySend(0x0D, arrayData))
        arrayData = [];
        varsInternal.arraySendData.push(makeArraySend(0xF0, arrayData));//comando fine scrittura
        sendDataAnimation("constant");
    });
    $("#ccpulseModeSend").click(function () {
        var arrayData = [];
        var valoreInviare = Math.floor(parseFloat($("#ccPulseSetpoint").val()) * 10000);
        varsInternal.arraySendData = [];

        arrayData = [];
        varsInternal.arraySendData.push(makeArraySend(0x0C, addDataToArray(arrayData, 1, 1))); //cc per pulse 

        arrayData = [];
        arrayData = addDataToArray(arrayData, parseInt(valoreInviare), 4);//quantità da dosare
        if ($("#diluizioneSet").is(':checked'))
            arrayData = addDataToArray(arrayData, 1, 1);//diluizione
        else
            arrayData = addDataToArray(arrayData, 0, 1);//diluizione
        varsInternal.arraySendData.push(makeArraySend(0x0E, arrayData));

        //ci metto anche il water meter
        varsInternal.arraySendData.push(makeArraySend(0x03, makeWaterMeterSend("waterMeterCCPulseSetpoint", "waterMeterKCCPulseSetpoint")));

        //comando fine scrittura
        arrayData = [];
        varsInternal.arraySendData.push(makeArraySend(0xF0, arrayData));//comando fine scrittura
        
        
        sendDataAnimation("ccpulse");
    });
    $("#ppmModeSend").click(function () {
        varsInternal.arraySendData = [];

        arrayData = [];
        varsInternal.arraySendData.push(makeArraySend(0x0C, addDataToArray(arrayData, 2, 1))); //ppm

        var valoreInviare = Math.floor(parseFloat($("#ppmSetpoint").val()) * 100);
        arrayData = [];
        arrayData = addDataToArray(arrayData, parseInt(valoreInviare), 4);//quantità da dosare
        valoreInviare = Math.floor(parseFloat($("#concentrazioneSetpoint").val()) * 10);
        arrayData = addDataToArray(arrayData, parseInt(valoreInviare), 2);//quantità da dosare
        varsInternal.arraySendData.push(makeArraySend(0x0F, arrayData));

        //ci metto anche il water meter
        varsInternal.arraySendData.push(makeArraySend(0x03, makeWaterMeterSend("waterMeterPPMSetpoint", "waterMeterKPPMSetpoint")));

        //ci metto upkeep
        varsInternal.arraySendData.push(makeArraySend(0x2F, makeUpKeepSend("upkeepPPMSet", "timeoutUpkeepPPMOreSetpoint", "timeoutUpkeepPPMMinutiSetpoint", "upkeepDosaggioPPM")));

        //comando fine scrittura
        arrayData = [];
        varsInternal.arraySendData.push(makeArraySend(0xF0, arrayData));//comando fine scrittura

        sendDataAnimation("ppm");
    });
    $("#percModeSend").click(function () {
        varsInternal.arraySendData = [];

        arrayData = [];
        varsInternal.arraySendData.push(makeArraySend(0x0C, addDataToArray(arrayData, 3, 1))); //perc

        var valoreInviare = Math.floor(parseFloat($("#percSetpoint").val()) * 100);
        arrayData = [];
        arrayData = addDataToArray(arrayData, parseInt(valoreInviare), 4);//quantità da dosare
        valoreInviare = Math.floor(parseFloat($("#concentrazionePercSetpoint").val()) * 10);
        arrayData = addDataToArray(arrayData, parseInt(valoreInviare), 2);//quantità da dosare
        varsInternal.arraySendData.push(makeArraySend(0x10, arrayData));

        //ci metto anche il water meter
        varsInternal.arraySendData.push(makeArraySend(0x03, makeWaterMeterSend("waterMeterPercSetpoint", "waterMeterKPercSetpoint")));

        //ci metto upkeep
        varsInternal.arraySendData.push(makeArraySend(0x2F, makeUpKeepSend("upkeepPercSet", "timeoutUpkeepOrePercSetpoint", "timeoutUpkeepMinutiPercSetpoint", "upkeepDosaggioPerc")));

        //comando fine scrittura
        arrayData = [];
        varsInternal.arraySendData.push(makeArraySend(0xF0, arrayData));//comando fine scrittura

        sendDataAnimation("perc");
    });
    $("#mlqModeSend").click(function () {
        varsInternal.arraySendData = [];

        arrayData = [];
        varsInternal.arraySendData.push(makeArraySend(0x0C, addDataToArray(arrayData, 4, 1))); //mlq

        var valoreInviare = Math.floor(parseFloat($("#mlqSetpoint").val()) * 100);
        arrayData = [];
        arrayData = addDataToArray(arrayData, parseInt(valoreInviare), 4);//quantità da dosare
        valoreInviare = Math.floor(parseFloat($("#concentrazionemlqSetpoint").val()) * 10);
        arrayData = addDataToArray(arrayData, parseInt(valoreInviare), 2);//quantità da dosare
        varsInternal.arraySendData.push(makeArraySend(0x11, arrayData));

        //ci metto anche il water meter
        varsInternal.arraySendData.push(makeArraySend(0x03, makeWaterMeterSend("waterMetermlqSetpoint", "waterMeterKmlqSetpoint")));

        //ci metto upkeep
        varsInternal.arraySendData.push(makeArraySend(0x2F, makeUpKeepSend("upkeepmlqSet", "timeoutUpkeepOremlqSetpoint", "timeoutUpkeepMinutimlqSetpoint", "upkeepDosaggiomlq")));

        //comando fine scrittura
        arrayData = [];
        varsInternal.arraySendData.push(makeArraySend(0xF0, arrayData));//comando fine scrittura

        sendDataAnimation("mlq");
    });
    $("#batchModeSend").click(function () {
        varsInternal.arraySendData = [];

        arrayData = [];
        varsInternal.arraySendData.push(makeArraySend(0x0C, addDataToArray(arrayData, 5, 1))); //batch

        arrayData = [];
        var valoreInviare = Math.floor(parseFloat($("#batchSetpoint").val()) * 1000);
        arrayData = addDataToArray(arrayData, parseInt(valoreInviare), 4);//quantità da dosare
        arrayData = addDataToArray(arrayData, parseInt($("#contactSetpoint").val()), 1);//quantità da dosare
        varsInternal.arraySendData.push(makeArraySend(0x16, arrayData));

        //comando fine scrittura
        arrayData = [];
        varsInternal.arraySendData.push(makeArraySend(0xF0, arrayData));//comando fine scrittura

        sendDataAnimation("batch");
    });
    $("#voltModeSend").click(function () {
        varsInternal.arraySendData = [];

        arrayData = [];
        varsInternal.arraySendData.push(makeArraySend(0x0C, addDataToArray(arrayData, 6, 1))); //volt

        arrayData = [];
        var valoreInviare = Math.floor(parseFloat($("#voltHighSetpoint").val()) * 10);
        arrayData = addDataToArray(arrayData, parseInt(valoreInviare), 2);
        valoreInviare = Math.floor(parseFloat($("#voltLowSetpoint").val()) * 10);
        arrayData = addDataToArray(arrayData, parseInt(valoreInviare), 2);
        valoreInviare = Math.floor(parseFloat($("#voltHighDosaggio").val()) * 1000);
        arrayData = addDataToArray(arrayData, parseInt(valoreInviare), 4);
        valoreInviare = Math.floor(parseFloat($("#voltLowDosaggio").val()) * 1000);
        arrayData = addDataToArray(arrayData, parseInt(valoreInviare), 4);
        varsInternal.arraySendData.push(makeArraySend(0x12, arrayData));

        //comando fine scrittura
        arrayData = [];
        varsInternal.arraySendData.push(makeArraySend(0xF0, arrayData));//comando fine scrittura

        sendDataAnimation("volt");

    });
    $("#maModeSend").click(function () {
        varsInternal.arraySendData = [];

        arrayData = [];
        varsInternal.arraySendData.push(makeArraySend(0x0C, addDataToArray(arrayData, 7, 1))); //ma

        arrayData = [];
        var valoreInviare = Math.floor(parseFloat($("#maHighSetpoint").val()) * 10);
        arrayData = addDataToArray(arrayData, parseInt(valoreInviare), 2);
        valoreInviare = Math.floor(parseFloat($("#maLowSetpoint").val()) * 10);
        arrayData = addDataToArray(arrayData, parseInt(valoreInviare), 2);
        valoreInviare = Math.floor(parseFloat($("#maHighDosaggio").val()) * 1000);
        arrayData = addDataToArray(arrayData, parseInt(valoreInviare), 4);
        valoreInviare = Math.floor(parseFloat($("#maLowDosaggio").val()) * 1000);
        arrayData = addDataToArray(arrayData, parseInt(valoreInviare), 4);
        varsInternal.arraySendData.push(makeArraySend(0x13, arrayData));

        //comando fine scrittura
        arrayData = [];
        varsInternal.arraySendData.push(makeArraySend(0xF0, arrayData));//comando fine scrittura

        sendDataAnimation("ma");

    });
    $("#pulseModeSend").click(function () {
        varsInternal.arraySendData = [];

        arrayData = [];
        varsInternal.arraySendData.push(makeArraySend(0x0C, addDataToArray(arrayData, 8, 1))); //pulse

        arrayData = [];
        var valoreInviare = Math.floor(parseFloat($("#pulseHighSetpoint").val()) * 1);
        arrayData = addDataToArray(arrayData, parseInt(valoreInviare), 2);
        valoreInviare = Math.floor(parseFloat($("#pulseLowSetpoint").val()) * 1);
        arrayData = addDataToArray(arrayData, parseInt(valoreInviare), 2);
        valoreInviare = Math.floor(parseFloat($("#pulseHighDosaggio").val()) * 1000);
        arrayData = addDataToArray(arrayData, parseInt(valoreInviare), 4);
        valoreInviare = Math.floor(parseFloat($("#pulseLowDosaggio").val()) * 1000);
        arrayData = addDataToArray(arrayData, parseInt(valoreInviare), 4);
        varsInternal.arraySendData.push(makeArraySend(0x14, arrayData));

        //comando fine scrittura
        arrayData = [];
        varsInternal.arraySendData.push(makeArraySend(0xF0, arrayData));//comando fine scrittura

        sendDataAnimation("pulse");

    });
    $("#pauseworkModeSend").click(function () {
        varsInternal.arraySendData = [];

        arrayData = [];
        varsInternal.arraySendData.push(makeArraySend(0x0C, addDataToArray(arrayData, 9, 1))); //pause work

        arrayData = [];
        var valoreInviare = Math.floor(parseFloat($("#lavoroSetpoint").val()) * 1);
        arrayData = addDataToArray(arrayData, parseInt(valoreInviare), 2);
        valoreInviare = Math.floor(parseFloat($("#pausaSetpoint").val()) * 1);
        arrayData = addDataToArray(arrayData, parseInt(valoreInviare), 2);
        valoreInviare = Math.floor(parseFloat($("#pausalavoroDosaggio").val()) * 1000);
        arrayData = addDataToArray(arrayData, parseInt(valoreInviare), 4);
        varsInternal.arraySendData.push(makeArraySend(0x15, arrayData));

        //comando fine scrittura
        arrayData = [];
        varsInternal.arraySendData.push(makeArraySend(0xF0, arrayData));//comando fine scrittura

        sendDataAnimation("pausework");

    });
    $("#weeklyModeSend").click(function () {

        varsInternal.arraySendData = [];

        arrayData = [];
        varsInternal.arraySendData.push(makeArraySend(0x0C, addDataToArray(arrayData, 10, 1))); //weekly

        var i = 0;
        var K = 0;
        for (i = 1; i < 25; i++) {
            arrayData = [];
            if (varsInternal.arrayIndiciProgrammazioniSettimanali[i]) {
                if ($("#weeklyP" + i.toString()).is(':checked'))
                    arrayData = addDataToArray(arrayData, 1, 1);//enable
                else
                    arrayData = addDataToArray(arrayData, 0, 1);//disabled

                var dataTemp = convertTo24Hour($("#weeklyP" + i.toString() + "Start").val()).split(":")
                arrayData = addDataToArray(arrayData, parseInt(dataTemp[0]), 1); //data partenza Ore
                arrayData = addDataToArray(arrayData, parseInt(dataTemp[1]), 1);//data partenza Minuti


                arrayData = addDataToArray(arrayData, parseInt($("#weeklyP" + i.toString() + "OreSetpoint").val()), 1); //durata Ore
                arrayData = addDataToArray(arrayData, parseInt($("#weeklyP" + i.toString() + "MinutiSetpoint").val()), 1); //durata Minuti

                var valoreInviare = Math.floor(parseFloat($("#weeklyP" + i.toString() + "Dosaggio").val()) * 1000);
                arrayData = addDataToArray(arrayData, parseInt(valoreInviare), 4); //quantità da dosare

                valoreInviare = 0;
                for (k = 6; k >= 0; k--) {
                    if ($("#weeklyP" + i.toString() + k.toString() + "D").is(':checked'))
                        valoreInviare = valoreInviare | 0x01;//enable
                    if ( k > 0 )
                        valoreInviare = valoreInviare << 1;
                }
                arrayData = addDataToArray(arrayData, valoreInviare, 1); //giorni settimana

                varsInternal.arraySendData.push(makeArraySend(0x16 + i, arrayData));

            }
        }
        //comando fine scrittura
        arrayData = [];
        varsInternal.arraySendData.push(makeArraySend(0xF0, arrayData));//comando fine scrittura


        sendDataAnimation("weekly");



    });
    $("#pumpCapacityModeSend").click(function () {
        varsInternal.arraySendData = [];
        arrayData = [];

        var valoreInviare = Math.floor(parseFloat($("#pumpCapacityFlow").val()) * 1000);
        arrayData = addDataToArray(arrayData, parseInt(valoreInviare), 4);

        var valoreInviare = Math.floor(parseFloat($("#pumpCapacitySlowMode").val()) * 1);
        arrayData = addDataToArray(arrayData, parseInt(valoreInviare), 1);
        varsInternal.arraySendData.push(makeArraySend(0x07, arrayData));

        //comando fine scrittura
        arrayData = [];
        varsInternal.arraySendData.push(makeArraySend(0xF0, arrayData));//comando fine scrittura

        sendDataAnimation("pumpCapacity");

    });
    $("#levelAlamrModeSend").click(function () {
        varsInternal.arraySendData = [];
        arrayData = [];

        
        if ($("#levelAlarmEnable").is(':checked'))
            arrayData = addDataToArray(arrayData, 1, 1);
        else
            arrayData = addDataToArray(arrayData, 0, 1);
        arrayData = addDataToArray(arrayData, parseInt($("#levelAlarmRiservaContact").val()), 1);
        var valoreInviare = Math.floor(parseFloat($("#levelAlarmRiserva").val()) * 1000);
        arrayData = addDataToArray(arrayData, parseInt(valoreInviare), 4);
        varsInternal.arraySendData.push(makeArraySend(0x01, arrayData));

        //comando fine scrittura
        arrayData = [];
        varsInternal.arraySendData.push(makeArraySend(0xF0, arrayData));//comando fine scrittura

        sendDataAnimation("levelAlamr");

    });
    $("#standbyModeSend").click(function () {
        varsInternal.arraySendData = [];
        arrayData = [];

        if ($("#standbyEnable").is(':checked'))
            arrayData = addDataToArray(arrayData, 1, 1);
        else
            arrayData = addDataToArray(arrayData, 0, 1);
        arrayData = addDataToArray(arrayData, parseInt($("#standbyContact").val()), 1);
        varsInternal.arraySendData.push(makeArraySend(0x09, arrayData));
        
        //comando fine scrittura
        arrayData = [];
        varsInternal.arraySendData.push(makeArraySend(0xF0, arrayData));//comando fine scrittura

        sendDataAnimation("standby");

    });
    $("#externalInputModeSend").click(function () {
        varsInternal.arraySendData = [];
        arrayData = [];

        if ($("#externalInputEnable").is(':checked'))
            arrayData = addDataToArray(arrayData, 1, 1);
        else
            arrayData = addDataToArray(arrayData, 0, 1);

        arrayData = addDataToArray(arrayData, parseInt($("#externalInputContact").val()), 1);
        var valoreInviare = Math.floor(parseFloat($("#externalInputQuantity").val()) * 1000);
        arrayData = addDataToArray(arrayData, parseInt(valoreInviare), 4);
        varsInternal.arraySendData.push(makeArraySend(0x0A, arrayData));

        //comando fine scrittura
        arrayData = [];
        varsInternal.arraySendData.push(makeArraySend(0xF0, arrayData));//comando fine scrittura

        sendDataAnimation("externalInput");

    });
    $("#waterMeterModeSend").click(function () {
        varsInternal.arraySendData = [];
        arrayData = [];

        arrayData = addDataToArray(arrayData, parseInt($("#waterMeterMoreSetpoint").val()), 1);
        var valoreInviare = Math.floor(parseFloat($("#waterMeterKMoreSetpoint").val()) * 10);
        arrayData = addDataToArray(arrayData, parseInt(valoreInviare), 2);
        varsInternal.arraySendData.push(makeArraySend(0x03, arrayData));

        //comando fine scrittura
        arrayData = [];
        varsInternal.arraySendData.push(makeArraySend(0xF0, arrayData));//comando fine scrittura

        sendDataAnimation("waterMeter");
    });
    $("#timeOutModeSend").click(function () {
        varsInternal.arraySendData = [];
        arrayData = [];

        arrayData = addDataToArray(arrayData, parseInt($("#timeOut").val()), 2);
        varsInternal.arraySendData.push(makeArraySend(0x04, arrayData));

        //comando fine scrittura
        arrayData = [];
        varsInternal.arraySendData.push(makeArraySend(0xF0, arrayData));//comando fine scrittura

        sendDataAnimation("timeOut");

    });
    $("#overflowModeSend").click(function () {
        varsInternal.arraySendData = [];
        arrayData = [];

        arrayData = addDataToArray(arrayData, parseInt($("#overflowSetpoint").val()), 1);
        varsInternal.arraySendData.push(makeArraySend(0x04, arrayData));

        //comando fine scrittura
        arrayData = [];
        varsInternal.arraySendData.push(makeArraySend(0xF0, arrayData));//comando fine scrittura

        sendDataAnimation("overflow");

    });
    $("#unitsModeSend").click(function () {
        varsInternal.arraySendData = [];
        arrayData = [];

        arrayData = addDataToArray(arrayData, parseInt($("#unitsSetpoint").val()), 1);
        varsInternal.arraySendData.push(makeArraySend(0x02, arrayData));

        //comando fine scrittura
        arrayData = [];
        varsInternal.arraySendData.push(makeArraySend(0xF0, arrayData));//comando fine scrittura

        sendDataAnimation("units");

    });
    $("#powerOnDelayModeSend").click(function () {
        varsInternal.arraySendData = [];
        arrayData = [];

        arrayData = addDataToArray(arrayData, parseInt($("#powerOnDelay").val()), 2);
        varsInternal.arraySendData.push(makeArraySend(0x06, arrayData));

        //comando fine scrittura
        arrayData = [];
        varsInternal.arraySendData.push(makeArraySend(0xF0, arrayData));//comando fine scrittura

        sendDataAnimation("powerOnDelay");

    });
    $("#alarmOutModeSend").click(function () {
        varsInternal.arraySendData = [];
        arrayData = [];

        if ($("#alarmOutEnable").is(':checked'))
            arrayData = addDataToArray(arrayData, 1, 1);
        else
            arrayData = addDataToArray(arrayData, 0, 1);
        arrayData = addDataToArray(arrayData, parseInt($("#alarmOutContact").val()), 1);
        if ($("#alarmOutLevelEnable").is(':checked'))
            arrayData = addDataToArray(arrayData, 1, 1);
        else
            arrayData = addDataToArray(arrayData, 0, 1);
        if ($("#alarmOutStandbyEnable").is(':checked'))
            arrayData = addDataToArray(arrayData, 1, 1);
        else
            arrayData = addDataToArray(arrayData, 0, 1);
        if ($("#alarmOutOverflowEnable").is(':checked'))
            arrayData = addDataToArray(arrayData, 1, 1);
        else
            arrayData = addDataToArray(arrayData, 0, 1);
        if ($("#alarmOutHighTempEnable").is(':checked'))
            arrayData = addDataToArray(arrayData, 1, 1);
        else
            arrayData = addDataToArray(arrayData, 0, 1);
        if ($("#alarmOutNoInputEnable").is(':checked'))
            arrayData = addDataToArray(arrayData, 1, 1);
        else
            arrayData = addDataToArray(arrayData, 0, 1);
        if ($("#alarmOutOverPressureEnable").is(':checked'))
            arrayData = addDataToArray(arrayData, 1, 1);
        else
            arrayData = addDataToArray(arrayData, 0, 1);

        varsInternal.arraySendData.push(makeArraySend(0x08, arrayData));

        //comando fine scrittura
        arrayData = [];
        varsInternal.arraySendData.push(makeArraySend(0xF0, arrayData));//comando fine scrittura

        sendDataAnimation("powerOnDelay");

    });
    $("#dateTimeModeSend").click(function () {
        varsInternal.arraySendData = [];
        arrayData = [];

        arrayData = addDataToArray(arrayData, parseInt($("#formatDate").val()), 1);
        arrayData = addDataToArray(arrayData, parseInt($("#formatTime").val()), 1);

        arrayData = addDateToArray($("#dateSetpoint").val(), arrayData, parseInt($("#formatDate").val()))
        arrayData = addTimeToArray($("#timeSetpoint").val(), arrayData);

        varsInternal.arraySendData.push(makeArraySend(0x50, arrayData));

        //comando fine scrittura
        arrayData = [];
        varsInternal.arraySendData.push(makeArraySend(0xF0, arrayData));//comando fine scrittura

        sendDataAnimation("dateTime");

    });
    
    
    function makeUpKeepSend(valore1, valore2, valore3, valore4) {
        arrayData = [];
        if ($("#" + valore1).is(':checked'))
            arrayData = addDataToArray(arrayData, 1, 2);//upkeep enable
        else
            arrayData = addDataToArray(arrayData, 0, 2);//upkeep disable

        arrayData = addDataToArray(arrayData, parseInt($("#" + valore2).val()), 2);//ore
        arrayData = addDataToArray(arrayData, parseInt($("#" + valore3).val()), 2);//minuti
        var valoreInviare = Math.floor(parseFloat($("#" + valore4).val()) * 1000);
        arrayData = addDataToArray(arrayData, valoreInviare, 4);//minuti
        return arrayData;
    }
    function makeWaterMeterSend(valore1,valore2) {
        arrayData = [];
        arrayData = addDataToArray(arrayData, parseInt($("#" + valore1).val()), 1); //water meter
        valoreInviare = Math.floor(parseFloat($("#" + valore2).val()) * 10);
        arrayData = addDataToArray(arrayData, parseInt(valoreInviare), 2);//watermeter
        return arrayData;
    }
    function sendDataAnimation(idLogic) {
        var errore = false;
        $("#" + idLogic + "ModeSend").next("div").remove();
        $("#nav-tabs-" + idLogic).find(".text-danger").each(function (index) {
            $("#" + idLogic + "ModeSend").after("<div class=\"text-danger small mt-1\">" + varsInternal.languageJsonSettingsMessage["sendError"] + "</div>");
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
    }
    function addDataToArray(arrayData,intero,lunghezza){
        var i = 0;
        var lunghezzaArrayTemp = arrayData.length;
        for (i = 0; i < lunghezza; i++) {
            arrayData[lunghezzaArrayTemp + i] = intero & 0xFF;
            intero = intero >> 8;
        }
        return arrayData;
    }
    function addDateToArray(dateTimeTemp,arrayData, formato) {
        var dateTimeSplit = dateTimeTemp.split("/")
        var lunghezzaArrayTemp = arrayData.length;
        switch (formato) {
            case 0://:gg/mm/aa
                if (dateTimeSplit.length >= 3)
                {
                    arrayData[lunghezzaArrayTemp + 0] = parseInt(dateTimeSplit[0]);
                    arrayData[lunghezzaArrayTemp + 1] = parseInt(dateTimeSplit[1]);
                    arrayData[lunghezzaArrayTemp + 2] = parseInt(dateTimeSplit[2]);
                }
                break;
            case 1://mm/gg/aa
                if (dateTimeSplit.length >= 3) {
                    arrayData[lunghezzaArrayTemp + 0] = parseInt(dateTimeSplit[1]);
                    arrayData[lunghezzaArrayTemp + 1] = parseInt(dateTimeSplit[0]);
                    arrayData[lunghezzaArrayTemp + 2] = parseInt(dateTimeSplit[2]);
                }
                break;
            case 2://aa/mm/gg
                if (dateTimeSplit.length >= 3) {
                    arrayData[lunghezzaArrayTemp + 0] = parseInt(dateTimeSplit[2]);
                    arrayData[lunghezzaArrayTemp + 1] = parseInt(dateTimeSplit[1]);
                    arrayData[lunghezzaArrayTemp + 2] = parseInt(dateTimeSplit[0]);
                }
                break;
        }
        return arrayData;
    }
    function addTimeToArray(dateTimeTemp, arrayData) {
        dateTimeTemp = convertTo24Hour(dateTimeTemp);
        var dateTimeSplit = dateTimeTemp.split(":")
        var lunghezzaArrayTemp = arrayData.length;
        if (dateTimeSplit.length >= 2) {
            arrayData[lunghezzaArrayTemp + 0] = parseInt(dateTimeSplit[0]);
            arrayData[lunghezzaArrayTemp + 1] = parseInt(dateTimeSplit[1]);
        }
        return arrayData;
    }
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

    /*-------------------------*/
}
//------------------------------------------------------------------

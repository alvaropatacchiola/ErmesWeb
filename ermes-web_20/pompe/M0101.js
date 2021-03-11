var state = { "publish": 0, "loadAllData": 1, "notConnected": 2, "readData": 3, "readSetpoint": 4 };
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
        arrayRisposteAll: []
    };
    var varsInternal = {
        socket: null,
        stateConnection: 1,
        indexGlobalProtocollo: 0,
        waitPompaVar: null,
        waitConnectionPompa: null,
        numeroTentativiRichieste: 0,
        reader: null,
        PompaSub: null

    };

    this.construct = function (options) {
        $.extend(vars, options);
        varsInternal.stateConnection = state.publish;
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
                        if ((uint8arrayToStringMethod(array).indexOf("PUBLISHOK")) >= 0) {
                            varsInternal.numeroTentativiRichieste = 0;
                            varsInternal.stateConnection = state.loadAllData;
                            clearTimeout(varsInternal.waitPompaVar); // blocco timeout
                            varsInternal.socket.send(createArraytoSend(vars.arrayReadAll));
                        }
                        else {//problema di pubblicazione

                        }
                        break;
                    case state.loadAllData:
                        //piazzo i risultati di risposta negli array
                        if ((uint8arrayToStringMethod(array).indexOf("bsyR")) >= 0) {//se bsyR0 vuol dire che connesso e non occupato
                        }
                        else{
                                if (varsInternal.indexGlobalProtocollo > (vars.arrayRisposteAll).length)
                                    vars.arrayRisposteAll.push(array);//lo aggiungo se non presente
                                else
                                    vars.arrayRisposteAll[varsInternal.indexGlobalProtocollo] = array;//lo aggiorno se già presente


                                if (varsInternal.indexGlobalProtocollo >= (vars.arrayReadAll).length) {
                                    varsInternal.indexGlobalProtocollo = 0;
                                    varsInternal.stateConnection = state.readData;
                                }

                                clearTimeout(varsInternal.waitPompaVar); // blocco timeout
                                varsInternal.socket.send(createArraytoSend(vars.arrayReadAll))
                                varsInternal.indexGlobalProtocollo++;
                        }
                        break;

                    case state.readData:
                        if ((uint8arrayToStringMethod(array).indexOf("bsyR")) >= 0) {//se bsyR0 vuol dire che connesso e non occupato
                        }
                        else {
                            //--------------------------------------------------
                            $("#messages").text((arrayToData(vars.arrayRisposteAll[0], 11, 4) / 1000) + " l/h")
                            $("#messages1").text((arrayToData(vars.arrayRisposteAll[0], 15, 4) / 1000) + " %")
                            //aggiornamento dati
                            vars.arrayRisposteAll[varsInternal.indexGlobalProtocollo] = array;//lo aggiorno se già presente
                            if (varsInternal.indexGlobalProtocollo >= (vars.arrayReadRealTime).length) {
                                varsInternal.indexGlobalProtocollo = 0;
                            }

                            clearTimeout(varsInternal.waitPompaVar); // blocco timeout
                            varsInternal.socket.send(createArraytoSend(vars.arrayReadAll))
                            varsInternal.indexGlobalProtocollo++;
                        }
                        break;
                }
                //var $el = document.createElement('p');
                //$el.innerHTML = array;
                //$messages.appendChild($el);
                console.log("Result: " + array + "," + varsInternal.stateConnection + "," + uint8arrayToStringMethod(array) + "," + vars.serialNumber);
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
        console.log("array Inviato:" + arrayDef + ":" + varsInternal.indexGlobalProtocollo + ":" + (arrayToSendMQTT).length)
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
}
//------------------------------------------------------------------
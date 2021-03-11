var state = { "connection": 1, "checkBusy": 2, "readData": 3, "readSetpoint": 4 };
var milliseconds = 5000; //ms di timeout nella attesa di risposta
var millisecondsRetry = 10000; //ms di timeout nel riprovare se è connsesa
/*$(document).ready(function () {
    console.log("ready!");
});
*/
//function OggettoPompa(serialNumberTemp, arrayReadRealTimeTemp, arrayReadSetpointTemp)
var OggettoPompa = function (options)
{

    var vars = {
        serialNumber: '',
        arrayReadRealTime:[],
        arrayReadSetpoint: []
    };
    var varsInternal = {
        socket:null,
        stateConnection: 1,
        indexGlobalProtocollo: 0,
        waitPompaVar: null,
        waitConnectionPompa: null,
        numeroTentativiRichieste: 0,
        reader: null,
        PompaSub:null

    };
    //var socket;
    //this.stateConnection = state.connection;
    //var stateConnection = 1;
    
    //var indexGlobalProtocollo = 0;
    //var waitPompaVar;
    //var waitConnectionPompa;
    //var numeroTentativiRichieste = 0;
    //var serialNumber = serialNumberTemp;
    //var arrayReadRealTime = arrayReadRealTimeTemp;
    //var arrayReadSetpoint = arrayReadSetpointTemp;
    /*
  * Constructor
  */
    this.construct = function (options) {
        $.extend(vars, options);
        varsInternal.stateConnection = 1;
    };

    this.construct(options);

    this.createConnection = function ()
    {
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
            
            varsInternal.socket.send("PUBLISH" + vars.serialNumber);
        }
        varsInternal.socket.onmessage = function (msg) {
            varsInternal.reader = new FileReader();

            varsInternal.reader.onloadend = () => {
                var data = varsInternal.reader.result;
                var array = new Uint8Array(data);
                if (varsInternal.indexGlobalProtocollo >= (vars.arrayReadRealTime).length) {
                    varsInternal.indexGlobalProtocollo = 0;
                }
                switch (varsInternal.stateConnection) {
                    case state.connection:
                        if ((uint8arrayToStringMethod(array).indexOf("PUBLISHOK")) >= 0) {
                            console.log("pubblicazione OK:" + vars.serialNumber)
                            varsInternal.stateConnection = state.checkBusy;
                            varsInternal.waitConnectionPompa = setTimeout(timeoutConnessione, millisecondsRetry);
                            //stateConnection = state.readData;
                            //numeroTentativiRichieste = 0;

                            //socket.send(createArraytoSend());
                        }
                        else {// problema autenticazione client assente

                        }
                        break;
                    case state.checkBusy:
                        clearTimeout(varsInternal.waitConnectionPompa); // blocco timeout
                        var arrayToStringValue = uint8arrayToStringMethod(array);
                        if ((arrayToStringValue.indexOf("bsyR0")) >= 0) {//se bsyR0 vuol dire che connesso e non occupato
                            //messaggioTesto("Connected.");
                            console.log(arrayToStringValue)
                            if (arrayToStringValue.indexOf("|") > 0) {// carattere che mi indica la configurazione codice del software per caricare il tipo di sw
                                var arrayToStringValueSplit = arrayToStringValue.split("|");
                                console.log(vars.serialNumber)
                                $("#" + vars.serialNumber + "_pump").load("pompe/P" + arrayToStringValueSplit[1] + ".aspx", function (response, status, xhr) {
                                    if (varsInternal.PompaSub == null){
                                        varsInternal.PompaSub = new OggettoPompaSub({ serialNumber: vars.serialNumber, arrayReadRealTime: vars.arrayReadRealTime, arrayReadSetpoint: vars.arrayReadSetpoint });
                                    }
                                    varsInternal.PompaSub.startDocument();
                                    varsInternal.PompaSub.waitConnection();
                                    if (status == "error") {
                                        var msg = "Sorry but there was an error: ";
                                        console.log(msg + xhr.status + " " + xhr.statusText)
                                    }
                                });
                            }
                            //waitConnection();
                            varsInternal.stateConnection = state.readData;
                            varsInternal.numeroTentativiRichieste = 0;
                            varsInternal.socket.send(createArraytoSend());
                        }
                        if ((arrayToStringValue.indexOf("bsyR1")) >= 0) {//se bsyR1 vuol dire che connesso e occupato
                            //pompa occupata in altra connessione
                            //messaggioTesto("Connection Busy.");
                        }
                        break;
                    case state.readData:
                        if ((uint8arrayToStringMethod(array).indexOf("bsyR")) >= 0) {//se bsyR0 vuol dire che connesso e non occupato
                            //blocco legatyo alla gestione del busy e altro
                        }
                        else{
                            varsInternal.numeroTentativiRichieste = 0;
                           // $("#messages").text((arrayToData(array, 11, 4) / 1000) + " l/h")
                            // $("#messages1").text((arrayToData(array, 15, 4) / 1000) + " %")

                            varsInternal.PompaSub.updateValoriRuntime(array);

                            clearTimeout(varsInternal.waitPompaVar); // blocco timeout
                            varsInternal.socket.send(createArraytoSend())
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
            varsInternal.stateConnection = state.checkBusy;
            console.log("tentativi CFompletati")
            messaggioTesto("Error Protocol.");
        }
        else { //n riprovo con il protocollo
            console.log("tentativi" + varsInternal.numeroTentativiRichieste)
            varsInternal.socket.send(createArraytoSend())
        }

        //setTimeout(retryPompa, millisecondsRetry);
    }
    function timeoutConnessione(){
        console.log("pompa non connessa");
        messaggioTesto("Not Connected.");
    }
    function retryPompa() {
        varsInternal.indexGlobalProtocollo = 0;
        varsInternal.stateConnection = state.readData;
        varsInternal.send(createArraytoSend())
        console.log("delay pompa suprato")
    }
    //----------------------------------------BLOCCO CALCOLI VARI
    function uint8arrayToStringMethod(myUint8Arr) {
        return String.fromCharCode.apply(null, myUint8Arr);
    }
    function createArraytoSend() {
        var arrayDef = new Uint8Array(6);
        arrayDef[0] = 0xFF;
        arrayDef[1] = vars.arrayReadRealTime[varsInternal.indexGlobalProtocollo];
        arrayDef[2] = 0x00;
        arrayDef[3] = 0xFE;
        arrayDef[4] = 0xFF;
        arrayDef[5] = calcolaChecksum(arrayDef);
        varsInternal.waitPompaVar = setTimeout(waitPompa, milliseconds);
        console.log("array Inviato:" + arrayDef + ":" + varsInternal.indexGlobalProtocollo + ":" + (vars.arrayReadRealTime).length)
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

    function messaggioTesto(stringaTesto) {
        $("#messageStart" + vars.serialNumber).text(stringaTesto);
    }
}
//------------------------------------------------------------------
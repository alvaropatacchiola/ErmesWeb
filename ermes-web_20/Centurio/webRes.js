
var new_num = 40; // global variable
var codice = "";
var username = "alvaro";
var password = "alvaro";
var type = "real";
var id485 = "01";
var nomeImpianto = ""
var cittaImpianto = ""

var countStrumenti = 0;
var counterProgressivo = 0;
var counterProgressivoGrafica = 0;
var jsonResponse = new Array(5);
var primaVolta = false;
var refreshData = 10000; //gestione dei valori degli strumenti da acquisire dal server
//var refreshData = 300000;// timer a 5 muinuti
var refreshGrafica = 20000; // timer 20 secondi per cambio schermata
var refreshDataMeteo = 20000;
// datetime
function display_c() {
    var refresh = 1000; // Refresh rate in milli seconds
    mytime = setTimeout('display_ct()', refresh)
}

function display_ct() {
    var x = new Date()
    //document.getElementById('ct').innerHTML = x;
    $("#datetime").text(x.toLocaleDateString() + " " + x.toLocaleTimeString());
    display_c();
}
//gestione dei valori degli strumenti da acquisire dal server
function download_data() {
    //var refresh = 300000; // timer a 5 muinuti
    //var refresh = 10000; // timer a 5 muinuti
    mytime = setTimeout('download_data_ct()', refreshData)
}
function download_data_ct() {
    if (countStrumenti > 0) {
        counterProgressivo = 1;
    }
    else {
        counterProgressivo++;
        if (counterProgressivo > countStrumenti)
            counterProgressivo = 1;
    }

    getDataStrumenti("0" + counterProgressivo.toString());
    download_data();
}
function getNumeroStrumentiConnessi() {
    $.ajax({
        type: "POST",
        url: "Centurio/JwebService.aspx/listConnected",
        //data: "{'serialNumber':'" + JSON.stringify(codice) + "','type':'real','user':'alvaro','pwd':'alvaro','id_485_impianto':''}",
        data: "{'serialNumber':'" + JSON.stringify(codice) + "'}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        //timeout: 6000, //3 second timeout
        success: function (response) {
            var jsonResponse;
            jsonResponse = JSON.parse(response.d);
            countStrumenti = parseInt(jsonResponse.count);
            console.log(countStrumenti);
        },
        failure: function (response) {
            //alert(response.d);

        }

    });
}
function getInfoImpianto()
{
    $.ajax({
        type: "POST",
        url: "Centurio/JwebService.aspx/jsonInfoCodice",
        //data: "{'serialNumber':'" + JSON.stringify(codice) + "','type':'real','user':'alvaro','pwd':'alvaro','id_485_impianto':''}",
        data: "{'serialNumber':'" + JSON.stringify(codice) + "'}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        //timeout: 6000, //3 second timeout
        success: function (response) {
            var jsonResponse;
            var indirizzoSplit;
            console.log(response)
            jsonResponse = JSON.parse(response.d);
            nomeImpianto = jsonResponse.impianto
            nomeImpianto = nomeImpianto.replace(">", ":")
            indirizzoSplit = jsonResponse.indirizzo.split("-")
            if (indirizzoSplit.length > 3){
                cittaImpianto = indirizzoSplit[2]
            }
            else
                cittaImpianto = ""
            $("#impianto").text(nomeImpianto)
            $("#localita").text(cittaImpianto)
            //console.log("info Impianto:" + nomeImpianto + " " + cittaImpianto )
        },
        failure: function (response) {
            //alert(response.d);

        }

    });
    //previsioni meteo
    $.getJSON('http://ip-api.com/json', getWeather);

}
function getDataStrumenti(id485Value) {
    
    $.ajax({
        type: "POST",
        url: "Centurio/JwebService.aspx/getRealTime",
        //data: "{'serialNumber':'" + JSON.stringify(codice) + "','type':'real','user':'alvaro','pwd':'alvaro','id_485_impianto':''}",
        data: "{'serialNumber':'" + JSON.stringify(codice) + "','type':'" + JSON.stringify(type) + "','user':'" + JSON.stringify(username) + "','password':'" + JSON.stringify(password) + "','id485':'" + JSON.stringify(id485Value) + "'}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        //timeout: 6000, //3 second timeout
        success: function (response) {
            console.log("id485:" + response)
            jsonResponse[parseInt(id485Value)] = JSON.parse(response.d);
            if (!primaVolta) {
                updateGrafica(1);
                primaVolta = true;
            }
            //console.log("leggo" + jsonResponse[parseInt(id485Value)])
        },
        failure: function (response) {
            //alert(response.d);

        }

    });
}
//end gestione dei valori degli strumenti da acquisire dal server
//scrittura grafica con passaggio di stato
function scriviGrafica() {
    //var refresh = 20000; // timer 20 secondi per cambio schermata
    mytime = setTimeout('scriviGrafica_ct()', refreshGrafica)

}
function scriviGrafica_ct() {
    if (countStrumenti > 0) {
        counterProgressivoGrafica = 1;
    }
    else {
        counterProgressivoGrafica++;
        if (counterProgressivoGrafica > countStrumenti)
            counterProgressivoGrafica = 1;
    }

    //getDataStrumenti(counterProgressivo.toString());
    updateGrafica(counterProgressivo)
    scriviGrafica();
}
function updateGrafica(counterProgressivoValue) {
    //console.log("labelAlarm:" + jsonResponse[counterProgressivoValue].labelAlarm)
    var LabelAlarmList = jsonResponse[counterProgressivoValue].labelAlarm.split(",");
    var statoAllarmeGenerale = false;
    for (k = 0; k < LabelAlarmList.length; k++) {
        
        statoAllarmeGenerale = statoAllarmeGenerale || getBooleanValue(decodeJsonString(jsonResponse[counterProgressivoValue], LabelAlarmList[k]))
    }
    console.log("allarme Global:" + statoAllarmeGenerale)
}
function getBooleanValue(labelDecode)
{
    if (labelDecode == "ON")
        return true;
    return false;

}
//end scrittura grafica con passaggio di stato
//leggere i parametri della url
$.urlParam = function (name) {
    var results = new RegExp('[\?&]' + name + '=([^&#]*)').exec(window.location.href);
    return results[1] || 0;
}
function getWeather_ct() {

    $.getJSON('http://ip-api.com/json', getWeather);
}
var getWeather = function (data) {
    
    if (cittaImpianto != "") {
        console.log("entro qui")
        $.getJSON('http://api.openweathermap.org/data/2.5/weather', {
            q: cittaImpianto,
            units: "metric",
            appid: "57d5b21566d36d6d57fd5892ef35cc37"
        }, showWeather, 'jsonp');
    }
    else{
        $.getJSON('http://api.openweathermap.org/data/2.5/weather', {
            lat: data.lat,
            lon: data.lon,
            units: "metric",
            appid: "57d5b21566d36d6d57fd5892ef35cc37"
        }, showWeather, 'jsonp');
    }
    mytime = setTimeout('getWeather_ct()', refreshDataMeteo)
};
function convertUTCDateToLocalDate(convertdLocalTime) {


    var hourOffset = convertdLocalTime.getTimezoneOffset() / 60;

    convertdLocalTime.setHours(convertdLocalTime.getHours() + hourOffset);

    return convertdLocalTime;
}

var showWeather = function (data) {

    /*var dataCurrent = parseInt(data.dt) *1000;
	var dataAlba = parseInt(data.sys.sunrise);
	var dataTramonto = parseInt(data.sys.sunset);
	var date = new Date(dataCurrent)*/
    var date = new Date();
    //date = convertUTCDateToLocalDate(date);
    $("#temp").text(data.main.temp)
    $("#tempMin").text(data.main.temp_min)
    $("#tempMax").text(data.main.temp_max)
    $("#description").text(data.weather[0].description)
    $("#place").text(data.name)
    $("#icon").text(data.weather[0].icon)
    //$("#datetime").text(date.getFullYear().toString() + "-" + (date.getMonth() + 1).toString() + "-" + date.getDate().toString() + " " + date.getHours().toString() + ":" + date.getMinutes().toString())
    /*if ((dataCurrent > dataAlba)&&(dataCurrent <= dataTramonto))
		$("#giornoNotte").text("giorno")
	else
		$("#giornoNotte").text("notte")*/
};
//test
function getDataErmes(data, status, xhr) {
    console.log("entro:" + data)
    $("#ermes").text(data.lastUpdateMin)
};

jQuery(document).ready(function () {

    console.log($.urlParam('code'));
    codice = $.urlParam('code');

    //visualizza date time
    display_ct();
    //get del numero strumenti connessi
    getNumeroStrumentiConnessi();
    //get info impianto
    getInfoImpianto();

    //get dati dello strumento
    getDataStrumenti("01");
    download_data();// avvuio la sequenza del timer per effettuare il download 

    //scrivo i dati in grafica
    scriviGrafica();
    
    //?serial='+ codice +'&type=real&user=vivo&pwd=%5e%7d8MG87@7pM6F32B;cp4JYeWkqCadqpo

    //test
    //http://localhost:10154/Centurio/webService.aspx?serial=223012&type=real&user=alvaro&pwd=alvaro
    /*
    $.getJSON('http://www.ermes-server.com/Centurio/webService.aspx', {
            serial: codice,
            type: "real",
            user:"vivo",
            pwd: "%5e%7d8MG87@7pM6F32B;cp4JYeWkqCadqpo"
        } , getDataErmes, 'jsonp');
    
    });
    */


    /*
$.getJSON('/Centurio/webService.aspx', {
        serial: codice,
        type: "real",
		user:"alvaro",
        pwd: "alvaro"
    } , getDataErmes);
*/
});
function decodeJsonString(jsonParseVal, label) {
    var k = 0;
    for (k = 0; k < jsonParseVal.variable.length; k++) {
        if (jsonParseVal.variable[k]["key"] == label)
            return jsonParseVal.variable[k]["value"];
    }
    return "";
}

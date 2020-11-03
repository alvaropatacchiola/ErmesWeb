
var new_num = 40; // global variable
var codice = "";
var appStatus = "";
var smartStatus = "";
var username = "alvaro";
var password = "alvaro";
var type = "real";
var id485 = "01";
var nomeImpianto = ""
var cittaImpianto = ""
var appExitListPlant = 0;

var countStrumenti = 0;
var counterProgressivo = 0;
var counterProgressivoGrafica = 0;
var maxStrumenti=5;
var jsonResponse = new Array(5);
var statusAlarmPrecedent = new Array(false,false,false,false,false);
var statusAlarmcount = new Array(0,0,0,0,0);
var primaVolta = false;
var refreshData = 60000; //gestione dei valori degli strumenti da acquisire dal server
//var refreshData = 300000;// timer a 5 muinuti
var refreshGrafica = 20000; // timer 20 secondi per cambio schermata
var refreshDataMeteo = 1800000;//refresh meteo ogni 30 minuti
var timeoutAlarm = 150;
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
    if (countStrumenti <= 0) {
        counterProgressivo = 1;
    }
    else {
        counterProgressivo++;
        if (counterProgressivo > countStrumenti)
            counterProgressivo = 1;
    }
    console.log("countProgressivo:" + counterProgressivo + "," + countStrumenti)
    getDataStrumenti("0" + counterProgressivo.toString(),true);
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
        async:false,
        //timeout: 6000, //3 second timeout
        success: function (response) {
            var jsonResponse;
            var i=1;
            jsonResponse = JSON.parse(response.d);
            countStrumenti = parseInt(jsonResponse.count);
            visualizzaStrumentiImpianto();
            for (i = 1; i <= countStrumenti;i++)
                getDataStrumenti("0" + i.toString(),false);
            
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
        async:false,
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
            //previsioni meteo
            
            //console.log("info Impianto:" + nomeImpianto + " " + cittaImpianto )
        },
        failure: function (response) {
            //alert(response.d);

        }

    });
    if (cittaImpianto != "") 
        getWeather();
    else
        getWeather_ct();
    

}
function getDataStrumenti(id485Value,asyncT) {
    
    $.ajax({
        type: "POST",
        url: "Centurio/JwebService.aspx/getRealTime",
        //data: "{'serialNumber':'" + JSON.stringify(codice) + "','type':'real','user':'alvaro','pwd':'alvaro','id_485_impianto':''}",
        data: "{'serialNumber':'" + JSON.stringify(codice) + "','type':'" + JSON.stringify(type) + "','user':'" + JSON.stringify(username) + "','password':'" + JSON.stringify(password) + "','id485':'" + JSON.stringify(id485Value) + "'}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: asyncT, //blocks window close
        //timeout: 6000, //3 second timeout
        success: function (response) {
            console.log("id485:" + response.d)
            jsonResponse[parseInt(id485Value)] = JSON.parse(response.d);
            aggiornaListaStrumenti(parseInt(id485Value));//lista degli strumenti presenti in impianto
            aggiornaListaStrumentiStatus();//aggiorno lo stato del pallino della lista
            if (!primaVolta) {//la prima volta aggiorno i valori della prima pagina
                updateStatusGeneral(1);
                aggiornaGraficaVal(1);
                activateAll();//attivo la parte grafica
				//auto swipe per smart tv
				if ((smartStatus == "1")&&(countStrumenti  > 1)){
					//swipeHandlerLeft();
					console.log("start Loop")
					setInterval(autoSwipe, 15000);
				}
				
                primaVolta = true;
            }
            if (asyncT) {// sto lavorando ina sincrona quindi dopo aver caricato la pagina
                console.log("inidiceSwipe:" + swpLindex)
                aggiornaGraficaVal(swpLindex);
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
    if (countStrumenti <= 0) {
        counterProgressivoGrafica = 1;
    }
    else {
        counterProgressivoGrafica++;
        if (counterProgressivoGrafica > countStrumenti)
            counterProgressivoGrafica = 1;
    }

    //getDataStrumenti(counterProgressivo.toString());
    updateStatusGeneral(counterProgressivoGrafica)
    scriviGrafica();
}
function updateStatusGeneral(counterProgressivoValue) {
    
    var LabelAlarmList = jsonResponse[counterProgressivoValue].labelAlarm.split(",");
    var statoAllarmeGenerale = false;
    for (k = 0; k < LabelAlarmList.length; k++) {
        
        statoAllarmeGenerale = statoAllarmeGenerale || getBooleanValue(decodeJsonString(jsonResponse[counterProgressivoValue], LabelAlarmList[k]))
    }
    console.log("labelAlarm:" + counterProgressivoValue + "," + statoAllarmeGenerale)
    if ((!statusAlarmPrecedent[counterProgressivoValue]) && (statoAllarmeGenerale)) {// se prima non era in allarme e adesso sta in allarme faccio partire un delay
        statusAlarmcount[counterProgressivoValue]++; //incremento un contatore, di solito questo contatore si incrementa ogni 5 minuti
        console.log("timer allarme count")
        if (statusAlarmcount[counterProgressivoValue] > timeoutAlarm)// è in allarme da più di 50 minuti
        {
            console.log("alalrme partito")
            statusAlarmPrecedent[counterProgressivoValue] = statoAllarmeGenerale;// posso modificare il colore della schermata
        }
    }
    else {
        statusAlarmcount[counterProgressivoValue] = 0;
        statusAlarmPrecedent[counterProgressivoValue] = statoAllarmeGenerale;
    }

   /* $("#nomeStrumento").text(decodeJsonString(jsonResponse[counterProgressivoValue], "labelValue"))
    $("#statoAllarme").text(statusAlarmPrecedent[counterProgressivoValue].toString())*/

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

    //$.getJSON('http://ip-api.com/json', getWeather);
	//if (appStatus == "1")
	//	getWeather();
    //else{
		/*$.ajax({
			dataType: "jsonp",
			url: "https://api.ip2loc.com/jtNZrAX52QtjennyQWIkB3oOeK4Zuzvi/detect",
			success: getWeather,
			 async:false,
			error:function (response) {
				getWeather(false);
				console.log("error")
			},	
			fail: function (response) {
				getWeather(false);
				console.log("fail")
			}
		});*/
    $.getJSON("https://api.ip2loc.com/jtNZrAX52QtjennyQWIkB3oOeK4Zuzvi/detect", getWeather/*function (result) {
        if (result.location.country.eu_member) {
            console.log(result.location.latitude);
        }
    }*/);
	//}
	
}
var getWeather = function (data) {
    console.log(data)
    if (cittaImpianto != "") {
        console.log("entro qui")
        // $.getJSON('http://api.openweathermap.org/data/2.5/weather', {
       /* $.getJSON('http://api.openweathermap.org/data/2.5/weather', {
            q: cittaImpianto,
            units: "metric",
            appid: "57d5b21566d36d6d57fd5892ef35cc37"
        }, showWeather, 'jsonp');*/
        $.ajax({
            dataType: "jsonp",
            url: 'https://api.openweathermap.org/data/2.5/weather',
            data:  {
                q: cittaImpianto,
                units: "metric",
                appid: "57d5b21566d36d6d57fd5892ef35cc37"
            }
        ,
            success: showWeather,
            error: function (jqXHR, textStatus, errorThrown) {
                nullMeteo();
                console.log("fail")
            }
        });

    }
    else{
        /*$.getJSON('http://api.openweathermap.org/data/2.5/weather', {
            lat: data.lat,
            lon: data.lon,
            units: "metric",
            appid: "57d5b21566d36d6d57fd5892ef35cc37"
        }, showWeather, 'jsonp');*/
        $.ajax({
            dataType: "jsonp",
            url: 'https://api.openweathermap.org/data/2.5/weather',
            data: {
                lat: data.location.latitude,
                lon: data.location.longitude,
                units: "metric",
                appid: "57d5b21566d36d6d57fd5892ef35cc37"
            }
             ,
            success: showWeather,
            error: function (jqXHR, textStatus, errorThrown) {
                console.log("fail")
                nullMeteo();
            }
        });
    }
    mytime = setTimeout('getWeather_ct()', refreshDataMeteo)
};
function convertUTCDateToLocalDate(convertdLocalTime) {


    var hourOffset = convertdLocalTime.getTimezoneOffset() / 60;

    convertdLocalTime.setHours(convertdLocalTime.getHours() + hourOffset);

    return convertdLocalTime;
}


//test
function getDataErmes(data, status, xhr) {
    console.log("entro:" + data)
    $("#ermes").text(data.lastUpdateMin)
};

jQuery(document).ready(function () {

    //console.log($.urlParam('code'));
    codice = $.urlParam('code');
	
    try {
        smartStatus = $.urlParam('smart')
        $("#more_1_nav").hide();
		$("#close_1_nav").hide();

        console.log("SMART SI")
    }

    catch (err) {
        console.log("SMART NO")
        smartStatus = "";
		$(".progressbar").hide();
    }
	
    try {
        appStatus = $.urlParam('app')
        $("#more_1_nav").hide();
        $("#close_1_nav").hide();
        timeoutAlarm = 0;
        console.log("APP SI")
    }

    catch (err) {
        console.log("APP NO")

        appStatus = "";
        timeoutAlarm = 0;//se NON si tratta di una app il timeout lo devo impostare a 20 cicli
    }
	
	if ((appStatus == "") && (smartStatus == "")){
		 $("#more_1_nav").show();
        $("#close_1_nav").show();
	}

    //visualizza date time
    display_ct();
    //get del numero strumenti connessi
    //get info impianto
    getInfoImpianto();
    
    getNumeroStrumentiConnessi();

    //get dati dello strumento
    
    download_data();// avvuio la sequenza del timer per effettuare il download 

    //scrivo i dati in grafica
    scriviGrafica();
    
	
	removeLoader();
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


//procedure js di modifica grafica
function aggiornaListaStrumenti(indexSwipeValue)
{
    console.log("listaValori:" + indexSwipeValue)
    var textTemp = decodeJsonString(jsonResponse[indexSwipeValue], "labelValue");
    if (textTemp == "")
		textTemp = "Controller " + indexSwipeValue.toString();
    $("#pN_" + indexSwipeValue.toString()).text(textTemp)
}
function aggiornaListaStrumentiStatus()
{
    var checkAlarm = false;
    $('div[id*="pS_"]').each(function () {
        var indiceTemp = parseInt($(this).attr("id").replace("pS_", ""));
        //console.log("statusColor:" + graficaStatusColor(indiceTemp))
        if (checkAlarm == false)
            checkAlarm = statusAlarmPrecedent[indiceTemp]
        $(this).css("background-color", graficaStatusColor(indiceTemp))
    });
    if (checkAlarm) {
        $(".color_path1").css("fill", "rgba(255,119,0,1.00)");
    }
    else {
        $(".color_path1").css("fill", "rgba(39,172,58,1.00)");
    }
}
function aggiornaGraficaVal(indexSwipeValue)
{
    var textTemp = decodeJsonString(jsonResponse[indexSwipeValue], "labelValue");
    if (textTemp == "")
		textTemp = "Controller " + indexSwipeValue.toString();
    //$("#pN_" + indexSwipeValue.toString()).text(textTemp)
    $("#poolname").text(textTemp);
    $("#poolname_copy").text(textTemp);
    graficaStatus(statusAlarmPrecedent[indexSwipeValue]);

    /*
    valori di lettura
    */
    //temperature: label :temperature
    var temperatureStr = decodeJsonString(jsonResponse[indexSwipeValue], "temperature");
    var temperatureStrTemp = temperatureStr.indexOf("F") > 0 ? parseInt(temperatureStr.replace("°F", "")) : parseInt(temperatureStr.replace("°C", ""))
    if (temperatureStrTemp > 0) {
        $("#pIW_3").show();
        $("#temp_title").text(temperatureStr);
    }
    else
        $("#pIW_3").hide();
    //valori di lettura
    $('div[id*="pIW_"]').each(function () {
        var indiceTemp = parseInt($(this).attr("id").replace("pIW_", ""));
        if (indiceTemp > 3) {
            var labelTempStr = decodeJsonString(jsonResponse[indexSwipeValue], "probeLabel" + (indiceTemp - 3).toString());
            if (labelTempStr != "") {
                $(this).show();
                $("#ch" + (indiceTemp - 3) + "_title").text(labelTempStr + " " + decodeJsonString(jsonResponse[indexSwipeValue], "probeValuel" + (indiceTemp - 3).toString()))
            }
            else
                $(this).hide();
        }
    });

    //$("#statoAllarme").text(statusAlarmPrecedent[indexSwipeValue].toString())

}
function graficaStatus(statoAllarme)
{
    //sfondo_all_good
    //sfondo_not_good
    //sfondo_bad
    if (statoAllarme) {
        $("#BG").removeClass().addClass("sfondo_not_good");
        $("svg#smile_good").css("display", "none");
        $("svg#smile_notGood").css("display", "block");
        $("svg#smile_bad").css("display", "none");
        

    }
    else {
        $("#BG").removeClass().addClass("sfondo_all_good");
        $("svg#smile_good").css("display", "block");
        $("svg#smile_notGood").css("display", "none");
        $("svg#smile_bad").css("display", "none");
        //$(".color_path1").css("fill", "rgba(255,119,0,1.00)");
    }
    
    
}
function graficaStatusSecond(indiceLista)
{
    var i = 1;
    $('div[id="dot"]').each(function () {

        if (i == indiceLista) 
                    $(this).attr('class', 'on');
                else
                    $(this).attr('class', 'off');
        i++;
        console.log("conto divi ultimi")
    });

    graficaStatus(statusAlarmPrecedent[indiceLista]);
}
function graficaText(indiceLista)
{
    console.log("testoGrafica:" + indiceLista)
    if (indiceLista <= countStrumenti) 
    {
        return decodeJsonString(jsonResponse[indiceLista], "labelValue") == "" ? "Controller " + indiceLista.toString(): decodeJsonString(jsonResponse[indiceLista], "labelValue");
    }
    return "";
}
function graficaStatusColor(indiceLista)
{

    if (indiceLista <= countStrumenti) {
        if (statusAlarmPrecedent[indiceLista])
            return "rgba(255,119,0,1.00)"
            //return "rgba(39,172,58,1.00)"
        else
            return "rgba(39,172,58,1.00)"
            //return "rgba(255,119,0,1.00)"
    }
    return "rgba(39,172,58,1.00)";
        
}
function visualizzaStrumentiImpianto()
{
    var i = 1;
    for (i = 1; i <= maxStrumenti; i++)
    {
        
        if (i <= countStrumenti) {

            //$("#pS_" + i.toString()).show();
            //$("#pN_" + i.toString()).show();
        }
        else{
            //$("#pS_" + i.toString()).hide();
            $("#pS_" + i.toString()).remove();
            //$("#pN_" + i.toString()).hide();
            $("#pN_" + i.toString()).remove();
            //$("#dot_" + i.toString()).remove();
        }
    }
    i = 1;
    $('div[id="dot"]').each(function () {
        if (countStrumenti == 1)
        {
            $(this).remove();
        }
        else {
            if (i <= countStrumenti) {
                if (i == 1)
                    $(this).attr('class', 'on');
                else
                    $(this).attr('class', 'off');
            }
            else {
                $(this).remove();
            }
        }
        i++;
        console.log("conto divi ultimi")
    });
    swpIndMax = countStrumenti;
    console.log("inizializzao2:" + swpIndMax)
}
function nullMeteo() {
    
    $("#temp").text(" No Data ")
    $("#tempMin").text(" No Data ")
    $("#tempMax").text(" No Data ")
    //$("#description").text(data.weather[0].description)
    $("#place").text(" No Data ")
    $("#meteo_tilte").text(" No Data ")
    $("#meteo_desc").text("  " + "°C (min " + "  " + "°C / max " + "  " + "°C )");//format 31° C (min 31° / max 38°)

    var image = document.createElement("IMG");
    image.alt = "";
    image.setAttribute('class', 'meteoImg_pos');
    //image.src = "http://openweathermap.org/img/wn/" + data.weather[0].icon + "@2x.png";
    $("#meteoIcon").html(image);

    pIcPaddTop(false);
    pIcPaddBott(false);
}
var showWeather = function (data) {

    /*var dataCurrent = parseInt(data.dt) *1000;
	var dataAlba = parseInt(data.sys.sunrise);
	var dataTramonto = parseInt(data.sys.sunset);
	var date = new Date(dataCurrent)*/
    console.log("AGGIORNO METEO")
    var date = new Date();
    //date = convertUTCDateToLocalDate(date);
    $("#temp").text(data.main.temp)
    $("#tempMin").text(data.main.temp_min)
    $("#tempMax").text(data.main.temp_max)
    //$("#description").text(data.weather[0].description)
    $("#place").text(data.name)
    $("#meteo_tilte").text(data.weather[0].description)
	var tempFloat = parseFloat(data.main.temp).toFixed(1);
	var tempMinFloat = parseFloat(data.main.temp_min).toFixed(1);
	var tempMaxFloat = parseFloat(data.main.temp_max).toFixed(1);
    $("#meteo_desc").text(tempFloat.toString() + "°C (min " + tempMinFloat.toString() + "°C / max " + tempMaxFloat.toString() + "°C )");//format 31° C (min 31° / max 38°)

    var image = document.createElement("IMG");
    image.alt = "";
    image.setAttribute('class', 'meteoImg_pos');
    image.src="http://openweathermap.org/img/wn/"+data.weather[0].icon+"@2x.png";
    $("#meteoIcon").html(image);

    pIcPaddTop(false);
    pIcPaddBott(false);

    //$("#icon").text(data.weather[0].icon)
    //$("#datetime").text(date.getFullYear().toString() + "-" + (date.getMonth() + 1).toString() + "-" + date.getDate().toString() + " " + date.getHours().toString() + ":" + date.getMinutes().toString())
    /*if ((dataCurrent > dataAlba)&&(dataCurrent <= dataTramonto))
		$("#giornoNotte").text("giorno")
	else
		$("#giornoNotte").text("notte")*/
};
//autorefresh page

function autoRefreshPage() {
    window.location = window.location.href;
}
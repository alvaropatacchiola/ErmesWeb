


var OggettoPompaSub = function (options) {
    var vars = {
        serialNumber: '',
        arrayReadRealTime: [],
        arrayReadSetpoint: [],
        plantName: '',
        languageSet: '',
        pumpCode: ''
    };
    var varsInternal = {
        arrayReadRealTimeResult: [],
        arrayReadSetpointResult: [],
        languageJson: null,
        languageJsonWarningAlarm: null
    };
    this.construct = function (options) {
        $.extend(vars, options);
        //console.log("lingua:" + t0101[vars.languageSet]);
        varsInternal.languageJson = jQuery.parseJSON(t0201[vars.languageSet]);
        varsInternal.languageJsonWarningAlarm = jQuery.parseJSON(t0201AlarmWarning[vars.languageSet]);


    };

    this.construct(options);

    this.updateValoriSetpoint = function (arrayReadSetpointTemp, indexGlobalProtocolloTemp) {
        varsInternal.arrayReadSetpointResult[indexGlobalProtocolloTemp] = arrayReadSetpointTemp;
        //-----------------download dei setting della pompa o sync
        $("#modalitaLavoro" + vars.serialNumber).text(varsInternal.languageJson.settingDownload);
        //-----------------download dei setting della pompa o sync
    }
    this.checkReSyncSetpoint = function () {
        return (arrayToData(varsInternal.arrayReadRealTimeResult[0], 3 + 81, 1))
    }


    this.updateValoriRuntime = function (arrayReadRealTimeTemp, indexGlobalProtocolloTemp) {
        varsInternal.arrayReadRealTimeResult[indexGlobalProtocolloTemp] = arrayReadRealTimeTemp;

        $("#statusConnection" + vars.serialNumber).hide();//rimozione blocco strumento disconnesso
        updateGrafica();
    }
    this.startDocument = function () {

        $("[id*='_SN']").each(function () {
            //$("#" + $(this).attr("id")).removeClass("active");
            var selectionId = $(this).attr("id");
            if (selectionId != undefined) {
                $(this).attr("id", selectionId.replace("_SN", vars.serialNumber));
            }
        });

        //-----------------parametri impianto
        $("#plantName" + vars.serialNumber).text(vars.plantName);

        $("#pumpLabel" + vars.serialNumber).text("LD OSIN - " + vars.serialNumber);

        $("#modalitaLavoro" + vars.serialNumber).text(varsInternal.languageJson.settingDownload);
        $("#hrefNext" + vars.serialNumber).attr("href", "pompe/M" + vars.pumpCode + ".aspx?serial=" + vars.serialNumber);
        $("#" + vars.serialNumber + "_pumpLeft").attr("href", "pompe/M" + vars.pumpCode + ".aspx?serial=" + vars.serialNumber);//blocco del lef connessione
        $("#hrefNext" + vars.serialNumber).text(varsInternal.languageJson.hrefText)
        //-----------------parametri impianto
    }

    this.waitConnection = function () {
        console.log("ci arrivo qui")
        //$("#messages" + vars.serialNumber).text("Connected.");
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
    // modifica grafica in funzione del protocollo
    function updateGrafica() {
        var testoModalitaLavoro = '';
        var testoUscitaConducibilita = '';
        var uscitaConducibilita = 0.0;
        var testoUnitadiMisuraUscitaConducibilita = '';
        var numeroSondaConversione = 0;
        var minutiSecondiLavaggio=''

        var testoIngressoConducibilita = '';
        var ingressoConducibilita = 0.0;
        var testoUnitadiMisuraIngressoConducibilita = '';

        var temperatura = 0.0;
        var testoTemperatura = '';
        var unitaTemperatura = '';

        var statoWarning = false;
        var txtWarning = "";
        var statoStby = false;
        var txtStby = "";
        var statoAllarme = false;
        var txtAllarme = "";

        if ((varsInternal.arrayReadSetpointResult).length > 0) {
            // --------------------conducibilità in uscita
            switch(arrayToData(varsInternal.arrayReadSetpointResult[0], 3 + 13, 2))
            {
                case 0:
                    numeroSondaConversione=24;
                    break;
                case 1:
                case 2:
                    numeroSondaConversione = 25;
                    break;
                case 3:
                    numeroSondaConversione = 26;
                    break;
                case 4:
                    numeroSondaConversione = 27;
                    break;

            }
            uscitaConducibilita = arrayToData(varsInternal.arrayReadRealTimeResult[0], 3 + 33, 2) / getFattoreDivisioneSonda(5, numeroSondaConversione);// conducibilità in uscita
            testoUscitaConducibilita = uscitaConducibilita.toFixed(getNumeroDecimaliSonda(5, numeroSondaConversione));
            testoUnitadiMisuraUscitaConducibilita = getValoreLabelJson(5, numeroSondaConversione);
            // --------------------end conducibilità in uscita
            // --------------------conducibilità in ingresso
            switch (arrayToData(varsInternal.arrayReadSetpointResult[0], 3 + 3, 2)) {
                case 0:
                    numeroSondaConversione = 24;
                    break;
                case 1:
                case 2:
                    numeroSondaConversione = 25;
                    break;
                case 3:
                    numeroSondaConversione = 26;
                    break;
                case 4:
                    numeroSondaConversione = 27;
                    break;

            }
            ingressoConducibilita = arrayToData(varsInternal.arrayReadRealTimeResult[0], 3 + 5, 2) / getFattoreDivisioneSonda(5, numeroSondaConversione);// conducibilità in uscita
            testoIngressoConducibilita = ingressoConducibilita.toFixed(getNumeroDecimaliSonda(5, numeroSondaConversione));
            testoUnitadiMisuraIngressoConducibilita = getValoreLabelJson(5, numeroSondaConversione);
            // --------------------end conducibilità in ingresso
            // --------------------temperature
            temperatura = arrayToData(varsInternal.arrayReadRealTimeResult[0], 3 + 3, 2) / 10;
            testoTemperatura = temperatura.toFixed(1);
            unitaTemperatura = "°C";
            // --------------------end temperature
            switch (arrayToData(varsInternal.arrayReadRealTimeResult[0], 3 + 1, 2)) { // gestione ON / OFF
                case 0:// OFF
                    testoModalitaLavoro = varsInternal.languageJson.pumpOff;
                    testoDosaggioIstantaneo = "0"
                    break;
                case 1:// ON
                    switch (arrayToData(varsInternal.arrayReadRealTimeResult[0], 3 + 13, 2))
                    {
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
                            minutiSecondiLavaggio = arrayToData(varsInternal.arrayReadRealTimeResult[0], 3 + 7, 2).toString() + "Min " + arrayToData(varsInternal.arrayReadRealTimeResult[0], 3 + 9, 2).toString() + "Sec"
                            break;

                    }
                    break;

            }

        }
        // controlloo Alert
        /*
        if ((arrayToData(varsInternal.arrayReadRealTimeResult[0], 3 + 1, 1) == 1) && (arrayToData(varsInternal.arrayReadRealTimeResult[0], 3 + 2, 1) == 0)) {//warning livello
            statoWarning = true;
            txtWarning = " " + varsInternal.languageJsonWarningAlarm.warningLevel;
        }
        if ((arrayToData(varsInternal.arrayReadRealTimeResult[0], 3 + 4, 1) == 1) && (arrayToData(varsInternal.arrayReadRealTimeResult[0], 3 + 28, 1) == 1)) {//warning Overflow
            statoWarning = true;
            txtWarning = " " + varsInternal.languageJsonWarningAlarm.warningOverflow;
        }
        //----- end controllo alert
        */
        // controlloo allarmi
        if ((arrayToData(varsInternal.arrayReadRealTimeResult[0], 3 + 11, 2) == 1) ) {//Alarm temperatura
            statoAllarme = true;
            txtAllarme = " " + varsInternal.languageJsonWarningAlarm.alarmTemperatura;
        }
        if ((arrayToData(varsInternal.arrayReadRealTimeResult[0], 3 + 15, 2) == 1)) {//Alarm Pressione Alta
            statoAllarme = true;
            txtAllarme = " " + varsInternal.languageJsonWarningAlarm.alarmPressioneH;
        }

        if ((arrayToData(varsInternal.arrayReadRealTimeResult[0], 3 + 17, 2) > 0)) {//Alarm Pressione Bassa tentativi
            statoAllarme = true;
            txtAllarme = " " + varsInternal.languageJsonWarningAlarm.alarmPressioneL + " " + arrayToData(varsInternal.arrayReadRealTimeResult[0], 3 + 17, 2) + " of " + arrayToData(varsInternal.arrayReadSetpointResult[0], 3 + 85, 2);
        }

        if ((arrayToData(varsInternal.arrayReadRealTimeResult[0], 3 + 19, 2) == 1)) {//Alarm Pressione Bassa
            statoAllarme = true;
            txtAllarme = " " + varsInternal.languageJsonWarningAlarm.alarmPressioneL;
        }
        if ((arrayToData(varsInternal.arrayReadRealTimeResult[0], 3 + 21, 2) == 1)) {//Alarmconducibilità in Alta
            statoAllarme = true;
            txtAllarme = " " + varsInternal.languageJsonWarningAlarm.alarmCdInH;
        }
        if ((arrayToData(varsInternal.arrayReadRealTimeResult[0], 3 + 23, 2) == 1)) {//Alarmconducibilità out Alta
            statoAllarme = true;
            txtAllarme = " " + varsInternal.languageJsonWarningAlarm.alarmCdOutH;
        }
        if ((arrayToData(varsInternal.arrayReadRealTimeResult[0], 3 + 27, 2) == 1)) {//Alarm Massimo dosaggio
            statoAllarme = true;
            txtAllarme = " " + varsInternal.languageJsonWarningAlarm.alarmDosing;
        }
        if ((arrayToData(varsInternal.arrayReadRealTimeResult[0], 3 + 29, 2) == 1)) {//Alarm filter
            statoAllarme = true;
            txtAllarme = " " + varsInternal.languageJsonWarningAlarm.alarmFilter;
        }
        if ((arrayToData(varsInternal.arrayReadRealTimeResult[0], 3 + 31, 2) == 1)) {//Alarm generic
            statoAllarme = true;
            txtAllarme = " " + varsInternal.languageJsonWarningAlarm.alarmGeneric;
        }
        if ((arrayToData(varsInternal.arrayReadRealTimeResult[0], 3 + 51, 2) == 1)) {//Alarm Levekl
            statoAllarme = true;
            txtAllarme = " " + varsInternal.languageJsonWarningAlarm.levelAlarm;
        }
        if ((arrayToData(varsInternal.arrayReadRealTimeResult[0], 3 + 53, 2) == 1)) {//Alarm temperature
            statoAllarme = true;
            txtAllarme = " " + varsInternal.languageJsonWarningAlarm.temperatureAlarm;
        }

        //--------end controlloo allarmi
        // controlloo stby
        if ((arrayToData(varsInternal.arrayReadRealTimeResult[0], 3 + 25, 1) == 1)) {//warning Standby
            statoStby = true;
            txtStby = " " + varsInternal.languageJsonWarningAlarm.alarmStby;
        }
        //-------end  controlloo stby

        alertErroreGrafica(statoAllarme, statoStby, statoWarning);
        
        $("#modalitaLavoro" + vars.serialNumber).text(testoModalitaLavoro + minutiSecondiLavaggio );
        $("#portata" + vars.serialNumber).html(testoUscitaConducibilita + "<span class=\"little\">" + testoUnitadiMisuraUscitaConducibilita + "</span>");

        $("#valore1" + vars.serialNumber).attr("data-original-title", varsInternal.languageJson.titleIngresso)
        $("#valore1" + vars.serialNumber).html(testoIngressoConducibilita + " " + testoUnitadiMisuraIngressoConducibilita);

        $("#valore2" + vars.serialNumber).attr("data-original-title", varsInternal.languageJson.titleTemperatura)
        $("#valore2" + vars.serialNumber).html(testoTemperatura + " " + unitaTemperatura);
/*
        $("#valore3" + vars.serialNumber).attr("data-original-title", varsInternal.languageJson.titleSlow)
        $("#valore3" + vars.serialNumber).html(testoSlowMode + "<span></span><i class=\"mdi mdi-eject\"></i>");
        */

    }
    function alertErroreGrafica(statoAllarme, statoStby, statoWarning) {
        var i;
        for (i = 0; i < classePompa.length; ++i) {
            // do something with `substr[i]`
            $("#" + vars.serialNumber + "_pump").removeClass(classePompa[i]);
        }
        $("#" + vars.serialNumber + "_pump").addClass("impiantoacceso");


        if (statoAllarme || statoStby || statoWarning)
            $("#" + vars.serialNumber + "_pump").addClass("allarme");

        for (i = 0; i < classePompaColor.length; ++i) {
            $("#headerColor" + vars.serialNumber).removeClass(classePompaColor[i]);
            $("#hrefNext" + vars.serialNumber).removeClass(classePompaButton[i]);
            $("#iconStatus" + vars.serialNumber).removeClass(classePompaIcon[i]);
        }
        //giallo
        if (statoWarning) {
            $("#headerColor" + vars.serialNumber).addClass(classePompaColor[2]);
            $("#hrefNext" + vars.serialNumber).addClass(classePompaButton[2]);
            $("#iconStatus" + vars.serialNumber).addClass(classePompaIcon[2]);
            return;
        }
        //gigio
        if (statoStby) {
            $("#headerColor" + vars.serialNumber).addClass(classePompaColor[3]);
            $("#hrefNext" + vars.serialNumber).addClass(classePompaButton[3]);
            $("#iconStatus" + vars.serialNumber).addClass(classePompaIcon[3]);
            return;
        }
        //rosso
        if (statoAllarme) {
            $("#headerColor" + vars.serialNumber).addClass(classePompaColor[0]);
            $("#hrefNext" + vars.serialNumber).addClass(classePompaButton[0]);
            $("#iconStatus" + vars.serialNumber).addClass(classePompaIcon[0]);
            return;
        }
        //green
        $("#headerColor" + vars.serialNumber).addClass(classePompaColor[1]);
        $("#hrefNext" + vars.serialNumber).addClass(classePompaButton[1]);
        $("#iconStatus" + vars.serialNumber).addClass(classePompaIcon[1]);
        return;

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
    function getFattoreDivisioneSonda(tipoCanale, numeroSonda) {
        var indiceCancvas = 0;

        for (indiceCancvas = 0; indiceCancvas < jsonParseListaSonde.variable.length; indiceCancvas++) {
            if ((jsonParseListaSonde.variable[indiceCancvas]["tipoCanale"] == tipoCanale) && (jsonParseListaSonde.variable[indiceCancvas]["numeroSonda"] == numeroSonda)) {
                switch(parseInt(jsonParseListaSonde.variable[indiceCancvas]["decimali"]))
                {
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
}



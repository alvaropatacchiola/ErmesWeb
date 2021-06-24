


var OggettoPompaSub = function (options)
{
    var vars = {
        serialNumber: '',
        arrayReadRealTime: [],
        arrayReadSetpoint: [],
        plantName: '',
        languageSet: ''
    };
    var varsInternal = {
        arrayReadRealTimeResult: [],
        arrayReadSetpointResult: [],
        languageJson: null,
        languageJsonWarningAlarm : null
    };
    this.construct = function (options) {
        $.extend(vars, options);
        //console.log("lingua:" + t0101[vars.languageSet]);
        varsInternal.languageJson = jQuery.parseJSON(t0101[vars.languageSet]);
        varsInternal.languageJsonWarningAlarm = jQuery.parseJSON(t0101AlarmWarning[vars.languageSet]);
        

    };

    this.construct(options);

    this.updateValoriSetpoint = function (arrayReadSetpointTemp, indexGlobalProtocolloTemp) {
        varsInternal.arrayReadSetpointResult[indexGlobalProtocolloTemp] = arrayReadSetpointTemp;
        //-----------------download dei setting della pompa o sync
        $("#modalitaLavoro" + vars.serialNumber).text(varsInternal.languageJson.settingDownload);
        //-----------------download dei setting della pompa o sync
    }
    this.checkReSyncSetpoint = function () {
        return (arrayToData(varsInternal.arrayReadRealTimeResult[0], 3 + 112, 1))
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
        $("#modalitaLavoro" + vars.serialNumber).text(varsInternal.languageJson.settingDownload);
        $("#hrefNext" + vars.serialNumber).attr("href", "pompe/M0101.aspx?serial=" + vars.serialNumber);
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
        var testoDosaggioIstantaneo = '';
        var dosaggioIstantaneo = 0.0;
        var testoUnitadiMisura = '';
        var testoFrequenza = '';
        var testoSlowMode = '';
        var testoPulseMinute = '';
        var statoWarning = false;
        var txtWarning = "";
        var statoStby = false;
        var txtStby = "";
        var statoAllarme = false;
        var txtAllarme = "";

        var startDelay = 0;
        var startDelayMinuti = 0;
        var startDelaySecondi = 0;
        if ((varsInternal.arrayReadSetpointResult).length > 0) {

            startDelay = arrayToData(varsInternal.arrayReadRealTimeResult[0], 3 + 138, 1);
            startDelayMinuti = arrayToData(varsInternal.arrayReadRealTimeResult[0], 3 + 139, 1);
            startDelaySecondi = arrayToData(varsInternal.arrayReadRealTimeResult[0], 3 + 140, 1);

            dosaggioIstantaneo = arrayToData(varsInternal.arrayReadRealTimeResult[0], 3 + 8, 4);// valore del dosaggio istantaneo
            // se Galloni scrivo x.xxx gal/h se litri sscrivo: xxx ml/h se <1 altrimenti x.xxx l/h
            testoDosaggioIstantaneo = arrayToData(varsInternal.arrayReadRealTimeResult[0], 3 + 22, 1) == 1 ? (dosaggioIstantaneo / 1000).toFixed(3) : ((dosaggioIstantaneo / 1000 > 0 && dosaggioIstantaneo / 1000 < 1) ? dosaggioIstantaneo.toString() : (dosaggioIstantaneo / 1000).toFixed(3))
            testoUnitadiMisura = arrayToData(varsInternal.arrayReadRealTimeResult[0], 3 + 22, 1) == 1 ? "Gal/h" : ((dosaggioIstantaneo / 1000 > 0 && dosaggioIstantaneo / 1000 < 1) ? "ml/h" : "l/h")

            //Velocità di rotazione del motore, con 1 ciffre decimali, espressa in %.Da0%a 100% 
            testoFrequenza = (arrayToData(varsInternal.arrayReadRealTimeResult[0], 3 + 12, 4) / 1000) == 100.0 ? "100 %" : (arrayToData(varsInternal.arrayReadRealTimeResult[0], 3 + 12, 4) / 1000).toFixed(3) + "%";
            //SLOW MODE
            testoSlowMode = (arrayToData(varsInternal.arrayReadRealTimeResult[0], 3 + 35, 1)).toFixed(1) + "%";
            //console.log(testoUnitadiMisura)
            switch (arrayToData(varsInternal.arrayReadSetpointResult[0], 3 + 1, 1)) { // gestione ON / OFF
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
                    switch (arrayToData(varsInternal.arrayReadSetpointResult[0], 3 + 2, 1)) { // gestione modalità di lavoro
                        case 0://Constant
                            testoModalitaLavoro = varsInternal.languageJson.modalita0;
                            //ok niente per cui nascosto
                            $("#valore1" + vars.serialNumber).hide();
                            break;
                        case 1://cc per pulse
                            testoModalitaLavoro = varsInternal.languageJson.modalita1;
                            //ok p/m netto
                            $("#valore1" + vars.serialNumber).show();
                            testoPulseMinute = arrayToData(varsInternal.arrayReadRealTimeResult[0], 3 + 117, 2).toString() + "P/m"
                            break;
                        case 2://ppm
                            testoModalitaLavoro = varsInternal.languageJson.modalita2;
                            //ok p/m netto
                            $("#valore1" + vars.serialNumber).show();
                            if (checkUpKeep())
                                testoPulseMinute = upKeepStr();
                            else
                                testoPulseMinute = arrayToData(varsInternal.arrayReadRealTimeResult[0], 3 + 117, 2).toString() + "P/m"
                            break;
                        case 3://perc
                            testoModalitaLavoro = varsInternal.languageJson.modalita3;
                            //ok p/m netto
                            $("#valore1" + vars.serialNumber).show();
                            if (checkUpKeep())
                                testoPulseMinute = upKeepStr();
                            else
                                testoPulseMinute = arrayToData(varsInternal.arrayReadRealTimeResult[0], 3 + 117, 2).toString() + "P/m"
                            break;
                        case 4://MLQ
                            testoModalitaLavoro = varsInternal.languageJson.modalita4;
                            //ok p/m netto
                            $("#valore1" + vars.serialNumber).show();
                            if (checkUpKeep())
                                testoPulseMinute = upKeepStr();
                            else
                                testoPulseMinute = arrayToData(varsInternal.arrayReadRealTimeResult[0], 3 + 117, 2).toString() + "P/m"
                            break;
                        case 5://batch
                            testoModalitaLavoro = varsInternal.languageJson.modalita5;
                            //ok litri o gal con tre decimali dopo la virgola con regola sotto a 1 scrivo ml galloni no.
                            //var litriOGalloni = arrayToData(varsInternal.arrayReadRealTimeResult[0], 3 + 117, 2);// valore del dosaggio istantaneo
                            var litriOGalloni = arrayToData(varsInternal.arrayReadRealTimeResult[0], 3 + 125, 8) / 10000;// valore del dosaggio istantaneo
                            testoPulseMinute = arrayToData(varsInternal.arrayReadRealTimeResult[0], 3 + 22, 1) == 1 ? (litriOGalloni / 1000).toFixed(3) + " Gal" : ((litriOGalloni / 1000 > 0 && litriOGalloni / 1000 < 1) ? litriOGalloni.toString() + " mL" : (litriOGalloni / 1000).toFixed(3) + " L")
                            $("#valore1" + vars.serialNumber).show();
                            break;
                        case 6://volt
                            testoModalitaLavoro = varsInternal.languageJson.modalita6;
                            //ok volt diviso 10 Volt
                            $("#valore1" + vars.serialNumber).show();
                            testoPulseMinute = (arrayToData(varsInternal.arrayReadRealTimeResult[0], 3 + 117, 2) / 10).toFixed(1) + "V"
                            break;
                        case 7://mA
                            testoModalitaLavoro = varsInternal.languageJson.modalita7;
                            //ok mA diviso 10 mA
                            $("#valore1" + vars.serialNumber).show();
                            testoPulseMinute = (arrayToData(varsInternal.arrayReadRealTimeResult[0], 3 + 117, 2) / 10).toFixed(1) + "mA"
                            break;
                        case 8://pulse
                            testoModalitaLavoro = varsInternal.languageJson.modalita8;
                            //ok p/m netto
                            $("#valore1" + vars.serialNumber).show();
                            testoPulseMinute = arrayToData(varsInternal.arrayReadRealTimeResult[0], 3 + 117, 2).toString() + "P/m"
                            break;
                        case 9://pause - work
                            testoModalitaLavoro = varsInternal.languageJson.modalita9;
                            //ok tempo in m:s
                            $("#valore1" + vars.serialNumber).show();
                            if (arrayToData(varsInternal.arrayReadRealTimeResult[0], 3 + 113, 1) == 1) {// sto in pause
                                testoPulseMinute = varsInternal.languageJson.pauseText + " " + arrayToData(varsInternal.arrayReadRealTimeResult[0], 3 + 121, 1).toString() + ":" + arrayToData(varsInternal.arrayReadRealTimeResult[0], 3 + 122, 1).toString()
                            }
                            else {//sto in lavoro
                                testoPulseMinute = varsInternal.languageJson.workText + " " + arrayToData(varsInternal.arrayReadRealTimeResult[0], 3 + 121, 1).toString() + ":" + arrayToData(varsInternal.arrayReadRealTimeResult[0], 3 + 122, 1).toString()
                            }
                            break;
                        case 10://weekly
                            testoModalitaLavoro = varsInternal.languageJson.modalita10;

                            $("#valore1" + vars.serialNumber).show();
                            //ok litri o gal con tre decimali dopo la virgola con regola sotto a 1 scrivo ml galloni no.
                            var litriOGalloni = arrayToData(varsInternal.arrayReadRealTimeResult[0], 3 + 125, 8) / 100;// valore del dosaggio istantaneo
                            if (arrayToData(varsInternal.arrayReadRealTimeResult[0], 3 + 114, 1) == 1) {//start
                                testoPulseMinute = arrayToData(varsInternal.arrayReadRealTimeResult[0], 3 + 22, 1) == 1 ? (litriOGalloni / 1000).toFixed(3) + " Gal" : ((litriOGalloni / 1000 > 0 && litriOGalloni / 1000 < 1) ? litriOGalloni.toString() + " mL" : (litriOGalloni / 1000).toFixed(3) + " L")
                            }
                            else {//stop  nex prog
                                testoPulseMinute = "Next Prog P" + (arrayToData(varsInternal.arrayReadRealTimeResult[0], 3 + 115, 1) + 1).toString()
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
        if ((arrayToData(varsInternal.arrayReadRealTimeResult[0], 3 + 1, 1) == 1) && (arrayToData(varsInternal.arrayReadRealTimeResult[0], 3 + 2, 1) == 0))
        {//warning livello
            statoWarning = true;
            txtWarning = " " + varsInternal.languageJsonWarningAlarm.warningLevel;
        }
        if ((arrayToData(varsInternal.arrayReadRealTimeResult[0], 3 + 4, 1) == 1) && (arrayToData(varsInternal.arrayReadRealTimeResult[0], 3 + 28, 1) == 1))
        {//warning Overflow
            statoWarning = true;
            txtWarning = " " + varsInternal.languageJsonWarningAlarm.warningOverflow;
        }
        //----- end controllo alert
        // controlloo allarmi
        if ((arrayToData(varsInternal.arrayReadRealTimeResult[0], 3 + 1, 1) == 1) && (arrayToData(varsInternal.arrayReadRealTimeResult[0], 3 + 2, 1) == 1))
        {//Alarm livello
            statoAllarme = true;
            txtAllarme = " " + varsInternal.languageJsonWarningAlarm.alarmLevel;
        }
        if ((arrayToData(varsInternal.arrayReadRealTimeResult[0], 3 + 4, 1) == 1) && (arrayToData(varsInternal.arrayReadRealTimeResult[0], 3 + 28, 1) == 0))
        {//Alarm overflow
            statoAllarme = true;
            txtAllarme = " " + varsInternal.languageJsonWarningAlarm.alarmOverflow;
        }
        if ((arrayToData(varsInternal.arrayReadRealTimeResult[0], 3 + 5, 1) == 1))
        {//Alarm temperatura
            statoAllarme = true;
            txtAllarme = " " + varsInternal.languageJsonWarningAlarm.alarmTemperatura;
        }
        if ((arrayToData(varsInternal.arrayReadRealTimeResult[0], 3 + 6, 1) == 1))
        {//Alarm Input
            statoAllarme = true;
            txtAllarme = " " + varsInternal.languageJsonWarningAlarm.alarmInput;
        }
        if ((arrayToData(varsInternal.arrayReadRealTimeResult[0], 3 + 7, 1) == 1))
        {//Alarm Motore Bloccato
            statoAllarme = true;
            txtAllarme = " " + varsInternal.languageJsonWarningAlarm.alarmMotoreBloccato;
        }
        //--------end controlloo allarmi
        // controlloo stby
        if ((arrayToData(varsInternal.arrayReadRealTimeResult[0], 3 + 3, 1) == 1))
        {//warning Standby
            statoStby = true;
            txtStby = " " + varsInternal.languageJsonWarningAlarm.alarmStby;
        }
        //-------end  controlloo stby

        alertErroreGrafica(statoAllarme, statoStby, statoWarning);
        $("#modalitaLavoro" + vars.serialNumber).text(testoModalitaLavoro + txtAllarme + txtWarning + txtStby);
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
    function checkUpKeep()
    {
        if (arrayToData(varsInternal.arrayReadSetpointResult[0], 3 + 85, 1) > 0) {//up keep enable
            //if ((arrayToData(varsInternal.arrayReadRealTimeResult[0], 3 + 123, 1) > 0) || (arrayToData(varsInternal.arrayReadRealTimeResult[0], 3 + 124, 1) > 0))
            if (arrayToData(varsInternal.arrayReadRealTimeResult[0], 3 + 117, 2) == 0)//se non ci sono impulsi allora sono in upkee
                return true
        }
        return false;
    }
    function upKeepStr()
    {
        return varsInternal.languageJson.upKeepText + " : " + arrayToData(varsInternal.arrayReadRealTimeResult[0], 3 + 123, 1).toString() + "h " + arrayToData(varsInternal.arrayReadRealTimeResult[0], 3 + 124, 1).toString() + "m"
    }

}






var OggettoPompaSub = function (options)
{
    var vars = {
        serialNumber: '',
        arrayReadRealTime: [],
        arrayReadSetpoint: []
    };
    this.construct = function (options) {
        $.extend(vars, options);
    };

    this.construct(options);

    this.updateValoriRuntime = function (arrayReadRealTimeTemp) {
        vars.arrayReadRealTime = arrayReadRealTimeTemp;
        $("#messages1" + vars.serialNumber).text((arrayToData(vars.arrayReadRealTime, 11, 4) / 1000) + " l/h")
        $("#messages2" + vars.serialNumber).text((arrayToData(vars.arrayReadRealTime, 15, 4) / 1000) + " %")
    }
    this.startDocument = function () {
        
        $("[id*='_SN']").each(function () {
            //$("#" + $(this).attr("id")).removeClass("active");
            var selectionId = $(this).attr("id");
            if (selectionId != undefined) {
                $(this).attr("id", selectionId.replace("_SN", vars.serialNumber));
            }
        });
    }

    this.waitConnection = function () {
        console.log("ci arrivo qui")
        $("#messages" + vars.serialNumber).text("Connected.");
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
}




var faseRisposta = 0;
$(document).ready(function () {
    $("#cercaSerial").click(function () {
        faseRisposta = 0;
        $('#statoR').text("Wait ....")
        //$('#result').text("")
        leggiDati()
        console.log("cliccato:" + $('#serialNumber').val())
        return false;
    });
});

function leggiDati() {
    $.ajax({
        type: "POST",
        url: "Centurio/centurioReal.aspx/getAllData",
        //data: {check1: $("#rms_all").is(':checked') ,check1_1: $("#rms_medio").is(':checked'),  check1_2:  $("#rms_max").is(':checked') ,check2 : $("#picco_all").is(':checked') , check2_1 : $("#picco_medio").is(':checked') , check2_2 : $("#picco_max").is(':checked') , check3: $("#vm_rms_all").is(':checked') , check3_1: $("#vm_rms_medio").is(':checked') , check3_2 : $("#vm_rms_max").is(':checked') , check4 : $("#vm_picco_all").is(':checked') , check4_1 : $("#vm_picco_medio").is(':checked') , check4_2: $("#vm_picco_max").is(':checked')   },
        //data: { check1: false, check1_1: true, check1_2: false, check2: false, check2_1: true, check2_2: false, check3: false, check3_1:true, check3_2:false, check4: false, check4_1:true, check4_2:false },
        data: "{'serialNumber':'" + JSON.stringify($('#serialNumber').val()) + "'}",
        contentType: "application/json; charset=utf-8",
        //async: false,
        dataType: "json",
        //timeout: 6000, //3 second timeout
        success: function (response) {

            $('#result').text(response.d)
            faseRisposta = faseRisposta + 1;
            $('#statoR').text("risultato "+faseRisposta.toString()+" ...2")

        },
        failure: function (response) {
            $('#statoR').text("Errore")
        }

    });
    $.ajax({
        type: "POST",
        url: "Centurio/centurioReal.aspx/leggiLogConnessione",
        //data: {check1: $("#rms_all").is(':checked') ,check1_1: $("#rms_medio").is(':checked'),  check1_2:  $("#rms_max").is(':checked') ,check2 : $("#picco_all").is(':checked') , check2_1 : $("#picco_medio").is(':checked') , check2_2 : $("#picco_max").is(':checked') , check3: $("#vm_rms_all").is(':checked') , check3_1: $("#vm_rms_medio").is(':checked') , check3_2 : $("#vm_rms_max").is(':checked') , check4 : $("#vm_picco_all").is(':checked') , check4_1 : $("#vm_picco_medio").is(':checked') , check4_2: $("#vm_picco_max").is(':checked')   },
        //data: { check1: false, check1_1: true, check1_2: false, check2: false, check2_1: true, check2_2: false, check3: false, check3_1:true, check3_2:false, check4: false, check4_1:true, check4_2:false },
        data: "{'serialNumber':'" + JSON.stringify($('#serialNumber').val()) + "'}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        //async: false,
        //timeout: 6000, //3 second timeout
        success: function (response) {
            faseRisposta = faseRisposta + 1;
            $('#statoR').text("risultato " + faseRisposta.toString() + " ...2")
            $('#log').html(response.d)

        },
        failure: function (response) {
            $('#statoR').text("Errore")
        }

    });
}
//var var_alarm_aa_on = false;
//var var_alarm_aa_perc1 = false;
//var var_alarm_aa_off = false;
//var var_alarm_aa_perc2 = false;

//var var_alarm_ab_on = false;
//var var_alarm_ab_perc1 = false;
//var var_alarm_ab_off = false;
//var var_alarm_ab_perc2 = false;

//var var_alarm_pa_on = false;
//var var_alarm_pa_perc1 = false;
//var var_alarm_pa_off = false;
//var var_alarm_pa_perc2 = false;

//var var_alarm_pb_on = false;
//var var_alarm_pb_perc1 = false;
//var var_alarm_pb_off = false;
//var var_alarm_pb_perc2 = false;

//var var_alarm_ma_on = false;
//var var_alarm_ma_perc1 = false;
//var var_alarm_ma_off = false;
//var var_alarm_ma_perc2 = false;

//var var_alarm_aa1 = false;
//var var_alarm_ab1 = false;

//var var_alarm_ad_ore = false;
//var var_alarm_ad_min = false;

//var var_alarm_ar_ore = false;
//var var_alarm_ar_min = false;

var var_alarm_ch1_calibration = false;
var var_alarm_ch2_calibration = false;
//var error_general = false;

//------------------------------------------------------------
//---CONTROLLO RELAY A E RELAY B------------------------------
//------------------------------------------------------------
function remove_allarme(id1, id2) {
    var id = "#" + id1;
    var id_1 = "#" + id2;

    $(id_1).removeClass('error');
    $(id).next('p').remove();
}

function Changed_channel(id1, id2, max_ch, min_ch, myfix) {
    var id = "#" + id1;
    var id_1 = "#" + id2;
    var var_alarm = false;
    var myNumber;

    var value_form = $(id).val();
    myNumber = parseFloat(value_form);
    myNumber = myNumber.toFixed(myfix);
    var_alarm = false;
    if ((isNaN(myNumber)) || (myNumber > max_ch) || (myNumber < min_ch)) {
        $(id_1).removeClass('error');
        $(id).next('p').remove();

        $(id).after('<p class="error help-block"><span class="label label-important">' + range + ' ' + min_ch + ' - ' + max_ch + '</span></p>');
        $(id_1).addClass('error')
        var_alarm = true
    }
    switch (id1) {

        // sezione calibrazione
        case "ch1_new_value":
            var_alarm_ch1_calibration = var_alarm;
            break;
        case "ch2_new_value":
            var_alarm_ch2_calibration = var_alarm;
            break;
    }
}
//------------------------------------------------------------
//---END CONTROLLO RELAY A E RELAY B------------------------------
//------------------------------------------------------------
//calibrazione
function enable_channel_calibrazione(numero_canali) {
    switch (numero_canali) {
        case 1: // 1 solo canale
            $("#div_ch2").hide();
            $("#div_ch3").hide();
            $("#div_ch4").hide();
            $("#div_ch5").hide();
            break;
        case 2: // 2 solo canale
            $("#div_ch3").hide();
            $("#div_ch4").hide();
            $("#div_ch5").hide();
            break;
        case 3: // 3 solo canale
            $("#div_ch4").hide();
            $("#div_ch5").hide();
            break;
        case 4: // 4 solo canale
            $("#div_ch5").hide();
            break;
        case 5: // 5 solo canale
            break;

    }
}
//end calibrazione

// sezione calibrazione
//------------------------------------------------------------
//---KEY PRESSED ch1 value------------------------------
//------------------------------------------------------------

$("#ch1_new_value").keypress(function (evt) {
    return keypress_channel(evt);
});

$("#ch2_new_value").keypress(function (evt) {
    return keypress_channel(evt);
});
//------------------------------------------------------------
//---end KEY PRESSED ch1 value------------------------------
//------------------------------------------------------------

// end sezione calibrazione


//SEZIONE CALIBRAZIONEù
$("#ch1_new_value").click(function () {
 
    //$(this).val("");
    $(this).next('p').remove();
    $("#div_ch1_1").removeClass('error');
    var_alarm_ch1_calibration = false;
    // $("#principale").load("test.aspx");
    $("#ch1_probe_enale").prop('checked', true);

});

$("#ch2_new_value").click(function () {
  
    //$(this).val("");
    $(this).next('p').remove();
    $("#div_ch2_1").removeClass('error');
    var_alarm_ch2_calibration = false;
    // $("#principale").load("test.aspx");
    $("#ch2_probe_enale").prop('checked', true);
 
});
// END SEZIONE CALIBRAZIONE



$("#save_calibration_newld").click(function () {


    if (enable_send_setpoint == false) {
        result_setpoint_change(user_setpoint_disable);
        return false;
    }

    var one_setting = true;
    $('#save_calibration_newld').next('p').remove();

    if ($('#ch1_probe_enale').is(':checked')) {
        one_setting = false;
        Changed_channel('ch1_new_value', 'div_ch1_1', max_ch1_value, min_ch1_value, ch1_fix);
    }
    if ($('#ch2_probe_enale').is(':checked')) {
        one_setting = false;
        Changed_channel('ch2_new_value', 'div_ch2_1', max_ch2_value, min_ch2_value, ch2_fix);
    }


    if ((var_alarm_ch1_calibration) || (var_alarm_ch2_calibration)) {

        $('#save_calibration_newld').next('p').remove();
        $('#save_calibration_newld').after('<p class="error help-block"><span class="label label-important">' + wrong_settings + '</span></p>');
        submit_status = false;
        error_general = false;
        return false;
    }

    submit_status = true;
    error_general = true;
    notification['confirm'] = modify_plant;
    notification['annulla'] = annulla_impianto;
    // return true;


});
//END GESTIONE SALVATAGGIO DATI


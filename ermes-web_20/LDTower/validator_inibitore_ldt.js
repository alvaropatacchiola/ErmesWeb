var alarm_value_min_inhib = false;
var alarm_value_sec_inhib = false;
var alarm_value_count_inhib = false;
var alarm_water_meter_ppm = false;
var alarm_water_meter_ppm_percent = false;
var alarm_water_meter_ppm_cc_st = false;
var alarm_water_meter_ppm_l_h = false;


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
        case "value_min_inhib":
            alarm_value_min_inhib = var_alarm;
            //check_alarm_flow_time();
            break;
        case "value_sec_inhib":
            alarm_value_sec_inhib = var_alarm;
            //check_alarm_flow_time();
            break;
        case "value_counter_inhib":
            alarm_value_count_inhib = var_alarm;
            //check_alarm_flow_time();
            break;
        case "value_water_meter_ppm":
            alarm_water_meter_ppm = var_alarm;
            //check_alarm_flow_time();
            break;
        case "value_water_meter_ppm_percent":
            alarm_water_meter_ppm_percent = var_alarm;
            //check_alarm_flow_time();
            break;
        case "value_water_meter_ppm_cc_st":
            alarm_water_meter_ppm_cc_st = var_alarm;
            //check_alarm_flow_time();
            break;
        case "value_water_meter_ppm_l_h":
            alarm_water_meter_ppm_l_h = var_alarm;
            //check_alarm_flow_time();
            break;
    }
}

function keypress_channel_number(evt) {
    var charCode = (evt.which) ? evt.which : event.keyCode

    if (charCode > 31 && (charCode < 48 || charCode > 57))
        return false;

    return true;

}

/////////////////////////////// DA FARE TUTTA LA GESTIONE DELLA VALIDAZIONE  /////////////////////////////////////////////


//VALIDAZIONE DELLE STRINGHE INSERITE NEI CAMPI DI TESTO
$("#value_min_inhib").keypress(function (evt) {
    return keypress_channel_number(evt);                // controllo che i caratteri siano numeri e non stringhe 
});

$("#value_sec_inhib").keypress(function (evt) {
    return keypress_channel_number(evt);                // controllo che i caratteri siano numeri e non stringhe 
});

$("#value_counter_inhib").keypress(function (evt) {
    return keypress_channel_number(evt);                // controllo che i caratteri siano numeri e non stringhe 
});

$("#value_water_meter_ppm").keypress(function (evt) {
    return keypress_channel_number(evt);                // controllo che i caratteri siano numeri e non stringhe 
});

$("#value_water_meter_ppm_percent").keypress(function (evt) {
    return keypress_channel_number(evt);                // controllo che i caratteri siano numeri e non stringhe 
});

$("#value_water_meter_ppm_cc_st").keypress(function (evt) {
    return keypress_channel_number(evt);                // controllo che i caratteri siano numeri e non stringhe 
});

$("#value_water_meter_ppm_l_h").keypress(function (evt) {
    return keypress_channel_number(evt);                // controllo che i caratteri siano numeri e non stringhe 
});



$("#value_min_inhib").click(function () {

    $(this).next('p').remove();
    $("#riga1_value_min_inhib").removeClass('error');
    alarm_value_min_inhib = false;

});

$("#value_sec_inhib").click(function () {

    $(this).next('p').remove();
    $("#riga1_value_sec_inhib").removeClass('error');
    alarm_value_sec_inhib = false;

});

$("#value_counter_inhib").click(function () {

    $(this).next('p').remove();
    $("#riga1_value_count_inhib").removeClass('error');
    alarm_value_count_inhib = false;

});

$("#value_water_meter_ppm").click(function () {

    $(this).next('p').remove();
    $("#riga_water_meter_ppm").removeClass('error');
    alarm_water_meter_ppm = false;

});

$("#value_water_meter_ppm_percent").click(function () {

    $(this).next('p').remove();
    $("#riga_water_meter_ppm_percent").removeClass('error');
    alarm_water_meter_ppm_percent = false;

});

$("#value_water_meter_ppm_cc_st").click(function () {

    $(this).next('p').remove();
    $("#riga_water_meter_ppm_cc_st").removeClass('error');
    alarm_water_meter_ppm_cc_st = false;

});

$("#value_water_meter_ppm_l_h").click(function () {

    $(this).next('p').remove();
    $("#riga_water_meter_ppm_l_h").removeClass('error');
    alarm_water_meter_ppm_l_h = false;

});


//AZIONE DEL CLICK SUI RADIO BUTTON

$("#WM_inhib").click(function () {
    enable_WM_inhib();
});

$("#WM_ppm_inhib").click(function () {
    enable_WM_ppm_inhib();
});

$("#enable_water_meter_ppm_l_h").click(function () {
    enable_WM_l_h();
});
$("#enable_water_meter_ppm_cc_st").click(function () {
    enable_WM_cc_st();
});


//FUNZIONI UTILIZZATE NELLE AZIONI DEI RADIOBUTTON
function reset_variable() {

    alarm_value_min_inhib = false;
    alarm_value_sec_inhib = false;
    alarm_value_count_inhib = false;
    alarm_water_meter_ppm = false;
    alarm_water_meter_ppm_percent = false;
    alarm_water_meter_ppm_cc_st = false;
    alarm_water_meter_ppm_l_h = false;
}

function enable_WM_inhib() {
    $("#enable_value_WM").show();
    $("#enable_value_water_meter_ppm").hide();
    
    reset_variable();
}
function enable_WM_l_h() {
    $("#div_enable_water_meter_ppm_cc_st").hide();
    $("#div_enable_water_meter_ppm_l_h").show();
}
function enable_WM_cc_st() {
    $("#div_enable_water_meter_ppm_cc_st").show();
    $("#div_enable_water_meter_ppm_l_h").hide();
}

function enable_WM_ppm_inhib() {
    $("#enable_value_WM").hide();
    $("#enable_value_water_meter_ppm").show();

    reset_variable();
}
//AZIONE DEL CLICK SUL TASTO DI SALVATAGGIO

$("#save_inibldt_new").click(function () {
    if (enable_send_setpoint == false) {
        result_setpoint_change(user_setpoint_disable);
        return false;
    }

    $('#save_inibldt_new').next('p').remove();
    if (($('#WM_inhib').is(':checked'))) {
        Changed_channel('value_min_inhib', 'riga1_value_min_inhib', 99, 0, 0);
        Changed_channel('value_sec_inhib', 'riga1_value_sec_inhib', 59, 0, 0);
        Changed_channel('value_counter_inhib', 'riga1_value_count_inhib', 9999, 0, 0);
    }
     if (($('#WM_ppm_inhib').is(':checked'))) {
         Changed_channel('value_water_meter_ppm', 'riga_water_meter_ppm', max_us, 0, 0);
         Changed_channel('value_water_meter_ppm_cc_st', 'riga_water_meter_ppm_cc_st', 999, 0, 0);
         Changed_channel('value_water_meter_ppm_l_h', 'riga_water_meter_ppm_l_h', 999, 0, 0);
     }
    
    if ((alarm_value_min_inhib) || (alarm_value_sec_inhib) || (alarm_value_count_inhib) || (alarm_water_meter_ppm) || (alarm_water_meter_ppm_percent)
            || (alarm_water_meter_ppm_cc_st) || (alarm_water_meter_ppm_l_h))
    {
        alert("inibitore")
        $('#save_inibldt_new').next('p').remove();
        $('#save_inibldt_new').after('<p class="error help-block"><span class="label label-important">' + wrong_settings + '</span></p>');
        submit_status = false;
        error_general = false;
        return false;
    }
    submit_status = true;
    error_general = true;
    notification['confirm'] = modify_plant;
    notification['annulla'] = annulla_impianto;

});
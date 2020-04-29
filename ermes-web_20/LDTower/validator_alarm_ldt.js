var alarm_cond_low_abs = false;
var alarm_cond_low_track = false;
var alarm_cond_high_abs = false;
var alarm_cond_high_track = false;



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
        case "value_cond_low_abs":
            alarm_cond_low_abs = var_alarm;
            //check_alarm_flow_time();
            break;
        case "value_cond_low_track":
            alarm_cond_low_track = var_alarm;
            //check_alarm_flow_time();
            break;
        case "value_cond_high_abs":
            alarm_cond_high_abs = var_alarm;
            //check_alarm_flow_time();
            break;
        case "value_cond_high_track":
            alarm_cond_high_track = var_alarm;
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
$("#value_cond_low_abs").keypress(function (evt) {
    return keypress_channel_number(evt);                // controllo che i caratteri siano numeri e non stringhe 
});

$("#value_cond_low_track").keypress(function (evt) {
    return keypress_channel_number(evt);                // controllo che i caratteri siano numeri e non stringhe 
});

$("#value_cond_high_abs").keypress(function (evt) {
    return keypress_channel_number(evt);                // controllo che i caratteri siano numeri e non stringhe 
});

$("#value_cond_high_track").keypress(function (evt) {
    return keypress_channel_number(evt);                // controllo che i caratteri siano numeri e non stringhe 
});



$("#value_cond_low_abs").click(function () {

    $(this).next('p').remove();
    $("#riga_cond_low_abs").removeClass('error');
    alarm_cond_low_abs = false;

});

$("#value_cond_low_track").click(function () {

    $(this).next('p').remove();
    $("#riga_cond_low_track").removeClass('error');
    alarm_cond_low_track = false;

});

$("#value_cond_high_abs").click(function () {

    $(this).next('p').remove();
    $("#riga_cond_high_abs").removeClass('error');
    alarm_cond_high_abs = false;

});

$("#value_cond_high_track").click(function () {

    $(this).next('p').remove();
    $("#riga_cond_high_track").removeClass('error');
    alarm_cond_high_track = false;

});

//AZIONE DEL CLICK SUI RADIO BUTTON

$("#cond_low_off").click(function () {
    cond_low_off();
});
$("#cond_low_absolute").click(function () {
    cond_low_absolute();
});

$("#cond_low_track").click(function () {
    cond_low_track();
});

$("#cond_high_off").click(function () {
    cond_high_off();
});

$("#cond_high_absolute").click(function () {
    cond_high_absolute();
});

$("#cond_high_track").click(function () {
    cond_high_track();
});


function cond_low_off() {
    $("#enable_cond_low_track").hide();
    $("#enable_cond_low_abs").hide();

}

function cond_low_absolute() {
    $("#enable_cond_low_track").hide();
    $("#enable_cond_low_abs").show();

}

function cond_low_track() {
    $("#enable_cond_low_track").show();
    $("#enable_cond_low_abs").hide();

}


function cond_high_off() {
    $("#enable_cond_high_track").hide();
    $("#enable_cond_high_abs").hide();
}

function cond_high_absolute() {
    $("#enable_cond_high_track").hide();
    $("#enable_cond_high_abs").show();

}

function cond_high_track() {
    $("#enable_cond_high_track").show();
    $("#enable_cond_high_abs").hide();

}


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


//AZIONE DEL CLICK SUL TASTO DI SALVATAGGIO

$("#save_alarm_ldtower_new").click(function () {
    if (enable_send_setpoint == false) {
        result_setpoint_change(user_setpoint_disable);
        return false;
    }

    $('#save_alarm_ldtower_new').next('p').remove();

 //   alert("allarme")
    if (!($('#cond_low_off').is(':checked'))) {
        Changed_channel('value_cond_low_abs', 'riga_cond_low_abs', max_cond, 0, 0);
        Changed_channel('value_cond_low_track', 'riga_cond_low_track', max_cond, 0, 0);
    }
    if (!($('#cond_high_off').is(':checked'))) {
        Changed_channel('value_cond_high_abs', 'riga_cond_high_abs', max_cond, 0, 0);
        Changed_channel('value_cond_high_track', 'riga_cond_high_track', max_cond, 0, 0);
    }

   
    if ((alarm_cond_low_abs) || (alarm_cond_low_track) || (alarm_cond_high_abs) || (alarm_cond_high_track)) {
        $('#save_alarm_ldtower_new').next('p').remove();

        $('#save_alarm_ldtower_new').after('<p class="error help-block"><span class="label label-important">' + wrong_settings + '</span></p>');
        submit_status = false;
        error_general = false;
        return false;
    }
    submit_status = true;
    error_general = true;
    notification['confirm'] = modify_plant;
    notification['annulla'] = annulla_impianto;

});
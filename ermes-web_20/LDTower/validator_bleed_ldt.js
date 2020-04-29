var alarm_bleed_setpoint = false;
var alarm_bleed_deadband = false;
var alarm_bleed_time_limit_hr = false;
var alarm_bleed_time_limit_min = false;
var alarm_bleed_delay_hr = false;
var alarm_bleed_delay_min = false;



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
        case "value_bleed_setpoint":
            alarm_bleed_setpoint = var_alarm;
            //check_alarm_flow_time();
            break;
        case "value_bleed_deadband":
            alarm_bleed_deadband = var_alarm;
            //check_alarm_flow_time();
            break;
        case "value_bleed_time_limit_hr":
            alarm_bleed_time_limit_hr = var_alarm;
            //check_alarm_flow_time();
            break;
        case "value_bleed_time_limit_min":
            alarm_bleed_time_limit_min = var_alarm;
            //check_alarm_flow_time();
            break;
        case "value_bleed_delay_hr":
            alarm_bleed_delay_hr = var_alarm;
            //check_alarm_flow_time();
            break;
        case "value_bleed_delay_min":
            alarm_bleed_delay_min = var_alarm;
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
$("#value_bleed_setpoint").keypress(function (evt) {
    return keypress_channel_number(evt);                // controllo che i caratteri siano numeri e non stringhe 
});

$("#value_bleed_deadband").keypress(function (evt) {
    return keypress_channel_number(evt);                // controllo che i caratteri siano numeri e non stringhe 
});

$("#value_bleed_time_limit_hr").keypress(function (evt) {
    return keypress_channel_number(evt);                // controllo che i caratteri siano numeri e non stringhe 
});

$("#value_bleed_time_limit_min").keypress(function (evt) {
    return keypress_channel_number(evt);                // controllo che i caratteri siano numeri e non stringhe 
});

$("#value_bleed_delay_hr").keypress(function (evt) {
    return keypress_channel_number(evt);                // controllo che i caratteri siano numeri e non stringhe 
});

$("#value_bleed_delay_min").keypress(function (evt) {
    return keypress_channel_number(evt);                // controllo che i caratteri siano numeri e non stringhe 
});


$("#value_bleed_setpoint").click(function () {

    $(this).next('p').remove();
    $("#riga_bleed_setpoint").removeClass('error');
    alarm_bleed_setpoint = false;

});

$("#value_bleed_deadband").click(function () {

    $(this).next('p').remove();
    $("#riga_bleed_deadband").removeClass('error');
    alarm_bleed_deadband = false;

});

$("#value_bleed_time_limit_hr").click(function () {

    $(this).next('p').remove();
    $("#riga_bleed_time_limit_hr").removeClass('error');
    alarm_bleed_time_limit_hr = false;

});

$("#value_bleed_time_limit_min").click(function () {

    $(this).next('p').remove();
    $("#riga_bleed_time_limit_min").removeClass('error');
    alarm_bleed_time_limit_min = false;

});

$("#value_bleed_delay_hr").click(function () {

    $(this).next('p').remove();
    $("#riga_bleed_delay_hr").removeClass('error');
    alarm_bleed_delay_hr = false;

});

$("#value_bleed_delay_min").click(function () {

    $(this).next('p').remove();
    $("#riga_bleed_delay_min").removeClass('error');
    alarm_bleed_delay_min = false;

});


//AZIONE DEL CLICK SUL TASTO DI SALVATAGGIO
$("#save_bleed_ldtower_new").click(function () {
    if (enable_send_setpoint == false) {
        result_setpoint_change(user_setpoint_disable);
        return false;
    }

    $('#save_bleed_ldtower_new').next('p').remove();

    Changed_channel('value_bleed_setpoint', 'riga_bleed_setpoint', max_us, 0, 0);
    Changed_channel('value_bleed_deadband', 'riga_bleed_deadband', 999, -999, 0);
    Changed_channel('value_bleed_time_limit_min', 'riga_bleed_time_limit_min', 59, 0, 0);
    Changed_channel('value_bleed_time_limit_hr', 'riga_bleed_time_limit_hr', 99, 0, 0);
    Changed_channel('value_bleed_delay_min', 'riga_bleed_delay_min', 59, 0, 0);
    //Changed_channel('value_bleed_delay_min', 'riga_bleed_delay_min', 59, 0, 0);
    //Changed_channel('value_bleed_delay_hr', 'riga_bleed_delay_hr', 99, 0, 0);


    if ((alarm_bleed_setpoint) || (alarm_bleed_deadband) || (alarm_bleed_time_limit_hr) || (alarm_bleed_time_limit_min) ||
        (alarm_bleed_delay_hr) || (alarm_bleed_delay_min)) {
        $('#save_bleed_ldtower_new').next('p').remove();

        $('#save_bleed_ldtower_new').after('<p class="error help-block"><span class="label label-important">' + wrong_settings + '</span></p>');
        submit_status = false;
        error_general = false;
        return false;
    }
    submit_status = true;
    error_general = true;
    notification['confirm'] = modify_plant;
    notification['annulla'] = annulla_impianto;
});
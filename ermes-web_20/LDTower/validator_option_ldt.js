var alarm_option_tau = false;
var alarm_option_coefficiente_temperatura = false;
var alarm_option_startup_delay = false;
var alarm_option_temperature_ma_h = false;
var alarm_option_temperature_ma_l = false;
var alarm_option_ch1_ma_h = false;
var alarm_option_ch1_ma_l = false;


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
        case "value_option_tau":
            alarm_option_tau = var_alarm;
            check_alarm_option();
            break;
        case "value_option_coefficiente_temperatura":
            alarm_option_coefficiente_temperatura = var_alarm;
            check_alarm_option();
            break;
        case "value_option_startup_delay":
            alarm_option_startup_delay = var_alarm;
            check_alarm_option();
            break;


        case "value_option_temperature_ma_h":
            alarm_option_temperature_ma_h = var_alarm;
            check_alarm_option_ma();
            break;
        case "value_option_temperature_ma_l":
            alarm_temperature_ma_l = var_alarm;
            check_alarm_option_ma();
            break;
        case "value_option_ch1_ma_h":
            alarm_option_ch1_ma_h = var_alarm;
            check_alarm_option_ma();
            break;
        case "value_option_ch1_ma_l":
            alarm_option_ch1_ma_l = var_alarm;
            check_alarm_option_ma();
            break;

    }
}

//-- SE C'E' QUALCHE ERRORE ALLORA IDENTIFICA IL TAB CON IL COLORE ROSSO 

function check_alarm_option() {         
    if ((alarm_option_tau == true) || (alarm_option_coefficiente_temperatura == true) || (alarm_option_startup_delay == true)) {
        $("#tab_tower_sp1").attr('style', 'color:#b94a48');
    }
    else {
        $("#tab_tower_sp1").removeAttr('style');
    }
}
function check_alarm_option_ma() {
    if ((alarm_option_temperature_ma_h == true) || (alarm_option_temperature_ma_l == true) || (alarm_option_ch1_ma_h == true) || (alarm_option_ch1_ma_l == true)) {
        $("#tab_tower_sp2").attr('style', 'color:#b94a48');
    }
    else {
        $("#tab_tower_sp2").removeAttr('style');
    }
}
//----------------------------------------------------------------------------

function keypress_channel_number(evt) {
    var charCode = (evt.which) ? evt.which : event.keyCode

    if (charCode > 31 && (charCode < 48 || charCode > 57))
        return false;
    return true;
}

$("#value_option_tau").keypress(function (evt) {
    return keypress_channel_number(evt);
});
$("#value_option_coefficiente_temperatura").keypress(function (evt) {
    return keypress_channel(evt);
});
$("#value_option_startup_delay").keypress(function (evt) {
    return keypress_channel_number(evt);
});

$("#value_option_temperature_ma_h").keypress(function (evt) {
    return keypress_channel_number(evt);
});
$("#value_option_temperature_ma_l").keypress(function (evt) {
    return keypress_channel_number(evt);
});

$("#value_option_ch1_ma_h").keypress(function (evt) {
    return keypress_channel(evt);
});
$("#value_option_ch1_ma_l").keypress(function (evt) {
    return keypress_channel(evt);
});

function keypress_channel(evt) {
    var charCode = (evt.which) ? evt.which : event.keyCode

    if (charCode == 46) return true;// carattere .
    if (charCode > 31 && (charCode < 48 || charCode > 57))
        return false;

    return true;
}


$("#value_option_tau").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga_option_tau").removeClass('error');
    alarm_option_tau = false;
    check_alarm_option();
    // $("#principale").load("test.aspx");
});
$("#value_option_coefficiente_temperatura").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga_option_coefficiente_temperatura").removeClass('error');
    alarm_option_coefficiente_temperatura = false;
    check_alarm_option();
    // $("#principale").load("test.aspx");
});
$("#value_option_startup_delay").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga_option_startup_delay").removeClass('error');
    alarm_option_startup_delay = false;
    check_alarm_option();
    // $("#principale").load("test.aspx");
});

$("#value_option_temperature_ma_h").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga_option_temperature_ma_h").removeClass('error');
    alarm_option_temperature_ma_h = false;
    check_alarm_option_ma();
    // $("#principale").load("test.aspx");
});
$("#value_option_temperature_ma_l").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga_option_temperature_ma_l").removeClass('error');
    alarm_option_temperature_ma_l = false;
    check_alarm_option_ma();
    // $("#principale").load("test.aspx");
});
$("#value_option_ch1_ma_h").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga_option_ch1_ma_h").removeClass('error');
    alarm_option_ch1_ma_h = false;
    check_alarm_option_ma();
    // $("#principale").load("test.aspx");
});
$("#value_option_ch1_ma_l").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga_option_ch1_ma_l").removeClass('error');
    alarm_option_ch1_ma_l = false;
    check_alarm_option_ma();
    // $("#principale").load("test.aspx");
});
$("#save_option_ldtower_new").click(function () {
    if (enable_send_setpoint == false) {
        result_setpoint_change(user_setpoint_disable);
        return false;
    }

    $('#save_option_ldtower_new').next('p').remove();

    Changed_channel('value_option_tau', 'riga_option_tau', 30, 0, 0);

    Changed_channel('value_option_coefficiente_temperatura', 'riga_option_coefficiente_temperatura', 5, 0, 1);

    Changed_channel('value_option_startup_delay', 'riga_option_startup_delay', 99, 0, 0);

    Changed_channel('value_option_temperature_ma_h', 'riga_option_temperature_ma_h', max_temperature, 0, 0);
    Changed_channel('value_option_temperature_ma_l', 'riga_option_temperature_ma_l', max_temperature, 0, 0);

    Changed_channel('value_option_ch1_ma_h', 'riga_option_ch1_ma_h', max_ch1, 0, 0);
    Changed_channel('value_option_ch1_ma_l', 'riga_option_ch1_ma_l', max_ch1, 0, 0);

    
    check_alarm_option_ma();
    check_alarm_option();
    if ((alarm_option_tau) || (alarm_option_coefficiente_temperatura) || (alarm_option_startup_delay)  ||
        (alarm_option_temperature_ma_h) || (alarm_option_temperature_ma_l) || (alarm_option_ch1_ma_h) || (alarm_option_ch1_ma_l)) {
        $('#save_option_ldtower_new').next('p').remove();

        $('#save_option_ldtower_new').after('<p class="error help-block"><span class="label label-important">' + wrong_settings + '</span></p>');
        submit_status = false;
        error_general = false;
        return false;
    }
    submit_status = true;
    error_general = true;
    notification['confirm'] = modify_plant;
    notification['annulla'] = annulla_impianto;
});
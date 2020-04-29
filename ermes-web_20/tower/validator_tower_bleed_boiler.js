var alarm_bleed_setpoint = false;
var alarm_bleed_deadband = false;
var alarm_time_limit_hr = false;
var alarm_time_limit_min = false;
var alarm_bleed_delay_hr = false;
var alarm_bleed_delay_min = false;


var alarm_value_valve_open_time_timed = false;
var alarm_value_sample_timed = false;
var alarm_value_valve_open_time_sample = false;
var alarm_value_sample_sample = false;
var alarm_value_hold_sample = false;
var alarm_value_blowdown_sample = false;

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
        case "value_time_limit_hr":
            alarm_time_limit_hr = var_alarm;
            //check_alarm_flow_time();
            break;
        case "value_time_limit_min":
            alarm_time_limit_min = var_alarm;
            //check_alarm_flow_time();
            break;
        case "value_water_meter_hr":
            alarm_water_meter_hr = var_alarm;
            //check_alarm_flow_time();
            break;
        case "value_bleed_delay_hr":
            alarm_bleed_delay_hr = var_alarm;
            //alert(var_alarm);

            //check_alarm_flow_time();
            break;
        case "value_bleed_delay_min":
            alarm_bleed_delay_min = var_alarm;
            //alert(var_alarm);
            //check_alarm_flow_time();
            break;

        case "value_valve_open_time_timed":
            alarm_value_valve_open_time_timed = var_alarm;
            break;
        case "value_sample_timed":
            alarm_value_sample_timed = var_alarm;
            break;
        case "value_valve_open_time_sample":
            alarm_value_valve_open_time_sample = var_alarm;
            break;
        case "value_sample_sample":
            alarm_value_sample_sample = var_alarm;
            break;
        case "value_hold_sample":
            alarm_value_hold_sample = var_alarm;
            break;
        case "value_blowdown_sample":
            alarm_value_blowdown_sample = var_alarm;
            break;

    }
}

function keypress_channel_number(evt) {
    var charCode = (evt.which) ? evt.which : event.keyCode


    if (charCode > 31 && (charCode < 48 || charCode > 57))
        return false;

    return true;

}
function keypress_channel_number_neg(evt) {
    var charCode = (evt.which) ? evt.which : event.keyCode

    if (charCode == 45) return true;// carattere -
    if (charCode > 31 && (charCode < 48 || charCode > 57))
        return false;

    return true;

}


$("#value_bleed_setpoint").keypress(function (evt) {
    return keypress_channel_number(evt);
});
$("#value_bleed_deadband").keypress(function (evt) {
    return keypress_channel_number_neg(evt);
});

$("#value_time_limit_hr").keypress(function (evt) {
    return keypress_channel_number(evt);
});
$("#value_time_limit_min").keypress(function (evt) {
    return keypress_channel_number(evt);
});

$("#value_bleed_delay_hr").keypress(function (evt) {
    return keypress_channel_number(evt);
});
$("#value_bleed_delay_min").keypress(function (evt) {
    return keypress_channel_number(evt);
});

$("#value_valve_open_time_timed").keypress(function (evt) {
    return keypress_channel_number(evt);
});
$("#value_sample_timed").keypress(function (evt) {
    return keypress_channel_number(evt);
});
$("#value_valve_open_time_sample").keypress(function (evt) {
    return keypress_channel_number(evt);
});
$("#value_sample_sample").keypress(function (evt) {
    return keypress_channel_number(evt);
});
$("#value_hold_sample").keypress(function (evt) {
    return keypress_channel_number(evt);
});
$("#value_blowdown_sample").keypress(function (evt) {
    return keypress_channel_number(evt);
});



$("#value_bleed_setpoint").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga_bleed_setpoint").removeClass('error');
    alarm_bleed_setpoint = false;

    // $("#principale").load("test.aspx");
});
$("#value_bleed_deadband").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga_bleed_deadband").removeClass('error');
    alarm_bleed_deadband = false;
    // $("#principale").load("test.aspx");
});

$("#value_bleed_time_limit_hr").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga_bleed_time_limit_hr").removeClass('error');
    alarm_bleed_time_limit_hr = false;

    // $("#principale").load("test.aspx");
});
$("#value_bleed_time_limit_min").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga_bleed_time_limit_min").removeClass('error');
    alarm_bleed_time_limit_min = false;
    // $("#principale").load("test.aspx");
});
$("#value_bleed_delay_hr").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga_bleed_delay_hr").removeClass('error');
    alarm_bleed_delay_hr = false;

    // $("#principale").load("test.aspx");
});
$("#value_bleed_delay_min").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga_bleed_delay_min").removeClass('error');
    alarm_bleed_delay_min = false;
    // $("#principale").load("test.aspx");
});
$("#value_valve_open_time_timed").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga_valve_open_time_timed").removeClass('error');
    alarm_value_valve_open_time_timed = false;
    // $("#principale").load("test.aspx");
});
$("#value_sample_timed").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga_sample_timed").removeClass('error');
    alarm_value_sample_timed = false;
    // $("#principale").load("test.aspx");
});
$("#value_valve_open_time_sample").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga_valve_open_time_sample").removeClass('error');
    alarm_value_valve_open_time_sample = false;
    // $("#principale").load("test.aspx");
});
$("#value_sample_sample").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga_sample_sample").removeClass('error');
    alarm_value_sample_sample = false;
    // $("#principale").load("test.aspx");
});
$("#value_hold_sample").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga_hold_sample").removeClass('error');
    alarm_value_hold_sample = false;
    // $("#principale").load("test.aspx");
});
$("#value_blowdown_sample").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga_blowdown_sample").removeClass('error');
    alarm_value_blowdown_sample = false;
    // $("#principale").load("test.aspx");
});



$("#save_bleedtower_new").click(function () {
    if (enable_send_setpoint == false) {
        result_setpoint_change(user_setpoint_disable);
        return false;
    }

    $('#save_bleedtower_new').next('p').remove();

    Changed_channel('value_bleed_setpoint', 'riga_bleed_setpoint', max_us, 0, 0);
    Changed_channel('value_bleed_deadband', 'riga_bleed_deadband', 999, -999, 0);
    Changed_channel('value_bleed_time_limit_min', 'riga_bleed_time_limit_min', 59, 0, 0);
    Changed_channel('value_bleed_time_limit_hr', 'riga_bleed_time_limit_hr', 99, 0, 0);
    //Changed_channel('value_bleed_delay_min', 'riga_bleed_delay_min', 59, 0, 0);
    //Changed_channel('value_bleed_delay_hr', 'riga_bleed_delay_hr', 99, 0, 0);
    if (!($('#id_timed').is(':checked'))) {
        Changed_channel('value_valve_open_time_timed', 'riga_valve_open_time_timed', 999, 0, 0);
        Changed_channel('value_sample_timed', 'riga_sample_timed', 99, 0, 0);
    }
    if (!($('#id_sample_hold').is(':checked'))) {
        Changed_channel('value_valve_open_time_sample', 'riga_valve_open_time_sample', 999, 0, 0);
        Changed_channel('value_sample_sample', 'riga_sample_sample', 99, 0, 0);
        Changed_channel('value_hold_sample', 'riga_hold_sample', 999, 0, 0);
        Changed_channel('value_blowdown_sample', 'riga_blowdown_sample', 999, 0, 0);
    }

    if ((alarm_bleed_setpoint) || (alarm_bleed_deadband) || (alarm_time_limit_hr) || (alarm_time_limit_min) ||
        (alarm_bleed_delay_hr) || (alarm_bleed_delay_min)||
        (alarm_value_valve_open_time_timed)||(alarm_value_sample_timed)||(alarm_value_valve_open_time_sample)||
        (alarm_value_sample_sample)||(alarm_value_hold_sample)||(alarm_value_blowdown_sample)
        ) {

        $('#save_bleedtower_new').next('p').remove();

        $('#save_bleedtower_new').after('<p class="error help-block"><span class="label label-important">' + wrong_settings + '</span></p>');
        submit_status = false;
        error_general = false;
        return false;
    }
    submit_status = true;
    error_general = true;
    notification['confirm'] = modify_plant;
    notification['annulla'] = annulla_impianto;
});

function enable_working_mode(indice) {


    $(this).next('p').remove();
    $("#riga_valve_open_time_timed").removeClass('error');
    alarm_value_valve_open_time_timed = false;
    $(this).next('p').remove();
    $("#riga_sample_timed").removeClass('error');
    alarm_value_sample_timed = false;
    $(this).next('p').remove();
    $("#riga_valve_open_time_sample").removeClass('error');
    alarm_value_valve_open_time_sample = false;
    $(this).next('p').remove();
    $("#riga_sample_sample").removeClass('error');
    alarm_value_sample_sample = false;
    $(this).next('p').remove();
    $("#riga_hold_sample").removeClass('error');
    alarm_value_hold_sample = false;
    $(this).next('p').remove();
    $("#riga_blowdown_sample").removeClass('error');
    alarm_value_blowdown_sample = false;

    switch (indice) {
        case 1:// continuopus
            $("#id_timed").hide();
            $("#id_sample_hold").hide();
            break;
        case 2:// timed
            $("#id_timed").show();
            $("#id_sample_hold").hide();

            break;
        case 3:// sample hold
            $("#id_timed").hide();
            $("#id_sample_hold").show();

            break;
    }
}
$("#continuous").click(function () {
    enable_working_mode(1);
});
$("#timed").click(function () {
    enable_working_mode(2);
});
$("#sample_hold").click(function () {
    enable_working_mode(3);
});

var alarm_ch1_low = false;
var alarm_ch1_high = false;
var alarm_ch2_high = false;
var alarm_ch2_low = false;
var alarm_ch3_high = false;
var alarm_ch3_low = false;
var alarm_water_meter_input_hr = false;
var alarm_water_meter_input_min = false;
var alarm_water_meter_bleed_hr = false;
var alarm_water_meter_bleed_min = false;
var alarm_concentration_factor_ratio = false; 
var alarm_concentration_factor_tolerance = false;
var alarm_concentration_factor_Delay = false;

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

        case "value_ch1_low":
            alarm_ch1_low = var_alarm;
            check_alarm_alarm1();
            break;
        case "value_ch1_high":
            alarm_ch1_high = var_alarm;
            check_alarm_alarm1();
            break;
        case "value_ch2_low":
            alarm_ch2_low = var_alarm;
            check_alarm_alarm1();
            break;
        case "value_ch2_high":
            alarm_ch2_high = var_alarm;
            check_alarm_alarm1();
            break;


        case "value_water_meter_input_hr":
            alarm_water_meter_input_hr = var_alarm;
            check_alarm_alarm2();
            break;
        case "value_water_meter_input_min":
            alarm_water_meter_input_min = var_alarm;
            check_alarm_alarm2();
            break;
        case "value_water_meter_bleed_hr":
            alarm_water_meter_bleed_hr = var_alarm;
            check_alarm_alarm2();
            break;
        case "value_water_meter_bleed_min":
            alarm_water_meter_bleed_min = var_alarm;
            check_alarm_alarm2();
            break;
        case "value_concentration_factor_ratio":
            alarm_concentration_factor_ratio = var_alarm;
            check_alarm_alarm2();
            break;
        case "value_concentration_factor_tolerance":
            alarm_concentration_factor_tolerance = var_alarm;
            check_alarm_alarm2();
            break;
        case "value_concentration_factor_Delay":
            alarm_concentration_factor_Delay = var_alarm;
            check_alarm_alarm2();
            break;

            
            
            
    }
}
function check_alarm_alarm1() {
    if ((alarm_ch1_low == true) || (alarm_ch1_high == true) || (alarm_ch2_high == true) || (alarm_ch2_low == true) || (alarm_ch3_high == true) ||
        (alarm_ch3_low == true) ) {
        $("#tab_tower_sp1").attr('style', 'color:#b94a48');
    }
    else {
        $("#tab_tower_sp1").removeAttr('style');
    }
}
function check_alarm_alarm2() {
    if ((alarm_water_meter_input_hr == true) || (alarm_water_meter_input_min == true) || (alarm_water_meter_bleed_hr == true) ||
        (alarm_water_meter_bleed_min == true) || (alarm_concentration_factor_ratio == true) ||
        (alarm_concentration_factor_tolerance == true) || (alarm_concentration_factor_Delay == true)) {
        $("#tab_tower_sp2").attr('style', 'color:#b94a48');
    }
    else {
        $("#tab_tower_sp2").removeAttr('style');
    }
}
function enable_ch1_low() {
    $("#riga_ch1_low").show();
}
function disable_ch1_low() {
    $("#riga_ch1_low").hide();
}
function enable_ch1_high() {
    $("#riga_ch1_high").show();
}
function disable_ch1_high() {
    $("#riga_ch1_high").hide();
}

function enable_ch2_low() {
    $("#riga_ch2_low").show();
}
function disable_ch2_low() {
    $("#riga_ch2_low").hide();
}
function enable_ch2_high() {
    $("#riga_ch2_high").show();
}
function disable_ch2_high() {
    $("#riga_ch2_high").hide();
}

function enable_ch3_low() {
    $("#riga_ch3_low").show();
}
function disable_ch3_low() {
    $("#riga_ch3_low").hide();
}
function enable_ch3_high() {
    $("#riga_ch3_high").show();
}
function disable_ch3_high() {
    $("#riga_ch3_high").hide();
}
$("#ch1_low_off").click(function () {
    alarm_ch1_low = false;
    disable_ch1_low();
});
$("#ch1_low_track").click(function () {
    enable_ch1_low();
});
$("#ch1_low_absolute").click(function () {
    enable_ch1_low();
});
$("#ch1_high_off").click(function () {
    alarm_ch1_high = false;
    disable_ch1_high();
});
$("#ch1_high_track").click(function () {
    enable_ch1_high();
});
$("#ch1_high_absolute").click(function () {
    enable_ch1_high();
});

$("#ch2_low_off").click(function () {
    alarm_ch2_low = false;
    disable_ch2_low();
});
$("#ch2_low_track").click(function () {
    enable_ch2_low();
});
$("#ch2_low_absolute").click(function () {
    enable_ch2_low();
});
$("#ch2_high_off").click(function () {
    alarm_ch2_high = false;
    disable_ch2_high();
});
$("#ch2_high_track").click(function () {
    enable_ch2_high();
});
$("#ch2_high_absolute").click(function () {
    enable_ch2_high();
});

$("#ch3_low_off").click(function () {
    alarm_ch3_low = false;
    disable_ch3_low();
});
$("#ch3_low_track").click(function () {
    enable_ch3_low();
});
$("#ch3_low_absolute").click(function () {
    enable_ch3_low();
});
$("#ch3_high_off").click(function () {
    alarm_ch3_high = false;
    disable_ch3_high();
});
$("#ch3_high_track").click(function () {
    enable_ch3_high();
});
$("#ch3_high_absolute").click(function () {
    enable_ch3_high();
});
function keypress_channel(evt) {
    var charCode = (evt.which) ? evt.which : event.keyCode

    if (charCode == 46) return true;// carattere .
    if (charCode > 31 && (charCode < 48 || charCode > 57))
        return false;

    return true;

}
function keypress_channel_num(evt) {
    var charCode = (evt.which) ? evt.which : event.keyCode

    if (charCode > 31 && (charCode < 48 || charCode > 57))
        return false;

    return true;

}

$("#value_ch1_low").keypress(function (evt) {
    return keypress_channel(evt);
});
$("#value_ch1_high").keypress(function (evt) {
    return keypress_channel(evt);
});

$("#value_ch2_low").keypress(function (evt) {
    return keypress_channel(evt);
});
$("#value_ch2_high").keypress(function (evt) {
    return keypress_channel(evt);
});

$("#value_ch3_low").keypress(function (evt) {
    return keypress_channel(evt);
});
$("#value_ch3_high").keypress(function (evt) {
    return keypress_channel(evt);
});

$("#value_water_meter_input_hr").keypress(function (evt) {
    return keypress_channel_num(evt);
});
$("#value_water_meter_input_min").keypress(function (evt) {
    return keypress_channel_num(evt);
});
$("#value_water_meter_bleed_hr").keypress(function (evt) {
    return keypress_channel_num(evt);
});
$("#value_water_meter_bleed_min").keypress(function (evt) {
    return keypress_channel_num(evt);
});
$("#value_concentration_factor_ratio").keypress(function (evt) {
    return keypress_channel(evt);
});

$("#value_concentration_factor_tolerance").keypress(function (evt) {
    return keypress_channel_num(evt);
});
$("#value_concentration_factor_Delay").keypress(function (evt) {
    return keypress_channel_num(evt);
});

$("#value_ch1_low").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga_ch1_low").removeClass('error');
    alarm_ch1_low = false;
    check_alarm_alarm1();
    // $("#principale").load("test.aspx");
});
$("#value_ch1_high").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga_ch1_high").removeClass('error');
    alarm_ch1_high = false;
    check_alarm_alarm1();
    // $("#principale").load("test.aspx");
});

$("#value_ch2_low").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga_ch2_low").removeClass('error');
    alarm_ch2_low = false;
    check_alarm_alarm1();
    // $("#principale").load("test.aspx");
});
$("#value_ch2_high").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga_ch2_high").removeClass('error');
    alarm_ch2_high = false;
    check_alarm_alarm1();
    // $("#principale").load("test.aspx");
});

$("#value_ch3_low").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga_ch3_low").removeClass('error');
    alarm_ch3_low = false;
    check_alarm_alarm1();
    // $("#principale").load("test.aspx");
});
$("#value_ch3_high").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga_ch3_high").removeClass('error');
    alarm_ch3_high = false;
    check_alarm_alarm1();
    // $("#principale").load("test.aspx");
});

$("#value_water_meter_input_hr").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga_water_meter_input_hr").removeClass('error');
    alarm_water_meter_input_hr = false;
    check_alarm_alarm2();
    // $("#principale").load("test.aspx");
});
$("#value_water_meter_input_min").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga_water_meter_input_min").removeClass('error');
    alarm_water_meter_input_min = false;
    check_alarm_alarm2();
    // $("#principale").load("test.aspx");
});
$("#value_water_meter_bleed_hr").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga_water_meter_bleed_hr").removeClass('error');
    alarm_water_meter_bleed_hr = false;
    check_alarm_alarm2();
    // $("#principale").load("test.aspx");
});
$("#value_water_meter_bleed_min").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga_water_meter_bleed_min").removeClass('error');
    alarm_water_meter_bleed_min = false;
    check_alarm_alarm2();
    // $("#principale").load("test.aspx");
});
$("#value_concentration_factor_ratio").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga_concentration_factor_ratio").removeClass('error');
    alarm_concentration_factor_ratio = false;
    check_alarm_alarm2();
    // $("#principale").load("test.aspx");
});
$("#value_concentration_factor_tolerance").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga_concentration_factor_tolerance").removeClass('error');
    alarm_concentration_factor_tolerance = false;
    check_alarm_alarm2();
    // $("#principale").load("test.aspx");
});
$("#value_concentration_factor_Delay").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga_concentration_factor_Delay").removeClass('error');
    alarm_concentration_factor_Delay = false;
    check_alarm_alarm2();
    // $("#principale").load("test.aspx");
});

$("#save_alarmtower_new").click(function () {
    if (enable_send_setpoint == false) {
        result_setpoint_change(user_setpoint_disable);
        return false;
    }

    $('#save_alarmtower_new').next('p').remove();
    if ($("#ch1_low_off").length > 0) {
        if (!($('#ch1_low_off').is(':checked'))) {
            Changed_channel('value_ch1_low', 'riga_ch1_low', max_ch1, 0, 0);
        }
    }
    if ($("#ch1_high_off").length > 0) {
        if (!($('#ch1_high_off').is(':checked'))) {
            Changed_channel('value_ch1_high', 'riga_ch1_high', max_ch1, 0, 0);
        }
    }
    if ($("#ch2_low_off").length > 0) {

        if (!($('#ch2_low_off').is(':checked'))) {
            
            Changed_channel('value_ch2_low', 'riga_ch2_low', max_ch2, min_ch2, ch2_fix);
        }
    }
    if ($("#ch2_high_off").length > 0) {
        if (!($('#ch2_high_off').is(':checked'))) {
            
            Changed_channel('value_ch2_high', 'riga_ch2_high', max_ch2, min_ch2, ch2_fix);
        }
    }
    if ($("#ch3_low_off").length > 0) {
        if (!($('#ch3_low_off').is(':checked'))) {
            Changed_channel('value_ch3_low', 'riga_ch3_low', max_ch3, min_ch3, ch3_fix);
        }
    }
    if ($("#ch3_high_off").length > 0) {
        if (!($('#ch3_high_off').is(':checked'))) {
            Changed_channel('value_ch3_high', 'riga_ch3_high', max_ch3, min_ch3, ch3_fix);
        }
    }
     if (new_version == '1') {
         Changed_channel('value_water_meter_input_hr', 'riga_water_meter_input_hr', 9, 0, 0);
         Changed_channel('value_water_meter_input_min', 'riga_water_meter_input_min', 59, 0, 0);
         Changed_channel('value_water_meter_bleed_hr', 'riga_water_meter_bleed_hr', 9, 0, 0);
         Changed_channel('value_water_meter_bleed_min', 'riga_water_meter_bleed_min', 59, 0, 0);
         Changed_channel('value_concentration_factor_ratio', 'riga_concentration_factor_ratio', 10, 0, 1);
         Changed_channel('value_concentration_factor_tolerance', 'riga_concentration_factor_tolerance', 10, 0, 0);
         Changed_channel('value_concentration_factor_Delay', 'riga_concentration_factor_delay', 60, 0, 0);
     }


     if ((alarm_ch1_low) || (alarm_ch1_high) || (alarm_ch2_high) || (alarm_ch2_low) ||
        (alarm_ch3_high) || (alarm_ch3_low)|(alarm_water_meter_input_hr)||(alarm_water_meter_input_min)||(alarm_water_meter_bleed_hr)||
        (alarm_water_meter_bleed_min)||(alarm_concentration_factor_ratio)||(alarm_concentration_factor_tolerance)||(alarm_concentration_factor_Delay)) {
        $('#save_alarmtower_new').next('p').remove();

        $('#save_alarmtower_new').after('<p class="error help-block"><span class="label label-important">' + wrong_settings + '</span></p>');
        submit_status = false;
        error_general = false;
        return false;
    }
    submit_status = true;
    error_general = true;
    notification['confirm'] = modify_plant;
    notification['annulla'] = annulla_impianto;
});

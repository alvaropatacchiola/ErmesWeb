var alarm_feed_bleed_percent = false;
var alarm_feed_time_percent_hr = false;
var alarm_feed_time_percent_min = false;
var alarm_feed_time_percent_percent = false;
var alarm_water_meter_hr = false;
var alarm_water_meter_min = false;
var alarm_water_meter_counter = false;
var alarm_water_meter_ppm_ppm = false;
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
        case "value_feed_bleed_percent":
            alarm_feed_bleed_percent = var_alarm;
            //check_alarm_flow_time();
            break;
        case "value_feed_time_percent_hr":
            alarm_feed_time_percent_hr = var_alarm;
            //check_alarm_flow_time();
            break;
        case "value_feed_time_percent_min":
            alarm_feed_time_percent_min = var_alarm;
            //check_alarm_flow_time();
            break;
        case "value_feed_time_percent_percent":
            alarm_feed_time_percent_percent = var_alarm;
            //check_alarm_flow_time();
            break;
        case "value_water_meter_hr":
            alarm_water_meter_hr = var_alarm;
            //check_alarm_flow_time();
            break;
        case "value_water_meter_min":
            alarm_water_meter_min = var_alarm;
            //check_alarm_flow_time();
            break;
        case "value_water_meter_counter":
            alarm_water_meter_counter = var_alarm;
            //check_alarm_flow_time();
            break;
        case "value_water_meter_ppm_ppm":
            alarm_water_meter_ppm_ppm = var_alarm;
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
$("#value_feed_bleed_percent").keypress(function (evt) {
    return keypress_channel_number(evt);
});
$("#value_feed_time_percent_hr").keypress(function (evt) {
    return keypress_channel_number(evt);
});
$("#value_feed_time_percent_min").keypress(function (evt) {
    return keypress_channel_number(evt);
});
$("#value_feed_time_percent_percent").keypress(function (evt) {
    return keypress_channel_number(evt);
});
$("#value_water_meter_hr").keypress(function (evt) {
    return keypress_channel_number(evt);
});
$("#value_water_meter_min").keypress(function (evt) {
    return keypress_channel_number(evt);
});
$("#value_water_meter_counter").keypress(function (evt) {
    return keypress_channel_number(evt);
});
$("#value_water_meter_ppm_ppm").keypress(function (evt) {
    return keypress_channel_number(evt);
});
$("#value_water_meter_ppm_percent").keypress(function (evt) {
    return keypress_channel_number(evt);
});
$("#value_water_meter_ppm_cc_st").keypress(function (evt) {
    return keypress_channel(evt);
});
$("#value_water_meter_ppm_l_h").keypress(function (evt) {
    return keypress_channel_number(evt);
});
$("#value_feed_bleed_percent").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga_feed_bleed_percent").removeClass('error');
    alarm_feed_bleed_percent = false;

    // $("#principale").load("test.aspx");
});
$("#value_feed_time_percent_hr").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga_feed_time_percent_hr").removeClass('error');
    alarm_feed_time_percent_hr = false;
    // $("#principale").load("test.aspx");
});
$("#value_feed_time_percent_min").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga_feed_time_percent_min").removeClass('error');
    alarm_feed_time_percent_min = false;
    // $("#principale").load("test.aspx");
});

$("#value_feed_time_percent_percent").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga_feed_time_percent_percent").removeClass('error');
    alarm_feed_time_percent_percent = false;
    // $("#principale").load("test.aspx");
});

$("#value_water_meter_hr").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga_water_meter_hr").removeClass('error');
    alarm_water_meter_hr = false;
    // $("#principale").load("test.aspx");
});
$("#value_water_meter_min").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga_water_meter_min").removeClass('error');
    alarm_water_meter_min = false;
    // $("#principale").load("test.aspx");
});
$("#value_water_meter_counter").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga_water_meter_counter").removeClass('error');
    alarm_water_meter_counter = false;
    // $("#principale").load("test.aspx");
});
$("#value_water_meter_ppm_ppm").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga_water_meter_ppm_ppm").removeClass('error');
    alarm_water_meter_ppm_ppm = false;
    // $("#principale").load("test.aspx");
});
$("#value_water_meter_ppm_percent").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga_water_meter_ppm_percent").removeClass('error');
    alarm_water_meter_ppm_percent = false;
    // $("#principale").load("test.aspx");
});
$("#value_water_meter_ppm_cc_st").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga_water_meter_ppm_cc_st").removeClass('error');
    alarm_water_meter_ppm_cc_st = false;
    // $("#principale").load("test.aspx");
});
$("#value_water_meter_ppm_l_h").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga_water_meter_ppm_l_h").removeClass('error');
    alarm_water_meter_ppm_l_h = false;
    // $("#principale").load("test.aspx");
});


function reset_variable() {
    alarm_feed_bleed_percent = false;
    alarm_feed_time_percent_hr = false;
    alarm_feed_time_percent_min = false;
    alarm_feed_time_percent_percent = false;
    alarm_water_meter_hr = false;
    alarm_water_meter_min = false;
    alarm_water_meter_counter = false;
    alarm_water_meter_ppm_ppm = false;
    alarm_water_meter_ppm_percent = false;
    alarm_water_meter_ppm_cc_st = false;
    alarm_water_meter_ppm_l_h = false;

}
function enable_bleed() {
    $("#enable_value_feed_bleed_percent").hide();
    $("#enable_value_feed_time_percent").hide();
    $("#enable_value_water_meter").hide();
    $("#enable_value_water_meter_ppm").hide();
    reset_variable();
}
function enable_feed_bleed_percent() {
    $("#enable_value_feed_bleed_percent").show();
    $("#enable_value_feed_time_percent").hide();
    $("#enable_value_water_meter").hide();
    $("#enable_value_water_meter_ppm").hide();
    reset_variable();
}
function enable_feed_time_percent() {
    $("#enable_value_feed_bleed_percent").hide();
    $("#enable_value_feed_time_percent").show();
    $("#enable_value_water_meter").hide();
    $("#enable_value_water_meter_ppm").hide();
    reset_variable();
}
function enable_water_meter() {
    $("#enable_value_feed_bleed_percent").hide();
    $("#enable_value_feed_time_percent").hide();
    $("#enable_value_water_meter").show();
    $("#enable_value_water_meter_ppm").hide();
    reset_variable();
}
function enable_water_meter_ppm() {
    $("#enable_value_feed_bleed_percent").hide();
    $("#enable_value_feed_time_percent").hide();
    $("#enable_value_water_meter").hide();
    $("#enable_value_water_meter_ppm").show();
    if (($('#enable_water_meter_ppm_l_h').is(':checked'))) {
        $("#div_enable_water_meter_ppm_cc_st").hide();
        $("#div_enable_water_meter_ppm_l_h").show();
    }
    else
    {
        $("#div_enable_water_meter_ppm_cc_st").show();
        $("#div_enable_water_meter_ppm_l_h").hide();
    }
    reset_variable();
}
$("#enable_water_meter_ppm_l_h").click(function () {
    $("#div_enable_water_meter_ppm_cc_st").hide();
    $("#div_enable_water_meter_ppm_l_h").show();

});
$("#enable_water_meter_ppm_cc_st").click(function () {
    $("#div_enable_water_meter_ppm_cc_st").show();
    $("#div_enable_water_meter_ppm_l_h").hide();

});

$("#enable_feed_bleed").click(function () {
    enable_bleed();
});

$("#enable_feed_bleed_percent").click(function () {
    enable_feed_bleed_percent();
});
$("#enable_feed_time_percent").click(function () {
    enable_feed_time_percent();
});

$("#enable_water_meter").click(function () {
    enable_water_meter();
});
$("#enable_water_meter_ppm").click(function () {
    enable_water_meter_ppm();
});
$("#save_inhibitortower_new").click(function () {
    if (enable_send_setpoint == false) {
        result_setpoint_change(user_setpoint_disable);
        return false;
    }

    $('#save_inhibitortower_new').next('p').remove();
    
    if (($('#enable_feed_bleed').is(':checked'))) {
        //Changed_channel('value_alarm_flow_time', 'riga1_alarm_flow_time', 99, 0, 0);
    }
    if (($('#enable_feed_bleed_percent').is(':checked'))) {
        Changed_channel('value_feed_bleed_percent', 'riga_feed_bleed_percent', 100, 0, 0);

        //Changed_channel('value_alarm_flow_time', 'riga1_alarm_flow_time', 99, 0, 0);
    }
    if (($('#enable_feed_time_percent').is(':checked'))) {
        Changed_channel('value_feed_time_percent_hr', 'riga_feed_time_percent_hr', 99, 0, 0);
        Changed_channel('value_feed_time_percent_min', 'riga_feed_time_percent_min', 59, 0, 0);
        Changed_channel('value_feed_time_percent_percent', 'riga_feed_time_percent_percent', 100, 0, 0);
    }
    if (($('#enable_water_meter').is(':checked'))) {
        Changed_channel('value_water_meter_hr', 'riga_water_meter_hr', 99, 0, 0);
        Changed_channel('value_water_meter_min', 'riga_water_meter_min', 59, 0, 0);
        Changed_channel('value_water_meter_counter', 'riga_water_meter_counter', 9999, 0, 0);
    }
    if (($('#enable_water_meter_ppm').is(':checked'))) {
        //alert("qui");
        Changed_channel('value_water_meter_ppm_ppm', 'riga_water_meter_ppm_ppm', max_us, 0, 0);
        Changed_channel('value_water_meter_ppm_percent', 'riga_water_meter_ppm_percent', 100, 0, 0);
        
        if (($('#enable_water_meter_ppm_cc_st').is(':checked'))) {
            
            Changed_channel('value_water_meter_ppm_cc_st', 'riga_water_meter_ppm_cc_st', 30, 0, 2);
        }
        if (($('#enable_water_meter_ppm_l_h').is(':checked'))) {
            Changed_channel('value_water_meter_ppm_l_h', 'riga_water_meter_ppm_l_h', 999, 0, 0);
        }
    }
    if ((alarm_feed_bleed_percent)||(alarm_feed_time_percent_hr)||(alarm_feed_time_percent_min)||(alarm_feed_time_percent_percent)||
        (alarm_water_meter_hr)||(alarm_water_meter_min)||(alarm_water_meter_counter)||(alarm_water_meter_ppm_ppm)||
        (alarm_water_meter_ppm_percent)||(alarm_water_meter_ppm_cc_st)||(alarm_water_meter_ppm_l_h)) {
        $('#save_inhibitortower_new').next('p').remove();

        $('#save_inhibitortower_new').after('<p class="error help-block"><span class="label label-important">' + wrong_settings + '</span></p>');
        submit_status = false;
        error_general = false;
        return false;
    }
    submit_status = true;
    error_general = true;
    notification['confirm'] = modify_plant;
    notification['annulla'] = annulla_impianto;
});
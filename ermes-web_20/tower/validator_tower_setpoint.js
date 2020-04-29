var alarm_setpoint_on = false;
var alarm_setpoint_on_percent = false;
var alarm_setpoint_off = false;
var alarm_setpoint_off_percent = false;
var alarm_setpoint_p1_1 = false;
var alarm_setpoint_p1_1_pm = false;
var alarm_setpoint_p1_2 = false;
var alarm_setpoint_p1_2_pm = false;

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
        case "value_setpoint_on":
            alarm_setpoint_on = var_alarm;
            //check_alarm_flow_time();
            break;
        case "value_setpoint_on_percent":
            alarm_setpoint_on_percent = var_alarm;
            //check_alarm_flow_time();
            break;
        case "value_setpoint_off":
            alarm_setpoint_off = var_alarm;
            //check_alarm_flow_time();
            break;
        case "value_setpoint_off_percent":
            alarm_setpoint_off_percent = var_alarm;
            //check_alarm_flow_time();
            break;
        case "value_setpoint_p1_1":
            alarm_setpoint_p1_1 = var_alarm;
            //check_alarm_flow_time();
            break;
        case "valuesetpoint_p1_1_pm":
            alarm_setpoint_p1_1_pm = var_alarm;
            //check_alarm_flow_time();
            break;
        case "value_setpoint_p1_2":
            alarm_setpoint_p1_2 = var_alarm;
            //check_alarm_flow_time();
            break;
        case "value_setpoint_p1_2_pm":
            alarm_setpoint_p1_2_pm = var_alarm;
            //check_alarm_flow_time();
            break;

    }
}
function keypress_channel(evt) {
    var charCode = (evt.which) ? evt.which : event.keyCode

    if (charCode == 46) return true;// carattere .
    if (charCode > 31 && (charCode < 48 || charCode > 57))
        return false;

    return true;

}
function keypress_perc(evt) {
    var charCode = (evt.which) ? evt.which : event.keyCode
    if (charCode > 31 && (charCode < 48 || charCode > 57))
        return false;

    return true;
}
$("#value_setpoint_on_percent").keypress(function (evt) {
    return keypress_perc(evt);
});
$("#value_setpoint_off_percent").keypress(function (evt) {
    return keypress_perc(evt);
});
$("#value_setpoint_p1_1_pm").keypress(function (evt) {
    return keypress_perc(evt);
});
$("#value_setpoint_p1_2_pm").keypress(function (evt) {
    return keypress_perc(evt);
});

$("#value_setpoint_on").keypress(function (evt) {
    return keypress_channel(evt);
});
$("#value_setpoint_off").keypress(function (evt) {
    return keypress_channel(evt);
});
$("#value_setpoint_p1_1").keypress(function (evt) {
    return keypress_channel(evt);
});
$("#value_setpoint_p1_2").keypress(function (evt) {
    return keypress_channel(evt);
});


function disable_sepoint_on_off() {
    alarm_setpoint_on = false;
    alarm_setpoint_on_percent = false;
    alarm_setpoint_off = false;
    alarm_setpoint_off_percent = false;

    remove_allarme('value_setpoint_on_percent', 'riga_setpoint_on_percent');
    remove_allarme('value_setpoint_off_percent', 'riga_setpoint_off_percent');
    remove_allarme('value_setpoint_on', 'riga_setpoint_on');
    remove_allarme('value_setpoint_off', 'riga_setpoint_off');

    $("#enable_digital").hide();
}
function enable_sepoint_on_off() {
    $("#enable_digital").show();
    $("#riga_setpoint_on_percent").hide();
    $("#riga_setpoint_off_percent").hide();

    $("#label_on").show();
    $("#label_on_pwm").hide();
    $("#label_off").show();
    $("#label_off_pwm").hide();
    alarm_setpoint_on_percent = false;
    alarm_setpoint_off_percent = false;
    remove_allarme('value_setpoint_off_percent', 'riga_setpoint_off_percent');
    remove_allarme('value_setpoint_on_percent', 'riga_setpoint_on_percent');
}
function enable_sepoint_pwm() {
    $("#enable_digital").show();
    $("#riga_setpoint_on_percent").show();
    $("#riga_setpoint_off_percent").show();

    $("#label_on").hide();
    $("#label_on_pwm").show();
    $("#label_off").hide();
    $("#label_off_pwm").show();


}

function disable_sepoint_proportional() {
    alarm_setpoint_p1_1 = false;
    alarm_setpoint_p1_1_pm = false;
    alarm_setpoint_p1_2 = false;
    alarm_setpoint_p1_2_pm = false;
    remove_allarme('value_setpoint_p1_1', 'riga_setpoint_p1_1');
    remove_allarme('value_alarm_setpoint_p1_1_pm', 'riga_alarm_setpoint_p1_1_pm');

    remove_allarme('value_setpoint_p1_2', 'riga_setpoint_p1_2');
    remove_allarme('value_alarm_setpoint_p1_2_pm', 'riga_alarm_setpoint_p1_2_pm');

    $("#enable_proportional").hide();
}

function enable_sepoint_proportional() {

    $("#enable_proportional").show();
}

$("#disable_setpoint_ch2").click(function () {
    disable_sepoint_on_off();
});
$("#on_off_setpoint_ch2").click(function () {
    enable_sepoint_on_off();
});
$("#pwm_setpoint_ch2").click(function () {
    enable_sepoint_pwm();
});

$("#disable_setpoint_p1_ch2").click(function () {
    disable_sepoint_proportional();
});
$("#enable_setpoint_p1_ch2").click(function () {
    enable_sepoint_proportional();
});
$("#value_setpoint_on_percent").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga_setpoint_on_percent").removeClass('error');
    alarm_setpoint_on_percent = false;
      // $("#principale").load("test.aspx");
});

$("#value_setpoint_on").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga_setpoint_on").removeClass('error');
    alarm_setpoint_on = false;
    // $("#principale").load("test.aspx");
});

$("#value_setpoint_off").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga_setpoint_off").removeClass('error');
    alarm_setpoint_off = false;
    // $("#principale").load("test.aspx");
});
$("#value_setpoint_off_percent").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga_setpoint_off_percent").removeClass('error');
    alarm_setpoint_off_percent = false;
    // $("#principale").load("test.aspx");
});

$("#value_setpoint_p1_1_pm").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga_setpoint_p1_1_pm").removeClass('error');
    alarm_setpoint_p1_1_pm = false;
    // $("#principale").load("test.aspx");
});
$("#value_setpoint_p1_1").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga_setpoint_p1_1").removeClass('error');
    alarm_setpoint_p1_1 = false;
    // $("#principale").load("test.aspx");
});
$("#value_setpoint_p1_2_pm").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga_setpoint_p1_2_pm").removeClass('error');
    alarm_setpoint_p1_2_pm = false;
    // $("#principale").load("test.aspx");
});
$("#value_setpoint_p1_2").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga_setpoint_p1_2").removeClass('error');
    alarm_setpoint_p1_2 = false;
    // $("#principale").load("test.aspx");
});
$("#save_setpointtower_new").click(function () {
    if (enable_send_setpoint == false) {
        result_setpoint_change(user_setpoint_disable);
        return false;
    }

    $('#save_setpointtower_new').next('p').remove();
    if (($('#on_off_setpoint_ch2').is(':checked'))) {
        Changed_channel('value_setpoint_on', 'riga_setpoint_on', max_ch_value, min_ch_value, max_fix_value);
        Changed_channel('value_setpoint_off', 'riga_setpoint_off', max_ch_value, min_ch_value, max_fix_value);
    }
    if (($('#pwm_setpoint_ch2').is(':checked'))) {
        Changed_channel('value_setpoint_on', 'riga_setpoint_on', max_ch_value, min_ch_value, max_fix_value);
        Changed_channel('value_setpoint_off', 'riga_setpoint_off', max_ch_value, min_ch_value, max_fix_value);
        Changed_channel('value_setpoint_on_percent', 'riga_setpoint_on_percent', 100, 0, 0);
        Changed_channel('value_setpoint_off_percent', 'riga_setpoint_off_percent', 100, 0, 0);
    }
    if (($('#enable_setpoint_p1_ch2').is(':checked'))) {
        Changed_channel('value_setpoint_p1_1', 'riga_setpoint_p1_1', max_ch_value, min_ch_value, max_fix_value);
        Changed_channel('value_setpoint_p1_1_pm', 'riga_setpoint_p1_1_pm', 180, 0, 0);
        Changed_channel('value_setpoint_p1_2', 'riga_setpoint_p1_2', max_ch_value, min_ch_value, max_fix_value);
        Changed_channel('value_setpoint_p1_2_pm', 'riga_setpoint_p1_2_pm', 180, 0, 0);
    }
  
    if ((alarm_setpoint_on) || (alarm_setpoint_on_percent) || (alarm_setpoint_off) || (alarm_setpoint_off_percent) ||
           (alarm_setpoint_p1_1) || (alarm_setpoint_p1_1_pm) || (alarm_setpoint_p1_2) || (alarm_setpoint_p1_2_pm)) {
        $('#save_setpointtower_new').next('p').remove();

        $('#save_setpointtower_new').after('<p class="error help-block"><span class="label label-important">' + wrong_settings + '</span></p>');
        submit_status = false;
        error_general = false;
        return false;
    }
    submit_status = true;
    error_general = true;
    notification['confirm'] = modify_plant;
    
    notification['annulla'] = annulla_impianto;
});


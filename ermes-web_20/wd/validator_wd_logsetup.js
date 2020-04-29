
var log_time_alarm_24 = false;
var log_time_alarm_12 = false;

var log_every_alarm_h = false;
var log_every_alarm_m = false;
function activate_time_picker_12() {
    $('#value_log_time_12').timepicker({
        timeFormat: "hh:mm tt"
    });
}
function activate_time_picker_24() {
    $('#value_log_time_24').timepicker({
        timeFormat: "HH:mm"
    });
}

function Changed_channel_timer(id1, id2, lunghezza) {
    var id = "#" + id1;
    var id_1 = "#" + id2;


    var value_form = $(id).val().length;

    var_alarm = false;

    if ((value_form == 0) || (value_form != lunghezza)) {

        $(id_1).removeClass('error');
        $(id).next('p').remove();

        $(id).after('<p class="error help-block"><span class="label label-important">' + date_time_wrong + '</span></p>');
        $(id_1).addClass('error')
        var_alarm = true
    }
    else {
        $(id_1).removeClass('error');
        $(id).next('p').remove();
    }
    switch (id1) {
        case "value_log_time_24":
            log_time_alarm_24 = var_alarm;
            //check_alarm_time();
            break;
        case "value_log_time_12":
            log_time_alarm_12 = var_alarm;
            //check_alarm_timer();
            break;

    }
}
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
    var myNumber1;
    var value_form1;

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
        case "value_log_every_h":
            log_every_alarm_h = var_alarm;
            //check_alarm_flow_time();
            break;
        case "value_log_every_m":
            log_every_alarm_m = var_alarm;
            if (var_alarm == false) {
                value_form1 = $("#value_log_every_h").val();
                myNumber1 = parseFloat(value_form1);
                myNumber1 = myNumber1.toFixed(myfix);
                if (myNumber1 == 0) {
                    if (myNumber < 5) {
                        $(id_1).removeClass('error');
                        $(id).next('p').remove();

                        $(id).after('<p class="error help-block"><span class="label label-important">' + range + ' 5 min</span></p>');
                        $(id_1).addClass('error');
                        log_every_alarm_m = true;
                    }
                }
            }
            //check_alarm_flow_time();
            break;

    }
}
function keypress_channel(evt) {
    return false;
}
function keypress_channel_number(evt) {
    var charCode = (evt.which) ? evt.which : event.keyCode

    if (charCode > 31 && (charCode < 48 || charCode > 57))
        return false;

    return true;

}
$("#value_log_every_h").keypress(function (evt) {
    return keypress_channel_number(evt);
});
$("#value_log_every_m").keypress(function (evt) {
    return keypress_channel_number(evt);
});

$("#value_log_time_24").keypress(function (evt) {
    return keypress_channel(evt);
});
$("#value_log_time_12").keypress(function (evt) {
    return keypress_channel(evt);
});

function enable_log() {
    $("#enable_value_log").show();
}
function disable_log() {
    log_time_alarm_24 = false;
    log_time_alarm_12 = false;
    log_every_alarm_h = false;
    log_every_alarm_m = false;

    $("#enable_value_log").hide();
}
$("#log_disable").click(function () {
    disable_log();
});
$("#log_enable").click(function () {
    enable_log();
});

$("#value_log_time_24").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga1_log_time_24").removeClass('error');
    log_time_alarm_24 = false;
    //check_alarm_timer1_start();
    // $("#principale").load("test.aspx");
});
$("#value_log_time_12").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga1_log_time_12").removeClass('error');
    log_time_alarm_12 = false;
    //check_alarm_timer1_start();
    // $("#principale").load("test.aspx");
});
$("#value_log_every_h").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga1_log_every_h").removeClass('error');
    log_every_alarm_h = false;
    //check_alarm_timer1_start();
    // $("#principale").load("test.aspx");
});
$("#value_log_every_m").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga1_log_every_m").removeClass('error');
    log_every_alarm_m = false;
    //check_alarm_timer1_start();
    // $("#principale").load("test.aspx");
});
$("#save_logsetupwd_new").click(function () {
    if (enable_send_setpoint == false) {
        result_setpoint_change(user_setpoint_disable);
        return false;
    }

    $('#save_logsetupwd_new').next('p').remove();
    if (($('#log_enable').is(':checked'))) {
        Changed_channel('value_log_every_m', 'riga1_log_every_m', 59, 0, 0);
        Changed_channel('value_log_every_h', 'riga1_log_every_h', 23, 0, 0);
    }
    if ((log_every_alarm_h) || (log_every_alarm_m) || (log_time_alarm_24) || (log_time_alarm_12)) {
        $('#save_logsetupwd_new').next('p').remove();

        $('#save_logsetupwd_new').after('<p class="error help-block"><span class="label label-important">' + wrong_settings + '</span></p>');
        submit_status = false;
        error_general = false;

        return false;
    }
    submit_status = true;
    error_general = true;
    notification['confirm'] = modify_plant;
    notification['annulla'] = annulla_impianto;


});
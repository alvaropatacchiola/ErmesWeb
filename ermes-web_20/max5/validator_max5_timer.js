var var_timer1_start = false;
var var_timer1_stop = false;
var var_timer1_gg = false;
var var_timer1_pulse_minute = false;
var var_timer2_pulse_minute = false;
var var_timer3_pulse_minute = false;
var var_timer4_pulse_minute = false;
var var_timer5_pulse_minute = false;

var var_timer2_1_start = false;
var var_timer2_1_stop = false;
var var_timer2_2_start = false;
var var_timer2_2_stop = false;
var var_timer2_3_start = false;
var var_timer2_3_stop = false;
var var_timer2_4_start = false;
var var_timer2_4_stop = false;
var var_timer2_5_start = false;
var var_timer2_5_stop = false;

var var_timer3_1_start = false;
var var_timer3_1_stop = false;
var var_timer3_2_start = false;
var var_timer3_2_stop = false;
var var_timer3_3_start = false;
var var_timer3_3_stop = false;
var var_timer3_4_start = false;
var var_timer3_4_stop = false;
var var_timer3_5_start = false;
var var_timer3_5_stop = false;

var var_timer4_1_start = false;
var var_timer4_1_stop = false;
var var_timer4_2_start = false;
var var_timer4_2_stop = false;
var var_timer4_3_start = false;
var var_timer4_3_stop = false;
var var_timer4_4_start = false;
var var_timer4_4_stop = false;
var var_timer4_5_start = false;
var var_timer4_5_stop = false;

var var_timer5_1_start = false;
var var_timer5_1_stop = false;
var var_timer5_2_start = false;
var var_timer5_2_stop = false;
var var_timer5_3_start = false;
var var_timer5_3_stop = false;
var var_timer5_4_start = false;
var var_timer5_4_stop = false;
var var_timer5_5_start = false;
var var_timer5_5_stop = false;

//----------------GESTIONE TIMER
function remove_allarme_timer(id1, id2) {
    var id = "#" + id1;
    var id_1 = "#" + id2;

    $(id_1).removeClass('error');
    $(id).next('p').remove();
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
        case "timer_1_start":
            var_timer1_start = var_alarm;
            check_alarm_timer1_start();
            break;
        case "timer_1_stop":
            var_timer1_stop = var_alarm;
            check_alarm_timer1_start();
            break;
        case "timer2_start_1":
            var_timer2_1_start = var_alarm;
            check_alarm_timer2_start();
            break;
        case "timer2_stop_1":
            var_timer2_1_stop = var_alarm;
            check_alarm_timer2_start();
            break;
        case "timer2_start_2":
            var_timer2_2_start = var_alarm;
            check_alarm_timer2_start();
            break;
        case "timer2_stop_2":
            var_timer2_2_stop = var_alarm;
            check_alarm_timer2_start();
            break;
        case "timer2_start_3":
            var_timer2_3_start = var_alarm;
            check_alarm_timer2_start();
            break;
        case "timer2_stop_3":
            var_timer2_3_stop = var_alarm;
            check_alarm_timer2_start();
            break;
        case "timer2_start_4":
            var_timer2_4_start = var_alarm;
            check_alarm_timer2_start();
            break;
        case "timer2_stop_4":
            var_timer2_4_stop = var_alarm;
            check_alarm_timer2_start();
            break;
        case "timer2_start_5":
            var_timer2_5_start = var_alarm;
            check_alarm_timer2_start();
            break;
        case "timer2_stop_5":
            var_timer2_5_stop = var_alarm;
            check_alarm_timer2_start();
            break;
//timer3
        case "timer3_start_1":
            var_timer3_1_start = var_alarm;
            check_alarm_timer3_start();
            break;
        case "timer3_stop_1":
            var_timer3_1_stop = var_alarm;
            check_alarm_timer3_start();
            break;
        case "timer3_start_2":
            var_timer3_2_start = var_alarm;
            check_alarm_timer3_start();
            break;
        case "timer3_stop_2":
            var_timer3_2_stop = var_alarm;
            check_alarm_timer3_start();
            break;
        case "timer3_start_3":
            var_timer3_3_start = var_alarm;
            check_alarm_timer3_start();
            break;
        case "timer3_stop_3":
            var_timer3_3_stop = var_alarm;
            check_alarm_timer3_start();
            break;
        case "timer3_start_4":
            var_timer3_4_start = var_alarm;
            check_alarm_timer3_start();
            break;
        case "timer3_stop_4":
            var_timer3_4_stop = var_alarm;
            check_alarm_timer3_start();
            break;
        case "timer3_start_5":
            var_timer3_5_start = var_alarm;
            check_alarm_timer3_start();
            break;
        case "timer3_stop_5":
            var_timer3_5_stop = var_alarm;
            check_alarm_timer3_start();
            break;
            //end timer3

            //timer4
        case "timer4_start_1":
            var_timer4_1_start = var_alarm;
            check_alarm_timer4_start();
            break;
        case "timer4_stop_1":
            var_timer4_1_stop = var_alarm;
            check_alarm_timer4_start();
            break;
        case "timer4_start_2":
            var_timer4_2_start = var_alarm;
            check_alarm_timer4_start();
            break;
        case "timer4_stop_2":
            var_timer4_2_stop = var_alarm;
            check_alarm_timer4_start();
            break;
        case "timer4_start_3":
            var_timer4_3_start = var_alarm;
            check_alarm_timer4_start();
            break;
        case "timer4_stop_3":
            var_timer4_3_stop = var_alarm;
            check_alarm_timer4_start();
            break;
        case "timer4_start_4":
            var_timer4_4_start = var_alarm;
            check_alarm_timer4_start();
            break;
        case "timer4_stop_4":
            var_timer4_4_stop = var_alarm;
            check_alarm_timer4_start();
            break;
        case "timer4_start_5":
            var_timer4_5_start = var_alarm;
            check_alarm_timer4_start();
            break;
        case "timer4_stop_5":
            var_timer4_5_stop = var_alarm;
            check_alarm_timer4_start();
            break;
            //end timer4

            //timer5
        case "timer5_start_1":
            var_timer5_1_start = var_alarm;
            check_alarm_timer5_start();
            break;
        case "timer5_stop_1":
            var_timer5_1_stop = var_alarm;
            check_alarm_timer5_start();
            break;
        case "timer5_start_2":
            var_timer5_2_start = var_alarm;
            check_alarm_timer5_start();
            break;
        case "timer5_stop_2":
            var_timer5_2_stop = var_alarm;
            check_alarm_timer5_start();
            break;
        case "timer5_start_3":
            var_timer5_3_start = var_alarm;
            check_alarm_timer5_start();
            break;
        case "timer5_stop_3":
            var_timer5_3_stop = var_alarm;
            check_alarm_timer5_start();
            break;
        case "timer5_start_4":
            var_timer5_4_start = var_alarm;
            check_alarm_timer5_start();
            break;
        case "timer5_stop_4":
            var_timer5_4_stop = var_alarm;
            check_alarm_timer5_start();
            break;
        case "timer5_start_5":
            var_timer5_5_start = var_alarm;
            check_alarm_timer5_start();
            break;
        case "timer5_stop_5":
            var_timer5_5_stop = var_alarm;
            check_alarm_timer5_start();
            break;
            //end timer5
    }
}
function Changed_channel_timer_value(id1, id2, max_ch, min_ch, myfix) {
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
        case "value_timer1_gg_id":
            var_timer1_gg = var_alarm;
            check_alarm_timer1_start();
            break;
        case "value_timer1_pulse_minute_id":
            var_timer1_pulse_minute = var_alarm;
            if ($('#timer1_relay_pulse').val() < 7) {// check_pulse
                var_timer1_pulse_minute = false;
                remove_allarme_timer('value_timer1_pulse_minute_id', 'riga_timer_3_2');
            }
            check_alarm_timer1_start();
            break;
        case "value_timer2_pulse_minute_id":
            var_timer2_pulse_minute = var_alarm;
            if ($('#timer2_relay_pulse').val() < 7) {// check_pulse
                var_timer2_pulse_minute = false;
                remove_allarme_timer('value_timer2_pulse_minute_id', 'riga_timer2_7_2');
            }
            check_alarm_timer2_start();
            break;
        case "value_timer3_pulse_minute_id":
            var_timer3_pulse_minute = var_alarm;
            if ($('#timer3_relay_pulse').val() < 7) {// check_pulse
                var_timer3_pulse_minute = false;
                remove_allarme_timer('value_timer3_pulse_minute_id', 'riga_timer3_7_2');
            }
            check_alarm_timer3_start();
            break;
        case "value_timer4_pulse_minute_id":
            var_timer4_pulse_minute = var_alarm;
            if ($('#timer4_relay_pulse').val() < 7) {// check_pulse
                var_timer4_pulse_minute = false;
                remove_allarme_timer('value_timer4_pulse_minute_id', 'riga_timer4_7_2');
            }
            check_alarm_timer4_start();
            break;
        case "value_timer5_pulse_minute_id":
            var_timer5_pulse_minute = var_alarm;
            if ($('#timer5_relay_pulse').val() < 7) {// check_pulse
                var_timer5_pulse_minute = false;
                remove_allarme_timer('value_timer5_pulse_minute_id', 'riga_timer5_7_2');
            }
            check_alarm_timer5_start();
            break;

    }


}
// gestione allarmi su tab
function check_alarm_timer1_start() {
    if ((var_timer1_start == true) || (var_timer1_stop == true) || (var_timer1_gg == true) || (var_timer1_pulse_minute == true)) {
        $("#tab_1_2").attr('style', 'color:#b94a48');
    }
    else {
        $("#tab_1_2").removeAttr('style');
    }
}
function check_alarm_timer2_start() {
    if (!($("#time2_1").is(':checked'))) {
        var_timer2_1_start = false;
        var_timer2_1_stop = false;
        remove_allarme_timer('timer2_start_1', 'riga_timer2_2_2');
        remove_allarme_timer('timer2_stop_1', 'riga_timer2_2_3');
        
    }
    if (!($("#time2_2").is(':checked'))) {
        var_timer2_2_start = false;
        var_timer2_2_stop = false;
        remove_allarme_timer('timer2_start_2', 'riga_timer2_3_2');
        remove_allarme_timer('timer2_stop_2', 'riga_timer2_3_3');
    }
    if (!($("#time2_3").is(':checked'))) {
        var_timer2_3_start = false;
        var_timer2_3_stop = false;
        remove_allarme_timer('timer2_start_3', 'riga_timer2_4_2');
        remove_allarme_timer('timer2_stop_3', 'riga_timer2_4_3');
    }
    if (!($("#time2_4").is(':checked'))) {
        var_timer2_4_start = false;
        var_timer2_4_stop = false;
        remove_allarme_timer('timer2_start_4', 'riga_timer2_5_2');
        remove_allarme_timer('timer2_stop_4', 'riga_timer2_5_3');
    }
    if (!($("#time2_5").is(':checked'))) {
        var_timer2_5_start = false;
        var_timer2_5_stop = false;
        remove_allarme_timer('timer2_start_5', 'riga_timer2_6_2');
        remove_allarme_timer('timer2_stop_5', 'riga_timer2_6_3');
    }

    if ((var_timer2_1_start == true) || (var_timer2_1_stop == true) || (var_timer2_2_start == true) || (var_timer2_2_stop == true)||
        (var_timer2_3_start == true) || (var_timer2_3_stop == true) || (var_timer2_4_start == true) || (var_timer2_4_stop == true)||
        (var_timer2_5_start == true) || (var_timer2_5_stop == true) ) {
        $("#tab_2_2").attr('style', 'color:#b94a48');
    }
    else {
        $("#tab_2_2").removeAttr('style');
    }
}
function check_alarm_timer1_start() {
    if ((var_timer1_start == true) || (var_timer1_stop == true) || (var_timer1_gg == true) || (var_timer1_pulse_minute == true)) {
        $("#tab_1_2").attr('style', 'color:#b94a48');
    }
    else {
        $("#tab_1_2").removeAttr('style');
    }
}

function check_alarm_timer3_start() {
    if (!($("#time3_1").is(':checked'))) {
        var_timer3_1_start = false;
        var_timer3_1_stop = false;
        remove_allarme_timer('timer3_start_1', 'riga_timer3_2_2');
        remove_allarme_timer('timer3_stop_1', 'riga_timer3_2_3');

    }
    if (!($("#time3_2").is(':checked'))) {
        var_timer3_2_start = false;
        var_timer3_2_stop = false;
        remove_allarme_timer('timer3_start_2', 'riga_timer3_3_2');
        remove_allarme_timer('timer3_stop_2', 'riga_timer3_3_3');
    }
    if (!($("#time3_3").is(':checked'))) {
        var_timer3_3_start = false;
        var_timer3_3_stop = false;
        remove_allarme_timer('timer3_start_3', 'riga_timer3_4_2');
        remove_allarme_timer('timer3_stop_3', 'riga_timer3_4_3');
    }
    if (!($("#time3_4").is(':checked'))) {
        var_timer3_4_start = false;
        var_timer3_4_stop = false;
        remove_allarme_timer('timer3_start_4', 'riga_timer3_5_2');
        remove_allarme_timer('timer3_stop_4', 'riga_timer3_5_3');
    }
    if (!($("#time3_5").is(':checked'))) {
        var_timer3_5_start = false;
        var_timer3_5_stop = false;
        remove_allarme_timer('timer3_start_5', 'riga_timer3_6_2');
        remove_allarme_timer('timer3_stop_5', 'riga_timer3_6_3');
    }

    if ((var_timer3_1_start == true) || (var_timer3_1_stop == true) || (var_timer3_2_start == true) || (var_timer3_2_stop == true) ||
        (var_timer3_3_start == true) || (var_timer3_3_stop == true) || (var_timer3_4_start == true) || (var_timer3_4_stop == true) ||
        (var_timer3_5_start == true) || (var_timer3_5_stop == true)) {
        $("#tab_3_2").attr('style', 'color:#b94a48');
    }
    else {
        $("#tab_3_2").removeAttr('style');
    }
}
function check_alarm_timer4_start() {
    if (!($("#time4_1").is(':checked'))) {
        var_timer4_1_start = false;
        var_timer4_1_stop = false;
        remove_allarme_timer('timer4_start_1', 'riga_timer4_2_2');
        remove_allarme_timer('timer4_stop_1', 'riga_timer4_2_3');

    }
    if (!($("#time4_2").is(':checked'))) {
        var_timer4_2_start = false;
        var_timer4_2_stop = false;
        remove_allarme_timer('timer4_start_2', 'riga_timer4_3_2');
        remove_allarme_timer('timer4_stop_2', 'riga_timer4_3_3');
    }
    if (!($("#time4_3").is(':checked'))) {
        var_timer4_3_start = false;
        var_timer4_3_stop = false;
        remove_allarme_timer('timer4_start_3', 'riga_timer4_4_2');
        remove_allarme_timer('timer4_stop_3', 'riga_timer4_4_3');
    }
    if (!($("#time4_4").is(':checked'))) {
        var_timer4_4_start = false;
        var_timer4_4_stop = false;
        remove_allarme_timer('timer4_start_4', 'riga_timer4_5_2');
        remove_allarme_timer('timer4_stop_4', 'riga_timer4_5_3');
    }
    if (!($("#time4_5").is(':checked'))) {
        var_timer4_5_start = false;
        var_timer4_5_stop = false;
        remove_allarme_timer('timer4_start_5', 'riga_timer4_6_2');
        remove_allarme_timer('timer4_stop_5', 'riga_timer4_6_3');
    }

    if ((var_timer4_1_start == true) || (var_timer4_1_stop == true) || (var_timer4_2_start == true) || (var_timer4_2_stop == true) ||
        (var_timer4_3_start == true) || (var_timer4_3_stop == true) || (var_timer4_4_start == true) || (var_timer4_4_stop == true) ||
        (var_timer4_5_start == true) || (var_timer4_5_stop == true)) {
        $("#tab_4_2").attr('style', 'color:#b94a48');
    }
    else {
        $("#tab_4_2").removeAttr('style');
    }
}
function check_alarm_timer5_start() {
    if (!($("#time5_1").is(':checked'))) {
        var_timer5_1_start = false;
        var_timer5_1_stop = false;
        remove_allarme_timer('timer5_start_1', 'riga_timer5_2_2');
        remove_allarme_timer('timer5_stop_1', 'riga_timer5_2_3');

    }
    if (!($("#time5_2").is(':checked'))) {
        var_timer5_2_start = false;
        var_timer5_2_stop = false;
        remove_allarme_timer('timer5_start_2', 'riga_timer5_3_2');
        remove_allarme_timer('timer5_stop_2', 'riga_timer5_3_3');
    }
    if (!($("#time5_3").is(':checked'))) {
        var_timer5_3_start = false;
        var_timer5_3_stop = false;
        remove_allarme_timer('timer5_start_3', 'riga_timer5_4_2');
        remove_allarme_timer('timer5_stop_3', 'riga_timer5_4_3');
    }
    if (!($("#time5_4").is(':checked'))) {
        var_timer5_4_start = false;
        var_timer5_4_stop = false;
        remove_allarme_timer('timer5_start_4', 'riga_timer5_5_2');
        remove_allarme_timer('timer5_stop_4', 'riga_timer5_5_3');
    }
    if (!($("#time5_5").is(':checked'))) {
        var_timer5_5_start = false;
        var_timer5_5_stop = false;
        remove_allarme_timer('timer5_start_5', 'riga_timer5_6_2');
        remove_allarme_timer('timer5_stop_5', 'riga_timer5_6_3');
    }

    if ((var_timer5_1_start == true) || (var_timer5_1_stop == true) || (var_timer5_2_start == true) || (var_timer5_2_stop == true) ||
        (var_timer5_3_start == true) || (var_timer5_3_stop == true) || (var_timer5_4_start == true) || (var_timer5_4_stop == true) ||
        (var_timer5_5_start == true) || (var_timer5_5_stop == true)) {
        $("#tab_5_2").attr('style', 'color:#b94a48');
    }
    else {
        $("#tab_5_2").removeAttr('style');
    }
}
// end gestione allarmi su tab
//------------------------------------------------------------
//---KEY PRESSED timer------------------------------
//------------------------------------------------------------
function keypress_channel(evt) {
    return false;

}
function keypress_numeric(evt) {
    var charCode = (evt.which) ? evt.which : event.keyCode
    if (charCode > 31 && (charCode < 48 || charCode > 57))
        return false;

    return true;
}
$("#timer_1_start").keypress(function (evt) {
    return keypress_channel(evt);
});
$("#timer_1_stop").keypress(function (evt) {
    return keypress_channel(evt);
});
$("#value_timer1_gg_id").keypress(function (evt) {
    return keypress_numeric(evt);
});
$("#value_timer1_pulse_minute_id").keypress(function (evt) {
    return keypress_numeric(evt);
});
$("#timer2_start_1").keypress(function (evt) {
    return keypress_channel(evt);
});
$("#timer2_stop_1").keypress(function (evt) {
    return keypress_channel(evt);
});
$("#timer2_start_2").keypress(function (evt) {
    return keypress_channel(evt);
});
$("#timer2_stop_2").keypress(function (evt) {
    return keypress_channel(evt);
});
$("#timer2_start_3").keypress(function (evt) {
    return keypress_channel(evt);
});
$("#timer2_stop_3").keypress(function (evt) {
    return keypress_channel(evt);
});
$("#timer2_start_4").keypress(function (evt) {
    return keypress_channel(evt);
});
$("#timer2_stop_4").keypress(function (evt) {
    return keypress_channel(evt);
});
$("#timer2_start_5").keypress(function (evt) {
    return keypress_channel(evt);
});
$("#timer2_stop_5").keypress(function (evt) {
    return keypress_channel(evt);
});


$("#timer3_start_1").keypress(function (evt) {
    return keypress_channel(evt);
});
$("#timer3_stop_1").keypress(function (evt) {
    return keypress_channel(evt);
});
$("#timer3_start_2").keypress(function (evt) {
    return keypress_channel(evt);
});
$("#timer3_stop_2").keypress(function (evt) {
    return keypress_channel(evt);
});
$("#timer3_start_3").keypress(function (evt) {
    return keypress_channel(evt);
});
$("#timer3_stop_3").keypress(function (evt) {
    return keypress_channel(evt);
});
$("#timer3_start_4").keypress(function (evt) {
    return keypress_channel(evt);
});
$("#timer3_stop_4").keypress(function (evt) {
    return keypress_channel(evt);
});
$("#timer3_start_5").keypress(function (evt) {
    return keypress_channel(evt);
});
$("#timer3_stop_5").keypress(function (evt) {
    return keypress_channel(evt);
});

$("#timer4_start_1").keypress(function (evt) {
    return keypress_channel(evt);
});
$("#timer4_stop_1").keypress(function (evt) {
    return keypress_channel(evt);
});
$("#timer4_start_2").keypress(function (evt) {
    return keypress_channel(evt);
});
$("#timer4_stop_2").keypress(function (evt) {
    return keypress_channel(evt);
});
$("#timer4_start_3").keypress(function (evt) {
    return keypress_channel(evt);
});
$("#timer4_stop_3").keypress(function (evt) {
    return keypress_channel(evt);
});
$("#timer4_start_4").keypress(function (evt) {
    return keypress_channel(evt);
});
$("#timer4_stop_4").keypress(function (evt) {
    return keypress_channel(evt);
});
$("#timer4_start_5").keypress(function (evt) {
    return keypress_channel(evt);
});
$("#timer4_stop_5").keypress(function (evt) {
    return keypress_channel(evt);
});

$("#timer5_start_1").keypress(function (evt) {
    return keypress_channel(evt);
});
$("#timer5_stop_1").keypress(function (evt) {
    return keypress_channel(evt);
});
$("#timer5_start_2").keypress(function (evt) {
    return keypress_channel(evt);
});
$("#timer5_stop_2").keypress(function (evt) {
    return keypress_channel(evt);
});
$("#timer5_start_3").keypress(function (evt) {
    return keypress_channel(evt);
});
$("#timer5_stop_3").keypress(function (evt) {
    return keypress_channel(evt);
});
$("#timer5_start_4").keypress(function (evt) {
    return keypress_channel(evt);
});
$("#timer5_stop_4").keypress(function (evt) {
    return keypress_channel(evt);
});
$("#timer5_start_5").keypress(function (evt) {
    return keypress_channel(evt);
});
$("#timer5_stop_5").keypress(function (evt) {
    return keypress_channel(evt);
});

//------------------------------------------------------------
//---KEY PRESSED timer------------------------------
//------------------------------------------------------------
//------------------------------------------------------------
//---DISABLE TIMER------------------------------
//-----------------------------------------------------------
function activate_time_picker() {
    $('#timer_1_start').datetimepicker({
        dateFormat: formato_data,
        timeFormat: formato_ora
    });
    $('#timer_1_stop').timepicker({
        timeFormat: formato_ora
    });
    $('#timer2_start_1').timepicker({
        timeFormat: formato_ora
    });
    $('#timer2_stop_1').timepicker({
        timeFormat: formato_ora
    });

    $('#timer2_start_2').timepicker({
        timeFormat: formato_ora
    });
    $('#timer2_stop_2').timepicker({
        timeFormat: formato_ora
    });
    $('#timer2_start_3').timepicker({
        timeFormat: formato_ora
    });
    $('#timer2_stop_3').timepicker({
        timeFormat: formato_ora
    });
    $('#timer2_start_4').timepicker({
        timeFormat: formato_ora
    });
    $('#timer2_stop_4').timepicker({
        timeFormat: formato_ora
    });

    $('#timer2_start_5').timepicker({
        timeFormat: formato_ora
    });
    $('#timer2_stop_5').timepicker({
        timeFormat: formato_ora
    });

    $('#timer3_start_1').timepicker({
        timeFormat: formato_ora
    });
    $('#timer3_stop_1').timepicker({
        timeFormat: formato_ora
    });

    $('#timer3_start_2').timepicker({
        timeFormat: formato_ora
    });
    $('#timer3_stop_2').timepicker({
        timeFormat: formato_ora
    });
    $('#timer3_start_3').timepicker({
        timeFormat: formato_ora
    });
    $('#timer3_stop_3').timepicker({
        timeFormat: formato_ora
    });
    $('#timer3_start_4').timepicker({
        timeFormat: formato_ora
    });
    $('#timer3_stop_4').timepicker({
        timeFormat: formato_ora
    });

    $('#timer3_start_5').timepicker({
        timeFormat: formato_ora
    });
    $('#timer3_stop_5').timepicker({
        timeFormat: formato_ora
    });


    $('#timer4_start_1').timepicker({
        timeFormat: formato_ora
    });
    $('#timer4_stop_1').timepicker({
        timeFormat: formato_ora
    });

    $('#timer4_start_2').timepicker({
        timeFormat: formato_ora
    });
    $('#timer4_stop_2').timepicker({
        timeFormat: formato_ora
    });
    $('#timer4_start_3').timepicker({
        timeFormat: formato_ora
    });
    $('#timer4_stop_3').timepicker({
        timeFormat: formato_ora
    });
    $('#timer4_start_4').timepicker({
        timeFormat: formato_ora
    });
    $('#timer4_stop_4').timepicker({
        timeFormat: formato_ora
    });

    $('#timer4_start_5').timepicker({
        timeFormat: formato_ora
    });
    $('#timer4_stop_5').timepicker({
        timeFormat: formato_ora
    });

    $('#timer5_start_1').timepicker({
        timeFormat: formato_ora
    });
    $('#timer5_stop_1').timepicker({
        timeFormat: formato_ora
    });

    $('#timer5_start_2').timepicker({
        timeFormat: formato_ora
    });
    $('#timer5_stop_2').timepicker({
        timeFormat: formato_ora
    });
    $('#timer5_start_3').timepicker({
        timeFormat: formato_ora
    });
    $('#timer5_stop_3').timepicker({
        timeFormat: formato_ora
    });
    $('#timer5_start_4').timepicker({
        timeFormat: formato_ora
    });
    $('#timer5_stop_4').timepicker({
        timeFormat: formato_ora
    });

    $('#timer5_start_5').timepicker({
        timeFormat: formato_ora
    });
    $('#timer5_stop_5').timepicker({
        timeFormat: formato_ora
    });
    $('#timer5_start_5').timepicker({
        timeFormat: formato_ora
    });
    $('#timer5_stop_5').timepicker({
        timeFormat: formato_ora
    });
    
}
function disable_timer1_1() {
    disable_timer1();
    activate_time_picker();
}
function enable_timer1_1() {
    enable_timer1();
    activate_time_picker();
}

function disable_timer1() {
    var_timer1_start = false;
    var_timer1_stop = false;
    var_timer1_gg = false;
    check_alarm_timer2_start();
    remove_allarme_timer('timer_1_start', 'riga_timer_1_1');
    remove_allarme_timer('timer_1_stop', 'riga_timer_1_2');
    remove_allarme_timer('value_timer1_gg_id', 'riga_timer_2_1');
    remove_allarme_timer('value_timer1_pulse_minute_id', 'riga_timer_3_2');
    $("#div_enable_timer1").hide();
}
function enable_timer1() {
    $("#div_enable_timer1").show();
    check_relay_pulse('timer1_relay_pulse', 'riga_timer_3_2');
}
-
$("#disable_timer1").click(function () {
    disable_timer1();

});
$("#enable_timer1").click(function () {
    enable_timer1();
});

function disable_timer2() {
    var_timer2_1_start = false;
    var_timer2_1_stop = false;
    var_timer2_2_start = false;
    var_timer2_2_stop = false;
    var_timer2_3_start = false;
    var_timer2_3_stop = false;
    var_timer2_4_start = false;
    var_timer2_4_stop = false;
    var_timer2_5_start = false;
    var_timer2_5_stop = false;
    check_alarm_timer2_start();

    remove_allarme_timer('timer2_start_1', 'riga_timer2_2_2');
    remove_allarme_timer('timer2_stop_1', 'riga_timer2_2_3');
    remove_allarme_timer('timer2_start_2', 'riga_timer2_3_2');
    remove_allarme_timer('timer2_stop_2', 'riga_timer2_3_3');
    remove_allarme_timer('timer2_start_3', 'riga_timer2_4_2');
    remove_allarme_timer('timer2_stop_3', 'riga_timer2_4_3');
    remove_allarme_timer('timer2_start_4', 'riga_timer2_5_2');
    remove_allarme_timer('timer2_stop_4', 'riga_timer2_5_3');
    remove_allarme_timer('timer2_start_5', 'riga_timer2_6_2');
    remove_allarme_timer('timer2_stop_5', 'riga_timer2_6_3');
    $("#div_enable_timer2").hide();
}
function enable_timer2() {
    $("#div_enable_timer2").show();
    check_relay_pulse('timer2_relay_pulse', 'riga_timer2_7_2');
}
-
$("#disable_timer2").click(function () {
    disable_timer2();

});
$("#enable_timer2").click(function () {
    enable_timer2();
});

function disable_timer3() {
    var_timer3_1_start = false;
    var_timer3_1_stop = false;
    var_timer3_2_start = false;
    var_timer3_2_stop = false;
    var_timer3_3_start = false;
    var_timer3_3_stop = false;
    var_timer3_4_start = false;
    var_timer3_4_stop = false;
    var_timer3_5_start = false;
    var_timer3_5_stop = false;
    check_alarm_timer3_start();

    remove_allarme_timer('timer3_start_1', 'riga_timer3_2_2');
    remove_allarme_timer('timer3_stop_1', 'riga_timer3_2_3');
    remove_allarme_timer('timer3_start_2', 'riga_timer3_3_2');
    remove_allarme_timer('timer3_stop_2', 'riga_timer3_3_3');
    remove_allarme_timer('timer3_start_3', 'riga_timer3_4_2');
    remove_allarme_timer('timer3_stop_3', 'riga_timer3_4_3');
    remove_allarme_timer('timer3_start_4', 'riga_timer3_5_2');
    remove_allarme_timer('timer3_stop_4', 'riga_timer3_5_3');
    remove_allarme_timer('timer3_start_5', 'riga_timer3_6_2');
    remove_allarme_timer('timer3_stop_5', 'riga_timer3_6_3');
    $("#div_enable_timer3").hide();
}
function enable_timer3() {
    $("#div_enable_timer3").show();
    check_relay_pulse('timer3_relay_pulse', 'riga_timer3_7_2');
}
-
$("#disable_timer3").click(function () {
    disable_timer3();

});
$("#enable_timer3").click(function () {
    enable_timer3();
});

function disable_timer4() {
    var_timer4_1_start = false;
    var_timer4_1_stop = false;
    var_timer4_2_start = false;
    var_timer4_2_stop = false;
    var_timer4_3_start = false;
    var_timer4_3_stop = false;
    var_timer4_4_start = false;
    var_timer4_4_stop = false;
    var_timer4_5_start = false;
    var_timer4_5_stop = false;
    check_alarm_timer4_start();

    remove_allarme_timer('timer4_start_1', 'riga_timer4_2_2');
    remove_allarme_timer('timer4_stop_1', 'riga_timer4_2_3');
    remove_allarme_timer('timer4_start_2', 'riga_timer4_3_2');
    remove_allarme_timer('timer4_stop_2', 'riga_timer4_3_3');
    remove_allarme_timer('timer4_start_3', 'riga_timer4_4_2');
    remove_allarme_timer('timer4_stop_3', 'riga_timer4_4_3');
    remove_allarme_timer('timer4_start_4', 'riga_timer4_5_2');
    remove_allarme_timer('timer4_stop_4', 'riga_timer4_5_3');
    remove_allarme_timer('timer4_start_5', 'riga_timer4_6_2');
    remove_allarme_timer('timer4_stop_5', 'riga_timer4_6_3');
    $("#div_enable_timer4").hide();
}
function enable_timer4() {
    $("#div_enable_timer4").show();
    check_relay_pulse('timer4_relay_pulse', 'riga_timer4_7_2');
}
-
$("#disable_timer4").click(function () {
    disable_timer4();

});
$("#enable_timer4").click(function () {
    enable_timer4();
});
function disable_timer5() {
    var_timer5_1_start = false;
    var_timer5_1_stop = false;
    var_timer5_2_start = false;
    var_timer5_2_stop = false;
    var_timer5_3_start = false;
    var_timer5_3_stop = false;
    var_timer5_4_start = false;
    var_timer5_4_stop = false;
    var_timer5_5_start = false;
    var_timer5_5_stop = false;
    check_alarm_timer5_start();

    remove_allarme_timer('timer5_start_1', 'riga_timer5_2_2');
    remove_allarme_timer('timer5_stop_1', 'riga_timer5_2_3');
    remove_allarme_timer('timer5_start_2', 'riga_timer5_3_2');
    remove_allarme_timer('timer5_stop_2', 'riga_timer5_3_3');
    remove_allarme_timer('timer5_start_3', 'riga_timer5_4_2');
    remove_allarme_timer('timer5_stop_3', 'riga_timer5_4_3');
    remove_allarme_timer('timer5_start_4', 'riga_timer5_5_2');
    remove_allarme_timer('timer5_stop_4', 'riga_timer5_5_3');
    remove_allarme_timer('timer5_start_5', 'riga_timer5_6_2');
    remove_allarme_timer('timer5_stop_5', 'riga_timer5_6_3');
    $("#div_enable_timer5").hide();
}
function enable_timer5() {
    $("#div_enable_timer5").show();
    check_relay_pulse('timer5_relay_pulse', 'riga_timer5_7_2');
}
-
$("#disable_timer5").click(function () {
    disable_timer5();

});
$("#enable_timer5").click(function () {
    enable_timer5();
});

//------------------------------------------------------------
//---end DISABLE TIMER------------------------------
//------------------------------------------------------------
//------------------------------------------------------------
//---REMOVE CONTROL ERROR  Timer-----------------------------
//------------------------------------------------------------
$("#timer_1_start").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga_timer_1_1").removeClass('error');
    var_timer1_start = false;
    check_alarm_timer1_start();
    // $("#principale").load("test.aspx");
});
$("#timer_1_stop").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga_timer_1_2").removeClass('error');
    var_timer1_stop = false;
    check_alarm_timer1_start();
    // $("#principale").load("test.aspx");
});
$("#value_timer1_gg_id").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga_timer_2_1").removeClass('error');
    var_timer1_gg = false;
    check_alarm_timer1_start();
    // $("#principale").load("test.aspx");
});
$("#value_timer1_pulse_minute_id").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga_timer_3_2").removeClass('error');
    var_timer1_pulse_minute = false;
    check_alarm_timer1_start();
    // $("#principale").load("test.aspx");
});
$("#timer2_start_1").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga_timer2_2_2").removeClass('error');
    var_timer2_1_start = false;
    $("#time2_1").prop('checked', true);
    check_alarm_timer2_start();
    // $("#principale").load("test.aspx");
});
$("#timer2_stop_1").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga_timer2_2_3").removeClass('error');
    var_timer2_1_stop = false;
    $("#time2_1").prop('checked', true);
    check_alarm_timer2_start();
    // $("#principale").load("test.aspx");
});

$("#timer2_start_2").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga_timer2_3_2").removeClass('error');
    var_timer2_2_start = false;
    $("#time2_2").prop('checked', true);
    check_alarm_timer2_start();
    // $("#principale").load("test.aspx");
});
$("#timer2_stop_2").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga_timer2_3_3").removeClass('error');
    var_timer2_2_stop = false;
    $("#time2_2").prop('checked', true);
    check_alarm_timer2_start();
    // $("#principale").load("test.aspx");
});
$("#timer2_start_3").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga_timer2_4_2").removeClass('error');
    var_timer2_3_start = false;
    $("#time2_3").prop('checked', true);
    check_alarm_timer2_start();
    // $("#principale").load("test.aspx");
});
$("#timer2_stop_3").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga_timer2_4_3").removeClass('error');
    var_timer2_3_stop = false;
    $("#time2_3").prop('checked', true);
    check_alarm_timer2_start();
    // $("#principale").load("test.aspx");
});
$("#timer2_start_4").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga_timer2_5_2").removeClass('error');
    var_timer2_4_start = false;
    $("#time2_4").prop('checked', true);
    check_alarm_timer2_start();
    // $("#principale").load("test.aspx");
});
$("#timer2_stop_4").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga_timer2_5_3").removeClass('error');
    var_timer2_4_stop = false;
    $("#time2_4").prop('checked', true);
    check_alarm_timer2_start();
    // $("#principale").load("test.aspx");
});
$("#timer2_start_5").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga_timer2_6_2").removeClass('error');
    var_timer2_5_start = false;
    $("#time2_5").prop('checked', true);
    check_alarm_timer2_start();
    // $("#principale").load("test.aspx");
});
$("#timer2_stop_5").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga_timer2_6_3").removeClass('error');
    var_timer2_5_stop = false;
    $("#time2_5").prop('checked', true);
    check_alarm_timer2_start();
    // $("#principale").load("test.aspx");
});

//timer3
$("#timer3_start_1").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga_timer3_2_2").removeClass('error');
    var_timer3_1_start = false;
    $("#time3_1").prop('checked', true);
    check_alarm_timer3_start();
    // $("#principale").load("test.aspx");
});
$("#timer3_stop_1").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga_timer3_2_3").removeClass('error');
    var_timer3_1_stop = false;
    $("#time3_1").prop('checked', true);
    check_alarm_timer3_start();
    // $("#principale").load("test.aspx");
});

$("#timer3_start_2").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga_timer3_3_2").removeClass('error');
    var_timer3_2_start = false;
    $("#time3_2").prop('checked', true);
    check_alarm_timer3_start();
    // $("#principale").load("test.aspx");
});
$("#timer3_stop_2").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga_timer3_3_3").removeClass('error');
    var_timer3_2_stop = false;
    $("#time3_2").prop('checked', true);
    check_alarm_timer3_start();
    // $("#principale").load("test.aspx");
});
$("#timer3_start_3").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga_timer3_4_2").removeClass('error');
    var_timer3_3_start = false;
    $("#time3_3").prop('checked', true);
    check_alarm_timer3_start();
    // $("#principale").load("test.aspx");
});
$("#timer3_stop_3").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga_timer3_4_3").removeClass('error');
    var_timer3_3_stop = false;
    $("#time3_3").prop('checked', true);
    check_alarm_timer3_start();
    // $("#principale").load("test.aspx");
});
$("#timer3_start_4").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga_timer3_5_2").removeClass('error');
    var_timer3_4_start = false;
    $("#time3_4").prop('checked', true);
    check_alarm_timer3_start();
    // $("#principale").load("test.aspx");
});
$("#timer3_stop_4").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga_timer3_5_3").removeClass('error');
    var_timer3_4_stop = false;
    $("#time3_4").prop('checked', true);
    check_alarm_timer3_start();
    // $("#principale").load("test.aspx");
});
$("#timer3_start_5").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga_timer3_6_2").removeClass('error');
    var_timer3_5_start = false;
    $("#time3_5").prop('checked', true);
    check_alarm_timer3_start();
    // $("#principale").load("test.aspx");
});
$("#timer3_stop_5").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga_timer3_6_3").removeClass('error');
    var_timer3_5_stop = false;
    $("#time3_5").prop('checked', true);
    check_alarm_timer3_start();
    // $("#principale").load("test.aspx");
});
//timer4

$("#timer4_start_1").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga_timer4_2_2").removeClass('error');
    var_timer4_1_start = false;
    $("#time4_1").prop('checked', true);
    check_alarm_timer4_start();
    // $("#principale").load("test.aspx");
});
$("#timer4_stop_1").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga_timer4_2_3").removeClass('error');
    var_timer4_1_stop = false;
    $("#time4_1").prop('checked', true);
    check_alarm_timer4_start();
    // $("#principale").load("test.aspx");
});

$("#timer4_start_2").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga_timer4_3_2").removeClass('error');
    var_timer4_2_start = false;
    $("#time4_2").prop('checked', true);
    check_alarm_timer4_start();
    // $("#principale").load("test.aspx");
});
$("#timer4_stop_2").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga_timer4_3_3").removeClass('error');
    var_timer4_2_stop = false;
    $("#time4_2").prop('checked', true);
    check_alarm_timer4_start();
    // $("#principale").load("test.aspx");
});
$("#timer4_start_3").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga_timer4_4_2").removeClass('error');
    var_timer4_3_start = false;
    $("#time4_3").prop('checked', true);
    check_alarm_timer4_start();
    // $("#principale").load("test.aspx");
});
$("#timer4_stop_3").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga_timer4_4_3").removeClass('error');
    var_timer4_3_stop = false;
    $("#time4_3").prop('checked', true);
    check_alarm_timer4_start();
    // $("#principale").load("test.aspx");
});
$("#timer4_start_4").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga_timer4_5_2").removeClass('error');
    var_timer4_4_start = false;
    $("#time4_4").prop('checked', true);
    check_alarm_timer4_start();
    // $("#principale").load("test.aspx");
});
$("#timer4_stop_4").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga_timer4_5_3").removeClass('error');
    var_timer4_4_stop = false;
    $("#time4_4").prop('checked', true);
    check_alarm_timer4_start();
    // $("#principale").load("test.aspx");
});
$("#timer4_start_5").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga_timer4_6_2").removeClass('error');
    var_timer4_5_start = false;
    $("#time4_5").prop('checked', true);
    check_alarm_timer4_start();
    // $("#principale").load("test.aspx");
});
$("#timer4_stop_5").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga_timer4_6_3").removeClass('error');
    var_timer4_5_stop = false;
    $("#time4_5").prop('checked', true);
    check_alarm_timer4_start();
    // $("#principale").load("test.aspx");
});
//timer5
$("#timer5_start_1").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga_timer5_2_2").removeClass('error');
    var_timer5_1_start = false;
    $("#time5_1").prop('checked', true);
    check_alarm_timer5_start();
    // $("#principale").load("test.aspx");
});
$("#timer5_stop_1").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga_timer5_2_3").removeClass('error');
    var_timer5_1_stop = false;
    $("#time5_1").prop('checked', true);
    check_alarm_timer5_start();
    // $("#principale").load("test.aspx");
});

$("#timer5_start_2").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga_timer5_3_2").removeClass('error');
    var_timer5_2_start = false;
    $("#time5_2").prop('checked', true);
    check_alarm_timer5_start();
    // $("#principale").load("test.aspx");
});
$("#timer5_stop_2").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga_timer5_3_3").removeClass('error');
    var_timer5_2_stop = false;
    $("#time5_2").prop('checked', true);
    check_alarm_timer5_start();
    // $("#principale").load("test.aspx");
});
$("#timer5_start_3").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga_timer5_4_2").removeClass('error');
    var_timer5_3_start = false;
    $("#time5_3").prop('checked', true);
    check_alarm_timer5_start();
    // $("#principale").load("test.aspx");
});
$("#timer5_stop_3").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga_timer5_4_3").removeClass('error');
    var_timer5_3_stop = false;
    $("#time5_3").prop('checked', true);
    check_alarm_timer5_start();
    // $("#principale").load("test.aspx");
});
$("#timer5_start_4").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga_timer5_5_2").removeClass('error');
    var_timer5_4_start = false;
    $("#time5_4").prop('checked', true);
    check_alarm_timer5_start();
    // $("#principale").load("test.aspx");
});
$("#timer5_stop_4").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga_timer5_5_3").removeClass('error');
    var_timer5_4_stop = false;
    $("#time5_4").prop('checked', true);
    check_alarm_timer5_start();
    // $("#principale").load("test.aspx");
});
$("#timer5_start_5").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga_timer5_6_2").removeClass('error');
    var_timer5_5_start = false;
    $("#time5_5").prop('checked', true);
    check_alarm_timer5_start();
    // $("#principale").load("test.aspx");
});
$("#timer5_stop_5").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga_timer5_6_3").removeClass('error');
    var_timer5_5_stop = false;
    $("#time5_5").prop('checked', true);
    check_alarm_timer5_start();
    // $("#principale").load("test.aspx");
});
//------------------------------------------------------------
//---end REMOVE CONTROL ERROR  Timer-----------------------------
//------------------------------------------------------------

//------------------------------------------------------------
//---Gestione click relay or pulse-----------------------------
//-----------------------------------------------------------
function check_relay_pulse(id1, id2) {
    var id_1 = "#" + id1;
    var id_2 = "#" + id2;
    if ($(id_1).val() > 6) {// abilito pulse
        $(id_2).show();
    }
    else {
        $(id_2).hide();
    }

}
$("#timer1_relay_pulse").change(function () {
    check_relay_pulse('timer1_relay_pulse', 'riga_timer_3_2');
});
$("#timer2_relay_pulse").change(function () {
    check_relay_pulse('timer2_relay_pulse', 'riga_timer2_7_2');
});
$("#timer3_relay_pulse").change(function () {
    check_relay_pulse('timer3_relay_pulse', 'riga_timer3_7_2');
});
$("#timer4_relay_pulse").change(function () {
    check_relay_pulse('timer4_relay_pulse', 'riga_timer4_7_2');
});
$("#timer5_relay_pulse").change(function () {
    check_relay_pulse('timer5_relay_pulse', 'riga_timer5_7_2');
});

//------------------------------------------------------------
//---end Gestione click relay or pulse-----------------------------
//------------------------------------------------------------

//------------------------------------------------------------
//---TAB CLICK CONTROL------------------------------
//------------------------------------------------------------
$("#tab_1_2").click(function () {
    if ($('#enable_timer1').is(':checked')) {
        enable_timer1();
        check_relay_pulse('timer1_relay_pulse', 'riga_timer_3_2');
    }
    else {
        disable_timer1();
    }
});
$("#tab_2_2").click(function () {
    if ($('#enable_timer2').is(':checked')) {
        enable_timer2();
        check_relay_pulse('timer2_relay_pulse', 'riga_timer2_7_2');
    }
    else {
        disable_timer2();
    }
});

$("#tab_3_2").click(function () {
    if ($('#enable_timer3').is(':checked')) {
        enable_timer3();
        check_relay_pulse('timer3_relay_pulse', 'riga_timer3_7_2');
    }
    else {
        disable_timer3();
    }
});
$("#tab_4_2").click(function () {
    if ($('#enable_timer4').is(':checked')) {
        enable_timer4();
        check_relay_pulse('timer4_relay_pulse', 'riga_timer4_7_2');
    }
    else {
        disable_timer4();
    }
});
$("#tab_5_2").click(function () {
    if ($('#enable_timer5').is(':checked')) {
        enable_timer5();
        check_relay_pulse('timer5_relay_pulse', 'riga_timer5_7_2');
    }
    else {
        disable_timer5();
    }
});

//------------------------------------------------------------
//---end TAB CLICK CONTROL------------------------------
//------------------------------------------------------------
//GESTIONE SALVATAGGIO DATI
$("#save_timer_new").click(function () {
    var checked_t2 = false;
    var timer2_str = "";
    var checked_t3 = false;
    var timer3_str = "";
    var checked_t4 = false;
    var timer4_str = "";
    var checked_t5 = false;
    var timer5_str = "";
    if (enable_send_setpoint == false) {
        result_setpoint_change(user_setpoint_disable);
        return false;
    }

    $('#save_timer_new').next('p').remove();
    if ($('#enable_timer1').is(':checked')) {
        Changed_channel_timer('timer_1_start', 'riga_timer_1_1', lunghezza_data);
        Changed_channel_timer('timer_1_stop', 'riga_timer_1_2', lunghezza_ora);
        Changed_channel_timer_value('value_timer1_gg_id', 'riga_timer_2_1', 30, 0, 1);
    }
    
    if ($('#enable_timer2').is(':checked')) {
        Changed_channel_timer('timer2_start_1', 'riga_timer2_2_2', lunghezza_ora);
        Changed_channel_timer('timer2_stop_1', 'riga_timer2_2_3', lunghezza_ora);
        Changed_channel_timer('timer2_start_2', 'riga_timer2_3_2', lunghezza_ora);
        Changed_channel_timer('timer2_stop_2', 'riga_timer2_3_3', lunghezza_ora);
        Changed_channel_timer('timer2_start_3', 'riga_timer2_4_2', lunghezza_ora);
        Changed_channel_timer('timer2_stop_3', 'riga_timer2_4_3', lunghezza_ora);
        Changed_channel_timer('timer2_start_4', 'riga_timer2_5_2', lunghezza_ora);
        Changed_channel_timer('timer2_stop_4', 'riga_timer2_5_3', lunghezza_ora);
        Changed_channel_timer('timer2_start_5', 'riga_timer2_6_2', lunghezza_ora);
        Changed_channel_timer('timer2_stop_5', 'riga_timer2_6_3', lunghezza_ora);
        Changed_channel_timer_value('value_timer2_pulse_minute_id', 'riga_timer2_7_2', 180, 0, 0);
        
        if ((!($("#timer2_lunedi").is(':checked')))&& (!($("#timer2_martedi").is(':checked')))&&(!($("#timer2_mercoledi").is(':checked')))&&
            (!($("#timer2_giovedi").is(':checked')))&&(!($("#timer2_venerdi").is(':checked')))&&(!($("#timer2_sabato").is(':checked')))&&
            (!($("#timer2_domenica").is(':checked')))) {
            
            checked_t2 = true;
            timer2_str = "Timer2,";
        }

    }
    
    if ($('#enable_timer3').is(':checked')) {
        Changed_channel_timer('timer3_start_1', 'riga_timer3_2_2', lunghezza_ora);
        Changed_channel_timer('timer3_stop_1', 'riga_timer3_2_3', lunghezza_ora);
        Changed_channel_timer('timer3_start_2', 'riga_timer3_3_2', lunghezza_ora);
        Changed_channel_timer('timer3_stop_2', 'riga_timer3_3_3', lunghezza_ora);
        Changed_channel_timer('timer3_start_3', 'riga_timer3_4_2', lunghezza_ora);
        Changed_channel_timer('timer3_stop_3', 'riga_timer3_4_3', lunghezza_ora);
        Changed_channel_timer('timer3_start_4', 'riga_timer3_5_2', lunghezza_ora);
        Changed_channel_timer('timer3_stop_4', 'riga_timer3_5_3', lunghezza_ora);
        Changed_channel_timer('timer3_start_5', 'riga_timer3_6_2', lunghezza_ora);
        Changed_channel_timer('timer3_stop_5', 'riga_timer3_6_3', lunghezza_ora);
        Changed_channel_timer_value('value_timer3_pulse_minute_id', 'riga_timer3_7_2', 180, 0, 0);
        if ((!($("#timer3_lunedi").is(':checked'))) && (!($("#timer3_martedi").is(':checked'))) && (!($("#timer3_mercoledi").is(':checked'))) &&
            (!($("#timer3_giovedi").is(':checked')))&&(!($("#timer3_venerdi").is(':checked')))&&(!($("#timer3_sabato").is(':checked'))) &&
            (!($("#timer3_domenica").is(':checked')))) {
            checked_t3 = true;
            timer3_str = "Timer3,";
        }

    }
    if ($('#enable_timer4').is(':checked')) {
        Changed_channel_timer('timer4_start_1', 'riga_timer4_2_2', lunghezza_ora);
        Changed_channel_timer('timer4_stop_1', 'riga_timer4_2_3', lunghezza_ora);
        Changed_channel_timer('timer4_start_2', 'riga_timer4_3_2', lunghezza_ora);
        Changed_channel_timer('timer4_stop_2', 'riga_timer4_3_3', lunghezza_ora);
        Changed_channel_timer('timer4_start_3', 'riga_timer4_4_2', lunghezza_ora);
        Changed_channel_timer('timer4_stop_3', 'riga_timer4_4_3', lunghezza_ora);
        Changed_channel_timer('timer4_start_4', 'riga_timer4_5_2', lunghezza_ora);
        Changed_channel_timer('timer4_stop_4', 'riga_timer4_5_3', lunghezza_ora);
        Changed_channel_timer('timer4_start_5', 'riga_timer4_6_2', lunghezza_ora);
        Changed_channel_timer('timer4_stop_5', 'riga_timer4_6_3', lunghezza_ora);
        Changed_channel_timer_value('value_timer4_pulse_minute_id', 'riga_timer4_7_2', 180, 0, 0);
        if ((!($("#timer4_lunedi").is(':checked'))) && (!($("#timer4_martedi").is(':checked'))) && (!($("#timer4_mercoledi").is(':checked'))) &&
                (!($("#timer4_giovedi").is(':checked')))&&(!($("#timer4_venerdi").is(':checked')))&&(!($("#timer4_sabato").is(':checked'))) &&
                (!($("#timer4_domenica").is(':checked')))) {
            checked_t4 = true;
            timer4_str = "Timer4,";
        }

    }
    if ($('#enable_timer5').is(':checked')) {
        Changed_channel_timer('timer5_start_1', 'riga_timer5_2_2', lunghezza_ora);
        Changed_channel_timer('timer5_stop_1', 'riga_timer5_2_3', lunghezza_ora);
        Changed_channel_timer('timer5_start_2', 'riga_timer5_3_2', lunghezza_ora);
        Changed_channel_timer('timer5_stop_2', 'riga_timer5_3_3', lunghezza_ora);
        Changed_channel_timer('timer5_start_3', 'riga_timer5_4_2', lunghezza_ora);
        Changed_channel_timer('timer5_stop_3', 'riga_timer5_4_3', lunghezza_ora);
        Changed_channel_timer('timer5_start_4', 'riga_timer5_5_2', lunghezza_ora);
        Changed_channel_timer('timer5_stop_4', 'riga_timer5_5_3', lunghezza_ora);
        Changed_channel_timer('timer5_start_5', 'riga_timer5_6_2', lunghezza_ora);
        Changed_channel_timer('timer5_stop_5', 'riga_timer5_6_3', lunghezza_ora);
        Changed_channel_timer_value('value_timer5_pulse_minute_id', 'riga_timer5_7_2', 180, 0, 0);
        if ((!($("#timer5_lunedi").is(':checked'))) && (!($("#timer5_martedi").is(':checked'))) && (!($("#timer5_mercoledi").is(':checked'))) &&
            (!($("#timer5_giovedi").is(':checked')))&&(!($("#timer5_venerdi").is(':checked')))&&(!($("#timer5_sabato").is(':checked'))) &&
            (!($("#timer5_domenica").is(':checked')))) {
            checked_t5 = true;
            timer5_str = "Timer5,";
        }

    }
    if ((checked_t5) || (checked_t4) || (checked_t3) || (checked_t2)) {
        $('#save_timer_new').next('p').remove();

        $('#save_timer_new').after('<p class="error help-block"><span class="label label-important">Day Of Week '+timer2_str+timer3_str+timer4_str+timer5_str+'</span></p>');
        submit_status = false;
        return false;

    }
    if ((var_timer1_start) || (var_timer1_stop) || (var_timer1_gg) || (var_timer1_pulse_minute) || (var_timer2_pulse_minute) || (var_timer3_pulse_minute) || (var_timer4_pulse_minute) || (var_timer5_pulse_minute) ||
        (var_timer2_1_start) || (var_timer2_1_stop) || (var_timer2_2_start) || (var_timer2_2_stop) || (var_timer2_3_start) || (var_timer2_3_stop) || (var_timer2_4_start) || (var_timer2_4_stop) || (var_timer2_5_start) || (var_timer2_5_stop) ||
        (var_timer3_1_start) || (var_timer3_1_stop) || (var_timer3_2_start) || (var_timer3_2_stop) || (var_timer3_3_start) || (var_timer3_3_stop) || (var_timer3_4_start) || (var_timer3_4_stop) || (var_timer3_5_start) || (var_timer3_5_stop) ||
        (var_timer4_1_start) || (var_timer4_1_stop) || (var_timer4_2_start) || (var_timer4_2_stop) || (var_timer4_3_start) || (var_timer4_3_stop) || (var_timer4_4_start) || (var_timer4_4_stop) || (var_timer4_5_start) || (var_timer4_5_stop) ||
        (var_timer5_1_start) || (var_timer5_1_stop) || (var_timer5_2_start) || (var_timer5_2_stop) || (var_timer5_3_start) || (var_timer5_3_stop) || (var_timer5_4_start) || (var_timer5_4_stop) || (var_timer5_5_start) || (var_timer5_5_stop)
        ) {
        $('#save_timer_new').next('p').remove();

        $('#save_timer_new').after('<p class="error help-block"><span class="label label-important">' + wrong_settings + ' </span></p>');
        submit_status = false;
        error_general = false;

        return false;

    }

    submit_status = true;
    error_general = true;
    notification['confirm'] = modify_plant;
    notification['annulla'] = annulla_impianto;
});
//END GESTIONE SALVATAGGIO DATI
    //----------------END GESTIONE TIMER
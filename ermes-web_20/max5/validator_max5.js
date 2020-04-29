var var_alarm_aa_on = false;
var var_alarm_aa_perc1 = false;
var var_alarm_aa_off = false;
var var_alarm_aa_perc2 = false;

var var_alarm_ab_on = false;
var var_alarm_ab_perc1 = false;
var var_alarm_ab_off = false;
var var_alarm_ab_perc2 = false;

var var_alarm_pa_on = false;
var var_alarm_pa_perc1 = false;
var var_alarm_pa_off = false;
var var_alarm_pa_perc2 = false;

var var_alarm_pb_on = false;
var var_alarm_pb_perc1 = false;
var var_alarm_pb_off = false;
var var_alarm_pb_perc2 = false;

var var_alarm_ma_on = false;
var var_alarm_ma_perc1 = false;
var var_alarm_ma_off = false;
var var_alarm_ma_perc2 = false;

var var_alarm_aa1 = false;
var var_alarm_ab1 = false;

var var_alarm_ad_ore = false;
var var_alarm_ad_min = false;

var var_alarm_ar_ore = false;
var var_alarm_ar_min = false;

var var_alarm_ch1_calibration = false;
var var_alarm_ch2_calibration = false;
var var_alarm_ch3_calibration = false;
var var_alarm_ch4_calibration = false;
var var_alarm_ch5_calibration = false;

var var_log_start_h = false;
var var_log_start_m = false;
var var_log_every_h = false;
var var_log_every_m = false;
var var_log_filter_m = false;

var var_clean_cycle_h = false;
var var_clean_cycle_m = false;
var var_clean_clean_m = false;
var var_clean_clean_s = false;
var var_clean_restore_m = false;

var var_flow_rate = false;
var var_flow_low = false;
var var_flow_ma = false;

var alarmsetup_timed_min = false;
var alarmsetup_timed_sec = false;

var delay_min = false;
var tau_const = false;

var error_general = false;

//------------------------------------------------------------
//---CONTROLLO RELAY A E RELAY B------------------------------
//------------------------------------------------------------
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
    if ((isNaN(myNumber))||(myNumber > max_ch) || (myNumber < min_ch)) {
        $(id_1).removeClass('error');
        $(id).next('p').remove();

        $(id).after('<p class="error help-block"><span class="label label-important">'+ range +' ' + min_ch + ' - ' + max_ch + '</span></p>');
        $(id_1).addClass('error')
        var_alarm = true
    }
    switch (id1) {
//--- DA
        case "value_on_aa_id":
            var_alarm_aa_on = var_alarm;
            check_alarm_channel_aa();
            break;

        case "value_perc1_aa_id":
            var_alarm_aa_perc1 = var_alarm;
            check_alarm_channel_aa();
            break;

        case "value_off_aa_id":
            var_alarm_aa_off = var_alarm;
            check_alarm_channel_aa();
            break;

        case "value_perc2_aa_id":
            var_alarm_aa_perc2 = var_alarm;
            check_alarm_channel_aa();
            break;
//--- end DA
//--- DB
        case "value_on_ab_id":
            var_alarm_ab_on = var_alarm;
            check_alarm_channel_ab();
            break;

        case "value_perc1_ab_id":
            var_alarm_ab_perc1 = var_alarm;
            check_alarm_channel_ab();
            break;

        case "value_off_ab_id":
            var_alarm_ab_off = var_alarm;
            check_alarm_channel_ab();
            break;

        case "value_perc2_ab_id":
            var_alarm_ab_perc2 = var_alarm;
            check_alarm_channel_ab();
            break;
//--- end DB
//--- PA
        case "value_on_pa_id":
            var_alarm_pa_on = var_alarm;
            check_alarm_channel_pa();
            break;

        case "value_perc1_pa_id":
            var_alarm_pa_perc1 = var_alarm;
            check_alarm_channel_pa();
            break;

        case "value_off_pa_id":
            var_alarm_pa_off = var_alarm;
            check_alarm_channel_pa();
            break;

        case "value_perc2_pa_id":
            var_alarm_pa_perc2 = var_alarm;
            check_alarm_channel_pa();
            break;
//--- end PA
//--- PB
        case "value_on_pb_id":
            var_alarm_pb_on = var_alarm;
            check_alarm_channel_pb();
            break;

        case "value_perc1_pb_id":
            var_alarm_pb_perc1 = var_alarm;
            check_alarm_channel_pb();
            break;

        case "value_off_pb_id":
            var_alarm_pb_off = var_alarm;
            check_alarm_channel_pb();
            break;

        case "value_perc2_pb_id":
            var_alarm_pb_perc2 = var_alarm;
            check_alarm_channel_pb();
            break;
//end PB
//--- mA
        case "value_on_ma_id":
            var_alarm_ma_on = var_alarm;
            check_alarm_channel_ma();
            break;

        case "value_perc1_ma_id":
            var_alarm_ma_perc1 = var_alarm;
            check_alarm_channel_ma();
            break;

        case "value_off_ma_id":
            var_alarm_ma_off = var_alarm;
            check_alarm_channel_ma();
            break;

        case "value_perc2_ma_id":
            var_alarm_ma_perc2 = var_alarm;
            check_alarm_channel_ma();
            break;
//end mA
//--- Alarm A
        case "value_alarm_aa1_id":
            var_alarm_aa1 = var_alarm;
            check_alarm_aa1();
            break;

//--- end Alarm A
        //--- Alarm b
        case "value_alarm_ab1_id":
            var_alarm_ab1 = var_alarm;
            check_alarm_ab1();
            break;

            //--- end Alarm b
            //--- Alarm Ad
        case "value_alarm_ore_ad_id":
            var_alarm_ad_ore = var_alarm;
            check_alarm_ad();
            break;
        case "value_alarm_min_ad_id":
            var_alarm_ad_min = var_alarm;
            check_alarm_ad();
            break;

            //--- end Alarm Ad
            //--- Alarm Ar
        case "value_alarm_ore_ar_id":
            var_alarm_ar_ore = var_alarm;
            check_alarm_ar();
            break;
        case "value_alarm_min_ar_id":
            var_alarm_ar_min = var_alarm;
            check_alarm_ar();
            break;

            //--- end Alarm Ar
            // sezione calibrazione
        case "ch1_new_value":
            var_alarm_ch1_calibration = var_alarm;
            break;
        case "ch2_new_value":
            var_alarm_ch2_calibration = var_alarm;
            break;
        case "ch3_new_value":
            var_alarm_ch3_calibration = var_alarm;
            break;
        case "ch4_new_value":
            var_alarm_ch4_calibration = var_alarm;
            break;
        case "ch5_new_value":
            var_alarm_ch5_calibration = var_alarm;
            break;

            //end sezione calibrazione
            // sezione option
            // sezione option, log setup
        case "value_start_hr_id":
            var_log_start_h = var_alarm;
            check_alarm_logsetup();
            break;
        case "value_start_min_id":
            var_log_start_m = var_alarm;
            check_alarm_logsetup();
            break;
        case "value_every_hr_id":
            var_log_every_h = var_alarm;
            check_alarm_logsetup();
            break;
        case "value_every_min_id":
            var_log_every_m = var_alarm;
            check_alarm_logsetup();
            break;
        case "value_filter_min_id":
            var_log_filter_m = var_alarm;
            check_alarm_logsetup();
            break;
            // end sezione option, log setup
            // sezione option, probe clean
        case "value_cycle_hr_id":
            var_clean_cycle_h = var_alarm;
            check_alarm_cleansetup();
            break;
        case "value_cycle_min_id":
            var_clean_cycle_m = var_alarm;
            check_alarm_cleansetup();
            break;
        case "value_cleant_hr_id":
            var_clean_clean_m = var_alarm;
            check_alarm_cleansetup();
            break;
        case "value_cleant_min_id":
            var_clean_clean_s = var_alarm;
            check_alarm_cleansetup();
            break;
        case "value_restore_min_id":
            var_clean_restore_m = var_alarm;
            check_alarm_cleansetup();
            break;
            // end sezione option, probe clean
            // sezione option, flow meter
        case "value_flow_rate_id":
            var_flow_rate = var_alarm;
            check_alarm_flowrate();
            break;
        case "value_flow_setpoint_id":
            var_flow_low = var_alarm;
            check_alarm_flowrate();
            break;
        case "value_flow_ma_id":
            var_flow_ma = var_alarm;
            check_alarm_flowrate();
            break;
            // end sezione option, flow meter
            // sezione option, alarm setup
        case "value_timed_min_id":
            if ($('#continuous_id').is(':checked')) { // allarme continuo
                alarmsetup_timed_min = false;
            }
            if ($('#timed_id').is(':checked')) { // allarme timed
                alarmsetup_timed_min = var_alarm;
            }
            check_alarm_alarmsetup();
            break;
        case "value_timed_sec_id":
            if ($('#continuous_id').is(':checked')) { // allarme continuo
                alarmsetup_timed_sec = false;
            }
            if ($('#timed_id').is(':checked')) { // allarme timed
                alarmsetup_timed_sec = var_alarm;
            }
            check_alarm_alarmsetup();
            break;
            // end sezione option, alarm setup
            // sezione option, delay
        case "value_delay_min_id":
            delay_min = var_alarm;
            check_alarm_alarmsetup();
            break;
            // end sezione option, delay
        // sezione option, tau
        case "value_tau_const_id":
            tau_const = var_alarm;
            check_alarm_alarmsetup();
            break;
            // end sezione option, tau

            // end sezione option
    }
}
//------------------------------------------------------------
//---END CONTROLLO RELAY A E RELAY B------------------------------
//------------------------------------------------------------
//calibrazione
function enable_channel_calibrazione(numero_canali) {
    switch (numero_canali) {
        case 1: // 1 solo canale
            $("#div_ch2").hide();
            $("#div_ch3").hide();
            $("#div_ch4").hide();
            $("#div_ch5").hide();
            break;
        case 2: // 2 solo canale
            $("#div_ch3").hide();
            $("#div_ch4").hide();
            $("#div_ch5").hide();
            break;
        case 3: // 3 solo canale
            $("#div_ch4").hide();
            $("#div_ch5").hide();
            break;
        case 4: // 4 solo canale
            $("#div_ch5").hide();
            break;
        case 5: // 5 solo canale
            break;

    }
}
                        //end calibrazione
//------------------------------------------------------------
//---ERRORI RELAY AA------------------------------
//------------------------------------------------------------

function check_alarm_channel_aa() {
    if ((var_alarm_aa_on == true) || (var_alarm_aa_perc1 == true) || (var_alarm_aa_off == true) || (var_alarm_aa_perc2 == true)) {
        $("#tab_1").attr('style', 'color:#b94a48');
    }
    else {
        $("#tab_1").removeAttr('style');
    }
}
//------------------------------------------------------------
//---END ERRORI RELAY AA------------------------------
//------------------------------------------------------------
//------------------------------------------------------------
//---ERRORI RELAY AB------------------------------
//------------------------------------------------------------

function check_alarm_channel_ab() {
    if ((var_alarm_ab_on == true) || (var_alarm_ab_perc1 == true) || (var_alarm_ab_off == true) || (var_alarm_ab_perc2 == true)) {
        $("#tab_2").attr('style', 'color:#b94a48');
    }
    else {
        $("#tab_2").removeAttr('style');
    }
}
//------------------------------------------------------------
//---END ERRORI RELAY AB------------------------------
//------------------------------------------------------------

//------------------------------------------------------------
//---ERRORI PULSE PA------------------------------
//------------------------------------------------------------

function check_alarm_channel_pa() {
    if ((var_alarm_pa_on == true) || (var_alarm_pa_perc1 == true) || (var_alarm_pa_off == true) || (var_alarm_pa_perc2 == true)) {
        $("#tab_3").attr('style', 'color:#b94a48');
    }
    else {
        $("#tab_3").removeAttr('style');
    }
}
//------------------------------------------------------------
//---END ERRORI PULKSE PA------------------------------
//------------------------------------------------------------
//------------------------------------------------------------
//---ERRORI PULSE PB------------------------------
//------------------------------------------------------------

function check_alarm_channel_pb() {
    if ((var_alarm_pb_on == true) || (var_alarm_pb_perc1 == true) || (var_alarm_pb_off == true) || (var_alarm_pb_perc2 == true)) {
        $("#tab_4").attr('style', 'color:#b94a48');
    }
    else {
        $("#tab_4").removeAttr('style');
    }
}
//------------------------------------------------------------
//---END ERRORI PULKSE PA------------------------------
//------------------------------------------------------------
//------------------------------------------------------------
//---ERRORI PULSE mA------------------------------
//------------------------------------------------------------

function check_alarm_channel_ma() {
    if ((var_alarm_ma_on == true) || (var_alarm_ma_perc1 == true) || (var_alarm_ma_off == true) || (var_alarm_ma_perc2 == true)) {
        $("#tab_5").attr('style', 'color:#b94a48');
    }
    else {
        $("#tab_5").removeAttr('style');
    }
}
//------------------------------------------------------------
//---END ERRORI PULKSE mA------------------------------
//------------------------------------------------------------
//------------------------------------------------------------
//---ERRORI Alarm a------------------------------
//------------------------------------------------------------

function check_alarm_aa1() {
    if ((var_alarm_aa1 == true)) {
        $("#tab_6").attr('style', 'color:#b94a48');
    }
    else {
        $("#tab_6").removeAttr('style');
    }
}
//------------------------------------------------------------
//---END ERRORI Alarm A------------------------------
//------------------------------------------------------------
//------------------------------------------------------------
//---ERRORI Alarm b------------------------------
//------------------------------------------------------------

function check_alarm_ab1() {
    if ((var_alarm_ab1 == true)) {
        $("#tab_7").attr('style', 'color:#b94a48');
    }
    else {
        $("#tab_7").removeAttr('style');
    }
}
//------------------------------------------------------------
//---END ERRORI Alarm b------------------------------
//------------------------------------------------------------
//------------------------------------------------------------
//---ERRORI Alarm Ad------------------------------
//------------------------------------------------------------

function check_alarm_ad() {
    if ((var_alarm_ad_ore == true) || (var_alarm_ad_min == true)) {
        $("#tab_8").attr('style', 'color:#b94a48');
    }
    else {
        $("#tab_8").removeAttr('style');
    }
}
//------------------------------------------------------------
//---END ERRORI Alarm Ad------------------------------
//------------------------------------------------------------
//------------------------------------------------------------
//---ERRORI Alarm Ar------------------------------
//------------------------------------------------------------

function check_alarm_ar() {
    if ((var_alarm_ar_ore == true) || (var_alarm_ar_min == true)) {
        $("#tab_9").attr('style', 'color:#b94a48');
    }
    else {
        $("#tab_9").removeAttr('style');
    }
}
//------------------------------------------------------------
//---END ERRORI Alarm Ad------------------------------
//------------------------------------------------------------

//------------------------------------------------------------
//---ERRORI Alarm LOG SETUP------------------------------
//------------------------------------------------------------

function check_alarm_logsetup() {
    if ((var_log_start_h == true) || (var_log_start_m == true) || (var_log_every_h == true) || (var_log_every_m == true) || (var_log_filter_m == true)) {
        $("#tab_1_1").attr('style', 'color:#b94a48');
    }
    else {
        $("#tab_1_1").removeAttr('style');
    }
}
//------------------------------------------------------------
//---END ERRORI Alarm LOG SETUP-------------------------------
//------------------------------------------------------------
//------------------------------------------------------------
//---ERRORI Alarm clean SETUP------------------------------
//------------------------------------------------------------

function check_alarm_cleansetup() {
    if ((var_clean_cycle_h == true) || (var_clean_cycle_m == true) || (var_clean_clean_m == true) || (var_clean_clean_s == true) || (var_clean_restore_m == true)) {
        $("#tab_2_1").attr('style', 'color:#b94a48');
    }
    else {
        $("#tab_2_1").removeAttr('style');
    }
}
//------------------------------------------------------------
//---END ERRORI Alarm clean SETUP-------------------------------
//------------------------------------------------------------
//------------------------------------------------------------
//---ERRORI Alarm Flow Rate------------------------------
//------------------------------------------------------------
function check_alarm_flowrate() {
    if ((var_flow_rate == true) || (var_flow_low == true) || (var_flow_ma == true)) {
        $("#tab_3_1").attr('style', 'color:#b94a48');
    }
    else {
        $("#tab_3_1").removeAttr('style');
    }
}


//------------------------------------------------------------
//---end ERRORI Alarm Flow Rate------------------------------
//------------------------------------------------------------
//------------------------------------------------------------
//---ERRORI Alarm Alarm Setup------------------------------
//------------------------------------------------------------
function check_alarm_alarmsetup() {
    if ((alarmsetup_timed_min == true) || (alarmsetup_timed_sec == true) || (delay_min == true) || (tau_const == true)) {
        $("#tab_4_1").attr('style', 'color:#b94a48');
    }
    else {
        $("#tab_4_1").removeAttr('style');
    }
}


//------------------------------------------------------------
//---end ERRORI Alarm Alarm Setup------------------------------
//------------------------------------------------------------
//------------------------------------------------------------
//---ERRORI Alarm delay------------------------------
//------------------------------------------------------------


//------------------------------------------------------------
//---end ERRORI Alarm delay------------------------------
//------------------------------------------------------------


//------------------------------------------------------------
//---KEY PRESSED AA------------------------------
//------------------------------------------------------------

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

$("#value_on_aa_id").keypress(function (evt) {
    return keypress_channel(evt);
});

$("#value_perc1_aa_id").keypress(function (evt) {
    return keypress_perc(evt);
    });

$("#value_off_aa_id").keypress(function (evt) {
    return keypress_channel(evt);
});
$("#value_perc2_aa_id").keypress(function (evt) {
    return keypress_perc(evt);
});
//------------------------------------------------------------
//---END KEY PRESSED AA------------------------------
//------------------------------------------------------------
$("#value_flow_setpoint_id").keypress(function (evt) {
    return keypress_channel(evt);
});

$("#value_flow_ma_id").keypress(function (evt) {
    return keypress_channel(evt);
});
$("#value_flow_rate_id").keypress(function (evt) {
    return keypress_channel(evt);
});



//------------------------------------------------------------
//---KEY PRESSED Ab------------------------------
//------------------------------------------------------------

$("#value_on_ab_id").keypress(function (evt) {
    return keypress_channel(evt);
});

$("#value_perc1_ab_id").keypress(function (evt) {
    return keypress_perc(evt);
});

$("#value_off_ab_id").keypress(function (evt) {
    return keypress_channel(evt);
});
$("#value_perc2_ab_id").keypress(function (evt) {
    return keypress_perc(evt);
});
//------------------------------------------------------------
//---KEY PRESSED AB------------------------------
//------------------------------------------------------------
//------------------------------------------------------------
//---end KEY PRESSED PA------------------------------
//------------------------------------------------------------

$("#value_on_pa_id").keypress(function (evt) {
    return keypress_channel(evt);
});

$("#value_perc1_pa_id").keypress(function (evt) {
    return keypress_perc(evt);
});

$("#value_off_pa_id").keypress(function (evt) {
    return keypress_channel(evt);
});
$("#value_perc2_pa_id").keypress(function (evt) {
    return keypress_perc(evt);
});
//------------------------------------------------------------
//---end KEY PRESSED PA------------------------------
//------------------------------------------------------------
//------------------------------------------------------------
//---KEY PRESSED PB------------------------------
//------------------------------------------------------------

$("#value_on_pb_id").keypress(function (evt) {
    return keypress_channel(evt);
});

$("#value_perc1_pb_id").keypress(function (evt) {
    return keypress_perc(evt);
});

$("#value_off_pb_id").keypress(function (evt) {
    return keypress_channel(evt);
});
$("#value_perc2_pb_id").keypress(function (evt) {
    return keypress_perc(evt);
});
//------------------------------------------------------------
//---end KEY PRESSED PB------------------------------
//------------------------------------------------------------
//------------------------------------------------------------
//---KEY PRESSED mA------------------------------
//------------------------------------------------------------

$("#value_on_ma_id").keypress(function (evt) {
    return keypress_channel(evt);
});

$("#value_perc1_ma_id").keypress(function (evt) {
    return keypress_channel(evt);
});

$("#value_off_ma_id").keypress(function (evt) {
    return keypress_channel(evt);
});
$("#value_perc2_ma_id").keypress(function (evt) {
    return keypress_channel(evt);
});
//------------------------------------------------------------
//---end KEY PRESSED mA------------------------------
//------------------------------------------------------------
//------------------------------------------------------------
//---KEY PRESSED Alarm A------------------------------
//------------------------------------------------------------

$("#value_alarm_aa1_id").keypress(function (evt) {
    return keypress_channel(evt);
});
$("#value_aa1_delay").keypress(function (evt) {
    return keypress_perc(evt);
});

//------------------------------------------------------------
//---end KEY PRESSED Alarm A------------------------------
//------------------------------------------------------------
//------------------------------------------------------------
//---KEY PRESSED Alarm B------------------------------
//------------------------------------------------------------

$("#value_alarm_ab1_id").keypress(function (evt) {
    return keypress_channel(evt);
});
$("#value_ab1_delay").keypress(function (evt) {
    return keypress_perc(evt);
});

//------------------------------------------------------------
//---end KEY PRESSED Alarm B------------------------------
//------------------------------------------------------------
//------------------------------------------------------------
//---KEY PRESSED Alarm AD------------------------------
//------------------------------------------------------------

$("#value_alarm_ore_ad_id").keypress(function (evt) {
    return keypress_perc(evt);
});
$("#value_alarm_min_ad_id").keypress(function (evt) {
    return keypress_perc(evt);
});

//------------------------------------------------------------
//---end KEY PRESSED Alarm AD------------------------------
//------------------------------------------------------------
//------------------------------------------------------------
//---KEY PRESSED Alarm AR------------------------------
//------------------------------------------------------------

$("#value_alarm_ore_ar_id").keypress(function (evt) {
    return keypress_perc(evt);
});
$("#value_alarm_min_ar_id").keypress(function (evt) {
    return keypress_perc(evt);
});

//------------------------------------------------------------
//---end KEY PRESSED Alarm AR------------------------------
//------------------------------------------------------------

                                                                        // sezione calibrazione
//------------------------------------------------------------
//---KEY PRESSED ch1 value------------------------------
//------------------------------------------------------------

$("#ch1_new_value").keypress(function (evt) {
    return keypress_channel(evt);
});
$("#ch2_new_value").keypress(function (evt) {
    return keypress_channel(evt);
});
$("#ch3_new_value").keypress(function (evt) {
    return keypress_channel(evt);
});
$("#ch4_new_value").keypress(function (evt) {
    return keypress_channel(evt);
});
$("#ch5_new_value").keypress(function (evt) {
    return keypress_channel(evt);
});

//------------------------------------------------------------
//---end KEY PRESSED ch1 value------------------------------
//------------------------------------------------------------

                                                        // end sezione calibrazione
                                                        //sezione option
                                                        //sezione log setup
$("#value_start_hr_id").keypress(function (evt) {
    return keypress_perc(evt);
});
$("#value_start_min_id").keypress(function (evt) {
    return keypress_perc(evt);
});
$("#value_every_hr_id").keypress(function (evt) {
    return keypress_perc(evt);
});
$("#value_every_min_id").keypress(function (evt) {
    return keypress_perc(evt);
});
$("#value_filter_min_id").keypress(function (evt) {
    return keypress_perc(evt);
});
                                                        //endsezione log setup
                                                        //sezione probe clean
$("#value_cycle_hr_id").keypress(function (evt) {
    return keypress_perc(evt);
});
$("#value_cycle_min_id").keypress(function (evt) {
    return keypress_perc(evt);
});
$("#value_cleant_hr_id").keypress(function (evt) {
    return keypress_perc(evt);
});
$("#value_cleant_min_id").keypress(function (evt) {
    return keypress_perc(evt);
});
$("#value_restore_min_id").keypress(function (evt) {
    return keypress_perc(evt);
});
                                                       //end sezione general
//sezione probe clean
$("#value_timed_min_id").keypress(function (evt) {
    return keypress_perc(evt);
});
$("#value_timed_sec_id").keypress(function (evt) {
    return keypress_perc(evt);
});
$("#value_delay_min_id").keypress(function (evt) {
    return keypress_perc(evt);
});
$("#value_tau_const_id").keypress(function (evt) {
    return keypress_perc(evt);
});
//end sezione general

//end sezione option
//------------------------------------------------------------
//---DISABLE AA------------------------------
//------------------------------------------------------------

function disable_channel_aa() {
     var_alarm_aa_on = false;
     var_alarm_aa_perc1 = false;
     var_alarm_aa_off = false;
     var_alarm_aa_perc2 = false;
     check_alarm_channel_aa();
     remove_allarme('value_on_aa_id', 'riga_aa_1_1');
     remove_allarme('value_perc1_aa_id', 'riga_aa_1_2');
     remove_allarme('value_off_aa_id', 'riga_aa_2_1');
     remove_allarme('value_perc2_aa_id', 'riga_aa_2_2');
     $("#div_enable_aa").hide();
    }
    function enable_channel_aa() {
        $("#div_enable_aa").show();
    }

    $("#disable_aa").click(function () {
        disable_channel_aa();
        
    });
    $("#enable_aa").click(function () {
        enable_channel_aa();
    });
//------------------------------------------------------------
//---END DISABLE AA------------------------------
//------------------------------------------------------------
//------------------------------------------------------------
//---DISABLE AB------------------------------
//------------------------------------------------------------

    function disable_channel_ab() {
        var_alarm_ab_on = false;
        var_alarm_ab_perc1 = false;
        var_alarm_ab_off = false;
        var_alarm_ab_perc2 = false;
        check_alarm_channel_ab();
        remove_allarme('value_on_ab_id', 'riga_ab_1_1');
        remove_allarme('value_perc1_ab_id', 'riga_ab_1_2');
        remove_allarme('value_off_ab_id', 'riga_ab_2_1');
        remove_allarme('value_perc2_ab_id', 'riga_ab_2_2');
        $("#div_enable_ab").hide();
    }
    function enable_channel_ab() {
        $("#div_enable_ab").show();
    }

    $("#disable_ab").click(function () {
        disable_channel_ab();

    });
    $("#enable_ab").click(function () {
        enable_channel_ab();
    });
//------------------------------------------------------------
//---END DISABLE AB------------------------------
//------------------------------------------------------------
    //------------------------------------------------------------
    //---DISABLE PA------------------------------
    //------------------------------------------------------------

    function disable_channel_pa() {
        var_alarm_pa_on = false;
        var_alarm_pa_perc1 = false;
        var_alarm_pa_off = false;
        var_alarm_pa_perc2 = false;
        check_alarm_channel_pa();
         remove_allarme('value_on_pa_id', 'riga_pa_1_1');
         remove_allarme('value_perc1_pa_id', 'riga_pa_1_2');
         remove_allarme('value_off_pa_id', 'riga_pa_2_1');
         remove_allarme('value_perc2_pa_id', 'riga_pa_2_2');

        $("#div_enable_pa").hide();
    }
    function enable_channel_pa() {
        $("#div_enable_pa").show();
    }

    $("#disable_pa").click(function () {
        disable_channel_pa();

    });
    $("#enable_pa").click(function () {
        enable_channel_pa();
    });
    //------------------------------------------------------------
    //---END DISABLE PA------------------------------
    //------------------------------------------------------------
    //------------------------------------------------------------
    //---DISABLE PB------------------------------
    //------------------------------------------------------------

    function disable_channel_pb() {
        var_alarm_pb_on = false;
        var_alarm_pb_perc1 = false;
        var_alarm_pb_off = false;
        var_alarm_pb_perc2 = false;
        check_alarm_channel_pb();
        remove_allarme('value_on_pb_id', 'riga_pa_1_1');
        remove_allarme('value_perc1_pb_id', 'riga_pa_1_2');
        remove_allarme('value_off_pb_id', 'riga_pa_2_1');
        remove_allarme('value_perc2_pb_id', 'riga_pa_2_2');

        $("#div_enable_pb").hide();
    }
    function enable_channel_pb() {
        
        $("#div_enable_pb").show();
    }

    $("#disable_pb").click(function () {
        disable_channel_pb();

    });
    $("#enable_pb").click(function () {
        enable_channel_pb();
    });
    //------------------------------------------------------------
    //---END DISABLE PB------------------------------
    //------------------------------------------------------------
    //------------------------------------------------------------
    //---DISABLE ma------------------------------
    //------------------------------------------------------------

    function disable_channel_ma() {
        var_alarm_ma_on = false;
        var_alarm_ma_perc1 = false;
        var_alarm_ma_off = false;
        var_alarm_ma_perc2 = false;
        check_alarm_channel_ma();
        remove_allarme('value_on_ma_id', 'riga_pa_1_1');
        remove_allarme('value_perc1_ma_id', 'riga_pa_1_2');
        remove_allarme('value_off_ma_id', 'riga_pa_2_1');
        remove_allarme('value_perc2_ma_id', 'riga_pa_2_2');

        $("#div_enable_ma").hide();
    }
    function enable_channel_ma() {
        $("#div_enable_ma").show();
    }

    $("#disable_ma").click(function () {
        disable_channel_ma();

    });
    $("#enable_ma").click(function () {
        enable_channel_ma();
    });
    //------------------------------------------------------------
    //---END DISABLE ma------------------------------
    //------------------------------------------------------------
    //------------------------------------------------------------
    //---DISABLE Alarm A------------------------------
    //------------------------------------------------------------

    function disable_channel_aa1() {
        var_alarm_aa1 = false;
        check_alarm_aa1();
        remove_allarme('value_alarm_aa1_id', 'riga_aa1_1_1');
        $("#div_enable_aa1").hide();
    }
    function enable_channel_aa1() {
        $("#div_enable_aa1").show();
    }

    $("#disable_aa1").click(function () {
        disable_channel_aa1();

    });
    $("#enable_aa1").click(function () {
        enable_channel_aa1();
    });
    //------------------------------------------------------------
    //---END DISABLE Alarm A------------------------------
    //------------------------------------------------------------
    //------------------------------------------------------------
    //---DISABLE Alarm B------------------------------
    //------------------------------------------------------------

    function disable_channel_ab1() {
        var_alarm_ab1 = false;
        check_alarm_ab1();
        remove_allarme('value_alarm_ab1_id', 'riga_ab1_1_1');

        $("#div_enable_ab1").hide();
    }
    function enable_channel_ab1() {
        $("#div_enable_ab1").show();
    }

    $("#disable_ab1").click(function () {
        disable_channel_ab1();

    });
    $("#enable_ab1").click(function () {
        enable_channel_ab1();
    });
    //------------------------------------------------------------
    //---END DISABLE Alarm B------------------------------
    //------------------------------------------------------------
    //------------------------------------------------------------
    //---DISABLE Alarm AD------------------------------
    //------------------------------------------------------------

    function disable_channel_ad() {
        var_alarm_ad_ore = false;
        var_alarm_ad_min = false;
        check_alarm_ad();
        remove_allarme('value_alarm_ore_ad_id', 'riga_ad_1_1');
        remove_allarme('value_alarm_min_ad_id', 'riga_ad_1_2');
        $("#div_enable_ad").hide();
    }
    function enable_channel_ad() {
        $("#div_enable_ad").show();
    }

    $("#disable_ad").click(function () {
        disable_channel_ad();

    });
    $("#enable_ad").click(function () {
        enable_channel_ad();
    });
    //------------------------------------------------------------
    //---END DISABLE Alarm AD------------------------------
    //------------------------------------------------------------
    //------------------------------------------------------------
    //---DISABLE Alarm AR------------------------------
    //------------------------------------------------------------

    function disable_channel_ar() {
        var_alarm_ar_ore = false;
        var_alarm_ar_min = false;
        check_alarm_ar();
        remove_allarme('value_alarm_ore_ar_id', 'riga_ar_1_1');
        remove_allarme('value_alarm_min_ar_id', 'riga_ar_1_2');
        $("#div_enable_ar").hide();
    }
    function enable_channel_ar() {
        $("#div_enable_ar").show();
    }

    $("#disable_ar").click(function () {
        disable_channel_ar();

    });
    $("#enable_ar").click(function () {
        enable_channel_ar();
    });
    //------------------------------------------------------------
    //---END DISABLE Alarm AR------------------------------
    //------------------------------------------------------------
//------------------------------------------------------------
//---ON/OFF  AA------------------------------
//------------------------------------------------------------

    function enable_on_off_aa() {
        $("#percent_on_aa").hide();
        $("#percent_off_aa").hide();
    }

    $("#on_off_aa").click(function () {
        enable_on_off_aa();
    });
//------------------------------------------------------------
//---end ON/OFF  AA------------------------------
//------------------------------------------------------------
//------------------------------------------------------------
//---ON/OFF  AB------------------------------
//------------------------------------------------------------
    function enable_on_off_ab() {
        $("#percent_on_ab").hide();
        $("#percent_off_ab").hide();
    }

    $("#on_off_ab").click(function () {
        enable_on_off_ab();
    });
//------------------------------------------------------------
//---END ON/OFF  AB------------------------------
//------------------------------------------------------------
//------------------------------------------------------------
//---PWM  AA------------------------------
//------------------------------------------------------------

    function enable_pwm_aa() {
        $("#percent_on_aa").show();
        $("#percent_off_aa").show();
        $("#label_percent_aa_1").html("<h5 class='control-label' style='padding-top:10px'>PWM %</h5>");
        $("#label_percent_aa_2").html("<h5 class='control-label' style='padding-top:10px'>PWM %</h5>");
    }

    $("#pwm_aa").click(function () {
        enable_pwm_aa();
    });
//------------------------------------------------------------
//---END PWM  AA------------------------------
//------------------------------------------------------------
//------------------------------------------------------------
//---PWM  AB------------------------------
//------------------------------------------------------------

    function enable_pwm_ab() {
        $("#percent_on_ab").show();
        $("#percent_off_ab").show();
        $("#label_percent_ab_1").html("<h5 class='control-label' style='padding-top:10px'>PWM %</h5>");
        $("#label_percent_ab_2").html("<h5 class='control-label' style='padding-top:10px'>PWM %</h5>");
    }

    $("#pwm_ab").click(function () {
        enable_pwm_ab();
    });
//------------------------------------------------------------
//---end PWM  AB------------------------------
//------------------------------------------------------------
//------------------------------------------------------------
//---PID  AA------------------------------
//------------------------------------------------------------

    function enable_pid_aa() {
        $("#percent_on_aa").show();
        $("#percent_off_aa").show();
        $("#label_percent_aa_1").html("<h5 class='control-label' style='padding-top:10px'>Integral Min</h5>");
        $("#label_percent_aa_2").html("<h5 class='control-label' style='padding-top:10px'>Derivative Min</h5>");
    }
    $("#pid_aa").click(function () {
        enable_pid_aa();
    });
//------------------------------------------------------------
//---END PID  AA------------------------------
//------------------------------------------------------------
//------------------------------------------------------------
//---PID  AB------------------------------
//------------------------------------------------------------

    function enable_pid_ab() {
        $("#percent_on_ab").show();
        $("#percent_off_ab").show();
        $("#label_percent_ab_1").html("<h5 class='control-label' style='padding-top:10px'>Integral Min</h5>");
        $("#label_percent_ab_2").html("<h5 class='control-label' style='padding-top:10px'>Derivative Min</h5>");
    }
    $("#pid_ab").click(function () {
        enable_pid_ab();
    });
//------------------------------------------------------------
//---END PID  AB------------------------------
//------------------------------------------------------------

    //------------------------------------------------------------
    //---DISABLE OPTION------------------------------
    //------------------------------------------------------------
//------------------------------------------------------------
//---DISABLE LOG SETUP------------------------------
//------------------------------------------------------------

    function disable_log_setup() {
        var_log_start_h = false;
        var_log_start_m = false;
        var_log_every_h = false;
        var_log_every_m = false;
        var_log_filter_m = false;
        check_alarm_logsetup();
        remove_allarme('value_start_hr_id', 'riga_log_1_1');
        remove_allarme('value_start_min_id', 'riga_log_1_2');
        remove_allarme('value_every_hr_id', 'riga_log_2_1');
        remove_allarme('value_every_min_id', 'riga_log_2_2');
        remove_allarme('value_filter_min_id', 'riga_log_3_1');
        $("#div_enable_log").hide();
    }
    function enable_log_setup() {
        $("#div_enable_log").show();
    }

    $("#disable_log").click(function () {
        disable_log_setup();

    });
    $("#enable_log").click(function () {
        enable_log_setup();
    });
//------------------------------------------------------------
//---end DISABLE log setup------------------------------
//------------------------------------------------------------
    //------------------------------------------------------------
    //---DISABLE probe clean------------------------------
    //------------------------------------------------------------

    function disable_probe_clean() {
        var_clean_cycle_h = false;
        var_clean_cycle_m = false;
        var_clean_clean_m = false;
        var_clean_clean_s = false;
        var_clean_restore_m = false;
        check_alarm_cleansetup();
        remove_allarme('value_cycle_hr_id', 'riga_clean_1_1');
        remove_allarme('value_cycle_min_id', 'riga_clean_1_2');
        remove_allarme('value_cleant_hr_id', 'riga_clean_2_1');
        remove_allarme('value_cleant_min_id', 'riga_clean_2_2');
        remove_allarme('value_restore_min_id', 'riga_clean_3_1');
        $("#div_enable_clean").hide();
    }
    function enable_probe_clean() {
        $("#div_enable_clean").show();
    }

    $("#disable_clean").click(function () {
        disable_probe_clean();

    });
    $("#enable_clean").click(function () {
        enable_probe_clean();
    });
    //------------------------------------------------------------
    //---end DISABLE probe clean------------------------------
    //------------------------------------------------------------
//------------------------------------------------------------
//---ALARM SETUP------------------------------
    //-----------------------------------------------------------

    $("#continuous_id").click(function () {
        alarmsetup_timed_min = false;
        alarmsetup_timed_sec = false;
        remove_allarme('value_timed_min_id', 'riga_alarm_timed_min');
        remove_allarme('value_timed_sec_id', 'riga_alarm_timed_sec');
    });

//------------------------------------------------------------
//---END ALARM SETUP------------------------------
//------------------------------------------------------------

    //------------------------------------------------------------
    //---END DISABLE OPTION------------------------------
    //------------------------------------------------------------

// ------------------------ SEZIONE TIMER


// ------------------------ END SEZIONE TIMER
//------------------------------------------------------------
//---REMOVE CONTROL ERROR  AA------------------------------
//------------------------------------------------------------

    $("#value_on_aa_id").click(function () {
        //$(this).val("");
        $(this).next('p').remove();
        $("#riga_aa_1_1").removeClass('error');
        var_alarm_aa_on = false;
        check_alarm_channel_aa();
        // $("#principale").load("test.aspx");
    });
    $("#value_perc1_aa_id").click(function () {
        //$(this).val("");
        $(this).next('p').remove();
        $("#riga_aa_1_2").removeClass('error');
        var_alarm_aa_perc1 = false;
        check_alarm_channel_aa();
        // $("#principale").load("test.aspx");
    });

    
    $("#value_off_aa_id").click(function () {
        //$(this).val("");
        $(this).next('p').remove();
        $("#riga_aa_2_1").removeClass('error');
        var_alarm_aa_off = false;
        check_alarm_channel_aa();
        // $("#principale").load("test.aspx");
    });
    $("#value_perc2_aa_id").click(function () {
        //$(this).val("");
        $(this).next('p').remove();
        $("#riga_aa_2_2").removeClass('error');
        var_alarm_aa_perc2 = false;
        check_alarm_channel_aa();
        // $("#principale").load("test.aspx");
    });
//------------------------------------------------------------
//---END REMOVE CONTROL ERROR  AA------------------------------
//------------------------------------------------------------
    //------------------------------------------------------------
    //---REMOVE CONTROL ERROR  AB------------------------------
    //------------------------------------------------------------

    $("#value_on_ab_id").click(function () {
        //$(this).val("");
        $(this).next('p').remove();
        $("#riga_ab_1_1").removeClass('error');
        var_alarm_ab_on = false;
        check_alarm_channel_ab();
        // $("#principale").load("test.aspx");
    });
    $("#value_perc1_ab_id").click(function () {
        //$(this).val("");
        $(this).next('p').remove();
        $("#riga_ab_1_2").removeClass('error');
        var_alarm_ab_perc1 = false;
        check_alarm_channel_ab();
        // $("#principale").load("test.aspx");
    });


    $("#value_off_ab_id").click(function () {
        //$(this).val("");
        $(this).next('p').remove();
        $("#riga_ab_2_1").removeClass('error');
        var_alarm_ab_off = false;
        check_alarm_channel_ab();
        // $("#principale").load("test.aspx");
    });
    $("#value_perc2_ab_id").click(function () {
        //$(this).val("");
        $(this).next('p').remove();
        $("#riga_ab_2_2").removeClass('error');
        var_alarm_ab_perc2 = false;
        check_alarm_channel_ab();
        // $("#principale").load("test.aspx");
    });
    //------------------------------------------------------------
    //---END REMOVE CONTROL ERROR  AB------------------------------
//------------------------------------------------------------
    //------------------------------------------------------------
    //---REMOVE CONTROL ERROR  PA------------------------------
    //------------------------------------------------------------

    $("#value_on_pa_id").click(function () {
        //$(this).val("");
        $(this).next('p').remove();
        $("#riga_pa_1_1").removeClass('error');
        var_alarm_pa_on = false;
        check_alarm_channel_pa();
        // $("#principale").load("test.aspx");
    });
    $("#value_perc1_pa_id").click(function () {
        //$(this).val("");
        $(this).next('p').remove();
        $("#riga_pa_1_2").removeClass('error');
        var_alarm_pa_perc1 = false;
        check_alarm_channel_pa();
        // $("#principale").load("test.aspx");
    });


    $("#value_off_pa_id").click(function () {
        //$(this).val("");
        $(this).next('p').remove();
        $("#riga_pa_2_1").removeClass('error');
        var_alarm_pa_off = false;
        check_alarm_channel_pa();
        // $("#principale").load("test.aspx");
    });
    $("#value_perc2_pa_id").click(function () {
        //$(this).val("");
        $(this).next('p').remove();
        $("#riga_pa_2_2").removeClass('error');
        var_alarm_pa_perc2 = false;
        check_alarm_channel_pa();
        // $("#principale").load("test.aspx");
    });
    //------------------------------------------------------------
    //---END REMOVE CONTROL ERROR  PA------------------------------
//------------------------------------------------------------
    //------------------------------------------------------------
    //---REMOVE CONTROL ERROR  PB------------------------------
    //------------------------------------------------------------

    $("#value_on_pb_id").click(function () {
        //$(this).val("");
        $(this).next('p').remove();
        $("#riga_pb_1_1").removeClass('error');
        var_alarm_pb_on = false;
        check_alarm_channel_pb();
        // $("#principale").load("test.aspx");
    });
    $("#value_perc1_pb_id").click(function () {
        //$(this).val("");
        $(this).next('p').remove();
        $("#riga_pb_1_2").removeClass('error');
        var_alarm_pb_perc1 = false;
        check_alarm_channel_pb();
        // $("#principale").load("test.aspx");
    });


    $("#value_off_pb_id").click(function () {
        //$(this).val("");
        $(this).next('p').remove();
        $("#riga_pb_2_1").removeClass('error');
        var_alarm_pb_off = false;
        check_alarm_channel_pb();
        // $("#principale").load("test.aspx");
    });
    $("#value_perc2_pb_id").click(function () {
        //$(this).val("");
        $(this).next('p').remove();
        $("#riga_pb_2_2").removeClass('error');
        var_alarm_pb_perc2 = false;
        check_alarm_channel_pb();
        // $("#principale").load("test.aspx");
    });
    //------------------------------------------------------------
    //---END REMOVE CONTROL ERROR  PB------------------------------
    //------------------------------------------------------------
    //------------------------------------------------------------
    //---REMOVE CONTROL ERROR  ma------------------------------
    //------------------------------------------------------------

    $("#value_on_ma_id").click(function () {
        //$(this).val("");
        $(this).next('p').remove();
        $("#riga_ma_1_1").removeClass('error');
        var_alarm_ma_on = false;
        check_alarm_channel_ma();
        // $("#principale").load("test.aspx");
    });
    $("#value_perc1_ma_id").click(function () {
        //$(this).val("");
        $(this).next('p').remove();
        $("#riga_ma_1_2").removeClass('error');
        var_alarm_ma_perc1 = false;
        check_alarm_channel_ma();
        // $("#principale").load("test.aspx");
    });


    $("#value_off_ma_id").click(function () {
        //$(this).val("");
        $(this).next('p').remove();
        $("#riga_ma_2_1").removeClass('error');
        var_alarm_ma_off = false;
        check_alarm_channel_ma();
        // $("#principale").load("test.aspx");
    });
    $("#value_perc2_ma_id").click(function () {
        //$(this).val("");
        $(this).next('p').remove();
        $("#riga_ma_2_2").removeClass('error');
        var_alarm_ma_perc2 = false;
        check_alarm_channel_ma();
        // $("#principale").load("test.aspx");
    });
    //------------------------------------------------------------
    //---END REMOVE CONTROL ERROR  ma------------------------------
//------------------------------------------------------------
    //------------------------------------------------------------
    //---REMOVE CONTROL ERROR  Alarm A------------------------------
    //------------------------------------------------------------

    $("#value_alarm_aa1_id").click(function () {
        //$(this).val("");
        $(this).next('p').remove();
        $("#riga_aa1_1_1").removeClass('error');
        var_alarm_aa1 = false;
        check_alarm_aa1();
        // $("#principale").load("test.aspx");
    });

    //------------------------------------------------------------
    //---END REMOVE CONTROL ERROR  Alarm A------------------------------
    //------------------------------------------------------------
    //------------------------------------------------------------
    //---REMOVE CONTROL ERROR  Alarm B------------------------------
    //------------------------------------------------------------

    $("#value_alarm_ab1_id").click(function () {
        //$(this).val("");
        $(this).next('p').remove();
        $("#riga_ab1_1_1").removeClass('error');
        var_alarm_ab1 = false;
        check_alarm_ab1();
        // $("#principale").load("test.aspx");
    });

    //------------------------------------------------------------
    //---END REMOVE CONTROL ERROR  Alarm B------------------------------
    //------------------------------------------------------------
    //------------------------------------------------------------
    //---REMOVE CONTROL ERROR  Alarm Ad------------------------------
    //------------------------------------------------------------

    $("#value_alarm_ore_ad_id").click(function () {
        //$(this).val("");
        $(this).next('p').remove();
        $("#riga_ad_1_1").removeClass('error');
        var_alarm_ad_ore = false;
        check_alarm_ad();
        // $("#principale").load("test.aspx");
    });
    $("#value_alarm_min_ad_id").click(function () {
        //$(this).val("");
        $(this).next('p').remove();
        $("#riga_ad_1_2").removeClass('error');
        var_alarm_ad_min = false;
        check_alarm_ad();
        // $("#principale").load("test.aspx");
    });

    //------------------------------------------------------------
    //---END REMOVE CONTROL ERROR  Alarm Ad------------------------------
    //------------------------------------------------------------
    //------------------------------------------------------------
    //---REMOVE CONTROL ERROR  Alarm Ar------------------------------
    //------------------------------------------------------------

    $("#value_alarm_ore_ar_id").click(function () {
        //$(this).val("");
        $(this).next('p').remove();
        $("#riga_ar_1_1").removeClass('error');
        var_alarm_ar_ore = false;
        check_alarm_ar();
        // $("#principale").load("test.aspx");
    });
    $("#value_alarm_min_ar_id").click(function () {
        //$(this).val("");
        $(this).next('p').remove();
        $("#riga_ad_1_2").removeClass('error');
        var_alarm_ar_min = false;
        check_alarm_ar();
        // $("#principale").load("test.aspx");
    });

    //------------------------------------------------------------
    //---END REMOVE CONTROL ERROR  Alarm Ar------------------------------
    //------------------------------------------------------------
                                                //SEZIONE CALIBRAZIONEù
    $("#ch1_new_value").click(function () {
        //$(this).val("");
        $(this).next('p').remove();
        $("#div_ch1_1").removeClass('error');
        var_alarm_ch1_calibration = false;
        // $("#principale").load("test.aspx");
        $("#ch1_probe_enale").prop('checked', true);
    });
    $("#ch2_new_value").click(function () {
        //$(this).val("");
        $(this).next('p').remove();
        $("#div_ch2_1").removeClass('error');
        var_alarm_ch2_calibration = false;
        $("#ch2_probe_enale").prop('checked', true);
        // $("#principale").load("test.aspx");
    });

    $("#ch3_new_value").click(function () {
        //$(this).val("");
        $(this).next('p').remove();
        $("#div_ch3_1").removeClass('error');
        var_alarm_ch3_calibration = false;
        $("#ch3_probe_enale").prop('checked', true);
        // $("#principale").load("test.aspx");
    });
    $("#ch4_new_value").click(function () {
        //$(this).val("");
        $(this).next('p').remove();
        $("#div_ch4_1").removeClass('error');
        var_alarm_ch4_calibration = false;
        $("#ch4_probe_enale").prop('checked', true);
        // $("#principale").load("test.aspx");
    });
    $("#ch5_new_value").click(function () {
        //$(this).val("");
        $(this).next('p').remove();
        $("#div_ch5_1").removeClass('error');
        var_alarm_ch5_calibration = false;
        $("#ch5_probe_enale").prop('checked', true);
        // $("#principale").load("test.aspx");
    });

// END SEZIONE CALIBRAZIONE
//SEZIONE OPTION
//SEZIONE OPTION LOG SETUP
    $("#value_start_hr_id").click(function () {
        //$(this).val("");
        $(this).next('p').remove();
        $("#riga_log_1_1").removeClass('error');
        var_log_start_h = false;
        // $("#principale").load("test.aspx");
    });
    $("#value_start_min_id").click(function () {
        //$(this).val("");
        $(this).next('p').remove();
        $("#riga_log_1_2").removeClass('error');
        var_log_start_m = false;
        // $("#principale").load("test.aspx");
    });

    $("#value_every_hr_id").click(function () {
        //$(this).val("");
        $(this).next('p').remove();
        $("#riga_log_2_1").removeClass('error');
        var_log_every_h = false;
        // $("#principale").load("test.aspx");
    });
    $("#value_every_min_id").click(function () {
        //$(this).val("");
        $(this).next('p').remove();
        $("#riga_log_2_2").removeClass('error');
        var_log_every_m = false;
        // $("#principale").load("test.aspx");
    });
    $("#value_filter_min_id").click(function () {
        //$(this).val("");
        $(this).next('p').remove();
        $("#riga_log_3_1").removeClass('error');
        var_log_filter_m = false;
        // $("#principale").load("test.aspx");
    });

//END SEZIONE OPTION LOG SETUP
//SEZIONE OPTION probe clean
    $("#value_cycle_hr_id").click(function () {
        //$(this).val("");
        $(this).next('p').remove();
        $("#riga_clean_1_1").removeClass('error');
        var_clean_cycle_h = false;
        // $("#principale").load("test.aspx");
    });
    $("#value_cycle_min_id").click(function () {
        //$(this).val("");
        $(this).next('p').remove();
        $("#riga_clean_1_2").removeClass('error');
        var_clean_cycle_m = false;
        // $("#principale").load("test.aspx");
    });
    $("#value_cleant_hr_id").click(function () {
        //$(this).val("");
        $(this).next('p').remove();
        $("#riga_clean_2_1").removeClass('error');
        var_clean_clean_m = false;
        // $("#principale").load("test.aspx");
    });
    $("#value_cleant_min_id").click(function () {
        //$(this).val("");
        $(this).next('p').remove();
        $("#riga_clean_2_2").removeClass('error');
        var_clean_clean_s = false;
        // $("#principale").load("test.aspx");
    });
    $("#value_restore_min_id").click(function () {
        //$(this).val("");
        $(this).next('p').remove();
        $("#riga_clean_3_1").removeClass('error');
        var_clean_restore_m = false;
        // $("#principale").load("test.aspx");
    });

//END SEZIONE OPTION probe clean
    //SEZIONE OPTION general
    $("#value_timed_min_id").click(function () {
        //$(this).val("");
        $(this).next('p').remove();
        $("#riga_alarm_timed_min").removeClass('error');
        alarmsetup_timed_min = false;
        // $("#principale").load("test.aspx");
    });
    $("#value_timed_sec_id").click(function () {
        //$(this).val("");
        $(this).next('p').remove();
        $("#riga_alarm_timed_sec").removeClass('error');
        alarmsetup_timed_sec = false;
        // $("#principale").load("test.aspx");
    });
    $("#value_delay_min_id").click(function () {
        //$(this).val("");
        $(this).next('p').remove();
        $("#riga_delay_min").removeClass('error');
        delay_min = false;
        // $("#principale").load("test.aspx");
    });
    $("#value_tau_const_id").click(function () {
        //$(this).val("");
        $(this).next('p').remove();
        $("#riga_tau_const").removeClass('error');
        tau_const = false;
        // $("#principale").load("test.aspx");
    });
   

//END SEZIONE OPTION general

    // sezione option, flow meter
    $("#value_flow_rate_id").click(function () {
        //$(this).val("");
        $(this).next('p').remove();
        $("#riga_flow_1_1").removeClass('error');
        var_flow_rate = false;
        //check_alarm_flowrate();
        // $("#principale").load("test.aspx");
    });
    $("#value_flow_setpoint_id").click(function () {
        //$(this).val("");
        $(this).next('p').remove();
        $("#riga_flow_2_1").removeClass('error');
        var_flow_low = false;
        //check_alarm_flowrate();
        // $("#principale").load("test.aspx");
    });
    $("#value_flow_ma_id").click(function () {
        //$(this).val("");
        $(this).next('p').remove();
        $("#riga_flow_2_2").removeClass('error');
        var_flow_ma = false;
        //check_alarm_flowrate();
        // $("#principale").load("test.aspx");
    });
    // end sezione option, flow meter

//END SEZIONE OPTION
//------------------------------------------------------------
//---TAB CLICK CONTROL------------------------------
//------------------------------------------------------------
    $("#tab_1").click(function () {
        if ($('#enable_aa').is(':checked')) {
            enable_channel_aa();
        }
        else {
            disable_channel_aa();
        }
        if ($('#on_off_aa').is(':checked')) {
            enable_on_off_aa();
        }
        if ($('#on_pwm_aa').is(':checked')) {
            enable_pwm_aa();
        }
        if ($('#on_pid_aa').is(':checked')) {
            enable_pid_aa();
        }

    });
    $("#tab_2").click(function () {
        if ($('#enable_ab').is(':checked')) {
            enable_channel_ab();
        }
        else {
            disable_channel_ab();
        }

        if ($('#on_off_ab').is(':checked')) {
            enable_on_off_ab();
        }
        if ($('#on_pwm_ab').is(':checked')) {
            enable_pwm_ab();
        }
        if ($('#on_pid_ab').is(':checked')) {
            enable_pid_ab();
        }

    });
    $("#tab_3").click(function () {
        if ($('#enable_pa').is(':checked')) {
            enable_channel_pa();
        }
        else {
            disable_channel_pa();
        }
    });
    $("#tab_4").click(function () {
        if ($('#enable_pb').is(':checked')) {
            enable_channel_pb();
        }
        else {
            disable_channel_pb();
        }
    });
    $("#tab_5").click(function () {
        if (ma_enable == 1)// ma enabled
        {
            $("#tab_ma").show();
            if ($('#enable_ma').is(':checked')) {
                enable_channel_ma();
            }
            else {
                disable_channel_ma();
            }
        }
        else {
            $("#tab_ma").hide();
        }
    });
    $("#tab_6").click(function () {
        if ($('#enable_aa1').is(':checked')) {
            enable_channel_aa1();
        }
        else {
            disable_channel_aa1();
        }
    });
    $("#tab_7").click(function () {
        if ($('#enable_ab1').is(':checked')) {
            enable_channel_ab1();
        }
        else {
            disable_channel_ab1();
        }
    });
    $("#tab_8").click(function () {
        if ($('#enable_ad').is(':checked')) {
            enable_channel_ad();
        }
        else {
            disable_channel_ad();
        }
    });
    $("#tab_9").click(function () {
        if ($('#enable_ar').is(':checked')) {
            enable_channel_ar();
        }
        else {
            disable_channel_ar();
        }
    });
//OPTION
    $("#tab_1_1").click(function () {
        if ($('#enable_log').is(':checked')) {
            enable_log_setup();
        }
        else {
            disable_log_setup();
        }
    });
    $("#tab_2_1").click(function () {
        
        if ($('#enable_clean').is(':checked')) {
             enable_probe_clean();
        }
        else {
            
            disable_probe_clean();
        }
    });

//END OPTION
//------------------------------------------------------------
//---END TAB CLICK CONTROL------------------------------
//------------------------------------------------------------

//GESTIONE SALVATAGGIO DATI

    $("#save_setpoint_new").click(function () {

        if (enable_send_setpoint == false) {
            result_setpoint_change(user_setpoint_disable);
            return false;
        }

        $('#save_setpoint_new').next('p').remove();
        
        if ($('#enable_aa').is(':checked')) {
            Changed_channel('value_on_aa_id', 'riga_aa_1_1', max_ch_value, min_ch_value, max_fix_value);
            Changed_channel('value_off_aa_id', 'riga_aa_2_1', max_ch_value, min_ch_value, max_fix_value);
            if (($('#pwm_aa').is(':checked')) || ($('#pid_aa').is(':checked'))) {
                Changed_channel('value_perc1_aa_id', 'riga_aa_1_2', max_percent_value, min_percent_value, 0);
                Changed_channel('value_perc2_aa_id', 'riga_aa_2_2', max_percent_value, min_percent_value, 0);
            }
        }
        if ($('#enable_ab').is(':checked')) {
            Changed_channel('value_on_ab_id', 'riga_ab_1_1', max_ch_value, min_ch_value, max_fix_value);
            Changed_channel('value_off_ab_id', 'riga_ab_2_1', max_ch_value, min_ch_value, max_fix_value);
            if (($('#pwm_ab').is(':checked')) || ($('#pid_ab').is(':checked'))) {
                Changed_channel('value_perc1_ab_id', 'riga_ab_1_2', max_percent_value, min_percent_value, 0);
                Changed_channel('value_perc2_ab_id', 'riga_ab_2_2', max_percent_value, min_percent_value, 0);
            }
        }
        if ($('#enable_pa').is(':checked')) {
            Changed_channel('value_on_pa_id', 'riga_pa_1_1', max_ch_value, min_ch_value, max_fix_value);
            Changed_channel('value_perc1_pa_id', 'riga_pa_1_2', max_pulse_value, min_pulse_value, 0);
            Changed_channel('value_off_pa_id', 'riga_pa_2_1', max_ch_value, min_ch_value, max_fix_value);
            Changed_channel('value_perc2_pa_id', 'riga_pa_2_2', max_pulse_value, min_pulse_value, 0);
        }
        if ($('#enable_pb').is(':checked')) {
            Changed_channel('value_on_pb_id', 'riga_pb_1_1', max_ch_value, min_ch_value, max_fix_value);
            Changed_channel('value_perc1_pb_id', 'riga_pb_1_2', max_pulse_value, min_pulse_value, 0);
            Changed_channel('value_off_pb_id', 'riga_pb_2_1', max_ch_value, min_ch_value, max_fix_value);
            Changed_channel('value_perc2_pb_id', 'riga_pb_2_2', max_pulse_value, min_pulse_value, 0);
        }
        if ($('#enable_ma').is(':checked')) {
            Changed_channel('value_on_ma_id', 'riga_ma_1_1', max_ch_value, min_ch_value, max_fix_value);
            //Changed_channel('value_perc1_ma_id', 'riga_ma_1_2', max_pulse_value, min_pulse_value, 0);
            Changed_channel('value_perc1_ma_id', 'riga_ma_1_2', max_ma_value, min_ma_value, 1);
            Changed_channel('value_off_ma_id', 'riga_ma_2_1', max_ch_value, min_ch_value, max_fix_value);
            //Changed_channel('value_perc2_ma_id', 'riga_ma_2_2', max_pulse_value, min_pulse_value, 0);
            Changed_channel('value_perc2_ma_id', 'riga_ma_2_2', max_ma_value, min_ma_value, 1);
        }
        if ($('#enable_aa1').is(':checked')) {
            Changed_channel('value_alarm_aa1_id', 'riga_aa1_1_1', max_ch_value, min_ch_value, max_fix_value);
        }
        if ($('#enable_ab1').is(':checked')) {
            Changed_channel('value_alarm_ab1_id', 'riga_ab1_1_1', max_ch_value, min_ch_value, max_fix_value);
        }
        if ($('#enable_ad').is(':checked')) {
            Changed_channel('value_alarm_ore_ad_id', 'riga_ad_1_1', 9, 0, 0);
            Changed_channel('value_alarm_min_ad_id', 'riga_ad_1_2', 99, 0, 0);
        }
        if ($('#enable_ar').is(':checked')) {
            Changed_channel('value_alarm_ore_ar_id', 'riga_ar_1_1', 9, 0, 0);
            Changed_channel('value_alarm_min_ar_id', 'riga_ar_1_2', 99, 0, 0);
        }
        // $(id_1).removeClass('error');
        if ((var_alarm_aa_on) || (var_alarm_aa_perc1) || (var_alarm_aa_off) || (var_alarm_aa_perc2) ||
            (var_alarm_ab_on) || (var_alarm_ab_perc1) || (var_alarm_ab_off) || (var_alarm_ab_perc2) ||
            (var_alarm_pa_on) || (var_alarm_pa_perc1) || (var_alarm_pa_off) || (var_alarm_pa_perc2) ||
            (var_alarm_pb_on) || (var_alarm_pb_perc1) || (var_alarm_pb_off) || (var_alarm_pb_perc2) ||
            (var_alarm_ma_on) || (var_alarm_ma_perc1) || (var_alarm_ma_off) || (var_alarm_ma_perc2) ||
            (var_alarm_aa1) || (var_alarm_ab1) || (var_alarm_ad_ore) || (var_alarm_ad_min) ||
            (var_alarm_ar_ore) || (var_alarm_ar_min)) {
            $('#save_setpoint_new').next('p').remove();

            $('#save_setpoint_new').after('<p class="error help-block"><span class="label label-important">' + wrong_settings + '</span></p>');
            submit_status = false;
            error_general = false;
            return false;
        }
        submit_status = true;
        error_general = true;
        notification['confirm'] = modify_plant;
        //return true;
    });

    $("#save_option_new").click(function () {

        if (enable_send_setpoint == false) {
            result_setpoint_change(user_setpoint_disable);
            return false;
        }
        
        $('#save_option_new').next('p').remove();

        if ($('#enable_log').is(':checked')) {
            Changed_channel('value_start_hr_id', 'riga_log_1_1', 23, 0, 0);
            Changed_channel('value_start_min_id', 'riga_log_1_2', 59, 0, 0);
            Changed_channel('value_every_hr_id', 'riga_log_2_1', 23, 0, 0);
            Changed_channel('value_every_min_id', 'riga_log_2_2', 59, 0, 0);
            Changed_channel('value_filter_min_id', 'riga_log_3_1', 59, 0, 0);
        }
        if ($('#enable_clean').is(':checked')) {
            Changed_channel('value_cycle_hr_id', 'riga_clean_1_1', 99, 0, 0);
            Changed_channel('value_cycle_min_id', 'riga_clean_1_2', 59, 0, 0);
            Changed_channel('value_cleant_hr_id', 'riga_clean_2_1', 59, 0, 0);
            Changed_channel('value_cleant_min_id', 'riga_clean_2_2', 59, 0, 0);
            Changed_channel('value_restore_min_id', 'riga_clean_3_1', 99, 0, 0);
        }
        Changed_channel('value_flow_rate_id', 'riga_flow_1_1', max_flowmeter, 0, my_fix_flowmeter);
        
        if (my_fix_flowmeter > 0) {
            Changed_channel('value_flow_setpoint_id', 'riga_flow_2_1', 999.9, 0, 1);
            Changed_channel('value_flow_ma_id', 'riga_flow_2_2', 999.9, 0, 1);
        }
        if ($('#timed_id').is(':checked')) {
            Changed_channel('value_timed_min_id', 'riga_alarm_timed_min', 99, 0, 1);
            Changed_channel('value_timed_sec_id', 'riga_alarm_timed_sec', 99, 0, 1);
        }
        Changed_channel('value_delay_min_id', 'riga_delay_min', 99, 0, 1);
        Changed_channel('value_tau_const_id', 'riga_tau_const', 99, 0, 1);
        
        if ((var_log_start_h)||(var_log_start_m)||(var_log_every_h)||(var_log_every_m)||(var_log_filter_m)||
            (var_clean_cycle_h)||(var_clean_cycle_m)||(var_clean_clean_m)||(var_clean_clean_s)||(var_clean_restore_m)||
            (var_flow_rate)||(var_flow_low)||(var_flow_ma)||(alarmsetup_timed_min)||(alarmsetup_timed_sec)||
            (delay_min)||(tau_const)){
            
                $('#save_option_new').next('p').remove();
                $('#save_option_new').after('<p class="error help-block"><span class="label label-important">'+ wrong_settings +'</span></p>');
                submit_status = false;
                error_general = false;
                return false;
    }
        
        submit_status = true;
        error_general = true;
        notification['confirm'] = modify_plant;
        
       // return true;

   
    });

    $("#save_calibration_new").click(function () {


        if (enable_send_setpoint == false) {
            result_setpoint_change(user_setpoint_disable);
            return false;
        }

        var one_setting = true;
        $('#save_calibration_new').next('p').remove();

        if ($('#ch1_probe_enale').is(':checked')) {
            one_setting = false;
            Changed_channel('ch1_new_value', 'div_ch1_1', max_ch1_value, min_ch1_value, ch1_fix);
        }
        if ($('#ch2_probe_enale').is(':checked')) {
            one_setting = false;
            Changed_channel('ch2_new_value', 'div_ch2_1', max_ch2_value, min_ch2_value, ch2_fix);
        }

        if ($('#ch3_probe_enale').is(':checked')) {
            one_setting = false;
            Changed_channel('ch3_new_value', 'div_ch3_1', max_ch3_value, min_ch3_value, ch3_fix);
        }
        if ($('#ch4_probe_enale').is(':checked')) {
            one_setting = false;
            Changed_channel('ch4_new_value', 'div_ch4_1', max_ch4_value, min_ch4_value, ch4_fix);
        }
        if ($('#ch5_probe_enale').is(':checked')) {
            one_setting = false;
            Changed_channel('ch5_new_value', 'div_ch5_1', max_ch5_value, min_ch5_value, ch5_fix);
        }


        if ((var_alarm_ch1_calibration) || (var_alarm_ch2_calibration) || (var_alarm_ch3_calibration) || (var_alarm_ch4_calibration) || (var_alarm_ch5_calibration) ||(one_setting)) {

            $('#save_calibration_new').next('p').remove();
            $('#save_calibration_new').after('<p class="error help-block"><span class="label label-important">' + wrong_settings + '</span></p>');
            submit_status = false;
            error_general = false;
            return false;
        }

        submit_status = true;
        error_general = true;
        notification['confirm'] = modify_plant;
        notification['annulla'] = annulla_impianto;

        // return true;


    });
//END GESTIONE SALVATAGGIO DATI


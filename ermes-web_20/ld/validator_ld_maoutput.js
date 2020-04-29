var ph_ma_max = false;
var ph_ma_min = false;
var cl_ma_max = false;
var cl_ma_min = false;
var temperature_ma_max = false;
var temperature_ma_min = false;
var mv_ma_max = false;
var mv_ma_min = false;


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
        case "value_ph_ma_max":
            ph_ma_max = var_alarm;
            check_alarm_channel_ph_ma();
            break;
        case "value_ph_ma_min":
            ph_ma_min = var_alarm;
            check_alarm_channel_ph_ma();
            break;

        case "value_cl_ma_max":
            cl_ma_max = var_alarm;
            check_alarm_channel_cl_ma();
            break;
        case "value_cl_ma_min":
            cl_ma_min = var_alarm;
            check_alarm_channel_cl_ma();
            break;

        case "value_temperature_ma_max":
            temperature_ma_max = var_alarm;
            check_alarm_channel_temperature_ma();
            break;
        case "value_temperature_ma_min":
            temperature_ma_min = var_alarm;
            check_alarm_channel_temperature_ma();
            break;

        case "value_mv_ma_max":
            mv_ma_max = var_alarm;
            check_alarm_channel_mv_ma();
            break;
        case "value_mv_ma_min":
            mv_ma_min = var_alarm;
            check_alarm_channel_mv_ma();
            break;
    }
}

function check_alarm_channel_ph_ma() {
    if ((ph_ma_max == true) || (ph_ma_min == true) ) {
        $("#tab_ld_sp1").attr('style', 'color:#b94a48');
    }
    else {
        $("#tab_ld_sp1").removeAttr('style');
    }
}
function check_alarm_channel_cl_ma() {
    if ((cl_ma_max == true) || (cl_ma_min == true)) {
        $("#tab_ld_sp2").attr('style', 'color:#b94a48');
    }
    else {
        $("#tab_ld_sp2").removeAttr('style');
    }
}
function check_alarm_channel_temperature_ma() {
    if ((temperature_ma_max == true) || (temperature_ma_min == true)) {
        $("#tab_ld_sp3").attr('style', 'color:#b94a48');
    }
    else {
        $("#tab_ld_sp3").removeAttr('style');
    }
}
function check_alarm_channel_mv_ma() {
    if ((mv_ma_max == true) || (mv_ma_min == true)) {
        $("#tab_ld_sp4").attr('style', 'color:#b94a48');
    }
    else {
        $("#tab_ld_sp4").removeAttr('style');
    }
}
function keypress_channel(evt) {
    var charCode = (evt.which) ? evt.which : event.keyCode

    if ((charCode == 46) || (charCode == 45))return true;// carattere .
    if (charCode > 31 && (charCode < 48 || charCode > 57))
        return false;

    return true;

}
$("#value_ph_ma_max").keypress(function (evt) {
    return keypress_channel(evt);
});
$("#value_ph_ma_min").keypress(function (evt) {
    return keypress_channel(evt);
});
$("#value_cl_ma_max").keypress(function (evt) {
    return keypress_channel(evt);
});
$("#value_cl_ma_min").keypress(function (evt) {
    return keypress_channel(evt);
});
$("#value_temperature_ma_max").keypress(function (evt) {
    return keypress_channel(evt);
});
$("#value_temperature_ma_min").keypress(function (evt) {
    return keypress_channel(evt);
});
$("#value_mv_ma_max").keypress(function (evt) {
    return keypress_channel(evt);
});
$("#value_mv_ma_min").keypress(function (evt) {
    return keypress_channel(evt);
});
$("#value_ph_ma_max").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga1_ph_ma_max").removeClass('error');
    ph_ma_max = false;
    check_alarm_channel_ph_ma();
    // $("#principale").load("test.aspx");
});
$("#value_ph_ma_min").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga1_ph_ma_min").removeClass('error');
    ph_ma_min = false;
    check_alarm_channel_ph_ma();
    // $("#principale").load("test.aspx");
});
$("#value_cl_ma_max").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga1_cl_ma_max").removeClass('error');
    cl_ma_max = false;
    check_alarm_channel_cl_ma();
    // $("#principale").load("test.aspx");
});
$("#value_cl_ma_min").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga1_cl_ma_min").removeClass('error');
    cl_ma_min = false;
    check_alarm_channel_cl_ma();
    // $("#principale").load("test.aspx");
});
$("#value_temperature_ma_max").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga1_temperature_ma_max").removeClass('error');
    temperature_ma_max = false;
    check_alarm_channel_temperature_ma();
    // $("#principale").load("test.aspx");
});
$("#value_temperature_ma_min").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga1_temperature_ma_min").removeClass('error');
    temperature_ma_min = false;
    check_alarm_channel_temperature_ma();
    // $("#principale").load("test.aspx");
});
$("#value_mv_ma_max").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga1_mv_ma_max").removeClass('error');
    mv_ma_max = false;
    check_alarm_channel_mv_ma();
    // $("#principale").load("test.aspx");
});
$("#value_mv_ma_min").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga1_mv_ma_min").removeClass('error');
    mv_ma_min = false;
    check_alarm_channel_mv_ma();
    // $("#principale").load("test.aspx");
});
$("#save_maoutputld_new").click(function () {
    if (enable_send_setpoint == false) {
        result_setpoint_change(user_setpoint_disable);
        return false;
    }

    $('#save_maoutputld_new').next('p').remove();
    Changed_channel('value_ph_ma_max', 'riga1_ph_ma_max', max_ph_value, min_ph_value, max_fix_value_ph);
    Changed_channel('value_ph_ma_min', 'riga1_ph_ma_min', max_ph_value, min_ph_value, max_fix_value_ph);
    Changed_channel('value_cl_ma_max', 'riga1_cl_ma_max', max_cl_value, min_cl_value, max_fix_value_cl);
    Changed_channel('value_cl_ma_min', 'riga1_cl_ma_min', max_cl_value, min_cl_value, max_fix_value_cl);
    Changed_channel('value_temperature_ma_max', 'riga1_temperature_ma_max', max_temperature_value, min_temperature_value, max_fix_value_temperature);
    Changed_channel('value_temperature_ma_min', 'riga1_temperature_ma_min', max_temperature_value, min_temperature_value, max_fix_value_temperature);
    if (max_mv_value < 2000) {
        Changed_channel('value_mv_ma_min', 'riga1_mv_ma_min', max_mv_value, min_mv_value, max_fix_value_mv);
        Changed_channel('value_mv_ma_max', 'riga1_mv_ma_max', max_mv_value, min_mv_value, max_fix_value_mv);
    }
    if ((ph_ma_max) || (ph_ma_min) || (cl_ma_max) || (cl_ma_min) ||
         (temperature_ma_max) || (temperature_ma_min) || (mv_ma_max) || (mv_ma_min)) {
        $('#save_maoutputld_new').next('p').remove();

        $('#save_maoutputld_new').after('<p class="error help-block"><span class="label label-important">' + wrong_settings + '</span></p>');
        submit_status = false;
        error_general = false;

        return false;

    }
    submit_status = true;
    error_general = true;
    notification['confirm'] = modify_plant;
    notification['annulla'] = annulla_impianto;

});




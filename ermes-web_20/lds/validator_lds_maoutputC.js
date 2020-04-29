var cl_ma_max = false;
var cl_ma_min = false;
var temperature_ma_max = false;
var temperature_ma_min = false;


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


    }
}

function check_alarm_channel_cl_ma() {
    if ((cl_ma_max == true) || (cl_ma_min == true)) {
        $("#tab_ld_sp1").attr('style', 'color:#b94a48');
    }
    else {
        $("#tab_ld_sp1").removeAttr('style');
    }
}
function check_alarm_channel_temperature_ma() {
    if ((temperature_ma_max == true) || (temperature_ma_min == true)) {
        $("#tab_ld_sp2").attr('style', 'color:#b94a48');
    }
    else {
        $("#tab_ld_sp2").removeAttr('style');
    }
}

function keypress_channel(evt) {
    var charCode = (evt.which) ? evt.which : event.keyCode

    if (charCode == 46) return true;// carattere .
    if (charCode > 31 && (charCode < 48 || charCode > 57))
        return false;

    return true;

}

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

$("#save_maoutputldsC_new").click(function () {
    if (enable_send_setpoint == false) {
        result_setpoint_change(user_setpoint_disable);
        return false;
    }

    $('#save_maoutputldsC_new').next('p').remove();
    Changed_channel('value_cl_ma_max', 'riga1_cl_ma_max', max_cl_value, min_cl_value, max_fix_value_cl);
    Changed_channel('value_cl_ma_min', 'riga1_cl_ma_min', max_cl_value, min_cl_value, max_fix_value_cl);
    Changed_channel('value_temperature_ma_max', 'riga1_temperature_ma_max', max_temperature_value, min_temperature_value, max_fix_value_temperature);
    Changed_channel('value_temperature_ma_min', 'riga1_temperature_ma_min', max_temperature_value, min_temperature_value, max_fix_value_temperature);
    if ((cl_ma_max) || (cl_ma_min) ||
         (temperature_ma_max) || (temperature_ma_min)) {
        $('#save_maoutputldsC_new').next('p').remove();

        $('#save_maoutputldsC_new').after('<p class="error help-block"><span class="label label-important">' + wrong_settings + '</span></p>');
        submit_status = false;
        error_general = false;
        return false;
    }
    submit_status = true;
    error_general = true;
    notification['confirm'] = modify_plant;
    notification['annulla'] = annulla_impianto;
});


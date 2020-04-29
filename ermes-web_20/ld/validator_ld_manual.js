
function keypress_num(evt) {
    var charCode = (evt.which) ? evt.which : event.keyCode
    if (charCode > 31 && (charCode < 48 || charCode > 57))
        return false;

    return true;
}

$("#value_relay1_id").keypress(function (evt) {
    return keypress_num(evt);
});
$("#value_relay2_id").keypress(function (evt) {
    return keypress_num(evt);
});


$("#value_pulse1_id").keypress(function (evt) {
    return keypress_num(evt);
});
$("#value_pulse2_id").keypress(function (evt) {
    return keypress_num(evt);
});
$("#value_pulse3_id").keypress(function (evt) {
    return keypress_num(evt);
});

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
    return var_alarm;
}

$("#value_relay1_id").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#check_relay1_id").prop('checked', true);
    $("#riga_relay1_id").removeClass('error');
    // $("#principale").load("test.aspx");
});
$("#value_relay2_id").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#check_relay2_id").prop('checked', true);
    $("#riga_relay2_id").removeClass('error');
    // $("#principale").load("test.aspx");
});

$("#value_pulse1_id").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#check_pulse1_id").prop('checked', true);
    $("#riga_pulse_id").removeClass('error');
    // $("#principale").load("test.aspx");
});
$("#value_pulse2_id").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#check_pulse2_id").prop('checked', true);
    $("#riga_pulse2_id").removeClass('error');
    // $("#principale").load("test.aspx");
});
$("#value_pulse3_id").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#check_pulse3_id").prop('checked', true);
    $("#riga_pulse3_id").removeClass('error');
    // $("#principale").load("test.aspx");
});


$("#save_manual_newld").click(function () {
    if (enable_send_setpoint == false) {
        result_setpoint_change(user_setpoint_disable);
        return false;
    }

    var one_setting = true;
    $('#save_manual_newld').next('p').remove();
    var alarm_temp1 = false;
    var alarm_temp2 = false;
    var alarm_temp3 = false;
    var alarm_temp4 = false;
    var alarm_temp5 = false;
    var alarm_temp6 = false;

    var alarm_temp7 = false;
    var alarm_temp8 = false;
    var alarm_temp9 = false;
    var alarm_temp10 = false;
    var alarm_temp11 = false;
    var alarm_temp12 = false;

    if ($('#check_relay1_id').is(':checked')) {
        one_setting = false;
        alarm_temp1 = Changed_channel('value_relay1_id', 'riga_relay1_id', 60, 0, 0);
    }
    if ($('#check_relay2_id').is(':checked')) {
        one_setting = false;
        alarm_temp2 = Changed_channel('value_relay2_id', 'riga_relay2_id', 60, 0, 0);
    }
    

    if ($('#check_pulse1_id').is(':checked')) {
        one_setting = false;
        alarm_temp7 = Changed_channel('value_pulse1_id', 'riga_pulse1_id', 60, 0, 0);
    }
    if ($('#check_pulse2_id').is(':checked')) {
        one_setting = false;
        alarm_temp8 = Changed_channel('value_pulse2_id', 'riga_pulse2_id', 60, 0, 0);
    }
    if ($('#check_pulse3_id').is(':checked')) {
        one_setting = false;
        alarm_temp9 = Changed_channel('value_pulse3_id', 'riga_pulse3_id', 60, 0, 0);
    }
    
    if ((alarm_temp1) || (alarm_temp2) ||
        (alarm_temp7) || (alarm_temp8) || (alarm_temp9)  || (one_setting)) {
        $('#save_manual_newld').next('p').remove();
        $('#save_manual_newld').after('<p class="error help-block"><span class="label label-important">' + wrong_settings + '</span></p>');
        submit_status = false;
        error_general = false;
        return false;
    }
    else {
        submit_status = true;
        error_general = true;
        notification['confirm'] = modify_plant;
        notification['annulla'] = annulla_impianto;
    }
});

var pulse_wm = false;

function remove_allarme(id1, id2) {
    var id = "#" + id1;
    var id_1 = "#" + id2;

    $(id_1).removeClass('error');
    $(id).next('p').remove();
}

function Changed_channel_str(id1, id2) {
    var id = "#" + id1;
    var id_1 = "#" + id2;
    var value_form = $(id).val().length;

    $(id_1).removeClass('error');
    $(id).next('p').remove();

    if (value_form == 0) {
        $(id).after('<p class="error help-block"><span class="label label-important">Not be Empty</span></p>');
        $(id_1).addClass('error')
        level_name = true;
    }
    else
        level_name = false;
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

    $(id_1).removeClass('error');
    $(id).next('p').remove();



    if ((isNaN(myNumber)) || (myNumber > max_ch) || (myNumber < min_ch)) {
        //$(id_1).removeClass('error');
        //$(id).next('p').remove();

        $(id).after('<p class="error help-block"><span class="label label-important">' + range + ' ' + min_ch + ' - ' + max_ch + '</span></p>');
        $(id_1).addClass('error')
        var_alarm = true
    }
    switch (id1) {
        case "value_pulse":
            pulse_wm = var_alarm;
            //check_alarm_level_4ma();
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
$("#calue_pulse").keypress(function (evt) {
    return keypress_channel(evt);
});

$("#value_pulse").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga1_pulse").removeClass('error');
    pulse_wm = false;
    //check_alarm_channel_ph_pulse1();
    // $("#principale").load("test.aspx");
});


$("#save_setpointldlg_new").click(function () {
    if (enable_send_setpoint == false) {
        result_setpoint_change(user_setpoint_disable);
        return false;
    }

    $('#save_setpointldlg_new').next('p').remove();
    Changed_channel('value_pulse', 'riga1_pulse', max_pulse, 0, virgole);

    Changed_channel_str('value_name', 'riga1_name');

    if ((pulse_wm) ) {
        $('#save_setpointldlg_new').next('p').remove();

        $('#save_setpointldlg_new').after('<p class="error help-block"><span class="label label-important">' + wrong_settings + '</span></p>');
        submit_status = false;
        error_general = false;

        return false;
    }
    submit_status = true;
    error_general = true;
    notification['confirm'] = modify_plant;
    notification['annulla'] = annulla_impianto;
});
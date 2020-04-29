var var_mail1 = false;
var var_mail2 = false;

function keypress_channel_sms(evt) {
    var charCode = (evt.which) ? evt.which : event.keyCode

    if (charCode == 43) return true;// carattere +
    if (charCode > 31 && (charCode < 48 || charCode > 57))
        return false;

    return true;

}

function keypress_check_mail(id1, id2) {
    var email_re = /^[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,4}$/i;
    var id = "#" + id1;
    var id_1 = "#" + id2;
    var value_form = $(id).val();
    var value_form_lunghezza = $(id).val().length;
    var var_alarm = false;

    if ((value_form_lunghezza > 0) && (value_form.search(email_re) == -1)) {
        $(id_1).removeClass('error');
        $(id).next('p').remove();

        $(id).after('<p class="error help-block"><span class="label label-important">' + invalid_mail_format + '</span></p>');
        $(id_1).addClass('error')
        var_alarm = true;
    }
    else {
        var_alarm = false;
        $(id_1).removeClass('error');
        $(id).next('p').remove();
    }
    switch (id1) {
        case "value_mail1_id":
            var_mail1 = var_alarm;
            check_alarm_mail();
            break;
        case "value_mail2_id":
            var_mail2 = var_alarm;
            check_alarm_mail();
            break;

    }

}

function check_alarm_mail() {
    if ((var_mail1 == true) || (var_mail2 == true)) {
        $("#tab_2_3").attr('style', 'color:#b94a48');
    }
    else {
        $("#tab_2_3").removeAttr('style');
    }
}

$("#value_sms1_id").keypress(function (evt) {
    return keypress_channel_sms(evt);
});

$("#value_sms2_id").keypress(function (evt) {
    return keypress_channel_sms(evt);
});

$("#value_mail1_id").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga_mail_1").removeClass('error');
    var_mail1 = false;
    check_alarm_mail();
    // $("#principale").load("test.aspx");
});

$("#value_mail2_id").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga_mail_2").removeClass('error');
    var_mail2 = false;
    check_alarm_mail();
    // $("#principale").load("test.aspx");
});
$("#tab_1_3").click(function () {
    keypress_check_mail('value_mail1_id', 'riga_mail_1');
    keypress_check_mail('value_mail2_id', 'riga_mail_2');
    check_alarm_mail();
});
$("#tab_2_3").click(function () {
    keypress_check_mail('value_mail1_id', 'riga_mail_1');
    keypress_check_mail('value_mail2_id', 'riga_mail_2');

    check_alarm_mail();
});

$("#save_message_newwd").click(function () {
    if (enable_send_setpoint == false) {
        result_setpoint_change(user_setpoint_disable);
        return false;
    }

    $('#save_message_newwd').next('p').remove();
    keypress_check_mail('value_mail1_id', 'riga_mail_1');
    keypress_check_mail('value_mail2_id', 'riga_mail_2');
    check_alarm_mail();
    if ((var_mail1 == true) || (var_mail2 == true)) {
        $('#save_message_newwd').next('p').remove();

        $('#save_message_newwd').after('<p class="error help-block"><span class="label label-important">' + wrong_settings + ' </span></p>');
        submit_status = false;
        error_general = false;
        return false;

    }
    submit_status = true;
    error_general = true;
    notification['confirm'] = modify_plant;
    notification['annulla'] = annulla_impianto;
});
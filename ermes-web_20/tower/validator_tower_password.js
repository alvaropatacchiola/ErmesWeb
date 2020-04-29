
function keypress_channel_password(evt) {
    var charCode = (evt.which) ? evt.which : event.keyCode

    if (charCode > 31 && (charCode < 48 || charCode > 57))
        return false;

    return true;

}
function check_password_old(id1, id2) {
    var id = "#" + id1;
    var id_1 = "#" + id2;
    var value_form_lunghezza = $(id).val().length;
    var value_form = $(id).val();

    if ((password_c != value_form) || (value_form_lunghezza < 4)) {
        $(id_1).removeClass('error');
        $(id).next('p').remove();
        if (value_form_lunghezza < 4) {
            $(id).after('<p class="error help-block"><span class="label label-important">' + password_6 + '</span></p>');
        }
        else {
            $(id).after('<p class="error help-block"><span class="label label-important">' + wrong_old_password + '</span></p>');
        }
        $(id_1).addClass('error')
        return false;
    }
    else {
        $(id_1).removeClass('error');
        $(id).next('p').remove();
    }
    return true;
}
function check_password_new(id1, id1_1, id2, id2_1) {
    var id = "#" + id1;
    var id1 = "#" + id1_1;
    var id_1 = "#" + id2;
    var id_2 = "#" + id2_1;
    var value_form_lunghezza = $(id).val().length;
    var value_form = $(id).val();

    var value_form_lunghezza_1 = $(id1).val().length;
    var value_form_1 = $(id1).val();
    if ((value_form != value_form_1) || (value_form_lunghezza < 4) || (value_form_lunghezza_1 < 4)) {
        $(id_1).removeClass('error');
        $(id_2).removeClass('error');
        $(id).next('p').remove();
        $(id1).next('p').remove();
        if (value_form_lunghezza < 4) {
            $(id).after('<p class="error help-block"><span class="label label-important">' + password_6_new + '</span></p>');
            $(id_1).addClass('error')
            return false;
        }
        if (value_form_lunghezza_1 < 4) {
            $(id1).after('<p class="error help-block"><span class="label label-important">' + password_uguale + '</span></p>');
            $(id_2).addClass('error')
            return false;
        }

        if (value_form != value_form_1) {
            $(id1).after('<p class="error help-block"><span class="label label-important">' + password_uguale + '</span></p>');
            $(id_2).addClass('error')
            return false;
        }

    }
    else {
        $(id_1).removeClass('error');
        $(id_2).removeClass('error');
        $(id).next('p').remove();
        $(id1).next('p').remove();
    }
    return true;
}

$("#old_password").keypress(function (evt) {
    return keypress_channel_password(evt);
});
$("#new_password").keypress(function (evt) {
    return keypress_channel_password(evt);
});
$("#confirm_password").keypress(function (evt) {
    return keypress_channel_password(evt);
});
$("#save_password_new").click(function () {
    var validator_password_old = false;
    var validator_password = false;
    if (enable_send_setpoint == false) {
        result_setpoint_change(user_setpoint_disable);
        return false;
    }

    $('#save_password_new').next('p').remove();
    validator_password_old = check_password_old('old_password', 'div_old_password');
    validator_password = check_password_new('new_password', 'confirm_password', 'div_new_password', 'div_confirm_password');
    //check_alarm_mail();
    if ((validator_password_old == false) || (validator_password == false)) {
        $('#save_password_new').next('p').remove();

        $('#save_password_new').after('<p class="error help-block"><span class="label label-important">' + wrong_settings + ' </span></p>');
        submit_status = false;
        error_general = false;
        return false;

    }
    submit_status = true;
    error_general = true;
    notification['confirm'] = modify_plant;
    notification['annulla'] = annulla_impianto;

});
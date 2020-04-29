function keypress_channel_password(evt) {
    var charCode = (evt.which) ? evt.which : event.keyCode

    if (charCode > 31 && (charCode < 48 || charCode > 57))
        return false;

    return true;

}
function check_password_old(id1, id2,password_c) {
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

function set_password() {
    $("#old_password_service").val(password_s);
    $("#new_password_service").val(password_s);
    $("#confirm_password_service").val(password_s);
    $("#old_password_log").val(password_l);
    $("#new_password_log").val(password_l);
    $("#confirm_password_log").val(password_l);

}

$("#old_password_service").keypress(function (evt) {
    return keypress_channel_password(evt);
});
$("#new_password_service").keypress(function (evt) {
    return keypress_channel_password(evt);
});
$("#confirm_password_service").keypress(function (evt) {
    return keypress_channel_password(evt);
});
$("#old_password_log").keypress(function (evt) {
    return keypress_channel_password(evt);
});
$("#new_password_log").keypress(function (evt) {
    return keypress_channel_password(evt);
});
$("#confirm_password_log").keypress(function (evt) {
    return keypress_channel_password(evt);
});

$("#save_password_ldma_new").click(function () {
    var validator_password_old_service = false;
    var validator_password_service = false;
    var validator_password_old_log = false;
    var validator_password_log = false;

    if (enable_send_setpoint == false) {
        result_setpoint_change(user_setpoint_disable);
        return false;
    }


    $('#save_password_ldlg_new').next('p').remove();
    validator_password_old_service = check_password_old('old_password_service', 'div_old_password_service', password_s);
    validator_password_service = check_password_new('new_password_service', 'confirm_password_service', 'div_new_password_service', 'div_confirm_password_service');
    validator_password_old_log = check_password_old('old_password_log', 'div_old_password_log', password_l);
    validator_password_log = check_password_new('new_password_log', 'confirm_password_log', 'div_new_password_log', 'div_confirm_password_log');
    $("#tab_1").removeAttr('style');
    $("#tab_2").removeAttr('style');

    if ((validator_password_old_service == false) || (validator_password_service == false)) {
        $("#tab_1").attr('style', 'color:#b94a48');
    }
    if ((validator_password_old_log == false) || (validator_password_log == false)) {
        $("#tab_2").attr('style', 'color:#b94a48');
    }

    //check_alarm_mail();
    if ((validator_password_old_service == false) || (validator_password_service == false)||
        (validator_password_old_log == false) || (validator_password_log == false)) {
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
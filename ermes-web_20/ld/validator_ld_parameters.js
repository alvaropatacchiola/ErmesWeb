var ph_feeding_delay = false;
var ph_tau = false;
var ph_password_new = false;
var ph_password_old = false;

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
        case "value_ph_feeding_delay":
            ph_feeding_delay = var_alarm;
            check_alarm_channel_ph_general();
            break;
        case "value_ph_tau":
            ph_tau = var_alarm;
            check_alarm_channel_ph_general();
            break;
    }
}
function check_alarm_channel_ph_general() {
    if ((ph_feeding_delay == true) || (ph_tau == true)) {
        $("#tab_ld_sp1").attr('style', 'color:#b94a48');
    }
    else {
        $("#tab_ld_sp1").removeAttr('style');
    }
}
function check_alarm_channel_ph_password() {
    if ((ph_password_new == true) || (ph_password_old == true)) {
        $("#tab_ld_sp2").attr('style', 'color:#b94a48');
    }
    else {
        $("#tab_ld_sp2").removeAttr('style');
    }
}

$("#value_ph_feeding_delay").keypress(function (evt) {
    return keypress_channel_password(evt);
});
$("#value_ph_tau").keypress(function (evt) {
    return keypress_channel_password(evt);
});
$("#value_ph_feeding_delay").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga1_ph_feeding_delay").removeClass('error');
    ph_feeding_delay = false;
    check_alarm_channel_ph_general();
    // $("#principale").load("test.aspx");
});
$("#value_ph_tau").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga1_ph_tau").removeClass('error');
    ph_tau = false;
    check_alarm_channel_ph_general();
    // $("#principale").load("test.aspx");
});


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
    ph_password_new = false;
    if ((password_c != value_form) || (value_form_lunghezza < 4)) {
        $(id_1).removeClass('error');
        $(id).next('p').remove();
        if (value_form_lunghezza < 4) {
            $(id).after('<p class="error help-block"><span class="label label-important">' + password_6 + '</span></p>');
        }
        else {
            $(id).after('<p class="error help-block"><span class="label label-important">' + wrong_old_password + '</span></p>');
        }
        ph_password_new = true;
        check_alarm_channel_ph_password();
        $(id_1).addClass('error')
        return false;
    }
    else {
        check_alarm_channel_ph_password();
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

    ph_password_old = false;
    if ((value_form != value_form_1) || (value_form_lunghezza < 4) || (value_form_lunghezza_1 < 4)) {
        $(id_1).removeClass('error');
        $(id_2).removeClass('error');
        $(id).next('p').remove();
        $(id1).next('p').remove();
        if (value_form_lunghezza < 4) {
            $(id).after('<p class="error help-block"><span class="label label-important">' + password_6_new + '</span></p>');
            $(id_1).addClass('error')
            ph_password_old = true;
            check_alarm_channel_ph_password();

            return false;
        }
        if (value_form_lunghezza_1 < 4) {
            $(id1).after('<p class="error help-block"><span class="label label-important">' + password_uguale + '</span></p>');
            $(id_2).addClass('error')
            ph_password_old = true;
            check_alarm_channel_ph_password();

            return false;
        }

        if (value_form != value_form_1) {
            $(id1).after('<p class="error help-block"><span class="label label-important">' + password_uguale + '</span></p>');
            $(id_2).addClass('error')
            ph_password_old = true;
            check_alarm_channel_ph_password();

            return false;
        }

    }
    else {
        check_alarm_channel_ph_password();
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

$("#save_parameters_new").click(function () {
    var validator_password_old = false;
    var validator_password = false;
   
    if (enable_send_setpoint == false) {
        result_setpoint_change(user_setpoint_disable);
        return false;
    }

    $('#save_parameters_new').next('p').remove();
    validator_password_old = check_password_old('old_password', 'div_old_password');
    
    validator_password = check_password_new('new_password', 'confirm_password', 'div_new_password', 'div_confirm_password');
    Changed_channel('value_ph_feeding_delay', 'riga1_ph_feeding_delay', 60, 0, 0);
    Changed_channel('value_ph_tau', 'riga1_ph_tau', 30, 0, 0);
    
    //check_alarm_mail();
    if ((validator_password_old == false) || (validator_password == false)) {
        $('#save_parameters_new').next('p').remove();

        $('#save_parameters_new').after('<p class="error help-block"><span class="label label-important">' + wrong_settings + ' </span></p>');
        submit_status = false;
        error_general = false;
        return false;
    }

    if ((ph_feeding_delay) || (ph_tau)) {
        $('#save_parameters_new').next('p').remove();

        $('#save_parameters_new').after('<p class="error help-block"><span class="label label-important">' + wrong_settings + '</span></p>');
        submit_status = false;
        error_general = false;
        return false;
    }
    submit_status = true;
    error_general = true;
    notification['confirm'] = modify_plant;
    notification['annulla'] = annulla_impianto;
});
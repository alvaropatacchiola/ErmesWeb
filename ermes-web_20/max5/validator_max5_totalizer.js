$("#save_totalizer_new").click(function () {
    if (enable_send_setpoint == false) {
        result_setpoint_change(user_setpoint_disable);
        return false;
    }

    $('#save_totalizer_new').next('p').remove();
    var alarm_temp1 = true;
    if ($('#reset_totalizer_check').is(':checked')) {
        alarm_temp1 = false;
    }
    
    if ((alarm_temp1)) {
        $('#save_totalizer_new').next('p').remove();
        $('#save_totalizer_new').after('<p class="error help-block"><span class="label label-important">' + wrong_settings + '</span></p>');
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
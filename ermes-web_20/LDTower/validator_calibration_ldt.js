var alarm_calibration = false;


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

        // sezione calibrazione
        case "new_value":
            alarm_calibration = var_alarm;
            break;
       
    }
}

// sezione calibrazione
//------------------------------------------------------------
//---KEY PRESSED ch1 value------------------------------
//------------------------------------------------------------

$("#new_value").keypress(function (evt) {
    return keypress_channel(evt);
});

//------------------------------------------------------------
//---end KEY PRESSED ch1 value------------------------------
//------------------------------------------------------------

// end sezione calibrazione


//SEZIONE CALIBRAZIONEù
$("#new_value").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga_new_value").removeClass('error');
    alarm_calibration = false;
    // $("#principale").load("test.aspx");
    $("#probe_enable").prop('checked', true);
});

// END SEZIONE CALIBRAZIONE



$("#save_calibration_ldtower_new").click(function () {

    
    if (enable_send_setpoint == false) {
        result_setpoint_change(user_setpoint_disable);
        return false;
    }

    var one_setting = true;
    $('#save_calibration_ldtower_new').next('p').remove();

    if ($('#probe_enable').is(':checked')) {
        one_setting = false;
        Changed_channel('new_value', 'riga_new_value', max_value, min_value, fix_value);
    }


    if (alarm_calibration) {

        $('#save_calibration_ldtower_new').next('p').remove();
        $('#save_calibration_ldtower_new').after('<p class="error help-block"><span class="label label-important">' + wrong_settings + '</span></p>');
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


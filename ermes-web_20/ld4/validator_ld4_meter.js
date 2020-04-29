var valore = false;
var m3h_valore = false;

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
        case "value_meter":
            valore = var_alarm;
            check_alarm_channel_meter_general();
            break;

        case "m3h":
            m3h_valore = var_alarm;
            check_alarm_channel_m3h_general();
            break;
            
    
    }
}
function check_alarm_channel_meter_general() {
    if ((valore == true) ) {
        $("#tab_ld_sp1").attr('style', 'color:#b94a48');
    }
    else {
        $("#tab_ld_sp1").removeAttr('style');
    }
}

function check_alarm_channel_m3h_general() {
    if ((m3h_valore == true)) {
        $("#tab_ld_sp1").attr('style', 'color:#b94a48');
    }
    else {
        $("#tab_ld_sp1").removeAttr('style');
    }
}



$("#value_meter").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga1_valore").removeClass('error');
    valore = false;
    check_alarm_channel_meter_general();
    // $("#principale").load("test.aspx");
});


$("#m3h").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#m3h_valore").removeClass('error');
    m3h_valore = false;
    check_alarm_channel_m3h_general();
    // $("#principale").load("test.aspx");
});



$("#disable_reset").click(function () {

    //enable_ph_alarm_high();
});

$("#enable_pulse").click(function () {

    //enable_ph_alarm_high();
});

$("#enable_litri").click(function () {

    //enable_ph_alarm_high();
});



$("#save_meter_new_ld4").click(function () {
    var validator_password_old = false;
    var validator_password = false;

    if (enable_send_setpoint == false) {
        result_setpoint_change(user_setpoint_disable);
        return false;
    }

    $('#save_meter_new_ld4').next('p').remove();
  

   
    Changed_channel('value_meter', 'riga1_valore', 599, 0, 0);
    Changed_channel('m3h', 'm3h_valore', 5999, 0, 0);

   
    if ((valore)||(m3h_valore)) {
        $('#save_meter_new_ld4').next('p').remove();

        $('#save_meter_new_ld4').after('<p class="error help-block"><span class="label label-important">' + wrong_settings + '</span></p>');
        submit_status = false;
        error_general = false;
        return false;
    }
    submit_status = true;
    error_general = true;
    notification['confirm'] = modify_plant;
    notification['annulla'] = annulla_impianto;
});
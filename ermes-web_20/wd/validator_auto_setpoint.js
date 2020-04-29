var ph_mode = false;
var ph_value = false;
var mV_value = false;


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
        //case "mode_ph":
        //    ph_mode = var_alarm;
        //    check_alarm_auto_setpoint();
        //    break;
        case "value_ph":
            ph_value = var_alarm;
            check_alarm_auto_setpoint();
            break;
        case "value_mV":
            mV_value = var_alarm;
            check_alarm_auto_setpoint();
            break;

            
    }
}
function check_alarm_auto_setpoint() {
    if ((ph_mode == true) || (ph_value == true) || (mV_value == true)) {
        $("#tab_ld_sp1").attr('style', 'color:#b94a48');
    }
    else {
        $("#tab_ld_sp1").removeAttr('style');
    }
}


//$("#mode_ph").keypress(function (evt) {
//    return keypress_channel(evt);
//});
$("#value_ph").keypress(function (evt) {
    return keypress_channel(evt);
});

$("#value_mV").keypress(function (evt) {
    return keypress_channel(evt);
});


//$("#mode_ph").click(function () {
//    //$(this).val("");
//    $(this).next('p').remove();
//    $("#riga1_ph_mode").removeClass('error');
//    ph_mode = false;
//    check_alarm_auto_setpoint();
//    // $("#principale").load("test.aspx");
//});
$("#value_ph").click(function () {
    //$(this).val("");
    remove_allarme('value_ph', 'riga1_ph_value');


    $(this).next('p').remove();
    $("#riga1_ph_value").removeClass('error');
    ph_value = false;
    check_alarm_auto_setpoint();
    // $("#principale").load("test.aspx");
});
$("#value_mV").click(function () {
    //$(this).val("");
    remove_allarme('value_mV', 'riga1_mV_value');

    $(this).next('p').remove();
    $("#riga1_mV_value").removeClass('error');
    mV_value = false;
    check_alarm_auto_setpoint();
    // $("#principale").load("test.aspx");
});





$("#save_auto_setpoint_new").click(function () {
    
    if (enable_send_setpoint == false) {
        result_setpoint_change(user_setpoint_disable);
        return false;
    }

    $('#save_auto_setpoint_new').next('p').remove();
    
    //Changed_channel('mode_ph', 'riga1_ph_mode', 60, 0, 0);
    Changed_channel('value_ph', 'riga1_ph_value', max_ch1_value, min_ch1_value, max_fix_value1);
    Changed_channel('value_mV', 'riga1_mV_value', max_ch2_value, min_ch2_value, max_fix_value2);
    
    if ((ph_mode) || (ph_value) || (mV_value)) {
      
        $('#save_auto_setpoint_new').next('p').remove();

        $('#save_auto_setpoint_new').after('<p class="error help-block"><span class="label label-important">' + wrong_settings + '</span></p>');
        submit_status = false;
        error_general = false;
        return false;
    }
    submit_status = true;
    error_general = true;
    notification['confirm'] = modify_plant;
    notification['annulla'] = annulla_impianto;
});
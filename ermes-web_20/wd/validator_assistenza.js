
var day_value = false;



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
    
        case "value_ph":
            day_value = var_alarm;
            check_alarm_valored();
            break;
     

    }
}
function check_alarm_valored() {
    if ((day_value == true) ) {
        $("#tab_ld_sp1").attr('style', 'color:#b94a48');
    }
    else {
        $("#tab_ld_sp1").removeAttr('style');
    }
}



$("#value_day").keypress(function (evt) {
    return keypress_channel(evt);
});





$("#value_day").click(function () {
    //$(this).val("");
    remove_allarme('value_day', 'riga1_day_value');


    $(this).next('p').remove();
    $("#riga1_day_value").removeClass('error');
    ph_value = false;
    check_alarm_valored();
 
});






$("#save_assistenza_new").click(function () {

    if (enable_send_setpoint == false) {
        result_setpoint_change(user_setpoint_disable);
        return false;
    }

    $('#save_assistenza_new').next('p').remove();

    //Changed_channel('mode_ph', 'riga1_ph_mode', 60, 0, 0);
    Changed_channel('value_day', 'riga1_day_value', 250, 0, 0);

    if ((day_value) ) {

        $('#save_assistenza_new').next('p').remove();

        $('#save_assistenza_new').after('<p class="error help-block"><span class="label label-important">' + wrong_settings + '</span></p>');
        submit_status = false;
        error_general = false;
        return false;
    }
    submit_status = true;
    error_general = true;
    notification['confirm'] = modify_plant;
    notification['annulla'] = annulla_impianto;
});
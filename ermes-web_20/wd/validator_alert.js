
var filtro_value = false;
var probe_value = false;
var manut_value = false;

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
        case "value_filtro":
            filtro_value = var_alarm;
            check_alarm_alert();
            break;
        case "value_probe":
            probe_value = var_alarm;
            check_alarm_alert();
            break;
        case "value_manut":
            manut_value = var_alarm;
            check_alarm_alert();
            break;

    }
}
function check_alarm_assistenza() {
    if ((filtro_value == true) || (probe_value == true) || (manut_value == true)) {
        $("#tab_ld_sp1").attr('style', 'color:#b94a48');
    }
    else {
        $("#tab_ld_sp1").removeAttr('style');
    }
}


//$("#mode_ph").keypress(function (evt) {
//    return keypress_channel(evt);
//});
$("#value_filtro").keypress(function (evt) {
    return keypress_channel(evt);
});

$("#value_probe").keypress(function (evt) {
    return keypress_channel(evt);
});

$("#value_manut").keypress(function (evt) {
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
$("#value_filtro").click(function () {
    //$(this).val("");
    remove_allarme('value_filtro', 'riga1_filtro_value');


    $(this).next('p').remove();
    $("#riga1_filtro_value").removeClass('error');
    day_value = false;
    check_alarm_auto_setpoint();
    // $("#principale").load("test.aspx");
});
$("#value_probe").click(function () {
    //$(this).val("");
    remove_allarme('value_probe', 'riga1_probe_value');

    $(this).next('p').remove();
    $("#riga1_probe_value").removeClass('error');
    pass_value = false;
    check_alarm_assistenza();
    // $("#principale").load("test.aspx");
});

$("#value_manut").click(function () {
    //$(this).val("");
    remove_allarme('value_manut', 'riga1_manut_value');

    $(this).next('p').remove();
    $("#riga1_manut_value").removeClass('error');
    pass_value = false;
    check_alarm_assistenza();
    // $("#principale").load("test.aspx");
});



$("#save_alert_new").click(function () {

    if (enable_send_setpoint == false) {
        result_setpoint_change(user_setpoint_disable);
        return false;
    }
    
    $('#save_alert_new').next('p').remove();
   
    //Changed_channel('mode_ph', 'riga1_ph_mode', 60, 0, 0);
    //Changed_channel('value_filtro', 'riga1_filtro_value', 999, 0, 0);
  

   // Changed_channel('value_probe', 'riga1_probe_value', 999, 0, 0);
   
   // Changed_channel('value_manut', 'riga1_manut_value', 999, 0, 0);

    if ((filtro_value) || (probe_value) || (manut_value)) {
    
        $('#save_alert_new').next('p').remove();

        $('#save_alert_new').after('<p class="error help-block"><span class="label label-important">' + wrong_settings + '</span></p>');
        submit_status = false;
        error_general = false;
        return false;
    }
    submit_status = true;
    error_general = true;
    notification['confirm'] = modify_plant;
    notification['annulla'] = annulla_impianto;
});
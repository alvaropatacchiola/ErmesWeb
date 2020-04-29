var var_alarm_temperatrure = false;
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

        $(id).after('<p class="error help-block"><span class="label label-important">' + range + ' ' + +min_ch + ' - ' + max_ch + '</span></p>');
        $(id_1).addClass('error')
        var_alarm = true
    }
    switch (id1) {
        case "value_temperature_on_id":
            var_alarm_temperatrure = var_alarm;
            break;
        case "value_temperature_off_id":
            var_alarm_temperatrure = var_alarm;
            break;

    }
}

function keypress_channel(evt) {
    var charCode = (evt.which) ? evt.which : event.keyCode

    if (charCode == 46) return true;// carattere .
    if (charCode > 31 && (charCode < 48 || charCode > 57))
        return false;

    return true;

}
$("#value_temperature_on_id").keypress(function (evt) {
    return keypress_channel(evt);
});
$("#value_temperature_off_id").keypress(function (evt) {
    return keypress_channel(evt);
});

$("#value_temperature_on_id").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga_temperature_on_id").removeClass('error');
    var_alarm_temperatrure = false;
    // $("#principale").load("test.aspx");
});
$("#value_temperature_off_id").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga_temperature_off_id").removeClass('error');
    var_alarm_temperatrure = false;
    // $("#principale").load("test.aspx");
});

$("#save_temperature_new").click(function () {
    if (enable_send_setpoint == false) {
        result_setpoint_change(user_setpoint_disable);
        return false;
    }

    $('#save_temperature_new').next('p').remove();
    Changed_channel('value_temperature_on_id', 'riga_temperature_on_id', max_ch_value, min_ch_value, max_fix_value);
    Changed_channel('value_temperature_off_id', 'riga_temperature_off_id', max_ch_value, min_ch_value, max_fix_value);
    if (var_alarm_temperatrure) {
        $('#save_temperature_new').next('p').remove();
        $('#save_temperature_new').after('<p class="error help-block"><span class="label label-important">' + wrong_settings + '</span></p>');
        submit_status = false;
        error_general = false;
        return false;
    }
    submit_status = true;
    error_general = true;
    notification['confirm'] = modify_plant;
    notification['annulla'] = annulla_impianto;
    //return true;
});

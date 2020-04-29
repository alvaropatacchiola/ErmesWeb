var alarm_flow_meter_input = false;
var alarm_flow_meter_bleed = false;
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
        case "value_flowmeter_input":
            alarm_flow_meter_input = var_alarm;
            //check_alarm_flow_time();
            break;
        case "value_flowmeter_bleed":
            alarm_flow_meter_bleed = var_alarm;
            //check_alarm_flow_time();
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

$("#value_flowmeter_input").keypress(function (evt) {
    return keypress_channel(evt);
});
$("#value_flowmeter_bleed").keypress(function (evt) {
    return keypress_channel(evt);
});

$("#value_flowmeter_input").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga_flowmeter_input").removeClass('error');
    alarm_flow_meter_input = false;

    // $("#principale").load("test.aspx");
});
$("#value_flowmeter_bleed").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga_flowmeter_bleed").removeClass('error');
    alarm_flow_meter_bleed = false;
    // $("#principale").load("test.aspx");
});

$("#save_flowtower_new").click(function () {
    if (enable_send_setpoint == false) {
        result_setpoint_change(user_setpoint_disable);
        return false;
    }

    $('#save_flowtower_new').next('p').remove();

    Changed_channel('value_flowmeter_input', 'riga_flowmeter_input', 400, 0, 1);
    Changed_channel('value_flowmeter_bleed', 'riga_flowmeter_bleed', 400, 0, 1);

    if ((alarm_flow_meter_input) || (alarm_flow_meter_bleed) ) {
        $('#save_flowtower_new').next('p').remove();

        $('#save_flowtower_new').after('<p class="error help-block"><span class="label label-important">' + wrong_settings + '</span></p>');
        submit_status = false;
        error_general = false;
        return false;
    }
    submit_status = true;
    error_general = true;
    notification['confirm'] = modify_plant;
    notification['annulla'] = annulla_impianto;
});

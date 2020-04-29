var alarm_value_watermeter1 = false;
var alarm_value_watermeter2 = false;


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
        case "value_watermeter1":
            alarm_value_watermeter1 = var_alarm;
            break;

        case "value_watermeter2":
            alarm_value_watermeter2 = var_alarm;
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

$("#value_watermeter1").keypress(function (evt) {
    return keypress_channel(evt);
});
$("#value_watermeter2").keypress(function (evt) {
    return keypress_channel(evt);
});

$("#value_watermeter1").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga_watermeter1").removeClass('error');
    alarm_value_watermeter1 = false;

    // $("#principale").load("test.aspx");
});
$("#value_watermeter2").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga_watermeter2").removeClass('error');
    alarm_value_watermeter2 = false;
    // $("#principale").load("test.aspx");
});

$("#save_flow_ldtower_new").click(function () {
    if (enable_send_setpoint == false) {
        result_setpoint_change(user_setpoint_disable);
        return false;
    }

    $('#save_flow_ldtower_new').next('p').remove();

    Changed_channel('value_watermeter1', 'riga_watermeter1', 400, 0, 1);
    Changed_channel('value_watermeter2', 'riga_watermeter2', 400, 0, 1);

    if ((alarm_value_watermeter1) || (alarm_value_watermeter2)) {
        $('#save_flow_ldtower_new').next('p').remove();

        $('#save_flow_ldtower_new').after('<p class="error help-block"><span class="label label-important">' + wrong_settings + '</span></p>');
        submit_status = false;
        error_general = false;
        return false;
    }
    submit_status = true;
    error_general = true;
    notification['confirm'] = modify_plant;
    notification['annulla'] = annulla_impianto;
});

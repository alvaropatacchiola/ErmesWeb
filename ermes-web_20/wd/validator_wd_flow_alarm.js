var alarm_flow_time = false;
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
        case "value_alarm_flow_time":
            alarm_flow_time = var_alarm;
            //check_alarm_flow_time();
            break;

    }
}

function keypress_channel_number(evt) {
    var charCode = (evt.which) ? evt.which : event.keyCode

    if (charCode > 31 && (charCode < 48 || charCode > 57))
        return false;

    return true;

}
$("#value_alarm_flow_time").keypress(function (evt) {
    return keypress_channel_number(evt);
});
$("#value_alarm_flow_time").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga1_alarm_flow_time").removeClass('error');
    alarm_flow_time = false;

    // $("#principale").load("test.aspx");
});

function disable_flow() {
    alarm_flow_time = false;
    $("#enable_value_alarm_flow_time").hide();

}
function enable_flow() {
    $("#enable_value_alarm_flow_time").show();

}

$("#alarm_flow_disable").click(function () {
    disable_flow();
});
$("#alarm_flow_direct").click(function () {
    enable_flow();
});
$("#alarm_flow_reverse").click(function () {
    enable_flow();
});

$("#save_flowwd_new").click(function () {
    if (enable_send_setpoint == false) {
        result_setpoint_change(user_setpoint_disable);
        return false;
    }

    $('#save_flowwd_new').next('p').remove();
    if (!($('#alarm_flow_direct').is(':checked'))) {
        Changed_channel('value_alarm_flow_time', 'riga1_alarm_flow_time', 99, 0, 0);
    }
    if (!($('#alarm_flow_reverse').is(':checked'))) {
        Changed_channel('value_alarm_flow_time', 'riga1_alarm_flow_time', 99, 0, 0);
    }
    if ((alarm_flow_time)) {
        $('#save_flowwd_new').next('p').remove();

        $('#save_flowwd_new').after('<p class="error help-block"><span class="label label-important">' + wrong_settings + '</span></p>');
        submit_status = false;
        error_general = false;

        return false;
    }
    submit_status = true;
    error_general = true;
    notification['confirm'] = modify_plant;
    notification['annulla'] = annulla_impianto;

});
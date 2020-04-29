
var level_4ma = false;
var level_20ma = false;
var level_alarm = false;
var level_name = false;

function remove_allarme(id1, id2) {
    var id = "#" + id1;
    var id_1 = "#" + id2;

    $(id_1).removeClass('error');
    $(id).next('p').remove();
}

function Changed_channel_str(id1, id2) {
    var id = "#" + id1;
    var id_1 = "#" + id2;
    var value_form = $(id).val().length;

    $(id_1).removeClass('error');
    $(id).next('p').remove();

    if (value_form == 0) {
        $(id).after('<p class="error help-block"><span class="label label-important">Not be Empty</span></p>');
        $(id_1).addClass('error')
        level_name = true;
    }
    else
        level_name = false;
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

    $(id_1).removeClass('error');
    $(id).next('p').remove();



    if ((isNaN(myNumber)) || (myNumber > max_ch) || (myNumber < min_ch)) {
        //$(id_1).removeClass('error');
        //$(id).next('p').remove();

        $(id).after('<p class="error help-block"><span class="label label-important">' + range + ' ' + min_ch + ' - ' + max_ch + '</span></p>');
        $(id_1).addClass('error')
        var_alarm = true
    }
    switch (id1) {
        case "value_level_4ma":
            level_4ma = var_alarm;
            //check_alarm_level_4ma();
            break;
        case "value_level_20ma":
            level_20ma = var_alarm;
            //check_alarm_level_20ma();
            break;
        case "value_level_alarm":
            level_alarm = var_alarm;
            //check_alarm_level_alarm();
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

function keypress_perc(evt) {
    var charCode = (evt.which) ? evt.which : event.keyCode
    if (charCode > 31 && (charCode < 48 || charCode > 57))
        return false;

    return true;
}
$("#value_level_4ma").keypress(function (evt) {
    return keypress_channel(evt);
});
$("#value_level_20ma").keypress(function (evt) {
    return keypress_channel(evt);
});
$("#value_level_alarm").keypress(function (evt) {
    return keypress_channel(evt);
});
$("#value_level_4ma").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga1_level_4ma").removeClass('error');
    level_4ma = false;
    //check_alarm_channel_ph_pulse1();
    // $("#principale").load("test.aspx");
});
$("#value_level_20ma").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga1_level_20ma").removeClass('error');
    level_20ma = false;
    //check_alarm_channel_ph_pulse1();
    // $("#principale").load("test.aspx");
});
$("#value_level_alarm").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga1_level_alarm").removeClass('error');
    level_alarm = false;
    //check_alarm_channel_ph_pulse1();
    // $("#principale").load("test.aspx");
});
$("#value_level_name").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga1_level_name").removeClass('error');
    level_name = false;
    //check_alarm_channel_ph_pulse1();
    // $("#principale").load("test.aspx");
});

$("#save_setpointldma_new").click(function () {
    if (enable_send_setpoint == false) {
        result_setpoint_change(user_setpoint_disable);
        return false;
    }

    $('#save_setpointld_new').next('p').remove();
    Changed_channel('value_level_4ma', 'riga1_level_4ma', 999, 0, 1);
    Changed_channel('value_level_20ma', 'riga1_level_20ma', 999, 0, 1);
    Changed_channel('value_level_alarm', 'riga1_level_alarm', 999, 0, 1);
    Changed_channel_str('value_level_name', 'riga1_level_name');

    if ((level_4ma) || (level_20ma) || (level_alarm) || (level_name)) {
        $('#save_setpointldma_new').next('p').remove();

        $('#save_setpointldma_new').after('<p class="error help-block"><span class="label label-important">' + wrong_settings + '</span></p>');
        submit_status = false;
        error_general = false;

        return false;
    }
    submit_status = true;
    error_general = true;
    notification['confirm'] = modify_plant;
    notification['annulla'] = annulla_impianto;
});

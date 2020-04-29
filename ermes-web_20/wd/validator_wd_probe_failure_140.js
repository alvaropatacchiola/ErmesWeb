var ph_alarm_failure = false;
var cl_alarm_failure = false;


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
        case "value_ph_alarm_failure":
            ph_alarm_failure = var_alarm;

            check_alarm_channel_ph_failure();
            break;
        case "value_cl_alarm_failure":
            cl_alarm_failure = var_alarm;

            check_alarm_channel_cl_failure();
            break;

    }
}
function check_alarm_channel_ph_failure() {
    if ((ph_alarm_failure == true)) {

        $("#tab_ld_sp1").attr('style', 'color:#b94a48');
    }
    else {

        $("#tab_ld_sp1").removeAttr('style');
    }
}
function check_alarm_channel_cl_failure() {
    if ((cl_alarm_failure == true)) {

        $("#tab_ld_sp2").attr('style', 'color:#b94a48');
    }
    else {

        $("#tab_ld_sp2").removeAttr('style');
    }
}
function keypress_channel_number(evt) {
    var charCode = (evt.which) ? evt.which : event.keyCode

    if (charCode > 31 && (charCode < 48 || charCode > 57))
        return false;

    return true;

}
$("#value_ph_alarm_failure").keypress(function (evt) {
    return keypress_channel_number(evt);
});
$("#value_cl_alarm_failure").keypress(function (evt) {
    return keypress_channel_number(evt);
});
function disable_ph_alarm_failure() {
    ph_alarm_failure = false;
    check_alarm_channel_ph_failure();
    $("#enable_value_ph_alarm_failure").hide();
}
function enable_ph_alarm_failure() {

    $("#enable_value_ph_alarm_failure").show();
}
function disable_cl_alarm_failure() {

    cl_alarm_failure = false;
    check_alarm_channel_cl_failure();
    $("#enable_value_cl_alarm_failure").hide();
}
function enable_cl_alarm_failure() {

    $("#enable_value_cl_alarm_failure").show();
}
$("#ph_alarm_failure_enable").click(function () {
    enable_ph_alarm_failure();
});
$("#ph_alarm_failure_disable").click(function () {
    disable_ph_alarm_failure();
});
$("#cl_alarm_failure_enable").click(function () {
    enable_cl_alarm_failure();
});
$("#cl_alarm_failure_disable").click(function () {
    disable_cl_alarm_failure();
});
$("#value_ph_alarm_failure").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga1_ph_alarm_failure").removeClass('error');
    ph_alarm_failure = false;
    check_alarm_channel_ph_failure();
    // $("#principale").load("test.aspx");
});
$("#value_cl_alarm_failure").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga1_cl_alarm_failure").removeClass('error');
    cl_alarm_failure = false;
    check_alarm_channel_cl_failure();
    // $("#principale").load("test.aspx");
});
$("#save_probefailurewd_140_new").click(function () {
    if (enable_send_setpoint == false) {
        result_setpoint_change(user_setpoint_disable);
        return false;
    }

    $('#save_probefailurewd_140_new').next('p').remove();
    if (!($('#ph_alarm_failure_enable').is(':checked'))) {
        Changed_channel('value_ph_alarm_failure', 'riga1_ph_alarm_failure', 999, 0, 0);
    }
    if (!($('#cl_alarm_failure_enable').is(':checked'))) {
        Changed_channel('value_cl_alarm_failure', 'riga1_cl_alarm_failure', 999, 0, 0);
    }

    if ((ph_alarm_failure) || (cl_alarm_failure)) {

        $('#save_probefailurewd_140_new').next('p').remove();

        $('#save_probefailurewd_140_new').after('<p class="error help-block"><span class="label label-important">' + wrong_settings + '</span></p>');
        submit_status = false;
        error_general = false;

        return false;
    }
    submit_status = true;
    error_general = true;
    notification['confirm'] = modify_plant;
    notification['annulla'] = annulla_impianto;
});

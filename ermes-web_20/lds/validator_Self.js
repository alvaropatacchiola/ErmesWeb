var clean_alarm = false;
var restore_alarm = false;



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
        case "value_clean":
            clean_alarm = var_alarm;
            check_alarm_clean();
            break;
        case "value_restore":
            restore_alarm = var_alarm;
            check_alarm_restore();
            break;

       
    }
}

function check_alarm_clean() {
    if ((clean_alarm == true) ) {
        $("#riga1_clean").attr('style', 'color:#b94a48');
    }
    else {
        $("#riga1_clean").removeAttr('style');
    }
}
function check_alarm_restore() {
    if ((restore_alarm == true) ) {
        $("#riga1_restore").attr('style', 'color:#b94a48');
    }
    else {
        $("#riga1_restore").removeAttr('style');
    }
}

function keypress_channel(evt) {
    var charCode = (evt.which) ? evt.which : event.keyCode

    if (charCode == 46) return true;// carattere .
    if (charCode > 31 && (charCode < 48 || charCode > 57))
        return false;

    return true;

}


function yes_on_alarm() {
    $("#enable_on_alarm").show();
}
function no_on_alarm() {

    $("#enable_on_alarm").hide();
}
$("#Alarm_disable").click(function () {
    no_on_alarm();
});
$("#Alarm_enable").click(function () {
    yes_on_alarm();
});



$("#value_clean").keypress(function (evt) {
    return keypress_channel(evt);
});
$("#value_restore").keypress(function (evt) {
    return keypress_channel(evt);
});

$("#value_clean").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga1_clean").removeClass('error');
    clean_alarm = false;
    check_alarm_clean();
    // $("#principale").load("test.aspx");
});
$("#value_restore").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga1_restore").removeClass('error');
    restore_alarm = false;
    check_alarm_restore();
    // $("#principale").load("test.aspx");
});

$("#save_Self_new").click(function () {
    if (enable_send_setpoint == false) {
        result_setpoint_change(user_setpoint_disable);
        return false;
    }

    $('#save_Self_new').next('p').remove();
    Changed_channel('value_clean', 'riga1_clean', 999, 0, 0);
    Changed_channel('value_restore', 'riga1_restore', 999, 0, 0);
  
  
    if ((clean_alarm) || (restore_alarm)) {
        $('#save_Self_new').next('p').remove();

        $('#save_Self_new').after('<p class="error help-block"><span class="label label-important">' + wrong_settings + '</span></p>');
        submit_status = false;
        error_general = false;

        return false;

    }
    submit_status = true;
    error_general = true;
    notification['confirm'] = modify_plant;
    notification['annulla'] = annulla_impianto;

});




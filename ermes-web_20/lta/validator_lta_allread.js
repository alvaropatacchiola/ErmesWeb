var alarm_temp_read = false;
var alarm_dioxide_read = false;


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
        case "value_alarm_dioxide":
            alarm_dioxide_read = var_alarm;
            //check_alarm_flow_time();
            break;
        case "value_alarm_temp":
            alarm_temp_read = var_alarm;
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


function keypress_channel(evt) {

    var charCode = (evt.which) ? evt.which : event.keyCode

    if (charCode == 46) return true;// carattere .
    if (charCode > 31 && (charCode < 48 || charCode > 57))
        return false;

    return true;

}


$("#value_alarm_temp").keypress(function (evt) {
    return keypress_channel_number(evt);
});
$("#value_alarm_temp").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga1_alarm_temp").removeClass('error');
    alarm_temp_read = false;

    // $("#principale").load("test.aspx");
});


$("#value_alarm_dioxide").keypress(function (evt) {
    return keypress_channel(evt);
});
$("#value_alarm_dioxide").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga1_alarm_dioxide").removeClass('error');
    alarm_dioxide_read = false;

    // $("#principale").load("test.aspx");
});



















$("#save_allreadlta_new").click(function () {
    if (enable_send_setpoint == false) {
        result_setpoint_change(user_setpoint_disable);
        return false;
    }

    
    Changed_channel('value_alarm_dioxide', 'riga1_alarm_dioxide', 2, 0, 2);
    Changed_channel('value_alarm_temp', 'riga1_alarm_temp', 200, 0, 0);



    if (
        (alarm_temp_read)
        ||(alarm_dioxide_read)
        ) {
        $('#save_allreadlta_new').next('p').remove();

        $('#save_allreadlta_new').after('<p class="error help-block"><span class="label label-important">' + wrong_settings + '</span></p>');
        submit_status = false;
        error_general = false;

        return false;
    }
    submit_status = true;
    error_general = true;
    notification['confirm'] = modify_plant;
    notification['annulla'] = annulla_impianto;

});
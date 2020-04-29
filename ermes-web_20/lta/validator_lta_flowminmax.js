var alarm_flow_time = false;
var alarm_soglia_time = false;
var alarm_soglia_max = false;
var alarm_soglia_min = false;






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

        case "value_alarm_minmax_time":
            alarm_soglia_time = var_alarm;
            //check_alarm_flow_time();
            break;



        case "value_alarm_minmax_max":
            alarm_soglia_max = false;
            alarm_soglia_max = var_alarm;
            check_alarm_read();
            break;
        case "value_alarm_minmax_min":
            alarm_soglia_min = false;
            alarm_soglia_min = var_alarm;
            check_alarm_read();

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


function check_alarm_read() {
    if ((alarm_soglia_max == true) || (alarm_soglia_min == true)) {
        $("#tab_ld_sp5").attr('style', 'color:#b94a48');
    }
    else {
        $("#tab_ld_sp5").removeAttr('style');
    }
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



$("#value_alarm_soglia_time").keypress(function (evt) {
    return keypress_channel_number(evt);
});
$("#value_alarm_soglia_time").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga1_alarm_minmax_time").removeClass('error');
    alarm_soglia_time = false;

    // $("#principale").load("test.aspx");
});

$("#value_alarm_minmax_max").keypress(function (evt) {
    return keypress_channel(evt);
});
$("#value_alarm_minmax_max").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga1_alarm_minmax_max").removeClass('error');
    alarm_soglia_max = false;

    // $("#principale").load("test.aspx");
});


$("#value_alarm_minmax_min").keypress(function (evt) {
    return keypress_channel(evt);
});
$("#value_alarm_minmax_min").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga1_alarm_minmax_min").removeClass('error');
    alarm_soglia_min = false;

    // $("#principale").load("test.aspx");
});




function disable_flow() {
    alarm_flow_time = false;
    $("#enable_value_alarm_flow_time").hide();

}
function enable_flow() {
    $("#enable_value_alarm_flow_time").show();

}


function disable_soglia() {
    alarm_soglia_time = false;

    $("#enable_value_alarm_minmax_time").hide();
    $("#enable_value_alarm_minmax_max").hide();
    $("#enable_value_alarm_minmax_min").hide();

}
function enable_soglia() {
   
    $("#enable_value_alarm_minmax_time").show();
    $("#enable_value_alarm_minmax_max").show();
    $("#enable_value_alarm_minmax_min").show();

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





$("#alarm_minmax_disable").click(function () {
   
    disable_soglia();
});
$("#alarm_minmax_en").click(function () {
  
    enable_soglia();
});





function enable_allarme() {
    $("#tab_ld_sp2_2").show();

}
function disable_allarme() {
    $("#tab_ld_sp2_2").hide();

}



$("#value_alarm_minmax_max").keypress(function (evt) {
    return keypress_channel(evt);
});
$("#value_alarm_minmax_max").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga1_alarm_minmax_max").removeClass('error');
    alarm_soglia_max = false;
    check_alarm_read();
    // $("#principale").load("test.aspx");
});

$("#value_alarm_minmax_min").keypress(function (evt) {
    return keypress_channel(evt);
});
$("#value_alarm_minmax_min").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga1_alarm_minmax_min").removeClass('error');
    alarm_soglia_min = false;
    check_alarm_read();
    // $("#principale").load("test.aspx");
});





$("#save_flow_minmax_new").click(function () {
    if (enable_send_setpoint == false) {
        result_setpoint_change(user_setpoint_disable);
        return false;
    }

    $('#save_flow_minmax_new').next('p').remove();
    if (!($('#alarm_flow_direct').is(':checked'))) {
        Changed_channel('value_alarm_flow_time', 'riga1_alarm_flow_time', 99, 0, 0);
    }
    if (!($('#alarm_flow_reverse').is(':checked'))) {
        Changed_channel('value_alarm_flow_time', 'riga1_alarm_flow_time', 99, 0, 0);
    }


    $('#save_flow_minmax_new').next('p').remove();
    if (!($('#alarm_minmax_en').is(':checked'))) {
        Changed_channel('value_alarm_minmax_time', 'riga1_alarm_minmax_time', 99, 0, 0);
    }
    Changed_channel('value1_mgl_propread', 'riga1_mgl_propread', max_ch2_value, min_ch2_value, max_fix_value2);
    Changed_channel('value2_mgl_propread', 'riga2_mgl_propread', max_ch2_value, min_ch2_value, max_fix_value2);



    if (
        (alarm_flow_time)
        ||(alarm_flow_time)
    ||(alarm_soglia_time)
    ||(alarm_soglia_max)
    || (alarm_soglia_min)

        ) {
        $('#save_flow_minmax_new').next('p').remove();

        $('#save_flow_minmax_new').after('<p class="error help-block"><span class="label label-important">' + wrong_settings + '</span></p>');
        submit_status = false;
        error_general = false;

        return false;
    }
    submit_status = true;
    error_general = true;
    notification['confirm'] = modify_plant;
    notification['annulla'] = annulla_impianto;

});
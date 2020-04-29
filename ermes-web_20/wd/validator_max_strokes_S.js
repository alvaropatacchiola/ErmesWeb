
//var ph_pulse1_on = false;
var ph_stk_on = false;



//var cl_pulse1_on = false;
//var cl_stk_on = false;








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
        case "value1_ph_stk":
            ph_stk_on = var_alarm;

            check_alarm_channel_ph_stk();


            break;




            //cl pulse 1
        case "value1_cl_stk":
            cl_stk_on = var_alarm;
            check_alarm_channel_cl_stk();
            break;


    }
}

function check_alarm_channel_ph_stk() {


    if ((ph_stk_on == true)) {
        $("#tab_ld_sp1").attr('style', 'color:#b94a48');
    }
    else {
        $("#tab_ld_sp1").removeAttr('style');
    }
}

function check_alarm_channel_cl_stk() {


    if ((cl_stk_on == true)) {
        $("#tab_ld_sp4").attr('style', 'color:#b94a48');
    }
    else {
        $("#tab_ld_sp4").removeAttr('style');
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


$("#value1_ph_stk").keypress(function (evt) {
    return keypress_channel(evt);
});


//cl pulse 1
$("#value1_cl_stk").keypress(function (evt) {
    return keypress_channel(evt);
});



//ph pulse 1
function disable_channel_ph_stk() {

    ph_stk_on = false;

    check_alarm_channel_ph_stk();
    remove_allarme('value1_ph_stk', 'riga1_ph_stk');
    //remove_allarme('value2_ph_pulse1_1', 'riga2_ph_pulse1_1');
    //remove_allarme('value1_ph_pulse1_2', 'riga1_ph_pulse1_2');
    //remove_allarme('value2_ph_pulse1_2', 'riga2_ph_pulse1_2');
    //remove_allarme('value2_ph_pulse1_3', 'riga1_ph_pulse1_3');
    $("#disable_ph_stk").hide();
}

//cl pulse 1
function disable_channel_cl_pulse1() {

    cl_stk_on = false;

    check_alarm_channel_cl_pulse1();
    remove_allarme('value1_cl_stk', 'riga1_cl_stk');
    //remove_allarme('value2_cl_pulse1_1', 'riga2_cl_pulse1_1');
    //remove_allarme('value1_cl_pulse1_2', 'riga1_cl_pulse1_2');
    //remove_allarme('value2_cl_pulse1_2', 'riga2_cl_pulse1_2');
    //remove_allarme('value2_cl_pulse1_3', 'riga1_cl_pulse1_3');
    $("#disable_cl_stk").hide();
}


//ph pulse 1
function enable_channel_ph_stk() {

    ph_pulse1_pm1 = false;
    ph_pulse1_pm2 = false;



    check_alarm_channel_ph_stk();

}

//cl pulse 1
function enable_channel_cl_stk() {

    cl_pulse1_pm1 = false;
    cl_pulse1_pm2 = false;
    check_alarm_channel_cl_stk();

}







$("#tab_ld_sp1").click(function () {
    if ($('#on_off_ph_pulse1').is(':checked')) {

        enable_channel_ph_stk();
    }


});


$("#tab_ld_sp4").click(function () {
    if ($('#on_off_cl_pulse1').is(':checked')) {

        enable_channel_cl_stk();
    }


});



//ph pulse 1
$("#value1_ph_stk").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga1_ph_stk").removeClass('error');
    ph_stk_on = false;
    check_alarm_channel_ph_pulse1();
    // $("#principale").load("test.aspx");
});



//cl pulse 1
$("#value1_cl_stk").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga1_cl_stk").removeClass('error');
    cl_stk_on = false;
    check_alarm_channel_cl_pulse1();
    // $("#principale").load("test.aspx");
});




$("#save_maxstrokesS_new").click(function () {
    if (enable_send_setpoint == false) {
        result_setpoint_change(user_setpoint_disable);
        return false;
    }


    $('#save_maxstrokesS_new').next('p').remove();

    Changed_channel('value1_ph_stk', 'riga1_ph_stk', 180, 1, 0);



    //Changed_channel('value1_cl_stk', 'riga1_cl_stk', 180, 1, 0);






    //  if ((ph_stk_on) || (cl_stk_on)) {
    if ((ph_stk_on) ) {

        $('#save_maxstrokesS_new').next('p').remove();

        $('#save_maxstrokesS_new').after('<p class="error help-block"><span class="label label-important">' + wrong_settings + '</span></p>');
        submit_status = false;
        error_general = false;
        return false;
    }
    submit_status = true;
    error_general = true;
    notification['confirm'] = modify_plant;
    notification['annulla'] = annulla_impianto;

});

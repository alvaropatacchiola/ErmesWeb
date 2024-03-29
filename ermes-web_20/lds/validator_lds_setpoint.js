﻿var cl_pulse1_on = false;
var cl_pulse1_pm1 = false;
var cl_pulse1_off = false;
var cl_pulse1_pm2 = false;
var cl_pulse1_speed = false;




var cl_relay_on = false;
var cl_relay_pm1 = false;
var cl_relay_off = false;
var cl_relay_pm2 = false;


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
            //cl pulse 1
        case "value1_cl_pulse1_1":
            cl_pulse1_on = var_alarm;
            check_alarm_channel_cl_pulse1();
            break;
        case "value2_cl_pulse1_1":
            //cl_pulse1_pm1 = var_alarm;

            var myNumber2;
            var value_form2 = $(value2_cl_pulse1_2).val();
        
            myNumber2 = parseFloat(value_form2);
            myNumber2 = myNumber2.toFixed(myfix);

            cl_pulse1_pm1 = false;
            cl_pulse1_pm2 = false;
            check_alarm_channel_cl_pulse1();


            
            if ((myNumber2 != 0) && (myNumber != 0)) {
                cl_pulse1_pm1 = true;
                
                $(id).after('<p class="error help-block"><span class="label label-important">' + 'One of these values must be zero' + '</span></p>');
                $(id_1).addClass('error')
            }
            else cl_pulse1_pm1 = false;

            //cl_pulse1_pm1 = false;
            break;

        case "value1_cl_pulse1_2":
            cl_pulse1_off = var_alarm;
            check_alarm_channel_cl_pulse1();
            break;
        case "value2_cl_pulse1_2":

            var myNumber2;
            var value_form2 = $(value2_cl_pulse1_1).val();
  
            myNumber2 = parseFloat(value_form2);
            myNumber2 = myNumber2.toFixed(myfix);

            //cl_pulse1_pm2 = var_alarm;

            cl_pulse1_pm1 = false;
            cl_pulse1_pm2 = false;
            check_alarm_channel_cl_pulse1();

            if ((myNumber2 != 0) && (myNumber != 0)) {
                cl_pulse1_pm2 = true;
                $(id).after('<p class="error help-block"><span class="label label-important">' + 'One of these values must be zero' + '</span></p>');
            $(id_1).addClass('error')
    }
                    else cl_pulse1_pm2 = false;

            //cl_pulse1_pm2 = false;
            break; 

        case "value2_cl_pulse1_3":
            cl_pulse1_speed = var_alarm;
            check_alarm_channel_cl_pulse1();
            break;
            //cl relay
        case "value1_cl_relay_1":
            cl_relay_on = var_alarm;
            check_alarm_channel_cl_relay();
            break;
        case "value2_cl_relay_1":

            var myNumber2;
            var value_form2 = $(value2_cl_relay_2).val();

            if (($('#fixed_cl_relay').is(':checked'))) {
                
                cl_relay_pm1 = var_alarm;
                cl_relay_pm1 = false;
                cl_relay_pm2 = false;

            check_alarm_channel_cl_relay();
            }
            if (!($('#fixed_cl_relay').is(':checked'))) {
          
            myNumber2 = parseFloat(value_form2);
            myNumber2 = myNumber2.toFixed(myfix);

            cl_relay_pm1 = false;
            cl_relay_pm2 = false;
            check_alarm_channel_cl_relay();


            if ((myNumber2 != 0) && (myNumber != 0))
            {
                cl_relay_pm1 = true;
                $(id).after('<p class="error help-block"><span class="label label-important">' + 'One of these values must be zero' + '</span></p>');
            $(id_1).addClass('error')
             }
            else cl_relay_pm1 = false;

            //cl_relay_pm1 = false;
            }
            break;

        case "value1_cl_relay_2":
            cl_relay_off = var_alarm;
            check_alarm_channel_cl_relay();
            break;
        case "value2_cl_relay_2":
            var myNumber2;
            var value_form2 = $(value2_cl_relay_1).val();

            if (($('#fixed_cl_relay').is(':checked'))) {
               
                cl_relay_pm2 = var_alarm;
                cl_relay_pm1 = false;
                cl_relay_pm2 = false;
                check_alarm_channel_cl_relay();
          
            }

            if (!($('#fixed_cl_relay').is(':checked'))) {
              
                myNumber2 = parseFloat(value_form2);
                myNumber2 = myNumber2.toFixed(myfix);

                cl_relay_pm1 = false;
                cl_relay_pm2 = false;
                check_alarm_channel_cl_relay();

                if ((myNumber2 != 0) && (myNumber != 0)) 
                {
                    cl_relay_pm2 = true;
                    $(id).after('<p class="error help-block"><span class="label label-important">' + 'One of these values must be zero' + '</span></p>');
                $(id_1).addClass('error')
            }
                    else cl_relay_pm2 = false;
                //cl_relay_pm2 = false;
            }

            break;
    }
}


function check_alarm_channel_cl_pulse1() {
    if ((cl_pulse1_on == true) || (cl_pulse1_pm1 == true) || (cl_pulse1_off == true) || (cl_pulse1_pm2 == true) || (cl_pulse1_speed == true) ) {
        $("#tab_ld_sp4").attr('style', 'color:#b94a48');
    }
    else {
        $("#tab_ld_sp4").removeAttr('style');
    }
}
function check_alarm_channel_cl_relay() {
    if ((cl_relay_on == true) || (cl_relay_pm1 == true) || (cl_relay_off == true) || (cl_relay_pm2 == true)) {
        $("#tab_ld_sp5").attr('style', 'color:#b94a48');
    }
    else {
        $("#tab_ld_sp5").removeAttr('style');
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



//cl pulse 1
$("#value1_cl_pulse1_1").keypress(function (evt) {
    return keypress_channel(evt);
});
$("#value2_cl_pulse1_1").keypress(function (evt) {
    return keypress_perc(evt);
});

$("#value1_cl_pulse1_2").keypress(function (evt) {
    return keypress_channel(evt);
});
$("#value2_cl_pulse1_2").keypress(function (evt) {
    return keypress_perc(evt);
});
$("#value2_cl_pulse1_3").keypress(function (evt) {
    return keypress_perc(evt);
});
//cl relay
$("#value1_cl_relay_1").keypress(function (evt) {
    return keypress_channel(evt);
});
$("#value2_cl_relay_1").keypress(function (evt) {
    return keypress_perc(evt);
});

$("#value1_cl_relay_2").keypress(function (evt) {
    return keypress_channel(evt);
});
$("#value2_cl_relay_2").keypress(function (evt) {
    return keypress_perc(evt);
});


//cl pulse 1
function disable_channel_cl_pulse1() {
    cl_pulse1_on = false;
    cl_pulse1_pm1 = false;
    cl_pulse1_off = false;
    cl_pulse1_pm2 = false;
    cl_pulse1_speed = false;
    check_alarm_channel_cl_pulse1();
    remove_allarme('value1_cl_pulse1_1', 'riga1_cl_pulse1_1');
    remove_allarme('value2_cl_pulse1_1', 'riga2_cl_pulse1_1');
    remove_allarme('value1_cl_pulse1_2', 'riga1_cl_pulse1_2');
    remove_allarme('value2_cl_pulse1_2', 'riga2_cl_pulse1_2');
    remove_allarme('value2_cl_pulse1_3', 'riga1_cl_pulse1_3');
    $("#disable_cl_pulse1").hide();
}
//cl relay
function disable_channel_cl_relay() {
    cl_relay_on = false;
    cl_relay_pm1 = false;
    cl_relay_off = false;
    cl_relay_pm2 = false;
    check_alarm_channel_cl_relay();
    remove_allarme('value1_cl_relay_1', 'riga1_cl_relay_1');
    remove_allarme('value2_cl_relay_1', 'riga2_cl_relay_1');
    remove_allarme('value1_cl_relay_2', 'riga1_cl_relay_2');
    remove_allarme('value2_cl_relay_2', 'riga2_cl_relay_2');

    $("#disable_cl_relay").hide();
}


//cl pulse 1
function enable_channel_cl_pulse1_on_off() {

    cl_pulse1_pm1 = false;
    cl_pulse1_pm2 = false;
    check_alarm_channel_cl_pulse1();
    remove_allarme('value2_cl_pulse1_1', 'riga2_cl_pulse1_1');
    remove_allarme('value2_cl_pulse1_2', 'riga2_cl_pulse1_2');
    $("#disable_cl_pulse1").show();
    $("#label1_cl_pulse1_proportional").hide();
    $("#label1_cl_pulse1_on_off").show();
    $("#label2_cl_pulse1_proportional").hide();
    $("#label2_cl_pulse1_on_off").show();

    $("#riga2_cl_pulse1_1").hide();
    $("#riga2_cl_pulse1_2").hide();
    $("#riga1_cl_pulse1_3").show();
}
//cl relay
function enable_channel_cl_relay_on_off() {

    cl_relay_pm1 = false;
    cl_relay_pm2 = false;
    check_alarm_channel_cl_relay();
    remove_allarme('value2_cl_relay_1', 'riga2_cl_relay_1');
    remove_allarme('value2_cl_relay_2', 'riga2_cl_relay_2');
    $("#disable_cl_relay").show();

    $("#label1_cl_relay_else").hide();
    $("#label1_cl_relay_on_off").show();
    $("#riga2_cl_relay_1").hide();

    $("#label2_cl_relay_else").hide();
    $("#label2_cl_relay_on_off").show();
    $("#riga2_cl_relay_2").hide();
}


//cl pulse 1
function enable_channel_cl_pulse1_proportional() {

    cl_pulse1_speed = false;
    check_alarm_channel_cl_pulse1();
    remove_allarme('value2_cl_pulse1_3', 'riga1_cl_pulse1_3');
    $("#disable_cl_pulse1").show();
    $("#label1_cl_pulse1_proportional").show();
    $("#label1_cl_pulse1_on_off").hide();
    $("#label2_cl_pulse1_proportional").show();
    $("#label2_cl_pulse1_on_off").hide();

    $("#riga2_cl_pulse1_1").show();
    $("#riga2_cl_pulse1_2").show();
    $("#riga1_cl_pulse1_3").hide();
}
//cl relay
function enable_channel_cl_relay_proportionalpwm() {

    check_alarm_channel_cl_relay();
    $("#disable_cl_relay").show();

    $("#riga2_cl_relay_1").show();
    $("#riga2_cl_relay_2").show();

    $("#label1_cl_relay_on_off").hide();
    $("#label1_cl_relay_else").show();
    $("#label1_cl_relay_proportionalpwm").show();
    $("#label1_cl_relay_fixedpwm").hide();

    $("#label2_cl_relay_on_off").hide();
    $("#label2_cl_relay_else").show();
    $("#label2_cl_relay_proportionalpwm").show();
    $("#label2_cl_relay_fixedpwm").hide();


}
function enable_channel_cl_relay_fixedpwm() {

    check_alarm_channel_cl_relay();
    $("#disable_cl_relay").show();

    $("#riga2_cl_relay_1").show();
    $("#riga2_cl_relay_2").show();

    $("#label1_cl_relay_on_off").show();
    $("#label1_cl_relay_else").hide();
    $("#label1_cl_relay_proportionalpwm").hide();
    $("#label1_cl_relay_fixedpwm").show();

    $("#label2_cl_relay_on_off").show();
    $("#label2_cl_relay_else").hide();
    $("#label2_cl_relay_proportionalpwm").hide();
    $("#label2_cl_relay_fixedpwm").show();

}

//cl pulse 1
$("#off_cl_pulse1").click(function () {
    disable_channel_cl_pulse1();

});
$("#proportional_cl_pulse1").click(function () {
    enable_channel_cl_pulse1_proportional();
});
$("#on_off_cl_pulse1").click(function () {
    enable_channel_cl_pulse1_on_off();
});
//cl relay
$("#on_off_cl_relay").click(function () {
    enable_channel_cl_relay_on_off();

});
$("#proportional_cl_relay").click(function () {

    enable_channel_cl_relay_proportionalpwm();
});
$("#fixed_cl_relay").click(function () {
    enable_channel_cl_relay_fixedpwm();
});
$("#off_cl_relay").click(function () {
    disable_channel_cl_relay();
});


$("#tab_ld_sp1").click(function () {
    if ($('#on_off_cl_pulse1').is(':checked')) {
        enable_channel_cl_pulse1_on_off();
    }
    if ($('#proportional_cl_pulse1').is(':checked')) {
        enable_channel_cl_pulse1_proportional();
    }
    if ($('#off_cl_pulse1').is(':checked')) {
        disable_channel_cl_pulse1();
    }
});
$("#tab_ld_sp2").click(function () {
    if ($('#on_off_cl_relay').is(':checked')) {
        enable_channel_cl_relay_on_off();
    }
    if ($('#proportional_cl_relay').is(':checked')) {
        enable_channel_cl_relay_proportionalpwm();
    }
    if ($('#fixed_cl_relay').is(':checked')) {
        enable_channel_cl_relay_fixedpwm();
    }
    if ($('#off_cl_relay').is(':checked')) {
        disable_channel_cl_relay();
    }
});



//cl pulse 1
$("#value1_cl_pulse1_1").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga1_cl_pulse1_1").removeClass('error');
    cl_pulse1_on = false;
    check_alarm_channel_cl_pulse1();
    // $("#principale").load("test.aspx");
});
$("#value2_cl_pulse1_1").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga2_cl_pulse1_1").removeClass('error');
    cl_pulse1_pm1 = false;
    check_alarm_channel_cl_pulse1();
    // $("#principale").load("test.aspx");
});
$("#value1_cl_pulse1_2").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga1_cl_pulse1_2").removeClass('error');
    cl_pulse1_off = false;
    check_alarm_channel_cl_pulse1();
    // $("#principale").load("test.aspx");
});
$("#value2_cl_pulse1_2").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga2_cl_pulse1_2").removeClass('error');
    cl_pulse1_pm2 = false;
    check_alarm_channel_cl_pulse1();
    // $("#principale").load("test.aspx");
});
$("#value2_cl_pulse1_3").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga1_cl_pulse1_3").removeClass('error');
    cl_pulse1_speed = false;
    check_alarm_channel_cl_pulse1();
    // $("#principale").load("test.aspx");
});

// cl relay
$("#value1_cl_relay_1").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga1_cl_relay_1").removeClass('error');
    cl_relay_on = false;
    check_alarm_channel_cl_relay();
    // $("#principale").load("test.aspx");
});
$("#value2_cl_relay_1").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga2_cl_relay_1").removeClass('error');
    cl_relay_pm1 = false;
    check_alarm_channel_cl_relay();
    // $("#principale").load("test.aspx");
});

$("#value1_cl_relay_2").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga1_cl_relay_2").removeClass('error');
    cl_relay_off = false;
    check_alarm_channel_cl_relay();
    // $("#principale").load("test.aspx");
});
$("#value2_cl_relay_2").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga2_cl_relay_2").removeClass('error');
    cl_relay_pm2 = false;
    check_alarm_channel_cl_relay();
    // $("#principale").load("test.aspx");
});

$("#save_setpointlds_new").click(function () {
    if (enable_send_setpoint == false) {
        result_setpoint_change(user_setpoint_disable);
        return false;
    }

    $('#save_setpointlds_new').next('p').remove();
    if (!($('#off_cl_pulse1').is(':checked'))) {
        Changed_channel('value1_cl_pulse1_1', 'riga1_cl_pulse1_1', max_ch2_value, min_ch2_value, max_fix_value2);
        Changed_channel('value2_cl_pulse1_1', 'riga2_cl_pulse1_1', 180, 0, 0);
        Changed_channel('value1_cl_pulse1_2', 'riga1_cl_pulse1_2', max_ch2_value, min_ch2_value, max_fix_value2);
        Changed_channel('value2_cl_pulse1_2', 'riga2_cl_pulse1_2', 180, 0, 0);
        Changed_channel('value2_cl_pulse1_3', 'riga1_cl_pulse1_3', 99, 0, 0);
    }
    if (!($('#off_cl_relay').is(':checked'))) {
        Changed_channel('value1_cl_relay_1', 'riga1_cl_relay_1', max_ch2_value, min_ch2_value, max_fix_value2);
        Changed_channel('value2_cl_relay_1', 'riga2_cl_relay_1', 100, 0, 0);
        Changed_channel('value1_cl_relay_2', 'riga1_cl_relay_2', max_ch2_value, min_ch2_value, max_fix_value2);
        Changed_channel('value2_cl_relay_2', 'riga2_cl_relay_2', 100, 0, 0);
    }
    if ((cl_pulse1_pm1) || (cl_pulse1_off) || (cl_pulse1_pm2) ||
           (cl_pulse1_speed) || (cl_relay_on) || (cl_relay_pm1) || (cl_relay_off) ||
           (cl_relay_pm2) ) {
        $('#save_setpointlds_new').next('p').remove();

        $('#save_setpointlds_new').after('<p class="error help-block"><span class="label label-important">' + wrong_settings + '</span></p>');
        submit_status = false;
        error_general = false;
        
        return false;
    }
    submit_status = true;
    error_general = true;
    notification['confirm'] = modify_plant;
    notification['annulla'] = annulla_impianto;

});


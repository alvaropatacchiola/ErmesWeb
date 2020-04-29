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

        case "value_alarm_soglie_time":
             alarm_soglia_time = var_alarm;
            //check_alarm_flow_time();
            break;


        case "value_alarm_soglie_max":
           

          
            alarm_soglia_max = false
            alarm_soglia_max = var_alarm;
           
            check_alarm_max();


            break;

        case "value_alarm_soglie_min":
           
            alarm_soglia_min = false
            alarm_soglia_min = var_alarm;

            check_alarm_min();
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


$("#value_alarm_soglie_time").keypress(function (evt) {
    return keypress_channel_number(evt);
});
$("#value_alarm_soglie_time").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga1_alarm_soglie_time").removeClass('error');
    alarm_soglia_time = false;

    // $("#principale").load("test.aspx");
});

$("#value_alarm_soglie_max").keypress(function (evt) {
    return keypress_channel(evt);
});
$("#value_alarm_soglie_max").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga2_alarm_soglie_max").removeClass('error');
    alarm_soglia_max = false;
    

    check_alarm_max();
    // $("#principale").load("test.aspx");
});



//$("#value_ppm_proportional").keypress(function (evt) {
//    return keypress_channel(evt);
//});

//$("#value_ppm_proportional").click(function () {
//    //$(this).val("");
//    $(this).next('p').remove();
//    $("#riga1_ppm_proportional").removeClass('error');
//    proportional = false;

//    check_alarm_proportional();
//    // $("#principale").load("test.aspx");
//});

$("#value_alarm_soglie_min").keypress(function (evt) {
    return keypress_channel(evt);
});
$("#value_alarm_soglie_min").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga3_alarm_soglie_min").removeClass('error');
    alarm_soglia_min = false;
    //check_alarm_min();
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



$("#Dis_soglie").click(function () {
    disable_soglia();
});
$("#Dose_soglie").click(function () {
    enable_soglia();
});
$("#Stop_soglie").click(function () {
    enable_soglia();
});



function enable_allarme() {
    $("#tab_ld_sp2_2").show();

}
function disable_allarme() {
    $("#tab_ld_sp2_2").hide();

}

function enable_soglia() {
  
    $("#enable_value_alarm_soglie_time").show();
    $("#enable_value_alarm_soglie_max").show();
    $("#enable_value_alarm_soglie_min").show();
}
function disable_soglia() {
    $("#enable_value_alarm_soglie_time").hide();
    $("#enable_value_alarm_soglie_max").hide();
    $("#enable_value_alarm_soglie_min").hide();

}

function check_alarm_max() {

    ;

    if ((alarm_soglia_max == true)) {
        $("#tab_ld_sp1_1").attr('style', 'color:#b94a48');
    }
    else {
        $("#tab_ld_sp1_1").removeAttr('style');
    }
}

function check_alarm_min() {

   

    if ((alarm_soglia_min == true)) {
        $("#tab_ld_sp1_1").attr('style', 'color:#b94a48');
    }
    else {
        $("#tab_ld_sp1_1").removeAttr('style');
    }
}











$("#save_flowltb_new").click(function () {
    if (enable_send_setpoint == false) {
        result_setpoint_change(user_setpoint_disable);
        return false;
    }

    $('#save_flowltb_new').next('p').remove();
    if (!($('#alarm_flow_direct').is(':checked'))) {
        Changed_channel('value_alarm_flow_time', 'riga1_alarm_flow_time', 99, 0, 0);
    }
    if (!($('#alarm_flow_reverse').is(':checked'))) {
        Changed_channel('value_alarm_flow_time', 'riga1_alarm_flow_time', 99, 0, 0);
    }

    if (!($('#Dose_soglie').is(':checked'))) {
        Changed_channel('value_alarm_soglie_time', 'riga1_alarm_soglie_time', 99, 0, 0);
    }
    if (!($('#Stop_soglie').is(':checked'))) {
        Changed_channel('value_alarm_soglie_time', 'riga1_alarm_soglie_time', 99, 0, 0);
    }

    if (!($('#Dose_soglie').is(':checked'))) {
      
        Changed_channel('value_alarm_soglie_max', 'riga2_alarm_soglie_max', max_ch2_value, min_ch2_value, max_fix_value2);
    }
    if (!($('#Stop_soglie').is(':checked'))) {
       
        Changed_channel('value_alarm_soglie_max', 'riga2_alarm_soglie_max', max_ch2_value, min_ch2_value, max_fix_value2);
    }

    if (!($('#Dose_soglie').is(':checked'))) {
        Changed_channel('value_alarm_soglie_min', 'riga3_alarm_soglie_min', max_ch2_value, min_ch2_value, max_fix_value2);
    }
    if (!($('#Stop_soglie').is(':checked'))) {
        Changed_channel('value_alarm_soglie_min', 'riga3_alarm_soglie_min', max_ch2_value, min_ch2_value, max_fix_value2);
    }


    
    
    if (
        (alarm_flow_time)
        || (alarm_soglia_time)
        || (alarm_soglia_max)
        || (alarm_soglia_min)
        ) {
        $('#save_flowltb_new').next('p').remove();

        $('#save_flowltb_new').after('<p class="error help-block"><span class="label label-important">' + wrong_settings + '</span></p>');
        submit_status = false;
        error_general = false;

        return false;
    }
    submit_status = true;
    error_general = true;
    notification['confirm'] = modify_plant;
    notification['annulla'] = annulla_impianto;

});
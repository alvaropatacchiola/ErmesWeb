
var ph_pulse1_on = false;
var ph_pulse1_pm1 = false;
var ph_pulse1_off = false;
var ph_pulse1_pm2 = false;
var ph_pulse1_speed = false;


var cl_pulse1_on = false;
var cl_pulse1_pm1 = false;
var cl_pulse1_off = false;
var cl_pulse1_pm2 = false;
var cl_pulse1_speed = false;




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
        case "value1_ph_pulse1_1":
            ph_pulse1_on = var_alarm;

            check_alarm_channel_ph_pulse1();
            
            
            break;
        case "value2_ph_pulse1_1":
            ph_pulse1_pm1 = var_alarm;
            check_alarm_channel_ph_pulse1();
           
            break;

        case "value1_ph_pulse1_2":
            ph_pulse1_off = var_alarm;
            check_alarm_channel_ph_pulse1();
            
            break;
        case "value2_ph_pulse1_2":
            ph_pulse1_pm2 = var_alarm;
            check_alarm_channel_ph_pulse1();
           
 
            break;

        case "value2_ph_pulse1_3":
            ph_pulse1_speed = var_alarm;
            check_alarm_channel_ph_pulse1();
           
            break;

            

            //cl pulse 1
        case "value1_cl_pulse1_1":
            cl_pulse1_on = var_alarm;
            check_alarm_channel_cl_pulse1();
            break;
        case "value2_cl_pulse1_1":
            cl_pulse1_pm1 = var_alarm;
            check_alarm_channel_cl_pulse1();
            break;

        case "value1_cl_pulse1_2":
            cl_pulse1_off = var_alarm;
            check_alarm_channel_cl_pulse1();
            break;
        case "value2_cl_pulse1_2":
            cl_pulse1_pm2 = var_alarm;
            check_alarm_channel_cl_pulse1();
            break;

        case "value2_cl_pulse1_3":
            cl_pulse1_speed = var_alarm;
            check_alarm_channel_cl_pulse1();
            break;
            
    }
}

function check_alarm_channel_ph_pulse1() {

 
    if ((ph_pulse1_on == true) || (ph_pulse1_pm1 == true) || (ph_pulse1_off == true) || (ph_pulse1_pm2 == true) || (ph_pulse1_speed == true)) {
        $("#tab_ld_sp1").attr('style', 'color:#b94a48');
    }
    else {
        $("#tab_ld_sp1").removeAttr('style');
    }
}

function check_alarm_channel_cl_pulse1() {

  
    if ((cl_pulse1_on == true) || (cl_pulse1_pm1 == true) || (cl_pulse1_off == true) || (cl_pulse1_pm2 == true) || (cl_pulse1_speed == true)) {
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


$("#value1_ph_pulse1_1").keypress(function (evt) {
    return keypress_channel(evt);
});
$("#value2_ph_pulse1_1").keypress(function (evt) {
    return keypress_perc(evt);
});

$("#value1_ph_pulse1_2").keypress(function (evt) {
    return keypress_channel(evt);
});
$("#value2_ph_pulse1_2").keypress(function (evt) {
    return keypress_perc(evt);
});
$("#value2_ph_pulse1_3").keypress(function (evt) {
    return keypress_perc(evt);
});

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


//ph pulse 1
function disable_channel_ph_pulse1() {
    
    ph_pulse1_on = false;
    ph_pulse1_pm1 = false;
    ph_pulse1_off = false;
    ph_pulse1_pm2 = false;
    ph_pulse1_speed = false;
    check_alarm_channel_ph_pulse1();
    remove_allarme('value1_ph_pulse1_1', 'riga1_ph_pulse1_1');
    remove_allarme('value2_ph_pulse1_1', 'riga2_ph_pulse1_1');
    remove_allarme('value1_ph_pulse1_2', 'riga1_ph_pulse1_2');
    remove_allarme('value2_ph_pulse1_2', 'riga2_ph_pulse1_2');
    remove_allarme('value2_ph_pulse1_3', 'riga1_ph_pulse1_3');




    $("#disable_ph_pulse1").hide();
}

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


//ph pulse 1
function enable_channel_ph_pulse1_on_off() {
    
    ph_pulse1_pm1 = false;
    ph_pulse1_pm2 = false;
    
    

    check_alarm_channel_ph_pulse1();
    remove_allarme('value2_ph_pulse1_1', 'riga2_ph_pulse1_1');
    remove_allarme('value2_ph_pulse1_2', 'riga2_ph_pulse1_2');
    $("#disable_ph_pulse1").show();
    $("#label1_ph_pulse1_proportional").hide();
    $("#label1_ph_pulse1_on_off").show();
    $("#label2_ph_pulse1_proportional").hide();
    $("#label2_ph_pulse1_on_off").show();

    

    $("#riga2_ph_pulse1_1").hide();
    $("#riga2_ph_pulse1_2").hide();
    $("#riga1_ph_pulse1_3").show();
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


//ph pulse 1
function enable_channel_ph_pulse1_proportional() {
    
    ph_pulse1_speed = false;
    check_alarm_channel_ph_pulse1();
    remove_allarme('value2_ph_pulse1_3', 'riga1_ph_pulse1_3');
    $("#disable_ph_pulse1").show();
    $("#label1_ph_pulse1_proportional").show();
    $("#label1_ph_pulse1_on_off").hide();
    $("#label2_ph_pulse1_proportional").show();
    $("#label2_ph_pulse1_on_off").hide();

    $("#riga2_ph_pulse1_1").show();
    $("#riga2_ph_pulse1_2").show();
    $("#riga1_ph_pulse1_3").hide();

   
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

//ph pulse 1

$("#proportional_ph_pulse1").click(function () {
    
    enable_channel_ph_pulse1_proportional();
});
$("#on_off_ph_pulse1").click(function () {
   
    enable_channel_ph_pulse1_on_off();
});


//cl pulse 1

$("#proportional_cl_pulse1").click(function () {
   
    enable_channel_cl_pulse1_proportional();
});
$("#on_off_cl_pulse1").click(function () {

    enable_channel_cl_pulse1_on_off();
});


$("#tab_ld_sp1").click(function () {
    if ($('#on_off_ph_pulse1').is(':checked')) {
        
        enable_channel_ph_pulse1_on_off();
    }
    if ($('#proportional_ph_pulse1').is(':checked')) {
        
        enable_channel_ph_pulse1_proportional();
    }
  
});


$("#tab_ld_sp4").click(function () {
    if ($('#on_off_cl_pulse1').is(':checked')) {
       
        enable_channel_cl_pulse1_on_off();
    }
    if ($('#proportional_cl_pulse1').is(':checked')) {
      
        enable_channel_cl_pulse1_proportional();
    }
    
});



//ph pulse 1
$("#value1_ph_pulse1_1").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga1_ph_pulse1_1").removeClass('error');
    ph_pulse1_on = false;
    check_alarm_channel_ph_pulse1();
    // $("#principale").load("test.aspx");
});
$("#value2_ph_pulse1_1").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga2_ph_pulse1_1").removeClass('error');
    ph_pulse1_pm1 = false;
    check_alarm_channel_ph_pulse1();
    // $("#principale").load("test.aspx");
});
$("#value1_ph_pulse1_2").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga1_ph_pulse1_2").removeClass('error');
    ph_pulse1_off = false;
    check_alarm_channel_ph_pulse1();
    // $("#principale").load("test.aspx");
});
$("#value2_ph_pulse1_2").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga2_ph_pulse1_2").removeClass('error');
    ph_pulse1_pm2 = false;
    check_alarm_channel_ph_pulse1();
    // $("#principale").load("test.aspx");
});
$("#value2_ph_pulse1_3").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga1_ph_pulse1_3").removeClass('error');
    ph_pulse1_speed = false;
    check_alarm_channel_ph_pulse1();
    // $("#principale").load("test.aspx");
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



$("#save_setpointwd_new").click(function () {
    if (enable_send_setpoint == false) {
        result_setpoint_change(user_setpoint_disable);
        return false;
    }


    $('#save_setpointwd_new').next('p').remove();
    
        Changed_channel('value1_ph_pulse1_1', 'riga1_ph_pulse1_1', max_ch1_value, min_ch1_value, max_fix_value1);
        Changed_channel('value2_ph_pulse1_1', 'riga2_ph_pulse1_1', 100, 0, 0);
        Changed_channel('value1_ph_pulse1_2', 'riga1_ph_pulse1_2', max_ch1_value, min_ch1_value, max_fix_value1);
        Changed_channel('value2_ph_pulse1_2', 'riga2_ph_pulse1_2', 100, 0, 0);
        Changed_channel('value2_ph_pulse1_3', 'riga1_ph_pulse1_3', 99, 0, 0);
    
  
        Changed_channel('value1_cl_pulse1_1', 'riga1_cl_pulse1_1', max_ch2_value, min_ch2_value, max_fix_value2);
        Changed_channel('value2_cl_pulse1_1', 'riga2_cl_pulse1_1', 100, 0, 0);
        Changed_channel('value1_cl_pulse1_2', 'riga1_cl_pulse1_2', max_ch2_value, min_ch2_value, max_fix_value2);
        Changed_channel('value2_cl_pulse1_2', 'riga2_cl_pulse1_2', 100, 0, 0);
        Changed_channel('value2_cl_pulse1_3', 'riga1_cl_pulse1_3', 99, 0, 0);

  
      

        
    if ((ph_pulse1_on) || (ph_pulse1_pm1) || (ph_pulse1_off) || (ph_pulse1_pm2) ||
           (ph_pulse1_speed) || (cl_pulse1_on) || (cl_pulse1_pm1) || (cl_pulse1_off) || (cl_pulse1_pm2) ||
           (cl_pulse1_speed) ) {
        $('#save_setpointwd_new').next('p').remove();

        $('#save_setpointwd_new').after('<p class="error help-block"><span class="label label-important">' + wrong_settings + '</span></p>');
        submit_status = false;
        error_general = false;
        return false;
    }
    submit_status = true;
    error_general = true;
    notification['confirm'] = modify_plant;
    notification['annulla'] = annulla_impianto;
});

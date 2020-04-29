
var constant = false;

var proportional = false;

var val1_propread = false;
var val2_propread = false;
var pm1_propread = false;
var pm2_propread = false;
var perc_propread = false;
var mch_propread = false;

var val1_read = false;
var val2_read = false;
var pm1_read = false;
var pm2_read = false;



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
        case "value_constant":

            constant = false
            constant = var_alarm;
            check_alarm_constant();



            break;


        case "value_ppm_proportional":
            
            proportional = false
            proportional = var_alarm;
            check_alarm_proportional();



            break;


        case "value1_mgl_propread":
           
            val1_propread = false;
            val1_propread = var_alarm;
            check_alarm_propread();

           
            break;

       
        case "value2_mgl_propread":
            val2_propread = false;
            val2_propread = var_alarm;
            check_alarm_propread();

            break;
           
            
          
        case "value1_pm_propread":
            pm1_propread = false;
            pm1_propread = var_alarm;
            check_alarm_propread();
            break;

            //ph pulse 2
        case "value2_pm_propread":
            pm2_propread = false;
            pm2_propread = var_alarm;
            check_alarm_propread();


            break;
        case "value_mch_propread":
            mch_propread = false;
            mch_propread = var_alarm;
            check_alarm_propread();


            break;

        case "value_perc_propread":
            perc_propread = false;
            perc_propread = var_alarm;
            check_alarm_propread();
            break;

        case "value1_mgl_reading":
            val1_read = false;
            val1_read = var_alarm;
            check_alarm_read();
            break;
        case "value2_mgl_reading":
            val2_read = false;
            val2_read = var_alarm;
            check_alarm_read();

            break;

        case "value1_pm_reading":
            pm1_read = false;
            pm1_read = var_alarm;
            check_alarm_read();
            break;
            //ph relay
        case "value2_pm_reading":
            pm2_read = false;
            pm2_read = var_alarm;
            check_alarm_read();
            break;
       
    }
}



function check_alarm_constant() {

    if ((constant == true) ) {
        $("#tab_ld_sp3").attr('style', 'color:#b94a48');
    }
    else {
        $("#tab_ld_sp3").removeAttr('style');
    }
}


function check_alarm_proportional() {
    
    if ((proportional == true)) {
        $("#tab_ld_sp2").attr('style', 'color:#b94a48');
    }
    else {
        $("#tab_ld_sp2").removeAttr('style');
    }
}




function check_alarm_propread() {
    if ((val1_propread == true) || (val2_propread == true) || (pm1_propread == true) || (pm2_propread == true) || (perc_propread == true) || (mch_propread == true)) {
        $("#tab_ld_sp4").attr('style', 'color:#b94a48');
    }
    else {
        $("#tab_ld_sp4").removeAttr('style');
    }
}

function check_alarm_read() {
    if ((val1_read == true) || (val2_read == true) || (pm1_read == true) || (pm2_read == true)) {
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



$("#value_constant").keypress(function (evt) {

    return keypress_perc(evt);
});

$("#value_constant").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga_constant").removeClass('error');
    constant = false;
    check_alarm_constant();
    // $("#principale").load("test.aspx");
});


$("#value_ppm_proportional").keypress(function (evt) {
    return keypress_channel(evt);
});

$("#value_ppm_proportional").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga1_ppm_proportional").removeClass('error');
    proportional = false;
 
    check_alarm_proportional();
    // $("#principale").load("test.aspx");
});


$("#value1_mgl_propread").keypress(function (evt) {
    return keypress_channel(evt);
});
$("#value1_mgl_propread").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga1_mgl_propread").removeClass('error');
    val1_propread = false;
    check_alarm_propread();
    // $("#principale").load("test.aspx");
});

$("#value2_mgl_propread").keypress(function (evt) {
    return keypress_channel(evt);
});
$("#value2_mgl_propread").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga2_mgl_propread").removeClass('error');
    val2_propread = false;
    check_alarm_propread();
    // $("#principale").load("test.aspx");
});

$("#value1_pm_propread").keypress(function (evt) {
    return keypress_perc(evt);
});
$("#value1_pm_propread").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga1_pm_propread").removeClass('error');
    pm1_propread = false;
    check_alarm_propread();
    // $("#principale").load("test.aspx");
});

//ph pulse 2
$("#value2_pm_propread").keypress(function (evt) {
    return keypress_perc(evt);
});
$("#value2_pm_propread").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga2_pm_propread").removeClass('error');
    pm2_propread = false;
    check_alarm_propread();
    // $("#principale").load("test.aspx");
});

$("#value_mch_propread").keypress(function (evt) {
    return keypress_channel(evt);
});
$("#value_mch_propread").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga4_mch_propread").removeClass('error');
    mch_propread = false;
    check_alarm_propread();
    // $("#principale").load("test.aspx");
});

$("#value_perc_propread").keypress(function (evt) {
    return keypress_perc(evt);
});
$("#value_perc_propread").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga3_perc_propread").removeClass('error');
    perc_propread = false;
    check_alarm_propread();
    // $("#principale").load("test.aspx");
});

$("#value1_mgl_reading").keypress(function (evt) {
    return keypress_channel(evt);
});
$("#value1_mgl_reading").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga1_mgl_reading").removeClass('error');
    val1_read = false;
    check_alarm_read();
    // $("#principale").load("test.aspx");
});

$("#value2_mgl_reading").keypress(function (evt) {
    return keypress_channel(evt);
});
$("#value2_mgl_reading").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga2_mgl_reading").removeClass('error');
    val2_read = false;
    check_alarm_read();
    // $("#principale").load("test.aspx");
});

//ph relay
$("#value1_pm_reading").keypress(function (evt) {
    return keypress_perc(evt);
});
$("#value1_pm_reading").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga1_pm_reading").removeClass('error');
    pm1_read = false;
    check_alarm_read();
    // $("#principale").load("test.aspx");
});

$("#value2_pm_reading").keypress(function (evt) {
    return keypress_perc(evt);
});
$("#value2_pm_reading").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga2_pm_reading").removeClass('error');
    pm2_read = false;
    check_alarm_read();
    // $("#principale").load("test.aspx");
});




function enable_mA() {
   

    $("#tab_ld_sp6_6").show();
    $("#propmA").show();
    $("enable_PropmA").show();
}
function disable_mA() {

    
    $("#tab_ld_sp6_6").hide();
    $("#propmA").hide();
    $("enable_PropmA").hide();
}






$("#save_setpointltb_new").click(function () {
    if (enable_send_setpoint == false) {
        result_setpoint_change(user_setpoint_disable);
        return false;
    }

    $('#save_setpointltb_new').next('p').remove();
    
    Changed_channel('value_constant', 'riga_constant', 180, 0, 0);

    Changed_channel('value_ppm_proportional', 'riga1_ppm_proportional', 9, 0, 2);

    Changed_channel('value1_mgl_propread', 'riga1_mgl_propread', max_ch2_value, min_ch2_value, max_fix_value2);
    Changed_channel('value2_mgl_propread', 'riga2_mgl_propread', max_ch2_value, min_ch2_value, max_fix_value2);
       
    Changed_channel('value1_pm_propread', 'riga1_pm_propread', 180, 0, 0);
    Changed_channel('value2_pm_propread', 'riga2_pm_propread', 180, 0, 0);

    Changed_channel('value_mch_propread', 'riga3_perc_propread', 100, 0, 0);
    Changed_channel('value_perc_propread', 'riga4_mch_propread', 650, 0, 2);
  
   
    Changed_channel('value1_mgl_reading', 'riga1_mgl_reading', max_ch2_value, min_ch2_value, max_fix_value2);
    Changed_channel('value2_mgl_reading', 'riga2_mgl_reading', max_ch2_value, min_ch2_value, max_fix_value2);
    Changed_channel('value1_pm_reading', 'riga1_pm_reading', 180, 0, 0);
    Changed_channel('value2_pm_reading', 'riga2_pm_reading', 180, 0, 0);


   
 
   
    if ((constant) ||
        (proportional) ||
           (val1_propread) || (val2_propread) || (pm1_propread) || (pm2_propread) || (perc_propread) || (mch_propread) ||
           (val1_read) || (val2_read) || (pm1_read) || (pm2_read)) {
        $('#save_setpointltb_new').next('p').remove();

        $('#save_setpointltb_new').after('<p class="error help-block"><span class="label label-important">' + wrong_settings + '</span></p>');
        submit_status = false;
        error_general = false;

        return false;
    }
    submit_status = true;
    error_general = true;
    notification['confirm'] = modify_plant;
    notification['annulla'] = annulla_impianto;

});

function activate_time_picker(time_type)
{
    //alert("attivazione Timer");
    if (time_type == 0) {//formato AM/pm
        $('#value_start_timer').timepicker({
            timeFormat: "hh:mm tt"
        });
        $('#value_stop_timer').timepicker({
            timeFormat: "hh:mm tt"
        });

    }
    else {
        $('#value_start_timer').timepicker({
            timeFormat: "HH:mm"
        });
        $('#value_stop_timer').timepicker({
            timeFormat: "HH:mm"
        });

    }
}
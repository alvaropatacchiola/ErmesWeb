var var_clock12 = false;

var var_clock24 = false;



var ph_password_new = false;

var ph_password_old = false;


function Changed_channel_clock(id1, id2, lunghezza) {
    var id = "#" + id1;
    var id_1 = "#" + id2;


    var value_form = $(id).val().length;

    var_alarm = false;

    if ((value_form == 0) || (value_form != lunghezza)) {

        $(id_1).removeClass('error');
        $(id).next('p').remove();

        $(id).after('<p class="error help-block"><span class="label label-important">' + date_time_wrong + '</span></p>');
        $(id_1).addClass('error')
        var_alarm = true;
    }
    else {
        var_alarm = false;
        $(id_1).removeClass('error');
        $(id).next('p').remove();
    }

    switch (id1) {
        case "clock_12_ggmmaa":
            var_clock12 = var_alarm;
            //check_alarm_clock1();
            break;

        case "clock_24_ggmmaa":
            var_clock24 = var_alarm;
            //check_alarm_clock1();
            break;
    }
}



function keypress_channel(evt) {
    return false;

}
$("#clock_12_ggmmaa").keypress(function (evt) {
   return keypress_channel(evt);
});
$("#clock_24_ggmmaa").keypress(function (evt) {
   return keypress_channel(evt);
});

function activate_time_picker() {
    $('#clock_12_ggmmaa').datetimepicker({

        dateFormat: 'dd-mm-yy',
        timeFormat: 'hh:mm tt',
        addSliderAccess: true,
        sliderAccessArgs: { touchonly: false }
               

    });
    

    $('#clock_24_ggmmaa').datetimepicker({
  
        dateFormat: 'dd-mm-yy',
        timeFormat: 'HH:mm',
        addSliderAccess: true,
        sliderAccessArgs: { touchonly: false }
    });
    set_format_data();

}

$("#clock_12").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#div_ch3").removeClass('error');
    var_clock12 = false;
    //check_alarm_timer1_start();
    // $("#principale").load("test.aspx");
});
$("#clock_24").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#div_ch3").removeClass('error');
    var_clock24 = false;
    //check_alarm_timer1_start();
    // $("#principale").load("test.aspx");
});

function set_format_data() {
    if ($('#english').is(':checked')) {
        $('#clock_formato_24_ggmmaa').show();

        $('#clock_formato_12_ggmmaa').hide();
        
    }

    if ($('#italiano').is(':checked')) {
        $('#clock_formato_24_ggmmaa').show();

        $('#clock_formato_12_ggmmaa').hide();

    }


    if ($('#english_usa').is(':checked')) {
        $('#clock_formato_12_ggmmaa').show();
 
        $('#clock_formato_24_ggmmaa').hide();

    }
}
function set_data_ora() {

    $('#clock_12_ggmmaa').val(data_ddmmyy + ore_12h);
    $('#clock_24_ggmmaa').val(data_ddmmyy + ore_24h);
}




$("#english").click(function () {

    var data_ora = "";
   
    set_format_data();
    set_data_ora();
    
});


$("#italiano").click(function () {

    var data_ora = "";

    set_format_data();
    set_data_ora();

});


$("#english_usa").click(function () {
    var data_ora = "";

    set_format_data();
    set_data_ora();
 
});



function check_alarm_password() {
    if ((ph_password_new == true) || (ph_password_old == true)) {
        $("#tab_ld_sp2").attr('style', 'color:#b94a48');
    }
    else {
        $("#tab_ld_sp2").removeAttr('style');
    }
}


function keypress_channel_password(evt) {
    var charCode = (evt.which) ? evt.which : event.keyCode

    if (charCode > 31 && (charCode < 48 || charCode > 57))
        return false;

    return true;

}
function check_password_old(id1, id2) {
    var id = "#" + id1;
    var id_1 = "#" + id2;
    var value_form_lunghezza = $(id).val().length;
    var value_form = $(id).val();
    ph_password_new = false;
    if ((password_c != value_form) || (value_form_lunghezza < 4)) {
        $(id_1).removeClass('error');
        $(id).next('p').remove();
        if (value_form_lunghezza < 4) {
            $(id).after('<p class="error help-block"><span class="label label-important">' + password_6 + '</span></p>');
        }
        else {
            $(id).after('<p class="error help-block"><span class="label label-important">' + wrong_old_password + '</span></p>');
        }
        ph_password_new = true;
        check_alarm_password();
        $(id_1).addClass('error')
        return false;
    }
    else {
        check_alarm_password();
        $(id_1).removeClass('error');
        $(id).next('p').remove();
    }
    return true;
}
function check_password_new(id1, id1_1, id2, id2_1) {
    var id = "#" + id1;
    var id1 = "#" + id1_1;
    var id_1 = "#" + id2;
    var id_2 = "#" + id2_1;
    var value_form_lunghezza = $(id).val().length;
    var value_form = $(id).val();

    var value_form_lunghezza_1 = $(id1).val().length;
    var value_form_1 = $(id1).val();

    ph_password_old = false;
    if ((value_form != value_form_1) || (value_form_lunghezza < 4) || (value_form_lunghezza_1 < 4)) {
        $(id_1).removeClass('error');
        $(id_2).removeClass('error');
        $(id).next('p').remove();
        $(id1).next('p').remove();
        if (value_form_lunghezza < 4) {
            $(id).after('<p class="error help-block"><span class="label label-important">' + password_6_new + '</span></p>');
            $(id_1).addClass('error')
            ph_password_old = true;
            check_alarm_password();

            return false;
        }
        if (value_form_lunghezza_1 < 4) {
            $(id1).after('<p class="error help-block"><span class="label label-important">' + password_uguale + '</span></p>');
            $(id_2).addClass('error')
            ph_password_old = true;
            check_alarm_password();

            return false;
        }

        if (value_form != value_form_1) {
            $(id1).after('<p class="error help-block"><span class="label label-important">' + password_uguale + '</span></p>');
            $(id_2).addClass('error')
            ph_password_old = true;
            check_alarm_password();

            return false;
        }

    }
    else {
        check_alarm_password();
        $(id_1).removeClass('error');
        $(id_2).removeClass('error');
        $(id).next('p').remove();
        $(id1).next('p').remove();
    }
    return true;
}

$("#old_password").keypress(function (evt) {
    return keypress_channel_password(evt);
});
$("#new_password").keypress(function (evt) {
    return keypress_channel_password(evt);
});
$("#confirm_password").keypress(function (evt) {
    return keypress_channel_password(evt);
});




$("#save_systemltb_new").click(function () {

    if (enable_send_setpoint == false) {
        result_setpoint_change(user_setpoint_disable);
        return false;
    }

    $('#save_systemltb_new').next('p').remove();

    validator_password_old = check_password_old('old_password', 'div_old_password');

    validator_password = check_password_new('new_password', 'confirm_password', 'div_new_password', 'div_confirm_password');

   
    if ((var_clock12) || (var_clock24)|| (validator_password_old == false) || (validator_password == false)) {
        $('#save_systemltb_new').next('p').remove();


        


        $('#save_systemltb_new').after('<p class="error help-block"><span class="label label-important">' + wrong_settings + '</span></p>');
        submit_status = false;
        error_general = false;

        return false;
    }
    submit_status = true;
    error_general = true;
    notification['confirm'] = modify_plant;
    notification['annulla'] = annulla_impianto;

});
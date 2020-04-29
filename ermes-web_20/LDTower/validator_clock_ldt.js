var var_clock12 = false;
var var_clock24 = false;
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
function set_format_data_12() {
    $('#clock_formato_12_ggmmaa').show();
    $('#clock_formato_24_ggmmaa').hide();
}
function set_format_data_24() {

    $('#clock_formato_24_ggmmaa').show();
    $('#clock_formato_12_ggmmaa').hide();
}
function set_data_ora() {

    $('#clock_12_ggmmaa').val(data_mmddyy + ore_12h);
    $('#clock_24_ggmmaa').val(data_ddmmyy + ore_24h);
}


function activate_time_picker() {
    $('#clock_12_ggmmaa').datetimepicker({
        dateFormat: 'mm-dd-yy',
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

}




//------------------------------------------------------------
//GESTIONE SALVATAGGIO DATI
$("#save_clock_new").click(function () {
    if (enable_send_setpoint == false) {
        result_setpoint_change(user_setpoint_disable);
        return false;
    }

    $('#save_clock_new').next('p').remove();
    Changed_channel_clock('clock_12_ggmmaa', 'div_ch3', 19);
    Changed_channel_clock('clock_24_ggmmaa', 'div_ch3', 16);
    if ((var_clock12) || (var_clock24)) {
        $('#save_clock_new').next('p').remove();

        $('#save_clock_new').after('<p class="error help-block"><span class="label label-important">' + wrong_settings + ' </span></p>');
        submit_status = false;
        error_general = false;
        return false;

    }
    submit_status = true;
    error_general = true;
    notification['confirm'] = modify_plant;
    notification['annulla'] = annulla_impianto;
});
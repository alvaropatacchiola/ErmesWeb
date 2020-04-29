
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
        case "clock_12_mmggaa":
            var_clock12 = var_alarm;
            //check_alarm_clock1();
            break;
        case "clock_12_aammgg":
            var_clock12 = var_alarm;
            //check_alarm_clock1();
            break;

        case "clock_24_ggmmaa":
            var_clock24 = var_alarm;
            //check_alarm_clock1();
            break;
        case "clock_24_mmggaa":
            var_clock24 = var_alarm;
            //check_alarm_clock1();
            break;
        case "clock_24_aammgg":
            var_clock24 = var_alarm;
            //check_alarm_clock1();
            break;

    }
}



function keypress_channel(evt) {
    return false;

}
$("#clock_1").keypress(function (evt) {
    return keypress_channel(evt);
});

function activate_time_picker() {
    $('#clock_12_ggmmaa').datetimepicker({
        dateFormat: 'dd-mm-yy',
        timeFormat: 'hh:mm tt',
        addSliderAccess: true,
        sliderAccessArgs: { touchonly: false }
    });
    $('#clock_12_mmggaa').datetimepicker({
        dateFormat: 'mm-dd-yy',
        timeFormat: 'hh:mm tt',
        addSliderAccess: true,
        sliderAccessArgs: { touchonly: false }
    });
    $('#clock_12_aammgg').datetimepicker({
        dateFormat: 'yy-mm-dd',
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
    $('#clock_24_mmggaa').datetimepicker({
        dateFormat: 'mm-dd-yy',
        timeFormat: 'HH:mm',
        addSliderAccess: true,
        sliderAccessArgs: { touchonly: false }
    });
    $('#clock_24_aammgg').datetimepicker({
        dateFormat: 'yy-mm-dd',
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
    if ($('#date_format_ggmmaa_enable').is(':checked')) {
        if ($('#time_format_24_enable').is(':checked')) {
            $('#clock_formato_24_ggmmaa').show();
            $('#clock_formato_12_ggmmaa').hide();
        }
        if ($('#time_format_12_enable').is(':checked')) {
            $('#clock_formato_12_ggmmaa').show();
            $('#clock_formato_24_ggmmaa').hide();
        }
        $('#clock_formato_12_mmggaa').hide();
        $('#clock_formato_12_aammgg').hide();
        $('#clock_formato_24_mmggaa').hide();
        $('#clock_formato_24_aammgg').hide();
    }

    if ($('#date_format_mmggaa_enable').is(':checked')) {
        if ($('#time_format_24_enable').is(':checked')) {
            $('#clock_formato_24_mmggaa').show();
            $('#clock_formato_12_mmggaa').hide();
        }
        if ($('#time_format_12_enable').is(':checked')) {
            $('#clock_formato_12_mmggaa').show();
            $('#clock_formato_24_mmggaa').hide();
        }
        $('#clock_formato_12_ggmmaa').hide();
        $('#clock_formato_12_aammgg').hide();
        $('#clock_formato_24_ggmmaa').hide();
        $('#clock_formato_24_aammgg').hide();
    }
    if ($('#date_format_aammgg_enable').is(':checked')) {
        if ($('#time_format_24_enable').is(':checked')) {
            $('#clock_formato_24_aammgg').show();
            $('#clock_formato_12_aammgg').hide();
        }
        if ($('#time_format_12_enable').is(':checked')) {
            $('#clock_formato_12_aammgg').show();
            $('#clock_formato_24_aammgg').hide();
        }
        $('#clock_formato_12_ggmmaa').hide();
        $('#clock_formato_12_mmggaa').hide();
        $('#clock_formato_24_ggmmaa').hide();
        $('#clock_formato_24_mmggaa').hide();
    }

}
function set_data_ora() {

    $('#clock_12_ggmmaa').val(data_ddmmyy + ore_12h);
    $('#clock_24_ggmmaa').val(data_ddmmyy + ore_24h);

    $('#clock_24_mmggaa').val(data_mmddyy + ore_24h);
    $('#clock_12_mmggaa').val(data_mmddyy + ore_12h);

    $('#clock_24_aammgg').val(data_yymmdd + ore_24h);
    $('#clock_12_aammgg').val(data_yymmdd + ore_12h);
}




$("#time_format_24_enable").click(function () {
    var data_ora = "";
    lunghezza_data = 16;
    formato_ora = 'HH:mm';
    set_format_data();
    set_data_ora();
});

$("#time_format_12_enable").click(function () {
    var data_ora = "";
    lunghezza_data = 19;
    formato_ora = 'hh:mm tt';
    set_format_data();
    set_data_ora();
});

$("#date_format_ggmmaa_enable").click(function () {
    
    formato_data = 'dd-mm-yy';
    //$('#clock_1').formatDate(formato_data, {}, {});
    set_format_data();
    set_data_ora();
});
$("#date_format_mmggaa_enable").click(function () {
    
    formato_data = 'mm-dd-yy';
    //$('#clock_1').formatDate(formato_data, {}, {});
    set_format_data();
    set_data_ora();

});
$("#date_format_aammgg_enable").click(function () {
    formato_data = 'yy-mm-dd';
    //$('#clock_1').formatDate(formato_data, {}, {});
    set_format_data();
    set_data_ora();
});

//------------------------------------------------------------
//GESTIONE SALVATAGGIO DATI
$("#save_clock_new").click(function () {

    if (enable_send_setpoint == false) {
        result_setpoint_change(user_setpoint_disable);
        return false;
    }

    $('#save_clock_new').next('p').remove();
    if ($('#time_format_12_enable').is(':checked')) {
        Changed_channel_clock('clock_12_ggmmaa', 'div_ch3', lunghezza_data);
        Changed_channel_clock('clock_12_mmggaa', 'div_ch3', lunghezza_data);
        Changed_channel_clock('clock_12_aammgg', 'div_ch3', lunghezza_data);
    }
    if ($('#time_format_24_enable').is(':checked')) {
        Changed_channel_clock('clock_24_ggmmaa', 'div_ch3', lunghezza_data);
        Changed_channel_clock('clock_24_mmggaa', 'div_ch3', lunghezza_data);
        Changed_channel_clock('clock_24_aammgg', 'div_ch3', lunghezza_data);
    }
    
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

var alarm_pre_bleed_time_hr = false;
var alarm_pre_bleed_time_min = false;
var alarm_pre_bleed_us = false;
var alarm_pre_biocide_hr = false;
var alarm_pre_biocide_min = false;
var alarm_pre_lockout_hr = false;
var alarm_pre_lockout_min = false;

var alarm_biocide1_week1_lunedi_hr = false;
var alarm_biocide1_week1_lunedi_min = false;
var alarm_biocide1_week1_martedi_hr = false;
var alarm_biocide1_week1_martedi_min = false;
var alarm_biocide1_week1_mercoledi_hr = false;
var alarm_biocide1_week1_mercoledi_min = false;
var alarm_biocide1_week1_giovedi_hr = false;
var alarm_biocide1_week1_giovedi_min = false;
var alarm_biocide1_week1_venerdi_hr = false;
var alarm_biocide1_week1_venerdi_min = false;
var alarm_biocide1_week1_sabato_hr = false;
var alarm_biocide1_week1_sabato_min = false;
var alarm_biocide1_week1_domenica_hr = false;
var alarm_biocide1_week1_domenica_min = false;

var alarm_biocide1_week2_lunedi_hr = false;
var alarm_biocide1_week2_lunedi_min = false;
var alarm_biocide1_week2_martedi_hr = false;
var alarm_biocide1_week2_martedi_min = false;
var alarm_biocide1_week2_mercoledi_hr = false;
var alarm_biocide1_week2_mercoledi_min = false;
var alarm_biocide1_week2_giovedi_hr = false;
var alarm_biocide1_week2_giovedi_min = false;
var alarm_biocide1_week2_venerdi_hr = false;
var alarm_biocide1_week2_venerdi_min = false;
var alarm_biocide1_week2_sabato_hr = false;
var alarm_biocide1_week2_sabato_min = false;
var alarm_biocide1_week2_domenica_hr = false;
var alarm_biocide1_week2_domenica_min = false;

var alarm_biocide1_week3_lunedi_hr = false;
var alarm_biocide1_week3_lunedi_min = false;
var alarm_biocide1_week3_martedi_hr = false;
var alarm_biocide1_week3_martedi_min = false;
var alarm_biocide1_week3_mercoledi_hr = false;
var alarm_biocide1_week3_mercoledi_min = false;
var alarm_biocide1_week3_giovedi_hr = false;
var alarm_biocide1_week3_giovedi_min = false;
var alarm_biocide1_week3_venerdi_hr = false;
var alarm_biocide1_week3_venerdi_min = false;
var alarm_biocide1_week3_sabato_hr = false;
var alarm_biocide1_week3_sabato_min = false;
var alarm_biocide1_week3_domenica_hr = false;
var alarm_biocide1_week3_domenica_min = false;

var alarm_biocide1_week4_lunedi_hr = false;
var alarm_biocide1_week4_lunedi_min = false;
var alarm_biocide1_week4_martedi_hr = false;
var alarm_biocide1_week4_martedi_min = false;
var alarm_biocide1_week4_mercoledi_hr = false;
var alarm_biocide1_week4_mercoledi_min = false;
var alarm_biocide1_week4_giovedi_hr = false;
var alarm_biocide1_week4_giovedi_min = false;
var alarm_biocide1_week4_venerdi_hr = false;
var alarm_biocide1_week4_venerdi_min = false;
var alarm_biocide1_week4_sabato_hr = false;
var alarm_biocide1_week4_sabato_min = false;
var alarm_biocide1_week4_domenica_hr = false;
var alarm_biocide1_week4_domenica_min = false;

var alarm_biocide1_week1_lunedi_feed = false;
var alarm_biocide1_week1_martedi_feed = false;
var alarm_biocide1_week1_mercoledi_feed = false;
var alarm_biocide1_week1_giovedi_feed = false;
var alarm_biocide1_week1_venerdi_feed = false;
var alarm_biocide1_week1_sabato_feed = false;
var alarm_biocide1_week1_domenica_feed = false;

var alarm_biocide1_week2_lunedi_feed = false;
var alarm_biocide1_week2_martedi_feed = false;
var alarm_biocide1_week2_mercoledi_feed = false;
var alarm_biocide1_week2_giovedi_feed = false;
var alarm_biocide1_week2_venerdi_feed = false;
var alarm_biocide1_week2_sabato_feed = false;
var alarm_biocide1_week2_domenica_feed = false;

var alarm_biocide1_week3_lunedi_feed = false;
var alarm_biocide1_week3_martedi_feed = false;
var alarm_biocide1_week3_mercoledi_feed = false;
var alarm_biocide1_week3_giovedi_feed = false;
var alarm_biocide1_week3_venerdi_feed = false;
var alarm_biocide1_week3_sabato_feed = false;
var alarm_biocide1_week3_domenica_feed = false;

var alarm_biocide1_week4_lunedi_feed = false;
var alarm_biocide1_week4_martedi_feed = false;
var alarm_biocide1_week4_mercoledi_feed = false;
var alarm_biocide1_week4_giovedi_feed = false;
var alarm_biocide1_week4_venerdi_feed = false;
var alarm_biocide1_week4_sabato_feed = false;
var alarm_biocide1_week4_domenica_feed = false;
 
var lunghezza_time = 0;
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
    
        case "value_pre_bleed_time_hr":
            alarm_pre_bleed_time_hr = var_alarm;
            check_alarm_biocide_biocide1();
            break;
        case "value_pre_bleed_time_min":
            alarm_feed_time_percent_hr = var_alarm;
            check_alarm_biocide_biocide1();
            break;
        case "value_pre_bleed_us":
            alarm_pre_bleed_us = var_alarm;
            check_alarm_biocide_biocide1();
            break;
        case "value_pre_biocide_hr":
            alarm_pre_biocide_hr = var_alarm;
            check_alarm_biocide_biocide1();
            break;
        case "value_pre_biocide_min":
            alarm_pre_biocide_min = var_alarm;
            check_alarm_biocide_biocide1();
            break;
        case "value_pre_lockout_hr":
            alarm_pre_lockout_hr = var_alarm;
            check_alarm_biocide_biocide1();
            break;
        case "value_pre_lockout_min":
            alarm_pre_lockout_min = var_alarm;
            check_alarm_biocide_biocide1();
            break;
//week 1
        case "value_biocide1_week1_lunedi_hr":
            alarm_biocide1_week1_lunedi_hr = var_alarm;
            check_alarm_biocide_week1();
            break;
        case "value_biocide1_week1_lunedi_min":
            alarm_biocide1_week1_lunedi_min = var_alarm;
            check_alarm_biocide_week1();
            break;
        case "value_biocide1_week1_martedi_hr":
            alarm_biocide1_week1_martedi_hr = var_alarm;
            check_alarm_biocide_week1();
            break;
        case "value_biocide1_week1_martedi_min":
            alarm_biocide1_week1_martedi_min = var_alarm;
            check_alarm_biocide_week1();
            break;
        case "value_biocide1_week1_mercoledi_hr":
            alarm_biocide1_week1_mercoledi_hr = var_alarm;
            check_alarm_biocide_week1();
            break;
        case "value_biocide1_week1_mercoledi_min":
            alarm_biocide1_week1_mercoledi_min = var_alarm;
            check_alarm_biocide_week1();
            break;
        case "value_biocide1_week1_giovedi_hr":
            alarm_biocide1_week1_giovedi_hr = var_alarm;
            check_alarm_biocide_week1();
            break;
        case "value_biocide1_week1_giovedi_min":
            alarm_biocide1_week1_giovedi_min = var_alarm;
            check_alarm_biocide_week1();
            break;
        case "value_biocide1_week1_venerdi_hr":
            alarm_biocide1_week1_venerdi_hr = var_alarm;
            check_alarm_biocide_week1();
            break;
        case "value_biocide1_week1_venerdi_min":
            alarm_biocide1_week1_venerdi_min = var_alarm;
            check_alarm_biocide_week1();
            break;
        case "value_biocide1_week1_sabato_hr":
            alarm_biocide1_week1_sabato_hr = var_alarm;
            check_alarm_biocide_week1();
            break;
        case "value_biocide1_week1_sabato_min":
            alarm_biocide1_week1_sabato_min = var_alarm;
            check_alarm_biocide_week1();
            break;
//week2
        case "value_biocide1_week2_lunedi_hr":
            alarm_biocide1_week2_lunedi_hr = var_alarm;
            check_alarm_biocide_week2();
            break;
        case "value_biocide1_week2_lunedi_min":
            alarm_biocide1_week2_lunedi_min = var_alarm;
            check_alarm_biocide_week2();
            break;
        case "value_biocide1_week2_martedi_hr":
            alarm_biocide1_week2_martedi_hr = var_alarm;
            check_alarm_biocide_week2();
            break;
        case "value_biocide1_week2_martedi_min":
            alarm_biocide1_week2_martedi_min = var_alarm;
            check_alarm_biocide_week2();
            break;
        case "value_biocide1_week2_mercoledi_hr":
            alarm_biocide1_week2_mercoledi_hr = var_alarm;
            check_alarm_biocide_week2();
            break;
        case "value_biocide1_week2_mercoledi_min":
            alarm_biocide1_week2_mercoledi_min = var_alarm;
            check_alarm_biocide_week2();
            break;
        case "value_biocide1_week2_giovedi_hr":
            alarm_biocide1_week2_giovedi_hr = var_alarm;
            check_alarm_biocide_week2();
            break;
        case "value_biocide1_week2_giovedi_min":
            alarm_biocide1_week2_giovedi_min = var_alarm;
            check_alarm_biocide_week2();
            break;
        case "value_biocide1_week2_venerdi_hr":
            alarm_biocide1_week2_venerdi_hr = var_alarm;
            check_alarm_biocide_week2();
            break;
        case "value_biocide1_week2_venerdi_min":
            alarm_biocide1_week2_venerdi_min = var_alarm;
            check_alarm_biocide_week2();
            break;
        case "value_biocide1_week2_sabato_hr":
            alarm_biocide1_week2_sabato_hr = var_alarm;
            check_alarm_biocide_week2();
            break;
        case "value_biocide1_week2_sabato_min":
            alarm_biocide1_week2_sabato_min = var_alarm;
            check_alarm_biocide_week2();
            break;
//week3
        case "value_biocide1_week3_lunedi_hr":
            alarm_biocide1_week3_lunedi_hr = var_alarm;
            check_alarm_biocide_week3();
            break;
        case "value_biocide1_week3_lunedi_min":
            alarm_biocide1_week3_lunedi_min = var_alarm;
            check_alarm_biocide_week3();
            break;
        case "value_biocide1_week3_martedi_hr":
            alarm_biocide1_week3_martedi_hr = var_alarm;
            check_alarm_biocide_week3();
            break;
        case "value_biocide1_week3_martedi_min":
            alarm_biocide1_week3_martedi_min = var_alarm;
            check_alarm_biocide_week3();
            break;
        case "value_biocide1_week3_mercoledi_hr":
            alarm_biocide1_week3_mercoledi_hr = var_alarm;
            check_alarm_biocide_week3();
            break;
        case "value_biocide1_week3_mercoledi_min":
            alarm_biocide1_week3_mercoledi_min = var_alarm;
            check_alarm_biocide_week3();
            break;
        case "value_biocide1_week3_giovedi_hr":
            alarm_biocide1_week3_giovedi_hr = var_alarm;
            check_alarm_biocide_week3();
            break;
        case "value_biocide1_week3_giovedi_min":
            alarm_biocide1_week3_giovedi_min = var_alarm;
            check_alarm_biocide_week3();
            break;
        case "value_biocide1_week3_venerdi_hr":
            alarm_biocide1_week3_venerdi_hr = var_alarm;
            check_alarm_biocide_week3();
            break;
        case "value_biocide1_week3_venerdi_min":
            alarm_biocide1_week3_venerdi_min = var_alarm;
            check_alarm_biocide_week3();
            break;
        case "value_biocide1_week3_sabato_hr":
            alarm_biocide1_week3_sabato_hr = var_alarm;
            check_alarm_biocide_week3();
            break;
        case "value_biocide1_week3_sabato_min":
            alarm_biocide1_week3_sabato_min = var_alarm;
            check_alarm_biocide_week3();
            break;
//week 4
        case "value_biocide1_week4_lunedi_hr":
            alarm_biocide1_week4_lunedi_hr = var_alarm;
            check_alarm_biocide_week4();
            break;
        case "value_biocide1_week4_lunedi_min":
            alarm_biocide1_week4_lunedi_min = var_alarm;
            check_alarm_biocide_week4();
            break;
        case "value_biocide1_week4_martedi_hr":
            alarm_biocide1_week4_martedi_hr = var_alarm;
            check_alarm_biocide_week4();
            break;
        case "value_biocide1_week4_martedi_min":
            alarm_biocide1_week4_martedi_min = var_alarm;
            check_alarm_biocide_week4();
            break;
        case "value_biocide1_week4_mercoledi_hr":
            alarm_biocide1_week4_mercoledi_hr = var_alarm;
            check_alarm_biocide_week4();
            break;
        case "value_biocide1_week4_mercoledi_min":
            alarm_biocide1_week4_mercoledi_min = var_alarm;
            check_alarm_biocide_week4();
            break;
        case "value_biocide1_week4_giovedi_hr":
            alarm_biocide1_week4_giovedi_hr = var_alarm;
            check_alarm_biocide_week4();
            break;
        case "value_biocide1_week4_giovedi_min":
            alarm_biocide1_week4_giovedi_min = var_alarm;
            check_alarm_biocide_week4();
            break;
        case "value_biocide1_week4_venerdi_hr":
            alarm_biocide1_week4_venerdi_hr = var_alarm;
            check_alarm_biocide_week4();
            break;
        case "value_biocide1_week4_venerdi_min":
            alarm_biocide1_week4_venerdi_min = var_alarm;
            check_alarm_biocide_week4();
            break;
        case "value_biocide1_week4_sabato_hr":
            alarm_biocide1_week4_sabato_hr = var_alarm;
            check_alarm_biocide_week4();
            break;
        case "value_biocide1_week4_sabato_min":
            alarm_biocide1_week4_sabato_min = var_alarm;
            check_alarm_biocide_week4();
            break;
    }
}
function Changed_channel_timer(id1, id2, lunghezza) {
    var id = "#" + id1;
    var id_1 = "#" + id2;


    var value_form = $(id).val().length;

    var_alarm = false;

    if ((value_form == 0) || (value_form != lunghezza)) {

        $(id_1).removeClass('error');
        $(id).next('p').remove();

        $(id).after('<p class="error help-block"><span class="label label-important">Time Not Valid</span></p>');
        $(id_1).addClass('error')
        var_alarm = true
    }
    else {
        $(id_1).removeClass('error');
        $(id).next('p').remove();
    }
    switch (id1) {
        case "value_biocide1_week1_lunedi_feed":
            alarm_biocide1_week1_lunedi_feed = var_alarm;
            check_alarm_biocide_week1();
            break;
        case "value_biocide1_week1_martedi_feed":
            alarm_biocide1_week1_martedi_feed = var_alarm;
            check_alarm_biocide_week1();
            break;
        case "value_biocide1_week1_mercoledi_feed":
            alarm_biocide1_week1_mercoledi_feed = var_alarm;
            check_alarm_biocide_week1();
            break;
        case "value_biocide1_week1_giovedi_feed":
            alarm_biocide1_week1_giovedi_feed = var_alarm;
            check_alarm_biocide_week1();
            break;
        case "value_biocide1_week1_venerdi_feed":
            alarm_biocide1_week1_venerdi_feed = var_alarm;
            check_alarm_biocide_week1();
            break;
        case "value_biocide1_week1_sabato_feed":
            alarm_biocide1_week1_sabato_feed = var_alarm;
            check_alarm_biocide_week1();
            break;
        case "value_biocide1_week1_domenica_feed":
            alarm_biocide1_week1_domenica_feed = var_alarm;
            check_alarm_biocide_week1();
            break;
        case "value_biocide1_week2_lunedi_feed":
            alarm_biocide1_week2_lunedi_feed = var_alarm;
            check_alarm_biocide_week2();
            break;
        case "value_biocide1_week2_martedi_feed":
            alarm_biocide1_week2_martedi_feed = var_alarm;
            check_alarm_biocide_week2();
            break;
        case "value_biocide1_week2_mercoledi_feed":
            alarm_biocide1_week2_mercoledi_feed = var_alarm;
            check_alarm_biocide_week2();
            break;
        case "value_biocide1_week2_giovedi_feed":
            alarm_biocide1_week2_giovedi_feed = var_alarm;
            check_alarm_biocide_week2();
            break;
        case "value_biocide1_week2_venerdi_feed":
            alarm_biocide1_week2_venerdi_feed = var_alarm;
            check_alarm_biocide_week2();
            break;
        case "value_biocide1_week2_sabato_feed":
            alarm_biocide1_week2_sabato_feed = var_alarm;
            check_alarm_biocide_week2();
            break;
        case "value_biocide1_week2_domenica_feed":
            alarm_biocide1_week2_domenica_feed = var_alarm;
            check_alarm_biocide_week2();
            break;
        case "value_biocide1_week3_lunedi_feed":
            alarm_biocide1_week3_lunedi_feed = var_alarm;
            check_alarm_biocide_week3();
            break;
        case "value_biocide1_week3_martedi_feed":
            alarm_biocide1_week3_martedi_feed = var_alarm;
            check_alarm_biocide_week3();
            break;
        case "value_biocide1_week3_mercoledi_feed":
            alarm_biocide1_week3_mercoledi_feed = var_alarm;
            check_alarm_biocide_week3();
            break;
        case "value_biocide1_week3_giovedi_feed":
            alarm_biocide1_week3_giovedi_feed = var_alarm;
            check_alarm_biocide_week3();
            break;
        case "value_biocide1_week3_venerdi_feed":
            alarm_biocide1_week3_venerdi_feed = var_alarm;
            check_alarm_biocide_week3();
            break;
        case "value_biocide1_week3_sabato_feed":
            alarm_biocide1_week3_sabato_feed = var_alarm;
            check_alarm_biocide_week3();
            break;
        case "value_biocide1_week3_domenica_feed":
            alarm_biocide1_week3_domenica_feed = var_alarm;
            check_alarm_biocide_week3();
            break;
        case "value_biocide1_week4_lunedi_feed":
            alarm_biocide1_week4_lunedi_feed = var_alarm;
            check_alarm_biocide_week4();
            break;
        case "value_biocide1_week4_martedi_feed":
            alarm_biocide1_week4_martedi_feed = var_alarm;
            check_alarm_biocide_week4();
            break;
        case "value_biocide1_week4_mercoledi_feed":
            alarm_biocide1_week4_mercoledi_feed = var_alarm;
            check_alarm_biocide_week4();
            break;
        case "value_biocide1_week4_giovedi_feed":
            alarm_biocide1_week4_giovedi_feed = var_alarm;
            check_alarm_biocide_week4();
            break;
        case "value_biocide1_week4_venerdi_feed":
            alarm_biocide1_week4_venerdi_feed = var_alarm;
            check_alarm_biocide_week4();
            break;
        case "value_biocide1_week4_sabato_feed":
            alarm_biocide1_week4_sabato_feed = var_alarm;
            check_alarm_biocide_week4();
            break;
        case "value_biocide1_week4_domenica_feed":
            alarm_biocide1_week4_domenica_feed = var_alarm;
            check_alarm_biocide_week4();
            break;
    }
}
function check_alarm_biocide_biocide1() {
    if ((alarm_pre_bleed_time_hr == true) || (alarm_pre_bleed_time_min == true) || (alarm_pre_bleed_us == true) || (alarm_pre_biocide_hr == true) || (alarm_pre_biocide_min == true) ||
        (alarm_pre_lockout_hr == true) ||(alarm_pre_lockout_min == true)) {
        $("#tab_tower_sp1").attr('style', 'color:#b94a48');
    }
    else {
        $("#tab_tower_sp1").removeAttr('style');
    }
}

function check_alarm_biocide_week1() {
    if ((alarm_biocide1_week1_lunedi_hr == true) || (alarm_biocide1_week1_lunedi_min == true) || (alarm_biocide1_week1_martedi_hr == true) || (alarm_biocide1_week1_martedi_min == true) ||
        (alarm_biocide1_week1_mercoledi_hr == true) || (alarm_biocide1_week1_mercoledi_min == true) || (alarm_biocide1_week1_giovedi_hr == true)||
        (alarm_biocide1_week1_giovedi_min == true) ||(alarm_biocide1_week1_venerdi_hr == true) ||(alarm_biocide1_week1_venerdi_min == true) ||(alarm_biocide1_week1_sabato_hr == true) ||
        (alarm_biocide1_week1_sabato_min == true) ||(alarm_biocide1_week1_domenica_hr == true)||(alarm_biocide1_week1_domenica_min == true)) {
        $("#tab_tower_sp2").attr('style', 'color:#b94a48');
    }
    else {
        $("#tab_tower_sp2").removeAttr('style');
    }
}
function check_alarm_biocide_week2() {
    if ((alarm_biocide1_week2_lunedi_hr == true) || (alarm_biocide1_week2_lunedi_min == true) || (alarm_biocide1_week2_martedi_hr == true) || (alarm_biocide1_week2_martedi_min == true) ||
        (alarm_biocide1_week2_mercoledi_hr == true) || (alarm_biocide1_week2_mercoledi_min == true) || (alarm_biocide1_week2_giovedi_hr == true) ||
        (alarm_biocide1_week2_giovedi_min == true) || (alarm_biocide1_week2_venerdi_hr == true) || (alarm_biocide1_week2_venerdi_min == true) || (alarm_biocide1_week2_sabato_hr == true) ||
        (alarm_biocide1_week2_sabato_min == true) || (alarm_biocide1_week2_domenica_hr == true) || (alarm_biocide1_week2_domenica_min == true)) {
        $("#tab_tower_sp3").attr('style', 'color:#b94a48');
    }
    else {
        $("#tab_tower_sp3").removeAttr('style');
    }
}
function check_alarm_biocide_week3() {
    if ((alarm_biocide1_week3_lunedi_hr == true) || (alarm_biocide1_week3_lunedi_min == true) || (alarm_biocide1_week3_martedi_hr == true) || (alarm_biocide1_week3_martedi_min == true) ||
        (alarm_biocide1_week3_mercoledi_hr == true) || (alarm_biocide1_week3_mercoledi_min == true) || (alarm_biocide1_week3_giovedi_hr == true) ||
        (alarm_biocide1_week3_giovedi_min == true) || (alarm_biocide1_week3_venerdi_hr == true) || (alarm_biocide1_week3_venerdi_min == true) || (alarm_biocide1_week3_sabato_hr == true) ||
        (alarm_biocide1_week3_sabato_min == true) || (alarm_biocide1_week3_domenica_hr == true) || (alarm_biocide1_week3_domenica_min == true)) {
        $("#tab_tower_sp4").attr('style', 'color:#b94a48');
    }
    else {
        $("#tab_tower_sp4").removeAttr('style');
    }
}
function check_alarm_biocide_week4() {
    if ((alarm_biocide1_week4_lunedi_hr == true) || (alarm_biocide1_week4_lunedi_min == true) || (alarm_biocide1_week4_martedi_hr == true) || (alarm_biocide1_week4_martedi_min == true) ||
        (alarm_biocide1_week4_mercoledi_hr == true) || (alarm_biocide1_week4_mercoledi_min == true) || (alarm_biocide1_week4_giovedi_hr == true) ||
        (alarm_biocide1_week4_giovedi_min == true) || (alarm_biocide1_week4_venerdi_hr == true) || (alarm_biocide1_week4_venerdi_min == true) || (alarm_biocide1_week4_sabato_hr == true) ||
        (alarm_biocide1_week4_sabato_min == true) || (alarm_biocide1_week4_domenica_hr == true) || (alarm_biocide1_week4_domenica_min == true)) {
        $("#tab_tower_sp5").attr('style', 'color:#b94a48');
    }
    else {
        $("#tab_tower_sp5").removeAttr('style');
    }
}



function pre_bleed_time_enable() {
    $("#enable_pre_bleed_time").show();
    $("#enable_pre_bleed_us").hide();
}
function pre_bleed_us_enable() {
    $("#enable_pre_bleed_time").hide();
    $("#enable_pre_bleed_us").show();
}
//week 1
function manage_biocide1_week1_lunedi() {
    if (($('#biocide1_week1_lunedi').is(':checked'))) {
        $("#enable_biocide1_week1_lunedi").show();
    }
    else {
        $("#enable_biocide1_week1_lunedi").hide();
    }
}
function manage_biocide1_week1_martedi() {
    if (($('#biocide1_week1_martedi').is(':checked'))) {
        $("#enable_biocide1_week1_martedi").show();
    }
    else {
        $("#enable_biocide1_week1_martedi").hide();
    }
}
function manage_biocide1_week1_mercoledi() {
    if (($('#biocide1_week1_mercoledi').is(':checked'))) {
        $("#enable_biocide1_week1_mercoledi").show();
    }
    else {
        $("#enable_biocide1_week1_mercoledi").hide();
    }
}
function manage_biocide1_week1_giovedi() {
    if (($('#biocide1_week1_giovedi').is(':checked'))) {
        $("#enable_biocide1_week1_giovedi").show();
    }
    else {
        $("#enable_biocide1_week1_giovedi").hide();
    }
}
function manage_biocide1_week1_venerdi() {
    if (($('#biocide1_week1_venerdi').is(':checked'))) {
        $("#enable_biocide1_week1_venerdi").show();
    }
    else {
        $("#enable_biocide1_week1_venerdi").hide();
    }
}
function manage_biocide1_week1_sabato() {
    if (($('#biocide1_week1_sabato').is(':checked'))) {
        $("#enable_biocide1_week1_sabato").show();
    }
    else {
        $("#enable_biocide1_week1_sabato").hide();
    }
}
function manage_biocide1_week1_domenica() {
    if (($('#biocide1_week1_domenica').is(':checked'))) {
        $("#enable_biocide1_week1_domenica").show();
    }
    else {
        $("#enable_biocide1_week1_domenica").hide();
    }
}
//week2
function manage_biocide1_week2_lunedi() {
    if (($('#biocide1_week2_lunedi').is(':checked'))) {
        $("#enable_biocide1_week2_lunedi").show();
    }
    else {
        $("#enable_biocide1_week2_lunedi").hide();
    }
}
function manage_biocide1_week2_martedi() {
    if (($('#biocide1_week2_martedi').is(':checked'))) {
        $("#enable_biocide1_week2_martedi").show();
    }
    else {
        $("#enable_biocide1_week2_martedi").hide();
    }
}
function manage_biocide1_week2_mercoledi() {
    if (($('#biocide1_week2_mercoledi').is(':checked'))) {
        $("#enable_biocide1_week2_mercoledi").show();
    }
    else {
        $("#enable_biocide1_week2_mercoledi").hide();
    }
}
function manage_biocide1_week2_giovedi() {
    if (($('#biocide1_week2_giovedi').is(':checked'))) {
        $("#enable_biocide1_week2_giovedi").show();
    }
    else {
        $("#enable_biocide1_week2_giovedi").hide();
    }
}
function manage_biocide1_week2_venerdi() {
    if (($('#biocide1_week2_venerdi').is(':checked'))) {
        $("#enable_biocide1_week2_venerdi").show();
    }
    else {
        $("#enable_biocide1_week2_venerdi").hide();
    }
}
function manage_biocide1_week2_sabato() {
    if (($('#biocide1_week2_sabato').is(':checked'))) {
        $("#enable_biocide1_week2_sabato").show();
    }
    else {
        $("#enable_biocide1_week2_sabato").hide();
    }
}
function manage_biocide1_week2_domenica() {
    if (($('#biocide1_week2_domenica').is(':checked'))) {
        $("#enable_biocide1_week2_domenica").show();
    }
    else {
        $("#enable_biocide1_week2_domenica").hide();
    }
}
//week 3
function manage_biocide1_week3_lunedi() {
    if (($('#biocide1_week3_lunedi').is(':checked'))) {
        $("#enable_biocide1_week3_lunedi").show();
    }
    else {
        $("#enable_biocide1_week3_lunedi").hide();
    }
}
function manage_biocide1_week3_martedi() {
    if (($('#biocide1_week3_martedi').is(':checked'))) {
        $("#enable_biocide1_week3_martedi").show();
    }
    else {
        $("#enable_biocide1_week3_martedi").hide();
    }
}
function manage_biocide1_week3_mercoledi() {
    if (($('#biocide1_week3_mercoledi').is(':checked'))) {
        $("#enable_biocide1_week3_mercoledi").show();
    }
    else {
        $("#enable_biocide1_week3_mercoledi").hide();
    }
}
function manage_biocide1_week3_giovedi() {
    if (($('#biocide1_week3_giovedi').is(':checked'))) {
        $("#enable_biocide1_week3_giovedi").show();
    }
    else {
        $("#enable_biocide1_week3_giovedi").hide();
    }
}
function manage_biocide1_week3_venerdi() {
    if (($('#biocide1_week3_venerdi').is(':checked'))) {
        $("#enable_biocide1_week3_venerdi").show();
    }
    else {
        $("#enable_biocide1_week3_venerdi").hide();
    }
}
function manage_biocide1_week3_sabato() {
    if (($('#biocide1_week3_sabato').is(':checked'))) {
        $("#enable_biocide1_week3_sabato").show();
    }
    else {
        $("#enable_biocide1_week3_sabato").hide();
    }
}
function manage_biocide1_week3_domenica() {
    if (($('#biocide1_week3_domenica').is(':checked'))) {
        $("#enable_biocide1_week3_domenica").show();
    }
    else {
        $("#enable_biocide1_week3_domenica").hide();
    }
}
//week 4
function manage_biocide1_week4_lunedi() {
    if (($('#biocide1_week4_lunedi').is(':checked'))) {
        $("#enable_biocide1_week4_lunedi").show();
    }
    else {
        $("#enable_biocide1_week4_lunedi").hide();
    }
}
function manage_biocide1_week4_martedi() {
    if (($('#biocide1_week4_martedi').is(':checked'))) {
        $("#enable_biocide1_week4_martedi").show();
    }
    else {
        $("#enable_biocide1_week4_martedi").hide();
    }
}
function manage_biocide1_week4_mercoledi() {
    if (($('#biocide1_week4_mercoledi').is(':checked'))) {
        $("#enable_biocide1_week4_mercoledi").show();
    }
    else {
        $("#enable_biocide1_week4_mercoledi").hide();
    }
}
function manage_biocide1_week4_giovedi() {
    if (($('#biocide1_week4_giovedi').is(':checked'))) {
        $("#enable_biocide1_week4_giovedi").show();
    }
    else {
        $("#enable_biocide1_week4_giovedi").hide();
    }
}
function manage_biocide1_week4_venerdi() {
    if (($('#biocide1_week4_venerdi').is(':checked'))) {
        $("#enable_biocide1_week4_venerdi").show();
    }
    else {
        $("#enable_biocide1_week4_venerdi").hide();
    }
}
function manage_biocide1_week4_sabato() {
    if (($('#biocide1_week4_sabato').is(':checked'))) {
        $("#enable_biocide1_week4_sabato").show();
    }
    else {
        $("#enable_biocide1_week4_sabato").hide();
    }
}
function manage_biocide1_week4_domenica() {
    if (($('#biocide1_week4_domenica').is(':checked'))) {
        $("#enable_biocide1_week4_domenica").show();
    }
    else {
        $("#enable_biocide1_week4_domenica").hide();
    }
}

$("#biocide1_week1_lunedi").click(function () {
    manage_biocide1_week1_lunedi();
});
$("#biocide1_week1_martedi").click(function () {
    manage_biocide1_week1_martedi();
});
$("#biocide1_week1_mercoledi").click(function () {
    manage_biocide1_week1_mercoledi();
});
$("#biocide1_week1_giovedi").click(function () {
    manage_biocide1_week1_giovedi();
});
$("#biocide1_week1_venerdi").click(function () {
    manage_biocide1_week1_venerdi();
});

$("#biocide1_week1_sabato").click(function () {
    manage_biocide1_week1_sabato();
});
$("#biocide1_week1_domenica").click(function () {
    manage_biocide1_week1_domenica();
});

$("#biocide1_week2_lunedi").click(function () {
    manage_biocide1_week2_lunedi();
});
$("#biocide1_week2_martedi").click(function () {
    manage_biocide1_week2_martedi();
});
$("#biocide1_week2_mercoledi").click(function () {
    manage_biocide1_week2_mercoledi();
});
$("#biocide1_week2_giovedi").click(function () {
    manage_biocide1_week2_giovedi();
});
$("#biocide1_week2_venerdi").click(function () {
    manage_biocide1_week2_venerdi();
});

$("#biocide1_week2_sabato").click(function () {
    manage_biocide1_week2_sabato();
});
$("#biocide1_week2_domenica").click(function () {
    manage_biocide1_week2_domenica();
});
$("#biocide1_week3_lunedi").click(function () {
    manage_biocide1_week3_lunedi();
});
$("#biocide1_week3_martedi").click(function () {
    manage_biocide1_week3_martedi();
});
$("#biocide1_week3_mercoledi").click(function () {
    manage_biocide1_week3_mercoledi();
});
$("#biocide1_week3_giovedi").click(function () {
    manage_biocide1_week3_giovedi();
});
$("#biocide1_week3_venerdi").click(function () {
    manage_biocide1_week3_venerdi();
});

$("#biocide1_week3_sabato").click(function () {
    manage_biocide1_week3_sabato();
});
$("#biocide1_week3_domenica").click(function () {
    manage_biocide1_week3_domenica();
});
$("#biocide1_week4_lunedi").click(function () {
    manage_biocide1_week4_lunedi();
});
$("#biocide1_week4_martedi").click(function () {
    manage_biocide1_week4_martedi();
});
$("#biocide1_week4_mercoledi").click(function () {
    manage_biocide1_week4_mercoledi();
});
$("#biocide1_week4_giovedi").click(function () {
    manage_biocide1_week4_giovedi();
});
$("#biocide1_week4_venerdi").click(function () {
    manage_biocide1_week4_venerdi();
});

$("#biocide1_week4_sabato").click(function () {
    manage_biocide1_week4_sabato();
});
$("#biocide1_week4_domenica").click(function () {
    manage_biocide1_week4_domenica();
});


$("#pre_bleed_time").click(function () {
    
    pre_bleed_time_enable();
});
$("#pre_bleed_us").click(function () {
       pre_bleed_us_enable();
});

function activate_time_picker_biocide(time_type) {
    
    if (time_type == 0) {//formato AM/pm
        lunghezza_time = 8;
        
        $('#value_biocide1_week1_lunedi_feed').timepicker({
            timeFormat: "hh:mm tt"
        });
        $('#value_biocide1_week1_martedi_feed').timepicker({
            timeFormat: "hh:mm tt"
        });
        $('#value_biocide1_week1_mercoledi_feed').timepicker({
            timeFormat: "hh:mm tt"
        });
        $('#value_biocide1_week1_giovedi_feed').timepicker({
            timeFormat: "hh:mm tt"
        });
        $('#value_biocide1_week1_venerdi_feed').timepicker({
            timeFormat: "hh:mm tt"
        });
        $('#value_biocide1_week1_sabato_feed').timepicker({
            timeFormat: "hh:mm tt"
        });
        $('#value_biocide1_week1_domenica_feed').timepicker({
            timeFormat: "hh:mm tt"
        });
        $('#value_biocide1_week2_lunedi_feed').timepicker({
            timeFormat: "hh:mm tt"
        });
        $('#value_biocide1_week2_martedi_feed').timepicker({
            timeFormat: "hh:mm tt"
        });
        $('#value_biocide1_week2_mercoledi_feed').timepicker({
            timeFormat: "hh:mm tt"
        });
        $('#value_biocide1_week2_giovedi_feed').timepicker({
            timeFormat: "hh:mm tt"
        });
        $('#value_biocide1_week2_venerdi_feed').timepicker({
            timeFormat: "hh:mm tt"
        });
        $('#value_biocide1_week2_sabato_feed').timepicker({
            timeFormat: "hh:mm tt"
        });
        $('#value_biocide1_week2_domenica_feed').timepicker({
            timeFormat: "hh:mm tt"
        });
        $('#value_biocide1_week3_lunedi_feed').timepicker({
            timeFormat: "hh:mm tt"
        });
        $('#value_biocide1_week3_martedi_feed').timepicker({
            timeFormat: "hh:mm tt"
        });
        $('#value_biocide1_week3_mercoledi_feed').timepicker({
            timeFormat: "hh:mm tt"
        });
        $('#value_biocide1_week3_giovedi_feed').timepicker({
            timeFormat: "hh:mm tt"
        });
        $('#value_biocide1_week3_venerdi_feed').timepicker({
            timeFormat: "hh:mm tt"
        });
        $('#value_biocide1_week3_sabato_feed').timepicker({
            timeFormat: "hh:mm tt"
        });
        $('#value_biocide1_week3_domenica_feed').timepicker({
            timeFormat: "hh:mm tt"
        });
        $('#value_biocide1_week4_lunedi_feed').timepicker({
            timeFormat: "hh:mm tt"
        });
        $('#value_biocide1_week4_martedi_feed').timepicker({
            timeFormat: "hh:mm tt"
        });
        $('#value_biocide1_week4_mercoledi_feed').timepicker({
            timeFormat: "hh:mm tt"
        });
        $('#value_biocide1_week4_giovedi_feed').timepicker({
            timeFormat: "hh:mm tt"
        });
        $('#value_biocide1_week4_venerdi_feed').timepicker({
            timeFormat: "hh:mm tt"
        });
        $('#value_biocide1_week4_sabato_feed').timepicker({
            timeFormat: "hh:mm tt"
        });
        $('#value_biocide1_week4_domenica_feed').timepicker({
            timeFormat: "hh:mm tt"
        });
    }
    else {//formato 24
        lunghezza_time = 5;
          $('#value_biocide1_week1_lunedi_feed').timepicker({
            timeFormat: "HH:mm"
        });
        $('#value_biocide1_week1_martedi_feed').timepicker({
            timeFormat: "HH:mm"
        });
        $('#value_biocide1_week1_mercoledi_feed').timepicker({
            timeFormat: "HH:mm"
        });
        $('#value_biocide1_week1_giovedi_feed').timepicker({
            timeFormat: "HH:mm"
        });
        $('#value_biocide1_week1_venerdi_feed').timepicker({
            timeFormat: "HH:mm"
        });
        $('#value_biocide1_week1_sabato_feed').timepicker({
            timeFormat: "HH:mm"
        });
        $('#value_biocide1_week1_domenica_feed').timepicker({
            timeFormat: "HH:mm"
        });
        $('#value_biocide1_week2_lunedi_feed').timepicker({
            timeFormat: "HH:mm"
        });
        $('#value_biocide1_week2_martedi_feed').timepicker({
            timeFormat: "HH:mm"
        });
        $('#value_biocide1_week2_mercoledi_feed').timepicker({
            timeFormat: "HH:mm"
        });
        $('#value_biocide1_week2_giovedi_feed').timepicker({
            timeFormat: "HH:mm"
        });
        $('#value_biocide1_week2_venerdi_feed').timepicker({
            timeFormat: "HH:mm"
        });
        $('#value_biocide1_week2_sabato_feed').timepicker({
            timeFormat: "HH:mm"
        });
        $('#value_biocide1_week2_domenica_feed').timepicker({
            timeFormat: "HH:mm"
        });
        $('#value_biocide1_week3_lunedi_feed').timepicker({
            timeFormat: "HH:mm"
        });
        $('#value_biocide1_week3_martedi_feed').timepicker({
            timeFormat: "HH:mm"
        });
        $('#value_biocide1_week3_mercoledi_feed').timepicker({
            timeFormat: "HH:mm"
        });
        $('#value_biocide1_week3_giovedi_feed').timepicker({
            timeFormat: "HH:mm"
        });
        $('#value_biocide1_week3_venerdi_feed').timepicker({
            timeFormat: "HH:mm"
        });
        $('#value_biocide1_week3_sabato_feed').timepicker({
            timeFormat: "HH:mm"
        });
        $('#value_biocide1_week3_domenica_feed').timepicker({
            timeFormat: "HH:mm"
        });
        $('#value_biocide1_week4_lunedi_feed').timepicker({
            timeFormat: "HH:mm"
        });
        $('#value_biocide1_week4_martedi_feed').timepicker({
            timeFormat: "HH:mm"
        });
        $('#value_biocide1_week4_mercoledi_feed').timepicker({
            timeFormat: "HH:mm"
        });
        $('#value_biocide1_week4_giovedi_feed').timepicker({
            timeFormat: "HH:mm"
        });
        $('#value_biocide1_week4_venerdi_feed').timepicker({
            timeFormat: "HH:mm"
        });
        $('#value_biocide1_week4_sabato_feed').timepicker({
            timeFormat: "HH:mm"
        });
        $('#value_biocide1_week4_domenica_feed').timepicker({
            timeFormat: "HH:mm"
        });
    }
}

//keypress time
function keypress_channel(evt) {
    return false;
}
$("#value_biocide1_week1_lunedi_feed").keypress(function (evt) {
    return keypress_channel(evt);
});
$("#value_biocide1_week1_martedi_feed").keypress(function (evt) {
    return keypress_channel(evt);
});
$("#value_biocide1_week1_mercoledi_feed").keypress(function (evt) {
    return keypress_channel(evt);
});
$("#value_biocide1_week1_giovedi_feed").keypress(function (evt) {
    return keypress_channel(evt);
});
$("#value_biocide1_week1_venerdi_feed").keypress(function (evt) {
    return keypress_channel(evt);
});
$("#value_biocide1_week1_sabato_feed").keypress(function (evt) {
    return keypress_channel(evt);
});
$("#value_biocide1_week1_domenica_feed").keypress(function (evt) {
    return keypress_channel(evt);
});
$("#value_biocide1_week2_lunedi_feed").keypress(function (evt) {
    return keypress_channel(evt);
});
$("#value_biocide1_week2_martedi_feed").keypress(function (evt) {
    return keypress_channel(evt);
});
$("#value_biocide1_week2_mercoledi_feed").keypress(function (evt) {
    return keypress_channel(evt);
});
$("#value_biocide1_week2_giovedi_feed").keypress(function (evt) {
    return keypress_channel(evt);
});
$("#value_biocide1_week2_venerdi_feed").keypress(function (evt) {
    return keypress_channel(evt);
});
$("#value_biocide1_week2_sabato_feed").keypress(function (evt) {
    return keypress_channel(evt);
});
$("#value_biocide1_week2_domenica_feed").keypress(function (evt) {
    return keypress_channel(evt);
});
$("#value_biocide1_week3_lunedi_feed").keypress(function (evt) {
    return keypress_channel(evt);
});
$("#value_biocide1_week3_martedi_feed").keypress(function (evt) {
    return keypress_channel(evt);
});
$("#value_biocide1_week3_mercoledi_feed").keypress(function (evt) {
    return keypress_channel(evt);
});
$("#value_biocide1_week3_giovedi_feed").keypress(function (evt) {
    return keypress_channel(evt);
});
$("#value_biocide1_week3_venerdi_feed").keypress(function (evt) {
    return keypress_channel(evt);
});
$("#value_biocide1_week3_sabato_feed").keypress(function (evt) {
    return keypress_channel(evt);
});
$("#value_biocide1_week3_domenica_feed").keypress(function (evt) {
    return keypress_channel(evt);
});
$("#value_biocide1_week4_lunedi_feed").keypress(function (evt) {
    return keypress_channel(evt);
});
$("#value_biocide1_week4_martedi_feed").keypress(function (evt) {
    return keypress_channel(evt);
});
$("#value_biocide1_week4_mercoledi_feed").keypress(function (evt) {
    return keypress_channel(evt);
});
$("#value_biocide1_week4_giovedi_feed").keypress(function (evt) {
    return keypress_channel(evt);
});
$("#value_biocide1_week4_venerdi_feed").keypress(function (evt) {
    return keypress_channel(evt);
});
$("#value_biocide1_week4_sabato_feed").keypress(function (evt) {
    return keypress_channel(evt);
});
$("#value_biocide1_week4_domenica_feed").keypress(function (evt) {
    return keypress_channel(evt);
});

$("#value_pre_bleed_time_hr").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga_pre_bleed_time_hr").removeClass('error');
    alarm_pre_bleed_time_hr = false;
    check_alarm_biocide_biocide1();
    // $("#principale").load("test.aspx");
});
$("#value_pre_bleed_time_min").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga_pre_bleed_time_min").removeClass('error');
    alarm_pre_bleed_time_min = false;
    check_alarm_biocide_biocide1();
    // $("#principale").load("test.aspx");
});
$("#value_pre_bleed_us").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga_pre_bleed_us").removeClass('error');
    alarm_pre_bleed_us = false;
    check_alarm_biocide_biocide1();
    // $("#principale").load("test.aspx");
});
$("#value_pre_biocide_hr").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga_pre_biocide_hr").removeClass('error');
    alarm_pre_biocide_hr = false;
    check_alarm_biocide_biocide1();
    // $("#principale").load("test.aspx");
});
$("#value_pre_biocide_min").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga_pre_biocide_min").removeClass('error');
    alarm_pre_biocide_min = false;
    check_alarm_biocide_biocide1();
    // $("#principale").load("test.aspx");
});
$("#value_pre_lockout_hr").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga_pre_lockout_hr").removeClass('error');
    alarm_pre_lockout_hr = false;
    check_alarm_biocide_biocide1();
    // $("#principale").load("test.aspx");
});
//week1
$("#value_biocide1_week1_lunedi_hr").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga_biocide1_week1_lunedi_hr").removeClass('error');
    alarm_biocide1_week1_lunedi_hr = false;
    check_alarm_biocide_week1();
    // $("#principale").load("test.aspx");
});
$("#value_biocide1_week1_lunedi_min").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga_biocide1_week1_lunedi_min").removeClass('error');
    alarm_biocide1_week1_lunedi_min = false;
    check_alarm_biocide_week1();
    // $("#principale").load("test.aspx");
});
$("#value_biocide1_week1_lunedi_feed").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga_biocide1_week1_lunedi_feed").removeClass('error');
    alarm_biocide1_week1_lunedi_feed = false;
    check_alarm_biocide_week1();
    // $("#principale").load("test.aspx");
});

$("#value_biocide1_week1_martedi_hr").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga_biocide1_week1_martedi_hr").removeClass('error');
    alarm_biocide1_martedi_hr = false;
    check_alarm_biocide_week1();
    // $("#principale").load("test.aspx");
});
$("#value_biocide1_week1_martedi_min").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga_biocide1_week1_martedi_min").removeClass('error');
    alarm_biocide1_week1_martedi_min = false;
    check_alarm_biocide_week1();
    // $("#principale").load("test.aspx");
});
$("#value_biocide1_week1_martedi_feed").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga_biocide1_week1_martedi_feed").removeClass('error');
    alarm_biocide1_week1_martedi_feed = false;
    check_alarm_biocide_week1();
    // $("#principale").load("test.aspx");
});

$("#value_biocide1_week1_mercoledi_hr").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga_biocide1_week1_mercoledi_hr").removeClass('error');
    alarm_biocide1_mercoledi_hr = false;
    check_alarm_biocide_week1();
    // $("#principale").load("test.aspx");
});
$("#value_biocide1_week1_mercoledi_min").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga_biocide1_week1_mercoledi_min").removeClass('error');
    alarm_biocide1_week1_mercoledi_min = false;
    check_alarm_biocide_week1();
    // $("#principale").load("test.aspx");
});
$("#value_biocide1_week1_mercoledi_feed").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga_biocide1_week1_mercoledi_feed").removeClass('error');
    alarm_biocide1_week1_mercoledi_feed = false;
    check_alarm_biocide_week1();
    // $("#principale").load("test.aspx");
});
$("#value_biocide1_week1_giovedi_hr").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga_biocide1_week1_giovedi_hr").removeClass('error');
    alarm_biocide1_giovedi_hr = false;
    check_alarm_biocide_week1();
    // $("#principale").load("test.aspx");
});
$("#value_biocide1_week1_giovedi_min").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga_biocide1_week1_giovedi_min").removeClass('error');
    alarm_biocide1_week1_giovedi_min = false;
    check_alarm_biocide_week1();
    // $("#principale").load("test.aspx");
});
$("#value_biocide1_week1_giovedi_feed").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga_biocide1_week1_giovedi_feed").removeClass('error');
    alarm_biocide1_week1_giovedi_feed = false;
    check_alarm_biocide_week1();
    // $("#principale").load("test.aspx");
});
$("#value_biocide1_week1_venerdi_hr").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga_biocide1_week1_venerdi_hr").removeClass('error');
    alarm_biocide1_venerdi_hr = false;
    check_alarm_biocide_week1();
    // $("#principale").load("test.aspx");
});
$("#value_biocide1_week1_venerdi_min").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga_biocide1_week1_venerdi_min").removeClass('error');
    alarm_biocide1_week1_venerdi_min = false;
    check_alarm_biocide_week1();
    // $("#principale").load("test.aspx");
});
$("#value_biocide1_week1_venerdi_feed").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga_biocide1_week1_venerdi_feed").removeClass('error');
    alarm_biocide1_week1_venerdi_feed = false;
    check_alarm_biocide_week1();
    // $("#principale").load("test.aspx");
});
$("#value_biocide1_week1_sabato_hr").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga_biocide1_week1_sabato_hr").removeClass('error');
    alarm_biocide1_sabato_hr = false;
    check_alarm_biocide_week1();
    // $("#principale").load("test.aspx");
});
$("#value_biocide1_week1_sabato_min").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga_biocide1_week1_sabato_min").removeClass('error');
    alarm_biocide1_week1_sabato_min = false;
    check_alarm_biocide_week1();
    // $("#principale").load("test.aspx");
});
$("#value_biocide1_week1_sabato_feed").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga_biocide1_week1_sabato_feed").removeClass('error');
    alarm_biocide1_week1_sabato_feed = false;
    check_alarm_biocide_week1();
    // $("#principale").load("test.aspx");
});
$("#value_biocide1_week1_domenica_hr").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga_biocide1_week1_domenica_hr").removeClass('error');
    alarm_biocide1_domenica_hr = false;
    check_alarm_biocide_week1();
    // $("#principale").load("test.aspx");
});
$("#value_biocide1_week1_domenica_min").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga_biocide1_week1_domenica_min").removeClass('error');
    alarm_biocide1_week1_domenica_min = false;
    check_alarm_biocide_week1();
    // $("#principale").load("test.aspx");
});
$("#value_biocide1_week1_domenica_feed").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga_biocide1_week1_domenica_feed").removeClass('error');
    alarm_biocide1_week1_domenica_feed = false;
    check_alarm_biocide_week1();
    // $("#principale").load("test.aspx");
});
//week2
$("#value_biocide1_week2_lunedi_hr").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga_biocide1_week2_lunedi_hr").removeClass('error');
    alarm_biocide1_week2_lunedi_hr = false;
    check_alarm_biocide_week2();
    // $("#principale").load("test.aspx");
});
$("#value_biocide1_week2_lunedi_min").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga_biocide1_week2_lunedi_min").removeClass('error');
    alarm_biocide1_week2_lunedi_min = false;
    check_alarm_biocide_week2();
    // $("#principale").load("test.aspx");
});
$("#value_biocide1_week2_lunedi_feed").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga_biocide1_week2_lunedi_feed").removeClass('error');
    alarm_biocide1_week2_lunedi_feed = false;
    check_alarm_biocide_week2();
    // $("#principale").load("test.aspx");
});

$("#value_biocide1_week2_martedi_hr").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga_biocide1_week2_martedi_hr").removeClass('error');
    alarm_biocide1_martedi_hr = false;
    check_alarm_biocide_week2();
    // $("#principale").load("test.aspx");
});
$("#value_biocide1_week2_martedi_min").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga_biocide1_week2_martedi_min").removeClass('error');
    alarm_biocide1_week2_martedi_min = false;
    check_alarm_biocide_week2();
    // $("#principale").load("test.aspx");
});
$("#value_biocide1_week2_martedi_feed").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga_biocide1_week2_martedi_feed").removeClass('error');
    alarm_biocide1_week2_martedi_feed = false;
    check_alarm_biocide_week2();
    // $("#principale").load("test.aspx");
});

$("#value_biocide1_week2_mercoledi_hr").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga_biocide1_week2_mercoledi_hr").removeClass('error');
    alarm_biocide1_mercoledi_hr = false;
    check_alarm_biocide_week2();
    // $("#principale").load("test.aspx");
});
$("#value_biocide1_week2_mercoledi_min").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga_biocide1_week2_mercoledi_min").removeClass('error');
    alarm_biocide1_week2_mercoledi_min = false;
    check_alarm_biocide_week2();
    // $("#principale").load("test.aspx");
});
$("#value_biocide1_week2_mercoledi_feed").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga_biocide1_week2_mercoledi_feed").removeClass('error');
    alarm_biocide1_week2_mercoledi_feed = false;
    check_alarm_biocide_week2();
    // $("#principale").load("test.aspx");
});
$("#value_biocide1_week2_giovedi_hr").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga_biocide1_week2_giovedi_hr").removeClass('error');
    alarm_biocide1_giovedi_hr = false;
    check_alarm_biocide_week2();
    // $("#principale").load("test.aspx");
});
$("#value_biocide1_week2_giovedi_min").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga_biocide1_week2_giovedi_min").removeClass('error');
    alarm_biocide1_week2_giovedi_min = false;
    check_alarm_biocide_week2();
    // $("#principale").load("test.aspx");
});
$("#value_biocide1_week2_giovedi_feed").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga_biocide1_week2_giovedi_feed").removeClass('error');
    alarm_biocide1_week2_giovedi_feed = false;
    check_alarm_biocide_week2();
    // $("#principale").load("test.aspx");
});
$("#value_biocide1_week2_venerdi_hr").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga_biocide1_week2_venerdi_hr").removeClass('error');
    alarm_biocide1_venerdi_hr = false;
    check_alarm_biocide_week2();
    // $("#principale").load("test.aspx");
});
$("#value_biocide1_week2_venerdi_min").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga_biocide1_week2_venerdi_min").removeClass('error');
    alarm_biocide1_week2_venerdi_min = false;
    check_alarm_biocide_week2();
    // $("#principale").load("test.aspx");
});
$("#value_biocide1_week2_venerdi_feed").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga_biocide1_week2_venerdi_feed").removeClass('error');
    alarm_biocide1_week2_venerdi_feed = false;
    check_alarm_biocide_week2();
    // $("#principale").load("test.aspx");
});
$("#value_biocide1_week2_sabato_hr").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga_biocide1_week2_sabato_hr").removeClass('error');
    alarm_biocide1_sabato_hr = false;
    check_alarm_biocide_week2();
    // $("#principale").load("test.aspx");
});
$("#value_biocide1_week2_sabato_min").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga_biocide1_week2_sabato_min").removeClass('error');
    alarm_biocide1_week2_sabato_min = false;
    check_alarm_biocide_week2();
    // $("#principale").load("test.aspx");
});
$("#value_biocide1_week2_sabato_feed").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga_biocide1_week2_sabato_feed").removeClass('error');
    alarm_biocide1_week2_sabato_feed = false;
    check_alarm_biocide_week2();
    // $("#principale").load("test.aspx");
});
$("#value_biocide1_week2_domenica_hr").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga_biocide1_week2_domenica_hr").removeClass('error');
    alarm_biocide1_domenica_hr = false;
    check_alarm_biocide_week2();
    // $("#principale").load("test.aspx");
});
$("#value_biocide1_week2_domenica_min").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga_biocide1_week2_domenica_min").removeClass('error');
    alarm_biocide1_week2_domenica_min = false;
    check_alarm_biocide_week2();
    // $("#principale").load("test.aspx");
});
$("#value_biocide1_week2_domenica_feed").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga_biocide1_week2_domenica_feed").removeClass('error');
    alarm_biocide1_week2_domenica_feed = false;
    check_alarm_biocide_week2();
    // $("#principale").load("test.aspx");
});
//week3
$("#value_biocide1_week3_lunedi_hr").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga_biocide1_week3_lunedi_hr").removeClass('error');
    alarm_biocide1_week3_lunedi_hr = false;
    check_alarm_biocide_week3();
    // $("#principale").load("test.aspx");
});
$("#value_biocide1_week3_lunedi_min").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga_biocide1_week3_lunedi_min").removeClass('error');
    alarm_biocide1_week3_lunedi_min = false;
    check_alarm_biocide_week3();
    // $("#principale").load("test.aspx");
});
$("#value_biocide1_week3_lunedi_feed").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga_biocide1_week3_lunedi_feed").removeClass('error');
    alarm_biocide1_week3_lunedi_feed = false;
    check_alarm_biocide_week3();
    // $("#principale").load("test.aspx");
});

$("#value_biocide1_week3_martedi_hr").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga_biocide1_week3_martedi_hr").removeClass('error');
    alarm_biocide1_martedi_hr = false;
    check_alarm_biocide_week3();
    // $("#principale").load("test.aspx");
});
$("#value_biocide1_week3_martedi_min").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga_biocide1_week3_martedi_min").removeClass('error');
    alarm_biocide1_week3_martedi_min = false;
    check_alarm_biocide_week3();
    // $("#principale").load("test.aspx");
});
$("#value_biocide1_week3_martedi_feed").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga_biocide1_week3_martedi_feed").removeClass('error');
    alarm_biocide1_week3_martedi_feed = false;
    check_alarm_biocide_week3();
    // $("#principale").load("test.aspx");
});

$("#value_biocide1_week3_mercoledi_hr").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga_biocide1_week3_mercoledi_hr").removeClass('error');
    alarm_biocide1_mercoledi_hr = false;
    check_alarm_biocide_week3();
    // $("#principale").load("test.aspx");
});
$("#value_biocide1_week3_mercoledi_min").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga_biocide1_week3_mercoledi_min").removeClass('error');
    alarm_biocide1_week3_mercoledi_min = false;
    check_alarm_biocide_week3();
    // $("#principale").load("test.aspx");
});
$("#value_biocide1_week3_mercoledi_feed").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga_biocide1_week3_mercoledi_feed").removeClass('error');
    alarm_biocide1_week3_mercoledi_feed = false;
    check_alarm_biocide_week3();
    // $("#principale").load("test.aspx");
});
$("#value_biocide1_week3_giovedi_hr").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga_biocide1_week3_giovedi_hr").removeClass('error');
    alarm_biocide1_giovedi_hr = false;
    check_alarm_biocide_week3();
    // $("#principale").load("test.aspx");
});
$("#value_biocide1_week3_giovedi_min").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga_biocide1_week3_giovedi_min").removeClass('error');
    alarm_biocide1_week3_giovedi_min = false;
    check_alarm_biocide_week3();
    // $("#principale").load("test.aspx");
});
$("#value_biocide1_week3_giovedi_feed").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga_biocide1_week3_giovedi_feed").removeClass('error');
    alarm_biocide1_week3_giovedi_feed = false;
    check_alarm_biocide_week3();
    // $("#principale").load("test.aspx");
});
$("#value_biocide1_week3_venerdi_hr").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga_biocide1_week3_venerdi_hr").removeClass('error');
    alarm_biocide1_venerdi_hr = false;
    check_alarm_biocide_week3();
    // $("#principale").load("test.aspx");
});
$("#value_biocide1_week3_venerdi_min").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga_biocide1_week3_venerdi_min").removeClass('error');
    alarm_biocide1_week3_venerdi_min = false;
    check_alarm_biocide_week3();
    // $("#principale").load("test.aspx");
});
$("#value_biocide1_week3_venerdi_feed").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga_biocide1_week3_venerdi_feed").removeClass('error');
    alarm_biocide1_week3_venerdi_feed = false;
    check_alarm_biocide_week3();
    // $("#principale").load("test.aspx");
});
$("#value_biocide1_week3_sabato_hr").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga_biocide1_week3_sabato_hr").removeClass('error');
    alarm_biocide1_sabato_hr = false;
    check_alarm_biocide_week3();
    // $("#principale").load("test.aspx");
});
$("#value_biocide1_week3_sabato_min").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga_biocide1_week3_sabato_min").removeClass('error');
    alarm_biocide1_week3_sabato_min = false;
    check_alarm_biocide_week3();
    // $("#principale").load("test.aspx");
});
$("#value_biocide1_week3_sabato_feed").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga_biocide1_week3_sabato_feed").removeClass('error');
    alarm_biocide1_week3_sabato_feed = false;
    check_alarm_biocide_week3();
    // $("#principale").load("test.aspx");
});
$("#value_biocide1_week3_domenica_hr").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga_biocide1_week3_domenica_hr").removeClass('error');
    alarm_biocide1_domenica_hr = false;
    check_alarm_biocide_week3();
    // $("#principale").load("test.aspx");
});
$("#value_biocide1_week3_domenica_min").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga_biocide1_week3_domenica_min").removeClass('error');
    alarm_biocide1_week3_domenica_min = false;
    check_alarm_biocide_week3();
    // $("#principale").load("test.aspx");
});
$("#value_biocide1_week3_domenica_feed").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga_biocide1_week3_domenica_feed").removeClass('error');
    alarm_biocide1_week3_domenica_feed = false;
    check_alarm_biocide_week3();
    // $("#principale").load("test.aspx");
});
//week4
$("#value_biocide1_week4_lunedi_hr").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga_biocide1_week4_lunedi_hr").removeClass('error');
    alarm_biocide1_week4_lunedi_hr = false;
    check_alarm_biocide_week4();
    // $("#principale").load("test.aspx");
});
$("#value_biocide1_week4_lunedi_min").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga_biocide1_week4_lunedi_min").removeClass('error');
    alarm_biocide1_week4_lunedi_min = false;
    check_alarm_biocide_week4();
    // $("#principale").load("test.aspx");
});
$("#value_biocide1_week4_lunedi_feed").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga_biocide1_week4_lunedi_feed").removeClass('error');
    alarm_biocide1_week4_lunedi_feed = false;
    check_alarm_biocide_week4();
    // $("#principale").load("test.aspx");
});

$("#value_biocide1_week4_martedi_hr").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga_biocide1_week4_martedi_hr").removeClass('error');
    alarm_biocide1_martedi_hr = false;
    check_alarm_biocide_week4();
    // $("#principale").load("test.aspx");
});
$("#value_biocide1_week4_martedi_min").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga_biocide1_week4_martedi_min").removeClass('error');
    alarm_biocide1_week4_martedi_min = false;
    check_alarm_biocide_week4();
    // $("#principale").load("test.aspx");
});
$("#value_biocide1_week4_martedi_feed").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga_biocide1_week4_martedi_feed").removeClass('error');
    alarm_biocide1_week4_martedi_feed = false;
    check_alarm_biocide_week4();
    // $("#principale").load("test.aspx");
});

$("#value_biocide1_week4_mercoledi_hr").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga_biocide1_week4_mercoledi_hr").removeClass('error');
    alarm_biocide1_mercoledi_hr = false;
    check_alarm_biocide_week4();
    // $("#principale").load("test.aspx");
});
$("#value_biocide1_week4_mercoledi_min").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga_biocide1_week4_mercoledi_min").removeClass('error');
    alarm_biocide1_week4_mercoledi_min = false;
    check_alarm_biocide_week4();
    // $("#principale").load("test.aspx");
});
$("#value_biocide1_week4_mercoledi_feed").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga_biocide1_week4_mercoledi_feed").removeClass('error');
    alarm_biocide1_week4_mercoledi_feed = false;
    check_alarm_biocide_week4();
    // $("#principale").load("test.aspx");
});
$("#value_biocide1_week4_giovedi_hr").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga_biocide1_week4_giovedi_hr").removeClass('error');
    alarm_biocide1_giovedi_hr = false;
    check_alarm_biocide_week4();
    // $("#principale").load("test.aspx");
});
$("#value_biocide1_week4_giovedi_min").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga_biocide1_week4_giovedi_min").removeClass('error');
    alarm_biocide1_week4_giovedi_min = false;
    check_alarm_biocide_week4();
    // $("#principale").load("test.aspx");
});
$("#value_biocide1_week4_giovedi_feed").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga_biocide1_week4_giovedi_feed").removeClass('error');
    alarm_biocide1_week4_giovedi_feed = false;
    check_alarm_biocide_week4();
    // $("#principale").load("test.aspx");
});
$("#value_biocide1_week4_venerdi_hr").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga_biocide1_week4_venerdi_hr").removeClass('error');
    alarm_biocide1_venerdi_hr = false;
    check_alarm_biocide_week4();
    // $("#principale").load("test.aspx");
});
$("#value_biocide1_week4_venerdi_min").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga_biocide1_week4_venerdi_min").removeClass('error');
    alarm_biocide1_week4_venerdi_min = false;
    check_alarm_biocide_week4();
    // $("#principale").load("test.aspx");
});
$("#value_biocide1_week4_venerdi_feed").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga_biocide1_week4_venerdi_feed").removeClass('error');
    alarm_biocide1_week4_venerdi_feed = false;
    check_alarm_biocide_week4();
    // $("#principale").load("test.aspx");
});
$("#value_biocide1_week4_sabato_hr").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga_biocide1_week4_sabato_hr").removeClass('error');
    alarm_biocide1_sabato_hr = false;
    check_alarm_biocide_week4();
    // $("#principale").load("test.aspx");
});
$("#value_biocide1_week4_sabato_min").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga_biocide1_week4_sabato_min").removeClass('error');
    alarm_biocide1_week4_sabato_min = false;
    check_alarm_biocide_week4();
    // $("#principale").load("test.aspx");
});
$("#value_biocide1_week4_sabato_feed").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga_biocide1_week4_sabato_feed").removeClass('error');
    alarm_biocide1_week4_sabato_feed = false;
    check_alarm_biocide_week4();
    // $("#principale").load("test.aspx");
});
$("#value_biocide1_week4_domenica_hr").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga_biocide1_week4_domenica_hr").removeClass('error');
    alarm_biocide1_domenica_hr = false;
    check_alarm_biocide_week4();
    // $("#principale").load("test.aspx");
});
$("#value_biocide1_week4_domenica_min").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga_biocide1_week4_domenica_min").removeClass('error');
    alarm_biocide1_week4_domenica_min = false;
    check_alarm_biocide_week4();
    // $("#principale").load("test.aspx");
});
$("#value_biocide1_week4_domenica_feed").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga_biocide1_week4_domenica_feed").removeClass('error');
    alarm_biocide1_week4_domenica_feed = false;
    check_alarm_biocide_week4();
    // $("#principale").load("test.aspx");
});
$("#save_biocide1tower_new").click(function () {
    if (enable_send_setpoint == false) {
        result_setpoint_change(user_setpoint_disable);
        return false;
    }

    $('#save_biocide1tower_new').next('p').remove();
    if (($('#pre_bleed_time').is(':checked'))) {
        Changed_channel('value_pre_bleed_time_hr', 'riga_pre_bleed_time_hr', 99, 0, 0);
        Changed_channel('value_pre_bleed_time_min', 'riga_pre_bleed_time_min', 59, 0, 0);
    }
    if (($('#pre_bleed_us').is(':checked'))) {
        Changed_channel('value_pre_bleed_us', 'riga_pre_bleed_us', max_us, 0, 0);
    }
    Changed_channel('value_pre_biocide_hr', 'riga_pre_biocide_hr', 99, 0, 0);
    Changed_channel('value_pre_biocide_min', 'riga_pre_biocide_min', 59, 0, 0);
    Changed_channel('value_pre_lockout_hr', 'riga_pre_lockout_hr', 99, 0, 0);
    Changed_channel('value_pre_lockout_min', 'riga_pre_lockout_min', 59, 0, 0);
    //week1
    if (($('#biocide1_week1_lunedi').is(':checked'))) {
        Changed_channel('value_biocide1_week1_lunedi_hr', 'riga_biocide1_week1_lunedi_hr', 99, 0, 0);
        Changed_channel('value_biocide1_week1_lunedi_min', 'riga_biocide1_week1_lunedi_min', 59, 0, 0);
        Changed_channel_timer('value_biocide1_week1_lunedi_feed', 'riga_biocide1_week1_lunedi_feed', lunghezza_time);
    }
    if (($('#biocide1_week1_martedi').is(':checked'))) {
        Changed_channel('value_biocide1_week1_martedi_hr', 'riga_biocide1_week1_martedi_hr', 99, 0, 0);
        Changed_channel('value_biocide1_week1_martedi_min', 'riga_biocide1_week1_martedi_min', 59, 0, 0);
        Changed_channel_timer('value_biocide1_week1_martedi_feed', 'riga_biocide1_week1_martedi_feed', lunghezza_time);
    }
    if (($('#biocide1_week1_mercoledi').is(':checked'))) {
        Changed_channel('value_biocide1_week1_mercoledi_hr', 'riga_biocide1_week1_mercoledi_hr', 99, 0, 0);
        Changed_channel('value_biocide1_week1_mercoledi_min', 'riga_biocide1_week1_mercoledi_min', 59, 0, 0);
        Changed_channel_timer('value_biocide1_week1_mercoledi_feed', 'riga_biocide1_week1_mercoledi_feed', lunghezza_time);
    }
    if (($('#biocide1_week1_giovedi').is(':checked'))) {
        Changed_channel('value_biocide1_week1_giovedi_hr', 'riga_biocide1_week1_giovedi_hr', 99, 0, 0);
        Changed_channel('value_biocide1_week1_giovedi_min', 'riga_biocide1_week1_giovedi_min', 59, 0, 0);
        Changed_channel_timer('value_biocide1_week1_giovedi_feed', 'riga_biocide1_week1_giovedi_feed', lunghezza_time);
    }
    if (($('#biocide1_week1_venerdi').is(':checked'))) {
        Changed_channel('value_biocide1_week1_venerdi_hr', 'riga_biocide1_week1_venerdi_hr', 99, 0, 0);
        Changed_channel('value_biocide1_week1_venerdi_min', 'riga_biocide1_week1_venerdi_min', 59, 0, 0);
        Changed_channel_timer('value_biocide1_week1_venerdi_feed', 'riga_biocide1_week1_venerdi_feed', lunghezza_time);
    }
    if (($('#biocide1_week1_sabato').is(':checked'))) {
        Changed_channel('value_biocide1_week1_sabato_hr', 'riga_biocide1_week1_sabato_hr', 99, 0, 0);
        Changed_channel('value_biocide1_week1_sabato_min', 'riga_biocide1_week1_sabato_min', 59, 0, 0);
        Changed_channel_timer('value_biocide1_week1_sabato_feed', 'riga_biocide1_week1_sabato_feed', lunghezza_time);
    }
    if (($('#biocide1_week1_domenica').is(':checked'))) {
        Changed_channel('value_biocide1_week1_domenica_hr', 'riga_biocide1_week1_domenica_hr', 99, 0, 0);
        Changed_channel('value_biocide1_week1_domenica_min', 'riga_biocide1_week1_domenica_min', 59, 0, 0);
        Changed_channel_timer('value_biocide1_week1_domenica_feed', 'riga_biocide1_week1_domenica_feed', lunghezza_time);
    }
    //week2
    if (($('#biocide1_week2_lunedi').is(':checked'))) {
        Changed_channel('value_biocide1_week2_lunedi_hr', 'riga_biocide1_week2_lunedi_hr', 99, 0, 0);
        Changed_channel('value_biocide1_week2_lunedi_min', 'riga_biocide1_week2_lunedi_min', 59, 0, 0);
        Changed_channel_timer('value_biocide1_week2_lunedi_feed', 'riga_biocide1_week2_lunedi_feed', lunghezza_time);
    }
    if (($('#biocide1_week2_martedi').is(':checked'))) {
        Changed_channel('value_biocide1_week2_martedi_hr', 'riga_biocide1_week2_martedi_hr', 99, 0, 0);
        Changed_channel('value_biocide1_week2_martedi_min', 'riga_biocide1_week2_martedi_min', 59, 0, 0);
        Changed_channel_timer('value_biocide1_week2_martedi_feed', 'riga_biocide1_week2_martedi_feed', lunghezza_time);
    }
    if (($('#biocide1_week2_mercoledi').is(':checked'))) {
        Changed_channel('value_biocide1_week2_mercoledi_hr', 'riga_biocide1_week2_mercoledi_hr', 99, 0, 0);
        Changed_channel('value_biocide1_week2_mercoledi_min', 'riga_biocide1_week2_mercoledi_min', 59, 0, 0);
        Changed_channel_timer('value_biocide1_week2_mercoledi_feed', 'riga_biocide1_week2_mercoledi_feed', lunghezza_time);
    }
    if (($('#biocide1_week2_giovedi').is(':checked'))) {
        Changed_channel('value_biocide1_week2_giovedi_hr', 'riga_biocide1_week2_giovedi_hr', 99, 0, 0);
        Changed_channel('value_biocide1_week2_giovedi_min', 'riga_biocide1_week2_giovedi_min', 59, 0, 0);
        Changed_channel_timer('value_biocide1_week2_giovedi_feed', 'riga_biocide1_week2_giovedi_feed', lunghezza_time);
    }
    if (($('#biocide1_week2_venerdi').is(':checked'))) {
        Changed_channel('value_biocide1_week2_venerdi_hr', 'riga_biocide1_week2_venerdi_hr', 99, 0, 0);
        Changed_channel('value_biocide1_week2_venerdi_min', 'riga_biocide1_week2_venerdi_min', 59, 0, 0);
        Changed_channel_timer('value_biocide1_week2_venerdi_feed', 'riga_biocide1_week2_venerdi_feed', lunghezza_time);
    }
    if (($('#biocide1_week2_sabato').is(':checked'))) {
        Changed_channel('value_biocide1_week2_sabato_hr', 'riga_biocide1_week2_sabato_hr', 99, 0, 0);
        Changed_channel('value_biocide1_week2_sabato_min', 'riga_biocide1_week2_sabato_min', 59, 0, 0);
        Changed_channel_timer('value_biocide1_week2_sabato_feed', 'riga_biocide1_week2_sabato_feed', lunghezza_time);
    }
    if (($('#biocide1_week2_domenica').is(':checked'))) {
        Changed_channel('value_biocide1_week2_domenica_hr', 'riga_biocide1_week2_domenica_hr', 99, 0, 0);
        Changed_channel('value_biocide1_week2_domenica_min', 'riga_biocide1_week2_domenica_min', 59, 0, 0);
        Changed_channel_timer('value_biocide1_week2_domenica_feed', 'riga_biocide1_week2_domenica_feed', lunghezza_time);
    }
    //week3
    if (($('#biocide1_week3_lunedi').is(':checked'))) {
        Changed_channel('value_biocide1_week3_lunedi_hr', 'riga_biocide1_week3_lunedi_hr', 99, 0, 0);
        Changed_channel('value_biocide1_week3_lunedi_min', 'riga_biocide1_week3_lunedi_min', 59, 0, 0);
        Changed_channel_timer('value_biocide1_week3_lunedi_feed', 'riga_biocide1_week3_lunedi_feed', lunghezza_time);
    }
    if (($('#biocide1_week3_martedi').is(':checked'))) {
        Changed_channel('value_biocide1_week3_martedi_hr', 'riga_biocide1_week3_martedi_hr', 99, 0, 0);
        Changed_channel('value_biocide1_week3_martedi_min', 'riga_biocide1_week3_martedi_min', 59, 0, 0);
        Changed_channel_timer('value_biocide1_week3_martedi_feed', 'riga_biocide1_week3_martedi_feed', lunghezza_time);
    }
    if (($('#biocide1_week3_mercoledi').is(':checked'))) {
        Changed_channel('value_biocide1_week3_mercoledi_hr', 'riga_biocide1_week3_mercoledi_hr', 99, 0, 0);
        Changed_channel('value_biocide1_week3_mercoledi_min', 'riga_biocide1_week3_mercoledi_min', 59, 0, 0);
        Changed_channel_timer('value_biocide1_week3_mercoledi_feed', 'riga_biocide1_week3_mercoledi_feed', lunghezza_time);
    }
    if (($('#biocide1_week3_giovedi').is(':checked'))) {
        Changed_channel('value_biocide1_week3_giovedi_hr', 'riga_biocide1_week3_giovedi_hr', 99, 0, 0);
        Changed_channel('value_biocide1_week3_giovedi_min', 'riga_biocide1_week3_giovedi_min', 59, 0, 0);
        Changed_channel_timer('value_biocide1_week3_giovedi_feed', 'riga_biocide1_week3_giovedi_feed', lunghezza_time);
    }
    if (($('#biocide1_week3_venerdi').is(':checked'))) {
        Changed_channel('value_biocide1_week3_venerdi_hr', 'riga_biocide1_week3_venerdi_hr', 99, 0, 0);
        Changed_channel('value_biocide1_week3_venerdi_min', 'riga_biocide1_week3_venerdi_min', 59, 0, 0);
        Changed_channel_timer('value_biocide1_week3_venerdi_feed', 'riga_biocide1_week3_venerdi_feed', lunghezza_time);
    }
    if (($('#biocide1_week3_sabato').is(':checked'))) {
        Changed_channel('value_biocide1_week3_sabato_hr', 'riga_biocide1_week3_sabato_hr', 99, 0, 0);
        Changed_channel('value_biocide1_week3_sabato_min', 'riga_biocide1_week3_sabato_min', 59, 0, 0);
        Changed_channel_timer('value_biocide1_week3_sabato_feed', 'riga_biocide1_week3_sabato_feed', lunghezza_time);
    }
    if (($('#biocide1_week3_domenica').is(':checked'))) {
        Changed_channel('value_biocide1_week3_domenica_hr', 'riga_biocide1_week3_domenica_hr', 99, 0, 0);
        Changed_channel('value_biocide1_week3_domenica_min', 'riga_biocide1_week3_domenica_min', 59, 0, 0);
        Changed_channel_timer('value_biocide1_week3_domenica_feed', 'riga_biocide1_week3_domenica_feed', lunghezza_time);
    }
    //week4
    if (($('#biocide1_week4_lunedi').is(':checked'))) {
        Changed_channel('value_biocide1_week4_lunedi_hr', 'riga_biocide1_week4_lunedi_hr', 99, 0, 0);
        Changed_channel('value_biocide1_week4_lunedi_min', 'riga_biocide1_week4_lunedi_min', 59, 0, 0);
        Changed_channel_timer('value_biocide1_week4_lunedi_feed', 'riga_biocide1_week4_lunedi_feed', lunghezza_time);
    }
    if (($('#biocide1_week4_martedi').is(':checked'))) {
        Changed_channel('value_biocide1_week4_martedi_hr', 'riga_biocide1_week4_martedi_hr', 99, 0, 0);
        Changed_channel('value_biocide1_week4_martedi_min', 'riga_biocide1_week4_martedi_min', 59, 0, 0);
        Changed_channel_timer('value_biocide1_week4_martedi_feed', 'riga_biocide1_week4_martedi_feed', lunghezza_time);
    }
    if (($('#biocide1_week4_mercoledi').is(':checked'))) {
        Changed_channel('value_biocide1_week4_mercoledi_hr', 'riga_biocide1_week4_mercoledi_hr', 99, 0, 0);
        Changed_channel('value_biocide1_week4_mercoledi_min', 'riga_biocide1_week4_mercoledi_min', 59, 0, 0);
        Changed_channel_timer('value_biocide1_week4_mercoledi_feed', 'riga_biocide1_week4_mercoledi_feed', lunghezza_time);
    }
    if (($('#biocide1_week4_giovedi').is(':checked'))) {
        Changed_channel('value_biocide1_week4_giovedi_hr', 'riga_biocide1_week4_giovedi_hr', 99, 0, 0);
        Changed_channel('value_biocide1_week4_giovedi_min', 'riga_biocide1_week4_giovedi_min', 59, 0, 0);
        Changed_channel_timer('value_biocide1_week4_giovedi_feed', 'riga_biocide1_week4_giovedi_feed', lunghezza_time);
    }
    if (($('#biocide1_week4_venerdi').is(':checked'))) {
        Changed_channel('value_biocide1_week4_venerdi_hr', 'riga_biocide1_week4_venerdi_hr', 99, 0, 0);
        Changed_channel('value_biocide1_week4_venerdi_min', 'riga_biocide1_week4_venerdi_min', 59, 0, 0);
        Changed_channel_timer('value_biocide1_week4_venerdi_feed', 'riga_biocide1_week4_venerdi_feed', lunghezza_time);
    }
    if (($('#biocide1_week4_sabato').is(':checked'))) {
        Changed_channel('value_biocide1_week4_sabato_hr', 'riga_biocide1_week4_sabato_hr', 99, 0, 0);
        Changed_channel('value_biocide1_week4_sabato_min', 'riga_biocide1_week4_sabato_min', 59, 0, 0);
        Changed_channel_timer('value_biocide1_week4_sabato_feed', 'riga_biocide1_week4_sabato_feed', lunghezza_time);
    }
    if (($('#biocide1_week4_domenica').is(':checked'))) {
        Changed_channel('value_biocide1_week4_domenica_hr', 'riga_biocide1_week4_domenica_hr', 99, 0, 0);
        Changed_channel('value_biocide1_week4_domenica_min', 'riga_biocide1_week4_domenica_min', 59, 0, 0);
        Changed_channel_timer('value_biocide1_week4_domenica_feed', 'riga_biocide1_week4_domenica_feed', lunghezza_time);
    }
    if ((alarm_pre_bleed_time_hr) || (alarm_pre_bleed_time_min) || (alarm_pre_bleed_us) || (alarm_pre_biocide_hr) || (alarm_pre_biocide_min) || (alarm_pre_lockout_hr) || (alarm_pre_lockout_min) ||
        (alarm_biocide1_week1_lunedi_hr) || (alarm_biocide1_week1_lunedi_min) || (alarm_biocide1_week1_martedi_hr) || (alarm_biocide1_week1_martedi_min) || (alarm_biocide1_week1_mercoledi_hr) || (alarm_biocide1_week1_mercoledi_min) ||
        (alarm_biocide1_week1_giovedi_hr) || (alarm_biocide1_week1_giovedi_min) || (alarm_biocide1_week1_venerdi_hr) || (alarm_biocide1_week1_venerdi_min) || (alarm_biocide1_week1_sabato_hr) || (alarm_biocide1_week1_sabato_min) || (alarm_biocide1_week1_domenica_hr) || (alarm_biocide1_week1_domenica_min) ||
        (alarm_biocide1_week2_lunedi_hr) || (alarm_biocide1_week2_lunedi_min) || (alarm_biocide1_week2_martedi_hr) || (alarm_biocide1_week2_martedi_min) || (alarm_biocide1_week2_mercoledi_hr) || (alarm_biocide1_week2_mercoledi_min) ||
        (alarm_biocide1_week2_giovedi_hr) || (alarm_biocide1_week2_giovedi_min) || (alarm_biocide1_week2_venerdi_hr) || (alarm_biocide1_week2_venerdi_min) || (alarm_biocide1_week2_sabato_hr) || (alarm_biocide1_week2_sabato_min) || (alarm_biocide1_week2_domenica_hr) || (alarm_biocide1_week2_domenica_min) ||
                (alarm_biocide1_week3_lunedi_hr) || (alarm_biocide1_week3_lunedi_min) || (alarm_biocide1_week3_martedi_hr) || (alarm_biocide1_week3_martedi_min) || (alarm_biocide1_week3_mercoledi_hr) || (alarm_biocide1_week3_mercoledi_min) ||
        (alarm_biocide1_week3_giovedi_hr) || (alarm_biocide1_week3_giovedi_min) || (alarm_biocide1_week3_venerdi_hr) || (alarm_biocide1_week3_venerdi_min) || (alarm_biocide1_week3_sabato_hr) || (alarm_biocide1_week3_sabato_min) || (alarm_biocide1_week3_domenica_hr) || (alarm_biocide1_week3_domenica_min) ||
                (alarm_biocide1_week4_lunedi_hr) || (alarm_biocide1_week4_lunedi_min) || (alarm_biocide1_week4_martedi_hr) || (alarm_biocide1_week4_martedi_min) || (alarm_biocide1_week4_mercoledi_hr) || (alarm_biocide1_week4_mercoledi_min) ||
        (alarm_biocide1_week4_giovedi_hr) || (alarm_biocide1_week4_giovedi_min) || (alarm_biocide1_week4_venerdi_hr) || (alarm_biocide1_week4_venerdi_min) || (alarm_biocide1_week4_sabato_hr) || (alarm_biocide1_week4_sabato_min) || (alarm_biocide1_week4_domenica_hr) || (alarm_biocide1_week4_domenica_min)||
        (alarm_biocide1_week1_lunedi_feed)||(alarm_biocide1_week1_martedi_feed)||(alarm_biocide1_week1_mercoledi_feed)||(alarm_biocide1_week1_giovedi_feed)||(alarm_biocide1_week1_venerdi_feed)||(alarm_biocide1_week1_sabato_feed)||(alarm_biocide1_week1_domenica_feed)||
        (alarm_biocide1_week2_lunedi_feed)||(alarm_biocide1_week2_martedi_feed)||(alarm_biocide1_week2_mercoledi_feed)||(alarm_biocide1_week2_giovedi_feed)||(alarm_biocide1_week2_venerdi_feed)||(alarm_biocide1_week2_sabato_feed)||(alarm_biocide1_week2_domenica_feed)||
        (alarm_biocide1_week3_lunedi_feed)||(alarm_biocide1_week3_martedi_feed)||(alarm_biocide1_week3_mercoledi_feed)||(alarm_biocide1_week3_giovedi_feed)||(alarm_biocide1_week3_venerdi_feed)||(alarm_biocide1_week3_sabato_feed)||(alarm_biocide1_week3_domenica_feed)||
        (alarm_biocide1_week4_lunedi_feed)||(alarm_biocide1_week4_martedi_feed)||(alarm_biocide1_week4_mercoledi_feed)||(alarm_biocide1_week4_giovedi_feed)||(alarm_biocide1_week4_venerdi_feed)||(alarm_biocide1_week4_sabato_feed)||(alarm_biocide1_week4_domenica_feed)
        ) {
        $('#save_biocide1tower_new').next('p').remove();

        $('#save_biocide1tower_new').after('<p class="error help-block"><span class="label label-important">' + wrong_settings + '</span></p>');
        submit_status = false;
        error_general = false;
        return false;
    }
    submit_status = true;
    error_general = true;
    notification['confirm'] = modify_plant;
    notification['annulla'] = annulla_impianto;
});




var constant = false;
var constant2 = false;

var proportional = false;

var val1_propread = false;
var val2_propread = false;


var val1_read = false;
var val2_read = false;

var valorecap20mA = false;

var valoreread04mA = false;
var valoreread20mA = false;

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

        case "value_constant2":

            constant2 = false
            constant2 = var_alarm;
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

       

        case "valore_cap_20mA":
            valorecap20mA = false;
            valorecap20mA = var_alarm;
            check_alarm_cap_mA();
            break;

        case "valore_read_0_4mA":
            valoreread04mA = false;
            valoreread04mA = var_alarm;
            check_alarm_read_mA();
            break;


        case "valore_read_20mA":
            valoreread20mA = false;
            valoreread20mA = var_alarm;
            check_alarm_read_mA();
            break;


    }
}


function check_alarm_constant() {

    if ((constant == true) || (constant2 == true)) {
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
    if ((val1_propread == true) || (val2_propread == true) ) {
        $("#tab_ld_sp4").attr('style', 'color:#b94a48');
    }
    else {
        $("#tab_ld_sp4").removeAttr('style');
    }
}

function check_alarm_read() {
    if ((val1_read == true) || (val2_read == true) ) {
        $("#tab_ld_sp5").attr('style', 'color:#b94a48');
    }
    else {
        $("#tab_ld_sp5").removeAttr('style');
    }
}

function check_alarm_cap_mA() {
    if ((valorecap20mA == true) || (valoreread04mA == true) || (valoreread20mA == true) ) {
        $("#tab_ld_sp7").attr('style', 'color:#b94a48');
    }
    else {
        $("#tab_ld_sp7").removeAttr('style');
    }
}
function check_alarm_read_mA() {
    if ((valorecap20mA == true) || (valoreread04mA == true) || (valoreread20mA == true)) {
        $("#tab_ld_sp7").attr('style', 'color:#b94a48');
    }
    else {
        $("#tab_ld_sp7").removeAttr('style');
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




$("#valore_read_20mA").keypress(function (evt) {
    return keypress_channel(evt);
});
$("#valore_read_20mA").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga_val_read_20mA").removeClass('error');
    valoreread20mA = false;

    check_alarm_read_mA();
    // $("#principale").load("test.aspx");
});

$("#valore_read_0_4mA").keypress(function (evt) {
    return keypress_channel(evt);
});
$("#valore_read_0_4mA").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga_val_read_0_4mA").removeClass('error');
    valoreread04mA = false;

    check_alarm_read_mA();
    // $("#principale").load("test.aspx");
});

$("#valore_cap_20mA").keypress(function (evt) {
    return keypress_perc(evt);
});
$("#valore_cap_20mA").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga_val_cap_20mA").removeClass('error');
    valorecap20mA = false;

    check_alarm_cap_mA();
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






$("#save_setpointlta_new").click(function () {
    if (enable_send_setpoint == false) {
        result_setpoint_change(user_setpoint_disable);
        return false;
    }
    
    $('#save_setpointlta_new').next('p').remove();

    Changed_channel('value_constant', 'riga_constant', 100, 0, 0);
    Changed_channel('value_constant2', 'riga_constant2', 100, 0, 0);

    Changed_channel('value_ppm_proportional', 'riga1_ppm_proportional', 9, 0, 2);

    Changed_channel('value1_mgl_propread', 'riga1_mgl_propread', max_ch2_value, min_ch2_value, max_fix_value2);
    Changed_channel('value2_mgl_propread', 'riga2_mgl_propread', max_ch2_value, min_ch2_value, max_fix_value2);




    Changed_channel('value1_mgl_reading', 'riga1_mgl_reading', max_ch2_value, min_ch2_value, max_fix_value2);
    Changed_channel('value2_mgl_reading', 'riga2_mgl_reading', max_ch2_value, min_ch2_value, max_fix_value2);

    Changed_channel('valore_cap_20mA', 'riga_val_cap_20mA', 4000, 0, 0);

    Changed_channel('valore_read_0_4mA', 'riga_val_read_0_4mA', max_ch2_value, min_ch2_value, max_fix_value2);
    Changed_channel('valore_read_20mA', 'riga_val_read_20mA', max_ch2_value, min_ch2_value, max_fix_value2);

    if ((constant) || (constant2) ||
        (proportional) ||
           (val1_propread) || (val2_propread)  ||
           (val1_read) || (val2_read) || 
        (valorecap20mA) || (valoreread04mA) || (valoreread20mA)) {
        $('#save_setpointlta_new').next('p').remove();

        $('#save_setpointlta_new').after('<p class="error help-block"><span class="label label-important">' + wrong_settings + '</span></p>');
        submit_status = false;
        error_general = false;

        return false;
    }


    submit_status = true;
    error_general = true;
    notification['confirm'] = modify_plant;
    notification['annulla'] = annulla_impianto;

});

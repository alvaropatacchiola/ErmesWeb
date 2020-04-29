var ph_alarm_high = false;
var ph_alarm_low = false;
var ph_alarm_stop = false;
var cl_alarm_high = false;
var cl_alarm_low = false;
var cl_alarm_stop = false;

var mV_alarm_high = false;
var mV_alarm_low = false;
var mV_alarm_stop = false;


var ntu_alarm_high = false;
var ntu_alarm_low = false;
var ntu_alarm_stop = false;


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
        case "value_ph_alarm_high":

            var myNumber2;
            var value_form2 = $(value_ph_alarm_low).val();
            ph_alarm_high = false;
            ph_alarm_low = false;
            check_alarm_channel_ph_alarm();


            if (!($('#ph_alarm_low_enable').is(':checked'))) {

                ph_alarm_high = var_alarm;
                check_alarm_channel_ph_alarm();

            }
            if (($('#ph_alarm_low_enable').is(':checked'))) {

                myNumber2 = parseFloat(value_form2);
                myNumber2 = myNumber2.toFixed(myfix);
                if (myNumber2 > myNumber) {

                    ph_alarm_high = true;
                    $(id).after('<p class="error help-block"><span class="label label-important">' + 'This value must be greater than Low' + '</span></p>');
                    $(id_1).addClass('error')


                }
                else ph_alarm_high = false;

            }





            //ph_alarm_high = var_alarm;
            //check_alarm_channel_ph_alarm();
            break;
        case "value_ph_alarm_low":
            //ph_alarm_low = var_alarm;
            //check_alarm_channel_ph_alarm();


            var myNumber2;
            var value_form2 = $(value_ph_alarm_high).val();
            ph_alarm_high = false;
            ph_alarm_low = false;
            check_alarm_channel_ph_alarm();

            if (!($('#ph_alarm_high_enable').is(':checked'))) {

                ph_alarm_low = var_alarm;
                check_alarm_channel_ph_alarm();

            }

            if (($('#ph_alarm_high_enable').is(':checked'))) {

                myNumber2 = parseFloat(value_form2);
                myNumber2 = myNumber2.toFixed(myfix);
                if (myNumber2 < myNumber) {

                    ph_alarm_low = true;
                    $(id).after('<p class="error help-block"><span class="label label-important">' + 'This value must be less than High' + '</span></p>');
                    $(id_1).addClass('error')

                }
                else ph_alarm_low = false;

            }

            break;

        case "value_ph_alarm_stop":
            ph_alarm_stop = var_alarm;
            check_alarm_channel_ph_alarm();
            break;

        case "value_cl_alarm_high":
            //cl_alarm_high = var_alarm;
            //check_alarm_channel_cl_alarm();

            var myNumber2;
            var value_form2 = $(value_cl_alarm_low).val();


            cl_alarm_high = false;
            cl_alarm_low = false;
            check_alarm_channel_cl_alarm();

            if (!($('#cl_alarm_low_enable').is(':checked'))) {

                cl_alarm_high = var_alarm;
                check_alarm_channel_cl_alarm();
            }
            if (($('#cl_alarm_low_enable').is(':checked'))) {

                myNumber2 = parseFloat(value_form2);
                myNumber2 = myNumber2.toFixed(myfix);
                if (myNumber2 > myNumber) {
                    cl_alarm_high = true;
                    $(id).after('<p class="error help-block"><span class="label label-important">' + 'This value must be greater than Low' + '</span></p>');
                    $(id_1).addClass('error')
                }
                else cl_alarm_high = false;
            }

            break;
        case "value_cl_alarm_low":
            //cl_alarm_low = var_alarm;
            //check_alarm_channel_cl_alarm();


            var myNumber2;
            var value_form2 = $(value_cl_alarm_high).val();

            cl_alarm_high = false;
            cl_alarm_low = false;
            check_alarm_channel_cl_alarm();


            if (!($('#cl_alarm_high_enable').is(':checked'))) {

                cl_alarm_low = var_alarm;
                check_alarm_channel_cl_alarm();
            }
            if (($('#cl_alarm_high_enable').is(':checked'))) {

                myNumber2 = parseFloat(value_form2);
                myNumber2 = myNumber2.toFixed(myfix);
                if (myNumber2 < myNumber) {
                    cl_alarm_low = true;
                    $(id).after('<p class="error help-block"><span class="label label-important">' + 'This value must be less than High' + '</span></p>');
                    $(id_1).addClass('error')
                }
                else cl_alarm_low = false;
            }

            break;

        case "value_cl_alarm_stop":
            cl_alarm_stop = var_alarm;
            check_alarm_channel_cl_alarm();
            break;



            //---------------------------------

        case "value_mV_alarm_high":
            //cl_alarm_high = var_alarm;
            //check_alarm_channel_cl_alarm();

            var myNumber2;
            var value_form2 = $(value_mV_alarm_low).val();


            mV_alarm_high = false;
            mV_alarm_low = false;
            check_alarm_channel_mV_alarm();

            if (!($('#mV_alarm_low_enable').is(':checked'))) {

                mV_alarm_high = var_alarm;
                check_alarm_channel_mV_alarm();
            }
            if (($('#mV_alarm_low_enable').is(':checked'))) {

                myNumber2 = parseFloat(value_form2);
                myNumber2 = myNumber2.toFixed(myfix);
                if (myNumber2 > myNumber) {
                    mV_alarm_high = true;
                    $(id).after('<p class="error help-block"><span class="label label-important">' + 'This value must be greater than Low' + '</span></p>');
                    $(id_1).addClass('error')
                }
                else mV_alarm_high = false;
            }

            break;
        case "value_mV_alarm_low":
            //cl_alarm_low = var_alarm;
            //check_alarm_channel_cl_alarm();


            var myNumber2;
            var value_form2 = $(value_mV_alarm_high).val();

            mV_alarm_high = false;
            mV_alarm_low = false;
            check_alarm_channel_mV_alarm();


            if (!($('#mV_alarm_high_enable').is(':checked'))) {

                mV_alarm_low = var_alarm;
                check_alarm_channel_mV_alarm();
            }
            if (($('#mV_alarm_high_enable').is(':checked'))) {

                myNumber2 = parseFloat(value_form2);
                myNumber2 = myNumber2.toFixed(myfix);
                if (myNumber2 < myNumber) {
                    mV_alarm_low = true;
                    $(id).after('<p class="error help-block"><span class="label label-important">' + 'This value must be less than High' + '</span></p>');
                    $(id_1).addClass('error')
                }
                else mV_alarm_low = false;
            }

            break;

        case "value_mV_alarm_stop":
            mV_alarm_stop = var_alarm;
            check_alarm_channel_mV_alarm();
            break;

            //---------------------------------

        case "value_ntu_alarm_high":
            //cl_alarm_high = var_alarm;
            //check_alarm_channel_cl_alarm();

            var myNumber2;
            var value_form2 = $(value_ntu_alarm_low).val();


            ntu_alarm_high = false;
            ntu_alarm_low = false;
            check_alarm_channel_ntu_alarm();

            if (!($('#ntu_alarm_low_enable').is(':checked'))) {

                ntu_alarm_high = var_alarm;
                check_alarm_channel_ntu_alarm();
            }
            if (($('#ntu_alarm_low_enable').is(':checked'))) {

                myNumber2 = parseFloat(value_form2);
                myNumber2 = myNumber2.toFixed(myfix);
                if (myNumber2 > myNumber) {
                    ntu_alarm_high = true;
                    $(id).after('<p class="error help-block"><span class="label label-important">' + 'This value must be greater than Low' + '</span></p>');
                    $(id_1).addClass('error')
                }
                else ntu_alarm_high = false;
            }

            break;
        //case "value_ntu_alarm_low":
        //    //cl_alarm_low = var_alarm;
        //    //check_alarm_channel_cl_alarm();


        //    var myNumber2;
        //    var value_form2 = $(value_ntu_alarm_high).val();

        //    ntu_alarm_high = false;
        //    ntu_alarm_low = false;
        //    check_alarm_channel_ntu_alarm();


        //    if (!($('#ntu_alarm_high_enable').is(':checked'))) {

        //        ntu_alarm_low = var_alarm;
        //        check_alarm_channel_ntu_alarm();
        //    }
        //    if (($('#ntu_alarm_high_enable').is(':checked'))) {

        //        myNumber2 = parseFloat(value_form2);
        //        myNumber2 = myNumber2.toFixed(myfix);
        //        if (myNumber2 < myNumber) {
        //            ntu_alarm_low = true;
        //            $(id).after('<p class="error help-block"><span class="label label-important">' + 'This value must be less than High' + '</span></p>');
        //            $(id_1).addClass('error')
        //        }
        //        else ntu_alarm_low = false;
        //    }

        //    break;

        //case "value_ntu_alarm_stop":
        //    ntu_alarm_stop = var_alarm;
        //    check_alarm_channel_ntu_alarm();
        //    break;


    }
}
function check_alarm_channel_ph_alarm() {
    if ((ph_alarm_high == true) || (ph_alarm_low == true) || (ph_alarm_stop == true)) {
        $("#tab_ld_sp1").attr('style', 'color:#b94a48');
    }
    else {
        $("#tab_ld_sp1").removeAttr('style');
    }
}
function check_alarm_channel_cl_alarm() {
    if ((cl_alarm_high == true) || (cl_alarm_low == true) || (cl_alarm_stop == true)) {
        $("#tab_ld_sp2").attr('style', 'color:#b94a48');
    }
    else {
        $("#tab_ld_sp2").removeAttr('style');
    }
}
    
function check_alarm_channel_mV_alarm() {
        if ((mV_alarm_high == true) || (mV_alarm_low == true) || (mV_alarm_stop == true)) {
            $("#tab_ld_sp3").attr('style', 'color:#b94a48');
        }
        else {
            $("#tab_ld_sp3").removeAttr('style');
        }
}
        function check_alarm_channel_ntu_alarm() {
            if ((ntu_alarm_high == true) || (ntu_alarm_low == true) || (ntu_alarm_stop == true)) {
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
function keypress_channel_number(evt) {
    var charCode = (evt.which) ? evt.which : event.keyCode

    if (charCode > 31 && (charCode < 48 || charCode > 57))
        return false;

    return true;

}
$("#value_ph_alarm_high").keypress(function (evt) {
    return keypress_channel(evt);
});
$("#value_ph_alarm_low").keypress(function (evt) {
    return keypress_channel(evt);
});
$("#value_ph_alarm_stop").keypress(function (evt) {
    return keypress_channel_number(evt);
});

$("#value_cl_alarm_high").keypress(function (evt) {
    return keypress_channel(evt);
});
$("#value_cl_alarm_low").keypress(function (evt) {
    return keypress_channel(evt);
});
$("#value_cl_alarm_stop").keypress(function (evt) {
    return keypress_channel_number(evt);
});
        
$("#value_mV_alarm_high").keypress(function (evt) {
return keypress_channel(evt);
});
$("#value_mV_alarm_low").keypress(function (evt) {
    return keypress_channel(evt);
});
$("#value_mV_alarm_stop").keypress(function (evt) {
    return keypress_channel_number(evt);
});


        //    $("#value_ntu_alarm_high").keypress(function (evt) {
        //        return keypress_channel(evt);
        //    });
        //    $("#value_ntu_alarm_low").keypress(function (evt) {
        //        return keypress_channel(evt);
        //    });
        //    $("#value_ntu_alarm_stop").keypress(function (evt) {
        //        return keypress_channel_number(evt);
        //    });



function disable_ph_alarm_high() {
    ph_alarm_high = false;
    check_alarm_channel_ph_alarm();
    $("#enable_value_ph_alarm_high").hide();
    if (($('#ph_alarm_low_disable').is(':checked'))) {
        disable_ph_alarm_dose();
    }
}
function enable_ph_alarm_high() {
    $("#enable_value_ph_alarm_high").show();
    enable_ph_alarm_dose();
}

function disable_ph_alarm_low() {
    ph_alarm_low = false;
    check_alarm_channel_ph_alarm();
    $("#enable_value_ph_alarm_low").hide();
    if (($('#ph_alarm_high_disable').is(':checked'))) {
        disable_ph_alarm_dose();
    }

}
function enable_ph_alarm_low() {
    $("#enable_value_ph_alarm_low").show();
    enable_ph_alarm_dose();
}

function disable_ph_alarm_dose() {
    ph_alarm_dose = false;
    check_alarm_channel_ph_alarm();
    $("#enable_value_ph_alarm_stop").hide();
}
function enable_ph_alarm_dose() {
    $("#enable_value_ph_alarm_stop").show();
}
//----------------------------------------------------
function disable_cl_alarm_high() {
    cl_alarm_high = false;
    check_alarm_channel_cl_alarm();
    $("#enable_value_cl_alarm_high").hide();
    if (($('#cl_alarm_low_disable').is(':checked'))) {
        disable_cl_alarm_dose();
    }

}
function enable_cl_alarm_high() {
    $("#enable_value_cl_alarm_high").show();
    enable_cl_alarm_dose();
}

function disable_cl_alarm_low() {
    cl_alarm_low = false;
    check_alarm_channel_cl_alarm();
    $("#enable_value_cl_alarm_low").hide();
    if (($('#cl_alarm_high_disable').is(':checked'))) {
        disable_cl_alarm_dose();
    }

}
function enable_cl_alarm_low() {
    $("#enable_value_cl_alarm_low").show();
    enable_cl_alarm_dose();
}


function disable_cl_alarm_dose() {
    cl_alarm_dose = false;
    check_alarm_channel_cl_alarm();
    $("#enable_value_cl_alarm_stop").hide();
}
function enable_cl_alarm_dose() {
    $("#enable_value_cl_alarm_stop").show();
}


        //--------------------------------------------------
function disable_mV_alarm_high() {
  
    mV_alarm_high = false;
    check_alarm_channel_mV_alarm();
    $("#enable_value_mV_alarm_high").hide();
    if (($('#mV_alarm_low_disable').is(':checked'))) {
        disable_mV_alarm_dose();
    }

}
function enable_mV_alarm_high() {
    $("#enable_value_mV_alarm_high").show();
    enable_mV_alarm_dose();
}

function disable_mV_alarm_low() {

    mV_alarm_low = false;
    check_alarm_channel_mV_alarm();
    $("#enable_value_mV_alarm_low").hide();
    if (($('#mV_alarm_high_disable').is(':checked'))) {
        disable_mV_alarm_dose();
    }

}
function enable_mV_alarm_low() {
    $("#enable_value_mV_alarm_low").show();
    enable_mV_alarm_dose();
}

function disable_mV_alarm_dose() {
    mV_alarm_dose = false;
    check_alarm_channel_mV_alarm();
    $("#enable_value_mV_alarm_stop").hide();
}
function enable_mV_alarm_dose() {
    $("#enable_value_mV_alarm_stop").show();
}


//        ///----------------------------------------

function disable_ntu_alarm_high() {
 
    ntu_alarm_high = false;
    check_alarm_channel_ntu_alarm();
    $("#enable_value_ntu_alarm_high").hide();
    if (($('#ntu_alarm_low_disable').is(':checked'))) {
        disable_ntu_alarm_dose();
    }

}
function enable_ntu_alarm_high() {
    $("#enable_value_ntu_alarm_high").show();
    enable_ntu_alarm_dose();
}

function disable_ntu_alarm_low() {

    ntu_alarm_low = false;
    check_alarm_channel_ntu_alarm();
    $("#enable_value_ntu_alarm_low").hide();
    if (($('#ntu_alarm_high_disable').is(':checked'))) {
        disable_ntu_alarm_dose();
    }

}
function enable_ntu_alarm_low() {
    $("#enable_value_ntu_alarm_low").show();
    enable_ntu_alarm_dose();
}
function disable_ntu_alarm_dose() {

    ntu_alarm_dose = false;
    check_alarm_channel_ntu_alarm();
    $("#enable_value_ntu_alarm_stop").hide();
}
function enable_ntu_alarm_dose() {
    $("#enable_value_ntu_alarm_stop").show();
}

$("#ph_alarm_high_disable").click(function () {
  
    disable_ph_alarm_high();
});
$("#ph_alarm_high_enable").click(function () {
 
    enable_ph_alarm_high();
});
$("#ph_alarm_low_disable").click(function () {
  
    disable_ph_alarm_low();
});
$("#ph_alarm_low_enable").click(function () {

    enable_ph_alarm_low();
});
/*$("#ph_alarm_mode_dose").click(function () {
    disable_ph_alarm_dose();
});
$("#ph_alarm_mode_stop").click(function () {
    enable_ph_alarm_dose();
});
*/
$("#cl_alarm_high_disable").click(function () {

    disable_cl_alarm_high();
});
$("#cl_alarm_high_enable").click(function () {
 
    enable_cl_alarm_high();
});
$("#cl_alarm_low_disable").click(function () {
   
    disable_cl_alarm_low();
});
$("#cl_alarm_low_enable").click(function () {
  
    enable_cl_alarm_low();
});
/*
$("#cl_alarm_mode_dose").click(function () {
    disable_cl_alarm_dose();
});
$("#cl_alarm_mode_stop").click(function () {
    enable_cl_alarm_dose();
});
*/

$("#mV_alarm_high_disable").click(function () {

    disable_mV_alarm_high();
});
$("#mV_alarm_high_enable").click(function () {

    enable_mV_alarm_high();
});
$("#mV_alarm_low_disable").click(function () {

    disable_mV_alarm_low();
});
$("#mV_alarm_low_enable").click(function () {

    enable_mV_alarm_low();
});


$("#ntu_alarm_high_disable").click(function () {
    disable_ntu_alarm_high();
});
$("#ntu_alarm_high_enable").click(function () {
    enable_ntu_alarm_high();
});
$("#ntu_alarm_low_disable").click(function () {
    disable_ntu_alarm_low();
});
$("#ntu_alarm_low_enable").click(function () {
    enable_ntu_alarm_low();
});


$("#value_ph_alarm_high").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga1_ph_alarm_high").removeClass('error');
    ph_alarm_high = false;
    check_alarm_channel_ph_alarm();
    // $("#principale").load("test.aspx");
});
$("#value_ph_alarm_low").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga1_ph_alarm_low").removeClass('error');
    ph_alarm_low = false;
    check_alarm_channel_ph_alarm();
    // $("#principale").load("test.aspx");
});
$("#value_ph_alarm_stop").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga1_ph_alarm_stop").removeClass('error');
    ph_alarm_stop = false;
    check_alarm_channel_ph_alarm();
    // $("#principale").load("test.aspx");
});

$("#value_cl_alarm_high").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga1_cl_alarm_high").removeClass('error');
    cl_alarm_high = false;
    check_alarm_channel_cl_alarm();
    // $("#principale").load("test.aspx");
});
$("#value_cl_alarm_low").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga1_cl_alarm_low").removeClass('error');
    cl_alarm_low = false;
    check_alarm_channel_cl_alarm();
    // $("#principale").load("test.aspx");
});
$("#value_cl_alarm_stop").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga1_cl_alarm_stop").removeClass('error');
    cl_alarm_stop = false;
    check_alarm_channel_cl_alarm();
    // $("#principale").load("test.aspx");
});



$("#value_mV_alarm_high").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga1_mV_alarm_high").removeClass('error');
    mV_alarm_high = false;
    check_alarm_channel_mV_alarm();
    // $("#principale").load("test.aspx");
});
$("#value_mV_alarm_low").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga1_mV_alarm_low").removeClass('error');
    mV_alarm_low = false;
    check_alarm_channel_mV_alarm();
    // $("#principale").load("test.aspx");
});
$("#value_mV_alarm_stop").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga1_mV_alarm_stop").removeClass('error');
    mV_alarm_stop = false;
    check_alarm_channel_mV_alarm();
    // $("#principale").load("test.aspx");
});


$("#value_ntu_alarm_high").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga1_ntu_alarm_high").removeClass('error');
    ntu_alarm_high = false;
    check_alarm_channel_ntu_alarm();
    // $("#principale").load("test.aspx");
});
$("#value_ntu_alarm_low").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga1_ntu_alarm_low").removeClass('error');
    ntu_alarm_low = false;
    check_alarm_channel_ntu_alarm();
    // $("#principale").load("test.aspx");
});
$("#value_ntu_alarm_stop").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga1_ntu_alarm_stop").removeClass('error');
    ntu_alarm_stop = false;
    check_alarm_channel_ntu_alarm();
    // $("#principale").load("test.aspx");
});


$("#save_rangealarmld4_new").click(function () {
    if (enable_send_setpoint == false) {
        result_setpoint_change(user_setpoint_disable);
        return false;
    }


    $('#save_rangealarmld4_new').next('p').remove();
    if (!($('#ph_alarm_high_enable').is(':checked'))) {
        Changed_channel('value_ph_alarm_high', 'riga1_ph_alarm_high', max_ph_value, min_ph_value, max_fix_value_ph);
        Changed_channel('value_ph_alarm_stop', 'riga1_ph_alarm_stop', 99, 0, 0);
    }
    if (!($('#ph_alarm_low_enable').is(':checked'))) {
        Changed_channel('value_ph_alarm_low', 'riga1_ph_alarm_low', max_ph_value, min_ph_value, max_fix_value_ph);
        Changed_channel('value_ph_alarm_stop', 'riga1_ph_alarm_stop', 99, 0, 0);
    }

  

    // if (!($('#ph_alarm_mode_stop').is(':checked'))) {

    //}

    if (!($('#cl_alarm_high_enable').is(':checked'))) {
        Changed_channel('value_cl_alarm_high', 'riga1_cl_alarm_high', max_cl_value, min_cl_value, max_fix_value_cl);
        Changed_channel('value_cl_alarm_stop', 'riga1_cl_alarm_stop', 99, 0, 0);
    }
    if (!($('#cl_alarm_low_enable').is(':checked'))) {
        Changed_channel('value_cl_alarm_low', 'riga1_cl_alarm_low', max_cl_value, min_cl_value, max_fix_value_cl);
        Changed_channel('value_cl_alarm_stop', 'riga1_cl_alarm_stop', 99, 0, 0);
    }
    

    if (!($('#mV_alarm_high_enable').is(':checked'))) {
        Changed_channel('value_mV_alarm_high', 'riga1_mV_alarm_high', max_mV_value, min_mV_value, max_fix_value_mV);
        Changed_channel('value_mV_alarm_stop', 'riga1_mV_alarm_stop', 99, 0, 0);
    }
    if (!($('#mV_alarm_low_enable').is(':checked'))) {
        Changed_channel('value_mV_alarm_low', 'riga1_mV_alarm_low', max_mV_value, min_mV_value, max_fix_value_mV);
        Changed_channel('value_mV_alarm_stop', 'riga1_mV_alarm_stop', 99, 0, 0);
    }


    if (!($('#ntu_alarm_high_enable').is(':checked'))) {
        Changed_channel('value_ntu_alarm_high', 'riga1_ntu_alarm_high', max_ntu_value, min_ntu_value, max_fix_value_ntu);
        Changed_channel('value_ntu_alarm_stop', 'riga1_ntu_alarm_stop', 99, 0, 0);
    }
    if (!($('#ntu_alarm_low_enable').is(':checked'))) {
        Changed_channel('value_ntu_alarm_low', 'riga1_ntu_alarm_low', max_ntu_value, min_ntu_value, max_fix_value_ntu);
        Changed_channel('value_ntu_alarm_stop', 'riga1_ntu_alarm_stop', 99, 0, 0);
    }


    //}
    if ((ph_alarm_high) || (ph_alarm_low) ||
        (ph_alarm_stop) || (cl_alarm_high) ||(mV_alarm_high) ||
        (cl_alarm_low) || (cl_alarm_stop)||
        (mV_alarm_low) || (mV_alarm_stop)||(ntu_alarm_high) ||
        (ntu_alarm_low) || (ntu_alarm_stop)) {
        $('#save_rangealarmld4_new').next('p').remove();

        $('#save_rangealarmld4_new').after('<p class="error help-block"><span class="label label-important">' + wrong_settings + '</span></p>');
        submit_status = false;
        error_general = false;

        return false;
    }
    submit_status = true;
    error_general = true;
    notification['confirm'] = modify_plant;
    notification['annulla'] = annulla_impianto;

});
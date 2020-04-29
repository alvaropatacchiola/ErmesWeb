
var ph_pulse1_on = false;
var ph_pulse1_pm1 = false;
var ph_pulse1_off = false;
var ph_pulse1_pm2 = false;
var ph_pulse1_speed = false;

//var ph_pulse2_on = false;
//var ph_pulse2_pm1 = false;
//var ph_pulse2_off = false;
//var ph_pulse2_pm2 = false;
//var ph_pulse2_speed = false;

var ph_relay_on = false;
var ph_relay_pm1 = false;
var ph_relay_off = false;
var ph_relay_pm2 = false;

var cl_pulse1_on = false;
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
        case "value1_ph_pulse1_1":
            ph_pulse1_on = var_alarm;
            check_alarm_channel_ph_pulse1();


            break;
        case "value2_ph_pulse1_1":
            //ph_pulse1_pm1 = var_alarm;
            //check_alarm_channel_ph_pulse1();


            var myNumber2;
            var value_form2 = $(value2_ph_pulse1_2).val();

            myNumber2 = parseFloat(value_form2);
            myNumber2 = myNumber2.toFixed(myfix);

            ph_pulse1_pm1 = false;
            ph_pulse1_pm2 = false;
            check_alarm_channel_ph_pulse1();



            if ((myNumber2 != 0) && (myNumber != 0)) {
                ph_pulse1_pm1 = true;

                $(id).after('<p class="error help-block"><span class="label label-important">' + 'One of these values must be zero' + '</span></p>');
                $(id_1).addClass('error')
            }
            else ph_pulse1_pm1 = false;

            //ph_pulse1_pm1 = false;

            break;

        case "value1_ph_pulse1_2":
            ph_pulse1_off = var_alarm;
            check_alarm_channel_ph_pulse1();
            break;
        case "value2_ph_pulse1_2":
            //ph_pulse1_pm2 = var_alarm;
            //check_alarm_channel_ph_pulse1();

            var myNumber2;
            var value_form2 = $(value2_ph_pulse1_1).val();

            myNumber2 = parseFloat(value_form2);
            myNumber2 = myNumber2.toFixed(myfix);


            ph_pulse1_pm1 = false;
            ph_pulse1_pm2 = false;
            check_alarm_channel_ph_pulse1();



            if ((myNumber2 != 0) && (myNumber != 0)) {
                ph_pulse1_pm2 = true;

                $(id).after('<p class="error help-block"><span class="label label-important">' + 'One of these values must be zero' + '</span></p>');
                $(id_1).addClass('error')
            }
            else ph_pulse1_pm2 = false;

            //ph_pulse1_pm2 = false;

            break;

        case "value2_ph_pulse1_3":
            ph_pulse1_speed = var_alarm;
            ph_pulse1_speed = false;
            check_alarm_channel_ph_pulse1();
            break;

            //ph pulse 2
            //case "value1_ph_pulse2_1":
            //    ph_pulse2_on = var_alarm;
            //    check_alarm_channel_ph_pulse2();


            //    break;
            //case "value2_ph_pulse2_1":
            //    //ph_pulse2_pm1 = var_alarm;
            //    //check_alarm_channel_ph_pulse2();

            //    var myNumber2;
            //    var value_form2 = $(value2_ph_pulse2_2).val();

            //    myNumber2 = parseFloat(value_form2);
            //    myNumber2 = myNumber2.toFixed(myfix);


            //    check_alarm_channel_ph_pulse2();



            //    if ((myNumber2 != 0) && (myNumber != 0)) {
            //        ph_pulse2_pm1 = true;

            //        $(id).after('<p class="error help-block"><span class="label label-important">' + 'One of these values must be zero' + '</span></p>');
            //        $(id_1).addClass('error')
            //    }
            //    else ph_pulse2_pm1 = false;
            //    break;

            //case "value1_ph_pulse2_2":
            //    ph_pulse2_off = var_alarm;
            //    check_alarm_channel_ph_pulse2();
            //    break;
            //case "value2_ph_pulse2_2":
            //    //ph_pulse2_pm2 = var_alarm;
            //    //check_alarm_channel_ph_pulse2();


            //    var myNumber2;
            //    var value_form2 = $(value2_ph_pulse2_1).val();

            //    myNumber2 = parseFloat(value_form2);
            //    myNumber2 = myNumber2.toFixed(myfix);


            //    check_alarm_channel_ph_pulse2();



            //    if ((myNumber2 != 0) && (myNumber != 0)) {
            //        ph_pulse2_pm2 = true;

            //        $(id).after('<p class="error help-block"><span class="label label-important">' + 'One of these values must be zero' + '</span></p>');
            //        $(id_1).addClass('error')
            //    }
            //    else ph_pulse2_pm2 = false;
            //    break;

            //case "value2_ph_pulse2_3":
            //    ph_pulse2_speed = var_alarm;
            //    check_alarm_channel_ph_pulse2();
            //    break;
            //ph relay
        case "value1_ph_relay_1":
            ph_relay_on = var_alarm;
            check_alarm_channel_ph_relay();
            break;
        case "value2_ph_relay_1":
            //ph_relay_pm1 = var_alarm;
            //check_alarm_channel_ph_relay();


            var myNumber2;
            var value_form2 = $(value2_ph_relay_2).val();

            if (($('#fixed_ph_relay').is(':checked'))) {

                ph_relay_pm1 = var_alarm;

                ph_relay_pm1 = false;
                ph_relay_pm2 = false;
                check_alarm_channel_ph_relay();
            }
            if (!($('#fixed_ph_relay').is(':checked'))) {

                myNumber2 = parseFloat(value_form2);
                myNumber2 = myNumber2.toFixed(myfix);

                ph_relay_pm1 = false;
                ph_relay_pm2 = false;
                check_alarm_channel_ph_relay();

                if ((myNumber2 != 0) && (myNumber != 0)) {
                    ph_relay_pm1 = true;
                    $(id).after('<p class="error help-block"><span class="label label-important">' + 'One of these values must be zero' + '</span></p>');
                    $(id_1).addClass('error')
                }
                else ph_relay_pm1 = false;
            }
            break;

        case "value1_ph_relay_2":
            ph_relay_off = var_alarm;
            check_alarm_channel_ph_relay();
            break;
        case "value2_ph_relay_2":
            //ph_relay_pm2 = var_alarm;
            //check_alarm_channel_ph_relay();

            var myNumber2;
            var value_form2 = $(value2_ph_relay_1).val();

            if (($('#fixed_ph_relay').is(':checked'))) {

                ph_relay_pm2 = var_alarm;
                ph_relay_pm1 = false;
                ph_relay_pm2 = false;
                check_alarm_channel_ph_relay();
            }
            if (!($('#fixed_ph_relay').is(':checked'))) {

                myNumber2 = parseFloat(value_form2);
                myNumber2 = myNumber2.toFixed(myfix);

                ph_relay_pm1 = false;
                ph_relay_pm2 = false;
                check_alarm_channel_ph_relay();

                if ((myNumber2 != 0) && (myNumber != 0)) {
                    ph_relay_pm2 = true;
                    $(id).after('<p class="error help-block"><span class="label label-important">' + 'One of these values must be zero' + '</span></p>');
                    $(id_1).addClass('error')
                }
                else ph_relay_pm2 = false;
            }
            break;

            //cl pulse 1
        case "value1_cl_pulse1_1":
     
            cl_pulse1_on = var_alarm;
            check_alarm_channel_cl_pulse1();
            break;
        case "value2_cl_pulse1_1":
            //cl_pulse1_pm1 = var_alarm;
            //check_alarm_channel_cl_pulse1();
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

            break;

        case "value1_cl_pulse1_2":
           
            cl_pulse1_off = var_alarm;
            check_alarm_channel_cl_pulse1();
            break;
        case "value2_cl_pulse1_2":
            //cl_pulse1_pm2 = var_alarm;
            //check_alarm_channel_cl_pulse1();


            var myNumber2;
            var value_form2 = $(value2_cl_pulse1_1).val();
       
            myNumber2 = parseFloat(value_form2);
            myNumber2 = myNumber2.toFixed(myfix);


            cl_pulse1_pm1 = false;
            cl_pulse1_pm2 = false;
            check_alarm_channel_cl_pulse1();



            if ((myNumber2 != 0) && (myNumber != 0)) {
                cl_pulse1_pm2 = true;

                $(id).after('<p class="error help-block"><span class="label label-important">' + 'One of these values must be zero' + '</span></p>');
                $(id_1).addClass('error')
            }
            else cl_pulse1_pm2 = false;

            break;

        case "value2_cl_pulse1_3":
       
            cl_pulse1_speed = var_alarm;
            cl_pulse1_speed = false;
            check_alarm_channel_cl_pulse1();
            break;
            //cl relay
        case "value1_cl_relay_1":
            cl_relay_on = var_alarm;
            check_alarm_channel_cl_relay();


            break;
        case "value2_cl_relay_1":
            //cl_relay_pm1 = var_alarm;
            //check_alarm_channel_cl_relay();

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


                if ((myNumber2 != 0) && (myNumber != 0)) {
                    cl_relay_pm1 = true;
                    $(id).after('<p class="error help-block"><span class="label label-important">' + 'One of these values must be zero' + '</span></p>');
                    $(id_1).addClass('error')
                }
                else cl_relay_pm1 = false;
            }
            break;

        case "value1_cl_relay_2":
            cl_relay_off = var_alarm;
            check_alarm_channel_cl_relay();
            break;
        case "value2_cl_relay_2":
            //cl_relay_pm2 = var_alarm;
            //check_alarm_channel_cl_relay();

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


                if ((myNumber2 != 0) && (myNumber != 0)) {
                    cl_relay_pm2 = true;
                    $(id).after('<p class="error help-block"><span class="label label-important">' + 'One of these values must be zero' + '</span></p>');
                    $(id_1).addClass('error')
                }
                else cl_relay_pm2 = false;
            }
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
//function check_alarm_channel_ph_pulse2() {
//    if ((ph_pulse2_on == true) || (ph_pulse2_pm1 == true) || (ph_pulse2_off == true) || (ph_pulse2_pm2 == true) || (ph_pulse2_speed == true)) {
//        $("#tab_ld_sp2").attr('style', 'color:#b94a48');
//    }
//    else {
//        $("#tab_ld_sp2").removeAttr('style');
//    }
//}

function check_alarm_channel_ph_relay() {
    if ((ph_relay_on == true) || (ph_relay_pm1 == true) || (ph_relay_off == true) || (ph_relay_pm2 == true)) {
        $("#tab_ld_sp3").attr('style', 'color:#b94a48');
    }
    else {
        $("#tab_ld_sp3").removeAttr('style');
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

$("#value2_ph_pulse_mch").keypress(function (evt) {
    return keypress_channel(evt);
});
$("#value2_ph_pulse_range").keypress(function (evt) {
    return keypress_channel(evt);
});
$("#value2_ph_pulse_setpoint").keypress(function (evt) {
    return keypress_channel(evt);
});



//ph pulse 2
//$("#value1_ph_pulse2_1").keypress(function (evt) {
//    return keypress_channel(evt);
//});
//$("#value2_ph_pulse2_1").keypress(function (evt) {
//    return keypress_perc(evt);
//});

//$("#value1_ph_pulse2_2").keypress(function (evt) {
//    return keypress_channel(evt);
//});
//$("#value2_ph_pulse2_2").keypress(function (evt) {
//    return keypress_perc(evt);
//});
//$("#value2_ph_pulse2_3").keypress(function (evt) {
//    return keypress_perc(evt);
//});
//ph relay
$("#value1_ph_relay_1").keypress(function (evt) {
    return keypress_channel(evt);
});
$("#value2_ph_relay_1").keypress(function (evt) {
    return keypress_perc(evt);
});

$("#value1_ph_relay_2").keypress(function (evt) {
    return keypress_channel(evt);
});
$("#value2_ph_relay_2").keypress(function (evt) {
    return keypress_perc(evt);
});

$("#value2_ph_relay_mch").keypress(function (evt) {
    return keypress_channel(evt);
});
$("#value2_ph_relay_range").keypress(function (evt) {
    return keypress_channel(evt);
});
$("#value2_ph_relay_setpoint").keypress(function (evt) {
    return keypress_channel(evt);
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

$("#value2_cl_pulse_mch").keypress(function (evt) {
    return keypress_channel(evt);
});
$("#value2_cl_pulse_range").keypress(function (evt) {
    return keypress_channel(evt);
});
$("#value2_cl_pulse_setpoint").keypress(function (evt) {
    return keypress_channel(evt);
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

$("#value2_cl_relay_mch").keypress(function (evt) {
    return keypress_channel(evt);
});
$("#value2_cl_relay_range").keypress(function (evt) {
    return keypress_channel(evt);
});
$("#value2_cl_relay_setpoint").keypress(function (evt) {
    return keypress_channel(evt);
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

    $("#riga1_ph_pulse_perc4").hide();
    $("#riga1_ph_pulse_perc3").hide();
    $("#riga2_ph_pulse_mch").hide();
    $("#value2_ph_pulse_perc3").hide();
    $("#riga1_ph_pulse_perc0").hide();
    $("#Div2").hide();

    $("#riga2_ph_pulse_setpoint").hide();
    $("#riga2_ph_pulse_range").hide();

    $("#value1_ph_pulse1_1").show();
    $("#value1_ph_pulse1_2").show();

   

    $("#value2_ph_pulse_perc3").hide();
  

}


function enable_channel_ph_pulse1_pid() {

    ph_pulse1_pm1 = false;
    ph_pulse1_pm2 = false;
    check_alarm_channel_ph_pulse1();
    remove_allarme('value2_ph_pulse1_1', 'riga2_ph_pulse1_1');
    remove_allarme('value2_ph_pulse1_2', 'riga2_ph_pulse1_2');
    $("#disable_ph_pulse1").show();


  





    $("#label1_ph_pulse1_proportional").hide();
    $("#label1_ph_pulse1_on_off").hide();
    $("#label2_ph_pulse1_proportional").hide();
    $("#label2_ph_pulse1_on_off").hide();

    $("#riga2_ph_pulse1_1").hide();
    $("#riga2_ph_pulse1_2").hide();
    $("#riga1_ph_pulse1_3").hide();

    
    $("#riga1_ph_pulse_perc4").hide();
    $("#riga1_ph_pulse_perc3").hide();
    $("#riga2_ph_pulse_mch").hide();
    $("#value2_ph_pulse_perc3").hide();
    $("#riga1_ph_pulse_perc0").hide();
    //$("#Div2").hide();


    $("#value1_ph_pulse1_1").hide();
    $("#value1_ph_pulse1_2").hide();

    $("#riga2_ph_pulse_setpoint").show();
    $("#riga2_ph_pulse_range").show();
    $("#value2_ph_pulse_perc3").hide();
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


    $("#riga1_ph_pulse1_3").hide();



    $("#riga1_ph_pulse_perc4").hide();
    $("#riga1_ph_pulse_perc3").hide();
    $("#riga2_ph_pulse_mch").hide();
    $("#riga1_ph_pulse_perc0").hide();
    $("#value2_ph_pulse_mch").hide();
   // $("#Div2").hide();

    $("#riga2_ph_pulse_setpoint").hide();
    $("#riga2_ph_pulse_range").hide();

    $("#value1_ph_pulse1_1").show();
    $("#value1_ph_pulse1_2").show();

    $("#value2_ph_pulse1_1").show();
    $("#value2_ph_pulse1_2").show();

    $("#value2_ph_pulse_perc3").hide();

   

    $("#riga2_ph_pulse1_1").show();
    $("#riga2_ph_pulse1_2").show();

   

}


//ph pulse 1
function enable_channel_ph_pulse1_prop_wm() {
    ph_pulse1_speed = false;
    check_alarm_channel_ph_pulse1();
    remove_allarme('value2_ph_pulse1_3', 'riga1_ph_pulse1_3');
    $("#disable_ph_pulse1").show();


    //$("#value2_ph_pulse1_3").hide();

  


    $("#label1_ph_pulse1_proportional").show();
    $("#label1_ph_pulse1_on_off").hide();
    $("#label2_ph_pulse1_proportional").show();
    $("#label2_ph_pulse1_on_off").hide();

    $("#riga2_ph_pulse1_1").show();
    $("#riga2_ph_pulse1_2").show();
    $("#riga1_ph_pulse1_3").hide();


    $("#riga2_ph_pulse_setpoint").hide();
    $("#riga2_ph_pulse_range").hide();

    //  $("#Div2").show();
    $("#value2_ph_pulse_perc3").show();
    $("#riga1_ph_pulse_perc0").show();
    $("#riga1_ph_pulse_perc4").show();
    $("#riga1_ph_pulse_perc3").show();
    $("#riga2_ph_pulse_mch").show();
    

    $("#Literal11").show();
    $("#Literal2").show();
    
    $("#value2_ph_pulse_mch").show();

    

    $("#value1_ph_pulse1_1").show();
    $("#value1_ph_pulse1_2").show();
    
  

}





//ph relay
function disable_channel_ph_relay() {
    ph_relay_on = false;
    ph_relay_pm1 = false;
    ph_relay_off = false;
    ph_relay_pm2 = false;
    check_alarm_channel_ph_relay();
    remove_allarme('value1_ph_relay_1', 'riga1_ph_relay_1');
    remove_allarme('value2_ph_relay_1', 'riga2_ph_relay_1');
    remove_allarme('value1_ph_relay_2', 'riga1_ph_relay_2');
    remove_allarme('value2_ph_relay_2', 'riga2_ph_relay_2');

    $("#disable_ph_relay").hide();
}


//ph relay
function enable_channel_ph_relay_on_off() {

    ph_relay_pm1 = false;
    ph_relay_pm2 = false;

    check_alarm_channel_ph_relay();
    remove_allarme('value2_ph_relay_1', 'riga2_ph_relay_1');
    remove_allarme('value2_ph_relay_2', 'riga2_ph_relay_2');
    $("#disable_ph_relay").show();

    $("#label1_ph_relay_else").hide();
    $("#label1_ph_relay_on_off").show();
    $("#riga2_ph_relay_1").hide();

    $("#label2_ph_relay_else").hide();
    $("#label2_ph_relay_on_off").show();
    $("#riga2_ph_relay_2").hide();



    //$("#riga2_ph_pulse1_1").hide();
    //$("#riga2_ph_pulse1_2").hide();
   // $("#riga1_ph_pulse1_3").show();

    $("#riga1_ph_relay_perc4").hide();
    $("#riga1_ph_relay_perc3").hide();
    $("#riga2_ph_relay_mch").hide();
    $("#value2_ph_relay_perc3").hide();
    $("#riga1_ph_relay_perc0").hide();


    $("#riga2_ph_relay_setpoint").hide();
    $("#riga2_ph_relay_range").hide();

    $("#value1_ph_relay_1").show();
    $("#value1_ph_relay_2").show();
} 

//ph relay
function enable_channel_ph_relay_proportionalpwm() {

    check_alarm_channel_ph_relay();
    $("#disable_ph_relay").show();

    $("#riga2_ph_relay_1").show();
    $("#riga2_ph_relay_2").show();

    $("#label1_ph_relay_on_off").hide();
    $("#label1_ph_relay_else").show();
    $("#label1_ph_relay_proportionalpwm").show();
    $("#label1_ph_relay_fixedpwm").hide();

    $("#label2_ph_relay_on_off").hide();
    $("#label2_ph_relay_else").show();
    $("#label2_ph_relay_proportionalpwm").show();
    $("#label2_ph_relay_fixedpwm").hide();

   // $("#riga2_ph_pulse1_1").hide();
    //$("#riga2_ph_pulse1_2").hide();
    $("#riga1_ph_pulse1_3").show();

    $("#riga1_ph_relay_perc4").hide();
    $("#riga1_ph_relay_perc3").hide();
    $("#riga2_ph_relay_mch").hide();
    $("#value2_ph_relay_perc3").hide();
    $("#riga1_ph_relay_perc0").hide();


    $("#riga2_ph_relay_setpoint").hide();
    $("#riga2_ph_relay_range").hide();

    $("#value1_ph_relay_1").show();
    $("#value1_ph_relay_2").show();



}

function enable_channel_ph_relay_pid() {
    check_alarm_channel_ph_relay();
    $("#disable_ph_relay").show();

    $("#riga2_ph_relay_1").hide();
    $("#riga2_ph_relay_2").hide();

    $("#label1_ph_relay_on_off").hide();
    $("#label1_ph_relay_else").hide();
    $("#label1_ph_relay_proportionalpwm").hide();
    $("#label1_ph_relay_fixedpwm").hide();

    $("#label2_ph_relay_on_off").hide();
    $("#label2_ph_relay_else").hide();
    $("#label2_ph_relay_proportionalpwm").hide();
    $("#label2_ph_relay_fixedpwm").hide();

 //   $("#riga2_ph_pulse1_1").hide();
   // $("#riga2_ph_pulse1_2").hide();
    $("#riga1_ph_pulse1_3").hide();

    $("#riga1_ph_relay_perc4").hide();
    $("#riga1_ph_relay_perc3").hide();
    $("#riga2_ph_relay_mch").hide();
    $("#value2_ph_relay_perc3").hide();
    $("#riga1_ph_relay_perc0").hide();


    $("#riga2_ph_relay_setpoint").show();
    $("#riga2_ph_relay_range").show();

    $("#value1_ph_relay_1").hide();
    $("#value1_ph_relay_2").hide();


}
function enable_channel_ph_relay_prop_wm() {

    check_alarm_channel_ph_relay();
    $("#disable_ph_relay").show();

    $("#riga2_ph_relay_1").show();
    $("#riga2_ph_relay_2").show();

    $("#label1_ph_relay_on_off").hide();
    $("#label1_ph_relay_else").show();
    $("#label1_ph_relay_proportionalpwm").show();
    $("#label1_ph_relay_fixedpwm").hide();

    $("#label2_ph_relay_on_off").hide();
    $("#label2_ph_relay_else").show();
    $("#label2_ph_relay_proportionalpwm").show();
    $("#label2_ph_relay_fixedpwm").hide();

 //   $("#riga2_ph_pulse1_1").hide();
  //  $("#riga2_ph_pulse1_2").hide();
    $("#riga1_ph_pulse1_3").show();

    $("#riga1_ph_relay_perc4").show();
    $("#riga1_ph_relay_perc3").show();
    $("#riga2_ph_relay_mch").show();
    $("#value2_ph_relay_perc3").show();
    $("#riga1_ph_relay_perc0").show();


    $("#riga2_ph_relay_setpoint").hide();
    $("#riga2_ph_relay_range").hide();

    $("#value1_ph_relay_1").show();
    $("#value1_ph_relay_2").show();
}


function enable_channel_ph_relay_fixedpwm() {

    check_alarm_channel_ph_relay();
    $("#disable_ph_relay").show();

    $("#riga2_ph_relay_1").show();
    $("#riga2_ph_relay_2").show();

    $("#label1_ph_relay_on_off").show();
    $("#label1_ph_relay_else").hide();
    $("#label1_ph_relay_proportionalpwm").hide();
    $("#label1_ph_relay_fixedpwm").show();

    $("#label2_ph_relay_on_off").show();
    $("#label2_ph_relay_else").hide();
    $("#label2_ph_relay_proportionalpwm").hide();
    $("#label2_ph_relay_fixedpwm").show();


   // $("#riga2_ph_pulse1_1").hide();
   // $("#riga2_ph_pulse1_2").hide();
    $("#riga1_ph_pulse1_3").show();

    $("#riga1_ph_relay_perc4").hide();
    $("#riga1_ph_relay_perc3").hide();
    $("#riga2_ph_relay_mch").hide();
    $("#value2_ph_relay_perc3").hide();
    $("#riga1_ph_relay_perc0").hide();


    $("#riga2_ph_relay_setpoint").hide();
    $("#riga2_ph_relay_range").hide();

    $("#value1_ph_relay_1").show();
    $("#value1_ph_relay_2").show();
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

    $("#value1_cl_pulse1_1").show();
    $("#value1_cl_pulse1_2").show();

    $("#riga2_cl_pulse_setpoint").hide();
    $("#riga2_cl_pulse_range").hide();


    $("#value2_cl_pulse_perc3").hide();
    $("#riga1_cl_pulse_perc0").hide();
    $("#riga1_cl_pulse_perc4").hide();
    $("#riga1_cl_pulse_perc3").hide();
    $("#riga2_cl_pulse_mch").hide();



    $("#value2_cl_pulse_mch").hide();
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

    $("#value1_cl_pulse1_1").show();
    $("#value1_cl_pulse1_2").show();

    $("#riga2_cl_pulse_setpoint").hide();
    $("#riga2_cl_pulse_range").hide();


    $("#value2_cl_pulse_perc3").hide();
    $("#riga1_cl_pulse_perc0").hide();
    $("#riga1_cl_pulse_perc4").hide();
    $("#riga1_cl_pulse_perc3").hide();
    $("#riga2_cl_pulse_mch").hide();



    $("#value2_cl_pulse_mch").hide();


}

function enable_channel_cl_pulse1_prop_wm() {
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

    $("#value1_cl_pulse1_1").show();
    $("#value1_cl_pulse1_2").show();

    $("#value2_cl_pulse_perc3").show();
    $("#riga1_cl_pulse_perc0").show();
    $("#riga1_cl_pulse_perc4").show();
    $("#riga1_cl_pulse_perc3").show();
    $("#riga2_cl_pulse_mch").show();



    $("#value2_cl_pulse_mch").show();

    $("#riga2_cl_pulse_setpoint").hide();
    $("#riga2_cl_pulse_range").hide();

  

}

function enable_channel_cl_pulse1_pid() {

    cl_pulse1_pm1 = false;
    cl_pulse1_pm2 = false;
    check_alarm_channel_cl_pulse1();

  

    remove_allarme('value2_cl_pulse1_1', 'riga2_cl_pulse1_1');
    remove_allarme('value2_cl_pulse1_2', 'riga2_cl_pulse1_2');
    $("#disable_cl_pulse1").show();
    $("#label1_cl_pulse1_proportional").hide();
    $("#label1_cl_pulse1_on_off").hide();
    $("#label2_cl_pulse1_proportional").hide();
    $("#label2_cl_pulse1_on_off").hide();

    $("#riga2_cl_pulse1_1").hide();
    $("#riga2_cl_pulse1_2").hide();
    $("#riga1_cl_pulse1_3").hide();

    $("#value1_cl_pulse1_1").hide();
    $("#value1_cl_pulse1_2").hide();

    

    $("#riga1_cl_pulse_perc4").hide();
    $("#riga1_cl_pulse_perc3").hide();
    $("#riga2_cl_pulse_mch").hide();
    $("#value2_cl_pulse_perc3").hide();
    $("#riga1_cl_pulse_perc0").hide();
    //$("#Div2").hide();


    $("#value1_cl_pulse1_1").hide();
    $("#value1_cl_pulse1_2").hide();

    $("#riga2_cl_pulse_setpoint").show();
    $("#riga2_cl_pulse_range").show();
    $("#value2_cl_pulse_perc3").hide();

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
    

    $("#value1_cl_relay_1").show();
    $("#value1_cl_relay_2").show();




    $("#riga1_cl_relay_perc4").hide();
    $("#riga1_cl_relay_perc3").hide();
    $("#riga2_cl_relay_mch").hide();
    $("#value2_cl_relay_perc3").hide();
    $("#riga1_cl_relay_perc0").hide();
   

    $("#riga2_cl_relay_setpoint").hide();
    $("#riga2_cl_relay_range").hide();
    $("#value2_cl_relay_perc3").hide();

}

function enable_channel_cl_relay_pid() {

    cl_relay_pm1 = false;
    cl_relay_pm2 = false;
    check_alarm_channel_cl_relay();
    remove_allarme('value2_cl_relay_1', 'riga2_cl_relay_1');
    remove_allarme('value2_cl_relay_2', 'riga2_cl_relay_2');
    $("#disable_cl_relay").show();

    $("#label1_cl_relay_else").hide();
    $("#label1_cl_relay_on_off").hide();
    $("#riga2_cl_relay_1").hide();

    $("#label2_cl_relay_else").hide();
    $("#label2_cl_relay_on_off").hide();
    $("#riga2_cl_relay_2").hide();


    $("#value1_cl_relay_1").hide();
    $("#value1_cl_relay_2").hide();




    $("#riga1_cl_relay_perc4").hide();
    $("#riga1_cl_relay_perc3").hide();
    $("#riga2_cl_relay_mch").hide();
    $("#value2_cl_relay_perc3").hide();
    $("#riga1_cl_relay_perc0").hide();


    $("#riga2_cl_relay_setpoint").show();
    $("#riga2_cl_relay_range").show();
    $("#value2_cl_relay_perc3").hide();

 

}

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

    $("#value1_cl_relay_1").show();
    $("#value1_cl_relay_2").show();

    $("#riga1_cl_relay_perc4").hide();
    $("#riga1_cl_relay_perc3").hide();
    $("#riga2_cl_relay_mch").hide();
    $("#value2_cl_relay_perc3").hide();
    $("#riga1_cl_relay_perc0").hide();


    $("#riga2_cl_relay_setpoint").hide();
    $("#riga2_cl_relay_range").hide();
    $("#value2_cl_relay_perc3").hide();

}
//cl relay
function enable_channel_cl_relay_prop_wm() {

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

    $("#value1_cl_relay_1").show();
    $("#value1_cl_relay_2").show();

    $("#riga1_cl_relay_perc4").show();
    $("#riga1_cl_relay_perc3").show();
    $("#riga2_cl_relay_mch").show();
    $("#value2_cl_relay_perc3").show();
    $("#riga1_cl_relay_perc0").show();


    $("#riga2_cl_relay_setpoint").hide();
    $("#riga2_cl_relay_range").hide();
    $("#value2_cl_relay_perc3").show();

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

    $("#value1_cl_relay_1").show();
    $("#value1_cl_relay_2").show();


    $("#riga1_cl_relay_perc4").hide();
    $("#riga1_cl_relay_perc3").hide();
    $("#riga2_cl_relay_mch").hide();
    $("#value2_cl_relay_perc3").hide();
    $("#riga1_cl_relay_perc0").hide();


    $("#riga2_cl_relay_setpoint").hide();
    $("#riga2_cl_relay_range").hide();
    $("#value2_cl_relay_perc3").hide();

}
//ph pulse 1
$("#off_ph_pulse1").click(function () {
    disable_channel_ph_pulse1();



});
$("#proportional_ph_pulse1").click(function () {
    enable_channel_ph_pulse1_proportional();
  
});
$("#on_off_ph_pulse1").click(function () {
    enable_channel_ph_pulse1_on_off();
 
});

$("#Prop_WM_ph_pulse1").click(function () {
    enable_channel_ph_pulse1_prop_wm();

});

$("#PID_ph_pulse1").click(function () {
    enable_channel_ph_pulse1_pid();
 
});




//ph pulse 2
//$("#off_ph_pulse2").click(function () {
//    disable_channel_ph_pulse2();

//});
//$("#proportional_ph_pulse2").click(function () {
//    enable_channel_ph_pulse2_proportional();
//});
//$("#on_off_ph_pulse2").click(function () {
//    enable_channel_ph_pulse2_on_off();
//});

//ph relay
$("#on_off_ph_relay").click(function () {
    enable_channel_ph_relay_on_off();

});
$("#proportional_ph_relay").click(function () {

    enable_channel_ph_relay_proportionalpwm();
});
$("#fixed_ph_relay").click(function () {
    enable_channel_ph_relay_fixedpwm();
});
$("#off_ph_relay").click(function () {
    disable_channel_ph_relay();
});

$("#Prop_WM_ph_relay").click(function () {
    enable_channel_ph_relay_prop_wm();
});

$("#PID_ph_relay").click(function () {
    enable_channel_ph_relay_pid();
});



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
$("#Prop_WM_cl_pulse1").click(function () {
    enable_channel_cl_pulse1_prop_wm();
});
$("#PID_cl_pulse1").click(function () {
    enable_channel_cl_pulse1_pid();
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
$("#Prop_WM_cl_relay").click(function () {
    enable_channel_cl_relay_prop_wm();
});
$("#PID_cl_relay").click(function () {
    enable_channel_cl_relay_pid();
});



$("#tab_ld_sp1").click(function () {
    if ($('#on_off_ph_pulse1').is(':checked')) {
        enable_channel_ph_pulse1_on_off();
    }
    if ($('#proportional_ph_pulse1').is(':checked')) {
        enable_channel_ph_pulse1_proportional();
    }
    if ($('#off_ph_pulse1').is(':checked')) {
        disable_channel_ph_pulse1();
    }
    if ($('#Prop_WM_ph_pulse1').is(':checked')) {
        enable_channel_ph_pulse1_prop_wm();
    }
    if ($('#PID_ph_pulse1').is(':checked')) {
        enable_channel_ph_pulse1_pid();
    }
    
});
$("#tab_ld_sp2").click(function () {
    if ($('#on_off_ph_pulse2').is(':checked')) {
        enable_channel_ph_pulse2_on_off();
    }
    if ($('#proportional_ph_pulse2').is(':checked')) {
        enable_channel_ph_pulse2_proportional();
    }
    if ($('#off_ph_pulse2').is(':checked')) {
        disable_channel_ph_pulse2();
    }
    if ($('#Prop_WM_ph_pulse2').is(':checked')) {
        enable_channel_ph_pulse2_prop_wm();
    }
    if ($('#PID_ph_pulse2').is(':checked')) {
        enable_channel_ph_pulse2_pid();
    }
});
$("#tab_ld_sp3").click(function () {
    if ($('#on_off_ph_relay').is(':checked')) {
        enable_channel_ph_relay_on_off();
    }
    if ($('#proportional_ph_relay').is(':checked')) {
        enable_channel_ph_relay_proportionalpwm();
    }
    if ($('#fixed_ph_relay').is(':checked')) {
        enable_channel_ph_relay_fixedpwm();
    }
    if ($('#off_ph_relay').is(':checked')) {
        disable_channel_ph_relay();
    }
    if ($('#Prop_WM_ph_relay').is(':checked')) {
        enable_channel_ph_relay_prop_wm();
    }
    if ($('#PID_ph_relay').is(':checked')) {
        enable_channel_ph_relay_pid();
    }


    
});
$("#tab_ld_sp4").click(function () {
    if ($('#on_off_cl_pulse1').is(':checked')) {
        enable_channel_cl_pulse1_on_off();
    }
    if ($('#proportional_cl_pulse1').is(':checked')) {
        enable_channel_cl_pulse1_proportional();
    }
    if ($('#off_cl_pulse1').is(':checked')) {
        disable_channel_cl_pulse1();
    }
    if ($('#Prop_WM_cl_pulse1').is(':checked')) {
        enable_channel_cl_pulse1_prop_wm();
    }
    if ($('#PID_cl_pulse1').is(':checked')) {
        enable_channel_cl_pulse1_pid();
    }


});
$("#tab_ld_sp5").click(function () {
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
    if ($('#Prop_WM_cl_relay').is(':checked')) {
        enable_channel_cl_relay_prop_wm();
    }
    if ($('#PID_cl_relay').is(':checked')) {
        enable_channel_cl_relay_pid();
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
//ph pulse 2
//$("#value1_ph_pulse2_1").click(function () {
//    //$(this).val("");
//    $(this).next('p').remove();
//    $("#riga1_ph_pulse2_1").removeClass('error');
//    ph_pulse2_on = false;
//    check_alarm_channel_ph_pulse2();
//    // $("#principale").load("test.aspx");
//});
//$("#value2_ph_pulse2_1").click(function () {
//    //$(this).val("");
//    $(this).next('p').remove();
//    $("#riga2_ph_pulse2_1").removeClass('error');
//    ph_pulse2_pm1 = false;
//    check_alarm_channel_ph_pulse2();
//    // $("#principale").load("test.aspx");
//});
//$("#value1_ph_pulse2_2").click(function () {
//    //$(this).val("");
//    $(this).next('p').remove();
//    $("#riga1_ph_pulse2_2").removeClass('error');
//    ph_pulse2_off = false;
//    check_alarm_channel_ph_pulse2();
//    // $("#principale").load("test.aspx");
//});
//$("#value2_ph_pulse2_2").click(function () {
//    //$(this).val("");
//    $(this).next('p').remove();
//    $("#riga2_ph_pulse2_2").removeClass('error');
//    ph_pulse2_pm2 = false;
//    check_alarm_channel_ph_pulse2();
//    // $("#principale").load("test.aspx");
//});
//$("#value2_ph_pulse2_3").click(function () {
//    //$(this).val("");
//    $(this).next('p').remove();
//    $("#riga1_ph_pulse2_3").removeClass('error');
//    ph_pulse2_speed = false;
//    check_alarm_channel_ph_pulse2();
//    // $("#principale").load("test.aspx");
//});
// ph relay
$("#value1_ph_relay_1").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga1_ph_relay_1").removeClass('error');
    ph_relay_on = false;
    check_alarm_channel_ph_relay();
    // $("#principale").load("test.aspx");
});
$("#value2_ph_relay_1").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga2_ph_relay_1").removeClass('error');
    ph_relay_pm1 = false;
    check_alarm_channel_ph_relay();
    // $("#principale").load("test.aspx");
});

$("#value1_ph_relay_2").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga1_ph_relay_2").removeClass('error');
    ph_relay_off = false;
    check_alarm_channel_ph_relay();
    // $("#principale").load("test.aspx");
});
$("#value2_ph_relay_2").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga2_ph_relay_2").removeClass('error');
    ph_relay_pm2 = false;
    check_alarm_channel_ph_relay();
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

$("#save_setpointldsC_new").click(function () {
    if (enable_send_setpoint == false) {
        result_setpoint_change(user_setpoint_disable);
        return false;
    }

    $('#save_setpointldsC_new').next('p').remove();
    if (!($('#off_ph_pulse1').is(':checked'))) {
        Changed_channel('value1_ph_pulse1_1', 'riga1_ph_pulse1_1', max_ch1_value, min_ch1_value, max_fix_value1);
        Changed_channel('value2_ph_pulse1_1', 'riga2_ph_pulse1_1', 180, 0, 0);
        Changed_channel('value1_ph_pulse1_2', 'riga1_ph_pulse1_2', max_ch1_value, min_ch1_value, max_fix_value1);
        Changed_channel('value2_ph_pulse1_2', 'riga2_ph_pulse1_2', 180, 0, 0);
        if ($('#proportional_ph_pulse1').is(':checked')) Changed_channel('value2_ph_pulse1_3', 'riga1_ph_pulse1_3', 99, 0, 0);
    }

    if (!($('#off_ph_relay').is(':checked'))) {
        Changed_channel('value1_ph_relay_1', 'riga1_ph_relay_1', max_ch1_value, min_ch1_value, max_fix_value1);
        Changed_channel('value2_ph_relay_1', 'riga2_ph_relay_1', 100, 0, 0);
        Changed_channel('value1_ph_relay_2', 'riga1_ph_relay_2', max_ch1_value, min_ch1_value, max_fix_value1);
        Changed_channel('value2_ph_relay_2', 'riga2_ph_relay_2', 100, 0, 0);
    }
    //if (!($('#off_cl_pulse1').is(':checked'))) {
    //    Changed_channel('value1_cl_pulse1_1', 'riga1_cl_pulse1_1', max_ch1_value, min_ch1_value, max_fix_value1);
    //    Changed_channel('value2_cl_pulse1_1', 'riga2_cl_pulse1_1', 180, 0, 0);
    //    Changed_channel('value1_cl_pulse1_2', 'riga1_cl_pulse1_2', max_ch1_value, min_ch1_value, max_fix_value1);
    //    Changed_channel('value2_cl_pulse1_2', 'riga2_cl_pulse1_2', 180, 0, 0);
    //    Changed_channel('value2_cl_pulse1_3', 'riga1_cl_pulse1_3', 99, 0, 0);
    //}
    //if (!($('#off_cl_relay').is(':checked'))) {
    //    Changed_channel('value1_cl_relay_1', 'riga1_cl_relay_1', max_ch1_value, min_ch1_value, max_fix_value1);
    //    Changed_channel('value2_cl_relay_1', 'riga2_cl_relay_1', 100, 0, 0);
    //    Changed_channel('value1_cl_relay_2', 'riga1_cl_relay_2', max_ch1_value, min_ch1_value, max_fix_value1);
    //    Changed_channel('value2_cl_relay_2', 'riga2_cl_relay_2', 100, 0, 0);
    //}

    if (!($('#off_cl_pulse1').is(':checked'))) {
        Changed_channel('value1_cl_pulse1_1', 'riga1_cl_pulse1_1', max_ch1_value, min_ch1_value, max_fix_value1);
        Changed_channel('value2_cl_pulse1_1', 'riga2_cl_pulse1_1', 180, 0, 0);
        Changed_channel('value1_cl_pulse1_2', 'riga1_cl_pulse1_2', max_ch1_value, min_ch1_value, max_fix_value1);
        Changed_channel('value2_cl_pulse1_2', 'riga2_cl_pulse1_2', 180, 0, 0);
        
        if ($('#Prop_WM_cl_pulse1').is(':checked')) Changed_channel('value2_cl_pulse1_3', 'riga1_cl_pulse1_3', 99, 0, 0);
    }
    if (!($('#off_cl_relay').is(':checked'))) {
        Changed_channel('value1_cl_relay_1', 'riga1_cl_relay_1', max_ch1_value, min_ch1_value, max_fix_value1);
        Changed_channel('value2_cl_relay_1', 'riga2_cl_relay_1', 100, 0, 0);
        Changed_channel('value1_cl_relay_2', 'riga1_cl_relay_2', max_ch1_value, min_ch1_value, max_fix_value1);
        Changed_channel('value2_cl_relay_2', 'riga2_cl_relay_2', 100, 0, 0);
    }
    if ((ph_pulse1_on) || (ph_pulse1_pm1) || (ph_pulse1_off) || (ph_pulse1_pm2) ||
          (ph_pulse1_speed) || (ph_relay_on) || (ph_relay_off) ||
          (ph_relay_pm2) || (cl_pulse1_pm1) || (cl_pulse1_off) || (cl_pulse1_pm2) ||
          (cl_pulse1_speed) || (cl_relay_on) || (cl_relay_pm1) || (cl_relay_off) ||
          (cl_relay_pm2)) {
       


        //if (ph_pulse1_on) alert("1");
        //if (ph_pulse1_pm1) alert("2");
        //if (ph_pulse1_off) alert("3");
        //if (ph_pulse1_pm2) alert("4");
        //if (ph_pulse1_speed) alert("5");
        //if (ph_relay_on) alert("6");
        //if (ph_relay_off) alert("7");
        //if (ph_relay_pm2) alert("8");
        //if (cl_pulse1_pm1) alert("9");
        //if (cl_pulse1_off) alert("10");
        //if (cl_pulse1_pm2) alert("11");
        //if (cl_pulse1_speed) alert("12");
        //if (cl_relay_on) alert("13");
        //if (cl_relay_pm1) alert("14");
        //if (cl_relay_off) alert("15");
        //if (cl_relay_pm2) alert("16");
        


        $('#save_setpointldsC_new').next('p').remove();

        $('#save_setpointldsC_new').after('<p class="error help-block"><span class="label label-important">' + wrong_settings + '</span></p>');
        submit_status = false;
        error_general = false;

        return false;
    }
    submit_status = true;
    error_general = true;
    notification['confirm'] = modify_plant;
    notification['annulla'] = annulla_impianto;

});

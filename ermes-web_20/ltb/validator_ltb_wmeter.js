
var valore = false;

var maxflow = false;

var timeout = false;




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
        case "value_wm":
      
            valore = false
            valore = var_alarm;
            check_alarm_valore();
           

            break;


        case "value_resol":
   
            maxflow = false
            maxflow = var_alarm;
            check_alarm_maxflow();
       


            break;


        case "valore_timeout":
       
            timeout = false;
            timeout = var_alarm;
            check_alarm_timeout();
    

            break;


      

    }
}



function check_alarm_valore() {
 
    if ((valore == true)) {
        $("#tab_ld_sp1").attr('style', 'color:#b94a48');
    }
    else {
        $("#tab_ld_sp1").removeAttr('style');
    }

}


function check_alarm_maxflow() {

    if ((maxflow == true)) {
        $("#tab_ld_sp1").attr('style', 'color:#b94a48');
    }
    else {
        $("#tab_ld_sp1").removeAttr('style');
    }
}

function check_alarm_timeout() {

    if ((timeout == true)) {
        $("#tab_ld_sp1").attr('style', 'color:#b94a48');
    }
    else {
        $("#tab_ld_sp1").removeAttr('style');
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



$("#value_wm").keypress(function (evt) {

    return keypress_channel(evt);
});

$("#value_wm").click(function () {

    $(this).next('p').remove();
    $("#riga1_value").removeClass('error');
    valore = false;

    check_alarm_valore();

    // $("#principale").load("test.aspx");
});


$("#value_resol").keypress(function (evt) {
    return keypress_channel(evt);
});

$("#value_resol").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga1_resolution").removeClass('error');
    maxflow = false;

    check_alarm_maxflow();
    // $("#principale").load("test.aspx");
});




$("#valore_timeout").keypress(function (evt) {
    return keypress_perc(evt);
});
$("#valore_timeout").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    $("#riga1_timeout").removeClass('error');
    timeout = false;
    check_alarm_timeout();
    // $("#principale").load("test.aspx");
});











$("#save_wmeterltb_new").click(function () {
    if (enable_send_setpoint == false) {
        result_setpoint_change(user_setpoint_disable);
        return false;
    }

    $('#save_wmeterltb_new').next('p').remove();

   var valore = false;

    var maxflow = false;

    var timeout = false;




   
    

    

    Changed_channel('value_wm', 'riga1_value', 1200, 0, 1);

    Changed_channel('value_resol', 'riga1_resolution', 9999, 0, 1);

Changed_channel('value_timeout', 'riga1_timeout', 99, 1, 0);


    if ((valore) ||
        (maxflow) ||
           (timeout)) {
        $('#save_wmeterltb_new').next('p').remove();

        $('#save_wmeterltb_new').after('<p class="error help-block"><span class="label label-important">' + wrong_settings + '</span></p>');
        submit_status = false;
        error_general = false;
       
        return false;
    }
    submit_status = true;
    error_general = true;
    notification['confirm'] = modify_plant;
    notification['annulla'] = annulla_impianto;

});

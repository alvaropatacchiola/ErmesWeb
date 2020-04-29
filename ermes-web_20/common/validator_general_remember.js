var alarm_email = false;

function keypress_check_mail(id1) {
    var email_re = /^[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,4}$/i;
    var id = "#" + id1;
    var value_form = $(id).val();
    var value_form_lunghezza = $(id).val().length;
    var var_alarm = false;

    if ((value_form_lunghezza == 0) || ((value_form_lunghezza > 0) && (value_form.search(email_re) == -1))) {
        //alert(invalid_mail_format);
        
        $(id).next('p').remove();

        $(id).after('<p class="error help-block"><span class="label label-important">' + invalid_mail_format + '</span></p>');

        var_alarm = true;
    }
    else {
        
        var_alarm = false;
        $(id).next('p').remove();
    }
    switch (id1) {
        case "email_val":
            alarm_email = var_alarm;
            break;
    }

}
function check_button1() {
    keypress_check_mail('email_val');


    if ((alarm_email)) {

        return false;
    }
    else {
        // $("#form_add_impianto").submit();
        return true;
    }
}

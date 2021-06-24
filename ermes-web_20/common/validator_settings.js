
var alarm_azienda = false;
var alarm_username = false;
var alarm_password = false;
var alarm_confirm_password = false;
var alarm_email = false;


function Changed_channel(id1, lunghezza) {


    var id = "#" + id1;
    var var_lunghezza = $(id).val().length;
    var alarm = false;
    //$(id).next('p').remove();ù
    $(id).next("div").remove();
    if ((var_lunghezza == 0) || (var_lunghezza < lunghezza)) {
        alarm = true;
        if (var_lunghezza == 0) {
            //$(id).after('<p class="error help-block"><span class="label label-important">*' + required + '</span></p>');
            $(id).after("<div class=\"text-danger small mt-1\">*" + required + "</div>");
        }
        else {
            //$(id).after('<p class="error help-block"><span class="label label-important">' + username_6 + '</span></p>');
            $(id).after("<div class=\"text-danger small mt-1\">*" + username_6 + "</div>");
        }
    }
    switch (id1) {
        case "inputcompany":
            alarm_azienda = alarm;
            //check_first();
            break;
        case "Username":

            alarm_username = alarm;
            //check_quarto();
            break;
    }

}


function check_password_new(id1, id1_1) {
    var id = "#" + id1;
    var id1 = "#" + id1_1;
    var value_form_lunghezza = $(id).val().length;
    var value_form = $(id).val();

    var value_form_lunghezza_1 = $(id1).val().length;
    var value_form_1 = $(id1).val();
    if ((value_form != value_form_1) || (value_form_lunghezza < 4) || (value_form_lunghezza_1 < 4)) {
        //$(id).next('p').remove();
        $(id).next("div").remove();
        //$(id1).next('p').remove();
        $(id1).next("div").remove();
        if (value_form_lunghezza < 4) {
            //$(id).after('<p class="error help-block"><span class="label label-important">' + password_6_new + '</span></p>');
            $(id).after("<div class=\"text-danger small mt-1\">*" + password_6_new + "</div>");
            return false;
        }
        if (value_form_lunghezza_1 < 4) {
            //$(id1).after('<p class="error help-block"><span class="label label-important">' + password_uguale + '</span></p>');
            $(id1).after("<div class=\"text-danger small mt-1\">*" + password_uguale + "</div>");
            return false;
        }

        if (value_form != value_form_1) {
            //$(id1).after('<p class="error help-block"><span class="label label-important">' + password_uguale + '</span></p>');
            $(id1).after("<div class=\"text-danger small mt-1\">*" + password_uguale + "</div>");
            return false;
        }

    }
    else {
        //$(id).next('p').remove();
        $(id).next("div").remove();
        //$(id1).next('p').remove();
        $(id1).next("div").remove();
    }
    return true;
}
function keypress_check_mail(id1) {
    var email_re = /^[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,4}$/i;
    var id = "#" + id1;
    var value_form = $(id).val();
    var value_form_lunghezza = $(id).val().length;
    var var_alarm = false;

    if ((value_form_lunghezza == 0) || ((value_form_lunghezza > 0) && (value_form.search(email_re) == -1))) {
        //alert(invalid_mail_format);

        //$(id).next('p').remove();
        $(id).next("div").remove();

        //$(id).after('<p class="error help-block"><span class="label label-important">' + invalid_mail_format + '</span></p>');
        $(id1).after("<div class=\"text-danger small mt-1\">*" + invalid_mail_format + "</div>");

        var_alarm = true;
    }
    else {
        var_alarm = false;
        //$(id).next('p').remove();
        $(id).next("div").remove();
    }
    switch (id1) {
        case "email_val":
            alarm_email = var_alarm;
            break;
    }

}

$("#save_modifica_account_new").click(function () {
    var validator_password_old = false;
    var validator_password = false;

    //$('#save_modifica_account_new').next('p').remove();
    $('#save_modifica_account_new').next("div").remove();
    Changed_channel('inputcompany', 0);
    Changed_channel('Username', 6);
    validator_password = check_password_new('password', 'confirm_password');
    keypress_check_mail('email_val');
    if ((alarm_azienda) || (alarm_username) || (validator_password == false) || (alarm_email)) {
        //$('#save_modifica_account_new').after('<p class="error help-block"><span class="label label-important">' + wrong_settings + '</span></p>');
        $('#save_modifica_account_new').after("<div class=\"text-danger small mt-1\">*" + wrong_settings + "</div>");
        error_general = false;
        return false;
    }
    else {
        // $("#form_add_impianto").submit();
        error_general = true;
        //notification['confirm'] = modify_plant;
        //notification['annulla'] = annulla_impianto;
        return true;
    }
});
function errorUpdate() {
    $('#save_modifica_account_new').next("div").remove();
    $('#save_modifica_account_new').val("Save Error")
    $('#save_modifica_account_new').after("<div class=\"text-danger small mt-1\">Update Error Try Now</div>");
}
function invalidFileFormat() {
    $('#FileUpload1').next("div").remove();
    $('#FileUpload1').after("<div class=\"text-danger small mt-1\">Invalid file extension</div>");
    
}
function invalidFileSize() {
    $('#FileUpload1').next("div").remove();
    $('#FileUpload1').after("<div class=\"text-danger small mt-1\">Max size 2Mbyte</div>");

}
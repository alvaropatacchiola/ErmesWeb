var alarm_nome = false;
var alarm_username = false;
var alarm_password = false;


function Changed_channel(id1, lunghezza) {


    var id = "#" + id1;
    var var_lunghezza = $(id).val().length;
    var alarm = false;
    $(id).next('p').remove();
    if ((var_lunghezza == 0) || (var_lunghezza < lunghezza)) {
        alarm = true;
        if (var_lunghezza == 0) {
            $(id).after('<p class="error help-block"><span class="label label-important">*' + required + '</span></p>');
        }
        else {
            $(id).after('<p class="error help-block"><span class="label label-important">' + username_6 + '</span></p>');
        }
    }
    switch (id1) {
        case "nome_utilizzatore":
            alarm_nome = alarm;
            //check_first();
            break;
        case "username_utilizzatore":
            alarm_username = alarm;
            //check_quarto();
            break;
        case "password_utilizzatore":
            alarm_password = alarm;
            //check_quarto();
            break;

    }

}




$("#save_aggiungi_utilizzatore_new").click(function () {

    $('#save_aggiungi_utilizzatore_new').next('p').remove();
    Changed_channel('nome_utilizzatore', 2);
    Changed_channel('username_utilizzatore', 6);
    Changed_channel('password_utilizzatore', 6);


    if ((alarm_nome) || (alarm_username) || (alarm_password)) {
        $('#save_aggiungi_utilizzatore_new').after('<p class="error help-block"><span class="label label-important">' + wrong_settings + '</span></p>');
        error_general = false;
        return false;
    }
    else {
        // $("#form_add_impianto").submit();
        error_general = true;
        notification['confirm'] = confirm_modify_user;
        notification['annulla'] = annulla_impianto;
        return true;
    }
});
var alarm_nome = false;
var alarm_username = false;
var alarm_password = false;


function Changed_channel(id1, lunghezza) {


    var id = "#" + id1;
    var var_lunghezza = $(id).val().length;
    var alarm = false;
    //$(id).next('p').remove();
    $(id).next("div").remove();
    if ((var_lunghezza == 0) || (var_lunghezza < lunghezza)) {
        alarm = true;
        if (var_lunghezza == 0) {
           // $(id).after('<p class="error help-block"><span class="label label-important">*' + required + '</span></p>');
            $(id).after("<div class=\"text-danger small mt-1\">*" + required + "</div>");
        }
        else {
            //$(id).after('<p class="error help-block"><span class="label label-important">' + username_6 + '</span></p>');
            $(id).after("<div class=\"text-danger small mt-1\">*" + username_6 + "</div>");
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

    //$('#save_aggiungi_utilizzatore_new').next('p').remove();
    $('#save_aggiungi_utilizzatore_new').next("div").remove();
    Changed_channel('nome_utilizzatore', 2);
    Changed_channel('username_utilizzatore', 6);
    Changed_channel('password_utilizzatore', 6);


    if ((alarm_nome) || (alarm_username) || (alarm_password)) {
        //$('#save_aggiungi_utilizzatore_new').after('<p class="error help-block"><span class="label label-important">' + wrong_settings + '</span></p>');
        $('#save_modifica_impianto_new').after("<div class=\"text-danger small mt-1\">" + wrong_settings + "</div>");

        error_general = false;
        return false;
    }
    else {
        $(".ModeSendLoad").show();
        $('#save_aggiungi_utilizzatore_new').val("Saving ....")
        // $("#form_add_impianto").submit();
        error_general = true;

        return true;
    }
});

function utilizzatoreOK() {
    $('#save_aggiungi_utilizzatore_new').next("div").remove();
    $('#save_aggiungi_utilizzatore_new').val("Save Completed")

}
function utilizzatoreDuplicato() {
    $('#save_aggiungi_utilizzatore_new').next("div").remove();
    $('#save_aggiungi_utilizzatore_new').val("Save Error")
    $('#save_aggiungi_utilizzatore_new').after("<div class=\"text-danger small mt-1\">" + utilizzatore_duplicato + "</div>");
}
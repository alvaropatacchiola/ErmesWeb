var alarm_first = false;
var alarm_first1 = false;
var alarm_terzo = false;
var alarm_terzo1 = false;
var alarm_terzo2 = false;
var alarm_quarto = false;
var alarm_quinto = false;

var error_general = false;
function get_place1() {
    return codice_6cifre_place;
}


function disabilita_form() {
    $("#inputTitle").prop('disabled', true);
    $("#Text1").prop('disabled', true);
    $("#Text2").prop('disabled', true);
    $("#Text3").prop('disabled', true);
}
function abilita_form() {
    $("#inputTitle").prop('disabled', false);
    $("#Text1").prop('disabled', false);
    $("#Text2").prop('disabled', false);
    $("#Text3").prop('disabled', false);
}
function reset_form() {
    $('#inputTitle').val('');
    $('#Text1').val('');
    $('#Text2').val('');
    $('#Text3').val('');
}
function reset_form_gruppo() {
    $('#textGruppo').val('');
}
function reset_form_sotto_gruppo() {
    $('#Text11').val('');
}

function abilita_form_gruppo() {
    $("#textGruppo").prop('disabled', false);
}
function abilita_form_sotto_gruppo() {
   // $("#Text11").prop('disabled', false);
}

function disabilita_form_gruppo() {
    $("#textGruppo").prop('disabled', true);
}
function disabilita_form_sotto_gruppo() {
   // $("#Text11").prop('disabled', true);
}

function riempi_form(indirizzo_testo) {
    var lines = indirizzo_testo.split('-');

    var indice = 0;

    for (indice = 0; indice < lines.length; indice++) {
        switch (indice) {
            case 0:

                $('#countries').val(lines[indice]);
                break;
            case 2:
                $('#inputTitle').val(lines[indice]);

                break;
            case 3:
                $('#Text1').val(lines[indice]);

                break;

            case 4:
                //$('#Text2').val(lines[indice]);
                var lines1 = lines[indice].split(',');
                var indice1 = 0;
                for (indice1 = 0; indice1 < lines1.length; indice1++) {
                    switch (indice1) {
                        case 0:
                            $('#Text2').val(lines1[indice1]);
                            break;
                        case 1:
                            $('#Text3').val(lines1[indice1]);
                            break;
                    }
                }
                break;
        }

    }
}
function crea_sottogruppo(items_sottogruppo) {
    $('#sottogruppi option').remove();

    $('#sottogruppi').append(new Option("New..", "nuovo"));
    if (items_sottogruppo != "null") {
        var lines = items_sottogruppo.split('>');
        var indice = 0;
        for (indice = 1; indice < lines.length; indice++) {
            $('#sottogruppi').append(new Option(lines[indice], lines[indice]));
        }
    }
}
$("#indirizzi").change(function () {
    var indice = $('#indirizzi').find('option:selected').val();
    reset_form();
    if (indice != "nuovo") {

        riempi_form($('#indirizzi').find('option:selected').val());
        disabilita_form();
    }
    else {

        abilita_form();
    }


});
$("#sottogruppi").change(function () {
    var indice = $('#sottogruppi').find('option:selected').val();
    reset_form_sotto_gruppo();
    if (indice != "nuovo") {
        $('#Text11').val($('#sottogruppi').find('option:selected').val());
        disabilita_form_sotto_gruppo();
    }
    else {
        abilita_form_sotto_gruppo();
    }
});
$("#gruppi").change(function () {
    
    var indice = $('#gruppi').find('option:selected').val();

    reset_form_gruppo();

    if (indice != "nuovo") {

        $('#textGruppo').val($('#gruppi').find('option:selected').text());

        crea_sottogruppo($('#gruppi').find('option:selected').val());
        disabilita_form_gruppo();
    }
    else {
        crea_sottogruppo("null");
        abilita_form_gruppo();
    }


});

function Changed_channel(id1,lunghezza) {

    var id = "#" + id1;
    var var_lunghezza = $(id).val().length;
    var alarm = false;
    $(id).next('p').remove();
    
    if ((var_lunghezza == 0) || (var_lunghezza < lunghezza)) {
        alarm = true;
        if (var_lunghezza == 0) {
            $(id).after('<p class="error help-block"><span class="label label-important">*'+ required +'</span></p>');
        }
        else {
            $(id).after('<p class="error help-block"><span class="label label-important">*6 '+ numeric_digit +'</span></p>');
        }
    }
    switch (id1) {
        case "inputCodice":
            alarm_first = alarm;
            check_first();
            break;

        case "textDescription":
            alarm_first1 = alarm;
            check_first();
            break;
        case "textGruppo":
            
            alarm_quarto = alarm;
            check_quarto();
            break;
        case "Text11":
            alarm_quinto = alarm;
            check_quinto();
            break;
        case "Text9":
            alarm_terzo = alarm;
            check_terzo();
            break;

        case "Text10":
            alarm_terzo1 = alarm;
            check_terzo();
            break;

        case "Text12":
            alarm_terzo2 = alarm;
            check_terzo();
            break;
            
    }

}
function check_first() {
    if ((alarm_first == true) || (alarm_first1 == true)) {
        $("#tab3_3").attr('style', 'color:#b94a48');
    }
    else {
        $("#tab3_3").removeAttr('style');
    }

}
function check_quarto() {
    if ((alarm_quarto == true)) {
        $("#tab1_1").attr('style', 'color:#b94a48');
    }
    else {
        $("#tab1_1").removeAttr('style');
    }

}
function check_quinto() {
    if ((alarm_quinto == true)) {
        $("#tab2_2").attr('style', 'color:#b94a48');
    }
    else {
        $("#tab2_2").removeAttr('style');
    }

}

function check_terzo() {
    if ((alarm_terzo == true) || (alarm_terzo1 == true) || (alarm_terzo2 == true)) {
        $("#tab6_6").attr('style', 'color:#b94a48');
    }
    else {
        $("#tab6_6").removeAttr('style');
    }

}



function keypress_perc(evt) {
    var charCode = (evt.which) ? evt.which : event.keyCode
    if (charCode > 31 && (charCode < 48 || charCode > 57))
        return false;

    return true;
}
$("#inputCodice").keypress(function (evt) {
     return keypress_perc(evt);
});
        

$("#inputCodice").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    alarm_first = false;
    check_first();
    // $("#principale").load("test.aspx");
});
$("#textDescription").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    alarm_first1 = false;
    check_first();
    // $("#principale").load("test.aspx");
});
$("#textGruppo").click(function () {
    //$(this).val("");
    
    $(this).next('p').remove();
    alarm_quarto = false;
    check_quarto();
    // $("#principale").load("test.aspx");
});
$("#Text11").click(function () {
    //$(this).val("");
    
    $(this).next('p').remove();
    alarm_quinto = false;
    check_quinto();
    // $("#principale").load("test.aspx");
});

$("#Text9").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    alarm_terzo = false;
    check_terzo();
    // $("#principale").load("test.aspx");
});
$("#Text10").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    alarm_terzo1 = false;
    check_terzo();
    // $("#principale").load("test.aspx");
});
$("#Text12").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    alarm_terzo2 = false;
    check_terzo();
    // $("#principale").load("test.aspx");
});

function identificativo_presente() {
    
    alarm_first = true;
    check_first();
    $("#inputCodice").next('p').remove();
    $("#inputCodice").after('<p class="error help-block"><span class="label label-important">*' + impianto_duplicato + '</span></p>');
}

function user_presente() {
    
    alarm_terzo = true;
    alarm_terzo1 = true;
    alarm_terzo2 = true;
    check_terzo();
    $("#Text9").next('p').remove();
    $("#Text9").after('<p class="error help-block"><span class="label label-important">*' + impianto_duplicato + '</span></p>');
    $("#Text10").next('p').remove();
    $("#Text10").after('<p class="error help-block"><span class="label label-important">*' + impianto_duplicato + '</span></p>');
    $("#Text12").next('p').remove();
    $("#Text12").after('<p class="error help-block"><span class="label label-important">*' + impianto_duplicato + '</span></p>');
}
function manage_nuovi_impianti() {
    var indice_utilizzatore = $('#utilizzatore_list').find('option:selected').val();
   
    //var indice_utilizzatore = 0;
    if (indice_utilizzatore == 0) {
        $("#enable_utilizzatore").hide();
        
    }
    else {
        $("#enable_utilizzatore").show();
        if (indice_utilizzatore == 1) {
            $("#Text9").prop('disabled', false);
            $("#Text10").prop('disabled', false);
            $("#Text12").prop('disabled', false);
        }
        else
        {
            var utilizzatore_string = $('#utilizzatore_list').find('option:selected').val();
            var lines_utilizzatore = utilizzatore_string.split(',');

            $("#Text12").val(lines_utilizzatore[1]);
            $("#Text9").val(lines_utilizzatore[2]);
            $("#Text10").val(lines_utilizzatore[3]);
            if (lines_utilizzatore[4] == "False") {
                $("#check1").attr('checked', false);
            }
            else {
                $("#check1").attr('checked', true);
            }
            $("#Text9").prop('disabled', true);
            $("#Text10").prop('disabled', true);
            $("#Text12").prop('disabled', true);
        }
    }
}

$("#utilizzatore_list").change(function () {
    
    manage_nuovi_impianti();
});
$("#save_impianto_new").click(function () {
    
    $('#save_impianto_new').next('p').remove();
    Changed_channel( 'inputCodice',6);
    //Changed_channel('textDescription', 6);
    Changed_channel('textGruppo', 0);
    Changed_channel('Text11', 0);
    
    if ($('#utilizzatore_list').find('option:selected').val() > 0) {
        Changed_channel('Text9', 6);
        Changed_channel('Text10', 6);
        Changed_channel('Text12', 0);
    }
    if ((alarm_first) || (alarm_first1) || (alarm_terzo) || (alarm_terzo1) || (alarm_terzo2) || (alarm_quarto) || (alarm_quinto)) {
        $('#save_impianto_new').after('<p class="error help-block"><span class="label label-important">' + wrong_settings + '</span></p>');
        error_general = false;
        return false;
    }
    else {
        // $("#form_add_impianto").submit();
        error_general = true;
        notification['confirm'] = confirm_add;
        notification['annulla'] = annulla_impianto;
        return true;
    }
});

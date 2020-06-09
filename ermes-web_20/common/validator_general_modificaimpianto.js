var alarm_primo = false;
var alarm_primo1 = false;
var alarm_secondo = false;
var alarm_terzo = false;

var error_general = false;

function reset_form_gruppo() {
    $('#textGruppo').val('');
}

$("#gruppi").change(function () {

    var indice = $('#gruppi').find('option:selected').val();

    reset_form_gruppo();

    if (indice != "nuovo") {

        $('#textGruppo').val($('#gruppi').find('option:selected').text());

        crea_sottogruppo($('#gruppi').find('option:selected').val());
    }

});
$("#sottogruppi").change(function () {
        $('#Text11').val($('#sottogruppi').find('option:selected').val());
});

function crea_sottogruppo(items_sottogruppo) {
    $('#sottogruppi option').remove();
    
    

     if (items_sottogruppo != "null") {
        var lines = items_sottogruppo.split('>');
        var indice = 0;
        for (indice = 1; indice < lines.length; indice++) {
            if (indice == 1) {
                $('#Text11').val(lines[indice]);
            }
            $('#sottogruppi').append(new Option(lines[indice], lines[indice]));
        }
    }
}

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
            $(id).after('<p class="error help-block"><span class="label label-important">*6 ' + numeric_digit + '</span></p>');
        }
    }
    switch (id1) {
        case "inputCodice":
            alarm_primo = alarm;
            //check_first();
            break;
        case "textDescription":
            alarm_primo1 = alarm;
            //check_first();
            break;
        case "textGruppo":

            alarm_secondo = alarm;
            //check_quarto();
            break;
        case "Text11":
            alarm_terzo = alarm;
            
            break;
    }

}

$("#inputCodice").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    alarm_primo = false;
    //check_first();
    // $("#principale").load("test.aspx");
});
$("#textDescription").click(function () {
    //$(this).val("");
    $(this).next('p').remove();
    alarm_primo1 = false;
    //check_first();
    // $("#principale").load("test.aspx");
});
$("#textGruppo").click(function () {
    //$(this).val("");

    $(this).next('p').remove();
    alarm_secondo = false;
    //check_quarto();
    // $("#principale").load("test.aspx");
});
$("#Text11").click(function () {
    //$(this).val("");

    $(this).next('p').remove();
    alarm_terzo = false;
    //check_quinto();
    // $("#principale").load("test.aspx");
});



$("#main_table").on('click', '.btn', function () {
     $(this).closest('tr').remove();
    //alert($(this).closest('tr').attr('id'));
    for (i=0;i<array_inclusi.length;i++)
    {
        var current_index = $(this).closest('tr').attr('id');
        if (array_inclusi[i].indexOf(current_index) >= 0) {
            $("#utilizzatore_list").append('<option value="' + array_inclusi[i] + '">' + getUserTable(array_inclusi[i]) + '</option>');
            array_esclusi.push(array_inclusi[i]);
            array_inclusi.splice(i, 1);
            
            i = array_inclusi.length + 1;
            
        }
    }
   // alert("remove");
});

//$(".radio").click(function () {
$("#main_table").on('click', '.radio', function () {
    //alert($(this).attr('name'));
    
    setPropertyUser($(this).attr('name'),$(this).val());
});
$("#aggiungiUtente").click(function () {
    var checkedRadioSetpoimt = "";
    var checkedRadio = "";

    for (i = 0; i < array_esclusi.length; i++) {
        var current_index = $("#utilizzatore_list option:selected").val();
        if (array_esclusi[i].indexOf(current_index) >= 0) {
            var codiceHtml = ' <tr id ="' + getIdTable(array_esclusi[i]) + '" style = "border-bottom: 1px solid #e6e6e6;" >';
            codiceHtml = codiceHtml + '<td><div class=""widget-body uniformjs"">';
            codiceHtml = codiceHtml + '<div style= "float:left;width:25%;">' + getUserTable(array_esclusi[i]) + '</div>';
            if (getUserEnable(array_esclusi[i]) == "True") {
                checkedRadioSetpoimt = "checked";
                checkedRadio = "";
            }
            else {
                checkedRadioSetpoimt = "";
                checkedRadio = "checked";

            }
            
            codiceHtml = codiceHtml + '<div style= "float:left;width:25%;text-align:center;"> <input type="radio" ' + checkedRadioSetpoimt + ' class="radio" name="' + getIdTable(array_esclusi[i]) + '" value="1" /></div>';
            codiceHtml = codiceHtml + '<div style= "float:left;width:25%;text-align:center;"> <input type="radio" ' + checkedRadio +  ' class="radio" name="' + getIdTable(array_esclusi[i]) + '" value="0" /></div>';;
            codiceHtml = codiceHtml + '<div style= "float:left;width:25%;text-align:center;">';
            codiceHtml = codiceHtml + '<span Class="btn btn-block btn-danger btn-icon glyphicons remove" style="min-width:100px;"><i></i>' + traduzione_elimina + '</span>';
            codiceHtml = codiceHtml + '</div>';
            codiceHtml = codiceHtml + '</div></td></tr>';
            $('#main_table tr:last').after(codiceHtml);
            array_inclusi.push(array_esclusi[i]);
            $("#utilizzatore_list option[value='" + array_esclusi[i] + "']").remove();
            array_esclusi.splice(i, 1);
            i = array_esclusi.length + 1;

        }
    }

    return false;
});
function setPropertyUser(current_index, status) {
    var newValue = "";
    
    
    for (i = 0; i < array_inclusi.length; i++) {
        
        if (array_inclusi[i].indexOf(current_index) >= 0) {
            
            var resultSplit = array_inclusi[i].split(",");
            if (status == "1")
                newValue = resultSplit[0] + "," + resultSplit[1] + "," + resultSplit[2] + "," + resultSplit[3]+"," +"True";
            else
                newValue = resultSplit[0] + "," + resultSplit[1] + "," + resultSplit[2] + "," + resultSplit[3]+"," +"False";
            
            array_inclusi[i] = newValue;
            
            return;
        }
    }
}
function getUserTable(optionValue)
{
    var resultSplit = optionValue.split(",");

    return resultSplit[1];
}
function getUserEnable(optionValue) {
    var resultSplit = optionValue.split(",");

    return resultSplit[4];
}

function getIdTable(optionValue) {
    var resultSplit = optionValue.split(",");

    return resultSplit[0];
}

function updateList() {

    var parametro1 = '';

    for (i = 0; i < array_inclusi.length; i++) {
        parametro1 = parametro1 + array_inclusi[i] + '^';
    }

      $.ajax({
    type: "POST",
    url: "modifica_impianto_form.aspx/updateList",
    //data: {check1: $("#rms_all").is(':checked') ,check1_1: $("#rms_medio").is(':checked'),  check1_2:  $("#rms_max").is(':checked') ,check2 : $("#picco_all").is(':checked') , check2_1 : $("#picco_medio").is(':checked') , check2_2 : $("#picco_max").is(':checked') , check3: $("#vm_rms_all").is(':checked') , check3_1: $("#vm_rms_medio").is(':checked') , check3_2 : $("#vm_rms_max").is(':checked') , check4 : $("#vm_picco_all").is(':checked') , check4_1 : $("#vm_picco_medio").is(':checked') , check4_2: $("#vm_picco_max").is(':checked')   },
    //data: { check1: false, check1_1: true, check1_2: false, check2: false, check2_1: true, check2_2: false, check3: false, check3_1:true, check3_2:false, check4: false, check4_1:true, check4_2:false },
    data: "{'parametro':'" + JSON.stringify(parametro1)  + "'}",
    contentType: "application/json; charset=utf-8",
    dataType: "json",
    //timeout: 6000, //3 second timeout
    success: function (response) {


        $.each(response.d, function (k, v) {


        });
        
    },
    failure: function (response) {
        
    }

});
}
$("#save_modifica_impianto_new").click(function () {
    
    $('#save_modifica_impianto_new').next('p').remove();
    Changed_channel('inputCodice', 6);
    //Changed_channel('textDescription', 6);
    Changed_channel('textGruppo', 0);
    Changed_channel('Text11', 0);
    if ((alarm_primo) || (alarm_primo1) || (alarm_secondo) || (alarm_terzo)) {
        $('#save_modifica_impianto_new').after('<p class="error help-block"><span class="label label-important">' + wrong_settings + '</span></p>');
        error_general = false;
        return false;
    }
    else {
        // $("#form_add_impianto").submit();
        error_general = true;
        notification['confirm'] = modify_plant;
        notification['annulla'] = annulla_impianto;

        updateList();
      //  $('#utilizzatore_list_temp option').remove();
       
        return true;
    }
});

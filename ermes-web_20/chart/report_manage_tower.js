var primo = 0;
var from_difference = 0;
var to_difference = 0;

function manage_div() {
    if ($("#log_collapse").is(":visible")) {
        $("#log_collapse").hide();
    }
    else {
        $("#log_collapse").show();
    }
}
$("#head_log").click(function () {

    manage_div();

    return false;
});
$("#refresh_report").click(function () {
   
    if ((from_difference <= 0) && (to_difference >= 0)) {
        $("#log_collapse").hide();

        manage_report();
    }
    else {
        if (primo > 15) {
            result_setpoint_change(intervallo_log);
        }
        else {
            init_date = $('#graph_log_from').val();
            last_date = $('#graph_log_to').val();
            $("#refresh_log_server").trigger("click");
        }
    }
    modifica_coockie();
    return false;
});

function modifica_coockie() {
    var stringa = "";
    if ($('#ch1_val').is(':checked')) {
        stringa = stringa + "True";
    }
    else {
        stringa = stringa + "False";
    }
    stringa = stringa + "z";

    if (($('#ch1_high').is(':checked'))) {
        stringa = stringa + "True";
    }
    else {
        stringa = stringa + "False";
    }
    stringa = stringa + "z";
    if (($('#ch1_low').is(':checked'))) {
        stringa = stringa + "True";
    }
    else {
        stringa = stringa + "False";

    }
    stringa = stringa + "z";
    if (($('#ch1_bleed').is(':checked'))) {
        stringa = stringa + "True";
    }
    else {
        stringa = stringa + "False";

    }
    stringa = stringa + "z";
    if (($('#ch1_livello_inhibitor').is(':checked'))) {
        stringa = stringa + "True";
    }
    else {
        stringa = stringa + "False";

    }
    stringa = stringa + "z";
    if (($('#ch1_livello_prebiocide1').is(':checked'))) {
        stringa = stringa + "True";
    }
    else {
        stringa = stringa + "False";

    }
    stringa = stringa + "z";
    if (($('#ch1_livello_prebiocide2').is(':checked'))) {
        stringa = stringa + "True";
    }
    else {
        stringa = stringa + "False";

    }
    stringa = stringa + "z";
    if (($('#ch1_livello_biocide1').is(':checked'))) {
        stringa = stringa + "True";
    }
    else {
        stringa = stringa + "False";

    }
    stringa = stringa + "z";
    if (($('#ch1_livello_biocide2').is(':checked'))) {
        stringa = stringa + "True";
    }
    else {
        stringa = stringa + "False";

    }

    //end  canale ch1
    //canale ch2
    stringa = stringa + "z";
    if (($('#ch2_val').is(':checked'))) {
        stringa = stringa + "True";
    }
    else {
        stringa = stringa + "False";

    }
    //allarmi
    stringa = stringa + "z";
    if (($('#ch2_high').is(':checked'))) {
        stringa = stringa + "True";
    }
    else {
        stringa = stringa + "False";

    }
    stringa = stringa + "z";
    if (($('#ch2_low').is(':checked'))) {
        stringa = stringa + "True";
    }
    else {
        stringa = stringa + "False";

    }
    stringa = stringa + "z";
    if (($('#ch2_livello').is(':checked'))) {
        stringa = stringa + "True";
    }
    else {
        stringa = stringa + "False";

    }

    //end  canale ch2
    //canale ch3
    stringa = stringa + "z";
    if (($('#ch3_val').is(':checked'))) {
        stringa = stringa + "True";
    }
    else {
        stringa = stringa + "False";

    }

    //allarmi
    //allarmi
    stringa = stringa + "z";
    if (($('#ch3_high').is(':checked'))) {
        stringa = stringa + "True";
    }
    else {
        stringa = stringa + "False";

    }
    stringa = stringa + "z";
    if (($('#ch3_low').is(':checked'))) {
        stringa = stringa + "True";
    }
    else {
        stringa = stringa + "False";

    }
    stringa = stringa + "z";
    if (($('#ch3_livello').is(':checked'))) {
        stringa = stringa + "True";
    }
    else {
        stringa = stringa + "False";

    }
    //end  canale ch3
    //canale ch4

    //end  canale ch4
    //canale ch5
    stringa = stringa + "z";
    if (($('#temperature_select').is(':checked'))) {
        stringa = stringa + "True";
    }
    else {
        stringa = stringa + "False";

    }

    //end  canale ch5
    stringa = stringa + "z";
    if (($('#flow_select').is(':checked'))) {
        stringa = stringa + "True";
    }
    else {
        stringa = stringa + "False";

    }

    $.cookie(name_coockie, stringa);
}
$.datepicker.setDefaults({
    //dateFormat: 'dd/mm/yy',
    onSelect: function (dateText) {


        primo = daydiff(parseDate($('#graph_log_from').val(), 'dd/mm/yy'), parseDate($('#graph_log_to').val(), 'dd/mm/yy'));
        from_difference = daydiff(parseDate($('#graph_log_from').val(), 'dd/mm/yy'), parseDate(init_date, 'dd/mm/yy'));
        to_difference = daydiff(parseDate($('#graph_log_to').val(), 'dd/mm/yy'), parseDate(last_date, 'dd/mm/yy'));

        
        /*  var secondo = daydiff(parseDate(last_date, 'dd/mm/yy'), parseDate(dateText, 'dd/mm/yy'));

           if ((primo <= 0) && (secondo <= 0)) {
               
               this.onchange();
               this.onblur();
           }
           else {
               if (primo < 0) {
                   last_date = dateText;
                   var differenza = daydiff(parseDate(init_date, 'dd/mm/yy'), parseDate(last_date, 'dd/mm/yy'));
                   if (differenza > 15) {
                       result_setpoint_change("Max 15gg");
                   }
                   else {
                       $("#refresh_log_server").trigger("click");
                   }
               }
               if (secondo < 0) {
                   init_date = dateText;
                  
                   var differenza = daydiff(parseDate(init_date, 'dd/mm/yy'), parseDate(last_date, 'dd/mm/yy'));
                   if (differenza > 15) {
                       result_setpoint_change("Max 15gg");
                   }
                   else {
                       $("#refresh_log_server").trigger("click");
                  }
               }
           }*/

    }
});
function salva_dati_log(callback) {
    myFunction_log = new Function(callback);
    myFunction_log();
}
function daydiff(first, second) {
    return (second - first) / (1000 * 60 * 60 * 24);
}
function parseDate(str, format) {
    //var mdy = str.split('/')
    var data = $.datepicker.parseDate(format, str);
    return data;
}
function get_action() {
    $("#form_log").attr("action", "chart/report_tower.aspx?init_date=" + init_date + "&last_date=" + last_date)
    return true;
}

function create_picker() {
    $('#graph_log_from').datepicker({
        dateFormat: 'dd/mm/yy'
    });
    $('#graph_log_to').datepicker({
        dateFormat: 'dd/mm/yy'
    });
    $('#graph_log_from').val(init_date);
    $('#graph_log_to').val(last_date);
}

$("#refresh_log_server").click(function () {
    salva_dati_log(0);
    // myFunction_log();

});
function manage_report() {
    var counter_series = 0;

    if (($('#ch1_val').is(':checked')) && (counter_series < 10)) {
        $('.ch1_val').show();
        counter_series = counter_series + 1;
    }
    else {
        $('.ch1_val').hide();
    }
    //------------------------------------------
    if (($('#ch1_high').is(':checked')) && (counter_series < 10)) {
        $('.ch1_high').show();
        counter_series = counter_series + 1;
    }
    else {
        $('.ch1_high').hide();
    }
    if (($('#ch1_low').is(':checked')) && (counter_series < 10)) {
        $('.ch1_low').show();
        counter_series = counter_series + 1;
    }
    else {
        $('.ch1_low').hide();
    }
    if (($('#ch1_bleed').is(':checked')) && (counter_series < 10)) {
        $('.ch1_bleed').show();
        counter_series = counter_series + 1;
    }
    else {
        $('.ch1_bleed').hide();
    }
    if (($('#ch1_livello_inhibitor').is(':checked')) && (counter_series < 10)) {
        $('.ch1_livello_inhibitor').show();
        counter_series = counter_series + 1;
    }
    else {
        $('.ch1_livello_inhibitor').hide();
    }
    if (($('#ch1_livello_prebiocide1').is(':checked')) && (counter_series < 10)) {
        $('.ch1_livello_prebiocide1').show();
        counter_series = counter_series + 1;
    }
    else {
        $('.ch1_livello_prebiocide1').hide();
    }
    if (($('#ch1_livello_prebiocide2').is(':checked')) && (counter_series < 10)) {
        $('.ch1_livello_prebiocide2').show();
        counter_series = counter_series + 1;
    }
    else {
        $('.ch1_livello_prebiocide2').hide();
    }
    if (($('#ch1_livello_biocide1').is(':checked')) && (counter_series < 10)) {
        $('.ch1_livello_biocide1').show();
        counter_series = counter_series + 1;
    }
    else {
        $('.ch1_livello_biocide1').hide();
    }
    if (($('#ch1_livello_biocide2').is(':checked')) && (counter_series < 10)) {
        $('.ch1_livello_biocide2').show();
        counter_series = counter_series + 1;
    }
    else {
        $('.ch1_livello_biocide2').hide();
    }

    //----------------------------------------------------------
    if (($('#ch2_val').is(':checked')) && (counter_series < 10)) {
        $('.ch2_val').show();
        counter_series = counter_series + 1;
    }
    else {
        $('.ch2_val').hide();
    }

    if (($('#ch2_high').is(':checked')) && (counter_series < 10)) {
        $('.ch2_high').show();
        counter_series = counter_series + 1;
    }
    else {
        $('.ch2_high').hide();
    }
    if (($('#ch2_low').is(':checked')) && (counter_series < 10)) {
        $('.ch2_low').show();
        counter_series = counter_series + 1;
    }
    else {
        $('.ch2_low').hide();
    }
    if (($('#ch2_livello').is(':checked')) && (counter_series < 10)) {
        $('.ch2_livello').show();
        counter_series = counter_series + 1;
    }
    else {
        $('.ch2_livello').hide();
    }

    //------------------------------------------
    if (($('#ch3_val').is(':checked')) && (counter_series < 10)) {
        $('.ch3_val').show();
        counter_series = counter_series + 1;
    }
    else {
        $('.ch3_val').hide();
    }

    if (($('#ch3_high').is(':checked')) && (counter_series < 10)) {
        $('.ch3_high').show();
        counter_series = counter_series + 1;
    }
    else {
        $('.ch3_high').hide();
    }
    if (($('#ch3_low').is(':checked')) && (counter_series < 10)) {
        $('.ch3_low').show();
        counter_series = counter_series + 1;
    }
    else {
        $('.ch3_low').hide();
    }
    if (($('#ch3_livello').is(':checked')) && (counter_series < 10)) {
        $('.ch3_livello').show();
        counter_series = counter_series + 1;
    }
    else {
        $('.ch3_livello').hide();
    }

    //----------------------------------------------------------
    //------------------------------------------
    if (($('#flow_select').is(':checked')) && (counter_series < 10)) {
        $('.flow_select').show();
        counter_series = counter_series + 1;
    }
    else {
        $('.flow_select').hide();
    }

    //----------------------------------------------------------
    //------------------------------------------
    if (($('#temperature_select').is(':checked')) && (counter_series < 10)) {
        $('.temperature_select').show();
        counter_series = counter_series + 1;
    }
    else {
        $('.temperature_select').hide();
    }

    //----------------------------------------------------------

}
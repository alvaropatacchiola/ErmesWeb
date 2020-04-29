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
    //-------------------------uscite digitali
    stringa = stringa + "z";
    if ($('#ch1_da').is(':checked')) {
        stringa = stringa + "True";
    }
    else {
        stringa = stringa + "False";
    }
    stringa = stringa + "z";
    if ($('#ch1_db').is(':checked')) {
        stringa = stringa + "True";
    }
    else {
        stringa = stringa + "False";
    }

    //-------------------------uscite proporzionali
    stringa = stringa + "z";
    if ($('#ch1_pa').is(':checked')) {
        stringa = stringa + "True";
    }
    else {
        stringa = stringa + "False";
    }
    stringa = stringa + "z";
    if ($('#ch1_pb').is(':checked')) {
        stringa = stringa + "True";
    }
    else {
        stringa = stringa + "False";
    }
    stringa = stringa + "z";
    if ($('#ch1_ma').is(':checked')) {
        stringa = stringa + "True";
    }
    else {
        stringa = stringa + "False";
    }

    //-------------------------uscite allarmi
    stringa = stringa + "z";
    if ($('#ch1_aa').is(':checked')) {
        stringa = stringa + "True";
    }
    else {
        stringa = stringa + "False";
    }
    stringa = stringa + "z";
    if ($('#ch1_ab').is(':checked')) {
        stringa = stringa + "True";
    }
    else {
        stringa = stringa + "False";
    }
    stringa = stringa + "z";
    if ($('#ch1_ad').is(':checked')) {
        stringa = stringa + "True";
    }
    else {
        stringa = stringa + "False";
    }
    stringa = stringa + "z";
    if ($('#ch1_ar').is(':checked')) {
        stringa = stringa + "True";
    }
    else {
        stringa = stringa + "False";
    }
    stringa = stringa + "z";
    //-----------------------------------------------------------------
    if ($('#ch2_val').is(':checked')) {
        stringa = stringa + "True";
    }
    else {
        stringa = stringa + "False";
    }
    //-------------------------uscite digitali
    stringa = stringa + "z";
    if ($('#ch2_da').is(':checked')) {
        stringa = stringa + "True";
    }
    else {
        stringa = stringa + "False";
    }
    stringa = stringa + "z";
    if ($('#ch2_db').is(':checked')) {
        stringa = stringa + "True";
    }
    else {
        stringa = stringa + "False";
    }

    //-------------------------uscite proporzionali
    stringa = stringa + "z";
    if ($('#ch2_pa').is(':checked')) {
        stringa = stringa + "True";
    }
    else {
        stringa = stringa + "False";
    }
    stringa = stringa + "z";
    if ($('#ch2_pb').is(':checked')) {
        stringa = stringa + "True";
    }
    else {
        stringa = stringa + "False";
    }
    stringa = stringa + "z";
    if ($('#ch2_ma').is(':checked')) {
        stringa = stringa + "True";
    }
    else {
        stringa = stringa + "False";
    }

    //-------------------------uscite allarmi
    stringa = stringa + "z";
    if ($('#ch2_aa').is(':checked')) {
        stringa = stringa + "True";
    }
    else {
        stringa = stringa + "False";
    }
    stringa = stringa + "z";
    if ($('#ch2_ab').is(':checked')) {
        stringa = stringa + "True";
    }
    else {
        stringa = stringa + "False";
    }
    stringa = stringa + "z";
    if ($('#ch2_ad').is(':checked')) {
        stringa = stringa + "True";
    }
    else {
        stringa = stringa + "False";
    }
    stringa = stringa + "z";
    if ($('#ch2_ar').is(':checked')) {
        stringa = stringa + "True";
    }
    else {
        stringa = stringa + "False";
    }
    stringa = stringa + "z";
    //---------------------------------------------------------
    if ($('#ch3_val').is(':checked')) {
        stringa = stringa + "True";
    }
    else {
        stringa = stringa + "False";
    }
    //-------------------------uscite digitali
    stringa = stringa + "z";
    if ($('#ch3_da').is(':checked')) {
        stringa = stringa + "True";
    }
    else {
        stringa = stringa + "False";
    }
    stringa = stringa + "z";
    if ($('#ch3_db').is(':checked')) {
        stringa = stringa + "True";
    }
    else {
        stringa = stringa + "False";
    }

    //-------------------------uscite proporzionali
    stringa = stringa + "z";
    if ($('#ch3_pa').is(':checked')) {
        stringa = stringa + "True";
    }
    else {
        stringa = stringa + "False";
    }
    stringa = stringa + "z";
    if ($('#ch3_pb').is(':checked')) {
        stringa = stringa + "True";
    }
    else {
        stringa = stringa + "False";
    }
    stringa = stringa + "z";
    if ($('#ch3_ma').is(':checked')) {
        stringa = stringa + "True";
    }
    else {
        stringa = stringa + "False";
    }

    //-------------------------uscite allarmi
    stringa = stringa + "z";
    if ($('#ch3_aa').is(':checked')) {
        stringa = stringa + "True";
    }
    else {
        stringa = stringa + "False";
    }
    stringa = stringa + "z";
    if ($('#ch3_ab').is(':checked')) {
        stringa = stringa + "True";
    }
    else {
        stringa = stringa + "False";
    }
    stringa = stringa + "z";
    if ($('#ch3_ad').is(':checked')) {
        stringa = stringa + "True";
    }
    else {
        stringa = stringa + "False";
    }
    stringa = stringa + "z";
    if ($('#ch3_ar').is(':checked')) {
        stringa = stringa + "True";
    }
    else {
        stringa = stringa + "False";
    }
    stringa = stringa + "z";
    //----------------------------------------------------------------------------
    if ($('#ch4_val').is(':checked')) {
        stringa = stringa + "True";
    }
    else {
        stringa = stringa + "False";
    }
    //-------------------------uscite digitali
    stringa = stringa + "z";
    if ($('#ch4_da').is(':checked')) {
        stringa = stringa + "True";
    }
    else {
        stringa = stringa + "False";
    }
    stringa = stringa + "z";
    if ($('#ch4_db').is(':checked')) {
        stringa = stringa + "True";
    }
    else {
        stringa = stringa + "False";
    }

    //-------------------------uscite proporzionali
    stringa = stringa + "z";
    if ($('#ch4_pa').is(':checked')) {
        stringa = stringa + "True";
    }
    else {
        stringa = stringa + "False";
    }
    stringa = stringa + "z";
    if ($('#ch4_pb').is(':checked')) {
        stringa = stringa + "True";
    }
    else {
        stringa = stringa + "False";
    }
    stringa = stringa + "z";
    if ($('#ch4_ma').is(':checked')) {
        stringa = stringa + "True";
    }
    else {
        stringa = stringa + "False";
    }

    //-------------------------uscite allarmi
    stringa = stringa + "z";
    if ($('#ch4_aa').is(':checked')) {
        stringa = stringa + "True";
    }
    else {
        stringa = stringa + "False";
    }
    stringa = stringa + "z";
    if ($('#ch4_ab').is(':checked')) {
        stringa = stringa + "True";
    }
    else {
        stringa = stringa + "False";
    }
    stringa = stringa + "z";
    if ($('#ch4_ad').is(':checked')) {
        stringa = stringa + "True";
    }
    else {
        stringa = stringa + "False";
    }
    stringa = stringa + "z";
    if ($('#ch4_ar').is(':checked')) {
        stringa = stringa + "True";
    }
    else {
        stringa = stringa + "False";
    }
    stringa = stringa + "z";

    //--------------------------------------------------------------
    if ($('#ch5_val').is(':checked')) {
        stringa = stringa + "True";
    }
    else {
        stringa = stringa + "False";
    }
    //-------------------------uscite digitali
    stringa = stringa + "z";
    if ($('#ch5_da').is(':checked')) {
        stringa = stringa + "True";
    }
    else {
        stringa = stringa + "False";
    }
    stringa = stringa + "z";
    if ($('#ch5_db').is(':checked')) {
        stringa = stringa + "True";
    }
    else {
        stringa = stringa + "False";
    }

    //-------------------------uscite proporzionali
    stringa = stringa + "z";
    if ($('#ch5_pa').is(':checked')) {
        stringa = stringa + "True";
    }
    else {
        stringa = stringa + "False";
    }
    stringa = stringa + "z";
    if ($('#ch5_pb').is(':checked')) {
        stringa = stringa + "True";
    }
    else {
        stringa = stringa + "False";
    }
    stringa = stringa + "z";
    if ($('#ch5_ma').is(':checked')) {
        stringa = stringa + "True";
    }
    else {
        stringa = stringa + "False";
    }

    //-------------------------uscite allarmi
    stringa = stringa + "z";
    if ($('#ch5_aa').is(':checked')) {
        stringa = stringa + "True";
    }
    else {
        stringa = stringa + "False";
    }
    stringa = stringa + "z";
    if ($('#ch5_ab').is(':checked')) {
        stringa = stringa + "True";
    }
    else {
        stringa = stringa + "False";
    }
    stringa = stringa + "z";
    if ($('#ch5_ad').is(':checked')) {
        stringa = stringa + "True";
    }
    else {
        stringa = stringa + "False";
    }
    stringa = stringa + "z";
    if ($('#ch5_ar').is(':checked')) {
        stringa = stringa + "True";
    }
    else {
        stringa = stringa + "False";
    }
    stringa = stringa + "z";
    //------------------------------------------------------------------

    //TEMPERATURA
    if (($('#temperature_select').is(':checked'))) {

        stringa = stringa + "True";
    }
    else {
        stringa = stringa + "False";

    }
    stringa = stringa + "z";
    if (($('#flow_meter_low').is(':checked'))) {

        stringa = stringa + "True";
    }
    else {

        stringa = stringa + "False";

    }
    stringa = stringa + "z";
    if (($('#flow_meter').is(':checked'))) {

        stringa = stringa + "True";
    }
    else {
        stringa = stringa + "False";

    }
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
    $("#form_log").attr("action", "chart/report_max5.aspx?init_date=" + init_date + "&last_date=" + last_date)
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
    //uscite digitali
    if (($('#ch1_da').is(':checked')) && (counter_series < 10)) {
        $('.ch1_da').show();
        counter_series = counter_series + 1;
    }
    else {
        $('.ch1_da').hide();
    }
    if (($('#ch1_db').is(':checked')) && (counter_series < 10)) {
        $('.ch1_db').show();
        counter_series = counter_series + 1;
    }
    else {
        $('.ch1_db').hide();
    }
    //uscite proporzionali
    if (($('#ch1_pa').is(':checked')) && (counter_series < 10)) {
        $('.ch1_pa').show();
        counter_series = counter_series + 1;
    }
    else {
        $('.ch1_pa').hide();
    }
    if (($('#ch1_pb').is(':checked')) && (counter_series < 10)) {
        $('.ch1_pb').show();
        counter_series = counter_series + 1;
    }
    else {
        $('.ch1_pb').hide();
    }
    if (($('#ch1_ma').is(':checked')) && (counter_series < 10)) {
        $('.ch1_ma').show();
        counter_series = counter_series + 1;
    }
    else {
        $('.ch1_ma').hide();
    }

    //allarmi------------------------------------------
    if (($('#ch1_aa').is(':checked')) && (counter_series < 10)) {
        $('.ch1_aa').show();
        counter_series = counter_series + 1;
    }
    else {
        $('.ch1_aa').hide();
    }
    if (($('#ch1_ab').is(':checked')) && (counter_series < 10)) {
        $('.ch1_ab').show();
        counter_series = counter_series + 1;
    }
    else {
        $('.ch1_ab').hide();
    }
    if (($('#ch1_ad').is(':checked')) && (counter_series < 10)) {
        $('.ch1_ad').show();
        counter_series = counter_series + 1;
    }
    else {
        $('.ch1_ad').hide();
    }
    if (($('#ch1_ar').is(':checked')) && (counter_series < 10)) {
        $('.ch1_ar').show();
        counter_series = counter_series + 1;
    }
    else {
        $('.ch1_ar').hide();
    }

    //----------------------------------------------------------
    if (($('#ch2_val').is(':checked')) && (counter_series < 10)) {
        $('.ch2_val').show();
        counter_series = counter_series + 1;
    }
    else {
        $('.ch2_val').hide();
    }
    //uscite digitali
    if (($('#ch2_da').is(':checked')) && (counter_series < 10)) {
        $('.ch2_da').show();
        counter_series = counter_series + 1;
    }
    else {
        $('.ch2_da').hide();
    }
    if (($('#ch2_db').is(':checked')) && (counter_series < 10)) {
        $('.ch2_db').show();
        counter_series = counter_series + 1;
    }
    else {
        $('.ch2_db').hide();
    }
    //uscite proporzionali
    if (($('#ch2_pa').is(':checked')) && (counter_series < 10)) {
        $('.ch2_pa').show();
        counter_series = counter_series + 1;
    }
    else {
        $('.ch2_pa').hide();
    }
    if (($('#ch2_pb').is(':checked')) && (counter_series < 10)) {
        $('.ch2_pb').show();
        counter_series = counter_series + 1;
    }
    else {
        $('.ch2_pb').hide();
    }
    if (($('#ch2_ma').is(':checked')) && (counter_series < 10)) {
        $('.ch2_ma').show();
        counter_series = counter_series + 1;
    }
    else {
        $('.ch2_ma').hide();
    }
    //------------------------------------------
    if (($('#ch2_aa').is(':checked')) && (counter_series < 10)) {
        $('.ch2_aa').show();
        counter_series = counter_series + 1;
    }
    else {
        $('.ch2_aa').hide();
    }
    if (($('#ch2_ab').is(':checked')) && (counter_series < 10)) {
        $('.ch2_ab').show();
        counter_series = counter_series + 1;
    }
    else {
        $('.ch2_ab').hide();
    }
    if (($('#ch2_ad').is(':checked')) && (counter_series < 10)) {
        $('.ch2_ad').show();
        counter_series = counter_series + 1;
    }
    else {
        $('.ch2_ad').hide();
    }
    if (($('#ch2_ar').is(':checked')) && (counter_series < 10)) {
        $('.ch2_ar').show();
        counter_series = counter_series + 1;
    }
    else {
        $('.ch2_ar').hide();
    }
    //------------------------------------------
    if (($('#ch3_val').is(':checked')) && (counter_series < 10)) {
        $('.ch3_val').show();
        counter_series = counter_series + 1;
    }
    else {
        $('.ch3_val').hide();
    }
    //uscite digitali
    if (($('#ch3_da').is(':checked')) && (counter_series < 10)) {
        $('.ch3_da').show();
        counter_series = counter_series + 1;
    }
    else {
        $('.ch3_da').hide();
    }
    if (($('#ch3_db').is(':checked')) && (counter_series < 10)) {
        $('.ch3_db').show();
        counter_series = counter_series + 1;
    }
    else {
        $('.ch3_db').hide();
    }
    //uscite proporzionali
    if (($('#ch3_pa').is(':checked')) && (counter_series < 10)) {
        $('.ch3_pa').show();
        counter_series = counter_series + 1;
    }
    else {
        $('.ch3_pa').hide();
    }
    if (($('#ch3_pb').is(':checked')) && (counter_series < 10)) {
        $('.ch3_pb').show();
        counter_series = counter_series + 1;
    }
    else {
        $('.ch3_pb').hide();
    }
    if (($('#ch3_ma').is(':checked')) && (counter_series < 10)) {
        $('.ch3_ma').show();
        counter_series = counter_series + 1;
    }
    else {
        $('.ch3_ma').hide();
    }
    //------------------------------------------
    if (($('#ch3_aa').is(':checked')) && (counter_series < 10)) {
        $('.ch3_aa').show();
        counter_series = counter_series + 1;
    }
    else {
        $('.ch3_aa').hide();
    }
    if (($('#ch3_ab').is(':checked')) && (counter_series < 10)) {
        $('.ch3_ab').show();
        counter_series = counter_series + 1;
    }
    else {
        $('.ch3_ab').hide();
    }
    if (($('#ch3_ad').is(':checked')) && (counter_series < 10)) {
        $('.ch3_ad').show();
        counter_series = counter_series + 1;
    }
    else {
        $('.ch3_ad').hide();
    }
    if (($('#ch3_ar').is(':checked')) && (counter_series < 10)) {
        $('.ch3_ar').show();
        counter_series = counter_series + 1;
    }
    else {
        $('.ch3_ar').hide();
    }

    //----------------------------------------------------------
    if (($('#ch4_val').is(':checked')) && (counter_series < 10)) {
        $('.ch4_val').show();
        counter_series = counter_series + 1;
    }
    else {
        $('.ch4_val').hide();
    }
    //uscite digitali
    if (($('#ch4_da').is(':checked')) && (counter_series < 10)) {
        $('.ch4_da').show();
        counter_series = counter_series + 1;
    }
    else {
        $('.ch4_da').hide();
    }
    if (($('#ch4_db').is(':checked')) && (counter_series < 10)) {
        $('.ch4_db').show();
        counter_series = counter_series + 1;
    }
    else {
        $('.ch4_db').hide();
    }
    //uscite proporzionali
    if (($('#ch4_pa').is(':checked')) && (counter_series < 10)) {
        $('.ch4_pa').show();
        counter_series = counter_series + 1;
    }
    else {
        $('.ch4_pa').hide();
    }
    if (($('#ch4_pb').is(':checked')) && (counter_series < 10)) {
        $('.ch4_pb').show();
        counter_series = counter_series + 1;
    }
    else {
        $('.ch4_pb').hide();
    }
    if (($('#ch4_ma').is(':checked')) && (counter_series < 10)) {
        $('.ch4_ma').show();
        counter_series = counter_series + 1;
    }
    else {
        $('.ch4_ma').hide();
    }
    //------------------------------------------
    if (($('#ch4_aa').is(':checked')) && (counter_series < 10)) {
        $('.ch4_aa').show();
        counter_series = counter_series + 1;
    }
    else {
        $('.ch4_aa').hide();
    }
    if (($('#ch4_ab').is(':checked')) && (counter_series < 10)) {
        $('.ch4_ab').show();
        counter_series = counter_series + 1;
    }
    else {
        $('.ch4_ab').hide();
    }
    if (($('#ch4_ad').is(':checked')) && (counter_series < 10)) {
        $('.ch4_ad').show();
        counter_series = counter_series + 1;
    }
    else {
        $('.ch4_ad').hide();
    }
    if (($('#ch4_ar').is(':checked')) && (counter_series < 10)) {
        $('.ch4_ar').show();
        counter_series = counter_series + 1;
    }
    else {
        $('.ch4_ar').hide();
    }

    //----------------------------------------------------------
    if (($('#ch5_val').is(':checked')) && (counter_series < 10)) {
        $('.ch5_val').show();
        counter_series = counter_series + 1;
    }
    else {
        $('.ch5_val').hide();
    }
    //uscite digitali
    if (($('#ch5_da').is(':checked')) && (counter_series < 10)) {
        $('.ch5_da').show();
        counter_series = counter_series + 1;
    }
    else {
        $('.ch5_da').hide();
    }
    if (($('#ch5_db').is(':checked')) && (counter_series < 10)) {
        $('.ch5_db').show();
        counter_series = counter_series + 1;
    }
    else {
        $('.ch5_db').hide();
    }
    //uscite proporzionali
    if (($('#ch5_pa').is(':checked')) && (counter_series < 10)) {
        $('.ch5_pa').show();
        counter_series = counter_series + 1;
    }
    else {
        $('.ch5_pa').hide();
    }
    if (($('#ch5_pb').is(':checked')) && (counter_series < 10)) {
        $('.ch5_pb').show();
        counter_series = counter_series + 1;
    }
    else {
        $('.ch5_pb').hide();
    }
    if (($('#ch5_ma').is(':checked')) && (counter_series < 10)) {
        $('.ch5_ma').show();
        counter_series = counter_series + 1;
    }
    else {
        $('.ch5_ma').hide();
    }
    //------------------------------------------
    if (($('#ch5_aa').is(':checked')) && (counter_series < 10)) {
        $('.ch5_aa').show();
        counter_series = counter_series + 1;
    }
    else {
        $('.ch5_aa').hide();
    }
    if (($('#ch5_ab').is(':checked')) && (counter_series < 10)) {
        $('.ch5_ab').show();
        counter_series = counter_series + 1;
    }
    else {
        $('.ch5_ab').hide();
    }
    if (($('#ch5_ad').is(':checked')) && (counter_series < 10)) {
        $('.ch5_ad').show();
        counter_series = counter_series + 1;
    }
    else {
        $('.ch5_ad').hide();
    }
    if (($('#ch5_ar').is(':checked')) && (counter_series < 10)) {
        $('.ch5_ar').show();
        counter_series = counter_series + 1;
    }
    else {
        $('.ch5_ar').hide();
    }
    //----------------------------------------------------------
    //----------------------------------------------------------
    if (($('#flow_select').is(':checked')) && (counter_series < 10)) {
        $('.flow_select').show();
        counter_series = counter_series + 1;
    }
    else {
        $('.flow_select').hide();
    }

    //----------------------------------------------------------
    //----------------------------------------------------------
    if (($('#temperature_select').is(':checked')) && (counter_series < 10)) {
        $('.temperature_select').show();
        counter_series = counter_series + 1;
    }
    else {
        $('.temperature_select').hide();
    }

    //----------------------------------------------------------
    //----------------------------------------------------------
    if (($('#flow_meter_low').is(':checked')) && (counter_series < 10)) {
        $('.flow_meter_low').show();
        counter_series = counter_series + 1;
    }
    else {
        $('.flow_meter_low').hide();
    }

    //----------------------------------------------------------

    //----------------------------------------------------------
    if (($('#flow_meter').is(':checked')) && (counter_series < 10)) {
        $('.flow_meter').show();
        counter_series = counter_series + 1;
    }
    else {
        $('.flow_meter').hide();
    }

    //----------------------------------------------------------

}
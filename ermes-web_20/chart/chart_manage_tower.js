var primo = 0;
var from_difference = 0;
var to_difference = 0;
var array_ch1 = [];
var array_ch2=[];
var array_ch3=[];

var array_ch1_high=[];
var array_ch1_low=[];

var array_ch1_bleed=[];

var array_ch1_inhibitor=[];

var array_ch1_prebiocide1=[];
var array_ch1_prebiocide2=[];

var array_ch1_biocide1=[];
var array_ch1_biocide2=[];
var array_ch2_high=[];


var array_ch2_low=[];
var array_ch2_livello=[];

var array_ch3_high=[];


var array_ch3_low=[];
var array_ch3_livello=[];

var array_flow=[];
var array_temperatura=[];
var array_wmi=[];
var array_wmb = [];

var array_power_on = [];

function get_data(parametro1, parametro2, parametro3, parametro4, parametro5) {

    $.ajax({
        type: "POST",
        url: "chart/log_metod.aspx/get_log_tower",
        //data: {check1: $("#rms_all").is(':checked') ,check1_1: $("#rms_medio").is(':checked'),  check1_2:  $("#rms_max").is(':checked') ,check2 : $("#picco_all").is(':checked') , check2_1 : $("#picco_medio").is(':checked') , check2_2 : $("#picco_max").is(':checked') , check3: $("#vm_rms_all").is(':checked') , check3_1: $("#vm_rms_medio").is(':checked') , check3_2 : $("#vm_rms_max").is(':checked') , check4 : $("#vm_picco_all").is(':checked') , check4_1 : $("#vm_picco_medio").is(':checked') , check4_2: $("#vm_picco_max").is(':checked')   },
        //data: { check1: false, check1_1: true, check1_2: false, check2: false, check2_1: true, check2_2: false, check3: false, check3_1:true, check3_2:false, check4: false, check4_1:true, check4_2:false },
        data: "{'parametro':'" + JSON.stringify(parametro1) + "," + JSON.stringify(parametro2) + "," + JSON.stringify(parametro3) + "," + JSON.stringify(parametro4) + "," + JSON.stringify(parametro5) + "'}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        //timeout: 6000, //3 second timeout
        success: function (response) {


            $.each(response.d, function (k, v) {
                var res = v.split(",")
                var data;
                var data_year;
                var intero1 = 0;
                var intero2 = 0;
                var intero3 = 0;
                var intero4 = 0;
                var intero5 = 0;
                var indice = 0;

                data = Date.UTC(parseInt(res[0]), parseInt(res[1]), parseInt(res[2]), parseInt(res[3]), parseInt(res[4]));
                array_ch1.push([data, parseFloat(res[5])]);
                array_ch2.push([data, parseFloat(res[6])]);
                array_ch3.push([data, parseFloat(res[7])]);

                array_ch1_high.push([data, parseInt(res[8])]);
                array_ch1_low.push([data, parseInt(res[9])]);
                array_ch1_bleed.push([data, parseInt(res[10])]);
                array_ch1_inhibitor.push([data, parseInt(res[11])]);
                array_ch1_prebiocide1.push([data, parseInt(res[12])]);
                array_ch1_prebiocide2.push([data, parseInt(res[13])]);
                array_ch1_biocide1.push([data, parseInt(res[14])]);
                array_ch1_biocide2.push([data, parseInt(res[15])]);
                array_ch2_high.push([data, parseInt(res[16])]);
                array_ch2_low.push([data, parseInt(res[17])]);
                array_ch2_livello.push([data, parseInt(res[18])]);
                array_ch3_high.push([data, parseInt(res[19])]);
                array_ch3_low.push([data, parseInt(res[20])]);
                array_ch3_livello.push([data, parseInt(res[21])]);
                array_flow.push([data, parseInt(res[22])]);
                array_temperatura.push([data, parseFloat(res[23])]);
                array_wmi.push([data, parseFloat(res[24])]);
                array_wmb.push([data, parseFloat(res[25])]);

                array_power_on.push([data, parseInt(res[26])]);



            });
            upgrate_chart();
        },
        failure: function (response) {
            alert(response.d);
        }

    });

}

function create_chart(dati, yAxis) {
    //alert("entro_chart");

    $('#chart_div').highcharts('StockChart', {

        
        rangeSelector: {
            enabled: false
        },

        title: {
            text: graph_log
        },
        yAxis: yAxis,

        plotOptions: {
            scatter: {
                marker: {
                    radius: 1.2
                }
            }
        },

        series: dati
    }/*,
     function (chart) {

         // apply the date pickers
         setTimeout(function () {
             $('input.highcharts-range-selector', $(chart.container).parent())
                 .datepicker({ dateFormat: 'dd/mm/yy' });
         }, 0)
     }*/);
    // Create the chart
    
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
    // Create the chart

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
function salva_dati_log(callback) {
    myFunction_log = new Function(callback);
    myFunction_log();
}

function parseDate(str, format) {
    //var mdy = str.split('/')
    var data = $.datepicker.parseDate(format, str);
    return data;
}
function get_action() {
    $("#form_log").attr("action", "chart/log_tower.aspx?init_date=" + init_date + "&last_date=" + last_date)
    return true;
}


function daydiff(first, second) {
    return (second - first) / (1000 * 60 * 60 * 24);
}

$("#refresh_graph").click(function () {
    //alert("entro");
   
    if ((from_difference <= 0) && (to_difference >= 0)) {
        $("#log_collapse").hide();
        $('#chart_div').highcharts().destroy();
        init_date = $('#graph_log_from').val();
        last_date = $('#graph_log_to').val();
        var data1 = parseDate(init_date, 'dd/mm/yy');
        var data2 = parseDate(last_date, 'dd/mm/yy');

        upgrate_chart();
        if ((from_difference < 0) || (to_difference > 0)) {
            var chart_temp = $('#chart_div').highcharts();
            try{
            chart_temp.xAxis[0].setExtremes(
                 Date.UTC(data1.getFullYear(), data1.getMonth(), data1.getDate()),
                  Date.UTC(data2.getFullYear(), data2.getMonth(), data2.getDate())
                );
            }
            catch (ex) {
                init_date = $('#graph_log_from').val();
                last_date = $('#graph_log_to').val();
                $("#refresh_log_server").trigger("click");
            }
        }
    }
    else {
        if (primo > 30) {
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
    if (($('#ch1_low').is(':checked')) ) {
        stringa = stringa + "True";
    }
    else {
        stringa = stringa + "False";

    }
    stringa = stringa + "z";
    if (($('#ch1_bleed').is(':checked')) ) {
        stringa = stringa + "True";
    }
    else {
        stringa = stringa + "False";

    }
    stringa = stringa + "z";
    if (($('#ch1_livello_inhibitor').is(':checked')) ) {
        stringa = stringa + "True";
    }
    else {
        stringa = stringa + "False";

    }
    stringa = stringa + "z";
    if (($('#ch1_livello_prebiocide1').is(':checked')) ) {
        stringa = stringa + "True";
    }
    else {
        stringa = stringa + "False";

    }
    stringa = stringa + "z";
    if (($('#ch1_livello_prebiocide2').is(':checked')) ) {
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
    if (($('#ch2_high').is(':checked')) ) {
        stringa = stringa + "True";
    }
    else {
        stringa = stringa + "False";

    }
    stringa = stringa + "z";
    if (($('#ch2_low').is(':checked')) ) {
        stringa = stringa + "True";
    }
    else {
        stringa = stringa + "False";

    }
    stringa = stringa + "z";
    if (($('#ch2_livello').is(':checked')) ) {
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
    if (($('#temperature_select').is(':checked')) ) {
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
    stringa = stringa + "z";
    if (($('#wmi').is(':checked'))) {
        stringa = stringa + "True";
    }
    else {
        stringa = stringa + "False";

    }
    stringa = stringa + "z";
    if (($('#wmb').is(':checked'))) {
        stringa = stringa + "True";
    }
    else {
        stringa = stringa + "False";

    }

    $.cookie(name_coockie, stringa, { expires: 365 });
}
function upgrate_chart() {
    var altezza = 0;
    var numero_asse = 0;
    var counter_series = 0;
    var series_chart = [];
    var yaxis_chart = [];
    //canale ch1

    if (($('#ch1_val').is(':checked')) && (counter_series < 10)) {

        series_chart.push({
            name: label_ch1,
            id: 'ch1_val_series',
            data: array_ch1,
            yAxis: numero_asse,
            marker: {
                enabled: true,
                radius: 3
            }/*,
            tooltip: {
                valueDecimals: 2
            }*/
        });
        yaxis_chart.push({
            title: {
                text: label_ch1
            },
            opposite: false,
            id: 'ch1_val',
            height: 200,
            lineWidth: 2
        });
        altezza = altezza + 300;
        numero_asse = numero_asse + 1;
        counter_series = counter_series + 1;
    }
    
    if (($('#ch1_high').is(':checked')) && (counter_series < 10)) {
        series_chart.push({
            name: ch1_high_label,
            id: 'ch2_val_series',
            data: array_ch1_high,
            step: true,
            type: 'scatter',

            tooltip: {
                pointFormat: function () {
                    return false;
                },
                valueDecimals: 0
            },
            lineWidth: 2,

            yAxis: numero_asse
        },
        {
            id: 'ch2_val_series',
            name: ch1_high_label,
            data: array_ch1_high,
            //type:'line',
            step: true,
            shadow: false,
            color: 'rgba(255,255,255,0.1)',
            tooltip: {
                //pointFormat: '<span style="#FFFFF">{series.name}:<b>{point.y}</b></span>',
                // formatter: '<span style="#FFFFF">{series.name}:<b>{point.y}</b></span>',
                pointFormat: '<span style="#FFFFF">{series.name}:<b>{point.y}</b></span><br/>',

                valueDecimals: 0
            },
            lineWidth: 2,
            shared: true,
            yAxis: numero_asse
        });
        yaxis_chart.push({
            labels: {
                formatter: function () {
                    if (this.value == 1) {
                        return on_label;
                    }
                    else {
                        return off_label;
                    }
                }
            },

            title: {
                text: ch1_high_label
            },
            opposite: false,
            id: 'ch1_flow',
            top: altezza,
            height: 100,
            offset: 0,
            lineWidth: 2,
            max: 2,
            min: 0
        });
        altezza = altezza + 150;
        numero_asse = numero_asse + 1;
        counter_series = counter_series + 1;
    }
    
    if (($('#ch1_low').is(':checked')) && (counter_series < 10)) {
        series_chart.push({
            id: 'ch3_val_series',
            name: ch1_low_label,
            data: array_ch1_low,
            step: true,
            type: 'scatter',
            tooltip: {
                pointFormat: function () {
                    return false;
                },
                valueDecimals: 0
            },
            lineWidth: 2,
            yAxis: numero_asse
        },
        {
            id: 'ch2_val_series',
            name: ch1_low_label,
            data: array_ch1_low,
            //type:'line',
            step: true,
            shadow: false,
            color: 'rgba(255,255,255,0.1)',
            tooltip: {
                //pointFormat: '<span style="#FFFFF">{series.name}:<b>{point.y}</b></span>',
                // formatter: '<span style="#FFFFF">{series.name}:<b>{point.y}</b></span>',
                pointFormat: '<span style="#FFFFF">{series.name}:<b>{point.y}</b></span><br/>',

                valueDecimals: 0
            },
            lineWidth: 2,
            shared: true,
            yAxis: numero_asse
        });
        yaxis_chart.push({
            labels: {
                formatter: function () {
                    if (this.value == 1) {
                        return on_label;
                    }
                    else {
                        return off_label;
                    }
                }
            },

            title: {
                text: ch1_low_label
            },
            opposite: false,
            top: altezza,
            height: 100,
            offset: 0,
            lineWidth: 2,
            max: 2,
            min: 0
        });
        altezza = altezza + 150;
        numero_asse = numero_asse + 1;
        counter_series = counter_series + 1;
    }
    
    if (($('#ch1_bleed').is(':checked')) && (counter_series < 10)) {
        series_chart.push({
            id: 'ch4_val_series',
            name: ch1_bleed_label,
            data: array_ch1_bleed,
            step: true,
            type: 'scatter',
            tooltip: {
                pointFormat: function () {
                    return false;
                },
                valueDecimals: 0
            },
            lineWidth: 2,

            yAxis: numero_asse
        },
        {
            id: 'ch2_val_series',
            name: ch1_bleed_label,
            data: array_ch1_bleed,
            //type:'line',
            step: true,
            shadow: false,
            color: 'rgba(255,255,255,0.1)',
            tooltip: {
                //pointFormat: '<span style="#FFFFF">{series.name}:<b>{point.y}</b></span>',
                // formatter: '<span style="#FFFFF">{series.name}:<b>{point.y}</b></span>',
                pointFormat: '<span style="#FFFFF">{series.name}:<b>{point.y}</b></span><br/>',

                valueDecimals: 0
            },
            lineWidth: 2,
            shared: true,
            yAxis: numero_asse
        });
        yaxis_chart.push({
            labels: {
                formatter: function () {
                    if (this.value == 1) {
                        return on_label;
                    }
                    else {
                        return off_label;
                    }
                }
            },

            title: {
                text: ch1_bleed_label
            },
            opposite: false,
            top: altezza,
            height: 100,
            offset: 0,
            lineWidth: 2,
            max: 2,
            min: 0
        });
        altezza = altezza + 150;
        numero_asse = numero_asse + 1;
        counter_series = counter_series + 1;
    }
    
    if (($('#ch1_livello_inhibitor').is(':checked')) && (counter_series < 10)) {
        series_chart.push({
            id: 'ch5_val_series',
            name: ch1_livello_inhibitor_label,
            data: array_ch1_inhibitor,
            step: true,
            type: 'scatter',
            tooltip: {
                pointFormat: function () {
                    return false;
                },
                valueDecimals: 0
            },
            lineWidth: 2,

            yAxis: numero_asse
        },
        {
            id: 'ch2_val_series',
            name: ch1_livello_inhibitor_label,
            data: array_ch1_inhibitor,
            //type:'line',
            step: true,
            shadow: false,
            color: 'rgba(255,255,255,0.1)',
            tooltip: {
                //pointFormat: '<span style="#FFFFF">{series.name}:<b>{point.y}</b></span>',
                // formatter: '<span style="#FFFFF">{series.name}:<b>{point.y}</b></span>',
                pointFormat: '<span style="#FFFFF">{series.name}:<b>{point.y}</b></span><br/>',

                valueDecimals: 0
            },
            lineWidth: 2,
            shared: true,
            yAxis: numero_asse
        });
        yaxis_chart.push({
            labels: {
                formatter: function () {
                    if (this.value == 1) {
                        return on_label;
                    }
                    else {
                        return off_label;
                    }
                }
            },

            title: {
                text: ch1_livello_inhibitor_label
            },
            opposite: false,
            top: altezza,
            height: 100,
            offset: 0,
            lineWidth: 2,
            max: 2,
            min: 0
        });
        altezza = altezza + 150;
        numero_asse = numero_asse + 1;
        counter_series = counter_series + 1;
    }
    
    if (($('#ch1_livello_prebiocide1').is(':checked')) && (counter_series < 10)) {
        series_chart.push({
            id: 'ch5_val_series',
            name: ch1_livello_prebiocide1_label,
            data: array_ch1_prebiocide1,
            step: true,
            type: 'scatter',
            tooltip: {
                pointFormat: function () {
                    return false;
                },
                valueDecimals: 0
            },
            lineWidth: 2,

            yAxis: numero_asse
        },
        {
            id: 'ch2_val_series',
            name: ch1_livello_prebiocide1_label,
            data: array_ch1_inhibitor,
            //type:'line',
            step: true,
            shadow: false,
            color: 'rgba(255,255,255,0.1)',
            tooltip: {
                //pointFormat: '<span style="#FFFFF">{series.name}:<b>{point.y}</b></span>',
                // formatter: '<span style="#FFFFF">{series.name}:<b>{point.y}</b></span>',
                pointFormat: '<span style="#FFFFF">{series.name}:<b>{point.y}</b></span><br/>',

                valueDecimals: 0
            },
            lineWidth: 2,
            shared: true,
            yAxis: numero_asse
        });
        yaxis_chart.push({
            labels: {
                formatter: function () {
                    if (this.value == 1) {
                        return on_label;
                    }
                    else {
                        return off_label;
                    }
                }
            },

            title: {
                text: ch1_livello_prebiocide1_label
            },
            opposite: false,
            top: altezza,
            height: 100,
            offset: 0,
            lineWidth: 2,
            max: 2,
            min: 0
        });
        altezza = altezza + 150;
        numero_asse = numero_asse + 1;
        counter_series = counter_series + 1;
    }
    
    if (($('#ch1_livello_prebiocide2').is(':checked')) && (counter_series < 10)) {
        series_chart.push({
            id: 'ch5_val_series',
            name: ch1_livello_prebiocide2_label,
            data: array_ch1_prebiocide2,
            step: true,
            type: 'scatter',
            tooltip: {
                pointFormat: function () {
                    return false;
                },
                valueDecimals: 0
            },
            lineWidth: 2,

            yAxis: numero_asse
        },
        {
            id: 'ch2_val_series',
            name: ch1_livello_prebiocide2_label,
            data: array_ch1_prebiocide2,
            //type:'line',
            step: true,
            shadow: false,
            color: 'rgba(255,255,255,0.1)',
            tooltip: {
                //pointFormat: '<span style="#FFFFF">{series.name}:<b>{point.y}</b></span>',
                // formatter: '<span style="#FFFFF">{series.name}:<b>{point.y}</b></span>',
                pointFormat: '<span style="#FFFFF">{series.name}:<b>{point.y}</b></span><br/>',

                valueDecimals: 0
            },
            lineWidth: 2,
            shared: true,
            yAxis: numero_asse
        });
        yaxis_chart.push({
            labels: {
                formatter: function () {
                    if (this.value == 1) {
                        return on_label;
                    }
                    else {
                        return off_label;
                    }
                }
            },

            title: {
                text: ch1_livello_prebiocide2_label
            },
            opposite: false,
            top: altezza,
            height: 100,
            offset: 0,
            lineWidth: 2,
            max: 2,
            min: 0
        });
        altezza = altezza + 150;
        numero_asse = numero_asse + 1;
        counter_series = counter_series + 1;
    }
    
    if (($('#ch1_livello_biocide1').is(':checked')) && (counter_series < 10)) {
        series_chart.push({
            id: 'ch5_val_series',
            name: ch1_livello_biocide1_label,
            data: array_ch1_biocide1,
            step: true,
            type: 'scatter',
            tooltip: {
                pointFormat: function () {
                    return false;
                },
                valueDecimals: 0
            },
            lineWidth: 2,

            yAxis: numero_asse
        },
        {
            id: 'ch2_val_series',
            name: ch1_livello_biocide1_label,
            data: array_ch1_biocide1,
            //type:'line',
            step: true,
            shadow: false,
            color: 'rgba(255,255,255,0.1)',
            tooltip: {
                //pointFormat: '<span style="#FFFFF">{series.name}:<b>{point.y}</b></span>',
                // formatter: '<span style="#FFFFF">{series.name}:<b>{point.y}</b></span>',
                pointFormat: '<span style="#FFFFF">{series.name}:<b>{point.y}</b></span><br/>',

                valueDecimals: 0
            },
            lineWidth: 2,
            shared: true,
            yAxis: numero_asse
        });
        yaxis_chart.push({
            labels: {
                formatter: function () {
                    if (this.value == 1) {
                        return on_label;
                    }
                    else {
                        return off_label;
                    }
                }
            },

            title: {
                text: ch1_livello_biocide1_label
            },
            opposite: false,
            top: altezza,
            height: 100,
            offset: 0,
            lineWidth: 2,
            max: 2,
            min: 0
        });
        altezza = altezza + 150;
        numero_asse = numero_asse + 1;
        counter_series = counter_series + 1;
    }
    
    if (($('#ch1_livello_biocide2').is(':checked')) && (counter_series < 10)) {
        series_chart.push({
            id: 'ch5_val_series',
            name: ch1_livello_biocide2_label,
            data: array_ch1_biocide2,
            step: true,
            type: 'scatter',
            tooltip: {
                pointFormat: function () {
                    return false;
                },
                valueDecimals: 0
            },
            lineWidth: 2,

            yAxis: numero_asse
        },
        {
            id: 'ch2_val_series',
            name: ch1_livello_biocide2_label,
            data: array_ch1_biocide2,
            //type:'line',
            step: true,
            shadow: false,
            color: 'rgba(255,255,255,0.1)',
            tooltip: {
                //pointFormat: '<span style="#FFFFF">{series.name}:<b>{point.y}</b></span>',
                // formatter: '<span style="#FFFFF">{series.name}:<b>{point.y}</b></span>',
                pointFormat: '<span style="#FFFFF">{series.name}:<b>{point.y}</b></span><br/>',

                valueDecimals: 0
            },
            lineWidth: 2,
            shared: true,
            yAxis: numero_asse
        });
        yaxis_chart.push({
            labels: {
                formatter: function () {
                    if (this.value == 1) {
                        return on_label;
                    }
                    else {
                        return off_label;
                    }
                }
            },

            title: {
                text: ch1_livello_biocide2_label
            },
            opposite: false,
            top: altezza,
            height: 100,
            offset: 0,
            lineWidth: 2,
            max: 2,
            min: 0
        });
        altezza = altezza + 150;
        numero_asse = numero_asse + 1;
        counter_series = counter_series + 1;
    }
    
    //end  canale ch1
    //canale ch2
    if (($('#ch2_val').is(':checked')) && (counter_series < 10)) {

        series_chart.push({
            name: label_ch2,
            id: 'ch6_val_series',
            data: array_ch2,
            yAxis: numero_asse,
            marker: {
                enabled: true,
                radius: 3
            },
            tooltip: {
                valueDecimals: 2
            }
        });
        yaxis_chart.push({
            title: {
                text: label_ch2
            },
            opposite: false,
            id: 'ch1_val',
            top: altezza,
            height: 200,
            lineWidth: 2
        });
        altezza = altezza + 300;
        numero_asse = numero_asse + 1;
        counter_series = counter_series + 1;
    }
    //allarmi
    
    if (($('#ch2_high').is(':checked')) && (counter_series < 10)) {
        series_chart.push({
            name: ch2_high_label,
            id: 'ch2_val_series',
            data: array_ch2_high,
            step: true,
            type: 'scatter',
            tooltip: {
                pointFormat: function () {
                    return false;
                },
                valueDecimals: 0
            },
            lineWidth: 2,

            yAxis: numero_asse
        },
        {
            id: 'ch2_val_series',
            name: ch2_high_label,
            data: array_ch2_high,
            //type:'line',
            step: true,
            shadow: false,
            color: 'rgba(255,255,255,0.1)',
            tooltip: {
                //pointFormat: '<span style="#FFFFF">{series.name}:<b>{point.y}</b></span>',
                // formatter: '<span style="#FFFFF">{series.name}:<b>{point.y}</b></span>',
                pointFormat: '<span style="#FFFFF">{series.name}:<b>{point.y}</b></span><br/>',

                valueDecimals: 0
            },
            lineWidth: 2,
            shared: true,
            yAxis: numero_asse
        });
        yaxis_chart.push({
            labels: {
                formatter: function () {
                    if (this.value == 1) {
                        return on_label;
                    }
                    else {
                        return off_label;
                    }
                }
            },

            title: {
                text: ch2_high_label
            },
            opposite: false,
            id: 'ch1_flow',
            top: altezza,
            height: 100,
            offset: 0,
            lineWidth: 2,
            max: 2,
            min: 0
        });
        altezza = altezza + 150;
        numero_asse = numero_asse + 1;
        counter_series = counter_series + 1;
    }
    
    if (($('#ch2_low').is(':checked')) && (counter_series < 10)) {
        series_chart.push({
            id: 'ch3_val_series',
            name: ch2_low_label,
            data: array_ch2_low,
            step: true,
            type: 'scatter',
            tooltip: {
                pointFormat: function () {
                    return false;
                },
                valueDecimals: 0
            },
            lineWidth: 2,

            yAxis: numero_asse
        },
        {
            id: 'ch2_val_series',
            name: ch2_low_label,
            data: array_ch2_low,
            //type:'line',
            step: true,
            shadow: false,
            color: 'rgba(255,255,255,0.1)',
            tooltip: {
                //pointFormat: '<span style="#FFFFF">{series.name}:<b>{point.y}</b></span>',
                // formatter: '<span style="#FFFFF">{series.name}:<b>{point.y}</b></span>',
                pointFormat: '<span style="#FFFFF">{series.name}:<b>{point.y}</b></span><br/>',

                valueDecimals: 0
            },
            lineWidth: 2,
            shared: true,
            yAxis: numero_asse
        });
        yaxis_chart.push({
            labels: {
                formatter: function () {
                    if (this.value == 1) {
                        return on_label;
                    }
                    else {
                        return off_label;
                    }
                }
            },

            title: {
                text: ch2_low_label
            },
            opposite: false,
            top: altezza,
            height: 100,
            offset: 0,
            lineWidth: 2,
            max: 2,
            min: 0
        });
        altezza = altezza + 150;
        numero_asse = numero_asse + 1;
        counter_series = counter_series + 1;
    }
    
    if (($('#ch2_livello').is(':checked')) && (counter_series < 10)) {
        series_chart.push({
            id: 'ch5_val_series',
            name: ch2_livello_label,
            data: array_ch2_livello,
            step: true,
            type: 'scatter',
            tooltip: {
                pointFormat: function () {
                    return false;
                },
                valueDecimals: 0
            },
            lineWidth: 2,

            yAxis: numero_asse
        },
        {
            id: 'ch2_val_series',
            name: ch2_livello_label,
            data: array_ch2_livello,
            //type:'line',
            step: true,
            shadow: false,
            color: 'rgba(255,255,255,0.1)',
            tooltip: {
                //pointFormat: '<span style="#FFFFF">{series.name}:<b>{point.y}</b></span>',
                // formatter: '<span style="#FFFFF">{series.name}:<b>{point.y}</b></span>',
                pointFormat: '<span style="#FFFFF">{series.name}:<b>{point.y}</b></span><br/>',

                valueDecimals: 0
            },
            lineWidth: 2,
            shared: true,
            yAxis: numero_asse
        });
        yaxis_chart.push({
            labels: {
                formatter: function () {
                    if (this.value == 1) {
                        return on_label;
                    }
                    else {
                        return off_label;
                    }
                }
            },

            title: {
                text: ch2_livello_label
            },
            opposite: false,
            top: altezza,
            height: 100,
            offset: 0,
            lineWidth: 2,
            max: 2,
            min: 0
        });
        altezza = altezza + 150;
        numero_asse = numero_asse + 1;
        counter_series = counter_series + 1;
    }
    
    //end  canale ch2
    //canale ch3
    if (($('#ch3_val').is(':checked')) && (counter_series < 10)) {

        series_chart.push({
            name: label_ch3,
            id: 'ch6_val_series',
            data: array_ch3,
            yAxis: numero_asse,
            marker: {
                enabled: true,
                radius: 3
            },
            tooltip: {
                valueDecimals: 2
            }
        });
        yaxis_chart.push({
            title: {
                text: label_ch3
            },
            opposite: false,
            id: 'ch1_val',
            top: altezza,
            height: 200,
            lineWidth: 2
        });
        altezza = altezza + 300;
        numero_asse = numero_asse + 1;
        counter_series = counter_series + 1;
    }
    
    //allarmi
    //allarmi
    if (($('#ch3_high').is(':checked')) && (counter_series < 10)) {
        series_chart.push({
            name: ch3_high_label,
            id: 'ch3_val_series',
            data: array_ch3_high,
            step: true,
            type: 'scatter',
            tooltip: {
                pointFormat: function () {
                    return false;
                },
                valueDecimals: 0
            },
            lineWidth: 2,

            yAxis: numero_asse
        },
        {
            id: 'ch2_val_series',
            name: ch3_high_label,
            data: array_ch3_high,
            //type:'line',
            step: true,
            shadow: false,
            color: 'rgba(255,255,255,0.1)',
            tooltip: {
                //pointFormat: '<span style="#FFFFF">{series.name}:<b>{point.y}</b></span>',
                // formatter: '<span style="#FFFFF">{series.name}:<b>{point.y}</b></span>',
                pointFormat: '<span style="#FFFFF">{series.name}:<b>{point.y}</b></span><br/>',

                valueDecimals: 0
            },
            lineWidth: 2,
            shared: true,
            yAxis: numero_asse
        });
        yaxis_chart.push({
            labels: {
                formatter: function () {
                    if (this.value == 1) {
                        return on_label;
                    }
                    else {
                        return off_label;
                    }
                }
            },

            title: {
                text: ch3_high_label
            },
            opposite: false,
            id: 'ch1_flow',
            top: altezza,
            height: 100,
            offset: 0,
            lineWidth: 2,
            max: 2,
            min: 0
        });
        altezza = altezza + 150;
        numero_asse = numero_asse + 1;
        counter_series = counter_series + 1;
    }
    
    if (($('#ch3_low').is(':checked')) && (counter_series < 10)) {
        series_chart.push({
            id: 'ch3_val_series',
            name: ch3_low_label,
            data: array_ch3_low,
            step: true,
            type: 'scatter',
            tooltip: {
                pointFormat: function () {
                    return false;
                },
                valueDecimals: 0
            },
            lineWidth: 2,

            yAxis: numero_asse
        },
        {
            id: 'ch2_val_series',
            name: ch3_low_label,
            data: array_ch3_low,
            //type:'line',
            step: true,
            shadow: false,
            color: 'rgba(255,255,255,0.1)',
            tooltip: {
                //pointFormat: '<span style="#FFFFF">{series.name}:<b>{point.y}</b></span>',
                // formatter: '<span style="#FFFFF">{series.name}:<b>{point.y}</b></span>',
                pointFormat: '<span style="#FFFFF">{series.name}:<b>{point.y}</b></span><br/>',

                valueDecimals: 0
            },
            lineWidth: 2,
            shared: true,
            yAxis: numero_asse
        });
        yaxis_chart.push({
            labels: {
                formatter: function () {
                    if (this.value == 1) {
                        return on_label;
                    }
                    else {
                        return off_label;
                    }
                }
            },

            title: {
                text: ch3_low_label
            },
            opposite: false,
            top: altezza,
            height: 100,
            offset: 0,
            lineWidth: 2,
            max: 2,
            min: 0
        });
        altezza = altezza + 150;
        numero_asse = numero_asse + 1;
        counter_series = counter_series + 1;
    }
    
    if (($('#ch3_livello').is(':checked')) && (counter_series < 10)) {
        series_chart.push({
            id: 'ch5_val_series',
            name: ch3_livello_label,
            data: array_ch3_livello,
            step: true,
            type: 'scatter',
            tooltip: {
                pointFormat: function () {
                    return false;
                },
                valueDecimals: 0
            },
            lineWidth: 2,

            yAxis: numero_asse
        },
        {
            id: 'ch2_val_series',
            name: ch3_livello_label,
            data: array_ch3_livello,
            //type:'line',
            step: true,
            shadow: false,
            color: 'rgba(255,255,255,0.1)',
            tooltip: {
                //pointFormat: '<span style="#FFFFF">{series.name}:<b>{point.y}</b></span>',
                // formatter: '<span style="#FFFFF">{series.name}:<b>{point.y}</b></span>',
                pointFormat: '<span style="#FFFFF">{series.name}:<b>{point.y}</b></span><br/>',

                valueDecimals: 0
            },
            lineWidth: 2,
            shared: true,
            yAxis: numero_asse
        });
        yaxis_chart.push({
            labels: {
                formatter: function () {
                    if (this.value == 1) {
                        return on_label;
                    }
                    else {
                        return off_label;
                    }
                }
            },

            title: {
                text: ch3_livello_label
            },
            opposite: false,
            top: altezza,
            height: 100,
            offset: 0,
            lineWidth: 2,
            max: 2,
            min: 0
        });
        altezza = altezza + 150;
        numero_asse = numero_asse + 1;
        counter_series = counter_series + 1;
    }
    //end  canale ch3
    //canale ch4
    
    //end  canale ch4
    //canale ch5
    if (($('#temperature_select').is(':checked')) && (counter_series < 10)) {

        series_chart.push({
            name: label_temperature_select,
            id: 'ch6_val_series',
            data: array_temperatura,
            yAxis: numero_asse,
            marker: {
                enabled: true,
                radius: 3
            },
            tooltip: {
                valueDecimals: 2
            }
        });
        yaxis_chart.push({
            title: {
                text: label_temperature_select
            },
            opposite: false,
            id: 'ch1_val',
            top: altezza,
            height: 200,
            lineWidth: 2
        });
        altezza = altezza + 300;
        numero_asse = numero_asse + 1;
        counter_series = counter_series + 1;
    }
    
    //end  canale ch5
    if (($('#flow_select').is(':checked')) && (counter_series < 10)) {
        series_chart.push({
            id: 'ch5_val_series',
            name: label_flow_select,
            data: array_flow,
            step: true,
            type: 'scatter',
            tooltip: {
                pointFormat: function () {
                    return false;
                },
                valueDecimals: 0
            },
            lineWidth: 2,

            yAxis: numero_asse
        },
        {
            id: 'ch2_val_series',
            name: label_flow_select,
            data: array_flow,
            //type:'line',
            step: true,
            shadow: false,
            color: 'rgba(255,255,255,0.1)',
            tooltip: {
                //pointFormat: '<span style="#FFFFF">{series.name}:<b>{point.y}</b></span>',
                // formatter: '<span style="#FFFFF">{series.name}:<b>{point.y}</b></span>',
                pointFormat: '<span style="#FFFFF">{series.name}:<b>{point.y}</b></span><br/>',

                valueDecimals: 0
            },
            lineWidth: 2,
            shared: true,
            yAxis: numero_asse
        });
        yaxis_chart.push({
            labels: {
                formatter: function () {
                    if (this.value == 1) {
                        return on_label;
                    }
                    else {
                        return off_label;
                    }
                }
            },

            title: {
                text: label_flow_select
            },
            opposite: false,
            top: altezza,
            height: 100,
            offset: 0,
            lineWidth: 2,
            max: 2,
            min: 0
        });
        altezza = altezza + 150;
        numero_asse = numero_asse + 1;
        counter_series = counter_series + 1;
    }
    if (($('#wmi').is(':checked')) && (counter_series < 10)) {

        series_chart.push({
            name: label_wmi_select,
            id: 'ch6_val_series',
            data: array_wmi,
            yAxis: numero_asse,
            marker: {
                enabled: true,
                radius: 3
            },
            tooltip: {
                valueDecimals: 2
            }
        });
        yaxis_chart.push({
            title: {
                text: label_wmi_select
            },
            opposite: false,
            id: 'ch1_val',
            top: altezza,
            height: 200,
            lineWidth: 2
        });
        altezza = altezza + 300;
        numero_asse = numero_asse + 1;
        counter_series = counter_series + 1;
    }
    if (($('#wmb').is(':checked')) && (counter_series < 10)) {

        series_chart.push({
            name: 'wmb',
            id: 'ch6_val_series',
            data: array_wmb,
            yAxis: numero_asse,
            marker: {
                enabled: true,
                radius: 3
            },
          /*  tooltip: {
                valueDecimals: 2
            }*/
        });
        yaxis_chart.push({
            title: {
                text: label_wmb_select
            },
            opposite: false,
            id: 'ch1_val',
            top: altezza,
            height: 200,
            lineWidth: 2
        });
        altezza = altezza + 300;
        numero_asse = numero_asse + 1;
        counter_series = counter_series + 1;
    }

    if (($('#Power_On').is(':checked')) && (counter_series < 10)) {
        series_chart.push({
            name: label_poweron_select,
            id: 'power_on_val_series',
            data: array_power_on,
            step: true,
            type: 'scatter',

            tooltip: {
                pointFormat: function () {
                    return false;
                },
                valueDecimals: 0
            },
            lineWidth: 2,

            yAxis: numero_asse
        },
        {
            id: 'power_on_val_series',
            name: label_poweron_select,
            data: array_power_on,
            //type:'line',
            step: true,
            shadow: false,
            color: 'rgba(255,255,255,0.1)',
            tooltip: {
                //pointFormat: '<span style="#FFFFF">{series.name}:<b>{point.y}</b></span>',
                // formatter: '<span style="#FFFFF">{series.name}:<b>{point.y}</b></span>',
                pointFormat: '<span style="#FFFFF">{series.name}:<b>{point.y}</b></span><br/>',

                valueDecimals: 0
            },
            lineWidth: 2,
            shared: true,
            yAxis: numero_asse
        });
        yaxis_chart.push({
            labels: {
                formatter: function () {
                    if (this.value == 1) {
                        return on_label;
                    }
                    else {
                        return off_label;
                    }
                }
            },

            title: {
                text: label_poweron_select
            },
            opposite: false,
            id: 'Power_On',
            top: altezza,
            height: 100,
            offset: 0,
            lineWidth: 2,
            max: 2,
            min: 0
        });
        altezza = altezza + 150;
        numero_asse = numero_asse + 1;
        counter_series = counter_series + 1;
    }

    altezza = altezza + 100;

    // series_chart[0].setData(array_ch1);
    // series_chart[1].setData(array_ch1);
    $("#chart_div").height(altezza);
    
    create_chart(series_chart, yaxis_chart);
    draw_tabella();
}
function convertUTCDateToLocalDate(convertdLocalTime) {


    var hourOffset = convertdLocalTime.getTimezoneOffset() / 60;

    convertdLocalTime.setHours(convertdLocalTime.getHours() + hourOffset);

    return convertdLocalTime;
}
function draw_tabella() {

    var chart = $('#chart_div').highcharts();
    var series_chart = chart.series;
    var header_array = [];
    var header_value = [];
    var oggetto = {};
    var string_array = "";
    var string_array_precedent = "";
    var i = 0;
    oggetto = { "title": data_label }
    header_array.push(oggetto)
    var date2_ms = parseDate(last_date, 'dd/mm/yy');
    var date1_ms = parseDate(init_date, 'dd/mm/yy');


    $.each(series_chart, function (row, series_chart_temp) {
        //if ((series_chart_temp.name != "Navigator") && (series_chart_temp.name != string_array_precedent)) {
        if ((series_chart_temp.name.indexOf("Navigator") < 0) && ((series_chart_temp.type != "scatter"))) {
            // if (string_array == "") {
            // string_array = string_array + '[{ "title": "' + series_chart_temp.name + '" }'
            //string_array = string_array + '"title": "' + series_chart_temp.name + '"'
            oggetto = { "title": series_chart_temp.name }
            header_array.push(oggetto)

            //header_value.push(point.);
        }
        string_array_precedent = series_chart_temp.name;
    });
    i = array_ch1.length - 1;
    $.each(array_ch1, function (row1, point1) {
        var array_temp = [];
        var date = new Date(array_ch1[i][0]);
        date = convertUTCDateToLocalDate(date);
        var frequenza_lettura = false;

        var theyear = date.getFullYear()
        var themonth = date.getMonth() + 1
        var thetoday = date.getDate()
        var data_confronto = parseDate(thetoday + "/" + themonth + "/" + theyear, 'dd/mm/yy');
        var ore = date.getHours();
        var minuti = date.getMinutes();

        /*var data_stringa = date.toString("dd/MM/yy");
        var data_finale = parseDate(data_stringa, 'dd/mm/yy');
        alert(data_finale);
        array_temp.push(data_finale.toString("dd/MM/yy"));
        */
        //alert(theyear + "/" + themonth + "/" + thetoday);
        if ((data_confronto >= date1_ms) && (data_confronto <= date2_ms)) {
            if ((array_ch1_high[i][1] == 0) && (array_ch1_low[i][1] == 0) && (array_ch1_bleed[i][1] == 0) &&
                (array_ch1_inhibitor[i][1] == 0) && (array_ch1_prebiocide1[i][1] == 0) && (array_ch1_prebiocide2[i][1] == 0) &&
                (array_ch1_biocide1[i][1] == 0) && (array_ch1_biocide2[i][1] == 0) && (array_ch2_high[i][1] == 0) &&
                (array_ch2_low[i][1] == 0) && (array_ch2_livello[i][1] == 0) && (array_ch3_high[i][1] == 0) &&
                (array_ch2_low[i][1] == 0) && (array_ch3_livello[i][1] == 0) && (array_flow[i][1] == 0)) {

                frequenza_lettura = true;

            }

            if (international_unit == "IS") {// ' europeo
                if (frequenza_lettura)
                    array_temp.push('<span style="color:blue">' + get_numero_string(thetoday) + "/" + get_numero_string(themonth) + "/" + get_numero_string(theyear) + " " + get_numero_string(ore) + ":" + get_numero_string(minuti) + '</span>');
                else
                    array_temp.push(get_numero_string(thetoday) + "/" + get_numero_string(themonth) + "/" + get_numero_string(theyear) + " " + get_numero_string(ore) + ":" + get_numero_string(minuti));

            }
            else {
                var suffex = "";
                // alert(ore_temp);
                if (ore >= 12) {
                    suffex = "pm";
                }
                else {
                    suffex = "am";
                }
                if (ore > 12) {
                    ore = ore - 12;
                    if (ore == 0) ore = 12;
                }
                
                if (frequenza_lettura)
                    array_temp.push('<span style="color:blue">' + get_numero_string(thetoday) + "/" + get_numero_string(themonth) + "/" + get_numero_string(theyear) + " " + get_numero_string(ore) + ":" + get_numero_string(minuti) + " " + suffex + '</span>');
                else
                    array_temp.push(get_numero_string(thetoday) + "/" + get_numero_string(themonth) + "/" + get_numero_string(theyear) + " " + get_numero_string(ore) + ":" + get_numero_string(minuti) + " " + suffex);

            }

            if (($('#ch1_val').is(':checked'))) {
                if (frequenza_lettura)
                    array_temp.push('<span style="color:blue">' + array_ch1[i][1] + '</span>');
                else
                    array_temp.push(array_ch1[i][1]);
            }
            if (($('#ch1_high').is(':checked'))) {
                if (frequenza_lettura)
                    array_temp.push('<span style="color:blue">' + on_off(array_ch1_high[i][1]) + '</span>');
                else {
                    if (array_ch1_high[i][1] == 1)
                        array_temp.push('<span style="color:red">' + on_off(array_ch1_high[i][1]) + '</span>');
                    else
                        array_temp.push(on_off(array_ch1_high[i][1]));
                }
            }
            if (($('#ch1_low').is(':checked'))) {
                if (frequenza_lettura)
                    array_temp.push('<span style="color:blue">' + on_off(array_ch1_low[i][1]) + '</span>');
                else {
                    if (array_ch1_low[i][1] == 1)
                        array_temp.push('<span style="color:red">' + on_off(array_ch1_low[i][1]) + '</span>');
                    else
                        array_temp.push(on_off(array_ch1_low[i][1]));
                }

                //array_temp.push(on_off(array_ch1_low[i][1]));
            }
            if (($('#ch1_bleed').is(':checked'))) {
                if (frequenza_lettura)
                    array_temp.push('<span style="color:blue">' + on_off(array_ch1_bleed[i][1]) + '</span>');
                else {
                    if (array_ch1_bleed[i][1] == 1)
                        array_temp.push('<span style="color:red">' + on_off(array_ch1_bleed[i][1]) + '</span>');
                    else
                        array_temp.push(on_off(array_ch1_bleed[i][1]));
                }

                //array_temp.push(on_off(array_ch1_bleed[i][1]));
            }
            if (($('#ch1_livello_inhibitor').is(':checked'))) {
                if (frequenza_lettura)
                    array_temp.push('<span style="color:blue">' + on_off(array_ch1_inhibitor[i][1]) + '</span>');
                else {
                    if (array_ch1_inhibitor[i][1] == 1)
                        array_temp.push('<span style="color:red">' + on_off(array_ch1_inhibitor[i][1]) + '</span>');
                    else
                        array_temp.push(on_off(array_ch1_inhibitor[i][1]));
                }

                //array_temp.push(on_off(array_ch1_inhibitor[i][1]));
            }
            if (($('#ch1_livello_prebiocide1').is(':checked'))) {
                if (frequenza_lettura)
                    array_temp.push('<span style="color:blue">' + on_off(array_ch1_prebiocide1[i][1]) + '</span>');
                else {
                    if (array_ch1_prebiocide1[i][1] == 1)
                        array_temp.push('<span style="color:red">' + on_off(array_ch1_prebiocide1[i][1]) + '</span>');
                    else
                        array_temp.push(on_off(array_ch1_prebiocide1[i][1]));
                }

                // array_temp.push(on_off(array_ch1_prebiocide1[i][1]));
            }
            if (($('#ch1_livello_prebiocide2').is(':checked'))) {
                //array_temp.push(on_off(array_ch1_prebiocide2[i][1]));
                if (frequenza_lettura)
                    array_temp.push('<span style="color:blue">' + on_off(array_ch1_prebiocide2[i][1]) + '</span>');
                else {
                    if (array_ch1_prebiocide2[i][1] == 1)
                        array_temp.push('<span style="color:red">' + on_off(array_ch1_prebiocide2[i][1]) + '</span>');
                    else
                        array_temp.push(on_off(array_ch1_prebiocide2[i][1]));
                }

            }
            if (($('#ch1_livello_biocide1').is(':checked'))) {
                //array_temp.push(on_off(array_ch1_biocide1[i][1]));
                if (frequenza_lettura)
                    array_temp.push('<span style="color:blue">' + on_off(array_ch1_biocide1[i][1]) + '</span>');
                else {
                    if (array_ch1_biocide1[i][1] == 1)
                        array_temp.push('<span style="color:red">' + on_off(array_ch1_biocide1[i][1]) + '</span>');
                    else
                        array_temp.push(on_off(array_ch1_biocide1[i][1]));
                }

            }
            if (($('#ch1_livello_biocide2').is(':checked'))) {
                //array_temp.push(on_off(array_ch1_biocide2[i][1]));
                if (frequenza_lettura)
                    array_temp.push('<span style="color:blue">' + on_off(array_ch1_biocide2[i][1]) + '</span>');
                else {
                    if (array_ch1_biocide2[i][1] == 1)
                        array_temp.push('<span style="color:red">' + on_off(array_ch1_biocide2[i][1]) + '</span>');
                    else
                        array_temp.push(on_off(array_ch1_biocide2[i][1]));
                }

            }
            if (($('#ch2_val').is(':checked'))) {
                if (frequenza_lettura)
                    array_temp.push('<span style="color:blue">' + array_ch2[i][1] + '</span>');
                else
                    array_temp.push(array_ch2[i][1]);
            }
            if (($('#ch2_high').is(':checked'))) {
                //array_temp.push(on_off(array_ch2_high[i][1]));
                if (frequenza_lettura)
                    array_temp.push('<span style="color:blue">' + on_off(array_ch2_high[i][1]) + '</span>');
                else {
                    if (array_ch2_high[i][1] == 1)
                        array_temp.push('<span style="color:red">' + on_off(array_ch2_high[i][1]) + '</span>');
                    else
                        array_temp.push(on_off(array_ch2_high[i][1]));
                }

            }
            if (($('#ch2_low').is(':checked'))) {
                //array_temp.push(on_off(array_ch2_low[i][1]));
                if (frequenza_lettura)
                    array_temp.push('<span style="color:blue">' + on_off(array_ch2_low[i][1]) + '</span>');
                else {
                    if (array_ch2_low[i][1] == 1)
                        array_temp.push('<span style="color:red">' + on_off(array_ch2_low[i][1]) + '</span>');
                    else
                        array_temp.push(on_off(array_ch2_low[i][1]));
                }

            }
            if (($('#ch2_livello').is(':checked'))) {
                //array_temp.push(on_off(array_ch2_livello[i][1]));
                if (frequenza_lettura)
                    array_temp.push('<span style="color:blue">' + on_off(array_ch2_livello[i][1]) + '</span>');
                else {
                    if (array_ch2_livello[i][1] == 1)
                        array_temp.push('<span style="color:red">' + on_off(array_ch2_livello[i][1]) + '</span>');
                    else
                        array_temp.push(on_off(array_ch2_livello[i][1]));
                }

            }
            if (($('#ch3_val').is(':checked'))) {
                if (frequenza_lettura)
                    array_temp.push('<span style="color:blue">' + array_ch3[i][1] + '</span>');
                else
                    array_temp.push(array_ch3[i][1]);
            }
            if (($('#ch3_high').is(':checked'))) {
                //array_temp.push(on_off(array_ch3_high[i][1]));
                if (frequenza_lettura)
                    array_temp.push('<span style="color:blue">' + on_off(array_ch3_high[i][1]) + '</span>');
                else {
                    if (array_ch3_high[i][1] == 1)
                        array_temp.push('<span style="color:red">' + on_off(array_ch3_high[i][1]) + '</span>');
                    else
                        array_temp.push(on_off(array_ch3_high[i][1]));
                }

            }
            if (($('#ch3_low').is(':checked'))) {
                //array_temp.push(on_off(array_ch3_low[i][1]));
                if (frequenza_lettura)
                    array_temp.push('<span style="color:blue">' + on_off(array_ch3_low[i][1]) + '</span>');
                else {
                    if (array_ch3_low[i][1] == 1)
                        array_temp.push('<span style="color:red">' + on_off(array_ch3_low[i][1]) + '</span>');
                    else
                        array_temp.push(on_off(array_ch3_low[i][1]));
                }

            }
            if (($('#ch3_livello').is(':checked'))) {
                //array_temp.push(on_off(array_ch3_livello[i][1]));
                if (frequenza_lettura)
                    array_temp.push('<span style="color:blue">' + on_off(array_ch3_livello[i][1]) + '</span>');
                else {
                    if (array_ch3_livello[i][1] == 1)
                        array_temp.push('<span style="color:red">' + on_off(array_ch3_livello[i][1]) + '</span>');
                    else
                        array_temp.push(on_off(array_ch3_livello[i][1]));
                }

            }
            if (($('#temperature_select').is(':checked'))) {
                if (frequenza_lettura)
                    array_temp.push('<span style="color:blue">' + array_temperatura[i][1] + '</span>');
                else
                    array_temp.push(array_temperatura[i][1]);
            }

            if (($('#flow_select').is(':checked'))) {
                if (frequenza_lettura)
                    array_temp.push('<span style="color:blue">' + on_off(array_flow[i][1]) + '</span>');
                else {
                    if (array_flow[i][1] == 1)
                        array_temp.push('<span style="color:red">' + on_off(array_flow[i][1]) + '</span>');
                    else
                        array_temp.push(on_off(array_flow[i][1]));
                }

            }
            if (($('#wmi').is(':checked'))) {
                if (frequenza_lettura)
                    array_temp.push('<span style="color:blue">' + array_wmi[i][1] + '</span>');
                else
                    array_temp.push(array_wmi[i][1]);

                //array_temp.push(array_wmi[i][1]);
            }
            if (($('#wmb').is(':checked'))) {
               // alert(array_wmb[i][1]);
                if (frequenza_lettura)
                    array_temp.push('<span style="color:blue">' + array_wmb[i][1] + '</span>');
                else
                    array_temp.push(array_wmb[i][1]);

                //array_temp.push(array_wmb[i][1]);
            }

            if (($('#Power_On').is(':checked'))) {
                //array_temp.push(on_off(array_ch3_livello[i][1]));
                if (frequenza_lettura)
                    array_temp.push('<span style="color:blue">' + on_off(array_power_on[i][1]) + '</span>');
                else {
                    if (array_power_on[i][1] == 1)
                        array_temp.push('<span style="color:red">' + on_off(array_power_on[i][1]) + '</span>');
                    else
                        array_temp.push(on_off(array_power_on[i][1]));
                }

            }
            
            header_value.push(array_temp);
        }
        i = i - 1;
    });

    // header_array.push(string_array);
    $('#chart_table').html('<table cellpadding="0" cellspacing="0" border="0" class="display dynamicTable table table-striped table-bordered table-condensed" id="example"></table>');
/*
    $('#example').dataTable({
        "dom": 'T<"clear">lfrtip',
        "bSort": false,
        "tableTools": {
            "sSwfPath": "/chart/js/swf/copy_csv_xls_pdf.swf"
        },
        "data": header_value,
        "columns": header_array
    });*/
    $('#example').dataTable({
        dom: 'Bfrtip',
        buttons: [
            'copy', 'csv', 'excel', 'pdf', 'print'
        ],
        bSort: false,
        data: header_value,
        columns: header_array
    });
}
function get_numero_string(numero_valore) {
    if (numero_valore < 10)
        return "0" + numero_valore;
    else
        return numero_valore;
}
function on_off(ingresso) {
    if (ingresso == 1)
        return on_label
    else
        return off_label
}
function manage_div() {
    
    if ($("#log_collapse").is(":visible")) {
        $("#log_collapse").hide();
    }
    else {
        $("#log_collapse").show();
    }
   // alert(array_wmb[0][1]);
   // alert(array_wmb[1][1]);

}
$("#head_log").click(function () {

    manage_div();
});
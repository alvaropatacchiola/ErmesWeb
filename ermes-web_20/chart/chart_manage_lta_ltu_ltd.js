var primo = 0;
var from_difference = 0;
var to_difference = 0;

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
    },
     function (chart) {

         // apply the date pickers
         setTimeout(function () {
             $('input.highcharts-range-selector', $(chart.container).parent())
                 .datepicker({ dateFormat: 'dd/mm/yy' });
         }, 0)
     });
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
function salva_dati_log(callback) {
    myFunction_log = new Function(callback);
    myFunction_log();
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

function parseDate(str, format) {
    //var mdy = str.split('/')
    var data = $.datepicker.parseDate(format, str);
    return data;
}
function get_action() {
    $("#form_log").attr("action", "chart/log_lta_ltu_ltd.aspx?init_date=" + init_date + "&last_date=" + last_date)
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
            try {
                chart_temp.xAxis[0].setExtremes(
                     Date.UTC(data1.getFullYear(), data1.getMonth(), data1.getDate()),
                      Date.UTC(data2.getFullYear(), data2.getMonth(), data2.getDate()+1)
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
    if ($('#Lev_Acid_L').is(':checked')) {
        stringa = stringa + "True";
    }
    else {
        stringa = stringa + "False";
    }
    stringa = stringa + "z";

    if ($('#Flow_Acid_L').is(':checked')) {
        stringa = stringa + "True";
    }
    else {
        stringa = stringa + "False";
    }
    stringa = stringa + "z";
    if (($('#Flow_Self_Water_L').is(':checked'))) {
        stringa = stringa + "True";
    }
    else {
        stringa = stringa + "False";
    }
    stringa = stringa + "z";
    if (($('#Lev_Water_L').is(':checked'))) {
        stringa = stringa + "True";
    }
    else {
        stringa = stringa + "False";
    }
    stringa = stringa + "z";
    if (($('#Flow_Chlorite_L').is(':checked'))) {
        stringa = stringa + "True";
    }
    else {
        stringa = stringa + "False";
    }
    stringa = stringa + "z";
    if (($('#Lev_Chlorite_L').is(':checked'))) {
        stringa = stringa + "True";
    }
    else {
        stringa = stringa + "False";
    }
    stringa = stringa + "z";
    if (($('#Overf').is(':checked'))) {
        stringa = stringa + "True";
    }
    else {
        stringa = stringa + "False";
    }
    stringa = stringa + "z";
    if (($('#Flow_Water_dil_L').is(':checked'))) {
        stringa = stringa + "True";
    }
    else {
        stringa = stringa + "False";
    }
    stringa = stringa + "z";

    //----------------------------------------------------------
    if (($('#Level_SW').is(':checked'))) {
        stringa = stringa + "True";
    }
    else {
        stringa = stringa + "False";
    }
    stringa = stringa + "z";
    if (($('#Level_SW').is(':checked'))) {
        stringa = stringa + "True";
    }
    else {
        stringa = stringa + "False";
    }
    stringa = stringa + "z";
    if (($('#BypassB').is(':checked'))) {
        stringa = stringa + "True";
    }
    else {
        stringa = stringa + "False";
    }
    stringa = stringa + "z";

    if (($('#TimeOut_L').is(':checked'))) {
        stringa = stringa + "True";
    }
    else {
        stringa = stringa + "False";
    }
    stringa = stringa + "z";

    if (($('#Service_F_L').is(':checked'))) {
        stringa = stringa + "True";
    }
    else {
        stringa = stringa + "False";
    }
    stringa = stringa + "z";

    if (($('#Lim_Dioxide').is(':checked'))) {
        stringa = stringa + "True";
    }
    else {
        stringa = stringa + "False";
    }
    stringa = stringa + "z";

    if (($('#Lev_Alflow').is(':checked'))) {
        stringa = stringa + "True";
    }
    else {
        stringa = stringa + "False";
    }
    stringa = stringa + "z";




    if (($('#flow1').is(':checked'))) {
        stringa = stringa + "True";
    }
    else {
        stringa = stringa + "False";
    }
    stringa = stringa + "z";

    if (($('#clo2').is(':checked'))) {
        stringa = stringa + "True";
    }
    else {
        stringa = stringa + "False";
    }
    stringa = stringa + "z";

    if (($('#naso').is(':checked'))) {
        stringa = stringa + "True";
    }
    else {
        stringa = stringa + "False";
    }
    stringa = stringa + "z";

    if (($('#temperature_lt').is(':checked'))) {
        stringa = stringa + "True";
    }
    else {
        stringa = stringa + "False";
    }
    stringa = stringa + "z";

    if (($('#MinMax').is(':checked'))) {
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
    //alert("entro")

    //allarmi

    if (($('#Lev_Acid_L').is(':checked')) && (counter_series < 10)) {
        series_chart.push({
            id: 'ch3_val_series',
            name: Lev_Acid_L_label,
            data: array_Lev_Acid_L,
            type: 'scatter',
            tooltip: {
                pointFormat: function () {
                    return false;
                },
                valueDecimals: 0
            },
            lineWidth: 2,

            step: true,
            yAxis: numero_asse
        },
        {
            id: 'ch2_val_series',
            name: Lev_Acid_L_label,
            data: array_Lev_Acid_L,
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
                        return 'ON';
                    }
                    else {
                        return 'OFF';
                    }
                }
            },

            title: {
                text: Lev_Acid_L_label
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
    if (($('#Flow_Acid_L').is(':checked')) && (counter_series < 10)) {
        series_chart.push({
            id: 'ch4_val_series',
            name: Flow_Acid_L_label,
            data: array_Flow_Acid_L,
            type: 'scatter',
            tooltip: {
                pointFormat: function () {
                    return false;
                },
                valueDecimals: 0
            },
            lineWidth: 2,

            step: true,
            yAxis: numero_asse
        },
        {
            id: 'ch2_val_series',
            name: Flow_Acid_L_label,
            data: array_Flow_Acid_L,
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
                        return 'ON';
                    }
                    else {
                        return 'OFF';
                    }
                }
            },

            title: {
                text: Flow_Acid_L_label
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



    if (($('#Flow_Self_Water_L').is(':checked')) && (counter_series < 10)) {
        series_chart.push({
            id: 'ch3_val_series',
            name: Flow_Self_Water_L_label,
            data: array_Flow_Self_Water_L,
            type: 'scatter',
            tooltip: {
                pointFormat: function () {
                    return false;
                },
                valueDecimals: 0
            },
            lineWidth: 2,

            step: true,
            yAxis: numero_asse
        },
        {
            id: 'ch2_val_series',
            name: Flow_Self_Water_L_label,
            data: array_Flow_Self_Water_L,
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
                        return 'ON';
                    }
                    else {
                        return 'OFF';
                    }
                }
            },

            title: {
                text: Flow_Self_Water_L_label
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
    //timer
    if (($('#Lev_Water_L').is(':checked')) && (counter_series < 10)) {
        series_chart.push({
            id: 'ch3_val_series',
            name: Lev_Water_L_label,
            data: array_Lev_Water_L,
            type: 'scatter',
            tooltip: {
                pointFormat: function () {
                    return false;
                },
                valueDecimals: 0
            },
            lineWidth: 2,

            step: true,
            yAxis: numero_asse
        },
        {
            id: 'ch2_val_series',
            name: Lev_Water_L_label,
            data: array_Lev_Water_L,
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
                        return 'ON';
                    }
                    else {
                        return 'OFF';
                    }
                }
            },

            title: {
                text: Lev_Water_L_label
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
    if (($('#Flow_Chlorite_L').is(':checked')) && (counter_series < 10)) {
        series_chart.push({
            id: 'ch3_val_series',
            name: Flow_Chlorite_L_label,
            data: array_Flow_Chlorite_L,
            type: 'scatter',
            tooltip: {
                pointFormat: function () {
                    return false;
                },
                valueDecimals: 0
            },
            lineWidth: 2,

            step: true,
            yAxis: numero_asse
        },
        {
            id: 'ch2_val_series',
            name: '3_val_series',
            name: Flow_Chlorite_L_label,
            data: array_Flow_Chlorite_L,
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
                        return 'ON';
                    }
                    else {
                        return 'OFF';
                    }
                }
            },

            title: {
                text: Flow_Chlorite_L_label
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
    if (($('#Lev_Chlorite_L').is(':checked')) && (counter_series < 10)) {
        series_chart.push({
            id: 'ch3_val_series',
            name: Lev_Chlorite_L_label,
            data: array_Lev_Chlorite_L,
            type: 'scatter',
            tooltip: {
                pointFormat: function () {
                    return false;
                },
                valueDecimals: 0
            },
            lineWidth: 2,

            step: true,
            yAxis: numero_asse
        },
        {
            id: 'ch2_val_series',
            name: Lev_Chlorite_L_label,
            data: array_Lev_Chlorite_L,
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
                        return 'ON';
                    }
                    else {
                        return 'OFF';
                    }
                }
            },

            title: {
                text: Lev_Chlorite_L_label
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

    if (($('#Overf').is(':checked')) && (counter_series < 10)) {
        series_chart.push({
            id: 'ch3_val_series',
            name: Overf_label,
            data: array_Overf,
            type: 'scatter',
            tooltip: {
                pointFormat: function () {
                    return false;
                },
                valueDecimals: 0
            },
            lineWidth: 2,

            step: true,
            yAxis: numero_asse
        },
        {
            id: 'ch2_val_series',
            name: Overf_label,
            data: array_Overf,
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
                        return 'ON';
                    }
                    else {
                        return 'OFF';
                    }
                }
            },

            title: {
                text: Overf_label
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
    if (($('#Flow_Water_dil_L').is(':checked')) && (counter_series < 10)) {
        series_chart.push({
            id: 'ch3_val_series',
            name: Flow_Water_dil_L_label,
            data: array_Flow_Water_dil_L,
            type: 'scatter',
            tooltip: {
                pointFormat: function () {
                    return false;
                },
                valueDecimals: 0
            },
            lineWidth: 2,

            step: true,
            yAxis: numero_asse
        },
        {
            id: 'ch2_val_series',
            name: Flow_Water_dil_L_label,
            data: array_Flow_Water_dil_L,
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
                        return 'ON';
                    }
                    else {
                        return 'OFF';
                    }
                }
            },

            title: {
                text: Flow_Water_dil_L_label
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
    if (($('#TimeOut_L').is(':checked')) && (counter_series < 10)) {
        series_chart.push({
            id: 'ch3_val_series',
            name: TimeOut_L_label,
            data: array_TimeOut_L,
            type: 'scatter',
            tooltip: {
                pointFormat: function () {
                    return false;
                },
                valueDecimals: 0
            },
            lineWidth: 2,

            step: true,
            yAxis: numero_asse
        },
        {
            id: 'ch2_val_series',
            name: TimeOut_L_label,
            data: array_TimeOut_L,
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
                        return 'ON';
                    }
                    else {
                        return 'OFF';
                    }
                }
            },

            title: {
                text: TimeOut_L_label
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
    if (($('#Service_F_L').is(':checked')) && (counter_series < 10)) {
        series_chart.push({
            id: 'ch3_val_series',
            name: Service_F_L_label,
            data: array_Service_F_L,
            type: 'scatter',
            tooltip: {
                pointFormat: function () {
                    return false;
                },
                valueDecimals: 0
            },
            lineWidth: 2,

            step: true,
            yAxis: numero_asse
        },
        {
            id: 'ch2_val_series',
            name: Service_F_L_label,
            data: array_Service_F_L,
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
                        return 'ON';
                    }
                    else {
                        return 'OFF';
                    }
                }
            },

            title: {
                text: Service_F_L_label
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
    if (($('#Level_SW').is(':checked')) && (counter_series < 10)) {
        series_chart.push({
            id: 'ch3_val_series',
            name: Level_SW_label,
            data: array_Level_SW,
            type: 'scatter',
            tooltip: {
                pointFormat: function () {
                    return false;
                },
                valueDecimals: 0
            },
            lineWidth: 2,

            step: true,
            yAxis: numero_asse
        },
        {
            id: 'ch2_val_series',
            name: Level_SW_label,
            data: array_Level_SW,
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
                        return 'ON';
                    }
                    else {
                        return 'OFF';
                    }
                }
            },

            title: {
                text: Level_SW_label
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
    if (($('#BypassB').is(':checked')) && (counter_series < 10)) {
        series_chart.push({
            id: 'ch3_val_series',
            name: BypassB_label,
            data: array_BypassB,
            type: 'scatter',
            tooltip: {
                pointFormat: function () {
                    return false;
                },
                valueDecimals: 0
            },
            lineWidth: 2,

            step: true,
            yAxis: numero_asse
        },
        {
            id: 'ch2_val_series',
            name: BypassB_label,
            data: array_BypassB,
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
                        return 'ON';
                    }
                    else {
                        return 'OFF';
                    }
                }
            },

            title: {
                text: BypassB_label
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
    if (($('#Lim_Dioxide').is(':checked')) && (counter_series < 10)) {
        series_chart.push({
            id: 'ch3_val_series',
            name: Lim_Dioxide_label,
            data: array_Lim_Dioxide,
            type: 'scatter',
            tooltip: {
                pointFormat: function () {
                    return false;
                },
                valueDecimals: 0
            },
            lineWidth: 2,

            step: true,
            yAxis: numero_asse
        },
        {
            id: 'ch2_val_series',
            name: Lim_Dioxide_label,
            data: array_Lim_Dioxide,
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
                        return 'ON';
                    }
                    else {
                        return 'OFF';
                    }
                }
            },

            title: {
                text: Lim_Dioxide_label
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
    if (($('#Lev_Alflow').is(':checked')) && (counter_series < 10)) {
        series_chart.push({
            id: 'ch3_val_series',
            name: Lev_Alflow_label,
            data: array_Lev_Alflow,
            type: 'scatter',
            tooltip: {
                pointFormat: function () {
                    return false;
                },
                valueDecimals: 0
            },
            lineWidth: 2,

            step: true,
            yAxis: numero_asse
        },
        {
            id: 'ch2_val_series',
            name: Lev_Alflow_label,
            data: array_Lev_Alflow,
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
                        return 'ON';
                    }
                    else {
                        return 'OFF';
                    }
                }
            },

            title: {
                text: Lev_Alflow_label
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
    //canale ch2
    if (($('#flow1').is(':checked')) && (counter_series < 10)) {

        series_chart.push({
            name: flow1_label,
            id: 'flow_series',
            data: array_m3h,
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
                text: flow1_label
            },
            opposite: false,
            id: 'flow_y_val',
            top: altezza,
            height: 200,
            lineWidth: 2
        });
        altezza = altezza + 300;
        numero_asse = numero_asse + 1;
        counter_series = counter_series + 1;
    }
    if (($('#clo2').is(':checked')) && (counter_series < 10)) {

        series_chart.push({
            name: clo2_label,
            id: 'clo2_series',
            data: array_lettura,
            yAxis: numero_asse,
            marker: {
                enabled: true,
                radius: 3
            },
            tooltip: {
                valueDecimals: 3
            }
        });
        yaxis_chart.push({
            title: {
                text: clo2_label
            },
            opposite: false,
            id: 'clo2_y_val',
            top: altezza,
            height: 200,
            lineWidth: 2
        });
        altezza = altezza + 300;
        numero_asse = numero_asse + 1;
        counter_series = counter_series + 1;
    }
    if (($('#naso').is(':checked')) && (counter_series < 10)) {

        series_chart.push({
            name: naso_label,
            id: 'naso_series',
            data: array_naso,
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
                text: naso_label
            },
            opposite: false,
            id: 'naso_y_val',
            top: altezza,
            height: 200,
            lineWidth: 2
        });
        altezza = altezza + 300;
        numero_asse = numero_asse + 1;
        counter_series = counter_series + 1;
    }
    
    if (($('#temperature_lt').is(':checked')) && (counter_series < 10)) {

        series_chart.push({
            name: temperature_lt_label,
            id: 'temperature_series',
            data: array_temp_lt,
            yAxis: numero_asse,
            marker: {
                enabled: true,
                radius: 3
            },
            tooltip: {
                valueDecimals: 1
            }
        });
        yaxis_chart.push({
            title: {
                text: temperature_lt_label
            },
            opposite: false,
            id: 'temperature_y_val',
            top: altezza,
            height: 200,
            lineWidth: 2
        });
        altezza = altezza + 300;
        numero_asse = numero_asse + 1;
        counter_series = counter_series + 1;
    }
    
    
    if (($('#MinMax').is(':checked')) && (counter_series < 10)) {
        series_chart.push({
            id: 'ch3_val_series',
            name: MinMax_Label,
            data: array_minmax,
            type: 'scatter',
            tooltip: {
                pointFormat: function () {
                    return false;
                },
                valueDecimals: 0
            },
            lineWidth: 2,

            step: true,
            yAxis: numero_asse
        },
        {
            id: 'ch2_val_series',
            name: MinMax_Label,
            data: array_minmax,
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
                        return 'ON';
                    }
                    else {
                        return 'OFF';
                    }
                }
            },

            title: {
                text: MinMax_Label
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
    oggetto = { "title": "Date" }
    header_array.push(oggetto)
    var date2_ms = parseDate(last_date, 'dd/mm/yy');
    var date1_ms = parseDate(init_date, 'dd/mm/yy');



    $.each(series_chart, function (row, series_chart_temp) {
        // if ((series_chart_temp.name != "Navigator") && (series_chart_temp.name != string_array_precedent)) {
        if ((series_chart_temp.name.indexOf("Navigator") < 0) && ((series_chart_temp.type != "scatter"))) {
            // if (string_array == "") {
            // string_array = string_array + '[{ "title": "' + series_chart_temp.name + '" }'
            //string_array = string_array + '"title": "' + series_chart_temp.name + '"'
            oggetto = { "title": series_chart_temp.name };
            header_array.push(oggetto);

            //header_value.push(point.);
        }
        string_array_precedent = series_chart_temp.name;
    });
    i = array_Lev_Acid_L.length - 1;
    $.each(array_Lev_Acid_L, function (row1, point1) {
        var array_temp = [];
        var date = new Date(array_Lev_Acid_L[i][0]);
        date = convertUTCDateToLocalDate(date);


        var theyear = date.getFullYear()
        var themonth = date.getMonth() + 1;
        var thetoday = date.getDate();
        var ore = date.getHours();
        var minuti = date.getMinutes();
        var data_confronto = parseDate(thetoday + "/" + themonth + "/" + theyear, 'dd/mm/yy');

        /*var data_stringa = date.toString("dd/MM/yy");
        var data_finale = parseDate(data_stringa, 'dd/mm/yy');
        alert(data_finale);
        array_temp.push(data_finale.toString("dd/MM/yy"));
        */
        //alert(theyear + "/" + themonth + "/" + thetoday);
        if ((data_confronto >= date1_ms) && (data_confronto <= date2_ms)) {
            if (formato_data != "2") {// ' europeo
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

                array_temp.push(get_numero_string(thetoday) + "/" + get_numero_string(themonth) + "/" + get_numero_string(theyear) + " " + get_numero_string(ore) + ":" + get_numero_string(minuti) + " " + suffex);
            }
            if (($('#Lev_Acid_L').is(':checked'))) {
                array_temp.push(on_off(array_Lev_Acid_L[i][1]));
            }
            if (($('#Flow_Acid_L').is(':checked'))) {
                array_temp.push(on_off(array_Flow_Acid_L[i][1]));
            }
            if (($('#Flow_Self_Water_L').is(':checked'))) {
                array_temp.push(on_off(array_Flow_Self_Water_L[i][1]));
            }
            if (($('#Lev_Water_L').is(':checked'))) {
                array_temp.push(on_off(array_Lev_Water_L[i][1]));
            }
            if (($('#Flow_Chlorite_L').is(':checked'))) {
                array_temp.push(on_off(array_Flow_Chlorite_L[i][1]));
            }
            if (($('#Lev_Chlorite_L').is(':checked'))) {
                array_temp.push(on_off(array_Lev_Chlorite_L[i][1]));
            }


            if (($('#Overf').is(':checked'))) {
                array_temp.push(on_off(array_Overf[i][1]));
            }
            if (($('#Flow_Water_dil_L').is(':checked'))) {
                array_temp.push(on_off(array_Flow_Water_dil_L[i][1]));
            }
            if (($('#TimeOut_L').is(':checked'))) {
                array_temp.push(on_off(array_TimeOut_L[i][1]));
            }

            if (($('#Service_F_L').is(':checked'))) {
                array_temp.push(on_off(array_Service_F_L[i][1]));
            }
            if (($('#Level_SW').is(':checked'))) {
                array_temp.push(on_off(array_Level_SW[i][1]));
            }
            if (($('#BypassB').is(':checked'))) {
                array_temp.push(on_off(array_BypassB[i][1]));
            }
            if (($('#Lim_Dioxide').is(':checked'))) {
                array_temp.push(on_off(array_Lim_Dioxide[i][1]));
            }

            if (($('#Lev_Alflow').is(':checked'))) {
                array_temp.push(on_off(array_Lev_Alflow[i][1]));
            }
            if (($('#flow1').is(':checked'))) {
                array_temp.push(array_m3h[i][1]);
            }
            if (($('#clo2').is(':checked'))) {
                array_temp.push(array_lettura[i][1]);
            }
            if (($('#naso').is(':checked'))) {
                array_temp.push(array_naso[i][1]);
            }
            if (($('#temperature_lt').is(':checked'))) {
                array_temp.push(array_temp_lt[i][1]);
            }

            if (($('#MinMax').is(':checked'))) {
                array_temp.push(on_off(array_minmax[i][1]));
            }


            header_value.push(array_temp);
        }
        i = i - 1;
    });

    // header_array.push(string_array);
    $('#chart_table').html('<table cellpadding="0" cellspacing="0" border="0" class="display dynamicTable table table-striped table-bordered table-condensed" id="example"></table>');

    /*  $('#example').dataTable({
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
        return "0" + numero_valore.toString();
    else
        return numero_valore.toString();
}
function on_off(ingresso) {
    if (ingresso == 1)
        return "ON"
    else
        return "OFF"
}
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

});
var primo = 0;
var from_difference = 0;
var to_difference = 0;

var array_ch1=[];
var array_ch2=[];

var array_ch3=[];

var array_ch4=[];
var array_ch5=[];
var array_aa1=[];
var array_aa2=[];
var array_aa3=[];
var array_aa4=[];
var array_aa5=[];
var array_ab1=[];
var array_ab2=[];
var array_ab3=[];
var array_ab4=[];
var array_ab5=[];
var array_ad1=[];
var array_ad2=[];
var array_ad3=[];
var array_ad4=[];
var array_ad5=[];
var array_ar1=[];
var array_ar2=[];
var array_ar3=[];
var array_ar4=[];
var array_ar5=[];
var array_flow = [];
var array_stby = [];
var array_temperatura=[];
var array_fml=[];
var array_wm=[];

var array_da1=[];
var array_db1=[];
var array_pa1=[];
var array_pb1=[];
var array_ma1=[];

var array_da2=[];
var array_db2=[];
var array_pa2=[];
var array_pb2=[];
var array_ma2=[];

var array_da3=[];
var array_db3=[];
var array_pa3=[];
var array_pb3=[];
var array_ma3=[];

var array_da4=[];
var array_db4=[];
var array_pa4=[];
var array_pb4=[];
var array_ma4=[];

var array_da5=[];
var array_db5=[];
var array_pa5=[];
var array_pb5=[];
var array_ma5 = [];


var myFunction_log;

/*var data_chart1 = [{ x: Date.UTC(2013, 1, 1, 08, 30), y: 0 ,name: 'Off'},
    { x: Date.UTC(2013, 2, 1, 10, 00), y: 0, name: 'Off' },
    {x:Date.UTC(2013, 3, 1, 16, 00), y:1, name: 'ON'}, 
    { x: Date.UTC(2013, 3, 5, 16, 00), y: 1, name: 'ON' },
    { x: Date.UTC(2013, 4, 1, 16, 00), y: 0, name: 'off' }];*/


/*[{
name: 'pH',
id: 'dataseries',
data: data_chart,
marker: {
    enabled: true,
    radius: 3
},
tooltip: {
    valueDecimals: 2
}
},
        {
            type: 'flags',
            data: [{
                x: Date.UTC(2013, 2, 1, 10, 00),

                title: 'OFF',
                text: 'Power OFF'
            }, {
                x: Date.UTC(2013, 3, 1, 16, 00),

                title: 'OFF',
                text: 'Power OFF'
            }],
            color: '#5F86B3',
            fillColor: '#5F86B3',
            onSeries: 'dataseries',
            width: 22,
            style: {// text style
                color: 'white'
            },
            states: {
                hover: {
                    fillColor: '#395C84' // darker
                }
            }
        }];*/
/*var series_chart1 = [{
    type: 'column',
    name: 'Volume',
    data: data_chart1,
    yAxis: 1,

}];*/
/*[{
name: 'pH',
id: 'dataseries',
data: data_chart1,
marker: {
    enabled: true,
    radius: 3
},
yAxis: 1,
tooltip: {
    valueDecimals: 2
}
},
        {
            type: 'flags',
            data: [{
                x: Date.UTC(2013, 2, 1, 10, 00),

                title: 'OFF',
                text: 'Power OFF'
            }, {
                x: Date.UTC(2013, 3, 1, 16, 00),

                title: 'OFF',
                text: 'Power OFF'
            }],
            color: '#5F86B3',
            fillColor: '#5F86B3',
            onSeries: 'dataseries',
            width: 22,
            style: {// text style
                color: 'white'
            },
            states: {
                hover: {
                    fillColor: '#395C84' // darker
                }
            }
        }];*/


function get_data(parametro1, parametro2, parametro3, parametro4, parametro5) {
    
    $.ajax({
        type: "POST",
        url: "chart/log_metod.aspx/get_log_max5",
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

                array_ch4.push([data, parseFloat(res[8])]);
                array_ch5.push([data, parseFloat(res[9])]);
                array_aa1.push([data, parseInt(res[10])]);
                 array_aa2.push([data, parseInt(res[11])]);
                 array_aa3.push([data, parseInt(res[12])]);
                 array_aa4.push([data, parseInt(res[13])]);
                 array_aa5.push([data, parseInt(res[14])]);
                 array_ab1.push([data, parseInt(res[15])]);
                 array_ab2.push([data, parseInt(res[16])]);
                 array_ab3.push([data, parseInt(res[17])]);
                 array_ab4.push([data, parseInt(res[18])]);
                 array_ab5.push([data, parseInt(res[19])]);
                 array_ad1.push([data, parseInt(res[20])]);
                 array_ad2.push([data, parseInt(res[21])]);
                 array_ad3.push([data, parseInt(res[22])]);
                 array_ad4.push([data, parseInt(res[23])]);
                 array_ad5.push([data, parseInt(res[24])]);
                 array_ar1.push([data, parseInt(res[25])]);
                 array_ar2.push([data, parseInt(res[26])]);
                 array_ar3.push([data, parseInt(res[27])]);
                 array_ar4.push([data, parseInt(res[28])]);
                 array_ar5.push([data, parseInt(res[29])]);
                 array_flow.push([data, parseInt(res[30])]);
                 array_temperatura.push([data, parseFloat(res[31])]);
                 array_fml.push([data, parseInt(res[32])]);
                 array_wm.push([data, parseInt(res[33])]);

                 array_da1.push([data, parseInt(res[34])]);
                 array_db1.push([data, parseInt(res[35])]);
                 array_pa1.push([data, parseInt(res[36])]);
                 array_pb1.push([data, parseInt(res[37])]);
                 array_ma1.push([data, parseFloat(res[38])]);

                 array_da2.push([data, parseInt(res[39])]);
                 array_db2.push([data, parseInt(res[40])]);
                 array_pa2.push([data, parseInt(res[41])]);
                 array_pb2.push([data, parseInt(res[42])]);
                 array_ma2.push([data, parseFloat(res[43])]);

                 array_da3.push([data, parseInt(res[44])]);
                 array_db3.push([data, parseInt(res[45])]);
                 array_pa3.push([data, parseInt(res[46])]);
                 array_pb3.push([data, parseInt(res[47])]);
                 array_ma3.push([data, parseFloat(res[48])]);

                 array_da4.push([data, parseInt(res[49])]);
                 array_db4.push([data, parseInt(res[50])]);
                 array_pa4.push([data, parseInt(res[51])]);
                 array_pb4.push([data, parseInt(res[52])]);
                 array_ma4.push([data, parseFloat(res[53])]);

                 array_da5.push([data, parseInt(res[54])]);
                 array_db5.push([data, parseInt(res[55])]);
                 array_pa5.push([data, parseInt(res[56])]);
                 array_pb5.push([data, parseInt(res[57])]);
                 array_ma5.push([data, parseFloat(res[58])]);

                 array_stby.push([data, parseInt(res[59])]);
            });
            upgrate_chart();
        },
        failure: function (response) {
            alert(response.d);
        }

    });
    
}

function salva_dati_log(callback) {
    myFunction_log = new Function(callback);
    myFunction_log();
}

function create_chart(dati, yAxis, plot_option) {
    
    $('#chart_div').highcharts('StockChart', {


        rangeSelector: {
            enabled: false
        },

        title: {
            text: graph_log
        },
        /*xAxis: {
            min: Date.UTC(data1.getFullYear(), data1.getMonth(), data1.getDate()),
            max: Date.UTC(data2.getFullYear(), data2.getMonth(), data2.getDate())
        },*/
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
    $("#form_log").attr("action", "chart/log_max5.aspx?init_date=" + init_date + "&last_date=" + last_date)
    return true;
}


function daydiff(first, second) {
    return (second - first) / (1000 * 60 * 60 * 24);
}
// Set the datepicker's date format
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
    //alert(stringa);
    //alert(name_coockie);
    $.cookie(name_coockie, stringa, { expires: 365 });
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
            },
            tooltip: {
                valueDecimals: 2
            }
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
    //-----------------------------------------------------------------------------------------------
    //digitale
    if (($('#ch1_da').is(':checked')) && (counter_series < 10)) {
        series_chart.push({
            name: ch1_da_label,
            id: 'ch2_val_series',
            data: array_da1,
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
            id: 'flow_select_series1',
            name: ch1_da_label,
            data: array_da1,
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
        }
        );
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
                text: ch1_da_label
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
    if (($('#ch1_db').is(':checked')) && (counter_series < 10)) {
        series_chart.push({
            name: ch1_db_label,
            id: 'ch2_val_series',
            data: array_db1,
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
            id: 'flow_select_series1',
            name: ch1_db_label,
            data: array_db1,
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
        }
        );
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
                text: ch1_db_label
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
    //---------------proporzionale
    if (($('#ch1_pa').is(':checked')) && (counter_series < 10)) {

        series_chart.push({
            name: ch1_pa_label,
            id: 'ch6_val_series',
            data: array_pa1,
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
                text: ch1_pa_label
            },
            opposite: false,
            id: 'ch1_val',
            top: altezza,
            height: 150,
            lineWidth: 2
        });

        altezza = altezza + 200;
        numero_asse = numero_asse + 1;
        counter_series = counter_series + 1;
    }
    if (($('#ch1_pb').is(':checked')) && (counter_series < 10)) {

        series_chart.push({
            name: ch1_pb_label,
            id: 'ch6_val_series',
            data: array_pb1,
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
                text: ch1_pb_label
            },
            opposite: false,
            id: 'ch1_val',
            top: altezza,
            height: 150,
            lineWidth: 2
        });

        altezza = altezza + 200;
        numero_asse = numero_asse + 1;
        counter_series = counter_series + 1;
    }
    if (($('#ch1_ma').is(':checked')) && (counter_series < 10)) {

        series_chart.push({
            name: ch1_ma_label,
            id: 'ch6_val_series',
            data: array_ma1,
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
                text: ch1_ma_label
            },
            opposite: false,
            id: 'ch1_val',
            top: altezza,
            height: 150,
            lineWidth: 2
        });

        altezza = altezza + 200;
        numero_asse = numero_asse + 1;
        counter_series = counter_series + 1;
    }
    //-------------------------------------------------------------------------------------------------
    if (($('#ch1_aa').is(':checked')) && (counter_series < 10)) {
        series_chart.push({
            name: ch1_aa_label,
            id: 'ch2_val_series',
            data: array_aa1,
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
        id: 'flow_select_series1',
        name: ch1_aa_label,
        data: array_aa1,
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
    }  
        );
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
                text: ch1_aa_label
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
    if (($('#ch1_ab').is(':checked')) && (counter_series < 10)) {
        series_chart.push({
            id: 'ch3_val_series',
            name: ch1_ab_label,
            data: array_ab1,
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
        }
        ,
        {
            id: 'flow_select_series1',
            name: ch1_ab_label,
            data: array_ab1,
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
            yAxis: numero_asse
        }
        );
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
                text: ch1_ab_label
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
    if (($('#ch1_ad').is(':checked')) && (counter_series < 10)) {
        series_chart.push({
            id: 'ch4_val_series',
            name: ch1_ad_label,
            data: array_ad1,
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
        }
        ,
        {
            id: 'flow_select_series1',
            name: ch1_ad_label,
            data: array_ad1,
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
            yAxis: numero_asse
        }
        );
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
                text: ch1_ad_label
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
    if (($('#ch1_ar').is(':checked')) && (counter_series < 10)) {
        series_chart.push({
            id: 'ch5_val_series',
            name: ch1_ar_label,
            data: array_ar1,
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
            id: 'flow_select_series1',
            name: ch1_ar_label,
            data: array_ar1,
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
            yAxis: numero_asse
        } 
        );
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
                text: ch1_ar_label
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
    //-----------------------------------------------------------------------------------------------
    //digitale
    if (($('#ch2_da').is(':checked')) && (counter_series < 10)) {
        series_chart.push({
            name: ch2_da_label,
            id: 'ch2_val_series',
            data: array_da2,
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
            id: 'flow_select_series1',
            name: ch2_da_label,
            data: array_da2,
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
        }
        );
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
                text: ch2_da_label
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
    if (($('#ch2_db').is(':checked')) && (counter_series < 10)) {
        series_chart.push({
            name: ch2_db_label,
            id: 'ch2_val_series',
            data: array_db2,
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
            id: 'flow_select_series1',
            name: ch2_db_label,
            data: array_db2,
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
        }
        );
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
                text: ch2_db_label
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
    //---------------proporzionale
    if (($('#ch2_pa').is(':checked')) && (counter_series < 10)) {

        series_chart.push({
            name: ch2_pa_label,
            id: 'ch6_val_series',
            data: array_pa2,
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
                text: ch2_pa_label
            },
            opposite: false,
            id: 'ch1_val',
            top: altezza,
            height: 150,
            lineWidth: 2
        });

        altezza = altezza + 200;
        numero_asse = numero_asse + 1;
        counter_series = counter_series + 1;
    }
    if (($('#ch2_pb').is(':checked')) && (counter_series < 10)) {

        series_chart.push({
            name: ch2_pb_label,
            id: 'ch6_val_series',
            data: array_pb2,
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
                text: ch2_pb_label
            },
            opposite: false,
            id: 'ch1_val',
            top: altezza,
            height: 150,
            lineWidth: 2
        });

        altezza = altezza + 200;
        numero_asse = numero_asse + 1;
        counter_series = counter_series + 1;
    }
    if (($('#ch2_ma').is(':checked')) && (counter_series < 10)) {

        series_chart.push({
            name: ch2_ma_label,
            id: 'ch6_val_series',
            data: array_ma2,
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
                text: ch2_ma_label
            },
            opposite: false,
            id: 'ch1_val',
            top: altezza,
            height: 150,
            lineWidth: 2
        });

        altezza = altezza + 200;
        numero_asse = numero_asse + 1;
        counter_series = counter_series + 1;
    }
    //-------------------------------------------------------------------------------------------------
    //allarmi
    if (($('#ch2_aa').is(':checked')) && (counter_series < 10)) {
        series_chart.push({
            name: ch2_aa_label,
            id: 'ch2_val_series',
            data: array_aa2,
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
        }
        ,
        {
            id: 'flow_select_series1',
            name: ch2_aa_label,
            data: array_aa2,
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
            yAxis: numero_asse
        }
        );
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
                text: ch2_aa_label
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
    if (($('#ch2_ab').is(':checked')) && (counter_series < 10)) {
        series_chart.push({
            id: 'ch3_val_series',
            name: ch2_ab_label,
            data: array_ab2,
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
        }
        ,
        {
            id: 'flow_select_series1',
            name: ch2_ab_label,
            data: array_ab2,
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
            yAxis: numero_asse
        }
        );
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
                text: ch2_ab_label
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
    if (($('#ch2_ad').is(':checked')) && (counter_series < 10)) {
        series_chart.push({
            id: 'ch4_val_series',
            name: ch2_ad_label,
            data: array_ad2,
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
        }
        ,
        {
            id: 'flow_select_series1',
            name: ch2_ad_label,
            data: array_ad2,
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
            yAxis: numero_asse
        }
        );
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
                text: ch2_ad_label
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
    if (($('#ch2_ar').is(':checked')) && (counter_series < 10)) {
        series_chart.push({
            id: 'ch5_val_series',
            name: ch2_ar_label,
            data: array_ar2,
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
        }
        ,
        {
            id: 'flow_select_series1',
            name: ch2_ar_label,
            data: array_ar2,
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
            yAxis: numero_asse
        }
        );
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
                text: ch2_ar_label
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
    //-----------------------------------------------------------------------------------------------
    //digitale
    if (($('#ch3_da').is(':checked')) && (counter_series < 10)) {
        series_chart.push({
            name: ch3_da_label,
            id: 'ch2_val_series',
            data: array_da3,
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
            id: 'flow_select_series1',
            name: ch3_da_label,
            data: array_da3,
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
        }
        );
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
                text: ch3_da_label
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
    if (($('#ch3_db').is(':checked')) && (counter_series < 10)) {
        series_chart.push({
            name: ch3_db_label,
            id: 'ch2_val_series',
            data: array_db3,
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
            id: 'flow_select_series1',
            name: ch3_db_label,
            data: array_db3,
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
        }
        );
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
                text: ch3_db_label
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
    //---------------proporzionale
    if (($('#ch3_pa').is(':checked')) && (counter_series < 10)) {

        series_chart.push({
            name: ch3_pa_label,
            id: 'ch6_val_series',
            data: array_pa3,
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
                text: ch3_pa_label
            },
            opposite: false,
            id: 'ch1_val',
            top: altezza,
            height: 150,
            lineWidth: 2
        });

        altezza = altezza + 200;
        numero_asse = numero_asse + 1;
        counter_series = counter_series + 1;
    }
    if (($('#ch3_pb').is(':checked')) && (counter_series < 10)) {

        series_chart.push({
            name: ch3_pb_label,
            id: 'ch6_val_series',
            data: array_pb3,
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
                text: ch3_pb_label
            },
            opposite: false,
            id: 'ch1_val',
            top: altezza,
            height: 150,
            lineWidth: 2
        });

        altezza = altezza + 200;
        numero_asse = numero_asse + 1;
        counter_series = counter_series + 1;
    }
    if (($('#ch3_ma').is(':checked')) && (counter_series < 10)) {

        series_chart.push({
            name: ch3_ma_label,
            id: 'ch6_val_series',
            data: array_ma3,
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
                text: ch3_ma_label
            },
            opposite: false,
            id: 'ch1_val',
            top: altezza,
            height: 150,
            lineWidth: 2
        });

        altezza = altezza + 200;
        numero_asse = numero_asse + 1;
        counter_series = counter_series + 1;
    }
    //-------------------------------------------------------------------------------------------------
    //allarmi
    if (($('#ch3_aa').is(':checked')) && (counter_series < 10)) {
        series_chart.push({
            name: ch3_aa_label,
            id: 'ch2_val_series',
            data: array_aa3,
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
        }
        ,
        {
            id: 'flow_select_series1',
            name: ch3_aa_label,
            data: array_aa3,
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
            yAxis: numero_asse
        }
        );
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
                text: ch3_aa_label
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
    if (($('#ch3_ab').is(':checked')) && (counter_series < 10)) {
        series_chart.push({
            id: 'ch3_val_series',
            name: ch3_ab_label,
            data: array_ab3,
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
        }
        ,
        {
            id: 'flow_select_series1',
            name: ch3_ab_label,
            data: array_ab3,
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
            yAxis: numero_asse
        }
        );
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
                text: ch3_ab_label
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
    if (($('#ch3_ad').is(':checked')) && (counter_series < 10)) {
        series_chart.push({
            id: 'ch4_val_series',
            name: ch3_ad_label,
            data: array_ad3,
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
        }
        ,
        {
            id: 'flow_select_series1',
            name: ch3_ad_label,
            data: array_ad3,
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
            yAxis: numero_asse
        }
        );
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
                text: ch3_ad_label
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
    if (($('#ch3_ar').is(':checked')) && (counter_series < 10)) {
        series_chart.push({
            id: 'ch5_val_series',
            name: ch3_ar_label,
            data: array_ar3,
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
        }
        ,
        {
            id: 'flow_select_series1',
            name: ch3_ar_label,
            data: array_ar3,
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
            yAxis: numero_asse
        }
        );
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
                text: ch3_ar_label
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
    if (($('#ch4_val').is(':checked')) && (counter_series < 10)) {

        series_chart.push({
            name: label_ch4,
            id: 'ch6_val_series',
            data: array_ch4,
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
                text: label_ch4
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
    //-----------------------------------------------------------------------------------------------
    //digitale
    if (($('#ch4_da').is(':checked')) && (counter_series < 10)) {
        series_chart.push({
            name: ch4_da_label,
            id: 'ch2_val_series',
            data: array_da4,
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
            id: 'flow_select_series1',
            name: ch4_da_label,
            data: array_da4,
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
        }
        );
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
                text: ch4_da_label
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
    if (($('#ch4_db').is(':checked')) && (counter_series < 10)) {
        series_chart.push({
            name: ch4_db_label,
            id: 'ch2_val_series',
            data: array_db4,
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
            id: 'flow_select_series1',
            name: ch4_db_label,
            data: array_db4,
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
        }
        );
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
                text: ch4_db_label
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
    //---------------proporzionale
    if (($('#ch4_pa').is(':checked')) && (counter_series < 10)) {

        series_chart.push({
            name: ch4_pa_label,
            id: 'ch6_val_series',
            data: array_pa4,
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
                text: ch4_pa_label
            },
            opposite: false,
            id: 'ch1_val',
            top: altezza,
            height: 150,
            lineWidth: 2
        });

        altezza = altezza + 200;
        numero_asse = numero_asse + 1;
        counter_series = counter_series + 1;
    }
    if (($('#ch4_pb').is(':checked')) && (counter_series < 10)) {

        series_chart.push({
            name: ch4_pb_label,
            id: 'ch6_val_series',
            data: array_pb4,
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
                text: ch4_pb_label
            },
            opposite: false,
            id: 'ch1_val',
            top: altezza,
            height: 150,
            lineWidth: 2
        });

        altezza = altezza + 200;
        numero_asse = numero_asse + 1;
        counter_series = counter_series + 1;
    }
    if (($('#ch4_ma').is(':checked')) && (counter_series < 10)) {

        series_chart.push({
            name: ch4_ma_label,
            id: 'ch6_val_series',
            data: array_ma4,
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
                text: ch4_ma_label
            },
            opposite: false,
            id: 'ch1_val',
            top: altezza,
            height: 150,
            lineWidth: 2
        });

        altezza = altezza + 200;
        numero_asse = numero_asse + 1;
        counter_series = counter_series + 1;
    }
    //-------------------------------------------------------------------------------------------------
    //allarmi
    if (($('#ch4_aa').is(':checked')) && (counter_series < 10)) {
        series_chart.push({
            name: ch4_aa_label,
            id: 'ch2_val_series',
            data: array_aa4,
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
        }
        ,
        {
            id: 'flow_select_series1',
            name: ch4_aa_label,
            data: array_aa4,
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
            yAxis: numero_asse
        }
        );
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
                text: ch4_aa_label
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
    if (($('#ch4_ab').is(':checked')) && (counter_series < 10)) {
        series_chart.push({
            id: 'ch3_val_series',
            name: ch4_ab_label,
            data: array_ab4,
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
        }
        ,
        {
            id: 'flow_select_series1',
            name: ch4_ab_label,
            data: array_ab4,
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
            yAxis: numero_asse
        }
        );
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
                text: ch4_ab_label
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
    if (($('#ch4_ad').is(':checked')) && (counter_series < 10)) {
        series_chart.push({
            id: 'ch4_val_series',
            name: ch4_ad_label,
            data: array_ad4,
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
        }
        ,
        {
            id: 'flow_select_series1',
            name: ch4_ad_label,
            data: array_ad4,
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
            yAxis: numero_asse
        }
        );
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
                text: ch4_ad_label
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
    if (($('#ch4_ar').is(':checked')) && (counter_series < 10)) {
        series_chart.push({
            id: 'ch5_val_series',
            name: ch4_ar_label,
            data: array_ar4,
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
        }
        ,
        {
            id: 'flow_select_series1',
            name: ch4_ar_label,
            data: array_ar4,
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
            yAxis: numero_asse
        }
        );
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
                text: ch4_ar_label
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
    //end  canale ch4
    //canale ch5
    if (($('#ch5_val').is(':checked')) && (counter_series < 10)) {

        series_chart.push({
            name: label_ch5,
            id: 'ch6_val_series',
            data: array_ch5,
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
                text: label_ch5
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
    //-----------------------------------------------------------------------------------------------
    //digitale
    if (($('#ch5_da').is(':checked')) && (counter_series < 10)) {
        series_chart.push({
            name: ch5_da_label,
            id: 'ch2_val_series',
            data: array_da5,
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
            id: 'flow_select_series1',
            name: ch5_da_label,
            data: array_da5,
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
        }
        );
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
                text: ch5_da_label
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
    if (($('#ch5_db').is(':checked')) && (counter_series < 10)) {
        series_chart.push({
            name: ch5_db_label,
            id: 'ch2_val_series',
            data: array_db5,
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
            id: 'flow_select_series1',
            name: ch5_db_label,
            data: array_db5,
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
        }
        );
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
                text: ch5_db_label
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
    //---------------proporzionale
    if (($('#ch5_pa').is(':checked')) && (counter_series < 10)) {

        series_chart.push({
            name: ch5_pa_label,
            id: 'ch6_val_series',
            data: array_pa5,
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
                text: ch5_pa_label
            },
            opposite: false,
            id: 'ch1_val',
            top: altezza,
            height: 150,
            lineWidth: 2
        });

        altezza = altezza + 200;
        numero_asse = numero_asse + 1;
        counter_series = counter_series + 1;
    }
    if (($('#ch5_pb').is(':checked')) && (counter_series < 10)) {

        series_chart.push({
            name: ch5_pb_label,
            id: 'ch6_val_series',
            data: array_pb5,
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
                text: ch5_pb_label
            },
            opposite: false,
            id: 'ch1_val',
            top: altezza,
            height: 150,
            lineWidth: 2
        });

        altezza = altezza + 200;
        numero_asse = numero_asse + 1;
        counter_series = counter_series + 1;
    }
    if (($('#ch5_ma').is(':checked')) && (counter_series < 10)) {

        series_chart.push({
            name: ch5_ma_label,
            id: 'ch6_val_series',
            data: array_ma5,
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
                text: ch5_ma_label
            },
            opposite: false,
            id: 'ch1_val',
            top: altezza,
            height: 150,
            lineWidth: 2
        });

        altezza = altezza + 200;
        numero_asse = numero_asse + 1;
        counter_series = counter_series + 1;
    }
    //-------------------------------------------------------------------------------------------------
    if (($('#ch5_aa').is(':checked')) && (counter_series < 10)) {
        series_chart.push({
            name: ch5_aa_label,
            id: 'ch2_val_series',
            data: array_aa5,
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
        }
        ,
        {
            id: 'flow_select_series1',
            name: ch5_aa_label,
            data: array_aa5,
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
            yAxis: numero_asse
        }
        );
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
                text: ch5_aa_label
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
    if (($('#ch5_ab').is(':checked')) && (counter_series < 10)) {
        series_chart.push({
            id: 'ch3_val_series',
            name: ch5_ab_label,
            data: array_ab5,
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
        }
        ,
        {
            id: 'flow_select_series1',
            name: ch5_ab_label,
            data: array_ab5,
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
            yAxis: numero_asse
        }
        );
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
                text: ch5_ab_label
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
    if (($('#ch5_ad').is(':checked')) && (counter_series < 10)) {
        series_chart.push({
            id: 'ch4_val_series',
            name: ch5_ad_label,
            data: array_ad5,
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
        }
        ,
        {
            id: 'flow_select_series1',
            name: ch5_ad_label,
            data: array_ad5,
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
            yAxis: numero_asse
        }
        );
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
                text: ch5_ad_label
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
    if (($('#ch5_ar').is(':checked')) && (counter_series < 10)) {
        series_chart.push({
            id: 'ch5_val_series',
            name: ch5_ar_label,
            data: array_ar5,
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
        }
        ,
        {
            id: 'flow_select_series1',
            name: ch5_ar_label,
            data: array_ar5,
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
            yAxis: numero_asse
        }
        );
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
                text: ch5_ar_label
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
    //end  canale ch5
    //TEMPERATURA
    if (($('#temperature_select').is(':checked')) && (counter_series < 10)) {

        series_chart.push({
            name: temperature_label,
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
                text: temperature_label
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
    if (((doppiaPiscina == true) && ($('#temperature_select2').is(':checked'))) && (counter_series < 10)) {

        series_chart.push({
            name: temperature_label2,
            id: 'cht2_val_series',
            data: array_ch5,
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
                text: temperature_label2
            },
            opposite: false,
            id: 'cht2_val',
            top: altezza,
            height: 200,
            lineWidth: 2
        });

        altezza = altezza + 300;
        numero_asse = numero_asse + 1;
        counter_series = counter_series + 1;
    }
    if ((yagel_personalizzazione == "true") && ($('#flow_meter_low').is(':checked')) && (counter_series < 10)) {
        series_chart.push({
            id: 'ch5_val_series',
            name: 'Flow Meter Low',
            data: array_fml,
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
        }
        ,
        {
            id: 'flow_select_series1',
            name: 'Flow Meter Low',
            data: array_fml,
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
            yAxis: numero_asse
        }
        );
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
                text: 'Flow Meter Low'
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
  
    if (($('#flow_meter').is(':checked')) && (counter_series < 10)) {

        series_chart.push({
            name: "Flow Meter",
            id: 'ch6_val_series',
            data: array_wm,
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
                text: flow_meter_label
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

    if (($('#flow_select').is(':checked')) && (counter_series < 10)) {
    
        series_chart.push({
            id: 'flow_select_series',
            name: label_flow_select,
            data: array_flow,
            type: 'scatter',
            tooltip: {
                pointFormat: function () {
                    return false;
                },
                valueDecimals: 0
            },

            step: true,

            lineWidth: 2,
            yAxis: numero_asse/*,
            formatter: function () {
                colore = this.series.color;
            }*/
        },
{
    id: 'flow_select_series1',
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
    yAxis: numero_asse
}   );
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
    if (((doppiaPiscina == true) && ($('#flow_select2').is(':checked'))) && (counter_series < 10)) {
        series_chart.push({
            id: 'flow_select_series',
            name: label_flow_select2,
            data: array_stby,
            type: 'scatter',
            tooltip: {
                pointFormat: function () {
                    return false;
                },
                valueDecimals: 0
            },

            step: true,

            lineWidth: 2,
            yAxis: numero_asse/*,
            formatter: function () {
                colore = this.series.color;
            }*/
        },
{
    id: 'flow_select_series2',
    name: label_flow_select2,
    data: array_stby,
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
                text: label_flow_select2
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
function convertUTCDateToLocalDate(convertdLocalTime)
    {
    

        var hourOffset = convertdLocalTime.getTimezoneOffset() / 60;

        convertdLocalTime.setHours( convertdLocalTime.getHours() + hourOffset ); 

        return convertdLocalTime;
    }function draw_tabella() {

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
        //if ((series_chart_temp.name != "Navigator") && (series_chart_temp.name != string_array_precedent)) {
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
    i = array_ch1.length - 1;
    
    $.each(array_ch1, function (row1, point1) {
        var array_temp = [];
        var date = new Date(array_ch1[i][0]);
        date = convertUTCDateToLocalDate(date);

        var theyear = date.getFullYear()
        var themonth = date.getMonth() + 1;
        var thetoday = date.getDate();
        var ore = date.getHours() ;
        var minuti = date.getUTCMinutes();
   
        var data_confronto = parseDate(thetoday + "/" + themonth + "/" + theyear, 'dd/mm/yy');
        
        /*var data_stringa = date.toString("dd/MM/yy");
        var data_finale = parseDate(data_stringa, 'dd/mm/yy');
        alert(data_finale);
        array_temp.push(data_finale.toString("dd/MM/yy"));
        */
        //alert(theyear + "/" + themonth + "/" + thetoday);
        if ((data_confronto >= date1_ms) && (data_confronto <= date2_ms)) {
            var date_complete = "";
            if (date_format == '0') {//gg-mm-aa
                date_complete = get_numero_string(thetoday) + "/" + get_numero_string(themonth) + "/" + get_numero_string(theyear);
            }
            if (date_format == '1') {//mm-gg-aa
                date_complete = get_numero_string(themonth) + "/" + get_numero_string(thetoday) + "/" + get_numero_string(theyear);
            }
            if (date_format == '2') {//aa-mm-gg
                date_complete = get_numero_string(theyear) + "/" + get_numero_string(themonth) + "/" + get_numero_string(thetoday);
            }
            if (time_format == '1') {// formato 12
                // var suffex = (ore >= 12)? 'pm' : 'am';
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
                
                date_complete = date_complete + " " + get_numero_string(ore) + ":" + get_numero_string(minuti)  + " " + suffex;
                }
            else
            {
                date_complete = date_complete + " " + get_numero_string(ore) + ":" + get_numero_string(minuti)
                }
            array_temp.push(date_complete);
            //------------------------ch1
            if (($('#ch1_val').is(':checked'))) {
                array_temp.push(array_ch1[i][1]);
            }
            if (($('#ch1_da').is(':checked'))) {
                array_temp.push(on_off(array_da1[i][1]));
            }
            if (($('#ch1_db').is(':checked'))) {
                array_temp.push(on_off(array_db1[i][1]));
            }
            if (($('#ch1_pa').is(':checked'))) {
                array_temp.push(array_pa1[i][1]);
            }
            if (($('#ch1_pb').is(':checked'))) {
                array_temp.push(array_pb1[i][1]);
            }
            if (($('#ch1_ma').is(':checked'))) {
                array_temp.push(array_ma1[i][1]);
            }
            if (($('#ch1_aa').is(':checked'))) {
                array_temp.push(on_off(array_aa1[i][1]));
            }
            if (($('#ch1_ab').is(':checked'))) {
                array_temp.push(on_off(array_ab1[i][1]));
            }
            if (($('#ch1_ad').is(':checked'))) {
                array_temp.push(on_off(array_ad1[i][1]));
            }
            if (($('#ch1_ar').is(':checked'))) {
                array_temp.push(on_off(array_ar1[i][1]));
            }
            //----------------------ch2
            if (($('#ch2_val').is(':checked'))) {
                array_temp.push(array_ch2[i][1]);
            }
            if (($('#ch2_da').is(':checked'))) {
                array_temp.push(on_off(array_da2[i][1]));
            }
            if (($('#ch2_db').is(':checked'))) {
                array_temp.push(on_off(array_db2[i][1]));
            }
            if (($('#ch2_pa').is(':checked'))) {
                array_temp.push(array_pa2[i][1]);
            }
            if (($('#ch2_pb').is(':checked'))) {
                array_temp.push(array_pb2[i][1]);
            }
            if (($('#ch2_ma').is(':checked'))) {
                array_temp.push(array_ma2[i][1]);
            }
            if (($('#ch2_aa').is(':checked'))) {
                array_temp.push(on_off(array_aa2[i][1]));
            }
            if (($('#ch2_ab').is(':checked'))) {
                array_temp.push(on_off(array_ab2[i][1]));
            }
            if (($('#ch2_ad').is(':checked'))) {
                array_temp.push(on_off(array_ad2[i][1]));
            }
            if (($('#ch2_ar').is(':checked'))) {
                array_temp.push(on_off(array_ar2[i][1]));
            }
            //------------------------------ch3
            if (($('#ch3_val').is(':checked'))) {
                array_temp.push(array_ch3[i][1]);
            }
            if (($('#ch3_da').is(':checked'))) {
                array_temp.push(on_off(array_da3[i][1]));
            }
            if (($('#ch3_db').is(':checked'))) {
                array_temp.push(on_off(array_db3[i][1]));
            }
            if (($('#ch3_pa').is(':checked'))) {
                array_temp.push(array_pa3[i][1]);
            }
            if (($('#ch3_pb').is(':checked'))) {
                array_temp.push(array_pb3[i][1]);
            }
            if (($('#ch3_ma').is(':checked'))) {
                array_temp.push(array_ma3[i][1]);
            }
            if (($('#ch3_aa').is(':checked'))) {
                array_temp.push(on_off(array_aa3[i][1]));
            }
            if (($('#ch3_ab').is(':checked'))) {
                array_temp.push(on_off(array_ab3[i][1]));
            }
            if (($('#ch3_ad').is(':checked'))) {
                array_temp.push(on_off(array_ad3[i][1]));
            }
            if (($('#ch3_ar').is(':checked'))) {
                array_temp.push(on_off(array_ar3[i][1]));
            }
            //-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*ch4
            if (($('#ch4_val').is(':checked'))) {
                array_temp.push(array_ch4[i][1]);
            }
            if (($('#ch4_da').is(':checked'))) {
                array_temp.push(on_off(array_da4[i][1]));
            }
            if (($('#ch4_db').is(':checked'))) {
                array_temp.push(on_off(array_db4[i][1]));
            }
            if (($('#ch4_pa').is(':checked'))) {
                array_temp.push(array_pa4[i][1]);
            }
            if (($('#ch4_pb').is(':checked'))) {
                array_temp.push(array_pb4[i][1]);
            }
            if (($('#ch4_ma').is(':checked'))) {
                array_temp.push(array_ma4[i][1]);
            }
            if (($('#ch4_aa').is(':checked'))) {
                array_temp.push(on_off(array_aa4[i][1]));
            }
            if (($('#ch4_ab').is(':checked'))) {
                array_temp.push(on_off(array_ab4[i][1]));
            }
            if (($('#ch4_ad').is(':checked'))) {
                array_temp.push(on_off(array_ad4[i][1]));
            }
            if (($('#ch4_ar').is(':checked'))) {
                array_temp.push(on_off(array_ar4[i][1]));
            }
            //----------------------------------ch5
            if (($('#ch5_val').is(':checked'))) {
                array_temp.push(array_ch5[i][1]);
            }
            if (($('#ch5_da').is(':checked'))) {
                array_temp.push(on_off(array_da5[i][1]));
            }
            if (($('#ch5_db').is(':checked'))) {
                array_temp.push(on_off(array_db5[i][1]));
            }
            if (($('#ch5_pa').is(':checked'))) {
                array_temp.push(array_pa5[i][1]);
            }
            if (($('#ch5_pb').is(':checked'))) {
                array_temp.push(array_pb5[i][1]);
            }
            if (($('#ch5_ma').is(':checked'))) {
                array_temp.push(array_ma5[i][1]);
            }
            if (($('#ch5_aa').is(':checked'))) {
                array_temp.push(on_off(array_aa5[i][1]));
            }
            if (($('#ch5_ab').is(':checked'))) {
                array_temp.push(on_off(array_ab5[i][1]));
            }
            if (($('#ch5_ad').is(':checked'))) {
                array_temp.push(on_off(array_ad5[i][1]));
            }
            if (($('#ch5_ar').is(':checked'))) {
                array_temp.push(on_off(array_ar5[i][1]));
            }
            if ($('#temperature_select').is(':checked'))
            {
                array_temp.push(array_temperatura[i][1]);
            }
            if (((doppiaPiscina == true) && ($('#temperature_select2').is(':checked')))) {
                array_temp.push(array_ch5[i][1]);
            }
            if ((yagel_personalizzazione == "true") && ($('#flow_meter_low').is(':checked'))){
                array_temp.push(on_off(array_fml[i][1]));
            }
            if (($('#flow_meter').is(':checked')))
            {
                array_temp.push(array_wm[i][1]);
            }
            if (($('#flow_select').is(':checked'))) {
                array_temp.push(on_off(array_flow[i][1]));
            }
            if (((doppiaPiscina == true) && ($('#flow_select2').is(':checked')))) {
                array_temp.push(on_off(array_stby[i][1]));
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
function on_off(ingresso) {
    if (ingresso == 1)
        return "ON"
    else
        return "OFF"
}
function get_numero_string(numero_valore) {
    if (numero_valore < 10)
        return "0" + numero_valore;
    else
        return numero_valore;
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
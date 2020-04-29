
var array_livello1 = [];
var array_livello1_day = [];
var array_livello1_month = [];
var array_livello1_year = [];
var intero_month_start_1 = 0;
var intero_month_1 = 0;
var intero_day_start_1 = 0;
var intero_day_1 = 0;
var intero_year_start_1 = 0;
var intero_year_1 = 0;

var array_livello2 = [];
var array_livello2_day = [];
var array_livello2_month = [];
var array_livello2_year = [];
var intero_month_start_2 = 0;
var intero_month_2 = 0;
var intero_day_start_2 = 0;
var intero_day_2 = 0;
var intero_year_start_2 = 0;
var intero_year_2 = 0;
var array_livello3 = [];
var array_livello3_day = [];
var array_livello3_month = [];
var array_livello3_year = [];
var intero_month_start_3 = 0;
var intero_month_3 = 0;
var intero_day_start_3 = 0;
var intero_day_3 = 0;
var intero_year_start_3 = 0;
var intero_year_3 = 0;
var array_livello4 = [];
var array_livello4_day = [];
var array_livello4_month = [];
var array_livello4_year = [];
var intero_month_start_4 = 0;
var intero_month_4 = 0;
var intero_day_start_4 = 0;
var intero_day_4 = 0;
var intero_year_start_4 = 0;
var intero_year_4 = 0;
var array_livello5 = [];
var array_livello5_day = [];
var array_livello5_month = [];
var array_livello5_year = [];
var intero_month_start_5 = 0;
var intero_month_5 = 0;
var intero_day_start_5 = 0;
var intero_day_5 = 0;
var intero_year_start_5 = 0;
var intero_year_5 = 0;

var year = 0;
var year_prec = 0;
var month = 0;
var month_prec = 0;
var day = 0;
var day_prec = 0;

var array_livello2 = [];
var array_livello3 = [];
var array_livello4 = [];
var array_livello5 = [];
var name1 = "";
var name2 = "";
var name3 = "";
var name4 = "";
var name5 = "";
var name_global = "";
var primo = 0;
var date_start;
function manage_div() {
    if ($("#log_collapse").is(":visible")) {
        $("#log_collapse").hide();
    }
    else {
        $("#log_collapse").show();
    }
}
function set_name(name1_t, name2_t, name3_t, name4_t, name5_t) {
    name1 = name1_t;
    name2 = name2_t;
    name3 = name3_t;
    name4 = name4_t;
    name5 = name5_t;
    
}
function get_data(parametro1, parametro2) {
    $.ajax({
        type: "POST",
        url: "chart/ldma_logmetod.aspx/get_log_ldma",
        //data: {check1: $("#rms_all").is(':checked') ,check1_1: $("#rms_medio").is(':checked'),  check1_2:  $("#rms_max").is(':checked') ,check2 : $("#picco_all").is(':checked') , check2_1 : $("#picco_medio").is(':checked') , check2_2 : $("#picco_max").is(':checked') , check3: $("#vm_rms_all").is(':checked') , check3_1: $("#vm_rms_medio").is(':checked') , check3_2 : $("#vm_rms_max").is(':checked') , check4 : $("#vm_picco_all").is(':checked') , check4_1 : $("#vm_picco_medio").is(':checked') , check4_2: $("#vm_picco_max").is(':checked')   },
        //data: { check1: false, check1_1: true, check1_2: false, check2: false, check2_1: true, check2_2: false, check3: false, check3_1:true, check3_2:false, check4: false, check4_1:true, check4_2:false },
        data: "{'parametro':'" + JSON.stringify(parametro1) + "," + JSON.stringify(parametro2)  + "'}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        //timeout: 6000, //3 second timeout
        success: function (response) {

            var data;
            var data_year;
            var intero1 = 0;
            var intero2 = 0;
            var intero3 = 0;
            var intero4 = 0;
            var intero5 = 0;
            var indice = 0;


            $.each(response.d, function (k, v) {
                //htmlStr += v.id + ' ' + v.name + '<br />';
                switch (indice) {
                    case 0:
                        var res = v.split(",")

                        data = Date.UTC(parseInt(res[0]), parseInt(res[1]), parseInt(res[2]), parseInt(res[3]), parseInt(res[4]));
                        year = parseInt(res[0]);
                        month = parseInt(res[1]);
                        day = parseInt(res[2]);
                        if (primo == 0) {
                            //date_start = data;
                            year_prec = year;
                            day_prec = day;
                            month_prec = month;
                        }

                        indice = indice + 1;
                        break;
                    case 1:
                        if (primo == 0) {
                            //date_start = data;
                            intero_year_start_1 = parseFloat(v);
                            intero_month_start_1 = parseFloat(v);
                            intero_day_start_1 = parseFloat(v);
                            primo= 1;
                        }
                        if (year != year_prec) {
                            
                            if (intero1 >= intero_year_start_1) {
                            intero_year_1 = intero1 - intero_year_start_1;
                            }
                            else {
                                intero_year_1 = intero1;
                            }
                            data_year = Date.UTC(year_prec, month_prec);
                            array_livello1_year.push([data_year, intero_year_1]);

                        }
                        if (month != month_prec) {

                            if (intero1 >= intero_month_start_1) {
                            intero_month_1 = intero1 - intero_month_start_1;
                            }
                            else {
                                intero_month_1 = intero1;
                            }
                            data_month = Date.UTC(year_prec, month_prec);
                            array_livello1_month.push([data_month, intero_month_1]);

                        }
                     
                        if (day != day_prec) {
                            //alert(intero_day_start);
                            //alert(intero1);
                            if (intero1 >= intero_day_start_1) {
                                intero_day_1 = intero1 - intero_day_start_1;
                                // alert(intero_day);
                            }
                            else {
                                intero_day_1 = intero1;
                            }
                            data_day = Date.UTC(year_prec, month_prec, day_prec);
                            array_livello1_day.push([data_day, intero_day_1]);

                        }

                        if (year != year_prec) {
                            //year_prec = year;
                            intero_year_start_1 = parseFloat(v);
                        }
                        if (month != month_prec) {
                            //month_prec = month;
                            intero_month_start_1 = parseFloat(v);
                        }
                        if (day != day_prec) {
                            //day_prec = day;
                            intero_day_start_1 = parseFloat(v);
                        }

                        intero1 = parseFloat(v);
                        array_livello1.push([data, intero1]);
                        indice = indice + 1;
                        break;
                    case 2:
                        if (year != year_prec) {

                            if (intero2 >= intero_year_start_2) {
                            intero_year_2 = intero2 - intero_year_start_2;
                            }
                            else {
                                intero_year_2 = intero2;
                            }
                            data_year = Date.UTC(year_prec, month_prec);
                            array_livello2_year.push([data_year, intero_year_2]);

                        }
                        if (month != month_prec) {

                            if (intero2 >= intero_month_start_2) {
                            intero_month_2 = intero2 - intero_month_start_2;
                            }
                            else {
                                intero_month_2 = intero2;
                            }
                            data_month = Date.UTC(year_prec, month_prec);
                            array_livello2_month.push([data_month, intero_month_2]);

                        }

                        if (day != day_prec) {
                            //alert(intero_day_start);
                            //alert(intero1);
                            if (intero2 >= intero_day_start_2) {
                                intero_day_2 = intero2 - intero_day_start_2;
                                // alert(intero_day);
                            }
                            else {
                                intero_day_2 = intero2;
                            }
                            data_day = Date.UTC(year_prec, month_prec, day_prec);
                            array_livello2_day.push([data_day, intero_day_2]);

                        }

                        if (year != year_prec) {
                            //year_prec = year;
                            intero_year_start_2 = parseFloat(v);
                        }
                        if (month != month_prec) {
                            //month_prec = month;
                            intero_month_start_2 = parseFloat(v);
                        }
                        if (day != day_prec) {
                            //day_prec = day;
                            intero_day_start_2 = parseFloat(v);
                        }

                        intero2 = parseFloat(v);
                        array_livello2.push([data, intero2]);
                        indice = indice + 1;
                        break;
                    case 3:
                        if (year != year_prec) {

                            if (intero3 >= intero_year_start_3) {
                            intero_year_3 = intero3 - intero_year_start_3;
                            }
                            else {
                                intero_year_3 = intero3;
                            }
                            data_year = Date.UTC(year_prec, month_prec);
                            array_livello3_year.push([data_year, intero_year_3]);

                        }
                        if (month != month_prec) {

                            if (intero3 >= intero_month_start_3) {
                            intero_month_3 = intero3 - intero_month_start_3;
                            }
                            else {
                                intero_month_3 = intero3;
                            }
                            data_month = Date.UTC(year_prec, month_prec);
                            array_livello3_month.push([data_month, intero_month_3]);

                        }

                        if (day != day_prec) {
                            //alert(intero_day_start);
                            //alert(intero3);
                            if (intero3 >= intero_day_start_3) {
                                intero_day_3 = intero3 - intero_day_start_3;
                                // alert(intero_day);
                            }
                            else {
                                intero_day_3 = intero3;
                            }
                            data_day = Date.UTC(year_prec, month_prec, day_prec);
                            array_livello3_day.push([data_day, intero_day_3]);

                        }

                        if (year != year_prec) {
                            //year_prec = year;
                            intero_year_start_3 = parseFloat(v);
                        }
                        if (month != month_prec) {
                            //month_prec = month;
                            intero_month_start_3 = parseFloat(v);
                        }
                        if (day != day_prec) {
                            //day_prec = day;
                            intero_day_start_3 = parseFloat(v);
                        }

                        intero3 = parseFloat(v);
                        array_livello3.push([data, intero3]);
                        indice = indice + 1;
                        break;
                    case 4:
                        if (year != year_prec) {

                           if (intero4 >= intero_year_start_4) {
                            intero_year_4 = intero4 - intero_year_start_4;
                           }
                           else {
                               intero_year_4 = intero4;
                           }
                           data_year = Date.UTC(year_prec, month_prec);
                           array_livello4_year.push([data_year, intero_year_4]);

                        }
                        if (month != month_prec) {

                            if (intero4 >= intero_month_start_4) {
                            intero_month_4 = intero4 - intero_month_start_4;
                            }
                            else {
                                intero_month_4 = intero4;
                            }
                            data_month = Date.UTC(year_prec, month_prec);
                            array_livello4_month.push([data_month, intero_month_4]);

                        }

                        if (day != day_prec) {
                            //alert(intero_day_start);
                            //alert(intero4);
                            if (intero4 >= intero_day_start_4) {
                                intero_day_4 = intero4 - intero_day_start_4;
                                // alert(intero_day);
                            }
                            else {
                                intero_day_4 = intero4;
                            }
                            data_day = Date.UTC(year_prec, month_prec, day_prec);
                            array_livello4_day.push([data_day, intero_day_4]);
                        }

                        if (year != year_prec) {
                            //year_prec = year;
                            intero_year_start_4 = parseFloat(v);
                        }
                        if (month != month_prec) {
                            //month_prec = month;
                            intero_month_start_4 = parseFloat(v);
                        }
                        if (day != day_prec) {
                            //day_prec = day;
                            intero_day_start_4 = parseFloat(v);
                        }

                        intero4 = parseFloat(v);
                        array_livello4.push([data, intero4]);
                        indice = indice + 1;
                        break;
                    case 5:
                        if (year != year_prec) {

                            if (intero5 >= intero_year_start_5) {
                            intero_year_5 = intero5 - intero_year_start_5;
                            }
                            else {
                                intero_year_5 = intero5;
                            }
                            data_year = Date.UTC(year_prec, month_prec);
                            array_livello5_year.push([data_year, intero_year_5]);

                        }
                        if (month != month_prec) {

                            if (intero5 >= intero_month_start_5) {
                            intero_month_5 = intero5 - intero_month_start_5;
                            }
                            else {
                                intero_month_5 = intero5;
                            }
                            data_month = Date.UTC(year_prec, month_prec);
                            array_livello5_month.push([data_month, intero_month_5]);

                        }

                        if (day != day_prec) {
                            //alert(intero_day_start);
                            //alert(intero5);
                            if (intero5 >= intero_day_start_5) {
                                intero_day_5 = intero5 - intero_day_start_5;
                                // alert(intero_day);
                            }
                            else {
                                intero_day_5 = intero5;
                            }
                            data_day = Date.UTC(year_prec, month_prec, day_prec);
                            array_livello5_day.push([data_day, intero_day_5]);

                        }

                        if (year != year_prec) {
                            year_prec = year;
                            intero_year_start_5 = parseFloat(v);
                        }
                        if (month != month_prec) {
                            month_prec = month;
                            intero_month_start_5 = parseFloat(v);
                        }
                        if (day != day_prec) {
                            day_prec = day;
                            intero_day_start_5 = parseFloat(v);
                        }

                        intero5 = parseFloat(v);
                        array_livello5.push([data, intero5]);
                        indice = 0;
                        break;
                }
                
                
            });
            if (intero1 >= intero_year_start_1) {
                intero_year_1 = intero1 - intero_year_start_1;

            }
            else {
                intero_year_1 = intero1;
            }
            data_year = Date.UTC(year_prec, month_prec, day_prec);
            array_livello1_year.push([data_year, intero_year_1]);

            if (intero1 >= intero_month_start_1) {
                intero_month_1 = intero1 - intero_month_start_1;
                }
            else {
                intero_month_1 = intero1;
                }
            data_month = Date.UTC(year_prec, month_prec);
            array_livello1_month.push([data_month, intero_month_1]);

            if (intero1 >= intero_day_start_1) {
                intero_day_1 = intero1 - intero_day_start_1;
                // alert(intero_day);
               }
            else {
                intero_day_1 = intero1;
                }
            data_day = Date.UTC(year_prec, month_prec, day_prec);
            array_livello1_day.push([data_day, intero_day_1]);

            if (intero2 >= intero_year_start_2) {
                intero_year_2 = intero2 - intero_year_start_2;
                }
            else {
                intero_year_2 = intero2;
                }
            data_year = Date.UTC(year_prec, month_prec, day_prec);
            array_livello2_year.push([data_year, intero_year_2]);

            if (intero2 >= intero_month_start_2) {
                intero_month_2 = intero2 - intero_month_start_2;
            }
            else {
                intero_month_2 = intero2;
            }
            data_month = Date.UTC(year_prec, month_prec);
            array_livello2_month.push([data_month, intero_month_2]);

            if (intero2 >= intero_day_start_2) {
                intero_day_2 = intero2 - intero_day_start_2;
                // alert(intero_day);
            }
            else {
                intero_day_2 = intero2;
            }
            data_day = Date.UTC(year_prec, month_prec, day_prec);
            array_livello2_day.push([data_day, intero_day_2]);

           if (intero3 >= intero_year_start_3) {
                intero_year_3 = intero3 - intero_year_start_3;
           }
           else {
               intero_year_3 = intero3;
           }
           data_year = Date.UTC(year_prec, month_prec, day_prec);
           array_livello3_year.push([data_year, intero_year_3]);

            if (intero3 >= intero_month_start_3) {
                intero_month_3 =intero3 - intero_month_start_3;
            }
            else {
                intero_month_3 = intero3;
            }
            data_month = Date.UTC(year_prec, month_prec);
            array_livello3_month.push([data_month, intero_month_3]);

                if (intero3 >= intero_day_start_3) {
                    intero_day_3 = intero3 - intero_day_start_3;
                    // alert(intero_day);
                }
                else {
                    intero_day_3 = intero3;
                }
            data_day = Date.UTC(year_prec, month_prec, day_prec);
            array_livello3_day.push([data_day, intero_day_3]);

                if (intero4 >= intero_year_start_4) {
                    intero_year_4 = intero4 - intero_year_start_4;
                }
                else {
                    intero_year_4 = intero4;
                }
            data_year = Date.UTC(year_prec, month_prec, day_prec);
            array_livello4_year.push([data_year, intero_year_4]);

            if (intero4 >= intero_month_start_4) {
                    intero_month_4 = intero4 - intero_month_start_4;
                }
                else {
                    intero_month_4 = intero4;
                }
            data_month = Date.UTC(year_prec, month_prec);
            array_livello4_month.push([data_month, intero_month_4]);

            if (intero4 >= intero_day_start_4) {
                    intero_day_4 = intero4 - intero_day_start_4;
                    // alert(intero_day);
                }
                else {
                    intero_day_4 = intero4;
                }
            data_day = Date.UTC(year_prec, month_prec, day_prec);
            array_livello4_day.push([data_day, intero_day_4]);

            if (intero5 >= intero_year_start_5) {
                    intero_year_5 = intero5 - intero_year_start_5;
                }
                else {
                    intero_year_5 = intero5;
                }

            data_year = Date.UTC(year_prec, month_prec, day_prec);
            array_livello5_year.push([data_year, intero_year_5]);

            if (intero5 >= intero_month_start_5) {
                    intero_month_5 = intero5 - intero_month_start_5;
                }
                else {
                    intero_month_5 = intero5;
                }
            data_month = Date.UTC(year_prec, month_prec);
            array_livello5_month.push([data_month, intero_month_5]);

            if (intero5 >= intero_day_start_5) {
                    intero_day_5 = intero5 - intero_day_start_5;
                    // alert(intero_day);
                }
                else {
                    intero_day_5 = intero_5;
                }
            data_day = Date.UTC(year_prec, month_prec, day_prec);
            array_livello5_day.push([data_day, intero_day_5]);

            //            array.push(array_temp);
            upgrate_chart();
        },
        failure: function (response) {
            alert(response.d);
        }

    });
    
}
function upgrate_chart() {
    var series_chart = [];
    var array_temp1 = [];
    var array_temp2 = [];
    var array_temp3 = [];
    var array_temp4 = [];
    var array_temp5 = [];

    //alert(array_livello1[1]);
    if ($('#all_val').is(':checked')) {
        name_global = $('#all_val_label').text();
        array_temp1 = array_livello1;
        array_temp2 = array_livello2;
        array_temp3 = array_livello3;
        array_temp4 = array_livello4;
        array_temp5 = array_livello5;
    }
    if ($('#day_val').is(':checked')) {
        name_global = $('#day_val_label').text();
        array_temp1 = array_livello1_day;
        array_temp2 = array_livello2_day;
        array_temp3 = array_livello3_day;
        array_temp4 = array_livello4_day;
        array_temp5 = array_livello5_day;
        /*array_temp2 = array_livello2;
        array_temp3 = array_livello3;
        array_temp4 = array_livello4;
        array_temp5 = array_livello5;*/

    }
    if ($('#month_val').is(':checked')) {
        name_global = $('#month_val_label').text();
        array_temp1 = array_livello1_month;
        array_temp2 = array_livello2_month;
        array_temp3 = array_livello3_month;
        array_temp4 = array_livello4_month;
        array_temp5 = array_livello5_month;
    }
    if ($('#year_val').is(':checked')) {
        name_global = $('#year_val_label').text();
        array_temp1 = array_livello1_year;
        array_temp2 = array_livello2_year;
        array_temp3 = array_livello3_year;
        array_temp4 = array_livello4_year;
        array_temp5 = array_livello5_year;
    }

    if ($('#level1_val').is(':checked')) {
        series_chart.push({
            name: name1,
            id: 'ch1_val_series',
            //data: array_db_rms,
            data: array_temp1,
            tooltip: {
                valueDecimals: 2
            }
            // pointStart: date_start
            //pointInterval: 3600 * 1000,
        });
    }
    if ($('#level2_val').is(':checked')) {
        series_chart.push({
            name: name2,
            id: 'ch1_val_series1',
            //data: array_db_picco,
            data: array_temp2,
            tooltip: {
            valueDecimals: 2
        }

            //pointStart: date_start
            //pointInterval: 3600 * 1000,
        });
    }
    if ($('#level3_val').is(':checked')) {
        series_chart.push({
            name: name3,
            id: 'ch1_val_series1',
            //data: array_db_picco,
            data: array_temp3,
            tooltip: {
                valueDecimals: 2
            }


            //pointStart: date_start
            //pointInterval: 3600 * 1000,
        });
    }
    if ($('#level4_val').is(':checked')) {
        series_chart.push({
            name: name4,
            id: 'ch1_val_series1',
            //data: array_db_picco,
            data: array_temp4,
            tooltip: {
                valueDecimals: 2
            }


            //pointStart: date_start
            //pointInterval: 3600 * 1000,
        });
    }
    if ($('#level5_val').is(':checked')) {
        series_chart.push({
            name: name5,
            id: 'ch1_val_series1',
            //data: array_db_picco,
            data: array_temp5,
            tooltip: {
                valueDecimals: 2
            }


            //pointStart: date_start
            //pointInterval: 3600 * 1000,
        });
    }
    $('#chart_div').highcharts('StockChart', {

        rangeSelector: {
            //inputEnabled: $('#chart_div').width() > 480,
            enabled: false
        },

        title: {
            text: name_global
        },

        series: series_chart

    });

    crea_tabella(array_temp1, array_temp2, array_temp3, array_temp4, array_temp5, $('#all_val').is(':checked'), $('#day_val').is(':checked'), $('#month_val').is(':checked'), $('#year_val').is(':checked'), $('#level1_val').is(':checked'), $('#level2_val').is(':checked'), $('#level3_val').is(':checked'), $('#level4_val').is(':checked'), $('#level5_val').is(':checked'));
}

function crea_tabella(array_temp1, array_temp2, array_temp3, array_temp4, array_temp5,all_temp,day_temp,month_temp,year_temp, livello1_temp,livello2_temp,livello3_temp,livello4_temp,livello5_temp) {
    var i = 0;
    var header_array = [];
    var header_value = [];
    var oggetto = {};
    oggetto = { "title": "Date" }
    header_array.push(oggetto)

    if (livello1_temp) {
        oggetto = { "title": name1 };
        header_array.push(oggetto);
    }
    if (livello2_temp) {
        oggetto = { "title": name2 };
        header_array.push(oggetto);
    }
    if (livello3_temp) {
        oggetto = { "title": name3 };
        header_array.push(oggetto);
    }
    if (livello4_temp) {
        oggetto = { "title": name4 };
        header_array.push(oggetto);
    }
    if (livello5_temp) {
        oggetto = { "title": name5 };
        header_array.push(oggetto);
    }
    i = array_temp1.length - 1;
    $.each(array_temp1, function (row1, point1) {

        var array_temp = [];
        var date = new Date(array_temp1[i][0]);
        date = convertUTCDateToLocalDate(date);
        var theyear = date.getFullYear()
        var themonth = date.getMonth() + 1;
        var thetoday = date.getDate();
        var ore = date.getHours();
        var minuti = date.getMinutes();
        if (all_temp) {
            array_temp.push(get_numero_string(thetoday) + "/" + get_numero_string(themonth) + "/" + get_numero_string(theyear) + " " + get_numero_string(ore) + ":" + get_numero_string(minuti));
        }
        if (day_temp) {
            array_temp.push(get_numero_string(thetoday) + "/" + get_numero_string(themonth) + "/" + get_numero_string(theyear) );
        }
        if (month_temp) {
            array_temp.push(get_numero_string(themonth) + "/" + get_numero_string(theyear));
        }
        if (year_temp) {
            array_temp.push( get_numero_string(theyear));
        }

        if (livello1_temp) {
            array_temp.push(parseFloat(array_temp1[i][1]).toFixed(2));
        }
        if (livello2_temp) {
            array_temp.push(parseFloat(array_temp2[i][1]).toFixed(2));
        }
        if (livello3_temp) {
            array_temp.push(parseFloat(array_temp3[i][1]).toFixed(2));
        }
        if (livello4_temp) {
            array_temp.push(parseFloat(array_temp4[i][1]).toFixed(2));
        }
        if (livello5_temp) {
            array_temp.push(parseFloat(array_temp5[i][1]).toFixed(2));
        }
        header_value.push(array_temp);
        i= i-1
    });
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
    });
    */
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
$("#head_log").click(function () {

    manage_div();

});

$("#refresh_graph").click(function () {
    manage_div();
    upgrate_chart();
    return false;
});
function get_numero_string(numero_valore) {
    if (numero_valore < 10)
        return "0" + numero_valore;
    else
        return numero_valore;
}
function convertUTCDateToLocalDate(convertdLocalTime) {


    var hourOffset = convertdLocalTime.getTimezoneOffset() / 60;

    convertdLocalTime.setHours(convertdLocalTime.getHours() + hourOffset);

    return convertdLocalTime;
}

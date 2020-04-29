var array_pump1 = [];
var array_pump1_day = [];
var array_pump1_month = [];
var array_pump1_year = [];
var intero_month_start_1 = 0;
var intero_month_1 = 0;
var intero_day_start_1 = 0;
var intero_day_1 = 0;
var intero_year_start_1 = 0;
var intero_year_1 = 0;

var array_pump2 = [];
var array_pump2_day = [];
var array_pump2_month = [];
var array_pump2_year = [];
var intero_month_start_2 = 0;
var intero_month_2 = 0;
var intero_day_start_2 = 0;
var intero_day_2 = 0;
var intero_year_start_2 = 0;
var intero_year_2 = 0;

var array_pump3 = [];
var array_pump3_day = [];
var array_pump3_month = [];
var array_pump3_year = [];
var intero_month_start_3 = 0;
var intero_month_3 = 0;
var intero_day_start_3 = 0;
var intero_day_3 = 0;
var intero_year_start_3 = 0;
var intero_year_3 = 0;

var array_pump4 = [];
var array_pump4_day = [];
var array_pump4_month = [];
var array_pump4_year = [];
var intero_month_start_4 = 0;
var intero_month_4 = 0;
var intero_day_start_4 = 0;
var intero_day_4 = 0;
var intero_year_start_4 = 0;
var intero_year_4 = 0;

var array_pump5 = [];
var array_pump5_day = [];
var array_pump5_month = [];
var array_pump5_year = [];
var intero_month_start_5 = 0;
var intero_month_5 = 0;
var intero_day_start_5 = 0;
var intero_day_5 = 0;
var intero_year_start_5 = 0;
var intero_year_5 = 0;

var array_wm1 = [];
var array_wm1_day = [];
var array_wm1_month = [];
var array_wm1_year = [];
var intero_month_start_6 = 0;
var intero_month_6 = 0;
var intero_day_start_6 = 0;
var intero_day_6 = 0;
var intero_year_start_6 = 0;
var intero_year_6 = 0;

var array_wm2 = [];
var array_wm2_day = [];
var array_wm2_month = [];
var array_wm2_year = [];
var intero_month_start_7 = 0;
var intero_month_7 = 0;
var intero_day_start_7 = 0;
var intero_day_7 = 0;
var intero_year_start_7 = 0;
var intero_year_7 = 0;

var array_wm3 = [];
var array_wm3_day = [];
var array_wm3_month = [];
var array_wm3_year = [];
var intero_month_start_8 = 0;
var intero_month_8 = 0;
var intero_day_start_8 = 0;
var intero_day_8 = 0;
var intero_year_start_8 = 0;
var intero_year_8 = 0;

var array_wm4 = [];
var array_wm4_day = [];
var array_wm4_month = [];
var array_wm4_year = [];
var intero_month_start_9 = 0;
var intero_month_9 = 0;
var intero_day_start_9 = 0;
var intero_day_9 = 0;
var intero_year_start_9 = 0;
var intero_year_9 = 0;

var array_wm5 = [];
var array_wm5_day = [];
var array_wm5_month = [];
var array_wm5_year = [];
var intero_month_start_10 = 0;
var intero_month_10 = 0;
var intero_day_start_10 = 0;
var intero_day_10 = 0;
var intero_year_start_10 = 0;
var intero_year_10 = 0;

var array_delta = [];
var array_delta_day = [];
var array_delta_month = [];
var array_delta_year = [];
var intero_month_start_11 = 0;
var intero_month_11 = 0;
var intero_day_start_11 = 0;
var intero_day_11 = 0;
var intero_year_start_11 = 0;
var intero_year_11 = 0;

var array_differential = [];
var array_differential_day = [];
var array_differential_month = [];
var array_differential_year = [];
var intero_month_start_12 = 0;
var intero_month_12 = 0;
var intero_day_start_12 = 0;
var intero_day_12 = 0;
var intero_year_start_12 = 0;
var intero_year_12 = 0;

var year = 0;
var year_prec = 0;
var month = 0;
var month_prec = 0;
var day = 0;
var day_prec = 0;

var name1 = "";
var name2 = "";
var name3 = "";
var name4 = "";
var name5 = "";
var name6 = "";
var name7 = "";
var name8 = "";
var name9 = "";
var name10 = "";
var name11 = "";
var name12 = "";
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
function set_name(name_pump1, name_pump2, name_pump3, name_pump4, name_pump5, name_wm1, name_wm2, name_wm3, name_wm4, name_wm5, name_delta, name_percent) {
    name1 = name_pump1;
    name2 = name_pump2;
    name3 = name_pump3;
    name4 = name_pump4;
    name5 = name_pump5;
    name6 = name_wm1;
    name7 = name_wm2;
    name8 = name_wm3;
    name9 = name_wm4;
    name10 = name_wm5;

    name11 = name_delta;
    name12 = name_percent;

}
function get_data_new(parametro1, parametro2) {
    //alert(parametro1)
    $.ajax({
        type: "POST",
        url: "chart/ldma_logmetod.aspx/get_log_ldlg",
        //data: {check1: $("#rms_all").is(':checked') ,check1_1: $("#rms_medio").is(':checked'),  check1_2:  $("#rms_max").is(':checked') ,check2 : $("#picco_all").is(':checked') , check2_1 : $("#picco_medio").is(':checked') , check2_2 : $("#picco_max").is(':checked') , check3: $("#vm_rms_all").is(':checked') , check3_1: $("#vm_rms_medio").is(':checked') , check3_2 : $("#vm_rms_max").is(':checked') , check4 : $("#vm_picco_all").is(':checked') , check4_1 : $("#vm_picco_medio").is(':checked') , check4_2: $("#vm_picco_max").is(':checked')   },
        //data: { check1: false, check1_1: true, check1_2: false, check2: false, check2_1: true, check2_2: false, check3: false, check3_1:true, check3_2:false, check4: false, check4_1:true, check4_2:false },
        data: "{'parametro':'" + JSON.stringify(parametro1) + "," + JSON.stringify(parametro2) + "'}",
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
            var intero6 = 0;
            var intero7 = 0;
            var intero8 = 0;
            var intero9 = 0;
            var intero10 = 0;
            var intero11 = 0;
            var intero12 = 0;
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
                            primo = 1;
                        }
                        if (year != year_prec) {

                            if (intero1 >= intero_year_start_1) {
                                intero_year_1 = intero1 - intero_year_start_1;
                            }
                            else {
                                intero_year_1 = intero1;
                            }
                            data_year = Date.UTC(year_prec, month_prec);
                            array_pump1_year.push([data_year, intero_year_1]);

                        }
                        if (month != month_prec) {

                            if (intero1 >= intero_month_start_1) {
                                intero_month_1 = intero1 - intero_month_start_1;
                            }
                            else {
                                intero_month_1 = intero1;
                            }
                            data_month = Date.UTC(year_prec, month_prec);
                            array_pump1_month.push([data_month, intero_month_1]);

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
                            array_pump1_day.push([data_day, intero_day_1]);

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
                        array_pump1.push([data, intero1]);
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
                            array_pump2_year.push([data_year, intero_year_2]);

                        }
                        if (month != month_prec) {

                            if (intero2 >= intero_month_start_2) {
                                intero_month_2 = intero2 - intero_month_start_2;
                            }
                            else {
                                intero_month_2 = intero2;
                            }
                            data_month = Date.UTC(year_prec, month_prec);
                            array_pump2_month.push([data_month, intero_month_2]);

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
                            array_pump2_day.push([data_day, intero_day_2]);

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
                        array_pump2.push([data, intero2]);
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
                            array_pump3_year.push([data_year, intero_year_3]);

                        }
                        if (month != month_prec) {

                            if (intero3 >= intero_month_start_3) {
                                intero_month_3 = intero3 - intero_month_start_3;
                            }
                            else {
                                intero_month_3 = intero3;
                            }
                            data_month = Date.UTC(year_prec, month_prec);
                            array_pump3_month.push([data_month, intero_month_3]);

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
                            array_pump3_day.push([data_day, intero_day_3]);

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
                        array_pump3.push([data, intero3]);
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
                            array_pump4_year.push([data_year, intero_year_4]);

                        }
                        if (month != month_prec) {

                            if (intero4 >= intero_month_start_4) {
                                intero_month_4 = intero4 - intero_month_start_4;
                            }
                            else {
                                intero_month_4 = intero4;
                            }
                            data_month = Date.UTC(year_prec, month_prec);
                            array_pump4_month.push([data_month, intero_month_4]);

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
                            array_pump4_day.push([data_day, intero_day_4]);
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
                        array_pump4.push([data, intero4]);
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
                            array_pump5_year.push([data_year, intero_year_5]);

                        }
                        if (month != month_prec) {

                            if (intero5 >= intero_month_start_5) {
                                intero_month_5 = intero5 - intero_month_start_5;
                            }
                            else {
                                intero_month_5 = intero5;
                            }
                            data_month = Date.UTC(year_prec, month_prec);
                            array_pump5_month.push([data_month, intero_month_5]);

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
                            array_pump5_day.push([data_day, intero_day_5]);

                        }

                        if (year != year_prec) {
                            //year_prec = year;
                            intero_year_start_5 = parseFloat(v);
                        }
                        if (month != month_prec) {
                           // month_prec = month;
                            intero_month_start_5 = parseFloat(v);
                        }
                        if (day != day_prec) {
                            //day_prec = day;
                            intero_day_start_5 = parseFloat(v);
                        }

                        intero5 = parseFloat(v);
                        array_pump5.push([data, intero5]);
                        indice = indice + 1;
                        break;
                        //wm
                    case 6:
                        if (year != year_prec) {

                            if (intero6 >= intero_year_start_6) {
                                intero_year_6 = intero6 - intero_year_start_6;
                            }
                            else {
                                intero_year_6 = intero6;
                            }
                            data_year = Date.UTC(year_prec, month_prec);
                            array_wm1_year.push([data_year, intero_year_6]);

                        }
                        if (month != month_prec) {

                            if (intero6 >= intero_month_start_6) {
                                intero_month_6 = intero6 - intero_month_start_6;
                            }
                            else {
                                intero_month_6 = intero6;
                            }
                            data_month = Date.UTC(year_prec, month_prec);
                            array_wm1_month.push([data_month, intero_month_6]);

                        }

                        if (day != day_prec) {
                            //alert(intero_day_start);
                            //alert(intero5);
                            if (intero6 >= intero_day_start_6) {
                                intero_day_6 = intero6 - intero_day_start_6;
                                // alert(intero_day);
                            }
                            else {
                                intero_day_6 = intero6;
                            }
                            data_day = Date.UTC(year_prec, month_prec, day_prec);
                            array_wm1_day.push([data_day, intero_day_6]);

                        }

                        if (year != year_prec) {
                            //year_prec = year;
                            intero_year_start_6 = parseFloat(v);
                        }
                        if (month != month_prec) {
                            //month_prec = month;
                            intero_month_start_6 = parseFloat(v);
                        }
                        if (day != day_prec) {
                            //day_prec = day;
                            intero_day_start_6 = parseFloat(v);
                        }

                        intero6 = parseFloat(v);
                        array_wm1.push([data, intero6]);
                        indice = indice + 1;
                        break;
                    case 7:
                        if (year != year_prec) {

                            if (intero7 >= intero_year_start_7) {
                                intero_year_7 = intero7 - intero_year_start_7;
                            }
                            else {
                                intero_year_7 = intero7;
                            }
                            data_year = Date.UTC(year_prec, month_prec);
                            array_wm2_year.push([data_year, intero_year_7]);

                        }
                        if (month != month_prec) {

                            if (intero7 >= intero_month_start_7) {
                                intero_month_7 = intero7 - intero_month_start_7;
                            }
                            else {
                                intero_month_7 = intero7;
                            }
                            data_month = Date.UTC(year_prec, month_prec);
                            array_wm2_month.push([data_month, intero_month_7]);

                        }

                        if (day != day_prec) {
                            //alert(intero_day_start);
                            //alert(intero5);
                            if (intero7 >= intero_day_start_7) {
                                intero_day_7 = intero7 - intero_day_start_7;
                                // alert(intero_day);
                            }
                            else {
                                intero_day_7 = intero7;
                            }
                            data_day = Date.UTC(year_prec, month_prec, day_prec);
                            array_wm2_day.push([data_day, intero_day_7]);

                        }

                        if (year != year_prec) {
                            //year_prec = year;
                            intero_year_start_7 = parseFloat(v);
                        }
                        if (month != month_prec) {
                            //month_prec = month;
                            intero_month_start_7 = parseFloat(v);
                        }
                        if (day != day_prec) {
                            //day_prec = day;
                            intero_day_start_7 = parseFloat(v);
                        }

                        intero7 = parseFloat(v);
                        array_wm2.push([data, intero7]);
                        indice = indice + 1;
                        break;
                    case 8:
                        if (year != year_prec) {

                            if (intero8 >= intero_year_start_8) {
                                intero_year_8 = intero8 - intero_year_start_8;
                            }
                            else {
                                intero_year_8 = intero8;
                            }
                            data_year = Date.UTC(year_prec, month_prec);
                            array_wm3_year.push([data_year, intero_year_8]);

                        }
                        if (month != month_prec) {

                            if (intero8 >= intero_month_start_8) {
                                intero_month_8 = intero8 - intero_month_start_8;
                            }
                            else {
                                intero_month_8 = intero8;
                            }
                            data_month = Date.UTC(year_prec, month_prec);
                            array_wm3_month.push([data_month, intero_month_8]);

                        }

                        if (day != day_prec) {
                            //alert(intero_day_start);
                            //alert(intero5);
                            if (intero8 >= intero_day_start_8) {
                                intero_day_8 = intero8 - intero_day_start_8;
                                // alert(intero_day);
                            }
                            else {
                                intero_day_8 = intero8;
                            }
                            data_day = Date.UTC(year_prec, month_prec, day_prec);
                            array_wm3_day.push([data_day, intero_day_8]);

                        }

                        if (year != year_prec) {
                            //year_prec = year;
                            intero_year_start_8 = parseFloat(v);
                        }
                        if (month != month_prec) {
                            //month_prec = month;
                            intero_month_start_8 = parseFloat(v);
                        }
                        if (day != day_prec) {
                            //day_prec = day;
                            intero_day_start_8 = parseFloat(v);
                        }

                        intero8 = parseFloat(v);
                        array_wm3.push([data, intero8]);
                        indice = indice + 1;
                        break;
                    case 9:
                        if (year != year_prec) {

                            if (intero9 >= intero_year_start_9) {
                                intero_year_9 = intero9 - intero_year_start_9;
                            }
                            else {
                                intero_year_9 = intero9;
                            }
                            data_year = Date.UTC(year_prec, month_prec);
                            array_wm4_year.push([data_year, intero_year_9]);

                        }
                        if (month != month_prec) {

                            if (intero9 >= intero_month_start_9) {
                                intero_month_9 = intero9 - intero_month_start_9;
                            }
                            else {
                                intero_month_9 = intero9;
                            }
                            data_month = Date.UTC(year_prec, month_prec);
                            array_wm4_month.push([data_month, intero_month_9]);

                        }

                        if (day != day_prec) {
                            //alert(intero_day_start);
                            //alert(intero5);
                            if (intero9 >= intero_day_start_9) {
                                intero_day_9 = intero9 - intero_day_start_9;
                                // alert(intero_day);
                            }
                            else {
                                intero_day_9 = intero9;
                            }
                            data_day = Date.UTC(year_prec, month_prec, day_prec);
                            array_wm4_day.push([data_day, intero_day_9]);

                        }

                        if (year != year_prec) {
                            //year_prec = year;
                            intero_year_start_9 = parseFloat(v);
                        }
                        if (month != month_prec) {
                            //month_prec = month;
                            intero_month_start_9 = parseFloat(v);
                        }
                        if (day != day_prec) {
                            //day_prec = day;
                            intero_day_start_9 = parseFloat(v);
                        }

                        intero9 = parseFloat(v);
                        array_wm4.push([data, intero9]);
                        indice = indice + 1;
                        break;
                    case 10:
                        if (year != year_prec) {

                            if (intero10 >= intero_year_start_10) {
                                intero_year_10 = intero10 - intero_year_start_10;
                            }
                            else {
                                intero_year_10 = intero10;
                            }
                            data_year = Date.UTC(year_prec, month_prec);
                            array_wm5_year.push([data_year, intero_year_10]);

                        }
                        if (month != month_prec) {

                            if (intero10 >= intero_month_start_10) {
                                intero_month_10 = intero10 - intero_month_start_10;
                            }
                            else {
                                intero_month_10 = intero10;
                            }
                            data_month = Date.UTC(year_prec, month_prec);
                            array_wm5_month.push([data_month, intero_month_10]);

                        }

                        if (day != day_prec) {
                            //alert(intero_day_start);
                            //alert(intero5);
                            if (intero10 >= intero_day_start_10) {
                                intero_day_10 = intero10 - intero_day_start_10;
                                // alert(intero_day);
                            }
                            else {
                                intero_day_10 = intero10;
                            }
                            data_day = Date.UTC(year_prec, month_prec, day_prec);
                            array_wm5_day.push([data_day, intero_day_10]);

                        }

                        if (year != year_prec) {
                            //year_prec = year;
                            intero_year_start_10 = parseFloat(v);
                        }
                        if (month != month_prec) {
                            //month_prec = month;
                            intero_month_start_10 = parseFloat(v);
                        }
                        if (day != day_prec) {
                            //day_prec = day;
                            intero_day_start_10 = parseFloat(v);
                        }

                        intero10 = parseFloat(v);
                        array_wm5.push([data, intero10]);
                        indice = indice + 1;
                        break;
                    case 11:
                        if (year != year_prec) {

                            if (intero11 >= intero_year_start_11) {
                                intero_year_11 = intero11 - intero_year_start_11;
                            }
                            else {
                                intero_year_11 = intero11;
                            }
                            data_year = Date.UTC(year_prec, month_prec);
                            array_delta_year.push([data_year, intero_year_11]);

                        }
                        if (month != month_prec) {

                            if (intero11 >= intero_month_start_11) {
                                intero_month_11 = intero11 - intero_month_start_11;
                            }
                            else {
                                intero_month_11 = intero11;
                            }
                            data_month = Date.UTC(year_prec, month_prec);
                            array_delta_month.push([data_month, intero_month_11]);

                        }

                        if (day != day_prec) {
                            //alert(intero_day_start);
                            //alert(intero5);
                            if (intero11 >= intero_day_start_11) {
                                intero_day_11 = intero11 - intero_day_start_11;
                                // alert(intero_day);
                            }
                            else {
                                intero_day_11 = intero11;
                            }
                            data_day = Date.UTC(year_prec, month_prec, day_prec);
                            array_delta_day.push([data_day, intero_day_11]);

                        }

                        if (year != year_prec) {
                            //year_prec = year;
                            intero_year_start_11 = parseFloat(v);
                        }
                        if (month != month_prec) {
                            //month_prec = month;
                            intero_month_start_11 = parseFloat(v);
                        }
                        if (day != day_prec) {
                            //day_prec = day;
                            intero_day_start_11 = parseFloat(v);
                        }

                        intero11 = parseFloat(v);
                        array_delta.push([data, intero11]);
                        indice = indice + 1;
                        break;
                    case 12:
                        if (year != year_prec) {

                            if (intero12 >= intero_year_start_12) {
                                intero_year_12 = intero12 - intero_year_start_12;
                            }
                            else {
                                intero_year_12 = intero12;
                            }
                            data_year = Date.UTC(year_prec, month_prec);
                            array_differential_year.push([data_year, intero_year_12]);

                        }
                        if (month != month_prec) {

                            if (intero12 >= intero_month_start_12) {
                                intero_month_12 = intero12 - intero_month_start_12;
                            }
                            else {
                                intero_month_12 = intero12;
                            }
                            data_month = Date.UTC(year_prec, month_prec);
                            array_differential_month.push([data_month, intero_month_12]);

                        }

                        if (day != day_prec) {
                            //alert(intero_day_start);
                            //alert(intero5);
                            if (intero12 >= intero_day_start_12) {
                                intero_day_12 = intero12 - intero_day_start_12;
                                // alert(intero_day);
                            }
                            else {
                                intero_day_12 = intero12;
                            }
                            data_day = Date.UTC(year_prec, month_prec, day_prec);
                            array_differential_day.push([data_day, intero_day_12]);

                        }

                        if (year != year_prec) {
                            year_prec = year;
                            intero_year_start_12 = parseFloat(v);
                        }
                        if (month != month_prec) {
                            month_prec = month;
                            intero_month_start_12 = parseFloat(v);
                        }
                        if (day != day_prec) {
                            day_prec = day;
                            intero_day_start_12 = parseFloat(v);
                        }

                        intero12 = parseFloat(v);
                        array_differential.push([data, intero12]);
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
            array_pump1_year.push([data_year, intero_year_1]);

            if (intero1 >= intero_month_start_1) {
                intero_month_1 = intero1 - intero_month_start_1;
            }
            else {
                intero_month_1 = intero1;
            }
            data_month = Date.UTC(year_prec, month_prec);
            array_pump1_month.push([data_month, intero_month_1]);

            if (intero1 >= intero_day_start_1) {
                intero_day_1 = intero1 - intero_day_start_1;
                // alert(intero_day);
            }
            else {
                intero_day_1 = intero1;
            }
            data_day = Date.UTC(year_prec, month_prec, day_prec);
            array_pump1_day.push([data_day, intero_day_1]);

            if (intero2 >= intero_year_start_2) {
                intero_year_2 = intero2 - intero_year_start_2;
            }
            else {
                intero_year_2 = intero2;
            }
            data_year = Date.UTC(year_prec, month_prec, day_prec);
            array_pump2_year.push([data_year, intero_year_2]);

            if (intero2 >= intero_month_start_2) {
                intero_month_2 = intero2 - intero_month_start_2;
            }
            else {
                intero_month_2 = intero2;
            }
            data_month = Date.UTC(year_prec, month_prec);
            array_pump2_month.push([data_month, intero_month_2]);

            if (intero2 >= intero_day_start_2) {
                intero_day_2 = intero2 - intero_day_start_2;
                // alert(intero_day);
            }
            else {
                intero_day_2 = intero2;
            }
            data_day = Date.UTC(year_prec, month_prec, day_prec);
            array_pump2_day.push([data_day, intero_day_2]);

            if (intero3 >= intero_year_start_3) {
                intero_year_3 = intero3 - intero_year_start_3;
            }
            else {
                intero_year_3 = intero3;
            }
            data_year = Date.UTC(year_prec, month_prec, day_prec);
            array_pump3_year.push([data_year, intero_year_3]);

            if (intero3 >= intero_month_start_3) {
                intero_month_3 = intero3 - intero_month_start_3;
            }
            else {
                intero_month_3 = intero3;
            }
            data_month = Date.UTC(year_prec, month_prec);
            array_pump3_month.push([data_month, intero_month_3]);

            if (intero3 >= intero_day_start_3) {
                intero_day_3 = intero3 - intero_day_start_3;
                // alert(intero_day);
            }
            else {
                intero_day_3 = intero3;
            }
            data_day = Date.UTC(year_prec, month_prec, day_prec);
            array_pump3_day.push([data_day, intero_day_3]);

            if (intero4 >= intero_year_start_4) {
                intero_year_4 = intero4 - intero_year_start_4;
            }
            else {
                intero_year_4 = intero4;
            }
            data_year = Date.UTC(year_prec, month_prec, day_prec);
            array_pump4_year.push([data_year, intero_year_4]);

            if (intero4 >= intero_month_start_4) {
                intero_month_4 = intero4 - intero_month_start_4;
            }
            else {
                intero_month_4 = intero4;
            }
            data_month = Date.UTC(year_prec, month_prec);
            array_pump4_month.push([data_month, intero_month_4]);

            if (intero4 >= intero_day_start_4) {
                intero_day_4 = intero4 - intero_day_start_4;
                // alert(intero_day);
            }
            else {
                intero_day_4 = intero4;
            }
            data_day = Date.UTC(year_prec, month_prec, day_prec);
            array_pump4_day.push([data_day, intero_day_4]);

            if (intero5 >= intero_year_start_5) {
                intero_year_5 = intero5 - intero_year_start_5;
            }
            else {
                intero_year_5 = intero5;
            }

            data_year = Date.UTC(year_prec, month_prec, day_prec);
            array_pump5_year.push([data_year, intero_year_5]);

            if (intero5 >= intero_month_start_5) {
                intero_month_5 = intero5 - intero_month_start_5;
            }
            else {
                intero_month_5 = intero5;
            }
            data_month = Date.UTC(year_prec, month_prec);
            array_pump5_month.push([data_month, intero_month_5]);

            if (intero5 >= intero_day_start_5) {
                intero_day_5 = intero5 - intero_day_start_5;
                // alert(intero_day);
            }
            else {
                intero_day_5 = intero_5;
            }
            data_day = Date.UTC(year_prec, month_prec, day_prec);
            array_pump5_day.push([data_day, intero_day_5]);

            //wm
            if (intero6 >= intero_year_start_6) {
                intero_year_6 = intero6 - intero_year_start_6;
            }
            else {
                intero_year_6 = intero6;
            }

            data_year = Date.UTC(year_prec, month_prec, day_prec);
            array_wm1_year.push([data_year, intero_year_6]);

            if (intero6 >= intero_month_start_6) {
                intero_month_6 = intero6 - intero_month_start_6;
            }
            else {
                intero_month_6 = intero6;
            }
            data_month = Date.UTC(year_prec, month_prec);
            array_wm1_month.push([data_month, intero_month_6]);

            if (intero6 >= intero_day_start_6) {
                intero_day_6 = intero6 - intero_day_start_6;
                // alert(intero_day);
            }
            else {
                intero_day_6 = intero_6;
            }
            data_day = Date.UTC(year_prec, month_prec, day_prec);
            array_wm1_day.push([data_day, intero_day_6]);
            //wm2
            if (intero7 >= intero_year_start_7) {
                intero_year_7 = intero7 - intero_year_start_7;
            }
            else {
                intero_year_7 = intero7;
            }

            data_year = Date.UTC(year_prec, month_prec, day_prec);
            array_wm2_year.push([data_year, intero_year_7]);

            if (intero7 >= intero_month_start_7) {
                intero_month_7 = intero7 - intero_month_start_7;
            }
            else {
                intero_month_7 = intero7;
            }
            data_month = Date.UTC(year_prec, month_prec);
            array_wm2_month.push([data_month, intero_month_7]);

            if (intero7 >= intero_day_start_7) {
                intero_day_7 = intero7 - intero_day_start_7;
                // alert(intero_day);
            }
            else {
                intero_day_7 = intero_7;
            }
            data_day = Date.UTC(year_prec, month_prec, day_prec);
            array_wm2_day.push([data_day, intero_day_7]);
            //wm3
            if (intero8 >= intero_year_start_8) {
                intero_year_8 = intero8 - intero_year_start_8;
            }
            else {
                intero_year_8 = intero8;
            }

            data_year = Date.UTC(year_prec, month_prec, day_prec);
            array_wm3_year.push([data_year, intero_year_8]);

            if (intero8 >= intero_month_start_8) {
                intero_month_8 = intero8 - intero_month_start_8;
            }
            else {
                intero_month_8 = intero8;
            }
            data_month = Date.UTC(year_prec, month_prec);
            array_wm3_month.push([data_month, intero_month_8]);

            if (intero8 >= intero_day_start_8) {
                intero_day_8 = intero8 - intero_day_start_8;
                // alert(intero_day);
            }
            else {
                intero_day_8 = intero_8;
            }
            data_day = Date.UTC(year_prec, month_prec, day_prec);
            array_wm3_day.push([data_day, intero_day_8]);
            //wm4
            if (intero9 >= intero_year_start_9) {
                intero_year_9 = intero9 - intero_year_start_9;
            }
            else {
                intero_year_9 = intero9;
            }

            data_year = Date.UTC(year_prec, month_prec, day_prec);
            array_wm4_year.push([data_year, intero_year_9]);

            if (intero9 >= intero_month_start_9) {
                intero_month_9 = intero9 - intero_month_start_9;
            }
            else {
                intero_month_9 = intero9;
            }
            data_month = Date.UTC(year_prec, month_prec);
            array_wm4_month.push([data_month, intero_month_9]);

            if (intero9 >= intero_day_start_9) {
                intero_day_9 = intero9 - intero_day_start_9;
                // alert(intero_day);
            }
            else {
                intero_day_9 = intero_9;
            }
            data_day = Date.UTC(year_prec, month_prec, day_prec);
            array_wm4_day.push([data_day, intero_day_9]);
            //wm5
            if (intero10 >= intero_year_start_10) {
                intero_year_10 = intero10 - intero_year_start_10;
            }
            else {
                intero_year_10 = intero10;
            }

            data_year = Date.UTC(year_prec, month_prec, day_prec);
            array_wm5_year.push([data_year, intero_year_10]);

            if (intero10 >= intero_month_start_10) {
                intero_month_10 = intero10 - intero_month_start_10;
            }
            else {
                intero_month_10 = intero10;
            }
            data_month = Date.UTC(year_prec, month_prec);
            array_wm5_month.push([data_month, intero_month_10]);

            if (intero10 >= intero_day_start_10) {
                intero_day_10 = intero10 - intero_day_start_10;
                // alert(intero_day);
            }
            else {
                intero_day_10 = intero_10;
            }
            data_day = Date.UTC(year_prec, month_prec, day_prec);
            array_wm5_day.push([data_day, intero_day_10]);
            //delta
            if (intero11 >= intero_year_start_11) {
                intero_year_11 = intero11 - intero_year_start_11;
            }
            else {
                intero_year_11 = intero11;
            }

            data_year = Date.UTC(year_prec, month_prec, day_prec);
            array_delta_year.push([data_year, intero_year_11]);

            if (intero11 >= intero_month_start_11) {
                intero_month_11 = intero11 - intero_month_start_11;
            }
            else {
                intero_month_11 = intero11;
            }
            data_month = Date.UTC(year_prec, month_prec);
            array_delta_month.push([data_month, intero_month_11]);

            if (intero11 >= intero_day_start_11) {
                intero_day_11 = intero11 - intero_day_start_11;
                // alert(intero_day);
            }
            else {
                intero_day_11 = intero_11;
            }
            data_day = Date.UTC(year_prec, month_prec, day_prec);
            array_delta_day.push([data_day, intero_day_11]);
            //            array.push(array_temp);
            //differential
            if (intero12 >= intero_year_start_12) {
                intero_year_12 = intero12 - intero_year_start_12;
            }
            else {
                intero_year_12 = intero12;
            }

            data_year = Date.UTC(year_prec, month_prec, day_prec);
            array_differential_year.push([data_year, intero_year_12]);

            if (intero12 >= intero_month_start_12) {
                intero_month_12 = intero12 - intero_month_start_12;
            }
            else {
                intero_month_12 = intero12;
            }
            data_month = Date.UTC(year_prec, month_prec);
            array_differential_month.push([data_month, intero_month_12]);

            if (intero12 >= intero_day_start_12) {
                intero_day_12 = intero12 - intero_day_start_12;
                // alert(intero_day);
            }
            else {
                intero_day_12 = intero_12;
            }
            data_day = Date.UTC(year_prec, month_prec, day_prec);
            array_differential_day.push([data_day, intero_day_12]);
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
    var array_temp6 = [];
    var array_temp7 = [];
    var array_temp8 = [];
    var array_temp9 = [];
    var array_temp10 = [];
    var array_temp11 = [];
    var array_temp12 = [];
    
    //alert(array_pump1[1]);
    if ($('#all_val').is(':checked')) {
        
        name_global = $('#all_val_label').text();
        array_temp1 = array_pump1;
        array_temp2 = array_pump2;
        array_temp3 = array_pump3;
        array_temp4 = array_pump4;
        array_temp5 = array_pump5;

        array_temp6 = array_wm1;
        array_temp7 = array_wm2;
        array_temp8 = array_wm3;
        array_temp9 = array_wm4;
        array_temp10 = array_wm5;
        array_temp11 = array_delta;
        array_temp12 = array_differential;
        
    }

    if ($('#day_val').is(':checked')) {
        name_global = $('#day_val_label').text();
        array_temp1 = array_pump1_day;
        array_temp2 = array_pump2_day;
        array_temp3 = array_pump3_day;
        array_temp4 = array_pump4_day;
        array_temp5 = array_pump5_day;

        array_temp6 = array_wm1_day;
        array_temp7 = array_wm2_day;
        array_temp8 = array_wm3_day;
        array_temp9 = array_wm4_day;
        array_temp10 = array_wm5_day;
        array_temp11 = array_delta_day;
        array_temp12 = array_differential_day;

        /*array_temp2 = array_pump2;
        array_temp3 = array_pump3;
        array_temp4 = array_pump4;
        array_temp5 = array_pump5;*/

    }
    if ($('#month_val').is(':checked')) {
        name_global = $('#month_val_label').text();
        array_temp1 = array_pump1_month;
        array_temp2 = array_pump2_month;
        array_temp3 = array_pump3_month;
        array_temp4 = array_pump4_month;
        array_temp5 = array_pump5_month;

        array_temp6 = array_wm1_month;
        array_temp7 = array_wm2_month;
        array_temp8 = array_wm3_month;
        array_temp9 = array_wm4_month;
        array_temp10 = array_wm5_month;
        array_temp11 = array_delta_month;
        array_temp12 = array_differential_month;

    }
    if ($('#year_val').is(':checked')) {
        name_global = $('#year_val_label').text();
        array_temp1 = array_pump1_year;
        array_temp2 = array_pump2_year;
        array_temp3 = array_pump3_year;
        array_temp4 = array_pump4_year;
        array_temp5 = array_pump5_year;

        array_temp6 = array_wm1_year;
        array_temp7 = array_wm2_year;
        array_temp8 = array_wm3_year;
        array_temp9 = array_wm4_year;
        array_temp10 = array_wm5_year;
        array_temp11 = array_delta_year;
        array_temp12 = array_differential_year;

    }

    if ($('#pump1_val').is(':checked')) {
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
    if ($('#pump2_val').is(':checked')) {
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
    if ($('#pump3_val').is(':checked')) {
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
    if ($('#pump4_val').is(':checked')) {
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
    if ($('#pump5_val').is(':checked')) {
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

    if ($('#wm1_val').is(':checked')) {
        series_chart.push({
            name: name6,
            id: 'ch1_val_series1',
            //data: array_db_picco,
            data: array_temp6,
            tooltip: {
                valueDecimals: 2
            }
        });
    }
    if ($('#wm2_val').is(':checked')) {
        series_chart.push({
            name: name7,
            id: 'ch1_val_series1',
            //data: array_db_picco,
            data: array_temp7,
            tooltip: {
                valueDecimals: 2
            }


            //pointStart: date_start
            //pointInterval: 3600 * 1000,
        });
    }
    if ($('#wm3_val').is(':checked')) {
        series_chart.push({
            name: name8,
            id: 'ch1_val_series1',
            //data: array_db_picco,
            data: array_temp8,
            tooltip: {
                valueDecimals: 2
            }


            //pointStart: date_start
            //pointInterval: 3600 * 1000,
        });
    }
    if ($('#wm4_val').is(':checked')) {
        series_chart.push({
            name: name9,
            id: 'ch1_val_series1',
            //data: array_db_picco,
            data: array_temp9,
            tooltip: {
                valueDecimals: 2
            }


            //pointStart: date_start
            //pointInterval: 3600 * 1000,
        });
    }
    if ($('#wm5_val').is(':checked')) {
        series_chart.push({
            name: name10,
            id: 'ch1_val_series1',
            //data: array_db_picco,
            data: array_temp10,
            tooltip: {
                valueDecimals: 2
            }


            //pointStart: date_start
            //pointInterval: 3600 * 1000,
        });
    }
    if ($('#delta_val').is(':checked')) {
        series_chart.push({
            name: name11,
            id: 'ch1_val_series1',
            //data: array_db_picco,
            data: array_temp11,
            tooltip: {
                valueDecimals: 2
            }


            //pointStart: date_start
            //pointInterval: 3600 * 1000,
        });
    }
    if ($('#percent_val').is(':checked')) {
        series_chart.push({
            name: name12,
            id: 'ch1_val_series1',
            //data: array_db_picco,
            data: array_temp12,
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
    //alert(series_chart.length);
    crea_tabella(array_temp1, array_temp2, array_temp3, array_temp4, array_temp5, array_temp6, array_temp7, array_temp8, array_temp9, array_temp10, array_temp11, array_temp12, $('#all_val').is(':checked'), $('#day_val').is(':checked'), $('#month_val').is(':checked'), $('#year_val').is(':checked'), $('#pump1_val').is(':checked'), $('#pump2_val').is(':checked'), $('#pump3_val').is(':checked'), $('#pump4_val').is(':checked'), $('#pump5_val').is(':checked'), $('#wm1_val').is(':checked'), $('#wm2_val').is(':checked'), $('#wm3_val').is(':checked'), $('#wm4_val').is(':checked'), $('#wm5_val').is(':checked'), $('#delta_val').is(':checked'), $('#percent_val').is(':checked'));
}

function crea_tabella(array_temp1, array_temp2, array_temp3, array_temp4, array_temp5, array_temp6, array_temp7, array_temp8, array_temp9, array_temp10, array_temp11, array_temp12, all_temp, day_temp, month_temp, year_temp, pump1_temp, pump2_temp, pump3_temp, pump4_temp, pump5_temp, pump6_temp, pump7_temp, pump8_temp, pump9_temp, pump10_temp, pump11_temp, pump12_temp) {
    var i = 0;
    var header_array = [];
    var header_value = [];
    var oggetto = {};
    oggetto = { "title": "Date" }
    header_array.push(oggetto)

    if (pump1_temp) {
        oggetto = { "title": name1 };
        header_array.push(oggetto);
    }
    if (pump2_temp) {
        oggetto = { "title": name2 };
        header_array.push(oggetto);
    }
    if (pump3_temp) {
        oggetto = { "title": name3 };
        header_array.push(oggetto);
    }
    if (pump4_temp) {
        oggetto = { "title": name4 };
        header_array.push(oggetto);
    }
    if (pump5_temp) {
        oggetto = { "title": name5 };
        header_array.push(oggetto);
    }
    if (pump6_temp) {
        oggetto = { "title": name6 };
        header_array.push(oggetto);
    }
    if (pump7_temp) {
        oggetto = { "title": name7 };
        header_array.push(oggetto);
    }
    if (pump8_temp) {
        oggetto = { "title": name8 };
        header_array.push(oggetto);
    }
    if (pump9_temp) {
        oggetto = { "title": name9 };
        header_array.push(oggetto);
    }
    if (pump10_temp) {
        oggetto = { "title": name10 };
        header_array.push(oggetto);
    }
    if (pump11_temp) {
        oggetto = { "title": name11 };
        header_array.push(oggetto);
    }
    if (pump12_temp) {
        oggetto = { "title": name12 };
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
            array_temp.push(get_numero_string(thetoday) + "/" + get_numero_string(themonth) + "/" + get_numero_string(theyear));
        }
        if (month_temp) {
            array_temp.push(get_numero_string(themonth) + "/" + get_numero_string(theyear));
        }
        if (year_temp) {
            array_temp.push(get_numero_string(theyear));
        }

        if (pump1_temp) {
            array_temp.push(parseFloat(array_temp1[i][1]).toFixed(2));
        }
        if (pump2_temp) {
            array_temp.push(parseFloat(array_temp2[i][1]).toFixed(2));
        }
        if (pump3_temp) {
            array_temp.push(parseFloat(array_temp3[i][1]).toFixed(2));
        }
        if (pump4_temp) {
            array_temp.push(parseFloat(array_temp4[i][1]).toFixed(2));
        }
        if (pump5_temp) {
            array_temp.push(parseFloat(array_temp5[i][1]).toFixed(2));
        }
        if (pump6_temp) {
            array_temp.push(parseFloat(array_temp6[i][1]).toFixed(2));
        }
        if (pump7_temp) {
            array_temp.push(parseFloat(array_temp7[i][1]).toFixed(2));
        }
        if (pump8_temp) {
            array_temp.push(parseFloat(array_temp8[i][1]).toFixed(2));
        }
        if (pump9_temp) {
            array_temp.push(parseFloat(array_temp9[i][1]).toFixed(2));
        }
        if (pump10_temp) {
            array_temp.push(parseFloat(array_temp10[i][1]).toFixed(2));
        }
        if (pump11_temp) {
            array_temp.push(parseFloat(array_temp11[i][1]).toFixed(2));
        }
        if (pump12_temp) {
            array_temp.push(parseFloat(array_temp12[i][1]).toFixed(2));
        }

        header_value.push(array_temp);
        i = i - 1
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

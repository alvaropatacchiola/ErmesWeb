function create_chart(series_val,Text_graph,yAxis) {
    $('#container').highcharts('StockChart', {


        rangeSelector: {
            enabled: true
        },

        title: {
            text: Text_graph
        },
        yAxis: yAxis,
        
            plotOptions: {
        scatter: {
                        marker: {
                    radius: 1.2
                        }
        }
            },
        series: series_val
    });
}

function ordinaArray(){
probeCh1.sort();
probeCh2.sort();
probeCh3.sort();
probeCh4.sort();
timeLimitR.sort();
conductivityAlarmLowR.sort();
conductivityAlarmHighR.sort();
}

function upgrate_chart() {
    var series_chart = [];
    var yaxis_chart = [];
    var numero_asse = 0;
	var altezza = 100;
     ordinaArray();
if (($('#probeCh1check').is(':checked'))) {
        series_chart.push(createGraphLineSeries(probeCh1,numero_asse,probeCh1_str));
	numero_asse = numero_asse + 1;		
	//altezza = altezza + 300;		
        yaxis_chart.push(createGraphLineY(probeCh1_str,altezza));
}
if (($('#timeLimitRcheck').is(':checked'))) {
	series_chart.push(createGraphStepSeries(timeLimitR,numero_asse,timeLimitR_str),createGraphStepSeries1(timeLimitR,numero_asse,timeLimitR_str))
        numero_asse = numero_asse + 1;		
	altezza = altezza + 300;
	yaxis_chart.push(createGraphStepY(timeLimitR_str,altezza));

}
if (($('#conductivityAlarmLowRcheck').is(':checked'))) {
	series_chart.push(createGraphStepSeries(conductivityAlarmLowR,numero_asse,conductivityAlarmLowR_str),createGraphStepSeries1(conductivityAlarmLowR,numero_asse,conductivityAlarmLowR_str))
        numero_asse = numero_asse + 1;		
	altezza = altezza + 300;
	yaxis_chart.push(createGraphStepY(conductivityAlarmLowR_str,altezza));

}
if (($('#conductivityAlarmHighRcheck').is(':checked'))) {
	series_chart.push(createGraphStepSeries(conductivityAlarmHighR,numero_asse,conductivityAlarmHighR_str),createGraphStepSeries1(conductivityAlarmHighR,numero_asse,conductivityAlarmHighR_str))
        numero_asse = numero_asse + 1;		
	altezza = altezza + 300;
	yaxis_chart.push(createGraphStepY(conductivityAlarmHighR_str,altezza));

}

if (($('#probeCh2check').is(':checked'))) {
        series_chart.push(createGraphLineSeries(probeCh2,numero_asse,probeCh2_str));
        numero_asse = numero_asse + 1;		
	altezza = altezza + 300;
	yaxis_chart.push(createGraphLineY(probeCh2_str,altezza));
}
if (($('#probeCh3check').is(':checked'))) {
        series_chart.push(createGraphLineSeries(probeCh3,numero_asse,probeCh3_str));
        numero_asse = numero_asse + 1;		
	altezza = altezza + 300;
	yaxis_chart.push(createGraphLineY(probeCh3_str,altezza));
}		
altezza = altezza + 300;
numero_asse = numero_asse + 1;


$("#container").height(altezza);

create_chart(series_chart, "Centurio", yaxis_chart);
draw_tabella();
}
function createGraphLineSeries(arrayStepTemp,numero_asse,strStepTemp)
{
	return ({
            name: strStepTemp,
            id: 'ch1_val_series',
            data: arrayStepTemp,
            yAxis: numero_asse,
            marker: {
                enabled: true,
                radius: 3
            },
            tooltip: {
                valueDecimals: 2
            }
        });
}
function createGraphLineY(strStepTemp,altezzaTemp){
return ({
            title: {
                text: strStepTemp
            },
            opposite: false,
            id: 'ch2_val',
			top: altezzaTemp,
            height: 200,
            lineWidth: 2
        });
}
function createGraphStepSeries(arrayStepTemp,numero_asse,strStepTemp)
{
 
 
        return({
            id: strStepTemp,
            name: strStepTemp,
            data: arrayStepTemp,
            step: true,
            type: 'scatter',
            lineWidth: 2,
            yAxis: numero_asse
        });
}	
function createGraphStepSeries1(arrayStepTemp,numero_asse,strStepTemp)
{
 return({
            id: strStepTemp,
            name: strStepTemp,
            data: arrayStepTemp,
            //type:'line',
            step: true,
            shadow: false,
            color: 'rgba(255,255,255,0.1)',
            tooltip: {
                //pointFormat: '<span style="#FFFFF">{series.name}:<b>{point.y}</b></span>',
                // formatter: '<span style="#FFFFF">{series.name}:<b>{point.y}</b></span>',
                pointFormat: '<span style="#FFFFF">{series.name}:<b>{point.y}</b></span><br/>',
	        /*formatter: function () {
                    if (this.y == 1) {
                        return '<span style="#FFFFF">ciao:<b>ON</b></span><br/>';
                    }
                    else {
                        return '<span style="#FFFFF">ciao:<b>OFF</b></span><br/>';
                    }
                },*/

                valueDecimals: 0
            },
            lineWidth: 2,
            shared: true,
            yAxis: numero_asse
        });
}
function createGraphStepY(strStepTemp,altezzaTemp){
	return({
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
            opposite: false,
            title: {
                text: strStepTemp
            },
            top: altezzaTemp,
            height: 100,
            offset: 0,
            lineWidth: 2,
            max: 2,
            min: 0
        });

 }     
   

function draw_tabella() {

    var chart = $('#container').highcharts();
    var series_chart = chart.series;
    var header_array = [];
    var header_value = [];
    var oggetto = {};
    var string_array = "";
    var string_array_precedent = "";
    var i = 0;
    oggetto = { "title": "Date" }
    header_array.push(oggetto)
    


    $.each(series_chart, function (row, series_chart_temp) {
        if ((series_chart_temp.name != "Navigator") && ((series_chart_temp.type != "scatter"))) {
            // if (string_array == "") {
            // string_array = string_array + '[{ "title": "' + series_chart_temp.name + '" }'
            //string_array = string_array + '"title": "' + series_chart_temp.name + '"'
            oggetto = { "title": series_chart_temp.name };
            header_array.push(oggetto);

            //header_value.push(point.);
        }
        string_array_precedent = series_chart_temp.name;
    });
    i = probeCh1.length - 1;
   // i=0;
    $.each(probeCh1, function (row1, point1) {
        var array_temp = [];
        var date = new Date(probeCh1[i][0]);
        date = convertUTCDateToLocalDate(date);

        var theyear = date.getFullYear()
        var themonth = date.getMonth() + 1;
        var thetoday = date.getDate();
        var ore = date.getHours();
        var minuti = date.getMinutes();
        //var data_confronto = parseDate(thetoday + "/" + themonth + "/" + theyear, 'dd/mm/yy');
            
                array_temp.push(get_numero_string(thetoday) + "/" + get_numero_string(themonth) + "/" + get_numero_string(theyear) + " " + get_numero_string(ore) + ":" + get_numero_string(minuti));
            //array_temp.push(thetoday + "/" + themonth + "/" + theyear + " " + ore  + ":" + minuti);
//            if (($('#ch1_val_ld').is(':checked'))) {
if (($('#probeCh1check').is(':checked'))) {
                array_temp.push(probeCh1[i][1]);
		}
if (($('#probeCh2check').is(':checked'))) {		
                array_temp.push(probeCh2[i][1]);
		}
if (($('#probeCh3check').is(':checked'))) {				
                array_temp.push(probeCh3[i][1]);
		}
if (($('#probeCh4check').is(':checked'))) {						
                array_temp.push(probeCh4[i][1]);
		}
  //          }


            
            header_value.push(array_temp);

        i = i - 1;
	 //i = i + 1;
    });

    // header_array.push(string_array);
    $('#chart_table').html('<table cellpadding="0" cellspacing="0" border="0" class="display dynamicTable table table-striped table-bordered table-condensed" id="example"></table>');

    $('#example').dataTable({
        dom: 'Bfrtip',
        buttons: [
            'copy', 'csv', 'excel', 'pdf', 'print'
        ],
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
        return "ON"
    else
        return "OFF"
}
function convertUTCDateToLocalDate(convertdLocalTime) {


    var hourOffset = convertdLocalTime.getTimezoneOffset() / 60;

    convertdLocalTime.setHours(convertdLocalTime.getHours() + hourOffset);

    return convertdLocalTime;
}

$( "#containerHead" ).html(function() {
  var html = "<div class=\"checkbox\" id=\"canale1\">";
  html = html + "<label><input type=\"checkbox\" id=\"probeCh1check\" checked>" + probeCh1_str + "</label>";
  html = html + "<label><input type=\"checkbox\" id=\"timeLimitRcheck\">" + timeLimitR_str + "</label>";
  html = html + "<label><input type=\"checkbox\" id=\"conductivityAlarmLowRcheck\">" + conductivityAlarmLowR_str + "</label>";
  html = html + "<label><input type=\"checkbox\" id=\"conductivityAlarmHighRcheck\">" + conductivityAlarmHighR_str + "</label>";
  html = html + "</div>"
  html = html + "<div class=\"checkbox\" id=\"canale2\">";
  html = html + "<label><input type=\"checkbox\" id=\"probeCh2check\" checked>" + probeCh2_str + "</label>";
  html = html + "<label><input type=\"checkbox\" id=\"pHAlarmLowRcheck\">" + pHAlarmLowR_str + "</label>";
  html = html + "<label><input type=\"checkbox\" id=\"pHAlarmHighRcheck\">" + pHAlarmHighR_str + "</label>";
  html = html + "</div>"
  html = html + "<div class=\"checkbox\" id=\"canale3\">";
  html = html + "<label><input type=\"checkbox\" id=\"probeCh3check\" checked>" + probeCh3_str + "</label>";
  html = html + "<label><input type=\"checkbox\" id=\"chlorineAlarmLowRcheck\">" + chlorineAlarmLowR_str + "</label>";
  html = html + "<label><input type=\"checkbox\" id=\"chlorineAlarmHighRcheck\">" + chlorineAlarmHighR_str + "</label>";
  html = html + "</div>"
  html = html + "<div class=\"checkbox\" >";
  html = html + "<input type=\"button\" value =\"Refresh\" id=\"refresh\">";
  html = html + "</div>"
  return html;
});
$("#refresh").click(function () {

    upgrate_chart();

});



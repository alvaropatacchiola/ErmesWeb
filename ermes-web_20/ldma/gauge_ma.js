// The speed gauge
var gaugeOptions = {

    chart: {
        type: 'solidgauge'
    },

    title: null,

    pane: {
        center: ['50%', '80%'],
        size: '100%',
        startAngle: -90,
        endAngle: 90,
        background: {
            backgroundColor: (Highcharts.theme && Highcharts.theme.background2) || '#EEE',
            innerRadius: '60%',
            outerRadius: '100%',
            shape: 'arc'
        }
    },

    tooltip: {
        enabled: false
    },

    // the value axis
    yAxis: {
        lineWidth: 0,
        minorTickInterval: 0,
        //tickPixelInterval: 400,
        startOnTick: false,
        tickWidth: 0,
        title: {
            y: -70
        },
        labels: {
            y: 16
        }
    },

    plotOptions: {
        solidgauge: {
            dataLabels: {
                y: 5,
                borderWidth: 0,
                useHTML: true
            }
        }
    }
};



// Bring life to the dials
/*setInterval(function () {
    // Speed
    var chart = $('#container-speed1').highcharts(),
        point,
        newVal,
        inc;

    if (chart) {
        point = chart.series[0].points[0];
        inc = Math.round((Math.random() - 0.5) * 100);
        newVal = point.y + inc;

        if (newVal < 0 || newVal > 200) {
            newVal = point.y - inc;
        }

        point.update(newVal);
    }
    // RPM
    chart = $('#container-rpm1').highcharts();
    if (chart) {
        point = chart.series[0].points[0];
        inc = Math.random() - 0.5;
        newVal = point.y + inc;

        if (newVal < 0 || newVal > 5) {
            newVal = point.y - inc;
        }

        point.update(newVal);
    }
    chart = $('#container-speed2').highcharts();
    if (chart) {
        point = chart.series[0].points[0];
        inc = Math.round((Math.random() - 0.5) * 100);
        newVal = point.y + inc;

        if (newVal < 0 || newVal > 200) {
            newVal = point.y - inc;
        }

        point.update(newVal);
    }
    // RPM
    chart = $('#container-rpm2').highcharts();
    if (chart) {
        point = chart.series[0].points[0];
        inc = Math.random() - 0.5;
        newVal = point.y + inc;

        if (newVal < 0 || newVal > 5) {
            newVal = point.y - inc;
        }

        point.update(newVal);
    }
    chart = $('#container-speed3').highcharts();
    if (chart) {
        point = chart.series[0].points[0];
        inc = Math.round((Math.random() - 0.5) * 100);
        newVal = point.y + inc;

        if (newVal < 0 || newVal > 200) {
            newVal = point.y - inc;
        }

        point.update(newVal);
    }
    // RPM
    chart = $('#container-rpm3').highcharts();
    if (chart) {
        point = chart.series[0].points[0];
        inc = Math.random() - 0.5;
        newVal = point.y + inc;

        if (newVal < 0 || newVal > 5) {
            newVal = point.y - inc;
        }

        point.update(newVal);
    }
    chart = $('#container-speed4').highcharts();
    if (chart) {
        point = chart.series[0].points[0];
        inc = Math.round((Math.random() - 0.5) * 100);
        newVal = point.y + inc;

        if (newVal < 0 || newVal > 200) {
            newVal = point.y - inc;
        }

        point.update(newVal);
    }
    // RPM
    chart = $('#container-rpm4').highcharts();
    if (chart) {
        point = chart.series[0].points[0];
        inc = Math.random() - 0.5;
        newVal = point.y + inc;

        if (newVal < 0 || newVal > 5) {
            newVal = point.y - inc;
        }

        point.update(newVal);
    }
    chart = $('#container-speed5').highcharts();
    if (chart) {
        point = chart.series[0].points[0];
        inc = Math.round((Math.random() - 0.5) * 100);
        newVal = point.y + inc;

        if (newVal < 0 || newVal > 200) {
            newVal = point.y - inc;
        }

        point.update(newVal);
    }
    // RPM
    chart = $('#container-rpm5').highcharts();
    if (chart) {
        point = chart.series[0].points[0];
        inc = Math.random() - 0.5;
        newVal = point.y + inc;

        if (newVal < 0 || newVal > 5) {
            newVal = point.y - inc;
        }

        point.update(newVal);
    }
},


2000);
*/
var pippo = [10];
function create_gauge1(level_min, level_max, level_soglia, level_value, ma_min, ma_max, ma_value, name_totalizer, name_dayly, value_totalizer, valuedayly) {
    if (ma_value > ma_max) ma_max = ma_value;
    if (level_value > level_max) level_max = level_value;
    if (level_min == level_max) level_max = level_min + 10;
    
    $('#container-tot1').highcharts({
        chart: {
            type: 'bar'
        },
        title: {
            text: traduzione_totalizer
        },
       /* subtitle: {
            text: traduzione_totalizer_giornaliero
        },*/
        xAxis: {
            categories: [traduzione_totalizer],
            title: {
                text: null
            }
        },
        yAxis: {
            min: 0,
            //y:10,
            title: {
                text: 'Litre',
                align: 'high'
            },
            labels: {
                overflow: 'justify'
            }
        },
        tooltip: {
            valueSuffix: 'Litre'
        },
        plotOptions: {
            bar: {
                dataLabels: {
                    enabled: true
                }
            }
        },
        legend: {
            layout: 'vertical',
            align: 'right',
            verticalAlign: 'top',
            x: -30,
            y: 20,
            floating: true,
            borderWidth: 1,
            backgroundColor: ((Highcharts.theme && Highcharts.theme.legendBackgroundColor) || '#FFFFFF'),
            shadow: true
        },
        credits: {
            enabled: false
        },
        series: [{
            name: 'Totale',
            data: [value_totalizer[0]]
        }, {
            name: name_dayly,
            data: [valuedayly[0]]
        }]
    });
   
   
    $('#container-rpm1').highcharts(Highcharts.merge(gaugeOptions, {
        //alert("");
        yAxis: {
             min: ma_min,
            //min: 0,
            max: ma_max,
            //max: 20,
            stops: [
                    [0.1, '#DF5353'], // green
                    [0.5, '#DDDF0D'], // yellow
                    [0.9, '#55BF3B'] // red
            ],

            title: {
                text: 'mA'
            }
        },

        series: [{
            name: 'mA',
            data: [ma_value],
            //data: [10.20],
            dataLabels: {
                format: '<div style="text-align:center"><span style="font-size:25px;color:' +
                    ((Highcharts.theme && Highcharts.theme.contrastTextColor) || 'black') + '">{y:.1f}</span><br/>' +
                       '<span style="font-size:12px;color:silver">mA</span></div>'
            },
            tooltip: {
                valueSuffix: ' mA'
            }
        }]

    }));
    $('#container-speed1').highcharts(Highcharts.merge(gaugeOptions, {
        yAxis: {
            min: level_min,
            max: level_max,
            stops: [
                    //[0.1, '#DF5353'], // green
                    [level_soglia / level_max, '#DF5353'], // green
                    //[level_max / 3, '#DDDF0D'], // yellow
                    [(level_soglia / level_max)+0.2, '#DDDF0D'], // yellow
                    [0.9, '#55BF3B'] // red
            ],

            tickPositions: [level_min, level_soglia, level_max],
            title: {
                text: traduzione_level
            }
        },
        credits: {
            enabled: false
        },
        series: [{
            name: 'Level',
            data: [level_value],
            dataLabels: {
                format: '<div style="text-align:center"><br/><span style="font-size:25px;color:' +
                    ((Highcharts.theme && Highcharts.theme.contrastTextColor) || 'black') + '">{y:.1f}</span><br/>' +
                       '<span style="font-size:12px;color:silver">Litre</span></div>'
            },
            tooltip: {
                valueSuffix: ' Litre'
            }
        }]
    }));
}
function create_gauge2(level_min, level_max, level_soglia, level_value, ma_min, ma_max, ma_value, name_totalizer, name_dayly, value_totalizer, valuedayly) {
    if (ma_value > ma_max) ma_max = ma_value;
    if (level_value > level_max) level_max = level_value;
    if (level_min == level_max) level_max = level_min + 10;
    $('#container-tot2').highcharts({
        chart: {
            type: 'bar'
        },
        title: {
            text: traduzione_totalizer
        },
       /* subtitle: {
            text: traduzione_totalizer
        },*/
        xAxis: {
            categories: [traduzione_totalizer],
            title: {
                text: null
            }
        },
        yAxis: {
            min: 0,
            title: {
                text: 'Litre',
                align: 'high'
            },
            labels: {
                overflow: 'justify'
            }
        },
        tooltip: {
            valueSuffix: 'Litre'
        },
        plotOptions: {
            bar: {
                dataLabels: {
                    enabled: true
                }
            }
        },
        legend: {
            layout: 'vertical',
            align: 'right',
            verticalAlign: 'top',
            x: -30,
            y: 20,
            floating: true,
            borderWidth: 1,
            backgroundColor: ((Highcharts.theme && Highcharts.theme.legendBackgroundColor) || '#FFFFFF'),
            shadow: true
        },
        credits: {
            enabled: false
        },
        series: [{
            name: 'Totale',
            data: [value_totalizer[0]]
        }, {
            name: name_dayly,
            data: [valuedayly[0]]
        }]
    });

    $('#container-rpm2').highcharts(Highcharts.merge(gaugeOptions, {
        yAxis: {
            min: ma_min,
            max: ma_max,
            stops: [
                    [0.1, '#DF5353'], // green
                    [0.5, '#DDDF0D'], // yellow
                    [0.9, '#55BF3B'] // red
            ],

            title: {
                text: 'mA'
            }
        },

        series: [{
            name: 'mA',
            data: [ma_value],
            dataLabels: {
                format: '<div style="text-align:center"><span style="font-size:25px;color:' +
                    ((Highcharts.theme && Highcharts.theme.contrastTextColor) || 'black') + '">{y:.1f}</span><br/>' +
                       '<span style="font-size:12px;color:silver">mA</span></div>'
            },
            tooltip: {
                valueSuffix: ' mA'
            }
        }]

    }));
    $('#container-speed2').highcharts(Highcharts.merge(gaugeOptions, {
        yAxis: {
            min: level_min,
            max: level_max,
            stops: [
                    [level_soglia / level_max, '#DF5353'], // green
                    //[level_max / 3, '#DDDF0D'], // yellow
                    [(level_soglia / level_max) + 0.2, '#DDDF0D'], // yellow
                    [0.9, '#55BF3B'] // red
            ],

            tickPositions: [level_min, level_soglia, level_max],
            title: {
                text: traduzione_level
            }
        },
        credits: {
            enabled: false
        },
        series: [{
            name: 'Level',
            data: [level_value],
            dataLabels: {
                format: '<div style="text-align:center"><br/><span style="font-size:25px;color:' +
                    ((Highcharts.theme && Highcharts.theme.contrastTextColor) || 'black') + '">{y:.1f}</span><br/>' +
                       '<span style="font-size:12px;color:silver">Litre</span></div>'
            },
            tooltip: {
                valueSuffix: ' Litre'
            }
        }]
    }));
}
function create_gauge3(level_min, level_max, level_soglia, level_value, ma_min, ma_max, ma_value, name_totalizer, name_dayly, value_totalizer, valuedayly) {
    if (ma_value > ma_max) ma_max = ma_value;
    if (level_value > level_max) level_max = level_value;
    if (level_min == level_max) level_max = level_min + 10;
    
    $('#container-tot3').highcharts({
        chart: {
            type: 'bar'
        },
        title: {
            text: traduzione_totalizer
        },
       /* subtitle: {
            text: traduzione_totalizer
        },*/
        xAxis: {
            categories: [traduzione_totalizer],
            title: {
                text: null
            }
        },
        yAxis: {
            min: 0,
            title: {
                text: 'Litre',
                align: 'high'
            },
            labels: {
                overflow: 'justify'
            }
        },
        tooltip: {
            valueSuffix: 'Litre'
        },
        plotOptions: {
            bar: {
                dataLabels: {
                    enabled: true
                }
            }
        },
        legend: {
            layout: 'vertical',
            align: 'right',
            verticalAlign: 'top',
            x: -30,
            y: 20,
            floating: true,
            borderWidth: 1,
            backgroundColor: ((Highcharts.theme && Highcharts.theme.legendBackgroundColor) || '#FFFFFF'),
            shadow: true
        },
        credits: {
            enabled: false
        },
        series: [{
            name: 'Totale',
            data: [value_totalizer[0]]
        }, {
            name: name_dayly,
            data: [valuedayly[0]]
        }]
    });

    $('#container-rpm3').highcharts(Highcharts.merge(gaugeOptions, {
        yAxis: {
            min: ma_min,
            max: ma_max,
            stops: [
                    [0.1, '#DF5353'], // green
                    [0.5, '#DDDF0D'], // yellow
                    [0.9, '#55BF3B'] // red
            ],

            title: {
                text: 'mA'
            }
        },

        series: [{
            name: 'mA',
            data: [ma_value],
            dataLabels: {
                format: '<div style="text-align:center"><span style="font-size:25px;color:' +
                    ((Highcharts.theme && Highcharts.theme.contrastTextColor) || 'black') + '">{y:.1f}</span><br/>' +
                       '<span style="font-size:12px;color:silver">mA</span></div>'
            },
            tooltip: {
                valueSuffix: ' mA'
            }
        }]

    }));
    $('#container-speed3').highcharts(Highcharts.merge(gaugeOptions, {
        yAxis: {
            min: level_min,
            max: level_max,
            stops: [
                    [level_soglia / level_max, '#DF5353'], // green
                    //[level_max / 3, '#DDDF0D'], // yellow
                    [(level_soglia / level_max) + 0.2, '#DDDF0D'], // yellow
                    [0.9, '#55BF3B'] // red
            ],

            tickPositions: [level_min, level_soglia, level_max],
            title: {
                text: traduzione_level
            }
        },
        credits: {
            enabled: false
        },
        series: [{
            name: 'Level',
            data: [level_value],
            dataLabels: {
                format: '<div style="text-align:center"><br/><span style="font-size:25px;color:' +
                    ((Highcharts.theme && Highcharts.theme.contrastTextColor) || 'black') + '">{y:.1f}</span><br/>' +
                       '<span style="font-size:12px;color:silver">Litre</span></div>'
            },
            tooltip: {
                valueSuffix: ' Litre'
            }
        }]
    }));
}
function create_gauge4(level_min, level_max, level_soglia, level_value, ma_min, ma_max, ma_value, name_totalizer, name_dayly, value_totalizer, valuedayly) {
    if (ma_value > ma_max) ma_max = ma_value;
    if (level_value > level_max) level_max = level_value;
    if (level_min == level_max) level_max = level_min + 10;
    $('#container-tot4').highcharts({
        chart: {
            type: 'bar'
        },
        title: {
            text: traduzione_totalizer
        },
      /*  subtitle: {
            text: traduzione_totalizer
        },*/
        xAxis: {
            categories: [traduzione_totalizer],
            title: {
                text: null
            }
        },
        yAxis: {
            min: 0,
            title: {
                text: 'Litre',
                align: 'high'
            },
            labels: {
                overflow: 'justify'
            }
        },
        tooltip: {
            valueSuffix: 'Litre'
        },
        plotOptions: {
            bar: {
                dataLabels: {
                    enabled: true
                }
            }
        },
        legend: {
            layout: 'vertical',
            align: 'right',
            verticalAlign: 'top',
            x: -30,
            y: 20,
            floating: true,
            borderWidth: 1,
            backgroundColor: ((Highcharts.theme && Highcharts.theme.legendBackgroundColor) || '#FFFFFF'),
            shadow: true
        },
        credits: {
            enabled: false
        },
        series: [{
            name: 'Totale',
            data: [value_totalizer[0]]
        }, {
            name: name_dayly,
            data: [valuedayly[0]]
        }]
    });

    $('#container-rpm4').highcharts(Highcharts.merge(gaugeOptions, {
        yAxis: {
            min: ma_min,
            max: ma_max,
            stops: [
                    [0.1, '#DF5353'], // green
                    [0.5, '#DDDF0D'], // yellow
                    [0.9, '#55BF3B'] // red
            ],

            title: {
                text: 'mA'
            }
        },

        series: [{
            name: 'mA',
            data: [ma_value],
            dataLabels: {
                format: '<div style="text-align:center"><span style="font-size:25px;color:' +
                    ((Highcharts.theme && Highcharts.theme.contrastTextColor) || 'black') + '">{y:.1f}</span><br/>' +
                       '<span style="font-size:12px;color:silver">mA</span></div>'
            },
            tooltip: {
                valueSuffix: ' mA'
            }
        }]

    }));
    $('#container-speed4').highcharts(Highcharts.merge(gaugeOptions, {
        yAxis: {
            min: level_min,
            max: level_max,
            stops: [
                    [level_soglia / level_max, '#DF5353'], // green
                    //[level_max / 3, '#DDDF0D'], // yellow
                    [(level_soglia / level_max) + 0.2, '#DDDF0D'], // yellow
                    [0.9, '#55BF3B'] // red
            ],

            tickPositions: [level_min, level_soglia, level_max],
            title: {
                text: traduzione_level
            }
        },
        credits: {
            enabled: false
        },
        series: [{
            name: 'Level',
            data: [level_value],
            dataLabels: {
                format: '<div style="text-align:center"><br/><span style="font-size:25px;color:' +
                    ((Highcharts.theme && Highcharts.theme.contrastTextColor) || 'black') + '">{y:.1f}</span><br/>' +
                       '<span style="font-size:12px;color:silver">Litre</span></div>'
            },
            tooltip: {
                valueSuffix: ' Litre'
            }
        }]
    }));
}
function create_gauge5(level_min, level_max, level_soglia, level_value, ma_min, ma_max, ma_value, name_totalizer, name_dayly, value_totalizer, valuedayly) {
    if (ma_value > ma_max) ma_max = ma_value;
    if (level_value > level_max) level_max = level_value;
    if (level_min == level_max) level_max = level_min + 10;
    $('#container-tot5').highcharts({
        chart: {
            type: 'bar'
        },
        title: {
            text: traduzione_totalizer
        },
       /* subtitle: {
            text: traduzione_totalizer
        },*/
        xAxis: {
            categories: [traduzione_totalizer],
            title: {
                text: null
            }
        },
        yAxis: {
            min: 0,
            title: {
                text: 'Litre',
                align: 'high'
            },
            labels: {
                overflow: 'justify'
            }
        },
        tooltip: {
            valueSuffix: 'Litre'
        },
        plotOptions: {
            bar: {
                dataLabels: {
                    enabled: true
                }
            }
        },
        legend: {
            layout: 'vertical',
            align: 'right',
            verticalAlign: 'top',
            x: -30,
            y: 20,
            floating: true,
            borderWidth: 1,
            backgroundColor: ((Highcharts.theme && Highcharts.theme.legendBackgroundColor) || '#FFFFFF'),
            shadow: true
        },
        credits: {
            enabled: false
        },
        series: [{
            name: 'Totale',
            data: [value_totalizer[0]]
        }, {
            name: name_dayly,
            data: [valuedayly[0]]
        }]
    });

    $('#container-rpm5').highcharts(Highcharts.merge(gaugeOptions, {
        yAxis: {
            min: ma_min,
            max: ma_max,
            stops: [
                    [0.1, '#DF5353'], // green
                    [0.5, '#DDDF0D'], // yellow
                    [0.9, '#55BF3B'] // red
            ],

            title: {
                text: 'mA'
            }
        },

        series: [{
            name: 'mA',
            data: [ma_value],
            dataLabels: {
                format: '<div style="text-align:center"><span style="font-size:25px;color:' +
                    ((Highcharts.theme && Highcharts.theme.contrastTextColor) || 'black') + '">{y:.1f}</span><br/>' +
                       '<span style="font-size:12px;color:silver">mA</span></div>'
            },
            tooltip: {
                valueSuffix: ' mA'
            }
        }]

    }));
    $('#container-speed5').highcharts(Highcharts.merge(gaugeOptions, {
        yAxis: {
            min: level_min,
            max: level_max,
            stops: [
                    [level_soglia / level_max, '#DF5353'], // green
                    //[level_max / 3, '#DDDF0D'], // yellow
                    [(level_soglia / level_max) + 0.2, '#DDDF0D'], // yellow
                    [0.9, '#55BF3B'] // red
            ],

            tickPositions: [level_min, level_soglia, level_max],
            title: {
                text: traduzione_level
            }
        },
        credits: {
            enabled: false
        },
        series: [{
            name: 'Level',
            data: [level_value],
            dataLabels: {
                format: '<div style="text-align:center"><br/><span style="font-size:25px;color:' +
                    ((Highcharts.theme && Highcharts.theme.contrastTextColor) || 'black') + '">{y:.1f}</span><br/>' +
                       '<span style="font-size:12px;color:silver">Litre</span></div>'
            },
            tooltip: {
                valueSuffix: ' Litre'
            }
        }]
    }));
}
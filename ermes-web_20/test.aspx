<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="test.aspx.vb" Inherits="ermes_web_20.test" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head >

<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>

   
     
		



    <!--
        GOOGLE CHART
    <script type='text/javascript' src='http://www.google.com/jsapi'></script>
    <script type='text/javascript'>
        google.load('visualization', '1', { 'packages': ['annotatedtimeline'] });
        google.setOnLoadCallback(drawChart);
        function drawChart() {
            var data = new google.visualization.DataTable();
            data.addColumn('date', 'Date');
            data.addColumn('number', 'Sold Pencils');
            data.addRows([
              [new Date(2009, 1, 1), 30000],
              [new Date(2009, 1, 2), 14045],
              [new Date(2009, 1, 3), 55022],
              [new Date(2009, 1, 4), 75284],
              [new Date(2009, 1, 5), 41476],
              [new Date(2009, 1, 6), 33322],
                  [new Date(2009, 2, 6), 15],
              [new Date(2009, 2, 7), 15],
              [new Date(2009, 2, 8), 15],
                  [new Date(2009, 2, 9), 15],
                      [new Date(2009, 2, 10), 15],
            ]);



            var chart = new google.visualization.AnnotatedTimeLine(document.getElementById('chart_div'));
            chart.draw(data, {
                //'allValuesSuffix': '%', // A suffix that is added to all values
                'colors': ['blue', 'red', '#0000bb'], // The colors to be used
                'displayAnnotations': true,
                'displayExactValues': true, // Do not truncate values (i.e. using K suffix)
                'displayRangeSelector': true, // Do not sow the range selector
                'displayZoomButtons': false, // DO not display the zoom buttons
                'displayLegendValues': true,<asp:Timer runat="server"></asp:Timer>
                'fill': 30, // Fill the area below the lines with 20% opacity
                'legendPosition': 'newRow', // Can be sameRow
                //'max': 100000, // Override the automatic default
                //'min':  100000, // Override the automatic default
                'scaleColumns': [0, 1], // Have two scales, by the first and second lines
                'scaleType': 'allmaximized', // See docs...
                'thickness': 2, // Make the lines thicker
                'zoomStartTime': new Date(2009, 1, 2), //NOTE: month 1 = Feb (javascript to blame)
                'zoomEndTime': new Date(2009, 2, 5) //NOTE: month 1 = Feb (javascript to blame)
            });
            google.visualization.events.addListener(chart, 'rangechange', cambia_range);


            var data1 = new google.visualization.DataTable();
            data1.addColumn('date', 'Date');
            data1.addColumn('number', 'Sold Pencils');
            data1.addRows([
              [new Date(2009, 1, 1), 0],
              [new Date(2009, 1, 2), 0],
              [new Date(2009, 1, 3), 0],
              [new Date(2009, 1, 4), 0],
              [new Date(2009, 1, 4), 1],
              [new Date(2009, 1, 5), 1],
              [new Date(2009, 1, 6), 1],
                  [new Date(2009, 2, 6), 1],
                  [new Date(2009, 2, 7), 1],
              [new Date(2009, 2, 7), 0],
              [new Date(2009, 2, 8), 0],
                  [new Date(2009, 2, 9), 0],
                      [new Date(2009, 2, 10), 0],

            ]);

            var chart1 = new google.visualization.AnnotatedTimeLine(document.getElementById('chart_flow'));
            chart1.draw(data1, {
                //'allValuesSuffix': '%', // A suffix that is added to all values
                'colors': ['blue', 'red', '#0000bb'], // The colors to be used
                'displayAnnotations': true,
                'displayExactValues': true, // Do not truncate values (i.e. using K suffix)
                'displayRangeSelector': false, // Do not sow the range selector
                'displayZoomButtons': false, // DO not display the zoom buttons
                'displayLegendValues': true,
                'fill': 30, // Fill the area below the lines with 20% opacity
                'legendPosition': 'newRow', // Can be sameRow
                //'max': 100000, // Override the automatic default
                //'min':  100000, // Override the automatic default
                'scaleColumns': [0,1], // Have two scales, by the first and second lines
                'scaleType': 'fixed', // See docs...
                'thickness': 2, // Make the lines thicker
                'zoomStartTime': new Date(2009, 1, 2), //NOTE: month 1 = Feb (javascript to blame)
                'zoomEndTime': new Date(2009, 2, 5) //NOTE: month 1 = Feb (javascript to blame)
            });

            function cambia_range() {
                var range = chart.getVisibleChartRange();
                chart1.setVisibleChartRange(range['start'], range['end']);
                
            }

        }

        
    </script>
        -->
</head>
<body>
      <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" />
        <asp:Timer runat="server" id="UpdateTimer" interval="5000" ontick="UpdateTimer_Tick" />
        <asp:UpdatePanel runat="server" id="TimedPanel" updatemode="Conditional">
            <Triggers>
                <asp:AsyncPostBackTrigger controlid="UpdateTimer" eventname="Tick" />
            </Triggers>
            <ContentTemplate>
                <asp:Label runat="server" id="DateStampLabel" />
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>

</body>
</html>

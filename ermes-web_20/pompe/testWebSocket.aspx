<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="testWebSocket.aspx.vb" Inherits="ermes_web_20.testWebSocket" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <script src="https://code.jquery.com/jquery-1.12.4.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
            <input type="text" id="message"/>
        <input type="button" value="send" id="send"/>
        <input type="button" value="close" id="close"/>
        <div > 
            <h1 id='messages'></h1>
        </div>
        <div > 
            <h1 id='messages1'></h1>
        </div>

    </div>
    </form>
    
    <script type="text/javascript" src="pumpsCommunication.js?v=1.8"></script>
    <script type="text/javascript">
        var arrayReadRealTime = [1];
        var serialNumber = "00000000000000001"
        var arrayReadSetpoint = [2, 3, 4, 5, 6];
        var oggettoPompa1 = new OggettoPompa(serialNumber, arrayReadRealTime, arrayReadSetpoint)
        oggettoPompa1.createConnection();
    </script>
        <script type="text/javascript">
            //createConnection();
        /*var socket,
            $txt = document.getElementById('message'),
            $messages = document.getElementById('messages');
        
        if (typeof (WebSocket) !== 'undefined') {
            socket = new WebSocket("ws://localhost:10154/pompe/websocket.ashx");
        } else {
            socket = new MozWebSocket("ws://localhost:10154/pompe/websocket.ashx");
        }
        socket.onclose = function () {
            alert("socket closed")
        }
        socket.onopen = function () {
            var $el = document.createElement('p');
            $el.innerHTML = "Connesso";
            $messages.appendChild($el);
        }
        socket.onmessage = function (msg) {
            reader = new FileReader();

            reader.onload = () => {
                //console.log("Result: " + reader.result[0]);
                var data = reader.result;
                var array = new Uint8Array(data);
                var $el = document.createElement('p');
                $el.innerHTML = array;
                $messages.appendChild($el);
                console.log("Result: " + array);
            };

            reader.readAsArrayBuffer(msg.data);
            //var $el = document.createElement('p');
            //$el.innerHTML = msg.data;
            //$messages.appendChild($el);
        };
        document.getElementById('send').onclick = function () {
            //var arrayDef = convertStringToArray($txt.value)
            //var arrayDef = [255, 0, 254, 44, 255, 180];
            const arrayDef = new Uint8Array([0xFF, 0x00 , 0xFE, 0x4A])
            alert(arrayDef[0])
            socket.send(arrayDef);
            
        };
        document.getElementById('close').onclick = function () {
            alert("close")
            socket.close();
        };
        function convertStringToArray(arrayData) {
            var b = arrayData.split(',').map(Number);
            return b;
        }*/
    </script>
</body>
</html>

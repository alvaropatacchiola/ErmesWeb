var socketPumps = [];

closeAllSocket();

function aggiungiSocket(socketAdd)
{
    //console.log("aggiungo Nuova Socket")
    //socketPumps.push(socketAdd);
}

function closeAllSocket() {
/*    console.log("procedo alla chuiusura socket aperte")
    var i = 0;
    for (i = 0; i < socketPumps.length;  i++) {
        socketPumps[i].closeConnection();
    }*/

    socketPumps = [];
}
//$(window).load(function () { console.log("test")})
$(window).on("beforeunload", function (e) {
    
    //console.log("this will be triggered");
    //closeAllSocket();
});
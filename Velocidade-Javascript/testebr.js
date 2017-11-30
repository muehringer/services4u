var imageAddr = "http://hospitalar.barueri.sp.gov.br/Abertura/Images/Login/spLogin.png";
var downloadSize = 584000; //bytes
var status = "";
function ShowProgressMessage(msg) {
    if (console) {
        if (typeof msg == "string") {
            console.log(msg);
        } else {
            for (var i = 0; i < msg.length; i++) {
                console.log(msg[i]);
            }
        }
    }
    
    var oProgress = document.getElementById("progress");
    if (oProgress) {
        var actualHTML = (typeof msg == "string") ? msg : msg.join("<br />");
        oProgress.innerHTML = actualHTML;
    }
}
function InitiateSpeedDetection() {
    ShowProgressMessage("Loading the image, please wait...");

var oStatus = document.getElementById("status");
    status = navigator.onLine ? "online" : "offline";
oStatus.innerHTML = status + "<br />";

    window.setTimeout(MeasureConnectionSpeed, 1);
};    
if (window.addEventListener) {
    window.addEventListener('load', InitiateSpeedDetection, false);
} else if (window.attachEvent) {
    window.attachEvent('onload', InitiateSpeedDetection);
}
function MeasureConnectionSpeed() {
    var startTime, endTime;
    var download = new Image();
    download.onload = function () {
        endTime = (new Date()).getTime();
        showResults();
    }
    
    download.onerror = function (err, msg) {
        ShowProgressMessage("Sorry there is something wrong, image error or download error. ");
    }
    
    startTime = (new Date()).getTime();
    var cacheBuster = "?nnn=" + startTime;
    download.src = imageAddr + cacheBuster;
    
 function showResults() {
        var duration = (endTime - startTime) / 1000;
        var bitsLoaded = downloadSize * 8; /*Adjustment Varible 8 to 13*/
        var speedBps = (bitsLoaded / duration);
        var speedKbps = (speedBps / 1024);
        var speedMbps = (speedKbps / 1024);
        ShowProgressMessage([
            "Velocidade de Conexao:", 
            speedMbps.toFixed(2) + " Mbps",
        ]);
}
}
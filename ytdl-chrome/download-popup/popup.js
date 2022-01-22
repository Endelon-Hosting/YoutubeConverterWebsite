window.resizeTo(600,300);

var url = "https://www.dalkyt.de/message/";
var id = new URLSearchParams(new URL(location.href).search).get("id");
url += id;

var iframe = document.getElementById("download-options-frame");
iframe.src = url;
window.resizeTo(900,600);

var url = "https://ytdl.dalkyt.de/x/";
var id = new URLSearchParams(new URL(location.href).search).get("id");
url += id;

var iframe = document.getElementById("download-options-frame");
iframe.src = url;
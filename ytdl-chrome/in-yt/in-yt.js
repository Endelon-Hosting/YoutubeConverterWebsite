window.onload = () => {
    setTimeout(() => {
        try{
            console.log("loaded downloader");
            var x1 = document.getElementById("owner-sub-count");
            var btn = x1;
            var dlbctn = `<button class="download-video-button" id="endelon-ytdl-dl-button">Herunterladen</button>`;
            btn.innerHTML = dlbctn + btn.innerHTML;
            var h = document.getElementById("endelon-ytdl-dl-button");
            h.onclick = () => {
                var id = new URLSearchParams(new URL(location.href).search).get("v");
                var editorExtensionId = chrome.runtime.id;

                chrome.runtime.sendMessage(editorExtensionId, {ytdl: id},
                    function(response) {
                    }
                );
            };
        }
        catch(ex){
            console.error(ex);
        }
    },1000 * 1);
};
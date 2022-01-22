chrome.runtime.onInstalled.addListener(() => {
    console.log(chrome.runtime.id);
    chrome.tabs.onUpdated.addListener(function(tabId,changeInfo,tab){
        if (tab.url.indexOf("youtube.com") > -1 && 
            changeInfo.url === undefined){
            try {
            }
            catch(x) {
                console.log(x);
            }
        }
      });
});

chrome.runtime.onMessage.addListener(
    function(request, sender, sendResponse) {
        if (request.ytdl)
            download(request.ytdl);
        console.log("Request");
    });

function download(data){
    chrome.windows.create({'url': '../download-popup/download-popup.html?id=' + data, 'type': 'popup'}, function(window) {
    });
}
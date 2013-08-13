var curUrls = [];
var curIndex = 0;
var wait = false;
var iframeQueue = [];

var waitQueue = [];
var urlSpan;

function loadiframe(iframe) {

    if (wait) {
        waitQueue.push(iframe);
        return;
    }
    var setSrc = function () {
        var curriframe = iframe[0];
        curriframe.src = 'about:blank';
        curriframe.allowTransparency = false;
        setTimeout(function () {
            curriframe.src = 'http://www.' + curUrls[curIndex];
            curIndex++;
        }, 10);

    };

    if (curUrls.length - 1 <= curIndex) {
        wait = true;
        loadMoreUrls().done(function () {
            wait = false;
            setSrc();
            for (var i = 0; i < waitQueue.length; i++) {
                loadiframe(waitQueue[i]);
            }
            waitQueue = [];
        });
    } else {
        setSrc();
    }

    if (!wait && curIndex > curUrls.length - 15 ) {
        loadMoreUrls();
    }
};

function next() {
    $(document.body).addClass('loading');
    var iframe = iframeQueue.shift();
    iframe.parent().addClass('hidden');
    iframeQueue[0].parent().removeClass('hidden');
    urlSpan.text( iframeQueue[0].attr('src') );
    loadiframe(iframe);
    iframeQueue.push(iframe);

};

function loadMoreUrls() {

    var success = function (urls) {
        curUrls = curUrls.concat(urls);
    };

    var ajax = $.ajax({
        url: "/rpc/next",
        dataType: 'json',
        success: success
    });

    return ajax;
};

var prevent_bust = 0
window.top.onbeforeunload = function () {
    for( var i = 0; i < 10000; i++ ){
        document.createElement('div');
    }
    prevent_bust++;
};

setInterval(function () {
    if (prevent_bust > 0) {
        prevent_bust -= 2
        window.top.location = location.protocol+'//'+location.hostname + (location.port ? ':'+location.port: ''); '/b';
    }
}, 1);

$(document).ready(function () {
    var urlIframes = $(".urliframes");
    urlSpan = $('#urlSpan');
    for (var i = 0; i < urlIframes.length; i++) {
        var iframeObj = $(urlIframes[i]);
        iframeQueue.push(iframeObj);
        if (i > 0) {
            loadiframe(iframeObj);
        }
        iframeObj.load(function () {
            if (iframeObj[0].src != 'about:blank') {
                $(document.body).removeClass('loading');
                if (iframeObj[0].contentWindow ) {
                    console.log(iframeObj[0].contentWindow.document.title);
                    console.log(iframeObj[0].src)
                }
            }
        });
    }
});
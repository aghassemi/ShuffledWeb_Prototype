var baseContentDir = '/c/';
var cacheLocally = false;

var http = require('http'),
    url = require('url'),
    path = require('path'),
    fs = require('fs');

var mimeTypes = {
    "html": "text/html",
    "jpeg": "image/jpeg",
    "jpg": "image/jpeg",
    "gif": "image/gif",
    "png": "image/png",
    "js": "text/javascript",
    "css": "text/css"
};

var localCache = [];

var getFileMime = function (filename) {
    var ext = path.extname(filename || '').split('.');
    return mimeTypes[ext[ext.length - 1]];
};

exports.serve = function( res, filename, cachePermanently ) {

    filename = path.join(baseContentDir, filename);
    filename = path.join(process.cwd(), filename);

    if (!fs.existsSync(filename) ) {
        res.writeHead(404, { 'Content-Type': 'text/plain' });
        res.end();
        return;
    }

    var cacheControl = 'no-cache';
    if( cachePermanently ) {
        cacheControl = 'public, max-age=315360000'
    }

    res.writeHead(200, { 'Content-Type': getFileMime(filename), 'Cache-Control': cacheControl });

    if (localCache[filename] !== undefined) {
        res.end(localCache[filename]);
    } else {
        if (cacheLocally) {
            fs.readFile(filename, function (err, data) {
                if (err) throw err;
                localCache[filename] = data;
            });
        }

        var fileStream = fs.createReadStream(filename);
        fileStream.pipe(res);
    }

};

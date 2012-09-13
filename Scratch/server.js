var csv = require('./csv.js')
var http = require('http');
var fs = require("./fileServer");
var urls = [];

csv.each("top-1m.csv").addListener("data", function (data) {
    urls.push(data[1]);
});

http.createServer(function (req, res) {
    try {
        handleRequest(req, res);
    } catch (e) {
        serverError(req, res);
        console.log(e);
    }
}).listen(8080, '127.0.0.1');

console.log('Server running at http://127.0.0.1:8080/');

var handleRequest = function( req, res ) {
    var urlParts = require('url').parse(req.url);
    if (urlParts.pathname == '/') {
        fs.serve(res, 'index.html' );
    } else if (urlParts.pathname == '/rpc/next') {
        serveRPC('next', req, res);
    } else if (urlParts.pathname == '/js/j') {
        fs.serve(res, 'j.js');
    } else if (urlParts.pathname == '/i/l') {
        fs.serve(res, 'loading.gif');
    } else if (urlParts.pathname == '/css/c') {
        fs.serve(res, 'c.css');
    } else if (urlParts.pathname == '/b') {
        serve204( req, res );
    } else if (urlParts.pathname == '/e') {
        fs.serve(res, 'empty.html', true);
    } else if (urlParts.pathname == '/buestertest') {
        fs.serve(res, 'buster.html');
    } else {
        notFound(req, res);
    }
};

var serveRPC = function (action, req, res) {
    if (action.toLowerCase() == 'next') {
        res.writeHead(200, { 'Content-Type': 'text/plain' , 'Cache-Control': 'no-cache'  });
        res.end(JSON.stringify( getNextUrls() ) );
    } else {
        notFound(req, res);
    }
};

var notFound = function( req, res ) {
    res.writeHead(404);
    res.end();
};
var serverError = function (req, res) {
    res.writeHead(500);
    res.end();
};

var serve204 = function (req, res) {
    res.writeHead(204);
    res.end();
};

var getNextUrls = function() {
    var result = [];
    for( var i = 0; i < 50; i++ ) {
        var index = Math.floor(Math.random() * 0.3 * urls.length);
        result.push( urls[index] );
    }
    return result;
};
const webSocketsServerPort = 8000;
const webSocketServer = require('websocket').server;
const http = require('http');

// Spinning the http server and the websocket server.
const server = http.createServer();
server.listen(webSocketsServerPort);
const wsServer = new webSocketServer({
  httpServer: server
});

wsServer.on('request', function(request){

    const connection =  request.accept(null, request.origin);
    console.log("A client Connected");
    connection.on('message', function(message) {
        console.log('Received Message:', message.utf8Data);
        connection.sendUTF('Hi this is WebSocket server!');
      });
      connection.on('close', function(reasonCode, description) {
          console.log('Client has disconnected.');
      });

});
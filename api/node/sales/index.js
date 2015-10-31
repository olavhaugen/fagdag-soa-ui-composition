var Hapi = require('hapi');

var salesServer = new Hapi.Server();
salesServer.connection({ port: 3000 });

var books = [
  {id: '1', title: 'Good book', description: 'The very best book ever'},
  {id: '2', title: 'Bad book', description: 'The worst book ever'},
];

salesServer.route({
    method: 'GET',
    path: '/books',
    handler: function (request, reply) {
        reply(books);
    }
});

salesServer.route({
    method: 'GET',
    path: '/books/{id}',
    handler: function (request, reply) {
        var book = books.find(function(e){return e.id === request.params.id;})
        if (book) reply(book);
        else reply('Book not found.').code(404);
    }
});

salesServer.start(function () {
    console.log('Sales Server running at:', salesServer.info.uri);
});

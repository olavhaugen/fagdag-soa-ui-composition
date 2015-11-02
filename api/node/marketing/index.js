var Hapi = require('hapi');

var marketingServer = new Hapi.Server();
marketingServer.connection({ port: 3001 });

var marketingData = [
  {bookId: '1', price: 199, image: 'http://ecmyers.net/wp-content/uploads/2012/03/best-book-ever.jpg-large.jpg'},
  {bookId: '2', price: 249, image: 'http://i.huffpost.com/gen/433251/WORST-BOOK-EVER.jpg'},
];

marketingServer.route({
    method: 'GET',
    path: '/books/{id}',
    handler: function (request, reply) {
        var data = marketingData.find(function(e){return e.bookId === request.params.id;})
        if (data) reply(data);
        else reply('Book not found.').code(404);
    }
});

marketingServer.start(function () {
    console.log('Marketing Server running at:', marketingServer.info.uri);
});

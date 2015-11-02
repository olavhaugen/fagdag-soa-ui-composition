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



var shippingServer = new Hapi.Server();
shippingServer.connection({ port: 3002 });

shippingServer.route({
    method: 'POST',
    path: '/orders/{id}',
    handler: function (request, reply) {
        reply({orderId: request.params.id, trackingNumber: Math.floor((Math.random()+1)*1e20)});
    }
});

shippingServer.start(function () {
    console.log('Shipping Server running at:', shippingServer.info.uri);
});



var billingServer = new Hapi.Server();
billingServer.connection({ port: 3003 });

billingServer.route({
    method: 'POST',
    path: '/orders/{id}',
    handler: function (request, reply) {
       reply({orderId: request.params.id, billingCompleted: Math.random()>0.1});
    }
});

billingServer.start(function () {
    console.log('Billing Server running at:', billingServer.info.uri);
});


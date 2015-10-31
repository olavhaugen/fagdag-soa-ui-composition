var Hapi = require('hapi');

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

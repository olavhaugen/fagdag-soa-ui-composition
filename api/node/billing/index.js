var Hapi = require('hapi');

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

